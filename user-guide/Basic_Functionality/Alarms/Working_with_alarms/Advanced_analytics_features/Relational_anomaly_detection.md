---
uid: Relational_anomaly_detection
---

# Relational anomaly detection

From DataMiner 10.5.3/10.6.0 onwards, you can use relational anomaly detection (RAD) to detect when a group of parameters deviates from its normal behavior.<!-- RN 42034 -->

After you have [configured one or more groups of parameters](#configuring-parameter-groups-for-rad) that should be monitored together, RAD will learn how these parameters are related.

Whenever the relation is broken, RAD will detect this and generate suggestion events in the Alarm Console.

The suggestion events for the same group of parameters will be grouped into a single incident in the *Suggestion events* tab and *Relational anomalies* tab in the Alarm Console. Clearing the grouped incident will also clear all the suggestion events included in it. Other changes (e.g. taking ownership, adding comments) are not supported for grouped incidents. Note that prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4<!-- RN 41983, 42050 -->, a separate suggestion event will be generated for each parameter in the group where a broken relation is detected, and this will be shown in the *Active alarms* tab of the Alarm Console instead.

## Prerequisites

RAD uses average trending to detect anomalies. As such, it requires **numeric** parameters with **at least one week of five-minute average trend data**. If at least one parameter has less than a week of trend data available, monitoring will only start after this one week becomes available.

This means that the following prerequisites apply:

- Average trending has to be enabled for each parameter used in a RAD group.
- The TTL for five-minute average trend data has to be set to more than one week (recommended setting: 1 month).

## Configuring parameter groups for RAD

1. On the DMA where you want to configure the parameter groups, open the file `C:\Skyline DataMiner\Analytics\RelationalAnomalyDetection.xml`.

1. Configure the file as follows:

   ```xml
   <?xml version="1.0" ?>
   <RelationalAnomalyDetection>
     <Group name="[GROUP_NAME]" updateModel="[true/false]" anomalyScore="[THRESHOLD]">
       <Instance>[INSTANCE1]</Instance>
       <Instance>[INSTANCE2]</Instance>
       [... one <Instance> tag per parameter in the group]
     </Group>
     [... one <Group> tag per group of parameters that should be monitored by RAD]
   </RelationalAnomalyDetection>
   ```

   - In the `Group` tag, configure the following attributes:

     - `name`: The name of the parameter group. This name must be unique and will be used when a suggestion event is generated for the group in question.

     - `updateModel`: Indicates whether RAD should update its internal model of the relation between the parameters in the group.
  
       - If set to "false", RAD will only do an initial training based on the data available at startup.
       - If set to "true", RAD will update the model each time new data comes in.

     - `anomalyScore`: Optional argument that can be used to specify the suggestion event generation threshold.

       Higher values will result in less suggestion events, lower values will result in more suggestion events. Default: 3.

   - In each `Instance` element, you can specify either a single-value parameter or a table parameter using one of the following formats:

     - Single-value parameter: [DataMinerID]/[ElementID]/[ParameterID]
     - Table parameter: [DataMinerID]/[ElementID]/[ParameterID]/[PrimaryKey]

1. To make sure the changes take effect, in DataMiner Cube, go to *System Center* > *System settings* > *analytics config*, and disable and re-enable *Relational anomaly detection*.

> [!NOTE]
> In some cases, it can be useful to retrain the internal model used by RAD. This allows you to indicate the periods during which a parameter group was behaving as expected, so that RAD can better identify when the parameters deviate from that expected behavior in the future. To do so, you will need to use the SLNetClientTest tool. See [Retraining the internal model used by RAD](xref:SLNetClientTest_retrain_rad_model).

## Limitations

- RAD is only able to monitor parameters on the local DataMiner Agent. This means that all parameter instances configured in the *RelationalAnomalyDetection.xml* configuration file on a given DMA must be hosted on that same DMA. Currently, RAD is not able to simultaneously monitor parameters hosted on different DMAs.

- Some parameter behavior will cause RAD to work less accurately. For example, if a parameter only reacts to another parameter after a certain time, RAD will produce less accurate results.

- Relational anomalies on history set parameters can only be detected from DataMiner 10.5.4/10.6.0 onwards, and only under certain conditions:<!-- RN 42319 -->

  - If there is at least one history set parameter in a RAD parameter group, that parameter group will only be processed when all data from all parameters in the group has been received. In other words, if a history set parameter receives data 30 minutes later than the real-time parameters, possible anomalies will only be detected after 30 minutes.
  - RAD will only process data received within the last hour. If a history set parameter receives data more than an hour later than the real-time parameters, that data will be disregarded.
