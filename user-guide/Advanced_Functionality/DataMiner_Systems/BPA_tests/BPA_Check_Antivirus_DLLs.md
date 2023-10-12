---
uid: BPA_Check_Antivirus_DLLs
---

# Check Antivirus DLLs

When installed on a DataMiner Agent, [antivirus software must be configured to exclude the DataMiner processes](xref:Regarding_antivirus_software).

The *Check Antivirus DLLs* BPA test specifically detects the presence of antivirus DLLs loaded into DataMiner processes (SL*.exe hosted from the `C:\Skyline DataMiner\Files` folder). You can find information about this BPA test below.

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab, available from DataMiner 9.6.0 CU23, 10.0.0 CU13, 10.1.0 CU2 and 10.1.4 onwards). From DataMiner 10.1.4 onwards, it is available by default.

## Metadata

- Name: Check Antivirus DLLs
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

In the message above, the exception message is included (e.g. "Access Denied"). The test result details contain the full exception text, if available.

## Impact when issues detected

- Impact: Operation of the DataMiner System might be affected by the antivirus software.
- Corrective action: Please configure the antivirus software to exclude DataMiner processes (sl*.exe).

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

## Limitations

- The BPA can only check for native DLLs. Managed DLLs cannot be detected.
- The BPA currently does not check Cassandra or MySQL processes for loaded antivirus DLLs.
