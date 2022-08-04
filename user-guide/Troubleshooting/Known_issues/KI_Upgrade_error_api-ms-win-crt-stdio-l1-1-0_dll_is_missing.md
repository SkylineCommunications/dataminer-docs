---
uid: KI_Upgrade_error_api-ms-win-crt-stdio-l1-1-0_dll_is_missing
---

# Upgrade error: api-ms-win-crt-stdio-l1-1-0.dll is missing

## Description of the issue

While DataMiner is upgraded, the following error occurs:

```txt
The program can't start because api-ms-win-crt-stdio-l1-1-0.dll is missing from your computer. Try reinstalling the program to fix this problem.
```

## Cause

The latest version of Microsoft Visual C++ Redistributable for Visual Studio 2015 is not installed on the DMA.

## Resolution

Download and install the latest version of Visual C++ Redistributable for Visual Studio 2015.

You can do so from the following website: <https://www.microsoft.com/en-us/download/details.aspx?id=48145>.
