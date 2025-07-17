---
uid: KI_SLLog_issue_when_large_alarm_tree_is_closed
---

# SLLog issue when large alarm tree is closed

## Affected versions

- DataMiner 10.2.0 [CU8] and [CU9]
- DataMiner 10.2.11 and 10.2.12

## Cause

When an alarm tree is closed and DataMiner tries to move it from the *activealarms* Elasticsearch index to the *alarms* index, a tree gets inserted in one bulk request. For trees that are very large (e.g. lengthy history, or a lot of properties or base alarms), the query could become too big and get refused by Elastic. The query was then logged via SLLog, which triggered a problem in that process because of the size of the log statement.

## Fix

Upgrade to DataMiner 10.2.0 [CU10] or 10.3.1.

## Workaround

Depending on the exact cause, a workaround can be to delete an excessively large alarm tree from the *activealarms* index. This can be done with a query in [Kibana](https://www.elastic.co/kibana/) or [Elasticvue](https://elasticvue.com/), but the exact query depends on the DataMiner version and on the configuration of the system.

For example:

```txt
POST /dms-activealarms/_delete_by_query
{ 
      "query":
      {   
            "match":
            {     
                  "DmaId_RootAlarmID": "17/36470196"
            } 
      }
}
```

or

```txt
POST /dms-activealarms/_delete_by_query
{ 
      "query":
      {   
            "match":
            {     
                  "RootAlarmID": "30274729"
            } 
      }
}
```

The prefix before *activealarms* (*dms-* in the examples above) can be different depending on your configuration.

To find the root alarm ID for the alarm tree, contact Skyline Communications.

## Issue description

In systems using an Elasticsearch database, large alarm trees could cause a problem in the SLLog process, triggering a DataMiner restart.
