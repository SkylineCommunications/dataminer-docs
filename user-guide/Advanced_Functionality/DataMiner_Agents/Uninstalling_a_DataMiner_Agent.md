---
uid: Uninstalling_a_DataMiner_Agent
---

# Uninstalling a DataMiner Agent

There are two possibilities to uninstall a DataMiner Agent:

- [Using the DataMiner Installer](#uninstalling-a-dma-using-the-dataminer-installer)
- [Using a manual procedure](#uninstalling-a-dma-using-a-manual-procedure)

## Uninstalling a DMA using the DataMiner Installer

1. Download the DataMiner installer from [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2).

1. Make sure you are logged into Windows with the Administrator account. (Do not use a regular user account with administrative rights.)

1. Double-click *Setup.exe*.

1. Click *Uninstall*.

   > [!CAUTION]
   > Once you have clicked *Uninstall*, there is no way to gracefully stop the uninstallation process.

   The progress of the uninstallation will be displayed. With the *Open logs* button in the lower right corner, you can see more detailed log information if necessary.

1. Click *Close*.

1. In case the DataMiner Agent used a **Cassandra** database, follow the procedure related to Cassandra from [Uninstalling a DMA using a manual procedure](#uninstalling-a-dma-using-a-manual-procedure).

1. In case the DataMiner Agent used an **Elasticsearch** database, follow the procedure related to Elasticsearch from [Uninstalling a DMA using a manual procedure](#uninstalling-a-dma-using-a-manual-procedure).

## Uninstalling a DMA using a manual procedure

1. Go to the folder *C:\\Skyline DataMiner\\Tools*.

1. Run the following scripts as Administrator:

   - *Stop DataMiner.bat*

   - *ConfigureIIS_Undo.bat*

   - *ConfigureFirewall_Undo.bat*

   - In case the DataMiner Agent used a MySQL database: *RemoveDB.bat*

   - *UnRegister DataMiner.bat*

   - *UnRegister DLLs of DataMiner.bat*

   - *RemoveEventLog.exe*

1. From DataMiner 10.1.0/10.1.1 onwards, use SLEndpointTool_console to remove **NATS**:

   1. Run *C:\\Skyline DataMiner\\Files\\SLEndpointTool_Console.exe* either directly or from *cmd.exe*.

   1. Select *Uninstall*.

   1. Select *NAS* as the endpoint to uninstall.

1. Delete the folder *C:\\Skyline DataMiner*.

1. In case the DataMiner Agent used a **Cassandra** database:

   1. Stop the Cassandra service.

   1. Run *cmd.exe* as Administrator and enter the following command to delete the Cassandra service:

      ```txt
      sc delete cassandra
      ```

   1. Delete the folder C:\\Program Files\\Cassandra.

   1. Delete the folder C:\\ProgramData\\Cassandra.

      > [!NOTE]
      > The *ProgramData* folder is not displayed by default, so you may need to select to display hidden items in order to access this folder.

   1. Run *regedit* as Administrator and delete the registry key “cassandra” in *HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Apache Software Foundation\\Procrun 2.0*.

1. In case the DataMiner Agent used an **Elasticsearch** database:

   1. Stop the Elasticsearch service. If the process does not stop properly, end the process.

   1. Run *cmd.exe* as Administrator and enter the following command to delete the Elasticsearch service:

      ```txt
      sc delete elasticsearch-service-x64
      ```

   1. Run *regedit* as Administrator and delete *HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Apache Software Foundation\\Procrun 2.0\\elasticsearch-service-x64*.

   1. Delete the Elasticsearch data folder, e.g. *C:\\ProgramData\\Elasticsearch*. If you are unsure where to find the directory, look for path.data in the elasticsearch.yml file.

      > [!NOTE]
      > The *ProgramData* folder is not displayed by default, so you may need to select to display hidden items in order to access this folder.

   1. Delete the folder *C:\\Program Files\\Elasticsearch*.

   1. If any Elasticsearch firewall rule exists, delete it.
