---
uid: KI_Engine_location_mandatory_when_configuring_backup_of_external_database
description: "Learn what to do when the Indexing Engine Location backup path is incorrectly considered mandatory when you configure backups with an external database."
---

# Engine location is mandatory when configuring a backup of an external database

## Affected versions

From DataMiner 10.2.0 [CU19]/10.3.0 [CU7]/10.3.10 onwards.

## Cause

When, in DataMiner Cube, you configure a backup for a DataMiner Agent that is using an external Elasticsearch or OpenSearch database, the backup path in the *Indexing Engine Location* section is incorrectly considered a mandatory field.

## Workaround

When configuring a backup for a DataMiner Agent that is using an external Elasticsearch or OpenSearch database, do the following:

1. In the *Indexing Engine Location* section, leave the backup path empty.

1. When prompted, click "No".

1. Modify any other backup setting, and save the configuration.

   The configuration should now be saved successfully.

## Fix

No fix is available yet.

## Description

As DataMiner will not automatically take backups of external Elasticsearch/OpenSearch databases, the *Indexing Engine location* backup configuration field should be left empty if such a database is used. However, this is not possible as the field is considered mandatory.
