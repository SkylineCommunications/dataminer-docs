---
uid: MaintenanceSettings.AlarmSettings.PersistParameterLatchState
---

# PersistParameterLatchState element

Enables persistent parameter latch states.

## Content Type

boolean

## Parents

[AlarmSettings](xref:MaintenanceSettings.AlarmSettings)

## Remarks

From DataMiner 10.4.9/10.5.0 onwards<!--RN 39495-->, parameter latch states are not persistent by default. This means they will reset after every DataMiner restart.

To enable persistent parameter latch states, set `PersistParameterLatchState` to `true`.

```xml
<AlarmSettings>
   <PersistParameterLatchState>true</PersistParameterLatchState>
</AlarmSettings>
```

> [!NOTE]
> From DataMiner 10.4.9/10.5.0 onwards<!--RN 39495-->, if this tag has not been added to the *MaintenanceSettings.xml* file, or if the `PersistParameterLatchState` option is set to "false", parameter latch states will not be written to or fetched from the database.
