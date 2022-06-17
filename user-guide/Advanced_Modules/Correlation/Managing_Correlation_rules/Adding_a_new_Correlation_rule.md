---
uid: Adding_a_new_Correlation_rule
---

# Adding a new Correlation rule

To add a new rule in the Correlation module in DataMiner Cube:

- Select the folder where you want to add the rule, and click the *Add* button at the bottom of the pane, or

- Right-click the folder where you want a new rule and select *Add Rule*.

To create a functional new rule, you will also need to do the following:

- Give the rule a name and configure general options. See [General configuration of Correlation rules](xref:General_configuration_of_Correlation_rules).

- Optionally, filter out the alarms that can trigger the rule. See [Filtering and grouping base alarms for Correlation rules](xref:Filtering_and_grouping_base_alarms_for_Correlation_rules).

- Optionally, add rule conditions, based on which the rule may be triggered. See [Adding rule conditions in Correlation rules](xref:Adding_rule_conditions_in_Correlation_rules).

- Add rule actions, which will be executed when the rule is triggered. See [Adding rule actions in Correlation rules](xref:Adding_rule_actions_in_Correlation_rules).

> [!NOTE]
> The following minimum requirements must be met before you can enable a Correlation rule:
>
> - At least one valid rule action is configured.
> - At least one of the following conditions is met:
>   - A valid alarm filter is configured.
>   - The option *Trigger on single events* is enabled.
>   - A valid condition is configured.

You can also add a new rule by duplicating an existing rule and then changing this duplicate as required.

- To duplicate a rule, right-click the rule and select *Duplicate*.

  Alternatively, you can also select the rule, click the More... button at the bottom of the pane, and select *Duplicate*.

> [!NOTE]
> In DataMiner Cube, it is possible to add Correlation rules that use the deprecated System Display Correlation engine. To do so, right-click in the tree view pane (or click the *More...* button at the bottom of the pane) and select *Advanced* > *Old engine* > *Add rule*.
