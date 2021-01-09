package uk.ac.hereford.djw9349.objects;

import lombok.Getter;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@Getter
public class Address {
    @NonNull
    private String houseName;
    @NonNull
    private String lineOne;
    @NonNull
    private String lineTwo;
    @NonNull
    private String postcode;
    
    @Override
    public String toString() {
        return (houseName + ", " + lineOne +", " + lineTwo + ", " + postcode + ".");
    }
}