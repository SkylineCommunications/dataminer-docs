---
uid: Troubleshooting_Critical_Issues_Data_Not_Updated
---

# Critical issues: data not updated

## Data not updated troubleshooting flowchart

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
Surveyor[Surveyor]
AlarmConsole[Alarm Console]
Element[Element]
%% Connect blocks %%
Start --- Automaticrestart
Start --- MachineoutofResources
Start --- DataNotUpdated
Start --- ErrorAlarmConsole
DataNotUpdated --- Surveyor
DataNotUpdated --- AlarmConsole
DataNotUpdated --- Element
%% Define hyperlinks %%
click Home "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click SLLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html"
click Investigation "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click DataNotUpdated "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Data_Not_Updated.html" "Data Not Updated"
click Automaticrestart "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Automatic_Restart.html" "Automatic Restart"
click ErrorAlarmConsole "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Alarm_Console.html" "Errors In Alarm Console"
click Start "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Overview.html" "Critical issue suspected"
click MachineoutofResources "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Resources.html" "Machine Out Of Resources"
click Surveyor "#surveyor" "Surveyor"
click AlarmConsole "#alarm-console" "Alarm-Console"
click Element "#element" "Element"
%% Apply styles to blocks %%
class Start DarkBlue;
class Automaticrestart,DataNotUpdated,ErrorAlarmConsole,Automaticrestart,MachineoutofResources, LightBlue;
class Home,SLLogCollector,Investigation LightBlue;
class Surveyor,AlarmConsole,Element Gray;
</div>

## Surveyor

- **Issue**: Views are not consistent

  **Plan of attack**:

  1. Check the *Views.xml* file across the cluster to ensure that the most recent file is present on all DMAs.

  1. Manually sync the *Views.xml* file if it is outdated on a DMA. See [Synchronizing data between DataMiner Agents](xref:Synchronizing_data_between_DataMiner_Agents).

## Alarm Console

- **Issue**: Alarm not cleared

  **Plan of attack**:

  1. Check on the element page what the current value is of the parameter in alarm.

  1. Check in the device GUI for the same parameter value.

  1. Restart the element.

  1. Clear the alarm entry from the database.

- **Issue**: Alarm not triggered

  **Plan of attack**:

  1. Check the alarm template.

  1. Check on the element page what the current value for the parameter is.

  1. Check in the device GUI for the same parameter value.

  1. Check the MIB browser or Stream Viewer for the parameter value.

## Element

- **Issue**: Element state not updated

  **Plan of attack**:

  1. Restart the element, if possible.

  1. Check for the element state in *Element.xml*.

  1. Check for Correlation issues.

  1. Check for [issues with SLElement](xref:Troubleshooting_SLElement_exe).

  1. Set the desired element state via SLNetClientTest tool.

- **Issue**: Element user interface not updated

  **Plan of attack**:

  1. Look for protocol thread RTEs.

  1. Look for issues in the protocol logs.

  1. Look for [issues in SLElement](xref:Troubleshooting_SLElement_exe).

  1. Check the CPU and memory usage for the SLElement process.

- **Issue**: Parameter sets not executed

  **Plan of attack**:

  1. Check the element logs for SetParameter thread.

  1. Check the information events.

  1. Follow the Cube session with the SLNetClientTest tool.

- **Issue**: Trending flatlining/not updating

  **Plan of attack**:

  1. Check for polling issues from the device.

  1. Check for driver-related issues.

  1. Check for [issues with SLDataGateway](xref:Troubleshooting_SLDataGateway_exe).
