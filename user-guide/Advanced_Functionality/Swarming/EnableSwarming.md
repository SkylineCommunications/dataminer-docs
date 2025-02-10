---
uid: EnableSwarming
---

# Enabling the Swarming feature

> [!IMPORTANT]
> We highly recommend creating a backup before enabling the Swarming feature.

## Prerequisites

- DataMiner 10.5.1/10.6.0 or higher.
- [STaaS](xref:STaaS) or a [dedicated clustered storage](xref:Configuring_dedicated_clustered_storage) setup.
- No [Failover Agents](xref:About_DMA_Failover) are present in the cluster.
- No [data offloads](xref:Offload_database) are configured.
- Enhanced services in the cluster (if any) use only [compatible connectors](xref:SwarmingPrepare).
- Scripts (Automation/GQI) and QActions in connectors have all been [made compatible](xref:SwarmingPrepare), i.e. they do not use obsolete or incompatible SLNet calls/properties that handle Alarm IDs as "DmaID/AlarmID".
- For the user account that will be used to enable Swarming, the [Admin Tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission is enabled.

## Running a prerequisites check

To verify whether your system meets these prerequisites before you enable Swarming, you can send a *SwarmingPrerequisitesCheckRequest* message to SLNet using the [SLNetClientTest tool](xref:SLNetClientTest_tool). The prerequisite check is also executed when you enable Swarming, ensuring that all prerequisites are met before Swarming is enabled.

> [!NOTE]
> The prerequisites check can take some time, as checking the usage of legacy alarm IDs in scripts can take several minutes.

To run a prerequisites check using SLNetClientTest tool:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   > [!CAUTION]
   > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select the message *Skyline.DataMiner.Net.Swarming.SwarmingPrerequisitesCheckRequest*.

   By default, the *DataMinerID* property for the message will be set to -1, which means that the entire cluster will be checked.

   If you do not want to check the alarm ID usage yet, but you want to run a first, quicker check for the other prerequisites, you can set the *AnalyzeAlarmIDUsage* property to false.

1. Click *Send Message*.

   While the prerequisites check is running, this will be indicated at the bottom of the window. When the check is complete, the tool will switch to the *Properties* tab.

1. In the *Properties* tab, make sure the top message is selected, and check the summary in the pane on the right.

   For each prerequisite, the tool will indicate whether the prerequisite is met (*True*) or not (*False*). If you hover over the *Summary* item, you will get a detailed overview of which items cause prerequisites not to be met (e.g. specific scripts, enhanced service connectors, connectors using the obsolete alarm ID format, etc.).

> [!IMPORTANT]
> Obsolete Engine methods are only included in the prerequisites check from DataMiner 10.5.3 onwards<!--RN 42073-->. If you are using DataMiner 10.5.1 or 10.5.2, these obsolete methods may still be present even if the prerequisite check does not report any issues.
> The following Engine methods are obsolete and should not be used:
>
> - GetAlarmProperty
> - SetAlarmProperty
> - SetAlarmProperties
> - AcknowledgeAlarm

## Enabling Swarming

When you have made sure prerequisites are met, and you are ready to enable Swarming, you can do so using the SLNet message *EnableSwarmingRequest* (with the default parameters) in SLNetClientTest tool or an Automation script. Enabling Swarming via DataMiner Cube is currently not yet possible.

> [!IMPORTANT]
> When you enable swarming, the element configuration will be moved from disk to database. This change can only partially be rolled back. See [Partially rolling back Swarming](xref:SwarmingRollback). We highly recommend taking a backup before enabling Swarming.

To enable Swarming using SLNetClientTest tool:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   > [!CAUTION]
   > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select the message *Skyline.DataMiner.Net.Swarming.EnableSwarmingRequest*.

   This message will need to be sent with its default settings, so do not make any changes to the settings for the message.

1. Click *Send Message*.

   If a confirmation box appears, click *Yes*.

   The prerequisites, including the usage of legacy alarm IDs in scripts, will be checked for all Agents in the system, which can take several minutes. If the prerequisites are met, Swarming will enabled and all Agents in the DMS will be **restarted**.

   If SLNetClientTest tool is unable to reach any of the Agents at the time of the check, for example because an Agent is stopped, Swarming will not be enabled.<!-- RN 41217 -->

   After Swarming is enabled, when DataMiner starts up again for the first time, the existing element XML files will be moved from the disk to the database. This can also take several minutes. While this is happening, a message will be displayed on any clients that are trying to connect.

> [!NOTE]
> The migrated element files will be **temporarily** backed up in the *Recycle Bin* (e.g. *2024_11_20 11_03_12_300_ElementFolder_BeforeSwarmingMigration.zip*). We recommend that you store these files somewhere safe if you ever want to access these again later or if you want to be able to [partially roll back Swarming](wref:SwarmingRollback).

## Verifying that the feature is active

Once all Agents have been restarted, you can verify whether the Swarming feature has been activated by checking if the following line is present in the *SLSwarming.txt* log file:

`SwarmingManager::SwarmingManager|INF|-1|Swarming enabled`

You can find this log file in DataMiner Cube via *System Center* > *Logging* > *dataminer* > *Swarming*. The log file also shows details on the migration of elements that happened during DMA startup.

Once Swarming is enabled, you can go to *System Center* > *Agents* > *Status* > *Swarm* to swarm elements for which this feature is supported. However, note that this is only available in DataMiner Systems consisting of multiple Agents.

> [!NOTE]
> Elements for which swarming is not supported will not be shown in this UI.

## Troubleshooting

### DataMiner not starting up

- Double-check whether the DataMiner System uses a database compatible with Swarming. See [Prerequisites](#prerequisites).

- Check the *SLErrors.txt* and *SLSwarming.txt* log files for swarming-related errors.

- Double-check the *Swarming.xml* configuration file for errors.

- Check *SLDataMiner.txt* and *SLNet.txt* for any critical exceptions (e.g. an invalid setup is detected).
