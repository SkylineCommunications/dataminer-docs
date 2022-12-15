---
uid: Configuring_Elasticsearch_backups
---

# Configuring Elasticsearch backups

Backups of the Elasticsearch database are not included in a DataMiner restore package. Instead, the backups are stored at a fixed location, which must be specified during the Elasticsearch installation (see [Installing Elasticsearch](xref:Installing_Elasticsearch_via_DataMiner)). This location is the same for all Elasticsearch nodes in the cluster.

There are two methods to configure an Elasticsearch backup:

- [Taking and restoring snapshots](xref:Configuring_Elasticsearch_backups_Windows_Linux): We strongly recommend you use this method as it is applicable to both Windows and Linux and explains how to first make a backup and afterwards restore it again.

- [Manually specifying the backup path](xref:Configuring_Elasticsearch_backups_Windows): This method explains how to make a backup, but can only be used with a Windows-setup.
