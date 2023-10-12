---
uid: Ad_hoc_Life_cycle
---

# Life cycle of queries with ad hoc data

All methods listed in [Configuring an ad hoc data source in a query](xref:Configuring_an_ad_hoc_data_source_in_a_query) are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following flowchart illustrates the GQI life cycle when a query is created:

![GQI query creation life cycle](~/user-guide/images/GQICreateQuery.png)

The following flowchart illustrates the GQI life cycle when a query is fetched:

![GQI query fetching life cycle](~/user-guide/images/GQIFetchQuery.png)