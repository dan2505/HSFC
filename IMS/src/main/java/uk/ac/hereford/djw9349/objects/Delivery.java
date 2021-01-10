package uk.ac.hereford.djw9349.objects;

import lombok.Getter;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;
import lombok.Setter;
import uk.ac.hereford.djw9349.enums.Status;

import java.util.ArrayList;
import java.util.Date;

@RequiredArgsConstructor
@Getter
public class Delivery {
    @NonNull
    @Setter
    private Status status;
    @NonNull
    private Date date;
    @NonNull
    private String supplier;
    @NonNull
    private ArrayList<Ingredient> ingredients = new ArrayList<Ingredient>();

    public void addIngredient(Ingredient ingredient) {
        ingredients.add(ingredient);
    }
    public void removeIngredient(Ingredient ingredient) {
        ingredients.remove(ingredient);
    }
    
    public String getIngredients() {
        String temp = "";
        for (Ingredient ingredient : ingredients) {
            temp = temp + ingredient.getName() + ",";
        }
        return temp;
    }

    public ArrayList<Ingredient> getArray() {
        return ingredients;
    }
}
