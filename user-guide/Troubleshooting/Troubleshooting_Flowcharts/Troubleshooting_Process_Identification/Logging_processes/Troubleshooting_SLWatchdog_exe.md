---
uid: Troubleshooting_SLWatchdog_exe
---

# SLWatchdog.exe

## About SLWatchdog

*SLWatchDog.exe* (or "SLWatchdog" for short) monitors all other DataMiner processes and threads. It makes any issues within them visible and tries to resolve issues by restarting DataMiner.

SLWatchdog polls all processes and threads every second if possible, and every few seconds if the process is under a high load. It registers if a thread is not responding and keeps track of how long a thread does not respond to SLWatchdog's queries.

Note that while in most cases the root time of an issue in the SLWatchdog logging matches the actual time to the second, when a process or thread is under heavy stress, it can occur that SLWatchdog only registers the root time of the issue within the minute.

### What does SLWatchdog monitor?

- DataMiner threads, grouped per process. Found issues are logged per process.

- Databases:

  - MySQL

  - Cassandra

  - Elasticsearch

### When will SLWatchdog take action?

SLWatchdog will take action:

- If a run-time error occurs – see [Troubleshooting – Run-Time Errors (RTEs)](xref:Troubleshooting_Run_Time_Errors).

- If a process suddenly stops (i.e. a process disappearance).

- If a process crashes. This is not the same as a process disappearance.

- If anomalies are detected within a certain thread.

- Every hour, to send reports to CDMR.

SLWatchdog will perform the following actions, depending on what has happened:

- Generate an "error" alarm.

- Automatically restart the DMA.

- Send daily/hourly performance reports.

- Send performance reports in case of issues.

### Where can you find SLWatchdog logging?

You can find the SLWatchdog logging in *C:\Skyline DataMiner\Logging\SLWatchdog2.txt*.

Note that this file contains the number 2. *SLWatchdog.txt* also exists, but this is an older log file that contains less relevant information.

## SLWatchdog troubleshooting flowcharts

To troubleshoot SLWatchdog issues, start from the Memory leak flowchart below.

### Memory leak flowchart

<div class="mermaid">
flowchart TD
%% Define blocks %%
    Home([Start page])
    SLLogCollector([Log collector usage guide])
    Investigation([How to investigate])
    SLWatchDog[SLWatchDog]
    MemoryLeak{{Is there a memory leak?}}
    ConfirmLeak(How to confirm a memory leak)
    ReportsGrowing[Check if the size of generated reports is growing: <br>C:\Skyline DataMiner\Logging\WatchDog\Reports]
    ValidateXml[Open recent reports and check if the XML is valid. <br>Check XML tags, attributes, data.]
    togglingRTE[Check for toggling RTEs, i.e. RTEs switching on and off in quick<br/>succession, which can cause SLWatchDog to generate many files: <br> C:\Skyline DataMiner\Logging\WatchDog\Notifications]
    RteLink([How to check for RTEs])
    CheckSlXml[Check SLXML process for issues]
    XmlFlowchart([SLXML flowchart])
    CommonIssues([SLWatchDog common issues])
%% Connect blocks %%
    SLWatchDog--- MemoryLeak
    MemoryLeak --- ConfirmLeak
    ConfirmLeak---|Yes| ReportsGrowing
    ConfirmLeak --- |No| CommonIssues
    ReportsGrowing --- ValidateXml
    ValidateXml --- togglingRTE
    togglingRTE --- RteLink
    togglingRTE --- CheckSlXml
    CheckSlXml --- XmlFlowchart
 %% Define hyperlinks %%
click Investigation "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click RteLink "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Alarm_Console/Troubleshooting_Run_Time_Errors.html" "Go to RTE troubleshooting page"
click XmlFlowchart "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Other_processes/Troubleshooting_SLXML_exe.html" "Go to SLXML Flowchart"
click ConfirmLeak "#how-can-you-confirm-a-memory-leak" "How to identify a memory leak."
click CommonIssues "#common-issues-flowchart" "Go to common issues"
click RunLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html" "How to use the log collector tool."
click Home "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Root Cause Identification flow"
click SLLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html" "How to use the log collector tool."
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
%% Apply styles to blocks %%
class SLWatchDog classTerminal;
class MemoryLeak classDecision;
class ReportsGrowing,ValidateXml,togglingRTE,CheckSlXml classAction;
%%class classSolution;
class ConfirmLeak,CommonIssues classActionClickable;
class Home,SLLogCollector,Investigation,RteLink,XmlFlowchart classExternalRef;
</div>

### Common issues flowchart

<div class="mermaid">
flowchart TD
%% Define blocks %%
    CommonIssues[SLWatchDog common issues]
    WatchdogStarted{{Is the SLWatchdog.exe process <br>running in Windows Task Manager?}}
    UpgradeStuck{{Is a DataMiner upgrade stuck <br>unpacking update.zip?}}
    CheckBitness[Watchdog registered as wrong bitness:<br/>32-bit vs. 64-bit process.]
    InstructionsBitness[Confirm if SLWatchdog is running<br> as a 64- or 32-bit process. ]
    dmaVersion[Look up the DataMiner version.]
    ResolveMismatch([Resolve a mismatch between <br/>the DataMiner version and<br/>the 64-/32-bit process. ])
    LogIssues[Issues with logging]
    WrongDates([Incorrect dates: year 1899 <br>Fixed in DataMiner 9.6.1: RN 19671])
    FailedMinidumps[Minidumps not created.]
    CheckSystemCache[Check the System Cache folder <br>for temporary minidumps.]
    RunLogCollector([Run SLLogCollector and check for errors.])
     CrashdumpIssues[Crash dump issues]
     CrashRestart[Normally, DataMiner restarts upon a process crash. <br>When a process has a crash dump, <br>the process could keep running.]
     VerifyRestart([Check if SLWatchDog restarts after crash dumps. <br> See DataMiner 10.0.0/10.0.12 RNs: RN 27321.])
%% Connect blocks %%
    Home([Start page])
    SLLogCollector([Log collector usage guide])
    Investigation([How to investigate])
    CommonIssues--- UpgradeStuck
    UpgradeStuck --- |Yes| CheckBitness
    UpgradeStuck --- |No| WatchdogStarted
    WatchdogStarted --- |Yes| LogIssues
     WatchdogStarted --- |Yes| CrashdumpIssues
    WatchdogStarted --- |No| CheckBitness
    CheckBitness--- InstructionsBitness
    InstructionsBitness---dmaVersion
    dmaVersion---ResolveMismatch
    LogIssues---WrongDates
    LogIssues---FailedMinidumps
    FailedMinidumps---CheckSystemCache
    CheckSystemCache---RunLogCollector
    CrashdumpIssues---CrashRestart
    CrashRestart--- VerifyRestart
%% Define hyperlinks %%
click Investigation "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Where_to_Start.html"
click InstructionsBitness "#is-watchdog-running-as-a-64-bit-process" "Determine if Watchdog is registered as 32-bit or 64 bit process. "
click ResolveMismatch "#how-do-you-resolve-a-bitness-mismatch-between-the-dataminer-version-and-slwatchdogexe" "Resolve mismatch between DMA and SLWatchdog bitness"
click RunLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html" "How to use the log collector tool."
click Home "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Root Cause Identification flow"
click SLLogCollector "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html" "How to use the log collector tool."
click VerifyRestart "https://docs.dataminer.services/release-notes/General/General_Main_Release_10.0/General_Main_Release_10.0.0_CU7.html#dataminer-restart-not-triggered-after-process-generated-crashdump-id_27321" "Release Note 27321"
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
%% Apply styles to blocks %%
class CommonIssues classTerminal;
class UpgradeStuck,WatchdogStarted classDecision;
class CrashRestart,CrashdumpIssues,CheckBitness,dmaVersion,LogIssues,FailedMinidumps,CheckSystemCache classAction;
class InstructionsBitness,ResolveMismatch classActionClickable;
class WrongDates,VerifyRestart,Home,SLLogCollector,Investigation,RunLogCollector classExternalRef;
</div>

### Is Watchdog running as a 64-bit process?

SLWatchDog will run as a 32-bit or 64-bit process depending on the DataMiner version: prior to the 9.6.0 main release and 9.6.2 feature release, it runs as a 32-bit process.

Performing upgrades/downgrades between DataMiner versions with 32-bit and 64-bit SLWatchdog processes can cause issues.

### How do you resolve a bitness mismatch between the DataMiner version and SLWatchdog.exe?

If there is a mismatch, perform the steps below:

1. Stop DataMiner.

1. Go to the folder *C:\Skyline DataMiner\Tools* and run the following files as Administrator:

   1. *UnRegister DLLs of DataMiner.bat*

   1. *Unregister DataMiner.bat*

1. Restart the server.

1. From the folder *C:\Skyline DataMiner\Tools*, run the following files as Administrator:

   1. *RegisterDLLs.bat*

   1. *Register DataMiner as Service.bat or Register DataMiner as Service32.bat*

1. Restart DataMiner.

### How can you confirm a memory leak?

To confirm if there is a memory leak in *SLWatchdog.exe*:

1. Open a Microsoft Platform element monitoring the affected DMA. This element should be present on every DMA with a maintenance contract.

1. Go to the *Task Manager* page.

1. In the *Task Manager* table, filter on SLWatchdog. Ascertain if trending is enabled for memory, and open trending for this particular process.

1. Check if specific memory usage is rising steadily over time. If it is, this confirms that a memory leak is present.
