---
uid: KI_DataMiner_Web_and_GQI_crash_briefly_during_startup
---

# DataMiner Web and GQI crash briefly during startup

## Affected versions

DataMiner 10.5.0 [CU11] and 10.6.2

## Cause

During startup, the DataMiner Web and DataMiner GQI processes may attempt to access an object that has already been disposed.

## Fix

No fix is available yet<!--RN 44380 + 44642-->.

## Description

DataMiner Web and/or DataMiner GQI can crash during startup. When this occurs, the following symptoms can be observed:

- In the *Event Viewer* application in Windows, the following errors events appear under *Applications and Services Logs* > *DataMiner*:

  | Level | Date and Time | Source |
  |--|--|--|
  | Error | DD/MM/YYYY HH:MM:SS | Application Error |
  | Error | DD/MM/YYYY HH:MM:SS | .NET Runtime |

  ![Event Viewer](~/dataminer/images/EventViewer.png)

- A crash dump is created in the `C:\Skyline DataMiner\Logging\CrashDump\wer\` folder.

  This folder contains a subfolder for the crashed process, including the dump file captured at the time of the crash.

Although DataMiner Web and GQI may crash briefly during startup, they automatically recover and continue running without user impact.
