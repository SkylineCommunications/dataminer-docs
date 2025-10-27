---
uid: BPA_Report_Active_RTE
---

# Active Runtime Errors

Prior to DataMiner 10.4.12/10.5.0<!--RN 40751-->, this BPA test is called "Report Active RTE".

This BPA test specifically detects the presence of active runtime errors (RTEs) in the system by reading the `C:\Skyline DataMiner\logging\SLWatchdog2.txt` file.

This BPA test is available by default from DataMiner 10.1.0 [CU4]/10.1.7 onwards.

## Metadata

- Name: Active Runtime Errors
- Description: Verifies if there are active RTEs in the system
- Author: Skyline Communications
- Default schedule: Every 8 minutes

  > [!NOTE]
  > From DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 onwards<!--RN 40201-->, this BPA test is executed automatically 8 minutes after DataMiner has been started. Prior to DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10, this BPA test is executed immediately after a DataMiner restart.

## Results

### Success

No RTEs are reported by the system.

Result message: `No active RTE found.`

### Error

One or more RTEs are reported.

Result message: `Found RTEs (number of RTEs) in the system. Please check SLWatchdog2.txt as soon as possible.`

Note that this BPA test will only return an error message if the RTE has not been cleared yet and that it will provide the full list of the active RTEs sequentially.

### Warning

This BPA does not generate warnings.

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons, and cannot provide a conclusive report because of this:

`Could not execute test ([message]).` (on unexpected exceptions)

The test result details contain the full exception text, if available.

## Impact when issues detected

- Impact: Operation of the DataMiner System might be affected by this problem.
- Corrective action: Please perform an investigation to solve the present RTEs as soon as possible.

## Limitations

None
