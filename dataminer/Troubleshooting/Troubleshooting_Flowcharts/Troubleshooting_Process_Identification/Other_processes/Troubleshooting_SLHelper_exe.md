---
uid: Troubleshooting_SLHelper_exe
---

# SLHelper.exe

## About SLHelper

### Functions of SLHelper

These are the main functions of *SLHelper.exe*:

- Rendering Visual Overview pages for the Monitoring and Dashboards apps (see [Troubleshooting – web](xref:Investigating_Web_Issues)).

- Prior to DataMiner web 10.4.0 [CU20]/10.5.0 [CU8]/10.5.11, converting documents to PDF in the Reports, Dashboards, and Jobs apps (see [Troubleshooting – web](xref:Investigating_Web_Issues)).

- Executing queries for Dashboards via the Generic Query Interface (GQI) (see [Troubleshooting – web](xref:Investigating_Web_Issues)).

- Running Best Practice Analyzer (BPA) tests.

### General information

Unlike other DataMiner processes, SLHelper is not running constantly. An instance of the process is created when a certain task requires SLHelper. A separate instance is created for each type of the task, e.g. for rendering a Visual Overview page and running a GQI query. When all tasks are completed, the process is terminated after an inactivity timeout.

SLHelper is often updated in new DataMiner builds. Before you report an issue to software development teams, check if the issue is present in the latest DataMiner release.

### Typical problems

- High memory usage. This should be expected if large Visual Overview pages, queries, or reports are processed.

- Memory leaks are possible if Visual Overview pages are constantly used.

- Timeouts are possible when large queries, reports or Visual Overview pages are processed.

### Logging

The process does not have a dedicated log file. However, since SLHelper is started by SLNet, logging can be found in *SLHelperWrapper.txt*. Depending on your use case, you can check the following additional log files:

- *SLUIProvider.txt*: Check this log file to check for Visual Overview issues. Search for "Log:" and "visio" for relevant information.

- *SLASPConnection.txt*: Check this log file for issues with DataMiner reports.

- *SLBPAManager.txt*: Check this log file for BPA-related issues.

- *SLHelperCrash.txt*: Check this log file for information on crashes.

For the GQI, there is no dedicated log file, but you can find error information in API responses using the Developer Console of a browser (see [Investigating web issues](xref:Investigating_Web_Issues)).

> [!NOTE]
> To enable logging of information required for an investigation, make sure you set the log level to "Log Everything (5) ". For more information, see [DataMiner logging](xref:DataMiner_logging).

## SLHelper troubleshooting flowchart

```mermaid
flowchart TD
%% Define blocks %%
LinkRootCause([To root cause flowchart])
LinkProcessList([To process identification])
Start[SLHelper problem suspected]
Function{{Which functionality is failing?}}
VisioKnown[See notes for known limitations/problems.]
VisioLogs[Check SLUIProvider.txt to find the page causing the problem.]
VisioCube{{Is the same page shown correctly in Cube?}}
VisioSave[Save the .vsdx file and SLUIProvider.txt log, and export the element.]
VisioFix[No issue in SLHelper. Fix errors in .vsdx file.]
GqiDevConsole[Check the Developer Console in your browser.]
GqiCheckRequest{{Is the API query valid?}}
GqiCheckResponse{{Is the response from the server valid?}}
GqiServerIssue[No issue in SLHelper. Check for origin of invalid data.]
GqiSave[Save a recording of the GQI session.]
GqiClientIssue([Report a client-side issue.])
BpaLogs[Check SLBPAManager.txt for more information.]
PdfLogs[Check SLASPConnection.txt to find the report causing the problem.]
PdfCheckHtml{{Is the HTML version of the report correct?}}
PdfReportsIssue([Check the Reporter flowchart.])
PdfErrors{{Are there errors in the output?}}
PdfModule[Identify the report module causing the error. Reproduce the issue with a simple report.]
PdfSave[Save the error message and describe the minimum report configuration to reproduce the issue.]
PdfTimeouts[Report may fail or time out if a very large data set is processed.]
PdfOptimize[Optimize the report to reduce the volume of data.]
EndReportIssue([Describe the issue in detail and contact Software Development.])
%% Connect blocks %%
Start --- Function
Function --- |Visual Overview|VisioKnown
Function --- |Query Interface|GqiDevConsole
Function --- |PDF reports| PdfLogs
Function --- |BPA| BpaLogs
BpaLogs -------- EndReportIssue
VisioKnown --- VisioLogs
VisioLogs --- VisioCube
VisioCube --- |NO| VisioFix
VisioCube ---- |YES| VisioSave
VisioSave --- EndReportIssue
GqiDevConsole --- GqiCheckRequest
GqiCheckRequest --- |YES| GqiCheckResponse
GqiCheckRequest --- |NO| GqiClientIssue
GqiCheckResponse ---- |NO errors, but data is invalid| GqiServerIssue
GqiCheckResponse ----- |Error message, NO data or NO response| GqiSave
GqiCheckResponse --- |Response is valid, but data is shown incorrectly in client| GqiClientIssue
GqiSave --- EndReportIssue
PdfLogs --- PdfCheckHtml
PdfCheckHtml --- |NO| PdfReportsIssue
PdfCheckHtml --- |YES| PdfErrors
PdfErrors ----- |YES| PdfModule
PdfModule --- PdfSave
PdfErrors --- |NO output is generated| PdfTimeouts
PdfTimeouts --- PdfOptimize
PdfSave --- EndReportIssue
%% Define hyperlinks %%
click LinkRootCause "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Root Cause Flowchart"
click LinkProcessList "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Troubleshooting_Process_Identification.html" "Go to process identification page"
click VisioKnown "#known-limitations-of-visual-overview-in-web-apps" "Known limitations"
click VisioLogs "#logging" "More on logging"
click GqiDevConsole "#using-the-developer-console-in-a-browser" "Using Developer Console"
click GqiSave "#recording-a-gqi-session" "How to record a GQI session"
click PdfLogs "#logging" "More on logging"
click PdfReportsIssue "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Other_processes/Troubleshooting_SLASPConnection_exe.html" "Go to Reporter flowchart"
click BpaLogs "#logging" "More on logging"
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
%% Apply styles to blocks %%
class Start,EndReportIssue,GqiClientIssue classTerminal;
class Function,VisioCube,GqiCheckRequest,GqiCheckResponse,PdfErrors,PdfCheckHtml classDecision;
class VisioSave,PdfModule,PdfSave,PdfTimeouts classAction;
class VisioFix,GqiServerIssue,PdfOptimize classSolution;
class VisioKnown,VisioLogs,GqiDevConsole,GqiSave,PdfLogs,BpaLogs classActionClickable;
class LinkRootCause,LinkProcessList,PdfReportsIssue classExternalRef;
```
