---
uid: dataminer_metrics
---

# DataMiner metrics

The metrics provided below are provided as a guide to help dimension DataMiner platforms. They are split into two sections, **Limits** and
**Benchmarks**.

- The limits section is designed to show absolute upper limits for DataMiner Agents and systems. Undesired operation or performance issues caused by exceeding the limits specified may not be covered by your support agreement and result in extra charges.
- The benchmarks show tested performance and load specifications as a guide. They are in no way guaranteed.

> [!NOTE]
>
> - Take care when combining metrics. For example, it is impossible to run 1000 regular elements next to 100,000 EPM (formerly CPE) devices on a single DMA.
> - The metrics are specified by DMA and DMS. DMA being a single DataMiner node and DMS referring to the whole clustered system.

All specifications are provided based on the assumption that DMAs are running on servers that comply with the [DataMiner compute requirements](xref:DataMiner_Compute_Requirements).

## Limits

| \# | Specification | Scope | Maximum | Remarks |
| -- | ------------- | ----- | ------- | ------- |
| 1 | Number of elements | DMA | 5 - 1,000 | Depending on the license<br>(highest license is 1,000) |
| 2 | Number of elements | DMS | 25,000 ||
| 3 | Number of standard services | DMS | 10,000 ||         
| 4 | Number of enhanced services | DMA | 5 - 1,000 ||
| 5 | Number of enhanced services | DMS | 10,000 ||
| 6 | Number of SLAs | DMA | 5 - 1,000 ||
| 7 | Number of SLAs | DMS | 10,000 ||
| 8 | Number of concurrent active alarms | DMS<br>DataMiner Cube | 10,000 | DataMiner Cube will enter protection mode when the number of alarms increases above this limit. In protection mode, the system will remain fully functional. However, not all active alarms will be pushed to the client.<br>Note: This setting is configurable. 10,000 is the recommended default value. |
| 9 | Number of concurrent active alarms | DMA | 25,000 ||
| 10 | Number of SNMP traps per second received on a DMA continuously | DMA | 400 ||
| 11 | Number of SNMP traps per second received on a DMA in burst mode | DMA | 1,000 ||
| 12 | Number of DVEs | DMA | 2,000 - 10,000 | Depending on the type of device. |
| 13 | Number of EPM (formerly CPE) devices | DMA | 100,000 | Based on a 15-minute update cycle. |
| 14 | Number of views | DMS | 8,000 ||
| 15 | Number of parameters | DMA | 25,000,000 | Based on a 15-minute update cycle.<br>Note: This figure supersedes metric 13 above (i.e. number of EPM devices) |
| 16 | Number of configured users | DMS | 1,000 ||
| 17 | Number of online users | DMS | 100 | Assuming common user behavior. |
| 18 | Switch frequency | DataMiner Failover | 1 switch every 15 minutes ||
| 19 | Number of concurrent active tickets | DMS | 10,000 ||
| 20 | Number of alarm properties (usable in alarm search filters) of all types (view, element or service) | DMS | 50 | When adding for example, an element with alarm filterable properties to multiple services, this can lead to a heavy load on the DMS during alarm storm situations. Please consider your configuration carefully. |

## Benchmarks

- [Alarm benchmarks](xref:alarm_benchmarks)
- [Alarm focus benchmarks](xref:alarm_focus_benchmarks)
- [Automatic incident tracking benchmarks](xref:automatic_incident_tracking_benchmarks)
- [Automation benchmarks](xref:automation_benchmarks)
- [Behavioral anomaly detection benchmarks](xref:behavioral_anomaly_detection_benchmarks)
- [Cassandra write performance benchmarks](xref:cassandra_write_performance_benchmarks)
- [Change history metrics](xref:change_history_benchmarks)
- [Dashboards benchmarks](xref:dashboards_benchmarks)
- [DataMiner Object Model benchmarks](xref:dataminer_object_model_benchmarks)
- [dataminer.services benchmarks](xref:cloud_benchmarks)
- [Direct view benchmarks](xref:direct_view_benchmarks)
- [Dynamic virtual element benchmarks](xref:dynamic_virtual_element_benchmarks)
- [Element benchmarks](xref:element_benchmarks)
- [Failover benchmarks](xref:failover_benchmarks)
- [History set benchmarks](xref:history_set_benchmarks)
- [Mobile Gateway benchmarks](xref:mobile_gateway_benchmarks)
- [NATS benchmarks](xref:nats_benchmarks)
- [Parameter set benchmarks](xref:parameter_set_benchmarks)
- [Pattern matching benchmarks](xref:pattern_matching_benchmarks)
- [Profile Manager benchmarks](xref:profile_manager_benchmarks)
- [Resources benchmarks](xref:resources_benchmarks)
- [Service benchmarks](xref:service_benchmarks)
- [Service profile benchmarks](xref:service_profile_benchmarks)
- [Service & Resource Management benchmarks](xref:service_resource_management_benchmarks)
- [User-Defined APIs benchmarks](xref:user-defined_API_benchmarks)
- [View benchmarks](xref:view_benchmarks)
- [Visual Overview benchmarks](xref:visual_overview_benchmarks)
