---
uid: DashboardStepper
---

# Stepper

Available from DataMiner 10.3.10/10.4.0 onwards.

This visualization takes a stateful object manager instance or object manager definition as data input and displays their respective states. This component simplifies complex workflows by breaking them down into distinct numbered or labeled steps.

To configure the component:

1. Apply a data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

   - When applying a DataMiner object manager (DOM) definition, the component will display states along the typical path of that definition, i.e. the happy path. This path illustrates the states an instance would undergo following the standard workflow.

     > [!NOTE]
     > DOM definitions can only be applied to the stepper component within the Low-Code Apps module.

   - When applying a DOM instance, the component will display the complete history of each state the instance has traversed until its current state. Based on the current state, it calculates and displays the remaining states along the happy path.

1. Fine-tune the component layout. In the *Component > Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Appearance*: Allows you to select a template from the dropdown list of 13 templates.
