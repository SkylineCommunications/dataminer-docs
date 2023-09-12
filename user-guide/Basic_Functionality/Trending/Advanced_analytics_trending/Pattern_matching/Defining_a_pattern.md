---
uid: Defining_a_pattern
---

# Defining a pattern

Before DataMiner Analytics can track specific patterns, you first need to define those patterns:

## [From DataMiner 10.3.6/10.4.0 onwards](#tab/tabid-1)

In a trend graph showing trend information for one single parameter ([univariate patterns](xref:Working_with_pattern_matching#univariate-patterns)) or multiple parameters ([multivariate patterns](xref:Working_with_pattern_matching#multivariate-patterns)), **first select the section of the graph** that you identify as a recurring pattern. The way you can do so depends on the configuration of the trending user settings. See [Trending settings](xref:User_settings#trending-settings).

There are now two ways to define the pattern, a quick way where you use all default options, and a more extensive way where you can customize those options.<!-- RN 36114 -->

- To **quickly** define a pattern, click the tag icon, enter a name for the pattern definition, and click the check mark icon.

- To define a pattern with **custom** options:

  1. Click the tag icon and then click the cogwheel icon.

  1. Enter a name and (optionally) a description.

  1. If you want the patterns to be available for other DataMiner functionality, e.g. to [generate suggestion events](xref:Monitoring_of_trend_patterns) or via the Generic Query Interface in dashboards or low-code apps, select *Continuously detect patterns in the background*.

  1. If you want the patterns to be detected for all elements using the protocol instead of the current element only, next to *Apply to*, click the element name and select the protocol instead.

  1. For a table parameter, if you want the pattern to be selected for all rows in the table instead of the current row only, next to *Apply to*, select *all rows*.

## [Prior to DataMiner 10.3.6/10.4.0](#tab/tabid-2)

1. In a trend graph showing trend information for one single parameter, select the section of the graph that you identify as a recurring pattern.

   The way you can select a section of a graph depends on the configuration of the trending user settings. See [Trending settings](xref:User_settings#trending-settings).

1. Click the tag icon and enter a name for the pattern definition.

1. From DataMiner 10.0.13 onwards, for a table parameter, optionally clear the checkbox *\[Display key instance\] only* if you do not want the display key of the parameter to be taken into account to match the tag.

   > [!NOTE]
   > Prior to DataMiner 10.0.13, patterns can only be detected in the trending for a specific parameter ID, without taking any possible table index into account. Clearing the *\[Display key instance\] only* checkbox therefore results in the behavior of DataMiner versions prior to 10.0.13.

1. From DataMiner 10.0.13 onwards, optionally select *Generate an alarm when detected* to have DataMiner generate a “suggestion event” type of alarm whenever the pattern is detected. DataMiner will then also monitor the affected parameters in real time and save every pattern occurrence in the Elasticsearch database. For more information, see [Monitoring of trend patterns](xref:Monitoring_of_trend_patterns).

1. Click the check mark to save the pattern definition.
