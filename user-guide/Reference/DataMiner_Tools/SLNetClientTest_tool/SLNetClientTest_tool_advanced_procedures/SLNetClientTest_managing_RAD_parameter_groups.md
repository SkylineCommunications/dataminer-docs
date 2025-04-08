---
uid: SLNetClientTest_managing_RAD_parameter_groups
---

# Managing parameter groups for RAD

From DataMiner 10.5.4/10.6.0 onwards<!--RN 42181-->, it is possible to manage [relational anomaly detection (RAD)](xref:Relational_anomaly_detection) parameter groups using the SLNetClientTest tool. While you can configure and view the same things directly in [*RelationalAnomalyDetection.xml*](xref:Relational_anomaly_detection#configuring-parameter-groups-for-rad), with these messages you can for example configure a [low-code app](xref:Application_framework) to visualize and manage the parameter groups.

1. [Connect to the DMA hosting the grouped parameters using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, choose one of the following messages:

   | Message | Function |
   |--|--|
   | Skyline.DataMiner.Analytics.Rad.AddRADParameterGroupMessage | Creates a new RAD parameter group. If a group with the same name already exists, the group will be updated instead. |
   | Skyline.DataMiner.Analytics.Rad.GetRADDataMessage | Retrieves anomaly scores over a specified time range. |
   | Skyline.DataMiner.Analytics.Rad.GetRADParameterGroupInfoMessage | Retrieves the configuration information for a specific RAD parameter group. |
   | Skyline.DataMiner.Analytics.Rad.GetRADParameterGroupsMessage | Retrieves a list of all configured RAD parameter groups. |
   | Skyline.DataMiner.Analytics.Rad.RemoveRADParameterGroupMessage | Deletes a RAD parameter group. |

   > [!NOTE]
   > In DataMiner 10.5.4, some of these messages may include "MAD" instead of "RAD", e.g. *Skyline.DataMiner.Analytics.MAD.AddMADParameterGroupMessage*. In this message, "MAD" stands for "multivariate anomaly detection", which is another name for RAD.

1. Configure the necessary fields:

   - *AddRADParameterGroupMessage*:

   - *GetRADDataMessage*:

     - *GroupName*: The name of the parameter group as configured in *RelationalAnomalyDetection.xml*.

     - *StartTime*: The start time of the period during which the parameter group was behaving as expected.

     - *EndTime*: The end time of the period during which the parameter group was behaving as expected.

   - *GetRADParameterGroupInfoMessage*:

     - *GroupName*: The name of the parameter group as configured in *RelationalAnomalyDetection.xml*.

   - *GetRADParameterGroupsMessage*:

   - *RemoveRADParameterGroupMessage*:

1. Click *Send Message*.

> [!NOTE]
>
> - Keep in mind that the group names need to be unique and will be processed in a case-insensitive manner.
> - From DataMiner 10.5.4/10.6.0 onwards, you can also [retrain the internal model used by RAD](xref:SLNetClientTest_retrain_rad_model).

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
