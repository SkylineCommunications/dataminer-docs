---
uid: Feature_overview
---

# Feature overview

Below you can find an overview of the main features that have been added to DataMiner in recent versions. Features that were released in versions prior to the [currently supported DataMiner versions](xref:Software_support_life_cycles) are not included in the overview.

> [!NOTE]
>
> - From DataMiner 10.2.0 [CU3]/10.2.6 onwards, Cube can automatically be upgraded to the latest version if [automatic updates are enabled](xref:DMA_configuration_related_to_client_applications#managing-client-versions), and depending on the selected [Cube update track](xref:Managing_the_start_window#selecting-your-cube-update-track) and on the [deployment method](xref:DataMiner_Cube_deployment_methods). This way you can have access to the latest Cube features even if you still use an older DataMiner version on the server.
> - For many DataMiner web apps features, from DataMiner 10.3.0/10.3.3 onwards, it is sufficient to [upgrade the web apps only](xref:Upgrading_Downgrading_Webapps). However, to upgrade to a 10.5.x version of the web apps, the server must first be upgraded to at least version 10.4.0/10.4.1. If other server limitations apply, these are listed below.

|Feature | Minimum required version(s) |
|---|---|
| Augmented operations: [Alarm Console light bulb](xref:Light_Bulb_Feature) | DataMiner 10.3.10/10.4.0<!-- [ID 36777] --> |
| Augmented operations: [Anomaly feedback](xref:Providing_user_feedback) | DataMiner 10.4.11/10.5.0<br>DataMiner 10.4.4 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#anomalyfeedback)<!-- [ID 38707] [ID 38980] [ID 39944] --> |
| Augmented operations: [Configuration of behavioral anomaly alarms](xref:Configuring_anomaly_detection_alarms) | DataMiner 10.3.12/10.4.0 <!-- [ID 36857] [ ID 37148] -->|
| Augmented operations: [Managing pattern definitions](xref:Managing_pattern_definitions) | DataMiner Cube 10.3.6/10.4.0 <!-- [ID 35694] [ID 36114] -->|
| Augmented operations: [Multivariate trend patterns](xref:Working_with_pattern_matching#multivariate-patterns) | DataMiner Cube 10.3.8/10.4.0<!-- [ID 36731] --><br>Minimum server version: DataMiner 10.3.3/10.4.0 <!-- [ID 35301] -->|
| Augmented operations: [Proactive cap detection feedback](xref:Providing_user_feedback) | DataMiner 10.5.1/10.6.0<!-- [ID 41371] --> |
| Augmented operations: [Time-scoped relations](xref:Adding_time_scoped_related_parameters_to_a_trend_graph) | DataMiner 10.3.8/10.4.0 <!-- [ID 36434] --> |
| Automation: [HideUI](xref:Skyline.DataMiner.Automation.Engine.HideUI) method | DataMiner web 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--  [ID 39451] [ID 39638] --> |
| Automation: [IsReadOnly](xref:Skyline.DataMiner.Automation.UIBlockDefinition.IsReadOnly) property | DataMiner web 10.4.1/10.5.0 <!-- [ID 37659] -->|
| Automation: [SkipAbortConfirmation](xref:Skyline.DataMiner.Automation.UIBuilder.SkipAbortConfirmation) property | DataMiner 10.4.12/10.5.0<!-- [ID 40720] --> |
| Client-server communication: gRPC connections between [Cube and DMAs](xref:ConnectionSettings_txt#connectionsettingstxt-options) and [between DMAs](xref:DMS_xml#redirects-subtag) | DataMiner 10.3.0/10.3.2 <!-- [ID 34797] [ID 34983] --> |
| Cube: [Duplicating a resource](xref:Configuring_pools_of_resources#duplicating-a-resource-from-a-pool) | DataMiner Cube 10.3.7/10.4.0 <!-- [ID 36308] -->|
| Cube: [Hiding the close button](xref:Working_with_cards_in_DataMiner_Cube#marking-cards-as-non-closable) and [Selecting a Master card](xref:Working_with_cards_in_DataMiner_Cube#selecting-a-master-card) | DataMiner Cube 10.3.9/10.4.0 <!-- [ID 36912] [ID 36956] --> |
| Cube: [*UseInitialArgumentsAfterDisconnect* argument](xref:Options_for_opening_DataMiner_Cube#useinitialargumentsafterdisconnecttrue) | DataMiner Cube 10.2.0 [CU22]/10.3.0 [CU10]/10.4.1 <!-- [ID 37888] --> |
| Dashboards/Low-Code Apps: [*Button panel* component](xref:DashboardButtonPanel) | DataMiner 10.3.9/10.4.0<br>DataMiner 10.0.3 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsbuttonpanel) <!-- [ID 36775] --> |
| Dashboards/Low-Code Apps: [Dynamic references in text](xref:Dynamically_Referencing_Data_in_Text) | DataMiner 10.3.11/10.4.0<!-- [ID 37229] --> |
| Dashboards/Low-Code Apps: [Flows](xref:Using_flows) | DataMiner web 10.4.0 [CU9]/10.4.12<!-- [ID 40974] --><br>Minimum server version: DataMiner 10.3.9/10.4.0 |
| Dashboards/Low-Code Apps: [*Form* component](xref:DashboardForm) and DOM data input | DataMiner web 10.3.6/10.4.0<br>DataMiner 10.1.7 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#dommanager) <!-- [ID 36124] -->|
| Dashboards/Low-Code Apps: [*Grid* component](xref:DashboardGrid) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.2.12 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) |
| Dashboards/Low-Code Apps: [*Numeric input* component](xref:DashboardNumericInput) | DataMiner web 10.3.5/10.4.0 <!-- [ID 35911] -->|
| Dashboards/Low-Code Apps: [*Query filter* component](xref:DashboardQueryFilter) | DataMiner 10.3.9/10.4.0<br>DataMiner 10.0.4 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsptp) <!-- [ID 33530] --> |
| Dashboards/Low-Code Apps: [*Search input* component](xref:DashboardSearchInput) | DataMiner web 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 <!-- [ID 39555] -->|
| Dashboards/Low-Code Apps: [*Stepper* component](xref:DashboardStepper) | DataMiner 10.3.10/10.4.0 <!-- [ID 37200] -->|
| Dashboards/Low-Code Apps: [Template editor](xref:Template_Editor) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.2.12 with the soft-launch options [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) and [ReportsAndDashboardsScheduler](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsscheduler) |
| Dashboards/Low-Code Apps: [*Text input* component](xref:DashboardTextInput) | DataMiner web 10.3.5/10.4.0 <!-- [ID 35902] -->|
| Dashboards/Low-Code Apps: [Variables](xref:Variables) | DataMiner web 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 <!-- [ID 41039] [ID 41063] [ID 41132] -->|
| Dashboards/Low-Code Apps: [*Timeline* component](xref:DashboardTimeline) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.1.10 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsscheduler) <!-- [ID 37812] -->|
| Dashboards/Low-Code Apps: [*Table* component column customization](xref:DashboardTable#column-appearance) | DataMiner web 10.4.1/10.5.0 <!-- [ID 37522] -->|
| Database: [OpenSearch indexing database](xref:OpenSearch_database) | DataMiner 10.3.0/10.3.3 |
| Database: [Resource migration to Elasticsearch](xref:Resources_migration_to_elastic) | DataMiner 10.3.0/10.3.2 <!-- [ID 33797] -->|
| DOM: [Calculating changes to a DOM instance](xref:ExecuteScriptOnDomInstanceActionSettings#calculating-changes-done-to-a-dom-instance-in-a-crud-script) | DataMiner 10.4.3/10.5.0 <!-- [ID 38364] -->|
| DOM: [CRUD actions on multiple instances](xref:DomHelper_class#multiple-instances) | DataMiner 10.4.2/10.5.0 <!-- [ID 37891] -->|
| DOM: [GroupFieldDescriptor](xref:DOM_GroupFieldDescriptor) and [UserFieldDescriptor](xref:DOM_UserFieldDescriptor) | DataMiner 10.3.3/10.4.0 <!-- [ID 35278] -->|
| [Elasticsearch to OpenSearch migration tool](xref:Migrating_from_Elasticsearch_to_OpenSearch) | DataMiner 10.4.0 [CU2]/10.4.4<!-- [ID 37994] --> |
| GQI: [Ad hoc data sources](xref:Get_ad_hoc_data) | DataMiner 10.2.4/10.3.0 <!-- [ID 32656] [ID 32659] [ID 32930] -->|
| GQI: [Custom operator](xref:GQI_Custom_Operator) | DataMiner web 10.3.0 [CU10]/10.4.1 <!-- [ID 37840] --><br>DataMiner 10.2.7 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) |
| GQI: [Custom sort order](xref:GQI_Redirect_Sort_Tutorial) | DataMiner 10.4.5/10.5.0 <!-- [ID 39136] -->|
| GQI: [Logging](xref:GQI_Logging) | DataMiner 10.4.0/10.4.4 <!-- [ID 38870] --> |
| GQI: [Logging of metrics](xref:GQI_Logging#metrics) | DataMiner 10.4.0 [CU3]/10.4.5 <!-- [ID 39098] -->|
| GQI: [Real-time updates for ad hoc data sources](xref:GQI_IGQIUpdateable) | DataMiner 10.4.4/10.5.0 <!-- [ID 38643] --> |
| GQI: [Sending/receiving DMS messages](xref:GQI_GQIDMS) | DataMiner web 10.3.4/10.4.0 <!-- [ID 35701] -->|
| GQI: [Trend data patterns](xref:Get_trend_data_patterns), [Trend data pattern events](xref:Get_trend_data_pattern_events), and [behavioral change events](xref:Get_behavioral_change_events) data sources | DataMiner web 10.3.3/10.4.0 <!-- [ID 34747] [ID 35027] [ID 34965] [ID 35058] -->|
| Low-Code Apps: [Duplicating an app](xref:Creating_custom_apps#duplicating-an-existing-low-code-app) | DataMiner web 10.3.0 [CU10]/10.4.1 <!-- [ID 37698] -->|
| Low-Code Apps: [*Interactive Automation script* component](xref:InteractiveAutomationScript) | DataMiner web 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 <!-- [ID 39969] -->|
| Low-Code Apps: [*Change variable* actions](xref:LowCodeApps_event_config#changing-a-variable) | DataMiner web 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1<!-- [ID 41253] [ID 41324] --> |
| Low-Code Apps: [*Open monitoring card* action](xref:LowCodeApps_event_config#opening-a-monitoring-card) | DataMiner web 10.3.4/10.4.0 <!-- [ID 35661] -->|
| Low-Code Apps: [*Show a notification* action](xref:LowCodeApps_event_config#showing-a-notification) | DataMiner 10.3.0 [CU12]/10.4.3 <!-- [ID 38548] -->|
| Low-Code Apps: [Timeline component events and actions](xref:DashboardTimeline#configuring-events-and-actions) | DataMiner web 10.3.0 CU14/10.4.0 CU2/10.4.5<!-- [ID 39254] --> |
| [User-defined APIs](xref:UD_APIs) | DataMiner 10.3.6/10.4.0<br>DataMiner 10.3.5 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#userdefinableapi) <!-- [ID 36273] --> |
| [SLProtocol as a 64-bit process](xref:Activating_SLProtocol_as_a_64_Bit_Process) |  DataMiner 10.3.9/10.4.0<br>DataMiner 10.1.8 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#slprotocolasx64) |
| Spectrum Analysis: [Zooming and panning](xref:Viewing_spectrum_analyzer_traces#zooming-and-panning) | DataMiner Cube DataMiner 10.3.11/10.4.0 <!-- [ID 37284] [ID 37461] --> |
| [Storage as a Service (STaaS)](xref:STaaS) | DataMiner 10.4.0/10.4.1 |
| [Swarming](xref:Swarming) | DataMiner 10.5.1/10.6.0<br>DataMiner 10.3.11 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#swarming) (Feature Release only)<!-- [ID 41490] --> |
| Visual Overview: [*BookingData* component](xref:Linking_a_shape_to_a_booking#making-the-booking-shape-display-booking-information) | DataMiner Cube 10.3.8/10.4.0<br>DataMiner 10.2.7 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#bookingdata)<!-- [ID 33215] [ID 36489] --> |
| Visual Overview: [EPM statistics](xref:Linking_a_shape_to_an_EPM_object#showing-statistics-for-the-epm-object-in-the-shape-text) | DataMiner Cube 10.3.2/10.4.0 <!-- [ID 35222] --> |
| Visual Overview: [*RegexMatch* placeholder](xref:Placeholders_for_variables_in_shape_data_values#regexmatchxyoptions) | DataMiner Cube 10.3.0 [CU17]/10.4.0 [CU5]/10.4.8 <!-- [ID 39763] -->|





## Connectors

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Configuring separate SLProtocol and SLScripting instances for a specific protocol<br>DataMiner.xml (ProcessOptions) | 10.2.5/10.3.0 |   | |
| Configuring separate SLProtocol and SLScripting instances for a specific protocol<br>Protocol.xml ([RunInSeparateInstance](xref:Protocol.SystemOptions.RunInSeparateInstance)) | 10.2.7/10.3.0 |   | |
| Setting the number of simultaneously running SLScripting processes<br>DataMiner.xml (ProcessOptions) | 10.2.7/10.3.0 |   | |

## Databases

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Data offload to a local file | 10.2.0/10.1.1 |   | |
| Data offload to multiple Elasticsearch clusters | 10.2.0/10.1.3 |   | |
| Exporting/importing logger table data saved in an indexing database | 10.1.4/10.2.0 |   | |
| [Specifying credentials for a shared backup path for Elasticsearch](xref:SLNetClientTest_credentials_shared_backup_Elasticsearch) | 10.2.0/10.1.8 |   | |
| [Standalone Cassandra Backup tool](xref:Standalone_Cassandra_Backup_Tool) | 10.1.8/10.2.0 |   | |

## Security

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| External user authentication via SAML - Azure B2C | 10.2.6/10.3.0 |   | |

## Visual Overview

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Source type "Resources" in list view components | 10.1.11/10.2.0 | 10.1.3 | Cube-only feature |

## Web apps

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Alarm list component | 10.1.5/10.2.0 | 9.6.8 | |
| Export to PDF (in Dashboards app) | 10.2.12/10.3.0 | 9.6.4 | |
| Low-code apps | 10.2.5/10.3.0 | 10.0.8 | |
| Message throttling | 10.2.0/10.1.2 |   | |
| Monitoring app | 10.0.2/10.0.0 | 9.6.7 ||

## Miscellaneous

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Data Aggregator DxM | 10.2.12 |   | |
| DataMiner Object Models (DOM) | 10.1.2/10.2.0 |   | |
| Failover using a shared hostname instead of virtual IP addresses | 10.2.0/10.1.8 |   | |

