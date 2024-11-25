---
uid: SwarmingEnable
---

# Enabling the Swarming feature

This page shows how you can activate the Swarming feature on a DataMiner system.

> [!WARNING]
> It is highly recommended to create a backup before enabling the Swarming feature.

## Prerequisites

- DataMiner v10.5.1+
- [STaaS](xref:STaaS) or a [dedicated clustered storage](xref:Configuring_dedicated_clustered_storage)
- There may not be Failover agents in the cluster
- There may not be an offload database configured
- There may not be Enhanced Services using non-compatible connectors ([more info](xref:SwarmingPrepare))
- Scripts (Automation/GQI) should not use any obsolete and incompatible SLNet calls/properties that handle AlarmIDs as 'DmaID/AlarmID' ([more info](xref:SwarmingPrepare))
- Only users having the *Admin Tools* permission can enable Swarming.

> [!TIP]
> To verify whether your system satisfies these prerequisites ahead of trying to enable Swarming, you can send a `SwarmingPrerequisitesCheckRequest` message to SLNet using the SLNetClientTest tool. This which will give you a summary of above checks.
> The response will show which prerequisites are not met. For the obsolete AlarmID usages that need to be replaced or removed, it will give you a summary of which scripts use which deprecated calls and/or properties.
>
> The same checks are also executed when enabling Swarming and must pass to be able to be allowed to enable Swarming.
>
> Note that this `SwarmingPrerequisitesCheckRequest` might take a while to execute because of legacy alarm id usage detection in scripts.

## Enabling Swarming

This section describes how to enable the Swarming feature on a DataMiner System.

When Swarming is enabled, element configuration will be stored in the cluster wide database rather than in element XML files on disk. Next to that, alarm ids will be generated on a per-element level instead of per agent. These changes enable other agents to swarm elements from dead agents.

On first startup, the existing element XML files get moved from disk into the database. Moving these files can take some minutes. While this is happening, a message is displayed on the clients that are trying to connect.

The migrated element files are **temporarily** backed up in the `Recycle Bin` (e.g. `2024_11_20 11_03_12_300_ElementFolder_BeforeSwarmingMigration.zip`). It is advised to store these somewhere safe if you ever want to access these again later, or to take a backup prior to enabling the Swarming feature.

> [!IMPORTANT]
> There is no good way to move these files back from database to disk. This effectively means there is no good way to turn Swarming off. Disabling Swarming would mean you would lose all your elements leaving your DMS with a lot of lingering references to non-existing elements. For instructions on how to disable Swarming and **partially** recover your elements, see [Partially rollback Swarming](xref:TutorialSwarmingPartiallyRollBack).

Enabling Swarming for the whole DMS can be done via the SLNet message `EnableSwarmingRequest` with the default parameters. This message will check for all agents if the prerequisites are met and if so, enable Swarming and **restart** the whole DMS.
There is currently no UI for this in Cube, so this has to be done via another client such as Client Test Tool or via an automation script.

> [!NOTE]
> The `EnableSwarmingRequest` might take a while to execute because of the prerequisite checks it does (legacy alarm id usage detection in scripts).

After the restart, one way to verify that the Swarming feature has been activated is by checking the *SLSwarming.txt* logfile for the presence of a line `SwarmingManager::SwarmingManager|INF|-1|Swarming enabled`. This can be done in Cube through *System Center > Logging > dataminer > Swarming*. This logfile also shows details on the migration of elements that happened during DMA startup.

Once swarming is enabled, eligible elements can be swarmed in a cluster through e.g. the *System Center > Agents > Status > Swarm* window.

> [!NOTE]
> Elements that are not Swarmable will not show up in this UI.

## Permissions

Swarming elements requires the new Swarming permission and also config rights on the element. This can be configured through System Center.

> [!NOTE]
> Groups that previously had the *DELT Import & Export* permissions will retroactively have the Swarming permission enabled.

## Support

Below is an overview of the differences between a system that does not have the swarming feature enabled vs one that has:

> [!NOTE]
> Where possible, non-supported objects are actively being blocked when trying to enabled the Swarming feature or when trying to configure/create them on a Swarming-enabled system.

| | 10.5.1+&nbsp;(No&nbsp;Swarming) | 10.5.1+&nbsp;(With&nbsp;Swarming) |
| --- | --- | --- |
| Element Configuration | On disk (element.xml) | In database |
| Alarm IDs | Per DataMiner Agent | Per Element |
| Database Per Agent | Supported | Not Supported |
| Script & QActions using legacy alarm references | Supported | Not Supported |
| LegacyReportsAndDashboards | Supported | Not Supported |
| Failover | Supported | Not Supported |
| Legacy Correlation | Not Supported | Not Supported |
| Central Database | Supported | Not Supported* |
| SLA elements | Supported | Supported but not swarmable* |
| Enhanced services | Supported | Supported** but not swarmable* |
| Spectrum Elements | Supported | Supported but not swarmable* |
| Redundancy group elements | Supported | Supported but not swarmable* |
| Elements exporting DVEs of Functions | Supported | Supported but not swarmable* |
| CPE elements | Supported | Supported but not swarmable* |
| Elements polling localhost | Supported | Supported but not swarmable |
| Elements with element connections | Supported | Supported but not swarmable* |
| Smart-serial elements in server mode | Supported | Supported but not swarmable |
| Elements receiving SNMP traps | Supported | Supported but not swarmable |

(*) In initial release

(**) [Enhanced Service connectors might need an update](xref:TutorialSwarmingUpdateServiceConnector)

## Troubleshooting

### DataMiner not starting up

- Double-check whether the database being used is compatible for Swarming.

- Check the *SLErrors.txt* and *SLSwarming.txt* log files for swarming-related errors.

- Double-check the *Swarming.xml* configuration file for errors.

- Check *SLDataMiner.txt* and *SLNet.txt* for any critical exceptions (eg when an invalid setup is detected)
