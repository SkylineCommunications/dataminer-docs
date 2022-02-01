---
uid: Moving_the_Cassandra_database_to_a_different_disk_drive
---

# Moving the Cassandra database to a different disk drive

To ensure optimal performance when using a Cassandra database, the database should be located on a different drive than DataMiner. If your Cassandra database is currently on the same drive, you should move it to a different disk drive.

To do so:

1. Stop the DMA.

    > [!NOTE]
    > To reduce the size of the data that will need to be copied, at this point, it can be useful to first do a cleanup of the snapshots that are used in Cassandra, by means of the Cassandra nodetool, which is provided by Cassandra in the folder *C:\\Program Files\\Cassandra\\bin\\*.
    > - To check the size of the snapshots, run the following command in a command prompt window: *nodetool listsnapshots*.
    > - To clean up the snapshots, run the following command in a command prompt window: *nodetool clearsnapshot*. This will mark all snapshots as ready for deletion. Then restart the Cassandra service in order to remove the snapshots.

2. Stop the Cassandra service

3. Locate the file *cassandra.yaml*. By default, it is located in the folder *C:\\Program Files\\Cassandra\\conf*.

4. Open the .yaml file (as Administrator) and look for the attribute *data_file_directories*.

5. Edit this attribute so that it points to the new data directory you wish to use.

6. Locate the current Cassandra data directory. By default, this is *C:\\ProgramData\\Cassandra*.

7. Copy the data from this directory to the new data directory you wish to use.

    > [!NOTE]
    > - Depending on the size of the database, copying the existing database may take a while.
    > - Do not place the Cassandra database on a network attached storage (NAS) device or in a shared network file system (NFS). Such a setup is not supported by Cassandra.

8. When the copy is complete, start the Cassandra service.

9. Start the DMA.
