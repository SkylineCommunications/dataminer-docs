---
uid: Installing_DataMiner_Indexing_Engine
---

## Installing DataMiner Indexing Engine

To install DataMiner Indexing Engine:

1. In DataMiner Cube, go to *System Center \> Search & Indexing* and click *Install Indexing Engine*.

    > [!NOTE]
    > - If Cassandra is not installed on all DMAs in the system, the Indexing installation button will not be available.
    > - This requires the user permission *System configuration* > *System Settings* > *Indexing engine* > *Configure*.

2. In the installation wizard, click *Check system requirements*.

    The wizard will then check whether your system meets the requirements listed above. If any requirements are not met, this will be indicated, and you will be able to close the wizard again in order to continue later after the necessary changes have been made. In case changes are implemented while the wizard is open, a button is available that allows you to refresh the validation data.

3. Optionally, in case you only wish to install the Indexing Engine on some of the DMAs in the system, clear the checkbox to the left of the DMAs where it should not be installed.

    > [!NOTE]
    > You will only be able to start the installation if the required minimum number of Agents in the DMS is selected. This minimum number depends on the total number of DMAs in the system. If there are 3 or less DMAs in the system, all DMAs must be selected, otherwise at least 3 DMAs must be selected.

4. At the bottom of the installation window, in the *Backup path* box, specify the network path where the backup of the Indexing database should be stored.

    > [!NOTE]
    > Specific criteria apply for the backup path, as detailed in [Configuring Indexing backups](Configuring_Indexing_backups.md). Make sure the backup path meets these criteria, as an **incorrect backup configuration can cause the installation to fail**.

5. If your configuration meets the requirements, click *Next*.

6. If you have internet access, click *Download and install*, and then enter your DCP credentials. If you do not have internet access, click *I have no internet access*, and browse to the location of the installation package on your system.

    The progress of the download will then be indicated at the top of the window.

    > [!NOTE]
    > Do not close the installation window while the installation package is uploaded and unpacked. If you do so, the installation process will stop. After the actual installation process has begun, it will continue even if the window is closed.

7. You can follow the progress of the installation in the progress table, which has several tabs:

    - Overview: Displays a short summary of the installation progress.

    - General: Displays all actions in the order in which they occur.

    - \[DMA name\]: Displays the progress for the DMA in question.

    To view all details of the installation process, select *Show details*.

8. Once the installation has been completed, restart DataMiner to make sure all functionality is available.

    > [!NOTE]
    > - After the Indexing Engine is installed, it may take a while before the indexing of all history alarms is complete.
    > - Service & Resource Management is not automatically migrated. For more information on how to trigger the migration, see [Configuring DataMiner Indexing](Configuring_DataMiner_Indexing.md).

Remarks on the DataMiner Indexing Engine installation

- When several DMAs in a DataMiner System have an indexing database installed, all indexes in all those indexing databases will be linked. That way, when a search is done on one DMA, all indexing databases in the DataMiner System are queried.

- If an indexing database is installed on a Failover system, a database instance will be installed on each of the DMAs, and both instances will be clustered. Also, when a DMA with an indexing database and a DMA without an indexing database are combined into a Failover system, a new database instance will be created on the latter DMA, and both instances will be clustered. When a DMA is removed from a Failover system, the indexing database instance on that DMA is removed from the cluster.

- In a DataMiner System, there must be at least 2 master nodes. By default, the 3 DataMiner Agents with the lowest DataMiner ID will act as master nodes.

- Prior to DataMiner 10.0.1, it is possible to set *Location* to *Remote* in the installation wizard. However, as this is not supported in later versions of DataMiner, we strongly recommend not to use this option.

- Alarms in the indexing database are kept in two separate tables, one for active alarms and one for closed alarms.

- At present, adding remote Elasticsearch nodes is only possibly by installing Elasticsearch manually on the nodes, and then connecting the DMS to the nodes using an *InstallElasticAndMigrateRequest* message in a script. For example:

    ```txt
    var request = new InstallElasticAndMigrateRequest();
    request.RemoteOptions = RemoteOptions.Remote(new string[] { "10.11.51.58" , "10.11.52.58" , "10.11.53.58" });
    ```

- When you install the Indexing database, TLS is not enabled by default. For information on how to enable this, go to [Configuring TLS and security in Elasticsearch](https://community.dataminer.services/documentation/configuring-tls-and-security-in-elasticsearch/) on Dojo.
