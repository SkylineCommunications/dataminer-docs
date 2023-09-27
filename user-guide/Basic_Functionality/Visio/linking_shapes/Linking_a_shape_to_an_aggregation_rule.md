---
uid: Linking_a_shape_to_an_aggregation_rule
---

# Linking a shape to an aggregation rule

From DataMiner 9.0.2 onwards, it is possible to display aggregated parameter values in Visual Overview by linking shapes to aggregation rules.

To do so:

1. Add a shape data field of type **Aggregation** to the shape that you want to link to an aggregation rule.

1. Configure the value of the shape data field in one of the following ways:

   - **Without using a placeholder**: Specify the following items, in the order specified, separated by colons:

     1. The DMA ID/element ID of the hidden *Skyline Generic Aggregator* element. You can find this DMA ID/element ID by looking in the *Element.xml* file for this hidden element in the *Elements* folder on the DMA.

     2. The fixed parameter ID of the aggregator element, i.e. 4005.

     3. The relevant aggregation index. You can find the index by going to the aggregation page of a view, selecting the aggregation rule, going to the *table* tab, right-clicking a column-header, selecting *Columns* in the right-click menu, and enabling the *Index* column.

     | Shape data field | Value |
     |--|--|
     | Aggregation | *dmaID*/*elementID*:4005:*aggregationIndex* |

     For example:

     ```txt
     345/1088:4005:c720c5d8387c41988c327bf26de8d5ef.337.-1
     ```

   - **Using a placeholder**: Set the value to *\[AggregationRule: folder/rule, viewID, protocol, element property, view property, remote primary key\]*.

     | Shape data field | Value |
     |--|--|
     | Aggregation | [AggregationRule: *folder/rule, viewID, protocol, element property, view property, remote primary key*] |

     For example:

     ```txt
     [AggregationRule:Ziine/VisioPlaceHolderSample,337]
     ```

> [!NOTE]
> The above-mentioned *AggregationRule* placeholder can also be used in a trend component, a pie chart, a bar chart, a column chart, a stacked area chart, and a parameter summary. For more information on this placeholder, see [\[AggregationRule: ...\]](xref:Placeholders_for_variables_in_shape_data_values#aggregationrule).
