package org.besc.speed.control.station;

import org.besc.speed.control.station.records.AverageSpeed;
import org.besc.speed.control.station.records.NumberWhoExceededSpeedLimit;
import org.besc.speed.control.station.records.QuantityByBodyType;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.awt.*;
import java.util.Map;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

class SpeedControlStationTest {

    static SpeedControlStation station;

    @BeforeAll
    static void setUp(){
        station = new SpeedControlStation();
        new AverageSpeed(station);
        new QuantityByBodyType(station);
        new NumberWhoExceededSpeedLimit(station, 110);
        Set<CarInfo> carInfos = Set.of(
                new CarInfo("111fff", Color.BLACK, "bt1", 100),
                new CarInfo("112fff", Color.BLACK, "bt2", 115),
                new CarInfo("113fff", Color.BLACK, "bt1", 100),
                new CarInfo("114fff", Color.BLACK, "bt1", 75),
                new CarInfo("115fff", Color.BLACK, "bt2", 110),
                new CarInfo("116fff", Color.BLACK, "bt1", 90),
                new CarInfo("777fff", Color.ORANGE, "bt3", 246),
                new CarInfo("118fff", Color.BLACK, "bt3", 95),
                new CarInfo("119fff", Color.BLACK, "bt1", 120),
                new CarInfo("120fff", Color.BLACK, "bt2", 8)
        );
        for (CarInfo carInfo : carInfos) {
            station.addCarInfo(carInfo);
        }
    }

    @Test
    void averageSpeedTest() {
        assertEquals(105.9f, station.getRecord(AverageSpeed.recordName));
    }

    @Test
    void quantityByBodyTypeTest() {
        Map<String, Integer> expected = Map.of("bt1", 5, "bt2", 3, "bt3", 2);
        assertEquals(expected, station.getRecord(QuantityByBodyType.recordName));
    }

    @Test
    void numberWhoExceededSpeedLimitTest() {
        assertEquals(3, station.getRecord(NumberWhoExceededSpeedLimit.recordName));
    }

}