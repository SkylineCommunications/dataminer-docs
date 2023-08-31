---
uid: DashboardStepper
---

# Stepper

Available from DataMiner 10.3.10/10.4.0 onwards<!-- RN 37200 -->.

This component is used to guide the user through a workflow by splitting it up into different numbered or labeled steps. It indicates the progress through the workflow by showing the past steps, current step, and future steps. The component uses a stateful DOM instance or DOM definition (i.e. a DOM instance or DOM definition that contains states) as data input.

To configure the component:

1. Apply a DOM definition or DOM instance data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

   You can apply a DOM definition or DOM instance directly, or use e.g. a feed based on a table component, so that the stepper will display the information linked to the item selected in the table component.

   - When a DOM definition is applied, this will be used to display states along the typical path of the definition, i.e. the "happy path". This path illustrates the states an instance would undergo following the standard workflow.

     > [!NOTE]
     > DOM definitions can only be applied to the stepper component within the Low-Code Apps module.

   - When a DOM instance is applied, this will be used to display the current state, preceded by the states the instance has traversed until its current state, and followed by the future states it will go through if it follows the normal flow.

1. Fine-tune the component layout. In the *Component > Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Appearance*: Allows you to select a template. This determines among others whether steps are numbered, whether check marks are displayed for steps that are completed, etc.
