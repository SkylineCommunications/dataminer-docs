---
uid: KI_Engine_location_mandatory_when_configuring_backup_of_external_database
---

# Engine location is mandatory when configuring a backup of an external database

## Affected versions

From DataMiner ... onwards.

## Cause

## Workaround

When configuring a backup for a DataMiner Agent that is using an external Elasticsearch or OpenSearch database, do the following:

1. In the *Indexing Engine Location* section, leave the backup path empty.
1. When prompted, click "No".
1. Modify any other backup setting, and save the configuration.

   The configuration should now have been saved successfully.

## Fix

No fix is available yet.

## Description

When, in DataMiner Cube, you configure a backup for a DataMiner Agent that is using an external Elasticsearch or OpenSearch database, the backup path in the *Indexing Engine Location* section is incorrectly considered a mandatory field.

When configuring a backup for a DataMiner Agent using an external Elasticsearch or OpenSearch database, you should be allowed to leave the backup path field empty.
