---
uid: Overview_of_Soft_Launch_Options
---
# Overview of soft-launch options

The table below contains an overview of all available soft-launch options. Unless otherwise specified, the key in the “Feature key” column must be added in *SoftLaunchOptions.xml* with the value “true” in order to activate the feature.

The table also details the minimum DataMiner version to start using each option and, in case the feature has already been officially released in a later DataMiner version, the “Release version” when it becomes available. From that “Release version” onwards, the feature is active by default and any soft-launch configuration for the feature is ignored. As such, it is not necessary to remove a tag from *SoftLaunchOptions.xml* when the corresponding feature is officially released.

### AlarmFocus

See [Filtering alarms on alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus).

- **Minimum version**: 9.6.13
- **Release version**: 10.0.0/10.0.2 ([RN 23911](xref:General_Feature_Release_10.0.2_new_features#dataminer-analytics-alarm-focus-23911id_24083id_24102id_24128))

### AlarmForecasting

Enables proactive cap detection. See [Proactive cap detection](xref:Proactive_cap_detection).

- **Minimum version**: 9.5.12
- **Release version**: 10.1.0/10.0.11 ([RN 27132](xref:General_Feature_Release_10.0.11#proactive-cap-detection-id_26637id_27132id_27241id_27355id_27393))

### AlarmGrouping

Enables automatic incident tracking. See [Automatic incident tracking](xref:Automatic_incident_tracking).

- **Minimum version**: 10.0.3
- **Release version**: 10.1.0/10.0.11 ([RN 27027](xref:General_Feature_Release_10.0.11#alarm-console-automatic-incident-tracking-id_25162id_25802id_25905id_26592id_27027id_27336))

### AlarmSquashing

Enables alarm tree optimization.

- **Minimum version**: 10.0.1
- **Release version**: 10.1.0/10.0.12 ([RN 27413](xref:General_Feature_Release_10.0.12#alarm-console-alarm-events-without-a-severity-change-can-now-be-consolidated-in-the-preceding-event-in-the-alarm-tree-id_23234id_23526id_24462id_27413))

### AnomalyDetection

Enables behavioral anomaly detection and suggestion events. See [Behavioral anomaly detection](xref:Behavioral_anomaly_detection).

- **Minimum version**: 9.5.12
- **Release version**: 10.0.0/10.0.2 ([RN 24095](xref:General_Feature_Release_10.0.2_new_features#dataminer-analytics-behavioral-anomaly-detection-and-suggestion-events-id_15723id_15914id_15916id_15951id_15952id_15976id_16001id_16050id_16163id_17279id_17462id_19224id_24095id_24126id_24147))

### APIDeployment

> [!NOTE]
> Deprecated from DataMiner 10.3.6 onwards. No longer supported from DataMiner 10.4.1 onwards. This feature is replaced by the [UserDefinableAPI](#userdefinableapi) feature.

Enables dynamic API deployment on the SLAPIEndpoint application.

Requires the .NET 5.0 hosting bundle.

- **Minimum version**: 10.1.6

### Applications

Enables the [Low-Code Apps module](xref:Application_framework).

> [!NOTE]
> Requires an IIS restart.

- **Minimum version**: 10.0.8
- **Release version**: 10.2.5/10.3.0 ([RN 33040](xref:General_Feature_Release_10.2.5#application-framework-id_33002-id_33040))

### BookingData

Enables the [BookingData](xref:Linking_a_shape_to_a_booking#making-the-booking-shape-display-booking-information) Visual Overview component.

- **Minimum version**: 10.2.7
- **Release version**: 10.3.8/10.4.0 ([RN 36489](xref:Cube_Feature_Release_10.3.8#visual-overview-new-bookingdata-component-id_33215-id_36489))

### CassandraCluster

Allows you to set up the [Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) configuration in DataMiner Cube.

- **Minimum version**: 10.0.13
- **Release version**: 10.1.0/10.1.2 ([RN 28406](xref:General_Feature_Release_10.1.2#new-cassandra-cluster-feature-id_23210id_23975id_25945id_26144id_26475id_27080-id_27520id_27615id_27648id_27694id_28406))

### CloudConnectedAgents

Makes it possible to [connect the DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- **Minimum version**: 10.1.2
- **Release version**: 10.1.9/10.2.0 ([RN 30513](xref:General_Feature_Release_10.1.9#connecting-a-dataminer-system-to-the-cloud-id_30513))

### CorrectedDisplayKeyOnNaming

  Takes exception values into account for display key generation.

- **Minimum version**: 10.0.11/9.6.0 [CU18]/10.0.0 [CU6]
- **Estimated Release version**: To be determined

### CorrelationTicketAction

Allows you to [create a ticket](xref:Creating_a_ticket) as a Correlation action.

- **Minimum version**: 9.6.5
- **Estimated Release version**: Will not be released (deprecated)

### CPEIntegration

This is a Cube-only feature that can only be activated with the argument `ENABLEFEATURE=CPEINTEGRATION`. Note that you also need specific protocol changes in order to benefit from this.

- **Minimum version**: 9.6.7
- **Estimated Release version**: To be determined

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
- **Release version**: 10.3.6/10.4.0 ([RN 36124](xref:Web_apps_Feature_Release_10.3.6#dom-features-now-available-in-dashboards-and-low-code-apps-id_29732-id_31804-id_32236-id_36124))

### DynamicUnits

Enables dynamic units in Data Display in DataMiner Cube and the Monitoring app. If you want to test this feature for one DataMiner Cube session only, use the argument `SOFTLAUNCH_DYNAMICUNITS=Enabled`.

- **Minimum version**: 10.0.12
- **Estimated release version**: 10.3.12

### ElasticTicketing

Allows you to store tickets in the Elasticsearch database.

- **Minimum version**: 9.6.4
- **Release version**: 10.0.13/10.1.0 ([RN 26677](xref:General_Feature_Release_10.0.13_new_features#ticketing-app-move-to-elasticsearch-database-and-other-improvements-id_24667id_25539-id_25713id_26644id_26676id_26677id_26911id_26982id_27974id_28016id_28043-id_28079id_28153))

### FeatureOffload

Allows the offloading of specific DataMiner Analytics features to a specific DataMiner Node.

- **Minimum version**: 10.0.9
- **Estimated release version**: Will not be released (deprecated)

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

- **Minimum version**: 10.0.13
- **Estimated release version for the custom operator**: 10.3.11
- **Estimated release version for other data sources and operators**: To be determined

### GenericOwnership

Enables the ownership framework.

- **Minimum version**: 9.5.11
- **Estimated release version**: Will not be released (deprecated)

### Indexing

Enables the use of Elasticsearch for alarm indexing and other applications. To preview the indexing configuration in DataMiner Cube, use the argument `ENABLEFEATURE=Indexing`.

- **Minimum version**: 9.5.0
- **Release version**: 10.0.0/1.0.0.2 ([RN 24054](xref:General_Feature_Release_10.0.2_new_features#dataminer-indexing-id_13370id_13406id_13504id_13571id_13623-id_13622id_13629id_13695id_13769id_13912id_14001id_14038-id_16287id_16896id_16915id_16935id_16959id_17081id_17166-id_17328id_17851id_18562id_18714id_19337id_19437id_19443-id_19691id_20373id_20845id_20998id_21205id_21257id_21634-id_22378id_22927id_23049id_23998id_24054id_24158))

### JobManager

Enables the [Jobs app](xref:jobs).

- **Minimum version**: 9.6.2
- **Release version**: 9.6.4/10.0.0 ([RN 21098](xref:General_Main_Release_10.0.0_new_features_1#new-job-manager-app-id_19964id_20130id_20583id_21098id_21180id_21422id_21660-id_21724id_21767id_21940id_22289id_22331id_22772id_22758id_22823id_22895-id_22909id_22913id_22966-id_22988id_23007id_23042id_23049id_23790))

### LegacyAnnotations

Shows the legacy Annotations module in Cube.

- **Minimum version**: 10.1.12/10.2.0 ([RN 31329](xref:General_Feature_Release_10.1.12#legacy-reports-dashboards-and-annotations-modules-will-by-default-be-hidden-in-new-installations-id_31329))

### LegacyReportsAndDashboards

Shows the legacy Reports & Dashboards module in Cube.

- **Minimum version**: 10.1.12/10.2.0 ([RN 31329](xref:General_Feature_Release_10.1.12#legacy-reports-dashboards-and-annotations-modules-will-by-default-be-hidden-in-new-installations-id_31329))

### MonitoringAndControl

Enables the new Monitoring app. See [Accessing the Monitoring app](xref:Accessing_the_Monitoring_app) and [The Monitoring app user interface](xref:The_Monitoring_app_user_interface).

- **Minimum version**: 9.6.7
- **Release version**: 10.0.2/10.0.0 ([RN 24180](xref:General_Feature_Release_10.0.2_new_features#new-monitoring--control-app-id_21736id_22023id_22209id_22750id_22801id_22888id_22943id_23025id_23036id_23090id_23387id_23798id_23874id_24017id_24059id_24072id_24080id_24114id_24134id_24180id_24192))

### NATS

Installs NATS and NAS on the DMA. If this option is enabled on all DMAs in the cluster, the NATS configuration will be updated so that a single NATS cluster is created.

- **Minimum version**: 10.0.13
- **Release version**: 10.1.1/10.1.0 ([RN 28131](xref:General_Feature_Release_10.1.1#gradual-introduction-of-inter-process-communication-via-nats-id_27496id_28082id_28131-id_28233))

### NewAverageTrending

Enables the new average trending feature. From DataMiner 10.0.12 onwards, this is automatically enabled if a Cassandra cluster setup is used.

- **Minimum version**: 10.0.6
- **Release version**: 10.1.10/10.2.0 ([RN 28684](xref:General_Feature_Release_10.1.10#improved-average-trending-id_28684))

### PlannedMaintenance

Enables the Planned Maintenance module.

> [!NOTE]
> Deprecated: The Planned Maintenance module is now available as an application package. It is not enabled in the core DataMiner software.

- **Minimum version**: 9.5.13

### ReportsAndDashboards

Enables the [Dashboards app](xref:newR_D).

- **Minimum version**: 9.5.8
- **Release version**: 9.6.9/10.0.0 ([RN 22517](xref:General_Main_Release_10.0.0_new_features_4#new-dashboards-app-id_19638id_20719id_20739id_21182id_21199id_21213id_21220-id_21223id_21234id_21263id_21340id_21437id_21706id_21848id_21932id_21957-id_22072id_22117id_22273id_22325id_22517id_22672id_22761id_22855id_22874-id_23080-id_23097id_23131id_23161id_23173id_23176id_23245id_23249id_23293-id_23401id_23481id_23546id_23563id_23671-id_23692id_23747id_23754id_23839-id_24171))

### ReportsAndDashboardsAlarmList

Enables the alarm list component in the Dashboards app.

- **Minimum version**: 9.6.8
- **Release version**: 10.1.5/10.2.0 ([RN 29456](xref:General_Feature_Release_10.1.5#dashboards-app-alarm-table-component-id_27790-id_28012-id_28142-id_28519-id_28718-id_28887-id_29131-id_29456))

### ReportsAndDashboardsAlpha

Enables alpha components in the Dashboards app.

- **Minimum version**: 9.6.6
- **Estimated release version**: Will not be released (deprecated from [DataMiner 10.3.9](xref:Web_apps_Feature_Release_10.3.9#dashboards-app--low-code-apps-reportsanddashboardsalpha-soft-launch-option-is-now-deprecated-id_36894) onwards)

### ReportsAndDashboardsAutomationScript

Enables the Automation script component in the Dashboards app.

- **Minimum version**: 9.6.8
- **Estimated release version**: To be determined

### ReportsAndDashboardsButton

Enables the button component in the Dashboards app.

- **Minimum version**: 10.0.3
- **Estimated release version**: To be determined

### ReportsAndDashboardsButtonPanel

Enables the button panel component in the Dashboards app.

- **Minimum version**: 10.0.3
- **Release version**: 10.3.9/10.4.0 ([RN 36775](xref:Web_apps_Feature_Release_10.3.9#dashboards-app--low-code-apps-button-panel-visualization-now-officially-released-id_36775))

### ReportsAndDashboardsDynamicVisuals

Enables the grid component in the Dashboards app.

- **Minimum version**: 10.2.12
- **Estimated release version**: 10.3.11

### ReportsAndDashboardsExport

Enables the export to PDF button within the Dashboards app itself. Creating PDFs of dashboards is possible outside the app (e.g. via DataMiner Scheduler) without this soft-launch option.

- **Minimum version**: 9.6.4
- **Release version**: 10.2.12/10.3.0 ([RN 34634](xref:General_Feature_Release_10.2.12#dashboards-app-jobs-and-dashboards-app-now-support-pdf-module-id_34634))

### ReportsAndDashboardsGQIMaps

Enables a new Maps component in the Dashboards app and the Low-Code Apps.

- **Minimum version**: 10.3.2
- **Estimated release version**: 10.3.11

### ReportsAndDashboardsGuides

Enables the guides in the Dashboards app.

- **Minimum version**: 9.6.8
- **Estimated release version**: To be determined

### ReportsAndDashboardsPTP

Enables the Query Filter component in the Dashboards app.

> [!NOTE]
>
> - Prior to DataMiner 10.0.13, this option also enables the Generic Interface feature in the Dashboards app, which becomes available from 10.0.13 onwards (partially using the GenericInterface soft-launch option).
> - Prior to DataMiner 10.1.5, this option also enables the Node Edge component, which becomes available by default from DataMiner 10.1.5 onwards.

- **Minimum version**: 10.0.4
- **Release version**: 10.3.9/10.4.0 ([RN 36822](xref:Web_apps_Feature_Release_10.3.9#dashboards-app--low-code-apps-query-filter-component-now-officially-released-id_33530-id_33547-id_34037-id_36822-id_36832))

### ReportsAndDashboardsScheduler

Enables the Timeline component in the Dashboards app.

- **Minimum version**: 10.1.10
- **Estimated release version**: 10.3.11

### ResourceList

Enables support for the source type "Resources" in list view components. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=ResourceList`.

- **Minimum version**: 10.1.3
- **Release version**: 10.1.11/10.2.0 ([RN 30998](xref:General_Feature_Release_10.1.11#visual-overview-listview-component-can-now-be-used-to-list-resources-id_28723-id_30998))

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

### SrmOwnServices

Enables ownership support for SRM services.

- **Minimum version**: 9.6.1
- **Estimated release version**: Will not be released (deprecated)

### SrmProtocolGeneration

Enables contributing service protocol generation.

- **Minimum version**: 9.6.1
- **Release version**: 9.6.11/10.0.0 ([RN 23201](xref:General_Main_Release_10.0.0_new_features_5#service--resource-management-possibility-to-generate-protocols-and-function-definitions-based-on-service-definitions-and-enhanced-services-based-on-reservations-id_19330id_19359id_19385id_19386id_19415id_19431id_19450-id_19491id_19498id_19556id_19632id_19789id_23201))

### VisualDataManager

Enables the new VisualDataHelper.

- **Minimum version**: 9.6.1
- **Release version**: 9.6.4

### UseWebIAS

Uses an embedded web browser for Automation script execution instead of the native Cube pop-up window.

- **Minimum version**: 10.1.4

### UserDefinableAPI

Enables the Cube UI for [User-Defined APIs](xref:UD_APIs).

- **Minimum version**: 10.3.5
- **Release version**: 10.3.6/10.4.0 ([RN 36273](xref:General_Feature_Release_10.3.6#user-defined-apis-id_34910-id_35134-id_35169-id_35417-id_35743-id_35810-id_35880-id_35885-id_36118-id_36250-id_36273-id_36366))
