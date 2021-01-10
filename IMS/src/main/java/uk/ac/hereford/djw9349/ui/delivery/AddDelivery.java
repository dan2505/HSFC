package uk.ac.hereford.djw9349.ui.delivery;

import uk.ac.hereford.djw9349.enums.Status;
import uk.ac.hereford.djw9349.objects.Delivery;
import uk.ac.hereford.djw9349.ui.users.*;
import lombok.SneakyThrows;
import uk.ac.hereford.djw9349.IMS;
import uk.ac.hereford.djw9349.enums.Role;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Vector;

public class AddDelivery implements ActionListener {
    private JFrame frame = new JFrame("Add Delivery");
    private JPanel panel = new JPanel();
    private JLabel supplierLabel;
    private JTextField supplierField;
    private JLabel dateLabel;
    private JTextField dateField;
    private JLabel timeLabel;
    private JTextField timeField;
    private JLabel stockLabel;
    private JButton addButton;
    private JButton button;
    private JLabel label;

    public AddDelivery() {
        Dimension size = new Dimension(350, 155);
        panel.setSize(size);
        panel.setPreferredSize(size);
        panel.setBackground(new Color(247, 247, 247));
        panel.setLayout(null);

        supplierLabel = new JLabel("Supplier");
        supplierLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        supplierLabel.setForeground(new Color(0, 0, 0));
        supplierLabel.setBounds(10, 20, 80, 25);
        panel.add(supplierLabel);

        supplierField = new JTextField(20);
        supplierField.setBounds(170, 20, 165, 25);
        panel.add(supplierField);

        dateLabel = new JLabel("Date (dd/mm/yy)");
        dateLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        dateLabel.setForeground(new Color(0, 0, 0));
        dateLabel.setBounds(10, 50, 150, 25);
        panel.add(dateLabel);

        dateField = new JTextField(20);
        dateField.setBounds(170, 50, 165, 25);
        panel.add(dateField);

        timeLabel = new JLabel("time (hh:mm)");
        timeLabel.setFont(new Font("Segoe UI", Font.PLAIN, 15));
        timeLabel.setForeground(new Color(0, 0, 0));
        timeLabel.setBounds(10, 70, 150, 25);
        panel.add(timeLabel);

        timeField = new JTextField(20);
        timeField.setBounds(170, 70, 165, 25);
        panel.add(timeField);

        button = new JButton("Add Delivery");
        button.setBounds(10, 100, 150, 25);
        button.addActionListener(this);
        panel.add(button);

        label = new JLabel("");
        label.setFont(new Font("Segoe UI", Font.PLAIN, 10));
        label.setForeground(new Color(0, 0, 0));
        label.setBounds(10, 130, 300, 25);
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
        String supplier = supplierField.getText();
        String date = dateField.getText();
        String time = timeField.getText();

        if ((supplier.isEmpty()) || (date.isEmpty()) || (time.isEmpty())) {
            label.setText("Please provide the appropriate fields.");
            return;
        }

        if (!IMS.supplierManager.alreadyExists(supplier)) {
            label.setText("This supplier does not exist!");
            return;
        }

        Date result = new Date();
        try {
            DateFormat formatter = new SimpleDateFormat("dd/MM/yy HH:mm");
            String tempDate = date + " " + time;
            result = formatter.parse(tempDate);
        } catch (ParseException e) {
            label.setText("Invalid date / time.");
            return;
        }

        IMS.deliveryManager.addDelivery(new Delivery(Status.PENDING, result, supplier));
        frame.setVisible(false);
        DeliveryManagement.main(null);
    }
}