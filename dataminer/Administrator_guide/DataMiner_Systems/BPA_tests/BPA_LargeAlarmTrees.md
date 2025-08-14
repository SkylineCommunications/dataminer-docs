---
uid: BPA_LargeAlarmTrees
---

# Large Alarm Trees

This BPA test is executed on one DMA per cluster. It will fetch active alarm trees and check if any are getting too large. If this is the case, it could have a serious impact on several DataMiner processes, so you will have to take the necessary [corrective actions](xref:Best_practices_for_assigning_alarm_severity_levels#keep-alarm-trees-from-growing-too-large).

This BPA test is available from DataMiner 10.5.9/10.6.0 onwards.<!-- RN 42952 --> You can [run it in System Center](xref:Running_BPA_tests) on the *Agents > BPA* tab.

## Metadata

- Name: Large Alarm Trees
- Description: Warns about large active alarm trees.
- Author: Skyline Communications
- Default schedule: None

## Results

### Success

When the test is successful, this message is shown:

- `No issues detected: No large active alarm trees detected.`

### Error

`One or more potential problems were detected.`

The output is marked as an error when there is at least one alarm tree that consists of 10&thinsp;000 or more alarms. Only the alarm trees that have reached this size will be returned in the detailed result.

The detailed JSON output of the BPA test may contain the following possible message, depending on which potential issues have been detected:

- `x large alarm trees detected`, followed by a list of alarm tree IDs with the corresponding exact size.

### Warning

The output is marked as a warning when there is at least one alarm tree that consists of 100 or more alarms, but all alarm trees have less than 10&thinsp;000 alarms. Only the alarm trees that have reached this size will be returned in the detailed result.

The detailed JSON output of the BPA may contain the following message, depending on which potential issues have been detected:

- `x large alarm trees detected`, followed by a list of alarm tree IDs with the corresponding exact size.

### Not Executed

If the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this, the following message can be shown:

- `BPA execution timed out after 10 minutes.` In this case, it took too long to collect all the necessary information.

> [!NOTE]
> If you get the exception `BPA doesn't have valid signature`, this means the BPA test is unsigned. To resolve this issue, contact Skyline to ask for the signed version of the BPA or upgrade DataMiner.

## Possible solutions

To resolve any potential issues that have been detected, refer to [Keep alarm trees from growing too large](xref:Best_practices_for_assigning_alarm_severity_levels#keep-alarm-trees-from-growing-too-large).
