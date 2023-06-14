---
uid: Adding_time_scoped_related_parameters_to_a_trend_graph
---

# Adding time scoped related parameters to a trend graph

To take your insights into your data to the next level, from DataMiner 10.3.8/10.4.0 onwards<!--RN 36434 -->, you can use the light bulb in the selection of a section of a trend graph.

This allows you to add related parameters to your trend graphs to get a better understanding of what is exactly happening during this specific section of your trend graph. This way, you can uncover hidden connections in your data that you might not have noticed otherwise. This means that you do not have to spend hours sifting through your data to find connections, because DataMiner analytics will do the work for you.

## Prerequisites

The following prerequisites are **mandatory**. You will not be able to use this feature without them:

- The DataMiner System should use an Elasticsearch or OpenSearch general database setup. See [Supported system data storage architectures](xref:Supported_system_data_storage_architectures).

- Behavioral anomaly detection should be enabled. You can enable this feature in System Center, via *System settings* > *analytics config*. Enabling this feature allows DataMiner to generate data based on what happens in your system, so that it can understand what is going on.

  ![System Center analytics config page](~/user-guide/images/Analytics_anomaly_detection.jpg)<br>
  *System Center analytics config page in DataMiner 10.3.5*

## Adding a time scoped related parameter to a trend graph

To add a related parameter for a specific section of the graph:

1. In a trend graph showing trend information for one single parameter, **first select the section of the graph** where the parameter exhibits some remarkable behavior. The way you can do so depends on the configuration of the trending user settings. See [Trending settings](xref:User_settings#trending-settings).

1. Click the light bulb icon. This will open a menu with the related parameters solely based on the behavior of the parameters during the time range of the selected section.

1. Select the parameter you want to add.

    If other related parameters are available that have not been added yet, you can click the light bulb again to add those parameters as well.

> [!NOTE]
> The light bulb icon is always displayed regardless of whether DataMiner was able to find related parameters for the selected section. If no related parameters were found, the light bulb icon will not be "lit up" with an accent color as it would be otherwise. Clicking the icon will prompt a message indicating that the necessary requirements have not been met, hereby explaining why the feature could not find related parameters.
