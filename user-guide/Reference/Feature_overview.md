---
uid: Feature_overview
---

# Feature overview

Below you can find an overview of the main features that have been added to DataMiner in recent versions. Features that were already included in versions prior to the currently supported DataMiner versions are not included in the overview.

|Feature | Minimum required version(s) |
|---|---|
| Augmented operations: [Anomaly feedback](xref:Providing_user_feedback) | DataMiner 10.4.11/10.5.0<br>DataMiner 10.4.4 with soft-launch option |
| Augmented operations: [Proactive cap detection feedback](xref:Providing_user_feedback) | DataMiner 10.5.1/10.6.0 |
| Automation: [SkipAbortConfirmation](xref:Skyline.DataMiner.Automation.UIBuilder.SkipAbortConfirmation) property | DataMiner 10.4.12/10.5.0 |
| Dashboards/Low-Code Apps: [Flows](xref:Using_flows) | DataMiner web 10.4.12 |
| Dashboards/Low-Code Apps: [Variables](xref:Variables) | DataMiner web 10.4.12 |
| Low-Code Apps: [*Interactive Automation script* component](xref:InteractiveAutomationScript) | DataMiner web 10.4.9 |
| Low-Code Apps: [*Change variable* actions](xref:LowCodeApps_event_config#changing-a-variable) | DataMiner web 10.5.1 |
| [Swarming](xref:Swarming) | DataMiner 10.5.1/10.6.0<br>DataMiner 10.3.11 with soft-launch option (Feature Release only) |
| Visual Overview: [*RegexMatch* placeholder](xref:Placeholders_for_variables_in_shape_data_values#regexmatchxyoptions) | DataMiner Cube 10.3.0 [CU17]/10.4.0 [CU5]/10.4.8 |

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
| Migrating data to STaaS via a proxy | 10.4.6 |   |   |
| [Migrating from Elasticsearch to OpenSearch](xref:Migrating_from_Elasticsearch_to_OpenSearch) | 10.4.0 [CU2]/10.4.4 |   | |
| [Migrating SRM resources to the indexing database](xref:Resources_migration_to_elastic) | 10.3.0/10.3.2 |   | |
| OpenSearch cluster | 10.3.0/10.3.3 |   | |
| [Specifying credentials for a shared backup path for Elasticsearch](xref:SLNetClientTest_credentials_shared_backup_Elasticsearch) | 10.2.0/10.1.8 |   | |
| [Standalone Cassandra Backup tool](xref:Standalone_Cassandra_Backup_Tool) | 10.1.8/10.2.0 |   | |

## DataMiner Cube

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Automatic Cube updates | 10.2.0 [CU3]/10.2.6 |   | |

## dataminer.services

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| Storage as a Service (STaaS) | 10.3.10 [CU1] |   | |

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
| [Automatic backup of all dashboards and low-code apps during DMA upgrade or Web upgrade](xref:Upgrading_Downgrading_Webapps#automatic-backup) | 10.3.11/10.3.0 [CU8] |   | |
| Button panel component | 10.3.9/10.4.0 | 10.0.3 | |
| [DataMiner web upgrades](xref:Upgrading_Downgrading_Webapps) | 10.3.0/10.3.3 |   | |
| Export to PDF (in Dashboards app) | 10.2.12/10.3.0 | 9.6.4 | |
| Grid component | 10.3.0 [CU10]/10.4.1 | 10.2.12 | |
| Low-code apps | 10.2.5/10.3.0 | 10.0.8 | |
| Message throttling | 10.2.0/10.1.2 |   | |
| Monitoring app | 10.0.2/10.0.0 | 9.6.7 ||
| Query filter component | 10.3.9/10.4.0 | 10.0.4 | |
| Template Editor | 10.4.1/10.5.0 | 10.2.12 | |
| Timeline component | 10.3.0 [CU10]/10.4.1 | 10.1.10 ||
| Using DOM data in dashboards and low-code apps | 10.3.6/10.4.0 | 10.1.7 |  |

## Miscellaneous

|Feature | Minimum DataMiner version | Minimum soft-launch version | Notes |
|---|---|---|---|
| BrokerGateway DxM | N/A | 10.4.1 | |
| Data Aggregator DxM | 10.2.12 |   | |
| DataMiner Object Models (DOM) | 10.1.2/10.2.0 |   | |
| Failover using a shared hostname instead of virtual IP addresses | 10.2.0/10.1.8 |   | |
| gRPC connections between DMAs and between DMAs and client applications | 10.3.2/10.3.0 |   | |
| NATS using TLS | 10.4.3 |   | |
| Real-time updates in ad hoc data sources | 10.4.4/10.5.0 |   | |
| SLProtocol as a 64-bit process | 10.3.9 | 10.1.8 | |
| User-defined APIs | 10.3.6/10.4.0 | 10.3.5 | |
