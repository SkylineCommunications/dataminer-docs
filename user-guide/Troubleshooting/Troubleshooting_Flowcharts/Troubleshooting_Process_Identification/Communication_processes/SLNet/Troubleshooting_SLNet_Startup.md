---
uid: Troubleshooting_SLNet_Startup
---

# SLNet - startup issues

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

<div class="mermaid">
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
  START([DMA has trouble <br>starting up correctly<br/>])
  BACK([Back to SLNet <br>troubleshooting])
  MODULES{{Which issue <br> is affecting<br/> the DMA ?}}
    IsRunning{{Is the<br/>DMA running?}}
    IsConnected{{Is the<br/>connection <br>successful?}}
    IsRTEorCrash{{Are there RTEs <br>or crashes?}}
    IsGenericIssueFound{{Is the issue <br> identified?}}
    IsSLNetPresent{{Is the SLNet <br>service present?}}
    IsProcessSuspended{{Is the <br> SLNet process <br>suspended?}}
    IsAv[[Is any software <br>interfering with <br>the process?<br>For example: <br> antivirus.]]
    OpenCube[[Open Cube<br/>and connect<br/>to the DMA.]]
    GenericCases[[Follow the <br>generic startup <br>issues flowchart.]]
    RTEChart[[Follow the RTE <br/>troubleshooting <br>flowchart.]]
    CrashChart[[Follow the <br>crash troubleshooting <br>flowchart.]]
    EventsAndLogs[[Check Windows <br>events and <br>DataMiner logs <br>for errors.]]
    RegisterDlls[[Register the DLLs <br> and recreate <br> the missing services.]]
    RestartAgent[[Restart <br>DataMiner.]]
    RestartMachine[[Restart <br>the machine.]]
    ManualStart[[Start the <br>DMA manually.]]
    SysAdmin[[Ask admin to <br>exclude DataMiner <br>files and services <br>from the antivirus <br>watchlist.]]
    IsRunning --- |Yes| OpenCube
    OpenCube --- IsConnected
    IsConnected --- |Yes, started correctly| END
    IsConnected --- |Yes, not started correctly| IsRTEorCrash
    IsConnected --- |No| GenericCases
    GenericCases --- IsGenericIssueFound
    IsGenericIssueFound --- |Yes, identified, fixed, <br>and started correctly| END
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
 click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
 click BACK "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/Troubleshooting_SLNet_exe.html"
 click GenericCases "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html"
 click RTEChart "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Identify_Per_Module/Alarm_Console/Troubleshooting_Run_Time_Errors.html"
 click CrashChart "http://"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
class AGENTDISC,GenericCases classActionClickable;
class CrashChart,RTEChart classSolution;
class MODULES,IsRunning,IsConnected,IsGenericIssueFound,IsRTEorCrash,IsSLNetPresent,IsProcessSuspended,IsAv classDecision;
class START,END,TECHSUPPORT classTerminal;
class HOME,BACK classExternalRef;
class OpenCube,EventsAndLogs,RegisterDlls,RestartAgent,RestartMachine,ManualStart,SysAdmin classActionNonClickable;
</div>
