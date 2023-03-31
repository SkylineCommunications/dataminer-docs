---
uid: How_do_I_connect_to_a_CMDB_from_an_Automation_script
---

# How do I connect to a CMDB from an Automation script?

In a C# block of an Automation script, you can connect to the CMDB of the Inventory & Asset Management module.

1. Refer to the following namespaces:

    ```cs
    Skyline.DataMiner.SLDatabaseSystem.Data
    ```

1. Refer to the following DLL files:

    ```txt
    C:\Skyline DataMiner\Files\SLDatabase.dll
    C:\Skyline DataMiner\Files\System.Data.dll
    C:\Skyline DataMiner\Files\System.XML.dll
    ```

1. Copy the following snippet in the C# block and make sure the database name matches the name that is specified in *DB.xml*:

    ```cs
    String dbName = "db-name"; //Name must be identical to name defined in db.xml
    SLSql localConnection = null;
    SLConnectionManager manager = new SLConnectionManager();

    if(manager != null)
    {
        localConnection = manager.GetConnection(dbName);
    }

    if(localConnection == null)
    {
        engine.GenerateInformation("Database connection failed");
        return;
    }

    DataSet result = localConnection.Query("SELECT * FROM table");
    ```
