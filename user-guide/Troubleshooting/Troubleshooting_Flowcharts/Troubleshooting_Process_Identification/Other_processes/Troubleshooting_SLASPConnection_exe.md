---
uid: Troubleshooting_SLASPConnection_exe
---

# Reporter - SLASPConnection.exe

## About Reporter

DMS Reporter is a legacy DataMiner module that is used to generate reports showing statistical data and operational metrics. These reports can be generated on the fly, forwarded by email at regular intervals (e.g. weekly, monthly, etc.) or sent by the DataMiner Correlation or Automation modules. They can also be incorporated into existing third-party web environments. For more detailed information on this module, see [DMS Reporter](xref:reporter) in the DataMiner Help.

This page is dedicated to helping you troubleshoot issues that might be preventing the generation of legacy reports. You can request additional assistance either via our [community platform](https://community.dataminer.services/questions/) or by sending an email to [techsupport@skyline.be](mailto:techsupport@skyline.be).

### SLASPConnection

SLASPConnection is the process behind the legacy DMS reporter module. This process does not trigger a DMA restart when stopped; instead it will be started automatically.

However, note that any reports that were in the queue will no longer be generated if this process is stopped, unless report generation is triggered again after the process restart.

## Reporter troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% -------------------------------------------------------------------------
%% Define styles
%% -------------------------------------------------------------------------
linkStyle default stroke:#cccccc
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:1px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:1px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:1px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:1px;
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:1px;
classDef classStart fill:#008FFF,stroke:#3f70ba,color:#ffffff,stroke-width:1px;
classDef classInputOutput fill:#ffffff,stroke:#3f70ba,stroke-width:1px;
%% Define blocks %%
HOME([Start page])
Start([Reporter/SLASPConnection issue])
TypeofIssue{{Which kind of issue<br/>are you facing?}}
ApplicationError{{Which error appears<br/>in the application?}}
Dcom[DCOM]
ChartDirector[ChartDirector]
ReportGeneration{{Which error appears after<br/>a report is generated?}}
UrlProcessing[URL processing]
WinHTTPRequest[WinHTTPRequest error]
RequestFailure[Request failure error]
TimeoutConfig[Report fails because of timeout]
ReportTimeout(Split the report if it <br/>retrieves a lot of data.)
Process[/Affected process: SLASPConnection/]
RTE[Critical Issues flowchart]
Other[Post question on Dojo]
IssueResolved{{Issue resolved?}}
Workaround[Workaround: access<br/>reports directly via<br/>https://x.x.x.x/reports]
End([End])
%% Connect blocks %%
Start--- TypeofIssue
TypeofIssue ---|Error in<br/>Reporter application| ApplicationError
ApplicationError ---|DMS Reporter could not<br/>communicate with the DMS| Dcom
Dcom----IssueResolved
ApplicationError ---|Could not start<br/>the ChartDirector object| ChartDirector
ChartDirector --- IssueResolved
TypeofIssue---|Issue or error<br/>at report generation| ReportGeneration
ReportGeneration---|Error occurred<br/>while processing URL|UrlProcessing
UrlProcessing-----IssueResolved
ReportGeneration ---|WinHTTPRequest|WinHTTPRequest
WinHTTPRequest----IssueResolved
ReportGeneration ---|Failed to send request|RequestFailure
RequestFailure---IssueResolved
ReportGeneration ---|Report timeout|TimeoutConfig
TimeoutConfig--- ReportTimeout
ReportTimeout---IssueResolved
TypeofIssue --- |Other| Other
TypeofIssue ---|RTE, process disappearance,<br/> or memory leak| Process
Process---RTE
IssueResolved--- |Yes|End
IssueResolved--- |No|Workaround---Other
Other---End
%% Define hyperlinks %%
click HOME "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to the start page"
click RTE "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Critical_Issues/Troubleshooting_Critical_Issues_Alarm_Console.html"
click CRASH "https://community.dataminer.services/ioc-flowchart---crash/" "Crash investigation diagram"
click Dcom "#how-to-configure-dcom-manually"
click ChartDirector "#error-could-not-start-the-chartdirector-object"
click  UrlProcessing "#error-occurred-while-processing-url"
click  WinHTTPRequest "#error-could-not-create-winhttprequest-object-to-generate-e-mail-reportnot-enough-storage-is-available-to-process-this-command-0x80070008h"
click  RequestFailure "#error-failed-to-send-request-for-httpsurlreportstemplatesreportnameasp-0x80072f7dh---12157"
click  Other "https://community.dataminer.services/questions/"
click TimeoutConfig "#report-timeout"
class Other,Dcom,ChartDirector,WinHTTPRequest,RequestFailure,UrlProcessing,RTE,TimeoutConfig classActionClickable;
class TypeofIssue,ApplicationError,ReportGeneration,IssueResolved classDecision;
class Start,End classTerminal;
class ReportTimeout classSolution;
class Process classInputOutput;
class HOME,BACK classExternalRef;
</div>

## How to configure DCOM manually?

1. Go to *Start > Administrative Tools > Component Services*.

1. Expand *Component Services > Computers > My Computer > DCOM Config*.

1. Right-click *SLASPConnection*, select *Properties* and go to the *Security* tab.

1. Under *Launch and Activation Permissions*, ensure that the *Customize* radio button is selected, and click *Edit*.

1. Add either the *IIS_IUSRS* group or the *IUSR* group, and grant it the *Local Activation* permission.

1. Repeat the previous two steps for SLDMS.

1. Restart IIS (iisreset).

## Error: Could not start the ChartDirector object

To troubleshoot this issue:

1. Check if the files *aspapi.dll*, *comchartdir.dll*, *chartdir31.dll* and *chartdir.lic* are present.

1. Check the version numbers of the .dll files. They should be all equal (e.g. 3.1.0.0).

1. Register *aspapi.dll* and *comchartdir.dll* (regsvr32).

1. If registration fails with "module could not be found", make sure the following file exists: *C:\windows\System32\msvbvm60.dll*. If it does not, copy it from another computer.

1. Check the permissions on these files. Make sure everyone is allowed to "Read" / "Read and Execute" them.

If the procedure above does not resolve the issue, download the file [*chartDir-diagnostics.asp.txt*](https://community.dataminer.services/download/chartdir-diagnostics-asp-txt/), rename it to chartDir-diagnostics.asp, save it to the web server in the *Reports*/ directory, and access it through the web server. This should give some more detailed errors.

## Error occurred while processing URL

Enable debug mode by following these steps:

1. Open IIS Manager.

1. Go to *Sites* and click *Default web site*.

1. Double-click *ASP*.

1. Under *Compilation*, expand *Debugging Properties*.

1. Set *Send Errors To Browser* to *True*.

## Error: Could not create WinHTTPRequest object to generate e-mail report:Not enough storage is available to process this command. (0x80070008h)

It seems a stack related to I/O operation reached its limit, causing the creation of the WinHTTPRequest to fail. This error can be caused by the IRPStackSize registry entry being set too low. The value of the IRPStackSize influences the number of allocated bits of memory your operating system can use to do any other sort of I/O operations within the system.

Increasing the IRPStackSize can therefore solve this issue. However, note that you should be **extremely careful when editing the registry**, and you should always **make a backup** before making any changes.

To implement the change:

1. Locate and then click the following registry subkey: *HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters*

1. If the *IRPStackSize* entry is not present in this subkey, follow these steps:

   1. Click *Edit*, point to *New*, and then click *DWORD Value*.

   1. Type *IRPStackSize* (case-sensitive), and press *Enter*.

1. Click *IRPStackSize*, click *Edit*, and then click *Modify*.

1. In the *Data Value* box, specify a value between 15 and 50 (e.g. 30), and then click *OK*. Note that values between 33 and 38 are not recommended.

## Error: Failed to send request for 'https://url/Reports/Templates/ReportName.asp': (0x80072f7dh - 12157)

This error can be related to how HTTPS is configured (HTTP, TLSv1.0, TLSv1.1 is disabled). To resolve this issue, try running the easy fix from [this Microsoft support page](https://support.microsoft.com/en-au/topic/update-to-enable-tls-1-1-and-tls-1-2-as-default-secure-protocols-in-winhttp-in-windows-c4bd73d2-31d7-761e-0178-11268bb10392).

## Report timeout

By default, the SLASPConnection process is configured to wait 1 hour for a report to respond. A timeout is generated when no response is received after an hour.

When a report times out, this is most likely related to reports generating a lot of data, and the default timeout configuration might not be sufficient. To fix this, you can adjust the timeout. For more information, refer to [the DataMiner Help](xref:MaintenanceSettings_xml#slaspconnectionreportresponsetimeout).

However, keep in mind that when the default timeout is adjusted, the **report ASP setting must be adjusted as well**.
