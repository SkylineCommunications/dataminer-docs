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

     > [!NOTE]
     >
     > - If the DOM history saving behavior of a module has been set to *Disabled* in [the `DomInstanceHistorySettings` object](xref:DOM_DomInstanceHistorySettings), the stepper component will not show a history of traversed states for any DOM instances. From DataMiner 10.3.11/10.4.0 onwards<!--RN 37233-->, instances without a history display the happy path from the initial state to the current state. In DataMiner 10.3.10, instances without a history calculate the path from the initial state to the current state as if they followed the standard flow, similar to a happy path.
     > - The DOM instance history objects are by default stored asynchronously, which enhances performance but may result in an outdated history when retrieved. In such cases, the path between the incomplete history and the current state is also completed according to the standard flow.

1. Fine-tune the component layout. In the *Component > Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Appearance*: Allows you to select a template. This determines among others whether steps are numbered, whether check marks are displayed for steps that are completed, etc.
