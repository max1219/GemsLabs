package org.besc;

import java.util.Map;
import java.util.Set;
import java.util.HashSet;

public class SpeedControlStation {

    private final int SPEED_LIMIT;

    private final Set<CarInfo> carInfos = new HashSet<>();

    private Map<String, Integer> quantityByBodeType = null;
    private Float averageSpeed = null;
    private Integer numberWhoExceededSpeedLimit = null;

    public SpeedControlStation(int SPEED_LIMIT) {
        this.SPEED_LIMIT = SPEED_LIMIT;
    }

    public SpeedControlStation() {
        this(110);
    }

    public void add(CarInfo info) {
        carInfos.add(info);
        nullingValues();
    }

    public Map<String, Integer> getQuantityByBodeType() {
        if (quantityByBodeType == null) {
            quantityByBodeType = DataProcessor.quantityByBodeType(carInfos.iterator());
        }
        return quantityByBodeType;
    }

    public Float getAverageSpeed() {
        if (averageSpeed == null) {
            averageSpeed = DataProcessor.averageSpeed(carInfos.iterator());
        }
        return averageSpeed;
    }

    public Integer getNumberWhoExceededSpeedLimit() {
        if (numberWhoExceededSpeedLimit == null) {
            numberWhoExceededSpeedLimit = DataProcessor.numberWhoExceededSpeedLimit(carInfos.iterator(), SPEED_LIMIT);
        }
        return numberWhoExceededSpeedLimit;
    }

    private void nullingValues() {
        if (quantityByBodeType != null) quantityByBodeType = null;
        if (averageSpeed != null) averageSpeed = null;
        if (numberWhoExceededSpeedLimit != null) numberWhoExceededSpeedLimit = null;
    }

}
