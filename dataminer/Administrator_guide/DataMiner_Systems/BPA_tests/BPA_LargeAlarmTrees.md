---
uid: BPA_LargeAlarmTrees
---

# Large Alarm Trees

This BPA test is executed on one DMA per cluster. It will fetch active alarm trees and check if any are getting too large.
If that's the case you'll have to take corrective actions, as suggested [here](https://aka.dataminer.services/LargeAlarmTrees).
We warn you about this since this can have a serious impact on several DataMiner processes.

This BPA test is available from DataMiner 10.4.0 [CU18]<!-- RN 42952 --> onwards. You can [run it in System Center](xref:Running_BPA_tests) on the *Agents > BPA* tab.

## Metadata

- Name: LargeAlarmTrees
- Description: Warns about large active alarm trees.
- Author: Skyline Communications
- Default schedule: None

## Results

### Success

These are the messages that can appear when the test is successful:

- No issues detected: No large active alarm trees detected.

### Error

The output is marked as an error when there is at least one Alarm Tree consisting of 10.000 or more alarms. Only the trees reaching this size will be returned in the detailed result.

One or more potential problems were detected.

The detailed JSON output of the BPA test may contain the following possible messages, depending on which potential issues are detected:

- x large alarm trees detected, followed by a list of Alarm Tree IDs with their exact size.

### Warning

The output is marked as a warning when there is at least one Alarm Tree consisting of 100 or more alarms and all have less than 10.000 alarms. Only the trees reaching this size will be returned in the detailed result.

The detailed JSON output of the BPA may contain the following messages, depending on which potential issues are detected:

- x large alarm trees detected, followed by a list of Alarm Tree IDs with their exact size.

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this:

- BPA execution timed out after 10 minutes. In this case it took too long to collect all necessary information.

> [!NOTE]
> If you get the exception "BPA doesn't have valid signature", this means the BPA test is unsigned. To resolve this issue, contact Skyline to ask for the signed version of the BPA or upgrade DataMiner.

## Possible solutions

If potential issues are detected, see [here](https://aka.dataminer.services/LargeAlarmTrees) for suggestions on how to improve your config.
