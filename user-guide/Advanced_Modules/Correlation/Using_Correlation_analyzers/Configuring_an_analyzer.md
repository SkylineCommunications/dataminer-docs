---
uid: Configuring_an_analyzer
---

# Configuring an analyzer

To configure a Correlation analyzer:

1. In the *Analyzers* tab of the *Correlation* module, make sure the analyzer is selected in the tree view.

1. Enter a name for the analyzer in the *Name* field.

    > [!NOTE]
    > - A new analyzer will by default be simply called “Analyzer”
    > - It is not possible to add two analyzers with the same name in the same folder. Across folders, however, this is no problem.

1. Optionally, expand *Show details* and add a description in the *Description* field.

1. If the analyzer should always be managed by one DMA, expand *Show details*, select *This rule will be managed by one single DataMiner Agent*, and select the DMA in the drop-down list.

1. In the *Alarm filter* section, indicate what should be analyzed:

    - To analyze a view, select *Analyze the alarms from view* and select the view in the drop-down list.

    - To analyze an element, select *Analyze the alarms from element* and select the element in the drop-down list.

    - To analyze based on an alarm filter, select *Analyze the alarms matching the filter* and create a filter:

        1. Click *Select a filter* and select a parameter to filter on.

        1. If this is the first (or only) filter condition, select *Is* or *Is Not* to indicate whether the condition has to be true or false. Otherwise, select the operator linking it to the previous filter condition (and, and not, or, or not).

        1. Specify whether the parameter should or should not match a regular expression or wildcard expression, and specify the expression in question.

            > [!NOTE]
            > - For more information on wildcards, see [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).
            > - For more information on using regular expressions in filters, see [Alarm filters using regular expressions](xref:ApplyingAlarmFiltersInTheAlarmConsole#alarm-filters-using-regular-expressions).

        1. If you want to add another condition to the filter, click *Add a Filter* and go back to step 4b.

        1. If you want to delete one of the filter conditions, click the *X* to the right of the filter.

1. If you want to use the analyzer to analyze real-time alarms, select *Enable real-time analyzing* at the top of the details pane.

    If this option is not selected, a time range for history alarms will need to be specified when the analyzer is used.

1. Click the *Apply* button at the bottom of the details pane to save the configuration changes.
