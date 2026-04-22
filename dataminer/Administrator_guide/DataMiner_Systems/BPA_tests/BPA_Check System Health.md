# Check System Health

This BPA test is executed locally on each DataMiner Agent. It analyzes the SLWatchdog reports generated during the past 7 days and checks whether the system's resource usage stayed within healthy boundaries.
If suspicious behavior is detected (e.g. high CPU, memory, handles, threads or disk latency), the test will report an error so that corrective actions can be taken.

You can [run it in System Center](https://docs.dataminer.services/dataminer/Administrator_guide/DataMiner_Systems/Running_BPA_tests.html)
on the *Agents > BPA* tab.

## Metadata

- Name: Check System Health
- Description: Verify the behavior of the system during the last week.
- Author: Skyline Communications
- Default schedule: Every 7 days

## Results

### Success

When the test is successful, this message is shown:

- `No suspicious problems detected in the system during the past week.`

This BPA currently validates the following parameters against fixed thresholds,
based on the SLWatchdog reports of the last 7 days:

| Parameter | Threshold |
| --- | --- |
| Total CPU per core | 75 % |
| Total CPU per SL process (`SL*` and `prunsrv`) | 12 % |
| Total Handles | 13 000 000 |
| Total Threads | 30 000 |
| Physical Memory usage (average over 7 days) | 70 % |
| Disk latency – avg sec/read | 20 ms |
| Disk latency – avg sec/write | 20 ms |
| Disk latency – avg sec/transfer | 20 ms |

Additional parameters may be taken into consideration in future versions.

### Error

`({problems}) warning problems found in the system. Please check as soon as possible.`

The output is marked as an error when at least one of the monitored parameters exceeds its threshold in a significant portion of the samples collected during the past 7 days.
The detailed result lists every threshold breach using one or more of the following messages:

- `Core ({name}) utilization has exceeded the 75% threshold in {x}% of the samples.`
- `Process ({name}) utilization has exceeded the 12% threshold in {x}% of the samples.`
- `The Total Handles utilization has exceeded the 13 000 000 threshold in {x} of the samples.`
- `The Total Threads utilization has exceeded the 30 000 threshold in {x} of the samples.`
- `The average of Physical Memory Usage is {x}% during the last 7 days.`
- `Disk ({name}) latency has exceeded the 20ms avg sec/read threshold in {x}% of the samples.`
- `Disk ({name}) latency has exceeded the 20ms avg sec/write threshold in {x}% of the samples.`
- `Disk ({name}) latency has exceeded the 20ms avg sec/transfer threshold in {x}% of the samples.`

### Warning

This BPA does not generate warnings.

### Not Executed

If the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this, the following messages can be shown:

- `Could not execute test ([message])` – returned when an unexpected exception occurs.
- `Error on parsing the file:{file}. Extra Details: ...` – returned when one of the SLWatchdog XML reports does not contain all the expected sections (CPU cores, total physical memory, task manager processes, total handles or total threads).
- `Files not found at C:\Skyline DataMiner\logging\WatchDog\Reports\` – returned when no valid SLWatchdog reports could be found for the past 7 days.

##### Note

If you get the exception `BPA doesn't have valid signature`, this means the BPA test is unsigned. To resolve this issue, contact Skyline to ask for the signed version of the BPA or upgrade DataMiner.

## Possible solutions

- Impact: Operation of the DataMiner System might be affected by this problem.
- Corrective Action: Investigate the unusual resource usage on the affected Agent. Look into the processes, disks or hardware components reported in the detailed output and take action to bring the resource usage back within the thresholds listed above.

## Limitations

- The BPA only inspects the SLWatchdog reports stored under `C:\Skyline DataMiner\logging\WatchDog\Reports\`. If those reports are not available (for example, on offline or recently installed Agents), the test cannot produce a conclusive result.
- Thresholds are fixed and cannot currently be configured by the user.
- Only the parameters listed above are validated; other system health indicators are not yet covered.
