---
uid: ConnectorsAlarms
---

# Alarms

Within the EPM Manager connector, we have the possibility to define and customize alarm settings according to our specific requirements.

## Severity Bubble Up

The Severity Bubble Up option gives the possibility to pass alarm severities to linked tables.

To implement this feature, you need to create a `<SeverityBubbleUp>` tag. Within this tag, you must define the `<path>` tag, which specifies the path through which the alarms should bubble up. This path should correspond to a defined chain.

As an example, consider the Location topology, which includes various levels connected in a one-to-many manner:

- Network (View table 9000)
  - Region (View table 8000)
    - Sub-Region (View table 7000)
      - Hub (View table 6000)
        - Station (View table 5000)
          - Device

To configure the SeverityBubbleUp feature for this topology, use the following setup:

```xml
<SeverityBubbleUp>
    <Path>5000;6000;7000;8000;9000</Path>
</SeverityBubbleUp>
```

## Alarm Level Linking

The alarm level link allows aggregating alarms from DataMiner elements or table rows.

In the following example we are aggregating alarms related to the Network topology level.

```xml
<AlarmLevelLinks>
    <AlarmLevelLink id="1" remoteElement="801:8000:8003" destination="9001:DISPLAY_NOLINK:9001" />
</AlarmLevelLinks>
```

- **AlarmLevelLink ID**: Unique identifier for the alarm level link.
- **Remote Element**: Attribute used to retrieve the alarm state of a different element.
- **Destination**: Specifies the column parameter ID where the result of the alarm level needs to be set.
