import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Main implements ActionListener {
    private static JFrame frame;
    private static JPanel panel;

    private static JLabel userLabel;
    private static JTextField userText;

    private static JLabel passwordLabel;
    private static JPasswordField passwordText;

    private static JButton button;
    private static JLabel successLabel;

    public static void main(String[] args) {
        frame = new JFrame();
        frame.setSize(350, 200);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        panel = new JPanel();
        panel.setLayout(null);
        frame.add(panel);

        userLabel = new JLabel("Username");
        userLabel.setBounds(10, 20, 80, 25);
        panel.add(userLabel);

        userText = new JTextField(20);
        userText.setBounds(100,20,165,25);
        panel.add(userText);

        passwordLabel = new JLabel("Password");
        passwordLabel.setBounds(10,50,80,25);
        panel.add(passwordLabel);

        passwordText = new JPasswordField(20);
        passwordText.setBounds(100,50,165,25);
        panel.add(passwordText);

        button = new JButton("Login");
        button.setBounds(10,80,80,25);
        button.addActionListener(new Main());
        panel.add(button);

        successLabel = new JLabel("");
        successLabel.setBounds(10,110,300,25);
        panel.add(successLabel);

        frame.setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent event) {
        String username = userText.getText();
        String password = passwordText.getText();

        if(username.equals("Dan") && password.equals("password123")) {
            successLabel.setText("Login successful!");
        }
    }
}
