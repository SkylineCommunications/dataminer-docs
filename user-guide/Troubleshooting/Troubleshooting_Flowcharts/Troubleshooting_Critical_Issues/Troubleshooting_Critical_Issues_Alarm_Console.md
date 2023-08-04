---
uid: Troubleshooting_Critical_Issues_Alarm_Console
---

# Critical issues: Alarm Console

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may be incomplete.

## Errors in Alarm Console troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
Start[Critical issue suspected]
Home([Start page])
SLLogCollector([Log collector <br> usage guide])
Investigation([How to investigate])
DataNotUpdated([Data not updated])
Automaticrestart([Automatic restart])
ErrorAlarmConsole([Errors in Alarm Console])
MachineoutofResources([Insufficient resources])
%% Connect blocks %%
Start ---- ErrorAlarmConsole
Start --- Automaticrestart
Start --- DataNotUpdated
Start --- MachineoutofResources
%% Define hyperlinks %%
click Home "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click SLLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html"
click Investigation "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click DataNotUpdated "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Data_Not_Updated.html" "Data Not Updated"
click Automaticrestart "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Automatic_Restart.html" "Automatic Restart"
click Start "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Overview.html" "Critical issue suspected"
click MachineoutofResources "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Resources.html" "Machine Out Of Resources"
click ErrorAlarmConsole "#errors-in-alarm-console" "Errors in Alarm Console"
%% Apply styles to blocks %%
class Start DarkBlue;
class Automaticrestart,DataNotUpdated,MachineoutofResources,ErrorAlarmConsole,RTE LightBlue;
class StickyYes,TogglingYes LightGray;
class Sticky,Toggling Blue;
class Home,SLLogCollector,Investigation LightBlue;
</div>

### Errors in Alarm Console

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
ErrorAlarmConsole([Errors in Alarm Console])
RTE([How to check for RTE])
Sticky{{"Is it a sticky alarm? <br/> "}}
Toggling{{"Are there toggling alarms? <br/> "}}
StickyYes["1. Check the element for the existence of the alarm.<br/> 2. Check the database for the alarm trigger and <br/>cleared alarm entries.<br/> "]
TogglingYes["1. Monitor Stream Viewer for a <br/>group or QAction that is stuck.<br/> 2. Check the protocol for any exceptions <br/>or errors when in debug mode.<br/> "]
%% Connect blocks %%
ErrorAlarmConsole --- Sticky
ErrorAlarmConsole --- RTE
Sticky --- |YES| StickyYes
Sticky --- |NO| Toggling
Toggling --- |YES| TogglingYes
%% Define hyperlinks %%
click RTE "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Alarm_Console/Troubleshooting_Run_Time_Errors.html" "How to check for RTE"
%% Apply styles to blocks %%
class Start DarkBlue;
class Automaticrestart,DataNotUpdated,MachineoutofResources,ErrorAlarmConsole,RTE LightBlue;
class StickyYes,TogglingYes LightGray;
class Sticky,Toggling Blue;
class Home,SLLogCollector,Investigation LightBlue;
</div>

## Typical errors

- **Severity**: [RTE](xref:Protocol_thread_run_time_errors_use_cases)

  **Alarm**: Thread problem in *SLProtocol.exe*

  **Plan of attack**:

  1. Check Stream Viewer for groups that are stuck.

  1. Check for [protocol pending calls](xref:How_to_retrieve_protocol_pending_calls).

- **Severity**: RTE

  **Alarm**: Thread problem in *SLElement.exe*

  **Plan of attack**:

  1. Check Stream Viewer for groups that are stuck.

  1. Check if there is a memory leak.

  1. Check if there has been a process crash.

- **Severity**: Timeout

  **Alarm**: Communication state: Not Responding

  **Plan of attack**:

  1. Perform a ping test from the server.

  1. Check the firewall for blocked ports.

  1. Check the element configuration, and compare with the information in the connector help.

  1. Check element logs for error logging.

- **Severity**: Timeout

  **Alarm**: Database not connected

- **Severity**: Timeout

  **Alarm**: Process crash
