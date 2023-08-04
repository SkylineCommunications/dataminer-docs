---
uid: Start_from
---

# Start from

Available from DataMiner 10.1.0/10.1.1 onwards. If another query has already been configured in the dashboard, the *Start from* data source allows you to start from that query and then refine it further.

Prior to DataMiner 10.3.8/10.4.0, if the query you start from is modified, the new query that makes use of it will not be updated unless it is also modified or the dashboard is refreshed. From DataMiner 10.3.8/10.4.0 onwards, updates in base queries (e.g. queries linked to feeds) are automatically taken into account.<!-- RN 36690 -->

> [!NOTE]
> By default, only a limited number of columns will be displayed in the dashboard for certain data sources. For example, for a parameter table, only the first 10 columns are displayed by default. In such a case, you can use the [*Select* operator](xref:GQI_Select) to display other columns or more columns than this default.
