---
uid: KI_Closed_alarms_migrated_too_slowly
---

# Closed alarms migrated too slowly from dms-activealarms index in Elasticsearch database

## Affected versions

Any DataMiner version, if an Elasticsearch database is used for alarm indexing.

## Cause

When alarms are closed, they need to be migrated from the *dms-activealarms* index to the *dms-alarms* in the Elasticsearch database. However, this migration is limited to 1000 records per 15 minutes, which is not fast enough for very active systems. This means that for such systems, the *dms-activealarms* index can keep growing indefinitely.

## Fix

Upgrade to DataMiner 10.2.0 CU8 or 10.2.11.

## Issue description

More alarms than strictly required are in the *dms-activealarms* index of the Elasticsearch database. This causes the index to grow larger than it should.
