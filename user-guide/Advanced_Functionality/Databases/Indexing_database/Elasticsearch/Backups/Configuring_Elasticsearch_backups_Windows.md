---
uid: Configuring_Elasticsearch_backups_Windows
---

# Restoring backups using the Standalone Elastic Backup Tool

If your Elasticsearch database does not contain any remote Elasticsearch nodes, you can use database backups created by DataMiner:

- These will be placed in the backup location specified during [Elasticsearch installation](xref:Installing_Elasticsearch_via_DataMiner). From DataMiner 9.6.11 onwards, you can also modify this location in System Center on the *Backup* page, in the section *Indexing Engine location*.

  > [!NOTE]
  >
  > - Restrictions apply for this backup path. See [Restrictions for the backup path](#restrictions-for-the-backup-path).
  > - After you change the path in System Center, it is possible that the UI is temporarily disabled while the Indexing nodes are restarted to implement the change. As such, we recommend that you only change the backup path if this is absolutely necessary.
  > - In DataMiner 9.6.10, the backup path may need to be [specified manually](#manually-specifying-the-backup-path).

- To restore such a backup, use the [Standalone Elastic Backup tool](xref:Standalone_Elastic_Backup_Tool).

- At most one backup per day can be created.

- DataMiner will try to remove old backups so that only the number of backups is kept that is configured in the backup policy (see [Configuring the DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups)). However, if the backups are stored on a network path, this may not be possible in case of insufficient permissions.

Backups for remote Elasticsearch nodes are not managed by DataMiner. You will need to manage backups of such nodes yourself outside DataMiner. You can also use the [Standalone Elastic Backup tool](xref:Standalone_Elastic_Backup_Tool) for this.

## Restrictions for the backup path

Keep the following restrictions in mind for the backup path:

- Do not use a mounted network drive for the backup path, as this is not supported.

- When the Elasticsearch database is backed up, data will only be stored in the location of the specified backup path, regardless of the number of nodes in the Elasticsearch cluster. As such, keep in mind that the path must be accessible for all nodes in the cluster.

- If a login is required to use the specified network path, you must make sure the SYSTEM user has access to the network path.

  1. Open a command window and execute the following command (replacing \[NameOfTask\] with the name of the Windows scheduled task that will be run to provide access to the backup location (e.g. *MountElasticBackupPath*), \[UNC Path\] with the specified path, and \[User\] and \[Password\] with the necessary credentials):

     ```txt
     schtasks /create /tn "[NameOfTask]" /tr "net use [UNC Path] /user:[User] [Password] /persistent:yes" /sc onstart /RU SYSTEM
     ```

  1. Open the Windows task scheduler and execute the task. The SYSTEM user will now have access to the UNC path.

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.8 onwards, it is possible to instead configure specific credentials for the network location via SLNetClientTest tool. See [Specifying credentials for a shared backup path for Elasticsearch](xref:SLNetClientTest_credentials_shared_backup_Elasticsearch).

## Manually specifying the backup path

In DataMiner 9.6.10, in case there is an Elasticsearch node in the cluster that does not have a DataMiner Agent installed, or in case Elasticsearch was installed on a DataMiner Agent prior to DataMiner 9.6.9, the backup path must be specified manually.

To do so:

1. Open the file *C:\\Program Files\\Elasticsearch\\config\\elasticsearch.yml*.

1. In this file, set "path.repo" to the desired backup path.

1. Close the file.

1. Restart the service *elasticsearch-service-x64.exe*.
