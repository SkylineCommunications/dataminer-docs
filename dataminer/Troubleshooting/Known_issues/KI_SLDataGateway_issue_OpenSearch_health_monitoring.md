---
uid: KI_SLDataGateway_issue_OpenSearch_health_monitoring
---

# SLDataGateway issue caused by OpenSearch health monitoring

## Affected versions

Dedicated clustered storage setups using DataMiner 10.5.0 [CU11]/10.6.2.

## Cause

Because of changes introduced in DataMiner 10.5.0 [CU11]/10.6.2, with certain D*B.xml* configurations or recent OpenSearch versions, the search database can be stuck in the RED health state and SLDataGateway can crash at startup.

## Fix

Install the latest, patched version of DataMiner 10.5.0 [CU11] or DataMiner 10.6.2 [CU1].<!-- RN 44647 -->

## Description

After upgrading to DataMiner 10.5.0 [CU11]/10.6.2, SLSearchHealth.txt reports issues with the health monitor, and it can occur that SLDataGateway crashes at startup.
