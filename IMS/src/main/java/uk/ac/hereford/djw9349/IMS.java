package uk.ac.hereford.djw9349;

import com.google.gson.Gson;
import lombok.Getter;
import uk.ac.hereford.djw9349.managers.UserManager;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;

public class IMS {
    @Getter
    private Gson gson = new Gson();

    public static void main(String... args) throws IOException, InvalidKeySpecException, NoSuchAlgorithmException {
        UserManager manager = new UserManager();
    }
}
