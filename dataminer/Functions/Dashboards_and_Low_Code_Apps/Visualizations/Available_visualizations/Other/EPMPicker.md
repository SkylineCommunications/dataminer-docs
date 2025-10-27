---
uid: DashboardEPMPicker
---

# EPM picker

> [!NOTE]
> Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this component is called EPM feed instead.
> Prior to DataMiner 10.1.7/10.2.0<!--  RN 29770 -->, this component is called CPE feed instead.

This picker component allows the user to make a filter selection for a particular EPM element (formerly known as CPE Manager) and EPM chain. It can be used as a filter for the parameter picker, so that this data can in turn be used to display info on EPM parameters.<!-- RN 33977 -->

To configure the component:

1. Add element data. This can also be data from another component.

1. In the *Settings* pane of the component, select the chain that should be filtered by the component and the chain filters that should be available.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Show label*: Determines whether the names of the chain filters are displayed next to the selection boxes in the component.
