---
uid: SoftLaunchOptions
---

# Soft-launch options

If you are addicted to new functionality and you always want to try out the very latest features, even when these have not yet been officially released, this page is the place to be for you. This is where you will find out about the soft-launch features in DataMiner, and how you can activate them.

## About soft launch

Soft-launch features are DataMiner features that have not yet been made available to the general public, but by activating specific options you can access them already. However, before you do so, read the disclaimer below:

- Make sure you validate soft-launch features on your **staging platform**, and do not activate them on your production system unless you have synced with Skyline to make an assessment on the risk.
- **No backwards compatibility** is guaranteed for these features. This means that if they require setup work, you may have to redo your work once the functionality is effectively released.
- These features typically have **not been stress tested** yet.
- **Hotfixes will not be provided** for soft-launch features. The only way to get a fix for them is by installing the latest feature release.

If you accept these limitations, feel tree to activate the soft-launch options of your choice. And obviously, your feedback on these preview features will be much appreciated.

## Activating soft-launch options

For most soft-launch options, you will need the following file on your DataMiner server: `C:\Skyline DataMiner\SoftLaunchOptions.xml`. In this file, for each feature you want to activate, you can add a specific tag and set it to the value "true".

For example, this *SoftLaunchOptions.xml* configuration activates the "AlarmSquashing" and "CloudConnectedAgents" features:

```xml
<SLNet>
   <CloudConnectedAgents>true</CloudConnectedAgents>
   <AlarmSquashing>true</AlarmSquashing>
</SLNet>
```

> [!NOTE]
> All XML tags in *SoftLaunchOptions.xml* are case-sensitive.

After you have modified this configuration file, you must **restart your DataMiner Agent** to activate the changes. If you have a cluster of DataMiner Agents, every DataMiner Agent in the cluster will need to be restarted. Many of the soft-launch options also require an **IIS restart** when they are activated.

For some **Cube-only** features, it is not necessary to configure a tag in SoftLaunchOptions.xml. For these features, it is sufficient to access DataMiner Cube using a specific **argument**. In the Cube desktop app, you can specify this argument in the start window by clicking the “…” button in the tile representing the DMS you want to connect to, and then specifying the argument in the *Advanced* section. For more information, see [Arguments for DataMiner Cube](xref:Options_for_opening_DataMiner_Cube).

For some features, a different configuration may be required. You can find more information about this below.

## Overview of soft-launch options

The table below contains an overview of all available soft-launch options. Unless otherwise specified, the key in the “Feature key” column must be added in SoftLaunchOptions.xml with the value “true” in order to activate the feature.

The table also details the minimum DataMiner version to start using each option and, in case the feature has already been officially released in a later DataMiner version, the “Release version” when it becomes available. From that “Release version” onwards, the feature is active by default and any soft-launch configuration for the feature is ignored. As such, it is not necessary to remove a tag from SoftLaunchOptions.xml when the corresponding feature is officially released.

Note that some features never make it to an official release. These are tagged as “Deprecated”.

### AlarmFocus

See [Filtering alarms on alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus).

- **Minimum version**: 9.6.13
- **Release version**: 10.0.1

### AlarmForecasting

Enables proactive cap detection. See [Proactive cap detection](xref:Proactive_cap_detection).

- **Minimum version**: 9.5.12
- **Release version**: 10.0.11

### AlarmGrouping

Enables automatic incident tracking. See [Automatic incident tracking](xref:Automatic_incident_tracking).

- **Minimum version**: 10.0.3
- **Release version**: 10.0.11

### AlarmSquashing

Enables alarm tree optimization.

- **Minimum version**: 10.0.1
- **Release version**: 10.0.12

### AnomalyDetection

Enables behavioral anomaly detection and suggestion events. See [Behavioral anomaly detection](xref:Behavioral_anomaly_detection).

- **Minimum version**: 9.5.12
- **Release version**: 10.0.2

### APIDeployment

Enables dynamic API deployment on the SLAPIEndpoint application.

> [!NOTE]
> Requires the .NET 5.0 hosting bundle.

- **Minimum version**: 10.1.6

### Applications

Enables the [Low-Code Apps module](xref:Application_framework).

> [!NOTE]
> Requires an IIS restart.

- **Minimum version**: 10.0.8
- **Release version**: 10.2.5

### BookingData

Enables the “BookingData” Visual Overview component.

- **Minimum version**: 10.2.7

### CassandraCluster

Allows you to set up the [Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) configuration in DataMiner Cube.

- **Minimum version**: 10.0.13
- **Release version**: 10.1.2

### CloudConnectedAgents

Enables cloud-connected Agents and allows you to [connect to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).

- **Minimum version**: 10.1.2
- **Release version**: 10.1.9

### CorrectedDisplayKeyOnNaming

  Takes exception values into account for display key generation.

- **Minimum version**: 10.0.11/9.6.0 [CU18]/10.0.0 [CU6]

### CorrelationTicketAction

Allows you to [create a ticket](xref:Creating_a_ticket) as a Correlation action.

- **Minimum version**: 9.6.5

### CPEIntegration

This is a Cube-only feature that can only be activated with the argument `ENABLEFEATURE=CPEINTEGRATION`. Note that you also need specific protocol changes in order to benefit from this.

- **Minimum version**: 9.6.7

### Diagnostics

Enable functionality to retrieve diagnostics from several DataMiner core processes.

- **Minimum version**: 9.6.3

### DirectViewRemoteDataUpdates

Updates the values of direct view tables.

- **Minimum version**: 10.0.11

### DOMManager

Enables the use of DOM data in dashboards and applications.

- **Minimum version**: 10.1.7

### DynamicUnits

Enables dynamic units in Data Display in DataMiner Cube and the Monitoring app. If you want to test this feature for one DataMiner Cube session only, use the argument `SOFTLAUNCH_DYNAMICUNITS=Enabled`.

- **Minimum version**: 10.0.12

### ElasticTicketing

Allows you to store tickets in the Elasticsearch database.

- **Minimum version**: 9.6.4
- **Release version**: 10.0.13

### FeatureOffload

Allows the offloading of specific DataMiner Analytics features to a specific DataMiner Node.

- **Minimum version**: 10.0.9

### Functions

Enables the Virtual Functions module in Cube. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=FUNCTIONS`.

- **Minimum version**: 10.0.10

### GenericInterface

Provides access to additional data sources and operators for GQI in the Dashboards app and Low-Code Apps.

> [!NOTE]
> From DataMiner 10.1.6 onwards, this option is no longer needed for the DCF connections GQI data source.

- **Minimum version**: 10.0.13

### GenericOwnership

Enables the ownership framework.

- **Minimum version**: 9.5.11

### Indexing

Enables the use of Elasticsearch for alarm indexing and other applications. To preview the indexing configuration in DataMiner Cube, use the argument `ENABLEFEATURE=Indexing`.

- **Minimum version**: 9.5.0
- **Release version**: 10.0.8

### JobManager

Enables the [Jobs app](xref:jobs).

- **Minimum version**: 9.6.2
- **Release version**: 9.6.4

### LegacyAnnotations

Shows the legacy Annotations module in Cube. By default set to false for new installations, but set to true when updating existing setups.

- **Minimum version**: 10.1.12

### LegacyReportsAndDashboards

Shows the legacy Reports & Dashboards module in Cube. By default set to false for new installations, but set to true when updating existing setups.

- **Minimum version**: 10.1.12

### MonitoringAndControl

Enables the new Monitoring app. See [Accessing the Monitoring app](xref:Accessing_the_Monitoring_app) and [The Monitoring app user interface](xref:The_Monitoring_app_user_interface).

- **Minimum version**: 9.6.7
- **Release version**: 10.0.0

### NATS

Installs NATS and NAS on the DMA. If this option is enabled on all DMAs in the cluster, the NATS configuration will be updated so that a single NATS cluster is created.

- **Minimum version**: 10.0.13
- **Release version**: 10.1.1

### NewAverageTrending

Enables the new average trending feature. From DataMiner 10.0.12 onwards, this is automatically enabled if a Cassandra cluster setup is used.

- **Minimum version**: 10.0.6
- **Release version**: 10.1.10

### PlannedMaintenance

Enables the Planned Maintenance module.

> [!NOTE]
> Deprecated: The Planned Maintenance module is now available as an application package. It is not enabled in the core DataMiner software.

- **Minimum version**: 9.5.13

### ReportsAndDashboards

Enables the [Dashboards app](xref:newR_D).

- **Minimum version**: 9.5.8
- **Release version**: 9.6.9

### ReportsAndDashboardsAlarmList

Enables the alarm list component in the Dashboards app.

- **Minimum version**: 9.6.8
- **Release version**: 10.1.5

### ReportsAndDashboardsAlpha

Enables alpha components in the Dashboards app.

- **Minimum version**: 9.6.6

### ReportsAndDashboardsAutomationScript

Enables the Automation script component in the Dashboards app.

- **Minimum version**: 9.6.8

### ReportsAndDashboardsButton

Enables the button component in the Dashboards app.

- **Minimum version**: 10.0.3

### ReportsAndDashboardsButtonPanel

Enables the button panel component in the Dashboards app.

- **Minimum version**: 10.0.3

### ReportsAndDashboardsExport

Enables the export to PDF button within the Dashboards app itself. Creating PDFs of dashboards is possible outside the app (e.g. via DataMiner Scheduler) without this soft-launch option.

- **Minimum version**: 9.6.4

### ReportsAndDashboardsGuides

Enables the guides in the Dashboards app.

- **Minimum version**: 9.6.8

### ReportsAndDashboardsPTP

Enables the Query Filter component in the Dashboards app.

> [!NOTE]
>
> - Prior to DataMiner 10.0.13, this option also enables the Generic Interface feature in the Dashboards app, which becomes available from 10.0.13 onwards (partially using the GenericInterface soft-launch option).
> - Prior to DataMiner 10.1.5, this option also enables the Node Edge component, which becomes available by default from DataMiner 10.1.5 onwards.

- **Minimum version**: 10.0.4

### ReportsAndDashboardsScheduler

Enables the Timeline component in the Dashboards app.

- **Minimum version**: 10.1.10

### ResourceList

Enables support for the source type “Resources” in list view components. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=ResourceList`.

- **Minimum version**: 10.1.3
- **Release version**: 10.1.11

### ServiceProfilesMigration

Enables the service profiles export and import in the DataMiner Cube Services app. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=ServiceProfilesMigration`.

- **Minimum version**: 10.1.7

### SLProtocolAsX64

Enables SLProtocol as a 64-bit process. This option is not configured in *SoftLaunchOptions.xml*. For more information on how to activate this, refer to [Activating SLProtocol as a 64-bit process](#activating-slprotocol-as-a-64-bit-process).

- **Minimum version**: 10.1.8

### SrmOwnServices

Enables ownership support for SRM services.

- **Minimum version**: 9.6.1

### SrmProtocolGeneration

Enables contributing service protocol generation.

- **Minimum version**: 9.6.1
- **Release version**: 9.6.11

### VisualDataManager

Enables the new VisualDataHelper.

- **Minimum version**: 9.6.1
- **Release version**: 9.6.4

### UseWebIAS

Uses an embedded web browser for Automation script execution instead of the native Cube pop-up window.

- **Minimum version**: 10.1.4

## Activating SLProtocol as a 64-bit process

There are **two ways** to activate this soft-launch feature, depending on whether you want to do so before you upgrade to a version supporting the feature, or after you upgrade.

- **Before the upgrade**:

  1. Create an empty text file named *SoftLaunchX64_SLProtocol.txt* in the folder `C:\Skyline DataMiner\Tools` on each DMA.
  1. Install the upgrade package.

- **After the upgrade**:

  1. Stop all DMAs in the cluster.
  1. On each DMA, execute `C:\Skyline DataMiner\Tools\RegisterSLProtocolAsX64.bat` from a command line prompt as administrator.
  1. Restart DataMiner.
