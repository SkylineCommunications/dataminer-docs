---
uid: Troubleshooting_SLDataGateway_exe
---

# SLDataGateway.exe

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

From DataMiner version 9.0 onwards, this process calculates the average trending information. If a Cassandra database is installed, this process also handles the following:

- All communication with Cassandra (communication with legacy databases happens via SLElement).

- The building of time traces, used for heat maps.

- Transfer of data to the SLAnalytics process.

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% Cassandra flowchart - Nodetool Status
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
HOME([Start page]):::classExternalRef
START([SLDataGateway]):::classTerminal
Action_HighMemory([High Memory Consumption]):::classExternalRef
Action_DataMinerNotStarting([DataMiner Not Starting up]):::classExternalRef
Action_DataMinerCrash([DataMiner crash]):::classExternalRef
Action_SLDataGatewayCrash([SLDataGateway crash]):::classExternalRef
Action_HighCPUUtilization([High CPU Utilization]):::classExternalRef
    START --- Action_HighMemory
    START --- Action_DataMinerNotStarting
    START --- Action_DataMinerCrash
    START --- Action_SLDataGatewayCrash
    START --- Action_HighCPUUtilization
%% -------------------------------------------------------------------------
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click Action_HighMemory "#option-1-high-memory-consumption"
click Action_DataMinerNotStarting "#option-2-dataminer-not-starting-up"
click Action_DataMinerCrash "#option-3-dataminer-crash"
click Action_SLDataGatewayCrash "#option-4-sldatagateway-crash"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
</div>

### Option 1: high memory consumption

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% Cassandra flowchart - Nodetool Status
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
Action_HighMemory([High Memory Consumption]):::classExternalRef
Action_OffloadFolder([Check if Offload folder <br>contains files]):::classExternalRef
Action_ElementsBigAlarms([Check for elements using<br> big alarm templates <br>or trend templates]):::classExternalRef
Action_AlarmCondition[Lookup for Alarm condition]:::classSolution
Action_CheckAVGtrending([Check Avg trending <br>on DVE elements<br> while Central Database <br>is enabled]):::classExternalRef
Action_TimetraceTable(["Confirm TimeTrace table <br>creation/modification"]):::classExternalRef
Action_AlarmTemplates(["Check for Alarm templates<br> with smart baselines <br>(enabled) (from QandA)"]):::classExternalRef
    Action_HighMemory --- Action_OffloadFolder
    Action_HighMemory --- Action_ElementsBigAlarms --- Action_AlarmCondition
    Action_HighMemory --- Action_CheckAVGtrending
    Action_HighMemory --- Action_TimetraceTable
    Action_HighMemory --- Action_AlarmTemplates
%% -------------------------------------------------------------------------
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
%% -------------------------------------------------------------------------
</div>

### Option 2: DataMiner not starting up

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% Cassandra flowchart - Nodetool Status
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
Action_DataMinerNotStarting([DataMiner Not Starting up]):::classExternalRef
Action_CentralDB([Confirm Central DB tag is present]):::classExternalRef
Action_ErrorLogging(["Error logging: Check CoCreateInstance SLXML<br> failed with Server execution failed. (hr = 0x80080005)"]):::classExternalRef
    Action_DataMinerNotStarting --- Action_CentralDB
    Action_DataMinerNotStarting --- Action_ErrorLogging
%% -------------------------------------------------------------------------
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
</div>

### Option 3: DataMiner crash

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% Cassandra flowchart - Nodetool Status
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
Action_DataMinerCrash([DataMiner <br>crash]):::classExternalRef
Action_CrashSLDataGateway(["Check SLDatagateway <br>memory usage (trending graphs)"]):::classExternalRef
Action_CrashSLDataGatewayLeakRestartYes([Restart DataMiner]):::classExternalRef
Action_CrashSLDataGatewayLeakRestartYes2(["Set an Alarm Template for DMA MS platform element <br>with 2 thresholds for SLDatagateway <br> memory usage (e.g. major alarm <br> for 3Gb and a critical alarm  for 5Gb )<br>and a correlation rule to send email notification<br> to your squad to get memory dumps <br>before Dataminer chashes and restart is needed"]):::classExternalRef
Action_CrashSLDataGatewayLeakRestartNo([Run SLLogcollector with SLDGW memory dump.<br>If its possible run it twice with at least <br>500Mb size difference]):::classExternalRef
Action_CrashSLDataGatewaySpider[After both memory dumps <br>are available send it <br>to Spider Squad]:::classSolution
Decision_CrashSLDataGatewayLeak{{Is there a SLDataGateway <br>memory leak?}}:::classExternalRef
Decision_CrashSLDataGatewayLeakRestart{{DataMiner <br>restart needed?}}:::classExternalRef
    Action_DataMinerCrash --- Action_CrashSLDataGateway --- Decision_CrashSLDataGatewayLeak
    Decision_CrashSLDataGatewayLeak --- |YES| Decision_CrashSLDataGatewayLeakRestart
    Decision_CrashSLDataGatewayLeakRestart --- |YES| Action_CrashSLDataGatewayLeakRestartYes
    Decision_CrashSLDataGatewayLeakRestart --- |NO| Action_CrashSLDataGatewayLeakRestartNo
    Action_CrashSLDataGatewayLeakRestartYes --- Action_CrashSLDataGatewayLeakRestartYes2 --- Action_CrashSLDataGatewaySpider
    Action_CrashSLDataGatewayLeakRestartNo --- Action_CrashSLDataGatewaySpider
%% -------------------------------------------------------------------------
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
</div>

### Option 4: SLDataGateway crash

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% Cassandra flowchart - Nodetool Status
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
%% -------------------------------------------------------------------------
%% flowchart structure
%% -------------------------------------------------------------------------
Action_SLDataGatewayCrash([SLDataGateway crash]):::classExternalRef
Action_SLDataGatewayCrashOverflow(["Error Type: StackOverflowException -><br> Check for large number of logger tables"]):::classExternalRef
Action_SLDataGatewayCrashAfterUpgrade([Occurred after a DM upgrade?]):::classExternalRef
Action_SLDataGatewayCrashAfterUpgrade2[Compare SLDataGateway files with a working agent or standard package]:::classSolution
    Action_SLDataGatewayCrash --- Action_SLDataGatewayCrashAfterUpgrade --- Action_SLDataGatewayCrashAfterUpgrade2
    Action_SLDataGatewayCrash --- Action_SLDataGatewayCrashOverflow
%% -------------------------------------------------------------------------
%% all blocks terminating at a common End?
%% -------------------------------------------------------------------------
%% -------------------------------------------------------------------------
%% Define hyperlinks %%
%% -------------------------------------------------------------------------
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
%% -------------------------------------------------------------------------
%% Apply styles to blocks
%% -------------------------------------------------------------------------
</div>
