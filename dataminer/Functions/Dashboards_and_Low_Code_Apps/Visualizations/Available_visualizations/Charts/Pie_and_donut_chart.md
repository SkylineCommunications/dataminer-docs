---
uid: PieAndDonutChart
---

# Pie & donut chart

This component displays the results of queries in a chart shaped like a pie or donut.

![Donut chart](~/dataminer/images/Donut_Chart.png)<br>*Donut chart in DataMiner 10.4.5*

To configure the component:

1. Apply query data. See [Creating a GQI query](xref:Creating_GQI_query).

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *Label*: Allows you to select which data should be used as a label.

   - *Segment size*: Allows you to select which data should determine the size of segments in the chart.

   > [!NOTE]
   > From DataMiner 10.3.7/10.4.0 onwards, when you add a query to the component, the label and segment size will automatically be configured. <!-- RN 36229 -->

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - *Chart shape*: Can be set to *Pie* or *Donut*.

   - *Legend \> Show Legend*: Determines whether the legend is displayed.

   - *Legend \> Show Legend*: If the legend is set to be displayed, this option determines whether it is displayed on the left, on the right, at the top or at the bottom of the visualization.

   - *Tooltips* > *Show Tooltips*: Determines whether tooltips are displayed.

   - *Tooltips* > *Include label*: Determines whether the label is included in tooltips.

   - *Tooltips* > *Include dimension*: Determines whether the dimensions are indicated in tooltips.

   - *Tooltips* > *Include value*: Determines whether values are indicated in tooltips.

   - *Tooltips* > *Include percentages*: Determines whether percentages are indicated in tooltips.

   - *Advanced* \> *Empty Result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results. From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!-- RN 44472 -->, this setting can be cleared, in which case no message is displayed and the component remains empty.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).
