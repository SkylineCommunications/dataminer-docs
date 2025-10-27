---
uid: Managing_aggregation_rules
---

# Managing aggregation rules

In DataMiner Cube, you can configure, create or delete aggregation rules, or create or delete folders for the rules:

- On the Aggregation page of a view card, click the *Edit mode* button. This switches the mode from View mode to Edit mode.

  In Edit mode, more buttons are available, and the detailed properties for any selected rule are displayed in the pane on the right instead of the aggregation data.

## Managing the folder structure

Using the folders in the tree view, you can sort aggregation rules logically, so that users will get useful information combined when they click a folder in View mode.

- To create a new folder, select a folder and click the *New folder* button at the bottom of the left pane. A new subfolder will be created in the selected folder.

- To delete a folder, select the folder and click the *Delete* button at the bottom of the left pane.

- To move folders to a different position in the folder structure, or to move rules to a different folder, simply drag and drop them to their new position.

  > [!NOTE]
  > It is not possible to have two folders or two rules with the same name within the same folder.

- To expand all folders, or to collapse all folders, right-click a folder in the list and select *Expand all* or *Collapse all* respectively.

- To rename a folder, select the folder in the list, enter a new name in the *Name* box on the right, and click the *Rename* button.

## Creating and configuring an aggregation rule

To create a new aggregation rule:

- Select the folder where you want to create the rule and click the *Add rule* button at the bottom.

  A new rule will be added to the folder, which you can then configure further.

To configure an aggregation rule, select it in the tree view on the left. In the pane on the right, you can then configure the rule as follows:

1. In the *Name* field, enter a new aggregation rule name.

   > [!NOTE]
   > Multiple rules in the same folder cannot have the same name. There is no such restriction across folders, however.

1. In the *Description* field, enter a description for the rule. This field can be left blank.

1. In the *Source* section of the pane, determine what the aggregation rule should calculate and how:

   1. In the first line under *What should be calculated*, indicate whether the calculation should happen *Manually* or *Automatically*.

      - If *Manually*: to calculate the aggregated data, the user will need to click the *Refresh* button in View mode.

      - If *Automatically*: indicate the time span when the data need to be calculated. This can be any time span less than a day, e.g. “30 seconds”, “15 minutes”, “2 hours”. Optionally, use the slider to increase or decrease the time span.

   1. In the second line, pick the type of aggregation:

      | Aggregation type | Description |
      |------------------|-------------|
      | Calculate the average | Calculates the average value of a parameter of a particular protocol and protocol version. |
      | Calculate the average (with additional information) | Calculates the average value of a parameter of a particular protocol and protocol version, as well as the minimum and maximum value and the number of values included in the calculation |
      | Count | Counts all rows from a table or all elements corresponding to a particular protocol and protocol version. |
      | Calculate the maximum | Calculates the maximum value of a parameter of a particular protocol and protocol version. |
      | Calculate the minimum | Calculates the minimum value of a parameter of a particular protocol and protocol version. |
      | Calculate the percentage of | Calculates the percentage of rows from a table or elements corresponding to a particular protocol and protocol version that meet a particular condition. |
      | Calculate the sum | Calculates the sum of the values of parameters of a particular protocol and protocol version. |

      > [!NOTE]
      > For the calculation of average values, empty parameter values are ignored.

   1. In the third line, specify if a condition has to apply, and if so, specify the condition. For some aggregation types, a condition is always required.

      > [!NOTE]
      >
      > - If the source you pick for the condition is a column parameter, an extra option will appear in the condition line that allows you to filter on an instance of that column.
      > - From DataMiner 10.1.10/10.2.0 onwards, the condition can include a regular expression. When you select *Matches regular expression*, you can select to match by value or by reference. If you select *by reference*, you will need to select the parameter containing the regular expression.

   1. Next to *Apply on view*, indicate the view that the rule should be applied on.

      > [!NOTE]
      > You will only be able to select views for which you have access permission.

   1. Optionally, to include subviews in the calculation, select *Include sub-views*.

   1. Optionally, depending on the source you specified, further grouping options may be available:

      - Select *For each view, group on property* and choose a property to group the data on a specified element property or view property.

      - If the source of the rule is based on a base protocol, select *For each view, group on protocol* to group data by protocol.

      - If the source of the rule is a table parameter, select *For each table, group on column* and choose a column, to group data by a column in the source table parameter.

1. In the Monitoring & Trending section, indicate whether the rule should be monitored and/or trended.

   - To enable monitoring, select *Monitored*, and enter the values for the alarm thresholds. This is done the same way as for a regular alarm template, including the possibility to use a smart baseline. For more information, see [Configuring normal alarm thresholds](xref:Configuring_normal_alarm_thresholds) and [Configuring dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds).

   - To enable trending, select *Average* and/or *Real-time*. For more information, see [About trend templates](xref:About_trend_templates).

1. At the top of the pane, select or clear the box next to *Enable this rule* to enable or disable the rule.
