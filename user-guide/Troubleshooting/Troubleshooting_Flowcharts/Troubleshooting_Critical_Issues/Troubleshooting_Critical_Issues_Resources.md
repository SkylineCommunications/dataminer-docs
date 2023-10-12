---
uid: Troubleshooting_Critical_Issues_Resources
---

# Critical issues: resources

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

## Insufficient resources troubleshooting flowchart

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
click Home "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click SLLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html"
click Investigation "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click DataNotUpdated "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Data_Not_Updated.html" "Data Not Updated"
click Automaticrestart "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Automatic_Restart.html" "Automatic Restart"
click ErrorAlarmConsole "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Alarm_Console.html" "Errors In Alarm Console"
click Start "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Overview.html" "Critical issue suspected"
click MachineoutofResources "#insufficient-resources" "Machine Out Of Resources"
%% Apply styles to blocks %%
class Start DarkBlue;
class Automaticrestart,DataNotUpdated,ErrorAlarmConsole,Automaticrestart,MachineoutofResources, LightBlue;
class UserActions,OSissues,ProcessCrash,ProcessDisappearance LightGray
class CrashdumpDetected,MinidumpDetected,CheckWatchdog Blue;
class Home,SLLogCollector,Investigation LightBlue;
</div>

### Insufficient resources

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
MachineoutofResources([Insufficient resources])
HDSpace{{"Insufficient hard disk space? <br/> "}}
RAM{{"Insufficient RAM? <br/> "}}
Process{{"Any specific process or program using up a lot of RAM? <br/> "}}
Cassandra{{"Is it the prunsrv service?"}}
DMProc{{"Is it a DataMiner process? <br/> "}}
FreeSpace["Make adjustments according <br>to troubleshooting procedure <br>or increase hard disk space."]
Prunsrv["1. Check compaction status.<br/> 2. Check backup schedule.<br/> 3. Check if there is any ongoing offloading. <br/> "]
Proc["1. Check for RTEs.<br/> 2. Check for stuck threads/errors in <br/>respective SL process logging.<br/> 3. Collect memory dump. <br/> "]
RAMup["Increase the RAM resources on the server."]
%% Connect blocks %%
MachineoutofResources --- HDSpace
HDSpace --- |YES| FreeSpace
HDSpace --- |NO| RAM
RAM --- |YES| Process
Process --- |YES| DMProc
Process --- |NO| RAMup
DMProc --- |YES| Proc
DMProc --- |NO| Cassandra
Cassandra --- |YES| Prunsrv
Cassandra --- |NO| RAMup
%% Define hyperlinks %%
click FreeSpace "/user-guide/Troubleshooting/Procedures/Keeping_a_DMA_from_running_out_of_disk_space.html"
%% Apply styles to blocks %%
class Start DarkBlue;
class Prunsrv,Proc,FreeSpace,RAMup LightGray;
class Automaticrestart,DataNotUpdated,ErrorAlarmConsole,MachineoutofResources LightBlue;
class HDSpace,RAM,Process,Cassandra,DMProc Blue;
class Home,SLLogCollector,Investigation LightBlue;
</div>
