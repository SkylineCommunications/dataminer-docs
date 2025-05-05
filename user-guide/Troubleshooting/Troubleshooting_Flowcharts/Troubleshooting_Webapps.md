---
uid: Troubleshooting_Webapps
---

# Troubleshooting - web apps

When troubleshooting an issue in the DataMiner web apps, you should always [create a recording using the Web Support Assistant](xref:Web_Issues_Support_Assistant).

Once this has been done, you can then troubleshoot the issue as detailed below.

```mermaid
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
%% Define blocks %%
START{{Do queries seem to be missing in the recording?}}
Adhocdatasource{{Are they ad hoc data sources?}}
ScriptCompiles{{Check if the script compiles}}
LicenseAvailable{{Check if the required license for built-in data sources is available}}
MissingComponents{{Are components or data sources missing that should be available in edit mode?}}
CheckSoftLaunch{{Check the software version and soft-launch options and upgrade or configure as necessary}}
KnownIssue{{Does the software version used contain this known issue?}}
UpgradeToFix{{Upgrade to a version that fixes the issue}}
LoadingIssues{{In the console logs, can you see loading issues or a Service Unavailable error?}}
IISRunning{{Is the IIS web server running?}}
CheckCloudConnection{{Check the connection to dataminer.services}}
RestartIIS{{Restart IIS}}
FailingCalls{{Are any network calls failing, e.g. GetVisioForElement?}}
CheckErrorMessage{{Check the error message and try to determine the source, which could be the web APIs or the core software}}
CheckConsoleErrors{{Check if there are console errors that indicate an issue in the client web app, and contact <a href="mailto:support.data-exploration@skyline.be">support.data-exploration@skyline.be</a> to report the issue}}
%% Connect blocks %%
START --- |Yes|Adhocdatasource
START --- |No|MissingComponents
Adhocdatasource --- |Yes|ScriptCompiles
Adhocdatasource --- |No|LicenseAvailable
MissingComponents --- |Yes|CheckSoftLaunch
MissingComponents --- |No|KnownIssue
KnownIssue --- |Yes|UpgradeToFix
KnownIssue --- |No|LoadingIssues
LoadingIssues --- |Yes|IISRunning
LoadingIssues --- |No|FailingCalls
IISRunning --- |Yes|CheckCloudConnection
IISRunning --- |No|RestartIIS
FailingCalls --- |Yes|CheckErrorMessage
FailingCalls --- |No|CheckConsoleErrors
%% Define hyperlinks %%
click CheckCloudConnection "/user-guide/Troubleshooting/Procedures/Cloud_Connection_Issues.html" "dataminer.services troubleshooting"
%% Apply styles to blocks %%
class START classTerminal;
class Adhocdatasource,MissingComponents,KnownIssue,LoadingIssues,IISRunning,FailingCalls classDecision;
%%class classExternalRef;
class CheckCloudConnection,CheckConsoleErrors classActionClickable;
class ScriptCompiles,LicenseAvailable,CheckSoftLaunch,UpgradeToFix,RestartIIS,CheckErrorMessage classAction;
```
