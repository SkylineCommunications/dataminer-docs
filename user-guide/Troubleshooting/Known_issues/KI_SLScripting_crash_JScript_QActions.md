---
uid: KI_SLScripting_crash_JScript_QActions
---

# SLScripting crash when using JScript QActions

## Affected versions

DataMiner Systems running on Windows 11 24H2.

This issue may also occur on Windows Server 2025.

## Cause

On Windows 11 24H2, SLScripting tries to load *Jscript9Legacy.dll* instead of *JScript.dll* when executing JScript QActions, causing it to stop working correctly.

## Fix

As support for JScript in QActions is ending, update your QActions to use C# instead.

## Workaround

See [Script errors in Working Papers Caseview - Windows 24H2 Update](https://my.caseware.com/s/article/Script-errors-in-Working-Papers-Windows-24H2-Update?language=en_US).

## Description

When a connector with a JScript QAction is used, SLScripting stops working correctly.

In SLErrors.txt, logging similar to the following example can be found:

```txt
2025/03/20 09:01:22.329|SLDataMiner.txt|SLDataMiner|48996|20948|ScriptingProcess::GetScriptingStreamFromFactory|ERR|-1|The SLScripting process seems to have crashed, removing the instance for index [0] so a new one will be created: The remote procedure call failed. (hr = 0x800706BE)
```
