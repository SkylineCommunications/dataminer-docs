---
uid: BPA_Report_Active_RTE
---

# Report Active RTE

This BPA test specifically detects the presence of active run-time errors (RTEs) in the system by reading the `C:\Skyline DataMiner\logging\SLWatchdog2.txt` file.

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab, available from DataMiner 9.6.0 CU23, 10.0.0 CU13, 10.1.0 CU2 and 10.1.4 onwards). From DataMiner 10.1.7, 10.1.0 CU4, 10.0.0 CU15 and 9.6.0 CU24 onwards, this BPA test is available by default.

## Metadata

- Name: Report Active RTE
- Description: Verifies if there are active RTEs in the system
- Author: Skyline Communications
- Default schedule: Every 8 minutes

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
