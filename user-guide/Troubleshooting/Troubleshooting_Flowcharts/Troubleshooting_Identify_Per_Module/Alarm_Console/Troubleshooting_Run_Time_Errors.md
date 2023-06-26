---
uid: Troubleshooting_Run_Time_Errors
---

# Alarm Console - run-time errors (RTEs)

## About run-time errors

RTEs occur when a DataMiner process thread does not respond for 15 minutes. Half-open RTEs occur after 7.5 minutes.

These are notable exceptions to the 15-minute window:

- SLDataMiner DataMinerNotificationQueueThread: 45 minutes

- MySQL DatabaseOffloadThread: 30 minutes

- MySQL DBCleaningThread: 1 hour

When an RTE occurs, an alarm is generated in the Alarm Console, the RTE is logged in *SLWatchDog2.txt*, and all DataMiner log files are captured in a minidump.

### Identifying run-time errors

- RTEs are displayed with severity "Error" in the Alarm Console.

- RTEs have the value "Thread problem in x: y” in the Alarm Console, where x is the process, and y is the thread.

- You can identify RTEs by opening *SLWatchDog2.txt* (in `C:\Skyline DataMiner\Logging` or in minidumps) and searching for “RTE Count = 1” (spaces included).

- Minidumps are named based on the RTE timestamp and DataMiner process that encountered an RTE.

### Additional resources

- [Watchdog logging and run-time error examples](xref:Watchdog_logging)

- [Common "Thread problem in x" errors](xref:Thread_problem_in_x)

- [Investigating a protocol thread RTE](xref:Investigating_a_protocol_thread_RTE)

## Run-time error flowchart

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classExtRef fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef classDecision fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef classTerminal fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef classSolution fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef classInfoAccClick fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef classInfoAccNoClick fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
START[RTE]
HOME([Start page])
CHECKRTE[Identifying an RTE]
CHECKALARM{{Are there alarms in the Alarm Console with value 'Thread problem in...'?}}
CHECKLOGS{{Check SLWatchdog2.txt logging for recent<br/> 'RTE Count = 1'. Is there an RTE?}}
CHECKDUMP{{Check minidump folder.<br/>Is there a recent RTE minidump?}}
NORTE([No RTE. Check for other possible issues.])
VERIFYRTE{{Verify which process has 'RTE Count = 1'<br/> and note the 'Not signaled 1' timestamp.}}
CHECKCRASHORDISP{{Any crashdumps or process disappearances<br/> near the time of the RTE?}}
CRASHORDISP([Check crash/process disappearance flows.])
CHECKACTIVE{{Is the RTE still active?}}
COLLECTLOGS[Run the SLLogCollector tool. Collect<br/>all logging and memory dumps of<br/>processes with active RTEs]
RTE([Take note of SL process and time of RTE.<br/>Follow relevant process flowcharts.])
%% Connect blocks %%
START --- CHECKRTE
CHECKRTE --- CHECKALARM
CHECKALARM --- |NO| CHECKLOGS
CHECKLOGS --- |NO| CHECKDUMP
CHECKDUMP --- |NO| NORTE
CHECKALARM --- |YES| VERIFYRTE
CHECKLOGS --- |YES| VERIFYRTE
CHECKDUMP ---- |YES| VERIFYRTE
VERIFYRTE --- CHECKACTIVE
CHECKACTIVE --- |NO|CHECKCRASHORDISP
CHECKACTIVE --- |YES|COLLECTLOGS
COLLECTLOGS --- CHECKCRASHORDISP
CHECKCRASHORDISP --- |YES|CRASHORDISP
CHECKCRASHORDISP --- |NO| RTE
%% Define hyperlinks %%
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click CRASHORDISP "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Alarm_Console.html"
click RTE "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Troubleshooting_Process_Identification.html"
click COLLECTLOGS "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html"
click CHECKRTE "#identifying-run-time-errors"
click NORTE "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
class START,CHECKRTE classTerminal;
class CHECKALARM,CHECKDUMP,CHECKLOGS,CHECKACTIVE,CHECKCRASHORDISP classDecision;
class HOME,RTE,NORTE,CRASHORDISP classExtRef;
class COLLECTLOGS,CHECKRTE classInfoAccClick
class VERIFYRTE classInfoAccNoClick
</div>
