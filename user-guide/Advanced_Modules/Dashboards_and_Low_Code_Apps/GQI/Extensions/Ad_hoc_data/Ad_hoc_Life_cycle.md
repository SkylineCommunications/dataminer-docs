---
uid: Ad_hoc_Life_cycle
---

# Life cycle of queries with ad hoc data

All methods listed in [Configuring an ad hoc data source in a query](xref:Configuring_an_ad_hoc_data_source_in_a_query) are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following diagram illustrates in what order each GQI life cycle method is called. Different methods are called depending on whether the query is being build or executed.

![Ad hoc data source life cycle](~/user-guide/images/GQI_AdHocDataSourceLifeCycle.png)
