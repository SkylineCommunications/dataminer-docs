---
uid: Triggering_a_parameter_set
---

# Triggering a parameter set

To make a Correlation rule trigger a parameter set:

1. In the *Actions* section of the details pane, click *Add Action* and select *Set parameter*.

1. Click the first underlined field and select an element from the list.

1. Click the second underlined field and select a parameter from the list.

1. Click the underlined field to the right of “with value” and enter the value to which the parameter should be set.

   > [!NOTE]
   > For a matrix parameter, when you click this field, you can select an input and output and indicate whether these should be connected.

1. If necessary, select one or more of the following options:

   - **Execute on clear**: Select this option to also set the parameter at the moment when the conditions triggering the rule are no longer fulfilled.

   - **Execute on base alarm updates**: Select this option to also set the parameter when the base alarms change.

   - **Evaluate value**: Select this option to allow placeholders in the parameter value. For more information, see [Correlation rule syntax](xref:Correlation_rule_syntax).
