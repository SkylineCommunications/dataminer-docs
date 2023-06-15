---
uid: Troubleshooting_SLLog_exe
---

# SLLog.exe

## Possible symptoms

- Some log files are not created in the Logging folder.

- Some log files are not limited in size and grow indefinitely.

- Log files are present but are not updated.

- DataMiner restarts because of a process disappearance.

## SLLog troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% Define blocks %%
LinkRootCause([To root cause flowchart])
LinkProcessList([To process identification])
Start([SLLog problem <br/>suspected])
CheckIssueType{{RTEs or crashes present?}}
Rte([Follow RTE investigation flowchart])
Crash([Follow Critical Issues -<br/>Automatic Restart flowchart])
EndReportIssue([Describe the issue in detail and<br/>contact Software Development])
%% Connect blocks %%
Start --- CheckIssueType
CheckIssueType --- |No| EndReportIssue
CheckIssueType --- |Run-time error| Rte
CheckIssueType --- |Crash| Crash
%% Define hyperlinks %%
click LinkRootCause "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Root Cause Flowchart"
click LinkProcessList "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Troubleshooting_Process_Identification.html" "Go to process identification page"
click Rte "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Alarm_Console/Troubleshooting_Run_Time_Errors.html" "RTE investigation diagram"
click Crash "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Automatic_Restart.html" "Crash investigation diagram"
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
%% Apply styles to blocks %%
class Start,EndReportIssue classTerminal;
class CheckIssueType classDecision;
class LinkRootCause,LinkProcessList,Rte,Crash classExternalRef;
</div>

## How does SLLog work?

SLLog is the process responsible for all DataMiner logging with the exception of SLNet. All output is written into files in *C:\Skyline DataMiner\logging*. Various processes connect to *SLLog.exe* and pass information to be logged. It is then written to *SL\*.txt* (a separate file for each process). Separate files are also created for each element and service.

SLNet uses its own logging mechanism. One of the reasons for this is that at DataMiner startup, SLNet starts earlier than SLLog.

In case of high load, e.g. when development logging is enabled, SLLog will use more CPU, but the memory usage should not rise. When a lot of data is being written to files, "Cleaned Stack!" messages may be found in various log files. These are notifications from SLLog that it has finished writing to a file.
