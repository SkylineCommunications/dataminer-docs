---
uid: KI_offline_DMA_cannot_sync
---

# Offline Failover DMA not synchronized

## Affected versions

- Main release versions from DataMiner 10.3.0 [CU11] to DataMiner 10.4.0 [CU9].
- Feature release versions from DataMiner 10.4.2 to DataMiner 10.4.12.
<!-- Introduced by RN 32951 -->

## Cause

A race condition could prevent the offline DMA in a Failover pair from synchronizing with the online DMA because the DataMiner version could not be found.

## Fix

Install DataMiner 10.4.0 [CU10] or DataMiner 10.5.1.<!-- RN 41527 -->

## Description

The offline DMA in a Failover pair does not properly sync with the online DMA, causing possible data loss in case of a Failover switch to the offline DMA.
