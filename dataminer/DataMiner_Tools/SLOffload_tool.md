---
uid: SLOffload_tool
keywords: central database
---

# SLOffload tool

The SLOffload tool allows the user to manually trigger a database offload to an Oracle or a MySQL database.

> [!NOTE]
> This tool cannot be used if a Cassandra general database is used.

To trigger a database offload:

1. Start the tool by double-clicking the file “SLOffload.exe” in the folder `C:\Skyline DataMiner\Tools`.

   A window will open that lists the different DMAs in the cluster, and the databases to be offloaded.

1. If there is a configuration issue, the *Start Offload* button is not available. If so, click the tools button next to *Details*, adjust the configuration as required and click *Save*.

   > [!NOTE]
   > If there is a configuration issue, the information in the pane on the right in the main window of the SLOffload tool can be used to determine what the problem is. The pane displays a log that details any issues that the application encounters, e.g., failed authentication.

1. If the configuration is correct, click *Start Offload* to start the database offload.
