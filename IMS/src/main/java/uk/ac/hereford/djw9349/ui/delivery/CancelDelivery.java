package uk.ac.hereford.djw9349.ui.delivery;

import uk.ac.hereford.djw9349.objects.Delivery;
import uk.ac.hereford.djw9349.ui.users.*;
import lombok.SneakyThrows;
import uk.ac.hereford.djw9349.IMS;
import uk.ac.hereford.djw9349.objects.User;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class CancelDelivery implements ActionListener {
    private JFrame frame = new JFrame("Cancel Delivery");
    private JPanel panel = new JPanel();
    private JLabel userLabel;
    private JTextField userField;
    private JLabel passwordLabel;
    private JPasswordField passwordField;
    private JLabel roleLabel;
    private JComboBox roleSelector;
    private JButton button;
    private JLabel label;

    public CancelDelivery() {
        Dimension size = new Dimension(300, 100);
        panel.setSize(size);
        panel.setPreferredSize(size);
        panel.setBackground(new Color(247, 247, 247));
        panel.setLayout(null);

        userLabel = new JLabel("Delivery");
        userLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        userLabel.setForeground(new Color(0, 0, 0));
        userLabel.setBounds(10, 20, 80, 25);
        panel.add(userLabel);

        roleSelector = new JComboBox();
        for (Delivery delivery : IMS.deliveryManager.getDeliveries()) roleSelector.addItem(delivery.getSupplier() + " - " + delivery.getDate());
        roleSelector.setBounds(100, 20, 165, 25);
        panel.add(roleSelector);

        button = new JButton("Cancel Delivery");
        button.setBounds(10, 50, 150, 25);
        button.addActionListener(this);
        panel.add(button);

        label = new JLabel("");
        label.setFont(new Font("Segoe UI", Font.PLAIN, 10));
        label.setForeground(new Color(0, 0, 0));
        label.setBounds(10, 80, 300, 25);
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
        Object role = roleSelector.getSelectedItem();
        if (role == null) {
            label.setText("Please select a delivery.");
            return;
        }

        IMS.deliveryManager.cancelDelivery(IMS.deliveryManager.getDeliveryFromString(role.toString().split(" - ")[1]));
        frame.setVisible(false);
        DeliveryManagement.main(null);
    }
}