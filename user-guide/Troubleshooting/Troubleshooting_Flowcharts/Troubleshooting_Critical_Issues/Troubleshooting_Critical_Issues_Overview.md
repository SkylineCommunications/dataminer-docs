---
uid: Troubleshooting_Critical_Issues_Overview
---

# Troubleshooting - critical issues - overview

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
ErrorAlarmConsole([Errors in Alarm Console])
Automaticrestart([Automatic restart])
MachineoutofResources([Insufficient resources])
%% Connect blocks %%
Start ---> MachineoutofResources
Start --> Automaticrestart
Start --> DataNotUpdated
Start --> ErrorAlarmConsole
%% Define hyperlinks %%
click Home "https://community.dataminer.services/troubleshooting-finding-a-root-cause/"
click SLLogCollector "https://community.dataminer.services/documentation/sllogcollector-tool/"
click Investigation "https://community.dataminer.services/documentation/troubleshooting-where-to-start/"
click DataNotUpdated "https://community.dataminer.services/troubleshooting-critical-issues-data-not-updated/" "Data Not Updated"
click Automaticrestart "https://community.dataminer.services/troubleshooting-critical-issues-automatic-restart/" "Automatic Restart"
click ErrorAlarmConsole "https://community.dataminer.services/troubleshooting-critical-issues-alarm-console/" "Errors In Alarm Console"
click Start "https://community.dataminer.services/troubleshooting-critical-issues-overview/" "Critical issue suspected"
click MachineoutofResources "https://community.dataminer.services/troubleshooting-critical-issues-resources/" "Machine Out Of Resources"
%% Apply styles to blocks %%
class Start DarkBlue;
class CheckWatchdog classDecision;
class Automaticrestart,MachineoutofResources,DataNotUpdated,ErrorAlarmConsole, LightBlue;
class Home,SLLogCollector,Investigation LightBlue;
</div>
