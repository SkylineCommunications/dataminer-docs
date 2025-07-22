---
uid: KI_DataMiner_reports_Cassandra_issue_when_another_database_fails
---

# DataMiner incorrectly reports a Cassandra issue when another database fails

## Affected versions

From DataMiner 10.4.0 onwards.

## Cause

The storage health monitoring logic incorrectly identifies the failing database. As a result, DataMiner attributes the issue to Cassandra, even if the actual problem lies with another database, such as Elasticsearch or OpenSearch.

## Workaround

Restore the affected database to its working state.

## Fix

Install DataMiner 10.4.11/10.5.0<!--RN 40488-->.

## Description

In DataMiner Cube, an error message related to Cassandra is displayed, even though the underlying issue may be with another database, such as Elasticsearch or OpenSearch.
