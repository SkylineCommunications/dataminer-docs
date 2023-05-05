---
uid: Configuring_Elasticsearch_indexing_database_backups
---

# Configuring indexing database backups

Configuring an Elasticsearch indexing database backup is done in the same way as configuring regular Elasticsearch database backups, by taking a snapshot of the Elasticsearch database and later restoring it to a different Elasticsearch database. See [Configuring Elasticsearch backups](xref:Configuring_Elasticsearch_backups).

It is also possible to make a backup using the [Standalone Elastic backup tool](xref:Standalone_Elastic_Backup_Tool). However, as this tool is being deprecated in favor of the snapshot functionality, we strongly recommend that you take database backups using the Elasticsearch snapshot functionality.

> [!TIP]
> See also: [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent).
