package uk.ac.hereford.djw9349.ui.supplier;

import uk.ac.hereford.djw9349.objects.Address;
import uk.ac.hereford.djw9349.objects.Supplier;
import uk.ac.hereford.djw9349.ui.users.*;
import lombok.SneakyThrows;
import uk.ac.hereford.djw9349.IMS;
import uk.ac.hereford.djw9349.enums.Role;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class AddSupplier implements ActionListener {
    private JFrame frame = new JFrame("Add Supplier");
    private JPanel panel = new JPanel();
    private JLabel nameLabel;
    private JTextField nameField;
    private JLabel addressLabel;
    private JLabel addressNameLabel;
    private JTextField addressNameField;
    private JLabel addressLineOneLabel;
    private JTextField addressLineOneField;
    private JLabel addressLineTwoLabel;
    private JTextField addressLineTwoField;
    private JLabel addressPostcodeLabel;
    private JTextField addressPostcodeField;
    private JLabel phoneLabel;
    private JTextField phoneField;
    private JButton button;
    private JLabel label;

    public AddSupplier() {
        Dimension size = new Dimension(300, 245);
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

        addressLabel = new JLabel("Address");
        addressLabel.setFont(new Font("Segoe UI", Font.CENTER_BASELINE, 15));
        addressLabel.setForeground(new Color(0, 0, 0));
        addressLabel.setBounds(10, 50, 80, 25);
        panel.add(addressLabel);

        addressNameLabel = new JLabel("Name");
        addressNameLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        addressNameLabel.setForeground(new Color(0, 0, 0));
        addressNameLabel.setBounds(10, 70, 80, 25);
        panel.add(addressNameLabel);

        addressNameField = new JTextField(20);
        addressNameField.setBounds(100, 70, 165, 25);
        panel.add(addressNameField);

        addressLineOneLabel = new JLabel("Line One");
        addressLineOneLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        addressLineOneLabel.setForeground(new Color(0, 0, 0));
        addressLineOneLabel.setBounds(10, 90, 80, 25);
        panel.add(addressLineOneLabel);

        addressLineOneField = new JTextField(20);
        addressLineOneField.setBounds(100, 90, 165, 25);
        panel.add(addressLineOneField);

        addressLineTwoLabel = new JLabel("Line Two");
        addressLineTwoLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        addressLineTwoLabel.setForeground(new Color(0, 0, 0));
        addressLineTwoLabel.setBounds(10, 110, 80, 25);
        panel.add(addressLineTwoLabel);

        addressLineTwoField = new JTextField(20);
        addressLineTwoField.setBounds(100, 110, 165, 25);
        panel.add(addressLineTwoField);

        addressPostcodeLabel = new JLabel("Postcode");
        addressPostcodeLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        addressPostcodeLabel.setForeground(new Color(0, 0, 0));
        addressPostcodeLabel.setBounds(10, 130, 80, 25);
        panel.add(addressPostcodeLabel);

        addressPostcodeField = new JTextField(20);
        addressPostcodeField.setBounds(100, 130, 165, 25);
        panel.add(addressPostcodeField);

        phoneLabel = new JLabel("Phone");
        phoneLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        phoneLabel.setForeground(new Color(0, 0, 0));
        phoneLabel.setBounds(10, 160, 80, 25);
        panel.add(phoneLabel);

        phoneField = new JTextField(20);
        phoneField.setBounds(100, 160, 165, 25);
        panel.add(phoneField);

        button = new JButton("Add Supplier");
        button.setBounds(10, 190, 150, 25);
        button.addActionListener(this);
        panel.add(button);

        label = new JLabel("");
        label.setFont(new Font("Segoe UI", Font.PLAIN, 10));
        label.setForeground(new Color(0, 0, 0));
        label.setBounds(10, 220, 300, 25);
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
        String addressName = addressNameField.getText();
        String addressLineOne = addressLineOneField.getText();
        String addressLineTwo = addressLineTwoField.getText();
        String addressPostcode = addressPostcodeField.getText();
        String phone = phoneField.getText();

        if ((name.isEmpty()) || (addressName.isEmpty()) || (addressLineOne.isEmpty()) || (addressLineTwo.isEmpty()) || (addressPostcode.isEmpty()) || (phone.isEmpty())) {
            label.setText("Please provide an input to all fields.");
            return;
        }

        if (IMS.supplierManager.alreadyExists(name)) {
            label.setText("This supplier already exists!");
            return;
        }

        IMS.supplierManager.addSupplier(new Supplier(name, new Address(addressName, addressLineOne, addressLineTwo, addressPostcode), phone));
        frame.setVisible(false);
        SupplierManagement.main(null);
    }
}