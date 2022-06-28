---
uid: Moving_the_Cassandra_database_to_a_different_disk_drive
---

# Moving the Cassandra database to a different disk drive

In some cases, the Cassandra database may need to be moved to a different disk drive. 

This is especially the case if Cassandra is hosted on the same machine as DataMiner. To ensure optimal performance, the **database should be located on a different drive than DataMiner**. If your Cassandra database is currently on the same drive, you should move it to a different disk drive.

To do so:

1. Stop the DMA.

    > [!NOTE]
    > To reduce the size of the data that will need to be copied, at this point, it can be useful to first do a cleanup of the snapshots that are used in Cassandra, by means of the Cassandra nodetool. For Windows, nodetool is located by default in the folder *C:\\Program Files\\Cassandra\\bin\\*. For Linux, the tool is available system-wide by default.
    >
    > - To check the size of the snapshots, run the following command in a command prompt window: *nodetool listsnapshots*.
    > - To clean up the snapshots, run the following command in a command prompt window: *nodetool clearsnapshot*. This will mark all snapshots as ready for deletion. Then restart the Cassandra service in order to remove the snapshots.

1. Stop the Cassandra service

1. Locate the file *cassandra.yaml*. By default, it is located in the folder */etc/cassandra* on Linux and *C:\\Program Files\\Cassandra\\conf* on Windows.

1. Open the .yaml file (as Administrator) and look for the attribute *data_file_directories*.

1. Edit this attribute so that it points to the new disk you wish to use.

1. Locate the current Cassandra data directory. By default, this is */var/lib/cassandra/data* on Linux and *C:\\ProgramData\\Cassandra* on Windows.

1. Copy the data from this directory to the new data directory you wish to use.

    > [!NOTE]
    >
    > - Depending on the size of the database, copying the existing database may take a while.
    > - Do not place the Cassandra database on a network attached storage (NAS) device or in a shared network file system (NFS). Such a setup is not supported by Cassandra.

1. When the copy is complete, start the Cassandra service.

1. Start the DMA.
