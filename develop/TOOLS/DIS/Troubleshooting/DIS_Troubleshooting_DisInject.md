---
uid: DIS_Troubleshooting_DisInject
keywords: dis inject issue, dis inject slscripting
---

# DIS Inject - Common scenario's

## Breakpoints are not hitting

### Possible solutions

- Projects need to be build in [Debug mode](https://learn.microsoft.com/en-us/visualstudio/debugger/what-is-debugging?view=vs-2022#debug-mode-vs-running-your-app).

  - DIS will run the code, so you only need to make sure the configuration is set to `Debug`.

- Multiple SLScripting processes: Starting from [DIS 2.44](xref:DIS_2.44#dis-inject-attaching-the-visual-studio-debugger-to-multiple-slscripting-processes-id_37042), DIS will attach to all SLScripting processes.

## Could not find SLScripting process, is DataMiner running?

### Problem

After clicking *Attach* in the *DIS Inject* window, you get the following error:

```txt
Visual Studio needs to run as administrator to perform this action.
```

### Cause

Microsoft Visual Studio is not allowed to attach to the DataMiner SLScripting process.

### Solution

Run Microsoft Visual Studio as an administrator.

#### To change the privilege level of VSLauncher.exe

1. Exit Microsoft Visual Studio
1. In Windows Explorer, go to *C:\\Program Files (x86)\\Common Files\\microsoft shared\\MSEnv*
1. Right-click *VSLauncher.exe* and select *Properties*.
1. In the *Properties* dialog box of *VSLauncher.exe*, go to the *Compatibility* tab.
1. In the *Settings* section, select the *Run this program as an administrator* checkbox.
1. Click *OK*.

#### To associate XML files with VSLauncher.exe

1. Right-click an XML file and select *Open With \> Choose Default Program.*
1. In the *Open With* dialog box, click *Browse.*
1. Go to *C:\\Program Files (x86)\\Common Files\\microsoft shared\\MSEnv*, select *VSLauncher.exe* and click *Open*.
1. Select the *Always use the selected program to open this kind of file* checkbox and click *OK*.
