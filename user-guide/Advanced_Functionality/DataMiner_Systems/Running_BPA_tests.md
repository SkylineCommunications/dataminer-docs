---
uid: Running_BPA_tests
---

# Running BPA tests

From DataMiner 9.6.0 \[CU23\]/10.0.0 \[CU11\]/10.2.0 onwards, it is possible to run BPA (i.e. Best Practices Analysis) tests from the *Agents* page in System Center. These tests can be used to verify that a specific part of a DataMiner setup conforms with Skyline recommendations, in order to guarantee an optimal DataMiner experience.

You can view and run BPA tests in System Center, on the *Agents* > *BPA* page.

This page shows a list of all the BPA tests that are currently available in the system. Depending on the type of test, you can run a BPA test on an individual DMA or across a cluster. A button at the top of the list allows you to group the displayed information either by test (default) or by the DMA or DMS the tests can be executed on.

- If the list is grouped by test, an *Execute all* button is available in the *Action* column that allows you to run a test for all applicable servers. Alternatively, you can expand a list item and click the *Execute* button to run the test for one specific DMA or DMS only.

- Similarly, if the list is grouped by Agent, the *Execute all* button in the *Action* column can be used to run all tests for a specific DMA or DMS, and you can expand a list item and click the *Execute* button to run only one specific test for a DMA or DMS.

- Regardless of how the list is grouped, the *Execute all* button in the top-right corner can be used to execute all available tests on all applicable Agents and clusters.

For a group item, the *Status* column displays the number of individual entries in the group with a colored LED indicating their status: green for a successful test, red if issues were detected, and gray if no results are available. For each individual item within a group, this same column can display the following status information: *No result available*, *Test running*, *OK*, *Warning*, *Issues detected* or *Execution failed*.

From DataMiner 10.1.4 onwards, the *Schedule* column allows you to configure at which interval a specific test should be executed, e.g. every 12 hours.

Once a test has run, the *Message* column will display information on the test results for specific items. Via the ... button in this column, you can open a window with more detailed information. From DataMiner 10.2.8/10.3.0 onwards, this window also contains a button that allows you to copy the information to the clipboard.

> [!NOTE]
>
> - Standard BPA tests are included in updates from DataMiner 10.2.0/10.1.2 onwards and added in the folder *C:\\Skyline DataMiner\\BPA*.
> - To use the *Agents* > *BPA* page in System Center, you need the user permissions under *Modules* > *System Configuration* > *Tools* > *Best Practices Analyzer*.
> - A BPA test can only be executed if it has been digitally signed by Skyline, and if your DataMiner version is within the limitations of the minimum and/or maximum DataMiner version configured in the test (if any).
