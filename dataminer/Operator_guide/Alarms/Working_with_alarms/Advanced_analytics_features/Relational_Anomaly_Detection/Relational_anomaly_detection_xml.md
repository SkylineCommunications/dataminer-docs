---
uid: Relational_anomaly_detection_xml
---

# Configuring RAD through the configuration XML file

> [!IMPORTANT]
> From DataMiner 10.5.9/10.6.0 onwards<!--RN 43320-->, RAD configuration settings are no longer stored in the *RelationalAnomalyDetection.xml* file, and all configuration must be done using either the [RAD Manager](xref:RAD_manager) or the [RAD API](xref:RAD_API). **The procedure below only applies to versions prior to DataMiner 10.5.9/10.6.0.**

In Feature Release versions up to DataMiner 10.5.8, the parameter groups that are monitored by *relational anomaly detection* are specified in the configuration file `C:\Skyline DataMiner\Analytics\RelationalAnomalyDetection.xml`. Each DMA has a separate configuration file specifying the groups that are monitored by that DMA. In the file on a given DMA, you can only specify parameters hosted on that DMA.

To add a new parameter group, follow these steps.

1. On the DMA where you want to configure the parameter groups, open the file `C:\Skyline DataMiner\Analytics\RelationalAnomalyDetection.xml`.

1. Configure the file as follows:

   ```xml
   <?xml version="1.0" ?>
   <RelationalAnomalyDetection>
     <Group name="[GROUP_NAME]" updateModel="[true/false]" anomalyScore="[THRESHOLD]" minimumAnomalyDuration="[THRESHOLD2]">
       <Instance>[INSTANCE1]</Instance>
       <Instance>[INSTANCE2]</Instance>
       [... one <Instance> tag per parameter in the group]
     </Group>
     [... one <Group> tag per group of parameters that should be monitored by RAD]
   </RelationalAnomalyDetection>
   ```

   The attributes `name` and `updateModel` are required, while `anomalyScore` and `minimumAnomalyDuration` are optional. For more information on the available options, see [Options for parameter groups](xref:Relational_anomaly_detection#options-for-parameter-groups).

   In each `Instance` element, you can specify either a single-value parameter or a table parameter using one of the following formats:

     - Single-value parameter: [DataMinerID]/[ElementID]/[ParameterID]
     - Table parameter: [DataMinerID]/[ElementID]/[ParameterID]/[PrimaryKey]

1. To make sure the changes take effect, in DataMiner Cube, go to *System Center* > *System settings* > *analytics config*, and disable and re-enable *Relational anomaly detection*.

> [!NOTE]
> In some cases, it can be useful to retrain the internal model used by RAD. This allows you to indicate the periods during which a parameter group was behaving as expected, so that RAD can better identify when the parameters deviate from that expected behavior in the future. To do so, either use the *RAD Manager* (see [Specifying the training range](xref:RAD_manager#specifying-the-training-range)) or the *SLNetClientTest tool* (see [Retraining the internal model used by RAD](xref:SLNetClientTest_retrain_rad_model)).
