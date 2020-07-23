package uk.ac.hereford.djw9349.objects;

import lombok.Getter;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@Getter
public class Ingredient {
    @NonNull
    private String name;
    @NonNull
    private Integer quantity;
    @NonNull
    private Category category;
}
