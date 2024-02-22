---
uid: KI_elements_not_loading_in_DMS_with_multiple_ES
---

# Elements not loading after upgrade of DMS with multiple Elasticsearch clusters

## Affected versions

Feature release versions from DataMiner 10.3.10 to 10.4.1.

## Cause

DataMiner 10.3.10 added a new *ID* attribute to the *ElasticCluster* tag in *DBConfiguration.xml*. In setups with multiple Elasticsearch clusters, existing files did not have this tag and did not get updated automatically, which made it impossible to load information from the Elasticsearch database in Cube.

## Workaround

Execute the following procedure for each DataMiner Agent in your DMS:

1. Stop DataMiner.

1. Open the file `C:\Skyline DataMiner\database\DBConfiguration.xml`.

1. Add the *ID* attribute to each *ElasticSearch* tag, and set it to a unique integer.

   For example:

   <ElasticCluster priorityOrder="0" ID="0">

   > [!NOTE]
   > Make sure the *ID* attribute for a specific *ElasticCluster* node is consistent across the different DMAs in the cluster (even if the *priorityOrder* is different).

1. Save and close the file.

1. Start DataMiner

## Fix

Install DataMiner 10.4.2.<!-- RN 37446 -->

## Description

In a DataMiner System using multiple Elasticsearch clusters, after an upgrade to DataMiner 10.3.10 or higher, elements can no longer be loaded in DataMiner Cube and Cube incorrectly reports that there is no active search database.
