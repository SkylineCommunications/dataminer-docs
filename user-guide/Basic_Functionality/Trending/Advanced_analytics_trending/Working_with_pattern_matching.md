---
uid: Working_with_pattern_matching
---

# Working with pattern matching

## Univariate patterns

From DataMiner 10.0.7 onwards, on systems using a Cassandra and Elasticsearch database, DataMiner Analytics can automatically recognize recurring patterns in trend data. For this purpose, you first need to [define the patterns](xref:Defining_a_pattern) DataMiner Analytics needs to track. This pattern definition is also known as a "tag".

If you are viewing a trend graph for a single parameter, and it contains patterns matching existing tags, these will be highlighted in orange when you hover the mouse pointer over the button representing a tag, or if the option *Expand tags* is selected in the right-click menu. The matches can be highlighted in bright orange or in a lighter orange. The meaning of these colors depends on the DataMiner version:

- From DataMiner 10.3.2/10.4.0 onwards: <!-- RN 34947 + RN 34898 -->

  - Matches are highlighted in **lighter orange** if the non-streaming method was used. These matches are detected only when trend data is fetched from the database after you opened a trend graph.
  - Matches are highlighted in **bright orange** if the streaming method was used. These matches are detected while tracking for trend patterns whenever a trended parameter is updated. When such a match is detected, a suggestion event is generated. Matches obtained through the streaming method will be stored in the database.

- In earlier DataMiner versions, matches found for the same element/parameter as the one for which a tag was defined will be shown in bright orange, while matches associated with tags created for another element/parameter will be shown in lighter orange.

> [!NOTE]
>
> - If a protocol is deleted, all patterns defined for parameters of that protocol will also be deleted the first time the SLAnalytics service restarts.
> - Patterns must have a size between 8 and 50,000 data points and should not have more than 5 percent missing values.
> - Pattern matching can only be performed on trended parameters containing numeric values.
> - If pattern matching is performed on a trend graph showing more than 100,000 data points, an aggregated level of detail will be used to improve performance at the cost of accuracy. If, at the most aggregated level, the number of data points exceeds 100,000 data points, no pattern matching will be performed.
> - You can enable or disable this feature via *System Center* > *System settings* > *analytics config.*
> - From DataMiner 10.3.1/10.4.0 onwards, you can also specify the maximum amount of memory that SLAnalytics will use to cache recurring patterns in trend data (in GB). This setting is available via *System Center* > *System settings* > *analytics config.* > *Maximum memory usage*. By default, this is set to 2 GB.

> [!TIP]
> See also: [Monitoring of trend patterns](xref:Monitoring_of_trend_patterns)

## Multivariate patterns

From DataMiner 10.3.8/10.4.0 onwards, DataMiner Analytics can automatically recognize recurring patterns in trend graphs showing trend information of multiple parameters. <!-- RN 36454 + 36731 + 36327 -->

When you open a trend graph showing trend information for multiple parameters, you have the option to define a *multivariate trend pattern*.

As with single-parameter patterns (i.e. [univariate patterns](#univariate-patterns)), you can [specify a number of options](xref:Managing_pattern_definitions) in the *Pattern Overview* window. <!-- RN 35010 -->

If you are viewing a trend graph where one or more of the parameters involved in the multivariate pattern are loaded and multivariate patterns have been detected, these patterns will be highlighted in orange when you hover the mouse pointer over the button representing a pattern, or if the option *Expand tags* is selected in the right-click menu.

The ![multivariate](~/user-guide/images/multivariate_icon.png) icon indicates that the pattern combines trend information from different parameters. By clicking this icon, you can load all trend graphs of the parameters that are part of the pattern. <!-- RN 36628 -->
