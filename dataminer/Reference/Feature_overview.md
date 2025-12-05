---
uid: Feature_overview
---

# Feature overview

Below you can find an overview of the main features that have been added to DataMiner in recent versions. Features that were released in versions prior to the [currently supported DataMiner versions](xref:Software_support_life_cycles) are not included in the overview.

> [!NOTE]
>
> - From DataMiner 10.2.0 [CU3]/10.2.6 onwards, **Cube** can automatically be upgraded to the latest version if [automatic updates are enabled](xref:DMA_configuration_related_to_client_applications#managing-client-versions), and depending on the selected [Cube update track](xref:Managing_the_start_window#selecting-your-cube-update-track) and on the [deployment method](xref:DataMiner_Cube_deployment_methods). This way you can have access to the latest Cube features even if you still use an older DataMiner version on the server.
> - For many DataMiner **web apps** features, from DataMiner 10.3.0/10.3.3 onwards, it is sufficient to [upgrade the web apps only](xref:Upgrading_Downgrading_Webapps). However, to upgrade to a 10.5.x version of the web apps, the server must first be upgraded to at least version 10.4.0/10.4.1. If other server limitations apply, these are listed below.

|Feature | Minimum required version(s) |
|---|---|
| Augmented operations: [Adding related parameters to a trend graph](xref:Adding_related_parameters_to_a_trend_graph) | DataMiner Cube 10.2.12/10.3.0 <!-- [ID 34432] -->|
| Augmented operations: [Alarm Console light bulb](xref:Light_Bulb_Feature) | DataMiner 10.3.10/10.4.0<!-- [ID 36777] --> |
| Augmented operations: [Anomaly feedback](xref:Providing_user_feedback) | DataMiner 10.4.11/10.5.0<br>DataMiner 10.4.4 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#anomalyfeedback)<!-- [ID 38707] [ID 38980] [ID 39944] --> |
| Augmented operations: [Configuration of behavioral anomaly alarms](xref:Configuring_anomaly_detection_alarms) | DataMiner 10.3.12/10.4.0 <!-- [ID 36857] [ ID 37148] -->|
| Augmented operations: [Managing pattern definitions](xref:Managing_pattern_definitions) | DataMiner Cube 10.3.6/10.4.0 <!-- [ID 35694] [ID 36114] -->|
| Augmented operations: [Manually updating an alarm group](xref:Manually_creating_or_updating_alarm_groups) | DataMiner 10.2.5/10.3.0 <!-- [ID 32729] -->|
| Augmented operations: [Multivariate trend patterns](xref:Pattern_matching#multivariate-patterns) | DataMiner Cube 10.3.8/10.4.0<!-- [ID 36731] --><br>Minimum server version: DataMiner 10.3.3/10.4.0 <!-- [ID 35301] -->|
| Augmented operations: [Proactive cap detection feedback](xref:Providing_user_feedback) | DataMiner 10.5.1/10.6.0<!-- [ID 41371] --> |
| Augmented operations: [Relational anomaly detection](xref:Relational_anomaly_detection) | DataMiner 10.5.3/10.6.0<!-- [ID 42034] --> |
| Augmented operations: [Time-scoped relations](xref:Adding_time_scoped_related_parameters_to_a_trend_graph) | DataMiner 10.3.8/10.4.0 <!-- [ID 36434] --> |
| Automation: [ExtendedErrorInfo](xref:Skyline.DataMiner.Automation.SubScriptOptions.ExtendedErrorInfo) property | DataMiner 10.2.7/10.3.0 <!-- [ID 33306] -->|
| Automation: [HideUI](xref:Skyline.DataMiner.Automation.Engine.HideUI) method | DataMiner web 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--  [ID 39451] [ID 39638] --> |
| Automation: [Interactivity](xref:DMSScript.Interactivity) tag | DataMiner 10.5.9/10.6.0 <!-- [ID 42954]--> |
| Automation: [IsReadOnly](xref:Skyline.DataMiner.Automation.UIBlockDefinition.IsReadOnly) property | DataMiner web 10.4.1/10.5.0 <!-- [ID 37659] -->|
| Automation: [Logging](xref:Automation_logging) | DataMiner Cube 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 <!-- [ID 43144] --> |
| Automation: [SkipAbortConfirmation](xref:Skyline.DataMiner.Automation.UIBuilder.SkipAbortConfirmation) property | DataMiner 10.4.12/10.5.0<!-- [ID 40720] --> |
| Automation: [TriggeredByName](xref:Skyline.DataMiner.Automation.Engine.TriggeredByName) property | DataMiner 10.2.6/10.3.0 <!-- [ID 33122] -->|
| [BrokerGateway DxM](xref:BrokerGateway_Migration) | DataMiner 10.5.0 [CU2]/10.5.5/10.6.0<br>DataMiner 10.5.0/10.5.2 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#brokergateway) <!-- [ID 42573] --> |
| [Cache for SNMP inform messages](xref:Adjusting_the_SNMP_inform_message_cache_size) | DataMiner 10.1.4/10.2.0 <!-- [ID 29034] -->|
| Client-server communication: gRPC connections between [Cube and DMAs](xref:ConnectionSettings_txt#connectionsettingstxt-options) and [between DMAs](xref:DMS_xml#redirects-subtag) | DataMiner 10.3.0/10.3.2 <!-- [ID 34797] [ID 34983] --> |
| Cube: [BPA tests in System Center](xref:Running_BPA_tests) | DataMiner 10.1.2/10.2.0 <!-- [ID 28516] --> |
| Cube: [Duplicating a resource](xref:Configuring_pools_of_resources#duplicating-a-resource-from-a-pool) | DataMiner Cube 10.3.7/10.4.0 <!-- [ID 36308] -->|
| Cube: [Hiding the close button](xref:Working_with_cards_in_DataMiner_Cube#marking-cards-as-non-closable) and [Selecting a Master card](xref:Working_with_cards_in_DataMiner_Cube#selecting-a-master-card) | DataMiner Cube 10.3.9/10.4.0 <!-- [ID 36912] [ID 36956] --> |
| Cube: [Large Alarm Trees](xref:BPA_LargeAlarmTrees) BPA test | DataMiner 10.5.9/10.6.0 <!-- [ID 42952] --> |
| Cube: [Opening Cube from a session link](xref:Using_the_desktop_app#opening-dataminer-cube-from-a-session-link) | DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 <!-- [ID 42389] --> |
| Cube: [*UseInitialArgumentsAfterDisconnect* argument](xref:Options_for_opening_DataMiner_Cube#useinitialargumentsafterdisconnecttrue) | DataMiner Cube 10.2.0 [CU22]/10.3.0 [CU10]/10.4.1 <!-- [ID 37888] --> |
| Dashboards: [*Alarm table* component](xref:DashboardAlarmTable) | DataMiner 10.1.5/10.2.0 |
| Dashboards: [JSON input in URL parameters](xref:Specifying_data_input_in_a_URL) | DataMiner 10.2.0/10.2.2 <!-- [ID 31833] [ID 31885] -->|
| Dashboards: [*Node edge graph* component](xref:DashboardNodeEdgeGraph) | DataMiner 10.1.5/10.2.0 <!-- [ID 29425] -->|
| Dashboards: [PDF export](xref:Sharing_PDF_report_from_Dashboards_app) | DataMiner 10.2.12/10.3.0<br>DataMiner 10.2.2 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsexport) <!-- [ID 34634] -->|
| Dashboards: [*Progress bar* component](xref:DashboardProgressBar) | DataMiner 10.1.7/10.2.0 <!-- [ID 29773] --> |
| Dashboards: [Sharing dashboards using the Live Sharing Service](xref:Sharing_a_dashboard#sharing-a-live-dashboard-via-cloud-share) | DataMiner 10.1.12/10.2.0 <!-- [ID 29047] [ID 31476] -->|
| Dashboards: [*Trigger* component](xref:DashboardTrigger) | DataMiner 10.1.1/10.2.0 <!-- [ID 28136] --> |
| Dashboards/Low-Code Apps: [*Button panel* component](xref:DashboardButtonPanel) | DataMiner 10.3.9/10.4.0<br>DataMiner 10.0.3 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsbuttonpanel) <!-- [ID 36775] --> |
| Dashboards/Low-Code Apps: [Dynamic references in text](xref:Dynamically_Referencing_Data_in_Text) | DataMiner 10.3.11/10.4.0<!-- [ID 37229] --> |
| Dashboards/Low-Code Apps: [Exporting a GQI query](xref:Creating_GQI_query#exporting-a-query) | DataMiner web 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!-- [ID 43800] --> |
| Dashboards/Low-Code Apps: [Flows](xref:Using_flows) | DataMiner web 10.4.0 [CU9]/10.4.12<!-- [ID 40974] --><br>Minimum server version: DataMiner 10.3.9/10.4.0 |
| Dashboards/Low-Code Apps: [*Form* component](xref:DashboardForm) and DOM data input | DataMiner web 10.3.6/10.4.0<br>DataMiner 10.1.7 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#dommanager) <!-- [ID 36124] -->|
| Dashboards/Low-Code Apps: [*Grid* component](xref:DashboardGrid) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.2.12 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) |
| Dashboards/Low-Code Apps: [*Icon* component](xref:DashboardIcon) | DataMiner 10.3.1/10.4.0 <!-- [ID 34867] -->|
| Dashboards/Low-Code Apps: [*Maps* component](xref:DashboardMaps) | DataMiner web 10.4.0 [CU13]/10.5.0 [CU1]/DataMiner 10.5.4<!-- [ID 42309] --> |
| Dashboards/Low-Code Apps: [*Numeric input* component](xref:DashboardNumericInput) | DataMiner web 10.3.5/10.4.0 <!-- [ID 35911] -->|
| Dashboards/Low-Code Apps: [*Query filter* component](xref:DashboardQueryFilter) | DataMiner 10.3.9/10.4.0<br>DataMiner 10.0.10 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsptp) <!-- [ID 33530] --> |
| Dashboards/Low-Code Apps: [*Search input* component](xref:DashboardSearchInput) | DataMiner web 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 <!-- [ID 39555] -->|
| Dashboards/Low-Code Apps: [*Stepper* component](xref:DashboardStepper) | DataMiner 10.3.10/10.4.0 <!-- [ID 37200] -->|
| Dashboards/Low-Code Apps: [Template editor](xref:Template_Editor) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.2.12 with the soft-launch options [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) and [ReportsAndDashboardsScheduler](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsscheduler) |
| Dashboards/Low-Code Apps: [*Table* component column customization](xref:DashboardTable#column-appearance) | DataMiner web 10.4.1/10.5.0 <!-- [ID 37522] -->|
| Dashboards/Low-Code Apps: [*Text input* component](xref:DashboardTextInput) | DataMiner web 10.3.5/10.4.0 <!-- [ID 35902] -->|
| Dashboards/Low-Code Apps: [Variables](xref:Variables) | DataMiner web 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 <!-- [ID 41039] [ID 41063] [ID 41132] -->|
| Dashboards/Low-Code Apps: [*Timeline* component](xref:DashboardTimeline) | DataMiner web 10.4.1/10.5.0 <!-- [ID 34761] --><br>DataMiner 10.2.12 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsscheduler) <!-- [ID 37812] -->|
| Dashboards/Low-Code Apps: [*Toggle* component](xref:Toggle) | DataMiner web 10.4.0 [CU12]/10.5.3<!-- [ID 41903]--> |
| [Data Aggregator](xref:Data_Aggregator_DxM) | DataMiner 10.2.12/10.3.0 |
| Databases: [Configuring multiple Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters) | DataMiner 10.1.3/10.2.0 <!-- [ID 28473] -->|
| Databases: [Dedicated clustered storage](xref:Dedicated_clustered_storage) | DataMiner 10.1.2/10.2.0 <!-- [ID 28406] -->|
| Databases: [Elasticsearch to OpenSearch migration tool](xref:Migrating_from_Elasticsearch_to_OpenSearch) | DataMiner 10.4.0 [CU2]/10.4.4<!-- [ID 37994] --> |
| Databases: [OpenSearch indexing database](xref:OpenSearch_database) | DataMiner 10.3.0/10.3.3 |
| Databases: [Resource migration to Elasticsearch](xref:Resources_migration_to_elastic) | DataMiner 10.3.0/10.3.2 <!-- [ID 33797] -->|
| Databases: [Standalone Cassandra Backup tool](xref:Standalone_Cassandra_Backup_Tool) | DataMiner 10.1.8/10.2.0 <!-- [ID 29005] [ID 30234] -->|
| DataMiner processes: [Customization of number of simultaneous SLScripting processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slscripting-processes) | DataMiner 10.2.7/10.3.0 <!-- [ID 33358] -->|
| DataMiner processes: [Fine-tuning message throttling](xref:Configuration_of_DataMiner_processes#fine-tuning-message-throttling) | DataMiner 10.1.3/10.2.0 <!-- [ID 28335] -->|
| DataMiner processes: [Running elements in isolation mode](xref:Adding_elements#adding-elements-in-isolation-mode) | DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4<!-- [ID 41757] --> |
| DataMiner processes: [Separate SLProtocol and SLScripting instances for specific protocol](xref:Configuration_of_DataMiner_processes#configuring-separate-slprotocol-and-slscripting-instances-for-a-specific-protocol) | DataMiner 10.2.5/10.3.0 |
| DataMiner processes: [SLProtocol as a 64-bit process](xref:Activating_SLProtocol_as_a_64_Bit_Process) |  DataMiner 10.3.9/10.4.0<br>DataMiner 10.1.8 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#slprotocolasx64) |
| [DMS connection to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) | DataMiner 10.1.12/10.2.0 |
| [DOM](xref:DOM) (DataMiner Object Models) | DataMiner 10.1.2/10.2.0 <!-- [ID 28460] --> |
| DOM: [Actions](xref:DOM_actions) | DataMiner 10.1.11/10.2.0 <!-- [ID 30923] --> |
| DOM: [Attachments](xref:DomHelper_class#attachments) | DataMiner 10.1.3/10.2.0 <!-- [ID 28739] --> |
| DOM: [Calculating changes to a DOM instance](xref:ExecuteScriptOnDomInstanceActionSettings#calculating-changes-done-to-a-dom-instance-in-a-crud-script) | DataMiner 10.4.3/10.5.0 <!-- [ID 38364] -->|
| DOM: [CRUD actions on multiple instances](xref:DomHelper_class#multiple-instances) | DataMiner 10.4.2/10.5.0 <!-- [ID 37891] -->|
| DOM: [definition-level security configuration](xref:DOM_security_ui) | DataMiner Cube 10.5.11/10.6.0 <!-- [ID 43622] --><br>Minimum server version: DataMiner 10.5.10/10.6.0 |
| DOM: [DomBehaviorDefinition](xref:DomBehaviorDefinition) and [status system](xref:DOM_status_system_example) | DataMiner 10.1.11/10.2.0 <!-- [ID 30443] --> |
| DOM: [DomInstanceFieldDescriptor](xref:DOM_DomInstanceFieldDescriptor) and [ElementFieldDescriptor](xref:DOM_ElementFieldDescriptor) | DataMiner 10.1.10/10.2.0 <!-- [ID 30583] --> |
| DOM: [DomInstanceNameDefinition](xref:DomInstanceNameDefinition) | DataMiner 10.1.9/10.2.0 <!-- [ID 30226] -->|
| DOM: [DomInstanceNetworkAttachmentSettings](xref:DOM_DomInstanceNetworkAttachmentSettings) | DataMiner 10.5.10/10.6.0 <!-- [ID 43114] + [ID 43366] --> |
| DOM: [DomInstanceValueFieldDescriptor](xref:DOM_DomInstanceValueFieldDescriptor) | DataMiner 10.2.3/10.3.0 <!-- [ID 32326] -->|
| DOM: [GroupFieldDescriptor](xref:DOM_GroupFieldDescriptor) and [UserFieldDescriptor](xref:DOM_UserFieldDescriptor) | DataMiner 10.3.3/10.4.0 <!-- [ID 35278] -->|
| DOM: [History of DOM instances](xref:DOM_history) | DataMiner 10.1.3/10.2.0 <!-- [ID 28709] --> |
| DOM: [Interactive Automation script action](xref:DOM_actions#interactive-script) |  DataMiner 10.2.8/10.3.0 <!-- [ID 33513] -->|
| DOM: [DOM link security](xref:DOM_security) | DataMiner 10.5.10/10.6.0 <!-- [ID 43589] --> |
| EPM: [Aliases for topology cells, chains and search chains](xref:EPMConfig_xml) | DataMiner 10.1.7/10.2.0 <!-- [ID 29766] [ID 29841] -->|
| [EPM integration](xref:Topology_app_configuration) | DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5<!-- [ID 42221] --> |
| [Failover with shared hostname](xref:Failover_configuration_in_Cube) | DataMiner 10.1.8/10.2.0 |
| GQI: [Ad hoc data sources](xref:Get_ad_hoc_data) | DataMiner 10.2.4/10.3.0 <!-- [ID 32656] [ID 32659] [ID 32930] -->|
| GQI: [Alarms data source](xref:Get_alarms) | DataMiner 10.1.9/10.2.0 <!-- [ID 30320] --> |
| GQI: [Custom operator](xref:GQI_Custom_Operator) | DataMiner web 10.3.0 [CU10]/10.4.1 <!-- [ID 37840] --><br>DataMiner 10.2.7 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) |
| GQI: [Custom sort order](xref:GQI_Redirect_Sort_Tutorial) | DataMiner 10.4.5/10.5.0 <!-- [ID 39136] -->|
| GQI: [DCF connections data source](xref:Get_DCF_connections) | DataMiner 10.1.3/10.2.0 <!-- [ID 29703] -->|
| GQI: [Relational anomalies data source](xref:Get_relational_anomalies) | DataMiner 10.5.12/10.6.0 <!-- [ID 43820] --> |
| GQI: [Importing queries](xref:Importing_a_query) | DataMiner 10.1.4/10.2.0 <!-- [ID 29022] --> |
| GQI: [Logging](xref:GQI_Logging) | DataMiner 10.4.0/10.4.4 <!-- [ID 38870] --> |
| GQI: [Logging of metrics](xref:GQI_Logging#metrics) | DataMiner 10.4.0 [CU3]/10.4.5 <!-- [ID 39098] -->|
| GQI: [Real-time updates for ad hoc data sources](xref:GQI_IGQIUpdateable) | DataMiner 10.4.4/10.5.0 <!-- [ID 38643] --> |
| GQI: [Sending/receiving DMS messages](xref:GQI_GQIDMS) | DataMiner web 10.3.4/10.4.0 <!-- [ID 35701] -->|
| GQI: [Trend data patterns](xref:Get_trend_data_patterns), [Trend data pattern events](xref:Get_trend_data_pattern_events), and [behavioral change events](xref:Get_behavioral_change_events) data sources | DataMiner web 10.3.3/10.4.0 <!-- [ID 34747] [ID 35027] [ID 34965] [ID 35058] -->|
| GQI: [View relations data source](xref:Get_view_relations) | DataMiner 10.1.4/10.2.0 <!-- [ID 28797] [ID 28877] -->|
| [GQI DxM](xref:GQI_DxM) | DataMiner web 10.5.0 [CU1]/10.5.4 |
| [Low-Code Apps](xref:Application_framework) | DataMiner 10.2.5/10.3.0<br>DataMiner 10.0.8 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#applications) <!-- [ID 33040] -->|
| Low-Code Apps: [*Change variable* actions](xref:LowCodeApps_event_config#changing-a-variable) | DataMiner web 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1<!-- [ID 41253] [ID 41324] --> |
| Low-Code Apps: [*Copy to clipboard* action](xref:LowCodeApps_event_config#copying-text-to-the-clipboard) | DataMiner web 10.4.0 [CU11]/10.5.2<!-- [ID 41729]-->|
| Low-Code Apps: [Duplicating an app](xref:Creating_custom_apps#duplicating-an-existing-low-code-app) | DataMiner web 10.3.0 [CU10]/10.4.1 <!-- [ID 37698] -->|
| Low-Code Apps: [*Interactive Automation script* component](xref:InteractiveAutomationScript) | DataMiner web 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 <!-- [ID 39969] -->|
| Low-Code Apps: [*Open monitoring card* action](xref:LowCodeApps_event_config#opening-a-monitoring-card) | DataMiner web 10.3.4/10.4.0 <!-- [ID 35661] -->|
| Low-Code Apps: [*Show a notification* action](xref:LowCodeApps_event_config#showing-a-notification) | DataMiner 10.3.0 [CU12]/10.4.3 <!-- [ID 38548] -->|
| Low-Code Apps: [Timeline component events and actions](xref:DashboardTimeline#adding-actions-to-a-timeline) | DataMiner web 10.3.0 CU14/10.4.0 CU2/10.4.5<!-- [ID 39254] --> |
| Low-Code Apps: [Trigger component actions that let users control the trigger timer](xref:DashboardTrigger#letting-users-control-the-trigger-timer) | DataMiner web 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8 <!-- [ID 43184]  --> |
| Low-Code Apps: [On app open event](xref:Changing_low-code_app_settings#having-an-event-triggered-when-the-app-is-opened) | DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10<!-- [ID 43350] --> |
| Protocols: [Buttons in table cells to open DataMiner objects](xref:UIComponentsTableRowButtons) | DataMiner 10.1.9/10.2.0 <!-- [ID 30413] --> |
| Protocols: [Buttons to open EPM objects](xref:AdvancedEPMLaunchEPMObjectsTableCellButtons)| DataMiner 10.2.3/10.3.0 <!-- [ID 32368] --> |
| Protocols: [NT_CLEAR_PARAMETER (474)](xref:NT_CLEAR_PARAMETER) message | DataMiner 10.4.0 [CU15]/10.5.0 [CU3]/10.5.6 <!-- [ID 42368] --> |
| Protocols: [Protocol.ParameterGroups.Group-isInternal](xref:Protocol.ParameterGroups.Group-isInternal) attribute to mark DCF connections as internal | DataMiner 10.1.6/10.2.0 <!-- [ID 29438] -->|
| Protocols: [Table-based matrix](xref:UIComponentsTableMatrix) | DataMiner 10.3.1/10.4.0 <!-- [ID 34645] -->|
| Protocols: [Direct view table with table columns of different protocols](xref:Protocol.Params.Param.CrossDriverOptions) | DataMiner 10.2.9/10.3.0 <!-- [ID 33253] --> |
| [User-defined APIs](xref:UD_APIs) | DataMiner 10.3.6/10.4.0<br>DataMiner 10.3.5 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#userdefinableapi) <!-- [ID 36273] --> |
| Security: [Custom user group rights presets](xref:Configuring_a_user_group#using-presets-to-assign-rights) | DataMiner Cube 10.4.0 [CU12]/10.5.0 [CU1]/10.5.3<!-- [ID 41656] --> |
| Security: [External user authentication using Azure B2C](xref:SAML_using_Azure_B2C) | DataMiner 10.2.6/10.3.0 <!-- [ID 32714] -->|
| Security: [External user authentication using Entra ID (formerly Azure AD)](xref:SAML_using_Entra_ID) | DataMiner 10.1.5/10.2.0 <!-- [ID 28444] -->|
| Security: [External user authentication using Okta](xref:SAML_using_Okta) | DataMiner 10.1.11/10.2.0 <!-- [ID 30749]-->|
| Service & Resource Management: [Resource availability](xref:Resource_availability) | DataMiner 10.5.3/10.6.0<!-- [ID 41894] --> |
| Spectrum Analysis: [Zooming and panning](xref:Viewing_spectrum_analyzer_traces#zooming-and-panning) | DataMiner Cube DataMiner 10.3.11/10.4.0 <!-- [ID 37284] [ID 37461] --> |
| [Storage as a Service (STaaS)](xref:STaaS) | DataMiner 10.4.0/10.4.1 |
| [Swarming](xref:Swarming) | DataMiner 10.5.1/10.6.0<br>DataMiner 10.3.11 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#swarming) (Feature Release only)<!-- [ID 41490] --> |
| Visual Overview: [Background color for static shapes](xref:Setting_the_background_color_of_a_static_shape) | DataMiner 10.1.11/10.2.0 <!-- [ID 30964] --> |
| Visual Overview: [*BookingData* component](xref:Linking_a_shape_to_a_booking#making-the-booking-shape-display-booking-information) | DataMiner Cube 10.3.8/10.4.0<br>DataMiner 10.2.7 with [soft-launch option](xref:Overview_of_Soft_Launch_Options#bookingdata)<!-- [ID 33215] [ID 36489] --> |
| Visual Overview: [Control to set duration in session variable](xref:Adding_options_to_a_session_variable_control#creating-a-control-to-set-a-duration-in-a-session-variable) | DataMiner 10.3.0/10.2.4 <!-- [ID 32716] -->|
| Visual Overview: [[Element:] placeholder](xref:Placeholders_for_variables_in_shape_data_values#elementinputoutput) | DataMiner 10.1.12/10.2.0 <!-- [ID 31158] -->|
| Visual Overview: [EPM statistics](xref:Linking_a_shape_to_an_EPM_object#showing-statistics-for-the-epm-object-in-the-shape-text) | DataMiner Cube 10.3.2/10.4.0 <!-- [ID 35222] --> |
| Visual Overview: [Filter for Service Manager component](xref:Embedding_a_Service_Manager_component#configuring-filters-for-a-service-manager-component) | DataMiner 10.2.6/10.3.0 <!-- [ID 33187] -->|
| Visual Overview: [History alarm shape](xref:Linking_a_shape_to_a_history_alarm) | DataMiner 10.1.8/10.5.0 <!-- [ID 29822] -->|
| Visual Overview: [History values for element parameters](xref:Linking_a_shape_to_an_element_parameter#displaying-history-values-for-parameters) | DataMiner 10.1.10/10.2.0 <!-- [ID 30333] -->|
| Visual Overview: [*RegexMatch* placeholder](xref:Placeholders_for_variables_in_shape_data_values#regexmatchxyoptions) | DataMiner Cube 10.3.0 [CU17]/10.4.0 [CU5]/10.4.8 <!-- [ID 39763] -->|
| Visual Overview: [Resource shape](xref:Linking_a_shape_to_a_resource) | DataMiner 10.1.10/10.2.0 <!-- [ID 30752] -->|
| Visual Overview: [[ServiceDefinition:] placeholder](xref:Placeholders_for_variables_in_shape_data_values#servicedefinition) | DataMiner 10.1.10/10.2.0 <!-- [ID 30757] -->|
| Visual Overview: [[this reservationID] placeholder](xref:Placeholders_for_variables_in_shape_data_values#this-reservationid) | DataMiner 10.2.8/10.3.0 <!-- [ID 33669] -->|
| Visual Overview: [Table control with Refresh and/or Sort button](xref:Turning_a_shape_into_a_parameter_control#adding-a-refresh-andor-sort-button-to-a-table-control) | DataMiner 10.2.6/10.3.0 <!-- [ID 33346]-->|
| Visual Overview: [Text wrapping and trimming](xref:Configuring_text_wrapping_and_trimming) | DataMiner 10.2.3/10.3.0 <!-- [ID 32440] --> |
| Visual Overview (web): [Load balancing](xref:Investigating_Web_Issues#load-balancing) | DataMiner 10.5.2/10.6.0 <!-- [ID 41434] [ID 41728] --> |
| [Web DcM](xref:DataMinerExtensionModules#web) | DataMiner 10.5.0 [CU8]/10.5.11 <!-- [ID 43439] --> |
