package org.besc.speed.control.station.records;

import org.besc.speed.control.station.CarInfo;
import org.besc.speed.control.station.SpeedControlStation;

import java.util.Iterator;

public class NumberWhoExceededSpeedLimit extends Record {

    public static final String recordName = "Number who exceeded speed limit";

    private final float speedLimit;

    public NumberWhoExceededSpeedLimit(SpeedControlStation station, float speedLimit) {
        super(station);
        this.speedLimit = speedLimit;
    }

    @Override
    public String getName() {
        return recordName;
    }

    @Override
    protected Object calculate() {
        int result = 0;
        Iterator<CarInfo> iterator = station.carInfoIterator();

        while (iterator.hasNext()) {
            float speed = iterator.next().Speed;
            if (speed > speedLimit) {
                result++;
            }
        }
        return result;
    }
}
