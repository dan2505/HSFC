package uk.ac.hereford.djw9349.objects;

import lombok.Getter;

@Getter
public class User {
    private String username;
    private String password;
    private Role role;

    public User(String username, String password, Role role) {
        this.username = username;
        this.password = password;
        this.role = role;
    }
}
