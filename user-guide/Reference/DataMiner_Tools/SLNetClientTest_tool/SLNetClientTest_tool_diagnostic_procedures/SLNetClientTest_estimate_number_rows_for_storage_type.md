---
uid: SLNetClientTest_estimate_number_rows_for_storage_type
---

# Requesting an estimate of the number of rows for a storage type in the database

From DataMiner 9.5.13 onwards, it is possible to request an estimate of the how many rows there are for a certain storage type in the database.

Retrieving this information via the SLNetClientTest tool instead of via a query has the advantage that you do not risk a timeout of the query. However, for large tables, it can take a while before the estimate is returned.

To request such an estimate:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Database* > *Estimate Count.*

   The *Estimate Database Row Count* window will open.

1. Next to *Type*, select the data type for which you wish to get the estimate.

1. Optionally, next to *Filter*, specify a filter to limit the number of rows that are taken into account.

1. Click *Count*.

   The estimate will be displayed at the bottom of the window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
