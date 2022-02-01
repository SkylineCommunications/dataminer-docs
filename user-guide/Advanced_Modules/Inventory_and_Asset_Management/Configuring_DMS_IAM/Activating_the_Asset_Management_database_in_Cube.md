---
uid: Activating_the_Asset_Management_database_in_Cube
---

# Activating the Asset Management database in Cube

Before you activate the Asset Management database in DataMiner Cube:

- Ensure that the Asset Manager configuration file has been placed in the following folder on the DMA: *C:\\Skyline DataMiner\\AssetManager\\Configs*

- Ensure that the database containing your Asset Management data is running.

Then do the following to activate the database:

1. In DataMiner Cube, go to *Apps* > *System Center \>* *Database* > *Other*.

2. Click *Add*, enter the name of the database, and click *Add*.

3. Select the *Activate this database* checkbox.

4. Enter the necessary information:

    - **Type**: MySQL

    - **DB**: Name of the database.

    - **DB server**: Name or IP address of the server that hosts the database.

    - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database. See [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube).

    - **User**: The username that the DMA should use to log on to the database.

    - **Password**: The password that the DMA should use to log on to the database.

5. Click the *Save* button.

6. In DataMiner Cube, go to *Apps* > *Asset Manager*.

7. In Asset Manager, click *Load database configuration*.
