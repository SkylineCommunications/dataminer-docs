---
uid: Backing_up_a_DataMiner_Agent
keywords: backup dataminer
---

# Backing up a DataMiner Agent

To back up a DataMiner Agent, you can take an [ad hoc backup using DataMiner Taskbar Utility](xref:Backing_up_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility) or [configure backups in DataMiner Cube](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube), where you can also configure the backups to automatically run on a daily, weekly, or monthly basis. Backups can be stored locally or remotely for added security.

When you back up a DataMiner Agent, you will be able to select different backup types, such as a full backup to restore an entire DataMiner Agent or a backup of the configuration only. In DataMiner Cube, you can even configure a fully customized backup and select which specific items you want to include or exclude.

![Custom backup example](~/dataminer/images/Custom_Backup_Cube.png)<br>*Custom backup configuration in DataMiner Cube 10.5.6*

Note that if you want to back up the data from one or more specific elements to migrate these to a different DMA, the easiest way to do so is by [exporting the data to a .dmimport package](xref:Exporting_and_importing_packages_on_a_DMA).

> [!NOTE]
> The binaries and settings of NAS and NATS are not included in a DataMiner backup. On startup, DataMiner automatically detects whether the NATS folders exist and creates them if necessary. However, this means that if for some reason a problem occurs with your NATS setup, you cannot fix this by means of a backup and restore.

## Self-managed storage backup

If you use self-managed storage instead of the recommended [Storage as a Service (STaaS)](xref:STaaS), please take the following information into account:

- For systems using **Cassandra**:

  If you take a backup of a DataMiner system that uses Cassandra, Cassandra takes snapshots of the database, which are then included in the DataMiner backup package. However, the snapshots Cassandra has taken remain on the disk and are not cleaned up automatically.

  If you wish to manage these snapshots, it is possible to use nodetool, which is provided by Cassandra in the folder `C:\Program Files\Cassandra\bin\`.

  - To check the size of the snapshots, you can run the following command in a command prompt window: *nodetool listsnapshots*.

  - To clean up the snapshots, you can run the following command in a command prompt window: *nodetool clearsnapshot*. This will mark all snapshots as ready for deletion; however, they will only be removed when the Cassandra service is restarted.

  > [!NOTE]
  > To take a backup of the Cassandra database only, from DataMiner 10.2.0/10.1.8 onwards, you can use the [Standalone Cassandra Backup tool](xref:Standalone_Cassandra_Backup_Tool).

- For systems using **OpenSearch**, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups).

- For systems using **Elasticsearch**:

  Taking a backup of a system using Elasticsearch is not possible if no backup path has been specified. See [Configuring Elasticsearch backups](xref:Configuring_Elasticsearch_backups).

  If the backup settings for DataMiner Indexing (i.e. Elasticsearch) have been changed, all Elasticsearch nodes need to be restarted, which may take some time. During this time, no backups can be taken.
