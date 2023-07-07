---
uid: Troubleshooting_Identify_per_Module
---

# Troubleshooting - identify per module

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

Each module below conforms to one of the main parts of the DataMiner Cube UI. Click the module you are having trouble with in order to continue.

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
START([DataMiner Cube])
ModuleDefinition{{Which module are you having trouble with? }}
Apps([Apps])
Surveyor([Surveyor])
AlarmConsole([Alarm Console])
%% Connect blocks %%
START --- ModuleDefinition
ModuleDefinition --- Surveyor
ModuleDefinition --- Apps
ModuleDefinition --- AlarmConsole
%% Define hyperlinks %%
click Apps "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Apps/Troubleshooting_Apps.html" "Apps"
click Surveyor "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Surveyor/Troubleshooting_Surveyor.html" "Surveyor"
click AlarmConsole "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Alarm_Console/Troubleshooting_Alarm_Console.html" "Alarm Console"
%% Apply styles to blocks %%
class START classTerminal;
class AlarmConsole,Surveyor,Apps classExternalRef;
%%class classActionClickable;
class ModuleDefinition classDecision;
</div>

### Examples

[**Surveyor**](xref:Troubleshooting_Surveyor)

- Elements

- Services

- Views

- Export/import

- ....

[**Alarm Console**](xref:Troubleshooting_Alarm_Console)

- Error

- Notice

- Information events

- Timeouts

- Alarms

- Responsiveness of alarms

[**Apps**](xref:Troubleshooting_Apps)

- Automation

- Correlation

- Bookings

- Services

- Profiles

- ...
