---
uid: Troubleshooting_SLNet_Startup
---

# SLNet - startup issues

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

```mermaid
flowchart TD
%% -------------------------------------------------------------------------
%% SLNet flowchart - startup issue branch
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classActionNonClickable fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
  HOME([Start page])
  START([DMA has trouble starting up correctly])
  BACK([Back to SLNet troubleshooting])
  MODULES{{Which issue is affecting the DMA ?}}
    IsRunning{{Is the DMA running?}}
    IsConnected{{Is the connection successful?}}
    IsRTEorCrash{{Are there RTEs or crashes?}}
    IsGenericIssueFound{{Is the issue identified?}}
    IsSLNetPresent{{Is the SLNet service present?}}
    IsProcessSuspended{{Is the SLNet process suspended?}}
    IsAv[[Is any software interfering with the process? For example: antivirus.]]
    OpenCube[[Open Cube and connect to the DMA.]]
    GenericCases[[Follow the generic startup issues flowchart.]]
    RTEChart[[Follow the RTE troubleshooting flowchart.]]
    CrashChart[[Follow the crash troubleshooting flowchart.]]
    EventsAndLogs[[Check Windows events and DataMiner logs for errors.]]
    RegisterDlls[[Register the DLLs and recreate the missing services.]]
    RestartAgent[[Restart DataMiner.]]
    RestartMachine[[Restart the machine.]]
    ManualStart[[Start the DMA manually.]]
    SysAdmin[[Ask admin to exclude DataMiner files and services from the antivirus watchlist.]]
    IsRunning --- |Yes| OpenCube
    OpenCube --- IsConnected
    IsConnected --- |Yes, started correctly| END
    IsConnected --- |Yes, not started correctly| IsRTEorCrash
    IsConnected --- |No| GenericCases
    GenericCases --- IsGenericIssueFound
    IsGenericIssueFound --- |Yes, identified, fixed, and started correctly| END
    IsGenericIssueFound --- |No| IsRTEorCrash
    IsRTEorCrash --- |RTE| RTEChart
    IsRTEorCrash --- |Crash| CrashChart
    RTEChart --- END
    CrashChart --- END
    IsRunning --- |No| IsSLNetPresent
    IsSLNetPresent --- |Yes| IsProcessSuspended
    IsProcessSuspended --- |No| ManualStart
    IsProcessSuspended --- |Yes| RestartMachine
    RestartMachine --- IsRunning
    ManualStart --- IsAv
    SysAdmin --- IsRunning
    IsAv --- |No| EventsAndLogs
    IsAv --- |Yes| SysAdmin
    EventsAndLogs --- IsRTEorCrash
    IsSLNetPresent --- |No| RegisterDlls
    RegisterDlls --- RestartAgent
    RestartAgent --- IsRunning
  START --- MODULES
  MODULES --- |Abnormal DMA startup| IsRunning
%% -------------------------------------------------------------------------
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%%    END([End])
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
 click HOME "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
 click BACK "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/Troubleshooting_SLNet_exe.html"
 click GenericCases "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html"
 click RTEChart "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Alarm_Console/Troubleshooting_Run_Time_Errors.html"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
class AGENTDISC,GenericCases classActionClickable;
class CrashChart,RTEChart classSolution;
class MODULES,IsRunning,IsConnected,IsGenericIssueFound,IsRTEorCrash,IsSLNetPresent,IsProcessSuspended,IsAv classDecision;
class START,END,TECHSUPPORT classTerminal;
class HOME,BACK classExternalRef;
class OpenCube,EventsAndLogs,RegisterDlls,RestartAgent,RestartMachine,ManualStart,SysAdmin classActionNonClickable;
```
