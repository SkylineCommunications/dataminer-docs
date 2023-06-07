---
uid: KI_SLElement_various_resolved_issues
---

# Various resolved SLElement issues

A number of issues could lead to SLElement problems, which could cause a memory leak or an unexpected DMA restart. Below you can find an overview of these issues.

| Issue | Affected versions | Workaround | Fix |
|--|--|--|--|
| When a parameter set was processed while an element was started at the exact same time, this could cause a problem in SLElement. <!-- RN 34899 --> | Main release versions prior to DataMiner 10.2.0 [CU10]/10.3.0.<br>Feature release versions prior to DataMiner 10.3.1. | N/A | Install DataMiner 10.2.0 [CU10], 10.3.0, or 10.3.1. |
| When a DVE or virtual function was started, a problem in SLElement could occur in case the table used to generate the DVE contained a column with the option "severity", or the protocol of the main element contained a tree view, topology exposers, RCA, parameter groups with dynamic ID, alarm property configuration, or advanced naming/naming format. <!-- RN 34861 --> | Main release versions prior to DataMiner 10.2.0 [CU10]/10.3.0.<br>Feature release versions prior to DataMiner 10.3.1. | N/A | Install DataMiner 10.2.0 [CU10], 10.3.0, or 10.3.1. |
| When a trend template was assigned, an access violation could cause a problem in SLElement. <!-- RN 34824 --> | Main release versions prior to DataMiner 10.3.0.<br>Feature release versions prior to DataMiner 10.3.1. | N/A | Install DataMiner 10.3.0 or 10.3.1. |
| When an alarm template was assigned or unassigned to an element while an alarm update happened at the exact same time, this could cause a problem in SLElement. <!-- RN 34813 --> | Main release versions prior to DataMiner 10.3.0.<br>Feature release versions prior to DataMiner 10.3.1. | N/A | Install DataMiner 10.3.0 or 10.3.1. |
| When filtered subscriptions were open on a table where rows were deleted, this could cause a problem in SLElement. <!-- RN 34578 --> | Main release versions prior to DataMiner 10.1.0 [CU21]/10.2.0 [CU9].<br>Feature release versions prior to DataMiner 10.2.12. | N/A | Install DataMiner 10.1.0 [CU21], 10.2.0 [CU9] or 10.2.12 |
| When an invalid timestamp was used on a monitored parameter that was processing history sets, a problem could occur in SLElement when it tried to send the alarm over NATS <!-- RN 33774/34378 --> | DataMiner 10.1.5 up to 10.2.7.<br>DataMiner 10.2.0 [CU0] up to [CU7]. | N/A | Install DataMiner 10.2.0 [CU8] or 10.2.8 |
| When a table was updated that contained parameters used in advanced naming/naming format, a problem could occur in SLElement. <!-- RN 34135 --> | DataMiner 10.1.0 [CU16] and [CU17].<br>DataMiner 10.2.0 [CU4] and [CU5].<br>DataMiner 10.2.7 and 10.2.8. | N/A | Install DataMiner 10.1.0 [CU18], 10.2.0 [CU6], or 10.2.9 |
| When foreign key resolving took longer than 100 ms and the element debug log level was 1 or higher, a problem could occur in SLElement. <!-- RN 33826 --> | DataMiner 10.1.0 [CU13] to [CU17].<br>DataMiner 10.2.0 [CU1] to [CU5].<br>DataMiner 10.2.4 to 10.2.8. | N/A | Install DataMiner 10.1.0 [CU18], 10.2.0 [CU6], or 10.2.9 |
| When SLElement notified SLDataGateway about big table updates, in some rare cases, a problem in SLElement could occur. <!-- RN 29987 --> | DataMiner 10.1.0 and 10.2.0 main release versions.<br>DataMiner 10.1.1 to 10.2.6. | N/A | Install DataMiner 10.3.0 or 10.2.7 |

> [!TIP]
> See also: [Various SLElement issues](xref:KI_SLElement_various_issues)
