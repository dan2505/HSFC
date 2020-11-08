package uk.ac.hereford.djw9349.managers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import org.apache.commons.codec.binary.Base64;
import uk.ac.hereford.djw9349.enums.Role;
import uk.ac.hereford.djw9349.objects.User;

import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.PBEKeySpec;
import java.io.*;
import java.lang.reflect.Type;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.security.spec.InvalidKeySpecException;
import java.util.ArrayList;
import java.util.List;

public class UserManager {
    public ArrayList<User> users = new ArrayList<User>();
    public User loggedIn = null;

    public UserManager() throws IOException {
        initialise();
    }

    private void initialise() throws IOException {
        File file = new File("login.json");
        if (!file.exists()) file.createNewFile();

        Type type = new TypeToken<ArrayList<User>>() {
        }.getType();
        List<User> local = new Gson().fromJson(new FileReader("login.json"), type);
        if (local != null) users.addAll(local);
    }

    private void save() throws IOException {
        try (Writer writer = new FileWriter("login.json")) {
            Gson builder = new GsonBuilder().create();
            builder.toJson(users, writer);
        }
    }

    public void addUser(String username, String password, Role role) throws InvalidKeySpecException, NoSuchAlgorithmException, IOException {
        users.add(new User(username, getHash(password), role));
        save();
    }

    public void removeUser(User user) throws IOException {
        users.remove(user);
        save();
    }

    public void removeUser(String user) throws IOException {
        removeUser(getUserFromString(user));
    }

    private User getUserFromString(String username) {
        for (User user : users) if (user.getUsername().equals(username)) return user;
        return null;
    }

    public boolean alreadyExists(String username) {
        for (User user : users) if (user.getUsername().equals(username)) return true;
        return false;
    }

    public boolean checkLogin(String username, String password) throws InvalidKeySpecException, NoSuchAlgorithmException {
        // Iterate over the users loaded.
        for (User user : users) {
            // Check if the inputted username equals that of the one currently being iterated.
            if (user.getUsername().equals(username)) {
                // Check that the inputted password equals the one currently being iterated.
                if (isValid(password, user.getPassword())) {
                    // Set the user that is logged in to the one currently in the iteration.
                    loggedIn = user;
                    // Return true as login was successful.
                    return true;
                }
            }
            // Continue on to next username.
            continue;
        }
        // Return false as login was unsuccessful.
        return false;
    }

    private String getHash(String password) throws NoSuchAlgorithmException, InvalidKeySpecException {
        // Generate a SHA1PRNG salt with 32 bytes.
        byte[] salt = SecureRandom.getInstance("SHA1PRNG").generateSeed(32);
        // Return the salt and hashed password separated by a $ sign.
        return Base64.encodeBase64String(salt) + "$" + hashing(password, salt);
    }

    private boolean isValid(String password, String store) throws InvalidKeySpecException, NoSuchAlgorithmException {
        // Split the stored password by the $ sign to get the salt and hashed password separate.
        String[] components = store.split("\\$");
        // Hash the password again with the salt and check that it equals the stored hash.
        return hashing(password, Base64.decodeBase64(components[0])).equals(components[1]);
    }

    private String hashing(String password, byte[] salt) throws NoSuchAlgorithmException, InvalidKeySpecException {
        // Generate the SecretKeyFactory for PBKDF2WithHmacSHA512.
        SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA512");
        // Generate the secret key / hash for the password & salt.
        SecretKey key = factory.generateSecret(new PBEKeySpec(password.toCharArray(), salt, (20 * 1000), 256));
        // Return the hash as a string for storage.
        return Base64.encodeBase64String(key.getEncoded());
    }
}