---
uid: SLNetClientTest_managing_RAD_parameter_groups
---

# Managing parameter groups for RAD

From DataMiner 10.5.4/10.6.0 onwards<!--RN 42181-->, it is possible to manage [relational anomaly detection (RAD)](xref:Relational_anomaly_detection) parameter groups using the SLNetClientTest tool. With these messages you can for example configure a [low-code app](xref:Application_framework) to visualize and manage the parameter groups.

All configuration settings are stored in the *ai_rad_models_v2* database table.

In Feature Release versions up to DataMiner 10.5.8<!--RN 43400-->, it is also possible to configure and view the same settings directly in [*RelationalAnomalyDetection.xml*](xref:Relational_anomaly_detection#configuring-relational-anomaly-groups).

1. [Connect to the DMA hosting the grouped parameters using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* dropdown list, choose one of the following messages. All message names start with the `Skyline.DataMiner.Analytics.Rad.` prefix:

   | Message | Function |
   |--|--|
   | AddRADParameterGroupMessage | Creates a new RAD parameter group. If a group with the same name already exists, the group will be updated instead. |
   | GetRADDataMessage | Retrieves anomaly scores over a specified time range. Note that anomaly scores can only be retrieved for past time periods where 5-minute averaged trend data is available. |
   | GetRADParameterGroupInfoMessage | Retrieves the configuration information for a specific RAD parameter group. From DataMiner 10.5.9/10.6.0 onwards<!--RN 43320-->, the response to this message also includes an `IsMonitored` flag, which indicates whether the group is correctly being monitored ("true"), or whether an error has occurred that prevents the group from being monitored ("false"). In the latter case, more information can be found in the SLAnalytics logging. From DataMiner 10.6.2/10.7.0 onwards<!--RN 44237-->, the response also includes the ID of the RAD parameter group. |
   | GetRADParameterGroupsMessage | Retrieves a list of all configured RAD parameter groups. |
   | RemoveRADParameterGroupMessage | Deletes a RAD parameter group. |

   > [!NOTE]
   > In DataMiner 10.5.4<!--RN 42480-->, some of these messages may include "MAD" instead of "RAD", e.g., *Skyline.DataMiner.Analytics.MAD.AddMADParameterGroupMessage*. In this message, "MAD" stands for "multivariate anomaly detection", which is another name for RAD.

1. Configure the necessary fields:

   - *AddRADParameterGroupMessage*:

     - *GroupInfo* > *AnomalyThreshold*: Optional. Defines the threshold for suggestion event generation. A higher value results in fewer suggestion events, a lower value results in more. If not specified, the default value `6` is used (`3` in versions prior to DataMiner 10.5.9/10.6.0<!--RN 43400-->).

     - *GroupInfo* > *MinimumAnomalyDuration*: Optional. The minimum duration (in minutes) that deviating behavior must persist to be considered a significant anomaly. If not specified, the default value `15` is used (`5` in versions prior to DataMiner 10.5.9/10.6.0<!--RN 43400-->).

     - *GroupInfo* > *Name*: The name of the parameter group.

     - *GroupInfo* > *Parameters*: A list of parameter instances (DataMiner ID, Element ID, Parameter ID, Primary Key) that will be monitored together by a RAD model.

     - *GroupInfo* > *UpdateModel*: Indicates whether the model should be updated continuously as new data becomes available (*true*), or only be trained initially based on available data at startup (*false*).

   - *GetRADDataMessage*:

     - *EndTime*: The end time of the period for which you want to retrieve anomaly scores.

     - *GroupName*: The name of the parameter group.

     - *StartTime*: The start time of the period for which you want to retrieve anomaly scores.

     > [!NOTE]
     > Anomaly scores can only be retrieved for past time periods where 5-minute averaged trend data is available.

   - *GetRADParameterGroupInfoMessage* and *RemoveRADParameterGroupMessage*:

     - *GroupName*: The name of the parameter group.

   - *GetRADParameterGroupsMessage*: No additional fields need to be configured.

1. Click *Send Message*.

> [!NOTE]
>
> - Keep in mind that the group names need to be unique and will be processed in a case-insensitive manner.
> - From DataMiner 10.5.4/10.6.0 onwards, you can also [retrain the internal model used by RAD](xref:SLNetClientTest_retrain_rad_model).

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
