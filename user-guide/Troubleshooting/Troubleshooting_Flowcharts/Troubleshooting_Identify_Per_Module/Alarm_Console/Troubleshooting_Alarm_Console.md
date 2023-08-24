---
uid: Troubleshooting_Alarm_Console
---

# Troubleshooting: Alarm Console

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

## Overview

<div class="mermaid">
flowchart TD
    %% Define styles %%
    linkStyle default stroke:#cccccc
    classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
    classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
    classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
    classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
    classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
    classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
    %% Define blocks %%
    START([Alarm Console])
    Error[Error]
    Rte([RTE])
    dberror([Database Error])
    Notice([Notice])
    InfoEvent([Information Event])
    TimeOut([Timeout])
    Alarms([Alarms])
    %% Connect blocks %%
    START --- Error
    Error --- Rte
    Error --- dberror
    START --- Notice
    START --- InfoEvent
    START --- TimeOut
    START --- Alarms
    %% Define hyperlinks %%
    click Rte "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Alarm_Console/Troubleshooting_Run_Time_Errors.html"
    %% Apply styles to blocks %%
    class START classTerminal;
    class Rte,dberror,Notice,InfoEvent,TimeOut,Alarms classExternalRef;
    class Error classActionClickable;
</div>

| **Flow item** | **Meaning** |
|--|--|
| Error | Referenced by white cross in red circle. <br> Signifies a significant problem. |
| Notice | Referenced by a black exclamation mark in a yellow triangle. <br> Signifies a potential problem or misconfiguration requiring attention. |
| Information Event | Indicates user activity at a certain time. <br> Significance depends on the type of activity. |
| Timeout | The device is not reachable or there is a problem with communication. |
| Alarms | If you have a problem with alarms, follow this path. |

## RTE

| **Issue** | **Plan of attack** |
|--|--|
| Protocol Thread RTE | [Check Protocol thread run-time errors: use cases](xref:Protocol_thread_run_time_errors_use_cases) |

## Database Error

| **Issue** | **Plan of attack** |
|--|--|
| Failed to Initialize Database tables | DMA cannot reach database <br> Refer to Database Flowchart |
| The Service Manager is licensed, but no Elasticsearch database is active on the system. Therefore, Resource Manager and Service Manager will not initialize. |Elasticsearch has not been installed - verify with Skyline if an Elasticsearch setup is required and install [Elasticsearch](xref:Elasticsearch_database) if necessary. |

## Notice

| **Issue** | **Plan of attack** |
|--|--|
| Alarm history exceeded 100 alarms. It is advised to revise your alarm threshold definitions. | 1. Preferably: stop toggling of alarm per parameter. <br> 2. If not possible, change [AlarmsPerParameter](xref:MaintenanceSettings_xml). |

## Information Event

| **Issue** | **Plan of attack** |
|--|--|
| Automation script failed | Check the exception |

## Timeout

| **Issue** | **Plan of attack** |
|--|--|
| SNMPv1,v2 Element in timeout | Refer to [SLSNMPManager flowchart](xref:Troubleshooting_SLSNMPManager_exe) |

## Alarms
| **Issue** | **Plan of attack** |
|--|--|
| Alarms delayed | Refer to [SLElement Flowchart](xref:Troubleshooting_SLElement_exe) |
