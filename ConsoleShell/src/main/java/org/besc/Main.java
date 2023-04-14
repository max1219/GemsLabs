package org.besc;

import java.awt.*;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("1. Look at the sample station.\n2. Simulate your station.\nPlease, enter number: ");
        int choice = scanner.nextInt();
        if (choice == 1) {
            sampleStation();
        } else if (choice == 2) {
            yourStation(scanner);
        }
    }

    public static CarInfo readCarInfo(Scanner scanner) {
        String registrationNumber = scanner.next();
        Color color = Color.decode(scanner.next());
        String bodyType = scanner.next();
        float speed = scanner.nextFloat();
        return new CarInfo(registrationNumber, color, bodyType, speed);
    }

    public static void addInfos(SpeedControlStation station, Set<CarInfo> carInfos) {
        for (CarInfo info : carInfos) {
            station.add(info);
        }
    }

    public static void printStationInfo(SpeedControlStation station) {
        System.out.println("AverageSpeed - " + station.getAverageSpeed());
        System.out.println("NumberWhoExceededSpeedLimit - " + station.getNumberWhoExceededSpeedLimit());
        System.out.println("QuantityByBodeType - " + station.getQuantityByBodeType());
    }

    public static void sampleStation() {
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
        SpeedControlStation station = new SpeedControlStation();
        addInfos(station, carInfos);
        printStationInfo(station);
    }

    public static void yourStation(Scanner scanner) {
        SpeedControlStation station = new SpeedControlStation();
        while (true) {
            System.out.println("1. Add car info.\n2. Print station info.\n3. Exit\nPlease, enter number: ");
            int choice = scanner.nextInt();
            if (choice == 1) {
                station.add(readCarInfo(scanner));
            }
            else if (choice == 2) {
                printStationInfo(station);
            }
            else if (choice == 3) {
                return;
            }
            else {
                System.out.println("Incorrect number.");
            }
        }
    }

}
