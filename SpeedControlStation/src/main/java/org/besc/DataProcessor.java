package org.besc;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

public class DataProcessor {

    public static Map<String, Integer> quantityByBodeType(Iterator<CarInfo> iterator) {
        Map<String, Integer> result = new HashMap<String, Integer>();

        while (iterator.hasNext()) {
            String bodyType = iterator.next().bodyType;
            int currentCount = 1 + result.getOrDefault(bodyType, 0);
            result.put(bodyType, currentCount);
        }
        return result;
    }

    public static float averageSpeed(Iterator<CarInfo> iterator) {
        int i = 0;
        float result = 0;

        while (iterator.hasNext()) {
            i++;
            float speed = iterator.next().Speed;
            result = result + (speed - result) / i;
            // Пересчет средней скорости на основе новой полученной скорости
        }
        return result;
    }

    public static int numberWhoExceededSpeedLimit(Iterator<CarInfo> iterator, float speedLimit) {
        int result = 0;

        while (iterator.hasNext()) {
            float speed = iterator.next().Speed;
            if (speed > speedLimit) {
                result++;
            }
        }
        return result;
    }
}
