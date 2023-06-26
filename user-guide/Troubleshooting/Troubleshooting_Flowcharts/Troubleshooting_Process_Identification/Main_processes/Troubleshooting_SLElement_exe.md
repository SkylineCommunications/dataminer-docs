---
uid: Troubleshooting_SLElement_exe
---

# SLElement.exe

## About SLElement

SLElement keeps track of parameter values that have to be shown to the user and also creates alarms.

This process is only aware of parameters that are being monitored and parameters that have to be displayed in the user interface.

## SLElement troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
Start[SLElement]
StartPage([Start page])
RTE{{Is there an RTE or a memory leak?}}
Watchdog[RTE troubleshooting:<br/>- Verify RTE Count = 1.<br/>- Check memory/CPU usage of SLElement.<br/>- Run collector and include memory dump.]
Threads{{Which SLDataMiner thread <br>is affected?}}
ThreadsDB[DB threads:<br/>- CentralOffloadThread<br/>- DBThread<br/>- DataGatewayParameterThread<br/>- DataGatewayTableThread<br/>- DataGatewayAlarmThread<br/>- DataGatewayElementNotifyThread]
Offload[- Check Offload DB folder for new files.<br/>- Confirm that DB connection is healthy.<br/>- Check if there are big tables that <br>might be slowing down queries.]
IssuesAfterCheck{{Any issues after check?}}
CassandraTb([Cassandra troubleshooting])
DumpDb[Run Log Collector with <br> the following dumps:<br/>- SLElement<br/>- SLProtocol<br/>- SLDataGateway<br/>]
ThreadsAlarm[Alarm threads:<br/>- AlarmThread<br/>- AlarmOffloadThread<br/>- DataMinerNotificationsThread<br/>- ClientNotificationsThread<br/>- AlarmLinkLevel]
DumpAlarm[Run Log Collector with <br> the following dumps:<br/>- SLElement<br/>- SLDataminer<br/>- SLNet<br/>]
Delt[If the issue is related to <br> a specific element, create a DELT export package <br> and make sure trend and alarm <br> data are not selected.]
SendSw[Send the collected information to the software team.]
LogCollectorSw[Run Log Collector with SLElement <br>memory dump and send <br>to the software team.]
PendingCalls[Check pending calls on the element <br>and contact the connector developer <br>to resolve the issue in a new version]
RunPending([How to run pending calls])
MemoryLeak[Check the trending on the <br>Microsoft element when <br>the memory leak started.]
LeakStart{{Can you link an event/action on <br>the DMA to when the leak started?}}
ElementActive{{Was an element activated?}}
%% Connect blocks %%
Start ----- RTE
RTE --- |RTE|Watchdog
Watchdog ----- Threads
Threads -----|DB|ThreadsDB
Threads ---|Alarm|ThreadsAlarm ----- DumpAlarm ----- Delt
ThreadsDB ----- Offload ---- IssuesAfterCheck -----|YES|CassandraTb
IssuesAfterCheck----|NO|DumpDb ----- Delt
Delt ----- SendSw
PendingCalls ---- RunPending
RTE ---|Memory leak|MemoryLeak
MemoryLeak ----- LeakStart
LeakStart ----- |YES|ElementActive
ElementActive ------ |YES|PendingCalls
LeakStart ----- |NO|LogCollectorSw
ElementActive ----- |NO|LogCollectorSw
%% Define hyperlinks %%
click StartPage "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click RunPending "https://docs.dataminer.services/develop/devguide/Connector/Howto/How_to_retrieve_protocol_pending_calls.html"
click CassandraTb "https://community.dataminer.services/troubleshooting-cassandra/"
click Delt "/user-guide/Advanced_Functionality/DataMiner_Agents/Exporting_and_importing/Exporting_elements_services_etc_to_a_dmimport_file.html"
%% Apply styles to blocks %%
class Start,LogCollectorSw,DumpAlarm,DumpDb,SendSw DarkBlue;
class Watchdog,MemoryLeak,ThreadsDB,ThreadsAlarm,Offload,PendingCalls,Delt LightGray;
class ElementRestarted,ElementStop,LeakStart,ElementActive,Threads,RTE,IssuesAfterCheck Blue;
class StartPage,RunPending,CassandraTb LightBlue;
</div>

> [!NOTE]
>
> - SLElement can consume quite a bit of memory if there are a lot of elements or if a lot of data is being monitored. As long as memory usage is stable, this is not a cause for concern.
> - SLElement also handles displayed parameters. However, not all errors related to parameters are strictly due to SLElement. Issues such as missing parameters, unavailable parameters, wrong units, or incorrect values can often be attributed to the connectors where the parameters originate. SLElement simply ensures that parameters are displayed, but it is not the source of the values.
