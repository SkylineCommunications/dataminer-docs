---
uid: MOP_Changing_the_default_password_for_Cassandra
---

# Changing the default password for Cassandra

The procedure below details how you can change the default password for a Cassandra database used by DataMiner.

## Requirements

Access to the servers with administrator rights. This requires a connection dedicated completely or partially to this procedure, via VPN or local network.

## Procedure

### Check the requirements and connection

#### Prerequisites

- Remote access to the system
- Database and DataMiner credentials with administrator rights
- Basic Cassandra knowledge
- Basic DataMiner knowledge

#### Steps

1. Connect to the system via the designated VPN or host PC.
1. Test if you can access DataMiner Cube.
1. Go to `C:\ProgramFiles\Cassandra\Devcenter\Run DevCenter` and open *DevCenter*.
1. Create a new connection with the address "localhost", the username "root", and the password "root".

### Create a database user with administrator permissions

#### Prerequisites

The previous requirements are met.

#### Steps

1. Run the following CQL statement to create a new superuser:

    ```txt
    create role newUserName with superuser=true and login=true and password='newUserPassword’;
    ```

1. Edit the localhost connection in *DevCenter* to use the new username and password, and confirm that this works.

1. Optionally, remove the old "root" user. To do so, first make sure the *DevCenter* database connection uses the new credentials, and then use the following command:

    ```txt
    DROP USER root;
    ```

1. To change the Cassandra password in DataMiner, in DataMiner Cube, go to *System Center > Database*, change the Cassandra database password, and click *Save*.

1. Repeat these steps for each DMA with its own dedicated Cassandra cluster. For example, if 2 DMAs are in Failover, these actions only need to be done from one of the DMAs. If the changes are done from the primary DMA, they will automatically be implemented on the backup DMA. Similarly, if the [Cassandra cluster feature](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) is used for the DMS (i.e. one Cassandra cluster for the complete DMS), the steps only need to be done for one DMA.

### Test the database connection

#### Prerequisites

The previous requirements are met.

#### Steps

1. In DataMiner Cube, go to *System Center > Tools > query executer*, make sure the correct database is selected at the top, and execute the following query:

    ```txt
    select * from system_schema.tables where keyspace_name='SLDMADB';
    ```

1. Check if trending data is available in DataMiner Cube.
1. Check the health of the Cassandra database in the [Failover status](xref:Viewing_the_current_Failover_DMA_status) window or in the Alarm Console.
1. Check the log files *SLDataminer.txt*, *SLError.txt*, *SLDatagateway.txt* and *SLDBConnection.txt* for database errors.

## Time estimate

| Item | Activity | Duration |
|------|----------|----------|
| 1    | Checking the requirements       | Approx. 10 min. |
| 2    | Creating a database user        | Approx. 60 min. |
| 3    | Testing the database connection | Approx. 60 min. |
