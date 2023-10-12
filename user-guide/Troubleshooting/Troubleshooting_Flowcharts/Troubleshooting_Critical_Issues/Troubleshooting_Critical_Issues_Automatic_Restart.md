---
uid: Troubleshooting_Critical_Issues_Automatic_Restart
---

# Critical issues: automatic restart

## Automatic restart troubleshooting flowchart

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
click Automaticrestart "#automatic-restart" "Automatic Restart"
click ErrorAlarmConsole "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Alarm_Console.html" "Errors In Alarm Console"
click Start "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Overview.html" "Critical issue suspected"
click MachineoutofResources "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Resources.html" "Machine Out Of Resources"
%% Apply styles to blocks %%
class Start DarkBlue;
class Automaticrestart,DataNotUpdated,ErrorAlarmConsole,Automaticrestart,MachineoutofResources, LightBlue;
class UserActions,OSissues,ProcessCrash,ProcessDisappearance LightGray
class CrashdumpDetected,MinidumpDetected,CheckWatchdog Blue;
class Home,SLLogCollector,Investigation LightBlue;
</div>

## Automatic restart

<div class="mermaid">
flowchart TD
%% Define styles %%
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
Automaticrestart([Automatic restart])
CrashdumpDetected{{"Crashdump found <br> at issue time? <br/>  C:\Skyline DataMiner\Logging\CrashDump"}}
MinidumpDetected{{"Minidump found <br> at issue time? <br/>  C:\Skyline DataMiner\Logging\MiniDump"}}
CheckWatchdog{{"Process disappearance <br> in log? <br/> C:\Skyline DataMiner\SLWatchdog2.txt"}}
UserActions["Did a user <br> trigger a restart?<br/> Check C:\Skyline DataMiner\SLWatchdog2_BAK.txt.<br/> "]
OSissues["Unexpected OS shutdown/problems, <br/> e.g. power outage, etc."]
ProcessCrash["1. Save .high Crashdump <br> + note timestamp. <br/>2. Collect minidump/<br>Log Collector logging. <br/>3. Investigate using the <br> Generic Investigation Flow. <br/>4. Send crashdump + logging <br> + conclusions to Create squads. "]
ProcessDisappearance["1. Identify process that <br> disappeared + timestamp.<br/> 2. Collect minidump. <br/> 3. Set up process dump <br> in Log Collector. <br/> 4.Identify DataMiner actions <br> during disappearance, <br/>using the Generic <br> Investigation Flow."]
%% Connect blocks %%
Automaticrestart --- CrashdumpDetected
CrashdumpDetected --- |Yes| ProcessCrash
CrashdumpDetected --- |No| MinidumpDetected
MinidumpDetected --- |Yes| CheckWatchdog
MinidumpDetected --- |No| OSissues
CheckWatchdog ---|Yes| ProcessDisappearance
CheckWatchdog ---|No| UserActions
%% Define hyperlinks %%
%% Apply styles to blocks %%
class Start DarkBlue;
class Automaticrestart,DataNotUpdated,ErrorAlarmConsole,Automaticrestart,MachineoutofResources, LightBlue;
class UserActions,OSissues,ProcessCrash,ProcessDisappearance LightGray
class CrashdumpDetected,MinidumpDetected,CheckWatchdog Blue;
class Home,SLLogCollector,Investigation LightBlue;
</div>
