---
uid: Troubleshooting_Services
---

# Troubleshooting - Services

> [!NOTE]
>
> - This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.
> - If you need more information on how to execute any of the steps below, feel free to reach out to [support.data-insights@skyline.be](mailto:support.data-insights@skyline.be).
> - You can leave feedback using the [*issues* feature](xref:contributing#reporting-an-issue), or [propose a change](xref:contributing).

## Services

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
START([Service issue])
GetDELT{{Get a .dmimport package.\nCheck the service configuration.}}
HostInfo{{Is the host of the service the same or different from the element?\nFind this by editing the service/element, where you can find the 'DMA:' setting.}}
DifferentHost([Check the service folder.\nCheck the RemoteService folder.])
SameHost{{"Compare the service impact (alarm property) \nvs\nthe service state (surveyor/card)."}}
DMAsDisconnected{{Are the DMAs disconnected?}}
SyncCheck{{Run Sync Check tool.\nClick node to see how.\nInvestigate why the DMAs are disconnected.}}
NotFixed{{"If your issue is not fixed,\ncontact support.data-insights@skyline.be.\nInclude all gathered information and steps taken."}}
ImpactOrStateIssue{{Service impact or state issue?}}
StateIssue{{Check SLElement service states in\nClient Test Tool => Diagnostics => DMA.\nCheck __service_'serviceName'.txt logging.}}
ImpactIssue{{Are there duplicate display keys\nfrom partially included elements?}}
NotFixedProtocolIssue{{Rows should have unique display keys.\nContact the author of your element's connector.}}
IsolateIssue{{Try to isolate and simulate the actual issue.\ne.g. if the elements are partially included\ncheck if it also happens with full inclusion.\ne.g. does the issue occur on \nstandalone or column parameters?}}
Alarms{{If your issue is not resolved,\nclick this node to go to the alarm flow.}}
%% Connect blocks %%
START --- GetDELT
GetDELT --- HostInfo
HostInfo --- |Different|DifferentHost
HostInfo --- |Same|SameHost
DifferentHost --- DMAsDisconnected
DMAsDisconnected --- |No|SameHost
DMAsDisconnected --- |Yes|SyncCheck
SyncCheck --- NotFixed
SameHost --- ImpactOrStateIssue
ImpactOrStateIssue --- |State|StateIssue
ImpactOrStateIssue --- |Impact|ImpactIssue
StateIssue --- NotFixed
ImpactIssue --- |Yes|NotFixedProtocolIssue
ImpactIssue --- |No|IsolateIssue
IsolateIssue --- Alarms
%% Define hyperlinks %%
click SyncCheck "/user-guide/Reference/DataMiner_Tools/Sync_Check.html"
click Alarms "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Alarms.html"
%% Apply styles to blocks %%
class START classTerminal;
class ServiceConsole,Surveyor,Apps,Trending,SyncCheck,Alarms classExternalRef;
%%class classActionClickable;
class GetDELT,DifferentHost,SameHost,StateIssue,IsolateIssue classAction;
class HostInfo,DMAsDisconnected,ImpactOrStateIssue,ImpactIssue classDecision;
class NotFixed,NotFixedProtocolIssue classSolution;
</div>

> [!NOTE]
>
> At any step of this flowchart:
>
> - your investigation may be complete.
> - you may need to check the log information in *SLErrors.txt*, *SLWatchDog2.txt*, *SLDBConnection.txt*, the element logging or the *\_\_service\_\<serviceName\>.txt* logging on each DMA.