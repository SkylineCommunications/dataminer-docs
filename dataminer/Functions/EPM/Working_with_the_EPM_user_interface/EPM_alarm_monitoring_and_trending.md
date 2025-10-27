---
uid: EPM_alarm_monitoring_and_trending
---

# EPM alarm monitoring and trending

Though in some aspects alarming and trending work in the same way as for regular elements, there are some differences for EPM elements:

- An alarm template can be applied to an EPM element just like for a regular DataMiner element. See [Assigning an alarm template](xref:Assigning_an_alarm_template).

- Alarming can be applied on the different available parameters, both on directly retrieved data and on aggregated data.

- Root causes for alarms can be visualized within the topology diagrams, but can also be determined by making an internal connectivity chain for the EPM element. See [Working with the Connectivity Editor](xref:Working_with_the_Connectivity_Editor).

- Depending on the protocol of the EPM element, topology diagrams can feature alarm bubble-up.

  - If the “ShowBubbleupAndInstanceAlarmLevel” option is used, each box in the topology diagram will have the color indicating the alarm level of the item in question, and the lower border will have the color of the bubble-up alarm level, indicating the highest alarm level of the underlying items.

  - If there are too many items to show them all separately in the topology diagram, a summary box is displayed with a list of items. In this box, the bubble-up alarm level is indicated to the left of each item, while the background color of each item indicates the alarm level of the item itself.

- Depending on the protocol, the alarm severity level is shown in the second column of the tables.

- If an alarm on a particular device in an EPM environment is masked, the device will be shown as having a “normal” state in the EPM user interface.

- Like in regular dynamic tables, for trended parameters, a trend icon is shown in tables of the EPM element.

- If trending is activated, you can access the trend graph for a parameter by clicking the trend graph icon displayed next to the parameter in the EPM user interface.

  The trend graph will be shown in a separate window.

- If trending is activated, you can access the histogram for KPIs by clicking the histogram icon next to the KPI in the EPM user interface.

  The histogram will open in a separate window. In this window, you can select a different KPI and level to group on in order to load a different histogram.

- Trending information for EPM elements, unlike for regular elements, is not kept for years for individual objects.

- If you filter down to a particular level of the overview and then open trending, a filter is displayed at the top of the trending legend, indicating the name and value of the field above the one where trending was opened. The index in the legend indicates the values filtered for that parent field. If you clear the filter at the top, the index will act similarly to the filter field in the EPM environment.

- In case you load trending for a [partial table](xref:Table_parameters#partial-tables), you will only see the specific entry from the page containing the relevant index. To load extra pages, select them in the corresponding drop-down list.
