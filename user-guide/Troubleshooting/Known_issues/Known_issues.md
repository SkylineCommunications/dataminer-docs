---
uid: Known_issues
---
# Known issues

## 10.3.x

| Issue | DataMiner version | Date added |
|--|--|--|
| [Default NATS port is already in use](xref:KI_NATS_port_9090) | From DataMiner 10.1.0/10.1.1 onwards | August 3, 2023 |
| [Unable to connect to DMS when using .NET Remoting](xref:KI_Unable_to_Connect_Net_Remoting) | DataMiner Cube 10.3.7 and 10.3.8 <br>Any versions from DataMiner 10.2.0 onwards using automatic client updates | August 1, 2023 |
| [Various issues with a geo-redundant Cassandra setup with multiple data centers](xref:KI_Multiple_Datacenters) | Cassandra Cluster setups | June 1, 2023 |
| [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node) | Cassandra Cluster setups | June 1, 2023 |
| [Corrupted low-code app after concurrent editing actions](xref:KI_app_corruption_after_editing) | From DataMiner 10.2.5/10.3.0 onwards | May 26, 2023 |
| [Cassandra cluster data not offloaded while database is unavailable](xref:KI_Cassandra_cluster_data_not_offloaded) | Cassandra Cluster setups | May 22, 2023 |
| [Inaccessible logger table data in Elasticsearch because of incorrect casing](xref:KI_Inaccessible_data_Elasticsearch_casing) | From DataMiner 10.3.0 to 10.3.0 [CU2]<br>From DataMiner 10.3.3 to 10.3.5.| May 8, 2023 |
| [RTEs caused by problem during automatic NATS reconfiguration](xref:KI_RTEs_NATS_reconfiguration) | From DataMiner 10.3.4 onward | May 5, 2023 |
| [Activities and scripts delayed because of CheckVIPs thread](xref:KI_CheckVIPs_delays_activities) | DataMiner 10.2.0 up to 10.2.0 [CU15]/10.3.0 [CU4]<br>DataMiner 10.1.12 up to 10.3.6 | April 28, 2023 |
| [Elasticsearch not initialized when DataMiner starts up](xref:KI_Elasticsearch_not_initialized_on_DMA_startup) | Any version using Elasticsearch | April 20, 2023 |
| [DataMiner keeps trying to restart when Elasticsearch is unavailable](xref:KI_Restart_loop_when_Elasticsearch_unavailable) | DataMiner 10.3 main and feature releases | April 11, 2023 |
| [GenIf folder takes up too much disk space](xref:KI_GenIf_Folder_Growing_In_Size) | DataMiner 10.1.0 up to 10.3.0 [CU4]<br>DataMiner 10.0.13 up to 10.3.7 | March 15, 2023 |
| [Problem with booking automation and function DVE deactivation](xref:KI_SRM_booking_events_issue) | SRM setups with DataMiner version below 10.3.0/10.3.2 | March 10, 2023 |
| [SLPort deadlock when element with serial connection is restarted](xref:KI_SLPort_deadlock_after_restart_serial_connection) | DataMiner 10.1.0 [CU17] to 10.2.0 [CU11]/10.3.0.0 - 12752<br>DataMiner 10.2.8 to 10.3.3 | February 28, 2023 |
| [Local user unable to access DMA after first reboot after installation](xref:KI_Local_user_unable_to_access_DMA_after_first_reboot_after_installation) | DataMiner 10.3.3 | February 24, 2023 |
| [Node: 'X' is not supported by the current server version](xref:KI_Node_is_not_supported_by_the_current_server_version) | DataMiner 10.3.2 | January 26, 2023 |
| [Contents of state_changes table not migrated after Cassandra Cluster migration](xref:KI_Contents_of_State_changes_Table_not_Migrated_after_Cassandra_Cluster_Migration) | Cassandra Cluster setups | January 16, 2023 |
| [Cassandra cluster node in unexpected state](xref:KI_Cassandra_cluster_node_unexpected_state) | Cassandra Cluster setups | January 10,2023 |
| [Year 2038 problem for Cassandra](xref:Year_2038_Problem_for_Cassandra) | All DataMiner versions with a Cassandra setup<br>prior to DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | January 10, 2023 |
| [Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details](xref:KI_NullReferenceException_SLDBConnection) | DataMiner 10.1.0 up to 10.2.0 [CU10]<br>DataMiner 10.1.2 up to 10.3.1 | December 20, 2022 |
| [SLProtocol timer thread run-time error](xref:KI_SLProtocol_timer_thread_RTE) | DataMiner versions prior to 10.2.0 [CU10]/10.3.1 | December 20, 2022 |
| [Vertical text in Visual Overview not displayed correctly](xref:KI_Visual_Overview_Vertical_Text_no_longer_working) | From DataMiner 10.2.0 [CU3]/10.2.3 onwards | December 16, 2022 |
| [SLNet deadlock on DMA startup](xref:KI_SLNet_deadlock_on_startup) | DataMiner 10.1.0 up to 10.2.0 [CU15]/10.3.0 [CU3]<br>DataMiner 10.1.2 up to 10.3.2 | December 14, 2022 |
| [Stable trend points not kept alive](xref:KI_stable_trend_points_not_kept_alive) | DataMiner 10.2.0 [CU8] up to 10.2.0 [CU10]<br>DataMiner 10.2.10 up to 10.3.1 | December 9, 2022 |
| [Missing 1-day average trending records](xref:KI_missing_avg_trending) | DataMiner 10.2.0 [CU0] up to 10.2.0 [CU10]<br>DataMiner 10.1.10 up to 10.3.1 | December 9, 2022 |
| [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput) | DataMiner 10.1.0 and 10.2.0 (up to [CU10])<br>From DataMiner 10.0.2 up to 10.3.1 | December 8, 2022 |
| [Various SLElement issues](xref:KI_SLElement_various_issues) | See [detailed page](xref:KI_SLElement_various_issues). | November 25, 2022 |
| [Element data lost after migrating elements in Cassandra Cluster setup](xref:KI_element_data_loss_after_migration_in_CC_setup) | DataMiner 10.1.0 up to 10.2.0 [CU11]<br>DataMiner 10.0.11 up to 10.3.1 | November 15, 2022 |
| [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars) | From DataMiner 10.1.0/10.1.2 <br>onwards | November 8, 2022 |
| [Excessive SLElement CPU usage during Cassandra Cluster migration](xref:KI_SLElement_CPU_high_during_CC_migration) | From DataMiner 10.1.0/10.1.2 <br>onwards. | October 28, 2022 |
| [SLElement memory leak during Cassandra Cluster migration](xref:KI_SLElement_CPU_memory_leak_during_CC_migration) | From DataMiner 10.1.0/10.1.2 <br>onwards. | October 28, 2022 |
| [Data from Elasticsearch cluster with IPv6 addresses offloaded to files](xref:KI_Elasticsearch_IPv6) | Any version prior to DataMiner 10.2.0 [CU11]/10.3.2 with Elasticsearch cluster using IPv6 addresses | October 21, 2022 |
| [Upgrade fails because of VerifyClusterPort.dll prerequisite](xref:KI_Upgrade_fails_VerifyClusterPorts_prerequisite) | From 10.2.0 CU1 and 10.2.4 onwards | September 2, 2022 |

## 10.2.x

| Issue | DataMiner version | Date added |
|--|--|--|
| [Default NATS port is already in use](xref:KI_NATS_port_9090) | From DataMiner 10.1.0/10.1.1 onwards | August 3, 2023 |
| [Unable to connect to DMS when using .NET Remoting](xref:KI_Unable_to_Connect_Net_Remoting) | Any versions from DataMiner 10.2.0 onwards using automatic client updates | August 1, 2023 |
| [RTEs caused by problem when updating alarm templates](xref:KI_RTEs_Alarm_Template_Issue) | DataMiner 10.2.0 [CU15], [CU16], and [CU17] | July 31, 2023 |
| [Various issues with a geo-redundant Cassandra setup with multiple data centers](xref:KI_Multiple_Datacenters) | Cassandra Cluster setups | June 1, 2023 |
| [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node) | Cassandra Cluster setups | June 1, 2023 |
| [Corrupted low-code app after concurrent editing actions](xref:KI_app_corruption_after_editing) | From DataMiner 10.2.5/10.3.0 onwards | May 26, 2023 |
| [Cassandra cluster data not offloaded while database is unavailable](xref:KI_Cassandra_cluster_data_not_offloaded) | Cassandra Cluster setups | May 22, 2023 |
| [Activities and scripts delayed because of CheckVIPs thread](xref:KI_CheckVIPs_delays_activities) | DataMiner 10.2.0 up to 10.2.0 [CU15]/10.3.0 [CU4]<br>DataMiner 10.1.12 up to 10.3.6 | April 28, 2023 |
| [Elasticsearch not initialized when DataMiner starts up](xref:KI_Elasticsearch_not_initialized_on_DMA_startup) | Any version using Elasticsearch | April 20, 2023 |
| [GenIf folder takes up too much disk space](xref:KI_GenIf_Folder_Growing_In_Size) | From DataMiner 10.1.0/10.0.13 onwards | March 15, 2023 |
| [Problem with booking automation and function DVE deactivation](xref:KI_SRM_booking_events_issue) | SRM setups with DataMiner version below 10.3.0/10.3.2 | March 10, 2023 |
| [SLPort deadlock when element with serial connection is restarted](xref:KI_SLPort_deadlock_after_restart_serial_connection) | DataMiner 10.1.0 [CU17] to 10.2.0 [CU11]/10.3.0.0 - 12752<br>DataMiner 10.2.8 to 10.3.3 | February 28, 2023 |
| [Contents of state_changes table not migrated after Cassandra Cluster migration](xref:KI_Contents_of_State_changes_Table_not_Migrated_after_Cassandra_Cluster_Migration) | Cassandra Cluster setups | January 16, 2023 |
| [Cassandra cluster node in unexpected state](xref:KI_Cassandra_cluster_node_unexpected_state) | Cassandra Cluster setups | January 10,2023 |
| [Year 2038 problem for Cassandra](xref:Year_2038_Problem_for_Cassandra) | All DataMiner versions with a Cassandra setup<br>prior to DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | January 10, 2023 |
| [Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details](xref:KI_NullReferenceException_SLDBConnection) | DataMiner 10.1.0 up to 10.2.0 [CU10]<br>DataMiner 10.1.2 up to 10.3.1 | December 20,2022 |
| [SLProtocol timer thread run-time error](xref:KI_SLProtocol_timer_thread_RTE) | DataMiner versions prior to 10.2.0 [CU10]/10.3.1 | December 20, 2022 |
| [Vertical text in Visual Overview not displayed correctly](xref:KI_Visual_Overview_Vertical_Text_no_longer_working) | From DataMiner 10.2.0 [CU3]/10.2.3 onwards | December 16, 2022 |
| [SLNet deadlock on DMA startup](xref:KI_SLNet_deadlock_on_startup) | DataMiner 10.1.0 up to 10.2.0 [CU15]/10.3.0 [CU3]<br>DataMiner 10.1.2 up to 10.3.2 | December 14, 2022 |
| [Stable trend points not kept alive](xref:KI_stable_trend_points_not_kept_alive) | DataMiner 10.2.0 [CU8] up to 10.2.0 [CU10]<br>DataMiner 10.2.10 up to 10.3.1 | December 9, 2022 |
| [Missing 1-day average trending records](xref:KI_missing_avg_trending) | DataMiner 10.2.0 [CU0] up to 10.2.0 [CU10]<br>DataMiner 10.1.10 up to 10.3.1 | December 9, 2022 |
| [Memory leak in SLNet threads](xref:KI_SLNet_thread_leak) | DataMiner 10.2.12 [CU0] and [CU1] | December 9, 2022 |
| [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput) | DataMiner 10.1.0 and 10.2.0 (up to [CU10])<br>From DataMiner 10.0.2 up to 10.3.1 | December 8, 2022 |
| [SLNet issues due to SPI obfuscation](xref:KI_SLNet_issue_SPI_obfuscation) | DataMiner 10.2.0 [CU3] up to 10.2.0 [CU5]<br>DataMiner 10.2.6 up to 10.2.8 | December 7, 2022 |
| [Various SLElement issues](xref:KI_SLElement_various_issues) | See [detailed page](xref:KI_SLElement_various_issues). | November 25, 2022 |
| [SLLog issue when large alarm tree is closed](xref:KI_SLLog_issue_when_large_alarm_tree_is_closed) | DataMiner 10.2.0 [CU8] and [CU9]<br>DataMiner 10.2.11 and 10.2.12 | November 16, 2022 |
| [Element data lost after migrating elements in Cassandra Cluster setup](xref:KI_element_data_loss_after_migration_in_CC_setup) | DataMiner 10.1.0 up to 10.2.0 [CU11]<br>DataMiner 10.0.11 up to 10.3.1 | November 15, 2022 |
| [Multiple issues when Failover based on hostnames is used](xref:KI_Failover_with_hostnames) | From DataMiner 10.2.0/10.1.8 <br>onwards | November 15, 2022 |
| [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars) | From DataMiner 10.1.0/10.1.2 <br>onwards | November 8, 2022 |
| [SLDataGateway memory leak during Cassandra Cluster migration](xref:KI_SLDataGateway_leak_during_CC_migration) | DataMiner 10.1.0 prior to CU22<br>DataMiner 10.2.0 prior to CU10<br>DataMiner 10.1.2 to 10.2.12 | November 3, 2022 |
| [Excessive SLElement CPU usage during Cassandra Cluster migration](xref:KI_SLElement_CPU_high_during_CC_migration) | From DataMiner 10.1.0/10.1.2 <br>onwards. | October 28, 2022 |
| [SLElement memory leak during Cassandra Cluster migration](xref:KI_SLElement_CPU_memory_leak_during_CC_migration) | From DataMiner 10.1.0/10.1.2 <br>onwards. | October 28, 2022 |
| [SLProtocol memory leak when HTTP connectors are used](xref:KI_SLProtocol_memory_leak_HTTP) | DataMiner 10.1.0 [CU19], 10.2.0 <br>[CU7], and 10.2.8 to 10.2.11 | October 26, 2022 |
| [Data from Elasticsearch cluster with IPv6 addresses offloaded to files](xref:KI_Elasticsearch_IPv6) | Any version prior to DataMiner 10.2.0 [CU11]/10.3.2 with Elasticsearch cluster using IPv6 addresses | October 21, 2022 |
| [Increased CPU load and degraded performance because of excessive number of SPI events](xref:Excessive_SPI_events_causing_CPU_load) | 10.2 Main and Feature Release <br>versions prior to 10.2.0 [CU6]<br> and 10.2.9. | October 19, 2022 |
| [SLDataGateway memory leak](xref:KI_SLDataGateway_memory_leak) | Cassandra Cluster setups<br>prior to 10.2.0 [CU8]/10.2.11 | October 10, 2022 |
| [Taskbar Utility performance issue while agents are being upgraded](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded) | 10.1.0 [CU19] and 10.2.0 [CU7]<br>10.2.10 | September 23, 2022 |
| [SLDMS Hosting Agent cache issue](xref:KI_SLDMS_hosting_agent_cache_issue) | 10.2 Main & Feature Release<br>prior to 10.2.0 CU7 and 10.2.10 | September 15, 2022 |
| [Closed alarms migrated too slowly from dms-activealarms index in Elasticsearch database](xref:KI_Closed_alarms_migrated_too_slowly) | Versions using Elasticsearch<br>for alarm indexing prior to<br>10.2.0 CU8 and 10.2.11 | September 14, 2022 |
| [SNMP polling issues in case protocol contains wildcards in parameter OIDs](xref:KI_SNMP_polling_issues_with_wildcards_in_param_OIDs) |10.2.0 CU6<br>10.2.9 | September 6, 2022 |
| [Upgrade fails because of VerifyClusterPort.dll prerequisite](xref:KI_Upgrade_fails_VerifyClusterPorts_prerequisite) | From 10.2.0 CU1 and 10.2.4 onwards | September 2, 2022 |
| [SLAnalytics RTEs after upgrading DMS with Cassandra Cluster](xref:KI_RTE_with_SLAnalytics_when_upgrading) | 10.2.8 CU1 | August 8, 2022 |

## Other

| Issue | DataMiner version | Date added |
|--|--|--|
| [Default NATS port is already in use](xref:KI_NATS_port_9090) | From DataMiner 10.1.0/10.1.1 onwards | August 3, 2023 |
| [Various issues with a geo-redundant Cassandra setup with multiple data centers](xref:KI_Multiple_Datacenters) | Cassandra Cluster setups | June 1, 2023 |
| [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node) | Cassandra Cluster setups | June 1, 2023 |
| [SRM - Auto Select Resource not read for silent booking](xref:KI_SRM_Auto_Select_Resource_Not_Read) | SRM 1.2.30 CU2 | March 29, 2023 |
| [IP address in SAN field of TLS certificate ignored in Windows 2012 R2](xref:KI_Win2012R2_ignores_IP_in_SAN_field) | Systems using Windows 2012 R2 | March 20, 2023 |
| [GenIf folder takes up too much disk space](xref:KI_GenIf_Folder_Growing_In_Size) | From DataMiner 10.1.0/10.0.13 onwards | March 15, 2023 |
| [SLPort deadlock when element with serial connection is restarted](xref:KI_SLPort_deadlock_after_restart_serial_connection) | DataMiner 10.1.0 [CU17] to 10.2.0 [CU11]/10.3.0.0 - 12752<br>DataMiner 10.2.8 to 10.3.3 | February 28, 2023 |
| [Year 2038 problem for Cassandra](xref:Year_2038_Problem_for_Cassandra) | All DataMiner versions with a Cassandra setup<br>prior to DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | January 10, 2023 |
| [Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details](xref:KI_NullReferenceException_SLDBConnection) | DataMiner 10.1.0 up to 10.2.0 [CU10]<br>DataMiner 10.1.2 up to 10.3.1 | December 20,2022 |
| [SLNet deadlock on DMA startup](xref:KI_SLNet_deadlock_on_startup) | DataMiner 10.1.0 up to 10.2.0 [CU15]/10.3.0 [CU3]<br>DataMiner 10.1.2 up to 10.3.2 | December 14, 2022 |
| [Missing 1-day average trending records](xref:KI_missing_avg_trending) | DataMiner 10.2.0 [CU0] up to 10.2.0 [CU10]<br>DataMiner 10.1.10 up to 10.3.1 | December 9, 2022 |
| [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput) | DataMiner 10.1.0 and 10.2.0 (up to [CU10])<br>From DataMiner 10.0.2 up to 10.3.1 | December 8, 2022 |
| [Various SLElement issues](xref:KI_SLElement_various_issues) | See [detailed page](xref:KI_SLElement_various_issues). | November 25, 2022 |
| [Element data lost after migrating elements in Cassandra Cluster setup](xref:KI_element_data_loss_after_migration_in_CC_setup) | DataMiner 10.1.0 up to 10.2.0 [CU11]<br>DataMiner 10.0.11 up to 10.3.1 | November 15, 2022 |
| [Multiple issues when Failover based on hostnames is used](xref:KI_Failover_with_hostnames) | From DataMiner 10.2.0/10.1.8 <br>onwards | November 15, 2022 |
| [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars) | From DataMiner 10.1.0/10.1.2 <br>onwards | November 8, 2022 |
| [SLDataGateway memory leak during Cassandra Cluster migration](xref:KI_SLDataGateway_leak_during_CC_migration) | DataMiner 10.1.0 prior to CU22<br>DataMiner 10.2.0 prior to CU10<br>DataMiner 10.1.2 to 10.2.12 | November 3, 2022 |
| [Excessive SLElement CPU usage during Cassandra Cluster migration](xref:KI_SLElement_CPU_high_during_CC_migration) | From DataMiner 10.1.0/10.1.2 <br>onwards. | October 28, 2022 |
| [SLElement memory leak during Cassandra Cluster migration](xref:KI_SLElement_CPU_memory_leak_during_CC_migration) | From DataMiner 10.1.0/10.1.2 <br>onwards. | October 28, 2022 |
| [SLProtocol memory leak when HTTP connectors are used](xref:KI_SLProtocol_memory_leak_HTTP) | DataMiner 10.1.0 [CU19], 10.2.0 <br>[CU7], and 10.2.8 to 10.2.11 | October 26, 2022 |
| [Increased CPU load and degraded performance because of excessive number of SPI events](xref:Excessive_SPI_events_causing_CPU_load) | 10.2 Main and Feature Release <br>versions prior to 10.2.0 [CU6]<br> and 10.2.9. | October 19, 2022 |
| [SLDataGateway memory leak](xref:KI_SLDataGateway_memory_leak) | Cassandra Cluster setups<br>prior to 10.2.0 [CU8]/10.2.11 | October 10, 2022 |
| [Taskbar Utility performance issue while agents are being upgraded](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded) | 10.1.0 [CU19] and 10.2.0 [CU7]<br>10.2.10 | September 23, 2022 |
| [SLDMS Hosting Agent cache issue](xref:KI_SLDMS_hosting_agent_cache_issue) | 10.2 Main & Feature Release<br>prior to 10.2.0 CU7 and 10.2.10 | September 15, 2022 |
| [Closed alarms migrated too slowly from dms-activealarms index in Elasticsearch database](xref:KI_Closed_alarms_migrated_too_slowly) | Versions using Elasticsearch<br>for alarm indexing prior to<br>10.2.0 CU8 and 10.2.11 | September 14, 2022 |
| [Cassandra nodes not configured if current DMA IP is assigned as virtual IP](xref:KI_Cassandra_nodes_not_configured_if_current_DMA_IP_is_assigned_as_virtual_IP) | 10.1.x | - |
| [Migration of Ticketing data from Cassandra to Elasticsearch fails](xref:KI_Migration_of_Ticketing_data_from_Cassandra_to_Elasticsearch_fails) | 10.1.x<br>10.0.x | - |
| [NATS error message after 10.1 installation](xref:KI_NATS_error_message_after_10_1_installation) | 10.1.x | - |
| [Smart-serial communication no longer working](xref:KI_Smart-serial_communication_no_longer_working) | 10.1.x | - |
| [Incorrect RTE counts in SLWatchdog2.txt and Alarm Console](xref:KI_Incorrect_RTE_counts_in_SLWatchdog2txt_and_Alarm_Console) | 10.0.x<br>9.6.x | - |
| [DataMiner Cube freeze on startup](xref:KI_DataMiner_Cube_freeze_on_startup) | N/A | - |
| [Not possible to generate reports on Windows Server 2012 or earlier](xref:KI_Not_possible_to_generate_reports_on_Windows_Server_2012_or_earlier) | N/A | - |
| [Setting a protocol to production takes a long time](xref:KI_Setting_a_protocol_to_production_takes_a_long_time) | N/A | - |
| [Shapes in DataMiner stencils not found in Visio search](xref:KI_Shapes_in_DataMiner_stencils_not_found_in_Visio_search) | N/A | - |
| [SLDataMiner addressChangeThread RTE after DMA startup](xref:KI_SLDataMiner_addressChangeThread_RTE_after_DMA_startup) | N/A | - |
| [SNMP SET returns a 'NO ACCESS' error](xref:KI_SNMP_SET_returns_a_NO_ACCESS_error) | N/A | - |
| [Unavailable system database after DataMiner server reboot](xref:KI_Unavailable_system_database_after_DataMiner_server_reboot) | N/A | - |
| [Upgrade error: api-ms-win-crt-stdio-l1-1-0.dll is missing](xref:KI_Upgrade_error_api-ms-win-crt-stdio-l1-1-0_dll_is_missing) | N/A | - |
