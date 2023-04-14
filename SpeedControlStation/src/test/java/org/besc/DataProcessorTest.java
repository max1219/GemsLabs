package org.besc;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.awt.*;
import java.util.Map;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

class DataProcessorTest {

    static Set<CarInfo> carInfos;

    @BeforeAll
    static void setUp() {
        carInfos = Set.of(
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
    }

    @Test
    void quantityByBodeType() {
        Map<String, Integer> expected = Map.of("bt1", 5, "bt2", 3, "bt3", 2);
        Map<String, Integer> actual = DataProcessor.quantityByBodeType(carInfos.iterator());
        assertEquals(expected, actual);
    }

    @Test
    void averageSpeed() {
        float expected = 105.9f;
        float actual = DataProcessor.averageSpeed(carInfos.iterator());
        assertEquals(expected, actual, 0.001f);
    }

    @Test
    void numberWhoExceededSpeedLimit() {
        float speedLimit = 110;
        int expected = 3;
        int actual = DataProcessor.numberWhoExceededSpeedLimit(carInfos.iterator(), speedLimit);
        assertEquals(expected, actual);
    }
}