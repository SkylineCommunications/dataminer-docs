---
uid: Amazon_Keyspaces_Service
---

# Amazon Keyspaces Service

From DataMiner 10.3.0/10.3.3 onwards, it is possible to use the Amazon Keyspaces Service on AWS as an alternative for a Cassandra Cluster setup. See also: [Supported system data storage architectures](xref:Supported_system_data_storage_architectures).

> [!NOTE]
>
> - Amazon Keyspaces does not support all Cassandra functionality, most notably indices on columns. As a result, some queries against logger tables (including SLAs) may be slower on Amazon Keyspaces compared to Cassandra.
> - The only consistency level supported is `Local Quorum`. See [Supported Apache Cassandra consistency levels in Amazon Keyspaces](https://docs.aws.amazon.com/keyspaces/latest/devguide/consistency.html). No matter the configuration, the consistency level will always be overwritten to `Local Quorum`.
> - The only replication strategy supported is the Amazon Keyspaces specific `Single-Region strategy`, which is not configurable.

> [!NOTE]
> Migrating existing databases to Amazon Keyspaces is not yet supported.

## Installing the Starfield certificate

For Amazon Keyspaces, the Starfield certificate must be present on the local Windows machine DataMiner is running on. To install the certificate, you will need to add it to the *Trusted Root Certification Authorities* section of the Windows certificate store:

1. Download the [sf-class2-root.crt certificate file](https://certs.secureserver.net/repository/sf-class2-root.crt).

1. To import the certificate to your machine, press WINDOWS + R and enter the `mmc` command.

    If necessary, confirm that you want to allow the app to make changes to the device. A Console window will be opened.

1. In the Console window, go to *File* > *Add/Remove Snap-in*.

1. In the *Available snap-ins* list, select *Certificates*, and click *Add >*.

1. Select *Computer account*, and click *Next*.

1. Make sure *Local computer* is selected, and click *Finish*.

1. Click *OK*.

1. In the *Console Root* tree view on the left, select the folder *Certificates (Local Computer)* > *Trusted Root Certification Authorities* > *Certificates*.

1. Right-click the *Certificates* folder you have just selected, and select *All Tasks* > *Import*.

1. Click *Next* until you can browse to the location of the certificate file.

1. Keep selecting *Next* or *Finish* until the certificate is successfully imported.

   You should now see the certificate listed as shown in the example screenshot below.

   ![Add Certificate](~/user-guide/images/aks_add_certificate.png)

## Connecting your DMS to your Amazon Keyspaces

To configure the connection to an Amazon Keyspaces database, configure the settings as detailed in [Amazon Keyspaces](xref:Configuring_the_database_settings_in_Cube#amazon-keyspaces).

> [!IMPORTANT]
> An Amazon Keyspaces database requires a separate indexing database.
>
> For information on how to configure an indexing database, see [Elasticsearch database](xref:Elasticsearch_database) or [OpenSearch database](xref:OpenSearch_database).
