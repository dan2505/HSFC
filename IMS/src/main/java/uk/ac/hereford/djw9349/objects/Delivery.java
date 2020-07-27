package uk.ac.hereford.djw9349.objects;

import lombok.Getter;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;
import uk.ac.hereford.djw9349.enums.Status;

import java.util.ArrayList;
import java.util.Date;

@RequiredArgsConstructor
@Getter
public class Delivery {
    @NonNull
    private Status status;
    @NonNull
    private Date date;
    @NonNull
    private ArrayList<Ingredient> ingredients = new ArrayList<Ingredient>();
    @NonNull
    private Supplier supplier;
}
