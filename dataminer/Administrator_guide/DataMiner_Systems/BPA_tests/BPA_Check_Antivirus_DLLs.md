---
uid: BPA_Check_Antivirus_DLLs
---

# Antivirus on the DataMiner Agents

Prior to DataMiner 10.4.12/10.5.0 [CU10]<!--RN 40751-->, this BPA test is called "Check Antivirus DLLs".

When installed on a DataMiner Agent, [antivirus software must be configured to exclude the DataMiner processes](xref:Regarding_antivirus_software).

The *Antivirus on the DataMiner Agents* BPA test specifically detects the presence of antivirus DLLs loaded into DataMiner processes (SL*.exe hosted from the `C:\Skyline DataMiner\Files` folder). You can find information about this BPA test below.

This BPA test is available by default from DataMiner 10.1.4 onwards.

## Metadata

- Name: Antivirus on the DataMiner Agents
- Description: Verifies that no antivirus DLLs have been loaded into DataMiner processes
- Author: Skyline Communications
- Default Schedule: Every day

## Results

### Success

`No antivirus DLLs found`

This is the result when none of the running SL*.exe processes have a known antivirus DLL loaded.

### Error

`Found antivirus DLL in SLXXXX: [dllname]. To resolve, exclude DataMiner processes (SL*) from antivirus checking.`

Note that there will only be one DLL reported for one process. The test quits as soon as it finds one DataMiner process hosting an antivirus DLL.

### Warning

This BPA does not generate warnings.

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this:

`Could not execute test ([message])` (on unexpected exceptions).

In the message above, the exception message is included (e.g., "Access Denied"). The test result details contain the full exception text, if available.

## Impact when issues detected

- Impact: Operation of the DataMiner System might be affected by the antivirus software.
- Corrective action: Please configure the antivirus software to exclude DataMiner processes (sl*.exe).

> [!NOTE]
> As some antivirus software injects itself into the DataMiner processes, it may be necessary to also restart DataMiner to resolve this error.

## List of DLLs being checked

The following DLLs are currently checked (case insensitive):

### Fixed names

- `UMEngx86.dll` (Symantec)
- `TmUmEvt.dll` (Trend Micro)
- `tmmon.dll` (Trend Micro)
- `sophos_detoured_x64.dll` (Sophos AV)
- `sysfer.dll` (Symantec endpoint Protection)

### Regular expressions

- `^(?:CrowdStrike\.Sensor\.)?ScriptControl(?:32_|64_|86_)?\d+\.dll$` (CrowdStrike)
- `^ScriptSn\.\d+\.dll$` (McAfee)

### File path checks

From DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 onwards<!--RN 32567-->, the BPA test also checks the paths of loaded antivirus DLL files.

This means:

- The test can detect antivirus DLLs even if they are renamed or newly added, as long as they are loaded from a known antivirus file path.

- The test takes into consideration both the file name and the source path, which increases the chances of detection.

## Limitations

- The BPA can only check for native DLLs. Managed DLLs cannot be detected.
- The BPA currently does not check Cassandra or MySQL processes for loaded antivirus DLLs.
