package uk.ac.hereford.djw9349.managers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import org.apache.commons.codec.binary.Base64;
import uk.ac.hereford.djw9349.objects.Role;
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
    private Gson gson = new Gson();
    private ArrayList<User> users = new ArrayList<User>();

    public UserManager() throws IOException {
        initialise();
    }

    private void initialise() throws IOException {
        File file = new File("login.json");
        if (!file.exists()) file.createNewFile();

        Type type = new TypeToken<ArrayList<User>>() {}.getType();
        List<User> local = new Gson().fromJson(new FileReader("login.json"), type);
        users.addAll(local);
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

    public String getHash(String password) throws NoSuchAlgorithmException, InvalidKeySpecException {
        byte[] salt = SecureRandom.getInstance("SHA1PRNG").generateSeed(32);
        return Base64.encodeBase64String(salt) + "$" + hashing(password, salt);
    }

    public boolean isValid(String password, String store) throws InvalidKeySpecException, NoSuchAlgorithmException {
        String[] components = store.split("\\$");
        return hashing(password, Base64.decodeBase64(components[0])).equals(components[1]);
    }

    private String hashing(String password, byte[] salt) throws NoSuchAlgorithmException, InvalidKeySpecException {
        SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA512");
        SecretKey key = factory.generateSecret(new PBEKeySpec(password.toCharArray(), salt, (20 * 1000), 256));
        return Base64.encodeBase64String(key.getEncoded());
    }
}