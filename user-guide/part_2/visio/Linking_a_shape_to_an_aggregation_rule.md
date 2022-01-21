---
uid: Linking_a_shape_to_an_aggregation_rule
---

## Linking a shape to an aggregation rule

From DataMiner 9.0.2 onwards, it is possible to display aggregated parameter values in Visual Overview by linking shapes to aggregation rules.

To do so:

1. Add a shape data field of type **Aggregation** to the shape that you want to link to an aggregation rule.

2. Configure the value of the shape data field in one of the following ways:

    - Without using a placeholder: Set the value to the DMA ID/element ID of the hidden *Skyline Generic Aggregator* element, followed by a colon and the relevant aggregation index. You can find the relevant DMA ID/element ID by looking in the *Element.xml* file for this hidden element in the *Elements* folder on the DMA. You can find the index by going to the aggregation page of a view, selecting the aggregation rule, and then checking the *Index* column in the *table* tab.

    - Using a placeholder: Set the value to *\[AggregationRule: folder/rule, viewID, protocol, element property, view property, remote primary key\]*.

| Shape data field | Value                                                                                                                                                                                                                                                                                        |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Aggregation      | *dmaID*/*elementID*:4005:*aggregationIndex*<br> or<br> \[AggregationRule: *folder/rule, viewID, protocol, element property, view property, remote primary key*\] |

> [!NOTE]
> The above-mentioned *AggregationRule* placeholder can also be used in a trend component, a pie chart, a bar chart, a column chart, a stacked area chart and a parameter summary.
>
> For more information on the placeholder, see [\[AggregationRule: ...\]](Placeholders_for_variables_in_shape_data_values.md#aggregationrule).
>
