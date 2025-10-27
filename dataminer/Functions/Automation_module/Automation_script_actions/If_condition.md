---
uid: If_condition
---

# If condition

Add an If condition to make certain actions in the script depend on one or more conditions.

When you add an If condition, a block is added that consists of three sections:

| Section | Description                                                               |
|---------|---------------------------------------------------------------------------|
| If      | Contains one or more conditions, combined with “and” or “or”.             |
| Then    | Contains actions that will only be executed if the If condition is true.  |
| Else    | Contains actions that will only be executed if the If condition is false. |

To add a condition:

1. Click *Add condition* and select either *Parameter* or *Variable*.

1. If there already is a condition, and either of the conditions may apply, click the default *and* field to select *or* instead. If both conditions should apply at the same time, leave this field as it is.

1. If the condition is based on a variable, specify the variable. The value of the variable can depend on user input, or can be a value returned elsewhere in the script.

1. If the condition is based on a parameter, add a dummy element or choose an existing dummy element, and select the parameter in question.

1. Specify if the variable or parameter should be less than, equal to, or greater than a particular value or variable it is compared to. A combination of these, e.g. “less than or equal to”, is also possible.

1. Specify whether you compare to a value or a variable. Then enter the value or select the variable.

1. Optionally, select the option *Wait for positive result for at most* and enter a time span, in order to make the script wait during the specified period before evaluating the If condition.

> [!NOTE]
> - The *Then* and *Else* sections can in turn also contain If conditions.
> - Add a Sleep action in the *Then* and *Else* sections to specify a period of time during which the Automation script has to pause in order to check if the condition is true or false.
