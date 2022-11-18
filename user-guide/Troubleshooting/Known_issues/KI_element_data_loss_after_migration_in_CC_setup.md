---
uid: KI_element_data_loss_after_migration_in_CC_setup
---

# Element data lost after migrating elements in Cassandra Cluster setup

## Affected versions

From DataMiner 10.1.0/10.0.11 onwards.

## Cause

In a Cassandra Cluster setup, migrating an element removes the element data from the database but then imports the element without adding the data again.

## Fix

No fix is available yet.

## Issue description

After migrating an element from one DMA to another, data for this element, including trending and alarm information, is missing. This only occurs in systems where one Cassandra cluster is used as the general database for the entire DMS (i.e. a "Cassandra Cluster" setup).
