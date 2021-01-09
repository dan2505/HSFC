package uk.ac.hereford.djw9349;

import uk.ac.hereford.djw9349.managers.DeliveryManager;
import uk.ac.hereford.djw9349.managers.StockManager;
import uk.ac.hereford.djw9349.managers.UserManager;
import uk.ac.hereford.djw9349.ui.Login;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;
import java.util.Date;
import uk.ac.hereford.djw9349.enums.Category;
import uk.ac.hereford.djw9349.enums.Status;
import uk.ac.hereford.djw9349.managers.SupplierManager;
import uk.ac.hereford.djw9349.objects.Address;
import uk.ac.hereford.djw9349.objects.Delivery;
import uk.ac.hereford.djw9349.objects.Ingredient;
import uk.ac.hereford.djw9349.objects.Supplier;

public class IMS {
    public static UserManager userManager;
    public static StockManager stockManager;
    public static DeliveryManager deliveryManager;
    public static SupplierManager supplierManager;

    public static void main(String... args) throws IOException, InvalidKeySpecException, NoSuchAlgorithmException {
        // Initialise managers
        userManager = new UserManager();
        stockManager = new StockManager();
        deliveryManager = new DeliveryManager();
        supplierManager = new SupplierManager();
        
        supplierManager.addSupplier(new Supplier("Douglas Willis", new Address("5", "Grange Industrial Estate", "Cwmbran", "NP44 8HQ"), "01633 877777"));
        Delivery delivery = new Delivery(Status.PENDING, new Date(), "Douglas Willis");
        delivery.addIngredient(new Ingredient("8oz Rump Steak", 5, Category.MEAT));
        deliveryManager.addDelivery(delivery);
        Login login = new Login();
        
    }
}
