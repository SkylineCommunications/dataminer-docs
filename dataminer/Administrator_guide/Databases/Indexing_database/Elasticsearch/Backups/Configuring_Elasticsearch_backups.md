---
uid: Configuring_Elasticsearch_backups
---

# Configuring Elasticsearch backups

> [!IMPORTANT]
> Elasticsearch is **only supported up to version 6.8**, which is no longer supported by Elastic. We therefore recommend using [Storage as a Service](xref:STaaS) instead, or if you do want to continue using self-managed storage, using [OpenSearch](xref:OpenSearch_database).

Backups of the Elasticsearch database are not included in a DataMiner restore package.

There are two methods to configure Elasticsearch backups:

- [Taking and restoring snapshots](xref:Configuring_Elasticsearch_backups_Windows_Linux): We strongly recommend that you use this method. It is applicable to both Windows and Linux.

- [Restoring backups using the Standalone Elastic Backup Tool](xref:Configuring_Elasticsearch_backups_Windows): This method can only be used with a Windows setup.
