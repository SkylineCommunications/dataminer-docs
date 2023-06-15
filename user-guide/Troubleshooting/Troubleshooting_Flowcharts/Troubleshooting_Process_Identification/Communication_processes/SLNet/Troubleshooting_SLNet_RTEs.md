---
uid: Troubleshooting_SLNet_RTEs
---

# SLNet - RTEs

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% SLNet flowchart - SLNetCom notification issues
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
  START([SLNetCom is experiencing thread issues<br/>])
  BACK([Back to SLNet <br/>troubleshooting])
  MODULES{{Which issue is affecting<br/> the DMA ?}}
    IssueFound{{Is the issue identified?}}
    IsStackIssue{{What does the stack size look like?}}
    StartupGuide[[Follow the generic DMA startup troubleshooting guide]]
    CheckAlarmsAndLogs[[Inspect the alarms, notifications <br/>and logs of the affected processes.<br/>Also check SLErrors and SLNet logs.]]
    CheckJobSize[[Check job queue size<br/> via ClientTestTool]]
    HighStack[[Plot the stack size every 5 minutes:<br/> Diagnostics>SLNet>StackSizes<br/>Export]]
    SearchLine[[Turn auto-refresh on and<br/> search for the 'slnetcom' string]]
    LogSize[[Increase SLNet log size<br/> C:\Skyline DataMiner\Files\SLNet.exe.config]]
  START --- MODULES
    MODULES --- |Abnormal DMA startup| StartupGuide
    StartupGuide --- END
    MODULES --- |RTEs| CheckAlarmsAndLogs
    CheckAlarmsAndLogs --- IssueFound
    IssueFound --- |No| CheckJobSize
    IssueFound --- |Yes| END
    CheckJobSize --- IsStackIssue
    IsStackIssue --- |High and stagnating<br/> or high and growing| HighStack
    HighStack --- SearchLine
    IsStackIssue --- |Normal| LogSize
%% -------------------------------------------------------------------------
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%%    END([End])
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
 click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Start Page"
 click BACK "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/Troubleshooting_SLNet_exe.html" "Back to SLNet flowchart"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
class CheckAlarmsAndLogs,CheckJobSize,HighStack,LogSize,SearchLine classActionNonClickable;
class StartupGuide classActionClickable;
class test1 classSolution
class MODULES,IssueFound,IsStackIssue classDecision;
class START,END,TECHSUPPORT classTerminal;
class HOME,BACK classExternalRef;
</div>
