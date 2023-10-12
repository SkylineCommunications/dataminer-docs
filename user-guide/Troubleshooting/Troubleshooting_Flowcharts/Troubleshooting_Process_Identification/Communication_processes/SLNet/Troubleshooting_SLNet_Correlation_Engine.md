---
uid: Troubleshooting_SLNet_Correlation_Engine
---

# SLNet - correlation engine

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% SLNet flowchart - sub page on Correlation Engine issues
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
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
HOME([Start page])
START([Correlation engine <br />issues in SLNet])
BACK([Back to SLNet <br/>troubleshooting])
CONTACT([Send all information<br/>to tech support.])
ENDING([End])
PRESENT{{Issue still present?}}
PRESENTYES[[Check SLNetClientTest tool<br/>Diagnostics > SLNet > Stacksizes <br/>for high Correlation thread.]]
PRESENTNO{{Investigate gathered data: <br/>Found anything?}}
FOUNDYES[[Refactor the relevant<br/>Correlation rules and/or<br/>Automation scripts.]]
GATHER[[Gather a LogCollector package.<br/>Include memory dumps for<br/>SLNet and SLCorrelation.]]
START ---  GATHER
GATHER --- PRESENT
PRESENT --- |Yes| PRESENTYES
PRESENT --- |No| PRESENTNO
PRESENTYES --- PRESENTNO
PRESENTNO --- |Yes|FOUNDYES
PRESENTNO --- |No|CONTACT
FOUNDYES --- ENDING
%% what to check?
%% - information events many rules triggered?
%% - SLCorrelation/SLNet logging many rules triggered?
%% - Client test tool\Diagnostics\SLNet\Stacksizes --> CorrelationThread
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click DISC "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/SLNet/Troubleshooting_SLNet_Disconnects.html" "Go to disconnect cases"
click BACK "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Communication_processes/Troubleshooting_SLNet_exe.html" "Go back to SLNet Troubleshooting"
click GATHER "/user-guide/Reference/DataMiner_Tools/SLLogCollector.html" "Go to LogCollector"
click PRESENTYES "#slnetclienttest-tool"
click PRESENTNO "#slnetclienttest-tool"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
class GATHER,PRESENTYES classActionClickable;
class FOUNDYES classSolution
class PRESENTNO,PRESENT classDecision;
class START,ENDING,CONTACT classTerminal;
class HOME,BACK classExternalRef;
</div>

## Investigating the data

Check the log files *SLAutomation.txt*, *SLCorrelation.txt* and *SLNet.txt*.

Also check for relevant information events in the Alarm Console in DataMiner Cube.

### Automation - Sleep functions

Check if you have Correlation rules that trigger Automation scripts. If so, check if these scripts **contain a [Sleep](xref:Sleep) function**, i.e. Thread.Sleep(...) or Engine.Sleep(...), possibly in combination with the script options "[*Wait for the script to finish before continuing*](xref:Script_execution_options)" or "[*Wait when locked or busy*](xref:Script_execution_options)". If this is indeed the case, **refactor these scripts** to avoid these delays.

When SLCorrelation triggers an Automation script and that script contains a Sleep function, this can block the SLCorrelation process. If a large number of Correlation rules are triggered, this can cause SLNet issues.

These delays are also visible in the log files. You will notice that rules or scripts will only get triggered after the delay is finished.

### Correlation loops

Check the information events or the SLCorrelation log file to see if there is a high number of triggered Correlation rules, or if the same rule gets triggered repeatedly.

If this is the case, it could be caused by an **incorrectly configured Correlation rule causing a loop**. Check your Correlation rules and adjust them to avoid such loops.

### SLNetClientTest tool

The [SLNetClientTest tool](xref:SLNetClientTest_tool_advanced_procedures) is an advanced system administration tool. You should always **be extremely careful when using this tool**, as it can have far-reaching consequences for the functionality of your DataMiner System. If you do not feel comfortable using this tool, leave this to tech support.

In the SLNetClientTest tool, after you have [connected to the DMA](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool), go to *Diagnostics > SLNet > Stacksizes* and check the output.

When you see a high number in the Correlation thread, this typically means something is blocking the thread. As mentioned above, this could be a Correlation rule with a delay (because the Sleep function is used), which is repeatedly getting triggered.

If the high Correlation thread issue persists, check this value on all DMAs in the cluster. After you have generated the Stacksizes message, right-click it in the list on the *Properties* tab, select *View across cluster*, and filter on Correlation. This can help you pinpoint the root cause.
