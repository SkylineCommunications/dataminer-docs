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
> Quick filters are supported for table parameters in visual overview components. See [Using quick filters](xref:Using_quick_filters).

## Zooming

Zooming functionalities are available for the Visual Overview component.

- From DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->, the zooming method depends on the *Advanced* > *Hold Ctrl to zoom* setting in the *Settings* pane:

  - When this setting is enabled: Hold the Ctrl key while scrolling up or down to zoom in or out.

  - When this setting is disabled: Scroll up or down to zoom in or out.

- From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9<!--RN 40017--> up to DataMiner 10.4.0 [CU9]/10.4.12:

  - To zoom in, press Ctrl while scrolling up.

  - To zoom out, press Ctrl while scrolling down.

- Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9:

  - To zoom in, scroll up.

  - To zoom out, scroll down.

## Unsupported Capabilities

> [!NOTE]
>
> This list is not complete.

Mobile Visual Overviews were always considered a lightweight version of their Cube counterparts. It's therefore never been guaranteed that the same functionalities will work there as well.

- Spectrum components
- In versions prior to DataMiner 10.4.10<!--RN 40497-->, when you have multiple components that show the same visual overview with user context (e.g. a visual overview with card variables), the contexts of those components are shared. For example, if you click a button on one component, the same action will be mirrored on the other component.
- DataMiner Connectivity Framework (DCF) lacks much of its interactivity features, such as being able to click connection lines.
- Navigating to elements/services/views will always open the monitoring app, even if you are within the context of a Dashboard or Low Code App.
- Components/Apps that do not exist as visualizations in mobile such as Router Control, Dynamic List...
- Alarm list components.
- Drag/Drop functionalities.
