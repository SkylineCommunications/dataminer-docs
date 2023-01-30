---
uid: Synchronizing_a_database_with_elements_and_views_with_the_Surveyor
---

# Synchronizing a database with elements and views with the Surveyor

In the configuration file of the Inventory & Asset Management module, you can synchronize a database (MySQL and Microsoft SQL Server) containing elements and views with the Surveyor in DataMiner Cube.

- [Configuration up to DataMiner 9.0.3](#configuration-up-to-dataminer-903)

- [Configuration from DataMiner 9.0.4 onwards](#configuration-from-dataminer-904-onwards)

### Configuration up to DataMiner 9.0.3

Up to DataMiner 9.0.3, usually two configuration files are created in the directory *C:\\Skyline DataMiner\\AssetManager\\MediationConfigs*:

- one containing all settings for view synchronization. See [View synchronization file](#view-synchronization-file).

- one containing all settings for element synchronization. See [Element synchronization file](#element-synchronization-file).

The two files must have an identical SynchronizeData.Sync.DMA tag.

Alternatively, a single file can be used instead. See [Legacy configuration using a single file](#legacy-configuration-using-a-single-file).

> [!NOTE]
>
> - This configuration has become obsolete from DataMiner version 9.0.4 onwards. We advise to replace it with the new configuration in systems using DataMiner 9.0.4 and higher. See [Configuration from DataMiner 9.0.4 onwards](#configuration-from-dataminer-904-onwards). The legacy configuration type will remain supported for existing configurations.
> - When this configuration is used, multiple database tables are needed for each level of views and each level of elements, which limits the depth of the number of subviews you can create. To not have this limitation, use the configuration introduced in DataMiner 9.0.4 instead. Also, only the configuration introduced in DataMiner 9.0.4 allows the synchronization of elements to multiple views.

#### View synchronization file

In this file, you can specify the table(s) from which to fetch the necessary data for the views to be created.

Configuration file syntax:

```xml
<AssetMediationConfig forConfig="configuration_name">
  <SynchronizeData>
    <Sync interval="manual | #seconds" type="view" direction="dbToDma|dmaToDb|dual">
      <DB>
        <Tables>
          <Table name="table_name" column="column_name" filter="optional filter">
            <Properties>
              <Property name="property_name" linkedTable="optional linked table" column="column_name" />
              ...
            </Properties>
          </Table>
        </Tables>
      </DB>
      <DMA view="root_view_id" />
    </Sync>
  <SynchronizeData>
</AssetMediationConfig>
```

#### Overview of a number of typical view synchronization settings

| Tag      | Attribute     | Description                                                                                                                  |
|----------|---------------|------------------------------------------------------------------------------------------------------------------------------|
| Table    | name          | The name of the table containing the view records.                                                                           |
| Table    | column        | The name of the column containing the primary keys.                                                                          |
| Table    | filter        | (Optional) ANSI compliant WHERE clause that will be used to filter out specific records from the View table.                 |
| Table    | displayColumn | (Optional) If this attribute is used the name of the view will be taken from this display column instead of the primary key. |
| Property | name          | The name of a view property to be created and initialized.                                                                   |
| Property | linkedTable   | (Optional) The name of another table to which the column is linked by means of a foreign key.                                |
| Property | column        | Name of the column contain the property value.                                                                               |
| DMA      | view_id       | The ID of the existing DataMiner view under which the views have to be created.                                              |

For more information about configuration settings, see [Configuring data mediation settings in DataMiner Inventory and Asset Management](xref:Configuring_data_mediation_settings_in_DMS_Inventory_and_Asset_Management).

#### Element synchronization file

In this file, your can specify the table from which to fetch the necessary data for the elements to be created. It is very similar to the view synchronization configuration, but there are some differences:

- The element configuration file points to the view configuration by means of the same root view and parent view table name and parent key column name.

- Instead of view properties, this file contains element properties, optionally linked to another table.

- Element fields are added in this file, necessary to create elements. Note that some element fields are mandatory and some are optional. For a list of all possible element fields, see below.

Configuration file syntax:

```xml
<AssetMediationConfig forConfig="configuration_name">
  <SynchronizeData>
    <Sync interval="manual | #seconds" type="element" direction="dbToDma|dmaToDb|dual">
      <DB>
        <Tables>
          <Table name="table_name" filter="optional filter">
            <Properties>
              <Property name="property_name" linkedTable="optional linked table"  column="column_name" />
              ...
            <Properties>
            <ElementFields>
              <Field name="field_name" linkedTable="optional linked table" column="column_name" />
              ...
            <ElementFields>
            <Tables>
              <Table name="">
                <Properties />
                <ElementFields />
                <Tables>
                  <Table name="devices" filter="" linkedTable="racks" linkedColumn="Rack_ID">
                    <Properties>
                      <Property name="Model" column="Model" />
                      ...
                    </Properties>
                    <ElementFields>
                      <Field name="ElementName" column="DeviceName" linkedTable="" />
                      ...
                    </ElementFields>
                  </Table>
                </Tables>
              </Table>
            </Tables>
          </Table>
        </Tables>
      </DB>
      <DMA view="root_view_id" table="view_table_name" column="view_table_pk_column"/>
    </Sync>
  <SynchronizeData>
</AssetMediationConfig>
```

Mandatory element fields:

| Field           | Description                                           |
|-----------------|-------------------------------------------------------|
| ElementName     | The name of the element.                              |
| ProtocolName    | The name of the protocol.                             |
| ProtocolVersion | The protocol version, which can also be “Production”. |

Optional element fields:

- TrendTemplate

- AlarmTemplate

- IPAddress

- SubnetMask

- Description

- ElementTimeout

- State

- ReplicationDomain

- ReplicationHost

- ReplicationOptions

- ReplicationPassword

- ReplicationRemoteElement

- ReplicationUser

- IsReplicationActive

- PingInterval

- SlowPollBase

- SlowPollValue

- Type

- CreateDVE

- EnableSnmpAgent

- EnableTelnet

- Forceagent

- IsReadOnly

- PortPollingIPAddress

- PortPollingIPPort

- PortBusAddress

- PortTimeout

- PortRetries

- PortGetCommunity

- PortSetCommunity

- PortType

- PortBaudRate

- PortDataBits

- PortFlowControl

- PortLocalIPPort

- PortLocalNetwork

- PortPingInterval

- PortStopBits

- PortSlowPoll

- PortSlowPollBase

> [!NOTE]
>
> - Elements covering DVE child elements will not be synchronized from database to DMA. They will be synchronized from DMA to database, however.
> - If you set the sync direction to “dual” in the view configuration, then applying a “Sync Now” in DataMiner will perform a sync from DMA to database, followed by a sync from database to DMA. Be aware that changes to the database might be overwritten.
> - It is possible to sync DataMiner views from multiple database tables. However, in that case, when synchronizing a new DataMiner view from DataMiner to database, the view will be added to all specified tables.
> - When views are synchronized from database to DMA, access rights to views will also apply to the Inventory & Asset Management view tree. A user with limited access to views will only be able to see a limited number of Inventory & Asset Management records.
> - For elements with multiple ports, properties that apply to different ports are synchronized with a pipe character (“\|”) as separator. If the properties contain pipe characters (“\|”) or ampersands (“&”), these are escaped as “&separator;” and “&amp;” respectively.

#### Legacy configuration using a single file

Alternatively, up to DataMiner 9.0.3, a single file can be used instead, containing two *\<Sync>* tags. One of the *\<Sync>* tags must be of type “view”, the other of type “element”.

For example:

```xml
<AssetMediationConfig forConfig="AssetManagerSingleFileExample">
  <SynchronizeData>
    <Sync interval="3600" type="view" direction="dual">
      <DB>
        <Tables>
          <Table name="locations" column="LocationID" displayColumn="LocationName">
            <Properties>
              <Property name="Location Name" column="LocationName"/>
              <Property name="Location Abbreviation" column="Abbreviation"/>
            </Properties>
            <Tables>
              <Table name="rooms" column="RoomID" displayColumn="RoomName">
                <Properties>
                  <Property name="Room Name" column="RoomName"/>
                  <Property name="Room Abbreviation" column="RoomAbb"/>
                </Properties>
            </Tables>
          </Table>
        </Tables>
      </DB>
      <DMA view="5231"/>
    </Sync>
    <Sync interval="3600" type="element" direction="dual">
      <DB>
        <Tables>
          <Table name="devices" filter="">
            <Properties>
              <Property name="Model" column="Model" />
              <Property name="Version" linkedTable="" column="Version" />
              <Property name="Rack Slot" linkedTable="" column="RackSlot" />
              <Property name="Firmware Version" linkedTable="" column="FirmWareVersion" />
              <Property name="Manufacturer" linkedTable="device models" column="Manufacturer"/>
            </Properties>
            <ElementFields>
              <Field name="ElementName" column="DeviceName" linkedTable="" />
              <Field name="ProtocolName" column="protocol" linkedTable="" />
              <Field name="ProtocolVersion" column="protocolversion" linkedTable="" />
              <Field name="TrendTemplate" column="TrendTemplate" linkedTable="" />
              <Field name="AlarmTemplate" column="AlarmTemplate" linkedTable="" />
              <Field name="IPAddress" column="IPAddress" linkedTable="" />
              <Field name="SubNetMask" column="SubNetMask" linkedTable="" />
              <Field name="Description" column="Description" linkedTable="" />
              <Field name="ElementTimeOut" column="ElementTimeOut" linkedTable="" />
              <Field name="State" column="State" linkedTable="" />
              <Field name="ReplicationDomain" column="ReplicationDomain" linkedTable="" />
              <Field name="ReplicationHost" column="ReplicationHost" linkedTable="" />
              <Field name="ReplicationOptions" column="ReplicationOptions" linkedTable="" />
              <Field name="ReplicationPassword" column="ReplicationPassword" linkedTable="" />
              <Field name="ReplicationRemoteElement" column="ReplicationRemoteElement" linkedTable="" />
              <Field name="ReplicationUser" column="ReplicationUser" linkedTable="" />
              <Field name="IsReplicationActive" column="IsReplicationActive" linkedTable="" />
              <Field name="PingInterval" column="PingInterval" linkedTable="" />
              <Field name="SlowPollBase" column="SlowPollBase" linkedTable="" />
              <Field name="SlowPollValue" column="SlowPollValue" linkedTable="" />
              <Field name="Type" column="Type" linkedTable="" />
              <Field name="CreateDVE" column="CreateDVE" linkedTable="" />
              <Field name="EnableSnmpAgent" column="EnableSnmpAgent" linkedTable="" />
              <Field name="EnableTelnet" column="EnableTelnet" linkedTable="" />
              <Field name="ForceAgent" column="ForceAgent" linkedTable="" />
              <Field name="IsReadOnly" column="IsReadOnly" linkedTable="" />
              <Field name="PortPollingIPAddress" column="PortPollingIPAddress" linkedTable="" />
              <Field name="PortPollingIPPort" column="PortPollingIPPort" linkedTable="" />
              <Field name="PortBusAddress" column="PortBusAddress" linkedTable="" />
              <Field name="PortRetries" column="PortRetries" linkedTable="" />
              <Field name="PortGetCommunity" column="PortGetCommunity" linkedTable="" />
              <Field name="PortSetCommunity" column="PortSetCommunity" linkedTable="" />
              <Field name="PortType" column="PortType" linkedTable="" />
              <Field name="PortBaudRate" column="PortBaudRate" linkedTable="" />
              <Field name="PortDataBits" column="PortDataBits" linkedTable="" />
              <Field name="PortFlowControl" column="PortFlowControl" linkedTable="" />
              <Field name="PortLocalIPPort" column="PortLocalIPPort" linkedTable="" />
              <Field name="PortPingInterval" column="PortPingInterval" linkedTable="" />
              <Field name="PortStopBits" column="PortStopBits" linkedTable="" />
              <Field name="PortSlowPoll" column="PortSlowPoll" linkedTable="" />
              <Field name="PortSlowPollBase" column="PortSlowPollBase"  linkedTable="" />
            </ElementFields>
          </Table>
        </Tables>
      </DB>
      <DMA view="5231" table="racks" column="Rack_ID"/>
    </Sync>
  </SynchronizeData>
</AssetMediationConfig>
```

### Configuration from DataMiner 9.0.4 onwards

From DataMiner 9.0.4 onwards, a single configuration file is placed in the directory *C:\\Skyline DataMiner\\AssetManager\\MediationConfigs*, using a different configuration than for previous versions of DataMiner.

> [!NOTE]
>
> - As the configuration used in earlier DataMiner versions has become obsolete, we advise to replace it with this new configuration if possible. However, the old configuration remains supported for existing configurations.
> - Only this new configuration allows the synchronization of elements to multiple views.

This new synchronization method needs the following four tables:

| Table             | Columns                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
|-------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| View table        | \-  View ID (primary key)<br> -  View name<br> -  View ID of parent view (found in this same table)<br> -  View property columns (optional)                                                                                                                                                                        |
| Element table     | \-  Element ID (primary key)<br> -  Element name<br> -  Protocol name<br> -  Protocol version<br> -  Additional element fields (optional)<br> -  Element property columns (optional) |
| ElementView table | Link table containing information about which views contain which elements:<br> -  Primary key (optional)<br> -  View ID (from View table)<br> -  Element ID (from Element table)                                                                                                                                                                                                 |
| Ports table       | Table containing the port-specific fields of the elements:<br> -  Primary key<br> -  Element ID (from Element table)<br> -  Port number<br> -  Additional port fields (optional)                                                                                                                                   |

> [!NOTE]
> To ensure optimal functionality, it is best to have all available fields also defined in the Element table and Ports table in the database.

Example of a mediation configuration file:

```xml
<AssetMediationConfig forConfig="AssetManagerConfig">
  <SynchronizeData>
    <Sync direction="dual" type="ElementView" interval="60">
      <ElementView>
        <ViewID>27</ViewID>
        <ElementTable>
          <TableName>elements</TableName>
          <ElementNameColumn>name</ElementNameColumn>
          <Properties>
            <Property name="PropIAM" column="ElementProperty" />
            <!-- Additional Properties -->
          </Properties>
          <Fields>
            <Field column="Protocol" name="ProtocolName" />
            <Field column="ProtocolVersion" name="ProtocolVersion" />
            <!-- Additional Fields -->
          </Fields>
          <Ports>
            <TableName>Ports</TableName>
            <ElementKeyColumn>Element</ElementKeyColumn>
            <PortNumberColumn>Number</PortNumberColumn>
            <Fields>
              <Field name="PortPollingIPAddress" column="IPAddress" />
              <!-- Additional Fields -->
            </Fields>
          </Ports>
        </ElementTable>
        <ViewTable>
          <TableName>views</TableName>
          <ViewNameColumn>name</ViewNameColumn>
          <ParentColumn>ParentID</ParentColumn>
          <Properties>
            <Property name="PropViewIAM" column="ViewProperty" />
            <!-- Additional Properties -->
          </Properties>
        </ViewTable>
        <ElementInViewTableName>
          <TableName>elementview</TableName>
          <ViewKey>ViewId</ViewKey>
          <ElementKey>ElementID</ElementKey>
        </ElementInViewTableName>
      </ElementView>
    </Sync>
  </SynchronizeData>
</AssetMediationConfig>
```

> [!NOTE]
>
> - The names of the element fields are the same as in the configuration in use up to DataMiner 9.0.3. See [Element synchronization file](#element-synchronization-file).
> - For more information about configuration settings, see [Configuring data mediation settings in DataMiner Inventory and Asset Management](xref:Configuring_data_mediation_settings_in_DMS_Inventory_and_Asset_Management). However, note that the *AssetMediationConfig.SynchronizeData.Sync.DMA* and *AssetMediationConfig.SynchronizeData.Sync.DB* tags described in that section are replaced by the *AssetMediationConfig.SynchronizeData.Sync.ElementView* tag in this configuration.
