package uk.ac.hereford.djw9349.objects;

import lombok.Getter;
import lombok.NonNull;
import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@Getter
public class Supplier {
    @NonNull
    private String name;
    @NonNull
    private Address address;
    @NonNull
    private String emailAddress;
    @NonNull
    private String phoneNumber;
}