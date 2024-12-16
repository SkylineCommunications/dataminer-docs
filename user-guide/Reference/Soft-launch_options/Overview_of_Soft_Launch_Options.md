---
uid: Overview_of_Soft_Launch_Options
description: DataMiner soft-launch options activate features that are not yet available to the general public. They can be enabled in SoftLaunchOptions.xml.
---

# Overview of soft-launch options

The table below contains an overview of all available soft-launch options. Unless otherwise specified, the key in the "Feature key" column must be added in *SoftLaunchOptions.xml* with the value "true" in order to activate the feature.

The table also details the minimum DataMiner version to start using each option and, in case the feature has already been officially released in a later DataMiner version, the "Release version" when it becomes available. From that "Release version" onwards, the feature is active by default and any soft-launch configuration for the feature is ignored. As such, it is not necessary to remove a tag from *SoftLaunchOptions.xml* when the corresponding feature is officially released.

### AnomalyFeedback

Allows you to provide positive or negative feedback on anomaly suggestion events and alarms. This feedback is stored in the *ai_anomalyfeedback* table in the indexing database and is used to enhance anomaly event generation.

- **Minimum version**: 10.4.4<!--RN 38980-->
- **Release version**: 10.4.11<!--RN 39944+39945-->

### Applications

Enables the [Low-Code Apps module](xref:Application_framework).

> [!NOTE]
> Requires an IIS restart.

- **Minimum version**: 10.0.8
- **Release version**: 10.2.5/10.3.0 ([RN 33040](xref:General_Feature_Release_10.2.5#application-framework-id-33002-id-33040))

### BookingData

Enables the [BookingData](xref:Linking_a_shape_to_a_booking#making-the-booking-shape-display-booking-information) Visual Overview component.

- **Minimum version**: 10.2.7
- **Release version**: 10.3.8/10.4.0 ([RN 36489](xref:Cube_Feature_Release_10.3.8#visual-overview-new-bookingdata-component-id-33215-id-36489))

### BookingSwarming

Makes it possible to [swarm bookings](xref:SwarmingBookings).

- **Minimum version**: 10.5.1
- **Release version**: To be determined

### BrokerGateway

Disables specific NATS logic, in order to use the BrokerGateway DxM for the NATS configuration instead.

- **Minimum version**: 10.4.1<!-- RN 37649 -->

### CloudConnectedAgents

Makes it possible to [connect the DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- **Minimum version**: 10.1.2
- **Release version**: 10.1.9/10.2.0 ([RN 30513](xref:General_Feature_Release_10.1.9#connecting-a-dataminer-system-to-the-cloud-id-30513))

### CorrectedDisplayKeyOnNaming

  Takes exception values into account for display key generation.

- **Minimum version**: 10.0.11/9.6.0 [CU18]/10.0.0 [CU6]
- **Estimated Release version**: To be determined

### CPEIntegration

Enables the Topology app in DataMiner Cube. Note that you also need specific protocol changes in order to benefit from this. See [Topology app configuration](xref:Topology_app_configuration).

- **Minimum version**: 9.6.7
- **Estimated Release version**: To be determined

### DataAPI

Enables Data API functionality and scripted connectors. This displays the Data Sources module in DataMiner Cube.

- **Minimum version**: 10.4.2/10.4.0<!-- RN 36588/38307/38234 -->
- **Estimated Release version**: To be determined

> [!NOTE]
> The latest version of the DataAggregator DxM and DataAPI DxM also have to be installed for this feature to work.

### Diagnostics

Enable functionality to retrieve diagnostics from several DataMiner core processes.

- **Minimum version**: 9.6.3

### DirectViewRemoteDataUpdates

Updates the values of direct view tables.

- **Minimum version**: 10.0.11
- **Estimated release version**: To be determined

### DOMManager

Enables the use of DOM data in dashboards and applications.

- **Minimum version**: 10.1.7
- **Release version**: 10.3.6/10.4.0 ([RN 36124](xref:Web_apps_Feature_Release_10.3.6#dom-features-now-available-in-dashboards-and-low-code-apps-id-29732-id-31804-id-32236-id-36124))

### DynamicUnits

Allows you to enable dynamic units in Data Display in DataMiner Cube. When enabled, many numerical values are automatically converted into more readable formats with appropriate units. For example, 11 939 964 kB is displayed as 11.9 GB.

The following units are automatically converted:

- Bytes: B, kB, MB, GB, TB, PB, EB, ZB, YB
- Kibibytes: KiB, MiB, GiB, TiB, PiB, EiB, ZiB, YiB
- Bits: b, kb, Mb, Gb, Tb, Pb, Eb, Zb, Yb
- Bits per second: bps, kbps, Mbps, Gbps, Tbps, Pbps, Ebps, Zbps, Ybps
- Bytes per second: Bps, kBps, MBps, GBps, TBps, PBps, ZBps, YBps

From DataMiner 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1 onwards<!--RN 41436-->, this soft-launch feature is released and is enabled by default. To disable it, set this soft-launch option to *false*.

In versions prior to 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1, this feature is disabled by default. If you want to test this feature for one DataMiner Cube session only, use the argument `SOFTLAUNCH_DYNAMICUNITS=Enabled`.

- **Minimum version**: 10.0.12
- **Release version**: 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1 ([RN 41436](xref:Cube_Feature_Release_10.5.1#data-display-in-dataminer-cube-now-supports-dynamic-units-by-default-id-41436))

### Functions

Enables the Virtual Functions module in Cube. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=FUNCTIONS`.

- **Minimum version**: 10.0.10
- **Release version**: To be determined

### GenericInterface

Provides access to additional data sources and operators for GQI in the Dashboards app and Low-Code Apps.

> [!IMPORTANT]
> Requires an IIS and DataMiner restart.

> [!NOTE]
> Some features that originally required this option are fully available in recent DataMiner versions:
>
> - The DCF connections GQI data source (available from DataMiner 10.1.6 onwards).
> - The "Sort" operator (available from DataMiner 10.2.11/10.3.0 onwards).
> - The trend data patterns, trend data pattern events, and behavioral change events data sources (available from DataMiner 10.3.3/10.4.0 onwards).
> - The object manager instances data source (available from DataMiner 10.3.6 onwards).<!-- RN 36124 -->
> - The profile instances data source (available from DataMiner 10.3.0 CU11/10.4.2 onwards).<!-- RN 38138 -->

- **Minimum version**: 10.0.13
- **Minimum version for the custom operator**: 10.2.7
- **Release version for the custom operator**: 10.3.0 [CU10]/10.4.1 ([RN 37840](xref:Web_apps_Feature_Release_10.4.1#dashboards-app--low-code-apps-configuring-custom-operators-id-37840))
- **Estimated release version for other data sources and operators**: To be determined

### LegacyAnnotations

Enables or disables the legacy Annotations module.

- **Minimum version**: 10.1.10/10.2.0

> [!NOTE]
> The legacy Annotations module is disabled by default as from DataMiner versions 10.4.0/10.4.1 ([RN 37786](xref:General_Feature_Release_10.4.1#legacy-reports-dashboards-and-annotations-modules-are-now-end-of-life-and-will-be-disabled-by-default-id-37786)). If you want to keep on using this legacy module, set this soft-launch option to *true* (see [Activating SoftLaunch Options](xref:Activating_Soft_Launch_Options)), then run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator, and restart the DataMiner Agent.

### LegacyReportsAndDashboards

Enables or disables the legacy Reports and Dashboards modules.

- **Minimum version**: 10.1.10/10.2.0

> [!NOTE]
> The legacy Reports and Dashboards modules are disabled by default as from DataMiner versions 10.4.0/10.4.1 ([RN 37786](xref:General_Feature_Release_10.4.1#legacy-reports-dashboards-and-annotations-modules-are-now-end-of-life-and-will-be-disabled-by-default-id-37786)). If you want to keep on using these legacy modules, set this soft-launch option to *true* (see [Activating SoftLaunch Options](xref:Activating_Soft_Launch_Options)) before upgrading or uploading a 10.4.x upgrade package.

### ReportsAndDashboardsAlarmList

Enables the alarm list component in the Dashboards app.

- **Minimum version**: 9.6.8
- **Release version**: 10.1.5/10.2.0 ([RN 29456](xref:General_Feature_Release_10.1.5#dashboards-app-alarm-table-component-id-27790-id-28012-id-28142-id-28519-id-28718-id-28887-id-29131-id-29456))

### ReportsAndDashboardsAutomationScript

Enables the Automation script component in the Dashboards app, which is visualized as a button. This component can be used to execute scripts. It requires no data but can have elements or parameters as filters. If the *ReportsAndDashboardsButton* option is also enabled, one button component will be available that can be used with an Automation script or with a button parameter.

- **Minimum version**: 9.6.8
- **Estimated release version**: To be determined

### ReportsAndDashboardsButton

Enables the parameter button component in the Dashboards app. This component requires button parameters as data and can be used to trigger button parameters.

If the *ReportsAndDashboardsAutomationScript* option is also enabled, the button acts as an Automation script component instead unless a button parameter is added.

- **Minimum version**: 10.0.3
- **Estimated release version**: To be determined

### ReportsAndDashboardsButtonPanel

Enables the button panel component in the Dashboards app.

- **Minimum version**: 10.0.3
- **Release version**: 10.3.9/10.4.0 ([RN 36775](xref:Web_apps_Feature_Release_10.3.9#dashboards-app--low-code-apps-button-panel-visualization-now-officially-released-id-36775))

### ReportsAndDashboardsDynamicVisuals

Enables the grid component in the Dashboards app.

- **Minimum version**: 10.2.12
- **Release version**: 10.3.0 [CU10]/10.4.1 ([RN 37812](xref:Web_apps_Feature_Release_10.4.1#dashboards-app--low-code-apps-new-grid-and-timeline-components-id-33276-id-33287-id-34761-id-34948-id-37269-id-37699-id-37812))

### ReportsAndDashboardsExport

Enables the export to PDF button within the Dashboards app itself. Creating PDFs of dashboards is possible outside the app (e.g. via DataMiner Scheduler) without this soft-launch option.

- **Minimum version**: 9.6.4
- **Release version**: 10.2.12/10.3.0 ([RN 34634](xref:General_Feature_Release_10.2.12#dashboards-app-jobs-and-dashboards-app-now-support-pdf-module-id-34634))

### ReportsAndDashboardsGQIMaps

Enables a new Maps component in the Dashboards app and the Low-Code Apps.

- **Minimum version**: 10.3.2
- **Estimated release version**: 10.5.2

### ReportsAndDashboardsPTP

Enables the Query Filter component in the Dashboards app.

> [!NOTE]
>
> - Prior to DataMiner 10.0.13, this option also enables the Generic Interface feature in the Dashboards app, which becomes available from 10.0.13 onwards (partially using the GenericInterface soft-launch option).
> - Prior to DataMiner 10.1.5, this option also enables the Node Edge component, which becomes available by default from DataMiner 10.1.5 onwards.

- **Minimum version**: 10.0.4
- **Release version**: 10.3.9/10.4.0 ([RN 36822](xref:Web_apps_Feature_Release_10.3.9#dashboards-app--low-code-apps-query-filter-component-now-officially-released-id-33530-id-33547-id-34037-id-36822-id-36832))

### ReportsAndDashboardsScheduler

Enables the Timeline component in the Dashboards app.

- **Minimum version**: 10.1.10
- **Release version**: 10.3.0 [CU10]/10.4.1 ([RN 37812](xref:Web_apps_Feature_Release_10.4.1#dashboards-app--low-code-apps-new-grid-and-timeline-components-id-33276-id-33287-id-34761-id-34948-id-37269-id-37699-id-37812))

### ResourceList

Enables support for the source type "Resources" in list view components. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=ResourceList`.

- **Minimum version**: 10.1.3
- **Release version**: 10.1.11/10.2.0 ([RN 30998](xref:General_Feature_Release_10.1.11#visual-overview-listview-component-can-now-be-used-to-list-resources-id-28723-id-30998))

### ServiceProfilesMigration

Enables the service profiles export and import in the DataMiner Cube Services app. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=ServiceProfilesMigration`.

- **Minimum version**: 10.1.7
- **Release version**: To be determined

### SLProtocolAsX64

Enables SLProtocol as a 64-bit process. This option is not configured in *SoftLaunchOptions.xml*. For more information on how to activate this, refer to [Activating SLProtocol as a 64-bit process](xref:Activating_SLProtocol_as_a_64_Bit_Process).

- **Minimum version**: 10.1.8
- **Release version**: 10.3.9

### SLProtocolAsX86

Enables SLProtocol as a 32-bit process. This option is not configured in *SoftLaunchOptions.xml*. For more information on how to activate this, refer to [Activating SLProtocol as a 32-bit process](xref:Activating_SLProtocol_as_a_32_Bit_Process).

- **Minimum version**: 10.3.9
- **Release version**: N/A

### SnmpPollingSnmpPlusPlusOnly

Configures the DataMiner System to use SNMP++ for the polling of all three SNMP versions, instead of only for SNMPv3.<!-- RN 37778 -->

- **Minimum version**: 10.4.2
- **Release version**: To be determined.

> [!IMPORTANT]
>
> - This feature does not support polling of IPv6 addresses. In case IPv6 addresses are polled on your DMA, do not activate this feature.
> - [NT_SNMP_RAW_GET](xref:NT_SNMP_RAW_GET), [NT_SNMP_GET](xref:NT_SNMP_GET), [NT_SNMP_RAW_SET](xref:NT_SNMP_RAW_SET) and [NT_SNMP_SET](xref:NT_SNMP_SET) calls take this soft-launch option into account as from DataMiner versions 10.5.0/10.4.9.<!-- RN 40019 --> Prior to DataMiner versions 10.5.0/10.4.9, SNMPv1 and SNMPv2 `RawGet` and `RawSet` calls are always executed using WinSNMP.

### Swarming

Enables [Swarming](xref:Swarming) support for eligible systems.

- **Minimum version**: 10.3.11
- **Release version**: DataMiner 10.5.1/10.6.0<!-- RN 41490 -->

> [!NOTE]
> This soft-launch option is not supported in the Main Release track.<!-- RN 38016+41258 -->

### UseWebIAS

Uses an embedded web browser for Automation script execution instead of the native Cube pop-up window.

- **Minimum version**: 10.1.4

### UserDefinableAPI

Enables the Cube UI for [User-Defined APIs](xref:UD_APIs).

- **Minimum version**: 10.3.5
- **Release version**: 10.3.6/10.4.0 ([RN 36273](xref:General_Feature_Release_10.3.6#user-defined-apis-id-34910-id-35134-id-35169-id-35417-id-35743-id-35810-id-35880-id-35885-id-36118-id-36250-id-36273-id-36366))

### Deprecated soft-launch options

Below, you can find the soft-launch options that are no longer relevant for the currently supported DataMiner versions, as the related features have already been released or will not be released.

#### AlarmFocus

See [Filtering alarms on alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus).

- **Minimum version**: 9.6.13
- **Release version**: 10.0.0/10.0.2 ([RN 23911](xref:General_Feature_Release_10.0.2_new_features#dataminer-analytics-alarm-focus-23911id-24083id-24102id-24128))

#### AlarmForecasting

Enables proactive cap detection. See [Proactive cap detection](xref:Proactive_cap_detection).

- **Minimum version**: 9.5.12
- **Release version**: 10.1.0/10.0.11 ([RN 27132](xref:General_Feature_Release_10.0.11#proactive-cap-detection-id-26637id-27132id-27241id-27355id-27393))

#### AlarmGrouping

Enables automatic incident tracking. See [Automatic incident tracking](xref:Automatic_incident_tracking).

- **Minimum version**: 10.0.3
- **Release version**: 10.1.0/10.0.11 ([RN 27027](xref:General_Feature_Release_10.0.11#alarm-console-automatic-incident-tracking-id-25162id-25802id-25905id-26592id-27027id-27336))

#### AlarmSquashing

Enables alarm tree optimization.

- **Minimum version**: 10.0.1
- **Release version**: 10.1.0/10.0.12 ([RN 27413](xref:General_Feature_Release_10.0.12#alarm-console-alarm-events-without-a-severity-change-can-now-be-consolidated-in-the-preceding-event-in-the-alarm-tree-id-23234id-23526id-24462id-27413))

#### AnomalyDetection

Enables behavioral anomaly detection and suggestion events. See [Behavioral anomaly detection](xref:Behavioral_anomaly_detection).

- **Minimum version**: 9.5.12
- **Release version**: 10.0.0/10.0.2 ([RN 24095](xref:General_Feature_Release_10.0.2_new_features#dataminer-analytics-behavioral-anomaly-detection-and-suggestion-events-id-15723id-15914id-15916id-15951id-15952id-15976id-16001id-16050id-16163id-17279id-17462id-19224id-24095id-24126id-24147))

#### APIDeployment

> [!NOTE]
> Deprecated from DataMiner 10.3.6 onwards. No longer supported from DataMiner 10.4.0/10.4.1 onwards.<!-- RN 37765 -->
> This feature is replaced by the [UserDefinableAPI](#userdefinableapi) feature. When upgrading to 10.4.0 or newer, a prerequisite will block the upgrade if you still have deprecated APIs deployed. For more information, see [Verify No Obsolete API Deployed](xref:Verify_No_Obsolete_API_Deployed).

> [!CAUTION]
> APIDeployment is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Enables dynamic API deployment on the SLAPIEndpoint application.

Requires the .NET 5.0 hosting bundle.

- **Minimum version**: 10.1.6
- **Estimated Release version**: Will not be released (deprecated)

#### CassandraCluster

Allows you to set up the [Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) configuration in DataMiner Cube.

- **Minimum version**: 10.0.13
- **Release version**: 10.1.0/10.1.2 ([RN 28406](xref:General_Feature_Release_10.1.2#new-cassandra-cluster-feature-id-23210id-23975id-25945id-26144id-26475id-27080-id-27520id-27615id-27648id-27694id-28406))

#### CorrelationTicketAction

Allows you to [create a ticket](xref:Creating_a_ticket) as a Correlation action.

- **Minimum version**: 9.6.5
- **Estimated Release version**: Will not be released (deprecated)

#### ElasticTicketing

Allows you to store tickets in the indexing database.

- **Minimum version**: 9.6.4
- **Release version**: 10.0.13/10.1.0 ([RN 26677](xref:General_Feature_Release_10.0.13_new_features#ticketing-app-move-to-elasticsearch-database-and-other-improvements-id-24667id-25539-id-25713id-26644id-26676id-26677id-26911id-26982id-27974id-28016id-28043-id-28079id-28153))

#### FeatureOffload

Allows the offloading of specific DataMiner Analytics features to a specific DataMiner Node.

- **Minimum version**: 10.0.9
- **Estimated release version**: Will not be released (deprecated)

#### GenericOwnership

Enables the ownership framework.

- **Minimum version**: 9.5.11
- **Estimated release version**: Will not be released (deprecated)

#### Indexing

Enables the use of Elasticsearch for alarm indexing and other applications.

- **Minimum version**: 9.5.0
- **Release version**: 10.0.0/10.0.2 ([RN 24054](xref:General_Feature_Release_10.0.2_new_features#dataminer-indexing-id-13370id-13406id-13504id-13571id-13623-id-13622id-13629id-13695id-13769id-13912id-14001id-14038-id-16287id-16896id-16915id-16935id-16959id-17081id-17166-id-17328id-17851id-18562id-18714id-19337id-19437id-19443-id-19691id-20373id-20845id-20998id-21205id-21257id-21634-id-22378id-22927id-23049id-23998id-24054id-24158))

> [!NOTE]
> It is also possible to use the argument `ENABLEFEATURE=Indexing` in DataMiner Cube to view the *Indexing* app. However, this soft-launch feature has been abandoned and is no longer available in some setups.

#### JobManager

Enables the [Jobs app](xref:jobs).

- **Minimum version**: 9.6.2
- **Release version**: 9.6.4/10.0.0 ([RN 21098](xref:General_Main_Release_10.0.0_new_features_1#new-job-manager-app-id-19964id-20130id-20583id-21098id-21180id-21422id-21660-id-21724id-21767id-21940id-22289id-22331id-22772id-22758id-22823id-22895-id-22909id-22913id-22966-id-22988id-23007id-23042id-23049id-23790))

#### MonitoringAndControl

Enables the new Monitoring app. See [Accessing the Monitoring app](xref:Accessing_the_Monitoring_app) and [The Monitoring app user interface](xref:The_Monitoring_app_user_interface).

- **Minimum version**: 9.6.7
- **Release version**: 10.0.2/10.0.0 ([RN 24180](xref:General_Feature_Release_10.0.2_new_features#new-monitoring--control-app-id-21736id-22023id-22209id-22750id-22801id-22888id-22943id-23025id-23036id-23090id-23387id-23798id-23874id-24017id-24059id-24072id-24080id-24114id-24134id-24180id-24192))

#### NATS

Installs NATS and NAS on the DMA. If this option is enabled on all DMAs in the cluster, the NATS configuration will be updated so that a single NATS cluster is created.

- **Minimum version**: 10.0.13
- **Release version**: 10.1.1/10.1.0 ([RN 28131](xref:General_Feature_Release_10.1.1#gradual-introduction-of-inter-process-communication-via-nats-id-27496id-28082id-28131-id-28233))

#### NewAverageTrending

Enables the new average trending feature. From DataMiner 10.0.12 onwards, this is automatically enabled if a Cassandra cluster setup is used.

- **Minimum version**: 10.0.6
- **Release version**: 10.1.10/10.2.0 ([RN 28684](xref:General_Feature_Release_10.1.10#improved-average-trending-id-28684))

#### PlannedMaintenance

Enables the Planned Maintenance module.

> [!NOTE]
> Deprecated: The Planned Maintenance module is now available as an application package. It is not enabled in the core DataMiner software.

- **Minimum version**: 9.5.13

#### ReportsAndDashboards

Enables the [Dashboards app](xref:newR_D).

- **Minimum version**: 9.5.8
- **Release version**: 9.6.9/10.0.0 ([RN 22517](xref:General_Main_Release_10.0.0_new_features_4#new-dashboards-app-id-19638id-20719id-20739id-21182id-21199id-21213id-21220-id-21223id-21234id-21263id-21340id-21437id-21706id-21848id-21932id-21957-id-22072id-22117id-22273id-22325id-22517id-22672id-22761id-22855id-22874-id-23080-id-23097id-23131id-23161id-23173id-23176id-23245id-23249id-23293-id-23401id-23481id-23546id-23563id-23671-id-23692id-23747id-23754id-23839-id-24171))

#### ReportsAndDashboardsAlpha

Enables alpha components in the Dashboards app.

- **Minimum version**: 9.6.6
- **Estimated release version**: Will not be released (deprecated from [DataMiner 10.3.9](xref:Web_apps_Feature_Release_10.3.9#dashboards-app--low-code-apps-reportsanddashboardsalpha-soft-launch-option-is-now-deprecated-id-36894) onwards)

#### ReportsAndDashboardsGuides

Enables the guides in the Dashboards app.

- **Minimum version**: 9.6.8
- **Estimated release version**:  Will not be released (deprecated)

#### SrmOwnServices

Enables ownership support for SRM services.

- **Minimum version**: 9.6.1
- **Estimated release version**: Will not be released (deprecated)

#### SrmProtocolGeneration

Enables contributing service protocol generation.

- **Minimum version**: 9.6.1
- **Release version**: 9.6.11/10.0.0 ([RN 23201](xref:General_Main_Release_10.0.0_new_features_5#service--resource-management-possibility-to-generate-protocols-and-function-definitions-based-on-service-definitions-and-enhanced-services-based-on-reservations-id-19330id-19359id-19385id-19386id-19415id-19431id-19450-id-19491id-19498id-19556id-19632id-19789id-23201))

#### VisualDataManager

Enables the VisualDataHelper.

- **Minimum version**: 9.6.1
- **Release version**: 9.6.4
