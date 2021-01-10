package uk.ac.hereford.djw9349.ui.stock;

import uk.ac.hereford.djw9349.ui.users.*;
import lombok.SneakyThrows;
import uk.ac.hereford.djw9349.IMS;
import uk.ac.hereford.djw9349.enums.Role;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class AddStock implements ActionListener {
    private JFrame frame = new JFrame("Add Stock");
    private JPanel panel = new JPanel();
    private JLabel userLabel;
    private JTextField userField;
    private JLabel passwordLabel;
    private JPasswordField passwordField;
    private JLabel roleLabel;
    private JComboBox roleSelector;
    private JButton button;
    private JLabel label;

    public AddStock() {
        Dimension size = new Dimension(300, 175);
        panel.setSize(size);
        panel.setPreferredSize(size);
        panel.setBackground(new Color(247, 247, 247));
        panel.setLayout(null);

        userLabel = new JLabel("Name");
        userLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        userLabel.setForeground(new Color(0, 0, 0));
        userLabel.setBounds(10, 20, 80, 25);
        panel.add(userLabel);

        userField = new JTextField(20);
        userField.setBounds(100, 20, 165, 25);
        panel.add(userField);

        passwordLabel = new JLabel("Quantity");
        passwordLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        passwordLabel.setForeground(new Color(0, 0, 0));
        passwordLabel.setBounds(10, 50, 80, 25);
        panel.add(passwordLabel);

        passwordField = new JPasswordField(20);
        passwordField.setBounds(100, 50, 165, 25);
        panel.add(passwordField);

        roleLabel = new JLabel("Category");
        roleLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        roleLabel.setForeground(new Color(0, 0, 0));
        roleLabel.setBounds(10, 80, 80, 25);
        panel.add(roleLabel);

        roleSelector = new JComboBox();
        roleSelector.addItem("MEAT + FISH");
        roleSelector.addItem("FRUIT + VEG");
        roleSelector.addItem("HERBS + SPICES");
        roleSelector.addItem("BAKERY");
        roleSelector.addItem("DAIRY");
        roleSelector.addItem("PASTA");
        roleSelector.setBounds(100, 80, 165, 25);
        panel.add(roleSelector);

        button = new JButton("Add Stock");
        button.setBounds(10, 120, 150, 25);
        button.addActionListener(this);
        panel.add(button);

        label = new JLabel("");
        label.setFont(new Font("Segoe UI", Font.PLAIN, 10));
        label.setForeground(new Color(0, 0, 0));
        label.setBounds(10, 150, 300, 25);
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
        String username = userField.getText();
        String password = passwordField.getText();
        String role = roleSelector.getSelectedItem().toString();
        if ((username.isEmpty()) || (password.isEmpty())) {
            label.setText("Please provide the appropriate fields.");
            return;
        }

        if (IMS.userManager.alreadyExists(username)) {
            label.setText("This user already exists!");
            return;
        }

        IMS.userManager.addUser(username, password, Role.valueOf(role));
        frame.setVisible(false);
        UserManagement.main(null);
    }
}