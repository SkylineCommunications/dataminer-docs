---
uid: Relational_anomaly_detection
---

# Relational anomaly detection

From DataMiner 10.5.3/10.6.0 onwards, you can use relational anomaly detection (RAD) to detect when a group of parameters, also known as a "relational anomaly group", deviates from its normal behavior.<!-- RN 42034 -->

The RAD functionality works in three different steps:

1. First you need to [configure one or more groups of parameters](#configuring-relational-anomaly-groups) that should be monitored together, e.g. a main bit rate and backup bit rate.

1. The algorithm will then **learn the relations** between the parameters, e.g. learn that main and backup are typically equal. This is done automatically by the system, but you can manually specify a training range.

1. Whenever a detected relation is broken, e.g. the main is no longer equal to the backup, RAD will generate [suggestion events in the Alarm Console](#relational-anomalies-in-the-alarm-console).

![The three steps of the RAD algorithm](~/dataminer/images/tutorial_RAD_Overview_Algorithm.jpg)

Every five minutes, RAD calculates an anomaly score for each configured relational anomaly group. This score is based on the average value of each parameter in that group over the last five minutes. A high anomaly score indicates that the relationships between the parameters are broken, whereas a low anomaly score means the relationships remain intact. Historical anomaly scores can be visualized in the [RAD Manager](xref:RAD_manager) app.

## Prerequisites

RAD uses average trending to detect anomalies. As such, it requires **numeric** parameters with **at least one week of five-minute average trend data**. If at least one parameter has less than a week of trend data available, monitoring will only start after one week of data has been collected.

This means that the following prerequisites apply:

- Average trending has to be enabled for each parameter used in a RAD group.
- The TTL for five-minute average trend data has to be set to more than one week (recommended setting: 1 month).

## Use cases

By way of example, here are a few of the possible use cases for relational anomaly detection:

- **Main and backup transcoders (Xcoders)**: Monitor the output bit rate differences between main and backup transcoders to make sure that your backup remains synced with the main.

- **Bonded Interfaces**: Spot differences in bit rates across bonded interfaces. This can provide early warnings for failures in the load balancing circuit or for issues with individual interfaces or fibers.

- **UPS Management**: Decide on the best time to replace your battery. For a full use case description, refer to [UPS Management Use Case](https://community.dataminer.services/cut-ups-costs-and-prevent-outages-with-ai-powered-monitoring/).

- **Temperatures vs. fan speeds**: Monitor whether the fan speed of a device is in sync with the temperature of the device. This can help identify faults in the cooling system or in the device itself.

- **Power amplifiers in DAB transmitters**: Monitor the power outputs of all amplifiers in a DAB transmitter to ensure they remain in sync. This helps identify faults in the transmitter or the antenna system. For a tutorial on how to set up RAD for this use case, refer to [Working with relational anomaly detection](xref:Relational_Anomaly_Detection_Tutorial).

## Configuring relational anomaly groups

RAD only monitors parameters that have been added to one or more relational anomaly groups in its configuration. Each relational anomaly group represents a set of parameters that should be monitored together. RAD will learn how these parameters are related and notify you through a suggestion event when the relationship is broken.

The easiest way to configure these relational anomaly groups is by using the [RAD Manager](xref:RAD_manager) app from the DataMiner Catalog. Alternatively, you can use the [RAD API](xref:RAD_API).

### Options for relational anomaly groups

For each relational anomaly group, several configuration options are available. The table below provides an overview of these options:

| <div style="width:200px">Name in RAD Manager app</div> | Name in API and XML | Description |
|--|--|--|
| Group name | `name` | The name of the relational anomaly group. This name is used when generating a suggestion event or displaying all groups in the *RAD Manager*. |
| Update model on new data? | `updateModel` | Indicates whether RAD should update its internal model of the relationships between the parameters in the group when new trend data is available. If this is not selected, the model will only be trained immediately after creation and when [manually specifying a training range](xref:RAD_manager#configuring-model-training).<br>Enabling this can be useful when monitoring parameters that you would like to see changing over time; the model can then adapt to the new behavior, and only more pronounced breaks in relations will be detected. If the parameter relationship is static (e.g. two parameters that should remain equal forever), it is better not to enable this option.|
| Anomaly threshold | `anomalyThreshold` in API, `anomalyScore` in XML | The threshold used for suggestion event generation. Suggestion events are generated when RAD detects a region with an anomaly score higher than this threshold. A higher threshold results in fewer suggestion events, while a lower threshold results in more. Default: 6 (or 3 prior to DataMiner 10.5.9/10.6.0<!-- RN 43400 -->).|
| Minimum anomaly duration | `minimumAnomalyDuration` | Supported from DataMiner 10.5.4/10.6.0 onwards. <!-- RN 42283 --> This option specifies the minimum duration (in minutes) that deviating behavior must persist to be considered a significant anomaly, similar to [alarm hysteresis](xref:Alarm_hysteresis). This value must be 5 minutes or higher. If this is set to a value greater than 5 minutes, the deviating behavior must persist longer before an anomaly event is triggered. You can configure this to filter out noise events due to a single, short, harmless outlier, for instance caused by a planned maintenance or a device restart. Default: 15 minutes (or 5 minutes prior to DataMiner 10.5.9<!-- RN 43400 -->). |

### Shared model groups

From DataMiner 10.5.9/10.6.0 onwards, the [RAD API](xref:RAD_API) supports the creation of **shared model groups**. A shared model group consists of multiple relational anomaly subgroups that all use the same underlying model. This approach is particularly valuable when you need to monitor many entities that share genuine behavioral similarities.

Note that shared models generalize across subgroups, which can reduce accuracy for specific cases compared to dedicated single models trained on individual subgroup data. However, they can be especially effective when dealing with many subgroups, some of which may lack sufficient healthy reference data.

> [!NOTE]
> The [RAD Manager app](xref:RAD_manager) supports shared model groups from version 4.0.0 onwards. Older versions of the app only support single groups, where each group of parameters is associated with its own dedicated model.

#### Shared model use case example

Consider the [UPS Management Use Case](https://community.dataminer.services/cut-ups-costs-and-prevent-outages-with-ai-powered-monitoring/), where a battery system included many units, each containing several cells with voltage and current parameters. In healthy battery units, these values remain similar across cells and fluctuate together.

Because this behavior is consistent across all units, you can define a shared model group with a subgroup per battery. This allows a single model to monitor all battery units and detect deviations from expected patterns.

#### Identifying anomalous subgroups in a shared model group

The **fleet outlier detection** feature is available from DataMiner 10.5.12/10.6.0 onwards<!-- 43934 -->. It provides a high-level assessment of subgroups within a shared model group, helping you quickly identify individual assets or subgroups that behave unusually compared to their peers.

This detection method operates differently from relational anomaly detection (RAD):

- **RAD**: Focuses on the internal consistency and status of a single unit (or subgroup). For example, It checks whether the individual cell voltages within a single battery unit fluctuate together as expected.

- **Fleet outlier detection**: Analyzes the collective behavior of all units within a shared model. It establishes a "normal" performance baseline for the group and identifies any specific unit or subgroup that significantly deviates from this standard. This highlights issues between groups. For example, fleet outlier detection can identify the single battery unit whose overall parameters behave atypically compared to other batteries in the fleet, even if its internal parameters fluctuate consistently over time.

Within the [RAD Manager app](xref:RAD_manager), the affected shared model subgroups are explicitly labeled as "Outlier Group".

The [RAD API](xref:RAD_API) provides ways to retrieve a score for each subgroup in a shared model group. This score quantifies the degree of difference from the rest of the group, enabling automated sorting and prioritization of the most statistically anomalous units. The higher the score, the more critical the difference in behavior compared to its peers.

## Relational anomalies in the Alarm Console

Whenever the relationship for a relational anomaly group is broken, RAD detects this and generates suggestion events in the Alarm Console. These events can be viewed in the *Relational Anomalies* tab, accessible through [the Alarm Console light bulb](xref:Light_Bulb_Feature), or in the *Suggestion events* tab (see [Adding and Removing Alarm Tabs in the Alarm Console](xref:ChangingTheAlarmConsoleLayout#adding-and-removing-alarm-tabs-in-the-alarm-console)).

Suggestion events for the same group of parameters are grouped into a single incident. Clearing the grouped incident will also clear all suggestion events included in it. Other changes (e.g., taking ownership, adding comments) are not supported for grouped incidents. Note that prior to DataMiner 10.5.4, <!-- RN 41983, 42050 --> a separate suggestion event was generated for each parameter in the group where a broken relationship was detected.

From DataMiner 10.5.6/10.6.0 onwards<!--RN 42602-->, [deleting a relational anomaly group](xref:RAD_manager#removing-a-relational-anomaly-parameter-group) will also clear all open suggestion events associated with that group.

## Relational anomalies in trend graphs

From DataMiner 10.4.0 [CU22]/10.5.0 [CU10]/10.6.0/10.6.1 onwards<!-- RN 43857 -->, when you view a trend graph for a parameter that has relational anomalies, these will be indicated by tags.

Hovering over a tag button or right-clicking and selecting *Expand tags* will highlight the anomalies in orange.

Additionally, a "+" icon will appear to the right of multivariate trend pattern tags and relational anomaly tags when not all involved parameters are currently loaded in the graph. Clicking the icon will load all parameters associated with the multi-variate trend pattern or the anomaly.

![Relational anomaly group in trend graph](~/dataminer/images/RAD_trend_graph.gif)<br>*Trend graph showing a relational anomaly in DataMiner 10.6.1*

## Limitations

- Monitoring parameters hosted on **multiple DataMiner Agents within a single relational anomaly group** is only supported from DataMiner 10.5.11/10.6.0 onwards.<!-- RN 43686 --> In previous DataMiner versions, all parameters in a group must be hosted on the same DMA. Note also that prior to DataMiner 10.5.9/10.6.0<!--RN 43320-->, the *RelationalAnomalyDetection.xml* file on a given DMA can only include parameters hosted on that same DMA.

- Prior to DataMiner 10.5.11/10.6.0<!-- RN 43686 -->, a relational anomaly group will stop working if any elements in that group are [swarmed](xref:Swarming) to other DMAs. In more recent DataMiner versions, they will continue to work, but any active anomalies are cleared if elements involved in those anomalies are swarmed. Starting from DataMiner 10.5.12/10.6.0<!-- RN 43769 -->, after an element is swarmed, the relational anomaly group is also moved to the Agent hosting the majority of its parameters if necessary.

- Some parameter behavior will cause RAD to work less accurately. For example, if a parameter responds to another parameter with a delay, such as a door opening gradually lowering a room's temperature, RAD may generate less precise results.

- Parameters on DVE children can only be monitored directly by RAD from DataMiner 10.5.9/10.6.0 onwards <!-- RN 43320 -->. In earlier versions, you should monitor the corresponding parameter instance on the DVE parent.

- Relational anomalies on history set parameters can only be detected from DataMiner 10.5.4/10.6.0 onwards, and only under certain conditions:<!-- RN 42319 -->

  - If there is at least one history set parameter in a RAD parameter group, that parameter group will only be processed when all data from all parameters in the group has been received. In other words, if a history set parameter receives data 30 minutes later than the real-time parameters, possible anomalies will only be detected after 30 minutes.
  - RAD will only process data received within the last hour. If a history set parameter receives data more than an hour later than the real-time parameters, that data will be disregarded.
