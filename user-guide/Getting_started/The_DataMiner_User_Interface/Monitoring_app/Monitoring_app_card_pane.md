---
uid: Monitoring_app_card_pane
---

# Monitoring app card pane

The card pane of the Monitoring app is the large pane on the right side of the app. If no cards are opened, this pane displays the app homepage, which shows a list of recent items. If a card is opened, the displayed content depends on the type of card.

- [View cards](#view-cards)

- [Service cards](#service-cards)

- [Element cards](#element-cards)

- [Alarm cards](#alarm-cards)

- [CPE cards](#cpe-cards)

- [Spectrum analyzer cards](#spectrum-analyzer-cards)

> [!NOTE]
>
> - If the app is used on a mobile device, to make optimal use of the available space on the screen, the app layout may be different from what is described in this section.
> - If the app is viewed in a browser that supports fullscreen mode, for parameter tables, data pages, CPE/EPM pages and visual pages, a fullscreen button is available: ![Fullscreen button](~/user-guide/images/CubeMaximize00028.png)
>
>   Click this button to view the item in fullscreen mode. To leave fullscreen mode using a keyboard, press Esc or F11, depending on the browser.

## View cards

On the left side of a view card, a collapsible card navigation pane provides access to the pages of the card. You can resize this pane by dragging its right edge.

The following pages are available:

- *Visual*: One or more pages with a Visio-based visual overview of the view.

- *Below this view*: Contains pages listing the different elements and services in the view and its subviews.

- *Alarms*: Displays the active alarms for the view.

- *Reports*: Displays the DataMiner reports related to the view.

- *Histogram*: Available from DataMiner 10.0.3 onwards. Allows you to display a histogram of a protocol parameter for all elements of this protocol in the view. The parameter can be selected in the sidebar on the right. Once a valid parameter has been selected, you can click *Show histogram* to show or refresh the histogram. The side panel also has a settings tab where you can apply the following options:

  - *Include subviews*: Only displayed in case the view contains other views. Determines whether those subviews should also be taken into account.

  - *Use relative frequency*: Determines whether the frequency on the Y-axis should be shown in percent.

  - *Use custom intervals*: Allows you to specify a custom number of intervals and interval range.

- *Notes*: Allows you to add and view notes for the view.

View cards can be opened from the navigation or recent items pane, or from the search. In addition, you can also navigate directly to a view using the following URL: <br>*http(s)://*\<DMA IP>*/monitoring/view/*\<view ID>*/*\<view page>

The view page in this URL is optional; if it is not specified, the default page is displayed. To go to a visual page, specify *visual/*\<view page>. For example: *http://*\<DMA IP>*/monitoring/view/103/visual/0*

## Service cards

On the left side of a service card, a collapsible card navigation pane provides access to the pages of the card. You can resize this pane by dragging its right edge.

The following pages are available:

- *Visual*: One or more pages with a Visio-based visual overview of the service.

- *Children*: Contains the data pages of the elements contained within the service. If the service contains a child service, this is also listed under *Children* in the navigation pane, but clicking or tapping the child service will open the card of this child service.

- *Alarms*: Displays the active alarms for the service.

- *Reports*: Displays the DataMiner reports related to the service.

- *Notes*: Allows you to add and view notes for the service.

Service cards can be opened from the navigation or recent items pane, or from the search. In addition, you can also navigate directly to a service using the following URL: <br>*http(s)://*\<DMA IP>*/monitoring/service/*\<DMA ID>*/*\<service ID>*/*\<service page>

The service page in this URL is optional; if it is not specified, the default page is displayed.

- To go to a visual page, specify *visual/*\<service page>.
<br>For example: *http://*\<DMA IP>*/monitoring/service/67/511/visual/0*

- To go to the page of one of the service children, specify *child/*\<page name>. The page name consists of the DMA ID, the element ID and the page name, separated by %2F.<br>For example: *http://*\<DMA IP>*/monitoring/service/67/511/child/67%2F509%2FPerformance*

## Element cards

On the left side of an element card, a collapsible card navigation pane provides access to the pages of the card. You can resize this pane by dragging its right edge.

The following pages are available:

- *Visual*: One or more pages with a Visio-based visual overview of the element.

- *Data*: One or more pages with parameters, as configured in the element protocol. The following icons provide access to additional functionality:

  - ![Wrench icon](~/user-guide/images/MonitoringX_writeparam2.png) : Allows you to modify the value of a parameter.

  - ![Histogram icon](~/user-guide/images/MonitoringX_histogram2.png) : Displays a histogram for a trended table parameter.

  - ![Trend graph icon](~/user-guide/images/MonitoringX_trend2.png) : Allows you to view additional information on a trended parameter. When you click the icon, the parameter description, the parameter ID, and the time of the last change to the parameter are displayed.

    Below this, the *View trending* option provides access to the **trending page**, where you can view a trend graph or histogram for the parameter. On the left, the time span for the trend graph can be configured.

    From DataMiner 10.3.3/10.4.0 onwards, the header of a trend card shows a breadcrumb trail. Navigate back to the element card item by clicking it in the breadcrumb trail.

    From DataMiner 10.3.4/10.4.0 onwards, you can easily switch between the trend graph and histogram for the parameter by clicking the corresponding icons in the top-right corner of the trending page:

    - ![Trending](~/user-guide/images/Trending.png) : Displays the trend graph for the parameter.

    - ![Histogram](~/user-guide/images/Histogram.png) : Displays to the histogram for the parameter.

    > [!NOTE]
    > From DataMiner 10.2.0 [CU10]/10.3.1 onwards, the Monitoring app also supports trend graphs for string parameters.

- *Alarms*: Displays the active alarms for the element.

- *Reports*: Displays a page where you can view several different reports related to the element.

- *Dashboards*: Displays the legacy dashboards app.

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.12 onwards, the legacy Dashboards app is no longer available by default in new DataMiner installations. To enable it, set the soft-launch option *LegacyReportsAndDashboards* to true. See [Soft-launch options](xref:SoftLaunchOptions).

- *Notes*: Allows you to add and view notes related to the element.

The header bar contains two buttons:

- *State*: Allows you to change the element state (activate, pause, stop or restart)

- *Masking*: Allows you to mask or unmask the element. If you mask the element, a pop-up window will appear in which you need to indicate whether the element should be masked until it is unmasked, masked until the alarm is cleared, or masked for a limited period of time. Optionally, you can also specify a comment.

Element cards can be opened from the navigation or recent items pane, or from the search. In addition, you can also navigate directly to an element using the following URL: <br>*http(s)://*\<DMA IP>*/monitoring/element/*\<DMA ID>*/*\<element ID>*/*\<element page>

The element page in this URL is optional; if it is not specified, the default page is displayed. The page should be specified in the following format: \<*data or visual*\>/\<*page name*\>. <br>For example: *http://**\<DMA IP>**/monitoring/element/67/4/data/Main*

## Alarm cards

Alarm cards in the Monitoring app display the following information:

- *Current value*: The current value of the parameter in alarm. If it is a write parameter, you can click the wrench icon to modify the parameter value.

- *Details*: Detailed alarm information, such as the status of the alarm, the alarm owner, etc.

- *Properties*: The properties of the alarm and the element on which the alarm occurred.

- *Impact*: The elements, services and views affected by the alarm.

In the header of the card, two buttons are available:

- *Mask*: Allows you to mask or unmask the alarm or element. If you mask the alarm or element, a pop-up window will appear in which you need to indicate whether the alarm or element should be masked until it is unmasked, masked until the alarm is cleared, or masked for a limited period of time. Optionally, you can also specify a comment.

- *Ownership*: Allows you to take or release ownership of the alarm.

Alarm cards can be accessed from the Alarm Console, but you can also navigate directly to an alarm card by specifying the following URL:
<br>*http://*\<DMA IP>*/monitoring/alarm/*\<DMA ID>*/*\<alarm ID>

## CPE cards

On the left side of a CPE card, a collapsible card navigation pane provides access to the pages of the card. You can resize this pane by dragging its right edge.

The following pages are available:

- The pages that are available for element cards: see [Element cards](#element-cards).

- *Topology*: One or more pages with the different chains in the topology. When you open such a page, filter boxes on the right side of the card can be used to drill down to specific items.

CPE cards can be opened from the navigation or recent items pane, or from the search. In addition, you can also navigate directly to a CPE element using the following URL: <br>*http(s)://*\<DMA IP>*/monitoring/element/*\<DMA ID>*/*\<element ID>*/chain/*\<chain name>

> [!TIP]
> See also:
> [Working with the Experience and Performance Management interface](xref:Working_with_the_Experience_and_Performance_Management_interface)

## Spectrum analyzer cards

A spectrum analyzer card is similar to an element card, but has a special "Spectrum Analyzer" page. From DataMiner 10.0.4 onwards, if you open this spectrum page, a spectrum trace using a new monitor with the most recent preset will be displayed.

From DataMiner 10.0.5 onwards, the Spectrum Analyzer page contains buttons to the following tabs:

| Button | Tab description |
|--|--|
| ![Info button](~/user-guide/images/MonitoringX_spectruminfo.png) | Information tab. Contains basic information about the current measurement points, markers, thresholds and parameters. If no markers or thresholds are available for the current preset, these sections are not displayed in the tab. |
| ![Traces button](~/user-guide/images/MonitoringX_spectrumtraces.png)   | Traces tab. Allows you to select whether the current, minimum, maximum and/or average trace should be displayed. However, if a measurement point is selected, only the current trace can be shown. |
| ![Presets button](~/user-guide/images/MonitoringX_spectrumpresets.png) | Presets tab. This tab shows a list of all available presets. By default, only private presets are shown, i.e. presets that are only available to the current user. To view all presets, select Show shared presets. Select a preset and click Load to display it on the spectrum page. |
