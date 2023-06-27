---
uid: Adding_related_parameters_to_a_trend_graph
---

# Adding related parameters to a trend graph

From DataMiner 10.2.12/10.3.0 onwards, you can use the light bulb in the top-right corner of a trend graph to add related parameters and get more insight into your data.

## Prerequisites

The following prerequisites are **mandatory**. You will not be able to use this feature without them:

- The system must be connected to dataminer.services. You can check whether this is the case on the *Cloud* page in System Center.

  ![System Center Cloud page](~/user-guide/images/Cloud_connected.jpg)<br>
  *System Center Cloud page in DataMiner 10.3.5*

  > [!TIP]
  > See also: [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- *DataMiner ModelHost* must be running on your system.

  You can [use the Admin app](xref:Managing_cloud-connected_nodes) to check if the *DataMiner ModelHost* DxM is installed.

- *DataMiner CloudFeed* version 1.1.0 or higher must be running on your system.

  You can [use the Admin app](xref:Managing_cloud-connected_nodes) to check if the *DataMiner CloudFeed* DxM is installed.

- The option *Allow performance and usage data offload* must be enabled. See [Controlling cloud feed data offloads](xref:Controlling_cloudfeed_data_offloads).

> [!NOTE]
> From DataMiner 10.3.6/10.4.0 onwards, the light bulb icon is always displayed in the top-right corner of the trend graph, regardless of whether DataMiner was able to find related parameters. If no related parameters were found, the light bulb icon will not be "lit up" with an accent color as it would be otherwise. <!-- RN 35868 --> Clicking the icon will prompt a message indicating that the necessary requirements have not been met, hereby explaining why the feature could not find related parameters. <!--RN 36157-->

The following prerequisites are **optional** but highly recommended, as they will unlock the full capabilities of the feature:

- The DataMiner System should use a Cassandra general database setup. See [Supported system data storage architectures](xref:Supported_system_data_storage_architectures).

- Behavioral anomaly detection should be enabled. You can enable this feature in System Center, via *System settings* > *analytics config*. Enabling this feature allows DataMiner to generate data based on what happens in your system, so that it can understand what is going on.

  ![System Center analytics config page](~/user-guide/images/Analytics_anomaly_detection.jpg)<br>
  *System Center analytics config page in DataMiner 10.3.5*

If both optional requirements are met, DataMiner can study the system more efficiently, leading to even more valuable insights.

> [!NOTE]
>
> - From DataMiner 10.3.6/10.4.0 onwards, if you have met all mandatory prerequisites, you can check if any of these optional requirements are still missing in your system by clicking the light bulb icon in the top-right corner of the trend graph. If any are missing, a message will appear advising you to unlock all capabilities of this feature. <!-- RN 35868 --> Prior to DataMiner 10.3.6/10.4.0, you can check if any of these (optional) requirements are still missing in your system by checking the logs via *System Center* > *Logging* > *cube*. Filter the logs on "requirements" to quickly find the relevant entries.
> - When you have activated this feature, it may take up to a week before the first results are available. During this time, DataMiner will analyze your system in order to learn which parameters are related.

## Adding a related parameter to a trend graph

If all prerequisites are met, and you open a trend graph, DataMiner Cube will consult the ModelHost DxM to retrieve all parameters related to those shown in the trend graph.

To add a related parameter:

1. Click the light bulb icon in the top-right corner of the graph. This will open a menu with the related parameters.

   > [!NOTE]
   >
   > - In DataMiner versions prior to 10.3.6, the light bulb may not be displayed if not all prerequisites are met.
   > - If you click the light bulb and no relations have been found or not all prerequisites are met, a message will be displayed instead.

1. Select the parameter you want to add.

   If other related parameters are available that have not been added yet, you can click the light bulb again to add those parameters as well.
