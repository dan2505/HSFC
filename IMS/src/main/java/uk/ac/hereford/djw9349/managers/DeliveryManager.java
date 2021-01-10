package uk.ac.hereford.djw9349.managers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import uk.ac.hereford.djw9349.enums.Status;
import uk.ac.hereford.djw9349.objects.Delivery;
import uk.ac.hereford.djw9349.objects.Ingredient;
import uk.ac.hereford.djw9349.objects.Supplier;

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

    public void addDelivery(Delivery delivery) throws IOException {
        deliveries.add(delivery);
        save();
    }

    public void removeDelivery(Delivery delivery) throws IOException {
        deliveries.remove(delivery);
        save();
    }

    public Delivery getDeliveryFromString(String date) {
        for (Delivery delivery : deliveries) if (delivery.getDate().equals(date)) return delivery;
        return null;
    }

    public void cancelDelivery(Delivery delivery) throws IOException {
        Delivery temp = delivery;
        removeDelivery(delivery);
        temp.setStatus(Status.CANCELLED);
        addDelivery(temp);
    }
    
    public ArrayList<Delivery> getDeliveries() {
        return deliveries;
    }
}
