---
uid: Running_BPA_tests
---

# Running BPA tests

From the *Agents* > *BPA* page in System Center, you can run BPA (i.e. Best Practices Analysis) tests. These tests can be used to verify that a specific part of a DataMiner setup conforms with Skyline recommendations, in order to guarantee an optimal DataMiner experience.

From DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 onwards<!-- RN 40201-->, all BPA tests are executed between 10 and 60 minutes after DataMiner has been started, with the exception of the [*Active Runtime Errors* test](xref:BPA_Report_Active_RTE), which is executed 8 minutes after DataMiner has been started. Prior to DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10, all BPA tests are executed immediately after a DataMiner restart.

The *BPA* page shows a list of all the BPA tests that are currently available in the system. Depending on the type of test, you can run a BPA test on an individual DMA or across a cluster. A button at the top of the list allows you to group the displayed information either by test (default) or by the DMA or DMS the tests can be executed on.

- If the list is grouped by test, an *Execute all* button is available in the *Action* column that allows you to run a test for all applicable servers. Alternatively, you can expand a list item and click the *Execute* button to run the test for one specific DMA or DMS only.

- Similarly, if the list is grouped by Agent, the *Execute all* button in the *Action* column can be used to run all tests for a specific DMA or DMS, and you can expand a list item and click the *Execute* button to run only one specific test for a DMA or DMS.

- Regardless of how the list is grouped, the *Execute all* button in the top-right corner can be used to execute all available tests on all applicable Agents and clusters.

For a group item, the *Status* column displays the number of individual entries in the group with a colored LED indicating their status: green for a successful test, red if issues were detected, light gray if no results are available, and dark gray if the test is not applicable. If the execution of a test has failed, a warning icon will be displayed in the *Status* column instead of a colored LED. For each individual item within a group, this same column can display the following status information: *No result available*, *Test running*, *OK*, *Warning*, *Issues detected*, *Execution failed*, or *Not applicable*.

> [!NOTE]
> From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 39929-->, BPA tests that could not be run display the *Not applicable* status. Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9, tests that could not be run display the *Execution failed* status.

From DataMiner 10.1.4 onwards, the *Schedule* column allows you to configure at which interval a specific test should be executed, e.g. every 12 hours.

Once a test has run, the *Message* column will display information on the test results for specific items. Via the ... button in this column, you can open a window with more detailed information. From DataMiner 10.2.8/10.3.0 onwards, this window also contains a button that allows you to copy the information to the clipboard.

> [!NOTE]
>
> - Standard BPA tests are included in updates from DataMiner 10.2.0/10.1.2 onwards and added in the folder `C:\Skyline DataMiner\BPA`.
> - To use the *Agents* > *BPA* page in System Center, you need the user permissions under *Modules* > *System Configuration* > *Tools* > *Best Practices Analyzer*.
> - A BPA test can only be executed if it has been digitally signed by Skyline, and if your DataMiner version is within the limitations of the minimum and/or maximum DataMiner version configured in the test (if any).
