---
uid: Element_Cards
---

# Element cards

On the left side of an element card, a collapsible card navigation pane provides access to the pages of the card. You can resize this pane by dragging its right edge.

The following pages are available:

- *Visual*: One or more pages with a Visio-based visual overview of the element.

- *Data*: One or more pages with parameters, as configured in the element protocol. The following icons provide access to additional functionality:

  - ![Wrench icon](~/user-guide/images/MonitoringX_writeparam2.png) : Allows you to modify the value of a parameter. Obsolete from DataMiner 10.3.7/10.4.0 onwards. <!-- RN 36275-->

  - ![Pencil icon](~/user-guide/images/PencilIcon.png): Allows you to edit a parameter (from DataMiner 10.3.7/10.4.0 onwards). <!-- RN 36275 -->

  - ![Histogram icon](~/user-guide/images/MonitoringX_histogram2.png) : Displays a histogram for a trended table parameter.

  - ![Trend graph icon](~/user-guide/images/MonitoringX_trend2.png) : From DataMiner 10.3.7/10.4.0 onwards: Allows you to access the [trending page](xref:Trending_Page).<!-- RN 36352 --> Prior to DataMiner 10.3.7/10.4.0: Allows you to view additional information on a trended parameter. When you click the icon, the parameter description, the parameter ID, and the time of the last change to the parameter are displayed. Below this, the *View trending* option provides access to the [trending page](xref:Trending_Page).

- *Alarms*: Displays the active alarms for the element.

- *Reports*: Displays a page where you can view several different reports related to the element.

- *Dashboards*: Displays the legacy dashboards app.

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.12 onwards, the legacy Dashboards app can be disabled using the soft-launch option *LegacyReportsAndDashboards*. See [Soft-launch options](xref:SoftLaunchOptions).

- *Notes*: Allows you to add and view notes related to the element.

The header bar contains two buttons:

- *State*: Allows you to change the element state (activate, pause, stop or restart)

- *Masking*: Allows you to mask or unmask the element. If you mask the element, a pop-up window will appear in which you need to indicate whether the element should be masked until it is unmasked, masked until the alarm is cleared, or masked for a limited period of time. Optionally, you can also specify a comment.

Element cards can be opened from the navigation or recent items pane, or from the search. In addition, you can also navigate directly to an element using the following URL: <br>*http(s)://*\<DMA IP>*/monitoring/element/*\<DMA ID>*/*\<element ID>*/*\<element page>

The element page in this URL is optional; if it is not specified, the default page is displayed. The page should be specified in the following format: \<*data or visual*\>/\<*page name*\>. <br>For example: *http://**\<DMA IP>**/monitoring/element/67/4/data/Main*
