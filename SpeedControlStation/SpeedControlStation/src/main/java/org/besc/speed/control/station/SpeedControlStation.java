package org.besc.speed.control.station;

import org.besc.speed.control.station.records.Record;

import java.util.*;

public class SpeedControlStation {

    private final Set<CarInfo> carInfos = new HashSet<>();

    private final Map<String, Record> trackedRecords = new HashMap<>();


    public void addCarInfo(CarInfo carInfo) {
        carInfos.add(carInfo);
        nullingValues();
    }

    public Iterator<CarInfo> carInfoIterator() {
        return carInfos.iterator();
    }

    public void addRecordToTracking(Record record) {
        trackedRecords.put(record.getName(), record);
    }

    public Object getRecord(String recordName) {
        if (trackedRecords.containsKey(recordName)) {
            return trackedRecords.get(recordName).get();
        }
        throw new IllegalArgumentException("Untracked record");
    }

    public Set<String> getTrackedRecordsNames() {
        return trackedRecords.keySet();
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();
        for (Record record : trackedRecords.values()) {
            result.append(record.toString()).append('\n');
        }
        return result.toString();
    }

    private void nullingValues() {
        for (Record record : trackedRecords.values()) {
            record.nulling();
        }
    }
}
