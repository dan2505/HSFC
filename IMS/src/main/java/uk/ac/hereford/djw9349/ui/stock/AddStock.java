package uk.ac.hereford.djw9349.ui.stock;

import uk.ac.hereford.djw9349.enums.Category;
import uk.ac.hereford.djw9349.objects.Delivery;
import uk.ac.hereford.djw9349.objects.Ingredient;
import uk.ac.hereford.djw9349.objects.User;
import uk.ac.hereford.djw9349.ui.users.*;
import lombok.SneakyThrows;
import uk.ac.hereford.djw9349.IMS;
import uk.ac.hereford.djw9349.enums.Role;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Objects;

public class AddStock implements ActionListener {
    private JFrame frame = new JFrame("Add Stock");
    private JPanel panel = new JPanel();
    private JLabel nameLabel;
    private JTextField nameField;
    private JLabel quantityLabel;
    private JTextField quantityField;
    private JLabel categoryLabel;
    private JComboBox categorySelector;
    private JLabel deliveryLabel;
    private JComboBox deliverySelector;
    private JButton button;
    private JLabel label;

    public AddStock() {
        Dimension size = new Dimension(300, 175);
        panel.setSize(size);
        panel.setPreferredSize(size);
        panel.setBackground(new Color(247, 247, 247));
        panel.setLayout(null);

        nameLabel = new JLabel("Name");
        nameLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        nameLabel.setForeground(new Color(0, 0, 0));
        nameLabel.setBounds(10, 20, 80, 25);
        panel.add(nameLabel);

        nameField = new JTextField(20);
        nameField.setBounds(100, 20, 165, 25);
        panel.add(nameField);

        quantityLabel = new JLabel("Quantity");
        quantityLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        quantityLabel.setForeground(new Color(0, 0, 0));
        quantityLabel.setBounds(10, 50, 80, 25);
        panel.add(quantityLabel);

        quantityField = new JTextField(20);
        quantityField.setBounds(100, 50, 165, 25);
        panel.add(quantityField);

        categoryLabel = new JLabel("Category");
        categoryLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        categoryLabel.setForeground(new Color(0, 0, 0));
        categoryLabel.setBounds(10, 80, 80, 25);
        panel.add(categoryLabel);

        categorySelector = new JComboBox();
        categorySelector.addItem("MEAT + FISH");
        categorySelector.addItem("FRUIT + VEG");
        categorySelector.addItem("HERBS + SPICES");
        categorySelector.addItem("BAKERY");
        categorySelector.addItem("DAIRY");
        categorySelector.addItem("PASTA");
        categorySelector.setBounds(100, 80, 165, 25);
        panel.add(categorySelector);

        deliveryLabel = new JLabel("Delivery");
        deliveryLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        deliveryLabel.setForeground(new Color(0, 0, 0));
        deliveryLabel.setBounds(10, 110, 80, 25);
        panel.add(deliveryLabel);

        deliverySelector = new JComboBox();
        deliverySelector.addItem("None");
        for (Delivery delivery : IMS.deliveryManager.getDeliveries()) deliverySelector.addItem(delivery.getSupplier() + " - " + delivery.getDate());
        deliverySelector.setBounds(100, 110, 165, 25);
        panel.add(deliverySelector);

        button = new JButton("Add Stock");
        button.setBounds(10, 140, 150, 25);
        button.addActionListener(this);
        panel.add(button);

        label = new JLabel("");
        label.setFont(new Font("Segoe UI", Font.PLAIN, 10));
        label.setForeground(new Color(0, 0, 0));
        label.setBounds(10, 160, 300, 25);
        panel.add(label);

        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setResizable(false);
        frame.setLocationRelativeTo(null);
        frame.add(panel);
        frame.pack();
        frame.setVisible(true);
    }

    @SneakyThrows
    public void actionPerformed(ActionEvent event) {
        String name = nameField.getText();
        String quantity = quantityField.getText();
        String category = Objects.requireNonNull(categorySelector.getSelectedItem()).toString();
        if ((name.isEmpty()) || (quantity.isEmpty())) {
            label.setText("Please provide the appropriate fields.");
            return;
        }

        if (category.contains("MEAT")) category = "MEAT";
        if (category.contains("FRUIT")) category = "FRUIT";
        if (category.contains("HERBS")) category = "HERBSANDSPICES";

        if (!Objects.requireNonNull(deliverySelector.getSelectedItem()).toString().equals("None")) {
            Delivery delivery = IMS.deliveryManager.getDeliveryFromString(deliverySelector.getSelectedItem().toString());
            boolean found = false;
            for (Ingredient ingredient : delivery.getArray()) {
                if (ingredient.getName().equals(name)) {
                    ingredient.setQuantity(ingredient.getQuantity() + Integer.parseInt(quantity));
                    found = true;
                    break;
                }
            }

            if (found = false) {
                delivery.addIngredient(new Ingredient(name, Integer.valueOf(quantity), Category.valueOf(category)));
            }
        } else {
            if (IMS.stockManager.alreadyExists(name)) {
                Ingredient ingredient = IMS.stockManager.getStockFromString(name);
                IMS.stockManager.changeQuantity(ingredient, Integer.valueOf(quantity));
                StockManagement.main(null);
                return;
            }

            IMS.stockManager.addStock(new Ingredient(name, Integer.valueOf(quantity), Category.valueOf(category)));
            frame.setVisible(false);
            StockManagement.main(null);
        }
    }
}