---
uid: Troubleshooting_Critical_Issues_Alarm_Console
---

# Troubleshooting - critical issues - Alarm Console

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may be incomplete.

## Errors in Alarm Console troubleshooting flowchart
<div class="mermaid">
graph TD
%% Define styles %%
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
Start[Critical issue suspected]
Home([Start page])
SLLogCollector([Log collector usage guide])
Investigation([How to investigate])
DataNotUpdated([Data not updated])
Automaticrestart([Automatic restart])
ErrorAlarmConsole([Errors in Alarm Console])
MachineoutofResources([Insufficient resources])
RTE([How to check for RTE])
Sticky{{"Is it a sticky alarm? <br/> "}}
Toggling{{"Are there toggling alarms? <br/> "}}
StickyYes["1. Check the element for the existence of the alarm.<br/> 2. Check the database for the alarm trigger and <br/>cleared alarm entries.<br/> "]
TogglingYes["1. Monitor Stream Viewer for a <br/>group or QAction that is stuck.<br/> 2. Check the protocol for any exceptions <br/>or errors when in debug mode.<br/> "]
%% Connect blocks %%
Start ---> ErrorAlarmConsole
Start --> Automaticrestart
Start --> DataNotUpdated
Start --> MachineoutofResources
ErrorAlarmConsole --> Sticky
ErrorAlarmConsole --> RTE
Sticky --> |YES| StickyYes
Sticky --> |NO| Toggling
Toggling --> |YES| TogglingYes
%% Define hyperlinks %%
click Home "https://community.dataminer.services/troubleshooting-finding-a-root-cause/"
click SLLogCollector "https://docs.dataminer.services/user-guide/Reference/DataMiner_Tools/SLLogCollector.html"
click Investigation "https://community.dataminer.services/documentation/troubleshooting-where-to-start/"
click DataNotUpdated "https://community.dataminer.services/troubleshooting-critical-issues-data-not-updated/" "Data Not Updated"
click Automaticrestart "https://community.dataminer.services/troubleshooting-critical-issues-automatic-restart/" "Automatic Restart"
click ErrorAlarmConsole "https://community.dataminer.services/troubleshooting-critical-issues-alarm-console/" "Errors In Alarm Console"
click Start "https://community.dataminer.services/troubleshooting-critical-issues-overview/" "Critical issue suspected"
click MachineoutofResources "https://community.dataminer.services/troubleshooting-critical-issues-resources/" "Machine Out Of Resources"
click RTE "https://community.dataminer.services/troubleshooting-run-time-errors-rtes/" "How to check for RTE"
%% Apply styles to blocks %% 
class Start DarkBlue; 
class Automaticrestart,DataNotUpdated,MachineoutofResources,ErrorAlarmConsole,RTE LightBlue; 
class StickyYes,TogglingYes LightGray;
class Sticky,Toggling Blue;
class Home,SLLogCollector,Investigation LightBlue;
</div>

<!-- Comment: add link to troubleshooting critical issues overview + critical issues data not updated + automatic restart + resources + once added to docs -->
## Typical errors

### Severity: RTE

- Alarm: Thread problem in *SLProtocol.exe*

  Plan of attack:

  1. Check Stream Viewer for groups that are stuck.

  1. Check for protocol pending calls.

- Alarm: Thread problem in *SLElement.exe*

  Plan of attack:

  1. Check Stream Viewer for groups that are stuck.

  1. Check if there is a memory leak.

  1. Check if there has been a process crash.

### Severity: Timeout

- Alarm: Communication state: Not Responding

  Plan of attack:

  1. Perform a ping test from the server.

  1. Check the firewall for blocked ports.

  1. Check the element configuration, and compare with the information in the connector help.

  1. Check element logs for error logging.

### Database not connected

<!-- Comment: plan of attack missing -->

### Process crash

<!-- Comment: plan of attack missing -->
