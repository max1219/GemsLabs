package org.besc.speed.control.station;

import java.awt.*;
import java.util.Objects;

public class CarInfo {
    // Структура, хранящая данные о проехавшей машине

    public final String registrationNumber;
    public final Color color;
    public final String bodyType;
    public final float Speed;

    public CarInfo(String registrationNumber, Color color, String bodyType, float speed) {
        if (speed <= 0) {
            throw new IllegalArgumentException("Speed less than or equal to 0");
        }
        this.registrationNumber = registrationNumber;
        this.color = color;
        this.bodyType = bodyType;
        Speed = speed;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        CarInfo info = (CarInfo) o;
        return Float.compare(info.Speed, Speed) == 0 && Objects.equals(registrationNumber, info.registrationNumber) && Objects.equals(color, info.color) && Objects.equals(bodyType, info.bodyType);
    }

    @Override
    public int hashCode() {
        return Objects.hash(registrationNumber, color, bodyType, Speed);
    }
}
