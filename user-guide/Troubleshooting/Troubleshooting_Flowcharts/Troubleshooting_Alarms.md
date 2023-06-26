---
uid: Troubleshooting_Alarms
---

# Troubleshooting - alarms

> [!NOTE]
>
> - This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.
> - If you need more information on how to execute any of the steps below, feel free to reach out to [support.data-insights@skyline.be](mailto:support.data-insights@skyline.be).
> - You can leave feedback using the [*issues* feature](xref:contributing#reporting-an-issue), or [propose a change](xref:contributing).

## Alarms

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
START([Alarm issue])
GetDELT{{Get a .dmimport package with alarm data,\nunzip it and check the 'Database' folder.}}
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
</div>

> [!NOTE]
>
> At any step of this flowchart:
>
> - your investigation may be complete.
> - you may need to check the log information in *SLErrors.txt*, *SLWatchDog2.txt*, *SLDBConnection.txt*, or the element logging.

### Retrieval Issue

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
RetrievalIssue([Retrieval issue])
FollowCTT{{"Follow your session with the client test tool and\ntry to retrieve the (history) alarm with your alarm console."}}
RetrievalIssueChecks{{"Do you get valid AlarmEventMessages?"}}
ClientSide{{"Check Cube Logging for exceptions.\nLook for AlarmEventMessage in stacktrace."}}
ServerSide{{"Check SLDBConnection / SLNet / Database logging.\nCheck if database can be reached."}}
AlarmTTL{{"Check the Time to Live of your Alarm.\nIn MySQL & Cassandra: table 'Alarm'.\nIn Cassandra Cluster & Elastic: table 'Alarms'."}}
NotFixed{{"If your issue is not fixed,\ncontact support.data-insights@skyline.be.\nInclude all gathered information and steps taken."}}
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
</div>

### Creation Issue

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
CreationIssue([Creation issue])
AlarmTemplate{{"Check alarm template configuration."}}
ProtocolDebug{{"Use the protocol debug tool to simulate.\nClick the node to go the relevant docs page."}}
CanSimulate{{"Managed to simulate?"}}
ReduceFeatures{{"Reduce the number of features used to\nnarrow down the issue.\n(e.g. Hysteresis, conditional monitoring...)\nClick the node to go to a relevant docs page."}}
VerifyConfiguration{{"Verify if you have a clear issue,\nincorrect configuration or undefined behavior."}}
NotFixedCOPS{{"Contact techsupport@skyline.be.\nInclude all gathered information and steps taken."}}
ExtraInfoNotFixed{{"1. Check if the behavior is the same on a\nstandalone parameter, column parameter, matrix parameter...\n2. Check the element logging.\n3. Contact support.data-insights@skyline.be.\nInclude all gathered information and steps taken."}}
%% Connect blocks %%
CreationIssue --- AlarmTemplate
AlarmTemplate --- ProtocolDebug
ProtocolDebug --- CanSimulate
CanSimulate --- |Yes|ReduceFeatures
ReduceFeatures --- VerifyConfiguration
VerifyConfiguration --- |Not a configuration issue|NotFixedCOPS
CanSimulate --- |No|ExtraInfoNotFixed
%% Define hyperlinks %%
click ProtocolDebug "/user-guide/Reference/DataMiner_Tools/
Protocol_Debug_Tools.html"
click ReduceFeatures "/user-guide/Basic_Functionality/Protocols_and_templates/Alarm_templates/Configuring_alarm_templates/About_the_alarm_template_editor.html"
%% Apply styles to blocks %%
class CreationIssue classTerminal;
class AlarmConsole,Surveyor,Apps,Trending,ProtocolDebug,ReduceFeatures classExternalRef;
%%class classActionClickable;
class AlarmTemplate classAction;
class DataPresent,CanSimulate,VerifyConfiguration classDecision;
class ExtraInfoNotFixed,NotFixedCOPS classSolution;
</div>
