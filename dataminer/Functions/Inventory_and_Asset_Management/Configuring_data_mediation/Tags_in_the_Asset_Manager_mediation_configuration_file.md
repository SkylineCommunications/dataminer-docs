---
uid: Tags_in_the_Asset_Manager_mediation_configuration_file
---

# Tags in the Asset Manager mediation configuration file

## AssetMediationConfig

This is the root tag of the configuration file.

### forConfig

In this mandatory attribute, specify the name (without extension) of the Asset Manager configuration file to which you want to link this data mediation configuration file.

Refer to the *AssetManagerConfig.DatabaseConfig* tag of the Asset Manager configuration file to find the name. See [Configuring DataMiner Inventory and Asset Management](xref:Configuring_DMS_Inventory_and_Asset_Management).

## AssetMediationConfig.SynchronizeData

In this tag, specify a *\<Sync>* tag for every synchronization operation.

## AssetMediationConfig.SynchronizeData.Sync

A *\<Sync>* tag contains all information necessary to be able to synchronize the contents of a single column or cell.

### direction

In this attribute, specify the direction of the data synchronization.

| Value   | Description                                                      |
|---------|------------------------------------------------------------------|
| dbToDma | The data will be copied from the CMDB to the DataMiner database. |
| dmaToDb | The data will be copied from the DataMiner database to the CMDB. |
| dual    | The data will be copied both ways.                               |

### interval

In this attribute, specify how frequently you want the column or cell to be automatically synchronized. Apart from a number of seconds, you can also specify “onChange” or “manual”.

If you do not specify an interval attribute, the data will not be synchronized automatically. The data will only be synchronized when a user clicks the *Sync Now* button in the user interface of the Inventory & Asset Management module.

| Value    | Description                                                                                                                                                                                                                                                                                                                                                  |
|----------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| integer  | The data will be synchronized every X seconds.                                                                                                                                                                                                                                                                                                               |
| onChange | The data will be synchronized whenever something changes to a DataMiner parameter (normal parameter, table parameter, property or table column).<br> If you set the interval to “onChange”, the entire table columns will be compared. This means that, if the data changes frequently, extra load can be put on both the database and the DataMiner server. |
| manual   | The data will be synchronized when a user clicks the *Sync Now* button in the user interface of the Inventory & Asset Management module.                                                                                                                                                                                      |

> [!NOTE]
> onChange only works when synchronizing from a DataMiner database toward a CMDB.

### type

In this attribute, indicate whether the operation will synchronize an entire column or a single cell.

| Value  | Description                                      |
|--------|--------------------------------------------------|
| column | The operation will synchronize an entire column. |
| cell   | The operation will synchronize a single cell.    |

> [!NOTE]
> Only matching rows will be synchronized. Missing rows in the database will not automatically be created and extra rows will not be removed.

## AssetMediationConfig.SynchronizeData.Sync.DMA

In this tag, specify the data in the DataMiner database that has to be synchronized.

Depending on the type of *\<Sync>* tag and the type of DataMiner data to be synchronized, other attributes have to be specified. See the following table.

| Sync type | DataMiner data     | DMA tag attribute | Description                                                           |
|-----------|--------------------|-------------------|-----------------------------------------------------------------------|
| column    | Dynamic table row  | element           | Element ID (dmaid/eid)                                                |
| “         | “                  | table             | Parameter ID of the table                                             |
| “         | “                  | column            | Parameter ID of the column                                            |
| “         | “                  | dbKeyColumn       | Parameter ID of the key column                                        |
| “         | Property           | propertyType      | The type of property: “elements”, “views” or “services”               |
| “         | “                  | dbKeyProperty     | They key of the property                                              |
| “         | “                  | dataPropertyName  | The name of the property                                              |
| cell      | Parameter          | element           | Element ID (dmaid/eid)                                                |
| “         | “                  | pid               | Parameter ID                                                          |
| “         | Property           | propertyType      | The type of property: “elements”, “views” or “services”               |
| “         | “                  | propertyOwner     | ID of the element, view or service that owns the property (dmaid/eid) |
| “         | “                  | dataPropertyName  | The name of the property                                              |
| “         | Dynamic table cell | element           | Element ID (dmaid/eid)                                                |
| “         | “                  | column            | Parameter ID of the table column                                      |
| “         | “                  | idx               | The display key of the table row (to be specified as “row X”)         |

## AssetMediationConfig.SynchronizeData.Sync.DB

In this tag, specify the data in the CMDB that has to be synchronized.

Depending on the type of *\<Sync>* tag, other attributes have to be specified. See the following table.

| Sync type | DB tag attribute | Description                                         |
|-----------|------------------|-----------------------------------------------------|
| column    | column           | Name of the table column                            |
| “         | pkColumn         | Name of the table column containing the primary key |
| “         | table            | Name of the table                                   |
| cell      | column           | Name of the table column                            |
| “         | pk               | Primary key of the table row                        |
| “         | pkColumn         | Name of the table column containing the primary key |
| “         | table            | Name of the table                                   |
