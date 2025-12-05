---
uid: Pattern_matching
---

# Pattern matching

DataMiner Analytics can automatically recognize recurring patterns in trend data. You can [define such patterns](xref:Defining_a_pattern) in DataMiner Cube in trend graphs showing trend information for a single parameter ([univariate patterns](#univariate-patterns)) or for multiple parameters ([multivariate patterns](#multivariate-patterns)). Such a pattern definition is also known as a "tag".

This feature requires a DataMiner System using [Storage as a Service](xref:STaaS) (recommended) or a [self-managed Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures)

## Univariate patterns

If you are viewing a trend graph for a single parameter, and it contains patterns matching existing tags, these will be highlighted in orange when you hover the mouse pointer over the button representing a tag, or if the option *Expand tags* is selected in the right-click menu. For example:

![Pattern matching](~/dataminer/images/Pattern_Matching.png)<br>*Univariate pattern in DataMiner 10.4.5*

The matches can be highlighted in bright orange or in a lighter orange. The meaning of these colors depends on the DataMiner version:

- From DataMiner 10.3.2/10.4.0 onwards: <!-- RN 34947 + RN 34898 -->

  - Matches are highlighted in **lighter orange** if the non-streaming method was used. These matches are detected only when trend data is fetched from the database after you opened a trend graph.
  - Matches are highlighted in **bright orange** if the streaming method was used. These matches are detected while tracking for trend patterns whenever a trended parameter is updated. When such a match is detected, a suggestion event is generated. Matches obtained through the streaming method will be stored in the database.

    > [!NOTE]
    > Prior to DataMiner 10.3.10/10.4.0, Cube will not display new matches that are detected while a trend graph is open. You need to close and reopen the trend graph to see this. In more recent DataMiner versions<!-- RN 37153-->, pattern matches are shown in real time.

- In earlier DataMiner versions, matches found for the same element/parameter as the one for which a tag was defined will be shown in bright orange, while matches associated with tags created for another element/parameter will be shown in lighter orange.

> [!NOTE]
> If a protocol is deleted, all patterns defined for parameters of that protocol will also be deleted the first time the SLAnalytics service restarts.

## Multivariate patterns

From DataMiner 10.3.8/10.4.0 onwards, DataMiner Analytics can automatically recognize recurring patterns in trend graphs showing trend information of multiple parameters. <!-- RN 36454 + 36731 + 36327 -->

When you open a trend graph showing trend information for multiple parameters, you have the option to define a *multivariate trend pattern*.

As with single-parameter patterns (i.e. [univariate patterns](#univariate-patterns)), you can [specify a number of options](xref:Managing_pattern_definitions) in the *Pattern Overview* window. <!-- RN 35010 -->

If you are viewing a trend graph where one or more of the parameters involved in the multivariate pattern are loaded and multivariate patterns have been detected, these patterns will be highlighted in orange when you hover the mouse pointer over the button representing a pattern, or if the option *Expand tags* is selected in the right-click menu.

The ![multivariate](~/dataminer/images/multivariate_icon.png) icon indicates that the pattern combines trend information from different parameters. By clicking this icon, you can load all trend graphs of the parameters that are part of the pattern, as illustrated below. <!-- RN 36628 -->

![Multivariate pattern in trend graph](~/dataminer/images/blog_multiPM.gif)<br>*Multivariate pattern in DataMiner 10.3.12*

> [!NOTE]
> From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards<!--RN 36661-->, trend patterns of all parameters are loaded onto the trend graph. Prior to DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12, only the trend pattern of the first parameter is loaded onto the trend graph.

## Pattern matching configuration in System Center

In DataMiner Cube, you can configure this feature in System Center, via *System Center* > *System settings* > *analytics config* > *Pattern matching*. The following settings are available there:

- *Enabled*: Allows you to activate or deactivate this feature.

- *Maximum memory usage*: From DataMiner 10.3.1/10.4.0 onwards, this allows you to specify the maximum amount of memory that SLAnalytics will use to cache recurring patterns in trend data (in GB). By default, this is set to 2 GB.

## Limitations

- Patterns must have a size between 8 and 50,000 data points and should not have more than 5 percent missing values.
- Pattern matching can only be performed on trended parameters containing numeric values.
- If pattern matching is performed on a trend graph showing more than 100,000 data points, an aggregated level of detail will be used to improve performance at the cost of accuracy. If, at the most aggregated level, the number of data points exceeds 100,000 data points, no pattern matching will be performed.
- Prior to DataMiner 10.3.12/10.4.0<!--RN 37451-->, DataMiner Analytics cannot detect multivariate patterns containing subpatterns hosted on different DMAs.
