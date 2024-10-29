---
uid: Known_issues
---
# Known issues

## 10.4.x

| Issue | Affected versions | Resolved in | Date added |
|--|--|--|--|
| [Sticky element alarm state caused by correlation rules](xref:KI_sticky_element_alarm_state_caused_by_correlation_rules) | From DataMiner 10.2.0 onwards | | October 25, 2024 |
| [DataMiner incorrectly reports a Cassandra issue when another database fails](xref:KI_DataMiner_reports_Cassandra_issue_when_another_database_fails) | From DataMiner 10.4.0 onwards | | September 19, 2024 |
| [Inconsistent service impact of alarms after element is stopped and restarted](xref:KI_Inconsistent_service_impact) | All currently supported versions | | August 9, 2024 |
| [Unable to perform a DataMiner upgrade via Update Center](xref:KI_Unable_to_perform_a_DataMiner_upgrade_via_Update_Center) | From DataMiner 10.4.0 onwards | | August 6, 2024 |
| [Unable to override information events TTL of 5 years](xref:KI_Information_events_TTL_five_years) | Cassandra Cluster setups | | July 24, 2024 |
| [Problem after removing DMA from cluster](xref:KI_Problem_after_removing_DMA_from_cluster) | Any DataMiner version with clustered storage <br>and/or indexing | | December 15, 2023 |
| [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars) | From DataMiner 10.1.0/10.1.2 <br>onwards | | November 8, 2022 |
| [Upgrade fails because of VerifyClusterPort.dll prerequisite](xref:KI_Upgrade_fails_VerifyClusterPorts_prerequisite) | From 10.2.0 [CU1] and 10.2.4 onwards | | September 2, 2022 |
| [nats-server.config file not included in DataMiner backups](xref:KI_nats-server_config_file_not_included_in_backups) | From DataMiner 10.2.0 [CU6]/10.2.8 onwards | DataMiner 10.4.11/10.5.0 | October 10, 2024 |
| [Web apps experience frequent disconnects](xref:KI_Web_apps_experience_frequent_disconnects) | DataMiner 10.4.0 [CU6]<br>DataMiner 10.4.9 | DataMiner 10.4.0 [CU7]<br>DataMiner 10.4.10 | September 23, 2024 |
| [Problem when DMA server is named DATAMINER](xref:KI_Problem_when_server_name_is_DATAMINER) | From DataMiner 10.4.0 [CU2]/10.4.5 onwards | DataMiner 10.4.0 [CU9]<br>DataMiner 10.4.12 | September 10, 2024 |
| [ButtonState shapes in Visual Overview fail to hide as expected](xref:KI_ButtonState_shapes_in_Visual_Overview_fail_to_hide_as_expected) | DataMiner Cube versions prior to 10.4.2425.2536<br>DataMiner 10.4.8, if Cube client does not have internet access | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | August 13, 2024 |
| [Process crashes when trying to connect to MySQL database](xref:KI_MySQL_Unhandled_Exception) | From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 <br>onwards | DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 | July 15, 2024 |
| [Failover switch taking a long time on systems with Cassandra setup](xref:KI_Failover_switch_Cassandra) | Failover systems with Cassandra setup from DataMiner 10.4.2 to 10.4.8 | DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 | June 27, 2024 |
| [Deadlock in service loading during DataMiner startup](xref:KI_deadlock_service_loading) | From DataMiner 10.3.0 [CU10]/10.4.1 onwards | DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 [CU0] | June 11, 2024 |
| [SLProtocol RTE caused by SNMP group with condition](xref:KI_SLProtocol_RTE_SNMP_group_condition) |From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards | DataMiner 10.3.0 [CU17]/10.4.0 [CU5]/10.4.8 | June 6, 2024 |
| [Deadlock when forcing quarantine during booking update](xref:KI_Deadlock_when_forcing_quarantine) | DataMiner 10.4.6 | DataMiner 10.4.6 [CU1] | May 24, 2024 |
| [Param next attribute not working correctly](xref:KI_Param_next_not_working) | From DataMiner 10.1.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards | DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 | March 20, 2024 |
| [Error in SLDataMiner when generating MIB file](xref:KI_SLDataMiner_problem_generating_MIB) | DataMiner 10.4.2 and 10.4.3<br>DataMiner 10.4.0 [CU0]<br>DataMiner 10.3.0 [CU11] and [CU12]| DataMiner 10.3.0 [CU13], 10.4.0 [CU1], or 10.4.4| March 15, 2024 |
| [SLDataMiner crashes because of subgroup query failure](xref:KI_SLDataMiner_crashes_because_of_subgroup_query_failure) | DataMiner 10.4.2 and 10.4.3<br>DataMiner 10.3.0 [CU11] and [CU12]<br>DataMiner 10.4.0 [CU0] | DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 | March 11, 2024 |
| [Timetrace data is no longer written during Cassandra Cluster migration](xref:KI_Timetrace_Data_no_longer_written_during_Cassandra_Cluster_Migration) | Cassandra Cluster setups | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | February 29, 2024 |
| [IDP Discovery no longer working after upgrade](xref:KI_IDP_Discovery_not_working) | From DataMiner 10.4.0/10.4.3 onwards | IDP 1.5.0 | February 26, 2024 |
| [Port exhaustion because of NATS reconnection attempts](xref:KI_port_exhaustion_because_of_NATS_reconnect_attempts) | Any DataMiner version | DataMiner 10.4.6/10.5.0 | February 2, 2024 |
| [One or multiple Analytics features fail to start](xref:KI_Analytics_features_not_starting) | DataMiner 10.3.5 up to 10.4.2<br>10.2.0 Main Release from DataMiner 10.2.0 [CU13] onwards<br>DataMiner 10.3.0 [CU2] up to [CU11] | DataMiner 10.3.0 [CU12]/10.4.3 | January 29, 2024. |
| [NATS configuration not updated after adding DMA to DMS](xref:KI_NATS_config_not_updated_after_adding_DMA) | All DataMiner versions | DataMiner 10.3.0 [CU12]/10.4.0 [CU0]/10.4.3 | January 24, 2024 |
| [Downgrade fails because of VerifyNatsIsRunning.dll prerequisite](xref:KI_Downgrade_fails_VerifyNatsIsRunning_prerequisite) | From DataMiner 10.4.0/10.4.3 onwards | [Requires configuration](xref:KI_Downgrade_fails_VerifyNatsIsRunning_prerequisite) | January 23, 2024 |
| [Failover Agents remain offline after upgrade](xref:KI_Failover_Agents_offline_after_upgrade) | DataMiner 10.3.12 and 10.4.1<br>DataMiner 10.3.0 [CU9] and [CU10] | DataMiner 10.3.0 [CU11]/10.4.0/10.4.2 | January 22, 2024 |
| [NATS services missing after reboot](xref:KI_missing_NATS_services) | Any version | [Requires configuration](xref:KI_missing_NATS_services) | January 10, 2024 |
| [Elements not loading after upgrade of DMS with multiple Elasticsearch clusters](xref:KI_elements_not_loading_in_DMS_with_multiple_ES) | DataMiner 10.3.10 up to 10.4.1 | DataMiner 10.4.2 | October 3, 2023 |
| [Corrupted low-code app after concurrent editing actions](xref:KI_app_corruption_after_editing) | From DataMiner 10.2.5/10.3.0 onwards | DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 | May 26, 2023 |

## 10.3.x

| Issue | Affected versions | Resolved in | Date added |
|--|--|--|--|
| [Sticky element alarm state caused by correlation rules](xref:KI_sticky_element_alarm_state_caused_by_correlation_rules) | From DataMiner 10.2.0 onwards | | October 25, 2024 |
| [Unable to override information events TTL of 5 years](xref:KI_Information_events_TTL_five_years) | Cassandra Cluster setups | | July 24, 2024 |
| [Problem after removing DMA from cluster](xref:KI_Problem_after_removing_DMA_from_cluster) | Any DataMiner version with clustered storage <br>and/or indexing | | December 15, 2023 |
| [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars) | From DataMiner 10.1.0/10.1.2 <br>onwards | | November 8, 2022 |
| [Upgrade fails because of VerifyClusterPort.dll prerequisite](xref:KI_Upgrade_fails_VerifyClusterPorts_prerequisite) | From 10.2.0 [CU1] and 10.2.4 onwards | | September 2, 2022 |
| [nats-server.config file not included in DataMiner backups](xref:KI_nats-server_config_file_not_included_in_backups) | From DataMiner 10.2.0 [CU6]/10.2.8 onwards | DataMiner 10.4.11/10.5.0 | October 10, 2024 |
| [ButtonState shapes in Visual Overview fail to hide as expected](xref:KI_ButtonState_shapes_in_Visual_Overview_fail_to_hide_as_expected) | DataMiner Cube versions prior to 10.4.2425.2536<br>DataMiner 10.4.8, if Cube client does not have internet access | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | August 13, 2024 |
| [Process crashes when trying to connect to MySQL database](xref:KI_MySQL_Unhandled_Exception) | From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 <br>onwards | DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 | July 15, 2024 |
| [SLDataMiner crashes because of subgroup query failure](xref:KI_SLDataMiner_crashes_because_of_subgroup_query_failure) | DataMiner 10.4.2 and 10.4.3<br>DataMiner 10.3.0 [CU11] and [CU12]<br>DataMiner 10.4.0 [CU0] | DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 | March 11, 2024 |
| [Timetrace data is no longer written during Cassandra Cluster migration](xref:KI_Timetrace_Data_no_longer_written_during_Cassandra_Cluster_Migration) | Cassandra Cluster setups | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | February 29, 2024 |
| [Port exhaustion because of NATS reconnection attempts](xref:KI_port_exhaustion_because_of_NATS_reconnect_attempts) | Any DataMiner version | DataMiner 10.4.6/10.5.0 | February 2, 2024 |
| [One or multiple Analytics features fail to start](xref:KI_Analytics_features_not_starting) | DataMiner 10.3.5 up to 10.4.2<br>10.2.0 Main Release from DataMiner 10.2.0 [CU13] onwards<br>DataMiner 10.3.0 [CU2] up to [CU11] | DataMiner 10.3.0 [CU12]/10.4.3 | January 29, 2024. |
| [NATS configuration not updated after adding DMA to DMS](xref:KI_NATS_config_not_updated_after_adding_DMA) | All DataMiner versions | DataMiner 10.3.0 [CU12]/10.4.0 [CU0]/10.4.3 | January 24, 2024 |
| [Failover Agents remain offline after upgrade](xref:KI_Failover_Agents_offline_after_upgrade) | DataMiner 10.3.12 and 10.4.1<br>DataMiner 10.3.0 [CU9] and [CU10] | DataMiner 10.3.0 [CU11]/10.4.0/10.4.2 | January 22, 2024 |
| [NATS services missing after reboot](xref:KI_missing_NATS_services) | Any version | [Requires configuration](xref:KI_missing_NATS_services) | January 10, 2024 |
| [Cube freezes on 'Connected!' loading screen when no alarm tabs are displayed](xref:KI_Cube_connection_issue_alarm_tabs) | DataMiner 10.3.9 and 10.3.10 <br>Any versions from DataMiner 10.2.0 onwards using automatic client updates | DataMiner 10.2.0 [CU19]/10.3.0 [CU7]/10.3.11<br>Cube 10.3.11 | October 16, 2023 |
| [Various issues when using MessageBroker with chunking](xref:KI_DataMinerMessageBroker2)| 10.3.0 Main Release from 10.3.0 [CU5] onwards <br>DataMiner 10.3.8 up to 10.3.11 | DataMiner 10.4.0/10.4.1 | October 11, 2023 |
| [Offload to MySQL offload database fails](xref:KI_offload_database_incorrect_integer_value) | Any version | [Requires configuration](xref:KI_offload_database_incorrect_integer_value) | October 4, 2023 |
| [Elements not loading after upgrade of DMS with multiple Elasticsearch clusters](xref:KI_elements_not_loading_in_DMS_with_multiple_ES) | DataMiner 10.3.10 up to 10.4.1 | DataMiner 10.4.2 | October 3, 2023 |
| [SLNet deadlock in EPM setups](xref:KI_SLNet_Deadlock_EPM_Setups) | DataMiner 10.3.9 and 10.3.10 | DataMiner 10.3.11/10.4.0 | September 28, 2023 |
| [Max Payload exceptions occur when using MessageBroker with chunking](xref:KI_DataMinerMessageBroker_Chunking_MaxPayload)| DataMiner 10.3.5 [CU0]/10.3.8 up to 10.3.12 | DataMiner 10.4.0/10.4.1 | September 26, 2023 |
| [Cassandra backups no longer working](xref:KI_Cassandra_backups_not_working)| DataMiner 10.3.9 [CU0] | DataMiner 10.3.9 [CU1] | August 29, 2023 |
| [Default NATS port is already in use](xref:KI_NATS_port_9090) | From DataMiner 10.1.0/10.1.1 onwards | [Requires configuration](xref:KI_NATS_port_9090) | August 3, 2023 |
| [Unable to connect to DMS when using .NET Remoting](xref:KI_Unable_to_Connect_Net_Remoting) | DataMiner Cube 10.3.7 and 10.3.8 <br>Any versions from DataMiner 10.2.0 onwards using automatic client updates | DataMiner 10.3.9/10.4.0 | August 1, 2023 |
| [Various issues with a geo-redundant Cassandra setup with multiple data centers](xref:KI_Multiple_Datacenters_resolved_issues) | Cassandra Cluster setups | DataMiner 10.2.0 [CU18]/10.3.0 [CU6]/10.3.9<br>DataMiner 10.3.0 [CU7]/10.3.10<br>DataMiner 10.3.0 [CU8]/10.3.11| June 1, 2023 |
| [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node) | Cassandra Cluster setups | DataMiner 10.3.0 [CU7]/10.3.10 | June 1, 2023 |
| [Corrupted low-code app after concurrent editing actions](xref:KI_app_corruption_after_editing) | From DataMiner 10.2.5/10.3.0 onwards | DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 | May 26, 2023 |
| [Cassandra cluster data not offloaded while database is unavailable](xref:KI_Cassandra_cluster_data_not_offloaded) | Cassandra Cluster setups | DataMiner 10.2.0 [CU18]/10.3.0 [CU6]/10.3.9 | May 22, 2023 |
| [Inaccessible logger table data in Elasticsearch because of incorrect casing](xref:KI_Inaccessible_data_Elasticsearch_casing) | DataMiner 10.3.0 up to 10.3.0 [CU2]<br>DataMiner 10.3.3 up to 10.3.5. | DataMiner 10.3.0 [CU3]/10.3.6<br>[Requires configuration](xref:KI_Inaccessible_data_Elasticsearch_casing) | May 8, 2023 |
| [RTEs caused by problem during automatic NATS reconfiguration](xref:KI_RTEs_NATS_reconfiguration) | DataMiner 10.3.4 up to 10.3.8 | DataMiner 10.3.9 | May 5, 2023 |
| [Activities and scripts delayed because of CheckVIPs thread](xref:KI_CheckVIPs_delays_activities) | DataMiner 10.2.0 up to 10.2.0 [CU15]/10.3.0 [CU4]<br>DataMiner 10.1.12 up to 10.3.6 | DataMiner 10.2.0 [CU16]/10.3.0 [CU4]/10.3.7 | April 28, 2023 |
| [GenIf folder takes up too much disk space](xref:KI_GenIf_Folder_Growing_In_Size) | DataMiner 10.1.0 up to 10.3.0 [CU4]<br>DataMiner 10.0.13 up to 10.3.7 | DataMiner 10.3.0 [CU5]/10.3.8 | March 15, 2023 |
| [Problem with booking automation and function DVE deactivation](xref:KI_SRM_booking_events_issue) | SRM setups with DataMiner version below 10.3.0/10.3.2 | DataMiner 10.3.0/10.3.2 | March 10, 2023 |
| [SLPort deadlock when element with serial connection is restarted](xref:KI_SLPort_deadlock_after_restart_serial_connection) | DataMiner 10.1.0 [CU17] up to 10.2.0 [CU11]/10.3.0.0 - 12752<br>DataMiner 10.2.8 up to 10.3.3 | DataMiner 10.2.0 [CU12]/10.3.0.0 - 12790/10.3.3 [CU1] | February 28, 2023 |
| [Local user unable to access DMA after first reboot after installation](xref:KI_Local_user_unable_to_access_DMA_after_first_reboot_after_installation) | DataMiner 10.3.3 | DataMiner 10.4.0 [CU4]/10.4.7 | February 24, 2023 |
| [Node: 'X' is not supported by the current server version](xref:KI_Node_is_not_supported_by_the_current_server_version) | DataMiner 10.3.2 | DataMiner 10.3.2 [CU1]/10.3.3 | January 26, 2023 |
| [Contents of state_changes table not migrated after Cassandra Cluster migration](xref:KI_Contents_of_State_changes_Table_not_Migrated_after_Cassandra_Cluster_Migration) | Cassandra Cluster setups | DataMiner 10.3.0 [CU3]/10.2.0 [CU15]/10.3.4 | January 16, 2023 |
| [Cassandra cluster node in unexpected state](xref:KI_Cassandra_cluster_node_unexpected_state) | Cassandra Cluster setups | [Requires configuration](xref:KI_Cassandra_cluster_node_unexpected_state) | January 10, 2023 |
| [Year 2038 problem for Cassandra](xref:Year_2038_Problem_for_Cassandra) | All DataMiner versions with a Cassandra setup<br>prior to DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | January 10, 2023 |
| [Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details](xref:KI_NullReferenceException_SLDBConnection) | DataMiner 10.1.0 up to 10.2.0 [CU10]<br>DataMiner 10.1.2 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.0/10.3.2 | December 20, 2022 |
| [SLProtocol timer thread run-time error](xref:KI_SLProtocol_timer_thread_RTE) | DataMiner versions prior to 10.2.0 [CU10]/10.3.1 | DataMiner 10.2.0 [CU10]/10.3.1 | December 20, 2022 |
| [Vertical text in Visual Overview not displayed correctly](xref:KI_Visual_Overview_Vertical_Text_no_longer_working) | DataMiner 10.2.0 [CU3]/10.2.3 up to 10.3.0 [CU4]/10.3.7 | DataMiner 10.3.0 [CU5]/10.3.8 | December 16, 2022 |
| [SLNet deadlock on DMA startup](xref:KI_SLNet_deadlock_on_startup) | DataMiner 10.1.0 up to 10.2.0 [CU15]/10.3.0 [CU3]<br>DataMiner 10.1.2 up to 10.3.2 | DataMiner 10.2.0 [CU16]/10.3.0 [CU3]/10.3.3 | December 14, 2022 |
| [Stable trend points not kept alive](xref:KI_stable_trend_points_not_kept_alive) | DataMiner 10.2.0 [CU8] up to 10.2.0 [CU10]<br>DataMiner 10.2.10 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.2 | December 9, 2022 |
| [Missing 1-day average trending records](xref:KI_missing_avg_trending) | DataMiner 10.2.0 [CU0] up to 10.2.0 [CU10]<br>DataMiner 10.1.10 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.2 | December 9, 2022 |
| [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput) | DataMiner 10.1.0 and 10.2.0 (up to [CU10])<br>From DataMiner 10.0.2 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.0/10.3.2 | December 8, 2022 |
| [Various SLElement issues](xref:KI_SLElement_various_issues) | See [detailed page](xref:KI_SLElement_various_issues). | See [detailed page](xref:KI_SLElement_various_issues). | November 25, 2022 |
| [Element data lost after migrating elements in Cassandra Cluster setup](xref:KI_element_data_loss_after_migration_in_CC_setup) | DataMiner 10.1.0 up to 10.2.0 [CU11]<br>DataMiner 10.0.11 up to 10.3.1 | DataMiner 10.2.0 [CU12]/10.3.2 | November 15, 2022 |
| [Excessive SLElement CPU usage during Cassandra Cluster migration](xref:KI_SLElement_CPU_high_during_CC_migration) | DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0 | DataMiner 10.2.0 [CU10]/10.3.1 | October 28, 2022 |
| [SLElement memory leak during Cassandra Cluster migration](xref:KI_SLElement_CPU_memory_leak_during_CC_migration) | DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0. | DataMiner 10.2.0 [CU10]/10.3.1 | October 28, 2022 |
| [Data from Elasticsearch cluster with IPv6 addresses offloaded to files](xref:KI_Elasticsearch_IPv6) | Any version prior to DataMiner 10.2.0 [CU11]/10.3.2 with Elasticsearch cluster using IPv6 addresses | DataMiner 10.2.0 [CU11]/10.3.2 | October 21, 2022 |

## 10.2.x

| Issue | Affected versions | Resolved in | Date added |
|--|--|--|--|
| [Sticky element alarm state caused by correlation rules](xref:KI_sticky_element_alarm_state_caused_by_correlation_rules) | From DataMiner 10.2.0 onwards | | October 25, 2024 |
| [Unable to override information events TTL of 5 years](xref:KI_Information_events_TTL_five_years) | Cassandra Cluster setups | | July 24, 2024 |
| [Problem after removing DMA from cluster](xref:KI_Problem_after_removing_DMA_from_cluster) | Any DataMiner version with clustered storage <br>and/or indexing | | December 15, 2023 |
| [Elasticsearch not initialized when DataMiner starts up](xref:KI_Elasticsearch_not_initialized_on_DMA_startup) | Any version using Elasticsearch | | April 20, 2023 |
| [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars) | From DataMiner 10.1.0/10.1.2 <br>onwards | | November 8, 2022 |
| [Upgrade fails because of VerifyClusterPort.dll prerequisite](xref:KI_Upgrade_fails_VerifyClusterPorts_prerequisite) | From DataMiner 10.2.0 [CU1] and 10.2.4 onwards | | September 2, 2022 |
| [nats-server.config file not included in DataMiner backups](xref:KI_nats-server_config_file_not_included_in_backups) | From DataMiner 10.2.0 [CU6]/10.2.8 onwards | DataMiner 10.4.11/10.5.0 | October 10, 2024 |
| [ButtonState shapes in Visual Overview fail to hide as expected](xref:KI_ButtonState_shapes_in_Visual_Overview_fail_to_hide_as_expected) | DataMiner Cube versions prior to 10.4.2425.2536<br>DataMiner 10.4.8, if Cube client does not have internet access | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | August 13, 2024 |
| [Timetrace data is no longer written during Cassandra Cluster migration](xref:KI_Timetrace_Data_no_longer_written_during_Cassandra_Cluster_Migration) | Cassandra Cluster setups | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | February 29, 2024 |
| [Port exhaustion because of NATS reconnection attempts](xref:KI_port_exhaustion_because_of_NATS_reconnect_attempts) | Any DataMiner version | DataMiner 10.4.6/10.5.0 | February 2, 2024 |
| [One or multiple Analytics features fail to start](xref:KI_Analytics_features_not_starting) | DataMiner 10.3.5 up to 10.4.2<br>10.2.0 Main Release from DataMiner 10.2.0 [CU13] onwards<br>DataMiner 10.3.0 [CU2] up to [CU11] | DataMiner 10.3.0 [CU12]/10.4.3 | January 29, 2024. |
| [NATS configuration not updated after adding DMA to DMS](xref:KI_NATS_config_not_updated_after_adding_DMA) | All DataMiner versions | DataMiner 10.3.0 [CU12]/10.4.0 [CU0]/10.4.3 | January 24, 2024 |
| [NATS services missing after reboot](xref:KI_missing_NATS_services) | Any version | [Requires configuration](xref:KI_missing_NATS_services) | January 10, 2024 |
| [Cube freezes on 'Connected!' loading screen when no alarm tabs are displayed](xref:KI_Cube_connection_issue_alarm_tabs) | Any versions from DataMiner 10.2.0 onwards using automatic client updates | DataMiner 10.2.0 [CU19]/10.3.0 [CU7]/10.3.11<br>Cube 10.3.11 | October 16, 2023 |
| [Offload to MySQL offload database fails](xref:KI_offload_database_incorrect_integer_value) | Any version | [Requires configuration](xref:KI_offload_database_incorrect_integer_value) | October 4, 2023 |
| [Default NATS port is already in use](xref:KI_NATS_port_9090) | From DataMiner 10.1.0/10.1.1 onwards | [Requires configuration](xref:KI_NATS_port_9090) | August 3, 2023 |
| [Unable to connect to DMS when using .NET Remoting](xref:KI_Unable_to_Connect_Net_Remoting) | Any versions from DataMiner 10.2.0 onwards using automatic client updates | DataMiner 10.3.9/10.4.0 | August 1, 2023 |
| [RTEs caused by problem when updating alarm templates](xref:KI_RTEs_Alarm_Template_Issue) | DataMiner 10.2.0 [CU15], [CU16], and [CU17] | DataMiner 10.2.0 [CU18] | July 31, 2023 |
| [Various issues with a geo-redundant Cassandra setup with multiple data centers](xref:KI_Multiple_Datacenters_resolved_issues) | Cassandra Cluster setups | DataMiner 10.2.0 [CU18]/10.3.0 [CU6]/10.3.9<br>DataMiner 10.3.0 [CU7]/10.3.10<br>DataMiner 10.3.0 [CU8]/10.3.11| June 1, 2023 |
| [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node) | Cassandra Cluster setups | DataMiner 10.3.0 [CU7]/10.3.10 | June 1, 2023 |
| [Corrupted low-code app after concurrent editing actions](xref:KI_app_corruption_after_editing) | From DataMiner 10.2.5/10.3.0 onwards | DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 | May 26, 2023 |
| [Cassandra cluster data not offloaded while database is unavailable](xref:KI_Cassandra_cluster_data_not_offloaded) | Cassandra Cluster setups | DataMiner 10.2.0 [CU18]/10.3.0 [CU6]/10.3.9 | May 22, 2023 |
| [Activities and scripts delayed because of CheckVIPs thread](xref:KI_CheckVIPs_delays_activities) | DataMiner 10.2.0 up to 10.2.0 [CU15]/10.3.0 [CU4]<br>DataMiner 10.1.12 up to 10.3.6 | DataMiner 10.2.0 [CU16]/10.3.0 [CU4]/10.3.7 | April 28, 2023 |
| [GenIf folder takes up too much disk space](xref:KI_GenIf_Folder_Growing_In_Size) | From DataMiner 10.1.0/10.0.13 onwards | DataMiner 10.3.0 [CU5]/10.3.8 | March 15, 2023 |
| [Problem with booking automation and function DVE deactivation](xref:KI_SRM_booking_events_issue) | SRM setups with DataMiner version below 10.3.0/10.3.2 | DataMiner 10.3.0/10.3.2 | March 10, 2023 |
| [SLPort deadlock when element with serial connection is restarted](xref:KI_SLPort_deadlock_after_restart_serial_connection) | DataMiner 10.1.0 [CU17] up to 10.2.0 [CU11]/10.3.0.0 - 12752<br>DataMiner 10.2.8 up to 10.3.3 | DataMiner 10.2.0 [CU12]/10.3.0.0 - 12790/10.3.3 [CU1] | February 28, 2023 |
| [Contents of state_changes table not migrated after Cassandra Cluster migration](xref:KI_Contents_of_State_changes_Table_not_Migrated_after_Cassandra_Cluster_Migration) | Cassandra Cluster setups | DataMiner 10.3.0 [CU3]/10.2.0 [CU15]/10.3.4 | January 16, 2023 |
| [Cassandra cluster node in unexpected state](xref:KI_Cassandra_cluster_node_unexpected_state) | Cassandra Cluster setups | [Requires configuration](xref:KI_Cassandra_cluster_node_unexpected_state) | January 10,2023 |
| [Year 2038 problem for Cassandra](xref:Year_2038_Problem_for_Cassandra) | All DataMiner versions with a Cassandra setup<br>prior to DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | January 10, 2023 |
| [Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details](xref:KI_NullReferenceException_SLDBConnection) | DataMiner 10.1.0 up to 10.2.0 [CU10]<br>DataMiner 10.1.2 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.0/10.3.2 | December 20,2022 |
| [SLProtocol timer thread run-time error](xref:KI_SLProtocol_timer_thread_RTE) | DataMiner versions prior to 10.2.0 [CU10]/10.3.1 | DataMiner 10.2.0 [CU10]/10.3.1 | December 20, 2022 |
| [Vertical text in Visual Overview not displayed correctly](xref:KI_Visual_Overview_Vertical_Text_no_longer_working) | DataMiner 10.2.0 [CU3]/10.2.3 up to 10.3.0 [CU4]/10.3.7 | DataMiner 10.3.0 [CU5]/10.3.8 | December 16, 2022 |
| [SLNet deadlock on DMA startup](xref:KI_SLNet_deadlock_on_startup) | DataMiner 10.1.0 up to 10.2.0 [CU15]/10.3.0 [CU3]<br>DataMiner 10.1.2 up to 10.3.2 | DataMiner 10.2.0 [CU16]/10.3.0 [CU3]/10.3.3 | December 14, 2022 |
| [Stable trend points not kept alive](xref:KI_stable_trend_points_not_kept_alive) | DataMiner 10.2.0 [CU8] up to 10.2.0 [CU10]<br>DataMiner 10.2.10 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.2 | December 9, 2022 |
| [Missing 1-day average trending records](xref:KI_missing_avg_trending) | DataMiner 10.2.0 [CU0] up to 10.2.0 [CU10]<br>DataMiner 10.1.10 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.2 | December 9, 2022 |
| [Memory leak in SLNet threads](xref:KI_SLNet_thread_leak) | DataMiner 10.2.12 [CU0] and [CU1] | DataMiner 10.2.12 [CU2]/10.3.1 | December 9, 2022 |
| [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput) | DataMiner 10.1.0 and 10.2.0 (up to [CU10])<br>From DataMiner 10.0.2 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.0/10.3.2 | December 8, 2022 |
| [SLNet issues due to SPI obfuscation](xref:KI_SLNet_issue_SPI_obfuscation) | DataMiner 10.2.0 [CU3] up to 10.2.0 [CU5]<br>DataMiner 10.2.6 up to 10.2.8 | DataMiner 10.2.0 [CU6]/10.2.9 | December 7, 2022 |
| [Various SLElement issues](xref:KI_SLElement_various_issues) | See [detailed page](xref:KI_SLElement_various_issues). | See [detailed page](xref:KI_SLElement_various_issues). | November 25, 2022 |
| [SLLog issue when large alarm tree is closed](xref:KI_SLLog_issue_when_large_alarm_tree_is_closed) | DataMiner 10.2.0 [CU8] and [CU9]<br>DataMiner 10.2.11 and 10.2.12 | DataMiner 10.2.0 [CU10]/10.3.1 | November 16, 2022 |
| [Element data lost after migrating elements in Cassandra Cluster setup](xref:KI_element_data_loss_after_migration_in_CC_setup) | DataMiner 10.1.0 up to 10.2.0 [CU11]<br>DataMiner 10.0.11 up to 10.3.1 | DataMiner 10.2.0 [CU12]/10.3.2 | November 15, 2022 |
| [Multiple issues when Failover based on hostnames is used](xref:KI_Failover_with_hostnames) | DataMiner 10.2.0/10.1.8 up to 10.3.0 [CU10]/10.4.1 | DataMiner 10.3.0 [CU11]/10.4.2 | November 15, 2022 |
| [SLDataGateway memory leak during Cassandra Cluster migration](xref:KI_SLDataGateway_leak_during_CC_migration) | DataMiner 10.1.0 prior to [CU22]<br>DataMiner 10.2.0 prior to [CU10]<br>DataMiner 10.1.2 up to 10.2.12 | DataMiner 10.1.0 [CU22]/10.2.0 [CU10]/10.3.1 | November 3, 2022 |
| [Excessive SLElement CPU usage during Cassandra Cluster migration](xref:KI_SLElement_CPU_high_during_CC_migration) | DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0 | DataMiner 10.2.0 [CU10]/10.3.1 | October 28, 2022 |
| [SLElement memory leak during Cassandra Cluster migration](xref:KI_SLElement_CPU_memory_leak_during_CC_migration) | DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0 | DataMiner 10.2.0 [CU10]/10.3.1 | October 28, 2022 |
| [SLProtocol memory leak when HTTP connectors are used](xref:KI_SLProtocol_memory_leak_HTTP) | DataMiner 10.1.0 [CU19], 10.2.0 <br>[CU7], and 10.2.8 up to 10.2.11 | DataMiner 10.1.0 [CU20]/10.2.0 [CU8]/10.2.11 [CU1] | October 26, 2022 |
| [Data from Elasticsearch cluster with IPv6 addresses offloaded to files](xref:KI_Elasticsearch_IPv6) | Any version prior to DataMiner 10.2.0 [CU11]/10.3.2 with Elasticsearch cluster using IPv6 addresses | DataMiner 10.2.0 [CU11]/10.3.2 | October 21, 2022 |
| [Increased CPU load and degraded performance because of excessive number of SPI events](xref:Excessive_SPI_events_causing_CPU_load) | 10.2 Main and Feature Release <br>versions prior to 10.2.0 [CU6]<br> and 10.2.9. | DataMiner 10.2.0 [CU6]/10.2.9 | October 19, 2022 |
| [SLDataGateway memory leak](xref:KI_SLDataGateway_memory_leak) | Cassandra Cluster setups<br>prior to 10.2.0 [CU8]/10.2.11 | DataMiner 10.2.0 [CU8]/10.2.11 | October 10, 2022 |
| [Taskbar Utility performance issue while agents are being upgraded](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded) | 10.1.0 [CU19] and 10.2.0 [CU7]<br>10.2.10 | DataMiner 10.1.0 [CU20]/10.2.0 [CU8]/10.2.11 | September 23, 2022 |
| [SLDMS Hosting Agent cache issue](xref:KI_SLDMS_hosting_agent_cache_issue) | DataMiner 10.2 Main & Feature Release prior to 10.2.0 [CU7] and 10.2.10 | DataMiner 10.2.0 [CU7]/10.2.10 | September 15, 2022 |
| [Closed alarms migrated too slowly from dms-activealarms index in Elasticsearch database](xref:KI_Closed_alarms_migrated_too_slowly) | Versions using Elasticsearch<br>for alarm indexing prior to<br>10.2.0 [CU8] and 10.2.11 | DataMiner 10.2.0 [CU8]/10.2.11 | September 14, 2022 |
| [SNMP polling issues in case protocol contains wildcards in parameter OIDs](xref:KI_SNMP_polling_issues_with_wildcards_in_param_OIDs) |DataMiner 10.2.0 [CU6]/10.2.9 | DataMiner 10.2.0.0 - 12184 [CU6]/10.2.9 [CU1] | September 6, 2022 |
| [SLAnalytics RTEs after upgrading DMS with Cassandra Cluster](xref:KI_RTE_with_SLAnalytics_when_upgrading) | DataMiner 10.2.8 [CU1] | DataMiner 10.2.8 [CU2] | August 8, 2022 |

## Other

| Issue | Affected versions | Resolved in | Date added |
|--|--|--|--|
| [Unable to override information events TTL of 5 years](xref:KI_Information_events_TTL_five_years) | Cassandra Cluster setups | | July 24, 2024 |
| [Problem after removing DMA from cluster](xref:KI_Problem_after_removing_DMA_from_cluster) | Any DataMiner version with clustered storage <br>and/or indexing | | December 15, 2023 |
| [IP address in SAN field of TLS certificate ignored in Windows 2012 R2](xref:KI_Win2012R2_ignores_IP_in_SAN_field) | Systems using Windows 2012 R2 | | March 20, 2023 |
| [NATS not starting if DMS name contains special characters](xref:KI_NATS_not_starting_special_chars) | From DataMiner 10.1.0/10.1.2 <br>onwards | | November 8, 2022 |
| [Migration of Ticketing data from Cassandra to Elasticsearch fails](xref:KI_Migration_of_Ticketing_data_from_Cassandra_to_Elasticsearch_fails) | From DataMiner 10.1.0/10.0.13 onwards | | - |
| [DataMiner Cube freeze on startup](xref:KI_DataMiner_Cube_freeze_on_startup) | N/A | | - |
| [Setting a protocol to production takes a long time](xref:KI_Setting_a_protocol_to_production_takes_a_long_time) | N/A | | - |
| [Problem after upgrading Window OS to Windows Server 2022](xref:KI_Problem_after_OS_upgrade_to_win_2022) | Systems that have recently been upgraded to Windows Server 2022 | [Requires configuration](xref:KI_Problem_after_OS_upgrade_to_win_2022) | October 11, 2024 |
| [ButtonState shapes in Visual Overview fail to hide as expected](xref:KI_ButtonState_shapes_in_Visual_Overview_fail_to_hide_as_expected) | DataMiner Cube versions prior to 10.4.2425.2536<br>DataMiner 10.4.8, if Cube client does not have internet access | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | August 13, 2024 |
| [Timetrace data is no longer written during Cassandra Cluster migration](xref:KI_Timetrace_Data_no_longer_written_during_Cassandra_Cluster_Migration) | Cassandra Cluster setups | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 | February 29, 2024 |
| [Port exhaustion because of NATS reconnection attempts](xref:KI_port_exhaustion_because_of_NATS_reconnect_attempts) | Any DataMiner version | DataMiner 10.4.6/10.5.0 | February 2, 2024 |
| [NATS configuration not updated after adding DMA to DMS](xref:KI_NATS_config_not_updated_after_adding_DMA) | All DataMiner versions | DataMiner 10.3.0 [CU12]/10.4.0 [CU0]/10.4.3 | January 24, 2024 |
| [NATS services missing after reboot](xref:KI_missing_NATS_services) | Any version | [Requires configuration](xref:KI_missing_NATS_services) | January 10, 2024 |
| [Offload to MySQL offload database fails](xref:KI_offload_database_incorrect_integer_value) | Any version | [Requires configuration](xref:KI_offload_database_incorrect_integer_value) | October 4, 2023 |
| [Default NATS port is already in use](xref:KI_NATS_port_9090) | From DataMiner 10.1.0/10.1.1 onwards | [Requires configuration](xref:KI_NATS_port_9090) | August 3, 2023 |
| [Various issues with a geo-redundant Cassandra setup with multiple data centers](xref:KI_Multiple_Datacenters_resolved_issues) | Cassandra Cluster setups | DataMiner 10.2.0 [CU18]/10.3.0 [CU6]/10.3.9<br>DataMiner 10.3.0 [CU7]/10.3.10<br>DataMiner 10.3.0 [CU8]/10.3.11| June 1, 2023 |
| [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node) | Cassandra Cluster setups | DataMiner 10.3.0 [CU7]/10.3.10 | June 1, 2023 |
| [SRM - Auto Select Resource not read for silent booking](xref:KI_SRM_Auto_Select_Resource_Not_Read) | SRM 1.2.30 [CU2] | SRM 1.2.30 [CU3] | March 29, 2023 |
| [GenIf folder takes up too much disk space](xref:KI_GenIf_Folder_Growing_In_Size) | From DataMiner 10.1.0/10.0.13 onwards | DataMiner 10.3.0 [CU5]/10.3.8 | March 15, 2023 |
| [SLPort deadlock when element with serial connection is restarted](xref:KI_SLPort_deadlock_after_restart_serial_connection) | DataMiner 10.1.0 [CU17] up to 10.2.0 [CU11]/10.3.0.0 - 12752<br>DataMiner 10.2.8 up to 10.3.3 | DataMiner 10.2.0 [CU12], 10.3.0.0 - 12790/10.3.3 [CU1] | February 28, 2023 |
| [Year 2038 problem for Cassandra](xref:Year_2038_Problem_for_Cassandra) | All DataMiner versions with a Cassandra setup<br>prior to DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 | January 10, 2023 |
| [Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details](xref:KI_NullReferenceException_SLDBConnection) | DataMiner 10.1.0 up to 10.2.0 [CU10]<br>DataMiner 10.1.2 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.0/10.3.2 | December 20,2022 |
| [SLNet deadlock on DMA startup](xref:KI_SLNet_deadlock_on_startup) | DataMiner 10.1.0 up to 10.2.0 [CU15]/10.3.0 [CU3]<br>DataMiner 10.1.2 up to 10.3.2 | DataMiner 10.2.0 [CU16]/10.3.0 [CU3]/10.3.3 | December 14, 2022 |
| [Missing 1-day average trending records](xref:KI_missing_avg_trending) | DataMiner 10.2.0 [CU0] up to 10.2.0 [CU10]<br>DataMiner 10.1.10 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.2 | December 9, 2022 |
| [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput) | DataMiner 10.1.0 and 10.2.0 (up to [CU10])<br>From DataMiner 10.0.2 up to 10.3.1 | DataMiner 10.2.0 [CU11]/10.3.0/10.3.2 | December 8, 2022 |
| [Various SLElement issues](xref:KI_SLElement_various_issues) | See [detailed page](xref:KI_SLElement_various_issues). | See [detailed page](xref:KI_SLElement_various_issues). | November 25, 2022 |
| [Element data lost after migrating elements in Cassandra Cluster setup](xref:KI_element_data_loss_after_migration_in_CC_setup) | DataMiner 10.1.0 up to 10.2.0 [CU11]<br>DataMiner 10.0.11 up to 10.3.1 | DataMiner 10.2.0 [CU12]/10.3.2 | November 15, 2022 |
| [Multiple issues when Failover based on hostnames is used](xref:KI_Failover_with_hostnames) | DataMiner 10.2.0/10.1.8 up to 10.3.0 [CU10]/10.4.1 | DataMiner 10.3.0 [CU11]/10.4.2 | November 15, 2022 |
| [SLDataGateway memory leak during Cassandra Cluster migration](xref:KI_SLDataGateway_leak_during_CC_migration) | DataMiner 10.1.0 prior to [CU22]<br>DataMiner 10.2.0 prior to [CU10]<br>DataMiner 10.1.2 up to 10.2.12 |DataMiner  10.1.0 [CU22]/10.2.0 [CU10]/10.3.1 | November 3, 2022 |
| [Excessive SLElement CPU usage during Cassandra Cluster migration](xref:KI_SLElement_CPU_high_during_CC_migration) | DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0. | DataMiner 10.2.0 [CU10]/10.3.1 | October 28, 2022 |
| [SLElement memory leak during Cassandra Cluster migration](xref:KI_SLElement_CPU_memory_leak_during_CC_migration) | DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0 | DataMiner 10.2.0 [CU10]/10.3.1 | October 28, 2022 |
| [SLProtocol memory leak when HTTP connectors are used](xref:KI_SLProtocol_memory_leak_HTTP) | DataMiner 10.1.0 [CU19], 10.2.0 <br>[CU7], and 10.2.8 up to 10.2.11 | DataMiner 10.1.0 [CU20]/10.2.0 [CU8]/10.2.11 [CU1] | October 26, 2022 |
| [Increased CPU load and degraded performance because of excessive number of SPI events](xref:Excessive_SPI_events_causing_CPU_load) | DataMiner 10.2 Main and Feature Release <br>versions prior to 10.2.0 [CU6]<br> and 10.2.9. | DataMiner 10.2.0 [CU6]/10.2.9 | October 19, 2022 |
| [SLDataGateway memory leak](xref:KI_SLDataGateway_memory_leak) | Cassandra Cluster setups<br>prior to 10.2.0 [CU8]/10.2.11 | DataMiner 10.2.0 [CU8]/10.2.11 | October 10, 2022 |
| [Taskbar Utility performance issue while agents are being upgraded](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded) | DataMiner 10.1.0 [CU19] and 10.2.0 [CU7]<br>10.2.10 | DataMiner 10.1.0 [CU20]/10.2.0 [CU8]/10.2.11 | September 23, 2022 |
| [SLDMS Hosting Agent cache issue](xref:KI_SLDMS_hosting_agent_cache_issue) | DataMiner 10.2 Main & Feature Release<br>prior to 10.2.0 [CU7] and 10.2.10 | DataMiner 10.2.0 [CU7]/10.2.10 | September 15, 2022 |
| [Closed alarms migrated too slowly from dms-activealarms index in Elasticsearch database](xref:KI_Closed_alarms_migrated_too_slowly) | Versions using Elasticsearch<br>for alarm indexing prior to<br>10.2.0 [CU8] and 10.2.11 | DataMiner 10.2.0 [CU8]/10.2.11 | September 14, 2022 |
| [Cassandra nodes not configured if current DMA IP is assigned as virtual IP](xref:KI_Cassandra_nodes_not_configured_if_current_DMA_IP_is_assigned_as_virtual_IP) | DataMiner 10.1.0 [CU1]/10.1.1 up to 10.1.0 [CU5]/10.1.9 | DataMiner 10.1.0 [CU6]/10.1.9 | - |
| [NATS error message after 10.1 installation](xref:KI_NATS_error_message_after_10_1_installation) | From DataMiner 10.1 onwards | [Requires configuration](xref:KI_NATS_error_message_after_10_1_installation) | - |
| [Shapes in DataMiner stencils not found in Visio search](xref:KI_Shapes_in_DataMiner_stencils_not_found_in_Visio_search) | N/A | [Requires configuration](xref:KI_Shapes_in_DataMiner_stencils_not_found_in_Visio_search) | - |
| [SLDataMiner addressChangeThread RTE after DMA startup](xref:KI_SLDataMiner_addressChangeThread_RTE_after_DMA_startup) | N/A | [Requires configuration](xref:KI_SLDataMiner_addressChangeThread_RTE_after_DMA_startup) | - |
| [SNMP SET returns a 'NO ACCESS' error](xref:KI_SNMP_SET_returns_a_NO_ACCESS_error) | N/A | [Requires configuration](xref:KI_SNMP_SET_returns_a_NO_ACCESS_error) | - |
| [Unavailable system database after DataMiner server reboot](xref:KI_Unavailable_system_database_after_DataMiner_server_reboot) | N/A | [Requires configuration](xref:KI_Unavailable_system_database_after_DataMiner_server_reboot) | - |
| [Upgrade error: api-ms-win-crt-stdio-l1-1-0.dll is missing](xref:KI_Upgrade_error_api-ms-win-crt-stdio-l1-1-0_dll_is_missing) | N/A | [Requires configuration](xref:KI_Upgrade_error_api-ms-win-crt-stdio-l1-1-0_dll_is_missing) | - |
