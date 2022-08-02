---
uid: KI_Migration_of_Ticketing_data_from_Cassandra_to_Elasticsearch_fails
---

# Migration of Ticketing data from Cassandra to Elasticsearch fails

## Affected versions

- All main release version from DataMiner 10.1.0 onwards.
- All feature release versions from DataMiner 10.0.13 onwards.

## Cause

Elasticsearch does not support certain characters that are supported in Cassandra:

- An underscore (`_`) at the beginning of a field name (e.g. _testField)
- Any of the following characters, regardless of where they occur in a field name: `.`, `#`, `*`, `,`, double quotation mark (`"`) or single quotation mark (`'`).

## Issue description

After an upgrade to DataMiner versions 10.1.0/10.0.13 or higher, Ticketing data are automatically migrated from Cassandra to Elasticsearch. However, the migration fails in case characters are encountered that are not supported in Elasticsearch.

All invalid fields will be listed in the *SLMigrationManager.txt* log file.

Prior to DataMiner 10.1.10, no notification is displayed when this occurs. From DataMiner 10.1.0 \[CU7] and 10.1.10 onwards, a message will inform the user of the failure and how to resolve the problem.

## Workaround

A different workaround should be used depending on whether the Ticketing data from Cassandra is still needed.

### If the Cassandra Ticketing data is no longer needed

If you do not intend to use the Ticketing data stored in Cassandra, you can manually disable the migration procedure.

To do so, do the following on each DMA in the cluster:

1. Open the file `C:\Skyline DataMiner\Ticketing\ElasticTicketingMigration_OneTimeMigrationStatus.json`.

1. Change the contents of the file so that the number for the status property is 3.

   ```json
   {
     "$type": "Skyline.DataMiner.Net.OneTimeMigration.OneTimeMigrationStatus, SLNetTypes",
     "Status": 3,
     "Migration": 3
   }
   ```

### If the Cassandra Ticketing data must be migrated

If you do want to migrate the Cassandra Ticketing data, you will need to find the invalid fields and ensure that they no longer contain the characters Elasticsearch does not support.

To do so:

1. Check the *SLMigrationManager.txt* log file to find all invalid fields.
1. Downgrade your DataMiner System to a version prior to DataMiner 10.1.0 (Main Release) or 10.0.13 (Feature Release).
1. Open the Ticketing app.
1. Click the cogwheel button to access the domain and field configuration.
1. Find the invalid fields in the lists, and create corresponding new fields with the same settings, but a valid name (E.g. "FirstName" instead of "First.Name").
1. When you have created all new fields, copy the ticketing data to these fields. To do so, open each ticket and transfer the value of the invalid fields to the valid ones. Leave the invalid fields empty.
1. After you have transferred the values for all fields, go back to the configuration page and delete all invalid ticket fields.
1. Upgrade the DMS to the new DataMiner version. The migration should now be executed successfully on each DMA during the first startup.

> [!NOTE]
> If your system contains too much data to do this manually, contact us to request a script for this.
