package uk.ac.hereford.djw9349.ui;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import lombok.SneakyThrows;
import uk.ac.hereford.djw9349.IMS;
import uk.ac.hereford.djw9349.ui.Home;

public class AddUser implements ActionListener {
   private JFrame frame = new JFrame("Add User");
    private JPanel panel = new JPanel();
    private JLabel userLabel;
    private JTextField userField;
    private JLabel passwordLabel;
    private JPasswordField passwordField;
    private JLabel roleLabel;
    private JComboBox roleSelector;
    private JButton button;
    private JLabel label;

    public AddUser() {
        Dimension size = new Dimension(300, 150);
        panel.setSize(size);
        panel.setPreferredSize(size);
        panel.setBackground(new Color(247, 247, 247));
        panel.setLayout(null);

        userLabel = new JLabel("Username");
        userLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        userLabel.setForeground(new Color(0, 0, 0));
        userLabel.setBounds(10, 20, 80, 25);
        panel.add(userLabel);

        userField = new JTextField(20);
        userField.setBounds(100, 20, 165, 25);
        panel.add(userField);

        passwordLabel = new JLabel("Password");
        passwordLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        passwordLabel.setForeground(new Color(0, 0, 0));
        passwordLabel.setBounds(10, 50, 80, 25);
        panel.add(passwordLabel);

        passwordField = new JPasswordField(20);
        passwordField.setBounds(100, 50, 165, 25);
        panel.add(passwordField);
        
        roleLabel = new JLabel("Role");
        roleLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        roleLabel.setForeground(new Color(0, 0, 0));
        roleLabel.setBounds(10, 80, 80, 25);
        panel.add(roleLabel);
        
        roleSelector = new JComboBox();
        roleSelector.addItem("OWNER");
        roleSelector.addItem("MANAGER");
        roleSelector.addItem("STAFF");
        roleSelector.setBounds(100, 80, 165, 25);
        panel.add(roleSelector);

        button = new JButton("Add User");
        button.setBounds(10, 120, 120, 25);
        button.addActionListener(this);
        panel.add(button);

        label = new JLabel("");
        label.setFont(new Font("Segoe UI", Font.PLAIN, 10));
        label.setForeground(new Color(0, 0, 0));
        label.setBounds(10, 110, 300, 25);
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

        if (IMS.userManager.checkLogin(username, password)) {
            label.setText("Welcome back, " + username);
            frame.setVisible(false);
            Home.main(null);
            // Handle login.
        } else {
            label.setText("Invalid username / password.");
        }
    }
    
    
    
}
