---
uid: Get_elements
---

# Get elements

The *Get elements* data source retrieves the elements in the DataMiner System. From DataMiner 10.3.3/10.4.0 onwards, *Get elements* also returns alarm states. <!-- RN 35464 -->

Note that from DataMiner Web 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 onwards, property columns for elements are linked to the underlying property by name instead of by ID. This allows queries to be reused across DataMiner Systems where the same property can have a different ID. Existing queries that were created using earlier versions will continue to reference properties by ID to remain backwards-compatible. The existing property columns are marked as legacy columns in the query builder and can be updated manually when necessary. <!-- RN 45085 -->
