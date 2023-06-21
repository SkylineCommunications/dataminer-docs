---
uid: Adding_time_scoped_related_parameters_to_a_trend_graph
---

# Adding time-scoped related parameters to a trend graph

From DataMiner 10.3.8/10.4.0 onwards<!--RN 36434 -->, you can use the light bulb that appears after selecting a time range on a trend graph to add related parameters based only on the behavior during that time range. This is different from the lightbulb on the top right corner of the trend graph which proposes related parameters based on the entire history. Currently, only parameters from the same DataMiner Element can be proposed. The lightbulb only shows parameters related to one parameter, even if multiple curves are visisble on the trend graph. You can hover over the lightbulb icon to see for which parameter relations are proposed.

You can for instance use this in case a parameter (e.g. the total available memory of a server) behaves oddly during a particular time range (e.g. a downward spike), in order to find out if other parameters of the same device also showed unusual behavior during the same time range.

## Prerequisites

- The DataMiner System must use an indexing database (i.e. Elasticsearch or OpenSearch). See [Supported system data storage architectures](xref:Supported_system_data_storage_architectures).

- Behavioral anomaly detection must be enabled. You can enable this feature in System Center, via *System settings* > *analytics config*. Enabling this feature allows DataMiner to generate data based on what happens in your system, so that it can understand what is going on.

  ![System Center analytics config page](~/user-guide/images/Analytics_anomaly_detection.jpg)<br>
  *System Center analytics config page in DataMiner 10.3.5*

## Adding a time-scoped related parameter to a trend graph

To add a related parameter for a specific time range only:

1. In a trend graph showing trend information for one single parameter, **select the section of the graph** where the parameter shows the behavior you are interested in. The way you can do so depends on the configuration of the trending user settings. See [Trending settings](xref:User_settings#trending-settings).

1. Click the light bulb icon. This will open a menu with the parameters related to your original parameter, but only taking into account the behavior within the time range of the selected region.

1. Select the parameter you want to add.

   If other related parameters are available that have not been added yet, you can click the light bulb again to add those parameters as well.

> [!NOTE]
> The light bulb icon is always displayed regardless of whether DataMiner was able to find related parameters for the selected section. If no related parameters were found, the light bulb icon will not be "lit up" with an accent color as it would otherwise be. Click the icon for more information on why no related parameters could be found.
