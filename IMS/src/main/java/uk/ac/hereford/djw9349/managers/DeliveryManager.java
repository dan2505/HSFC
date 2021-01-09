package uk.ac.hereford.djw9349.managers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import uk.ac.hereford.djw9349.objects.Delivery;

import java.io.*;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

public class DeliveryManager {
    private ArrayList<Delivery> deliveries = new ArrayList<Delivery>();

    public DeliveryManager() throws IOException {
        initialise();
    }

    private void initialise() throws IOException {
        File file = new File("delivery.json");
        if (!file.exists()) file.createNewFile();

        Type type = new TypeToken<ArrayList<Delivery>>() {
        }.getType();
        List<Delivery> local = new Gson().fromJson(new FileReader("delivery.json"), type);
        if (local != null) deliveries.addAll(local);
    }

    private void save() throws IOException {
        try (Writer writer = new FileWriter("delivery.json")) {
            Gson builder = new GsonBuilder().create();
            builder.toJson(deliveries, writer);
        }
    }

    public void addStock(Delivery delivery) throws IOException {
        deliveries.add(delivery);
        save();
    }

    public void removeStock(Delivery delivery) throws IOException {
        deliveries.remove(delivery);
        save();
    }

}
