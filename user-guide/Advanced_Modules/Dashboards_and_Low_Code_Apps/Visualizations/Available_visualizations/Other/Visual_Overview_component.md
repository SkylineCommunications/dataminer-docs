---
uid: DashboardVisualOverview
---

# Visual overview

This component displays a Visio file linked to an element.

To configure this component:

1. In the *Data* tab, select the element for which the visual overview should be displayed and drag it to the component.

1. Optionally, customize the following component options in the *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Page selection*: In case the Visio drawing consists of several pages, select this checkbox to display a page selection drop-down list at the top of the component.

   - *Default page*: In case the Visio drawing consists of several pages, select the page that should be displayed by default in this drop-down list. Keep in mind that if *Page selection* is not selected, this is the only page the user will be able to see.

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

> [!NOTE]
>
> - Spectrum components are currently not yet supported in visual overviews within dashboards or low-code apps.
> - Quick filters are supported for table parameters in visual overview components from DataMiner 10.0.12 onwards. See [Using quick filters](xref:Using_quick_filters).
