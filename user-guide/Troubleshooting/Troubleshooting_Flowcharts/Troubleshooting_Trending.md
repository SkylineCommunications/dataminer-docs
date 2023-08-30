---
uid: Troubleshooting_Trending
---

# Troubleshooting - trending

> [!NOTE]
>
> - This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.
> - If you need more information on how to execute any of the steps below, feel free to reach out to [support.data-insights@skyline.be](mailto:support.data-insights@skyline.be).
> - You can leave feedback using the [*issues* feature](xref:contributing#reporting-an-issue), or [propose a change](xref:contributing).

## Trending

### Overview

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
START([Trend issue])
GetDELT{{Get a .dmimport package with trend data,\nunzip it and check the 'Database' folder.}}
TrendDataInspector{{"Check the data with the trend data inspector."}}
QueryDatabase{{Query the database directly.}}
DataPresent([Is the data there?])
ReadIssue([Read issue])
WriteIssue([Write issue])
%% Connect blocks %%
START --- GetDELT
START --- TrendDataInspector
START --- QueryDatabase
GetDELT --- DataPresent
QueryDatabase --- DataPresent
TrendDataInspector --- DataPresent
DataPresent --- |Yes|ReadIssue
DataPresent --- |No|WriteIssue
%% Define hyperlinks %%
click TrendDataInspector "/user-guide/Reference/DataMiner_Tools/SLNetClientTest_tool/SLNetClientTest_tool_diagnostic_procedures/SLNetClientTest_trend_data_inspector.html"
click ReadIssue "#read-issue" "Trending"
click WriteIssue "#write-issue" "Trending"
%% Apply styles to blocks %%
class START classTerminal;
class AlarmConsole,Surveyor,Apps,Trending classExternalRef;
%%class classActionClickable;
class GetDELT,TrendDataInspector,QueryDatabase,FollowCTT,ReadIssueChecks,ClientExport,WriteIssueActionLogging,WriteIssueActionDBXML,WriteIssueActionTrendTemplate,WriteIssueActionParameter classAction;
class DataPresent classDecision;
class NotFixed classSolution;
class ReadIssue,WriteIssue classExternalRef;
</div>

### Read Issue

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
ReadIssue([Read issue])
FollowCTT{{Follow your session with the client test tool and open the trend graph.}}
ClientExport{{1. Turn on computer setting for trend debug\n2. Open trend\n3. On the trend timeline, do CTRL + ALT + SHIFT + Right click}}
ReadIssueChecks{{"1. Check trend template flags (find your parameter in the element protocol)\n2. Check the export and/or GetTrendDataMessage requests and responses\n3.Check user settings ('show most detailed data', range settings...)"}}
NotFixed{{"If your issue is not fixed,\ncontact support.data-insights@skyline.be,\nincluding all info gathered and steps taken."}}
%% Connect blocks %%
ReadIssue --- FollowCTT
ReadIssue --- ClientExport
ClientExport --- ReadIssueChecks
FollowCTT --- ReadIssueChecks
ReadIssueChecks --- NotFixed
%% Define hyperlinks %%
%% Apply styles to blocks %%
class ReadIssue classTerminal;
class AlarmConsole,Surveyor,Apps,Trending classExternalRef;
%%class classActionClickable;
class GetDELT,TrendDataInspector,QueryDatabase,FollowCTT,ReadIssueChecks,ClientExport,WriteIssueActionLogging,WriteIssueActionDBXML,WriteIssueActionTrendTemplate,WriteIssueActionParameter classAction;
class DataPresent classDecision;
class NotFixed classSolution;
</div>

> [!NOTE]
>
> - For more information on trend logging, see [Debug settings](xref:Computer_settings#debug-settings).
> - For more information on following a Cube session via the SLNetClientTest tool, see [Tracking DMA communication](xref:SLNetClientTest_tracking_dma_communication). Tracking the requests and responses should be sufficient.

### Write Issue

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
WriteIssue([Write issue])
NotFixed{{"If your issue is not fixed,\ncontact support.data-insights@skyline.be,\nincluding all info gathered and steps taken."}}
WriteIssueActionLogging{{"Check Logging: SLDBConnection, SLNet, <br>NATS, SLMessageBroker_SLNet.\nLook for errors/exceptions/status messages."}}
WriteIssueActionDBXML{{"Check DB.xml."}}
WriteIssueActionTrendTemplate{{"Check trend template flags."}}
WriteIssueActionParameter{{"Check if parameter value is updating."}}
%% Connect blocks %%
WriteIssue --- WriteIssueActionLogging
WriteIssue --- WriteIssueActionDBXML
WriteIssue --- WriteIssueActionTrendTemplate
WriteIssue --- WriteIssueActionParameter
WriteIssueActionLogging --- NotFixed
WriteIssueActionDBXML --- NotFixed
WriteIssueActionTrendTemplate --- NotFixed
WriteIssueActionParameter --- NotFixed
%% Define hyperlinks %%
%% Apply styles to blocks %%
class WriteIssue classTerminal;
class AlarmConsole,Surveyor,Apps,Trending classExternalRef;
%%class classActionClickable;
class GetDELT,TrendDataInspector,QueryDatabase,FollowCTT,ReadIssueChecks,ClientExport,WriteIssueActionLogging,WriteIssueActionDBXML,WriteIssueActionTrendTemplate,WriteIssueActionParameter classAction;
class DataPresent classDecision;
class NotFixed classSolution;
</div>
