---
uid: Troubleshooting_Critical_Issues_Resources
---

# Critical issues: resources

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

## Insufficient resources troubleshooting flowchart

```mermaid
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
SLLogCollector([Log collector usage guide])
Investigation([How to investigate])
DataNotUpdated([Data not updated])
ErrorAlarmConsole([Errors in Alarm Console])
Automaticrestart([Automatic restart])
MachineoutofResources([Insufficient resources])
%% Connect blocks %%
Start --- Automaticrestart
Start --- MachineoutofResources
Start --- DataNotUpdated
Start --- ErrorAlarmConsole
%% Define hyperlinks %%
click Home "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click SLLogCollector "/dataminer/Reference/DataMiner_Tools/SLLogCollector.html"
click Investigation "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click DataNotUpdated "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Data_Not_Updated.html" "Data Not Updated"
click Automaticrestart "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Automatic_Restart.html" "Automatic Restart"
click ErrorAlarmConsole "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Alarm_Console.html" "Errors In Alarm Console"
click Start "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Overview.html" "Critical issue suspected"
click MachineoutofResources "#insufficient-resources" "Machine Out Of Resources"
%% Apply styles to blocks %%
class Start DarkBlue;
class Automaticrestart,DataNotUpdated,ErrorAlarmConsole,Automaticrestart,MachineoutofResources, LightBlue;
class UserActions,OSissues,ProcessCrash,ProcessDisappearance LightGray
class CrashdumpDetected,MinidumpDetected,CheckWatchdog Blue;
class Home,SLLogCollector,Investigation LightBlue;
```

### Insufficient resources

```mermaid
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
MachineoutofResources([Insufficient resources])
HDSpace{{"Insufficient hard disk space?"}}
RAM{{"Insufficient RAM? "}}
Process{{"Any specific process or program using up a lot of RAM? "}}
Cassandra{{"Is it the prunsrv service?"}}
DMProc{{"Is it a DataMiner process? "}}
FreeSpace["Make adjustments according to troubleshooting procedure or increase hard disk space."]
Prunsrv["1\. Check compaction status.<br/>2\. Check backup schedule.<br/>3\. Check if there is any ongoing offloading. "]
SLScriptingProc{{"Is it the SLScripting process? "}}
SLScriptingTroubleShooting["1\. Collect memory dump. <br/>2\. Analyze SLScripting memory dump."]
Proc["1\. Check for RTEs.<br/>2\. Check for stuck threads/errors in respective SL process logging.<br/>3\. Collect memory dump. "]
RAMup["Increase the RAM resources on the server."]
%% Connect blocks %%
MachineoutofResources --- HDSpace
HDSpace --- |YES| FreeSpace
HDSpace --- |NO| RAM
RAM --- |YES| Process
Process --- |YES| DMProc
Process --- |NO| RAMup
DMProc --- |YES| SLScriptingProc
SLScriptingProc --- |YES| SLScriptingTroubleShooting
SLScriptingProc --- |NO| Proc
DMProc --- |NO| Cassandra
Cassandra --- |YES| Prunsrv
Cassandra --- |NO| RAMup
%% Define hyperlinks %%
click FreeSpace "/dataminer/Troubleshooting/Procedures/Keeping_a_DMA_from_running_out_of_disk_space.html"
click SLScriptingTroubleShooting "/dataminer/Troubleshooting/Procedures/TroubleshootingSLScriptingOutOfMemoryException.html"
%% Apply styles to blocks %%
class Start DarkBlue;
class Prunsrv,Proc,FreeSpace,RAMup,SLScriptingTroubleShooting LightGray;
class Automaticrestart,DataNotUpdated,ErrorAlarmConsole,MachineoutofResources LightBlue;
class HDSpace,RAM,Process,Cassandra,DMProc,SLScriptingProc Blue;
class Home,SLLogCollector,Investigation LightBlue;
```
