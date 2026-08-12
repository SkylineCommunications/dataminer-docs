---
uid: KI_Data_loss_after_ES_to_OS_migration
description: "Learn how to recognize and work around data loss caused by index TTL and rollover flaws after an Elasticsearch to OpenSearch migration."
---

# Data loss after Elasticsearch to OpenSearch migration

## Affected versions

DataMiner Systems with dedicated clustered storage that have performed an Elasticsearch to OpenSearch migration.

## Cause

A combination of flaws in index TTL management and rollover behavior causes erroneous indices to accumulate and then expire together, resulting in data loss:

- SLDataGateway manages index TTL based on the index name (e.g., `dms-alarms-2025-04`), while index rollover is based on the index provided name template (e.g., `dms-alarms-func(date())`).
- Reindexing during the migration rewrites current indices with a string literal as the provided name (this cannot be set directly), in order to preserve TTL.
- SLDataGateway does not validate the name template during rollover, and it does not roll over empty indices.

This leads to erroneous indices such as `dms-alarms-2025-04-00001`, `dms-alarms-2025-04-00002`, `dms-alarms-2025-04-00003`, and so on. These all expire at the same time when the TTL calculation checks the name, causing data loss.

## Fix

A fix is being developed.<!-- RN 46168 --> We recommend waiting with any further Elasticsearch to OpenSearch migrations until the fix is available.

## Workaround

Please [contact DataMiner Support](xref:Contacting_tech_support) if your system is affected by this issue, so they can rectify any erroneous indices for you.

## Description

After an Elasticsearch to OpenSearch migration, data loss can occur over time. Alarm data and other indexed data disappears after a period, typically once the TTL for a batch of incorrectly named indices expires simultaneously.

You can diagnose this issue in two ways:

- **Using Elasticvue**: Inspect the latest indices created for `dms-alarms` using [Elasticvue](https://elasticvue.com/). If the date in the most recent alarm indices does not correspond to the current period but instead all indices are incrementing on an old date (e.g., `dms-alarms-2025-04-00001`, `dms-alarms-2025-04-00002`, ...), your system is affected.

- **Using the OpenSearch Get Index API**: Use the [Get Index](https://docs.opensearch.org/latest/api-reference/index-apis/get-index/) call to retrieve the index object. Check the `provided_name` field in the settings of the most recent index in the alias. If `provided_name` is a string literal rather than a date-based template expression, the issue is present.
