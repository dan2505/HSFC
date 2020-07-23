package uk.ac.hereford.djw9349.objects;

import lombok.Getter;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@Getter
public class Category {
    @NonNull
    private String name;
}
