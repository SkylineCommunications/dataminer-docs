---
uid: KI_Elasticsearch_not_initialized_on_DMA_startup
---

# Elasticsearch not initialized when DataMiner starts up

## Affected version

Any DataMiner version using an Elasticsearch database.

## Cause

Elasticsearch knows two important structures to query: indices and aliases. Indices contain the data, whereas aliases are groups of indices that you can query as if they were a single index.

When DataMiner attempts to write to an alias that does not exist, for example because it has been deleted manually, Elasticsearch will automatically create it as an index containing data. The next time DataMiner starts up, it will attempt to create the alias again, and this will conflict with the index that Elasticsearch created. This causes the Elasticsearch initialization to fail.

This can for example occur in case excessively large indices were deleted manually while the DMS was running, e.g. the alias/index *dms-active-info* for an SRM setup.

## Workaround

Stop DataMiner, delete the affected indices in Elasticsearch, and restart DataMiner.

> [!WARNING]
> The data in the deleted indices will be lost. Contact Skyline Communications if you have any doubts.

## Fix

No fix is available yet.

## Issue description

Elasticsearch does not get initialized when DataMiner starts up. Errors mention that the Elasticsearch database is not connected.

In *SLDBConnection.txt*, there are errors mentioning an invalid alias name because an index with that name already exists. For example:

```txt
CreateInitialIndexIfNotExists - Attempt 1/10 failed with exception: Elasticsearch.Net.ElasticsearchClientException: The remote server returned an error: (400) Bad Request.. Call: Status code 400 from: PUT /%3Cdms-info-%7Bnow%7Byyyy.MM.dd.HH%7D%7D-000001%3E. ServerError: Type: invalid_alias_name_exception Reason: "Invalid alias name [dms-active-info], an index exists with the same name as the alias" ---> System.Net.WebException: The remote server returned an error: (400) Bad Request.
```

If the Elasticsearch database is queried at `http://[database IP]:9200/_cat/indices?v&s=index:desc`, the indices mentioned in *SLDBConnection.txt* are found to be present (e.g. *dms-active-info*, *dms-active-alarms*, *dms-suggest-info*, *dms-suggest-patokens*, or *dms-suggest-paprocess*).