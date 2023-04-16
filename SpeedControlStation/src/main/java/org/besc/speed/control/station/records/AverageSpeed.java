package org.besc.speed.control.station.records;

import org.besc.speed.control.station.CarInfo;
import org.besc.speed.control.station.SpeedControlStation;

import java.util.Iterator;


public class AverageSpeed extends Record {

    public static final String recordName = "Average speed";


    public AverageSpeed(SpeedControlStation station) {
        super(station);
    }

    @Override
    public String getName() {
        return recordName;
    }

    @Override
    protected Float calculate() {
        int i = 0;
        float result = 0;
        Iterator<CarInfo> iterator = station.carInfoIterator();

        while (iterator.hasNext()) {
            i++;
            float speed = iterator.next().Speed;
            result = result + (speed - result) / i;
            // Пересчет средней скорости на основе новой полученной скорости
        }
        return result;
    }
}
