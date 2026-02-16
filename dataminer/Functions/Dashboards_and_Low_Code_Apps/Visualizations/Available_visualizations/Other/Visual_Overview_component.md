---
uid: DashboardVisualOverview
---

# Visual overview

This component displays a Visio file linked to an element.

![Visual overview](~/dataminer/images/Visual_Overview.png)<br>*Visual overview component on DataMiner 10.4.3*

To configure this component:

1. In the *Data* pane, select the element for which the visual overview should be displayed and drag it to the component.

1. Optionally, customize the following component options in the *Settings* pane:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Page selection*: In case the Visio drawing consists of several pages, select this checkbox to display a page selection dropdown list at the top of the component.

   - *Default page*: In case the Visio drawing consists of several pages, select the page that should be displayed by default in this dropdown list. Keep in mind that if *Page selection* is not selected, this is the only page the user will be able to see.

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Customize_Component_Layout).

> [!NOTE]
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

## Unsupported capabilities

The visual overviews shown in the DataMiner web apps are a lightweight version of their Cube counterparts. As such, not all functionality that is available in Cube will also be available in the web apps. Below, you can find a list of the main features that are not available in the web apps. However, note that this list is **not exhaustive**.

- [Spectrum components](xref:Embedding_a_Spectrum_Analysis_component).

- Interactivity features of the DataMiner Connectivity Framework (DCF), such as being able to click connection lines.

- Alarm list components (e.g., an [alarm timeline](xref:Embedding_an_alarm_timeline_component) or [filtered Alarm Console](xref:Making_a_shape_filter_Alarm_Console_tabs_when_clicked)).

- [Drag/drop functionalities](xref:Triggering_an_action_when_a_shape_is_dragged_onto_another_shape).

- [Router Control components](xref:Embedding_a_router_control_component).

- [Dynamic list components](xref:Creating_a_list_view).

There are also some differences in functionality:

- If you navigate to an element, service, or view from a visual overview in a DataMiner web app, this will always open the Monitoring app, even if the visual overview is embedded in a dashboard or low-code app.

- Prior to DataMiner 10.4.10<!--RN 40497-->, when you have multiple components that show the same visual overview with user context (e.g., a visual overview with card variables), the contexts of those components are shared. For example, if you click a button on one component, the same action will be mirrored on the other component.
