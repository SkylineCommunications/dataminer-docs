---
uid: Overview_of_Soft_Launch_Options
description: DataMiner soft-launch options activate features that are not yet available to the general public. They can be enabled in SoftLaunchOptions.xml.
---

# Overview of soft-launch options

The list below contains an overview of all available soft-launch options. Unless otherwise specified, the key must be added in *SoftLaunchOptions.xml* with the value "true" in order to activate the feature.

The list also details the minimum DataMiner version to start using each option and, in case the feature has already been officially released in a later DataMiner version, the "Release version" when it becomes available. From that "Release version" onwards, the feature is active by default and any soft-launch configuration for the feature is ignored. As such, it is not necessary to remove a tag from *SoftLaunchOptions.xml* when the corresponding feature is officially released.

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
- **Release version**: 10.5.5/10.5.0 [CU2]<!-- RN 42573 -->

> [!TIP]
> See also: [Migrating to BrokerGateway](xref:BrokerGateway_Migration)

### ClusterEndpointsManager

Allows you to disable the ClusterEndpointsManager. This can prevent possible issues, but it will not be possible to [migrate to BrokerGateway](xref:BrokerGateway_Migration). If this option is not specified or if it is set to "true", ClusterEndpointsManager is enabled.

- **Minimum version**: 10.5.0 [CU5]/10.5.8<!-- RN 43370 -->
- **Release version**: 10.5.0 [CU5]/10.5.8<!-- RN 43370 -->

### CorrectedDisplayKeyOnNaming

Takes exception values into account for display key generation. See [CorrectedDisplayKeyOnNaming soft-launch option](xref:UIComponentsTableDisplayKeys#correcteddisplaykeyonnaming-soft-launch-option)

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 10.0.11/9.6.0 [CU18]/10.0.0 [CU6]
- **Estimated Release version**: To be determined

### CPEIntegration

Enables the Topology app in DataMiner Cube. Note that you also need specific protocol changes in order to benefit from this. See [Topology app configuration](xref:Topology_app_configuration).

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 9.6.7
- **Release version**: Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5<!-- RN 42221 -->

### DataAPI

Enables Data API functionality and scripted connectors. This displays the Data Sources module in DataMiner Cube.

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 10.4.2/10.4.0<!-- RN 36588/38307/38234 -->
- **Estimated Release version**: To be determined

> [!NOTE]
> The latest version of the DataAggregator DxM and DataAPI DxM also have to be installed for this feature to work.

### Diagnostics

Enable functionality to retrieve diagnostics from several DataMiner core processes. This is currently not used.

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 9.6.3

### DirectViewRemoteDataUpdates

Updates the values of direct view tables.

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

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

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 10.0.12
- **Release version**: 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1 ([RN 41436](xref:Cube_Feature_Release_10.5.1#data-display-in-dataminer-cube-now-supports-dynamic-units-by-default-id-41436))

### Functions

Enables the Virtual Functions module in Cube. This is a Cube-only feature that can only be activated per session with the argument `ENABLEFEATURE=FUNCTIONS`.

- **Minimum version**: 10.0.10
- **Release version**: To be determined

### GenericInterface

Provides access to additional data sources and operators for GQI in the Dashboards app and Low-Code Apps.

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

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
> The legacy Annotations module is disabled by default as from DataMiner versions 10.4.0/10.4.1 ([RN 37786](xref:General_Feature_Release_10.4.1#legacy-reports-dashboards-and-annotations-modules-are-now-end-of-life-and-will-be-disabled-by-default-id-37786)). If you want to keep on using this legacy module, before upgrading or uploading a 10.4.x upgrade package, set this soft-launch option to *true* (see [Activating SoftLaunch Options](xref:Activating_Soft_Launch_Options)), then run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator, and restart the DataMiner Agent.

### LegacyReportsAndDashboards

Enables or disables the legacy Reports and Dashboards modules.

- **Minimum version**: 10.1.10/10.2.0

> [!NOTE]
> The legacy Reports and Dashboards modules are disabled by default as from DataMiner versions 10.4.0/10.4.1 ([RN 37786](xref:General_Feature_Release_10.4.1#legacy-reports-dashboards-and-annotations-modules-are-now-end-of-life-and-will-be-disabled-by-default-id-37786)). If you want to keep on using these legacy modules, before upgrading or uploading a 10.4.x upgrade package, set this soft-launch option to *true* (see [Activating SoftLaunch Options](xref:Activating_Soft_Launch_Options)), then run `C:\Skyline DataMiner\Tools\ConfigureIIS.bat` as Administrator, and restart the DataMiner Agent.

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

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 10.2.12
- **Release version**: 10.3.0 [CU10]/10.4.1 ([RN 37812](xref:Web_apps_Feature_Release_10.4.1#dashboards-app--low-code-apps-new-grid-and-timeline-components-id-33276-id-33287-id-34761-id-34948-id-37269-id-37699-id-37812))

### ReportsAndDashboardsExport

Enables the export to PDF button within the Dashboards app itself. Creating PDFs of dashboards is possible outside the app (e.g. via DataMiner Scheduler) without this soft-launch option.

- **Minimum version**: 9.6.4
- **Release version**: 10.2.12/10.3.0 ([RN 34634](xref:General_Feature_Release_10.2.12#dashboards-app-jobs-and-dashboards-app-now-support-pdf-module-id-34634))

### ReportsAndDashboardsGQIMaps

Enables a new Maps component in the Dashboards app and the Low-Code Apps.

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 10.3.2
- **Release version**: 10.5.4<!-- RN 42309 -->

### ReportsAndDashboardsPTP

Enables the Query Filter component in the Dashboards app.

> [!NOTE]
>
> - Prior to DataMiner 10.0.13, this option also enables the Generic Interface feature in the Dashboards app, which becomes available from 10.0.13 onwards (partially using the GenericInterface soft-launch option).
> - Prior to DataMiner 10.1.5, this option also enables the Node Edge component, which becomes available by default from DataMiner 10.1.5 onwards.

- **Minimum version**: 10.0.10
- **Release version**: 10.3.9/10.4.0 ([RN 36822](xref:Web_apps_Feature_Release_10.3.9#dashboards-app--low-code-apps-query-filter-component-now-officially-released-id-33530-id-33547-id-34037-id-36822-id-36832))

### ReportsAndDashboardsScheduler

Enables the Timeline component in the Dashboards app.

This option is enabled by default when DataMiner is deployed in the cloud ([DaaS](xref:Creating_a_DMS_in_the_cloud)).

- **Minimum version**: 10.1.10
- **Release version**: 10.3.0 [CU10]/10.4.1 ([RN 37812](xref:Web_apps_Feature_Release_10.4.1#dashboards-app--low-code-apps-new-grid-and-timeline-components-id-33276-id-33287-id-34761-id-34948-id-37269-id-37699-id-37812))

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
