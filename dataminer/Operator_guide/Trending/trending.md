---
uid: trending
---

# Trending

DataMiner trending allows you to check the behavior of specific parameters by means of graphs. In DataMiner Cube and the DataMiner Monitoring app, you can access these graphs [by drilling down on a parameter](xref:Accessing_trend_information_from_a_card) on an element card. DataMiner Cube also has a dedicated [Trending module](xref:Accessing_trend_information_from_the_Trending_module), and it is possible to embed a trending component [in Visual Overview](xref:Linking_a_shape_to_a_trend_component) and [in a DataMiner dashboard](xref:LineAndAreaChart).

![Trending](~/dataminer/images/Trending_UI.png)<br>
*The trending UI in DataMiner 10.3.10*

With the [trending settings](xref:User_settings#trending-settings) in DataMiner Cube, you can customize how graphs are displayed and how you can interact with them.

Based on the available trend data, DataMiner Analytics provides features such as [trend predictions](xref:Working_with_trend_predictions), [anomaly detection](xref:Behavioral_anomaly_detection), [pattern matching](xref:Working_with_pattern_matching), and [relation learning](xref:Working_with_relation_learning).

Trending is configured using so-called [trend templates](xref:About_trend_templates). For each protocol and protocol version, one or more trend templates can be configured. These determine for which parameters trend information is stored, and which kind of trend information (real-time or average).

> [!NOTE]
> For performance reasons, trending should only be activated for a limited number of parameters. Normally, DataMiner administrators will only activate trending for a certain parameter if it makes sense to do so.
