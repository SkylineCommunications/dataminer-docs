---
uid: Synchronizing_a_database_with_elements_and_views_with_the_Surveyor
---

# Synchronizing a database with elements and views with the Surveyor

To synchronize a database (MySQL and Microsoft SQL Server) containing elements and views with the Surveyor in DataMiner Cube, a configuration file must be placed in the directory `C:\Skyline DataMiner\AssetManager\MediationConfigs`.

The configuration file needs to contain the following four tables:

| Table | Columns |
|--|--|
| View table | \- View ID (primary key)<br> - View name<br> - View ID of parent view (found in this same table)<br> - View property columns (optional) |
| Element table | \- Element ID (primary key)<br> - Element name<br> - Protocol name<br> - Protocol version<br> - Additional element fields (optional): *TrendTemplate*, *AlarmTemplate*, *IPAddress*, *SubnetMask*, *Description*, *ElementTimeout*, *State*, *ReplicationDomain*, *ReplicationHost*, *ReplicationOptions*, *ReplicationPassword*, *ReplicationRemoteElement*, *ReplicationUser*, *IsReplicationActive*, *PingInterval*, *SlowPollBase*, *SlowPollValue*, *Type*, *CreateDVE*, *EnableSnmpAgent*, *EnableTelnet*, *Forceagent*, *IsReadOnly*, *PortPollingIPAddress*, *PortPollingIPPort*, *PortBusAddress*, *PortTimeout*, *PortRetries*, *PortGetCommunity*, *PortSetCommunity*, *PortType*, *PortBaudRate*, *PortDataBits*, *PortFlowControl*, *PortLocalIPPort*, *PortLocalNetwork*, *PortPingInterval*, *PortStopBits*, *PortSlowPoll*, and/or *PortSlowPollBase*<br> - Element property columns (optional) |
| ElementView table | Link table containing information about which views contain which elements:<br> - Primary key (optional)<br> - View ID (from View table)<br> - Element ID (from Element table) |
| Ports table | Table containing the port-specific fields of the elements:<br> - Primary key<br> - Element ID (from Element table)<br> - Port number<br> - Additional port fields (optional) |

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
> - Elements covering DVE child elements will not be synchronized from database to DMA, but they will be synchronized from DMA to database.
> - If you set the sync direction to "dual" in the view configuration, applying a "Sync Now" in DataMiner will perform a sync from DMA to database, followed by a sync from database to DMA. Be aware that changes to the database might be overwritten.
> - It is possible to sync DataMiner views from multiple database tables. However, in that case, when synchronizing a new DataMiner view from DataMiner to database, the view will be added to all specified tables.
> - When views are synchronized from database to DMA, access rights to views will also apply to the Inventory & Asset Management view tree. A user with limited access to views will only be able to see a limited number of Inventory & Asset Management records.
> - For elements with multiple ports, properties that apply to different ports are synchronized with a pipe character ("|") as separator. If the properties contain pipe characters ("|") or ampersands ("&"), these are escaped as "&separator;" and "&" respectively.
> - For more information about configuration settings, see [Configuring data mediation settings in DataMiner Inventory and Asset Management](xref:Configuring_data_mediation_settings_in_DMS_Inventory_and_Asset_Management). However, note that the *AssetMediationConfig.SynchronizeData.Sync.DMA* and *AssetMediationConfig.SynchronizeData.Sync.DB* tags described in that section are replaced by the *AssetMediationConfig.SynchronizeData.Sync.ElementView* tag in this configuration.
