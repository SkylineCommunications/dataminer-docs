---
uid: General_Main_Release_10.2.0_new_features_1
---

# General Main Release 10.2.0 - New features (part 1)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> A DataMiner Installer v10.2 is available on [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2/).
>
> - For 64-bit systems only.
> - No longer contains the necessary files to install MySQL.
> - Unattended cluster installation is not supported.
> - On Windows Server 2022, an “Internal server error” is thrown after installation. Workaround:
>   - Go to <https://www.iis.net/downloads/microsoft/url-rewrite>.
>   - Download and install the URL rewrite module.
>   - Go to <http://localhost/root> and verify whether the root page is shown.

### DMS core functionality

#### SLAnalytics - Automatic incident tracking: Enhanced configuration of property-based incident tracking \[ID_28083\]

In the *C:\\Skyline DataMiner\\Analytics\\configuration.xml* file, it is now possible to indicate which of the following properties will be used to group alarms by:

- The parameter the alarm is generated on
- The service the alarm is generated on
- The element the alarm is generated on
- The IDP location of the element the alarm is generated on
- The polling IP address of the element the alarm is generated on (only for timeouts)
- The view(s) of the element the alarm is generated on

Note that, from now on, alarms will only be grouped on location or view if the proportion of elements with an alarm at that location or in that view exceeds a certain threshold (by default 75% for location and 25% for views). Elements in a view will be counted recursively.

#### DataMiner Object Model \[ID_28096\]\[ID_28392\]\[ID_28460\]\[ID_28635\]\[ID_28703\]\[ID_28709\] \[ID_28739\] \[ID_30302\]

The DataMiner Object Model (DOM) is a collection of generic objects and a generic DomManager that can be used to perform a series of operations.

##### Object overview

| Object            | Description                                                                                             |
|-------------------|---------------------------------------------------------------------------------------------------------|
| SectionDefinition | Object that defines the data that should be present in a Section of a DomInstance.                      |
| DomDefinition     | Object that groups DomInstances and defines what Section-Definitions should be used by these instances. |
| DomInstance       | Object that contains the FieldValues in the Sections for the SectionDefinitions.                        |
| DomTemplate       | Simple object that has a pre-filled DomInstance object, which can be used as a template.                |

If, for example, you want to build a system that will store the time that employees spend on tasks, you can do the following:

1. Create a SectionDefinition with four FieldDescriptors:

    ```csharp
    SectionDefinition (Name = "PunchInfoSectionDefinition")
    ```

    - FieldDescriptor 1: Name = “Task ID” & Type = “Guid”
    - FieldDescriptor 2: Name = “Username” & Type = “String”
    - FieldDescriptor 3: Name = “Start time” & Type = “DateTime”
    - FieldDescriptor 4: Name = “Stop time” & Type = “DateTime”

1. Create a DomDefinition (Name = PunchInfoDomDefinition) that contains a link to the PunchInfoSectionDefinition.

Employees will now be able to log their time spent by creating a new DomInstance

- that is linked to the PunchInfoDomDefinition, and
- that has one Section linked to the PunchInfoSectionDefinition, which contains a FieldValue for each FieldDescriptor.

    > [!NOTE]
    > The SectionDefinitionId, DomDefinitionId, DomInstanceId and DomTemplateId objects all have a ModuleId property. This property will automatically be filled in when a SectionDefinition, DomDefinition, DomInstance or DomTemplate object is added or updated.
    > Note:
    >
    > - SectionDefinitions linked to the JobManager will have their ModuleId set to null.
    > - Existing objects will only have their ModuleId property filled in the first time they are updated.

##### DomManager

A DomManager manages the create/read/update/delete actions performed on the DOM objects, which are stored in an Elasticsearch index.

DomManagers run in SLNet and are created/started the first time they are called. Note that a ModuleSettings object must first be created before a DomManager can be created. This object contains a module ID and information on how the manager should behave.

Create, read, update and delete calls on a DomManager can be initiated using a DomHelper in a script or an application.

If you want an information event to be generated for every create, read, update or delete action performed on a DOM object, in the DomManager settings, you can enable the EnableInformationEvents property. Default value: false

##### DomManager event messages

Every DomManager can send out the following event messages:

| Event message                            | Description                                                       |
|------------------------------------------|-------------------------------------------------------------------|
| DomSectionDefinitionsChangedEventMessage | Generated when a SectionDefinition is created, updated or deleted |
| DomDefinitionsChangedEventMessage        | Generated when a DomDefinition is created, updated or deleted     |
| DomInstancesChangedEventMessage          | Generated when a DomInstance is created, updated or deleted       |
| DomTemplatesChangedEventMessage          | Generated when a DomTemplate is created, updated or deleted       |

Since multiple DomManager instances can send out the above-mentioned event messages (each with their own unique module ID), the ModuleEventSubscriptionFilter\<T>(string moduleId) subscription filter can be used to return events of type T sent by the DomManager with ID moduleId.

##### DomInstance history

A DomManager will keep track of the DomInstance history. A DomInstance change will be created after each successful create, read, update or delete action performed on a DOM object.

Changes to FieldValues will be stored in DomFieldValueChange objects containing the following items:

| Item              | Description                                                      |
|-------------------|------------------------------------------------------------------|
| FieldDescriptorId | The ID of the Field descriptor                                   |
| CrudType          | Whether this change is a create, update or delete                |
| ValueBefore       | The value before the change (will be null when this is a create) |
| ValueAfter        | The value after the change (will be null when this is a delete)  |

Per DomInstance section, those DomFieldValueChange objects will be bundled in a DomSectionChange object containing the following items:

| Item              | Description                          |
|-------------------|--------------------------------------|
| SectionId         | The ID of the section                |
| FieldValueChanges | The list of FieldValueChange objects |

The DomSectionChange objects will be stored in a HistoryChange object, which contains the metadata of the change. That metadata can then be used for filtering purposes:

| Item         | Description                                                      |
|--------------|------------------------------------------------------------------|
| ID           | A unique Guid (Filterable)                                       |
| SubjectId    | The ID of the DomInstance (Filterable)                           |
| Time         | The UTC time at which the change was done (Filterable)           |
| FullUsername | The name of the user who initiated the change (Filterable)       |
| DmaId        | The ID of the DMA on which the change was initiated (Filterable) |
| Changes      | The list of DomSectionChange objects                             |

The changes can be retrieved and filtered using the DomHelper. See the following examples:

```csharp
var filter = HistoryChangeExposers.SubjectID.Equal(domInstance.ID.ToFileFriendlyString());
```

```csharp
var history = domHelper.DomInstanceHistory.Read(filter);
```

> [!NOTE]
>
> - If the history storage were to work incorrectly, this will not affect the create, read, update or delete actions performed on the DomInstances. An error will be logged each time a history object could not be saved. A notice will only be generated once every hour.
> - It is not possible to manually create, update or delete history objects.
> - All history changes related to a DomInstance will automatically be deleted when that DomInstance is deleted.
> - History data is stored in a separate index per module (chistory_dominstance\_\*module id\*).

##### Adding attachments to DomInstances

It is possible to add attachments to DomInstance objects. See the examples below.

```csharp
var domHelper new DomHelper(engine.SendSLNetMessages, PermissionTestModuleId);
var fileBytes = File.ReadAllBytes("path");
// Adding an attachment
domHelper.DomInstances.Attachments.Add(domInstanceId, "filename", fileBytes);
// Get the names of all attachments
domHelper.DomInstances.Attachments.GetFileNames(domInstanceId);
// Get the content of an attachment
domHelper.DomInstances.Attachments.Get(domInstanceId, "filename");
// Delete an attachment
domHelper.DomInstances.Attachments.Delete(domInstanceId, "filename");
```

> [!NOTE]
>
> - The maximum size of the attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - If a DomInstance is deleted, all its attachments will physically be deleted from disk. They will not be recoverable.
> - Manipulating DomInstance attachments requires the same user permissions as normal DomInstance management operations: Read permission to view and download attachments and Edit permission to add and delete attachments.
> - All DomInstance attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.

#### Amazon Elasticsearch Service now supported \[ID_28104\]

DataMiner now supports Amazon Elasticsearch Service.

See the example below, showing how this can be configured in the *DB.xml* file.

```xml
<DataBase active="true" search="true" type="Elasticsearch">
  <DBServer>mycompany-elastic.amazonaws.com</DBServer>
  <UID>myUserId</UID>
  <PWD>myPassword</PWD>
</DataBase>
```

#### Video thumbnails: Authentication header can now be specified in an 'auth=' option \[ID_28116\]

In a video thumbnail URL, you can now specify an authorization header in an “auth=” option when requesting a thumbnail image from a video server using type “Generic Images”.

This option has to be used when the video server expects an authentication token (e.g. OAuth2).

> [!NOTE]
>
> - When the authentication token expires, the URL has to be updated with the new token.
> - URLs that request video thumbnails should use HTTPS instead of HTTP. That way, you can prevent the authentication token from being stolen.
> - It is now also possible to request thumbnails from video servers that only accept TLS 1.2.

#### Failover: PowerShell scripts can now be triggered when a Failover Agent claims or releases a virtual IP address \[ID_28236\]

When a Failover Agent claims or releases a virtual IP address, the following PowerShell scripts will now be triggered (if they exist):

- C:\\Skyline DataMiner\\Tools\\VIPAcquired.ps1
- C:\\Skyline DataMiner\\Tools\\VIPReleased.ps1

> [!NOTE]
>
> - The VIPAcquired script will also be triggered when the online Agent starts, but the VIPReleased script will not be triggered when the offline Agent starts.
> - The content of the Failover scripts can be read and modified using the FailoverScriptManagerHelper.

#### Elasticsearch: Multi-cluster offload \[ID_28295\]\[ID_28384\]\[ID_28473\]

It is now possible to have data offloaded to multiple Elasticsearch clusters, i.e. a main cluster and a number of replicated clusters.

Read actions are sent to the main cluster only, while write, delete and other modifying actions are sent to the main cluster as well as to all replicated clusters.

When an error occurs on one of the replicated clusters, a single alarm will be generated, indicating that there is a chance that not all data was replicated. If subsequent errors occur on the replicated clusters, no new similar alarms will be generated until after the DMA has been restarted.

##### Configuration

The configuration of the Elasticsearch clusters can be stored in a new *DBConfiguration.xml* file, located in the *C:\\Skyline DataMiner\\Database* folder. This configuration file takes priority over the existing *DB.xml* file when it comes to Elasticsearch.

At DataMiner startup, when the *DBConfiguration.xml* file exists and an Elasticsearch connection is defined in the *DB.xml* file, the Elasticsearch connection is commented out in the *DB.xml* file and an additional comment is added, indicating that the Elasticsearch configuration is taken from the *DBConfiguration.xml* file instead.

> [!NOTE]
>
> - The cluster with the lowest “priorityOrder” value is considered the main cluster. All other clusters are considered the replicated clusters.
> - The *DBConfiguration.xml* file is not synchronized among the DMAs in a DMS.

#### Message throttling configuration in MaintenanceSettings.xml \[ID_28335\] \[ID_32426\]

It is now possible to fine-tune message throttling, i.e. a mechanism that avoids an excessive number of parameter update messages getting sent to a client at the same time, using the following settings in *MaintenanceSettings.xml*:

- *MessageThrottlingThreshold*: Time interval in ms. The default and minimum value is 250. If two updates for the same parameter are received within this interval, message throttling is activated. The first of the parameter updates is sent immediately, but messages for the same parameter that come after this are throttled until no more parameter updates have been received for this same time interval. Once the throttling has stopped, the last update is also sent after at most this time interval.

- *MessageThrottlingPeriodicUpdate*: Time interval in ms. The default value is 1000, and the value must always be at least twice the *MessageThrottlingThreshold* value. If there is a steady flow of updates for the same parameter, and message throttling is activated, a periodic update is sent after this interval.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <MessageThrottlingThreshold>250</MessageThrottlingThreshold>
    <MessageThrottlingPeriodicUpdate>1000</MessageThrottlingPeriodicUpdate>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

> [!NOTE]
> This throttling mechanism is not applied to parameter changes originating from SLSpectrum, as spectrum traces are intended to mimic the actual front-panel display of a spectrum analyzer.

#### All alarms will now be published on the NATS bus \[ID_28441\]

On DataMiner Agents that contain an SLCloud.xml configuration file and are able to connect to a NATS instance, all new real-time alarms will now be published on the NATS bus.

Alarms will be published with the following topic name:

```txt
alarm.dma_id.element_id.pid.row_key
```

Example: alarm.162.951.102.AMP33_SLC

> [!NOTE]
> Currently, the alarm only contains the IDs of the views containing the parent object of the alarm (e.g. element, service, etc.). It does not yet contain the IDs of the views containing all the parents of that parent object.

#### Failover: Connecting to the online Agent using a DNS record with 2 IP addresses \[ID_28634\]

It is now possible to connect to the online Agent in a Failover setup when that setup only has a single DNS record containing 2 IP addresses (i.e. one for the online agent and one for the offline agent).

#### Deletion history of services and service templates \[ID_28664\]

From now on, each time a service or a service template is deleted, a service history record will be written to the database. Each record will contain the following information:

- A unique record ID
- The ID of the service (template) that was deleted
- The name of the service (template) that was deleted
- The time at which the service (template) was deleted
- The time at which the service (template) was created.

The service history records can be retrieved using the existing HistoryHelper:

```csharp
var historyHelper = new HistoryHelper(engine.SendSLNetMessages);
var recordsPastDay = ServiceDeletionHistoryExposers.ServiceDeletedAt.GreaterThan(DateTime.UtcNow.AddDays(-1));
var historyRecords = historyHelper.ServiceDeletionHistory.Read(recordsPastDay);
```

> [!NOTE]
>
> - Service history records are stored in Elasticsearch. This means that an Elasticsearch database has to be available for this feature to work.
> - If you want the service history records to be included in a DataMiner backup, select the *Include service history data in backup* option. In case of a full backup, this option will be selected by default.

#### Improved average trending \[ID_28684\]

The following improvements have been implemented to average trending:

- Because of improved performance and throughput, you will now be able to activate average trending for a larger number of parameters.
- Previously, average trending was discouraged in case there were a lot of different instances of a specific parameter. This is no longer the case. You can now use average trending even if millions of instances of the parameter are polled.
- Unexpected gaps in trend graphs, e.g. because an element is started or stopped, or because a parameter is cleared, will now be prevented.
- Issues with history sets not being averaged, e.g. when an element had been recently restarted, will now be prevented.
- Average data will be available more quickly. When parameter changes are averaged from 00:00:00 to 00:05:00, the average point is now guaranteed to become available in the database between 00:06:00 and 00:07:00, while previously this could take up to 5 minutes or longer. However, note that this does not apply if the parameter changes were pushed as a history set.

However, note that this results in a number of breaking changes:

- Some special status trend points will no longer be used. For more detailed information, see [Special status trend points](https://community.dataminer.services/documentation/average-trending-calculation/#special-status-trend-points).
- In some specific cases, intervals between two average trend points are no longer guaranteed to be constant. For more information, see [Granularity of averaged trend data](https://community.dataminer.services/documentation/average-trending-calculation/#granularity-of-averaged-trend-data).
- The exception values of continuous (non-discrete) parameters are now averaged in a discrete manner. For more information, see [Protocol-defined exception values](https://community.dataminer.services/documentation/average-trending-calculation/#protocol-defined-exception-values).

#### SLAnalytics - Automatic incident tracking: Grouping on generic alarm, element, service and view properties \[ID_28820\]

Automatic incident tracking attempts to group alarms that belong to the same incident. To do so, by default, it takes into account the following alarm properties:

- The parameter associated with the alarm
- The service associated with the alarm
- The element associated with the alarm, the IDP location of this element, and the view(s) in which this element is located
- The polling IP address of the element associated with the alarm (only in case of a timeout alarm)

From now on, automatic incident tracking can also take into account any alarm, element, service or view property.

- The properties that have to be taken into account must be configured in the analytics configuration file. See “Configuration” below.
- The alarm properties that have to be taken into account need to have the *Update alarms on value changed* option activated in DataMiner Cube.
- The element, service and view properties that have to be taken into account need to have the *Make this property available for alarm filtering* option activated in DataMiner Cube.

Alarms are grouped as soon as they have the same value for one of the configured alarm, service or view properties, the same focus value and approximately the same timestamp. However, in case of grouping on element property, a threshold needs to be set and alarms will only be grouped when a certain amount of elements with the given property value are in alarm. In other words, alarms on elements with the same property value will be grouped when the proportion of elements in alarm among all elements with that property value is greater than the configured threshold.

##### Configuration

If you want automatic incident tracking to take into account a certain alarm, element, view or service property, you will need to add that property to the \<Value>\</Value> tag in the following section of the \[DataMiner installation folder\]\\analytics\\configuration.xml file.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::vector&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt;,class std::allocator&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt; &gt; &gt; &gt;">
  <Value>
    [One <item> tag per property that has to be taken into account. See below.]
  </Value>
  <Accessibility>2</Accessibility>
  <Name>GenericProperties</Name>
</item>
```

> [!NOTE]
> After you edit this configuration file, SLAnalytics needs to be restarted.

To add an element property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the element property and \[THRESHOLD\] with the desired threshold (see above).

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericElementPropertyVisitorConfiguration">
  <enable>true</enable>
  <threshold>[THRESHOLD]</threshold>
  <name>[PROPERTY_NAME]</name>
</item>
```

To add an alarm property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the alarm property.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericAlarmPropertyVisitorConfiguration">
  <enable>true</enable>
  <name>[PROPERTY_NAME]</name>
</item>
```

To add a view property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the view property.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericViewPropertyVisitorConfiguration">
  <enable>true</enable>
  <name>[PROPERTY_NAME]</name>
</item>
```

To add a service property, add the following \<item> tag inside the \<value> tag. Make sure to replace \[PROPERTY_NAME\] with the name of the service property.

```xml
<item type="skyline::dataminer::analytics::workers::configuration::GenericServicePropertyVisitorConfiguration">
  <enable>true</enable>
  <name>[PROPERTY_NAME]</name>
</item>
```

#### LogHelper API: New FlushToDatabaseAfterUpsert option \[ID_28837\]

The LogHelper API now has a FlushToDatabaseAfterUpsert option.

- If you set this option to true (i.e. the default setting), the LogHelper will wait for the database to respond after writing log entries to the database.
- If you set this option to false, the LogHelper will not wait for the database to respond after writing log entries to the database.

> [!NOTE]
> If you set this option to false, there are no guarantees that all log entries will get stored in the database, especially in case of e.g. connection issues or exceptions.

#### Masked alarms will no longer be automatically unmasked when cleared \[ID_29007\]\[ID_29138\]

Up to now, when a masked alarm was cleared, it would automatically be unmasked. From now on, when a masked alarm is cleared, it will stay masked as long as the element associated with the alarm is masked.

In DataMiner Cube, the mask status (“Masked” or “Not masked”) will now be indicated in the Alarm Console column “Extra status”, which will not be visible by default.

> [!NOTE]
> This change will cause a small increase in latency when retrieving alarms from the database.

#### Configuration of credentials for Elasticsearch backup location \[ID_29024\]

It is now possible to configure specific credentials for the Elasticsearch backup location. To do so, send a *SetElasticBackupPath* message with the credentials using the SLNetClientTest tool. This will create a Windows scheduled task "elasticbackupwithcredentials", which is triggered on startup, and which makes it possible to access the backup path location.

> [!WARNING]
> Always be extremely careful when using SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Failover without virtual IP address [ID_29189] [ID_29911]

In a Failover system, which consists of two redundant DataMiner Agents, the offline Agent will stand by, waiting to take over as soon as the online Agent goes offline. Up to now, a Failover system always made use of a so-called "virtual IP address", an IP address that is shared by the two Agents and that the online Agent assigns to itself. However, in certain situations, it is very hard or even impossible to share a virtual IP address. In those situations, it is now possible to set up a Failover system using a shared hostname instead.

| Using a shared virtual IP address                      | Using a shared hostname                                                |
|--------------------------------------------------------|------------------------------------------------------------------------|
| DataMiner creates a virtual IP address on the NIC      | No modifications are needed on the NIC                                 |
| No additional IIS rules need to be created             | A "URL Rewrite" IIS rule will be created automatically (Reverse Proxy) |
| 2 NICs can be configured (Corporate & Acquisition) | Only one hostname (address)                                            |

##### Configuration

In DataMiner Cube, after opening the *Failover Config* window, you can now select either "Failover (Virtual IP)" or "Failover (hostname)".

Note that, in the DMS.xml file, two extra elements can now be specified:

- **FailoverType**: The type of Failover system: "VirtualIP" or "HostName".
- **Hostname**: The shared hostname (only applicable when FailoverType is set to "HostName".

  > [!NOTE]
  >
  > - The hostname you specify must be configured in the network. In other words, a corresponding DNS record must exist.
  > - The hostname must resolve to both primary IP addresses of the Failover agents. Example output of an nslookup of the hostname:
  >
  >   ```txt
  >   Name: ResetPlease.FailoverZone
  >   Addresses: 10.11.5.52
  >   10.11.4.52
  >   ```

When you set up a Failover system using a shared hostname, in IIS, a URL Rewrite rule will be created in order to forward all HTTP traffic to the online agent.

> [!NOTE]
> In order for this URL Rewrite rule to be created and enabled/disable automatically, the IIS extension "Application Request Routing" needs to be installed manually on both Failover agents. See <https://www.iis.net/downloads/microsoft/application-request-routing>.

#### External alarms can now also have general alarm properties \[ID_29231\]

External alarms (e.g. anomaly detection alarms, etc.) can now also have general alarm properties such as “System Name” or “System Type”.

> [!NOTE]
> DataMiner automatically evaluates and populates the “System Name” and “System Type” alarm properties. If you want external alarms to overwrite the values in those properties, make sure new property values are passed along with those external alarms.

#### Mobile Gateway: SMSEagle device can now send Unicode messages \[ID_29369\]

When using an SMSEagle device to send text messages, it is now possible to configure that device to use Unicode characters.

To do so, proceed as follows:

1. In the *C:\\Skyline DataMiner\\Mobile Gateway\\Config.xml* file, add unicode=”true” to the \<SMSEagle> element, and save the file.
2. Restart the SLGSMGateway process.

Default setting: unicode=”false”

#### New alarm table field on MySQL and SQL Server databases: ExtraStatusId \[ID_29374\]

On MySQL and Microsoft SQL Server databases, the alarm table now has an extra field of type BIGINT: ExtraStatusId.

> [!NOTE]
>
> - This change will cause a small increase in latency when retrieving alarms from the database.
> - From now on, using a filter with an AlarmFilterItemExtraStatus in the GetAlarmDetailsFromDbMessage from within an Automation script will not work correctly in conjunction with a MySQL or Microsoft SQL Server database.

#### SimulationHelper API now allows loading, enabling and disabling element simulations at run-time \[ID_29517\]

Up to now, loading new element simulations always required a DataMiner restart. Now, the SimulationHelper API will allow you to load, enable and disable element simulations at run-time from within protocol QActions or Automation scripts.

Construction:

```csharp
SimulationHelper(Func<DMSMessage[], DMSMessage[]> messageHandler)
```

- Loading all simulation files stored in the C:\\Skyline DataMiner\\Simulations folder of a specified DMA

    ```csharp
    void LoadSimulations(int dataMinerId)
    ```

- Enabling an element simulation

    ```csharp
    void EnableSimulation(int hostingDataMinerId, int dataMinerId, int elementId)
    ```

- Disabling an element simulation

    ```csharp
    void DisableSimulation(int hostingDataMinerId, int dataMinerId, int elementId)
    ```

Example of how to use this in an Automation script:

```csharp
var simulationHelper = new SimulationHelper(Engine.SLNet.SendMessages);
simulationHelper.LoadSimulations();
```

#### Alarm storm mode for clearable alarms \[ID_29637\]

A protection has been added to avoid reduced performance of the system when an alarm storm happens that causes a large number of clearable alarms at the same time. By default, when there are more than 1000 clearable alarm trees on a DMA, the newly generated clearable alarms will be closed instead of clearable. Once the number of clearable alarm trees has dropped to less than 100, this protection mode is lifted and newly generated alarms will be clearable again.

> [!NOTE]
> In *DataMiner.xml*, you can customize the above-mentioned default values for the minimum and maximum threshold with the min and max attributes of the DataMiner.ClearableAlarmStormProtection tag.
> If you change these settings, you must do so on every DMA in a cluster, as they are not automatically synchronized.

#### EPM: Aliases for topology cells, chains and search chains can now be specified in EPMConfig.xml \[ID_29766\]\[ID_29841\]

In an EPM environment, it is now possible to override the names of topology cells, chains and search chains specified in a protocol with aliases specified in a separate file.

In the *C:\\Skyline DataMiner\\* folder, create an *EPMConfig.xml* file that contains a \<Topologies> and/or \<Chains> configuration identical to the one in the protocol, and specify the necessary aliases in override attributes. See the following example.

```xml
<Protocol>
  <Topologies>
    <Topology name="" override="CustomChainName">
      <Cell name="CM" override="Cable Modem"/>
      <Cell name="OLT" override="Hub"/>
      <Cell name="Street" override="CustomStreet"/>
    </Topology>
    ...
  </Topologies>
  <Chains>
    <Chain name="OLT (Limited)" override="Full OLT">
      <Field name="Network" override="Mesh"/>
    </Chain>
    ...
    <SearchChain name="search">
      <Tabs>
        <Tab name="STB" override="Box">
          <Field name="Customer ID" override="User ID"/>
        </Tab>
      </Tabs>
    </SearchChain>
    ...
  </Chains>
</Protocol>
```

> [!NOTE]
>
> - If you want the aliases to be applied on every DMA in a DMS, then make sure every DMA contains a copy of the same *EPMConfig.xml* file.
> - When you update the *EPMConfig.xml* file on a particular DMA, delete the \*.txf files on that DMA and restart DataMiner.
> - Currently, the *EPMConfig.xml* file is only read at DataMiner startup.
