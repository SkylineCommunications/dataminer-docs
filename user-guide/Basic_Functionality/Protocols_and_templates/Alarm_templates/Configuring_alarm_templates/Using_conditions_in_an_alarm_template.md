---
uid: Using_conditions_in_an_alarm_template
---

# Using conditions in an alarm template

In the *Condition* column, you can add conditions for the alarm triggering of selected parameters. By specifying such a condition, you can ensure that a parameter is not monitored when another parameter of the same element has a specific value or alarm state. From DataMiner 10.2.0/10.1.11 onwards, it is also possible to let the monitoring of a parameter depend on whether the parameter (or another parameter of the same element) affects a service.

> [!NOTE]
>
> - When you specify a condition for a parameter in an alarm template, that parameter will only be monitored when the condition is false.
> - Some protocols specify default conditions, which are automatically filled in. However, it is possible to override these.

When you click in the selection box in the *Condition* column, the following actions are possible:

- Create a new condition as follows:

  1. Select *\<New>*. The window *Add condition to \[template name\]* opens.

  1. Enter a name for the condition next to *Name*.

  1. Click *Select a filter* to create a new filter.

  1. Select the parameter you want to filter on.

  1. Configure the filter:

     1. Select the parameter you want to filter on.

     1. Select the filter type. The default type is *Value*. Clicking *Value* allows you to select an alternative type, i.e. *Severity* or *Service impact*.

     1. Select the operator. The default operator is *Equal to*. Clicking *Equal to* allows you to select an alternative operator, i.e. *Not Equal to*, *Greater than*, or *Less than*.

     1. Specify the value, service impact or severity to filter on.

  1. Optionally, click *Add filter* to create more filters and combine them using logical operators (AND, OR).

  1. When the filters have been defined, click *OK*.

  > [!NOTE]
  >
  > - Prior to DataMiner 10.0.5, filters can only refer to columns from a different table, if these are linked to the first table via foreign key. For example, in case of two tables Table A and Table B, where the foreign key of Table B is the primary key of Table A, in the alarm template for Table B, you can specify conditional alarm filters using columns from Table A. From DataMiner 10.0.5 onwards, filters can also refer to columns from another table if the tables are not linked.
  > - From DataMiner 10.0.5 onwards, you can configure a condition on a column parameter based on the value of a cell in the same table or a different table. However, note that this is not supported for view table columns. Note also that if the monitored table and the table used in the condition are the same or are not related, the condition will be applied to all cells in the monitored column, but only when the cell specified in the condition changes. If the two tables are related, the condition will apply to all cells in the monitored column that are linked to the row containing the cell specified in the condition.
  > - From DataMiner 9.5.13 onwards, if you configure a condition based on the value of a string parameter, it is possible to use the wildcards "\*" and "?".
  > - From DataMiner 10.0.7 onwards, conditions are supported that check whether a parameter value is equal or not equal to “Not Initialized”, i.e. the value of a parameter that has not yet been set. To configure such a condition, click the *Value* field in the second part of the condition and select *Not initialized*.

- Select an existing condition, if any are available. If necessary, click the pencil icon next to the selected condition to modify it.

- To remove a condition, select *\<No condition>*, or click the *x* next to the condition.

- To add another condition for the same parameter, hover the mouse over the condition and click the *+* sign that appears next to it.

  > [!NOTE]
  > If there are multiple alarm template entries for the same parameter, each with a different condition, then the first entry of which the condition is false, starting from the top, will be applied.

> [!TIP]
> See also: [Alarm templates – Conditional monitoring](https://community.dataminer.services/video/alarm-templates-conditional-monitoring/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
