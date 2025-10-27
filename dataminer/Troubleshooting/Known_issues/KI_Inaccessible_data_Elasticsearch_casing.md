---
uid: KI_Inaccessible_data_Elasticsearch_casing
---

# Inaccessible logger table data in Elasticsearch because of incorrect casing

## Affected versions

- From DataMiner 10.3.0 to 10.3.0 [CU2].
- From DataMiner 10.3.3 to 10.3.5.

## Cause

If a logger table that has `Indexing` set to `true` contains column names with uppercase characters, SLDataGateway incorrectly changes these column names to lower case. This leads to the data getting stored in a different field than expected and therefore not being retrieved when requested.

## Fix

Install DataMiner 10.3.0 [CU3]/10.3.6<!-- RN 36343 -->. You can then recover the data by launching a `POST <loggertableAlias>/_update_by_query` with the following body (adjusted to reflect your column names):

```json
{
    "query": {
        "bool": {
            "must_not": {
                "exists": {
                    "field": "<Correctly cased ColumnName>"
                }
            }
        }
    },
    "script": {
        "inline": "ctx._source.<CorrectlyCasedFieldName1> = ctx._source.<lowercasedfieldname1>; ctx._source.remove(\"<lowercasedfieldname1>\");ctx._source.<CorrectlyCasedFieldName2> = ctx._source.<lowercasedfieldname2>; ctx._source.remove(\"<lowercasedfieldname2>\");...<!--repeat for every field in the loggertable-->"
    }
}
```

## Issue description

Data stored in a logger table in Elasticsearch appears to be inaccessible. Exceptions about missing fields are thrown.

When you investigate by using a `POST <loggertableIndex>\_search` in Kibana or Elasticvue with the following body, results are returned in the response:

```json
{
    "query": {
        "bool": {
            "must": {
                "exists": {
                    "field": "<lowercased variant of a columnname>"
                }
            }
        }
    }
}
```
