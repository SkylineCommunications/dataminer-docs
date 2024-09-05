---
uid: DashboardVisualOverview
---

# Visual overview

This component displays a Visio file linked to an element.

![Visual overview](~/user-guide/images/Visual_Overview.png)<br>*Visual overview component on DataMiner 10.4.3*

To configure this component:

1. In the *Data* tab, select the element for which the visual overview should be displayed and drag it to the component.

1. Optionally, customize the following component options in the *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Page selection*: In case the Visio drawing consists of several pages, select this checkbox to display a page selection dropdown list at the top of the component.

   - *Default page*: In case the Visio drawing consists of several pages, select the page that should be displayed by default in this dropdown list. Keep in mind that if *Page selection* is not selected, this is the only page the user will be able to see.

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Customize_Component_Layout).

> [!NOTE]
>
> - Spectrum components are currently not yet supported in visual overviews within dashboards or low-code apps.
> - Quick filters are supported for table parameters in visual overview components. See [Using quick filters](xref:Using_quick_filters).
> - In versions prior to DataMiner Web 10.4.10<!--RN 40497-->, when you have multiple components that show the same visual overview with user context (e.g. a visual overview with card variables), the contexts of those components are shared. For example, if you click a button on one component, the same action will be mirrored on the other component.

## Zooming

Zooming functionalities are available for the Visual Overview component.

- From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 40017-->:

  - To zoom in, press CTRL while scrolling up.

  - To zoom out, press CTRL while scrolling down.

- Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9:

  - To zoom in, scroll up.

  - To zoom out, scroll down.
