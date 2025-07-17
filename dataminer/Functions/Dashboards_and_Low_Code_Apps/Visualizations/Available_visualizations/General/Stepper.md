---
uid: DashboardStepper
---

# Stepper

Available from DataMiner 10.3.10/10.4.0 onwards<!-- RN 37200 -->.

This component is used to guide the user through a workflow by splitting it up into different numbered or labeled steps. It indicates the progress through the workflow by showing the past steps, current step, and future steps. The component uses a stateful DOM instance or DOM definition (i.e. a DOM instance or DOM definition that contains states) as data input.

![Stepper](~/dataminer/images/StepperComponent.png)<br>*Stepper component in DataMiner 10.3.10*

To configure the component:

1. Apply DOM definition or DOM instance data. See [Adding data to a component](xref:Adding_data_to_component).

   You can apply a DOM definition or DOM instance directly, or use e.g. data based on a table component, so that the stepper will display the information linked to the item selected in the table component.

   - When a DOM definition is applied, this will be used to display states along the typical path of the definition, i.e. the "happy path". This path illustrates the states an instance would undergo following the standard workflow.

     > [!NOTE]
     > DOM definitions can only be applied to the stepper component within the Low-Code Apps module.

   - When a DOM instance is applied, this will be used to display the current state, preceded by the states the instance has traversed until its current state, and followed by the future states it will go through if it follows the normal flow.

     > [!NOTE]
     >
     > - If the DOM history saving behavior of a module has been set to *Disabled* in [the `DomInstanceHistorySettings` object](xref:DOM_DomInstanceHistorySettings), the stepper component will not show the actual history of traversed states for any DOM instances. Instead, from DataMiner 10.3.11/10.4.0 onwards<!--RN 37233-->, instances without a history calculate the happy path from the initial state to the current state and then to the final state. In DataMiner 10.3.10, instances without a history only calculate the happy path from the current state to the final state.
     > - The DOM instance history objects are by default stored asynchronously, which enhances performance. In DataMiner 10.3.10<!-- RN 37252-->, asynchronous saving may result in an outdated history when retrieved. In such cases, the path between the incomplete history and the current state is also completed according to the standard flow.

1. Fine-tune the component layout. In the *Component > Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Appearance*: Allows you to select a template. This determines among others whether steps are numbered, whether check marks are displayed for steps that are completed, etc.

   > [!NOTE]
   > From DataMiner 10.3.11 onwards<!--RN 37242-->, text will automatically wrap onto a new line when it reaches the edge of the label box, using available horizontal and vertical space. If the text exceeds the label's capacity, it will be truncated with an ellipsis. In DataMiner 10.3.10, long names that exceed the label length are cut off.
