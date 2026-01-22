---
uid: Triggering_a_correlated_alarm
---

# Triggering a correlated alarm

To make a Correlation rule trigger a new, correlated alarm:

1. In the *Actions* section of the details pane, click *Add Action* and select *New Alarm*.

1. Click the first underlined field and select an element from the list.

1. Click the second underlined field and select a parameter from the list.

   If you select a dynamic table parameter, then to the right of the parameter, click *\<empty>* and select the row index.

   > [!NOTE]
   > You can also leave the element and parameter empty in the *New Alarm* action. This will generate a correlated alarm on the same element and parameter as the base alarm.

1. Click the underlined field to the right of “with alarm value”, and specify a parameter value.

   Instead of a value, you can also enter a placeholder. For more information, see [Correlation rule syntax](xref:Correlation_rule_syntax).

   > [!NOTE]
   > If you want a Correlation alarm on a table parameter to take the parameter index value of the original base alarm, use "\[original_idx\]" as the parameter index value.

1. Click the underlined field to the right of “and severity”, and select an alarm severity.

   > [!NOTE]
   > If you are using the Correlation rule to group **timeout alarms**, make sure to select a **different severity** than the *Base alarm severity*, because correlated alarms with severity "Timeout" are not supported.

1. If necessary, select one or more of the following options:

   - **Autoclear**: Select this option if you want the Correlation alarm to be cleared automatically as soon as the conditions specified in the Correlation rule are no longer met.

   - **Include name in alarm value**: Select this option if you want the name of the Correlation rule to be included in the alarm value.

   - **Update base alarms**: Select this option to allow the list of base alarms to be updated after a correlated alarm has been generated.

   - **Evaluate value**: Select this option if the alarm value field or parameter row index field of the alarm action contain placeholders. These placeholders consist of Correlation functions enclosed in square brackets. For example, the alarm value could be configured as “Avg value is \[AVG(FIELD(VALUE))\]”. For more information, see [Script condition functions](xref:Script_condition_functions).

   - **Root time of base alarm**: Select this option if you want the root time of the Correlation alarm to be that of the base alarm that triggered its creation.

> [!NOTE]
>
> - You can clear previously generated Correlation alarms from another rule as an action in a Correlation rule, by configuring an alarm with severity “Normal” to be generated on the same parameter.
> - From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38301-->, each Correlation rule checks if it is part of a chain of correlated alarms that led to the correlated alarm it is about to trigger. If it is, it will not trigger again, preventing a situation where rules could endlessly trigger each other.
