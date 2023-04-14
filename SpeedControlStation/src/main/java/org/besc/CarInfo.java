package org.besc;

import java.awt.*;

public class CarInfo {
    // Структура, хранящая данные о проехавшей машине

    public final String registrationNumber;
    public final Color color;
    public final String bodyType;
    public final float Speed;

    public CarInfo(String registrationNumber, Color color, String bodyType, float speed) {
        if (registrationNumber == null || color == null || bodyType == null) {
            throw new IllegalArgumentException("Field is null");
        }
        if (speed <= 0) {
            throw new IllegalArgumentException("Speed less than or equal to 0");
        }
        this.registrationNumber = registrationNumber;
        this.color = color;
        this.bodyType = bodyType;
        Speed = speed;
    }


}
