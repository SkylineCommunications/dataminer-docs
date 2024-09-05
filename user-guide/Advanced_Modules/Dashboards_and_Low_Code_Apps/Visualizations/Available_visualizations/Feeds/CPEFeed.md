---
uid: DashboardCPEFeed
---

# EPM feed

> [!NOTE]
> Prior to DataMiner 10.1.7/10.2.0<!--  RN 29770 -->, this component is called CPE feed instead.

This feed component allows the user to make a filter selection for a particular EPM element (formerly known as CPE Manager) and EPM chain. It can be used as a filter feed for the parameter feed, so that this feed can in turn be used to display info on EPM parameters.

To configure the component:

1. Add an element data feed. This can also be a feed from another feed component.

1. In the *Settings* tab of the component, select the chain that should be filtered by the component and the chain filters that should be available.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Show label*: Determines whether the names of the chain filters are displayed next to the selection boxes in the component.
