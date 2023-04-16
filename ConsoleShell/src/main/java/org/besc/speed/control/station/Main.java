package org.besc.speed.control.station;

import org.besc.speed.control.station.records.AverageSpeed;
import org.besc.speed.control.station.records.NumberWhoExceededSpeedLimit;
import org.besc.speed.control.station.records.QuantityByBodyType;

import java.awt.*;
import java.util.Scanner;
import java.util.Set;

public class Main {

    public static void main(String[] args) {
        SpeedControlStation station = new SpeedControlStation();
        new AverageSpeed(station);
        new NumberWhoExceededSpeedLimit(station, 110);
        new QuantityByBodyType(station);
        Scanner scanner = new Scanner(System.in);
        while (true) {
            System.out.println("1. Print records.\n2. Add sample cars info\n3. Add your car info\n4. Close\nPlease, enter number: ");
            int choice = scanner.nextInt();
            if (choice == 1) {
                printStationInfo(station);
            } else if (choice == 2) {
                addSampleCarsInfo(station);
            } else if (choice == 3) {
                System.out.println("Enter car info (*registration number* *color (hhhhhh)* *body type* *speed*)");
                station.addCarInfo(readCarInfo(scanner));
            } else if(choice == 4){
                return;
            }
        }
    }


    private static CarInfo readCarInfo(Scanner scanner) {
        String registrationNumber = scanner.next();
        Color color = Color.decode(scanner.next());
        String bodyType = scanner.next();
        float speed = scanner.nextFloat();
        return new CarInfo(registrationNumber, color, bodyType, speed);
    }

    private static void addInfos(SpeedControlStation station, Set<CarInfo> carInfos) {
        for (CarInfo info : carInfos) {
            station.addCarInfo(info);
        }
    }

    public static void printStationInfo(SpeedControlStation station) {
        System.out.println(station.toString());
    }


    public static void addSampleCarsInfo(SpeedControlStation station) {
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
        addInfos(station, carInfos);
    }


}
