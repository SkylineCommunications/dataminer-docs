---
uid: Configuring_Indexing_backups
---

# Configuring Indexing backups

Backups of the Indexing database are not included in a DataMiner restore package. Instead, the backups are stored at a fixed location, which must be specified during the installation of DataMiner Indexing (see [Installing DataMiner Indexing Engine](xref:Installing_DataMiner_Indexing_Engine)). This location is the same for all Indexing servers in the cluster.

Keep the following restrictions in mind for the backup path:

- Do not use a mounted network drive for the backup path, as this is not supported.

- When the Indexing database is backed up, data will only be stored in the location of the specified backup path, regardless of the number of nodes in the Indexing cluster. As such, keep in mind that the path must be accessible for all nodes in the cluster.

- If a login is required to use the specified network path, you must make sure the SYSTEM user has access to the network path.

    1. Open a command window and execute the following command (replacing \[NameOfTask\] with the name of the Windows scheduled task that will be run to provide access to the backup location (e.g. *MountElasticBackupPath*), \[UNC Path\] with the specified path, and \[User\] and \[Password\] with the necessary credentials):

        ```txt
        schtasks /create /tn "[NameOfTask]" /tr "net use [UNC Path] /user:[User] [Password] /persistent:yes" /sc onstart /RU SYSTEM
        ```

    2. Open the Windows task scheduler and execute the task. The SYSTEM user will now have access to the UNC path.

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.8 onwards, it is possible to instead configure specific credentials for the network location via SLNetClientTest tool. See [Specifying credentials for a shared backup path for Elasticsearch](xref:SLNetClientTest_tool_advanced_procedures#specifying-credentials-for-a-shared-backup-path-for-elasticsearch).

- At most one backup per day can be taken.

- DataMiner will try to remove old backups so that the only the number of backups are kept that is configured in the backup policy (see [Configuring the DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups)). However, if the backups are stored on a network path, this may not be possible in case of insufficient permissions.

In DataMiner 9.6.10, in case there is an Indexing server in the cluster that does not have a DataMiner Agent installed, or in case Indexing was installed on a DataMiner Agent prior to DataMiner 9.6.9, the backup path must be specified manually.

To do so:

1. Open the file *C:\\Program Files\\Elasticsearch\\config\\elasticsearch.yml*.

2. In this file, set "path.repo" to the desired backup path.

3. Close the file.

4. Restart the service *elasticsearch-service-x64.exe*.

From DataMiner 9.6.11 onwards, you can modify the Indexing backup path in System Center, on the *Backup* page, in the section *Indexing Engine location*.

> [!NOTE]
> - After you change the path in System Center, it is possible that the UI is temporarily disabled while the Indexing nodes are restarted to implement the change. As such, we recommend to only change the backup path if this is absolutely necessary.
> - From DataMiner 10.0.0 \[CU15\]/10.1.0 \[CU3\]/DataMiner 10.1.6 onwards, the **Indexing database is not included in a DataMiner restore**. To restore it, you should instead use the [Standalone Elastic Backup tool](https://community.dataminer.services/documentation/standalone-elastic-backup-tool/).
> - Backups for remote Elasticsearch nodes are not managed by DataMiner. You will need to manage backups of such nodes yourself outside of DataMiner. You can use the [Standalone Elastic Backup tool](https://community.dataminer.services/documentation/standalone-elastic-backup-tool/) for this.
>
