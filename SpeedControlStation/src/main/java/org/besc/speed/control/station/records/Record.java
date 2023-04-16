package org.besc.speed.control.station.records;

import org.besc.speed.control.station.SpeedControlStation;

public abstract class Record {


    protected final SpeedControlStation station;
    private boolean isActual;
    private Object record;

    public Record(SpeedControlStation station) {
        this.station = station;
        station.addRecordToTracking(this);
        nulling();
    }

    public abstract String getName();

    public final void nulling() {
        isActual = false;
    }

    public final Object get() {
        if (!isActual) {
            record = calculate();
            isActual = true;
        }
        return record;
    }

    @Override
    public final String toString() {
        return getName() + " - " + get().toString();
    }

    protected abstract Object calculate();

}
