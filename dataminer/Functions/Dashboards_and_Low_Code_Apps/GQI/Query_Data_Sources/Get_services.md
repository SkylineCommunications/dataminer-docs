---
uid: Get_services
description: "Use the Get services GQI data source to retrieve services and their alarm states, and learn how it handles property and legacy columns."
---

# Get services

The *Get services* data source retrieves the services in the DataMiner System. From DataMiner 10.3.3/10.4.0 onwards, *Get services* also returns alarm states. <!-- RN 35464 -->

Note that from DataMiner Web 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 onwards, property columns for services are linked to the underlying property by name instead of by ID. This allows queries to be reused across DataMiner Systems where the same property can have a different ID. Existing queries that were created using earlier versions will continue to reference properties by ID to remain backwards-compatible. The existing property columns are marked as legacy columns in the query builder and can be updated manually when necessary. <!-- RN 45085 -->

From DataMiner 10.6.0 [CU10]/10.7.0/10.7.1 onwards, the GQI DxM marks the *HasAnnotations* column as legacy because the Annotations module has been deprecated. <!-- RN 47144 -->
You can no longer select this column when building a new query, but existing queries that already use it continue to work. For details, see [how the query builder handles hidden items](xref:Creating_GQI_query#notes-on-gqi-queries).
