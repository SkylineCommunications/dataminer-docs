---
uid: Connector_help_TDF_Helios_Database
---

# TDF Helios Database

This connector can be used to execute queries to an Oracle SQL database, more specifically the Helios database, and display the query results.

## About

### Version Info

| **Range**                | **Key Features**                                     | **Based on** | **System Impact**                                     |
|--------------------------|------------------------------------------------------|--------------|-------------------------------------------------------|
| 1.0.0.x **\[Obsolete\]** | Initial version.                                     | \-           | \-                                                    |
| 1.0.1.x **\[SLC Main\]** | Service views are now created as DataMiner services. | 1.0.0.25     | Instead of only views, services are now also created. |

### Product Info

| **Range** | **Supported Firmware**     |
|-----------|----------------------------|
| 1.0.0.x   | Oracle SQL Developer 1.5.5 |
| 1.0.1.x   | Oracle SQL Developer 1.5.5 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**        |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | TDF Helios Database - Operator |
| 1.0.1.x   | No                  | Yes                     | \-                    | TDF Helios Database - Operator |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses Oracle.ManagedDataAcess, a .Net NuGet Managed Driver, to access an Oracle database. No connections need to be configured during element creation.

### Initialization

When the element has been created, go to the **General** page to configure the connection. You will need to define the **Server IP**, **Server Port**, **Username** and **Password**, and **SID**. Depending on your database configuration, the password can be empty. All other parameters must be filled in.

Note that this configuration will only be used to connect to the database when at least one query has been configured. As long as no queries have been configured, the connector will not try to connect.

## How to use

Aside from the General page, which contains the connection parameters mentioned above, this connector has a page for each type of query.

On these **Sites**, **CAT**, **Point of Services**, and **Equipments** pages, you need to define the **"Query name"** **Query File Path**. This is the path to the file where the query is available. This file must contain the **partial query** from the **"from"** keyword onwards, including the "from" keyword itself (see example below). The initial part of the query is initialized by the connector itself. This part is fixed, and the columns of the tables depend directly on it.

After you have created the query file and configured the relevant Query File Path parameter, you can execute the query with the **Execute "Query Name" Query** button.

The **Execute State "Query Name" Query** indicates the current status of a query:

- *Running Query*: The query is currently being performed on the database.
- *Filling Table*: The table of the connector is being filled in.
- *Failed*: The query has failed.
- *Success*: The query has been completed successfully.

If a query fails, a **"Query Name" Query Error Message** will be displayed.

These status parameters are available on all query pages, as well as on the General page, where the status of the most recently executed query is displayed.

There are also some parameters that indicate the progress of a query:

- **"Query name" Query Rows Read:** Indicates how many rows of the query have actually been read from the database.
- **"Query name" Table Rows Filled**: Indicates how many rows of the table in the connector have been filled in.
- **"Query name" Last updated**: Indicates the last time and date when this query was updated.
- **"Query Name" Count**: Indicates how many rows the table actually contains.

Finally, on the different query pages, the tables with the query results are also displayed.

### Example of a Sites query file

*"from*
*Q_helios_publication.sio_site,* *(select distinct sio_servicet.loc_code_ig from Q_helios_publication.sio_servicet,Q_helios_publication.sio_servicec where* *sio_servicet.cfs_code=sio_servicec.cfs_code_service_client(+)* *and* *( ( cfs_date_arret_realisee is null and CFS_classe='TNT')* *OR* *(* *sio_servicec.cfs_code_service_client is null and* *rfs_statut='Actif'* *and* *rfs_item_de_catalogue like '%TNT%')))* *SERVICE* *where* *sio_site.loc_statut\<\>'ObsolŠte'* *and* *sio_site.loc_code_ig=SERVICE.loc_code_ig*
*order by sio_site.loc_code_ig"*

## Notes

The table rows are updated with 1000 rows at the time. This limitation is in place in order to avoid a possible negative effect on DataMiner performance.
