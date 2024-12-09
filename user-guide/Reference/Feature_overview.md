---
uid: Feature_overview
---

# Feature overview

Below you can find an overview of the main features that have been added to DataMiner in recent versions. Features that were released in versions prior to the [currently supported DataMiner versions](xref:Software_support_life_cycles) are not included in the overview.

> [!NOTE]
>
> - From DataMiner 10.2.0 [CU3]/10.2.6 onwards, Cube can automatically be upgraded to the latest version if [automatic updates are enabled](xref:DMA_configuration_related_to_client_applications#managing-client-versions) and depending on the selected [Cube update track](xref:Managing_the_start_window#selecting-your-cube-update-track). This way you can have access to the latest Cube features even if you still use an older DataMiner version on the server.
> - For many DataMiner web apps features, it is sufficient to [upgrade the web apps only](xref:Upgrading_Downgrading_Webapps). However, to upgrade to a 10.5.x version of the web apps, the server must first be upgraded to at least version 10.4.0/10.4.1. If other server limitations apply, these are listed below.

|Feature | Minimum required version(s) |
|---|---|
| Augmented operations: [Anomaly feedback](xref:Providing_user_feedback) | DataMiner 10.4.11/10.5.0<br>DataMiner 10.4.4 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#anomalyfeedback)<!-- [ID 38707] [ID 38980] [ID 39944] --> |
| Augmented operations: [Configuration of behavioral anomaly alarms](xref:Configuring_anomaly_detection_alarms) | DataMiner 10.3.12/10.4.0 <!-- [ID 36857] [ ID 37148] -->|
| Augmented operations: [Proactive cap detection feedback](xref:Providing_user_feedback) | DataMiner 10.5.1/10.6.0<!-- [ID 41371] --> |
| Automation: [HideUI](xref:Skyline.DataMiner.Automation.Engine.HideUI) method | DataMiner web 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--  [ID 39451] [ID 39638] --> |
| Automation: [IsReadOnly](xref:Skyline.DataMiner.Automation.UIBlockDefinition.IsReadOnly) property | DataMiner web 10.4.1/10.5.0 <!-- [ID 37659] -->|
| Automation: [SkipAbortConfirmation](xref:Skyline.DataMiner.Automation.UIBuilder.SkipAbortConfirmation) property | DataMiner 10.4.12/10.5.0<!-- [ID 40720] --> |
| Dashboards/Low-Code Apps: [Dynamic references in text](xref:Dynamically_Referencing_Data_in_Text) | DataMiner 10.3.11/10.4.0<!-- [ID 37229] --> |
| Dashboards/Low-Code Apps: [Flows](xref:Using_flows) | DataMiner web 10.4.0 [CU9]/10.4.12<!-- [ID 40974] --><br>Minimum server version: DataMiner 10.3.9/10.4.0 |
| Dashboards/Low-Code Apps: [*Grid* component](xref:DashboardGrid) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.2.12 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) |
| Dashboards/Low-Code Apps: [Variables](xref:Variables) | DataMiner web 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 <!-- [ID 41039] [ID 41063] [ID 41132] -->|
| Dashboards/Low-Code Apps: [*Search input* component](xref:DashboardSearchInput) | DataMiner web 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 <!-- [ID 39555] -->|
| Dashboards/Low-Code Apps: [Template editor](xref:Template_Editor) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.2.12 with the soft-launch options [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) and [ReportsAndDashboardsScheduler](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsscheduler) |
| Dashboards/Low-Code Apps: [*Timeline* component](xref:DashboardTimeline) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.1.10 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsscheduler) <!-- [ID 37812] -->|
| Dashboards/Low-Code Apps: [*Table* component column customization](xref:DashboardTable#column-appearance) | DataMiner web 10.4.1/10.5.0 <!-- [ID 37522] -->|
| Cube: [*UseInitialArgumentsAfterDisconnect* argument](xref:Options_for_opening_DataMiner_Cube#useinitialargumentsafterdisconnecttrue) | DataMiner Cube 10.2.0 [CU22]/10.3.0 [CU10]/10.4.1 <!-- [ID 37888] --> |
| DOM: [Calculating changes to a DOM instance](xref:ExecuteScriptOnDomInstanceActionSettings#calculating-changes-done-to-a-dom-instance-in-a-crud-script) | DataMiner 10.4.3/10.5.0 <!-- [ID 38364] -->|
| DOM: [CRUD actions on multiple instances](xref:DomHelper_class#multiple-instances) | DataMiner 10.4.2/10.5.0 <!-- [ID 37891] -->|
| [Elasticsearch to OpenSearch migration tool](xref:Migrating_from_Elasticsearch_to_OpenSearch) | DataMiner 10.4.0 [CU2]/10.4.4<!-- [ID 37994] --> |
| GQI: [Custom operator](xref:GQI_Custom_Operator) | DataMiner web 10.3.0 [CU10]/10.4.1 <!-- [ID 37840] --><br>DataMiner 10.2.7 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) |
| GQI: [Custom sort order](xref:GQI_Redirect_Sort_Tutorial) | DataMiner 10.4.5/10.5.0 <!-- [ID 39136] -->|
| GQI: [Logging](xref:GQI_Logging) | DataMiner 10.4.0/10.4.4 <!-- [ID 38870] --> |
| GQI: [Logging of metrics](xref:GQI_Logging#metrics) | DataMiner 10.4.0 [CU3]/10.4.5 <!-- [ID 39098] -->|
| GQI: [Real-time updates for ad hoc data sources](xref:GQI_IGQIUpdateable) | DataMiner 10.4.4/10.5.0 <!-- [ID 38643] --> |
| Low-Code Apps: [Duplicating an app](xref:Creating_custom_apps#duplicating-an-existing-low-code-app) | DataMiner web 10.3.0 [CU10]/10.4.1 <!-- [ID 37698] -->|
| Low-Code Apps: [*Interactive Automation script* component](xref:InteractiveAutomationScript) | DataMiner web 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 <!-- [ID 39969] -->|
| Low-Code Apps: [*Change variable* actions](xref:LowCodeApps_event_config#changing-a-variable) | DataMiner web 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1<!-- [ID 41253] [ID 41324] --> |
| Low-Code Apps: [*Show a notification* action](xref:LowCodeApps_event_config#showing-a-notification) | DataMiner 10.3.0 [CU12]/10.4.3 <!-- [ID 38548] -->|
| Low-Code Apps: [Timeline component events and actions](xref:DashboardTimeline#configuring-events-and-actions) | DataMiner web 10.3.0 CU14/10.4.0 CU2/10.4.5<!-- [ID 39254] --> |
| Spectrum Analysis: [Zooming and panning](xref:Viewing_spectrum_analyzer_traces#zooming-and-panning) | DataMiner Cube DataMiner 10.3.11/10.4.0 <!-- [ID 37284] [ID 37461] --> |
| [Swarming](xref:Swarming) | DataMiner 10.5.1/10.6.0<br>DataMiner 10.3.11 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#swarming) (Feature Release only)<!-- [ID 41490] --> |
| Visual Overview: [*RegexMatch* placeholder](xref:Placeholders_for_variables_in_shape_data_values#regexmatchxyoptions) | DataMiner Cube 10.3.0 [CU17]/10.4.0 [CU5]/10.4.8 <!-- [ID 39763] -->|

<!-- to be confirmed by cloud team: | Storage as a Service (STaaS) | 10.3.10 [CU1]/10.4.0 [CU0] | -->

## Connectors

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Configuring separate SLProtocol and SLScripting instances for a specific protocol<br>DataMiner.xml (ProcessOptions) | 10.2.5/10.3.0 |   | |
| Configuring separate SLProtocol and SLScripting instances for a specific protocol<br>Protocol.xml ([RunInSeparateInstance](xref:Protocol.SystemOptions.RunInSeparateInstance)) | 10.2.7/10.3.0 |   | |
| Setting the number of simultaneously running SLScripting processes<br>DataMiner.xml (ProcessOptions) | 10.2.7/10.3.0 |   | |

## Databases

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Cassandra TLS | 10.3.7/10.3.0 [CU4] |   | |
| Data offload to a local file | 10.2.0/10.1.1 |   | |
| Data offload to multiple Elasticsearch clusters | 10.2.0/10.1.3 |   | |
| Data offload to multiple OpenSearch clusters | 10.3.0/10.3.3 |   | |
| Elasticsearch TLS | 10.3.7/10.3.0 [CU4] |   | |
| Exporting/importing logger table data saved in an indexing database | 10.1.4/10.2.0 |   | |
| [Migrating SRM resources to the indexing database](xref:Resources_migration_to_elastic) | 10.3.0/10.3.2 |   | |
| OpenSearch cluster | 10.3.0/10.3.3 |   | |
| [Specifying credentials for a shared backup path for Elasticsearch](xref:SLNetClientTest_credentials_shared_backup_Elasticsearch) | 10.2.0/10.1.8 |   | |
| [Standalone Cassandra Backup tool](xref:Standalone_Cassandra_Backup_Tool) | 10.1.8/10.2.0 |   | |

## DataMiner Cube

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Automatic Cube updates | 10.2.0 [CU3]/10.2.6 |   | |

## Security

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| External user authentication via SAML - Azure B2C | 10.2.6/10.3.0 |   | |
| External user authentication via SAML - Okta | 10.3.0/10.3.2 |   | |

## Visual Overview

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Booking data component | 10.3.8/10.4.0 | 10.2.7 ||
| Source type "Resources" in list view components | 10.1.11/10.2.0 | 10.1.3 | Cube-only feature |

## Web apps

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Alarm list component | 10.1.5/10.2.0 | 9.6.8 | |
| Button panel component | 10.3.9/10.4.0 | 10.0.3 | |
| [DataMiner web upgrades](xref:Upgrading_Downgrading_Webapps) | 10.3.0/10.3.3 |   | |
| Export to PDF (in Dashboards app) | 10.2.12/10.3.0 | 9.6.4 | |
| Low-code apps | 10.2.5/10.3.0 | 10.0.8 | |
| Message throttling | 10.2.0/10.1.2 |   | |
| Monitoring app | 10.0.2/10.0.0 | 9.6.7 ||
| Query filter component | 10.3.9/10.4.0 | 10.0.4 | |
| Using DOM data in dashboards and low-code apps | 10.3.6/10.4.0 | 10.1.7 |  |

## Miscellaneous

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Data Aggregator DxM | 10.2.12 |   | |
| DataMiner Object Models (DOM) | 10.1.2/10.2.0 |   | |
| Failover using a shared hostname instead of virtual IP addresses | 10.2.0/10.1.8 |   | |
| gRPC connections between DMAs and between DMAs and client applications | 10.3.2/10.3.0 |   | |
| SLProtocol as a 64-bit process | 10.3.9 | 10.1.8 | |
| User-defined APIs | 10.3.6/10.4.0 | 10.3.5 | |
