---
uid: Adding_time_scoped_related_parameters_to_a_trend_graph
---

# Adding time-scoped related parameters to a trend graph

From DataMiner 10.3.8/10.4.0 onwards<!--RN 36434 -->, a light bulb icon will be displayed when you select a time range on the trend graph of a parameter. If you want to know which other parameters are related to this parameter, based purely on the behavior during the selected time range, then you can click this icon to add or view related parameters. Even if multiple curves are displayed on the same trend graph, the light bulb always shows relations with one specific parameter, whose name is mentioned in the light bulb tooltip. Currently, the feature only proposes parameters from the same DataMiner element.

You can for instance use this in case a parameter (e.g. the total available memory of a server) behaves oddly during a particular time range (e.g. a downward spike), in order to find out if other parameters of the same device also showed unusual behavior during the same time range.

## Prerequisites

- The DataMiner System must use an [indexing database](xref:Indexing_Database). See [Supported system data storage architectures](xref:Supported_system_data_storage_architectures).

- Behavioral anomaly detection must be enabled. You can enable this feature in System Center, via *System settings* > *analytics config*.

  ![System Center analytics config page](~/user-guide/images/Analytics_anomaly_detection.jpg)<br>
  *System Center analytics config page in DataMiner 10.3.5*

## Adding a time-scoped related parameter to a trend graph

To add a related parameter for a specific time range only:

1. In a trend graph showing trend information for one single parameter, **select the section of the graph** where the parameter shows the behavior you are interested in. The way you can do so depends on the configuration of the trending user settings. See [Trending settings](xref:User_settings#trending-settings).

1. Click the light bulb icon. This will open a menu with the parameters related to your original parameter, but only taking into account the behavior within the selected time range.

1. Select the parameter you want to add.

   If other related parameters are available that have not been added yet, you can click the light bulb again to add those parameters as well.

> [!NOTE]
> The light bulb icon is always displayed regardless of whether DataMiner was able to find related parameters for the selected section. If no related parameters were found, the light bulb icon will not be "lit up" with an accent color as it would otherwise be. Click the icon for more information on why no related parameters could be found.
