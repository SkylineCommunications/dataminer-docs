---
uid: Troubleshooting_Alarms
---

# Troubleshooting - alarms

> [!NOTE]
>
> - This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.
> - If you need more information on how to execute any of the steps below, feel free to reach out to [support.data-core@skyline.be](mailto:support.data-core@skyline.be).
> - You can leave feedback using the [*issues* feature](xref:CTB_Reporting_Issue), or [propose a change](xref:contributing).

## Alarms

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
START([Alarm issue])
GetDELT{{Get a .dmimport package with alarm data, unzip it and check the 'Database' folder.}}
DataPresent([Is the data there?])
CreationIssue([Creation issue])
RetrievalIssue([Retrieval issue])
%% Connect blocks %%
START --- GetDELT
GetDELT --- DataPresent
DataPresent --- |Yes|RetrievalIssue
DataPresent --- |No|CreationIssue
%% Define hyperlinks %%
click RetrievalIssue "#retrieval-issue" "Alarms"
click CreationIssue "#creation-issue" "Alarms"
%% Apply styles to blocks %%
class START classTerminal;
class AlarmConsole,Surveyor,Apps,Trending,CreationIssue,RetrievalIssue classExternalRef;
%%class classActionClickable;
class GetDELT classAction;
class DataPresent classDecision;
```

> [!NOTE]
>
> At any step of this flowchart:
>
> - your investigation may be complete.
> - you may need to check the log information in *SLErrors.txt*, *SLWatchDog2.txt*, *SLDBConnection.txt*, or the element logging.

### Retrieval Issue

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
RetrievalIssue([Retrieval issue])
FollowCTT{{"Follow your session with the client test tool and try to retrieve the (history) alarm with your Alarm Console."}}
RetrievalIssueChecks{{"Do you get valid AlarmEventMessages?"}}
ClientSide{{"Check Cube Logging for exceptions. Look for AlarmEventMessage in stacktrace."}}
ServerSide{{"Check SLDBConnection / SLNet / Database logging. Check if database can be reached."}}
AlarmTTL{{"Check the Time to Live of your Alarm. In MySQL & Cassandra: table 'Alarm'. In Cassandra Cluster & Elastic: table 'Alarms'."}}
NotFixed{{"If your issue is not fixed, contact <a href="mailto:support.data-core@skyline.be">support.data-core@skyline.be</a>. Include all gathered information and steps taken."}}
%% Connect blocks %%
RetrievalIssue --- FollowCTT
FollowCTT --- RetrievalIssueChecks
RetrievalIssueChecks --- |Yes|ClientSide
RetrievalIssueChecks --- |No|ServerSide
ServerSide --- AlarmTTL
ClientSide --- NotFixed
AlarmTTL --- NotFixed
%% Define hyperlinks %%
%% Apply styles to blocks %%
class RetrievalIssue classTerminal;
class AlarmConsole,Surveyor,Apps,Trending classExternalRef;
%%class classActionClickable;
class FollowCTT,ClientSide,ServerSide,AlarmTTL classAction;
class RetrievalIssueChecks classDecision;
class NotFixed classSolution;
```

> [!NOTE]
> To investigate an alarm retrieval issue, usually a LogCollector package is needed with memory dumps of SLDataGateway and SLNet.

### Creation Issue

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
CreationIssue([Creation issue])
AlarmTemplate{{"Check alarm template configuration."}}
ProtocolDebug{{"Use the protocol debug tool to simulate. Click the node to go the relevant docs page."}}
CanSimulate{{"Managed to simulate?"}}
ReduceFeatures{{"Reduce the number of features used to narrow down the issue. (e.g. Hysteresis, conditional monitoring...) Click the node to go to a relevant docs page."}}
VerifyConfiguration{{"Verify if you have a clear issue, incorrect configuration or undefined behavior."}}
NotFixedCOPS{{"Contact <a href="mailto:support@dataminer.services">support@dataminer.services</a>. Include all gathered information and steps taken."}}
ExtraInfoNotFixed{{"1\. Check if the behavior is the same on a standalone parameter, column parameter, matrix parameter... <br>2\. Check the element logging. <br>3\. Contact <a href="mailto:support.data-core@skyline.be">support.data-core@skyline.be></a>. Include all gathered information and steps taken."}}
%% Connect blocks %%
CreationIssue --- AlarmTemplate
AlarmTemplate --- ProtocolDebug
ProtocolDebug --- CanSimulate
CanSimulate --- |Yes|ReduceFeatures
ReduceFeatures --- VerifyConfiguration
VerifyConfiguration --- |Not a configuration issue|NotFixedCOPS
CanSimulate --- |No|ExtraInfoNotFixed
%% Define hyperlinks %%
click ProtocolDebug "/dataminer/Reference/DataMiner_Tools/
Protocol_Debug_Tools.html"
click ReduceFeatures "/dataminer/Operator_guide/Protocols_and_templates/Alarm_templates/Configuring_alarm_templates/About_the_alarm_template_editor.html"
%% Apply styles to blocks %%
class CreationIssue classTerminal;
class AlarmConsole,Surveyor,Apps,Trending,ProtocolDebug,ReduceFeatures classExternalRef;
%%class classActionClickable;
class AlarmTemplate classAction;
class DataPresent,CanSimulate,VerifyConfiguration classDecision;
class ExtraInfoNotFixed,NotFixedCOPS classSolution;
```

> [!NOTE]
> To investigate an alarm creation issue, usually a LogCollector package is needed with memory dumps of SLProtocol, SLElement, and SLDataMiner.
