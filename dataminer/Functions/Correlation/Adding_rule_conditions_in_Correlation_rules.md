---
uid: Adding_rule_conditions_in_Correlation_rules
---

# Adding rule conditions in correlation rules

## About rule conditions

In a correlation rule, multiple filter conditions can be defined within the rule condition. The way these filter conditions are structured directly determines how alarms in the bucket are evaluated and, ultimately, whether the rule is triggered.

Each filter condition is evaluated against individual alarms. The system checks whether there is at least one alarm in the bucket that fully satisfies all the conditions defined within that filter condition. The logic of a filter condition is strict and self-contained: the entire condition must be matched by a single alarm instance. The evaluation iterates through the alarms in the bucket until such a match is found.

When multiple filter conditions are configured, they are evaluated independently. For each filter condition, alarms in the bucket are examined to determine whether any single alarm satisfies the corresponding condition. Because each filter condition is examined individually, the system does not require one single alarm to satisfy all filter conditions simultaneously. Instead, each filter condition may be fulfilled by different alarms.

This allows rules to be triggered based on more complex scenarios, such as combinations of alarms or even the absence of certain alarms. The system verifies whether the logical combination of all configured filter conditions is satisfied, rather than enforcing that all filter conditions must apply to a single alarm.

This distinction becomes particularly important when combining inclusion criteria (positive logic) and exclusion criteria (negative logic):

- When multiple criteria are grouped within a single filter condition, all inclusion and exclusion requirements must be satisfied by the same alarm.
- When criteria are split across multiple filter conditions, the evaluation is no longer limited to a single alarm:
  - Inclusion requirements can be satisfied by one alarm.
  - Exclusion requirements can be evaluated based on the presence or absence of other alarms in the bucket.

More broadly, the distinction can be summarized as follows:

- A single filter condition enforces that all constraints describe one alarm.
- Multiple filter conditions allow the rule to evaluate the entire set of alarms as a whole.

This explains why two rule configurations that appear similar can produce different outcomes in practice: one relies on a single alarm matching all conditions, while the other evaluates conditions across multiple alarms within the same bucket.

## Adding a rule condition

In the *Correlation* module in Cube, select a rule in the tree view pane on the left in order to add rule conditions to it in the details pane on the right.

In the *Rule condition* section of the details pane, specify one or more conditions that, when met, will trigger the correlation rule. You can select and combine Script conditions and Filter conditions, and specify one of different trigger mechanisms. In the *Sliding window* section, an additional trigger mechanism can be selected.

1. Click *Select a Condition* and select either *Script condition* or *Filter condition*.

1. If you have selected *Script condition*, enter the script in the large text box.

   For more information on how to enter a script condition, see [Correlation rule syntax](xref:Correlation_rule_syntax).

   > [!NOTE]
   > When configuring script conditions, keep in mind that a correlation rule can only be triggered by alarm events.

1. If you selected *Filter condition*, then do the following:

   1. Click *Select a filter*.

   1. Select one of the listed properties and create a filter condition, or select *Saved filters* and select an existing alarm filter.

1. If this is the first (or only) rule condition, select “Is” or “Is Not” to indicate whether the condition has to be true or false.

1. If this is not the first (or only) rule condition, select the operator linking it to the previous one (and, and not, or, or not).

1. If you want to add another rule condition, click *Add Filter* and go back to step 1.

1. If you want to delete one of the rule conditions, click the X to the right of that condition.

1. To determine the trigger mechanism, select one of the following options:

   - **Immediate evaluation:** If you select this option, the rule action(s) will be executed as soon as there is a match with the rule conditions.

     > [!NOTE]
     > You should also use this option if you want to use a sliding window as described in step 9.

   - **Persistent event: act only when the condition remains fulfilled for ...** : If you select this option and specify a time span, the rule action(s) will be executed when there is a match with the rule conditions that lasts for the duration of the specified time span.

   - **Collect events for ... after first event, then evaluate conditions and execute actions**: If you select this option, specify a time span. As soon as an alarm matches the alarm filter(s), the correlation rule will start collecting all alarm events matching the same alarm filter(s). After the specified time span, the rule conditions will be checked for the collected alarm events. If there is a match, the action(s) will be executed.

     This option can for example be used to only trigger the rule action(s) if the average value of the alarms matching the filter during the time span is higher than a value defined in the rule.

1. If *Immediate evaluation* was selected in the previous step, in the *Sliding window* section you can also determine an additional trigger mechanism in a sliding window.

   1. To trigger the correlation rule if a situation occurs a particular number of times in a given time span, select *Require situation to occur ... times in ... before acting*, and specify the number of times and the time span. When you select this option, and there is a match with the rule conditions, the occurrence will be registered. As soon as there are enough occurrences in the interval, the rule is triggered.

      > [!NOTE]
      > If, for instance, you want to create a rule that is triggered if a certain number of alarms occur within a sliding window, you must also select the option *Trigger on single events. Don’t maintain active tree status* in the *Alarm filter* section. Only the base alarms will be counted, so if you do not select this option, and there are changes in an alarm tree, these will not be counted as separate events.

   1. To trigger the correlation rule only if this situation persists during a given time span, also select the option *Require sliding window violation to persist for ... before acting*, and specify the time span.

> [!NOTE]
>
> - In a cluster, a temporary disconnection between the Agent handling the rule and a remote Agent can cause an extra sliding window occurrence, as the base event is considered cleared when the Agent disconnects, and considered new when it reconnects.
> - If a disconnection between the Agent handling the rule and a remote Agent occurs after actions have been executed for a persistent rule, and this causes the conditions to no longer be fulfilled, the persistent timer will start again as soon as connection between the Agents has been restored. See [Correlation in DataMiner clusters](xref:About_DMS_Correlation#correlation-in-dataminer-clusters).
> - Hidden elements are supported in rule conditions from DataMiner 10.1.0 [CU13], 10.2.0 [CU1], and 10.2.4 onwards.
