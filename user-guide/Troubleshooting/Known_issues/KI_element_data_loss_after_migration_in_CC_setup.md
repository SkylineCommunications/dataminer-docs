---
uid: KI_element_data_loss_after_migration_in_CC_setup
---

# Element data lost after migrating elements in Cassandra Cluster setup

## Affected versions

- DataMiner 10.1.0 up to 10.2.0 [CU11]
- DataMiner 10.0.11 up to 10.3.1

## Cause

In a Cassandra Cluster setup, migrating an element removes the element data from the database but then imports the element without adding the data again.

## Fix

Upgrade to DataMiner 10.2.0 [CU12] or 10.3.2. <!-- RN 35213 -->

> [!NOTE]
> Migrating trend data between different clusters is still not possible. Within the same cluster, trend data will not be removed when you migrate elements from one DMA to another.

## Issue description

After migrating an element from one DMA to another, data for this element, including trending and alarm information, is missing. This only occurs in systems where one Cassandra cluster is used as the general database for the entire DMS (i.e. a "Cassandra Cluster" setup).
