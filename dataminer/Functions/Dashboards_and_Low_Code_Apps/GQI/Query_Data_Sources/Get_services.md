---
uid: Get_services
---

# Get services

The *Get services* data source retrieves the services in the DataMiner System. From DataMiner 10.3.3/10.4.0 onwards, *Get services* also returns alarm states. <!-- RN 35464 -->

From DataMiner Web 10.6.6 [CU0] (MR 10.5.0 CU15/10.6.0 [CU3]) onwards, columns representing custom properties of a service will be represented in GQI by their name instead of their ID. This ensures that when queries are exported to other DataMiner systems that have the same custom properties, the query remains executable. Queries created before this version that reference custom property columns will remain working, and these columns will be suffixed with `(Legacy)` when selected within the query builder. <!-- RN 45085 -->
