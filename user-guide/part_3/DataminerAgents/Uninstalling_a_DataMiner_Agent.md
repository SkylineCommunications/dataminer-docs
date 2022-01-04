# Uninstalling a DataMiner Agent

You can uninstall the DataMiner Agent software as follows:

1. Go to the folder *C:\\Skyline DataMiner\\Tools*.

2. Run the following scripts as Administrator:

    - *Stop DataMiner.bat* 

    - *ConfigureIIS_Undo.bat* 

    - *ConfigureFirewall_Undo.bat* 

    - In case the DataMiner Agent used a MySQL database: *RemoveDB.bat* 

    - *UnRegister DataMiner.bat* 

    - *UnRegister DLLs of DataMiner.bat* 

    - *RemoveEventLog.exe* 

3. From DataMiner 10.1.0/10.1.1 onwards, use SLEndpointTool_console to remove **NATS**:

    1. Run *C:\\Skyline DataMiner\\Files\\SLEndpointTool_Console.exe* either directly or from *cmd.exe*.

    2. Select *Uninstall*.

    3. Select *NAS* as the endpoint to uninstall.

4. Delete the folder *C:\\Skyline DataMiner*.

5. In case the DataMiner Agent used a **Cassandra** database:

    1. Stop the Cassandra service.

    2. Run *cmd.exe* as Administrator and enter the following command to delete the Cassandra service:

        ```txt
        sc delete cassandra
        ```

    3. Delete the folder C:\\Program Files\\Cassandra.

    4. Delete the folder C:\\ProgramData\\Cassandra.

        > [!NOTE]
        > The *ProgramData* folder is not displayed by default, so you may need to select to display hidden items in order to access this folder.

    5. Run *regedit* as Administrator and delete the registry key “cassandra” in *HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Apache Software Foundation\\Procrun 2.0*.

6. In case the DataMiner Agent used an **Elasticsearch** database:

    1. Stop the Elasticsearch service. If the process does not stop properly, end the process.

    2. Run *cmd.exe* as Administrator and enter the following command to delete the Elasticsearch service:

        ```txt
        sc delete elasticsearch-service-x64
        ```

    3. Run *regedit* as Administrator and delete *HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Apache Software Foundation\\Procrun 2.0\\elasticsearch-service-x64*.

    4. Delete the Elasticsearch data folder, e.g. *C:\\ProgramData\\Elasticsearch*. If you are unsure where to find the directory, look for path.data in the elasticsearch.yml file.

        > [!NOTE]
        > The *ProgramData* folder is not displayed by default, so you may need to select to display hidden items in order to access this folder.

    5. Delete the folder *C:\\Program Files\\Elasticsearch*.

    6. If any Elasticsearch firewall rule exists, delete it.
