---
uid: Troubleshooting_Services
---

# Troubleshooting - services

> [!NOTE]
>
> - This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.
> - If you need more information on how to execute any of the steps below, feel free to reach out to [support.data-core@skyline.be](mailto:support.data-core@skyline.be).
> - For issues related to service alarms, see [Service alarm issues](#service-alarm-issues)
> - You can leave feedback using the [*issues* feature](xref:CTB_Reporting_Issue), or [propose a change](xref:contributing).

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
START([Service issue])
GetDELT{{Get a .dmimport package. Check the service configuration.}}
HostInfo{{Is the host of the service the same or different from the element? Find this by editing the service/element, where you can find the 'DMA:' setting.}}
DifferentHost([Check the service folder. Check the RemoteService folder.])
SameHost{{"Compare the service impact (alarm property) vs the service state (surveyor/card)."}}
DMAsDisconnected{{Are the DMAs disconnected?}}
SyncCheck{{Run Sync Check tool. Click node to see how. Investigate why the DMAs are disconnected.}}
NotFixed{{"If your issue is not fixed, contact <a href="mailto:support.data-core@skyline.be">support.data-core@skyline.be</a>. Include all gathered information and steps taken."}}
ImpactOrStateIssue{{Service impact or state issue?}}
StateIssue{{Check SLElement service states in Client Test Tool => Diagnostics => DMA. Check __service_'serviceName'.txt logging.}}
ImpactIssue{{Are there duplicate display keys from partially included elements?}}
NotFixedProtocolIssue{{Rows should have unique display keys. Contact the author of your element's connector.}}
IsolateIssue{{Try to isolate and simulate the actual issue. e.g., if the elements are partially included check if it also happens with full inclusion. e.g., does the issue occur on standalone or column parameters?}}
Alarms{{If your issue is not resolved, click this node to go to the alarm flow.}}
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
click SyncCheck "/dataminer/Reference/DataMiner_Tools/Sync_Check.html"
click Alarms "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Alarms.html"
%% Apply styles to blocks %%
class START classTerminal;
class ServiceConsole,Surveyor,Apps,Trending,SyncCheck,Alarms classExternalRef;
%%class classActionClickable;
class GetDELT,DifferentHost,SameHost,StateIssue,IsolateIssue classAction;
class HostInfo,DMAsDisconnected,ImpactOrStateIssue,ImpactIssue classDecision;
class NotFixed,NotFixedProtocolIssue classSolution;
```

> [!NOTE]
>
> At any step of this flowchart:
>
> - your investigation may be complete.
> - you may need to check the log information in *SLErrors.txt*, *SLWatchDog2.txt*, *SLDBConnection.txt*, the element logging, or the *\_\_service\_\<serviceName\>.txt* logging on each DMA.

## Service alarm issues

If you encounter issues related to service alarms, you will need to gather the following information from the DMAs involved and then contact [support.data-core@skyline.be](mailto:support.data-core@skyline.be):

- While the issue is active on the system, [use SLLogCollector](xref:Collecting_data_to_report_an_issue_to_TechSupport#log-collector-packages) to collect **memory dumps of the SLElement, SLDataMiner, and SLNet processes** from both the Agents hosting the affected elements and the Agent hosting the affected services.

  When you share these files, make sure to also include the **element ID and service ID**, as this will help us quickly locate the relevant information in the logs and dumps.

- Provide [a **DELT export package**](xref:Exporting_elements_services_etc_to_a_dmimport_file) that includes the alarms from the affected services and elements.

- If the service was generated from a **service template**, include the template. You can find this *Service.xml* file on the DataMiner server hosting the service template in the folder `C:\Skyline DataMiner\Services\[ServiceTemplateName]`.
