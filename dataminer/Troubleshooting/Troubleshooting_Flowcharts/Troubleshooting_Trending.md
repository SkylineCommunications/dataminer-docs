---
uid: Troubleshooting_Trending
---

# Troubleshooting - trending

> [!NOTE]
>
> - This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.
> - If you need more information on how to execute any of the steps below, feel free to reach out to [support.data-core@skyline.be](mailto:support.data-core@skyline.be).
> - You can leave feedback using the [*issues* feature](xref:CTB_Reporting_Issue), or [propose a change](xref:contributing).

## Trending

### Overview

```mermaid
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
GetDELT{{Get a .dmimport package with trend data, unzip it and check the 'Database' folder.}}
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
click TrendDataInspector "/dataminer/Reference/DataMiner_Tools/SLNetClientTest_tool/SLNetClientTest_tool_diagnostic_procedures/SLNetClientTest_trend_data_inspector.html"
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
```

### Read Issue

```mermaid
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
ClientExport{{1\. Turn on computer setting for trend debug<br>2\. Open trend<br>3\. On the trend timeline, press Ctrl + Alt + Shift + Right-click}}
ReadIssueChecks{{"1\. Check trend template flags (find your parameter in the element protocol)<br>2\. Check the export and/or GetTrendDataMessage requests and responses<br>3\. Check user settings ('show most detailed data', range settings...)"}}
NotFixed{{"If your issue is not fixed, contact <a href="mailto:support.data-core@skyline.be">support.data-core@skyline.be</a>, including all info gathered and steps taken."}}
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
```

> [!NOTE]
>
> - For more information on trend logging, see [Debug settings](xref:Computer_settings#debug-settings).
> - For more information on following a Cube session via the SLNetClientTest tool, see [Tracking DMA communication](xref:SLNetClientTest_tracking_dma_communication). Tracking the requests and responses should be sufficient.

### Write Issue

```mermaid
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
NotFixed{{"If your issue is not fixed, contact <a href="mailto:support.data-core@skyline.be">support.data-core@skyline.be</a>, including all info gathered and steps taken."}}
WriteIssueActionLogging{{"Check Logging: SLDBConnection, SLNet, NATS, SLMessageBroker_SLNet. Look for `errors/exceptions/status messages`."}}
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
```

> [!NOTE]
> If the Windows setting "fast startup" is activated on the DataMiner server, trend graphs for the server will not show a gap when it is turned off. We recommend disabling this option to make sure trending is displayed correctly.
