---
uid: Troubleshooting_Process_Identification
---

# Troubleshooting - process identification

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may be incomplete.

## Main processes

| **Process** | **Function**|
|--|--|
| [SLElement.exe](xref:Troubleshooting_SLElement_exe) | Displays parameters and alarms. |
| [SLDataMiner.exe](xref:Troubleshooting_SLDataMiner_exe) | General DataMiner functionality, e.g. start/stopping elements, checking licenses, etc. |
| SLProtocol.exe | Interprets protocols (i.e. drivers/connectors). |

## Communication processes

| **Process** | **Function**|
|--|--|
| [SLNet.exe](xref:Troubleshooting_SLNet_exe) | Inter-process communication, cluster communication, etc. |
| SLNetComService.exe | Communication with client applications, etc. |
| [SLDMS.exe](xref:Troubleshooting_SLDMS_exe) | File synchronization of cluster and Failover pair, Active Directory polling. |

## Polling processes

| **Process** | **Function**|
|--|--|
| [SLPort.exe](xref:Troubleshooting_SLPort_exe) | Serial communication, HTTP communication. |
| [SLSNMPManager.exe](xref:Troubleshooting_SLSNMPManager_exe) | SNMPv1/SNMPv2/SNMPv3 communication. |

## Logging processes

| **Process** | **Function**|
|--|--|
| [SLWatchdog.exe](xref:Troubleshooting_SLWatchdog_exe) | Monitors other DataMiner processes and warns when these are not responding. |
| [SLLog.exe](xref:Troubleshooting_SLLog_exe) | Writes logs. |

## Database processes

| **Process** | **Function**|
|--|--|
| [SLDataGateway.exe](xref:Troubleshooting_SLDataGateway_exe) | Interacts with the database, trending logic, etc. |

## Other processes

| **Process** | **Function**|
|--|--|
| [SLXML.exe](xref:Troubleshooting_SLXML_exe) | Writes XML to files. |
| [SLASPConnection.exe](xref:Troubleshooting_SLASPConnection_exe) | Generates legacy reports. |
| [SLAnalytics.exe](xref:Troubleshooting_SLAnalytics_exe) | AI-driven prediction and other DataMiner Analytics features. |
| [SLHelper.exe](xref:Troubleshooting_SLHelper_exe) | Performs various small tasks. |
| SLBrain.exe | Backwards compatibility DataMiner 8.0 Correlation. <br> Deprecated. |
| [SLScheduler.exe](xref:Troubleshooting_SLScheduler_exe) | Schedules DataMiner tasks. |
