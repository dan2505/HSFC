package uk.ac.hereford.djw9349.managers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import uk.ac.hereford.djw9349.objects.Ingredient;

import java.io.*;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;
import uk.ac.hereford.djw9349.enums.Category;

public class StockManager {
    private ArrayList<Ingredient> ingredients = new ArrayList<Ingredient>();
    // Temporary storage of the category from search.
    public Category category;

    public StockManager() throws IOException {
        initialise();
    }

    private void initialise() throws IOException {
        File file = new File("stock.json");
        if (!file.exists()) file.createNewFile();

        Type type = new TypeToken<ArrayList<Ingredient>>() {
        }.getType();
        List<Ingredient> local = new Gson().fromJson(new FileReader("stock.json"), type);
        if (local != null) ingredients.addAll(local);
    }

    private void save() throws IOException {
        try (Writer writer = new FileWriter("stock.json")) {
            Gson builder = new GsonBuilder().create();
            builder.toJson(ingredients, writer);
        }
    }

    public void addStock(Ingredient ingredient) throws IOException {
        ingredients.add(ingredient);
        save();
    }

    public void removeStock(Ingredient ingredient) throws IOException {
        ingredients.remove(ingredient);
        save();
    }
    
    public ArrayList<Ingredient> getStock() {
        return ingredients;
    }
    
    public boolean alreadyExists(String name) {
       for (Ingredient ingredient : ingredients) if (ingredient.getName().equals(name)) return true;
        return false;
    } 
}