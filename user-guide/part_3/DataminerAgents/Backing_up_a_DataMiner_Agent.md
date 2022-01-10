# Backing up a DataMiner Agent

This section consists of the following topics:

- [Backing up a DataMiner Agent using DataMiner Taskbar Utility](Backing_up_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility.md)

- [Backing up a DataMiner Agent in DataMiner Cube](Backing_up_a_DataMiner_Agent_in_DataMiner_Cube.md)

Please take the following information into account:

- For systems using **Cassandra**:

    If you take a backup of a DataMiner system that uses Cassandra, Cassandra takes snapshots of the database, which are then included in the DataMiner backup package. However, the snapshots Cassandra has taken remain on the disk and are not cleaned up automatically.     If you wish to manage these snapshots, it is possible to use nodetool, which is provided by Cassandra in the folder *C:\\Program Files\\Cassandra\\bin\\*.

    - To check the size of the snapshots, you can run the following command in a command prompt window: *nodetool listsnapshots*.

    - To clean up the snapshots, you can run the following command in a command prompt window: *nodetool clearsnapshot*. This will mark all snapshots as ready for deletion; however, they will only be removed when the Cassandra service is restarted.

    > [!NOTE]
    > To take a backup of the Cassandra database only, from DataMiner 10.2.0/10.1.8 onwards, you can use the [Standalone Cassandra Backup Tool](https://community.dataminer.services/documentation/standalone-cassandra-backup-tool/).

- For systems using **DataMiner Indexing**:

    Taking a backup of a system using DataMiner Indexing is not possible if no Indexing backup path has been specified. See [Configuring Indexing backups](../databases/Configuring_Indexing_backups.md).     If the backup settings for DataMiner Indexing have been changed, all Indexing nodes need to be restarted, which may take some time. During this time, no backups can be taken.

> [!NOTE]
> The binaries and settings of NAS and NATS are not included in a DataMiner backup. On startup, DataMiner automatically detects whether the NATS folders exist and creates them if necessary. However, this means that if for some reason a problem occurs with your NATS setup, you cannot fix this by means of a backup and restore.

> [!TIP]
> See also:
> <https://community.dataminer.services/video/backup-configuring-backups/>
