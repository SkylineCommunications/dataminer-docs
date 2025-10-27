---
uid: Managing_pattern_definitions
---

# Managing pattern definitions

From DataMiner 10.3.6/10.4.0 onwards<!-- RN 36114 -->, you can get an overview of all available pattern definitions for a specific parameter or across all parameters in the DMS.

To do so, right-click a trend graph and select *Trend patterns*. This will open the *Pattern Overview* window. By default, this window will only list the existing patterns that apply to the trend graph you have opened. If you select *Show all patterns*, it will list all patterns found in the DataMiner System.

If you select a pattern definition in the list on the left, you can then modify it on the right:

- Change the **name**.
- Change the **description**.
- Select whether patterns should be **continuously detected in the background**. If this is selected, the patterns will also become available in other DataMiner functionality, e.g. to [generate suggestion events](xref:Monitoring_of_trend_patterns) or in the Generic Query Interface in dashboards or low-code apps.
- Select whether the pattern should be detected for a **specific element**, or for **all elements using that same protocol**.
- For a table parameter, select whether the pattern should be detected for a **specific row** only, or for **all rows in the table**.

You can also **delete** a pattern definition using the recycle bin icon next to it in the list on the left.

> [!NOTE]
> From DataMiner 10.3.8/10.4.0 onwards, the *Pattern Overview* window also supports [multivariate patterns](xref:Working_with_pattern_matching#multivariate-patterns)<!-- RN 35010 -->.
