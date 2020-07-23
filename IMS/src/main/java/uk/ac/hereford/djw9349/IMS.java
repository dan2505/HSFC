package uk.ac.hereford.djw9349;

import uk.ac.hereford.djw9349.managers.StockManager;
import uk.ac.hereford.djw9349.managers.UserManager;
import uk.ac.hereford.djw9349.ui.Login;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;

public class IMS {
    public static UserManager userManager;
    public static StockManager stockManager;

    public static void main(String... args) throws IOException, InvalidKeySpecException, NoSuchAlgorithmException {
        // Initialise managers
        userManager = new UserManager();
        stockManager = new StockManager();

        Login login = new Login();
    }
}
