---
uid: Installing_Elasticsearch_via_DataMiner
---

# Installing Elasticsearch on a DMA via DataMiner

> [!IMPORTANT]
> This procedure is intended for a setup using a Cassandra database per DMA. If you use the [Cassandra Cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) feature, you will need to install Elasticsearch on a separate Linux machine. See [Installing Elasticsearch](xref:Installing_Elasticsearch_on_separate_Linux_machine).

To install Elasticsearch on a DataMiner Agent via DataMiner:

1. In DataMiner Cube, go to *System Center \> Search & Indexing* and click *Install Indexing Engine*.

   > [!NOTE]
   >
   > - If Cassandra is not installed on all DMAs in the system, the Indexing installation button will not be available.
   > - This requires the user permission *System configuration* > *System Settings* > *Indexing engine* > *Configure*.

1. In the installation wizard, click *Check system requirements*.

   The wizard will then check whether your system meets the requirements listed above. If any requirements are not met, this will be indicated, and you will be able to close the wizard again in order to continue later after the necessary changes have been made. In case changes are implemented while the wizard is open, a button is available that allows you to refresh the validation data.

1. Optionally, in case you only wish to install Elasticsearch on some of the DMAs in the system, clear the checkbox to the left of the DMAs where it should not be installed.

   > [!NOTE]
   > You will only be able to start the installation if the required minimum number of Agents in the DMS is selected. This minimum number depends on the total number of DMAs in the system. If there are 3 or less DMAs in the system, all DMAs must be selected, otherwise at least 3 DMAs must be selected.

1. At the bottom of the installation window, in the *Backup path* box, specify the network path where the backup of the Elasticsearch database should be stored.

   > [!NOTE]
   > Specific criteria apply for the backup path, as detailed in [Configuring Elasticsearch backups](xref:Configuring_Elasticsearch_backups). Make sure the backup path meets these criteria, as an **incorrect backup configuration can cause the installation to fail**.

1. If your configuration meets the requirements, click *Validate*, and then *Next*.

1. If you have internet access, click *Download and install*, and then enter your DCP credentials. If you do not have internet access, click *I have no internet access*, and browse to the location of the installation package on your system.

   The progress of the download will then be indicated at the top of the window.

   > [!NOTE]
   > Do not close the installation window while the installation package is uploaded and unpacked. If you do so, the installation process will stop. After the actual installation process has begun, it will continue even if the window is closed.

1. You can follow the progress of the installation in the progress table, which has several tabs:

   - Overview: Displays a short summary of the installation progress.

   - General: Displays all actions in the order in which they occur.

   - \[DMA name\]: Displays the progress for the DMA in question.

   To view all details of the installation process, select *Show details*.

1. Once the installation has been completed, restart DataMiner to make sure all functionality is available.

   > [!NOTE]
   >
   > - After the Elasticsearch is installed, it may take a while before the indexing of all history alarms is complete.
   > - Service & Resource Management is not automatically migrated. For more information on how to trigger the migration, see [Configuring Elasticsearch in System Center](xref:Configuring_DataMiner_Indexing).

Remarks on the Elasticsearch installation:

- If an Elasticsearch database is installed on a Failover system, a database instance will be installed on each of the DMAs, and both instances will be clustered. Also, when a DMA with an Elasticsearch database and a DMA without an Elasticsearch database are combined into a Failover system, a new database instance will be created on the latter DMA, and both instances will be clustered. When a DMA is removed from a Failover system, the Elasticsearch database instance on that DMA is removed from the cluster.

- In a DataMiner System, there must be at least 2 master nodes. By default, the 3 DataMiner Agents with the lowest DataMiner ID will act as master nodes.

- Prior to DataMiner 10.0.1, it is possible to set *Location* to *Remote* in the installation wizard. However, as this is not supported in later versions of DataMiner, we strongly recommend not to use this option.

- Alarms in the Elasticsearch database are kept in two separate tables, one for active alarms and one for closed alarms.

- Unless your DataMiner System uses the [Cassandra Cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) feature, to add a remote Elasticsearch node, you need to install Elasticsearch manually on the node, and then connect the DMS to the node using an *InstallElasticAndMigrateRequest* message in a script. For example:

    ```txt
    var request = new InstallElasticAndMigrateRequest();
    request.RemoteOptions = RemoteOptions.Remote(new string[] { "10.11.51.58" , "10.11.52.58" , "10.11.53.58" });
    ```

  > [!NOTE]
  > For systems using the Cassandra Cluster feature, use the [Cassandra Cluster Migrator](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) tool instead.

- When you install Elasticsearch, TLS is not enabled by default. For information on how to enable this, see [Securing the Elasticsearch database](xref:Security_Elasticsearch).
