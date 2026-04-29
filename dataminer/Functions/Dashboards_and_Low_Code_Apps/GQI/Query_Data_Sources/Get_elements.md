---
uid: Get_elements
---

# Get elements

The *Get elements* data source retrieves the elements in the DataMiner System. From DataMiner 10.3.3/10.4.0 onwards, *Get elements* also returns alarm states. <!-- RN 35464 -->

From DataMiner Web 10.6.6 [CU0] (MR 10.5.0 CU15/10.6.0 [CU3]) onwards, property columns for elements will be linked to the underlying property by name instead of by ID. This allows queries to be reused across DataMiner systems where the same property can have a different ID. Existing queries will still reference properties by ID to remain backwards compatible. The existing property columns will be marked as legacy columns in the query builder and can be updated manually when necessary. <!-- RN 45085 -->
