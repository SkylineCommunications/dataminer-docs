---
uid: Configuring_alarm_thresholds_dynamic_table_parameters
---

# Configuring alarm thresholds for dynamic table parameters

By default, each column of a dynamic table that has monitoring enabled will be represented by one row in the alarm template, so the alarm thresholds need to be determined per row.

1. To enable alarm monitoring for a table parameter column, select the checkbox in the first column of the template editor next to the table parameter column name.

1. Optionally, specify a mask in the *Filter* column to apply the alarm configuration only on a filtered selection of available rows of the dynamic table.

   > [!NOTE]
   > You can use the wildcard characters \* and ? in this filter mask. For more information on wildcards, see [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).

1. When you hover the mouse over a parameter, several buttons appear that allow additional options:

   - Duplicate column parameters using the *+* button to define different alarm thresholds with different filters, so that different rows in the dynamic table will have different alarm thresholds.

   - When you have duplicated a column parameter, you can remove the duplicate again using the *x* button.

   - Use the up and down buttons, visible as an upwards and a downwards triangle, to change the order of the filters. This may be important as alarming is applied top to bottom.

1. Enter the values you want for the different alarm severities, as for a regular parameter.

   > [!NOTE]
   >
   > - If an alarm template contains multiple duplicate instances of the same table column parameter, all those instances are displayed as soon as one of them is marked as being monitored, even if *Only monitored parameters* is selected in the top-right corner of the card.
   > - If you want to configure a table to have all rows monitored, except certain specific rows, add an entry with a filter for those rows above the entry for the entire table, and make sure the entry with the filter is not selected. For example: <br>![Row filter in alarm template](~/user-guide/images/MonitorTableRow.png)
