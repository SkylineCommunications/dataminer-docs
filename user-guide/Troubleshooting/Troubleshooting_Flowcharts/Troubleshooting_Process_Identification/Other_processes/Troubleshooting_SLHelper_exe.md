---
uid: Troubleshooting_SLHelper_exe
---

# SLHelper.exe

## About SLHelper

### Functions of SLHelper

These are the main functions of *SLHelper.exe*:

- Rendering Visual Overview pages for the Monitoring and Dashboards apps.

- Converting documents to PDF in the Reports, Dashboards and Jobs apps.

- Executing queries for Dashboards via the Generic Query Interface (GQI).

- Running Best Practice Analyzer (BPA) tests.

### General information

Unlike other DataMiner processes, SLHelper is not running constantly. An instance of the process is created when a certain task requires SLHelper. A separate instance is created for each type of the task, e.g. for rendering a Visual Overview page and running a GQI query. When all tasks are completed, the process is terminated after an inactivity timeout.

SLHelper is often updated in new DataMiner builds. Before you report an issue to software development teams, check if the issue is present in the latest DataMiner release.

### Typical problems

- High memory usage. This should be expected if large Visual Overview pages, queries, or reports are processed.

- Memory leaks are possible if Visual Overview pages are constantly used.

- Timeouts are possible when large queries, reports or Visual Overview pages are processed.

### Logging

The process does not have a dedicated log file. Depending on your use case, you can check the following log files:

- *SLUIProvider.txt*: Check this log file to check for Visual Overview issues. Search for "Log:" and "visio" for relevant information.

- *SLASPConnection.txt*: Check this log file for issues with DataMiner reports.

- *SLBPAManager.txt*: Check this log file for BPA-related issues.

- *SLHelperCrash.txt*: Check this log file for information on crashes.

- For the GQI, there is no dedicated log file, but you can find error information in API responses using the Developer Console of a browser.

> [!NOTE]
> To enable logging of information required for an investigation, make sure you set the log level to "Log Everything (5) ". For more information, see [DataMiner logging](xref:DataMiner_logging).

### Known limitations of Visual Overview in web apps

Certain behavior should be expected when Visual Overview is used in web apps:

- Visual Overview pages are rendered as images with clickable regions in them. Because of this, some features like embedding and some session variable controls are not fully supported.

- To render a Visual Overview page, SLHelper loads a virtual instance of DataMiner Cube in its memory. Initial loading of a page can take a long time because SLHelper needs to start Cube, connect to a DMA, and then generate an image.

- SLHelper may use a significant amount of memory to display Visual Overview pages, especially when multiple users are connected. When Visual Overview pages are not viewed by any user, the virtual DataMiner Cube instance is terminated after a timeout of 5 minutes and the memory is released.

## SLHelper troubleshooting flowchart

<div class="mermaid">
flowchart TD
%% Define blocks %%
LinkRootCause([To root cause flowchart])
LinkProcessList([To process identification])
Start[SLHelper problem <br />suspected]
Function{{Which functionality <br/>is failing?}}
VisioKnown[See notes <br>for known<br/>limitations/problems.]
VisioLogs[Check SLUIProvider.txt<br/>to find the page<br/>causing the problem.]
VisioCube{{Is the same page shown<br/>correctly in Cube?}}
VisioSave[Save the .vsdx file and<br/> SLUIProvider.txt log,<br/> and export the element.]
VisioFix[No issue in SLHelper.<br/>Fix errors in .vsdx file.]
GqiDevConsole[Check the <br>Developer Console<br/>in your browser.]
GqiCheckRequest{{Is the API query <br>valid?}}
GqiCheckResponse{{Is the response <br>from the <br>server valid?}}
GqiServerIssue[No issue in SLHelper.<br/>Check for origin<br/>of invalid data.]
GqiSave[Save a recording<br/>of the GQI session.]
GqiClientIssue([Report a client-side<br/>issue.])
BpaLogs[Check <br>SLBPAManager.txt<br/>for more information.]
PdfLogs[Check <br>SLASPConnection.txt<br/>to find the report<br/>causing the problem.]
PdfCheckHtml{{Is the HTML <br>version of<br/>the report <br>correct?}}
PdfReportsIssue([Check the <br>Reporter<br/>flowchart.])
PdfErrors{{Are there errors<br/>in the output?}}
PdfModule[Identify the report module<br/>causing the error.<br/>Reproduce the issue with<br/>a simple report.]
PdfSave[Save the error message<br/>and describe the minimum<br/>report configuration to<br/>reproduce the issue.]
PdfTimeouts[Report may fail<br/>or time out if <br>a very large<br/>data set is processed.]
PdfOptimize[Optimize <br>the report to<br/>reduce the <br>volume of data.]
EndReportIssue([Describe the issue in detail and<br/>contact Software Development.])
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
GqiCheckResponse ---- |NO errors,<br/>but data is invalid| GqiServerIssue
GqiCheckResponse ----- |Error message,<br/>NO data or<br/>NO response| GqiSave
GqiCheckResponse --- |Response is valid, but data<br/>is shown incorrectly in client| GqiClientIssue
GqiSave --- EndReportIssue
PdfLogs --- PdfCheckHtml
PdfCheckHtml --- |NO| PdfReportsIssue
PdfCheckHtml --- |YES| PdfErrors
PdfErrors ----- |YES| PdfModule
PdfModule --- PdfSave
PdfErrors --- |NO output<br/>is generated| PdfTimeouts
PdfTimeouts --- PdfOptimize
PdfSave --- EndReportIssue
%% Define hyperlinks %%
click LinkRootCause "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html" "Go to Root Cause Flowchart"
click LinkProcessList "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Troubleshooting_Process_Identification.html" "Go to process identification page"
click VisioKnown "#known-limitations-of-visual-overview-in-web-apps" "Known limitations"
click VisioLogs "#logging" "More on logging"
click GqiDevConsole "#using-the-developer-console-in-a-browser" "Using Developer Console"
click GqiSave "#recording-a-gqi-session" "How to record a GQI session"
click PdfLogs "#logging" "More on logging"
click PdfReportsIssue "/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Process_Identification/Other_processes/Troubleshooting_SLASPConnection_exe.html" "Go to Reporter flowchart"
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
</div>

## Notes on troubleshooting

### Using the Developer Console in a browser

Press F12 to open the Developer Tools console in your browser. Select the Network tab. All information in the DataMiner web apps (e.g. Monitoring, Dashboards and Jobs) is retrieved from DataMiner via POST messages to DataMiner API.

For example, an API call GetVisioForElement is used to display a Visual Overview page.

Any errors will be returned with HTTP Status 500.

### Recording a GQI session

GQI recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment. GQI recording is disabled by default.
To create a recording:

1. Create the folder  `C:\Skyline DataMiner\logging\genif`.

1. Perform the operation that needs to be recorded.

1. Save the files written to `C:\Skyline DataMiner\logging\genif`.

1. Delete the folder to disable recording.
