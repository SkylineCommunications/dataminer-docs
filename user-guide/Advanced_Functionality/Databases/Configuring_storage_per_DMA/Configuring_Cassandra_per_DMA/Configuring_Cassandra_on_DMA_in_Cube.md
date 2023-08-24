---
uid: Configuring_Cassandra_per_DMA_in_Cube
---

# Configuring the Cassandra database per DMA settings

> [!IMPORTANT]
> If a DataMiner Agent in a cluster is offline, database configuration changes will not be applied to that DataMiner Agent. From DataMiner 10.3.6/10.4.0 onwards, you will get a warning on the *Database* page in System Center to make you aware of this. However, this warning will not be triggered for the offline Agent in a Failover setup. <!-- RN 36184 -->

In case a separate Cassandra cluster is used per DMA, configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. In the column on the left, select the Agent of which you want to configure the general database.

1. Specify the following database settings, depending on your DataMiner version:

   From DataMiner 10.0.13/10.1.0 onwards:

   - **Type**: *Database per Agent*.

   - **Database**: The type of database, i.e. *Cassandra*.

   - **Name**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database. From DataMiner 10.3.0/10.3.3 onwards, you can specify an IP address with a custom port, e.g `10.5.100.1:5555`. If no port is provided, the default Cassandra port is used instead (see [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)). <!-- RN 34590 -->

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to Cassandra.

   - **Password**: The password with which the DMA has to log on to Cassandra.

   Earlier DataMiner versions:

   - **Type**: The type of database, i.e. *Cassandra*.

   - **DB**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to the general database.

   - **Password**: The password with which the DMA has to log on to the general database.

1. Click *Save*.

   > [!NOTE]
   > Database configuration changes will not take effect until the Agent is restarted.

> [!TIP]
> In the [*DB.xml* file](xref:DB_xml#general-database-settings), you can specify the configuration data for several databases as well.
