package org.besc.speed.control.station.records;

import org.besc.speed.control.station.CarInfo;
import org.besc.speed.control.station.SpeedControlStation;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

public class QuantityByBodyType extends Record {

    public static final String recordName = "Quantity by dody type speed";



    public QuantityByBodyType(SpeedControlStation station) {
        super(station);
    }

    @Override
    public String getName() {
        return recordName;
    }

    @Override
    protected Map<String, Integer> calculate() {
        Map<String, Integer> result = new HashMap<>();
        Iterator<CarInfo> iterator = station.carInfoIterator();

        while (iterator.hasNext()) {
            String bodyType = iterator.next().bodyType;
            int currentCount = 1 + result.getOrDefault(bodyType, 0);
            result.put(bodyType, currentCount);
        }
        return result;
    }
}
