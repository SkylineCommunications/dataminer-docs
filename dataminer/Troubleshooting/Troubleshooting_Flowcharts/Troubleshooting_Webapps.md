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
START[[Do queries seem to be missing in the recording?]]
Adhocdatasource[[Are they ad hoc data sources?]]
ScriptCompiles[[Check if the <br>script compiles]]
LicenseAvailable[[Check if the required license for built-in data sources is available]]
MissingComponents[[Are components or data sources missing that should be available in edit mode?]]
CheckSoftLaunch[[Check the software version and soft-launch options and upgrade or configure as necessary]]
KnownIssue[[Does the software version used contain this known issue?]]
UpgradeToFix[[Upgrade to a version <br>that fixes the issue]]
InvisibleComponents[[Does the page contain invisible components?]]
ClearInvisibleComponents[[Clear the invisible components as <br>detailed below]]
LoadingIssues[[In the console logs, can you see loading issues or a Service Unavailable error?]]
IISRunning[[Is the IIS web <br>server running?]]
CheckCloudConnection[[Check the connection <br>to dataminer.services]]
RestartIIS[[Restart IIS]]
FailingCalls[[Are any network calls failing, e.g. GetVisioForElement?]]
CheckErrorMessage[[Check the error message and try to determine the source, which could be <br>the web APIs or the core software]]
CheckConsoleErrors[[Check if there are console errors that indicate an issue in the client web app, and contact <a href="mailto:support.data-exploration@skyline.be">support.data-exploration@skyline.be</a> <br>to report the issue]]
%% Connect blocks %%
START --- |Yes|Adhocdatasource
START --- |No|MissingComponents
Adhocdatasource --- |Yes|ScriptCompiles
Adhocdatasource --- |No|LicenseAvailable
MissingComponents --- |Yes|CheckSoftLaunch
MissingComponents ---- |No|KnownIssue
KnownIssue --- |Yes|UpgradeToFix
KnownIssue ---- |No|InvisibleComponents
InvisibleComponents --- |Yes|ClearInvisibleComponents
InvisibleComponents ---- |No|LoadingIssues
LoadingIssues --- |Yes|IISRunning
LoadingIssues --- |No|FailingCalls
IISRunning --- |Yes|CheckCloudConnection
IISRunning --- |No|RestartIIS
FailingCalls --- |Yes|CheckErrorMessage
FailingCalls --- |No|CheckConsoleErrors
%% Define hyperlinks %%
click CheckCloudConnection "/dataminer/Troubleshooting/Procedures/Cloud_Connection_Issues.html" "dataminer.services troubleshooting"
click InvisibleComponents "#dealing-with-invisible-components" "Dealing with invisible components"
click ClearInvisibleComponents "#dealing-with-invisible-components" "Dealing with invisible components"
%% Apply styles to blocks %%
class START classTerminal;
class Adhocdatasource,MissingComponents,KnownIssue,LoadingIssues,IISRunning,FailingCalls classDecision;
class InvisibleComponents classExternalRef;
class CheckCloudConnection,CheckConsoleErrors,ClearInvisibleComponents classActionClickable;
class ScriptCompiles,LicenseAvailable,CheckSoftLaunch,UpgradeToFix,RestartIIS,CheckErrorMessage classAction;
```

> [!TIP]
> For more troubleshooting information for DataMiner web apps, refer to [Troubleshooting - web](xref:Investigating_Web_Issues).

## Dealing with invisible components

In some cases, it can occur that a page in a low-code app or a dashboard contains components that are not shown but that do influence the page or dashboard, causing unexpected behavior.

To check if this is the case, do the following in the dashboard or on every page and panel of the low-code app:

1. Press Ctrl + A and then press Delete.

1. Count the components mentioned in the dialog to see if they match the shown components, and then click **Cancel**.

   If the count matches up, the page, panel, or dashboard does not contain invisible components.

1. If the count does not match up, clear the selection of the components you can see by clicking them while keeping Ctrl pressed, and then press Delete again to remove the invisible component.
