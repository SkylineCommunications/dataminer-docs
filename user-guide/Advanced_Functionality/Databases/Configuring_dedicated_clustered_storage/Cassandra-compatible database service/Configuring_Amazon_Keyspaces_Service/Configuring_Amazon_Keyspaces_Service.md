---
uid: Configuring_AKS_in_Cube
---

# Configuring the Amazon Keyspaces Service in Cube

> [!IMPORTANT]
> An Amazon Keyspaces database requires a separate indexing database.
> For information on how to configure an indexing database, see [Elasticsearch database](xref:Deploying_the_Elasticsearch_database) or [OpenSearch database](xref:OpenSearch_database).

> [!NOTE]
> If you do not see the `Amazon Keyspaces` option, it means that your server is not compatible because it is not running DataMiner version 10.3.0/10.3.3 or higher.

To configure the connection to an [Amazon Keyspaces database](xref:Amazon_Keyspaces_Service), proceed as follows:

1. In DataMiner Cube, go to *System Center* > *Database*.

1. Specify the following database settings:

   - **Type**: *Database per cluster*.

   - **Database**: The type of database, i.e. *Amazon Keyspaces*.

   - **Keyspace prefix**: The name all Amazon Keyspaces will be prefixed with. This will be identical for all DMAs in the DMS.

     - Only alphanumeric characters are supported.

     - The prefix cannot start with a number.

     - The prefix has a maximum length of 11 characters.

   - **DB Server**: The URL of the [global endpoint](https://docs.aws.amazon.com/keyspaces/latest/devguide/programmatic.endpoints.html) of the region your Amazon Keyspaces cluster is in. (e.g. `cassandra.eu-north-1.amazonaws.com`).

   - **User**: The username of your [Amazon Keyspaces credentials](xref:Deploying_Amazon_Keyspaces_Service#generating-credentials-for-amazon-keyspaces).

   - **Password**: The password of your [Amazon Keyspaces credentials](xref:Deploying_Amazon_Keyspaces_Service#generating-credentials-for-amazon-keyspaces).

1. Restart the DMS.

   The first restart after configuring Amazon Keyspaces can take up to 15 minutes on top of the normal startup time as the keyspaces and tables will be created. In case of trouble, you can find the relevant logging in the *SLDBConnection.txt* file.

![Cube Database Configuration](~/user-guide/images/aks_cube_config.png)<br>*DataMiner 10.3.3 example configuration*
