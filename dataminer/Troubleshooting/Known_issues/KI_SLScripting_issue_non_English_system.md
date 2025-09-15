---
uid: KI_SLScripting_issue_non_English_system
---

# SLScripting issue with non-English system locale

## Affected versions

From DataMiner 10.4.0 [CU18]/10.5 [CU6]/10.5.9 onwards, on systems with a non-English locale.

## Cause

On non-English systems, changes introduced in DataMiner 10.4.0 [CU18]/10.5 [CU6]/10.5.9 can cause a null reference exception to be thrown when SLScripting starts up. The localization fails on such systems, getting into a loop while trying to load assemblies to translate the exception, until the process eventually gets killed.

## Fix

Install DataMiner 10.4.0 [CU18] build 16295, 10.5 [CU6] build 16294, or 10.5.9 build 16293

## Description

The SLScripting process keeps crashing. This can be observed in the Task Manager or by looking at the SLDataMiner logging, where the following will be logged: `The SLScripting process seems to have crashed, removing the instance for index.`

To further verify if you are indeed encountering this issue, you can check the Windows Event Viewer. The Application logs will show error events for the .NET Runtime source. In the details, it will mention that the application is SLScripting. The call stack contains a repetition of the following items:

```txt
CurrentDomain_AssemblyLoad
ManagedScriptLog.get_mpLog()
NullreferenceException..ctor()
CurrentDomain_AssemblyLoad
```
