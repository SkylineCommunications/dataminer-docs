---
uid: PieAndDonutChart
---

# Pie & donut chart

This component displays the results of queries in a chart shaped like a pie or donut. It is available from DataMiner 10.0.13 onwards.

To configure the component:

1. Apply a query data feed. See [Creating a GQI query](xref:Creating_GQI_query).

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *Label*: Allows you to select which data should be used as a label.

   - *Segment size*: Allows you to select which data should determine the size of segments in the chart.

   > [!NOTE]
   > From DataMiner 10.3.7/10.4.0 onwards, when you add a query to the component, the label and segment size will automatically be configured. <!-- RN 36229 -->

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - *Chart shape*: Can be set to *Pie* or *Donut*.

   - *Legend \> Show Legend*: Available from DataMiner 10.0.13 onwards. Determines whether the legend is displayed.

   - *Legend \> Show Legend*: Available from DataMiner 10.0.13 onwards. If the legend is set to be displayed, this option determines whether it is displayed on the left, on the right, at the top or at the bottom of the visualization.

   - *Tooltips* > *Show Tooltips*: Available from DataMiner 10.0.13 onwards. Determines whether tooltips are displayed.

   - *Tooltips* > *Include label*: Available from DataMiner 10.0.13 onwards. Determines whether the label is included in tooltips.

   - *Tooltips* > *Include dimension*: Available from DataMiner 10.0.13 onwards. Determines whether the dimensions are indicated in tooltips.

   - *Tooltips* > *Include value*: Available from DataMiner 10.0.13 onwards. Determines whether values are indicated in tooltips.

   - *Tooltips* > *Include percentages*: Available from DataMiner 10.0.13 onwards. Determines whether percentages are indicated in tooltips.
