---
uid: TutorialSwarmingUpdateServiceConnector
---
# Tutorial: Making Enhanced Service Connectors compatible with Swarming

This tutorial shows how you can update existing enhanced service connectors to be compatible with the Swarming feature on a DataMiner system.

## Background

When the Swarming feature is enabled on a DataMiner System, [references to alarm events are made in a different way](xref:TutorialSwarmingAlarmEventChanges). As service elements can have an *Active Service Alarms* table which uses these references, a connector update might be required before that enhanced service is compatible with a Swarming-enabled system.

> [!NOTE]
> Running enhanced services using non-compatible drivers is being actively blocked when the Swarming feature has been enabled on the system. Having such enhanced services present will block the migration towards a Swarming-enabled system.

## Is an update required?

Not all connectors require an update.

An update is only required if the current connector defines a parameter 4 (`raw_alarm_input`). Connectors without this parameter do not have an *Active Service Alarms* table and do not need an update.

## Update the driver

- Updating the driver starts by adding a new parameter 7 (`raw_alarmid_input`). Note that the name is different from the name of parameter 4.

    ```xml
    <Param id="7">
      <Name>raw_alarmid_input</Name>
      <Description>raw_alarmid_input</Description>
      <Type>read</Type>
      <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
      </Interprete>
      <Measurement>
        <Type>string</Type>
      </Measurement>
    </Param>
    ```

    When this parameter 7 is present, the driver will update the *Active Service Alarms* table using full alarm references on DataMiner versions 10.5.1 or up.

- If you have a QAction triggering on parameter 4, create an extra QAction triggering on the new parameter 7. This QAction will receive full alarm event references (formatted like `dmaid/eid/rootalarmid/alarmid`).

- If you want to keep supporting DataMiner versions before 10.5.1 / 10.6, keep the previously existing parameter 4 and make sure that your QActions can deal with both scenarios (legacy alarm references through parameter 4 or full alarm references through parameter 7)

- If you only need to support DataMiner versions higher than 10.5.1 / 10.6, the parameter 4 and associated QActions can be removed.

- In any case, if any QActions or code relies on the IDs as stored in the *Active Service Alarms* table, make sure that they can deal with either full or legacy type references depending on the DataMiner version they will run on.
