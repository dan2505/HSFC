package uk.ac.hereford.djw9349.objects;

import lombok.Getter;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;

import java.util.ArrayList;
import uk.ac.hereford.djw9349.enums.Category;

@RequiredArgsConstructor
@Getter
public class Ingredient {
    @NonNull
    private String name;
    @NonNull
    private Integer quantity;
    @NonNull
    private Category category;
    // An ingredient doesn't necessarily have to be grouped to a recipe, therefore it can be null.
    private ArrayList<Recipe> recipes = new ArrayList<Recipe>();

    public void addRecipe(Recipe recipe) {
        recipes.add(recipe);
    }
}
