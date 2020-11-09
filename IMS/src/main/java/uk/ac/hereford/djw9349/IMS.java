package uk.ac.hereford.djw9349;

import uk.ac.hereford.djw9349.enums.Status;
import uk.ac.hereford.djw9349.managers.DeliveryManager;
import uk.ac.hereford.djw9349.managers.StockManager;
import uk.ac.hereford.djw9349.managers.UserManager;
import uk.ac.hereford.djw9349.objects.*;
import uk.ac.hereford.djw9349.ui.Login;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;
import java.util.ArrayList;
import java.util.Date;

public class IMS {
    public static UserManager userManager;
    public static StockManager stockManager;
    public static DeliveryManager deliveryManager;

    public static void main(String... args) throws IOException, InvalidKeySpecException, NoSuchAlgorithmException {
        // Initialise managers
        userManager = new UserManager();
        stockManager = new StockManager();
        deliveryManager = new DeliveryManager();

        Login login = new Login();
    }
}
