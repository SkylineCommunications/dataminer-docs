---
uid: General_Main_Release_10.2.0
---

# General Main Release 10.2.0

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

## New features

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

#### SLSpectrum: Refactoring of code used to play back spectrum recordings \[ID_29785\]

In SLSpectrum, the code used to play back spectrum recordings has been refactored.

Also, the SpectrumManagerHelper now allows you to play, pause, slow-forward and fast-forward a recording. See the following table.

| Action       | Instruction                                                            |
|--------------|------------------------------------------------------------------------|
| Pause        | Helper.SetSpectrumRecordingSpeed(0.0)                                  |
| Play         | Helper.SetSpectrumRecordingSpeed(1.0)                                  |
| Slow-forward | Helper.SetSpectrumRecordingSpeed(0.5)<br> (any number between 0 and 1) |
| Fast-forward | Helper.SetSpectrumRecordingSpeed(2.0)<br> (any number greater than 1)  |

#### Improved SLLog stack cleaning behavior \[ID_29989\]

The way the SLLog process cleans the log file stack has been improved. SLLog now has a thread that iterates over the different log file buffers and that logs a number of lines from the buffers to the log files. The maximum number of lines depends on the *LinesPerIteration* setting in *LogSettings.xml* (default: 100).

In addition, SLLog now monitors its own memory usage, and whenever the memory usage exceeds a specific threshold, it will clean up the largest stack that has not yet been written to a file. This threshold is determined by the *SLLogMaxMemorysetting* in *LogSettings.xml* (default: 500 MB). For this setting, you can only specify integer numbers, which correspond with a number of megabytes.

*LogSettings.xml* can for instance be configured as follows:

```xml
<Log xmlns="http://www.skyline.be/config/log">
   <File name="">
      <Levels info="0" error="0" debug="0" />
   </File>
   <General>
      <LinesPerIteration>50</LinesPerIteration>
      <SLLogMaxMemory>100</SLLogMaxMemory>
   </General>
</Log>
```

#### DataMiner Object Model: DomInstanceNameDefinition \[ID_30226\]

A ModuleSettings object now has a DomInstanceNameDefinition property, which allows you to define how the name property of a DomInstance should be filled in automatically each time the instance is saved.

The DomInstanceNameDefinition class can contain a list of IDomInstanceConcatenationItems, which, placed in a specific order, will define the DomInstance name.

Currently, there are two types of concatenation items:

- **StaticValueConcatenationItem**

    Used to define a fixed string to be inserted into the DomInstance name.     The string value should be assigned to the ‘Value’ property.

- **FieldValueConcatenationItem**

    Used to define a FieldValue (defined on a DomInstance) to be inserted into the DomInstance name.     The FieldDescriptorID of the FieldValue should be assigned to the FieldDescriptorId property. When no FieldValue can be found with the given FieldDescriptorId, an empty string will be inserted instead.     A FieldValue can contain a variety of non-string data types. See below for more information on how these types will be converted to strings:

    | FieldValue type | Example of how this type will be converted to a string |
    |-------------------|--------------------------------------------------------|
    | Guid              | ‘bc77dcb5-b523-4722-aaaa-7d99a5c82304’                 |
    | double            | ‘124.65’                                               |
    | long/int          | ‘15254876’                                             |
    | DateTime          | ‘1997-04-10T14:40:14.0000000Z’ (ISO8601)               |
    | TimeSpan          | ‘13:28:18.9187335’                                     |
    | bool              | ‘True’                                                 |
    | GenericEnumEntry  | ‘SomeDisplayValue’ (the DisplayValue will be used)     |

##### Example

In the following example, we want to create DomInstances for switches in a network and created FieldDescriptors for the following data:

- Switch brand
- Switch model
- Management IP
- Year of installation

The names of the DomInstances, which will each represent a switch, have to contain all this information (example: “Cisco C9500-24Y4C - 10.11.5.87 (2021)”).

To achieve this, we could define the following in the ModuleSettings object, assuming that the FieldDescriptorIDs have already been defined elsewhere in the script/code:

```csharp
var settings = new ModuleSettings()
{
    ModuleId = "moduleid",
    DomManagerSettings = new DomManagerSettings()
    {
        DomInstanceNameDefinition = new DomInstanceNameDefinition()
        {
            ConcatenationItems = new List<IDomInstanceConcatenationItem>()
            {
                new FieldValueConcatenationItem(switchBrandDescriptorId),
                new StaticValueConcatenationItem(" "),
                new FieldValueConcatenationItem(switchModelDescriptorId),
                new StaticValueConcatenationItem(" - "),
                new FieldValueConcatenationItem(managementIpDescriptorId),
                new StaticValueConcatenationItem(" ("),
                new FieldValueConcatenationItem(yearDescriptorId),
                new StaticValueConcatenationItem(")")
            }
        }
    }
};
```

> [!NOTE]
>
> - When no concatenation is defined (i.e. when DomInstanceNameDefinition is empty or null), the ID of the DomInstance will be used as DomInstance name.
> - When multiple values are defined for the same FieldDescriptor (i.e. when there are multiple Sections for the same SectionDefinition), the first value will be used for the concatenation.
> - The DomInstanceNameDefinition can be overridden by a DomDefinition on the ModuleSettingsOverrides property.

#### DataMiner Object Model: DomBehaviorDefinition object & status system \[ID_30443\]

The DataMiner Object Model can now also contain objects of type DomBehaviorDefinition.

A DomBehaviorDefinition is a standalone object that extends a normal DomDefinition and contains configuration settings for special behavior, including the configuration of the status system. In a ModuleSettings object, the ModuleBehaviorDefinition property will contain the ID of the DomBehaviorDefinition that includes all the configuration settings that must be used in that particular module.

##### DomBehaviorDefinition properties

A DomBehaviorDefinition object has the following properties.

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | DomBehaviorDefinitionId | Yes | The unique ID of the definition. |
| Name | string | Yes | The name of the definition. |
| ParentId | DomBehaviorDefinitionId | Yes | The ID of the parent DomBehavior-Definition (when using inheritance). |
| InitialStatusId | string | No | The ID of the status that should be used when new DomInstances are created. |
| Statuses | List\<DomStatus> | No | A list of all statuses. |
| StatusSectionDefinitionLinks | List\<DomStatusSectionDefinitionLink> | No | A list of links to SectionDefinitions that define which fields are required, allowed, etc. for a specific status. |
| StatusTransitions | List\<DomStatusTransition> | No | A list of all allowed status transitions. |

> [!NOTE]
> Properties of which the *Filterable* column contains “Yes” can be used for filtering using DomBehaviorDefinitionExposers.

##### DomBehaviorDefinition inheritance

One DomBehaviorDefinition can inherit from another.

Limitations:

- A DomBehaviorDefinition can only inherit from the DomBehaviorDefinition that is specified in the ModuleBehaviorDefinition property of the ModuleSettings object.
- A DomBehaviorDefinition that inherits from another DomBehaviorDefinition can only contain an ID, a parent ID and a list of additional DomStatusSectionDefinitionLinks to SectionDefinitions that are not defined in the module definition. Adding additional statuses or status transitions is not allowed.

##### Requirements

Create & update:

- The string IDs of the statuses and status transitions must not contain duplicates and should all be lowercase.
- When a ModuleDomBehaviorDefinition has been defined, the definition that is being created or updated must inherit from it. When no ModuleDomBehaviorDefinition has been defined, the ParentId property should be empty.
- The InitialStatusId property must contain the ID of an existing status.
- All status transitions must contain IDs of existing statuses.
- For each SectionDefinition/status pair, only one DomStatusSectionDefinitionLink is allowed.
- All DomStatusSectionDefinitionLinks must refer to existing status IDs.

Delete:

- A DomBehaviorDefinition can only be deleted when no DomDefinitions or other DomBehaviorDefinitions link to it.

##### Errors

The TraceData can contain one or more DomDefinitionErrors. For each error, the Id and Name properties will be filled in alongside any other property mentioned in the description. See below for a list of all possible ErrorReasons:

| Reason | Description |
|--|--|
| InvalidParentId | The DomBehaviorDefinition.ParentId property contains an unexpected ID. If a ModuleDomBehaviorDefinition is defined, it must contain the ID of that definition. If not, it should be empty. |
| InheritingDefinitionContainsInvalidData | The DomBehaviorDefinition inherits from another one, but it contains data that is not allowed. Only the DomBehaviorDefinition.StatusSectionDefinitionLinks can contain additional objects. |
| StatusTransitionsReferenceNonExistingStatuses | At least one DomStatusTransition refers to a status that does not exist. The ID(s) of the invalid transition(s) can be found in StatusTransitionsIds. |
| StatusSectionDefinitionLinksReferenceNonExistingStatuses | At least one DomStatusSectionDefinitionLink refers to a status that does not exist. The ID(s) of the invalid DomStatusSectionDefinitionLink(s) can be found in DomStatusSectionDefinitionLinkIds. |
| InvalidStatusIds | At least one status has an invalid ID (IDs should only contain lowercase characters). The ID(s) of the invalid status(es) can be found in StatusIds. |
| DuplicateStatusIds | Some statuses have duplicate status IDs. The ID(s) of the duplicate status(es) can be found in StatusIds. |
| InvalidTransitionIds | At least one transition has an invalid transition ID (IDs should only contain lowercase characters). The ID(s) of the invalid transition(s) can be found in StatusTransitionsIds. |
| DuplicateTransitionIds | Some transitions have duplicate transition IDs. The ID(s) of the duplicate transition(s) can be found in StatusTransitionsIds. |
| InUseByDomDefinitions | The DomBehaviorDefinition cannot be deleted because it is being used by at least one DomDefinition. The ID(s) of these DomDefinition(s) can be found in DomDefinitionIds. |
| InUseByDomBehaviorDefinitions | The DomBehaviorDefinition cannot be deleted because it is being used by at least one DomBehaviorDefinition. The ID(s) of these DomBehaviorDefinition(s) can be found in DomBehaviorDefinitionIds. |
| InvalidInitialStatusId | The DomBehaviorDefinition defines at least one status, but does not define a valid initial status. The ID of the invalid initial status (which can be empty) can be found in StatusIds. |
| DuplicateSectionDefinitionLinks | The DomBehaviorDefinition defines more than one DomStatusSectionDefinitionLink for the same SectionDefinition/status pair. The ID(s) of the duplicate DomStatusSectionDefinitionLinks can be found in DomStatusSectionDefinitionLinkIds. |

##### Security

Security checks are performed on CRUD actions when user permissions are configured on the DomManagerSecuritySettings (of the ModuleSettings).

- To read DomBehaviorDefinitions, users must be granted the DomManagerSecuritySettings.ViewPermission.
- To create, update or delete DomBehaviorDefinitions, users must be granted the DomManagerSecuritySettings.ConfigurePermission.

> [!NOTE]
> To create, update or delete the ModuleDomBehaviorDefinition, users must be granted the ModuleSettingsConfiguration permission.

##### Status system

In a DomManager, you can now configure a DomDefinition to use the status system.

When a DomDefinition is using the status system, each DomInstance linked to that DomDefinition has to adhere to the rules set by the status system. The status system can be configured by means of a DomBehaviorDefinition object linked to the DomDefinition. A DomBehaviorDefinition object contains properties in which you can store the statuses, the initial status, the status transitions and links to the SectionDefinitions.

Using the status system is an alternate way of defining which data should be present in a DomInstance. This means that, when a status system is used, the SectionDefinitionLinks on the DomDefinition will not be used.

> [!NOTE]
> A DomManager will detect that the status system is being used from the moment (a) a DomDefinition is linked to a DomBehaviorDefinition and (b) that DomBehaviorDefinition contains at least one status.

To set up a status system, do the following:

1. Create a new DomBehaviorDefinition.

    - Add all statuses.
    - Define the initial status.
    - Add all status transitions.
    - Configure all fields.

2. Link a DomDefinition to the DomBehaviorDefinition.

3. Create DomInstances using the appropriate statuses and fields.

Configuration:

- To configure the statuses, for each status add a DomStatus object to the Statuses list property of the DomBehaviorDefinition. A DomStatus has the following properties:

    | Property  | Type   | Explanation                                                                                  |
    |-------------|--------|----------------------------------------------------------------------------------------------|
    | Id          | string | The ID of the status, consisting of lowercase characters only. Example: “initial_status” |
    | DisplayName | string | The display name of the status. Example: “Initial”                                       |

    > [!NOTE]
    >
    > - The Statuses collection should not contain any DomStatus objects with identical IDs.
    > - InitialStatusId must contain the ID of an existing status. When a DomInstance is created and no status is assigned to it, it will automatically be assigned the status specified in InitialStatusId.

- To configure the allowed status transitions, for each transition add a DomStatusTransition object to the Transitions list property of the DomBehaviorDefinition. A DomStatusTransition has the following properties:

    | Property   | Type   | Explanation                                                                                                                                                                                                           |
    |--------------|--------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Id           | string | The ID of the transition, consisting of lowercase characters only. Example: “initial_to_accepted_status”                                                                                                          |
    | FromStatusId | string | The ID of the status from which the DomInstance will transition.                                                                                                                                                      |
    | ToStatusId   | string | The ID of the status to which the DomInstance will transition.                                                                                                                                                        |
    | FlowLevel    | int    | The flow level of the transition compared to other transitions. The main transition will have FlowLevel 0 (the highest priority), while alternate transitions from the same status will have FlowLevel 1 or more. |

    > [!NOTE]
    > The Transitions collection should not contain any DomStatusTransition objects with identical IDs.

- For each status, you can configure the requirements of a specific field. To do so, create DomStatusSectionDefinitionLinks that each include DomStatusFieldDescriptorLinks. A DomStatusSectionDefinitionLink has the following properties:

    | Property             | Type                                | Explanation                                                           |
    |----------------------|-------------------------------------|-----------------------------------------------------------------------|
    | Id                   | DomStatusSectionDefinitionLinkId    | The SectionDefinitionID and the status ID.                            |
    | FieldDescriptorLinks | List\<DomStatusFieldDescriptorLink> | The links to FieldDescriptors that are part of the SectionDefinition. |

    A DomStatusFieldDescriptorLink contains the following properties:

    | Property        | Type              | Explanation                                                              |
    |-------------------|-------------------|--------------------------------------------------------------------------|
    | FieldDescriptorId | FieldDescriptorID | The ID of the linked FieldDescriptor.                                    |
    | Visible           | bool              | Whether this field should be visible in the UI for this status.          |
    | RequiredForStatus | bool              | Whether a value for this field must be present and valid in this status. |
    | ReadOnly          | bool              | Whether values of this field are read-only in this status.               |

    > [!NOTE]
    >
    > - When there is no FieldDescriptorLink for an existing FieldDescriptor, then no values will be allowed for this FieldDescriptor in that specific status.
    > - The Visible property is only used to tell the UI whether the field should be visible or not.
    > - When a field is marked as required, then at least one value for this FieldDescriptor should be present in a DomInstance and all values for this FieldDescriptor should be valid according to the validators of that descriptor (if any were defined).
    > - When a field is marked as read-only for a specified status, the values cannot be changed. If none were present before transitioning to that status, none can be added anymore once the DomInstance is in that status.
    > - The existence of the SectionDefinitions and FieldDescriptors are not checked when a DomBehaviorDefinition is saved.

    Some examples of fields you can define:

    | Case                       | RequiredForStatus | ReadOnly | Note                                                                                                                                                              |
    |------------------------------|-------------------|----------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Not allowed                  | N/A               | N/A      | When no values are allowed to be present, no FieldDescriptorLink should be added to the list.                                                                     |
    | Optional & editable      | false             | false    | A value can optionally be added or an existing value can be updated or deleted.                                                                                   |
    | Optional & not editable  | false             | true     | A value may be present but it is not required. None can be added, edited or deleted.                                                                              |
    | Required & editable      | true              | false    | A valid value must be present when transitioning to the status in question and it can be updated as long as there is at least one value and all values are valid. |
    | Required & not editable | true              | true     | A valid value must be present when transitioning and it can no longer be changed in this status.                                                                  |

If a DomInstance is created without a status, the DomManager will automatically assign the initial status when it detects that the instance is linked to a DomDefinition that uses the status system.

Transitioning to another status can only be done by means of a specific transition request. Changing the status by performing a status update is not allowed. A transition request requires the ID of the DomInstance and the ID of the transition. These requests can be sent using the helper.

```txt
domHelper.DomInstances.DoStatusTransition(domInstance.ID, "initial_to_acceptance");
```

When something goes wrong while performing a status transition, a DomStatusTransitionError will be returned in the TraceData of the request. This error can contain the following reasons:

| Reason | Description |
|--|--|
| StatusTransitionNotFound | The transition ID does not match any of the IDs defined on the associated DomBehaviorDefinition. This error can also occur when no valid DomBehaviorDefinition is linked. StatusTransitionId contains the ID of the transition that could not be found. |
| StatusTransitionIncompatibleWithCurrentStatus | The current status of the DomInstance does not match the “from” status defined by the transition. StatusTransitionId contains the ID of the transition that could not be completed. |
| DomInstanceContainsUnknownFieldsForNextStatus | At least one FieldValue was defined on the DomInstance for which in the DomBehaviorDefinition no link could be found to the next status. AssociatedFields contains the SectionDefinitionID/FieldDescriptorID pairs of the unknown fields. |
| DomInstanceHasInvalidFieldsForNextStatus | The DomInstance contains fields that are required but are not valid according to at least one validator. If there are multiple values for the same SectionDefinition and FieldDescriptor, only one entry will be included. AssociatedFields contains the SectionDefinitionID/FieldDescriptorID pairs of the invalid fields. |
| DomInstanceHasMissingRequiredFieldsForNextStatus | The DomInstance does not contain all fields that are required for the next status. AssociatedFields contains the SectionDefinitionID/FieldDescriptorID pairs of the missing fields. |
| CrudFailedExceptionOccurred | When saving the DomInstance, a CrudFailedException occurred. InnerTraceData will contain the TraceData included in the exception. |

It is possible to mark one DomBehaviorDefinition as the main “Module” definition. This will force all other DomBehaviorDefinitions to inherit from it, forcing them all to use the same status system. The inheriting definitions can only add extra DomStatusSectionDefinitionLinks.

#### Connecting a DataMiner System to the cloud \[ID_30513\]

It is now possible to connect a DataMiner System to the cloud. To do so:

1. Verify that each DMA that will be connected to the cloud is able to reach the following endpoints:

    - `https://connect.dataminer.services/`
    - `wss://tunnel.dataminer.services/`

2. Download the appropriate DataMiner Cloud Pack installer from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on one or more DMAs in the cluster. As .NET 5 is required to connect the DataMiner Cloud, you can choose an installer that includes or downloads .NET 5. If .NET 5 is already installed in your system, choose the installer that does not include .NET 5.

3. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following user permissions.

    - *System configuration* > *Cloud gateway* > *Connect to DCP*
    - *System configuration* > *Cloud gateway* > *Disconnect from DCP*

4. On the System Center \> *Cloud* page, click the *Connect* button. A pop-up browser window will open.

    > [!NOTE]
    > Internet Explorer is not supported for this. If your default browser is Internet Explorer, you may need to change this temporarily in order to continue with this procedure.

5. Specify the following information in the pop-up window:

    - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system, or by clicking *Create new* and specifying your name and DNS.
    - DMS name: Specify the name you want to use for your DMS.
    - DMS URL: Specify a URL-friendly version of the DMS name.

6. Select the checkbox to agree to the terms of service and click *Connect*.

7. On the System Center \> *Cloud* page, wait until the status under *Cloud info* changes to *Registered*. This can take up to half a minute.

If your DMS was already connected to the cloud using the earlier soft-launch version of this feature, install the DataMiner Cloud Pack installer on at least one DMA that was already hosting the cloud gateway, as described in step 2 above.

> [!NOTE]
> Make sure that all users that should be able to share data with the cloud have the necessary user permissions under *System configuration* > *Cloud sharing*. Refer to the DataMiner Help for more details.

#### New DataMiner process: SLSpiHost \[ID_30869\]

From now on, all processing with regard to system performance indicators (SPIs) will be performed by the new SLSpiHost process instead of the SLNet process.

#### DataMiner Object Model: Actions & buttons \[ID_30923\]

It is now possible to define actions on a DomBehaviorDefinition, which can be triggered via the DomHelper, and buttons that will execute one or more actions when clicked.

##### Defining an action

You can define an action by adding an IDomActionDefinition to the ActionDefinitions list of a DomBehaviorDefinition. Each action definition has an ID of type string and a condition of type IDomCondition. The ID must be unique for the DomBehaviorDefinition in question and can only contain lower-case characters.

Currently, you can only define actions of type ExecuteScriptDomActionDefinition, i.e. actions that execute a specified script. This type of action has the following properties.

| Property | Type | Description |
|--|--|--|
| Id | string | The ID of the action. |
| Condition | IDomCondition | The condition that should be met before the action is allowed to be executed. Note: When you do not define a condition, it will always be allowed to execute the action. |
| Script | string | The name of the script to be executed. |
| Async | bool | Whether the script will be run asynchronously (true) or synchronously (false). When true, no errors or info data from the script will be returned. |
| ScriptOptions | List\<string> | A list of options (e.g. “PARAMETER:1:MyValue”) that will be passed to the SLAutomation process during execution. Note: Do not add the “DEFER” option. This option will be added automatically depending on the value of the Async property. |

The scripts that will be executed using this action require a custom entry point of type OnDomAction. This entry point method should have two arguments: the IEngine object and an ExecuteScriptDomActionContext object. See the following example.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel.Actions;
namespace DOM_Action_Example
{
    public class Script
    {
        public void Run(Engine engine)
        {
            engine.ExitFail("This script should be executed using the 'OnDomAction' entry point");
        }
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomAction)]
        public void OnDomActionMethod(IEngine engine, ExecuteScriptDomActionContext context)
        {
            engine.GenerateInformation($"The DOM action with ID '{context.ActionId}' was executed.");
        }
    }
}
```

The ExecuteScriptDomActionContext object has the following properties:

| Property  | Type          | Description                                                                                                     |
|-----------|---------------|-----------------------------------------------------------------------------------------------------------------|
| ContextId | IDMAObjectRef | The ID of the object for which the action was executed. Note: Currently, only DomInstance IDs can be specified. |
| ActionId  | string        | The ID of the action that triggered the script.                                                                 |

If the executed script added script output to the engine object, that output will be returned in a DomActionInfo InfoData via the TraceData. See the example below, which shows how data can be added to the script and how it can be retrieved in the other script/application.

Action script code snippet:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnDomAction)]
public void OnDomActionMethod(IEngine engine, ExecuteScriptDomActionContext context)
{
    var returnValue = DoSomething();
    // Add the return value as script output
    engine.AddScriptOutput("ReturnValue", returnValue);
}
```

Calling script code snippet:

```csharp
// Execute action
domHelper.DomInstances.ExecuteAction(domInstance.ID, "do_something_action");
// Check if the TraceData contains info
var traceData = domHelper.DomInstances.GetTraceDataLastCall();
var info = traceData.InfoData.OfType<DomActionInfo>().FirstOrDefault();
if (info != null && info.InfoType == DomActionInfo.Type.ScriptOutput)
{
    var returnValue = info.Data["ReturnValue"];
    engine.GenerateInformation($"DOM script returned '{returnValue}'.");
}
```

##### Executing an action

An action can be executed by calling the ExecuteAction method on the DomInstance CrudHelperComponent of the DomHelper. The following IDs must be passed along: the ID of the DomInstance for which the action will be executed and the ID of the action that has to be executed.

```csharp
domHelper.DomInstances.ExecuteAction(domInstance.ID, "some_action_id");
```

The execute call will return TraceData when the action failed or when the condition was not met. If a non-existing DomInstance was specified, this TraceData will contain a ManagerStoreError with reason ObjectDidNotExist. In case of another error, a DomActionError will be returned with one of the following reasons:

| Reason                          | Description                                                                                                                                 |
|---------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| Unknown                         | An unknown error has occurred. Check the logging for more information.                                                                      |
| UnexpectedExceptionOccurred | An unexpected exception has occurred when executing an action. ExceptionMessage will contain the message of the exception.              |
| ScriptReturnedErrors            | A script has returned errors. ErrorData will contain a list of all the errors that were returned.                                       |
| ActionDefinitionNotFound    | The action that had to be executed could not be found by means of the IDMAObjectRef context ID.                                             |
| ConditionNotMet                 | The condition that was specified was not met. InnerTraceData may contain additional TraceData explaining why the condition was not met. |

##### Conditions

When you define an action, you can specify the following types of conditions:

- StatusCondition
- ValidForStatusTransitionCondition

A StatusCondition is a type of condition that is met when a DomInstance has one of the defined statuses. The list of required statuses can be specified via the constructor or by adding them to the Statuses list property. When this type of condition is not met, no extra TraceData will be returned.

```csharp
var condition = new StatusCondition(new List<string> { "first_status" });
```

A ValidForStatusTransitionCondition is a type of condition that is met when a DomInstance is valid for a given status transition. The required transition ID must be assigned to the TransitionId property. When this type of condition is not met, extra TraceData will be returned via the InnerTraceData property of the DomActionError. This TraceData should contain an error of type DomStatusTransitionError.

```csharp
var condition = new ValidForStatusTransitionCondition("first_to_second_transition");
```

##### Defining buttons

A DomBehaviorDefinition contains a list of IDomButtonDefinitions. These can be used to define buttons to be shown in the UI.

Currently, it is only possible to define buttons to be shown for a DomInstance by using a DomInstanceButtonDefinition. These buttons can be linked to one or more actions that will be executed when the buttons are clicked. A DomInstanceButtonDefinition also has a condition that determines whether a button is shown or not. When no condition is specified, a button will by default be shown. A DomInstanceButtonDefinition has the following properties:

| Property            | Type                      | Description                                                                                                                        |
|---------------------|---------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| Id                  | string                    | The ID of the button. This ID must be unique for the DomBehaviorDefinition in question and can only contain lower-case characters. |
| Layout              | DomButtonDefinitionLayout | Additional properties that define how the button will be displayed. See below.                                                     |
| VisibilityCondition | IDomInstanceCondition     | The condition that defines when the button will be shown.                                                                          |
| ActionDefinitionIds | List\<string>             | The IDs of the actions that should be executed.                                                                                    |

The DomButtonDefinitionLayout class has the following properties:

| Property | Type   | Description                                                                             |
|----------|--------|-----------------------------------------------------------------------------------------|
| Text     | string | The text that will be displayed on the button.                                          |
| Icon     | string | The (optional) icon that will be displayed on the button.                               |
| ToolTip  | string | The (optional) tooltip with more information about the button.                          |
| Order    | int    | The number assigned to the button that determines its place within a series of buttons. |

#### Virtual functions can now be included in element connectivity chains \[ID_30944\]

When creating a connectivity chain between parameters in an element, it is now possible to also select virtual functions to be included in that chain.

> [!NOTE]
> Virtual function alarms reside on the main element. When multiple virtual functions are defined in different element connectivity chains, the most severe RCA will be shown in the element RCA of the alarm.

#### Video thumbnails: Support for HLS streams \[ID_30953\]

Video thumbnails now also support HTTP Live Streaming (HLS). No plugins need to be installed.

Syntax:

```txt
#https://dma/videothumbnails/video.htm?type=HTML5-HLS&source=https://videoserver/stream.m3u8
```

> [!NOTE]
>
> - For more information on HLS, see <https://github.com/video-dev/hls.js/>
> - All HLS resources must be delivered with CORS headers that permit GET requests.
> - If you access a video thumbnail player that is using HTTPS, then the media must also be served over HTTPS.
> - When the video starts automatically, in order to comply with the browser's autoplay policy, it will be muted until the user turns on the sound.

#### Logging: SLCloudEndpointManager.txt renamed to SLUMSEndpointManager.txt \[ID_30974\]

The *SLCloudEndpointManager.txt* log file has been renamed to *SLUMSEndpointManager.txt*.

#### SLWatchdog will now by default send an email message when an anomaly was detected \[ID_30982\]

In the *MaintenanceSettings.xml* file of a newly installed DataMiner Agent, the Watchdog.Email@active setting will now by default be set to true. In other words, on a newly installed DataMiner Agent, the SLWatchdog process will now by default send an email to the configured destination(s) whenever it detects an anomaly.

```xml
<MaintenanceSettings>
  ...
  <WatchDog>
    <EMail active="true">
      <Destination></Destination>
      <CCDestination></CCDestination>
      <BCCDestination></BCCDestination>
    </EMail>
  </WatchDog>
  ...
</MaintenanceSettings>
```

#### Redundancy groups: Additional information in information events and Automation scripts \[ID_31358\]

When elements within a redundancy group are switched, from now on, additional information will be added both to the information events and to the Automation scripts that are executed.

##### Information events

The following information will be added to the information events.

- When a user changes the mode of a redundancy group, one of the following strings will now be added to the information event with parameter description “Edited”:

  - *RDG By Administrator: Set Mode to Automatic switching*
  - *RDG By Administrator: Set Mode to Manual switchback*
  - *RDG By Administrator: Set Mode to Manual switching*

- When a user sets an element to maintenance mode or takes an element out of maintenance mode, one of the following strings will now be added to the information event with parameter description “Edited”:

  - *RDG By Administrator: Switch to maintenance mode on \<element>*
  - *RDG By Administrator: Switch back from maintenance mode on element \<element>*

- When a switch is performed, an additional information event with parameter description “Redundancy switch” will now be generated to indicate the cause of the switch. In case of a manual switch, the information event will mention the user and in case of an automatic switch, it will mention the trigger ID.

- When DataMiner intervenes in the switching process, an information event with parameter description “Linked to” is generated. From now on, this event will also mention the element from which the switch occurred. It will now contain e.g. “RDG1, Unlinked from RDG3” instead of just “RDG1”.

##### Automation scripts

When an Automation script is triggered as part of an redundancy group action, that script will now have the following additional parameters. These can then be requested from within the Automation script using the GetScriptParam(\<id>) method on the engine object.

| ID | Name | Description |
|--|--|--|
| 65007 | \<Redundancy User> | In case of manual switching, this parameter will contain the name of the user who performed the switch. |
| 65008 | \<Redundancy Trigger> | In case of automatic switching, this parameter will contain the ID of the trigger that caused the switch to be performed. To look up the trigger, send a GetRedundancyGroup-ByID or GetRedundancyGroupByName message and check the Triggers array in the response. |
| 65009 | \<Redundancy Triggering Element> | In case of automatic switching, this parameter will contain the ID of the element that has caused the trigger to be fired. ID format: `<DataMinerID>/<ElementID>` |
| 65010 | \<Redundancy Primary> | This parameter will contain the ID of the primary element involved in the switch. ID format: `<DataMinerID>/<ElementID>` |
| 65011 | \<Redundancy Backup> | This parameter will contain the ID of the backup element involved in the switch. ID format: `<DataMinerID>/<ElementID>` |

#### Automatic Incident Tracking enabled by default on new systems \[ID_31617\]

From now on, Automatic Incident Tracking will be enabled by default

- on newly installed systems, and
- on systems that upgrade from a version on which Automatic Incident Tracking was not yet available (i.e. versions older than version 10.0.11).

> [!NOTE]
> In systems where Automatic Incident Tracking has explicitly been disabled, the feature will remain disabled.

#### Table filters of type 'fullfilter' now support filtering by means of regular expressions \[ID_31893\]

Inside a table filter of type “fullfilter”, it is now possible to filter by means of regular expressions.

In the following example, a regular expression will be applied to column 512:

```txt
fullfilter=(512 REGEX 'x\'y\\\\z' AND 510 == 1000)
```

> [!NOTE]
> In the example above, the regular expression contains a single quote and a backslash character that are part of the query. Since the “fullfilter” syntax requires these characters to be escaped, they have been escaped with an additional backslash character, and as a backslash character in a regular expression also needs to be escaped, four backslash characters were needed here.

### DMS Security

#### Importing domain users and user groups from an Azure Active Directory \[ID_28444\]

DataMiner is now able to import domain users and user groups from an Azure Active Directory.

In the *DataMiner.xml* file, an \<AzureAD> element should be present. See the following example.

```xml
<DataMiner>
  ...
  <AzureAD tenantId=""
           clientId=""
           clientSecret=""
           username=""
           password=""/>
  ...
</DataMiner>
```

> [!NOTE]
>
> - Currently, users imported from an Azure AD can only log in via SAML.
> - In an upcoming release, functionality will be added so that this can be configured directly in DataMiner Cube instead.

#### DataMiner Cube - System Center: New Planned Maintenance app permissions \[ID_28164\] \[ID_28541\]

In the *Users/Groups* section of System Center, it is now possible to configure the following new user permissions.

| User permission | Description                                                   |
|-----------------|---------------------------------------------------------------|
| UI available    | Permission to view the Planned Maintenance (PLM) app in Cube. |
| Add/Edit        | Permission to add or edit items in the PLM app.               |
| Delete          | Permission to delete items in the PLM app.                    |
| Configure       | Permission to configure the PLM app.                          |

#### Jobs and ReservationInstances: SecurityViewID property replaced by SecurityViewIDs property \[ID_28311\]

In Jobs and ReservationInstances, the single-value SecurityViewID property has now been replaced by a multiple-value SecurityViewIDs property.

If, for a particular job or ReservationInstance, this property contains view IDs, then the job or ReservationInstance will only be accessible to users who have access to at least one of the specified views.

For example, users with Read access to the view with ID 10 who display a list of jobs or ReservationInstances will only see the jobs or ReservationInstances of which the list of values in the SecurityViewIDs property includes “10” or no IDs at all.

> [!NOTE]
> The values in this property can be filter using a 'Contains' filter.
> Example: JobExposers.SecurityViewIDs.Contains(136)

#### DataMiner Cube - System Center: User permissions for 'Live Sharing' and 'Cloud Connected Agents' features have been reorganized \[ID_29004\]

In the *Users/Groups* section of *System Center*, the user permissions for the Live Sharing and Cloud Connected Agents features have been reorganized.

Under *General \> Live sharing*, you can now find the following user permissions:

- UI Available
- Share
- Edit
- Unshare

Under *System configuration \> Cloud gateway*, you can now find the following user permissions:

- Connect to cloud
- Disconnect from cloud
- Configure gateway service

> [!NOTE]
>
> - The user permissions listed under *Live sharing* are included in the *Power users* preset and higher.
> - The user permissions under *Cloud gateway* are included in the *Administrators (read-only access to Security)* preset and higher.

#### DataMiner Cube - System Center: New user permission \[ID_29097\]\[ID_29291\]

In the *Users/Groups* section of System Center, you can now configure the following new user permission:

- System Configuration \> DataMiner Object Manager (DOM) \> Module Settings

> [!NOTE]
> This user permission is included in the *Administrators (read-only access to Security)* preset and higher.

#### New functions user permissions \[ID_29659\] \[ID_30114\] \[ID_30122\]

Under *Modules* > *Functions*, you can now find the following user permissions:

- Read
- Add
- Edit
- Delete
- Configure
- Generate protocol

These permissions apply to the upload and delete function options in the Protocols and Templates app, as well as to the Functions app, which is currently only available in soft launch. For more information, see [Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/).

When upgrading to DataMiner version 10.1.7, these six permissions will automatically be granted to all user groups that have been granted the *Modules \> Resources \> Configure functions* permission.

#### Automatic LDAP notifications disabled by default \[ID_30290\]

Up to now, when Active Directory was used, DataMiner would automatically receive updates whenever changes occurred in the domain. From now on, this feature will be disabled by default. Instead, DataMiner will now poll the LDAP system on an hourly basis to check for changes.

> [!NOTE]
> If you want to enable the automatic LDAP notification feature, open the *DataMiner.xml* file and set the LDAP notifications attribute to true.

#### New user permission to send emails via DataMiner \[ID_30425\]

A new user permission *Email* > *Send via DataMiner System* is now available under the general user permissions in Users/Groups section of System Center. This user permission determines whether a user is allowed to send emails via the DataMiner System.

#### DataMiner Cube: Allow users to log in with a local user account even when external authentication via SAML is activated \[ID_30981\]\[ID_31043\]

By default, DataMiner Cube provides two methods to log in to a DataMiner Agent:

- Logging in “automatically” using Windows domain credentials.
- Entering an explicit username/password combination.

When external authentication is activated on a DataMiner Agent, bypassing the external authentication provider by entering an explicit username/password combination is only allowed for the Administrator user. However, from now on, when using external authentication via SAML, bypassing the external authentication by entering a username/password combination will be allowed for any local DataMiner user account.

#### DataMiner Cube - System Center: New & updated user permissions \[ID_30989\]\[ID_31208\]

In the *Users/Groups* section of System Center, new user permissions have been added and existing user permissions have been updated.

##### New user permissions

- Modules \> Process Automation \> Add/Edit
- Modules \> Process Automation \> Delete
- Modules \> Process Automation \> Read
- Modules \> Services \> Profiles \> Definitions \> Delete
- Modules \> Services \> Profiles \> Instances \> Delete

##### New and restructured user permissions

- Modules \> Profiles \> UI available
- Modules \> Profiles \> All except instances \> Add/Edit
- Modules \> Profiles \> All except instances \> Delete (NEW)
- Modules \> Profiles \> Instances \> Add/Edit
- Modules \> Profiles \> Instances \> Delete (NEW)
- Modules \> Profiles \> Configure (with tooltip providing more information) (NEW)

##### Updated user permissions

- Users are no longer allowed to add an instance to a newly created service profile definition that has not yet been saved.
- When a user who has been granted the Modules \> Services \> Profiles \> Definitions \> Delete permission deletes a service profile definition, all instances of that definition must also be deleted. A confirmation box will now appear to make the user aware of this. Also, a confirmation box will now appear when you try to delete definition instances.

#### Users authenticated by Azure AD using SAML can now automatically be created and assigned to groups \[ID_31057\] \[ID_31184\]

Users authenticated by Azure AD using SAML can now automatically be created and assigned to groups in DataMiner.

> [!NOTE]
> If you plan to implement this new feature, make sure DataMiner is not configured to import users and/or groups from Azure AD. This might cause users to be created twice.

To configure DataMiner to automatically (a) create users authenticated by Azure AD using SAML and (b) assign them to groups, proceed as follows:

1. Make sure DataMiner is registered as an Enterprise Application in Azure AD.
1. Go to *Users and groups* and add the necessary users and groups to the Enterprise Application.
1. Go to *Single sign-on*, select *SAML*, and edit the following settings in “Basic SAML Configuration”:

   - Set *Entity ID* to `https://[your application name]`.
   - Under *Reply URL*, specify the following URLs:

     ```txt
     https://[your application name]/root/ 
     https://[your application name]/ticketing 
     https://[your application name]/jobs 
     https://[your application name]/monitoring 
     https://[your application name]/dashboard 
     https://[your application name]/root 
     https://[your application name]/login 
     https://[your application name]
     ```

   - Set *Sign on URL* to `https://[your application name]`.

1. Go to *User Attributes & Claims* and add a group claim.

   > [!NOTE]
   > If you add a group claim, the account name of the group will only be sent via SAML when the groups are synchronized. Otherwise, the ID of the group will be sent instead.

1. In DataMiner Cube, add the necessary groups.

1. In the DataMiner.xml, configure the \<ExternalAuthentication> element as shown in the following example.

   ```xml
   <DataMiner ...>
     ...
     <ExternalAuthentication type="SAML" ipMetadata="[Path/URL of the identity provider’s metadata file]" spMetadata="[Path/URL of the service provider’s metadata file]" timeout="300">
       <AutomaticUserCreation enabled="true">
         <EmailClaim>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress</EmailClaim>
         <Givenname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname</Givenname>
         <Surname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname</Surname>
         <Groups claims=“true”>[group claim name]</Groups>
       </AutomaticUserCreation>
     </ExternalAuthentication>
     ...
   </DataMiner>
   ```

   > [!NOTE]
   >
   > - In Azure AD, the ipMetadata URL can be found under *Single sign-on \> SAML Signing Certificate – App Federation Metadata*.
   > - If, in the *Groups* element, you set the *claims* attribute to “false”, no claims will be used to add users to groups. In that case, the name of the group as specified in Cube will be used instead. A user can only be added to a single group this way.
   > - If, in the *Groups* element, you set the *claims* attribute to “false”, the user information that is created will not be updated.

1. Save the DataMiner.xml file.

1. Create an spMetadata file as described in the DataMiner Help section “Creating a DataMiner metadata file”.

   > [!NOTE]
   > In Azure AD, the EntityID can be found under *Single sign-on*. It is not the application ID.

1. Restart the DataMiner Agent.

#### Azure AD application query support \[ID_31059\]

DataMiner now supports Azure AD application querying.

From now on, a DataMiner Agent will no longer need a user name and password to connect to Azure AD. An authentication secret will suffice.

For this feature to work, the following permissions must be set in Azure AD:

- Application permission for User.Read.All and GroupMember.Read.All
- Delegated permission for User.Read

#### Web apps: Using custom HTTP headers will now be allowed \[ID_31090\]

From now on, the DataMiner web apps will allow the use of custom HTTP headers. Up to now, custom HTTP headers would by default be deleted.

As a result, it will now be possible to configure custom HTTP headers in IIS Manager to allow web applications to be secured with policies like HSTS, XSS, CSP, CORS, etc.

> [!NOTE]
> DataMiner web applications might still overwrite certain HTTP headers.

### DMS Protocols

#### Extension methods moved from QActionHelperBaseClasses to SLManagedScripting \[ID_27995\] \[ID_28675\]

The following extension methods have now been moved from the QActionHelperBaseClasses library to the SLManagedScripting library and are now instance methods of the SLProtocol interface.

##### static class NotifyProtocol

- AddRow(this SLProtocol protocol, int tableId, string row)
- AddRow(this SLProtocol protocol, int tableId, object\[\] row)
- AddRow(this SLProtocol protocol, int tableId, object\[\] row, bool\[\] keyMask)
- AddRowReturnKey(this SLProtocol protocol, int tableId)
- AddRowReturnKey(this SLProtocol protocol, int tableId, object\[\] row)
- DeleteRow(this SLProtocol protocol, int tableId, string rowKey)
- DeleteRow(this SLProtocol protocol, int tableId, int row)
- DeleteRow(this SLProtocol protocol, int tableId, string\[\] rows)
- Exists(this SLProtocol protocol, int tableId, string key)
- GetKeyPosition(this SLProtocol protocol, int tableId, string key)
- RowCount(this SLProtocol protocol, int tableId)
- GetKeys(SLProtocol^ protocol, int tableId, KeyType type = KeyType.Index)
- ClearAllKeys(this SLProtocol protocol, int tableId)
- GetKeysForIndex(this SLProtocol protocol, int columnPid, string value)
- FillArray(this SLProtocol protocol, int tableId, object\[\] columns, DateTime? timeInfo = null)
- FillArray(this SLProtocol protocol, int tableId, List\<object\[\]\> columns, DateTime? timeInfo = null)
- FillArrayNoDelete(this SLProtocol protocol, int tableId, object\[\] columns, DateTime? timeInfo = null)
- FillArrayNoDelete(this SLProtocol protocol, int tableId, List\<object\[\]\> columns, DateTime? timeInfo = null)
- FillArray(this SLProtocol protocol, int tableId, List\<object\[\]\> rows, SaveOption option, DateTime? timeInfo = null)
- FillArrayWithColumn(this SLProtocol protocol, int tableId, int columnPid, object\[\] keys, object\[\] values, DateTime? timeInfo = null)
- SetParameterBinary(this SLProtocol protocol, int pid, byte\[\] data)

##### static class ProtocolExtenders

- void Log(this SLProtocol protocol, string message, LogType logType = LogType.Allways, LogLevel logLevel = LogLevel.DevelopmentLogging)

> [!NOTE]
>
> - All overloads of the above-mentioned methods, which take in a QActionTableRow object instead of an object\[\], have been deleted.
> - The static methods could not be deleted. They have been marked obsolete instead.
> - The following types have moved from the QActionHelperBaseClasses DLL file to the SLManagedScripting DLL file:
>   - class NotifyProtocol
>   - enum LogType
>   - enum LogLevel

#### Enhanced (direct) view column option 'view' \[ID_28448\]

The following (direct) view column option has been enhanced.

```txt
view=linkedPid:elementkeycolumnpid:remotedatatablepid:remotedatacolumnidx
```

This option can be configured in three different ways. See the table below. In the examples, table 11000 is a (direct) view on table 1000.

| Type of filtering | Example | Description |
|--|--|--|
| Local filtering | view=:1004:1000:1 | The elementkeycolumnpid refers to another column of the same table. Each row will be requested from the element referred to by the DMAID/EID found in parameter 1004. |
| Foreign key filtering | view=1003:1105:1000:2 | The elementkeycolumnpid refers to a column of the table linked by the foreign key found in parameter 1003. Each row will be requested from the element referred to by the DMAID/EID found in parameter 1105, which is linked via the foreign key in parameter 1003. |
| No filtering | view=:1401:1000:1 | The elementkeycolumnpid refers to a column of another table, which is not linked to the local table (no linkedPid is provided). Each row will be requested from the elements referred to by the DMAID/EID items found in column 1401. Note: If the remote elements contain duplicate keys, then this can cause data to be overwritten. |

#### New 'FlushPerDatagram' option for smart-serial UDP connections \[ID_28999\]

When configuring the port settings of a smart-serial UDP connection, it is now possible to specify a *FlushPerDatagram* option.

When this option is set to true, any datagram received on the connection will be forwarded to SLProtocol, which will then store it in the response parameter.

Example:

```xml
...
<PortSettings>
    <FlushPerDatagram>true</FlushPerDatagram>
</PortSettings>
...
```

#### InterfaceInfo now contains an IsInternal flag to mark whether an interface is external or internal \[ID_29314\]

The InterfaceInfo class has been extended with an IsInternal flag that allows you to specify whether an interface is external or internal.

In order to get the information in the InterfaceInfoEventMessage, the following flag needs to be set in the client that is subscribing on the event:

```csharp
ClientCompatibilityFlags.SupportsInternalInterfaces
```

Also, the Interface class in SLManagedAutomation and the ConnectivityInterface class in SLManagedScripting have been extended with the IsInternal flag. The following public methods have been provided.

- SLManagedScripting

    ```csharp
    Dictionary<int, ConnectivityInterface> GetInternalConnectivityInterfaces(int dmaId, int elementId);
    Dictionary<int, ConnectivityInterface> GetExternalConnectivityInterfaces(int dmaId, int elementId);
    ```

- SLManagedAutomation

    ```csharp
    Interface[] GetInternalInterfaces();
    Interface[] GetExternalInterfaces();
    ```

#### DataMiner Connectivity Framework: DCF interfaces can now be marked internal \[ID_29326\] \[ID_29438\]

In an element protocol, it is now possible to make a distinction between

- internal DCF interfaces (i.e. virtual interfaces used within the protocol), and
- external DCF interfaces (i.e. physical interfaces that will appear in interface lists in the UI).

By default, all DCF interfaces are considered external. Interfaces that should be considered internal, have to be explicitly marked as internal. See the following example.

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
  ...
  <ParameterGroups>
    <Group id="1" name="500_in" type="in" dynamicId="500" dynamicIndex="*"       isInternal="true"/>
    <Group id="2" name="1000_out" type="out" dynamicId="1000" dynamicIndex="*"/>
    <Group id="3" name="1500_inout" type="inout" dynamicId="1500" dynamicIndex="*"/>
    <Group id="4" name="2000_inout" type="inout" dynamicId="2000" dynamicIndex="*"/>
    <Group id="5" name="fixed" type="inout" isInternal="true"/>
  </ParameterGroups>
  ...
```

#### SNMP polling: Retrieving polling delta time per row \[ID_29445\]

The notify protocol command NT_GET_BITRATE_DELTA, which can be launched from within a QAction, has been expanded to be able to retrieve the delta times per row when polling an SNMP table. However, this will only work for the multipleGetNext and multipleGetBulk polling schemes since only these polling schemes retrieve entire rows per request.

It is advised to enable this feature at startup using the notify protocol command NT_SET_BITRATE_DELTA_INDEX_TRACKING with either a single parameter ID or multiple parameter IDs. This information will not be saved and will only be kept as long as the element is running. See the following examples. The first call will enable the tracking for parameters 100 and 200. The second call will disable the tracking for parameter 100.

- `protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, new int[] {100, 200}, true);`
- `protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, 100, false);`

Once tracking has been enabled, the information can be retrieved by using the notify protocol command NT_GET_BITRATE_DELTA with a string as second argument. In the following example, the command will return the delta value for the specified key (“1”) of the specified parameter (100). If you set the second argument to an empty string (“”), then the command will return all currently tracked keys for the parameter in question.

`object delta = protocol.NotifyProtocol(269 /*NT_GET_BITRATE_DELTA*/, 100, "1");`

The information will be returned in the following format. If only a single key is requested, the initial array will have a length of 1:

`object[] { object[] {string key1, int delta1}, object[] {string key2, int delta2} }`

> [!NOTE]
>
> - If the requested key could not be found, or if no polling happened since the tracking was enabled, an empty array will be returned.
> - If there were no 2 poll cycles, or if the requested key was only present in 1 poll cycle, then the delta value will be returned as -1.

#### Aggregation: Using regular expressions in the filter \[ID_30199\]

It is now possible to a regular expression in the filtering options of an aggregate action.

##### Syntax 1: Equation with a regular expression defined in a regex attribute

When you use this syntax, add “equation:regex,” to the *options* attribute and specify the regular expression in a separate *regex* attribute.

Example:

```xml
<Action id="1">
  <Name>Regex aggregate with static equation</Name>
  <On id="304">parameter</On>
  <Type options="groupby:2;type:count;equation:regex,;return:3002"      regex="^[a-zA-Z]{2}$">aggregate</Type>
</Action>
```

##### Syntax 2: Equation with a regular expression defined in a parameter

When you use this syntax, add “equation:regex,” to the *options* attribute, followed by the ID of the parameter containing the regular expression.

Example:

```xml
<Action id="2">
  <Name>Regex aggregate with equation in parameter</Name>
  <On id="304">parameter</On>
  <Type options="groupby:2;type:count;equation:regex,3120;return:3102">aggregate</Type>
</Action>
```

##### Syntax 3: Equation value with a regular expression defined in a regex attribute

When you use this syntax, add “equationvalue:” to the *options* attribute, followed by four comma-separated arguments, and specify the regular expression in a separate *regex* attribute.

| Argument | Description                                                                                                |
|----------|------------------------------------------------------------------------------------------------------------|
| a        | Type of equation: “regex”                                                                                  |
| b        | Empty when regular expression is specified in a separate *regex* attribute. |
| c        | The ID of the column parameter to which the equation has to be applied.                                    |
| d        | The row index. If this argument is not specified, the matching will be done on a row by row basis.         |

Example:

```xml
<Action id="3">
  <Name>Regex aggregate with static equation value</Name>
  <On id="306">parameter</On>
  <Type options="groupby:2;type:avg;equationvalue:regex,,304,;return:3202"      regex="^[a-zA-Z]{2}$">aggregate</Type>
</Action>
```

##### Syntax 4: Equation value with a regular expression defined in a parameter

When you use this syntax, add “equationvalue:” to the *options* attribute, followed by four comma-separated arguments.

| Argument | Description                                                                                        |
|----------|----------------------------------------------------------------------------------------------------|
| a        | Type of equation: “regex”                                                                          |
| b        | The ID of the parameter containing the regular expression.                                         |
| c        | The ID of the column parameter to which the equation has to be applied.                            |
| d        | The row index. If this argument is not specified, the matching will be done on a row by row basis. |

Example:

```xml
<Action id="4">
  <Name>Regex aggregate with equation value in parameter</Name>
  <On id="306">parameter</On>
  <Type options="groupby:2;type:avg;equationvalue:regex,3120,304,;return:3302">aggregate</Type>
</Action>
```

> [!NOTE]
> When you opt to store a regular expression in a parameter, this parameter should be a standalone, single-value parameter of type string.

#### View table columns with options like 'view=:x:y:z' or 'view=a:b:c:z' can now be filtered by means of a 'VALUE=' filter \[ID_30237\] \[ID_30809\]

View tables containing a column with view options like “view=:x:y:z” or “view=a:b:c:z” now allow that column to be filtered by means of a “VALUE=” filter (e.g. VALUE=5 == abc).

> [!NOTE]
>
> - These filters will also work when filtering on a column of a view table that refers to a column of another view table.
> - When a directview table links to a view table with remote columns (i.e. view=:x:y:z), it is not yet possible to filter on those columns.
> - Combining filters with AND or OR is not supported.

#### New polling scheme polls SNMP tables by row \[ID_30780\]

A new polling scheme can now be used to poll SNMP tables.

This new scheme works similar to the GetNext/MultipleGet polling scheme, but polls by row instead of by column. In other words, similar to the GetNext/MultipleGet scheme, this new scheme will first poll the instances (if they have not been provided) and will then poll the data row by row.

To use this new polling scheme, add “multipleGet” to the SNMP options of the SNMP table to be polled.

- If you specify the “multipleGet” keyword without additional arguments, by default 10 rows will be polled in a single run. See the following example:

    ```xml
    <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete"     options="instance;multipleGet">1.3.6.1.4.1.34086.2.2.17.5.1</OID>
    </SNMP>
    ```

- If you want to have a specific number of rows polled in a single run, you can specify the “multipleGet” keyword followed by a colon (“:”) and the number of rows to be polled in a single run. In the following example, 5 rows will be polled in a single run:

    ```xml
    <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete"     options="instance;multipleGet:5">1.3.6.1.4.1.34086.2.2.17.5.1</OID>
    </SNMP>
    ```

> [!NOTE]
>
> - The multipleGet option cannot be used together with the multipleGetNext, multipleGetBulk and bulk options.
> - The multipleGet keyword can be used together with options like Subtable.
> - The notify protocol command NT_GET_BITRATE_DELTA, which can be launched from within a QAction, was expanded to be able to retrieve the delta times per row when polling an SNMP table. For more information, see [SNMP polling: Retrieving polling delta time per row \[ID_29445\]](#snmp-polling-retrieving-polling-delta-time-per-row-id_29445). This functionality will now also work in conjunction with the new multipleGet option.

### DMS Cube

#### Launching DataMiner Cube on a specific host using the cube:// protocol \[ID_28160\]

Using the cube:// protocol, it is now possible to launch a DataMiner Cube on a specific host. All existing URL arguments are supported.

Examples:

```txt
cube://mydma?element=MyElement
cube://10.11.12.13?view=12
```

#### Visual overview: Page-level execution of Automation scripts & new NodeDoubleClicked event \[ID_28185\]

On a Visio page, you can now configure to have Automation scripts executed automatically using a page-level data item of type *Execute*.

See the example below. You can use the keywords *Trigger* or *SetTrigger*, which can be set to either “ValueChanged” or “Event”.

Example:

```txt
Script:ScriptName|DummyName=ElementName or DmaID/ElementID;...| ParameterName1=[var:myVar];ParameterName2=#ValueFile;...| MemoryName=MemoryFileName;...|ToolTip|Options|Trigger=ValueChanged
```

##### Reserved prefixes can now mark each of the syntax components

In the syntax to be used in Automation script shapes as well as page-level Automation script triggers, each component can now be marked by a prefix. That way, you will no longer have to define empty components in case there are no dummies, no memory files, etc.

List of reserved prefixes:

- “Parameters:”
- “Dummies:”
- “MemoryFiles:”
- “Options:”
- “Tooltip:”

Example of syntax that can now be used in a shape data item of type *Execute*:

```txt
Script:<myScript>|Tooltip:<myTooltip>|Parameters:paramA=<myParam>|Options:NoConfirmation
```

> [!NOTE]
>
> - If you choose to use prefixes to mark syntax components, you must use them for every component.
> - When you use prefixes to mark syntax components, the components can be added in whatever order you choose.

##### New NodeDoubleClicked event

In an \[Event:\] placeholder, you can now add a new event named *NodeDoubleClicked*, followed by the argument *ID* or *Label*.

This event will trigger when you double-click a service definition node in an embedded Service Manager component. The event placeholder will then be replaced by the value of the specified argument.

Example:

```txt
[event:NodeDoubleClicked,ID]
```

##### Use case

Using the new features described above, it is possible to configure that when a user clicks a service definition node in an embedded Service Manager component, an Automation script is executed with e.g. the node ID as a parameter.

To configure this behavior, add a page-level data item of type *Execute*, and set its value to e.g. the following:

```txt
Script:<myScript>|Parameters:IDParam=[event:NodeDoubleClicked,ID]|Options:<possibleOptions>|Trigger=Event
```

#### Visual Overview: A shape linked to an alarm can now display the parameter key \[ID_28212\]

Using a data field of type “Info” set to the value “PARAMETER KEY”, a shape linked to an alarm can now be made to display the parameter key of the alarm in question.

#### System Center - Database: Option to offload database data to a file \[ID_28226\]

In the *Database* section of *System Center*, you can now also opt to offload database data to a file instead of a database.

#### Visual Overview: Group-level shape data fields of type 'ChildrenSort' now support placeholders \[ID_28289\]

In a group-level shape data field of type *ChildrenSort*, it is now possible to use placeholders.

This will allow you to dynamically specify how the different child item shapes should be sorted using placeholders such as “\[var:xxx\]” and “\[param:xxx\]”.

#### DataMiner Cube start window: Grouping, rearranging and filtering tiles \[ID_28346\]

In the DataMiner Cube start window, tiles representing DataMiner Systems or DataMiner Agents can now be grouped, rearranged and filtered.

- To create a new group, drag a tile out of its current group.
- To name or rename a group, click above the group and enter the (new) name.
- To move a tile to another position (or another group), drag it to its new position.
- To filter the tiles, hover over the looking glass and enter a search string in the search box. Alternatively, you can also start typing a search string without going to the search box.

    > [!NOTE]
    > When a search does not yield any results, you can click the plus icon or press ENTER to add the hostname or IP address you were looking for.

> [!NOTE]
>
> - The start window now has keyboard support. Use the arrow keys to move from one tile to the next, and press ENTER to launch.
> - The start window can now be resized. When you resize and/or reposition the window, its new size and position will be saved.

#### Visual Overview: Support for saving page and card variables \[ID_28434\]

It is now possible to have page variables and card variables saved across sessions.

To do so, place the following prefix before the variable name:

`__saved_`

The variable is then saved in a separate .dat file located in the following folder on the client machine: *C:\\Users\\{Username}\\AppData\\Roaming\\Skyline\\DataMiner*. When a variable is saved, if a user reopens a card with that variable, the variable will be set to the last saved value.

#### Visual Overview - ChildrenFilter: Using a regular expression to filter by name \[ID_28445\]

In a shape data field of type ChildrenFilter, it is now possible to filter by service name, view name or child element name.

To do so, in the ChildrenFilter data field of the child shape, add “Name=” following by a regular expression:

| Shape data field | Value           |
|------------------|-----------------|
| ChildrenFilter   | Name=\<myRegex> |

If you add this type of filter to a template shape, only objects of which the name matches the regular expression will use that particular template shape.

#### Service & Resource Management - Services app: Visualization and configuration of the node interfaces of service profile definitions and service profile instances \[ID_28508\]

In the *Profiles* tab of the *Services* app, it is now also possible to visualize and fully configure the node interfaces of service profile definitions and service profile instances.

Also, it is now possible to select a profile instance for every node interface of a service profile instance node.

#### Visual Overview: TableRowFilter option of ParameterControlOptions data item now supports FullFilter syntax \[ID_28531\]

When defining a table control in Visual Overview, it is now possible to use FullFilter syntax when configuring the *TableRowFilter* option in the *ParameterControlOptions* data item.

Example:

| Shape data field        | Value                                            |
|-------------------------|--------------------------------------------------|
| Element                 | MyTableElement                                   |
| ParameterControl        | 1000                                             |
| ParameterControlOptions | TableRowFilter:FULLFILTER=(PK == 0) OR (DK == 1) |

#### Service & Resource Management - Services app: Existing connections between node interfaces can now be edited on the service diagram using drag and drop \[ID_28597\]

In the service diagram, it is now possible to change the end points of connections between service definition node interfaces using drag and drop.

1. Select an existing connection. Its “from” and “to” interfaces will be highlighted.
2. Click the endpoint you want to change and drag it onto another endpoint while keeping the mouse button pressed.
3. Release the mouse button. The connection will now have changed. Its source point will be the same as before, but its endpoint will have changed.

#### DataMiner Cube start window: Opening a Cube instance without closing the start window \[ID_28608\]

It is now possible to connect to a DMA without closing the start window. To do so, in the start window, click a tile while holding the CTRL button.

This will allow you to open multiple instances of DataMiner Cube, each connected to a different DMA.

> [!NOTE]
> If you press ENTER while holding the CTRL button, a Cube instance will open and connect to the DMA specified in the currently selected tile.

#### DataMiner Cube: Option to return to the start window after logging out \[ID_28648\]

When you log out of DataMiner Cube, the login window appears. In that window, you can now click the *Back to start window* button to return to the DataMiner Cube start window.

#### Profiles app: Failsafe mechanism added to prevent situations where updates made by one user get overwritten by updates made by another user \[ID_28651\] \[ID_30057\]

The Profiles app now contains a failsafe mechanism to prevent possible situations where updates made by one user get overwritten by updates made simultaneously by another user.

#### DataMiner Cube - Alarm Console: Translations added for two new reasons mentioned in Value column of group alarms generated by Automatic incident tracking \[ID_28676\]

When automatic incident tracking is activated, active alarms that are related to the same incident will automatically be grouped into a new alarm, and the Value column of such an alarm will show the reason why the alarms underneath it were grouped.

Translations have now been added for two new reasons:

- View group
- Custom property group (which will be formatted as “\<propertyName> group: \<value>”)

#### Visual Overview: ListView component can now be used to list resources \[ID_28723\] \[ID_30998\]

The ListView component can now also be used to list resources. To do so, add a shape data field of type “Source” and set its value to “Resources”.

| Shape data field | Value |
|--|--|
| Component | ListView |
| Source | Resources |
| ComponentOptions | List of options, separated by pipe characters. For an overview of all possible component options, see [Component options](xref:Creating_a_list_view#component-options). |
| Columns | The list of columns that have to be displayed. Preferably, this should be configured by specifying the name of a saved column configuration, e.g. MyColumnConfig.<br> Saving a column configuration is possible via the right-click menu of the list header in DataMiner Cube. This right-click menu also allows you to load a column configuration.<br> If you do not specify this shape data field or leave it empty, all columns will be displayed. |
| Filter | Examples:<br> - Resource.Name\[string\]== 'Encoder'<br> - Resource.Name contains 'res'<br> - Resource.Name notContains 'res'<br> - Resource.ID\[Guid\] == fad6a6dd-ca3a-4b6f-9ca7-b68fd2071786<br> - Resource.MainDVEDmaID == 113<br> - Resource.PoolGUIDs contains<br>0fb47f51-ad81-47f2-9e69-3d9477bdc961<br> - Resource.MaxConcurrency != 1<br> - Resource.PropertiesDict.Location\[string\] == '3'<br> - Resource.Name\[string\] notContains 'RS' AND Resource.Name\[string\] notContains 'RT' AND Resource.Name\[string\] notContains 'ExposeFlow' <br>For more information on list view filters, see [List view filters](xref:Creating_a_list_view#list-view-filters). |

> [!NOTE]
> The IDOfSelection session variable contains a list of the IDs or GUIDs of the selected items, separated by pipe characters.

#### EPM: Chain grouping & automatic selection of single filter values \[ID_28751\]\[ID_28834\]\[ID_28846\]

In DataMiner Cube, EPM chains with the same value in the protocol’s Chain@groupingName element attribute (see example below) will now be grouped under that value in the EPM manager card (side panel and tabs) and in the chains selection box located in the topology sidebar.

Also, it is now possible to specify one filter value per chain that should be selected by default in filter boxes that contain only that specific value.

##### Example of a Protocol.Chains.Chain element with a group name and a default filter value

See the following example. The chain named “MyChain” will be part of the group named “MyChainGroup”, and if the filter named “MyField” only has one value, it will automatically be selected when you open the chain in the CPE manager or the topology tab in the sidebar.

```xml
<Protocol>
  <Chains>
    <Chain name="MyChain" defaultSelectionField="MyField" groupingName="MyChainGroup">
      ...
    </Chain>
  </Chains>
</Protocol>
```

> [!NOTE]
>
> - Each chain can only be part of a single chain group.
> - Chains that are not part of a group will be displayed as top-level tabs (on the same level as the group tabs).

#### Information event generated when a context menu of a table is used \[ID_28753\]

When, in DataMiner Cube, you open a context menu of a table and select an option from it, from now on, an information event will be generated similar to the one that is generated when you set a parameter.

This information event will contain the following data:

- **Parameter description**: The full display name of the context menu parameter. Format: *\<TableName>\_ContextMenu*

- **Parameter value**: A value in the following format:

  `Set by <user> to <command display value>`

  If there are dependency values, the value will have the following format:

  `Set by <user> to <command display value>: “<dependency 1>”; “<dependency 2>”`

#### Settings window: 'Surveyor' section renamed to 'Sidebar' & New 'Launch EPM card on filter selection' setting added \[ID_28788\]

In the user settings tab of the *Settings* window, the *Surveyor* section has been renamed to *Sidebar*.

Also, in that section, the existing Surveyor settings have now been grouped under the title “Surveyor”, and a new *Launch EPM card on filter selection* setting has been added under the title “Topology”. When you enable this new setting, an EPM card will automatically be launched after selecting an item in a topology tab filter.

#### DataMiner Cube will now use Chromium to handle SAML authentication \[ID_28922\]

In order to support a wider range of identity providers (e.g. Azure AD), DataMiner Cube will now use Chromium instead of Internet Explorer when handling SAML authentication.

> [!NOTE]
> DataMiner Cube clients will now automatically download the CefSharp package from the DataMiner Agent they connect to.

#### Alarm Console: New option to allow a history tab to show alarms associated with an enhanced service deleted in the selected time frame \[ID_28942\]

Up to now, when you created a history tab with a service filter, it was only possible to select one of the active enhanced services. Now, it is also possible to select one of the enhanced services that has been deleted in the selected time frame (e.g. “last hour”).

When, in the filter section, you selected “Service” and you want to be able to select an enhanced service that has been deleted in the selected time frame, then click the *Load deleted services* option, and select the deleted service from the list. That way, you will be able to create a history tab that lists the alarms associated with an enhanced service that has been deleted in the selected time frame.

#### Enhanced table export \[ID_28952\]

The table export mechanism has been reworked.

Also, in case of paged tables, it is now possible to indicate whether you want to export only the current page or the entire table.

#### New Surveyor setting: Collapse DVE elements beneath their main element \[ID_29021\]

The new Surveyor setting “Collapse DVE elements beneath their main element” now allows you to specify how DVE child elements are displayed.

By default, this setting is disabled, and DVE child elements are displayed in the same way as other elements.

- If you set this to “All DVEs”, DVE child elements will be displayed on the level below the parent elements in the tree structure, so that you can collapse and expand the list of child elements.
- If you set this to “Only function DVEs”, this will only happen for function DVEs.

#### Resources app: Enhanced UI \[ID_29086\]

The UI of the Resources app has had a complete overhaul. Look and feel are now in line with all other SRM-related apps.

#### Logging of important user actions \[ID_29139\]

From now on, the following important user actions will be logged in the SLClient.txt log file:

- Connect
- Disconnect
- Cube loaded
- Card opened
- Card closed
- Visio file loaded
- Alarm tab created in Alarm Console
- Trend graph opened

#### Services app: Duplicating service profile definitions and service profile instances \[ID_29262\]

In the *Profiles* tab of the *Services* app, it is now possible to duplicate service profile definitions or service profile instances.

#### Visual Overview: AlarmSettings tag of MaintenanceSettings.xml has new elementTimeoutMode attribute \[ID_29498\]

Next to the serviceTimeoutMode and viewTimeoutMode attributes, the AlarmSettings tag of the *MaintenanceSettings.xml* file now also has an elementTimeoutMode attribute.

Similar to the other two attributes, it can be set to one of the following values.

| Value | Description |
|--|--|
| displayTimeout | Shapes linked to elements will only show the timeout color. The current alarm color will not be shown. (Default setting.) |
| displayBoth | Shapes linked to elements will show both the current alarm color and the timeout color. The timeout color will be shown as a hatch pattern. |

#### Visual Overview: Prevent a child shape from inheriting the service context of its parent shape \[ID_29503\]

By default, an element shape that is a child of another element shape will inherit the service context of its parent when it does not have a service context of its own.

If you want to prevent this from happening, from now on, you can add the AllowInheritance option to the child shape and set its value to false.

#### Profiles app: New profile instance update errors \[ID_29546\]

When a ProfileInstance is updated while it is being used by one or more bookings, the following additional errors can now be returned.

When a ProfileInstance is updated without quarantine being forced (i.e. with forceQuarantine set to false):

- If no instances need to be quarantined, the update will be applied and the following warning will be returned:

  - A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the running reservations that were reconfigured because of the update.

- If instances need to be quarantined, the update will not proceed and the following errors will be returned:

  - An error with reason ReservationsMustMovedToQuarantine, listing the reservations that need to be quarantined as well as the usages.
  - An error with reason ReservationsMustBeReconfigured, listing the bookings that will be affected by the ProfileInstance update.

When a ProfileInstance is updated with quarantine being forced (i.e. with forceQuarantine set to true), the update will proceed and the following TraceData will be returned:

- A warning of type ReservationInstancesMovedToQuarantine, listing the reservations and the usages that were quarantined.
- A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the reservations that were reconfigured because of the update.

#### Profiles app: Profile parameters can now have settings configured \[ID_29580\]

It is now possible to configure a profile parameter to be hidden in scripts using the profile, with a new *Hide from scripts* checkbox for profile definitions and profile instances in the Profiles app.

#### EPM: Hiding chains and chain fields based on parameter values \[ID_29640\]\[ID_29656\]

DataMiner Cube now supports hiding specific chains (normal chains and search chains) and chain fields in an EPM topology based on parameter values, in the sidebar as well as in EPM Manager cards.

Below, you can find examples of how to configure conditional visibility in an element protocol.

##### Chain visibility

Example:

```xml
<Chain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</Chain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

##### Chain field visibility

Example:

```xml
<Chain>
  <Field>
    <Display>
      <Selection>
        <Visibility default=”false”>
          <Standalone pid=”18”>
            <Value>1</Value>
            <Value>2</Value>
          </Standalone>
        </Visibility>
      </Selection>
    </Display>
  </Field>
</Chain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

##### Search chain visibility

Example:

```xml
<SearchChain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</SearchChain>
```

> [!NOTE]
>
> - The default visibility defines the visibility when none of the conditions are met. Default: true
> - Multiple \<Standalone> elements are possible. Each one has to contain a parameter ID that refers to the trigger parameter and a set of values that toggle the visibility to the opposite setting of the one defined in the default attribute.

#### Visual Overview: New icon added to Icons stencils \[ID_29751\]

The following icon has been added to the Icons stencil:

- TX

#### Logging: New log file 'Resource Manager Storage' \[ID_29776\]

The Logging module now also allows you to access the SLResourceManagerStorage.txt log file.

#### New spectrum recording playback controls \[ID_29807\]\[ID_29926\] \[ID_30218\]

While a spectrum trace recording is playing, new controls are now available at the bottom of the display section:

- A slider control, which allows you to navigate to a specific point in the recording.
- Controls to go forward and backward in the recording, trace by trace.
- A pause/play toggle control.
- A fast forward button. The current playback speed is displayed next to this button. You can click the fast forward button again to increase the playback speed further.

While a recording is playing, these controls (with exception of the slider control) will fade away to show as much of the recording as possible. Moving the mouse pointer near the controls will display them again. The name, the start time and the end time of the recording are also displayed at the bottom of the display section, and fade away in the same way as the controls.

Because of these new controls, the *Manual* playback mode is now obsolete. You can now only select the *Keep repeating the recording* checkbox.

The following *SpectrumManagerHelper* methods have been implemented to support this:

- *SetSpectrumRecordingFrame (int frame)*: Sets the frame of the currently playing recording to the next available trace in the recording, starting from the given frame number.
- *SetSpectrumRecordingTime (TimeSpan time)*: Sets the currently playing recording to a specific point in time. The specified time span indicates the amount of time after the start of the recording where the playback should go.

#### Visual Overview: History mode for alarm states + culture option for datetime control \[ID_29822\]

When shapes in Visual Overview are linked to an element, parameter or service, it is now possible to show the alarm state for this linked object at a specific point in the past. To do so, you can use the new shape data *HistoryMode*, which can be added to a specific shape, or to the entire page.

The value of the shape data field should consist of a state indication and a timestamp, separated by a pipe character ("\|"). The *State* can be *On* or *Off*. *On* means history mode is active, *Off* means real-time alarm information should be shown instead. Both the state value and the timestamp value can be configured using placeholders.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\] |

> [!NOTE]
> This feature is currently not yet supported for shapes linked to views.

An additional change introduced by this release note is that you can now define the culture that should be used for a shape that has been turned into a datetime control (using the *SetVarOptions* shape data set to *Control=DateTime*). To do so, add *DateTimeCulture=* followed by *Current* or *Invariant*. The latter is the default value.

For example:

| Shape data field | Value                                     |
|------------------|-------------------------------------------|
| SetVarOptions    | Control=DateTime\|DateTimeCulture=Current |

#### EPM: Topology diagram will now display the topology cell name instead of the table name \[ID_29842\]

An EPM topology diagram will now display the topology cell name instead of the table name.

Also, table names can now be overridden in the information template. If names of column parameters contain the table name, it is advised to also override these names in order to avoid confusion.

#### Generating a report based on a dashboard: New 'Include CSV' option \[ID_29933\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app. When you click the *Configure* button, you will now notice a new “Include CSV” option. If you select this option, the email will not only include the report but also a zip file containing a CSV file for every Pivot table, GQI table and Line & area chart component in the dashboard.

#### Visual Overview: History mode for spectrum thumbnails \[ID_30130\]

It is now possible to have a spectrum thumbnail in Visual Overview show the trace from a specific moment in the past, based on the recorded trending for a parameter in a spectrum monitor.

The trended trace record from right before the specified time will be displayed. For this purpose, the trended traces are queried with the following steps until a trace record is found or the maximum search extent has been reached: 1 hour – 3 hours – 12 hours – 24 hours – 48 hours (maximum).

To configure this:

1. Configure the shape in the same way as for a regular spectrum thumbnail, but as the parameter ID, specify the ID of the spectrum monitor trace parameter (which is always in the range 50000 - 59999). You can find this ID in the file *SpectrumMonitors.xml* in the folder *C:\\Skyline DataMiner*.

2. Add the *HistoryMode* shape data field to the shape, and configure its value as follows:

    ```txt
    State=[On/Off]|TimeStamp=[datetime value]
    ```

    Refer to the table below for the value syntax:

    | Value | Explanation |
    |-------|-------------|
    | State | Can be "On" or "Off". On means history mode is active, Off means the real-time spectrum trace should be shown instead. You can use a placeholder to change this value dynamically. |
    | TimeStamp | The date and time for which the spectrum trace should be displayed. You can use a placeholder to change this value dynamically. |

For example:

| Shape data field | Value                                                 |
|------------------|-------------------------------------------------------|
| Element          | 113/333                                               |
| Parameter        | 50016\|11\|trace_2mps\|5\|DisplayLabels;DisplayTime\| |
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\]                    |

#### Visual Overview: New Collapse shape data field \[ID_30149\]

In Visual Overview, you can now hide a shape in a different way than with the *Hide* shape data field, using the new *Collapse* shape data field. This field is configured in the same way, as detailed under [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions) in the DataMiner Help. While on the face of it, the result of the *Collapse* action will be the same as for a *Hide* action, the shape is hidden in a different way, i.e. its visibility is collapsed.

This makes it a convenient alternative to the *ChildrenFilter* shape data, as it will keep all shapes in memory instead of removing and recreating them. This will allow better performance, though it will lead to slightly increased memory usage.

Using the *Collapse* action can also be convenient in a grid layout, as a collapsed shape will not take up room in a grid, unlike a shape hidden using *Hide*.This can allow you to use the "Auto" width or height more effectively.

#### Visual Overview: New icons added to Icons stencils \[ID_30198\]

The following icons have been added to the Icons stencil:

- TV streaming
- Microservices

#### Visual Overview: History mode for parameter values of element shapes \[ID_30333\]

It is now possible to make an element shape in Visual Overview show the parameter values for a specific point in the past. This time and date can optionally be selected using another Visual Overview component.

To retrieve the value, DataMiner will use the trend record stored for the selected time. To know whether real-time or average trending should be retrieved, the latest trending configuration will be taken into consideration. If both types of trending are available, by default real-time trending will be used.

To configure this history mode, add the shape data *HistoryMode* to the element shape or to the entire page. The value of the shape data field should consist of a state indication and a timestamp, separated by a pipe character ("\|"). The *State* can be *On* or *Off*. *On* means history mode is active, *Off* means real-time alarm information should be shown instead. Both the state value and the timestamp value can be configured using placeholders.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| HistoryMode      | State=On\|TimeStamp=\[var:myTime\] |

A number of options can also be added to the *HistoryMode* shape, again using a pipe character (“\|”) as separator:

| HistoryMode option | Description |
|--------------------|-------------|
| NoDataValue= | This option allows you to specify the text that should be displayed in case no trending is available. If this option is not specified, the default value “N/A” is displayed. For example: *State=On\|TimeStamp=\[var:myTime\]\|NoDataValue=\<No data available>* |
| TrendDataType | This option allows you to determine which kind of trend data should be used, if available: *Realtime* (default), *Average* or *RealtimeAndAverage*. |
| AverageTrendDataIndication | This option allows you to specify a prefix to the parameter value in case it represents an average value. By default, no prefix is shown. For example:  *State=On\|TimeStamp=\[var:myTime\]\|AverageTrendDataIndication=\[AVG\]* |

> [!NOTE]
>
> - You can override history mode on shape level. In case there are shapes within shapes, the lowest level will be checked first. However, the full shape data of this lowest level is used, so you must make sure that the shape data is fully configured even if you only want to change one option (e.g. NoDataValue).
> - At present, for history values no unit is displayed. In addition, only updating the element or parameter shape data will not update the history mode result.

If you are using a datetime control to set the date and time, use the *SetVarOptions* shape data and set the value to *Control= DateTime*. Optionally, you can also add *DateTimeCulture=* followed by *Current* or *Invariant*. The latter is the default value.

For example:

| Shape data field | Value                                     |
|------------------|-------------------------------------------|
| SetVar           | myTime                                    |
| SetVarOptions    | Control=DateTime\|DateTimeCulture=Current |

The following new placeholders are now also supported in an *Element* shape. These will only contain values in case history parameter values based on average trend data are displayed:

- \[average value\]
- \[minimum value\]
- \[maximum value\]

#### DataMiner Cube start window: Cleanup Cube Installation window \[ID_30351\]

When you click the cogwheel icon in the bottom-right corner of the DataMiner Cube start window, you can now select the *Cleanup* option to open the *Cleanup Cube Installation* window. That window will allow you to remove old and/or unused Cube versions as well as to clear the Visio cache and the protocol cache.

#### Data Display: Extended support for launching elements, services, redundancy groups and views by clicking buttons in Data Display table cells \[ID_30413\]

This feature offers a new way of adding links to elements, services, redundancy groups or views in a Data Display table.

When, in a protocol, you configure a cell button as shown below, the table cell will display an icon that includes the severity and, if necessary, the name. Clicking the link will open the linked object in a new card.

Example:

```xml
<Measurement>
  <Type>button</Type>
  <Discreets>
    <Discreet>
      <Display>{linkedItemName}</Display>
      <Value type="open">{pid:530}</Value>
    </Discreet>
  </Discreets>
</Measurement>
```

The discreet value can contain the name or the ID of the object, or a reference like “{pid:530}”. In the example above, the identifier is stored in the column with parameter ID 530, which can be the read parameter of the same column or a different column.

If you know the type of the object, you can add a type prefix (element, redundancygroup, view or service), followed by an equal sign and (a reference to) the identifier. If you refer to the name of the object, it is recommended to use “element=” as an element can have the same name as a view.

The \<Display> tag of the discreet can contain the same references as the \<Value> tag. One extra keyword is possible (and recommended): {linkedItemName}. This keyword will be replaced with the name of the object referred to in the \<Value> tag.

If you want to specify the page to be selected by default, add a suffix to the identifier in the \<Value> tag containing the root page name and the page name, separated by a colon. See the following examples:

- element=MyElementName:Data:Performance
- 212/13:Visual:MyVisioPage

#### New /Bootstrap command line argument for DataMiner Cube launcher \[ID_30573\]

A new */Bootstrap* command line argument is now supported for the DataMiner Cube launcher. This argument combines the */Install* and */Silent* arguments (see [Desktop application command-line arguments](xref:Desktop_app_command_line_arguments)), and also copies a number of files, such as *DataMinerCube.exe.config* en *CubeLauncherConfig.json*.

#### Aggregation rule conditions can now be specified in the form of a regular expression \[ID_30640\]

Aggregation rule conditions can now be specified in the form of a regular expression.

1. Set the condition type to “regular expression”.

2. Choose “by value” or “by reference”.

    - If you chose “by value” (i.e. the default setting), then enter a regular expression.
    - If you chose “by reference”, then select a single-value parameter of type “string” containing a regular expression.

#### Alarm templates: Conditions based on service impact \[ID_30691\]\[ID_30763\]

When editing an alarm template, it is now possible to configure alarm template conditions based on service impact.

#### Visual Overview: New ChildrenFilter 'ResourceMapping' \[ID_30751\]

When, within a service context, child shapes are automatically generated, it is now possible to use a ResourceMapping filter. This will allow you to only show shapes that have a certain role (mapped, unmapped, inheritance) within the booking.

In a child shape, add a data field of type *ChildrenFilter*, and set its value to “ResourceMapping=”, followed by one or more roles (separated by commas). If you specify multiple roles, all shapes of which the roles match one of the specified roles will be shown.

See the following example.

| Shape data field | Value                                       |
|------------------|---------------------------------------------|
| ChildrenFilter   | ResourceMapping=mapped,unmapped,inheritance |

> [!NOTE]
> Within a data field of type *ChildrenFilter*, you can specify multiple filters separated by pipe characters (“\|”). If you do so, only shapes matching all specified filters will be shown.

#### Visual Overview: Linking an element shape to a resource that is using that element \[ID_30752\]

It is now possible to link an element shape to a resource that is using that element.

To link an element shape to the last-known resource using the element in question, add a data field of type “Options” and set its value to “UseResource=True” (default value is false).

| Shape data field | Value            |
|------------------|------------------|
| Options          | UseResource=True |

> [!NOTE]
>
> - Within a service instance connectivity chain, the elements will automatically be linked to the resource.
> - Children of an element shape in which the “UseResource” option is specified will automatically inherit this setting unless overridden.

##### Placeholders that can retrieve resource-related data

When a resource is linked to an element shape, you can use the following placeholders to retrieve data from that resource.

| Placeholder | Data |
|--|--|
| \[Element Name\] | The name of the resource’s function element, if such an element could be found. If none could be found, this placeholder will contain the name of the element linked to the element shape. |
| \[Function Name\] | The name of the resource function. |
| \[Name\] | The name of the element linked to the element shape. |
| \[Resource ID\] | The ID of the resource (GUID). |
| \[Resource Name\] | The name of the resource. |

#### Visual Overview: New \[ServiceDefinition:\] placeholder & new \[Reservation:\] placeholder property 'ServiceDefinitionID' \[ID_30757\]

##### New \[ServiceDefinition:\] placeholder

The new \[ServiceDefinition:\] placeholder allows you to retrieve one of the following properties of a service definition:

| Property                 | Description                                                                                                                                                                                                  |
|--------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Name                     | The name of the service definition.                                                                                                                                                                          |
| Actions                  | The name of the scripts that are defined on the service definition. Names of multiple actions will be separated by colons (“:”). This will allows them to be inserted directly into e.g. a setvar shape. |
| Property=\<propertyName> | The value of any of the custom properties of the service definition.                                                                                                                                         |

Full syntax: \[ServiceDefinition:\<ServiceDefinitionID>,\<Property>\]

##### New \[Reservation:\] placeholder property 'ServiceDefinitionID'

The \[Reservation:\] placeholder now allows you to retrieve the service definition ID of a specific booking.

Full syntax: \[Reservation:\<Service ID or Booking ID>,ServiceDefinitionID\]

#### Logging now contains more information regarding system performance \[ID_30769\]

The Cube log files will now contain more information regarding system performance.

> [!NOTE]
> A new checkbox at the top of System Center’s Logging page will allow you to show or hide these System Performance Indicator (SPI) log entries.

#### Logging: New log file 'Sharing Manager' \[ID_30826\]

The Logging module now also allows you to access the Sharing Manager log file.

#### DataMiner Cube - Router Control: 'Direct take' mode \[ID_30865\]

When configuring a matrix in the Router Control module, you can now set it to either “preset mode” (i.e. the default mode) or “direct take mode”.

- In preset mode, you need to click the *Connect* button to create or delete a crosspoint between an input and an output.
- In direct take mode, you don’t need to click the *Connect* button to create or delete a crosspoint between an input and an output. When you select an input and an output, they will automatically be connected or disconnected.

> [!NOTE]
> When you use direct take mode in combination with the “Use output-first workflow” option
>
> - selecting an output will not cause crosspoints to be created or deleted, and
> - input selections will only be cleared when you select another output.

#### Sidebar: 'Advanced search' improvements \[ID_30885\]

Up to now, the advanced search pane was only added to the sidebar after you entered a search string in the search box in the middle of the Cube header bar and then clicked the “Advanced search for” option at the bottom of the suggestions list. From now on, you can directly open the advanced search pane by clicking the ellipsis button (“...”) in the sidebar and selecting the *Search* button.

In addition, there is now a search box at the top of the advanced search pane, so you can search from directly in the pane.

#### DataMiner Agent will no longer be selected by default when creating a new element on an DataMiner System with multiple agents \[ID_30889\]

When you created an element on a DataMiner System with multiple agents, up to now, the DMA to which you were connected would by default be selected in the DMA selection box. To prevent users from all creating new elements on the same agent, from now on, whenever there are multiple agents in the DataMiner System, no agent will be selected by default.

> [!NOTE]
> When you duplicate an element, the DMA selection box will by default be set to the same DMA as the original element.

#### Visual Overview: Edge/WebView2 browser engine \[ID_30940\]

In DataMiner Cube, up to now, embedded webpages could be displayed using either Chromium or Microsoft Internet Explorer. From now on, it is also possible to use Microsoft Edge (WebView2).

Using this new Edge browser engine offers a number of advantages:

- The web content is rendered directly to the graphics card.
- The browser engine automatically receives updates via Windows Update, independent of DataMiner or Cube version.
- Proprietary codecs such as H.264 and AAC are supported.

To set this browser engine as the system default for all users, go to *System Center \> System Settings \> Plugins*, and set the *Web browser Engine* option to “Edge”.

If you want a shape to display a webpage using the Edge web browser regardless of Cube’s default browser engine setting, add a shape data field of type *Options* to the shape containing the web browser control, and set its value to “UseEdge”.

> [!NOTE]
>
> - Currently, the Edge web browser engine cannot be used in DataMiner web apps like Ticketing, Dashboards, etc.
> - The WebView2 Runtime will automatically be installed when using Office 365 Apps. It will also come pre-installed with Windows 11. It will not be included in DataMiner upgrade packages.

#### Sidebar: Pinning and unpinning sidebar items \[ID_30963\] \[ID_31207\]

It is now possible to pin and unpin items in the sidebar.

- To pin an item, click the Add button (“+.”), and then click the item you want to pin to the sidebar.
- To unpin an item, right-click the item in the sidebar, and click *Unpin*.

> [!NOTE]
> One of the items you can pin after clicking the Add button (“+”) is the “Overview” button. Clicking this button after it has been pinned will open a card showing the root view (Below this view \> All).

#### Visual Overview: Setting the background color of a static shape using a shape data field of type 'BackgroundColor' \[ID_30964\]

Using a shape data field of type *BackgroundColor* it is now possible to set the background color of a static shape, i.e. a shape that is not linked to an element, a service or a view.

| Shape data field | Value    |
|------------------|----------|
| BackgroundColor  | \<color> |

The \<color> value in the example above can be specified as follows:

- An HTML color code (e.g. #FF102030)
- An RGB color code (e.g. 40,50,60)
- A standard color name (e.g. magenta)
- A color placeholder referring to one of the configured DataMiner alarm colors (e.g. \[color:severity=minor\])
- A placeholder referring to a variable containing a color value (e.g. \[PageVar:MyColorSessionVar\])

> [!NOTE]
>
> - If you specified a valid color or if the placeholder resolves correctly, the color you specified will overrule the shape’s default background color. Note that if blinking was enabled, it will be disabled.
> - If you specify a custom BackgroundColor, shape transparency will work as before.

#### System Center - Analytics config: New setting 'Maximum group size' \[ID_30993\] \[ID_31093\]

In the *System settings \> Analytics config* section of *System Center*, a new setting has been added for automatic incident tracking. The *Maximum group size* setting will now allow you to limit the size of the alarm groups.

When an alarm group reaches the maximum size specified in this setting, a new group will be created with all remaining alarms that belong to the same incident.

Default value: 1000

> [!NOTE]
> In the *System settings \> Analytics config* section of *System Center*, the setting names have been adjusted to improve consistency. “Minimal” has been replaced with “Minimum” and “Maximal” has been replaced with “Maximum”.

#### Visual Overview: New \[Element:\] placeholder \[ID_31158\]

In Visual Overview, you can now use the new “\[Element:\<input>,\<output>\]” placeholder to convert an element name to an element ID and vice versa.

\<input> can be set to

- an element name, or
- an element ID (dmaID/elementID).

\<output> can be set to

- “Name”, or
- “ID”.

Examples:

- \[Element:MyElement,ID\] will be resolved to the ID of the element with the name “MyElement”.
- \[Element:2/125,Name\] will be resolved to the name of the element with ID 2/125.

#### DataMiner Cube - Visual Overview: Service connectivity chains now support 'lite contributing' resources \[ID_31196\]

In Visual Overview, it is possible to have the connectivity chain of a service instance (from the Service & Resource Management module) drawn automatically in Visual Overview. Now, this feature supports so-called “lite” contributing resources, i.e. resources for which no enhanced elements have to be created.

#### Automatic Incident Tracking: New setting 'Maximum group events rate' \[ID_31203\]

In *System Center*, a new setting has been added to the *Analytics config* section: “Maximum group events rate”. With this setting, you can limit the maximal number of alarm group events that will be generated and thus avoid any possible performance issues during alarm floods.

When more events are generated per second than the value specified in this setting, the generation of events will be slowed down, and as soon as the number of generated events drops below the threshold again, the generation of events will again proceed at the fastest speed possible.

Each time alarm grouping enters flood mode, a notice alarm will be generated to notify users that they may experience a delay when checking the alarm group information shown by Cube. If this notice alarm is not cleared manually, it will be cleared automatically when the alarm flood has passed.

Default value of the “Maximum group events rate” setting: 100

#### Visual Overview: New icons added to Icons stencils \[ID_31271\]

The following icons have been added to the Icons stencil:

- Action
- Cloudy
- Cloud Formation
- Response
- Request
- Media Connect
- Groups
- Media Live
- Media Package
- Mist
- Moon
- Pairs
- Parameter
- Rain And Snow
- Qactions
- Rain
- Rain Percentage
- Snow
- Semi Cloudy
- Storm
- Snowflake
- Sunset
- Sun
- Umbrella
- Thunder
- Wind Direction
- Weather Forecast
- Wind

#### Services app: Enhanced service definition security \[ID_31306\] \[ID_31428\]

In the Services app, a number of security enhancements have been made with regard to service definitions.

- In the *Users/Groups* section of System Center, the *Add*, *Edit* and *Delete* permissions under *Modules \> Services \> Definitions* have now been replaced by one single *Edit actions* permission. If a user had at least one of those previous *Add*, *Edit* or *Delete* permissions, they will now automatically be granted the new permission.

- In some cases, the *Diagram* and *Properties* permission under *Modules \> Services \> Definitions* would be applied incorrectly.

- Users who do not have read permission on functions will now be able to correctly save function nodes when configuring service definitions.

#### Legacy Reports, Dashboards and Annotations modules will by default be hidden in new installations \[ID_31329\]

In new installations, from now on, the legacy Reports, Dashboards and Annotations modules will be hidden by default.

If you do not want these modules to be hidden, you can set the LegacyReportsAndDashboards and/or LegacyAnnotations soft-launch options to true.

#### Alarm Console - Context menu: Links to elements, services and views in 'Open' submenu now have an element, service or view icon in front of them \[ID_31499\]

When you right-click an alarm in the Alarm Console, the *Open* submenu contains a link to the alarm card as well as links to all elements, services and views affected by the alarm. From now on, the links to the elements, services and views will each have an element, service or view icon in front of them.

#### Filter will now be taken into account when exporting a table \[ID_31586\]

Up to now, when you filtered a table and then exported it, the filter would not be taken into account and the entire table would be exported. From now on, the filtered table will be exported instead.

#### DataMiner Cube - Views: 'Below this view' list has a new column 'Communication protocols' \[ID_31590\]

A “Communication protocols” column has been added to the list on the *Below this view* page of a view card. This column will show the communication protocols used by an element.

#### System Center - Users/Groups: New user permission 'Monitoring web app' \[ID_31706\] \[ID_31961\]

In the *General* section of the user permissions list, a new “Monitoring web app” permission has now been added next to the existing “DataMiner web apps” permission. This permission can be used to control access to the Monitoring web app.

This user permission is enabled by default.

#### DataMiner Cube desktop app: Support for system-wide installation via a shared MSI installer \[ID_31874\] \[ID_32154\]

The DataMiner Cube desktop app, which allows side-by-side installation of different Cube versions, now supports system-wide installation via a shared MSI installer.

> [!NOTE]
> When you install the DataMiner Cube desktop app by means of a shared MSI installer, all automatic updates will now be blocked. To update the DataMiner Cube desktop app, the administrator will need to install a new MSI file.
>
> Also, Cube will no longer attempt to download and install the CefSharp package automatically. This will now have to be installed manually using the separate CefSharp MSI installation package.

#### System Center - Users/Groups: Renamed user permissions \[ID_32141\]

For reasons of consistency, the following user permissions have been renamed:

| Old name                                     | New name                                |
|----------------------------------------------|-----------------------------------------|
| Best practices analyzer \> Read              | Best practices analyzer \> UI available |
| Alarm templates \> Add alarm templates       | Alarm templates \> Add                  |
| Alarm templates \> Edit alarm templates      | Alarm templates \> Edit                 |
| Alarm templates \> Delete alarm templates    | Alarm templates \> Delete               |
| Trend templates \> Configure trend templates | Trend templates \> Configure            |

#### Visual Overview: \[ServiceDefinition:...\] placeholder now allows you to look up a node ID by passing a node label \[ID_32222\]

Inside a \[ServiceDefinition:...\] placeholder, it is now possible to look up a node ID by passing a node label. See the following example.

```txt
[ServiceDefinition:aaaa-bbb-ccc-ddd,NodeID|NodeLabel=Primary Receiver]
```

This will, for instance, allow you to find a resource by passing a label of a service definition node. See the following example.

```txt
[Reservation:[this service],ResourceID|NodeID=[ServiceDefinition:aaaa-bbb-ccc-ddd,NodeID|NodeLabel=Primary Receiver]]
```

#### Visual Overview: URI scheme of the DataMiner Agent in question will now automatically be used when resolving the \<DMAIP> placeholder \[ID_32249\] \[ID_32349\]

The \<DMAIP> placeholder can only be used inside another placeholder, or in a URL for a shape data field of type Link. It is replaced with the first configured value from the following list that can be found for the DMA you are connecting to: the certificate address, the hostname or the primary IP address.

When the \<DMAIP> placeholder is resolved, from now on, the URI scheme of the DataMiner Agent in question (i.e. HTTP or HTTPS) will automatically be applied.

> [!NOTE]
> When a \<DMAIP> placeholder does not represent the URI host (e.g. when it is used as a query argument), the URI scheme of the DataMiner Agent (i.e. HTTP or HTTPS) will not automatically be applied.

### DMS Reports & Dashboards

#### Dashboards app: New 'view parameters' representing aggregation rules \[ID_28955\]

For the line chart, state, and ring visualizations, you can now use view parameters as a data source. These represent active aggregation rules on a specific view.

To select this new data source, in the drop-down box for the “parameter” data source, select “View”. The different available view parameters, corresponding with the aggregation rules configured in your system, will then be displayed.

You can combine these view parameters with other types of parameters in the same component. However, you can only group them together with other parameters using the "Group by" option "All together". If you group by element, parameter or index, the view parameters will be placed in a separate group. For view parameters, the view name is displayed instead of an element name, and the aggregation rule name is displayed instead of a regular parameter name.

#### Dashboards app - GQI: New 'DCF connections' data source \[ID_25827\] \[ID_26491\] \[ID_26744\] \[ID_29505\] \[ID_29703\]

In the Generic Query Interface, a new “DCF connections” data source is now available. It will return all DCF connections in the DMS.

> [!NOTE]
>
> - The “Is Internal” column indicates whether a connection has been marked internal (i.e. virtual) or external (i.e. physical).
> - External connections are configured both on the source element and the destination element. Hence, each external connection will be listed twice.
> - Connections of which both the source element and the destination element are stopped will not be listed.
> - Connections of which only the destination element is stopped will be listed once.

#### Dashboards app: Alarm table component \[ID_27790\] \[ID_28012\] \[ID_28142\] \[ID_28519\] \[ID_28718\] \[ID_28887\] \[ID_29131\] \[ID_29456\]

A new alarm table component is now available in the Dashboards app. It can be used to display a list of active alarms, masked alarms, history alarms, alarms in a sliding window, or information events.

Multiple component settings are available:

- Selection of type of alarm list.
- Filter configuration, including index filters using wildcards, and saved alarm filters.
- Default sorting column, default sorting order and number of alarms to load.
- Displayed columns and their order.
- Grouping by a specific column.
- “Expand on hover” layout option.

You can also add different data filters to the component, such as element or view data filters, or parameter feed or time range feed filters. If a parameter index data filter is used, a setting allows you to determine whether the index should match the filter or contain the filter.

#### Dashboards app: Trigger feed \[ID_28136\]

You can now add a trigger feed to a dashboard. This is a feed that allows you to trigger other components either manually or automatically.

Currently, the trigger feed can only be linked to components that can visualize a database query. In that case, when a trigger feed is triggered, the data displayed in the other component will be refreshed.

##### Settings

When, in the *Settings* tab, you enable the *Trigger timer* setting, a countdown bar will be displayed, and triggering will occur automatically when the counter reaches 0. The *Time* setting allows you to specify a counter interval (default: 60 seconds).

##### Layout

In the *Layout* tab, you find three additional sections:

- In the *Trigger label* section, you can specify a label and select an icon that will both be displayed on the trigger button.

- In the *Time label* section, select the *Show when the last trigger happened* option if you want the time of the last triggering displayed. When this option is selected, in the *Time description format* box, you can enter the message to be displayed. It can contain the following placeholders:

    | Placeholder | Description                                                                                                       |
    |---------------|-----------------------------------------------------------------------------------------------------------------|
    | {duration}    | An estimated indication of the time past since the last triggering. Example: “2 minutes ago”.                   |
    | {time}        | The exact textual representation of the time when the last triggering occurred. Example: “Nov 20, 2020, 12:33”. |

- In the *Layout* section, you can specify how you want the trigger label and time label to be aligned: left, center or right.

#### Dashboards app: Right-hand edit pane is now resizable \[ID_28137\]

It is now possible to change the width of the right-hand edit pane.

#### Dashboards app - Line chart component: New option to highlight parameters on graph and legend \[ID_28144\]

When configuring a line chart component, in the *Styling and Information* section of the *Layout* tab, you can now find the *Highlight lines on hover* option. This option enables users to highlight lines on a trend graph.

When you select the *Highlight lines on hover* option, which is cleared by default, you can also specify the thickness of the highlighted lines (default: 3 px).

There are two ways to highlight a trend line:

- Hovering over the trend graph.
- Expanding the legend and hovering over a parameter name.

#### Dashboards: Deleting components by pressing the DELETE key \[ID_28171\]

In the Dashboards app, up to now, it was possible to delete components in edit mode by selecting them and clicking the *Delete* button at the top of the page. Now, instead of clicking the Delete button, it is also possible to press the DELETE key on your keyboard.

> [!NOTE]
> After selecting the component to be deleted, make sure the focus is on the dashboard before you press the DELETE key. If the focus in on e.g. the header bar or the subheader bar, pressing the DELETE key will not work.

#### Dashboards app: Restricting access to dashboards \[ID_28345\]

From now on, when you create or import a new dashboard, you will be able to restrict access to it by specifying one of the following security levels:

| Security level | Description |
|----------------|-------------|
| Public         | Every user is allowed to view, edit and share the dashboard. |
| Protected      | Every user is allowed to view the dashboard, but only the user who created it is allowed to edit or share it. |
| Private        | Only the user who created the dashboard is allowed to view and edit it. Note: In the Automation app, it will not be possible to attach private dashboards to report emails. |

> [!NOTE]
>
> - When users with edit permission are editing a dashboard, they will now be able to indicate which users are allowed to view and/or edit that dashboard.
> - Users will not be able to rename or delete a dashboard folder when it contains dashboards they are not allowed to edit.
> - By default, the built-in Administrator account is allowed to view and edit all dashboards.
> - Existing dashboards created in earlier DataMiner versions will remain accessible to all.

#### Dashboards app: Parameter table filters \[ID_28539\]

In line chart components, it is now possible to configure a parameter table filter that will allow you to filter out specific rows.

Currently, two types of filters can be configured: VALUE and FULLFILTER. Built-in Intellisense will help you construct the filter.

Examples:

- value=PK == 1
- value=DK==Izegem
- value=518==5;value=522>=10
- fullfilter=(value=PK ==1 or value=PK ==2)
- fullfilter=((value=PK \> 36) and (value=518 in_range 1/5 )) or (VALUE=DK == Brus\*)

> [!NOTE]
>
> - Currently, only line chart components support the use of parameter table filters.
> - Parameter table filters can only be configured when you have started the Dashboards app with the *showAdvancedSettings* URL parameter set to true.
> - When you update a filter, you have to re-add it to the component.

#### Dashboards app - Table component: GQI query result can now be export to a CSV file \[ID_28637\]

When a table component displays the result of a GQI query, it is now possible to export that result to a CSV file.

To do so, click the ellipsis icon in the upper-right corner and select *Export to CSV*.

By default, the CSV file will be named “Query XXX” (XXX being the name of the query). If necessary, the name of the query can be changed in the *Queries* section in the table component’s data panel.

The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result. This data will contain the display values, not the raw values. This means that parameter values will contain units and that discrete values will be replaced by their corresponding display value.

By default, all rows of the query result will be exported. If you want to export only a subset, first select the rows to be exported and then click *Export to CSV*.

If you only want to export specific columns, you can drag those columns from the data panel onto the component before you export the data.

#### Dashboards app - Line chart component: Trend graph will now display the actual name of a profile parameter \[ID_28657\]

When, in the Dashboards app, you add a profile parameter to a line chart component, from now on, the label of its trend line will now display the actual name of the profile parameter instead of the name of the underlying parameter that is associated with it.

#### Dashboards app: State component now also supports protocol data and indices \[ID_28688\]

The state component now supports all possible data types, including protocol data and indices.

Also, the Layout pane of this component has been enhanced.

#### Dashboards app: New Views data source for generic query interface \[ID_28707\]\[ID_28877\]

The generic query interface now features a new *Views* data source, which can be used to retrieve all the views in the DataMiner System. For each view, the View ID and Name columns are retrieved by default. The following columns can also be retrieved by means of an additional column filter:

- Parent view ID
- Last modified
- Last modified by
- Enhanced element ID
- Custom view property columns

#### Dashboards app: Service Definition components now accept services as data sources \[ID_28746\]

In the Dashboards app, service definition components now accept services as data sources.

When you drag a service onto a service definition component, by default, the component will display the service definition and the bookings of that service.

If necessary, you can apply a filter by specifying a time range. If you do not specify a time range, the component will display the current booking.

> [!NOTE]
> From now on, it is no longer possible to filter a service definition component when its data source is either a booking or a service definition.

#### Dashboards app - GQI: Using a feed as a column filter \[ID_28770\]

When building a GQI query, it is now possible to use a feed as a column filter.

Instead of providing a fixed value to filter a specific column, you can now select the *From feed* option and configure a filter by specifying the following items:

| Filter item | Description                                                                                                                |
|-------------|----------------------------------------------------------------------------------------------------------------------------|
| Feed        | The name of the feed that will provide the data. If only one feed is available, it will automatically be selected.         |
| Type        | The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected. |
| Property    | The property by which the column will be filtered (depending on the type of data).                                         |

Example: If the column in question has to be filtered using the element name found in the URL of the dashboard, then you can set *Feed* to “URL”, *Type* to “Elements” and *Property* to “Name”.

#### Dashboards app - GQI: New 'View relations' data source \[ID_28797\]\[ID_28877\]

In the Generic Query Interface, a new “View relations” data source is now available. It contains all DataMiner objects that are part of a view.

Each row in this data source has the following columns:

| Column   | Description                                                                 |
|----------|-----------------------------------------------------------------------------|
| View ID  | The ID of the view.                                                         |
| Child ID | The ID of the DataMiner object in the view.                                 |
| Depth    | The level of the DataMiner object in the view tree in relation to the root. |

When you set the *Recursive* option to true, the table will not only contain all direct relationships (i.e. between a parent item and a child item), but also all indirect relationships (e.g. between a grandparent item and a grandchild item).

#### Dashboards app: Existing GQI queries stored in Queries.json will now automatically be copied to the correct dashboard files during a DataMiner upgrade \[ID_28816\]

As from DataMiner main release version 10.1.0 and feature release version 10.1.3, GQI queries are stored in the dashboards instead of a separate *Queries.json* file, located in the *C:\\Skyline DataMiner\\Generic Interface\\* folder.

When you upgrade to DataMiner main release version 10.2.0 or feature release version 10.1.4, any existing GQI queries that are still stored in the Queries.json file will now automatically be copied to the correct dashboard files.

#### Dashboards app - GQI: Records in views, services and elements data sources now contain metadata that will allow views, services and elements to act as feeds \[ID_28891\]\[ID_28940\]

All records in the views, services and elements data sources will now contain metadata that will allow a view, a service or an element to act as a feed when a table row referring to that view, service or element is selected.

#### Dashboards app - State, Gauge and Ring components: Enhancements \[ID_28984\]

A number of enhancements have been made to the Gauge and Ring components:

- As to the Ring component, labels are now displayed underneath the ring.

- The Gauge and Ring components can now display the configured range (minimum and maximum value). Also, it is now possible to configure a custom range in each of those components.

- The Gauge and Ring components are now more in line with the State component. When configuring these components, it is now possible to select one of three designs (small, large and autosize) and to specify the alignment (left, center and right).

#### Dashboards app - GQI: Importing a query from another dashboard into the current dashboard \[ID_28907\]\[ID_29022\]

It is now possible to import queries from another dashboard into the current dashboards.

1. In the *Queries* section of the *Data* pane, click the *Import* button.

2. In the *Import Query* window,

    - select the dashboard containing the query,
    - select the query,
    - if necessary, change the name of the query, and
    - click *Import*.

> [!NOTE]
> If you import a query that uses other queries, all those queries will be merged into one single query that will then be imported into the current dashboard.

#### Dashboards app: Sharing dashboards with other users via the DataMiner Cloud \[ID_29047\] \[ID_31476\]

It is now possible to share dashboards with other users via the DataMiner Cloud.

##### Prerequisites

- The DataMiner Cloud Pack must be installed on the DataMiner Agent.
- The DataMiner Agent must be connected to the DataMiner Cloud.
- To be able to share items, users must have the following permissions:

  - Modules \> Reports & Dashboards \> Dashboards \> Edit
  - General \> Live sharing \> Share
  - General \> Live sharing \> Edit
  - General \> Live sharing \> Unshare

##### To share a dashboard

1. In the Dashboards app, go to the list of dashboards on the left, and select the dashboard you want to share.

1. Click the “...” button in the top-right corner of the dashboard, and select *Start sharing*.

1. If it is the first time you are sharing the dashboard, you may be asked to confirm that you want to link your account to the cloud. Select *I want to link the above users* and click *Link accounts*.

1. In the pop-up window, fill in the email address of the person you want to share the dashboard with.

1. Optionally, in the *Message* field, add a message you want to send to the person you are sharing the dashboard with, in order to provide additional information.

1. If you do not want the dashboard to remain permanently available, select the *Expires* option and specify the expiration date.

1. Click *Share*. An email will be sent to the person you are sharing the dashboard with, to inform them that they now have access to the dashboard.

> [!NOTE]
>
> - If access to a dashboard is limited to some users only, it will not be possible to share this dashboard.
> - You can stop sharing a dashboard by clicking the “...” button again and selecting *Manage share*. This will open a pop-up box where you can delete the share or update the message.
> - At present, sharing dashboards that use the following components is not supported: spectrum components, Maps, SRM components (service definition and resource usage line graph), queries using feeds and visualizations based on query feeds (e.g. node edge graph, table), trend components with subscription filters and pivot table components. If you attempt to share a dashboard with content that is not supported for sharing, a message will be displayed with more information.

##### To access the Sharing module that lists the dashboards that others have shared with you

1. Open an internet browser (other than Microsoft Internet Explorer), go to <https://dataminer.services/>, and sign in.

1. On the landing page of the DataMiner Cloud Platform, click *Sharing*.

   You will now see all data that others have shared with you.

> [!NOTE]
> When somebody has shared a dashboard with you, you will receive an email informing you of this. You can then click the link in the email to immediately access the dashboard, provided that you already have a DataMiner Cloud Platform account.

##### Security layers

- User authentication via Microsoft B2C login.

- For every shared dashboard, a dedicated “Cloud-connected Agent” user (CCA user) is created on the DataMiner Agent. This user only has permission to view the data shown on the dashboard and nothing else.

- The DataMiner Web Services API now has a Web Application Firewall. Each time a CCA user calls a particular web method, this firewall will check whether that CCA user is allowed to do so.

- Detailed logging is stored in *C:\\Skyline DataMiner\\logging\\Web* and Dashboards Sharing SPI metrics are published.

> [!NOTE]
> In the list of users and groups in System Center, there is a separate section for cloud users and groups. These also have their own icon, so the distinction with regular users and groups is more clear.
>
> As cloud users and groups are entirely managed by DataMiner, they cannot be modified.

#### Dashboards app - Service definition component: Node scaling \[ID_29142\]

In the service definition component, nodes will now have a fixed initial size and ratio. When the service definition does not fit inside the component, vertical and/or horizontal panning will be enabled depending on the direction that is clipped. For example, when a service definition is very wide and its nodes are clipped on the right-hand side, horizontal panning will be possible, but vertical panning will not. Also, zooming in and out will fully scale the nodes so that every-thing keeps its aspect ratio.

> [!NOTE]
> The zoom controls in the bottom-right corner have been removed.

#### Dashboards app - GQI: Linking a \[Get parameters for elements where\] 'Protocol' filter to a parameter feed \[ID_29335\]

After selecting a \[Get parameters for elements where\] “Protocol” filter, you can now link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The parameters from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a filter to an index feed \[ID_29338\]

After selecting a filter, you can now link this filter to an index feed.

To do so, select the *Use feed* option, and select one of the available index feeds from the list.

#### Dashboards app - GQI: Linking a \[Get parameter table by ID\] 'DataMiner ID' 'Element ID' filter to a parameter feed \[ID_29351\]

After selecting a \[Get parameter table by ID\] “DataMiner ID” “Element ID” filter, you can now link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The first table parameter from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a \[Get elements/services/views/view relations\] \> \[Select\] filter to a parameter feed \[ID_29360\]

After selecting a \[Get elements/services/views/view relations\] \> \[Select\] filter, you can now link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The parameters from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a time range filter to a time range feed \[ID_29367\]

Whenever you have to specify a time range when building a query, you can now link this time range filter to a time range feed.

To do so, select the *From feed* option, and select one of the available time range feeds from the list.

#### Dashboards app - GQI: Query filters configured to filter using a regular expression will now combine multiple feed values using 'OR' operators \[ID_29396\]

When a query filter using a feed is configured to filter using a regular expression, from now on, it will combine multiple feed values using “OR” operators.

#### Dashboards app: Node edge graph component \[ID_29425\]

The new node edge graph component allows you to visualize any type of objects (i.e. “nodes”) and the connections between them (i.e. “edges”). Moreover, by linking parameters and properties to those nodes and edges, you can turn a node edge graph into a full-fledged analytical tool that shows real-time alarm statuses and KPI data using dynamic coloring.

The data necessary to create a node edge graph can to be provided by means of GQI queries. Node queries provide data that will be visualized as nodes (i.e. objects), whereas edge queries provide data that will be visualized as edges (i.e. connections between objects).

For more detailed information, see [Node edge graph](xref:DashboardNodeEdgeGraph).

#### Dashboards app - GQI: Regular expressions in column filters will now be converted to standard table filters \[ID_29458\]

From now on, when regular expressions with the following structure are found in column filters, they will be converted to standard table filters.

| Regular expressions with the following structure ... | will be converted to ...                                 |
|------------------------------------------------------|----------------------------------------------------------|
| ^(Value01\|Value02\|Value03)$                        | (XXX == Value01) OR (XXX == Value02) OR (XXX == Value03) |

#### Dashboards app: Enhanced data source counters in edit panel \[ID_29495\]

In the edit panel, up to now, the counter next to each data source would indicate the total number of draggable items in that data source that matched the applied filters. From now on, each data source counter will instead indicate the amount of items in the next level only.

Imagine a DataMiner Agent with the following view tree:

Root

- child 1

  - child 3
  - child 4

- child 2

  - child 5

From now on...

- the counter of the views data source will show “(1)”, i.e. the root, and
- the counter of the root view data source will show “(2)”, i.e. child view 1 and 2.

> [!NOTE]
> The counter of the parameters data source will show the total amount of parameters.

#### Dashboards app - GQI: Aggregated and manipulated columns now have metadata \[ID_29494\] \[ID_29514\]

Metadata will now be added to columns created by an aggregation or manipulation operation within the GQI environment. This metadata will provide information regarding the operation (aggregation or manipulation) and the columns involved.

#### Dashboards app - Line chart component: New 'Fill graph' and 'Stack trend lines' options \[ID_29527\]

When configuring a line chart component, you will now find two new options in the *Styling and Information* section of the *Layout* tab:

- **Fill graph**: When you select this option, the space underneath the line will be filled with the line color.
- **Stack trend lines**: When you select this option, all lines in a graph will be stacked on top of each other.

  > [!NOTE]
  > This option is not compatible with the *Show min/max shading*, *Show minimum*, and *Show maximum* options. When you select the *Stack trend lines* option, those options will be disabled and hidden.

Also, the following chart components have been renamed:

| Old name   | New name           |
|------------|--------------------|
| Bar chart  | Column & bar chart |
| Line chart | Line & area chart  |
| Pie        | Pie & donut chart  |

#### Dashboards app - GQI: New filter node option 'Return no rows when feed is empty' \[ID_29557\]

When, in the Data tab, you add a filter node to a GQI query, a new option named “Return no rows when feed is empty” will allow you to specify what should be returned when the filter yields no rows.

- When you enable this option, an empty table will be returned when the filter yields no rows.
- When you disable this option, the entire table (i.e. all rows) will be returned when the filter yields no rows.

#### Dashboards app: State, Gauge and Ring components can now be used as feeds by other components \[ID_29570\] \[ID_29650\] \[ID_29657\] \[ID_29708\]

The State, Gauge and Ring components can now be used as feeds by other components.

In other words, components using a State, Gauge and Ring component as a feed will now be able to ingest data (element, redundancy group, service, view, protocol, index) selected in that State, Gauge or Ring component.

> [!NOTE]
>
> - When a State, Gauge or Ring component is used as a feed, the data selected will be highlighted.
> - A State component can even be used by other components as a GQI data feed.

#### Dashboards app: New Progress bar component \[ID_29773\]

A new *Progress bar* component is now available among the state components in the Dashboards app. It can be used to display the value of an analog parameter as a progress bar.

In the *Layout* tab for this component you can select to hide or display various labels, such as the parameter name and value. You can also select whether the minimum and/or maximum value of the parameter should be displayed. Similar to other state components, you can also select a small or large design and, in case the component is used to display multiple parameters, you can select whether the parameters should be displayed in rows or columns.

In the *Settings* tab, you can specify a custom minimum and/or maximum value.

#### Dashboards app - GQI: Fetching query results page by page \[29801\] \[29858\] \[29898\]

GQI query results can now be fetched page by page.

Before executing a query, the system will send a GenIfOpenSessionRequest message to open a session. That request will return a session ID that then has to be passed along with a series of GenIfNextPageRequest messages to fetch the next pages. Finally, a GenIfCloseSessionRequest message will be sent to close the session.

> [!NOTE]
>
> - A new session must be opened for each query that has to be executed.
> - When a session is opened/used, a timestamp will be added/updated. This timestamp will be used to check whether a session has expired. Sessions can be kept alive by sending a GenIfSessionHeartbeatRequest message.

##### Overview of the request messages

- **GenIfOpenSessionRequest**: Opens a session.

  Properties:

  - Query
  - QueryOptions

- **GenIfNextPageRequest**: Fetches the next page.

  Properties:

  - SessionID (Guid)
  - PageSize (int)

- **GenIfCloseSessionRequest**: Closes a session.

  Properties:

  - SessionIDs: Guid\[\]

- **GenIfSessionHeartbeatRequest**: Prevents a session from expiring.

  Properties:

  - SessionIDs: Guid\[\]

- **GenIfGetOpenSessionsRequest**: Returns a response containing a list of all open sessions, together with the following properties:

  - SessionID (Guid)
  - CreationTime
  - LastUpdated

##### Variables

| Variable                                                                               | Default value    |
|----------------------------------------------------------------------------------------|------------------|
| Maximum concurrent sessions                                                            | 500              |
| Time before a session is expired (without receiving heartbeat/update for that session) | 5 minutes        |
| Internal check cycle if a session is expired                                           | Every 30 seconds |
| Minimum pageSize (rows)                                                                | 1                |
| Maximum pageSize (rows)                                                                | 2000             |

#### Dashboards app - GQI: Linking columns with values of type double or datetime to feeds in query filters \[ID_29902\]

In GQI query filters, from now on, columns containing values of type datetime or double can be linked to feeds. This will allows you to e.g. filter a bookings list by linking the *End* column to a time range feed.

#### Dashboards app: Table visualizations now allow columns to be reordered \[ID_30091\]

In table visualizations, it is now possible to reorder columns.

To move a table column to another location, click its header and drag it to its new location.

#### Dashboards app: Column filter based on text in Node edge graph and Table component \[ID_30182\]

When you configure a column filter for a Node edge graph or Table dashboard component in order to highlight specific columns depending on the displayed value, you can now filter on specific text. Previously, it was only possible to apply a column filter on a selected range. Now, you can instead select the column you want to use for highlighting, and then specify text to filter on in a text box. You can then choose whether a positive or negative filter should be used, and whether the value should equal the filter, contain the filter or match a regular expression.

Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters. You can also remove filters again by selecting No color.

#### Dashboards app - GQI: New 'Get alarms' data source \[ID_30320\] \[ID_30420\]

In the Generic Query Interface, a new “Get alarms” data source is now available. It will return all alarms in the DMS.

The following columns will be returned by default:

- Element name
- Parameter description
- Value
- Time
- Root time
- Severity
- Service impact
- RCA level
- Alarm type
- Owner

You can add the following columns using a column selector node:

- Alarm description
- Alarm ID
- Category
- Component info
- Corrective action
- Comments
- Creation time
- Element ID
- Element type
- Hosting agent ID
- Interface impact
- Key point
- Offline impact
- Parameter ID
- Root creation time
- Root alarm ID
- Status
- Source
- Table index display key
- Table index primary key
- User status
- Virtual function impact
- View impact
- A column for every custom alarm property

#### Dashboards app - State component: 'Show units' option \[ID_30322\]

In the *Settings* tab of a *State* component, it is now possible to select or clear the *Show units* option to show or hide the unit of the parameter.

#### Dashboards app - State component: Enhanced scrolling behavior when Layout flow is set to 'Columns' \[ID_30765\]

When the *Layout flow* setting of a State component is set to “Columns” and there is either a single group or no grouping at all, from now on, the states will always be displayed at full width.

#### Dashboards app - Node edge graph component: New 'Bidirectional configuration' option \[ID_30910\]

When configuring a node edge graph component, you can now use the *Bidirectional configuration* option to specify how you want multiple edges between two nodes to be mapped.

#### Dashboards app - Node edge graph component: 'Filtering & highlighting' section \[ID_31065\]

In the *Layout* pane of a node edge graph component, the *Column filters* section has been renamed to *Filtering & highlighting* and now contains the following options:

| Option | Description |
|--|--|
| Conditional coloring | Previously named *Column filters*, this option allows you to specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. |
| Highlight | When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled |
| Opacity | When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter. Note: When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized. |
| Highlight/Show entire path | When this option is enabled, not only the nodes matching the filter will be highlighted, but also the entire tree structure of which they are a part (from root to leaves). |

> [!NOTE]
> The filtering options mentioned above require the *Query filter* component, which is currently still in [soft launch](https://community.dataminer.services/documentation/soft-launch-options/).

#### Dashboards app: New 'Preserve feed selections' option for dashboard folders \[ID_31380\]

A new setting is now available for dashboard folders: *Preserve feed selections*. When this option is selected, any feed selection you make in a dashboard in the folder is preserved when you navigate to another dashboard in the folder. Note that this only applies to the folder itself, not to any other folders it may contain.

To access this setting, right-click the dashboard folder in the navigation pane and select *Edit*. This *Edit* option also allows you to rename the dashboard folder and replaces the previous *Rename* option in the right-click menu.

#### Dashboards app - GQI: New 'Update data' option \[ID_31445\] \[ID_31450\]

When configuring a GQI query, you can now enable the “Update data” option if you want the component to automatically refresh the data when changes to that data are detected.

By default, the “Update data” option is disabled.

> [!NOTE]
> At present, this feature will only work for queries using a “Parameter table by ID” data source.

#### Dashboards app: Share button will now be disabled when you make a dashboard private \[ID_31667\]

As it is not possible to share private dashboards, the “Share” button will now be disabled when you make a dashboard private.

#### Dashboards app: GQI engine will now check the GQI version of a query \[ID_31698\] \[ID_31703\]

When you open a GQI query, the GQI engine will now check the GQI version of that query to determine whether it is capable of updating or running that query.

#### Dashboards app - Line chart component: New 'Trend points' setting \[ID_31751\]

When configuring a line chart component, you can now indicate how trend data points should be added to the graph by setting the *Trend points* option to one of the following values:

- Average (changes only) (default value)
- Average (fixed interval)
- Real-time

This setting will also be taken into account when you export a trend graph to a CSV file.

#### Dashboards app: 'Start sharing' button replaced by 'Share' button \[ID_31822\]

The “Start sharing” button has been replaced by a “Share” button. Clicking that button will open a popup that allows you

- to create a cloud share, or
- to copy the URL of the dashboard.

When you choose to copy the URL of a dashboard, you can select the following options:

- Select “Embed” to use a URL that will link to the dashboard in embedded mode (i.e. not showing headers and sidebars).
- Select “Use uncompressed URL parameters” to use a URL in which the data in the search parameters is not compressed. This will allow you to see and, if necessary, modify the plain JSON object.

#### Dashboards app: Passing JSON data in a dashboard URL \[ID_31833\] \[ID_31885\]

There are now two ways of passing data in the URL of a dashboard:

- As a dataset containing a number of items to be selected in all components (legacy method)
- As a JSON object containing a number of items to be selected in specific components (new method)

##### Dataset (legacy method)

Up to now, data could be passed to a dashboard using the following syntax:

```txt
url?<datatype1>=<datakeys1>&<datatype2>=<datakeys2>&...
```

Using this method, the dataset, which consists of a list of datatype/datakey(s) expressions, will provide data that will be selected in all relevant components of the dashboard.

##### JSON object (new method)

Next to the legacy method, it is now also possible to pass data to a dashboard in a JSON object.

```txt
url?data=<URL-encoded JSON object>
```

This JSON object has to have the following structure:

```json
{
    "version": 1,
    "feedAndSelect": <data>, (optional)
    "feed": <data>, (optional)
    "select": <data>, (optional)
    "components": <component-data>
}
```

- **\<data>** is a JSON object with a number of property keys (identical to the legacy datatypes) and property values (as an array of datakey strings). See the following example.

    ```json
    {
        "parameters": ["1/2/3", "1/4/6"],
        "elements": ["1/2", "1/8", "212/123"]
        ...
    }
    ```

- **\<component-data>** is an array of objects that allow you to specify data to be passed to one particular component. See the following example:

    ```json
    {
        cid: <component-id>,
        select: <data>
    }
    ```

- When you provide data in the (optional) **feedAndSelect** item, that data will be interpreted as if it would be passed using the legacy method described above.

- When you provide data in the (optional) **feed** item, that data will only be used in the URL feed. It will not be used to select items in selection boxes on the dashboard.

- When you provide data in the (optional) **select** item, that data will only be used to select items in selection boxes on the dashboard. It will not be used in the URL feed.

- In the **components** item, you can provide data to be selected in specific components referred to by their ID.

    > [!NOTE]
    > When you are editing a dashboard, each component will show its ID in the bottom-right corner (e.g. “State 1”).

> [!NOTE]
> When a dashboard updates its own URL, it will use the new format, but in a compressed way. In that compressed syntax, the query parameter “d” will be used instead of “data”.

### DMS Automation

#### Interactive Automation scripts will now take into account timeouts set in the engine.Timeout property of the executed script \[ID_28405\]

From now on, interactive Automation scripts will also take into account any timeout set in the engine.Timeout property of the executed script.

#### Interactive Automation scripts: Lazy loading of tree view items \[ID_28528\]\[ID_29295\]

It is now possible to configure that a tree view item in interactive Automation scripts will only be loaded when a user expands the item by clicking the arrow in front of it.

To activate this so-called lazy loading for a particular tree view item, set its SupportsLazy-Loading property to true. An arrow will appear in front of the tree view item (even if it does not have any child items).

> [!NOTE]
> You can use the GetExpanded method of the UIResults class to retrieve the keys of all expanded tree view items that have the SupportsLazyLoading property set to true.

#### Interactive Automation scripts: Enhanced file selector \[ID_28628\]

A number of enhancements have been made to the file selector used in interactive Automation scripts.

#### Interactive Automation scripts: New 'TreeViewItemCheckingBehavior' property of TreeViewItem \[ID_29993\]\[ID_30603\]

You can now configure what happens when you select a tree view item in an interactive Automation script, using the new *TreeViewItemCheckingBehavior* enum property of the *TreeViewItem* object.

This property can have the following values:

- *FullRecursion*: All child items will automatically be selected when this item is selected, and vice versa.

- *None*: Only this item will be selected. The selection state of child items will not change. In addition, if all child items are selected, this tree view item will not be automatically selected.

For example:

```csharp
UIBuilder uib = new UIBuilder();
   uib.Title = "Treeview - Regular";
   uib.RequireResponse = true;
   uib.RowDefs = "*";
   uib.ColumnDefs = "*";
   UIBlockDefinition tree = new UIBlockDefinition();
   tree.Type = UIBlockType.TreeView;
   tree.Row = 0;
   tree.Column = 0;
   tree.DestVar = "treevar";
   tree.TreeViewItems = new List<TreeViewItem>
   {
      new TreeViewItem("Slapp", "Slapp (Nexus)", false, new List<TreeViewItem>
      {
         new TreeViewItem("Nitro", "Nitro (Squad)", false, new List<TreeViewItem>
         {
            new TreeViewItem("Brian", "Brian (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Gilles", "Gilles (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("KevinM", "KevinM  (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("KevinV", "KevinV  (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Seba", "Seba  (Member)", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Ward", "Ward  (Member)", true) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
         }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
         new TreeViewItem("Nitro", "Nitro (Squad)", true, new List<TreeViewItem>
         {
            new TreeViewItem("Jordy", "Jordy (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Jorge", "Jorge (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Ronald", "Ronald (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Victor", "Victor (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Wim", "Wim (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None },
            new TreeViewItem("Quinten", "Quinten (Member)") { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
         }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
     }) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None }
   };
   uib.AppendBlock(tree);
   _treeResults = _engine.ShowUI(uib);
```

Regardless of which type of behavior you choose, if one or more child items of a tree view item are selected, the checkbox of the tree view item will be colored.

#### ProcessAutomationHelper \[ID_30108\]

A new ProcessAutomationHelper has been added to manipulate PaToken and PaProcess objects. See the following example.

```csharp
public class Script
{
    public void Run(Engine engine)
    {
        var paHelper = new ProcessAutomationHelper(engine.SendSLNetMessages);
        var token = new PaToken() { Id = Guid.NewGuid() };
        var createdToken = paHelper.PaTokens.Create(token);
        var readToken = paHelper.PaTokens.Read(createdToken.ToFilter<PaToken>());
        paHelper.PaTokens.Delete(createdToken);
        var process = new PaProcess() { Id = "id" };
        var createdProcess = paHelper.PaProcesses.Create(process);
        var readProcess = paHelper.PaProcesses.Read(createdProcess.ToFilter<PaProcess>());
        paHelper.PaProcesses.Delete(createdProcess);
    }
}
```

> [!NOTE]
>
> - Save operations will always be executed synchronously. In other words, the method will only return once the data has been written to the database.
> - At present, bulk operations are not yet supported.
> - Both PaProcess and PaToken now have a new LastModifiedAt property, filled in by SLNet. It will be used to compare cached versions with versions retrieved from the database.

#### Interactive Automation scripts: File selector allowing multiple selections + file selector enhancements \[ID_30196\]

In an interactive Automation script that is used in the DataMiner web apps, you can now configure a file selector component that allows the user to upload multiple files. To do so, set the property *AllowMultipleFiles* to true.

For example:

```csharp
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
uibDef.DestVar = destvar;
uibDef.InitialValue = initialValue;
uibDef.Row = (int)row;
uibDef.RowSpan = (int)rowSpan;
uibDef.Column = (int)column;
uibDef.ColumnSpan = (int)columnSpan;
uibDef.HorizontalAlignment = GetHorizontalAlignment(horizontalAlignment);
uibDef.VerticalAlignment = GetVerticalAlignment(verticalAlignment);
uibDef.AllowMultipleFiles = true;
```

With this configuration, users will be able to add files one by one, but they will not be able to add the same file twice. They will also be able to add a file by dragging it to the file selector.

There have also been a number of enhancements to the file selector control in general, including improved layout and a more intuitive UI. These affect all the web apps, including the Dashboards app, the Jobs app, etc.

#### Interactive Automation scripts: Input components now have a 'WantsOnFocusLost' property & other input component enhancements \[ID_30638\]

In an interactive Automation script that is used in the DataMiner web apps, the following components now have a *WantsOnFocusLost* property. If you set this property to true, then an *OnChange* event will be triggered when the component loses focus.

- Calendar
- Checkbox
- CheckboxList
- Dropdown
- Numeric
- Passwordbox
- RadioButtonList
- Textbox
- Time

Other enhancements:

- A Dropdown component will now keep the focus after an option was selected. This will enable users to still browse through the options using the arrow keys even when the options popup window is closed.
- In a Checkbox, a CheckboxList or a RadioButtonList component, users can now select or clear options using the spacebar.
- In a CheckboxList or a RadioButtonList component, users can now go from one checkbox or radio button to another using the TAB keys.

#### Automation scripts launched from web apps will now take into account the MaxFileSizeInBytes and AllowedFileNameExtensions properties of UIBlockDefinitions of type FileSelector \[ID_31212\]

In Automation scripts launched from web apps, the MaxFileSizeInBytes and AllowedFileName-Extensions properties of UIBlockDefinitions of type FileSelector will now also be taken into account.

An error will now be thrown when you try to add a file that is larger than the allowed file size or does not have an allowed file name extension. Also, the “Choose file” popup window will now only list files with an allowed extension and dragging an item other than a file or a folder onto the script’s drop zone will no longer be possible.

### DMS Maps

#### Filtering on alarm severity: \<Checkbox> tags now have a 'checked' attribute \[ID_30429\]

If you want a map to contain a filter box that allows users to filter map items based on their alarm severity level, then you add a \<FilterBox> tag that contains a checkbox for every alarm severity level. From now on, it is possible to indicate whether those checkboxes should be selected or cleared by default. To do so, add a “checked” attribute to each of the checkboxes, and set their value to either true or false.

See the following example:

```xml
<MapConfig ...>
  ...
  <FilterBox visible="true">
    <CheckBoxes>
      <CheckBox alarmLevel="Normal" name="connected" checked="true" />
      <CheckBox alarmLevel="Critical" name="not connected" checked="true" />
      <CheckBox alarmLevel="Undefined" name="unknown" checked="false" />
    </CheckBoxes>
  </FilterBox>
  ...
</MapConfig>
```

> [!NOTE]
> If, for a particular checkbox, you do not specify a “checked” attribute, then the checkbox will be selected by default.

### DMS Web Services

#### BREAKING CHANGE: Web Services API v0 now disabled by default \[ID_29453\]

The Web Services API v0 is now disabled by default. It is recommended to use the Web Services API v1 instead (SOAP or JSON).

> [!NOTE]
> If necessary, you can still enable the Web Services API v0 by adding the following key inside the \<appSettings> element of the *C:\\Skyline DataMiner\\Webpages\\API\\Web.config* file:
>
> *\<add key="enableLegacyV0Interface" value="true"/>*

#### Web Services API v1: CreateElement and EditElement methods now allow to create and edit replicated elements \[ID_30339\]

The CreateElement and EditElement methods now allow you to create and edit elements that replicate elements from a different DataMiner System.

In the configuration section, you will find a ReplicationInfo subsection that allows you to specify the necessary settings.

#### Web Services API v1: New methods to manage alarm templates \[ID_30383\] \[ID_31149\]

The following new methods now allow you to create, update, delete and assign alarm templates:

- CreateAlarmTemplate
- UpdateAlarmTemplate
- DeleteAlarmTemplate
- AssignAlarmTemplate

If no baseline configuration is provided in the request, the alarm information configured in the protocol for the chosen parameter will be passed along, and if no alarm information could be found, then a default baseline will be passed along instead.

The “average type” property will always be set to “median”.

### DMS web apps

#### Throttling will now be enabled on all SLNet connections \[ID_28442\]

All web applications\* will now connect to SLNet with the “AllowMessageThrottling” attribute.

*\*Monitoring, new Dashboards, legacy Dashboards, Maps, Web Services APIs, etc.*

#### HTML5 apps that require an Elasticsearch database will now redirect users to an error page when that database is unavailable \[ID_28767\]

When you log on to an app that requires an Elasticsearch database, you will now be redirected to an error page when that database is unavailable.

#### Ticketing app: Executing scripts when a ticket is created, updated or deleted \[ID_29191\]

The TicketFieldResolver now includes a TicketFieldResolverSettings object, which can contain a ExecuteScriptOnTicketActionSettings object.

In an ExecuteScriptOnTicketActionSettings object, you can specify the names of the scripts that should be executed each time a ticket is created, updated or deleted. See the following example.

```csharp
var settings = new TicketFieldResolverSettings()
{
    ScriptSettings = new ExecuteScriptOnTicketActionSettings()
    {
        OnCreate = onCreateScriptName,
        OnDelete = onDeleteScriptName,
        OnUpdate = onUpdateScriptName
    }
};
var fieldResolver = new TicketFieldResolver(Guid.NewGuid())
{
    Settings = settings,
    TicketStateFieldDescriptor = { IsRequired = false }
};
```

The scripts must have an OnTicketCrud entry point defined. See the following example. This way, you can indicate the action, ticket and TicketFieldResolver for which the script was triggered.

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnTicketCrud)]
public void OnTicketCrud(Engine engine, TicketID ticketId, CrudType crudType)
{
    engine.GenerateInformation($"Script triggered for {crudType} action on Ticket with ID: {ticketId.TID}")
}
```

#### Jobs app: Added text and number filters for fields \[ID_29221\]

Users can now be allowed to filter on the following field types:

- Text
- Email
- Url

If you want to allow filtering on one of those fields, then select its *Allow filtering on this field* option.

> [!NOTE]
> Text-based filters will behave like case-sensitive “contains” filters.

#### Jobs app: Enhanced time filter \[ID_29328\]

In the Jobs app, the time filter in the sidebar has been improved. You can now indicate whether you want the list to show you the jobs that occurred, started or ended during a particular time frame.

> [!NOTE]
> This time filter will now be stored locally, in the web browser, per domain.

#### Web apps will now display a warning when you do not use an HTTPS connection \[ID_29389\]

From now on, when you access a web app (e.g. Monitoring, Dashboards, Jobs, Ticketing, etc.), a warning will be displayed when you do not use an HTTPS connection.

#### Dashboards/Monitoring: EPM components now fully aligned \[ID_29770\]

The EPM component of the Dashboards app and the Monitoring app are now fully aligned.

Also, the EPM component of the Dashboards app now allows the use of quick chains.

#### Visual Overview: Links starting with 'mailto:' now also work in web apps \[ID_30109\]

When, in shape data, you specify links starting with “mailto:”, those links will now also work in web apps.

#### Web app tooltips: Increased contrast to enhance readability \[ID_30283\]

In all web apps, tooltip contrast has been increased to enhance readability.

#### Web app tooltips: Cursor now changes from arrow to hand when hovering over a tooltip of an input component \[ID_30285\]

From now on, when you hover the mouse pointer over a tooltip of an input component, the arrow will change into a hand.

#### DataMiner landing page: Browser title changed to 'DataMiner' \[ID_31373\]

The browser title of the DataMiner landing page (e.g. `https://<MyDMA>/root/`) has been changed from “DataMiner Services” to “DataMiner”.

Also, the error message shown when you try to log in to a web application with a user account that has not been granted the “DataMiner Web Apps” user permission has now been changed to “You have no access to the DataMiner Web Apps”.

#### BREAKING CHANGE: End of Internet Explorer support for DataMiner web apps \[ID_31675\]

All DataMiner web apps have been upgraded to use Angular 12 instead of Angular 10, which means that the following DataMiner apps and functionality will no longer be available in Internet Explorer:

- The DataMiner landing page
- The Monitoring app
- The Dashboards app
- The Ticketing app
- The Jobs app
- The Monitoring app
- The Application Framework module (currently still in soft launch)
- Automation Script execution in embedded web browser (currently still in soft launch)

> [!NOTE]
> For now, we continue to support the use of DataMiner Cube in Internet Explorer, although it is highly recommended to use the DataMiner Cube desktop app instead. For more information, see DataMiner Dojo: <https://community.dataminer.services/documentation/internet-explorer-support/>

### DMS Service & Resource Management

#### ReservationInstances now have an 'AbsoluteQuarantinePriority' property \[ID_28080\]

ReservationInstances now have an “AbsoluteQuarantinePriority” property.

Resources reserved by a ReservationInstance of which the AbsoluteQuarantinePriority property was set to true will force all resource usages of overlapping ReservationInstances into quarantine.

The usages of a ReservationInstance with absolute quarantine priority do not need to reserve any capacities or capabilities.

In the example below, resources will be quarantined from 10h to 12h UTC tomorrow.

```csharp
var tomorrow = DateTime.UtcNow.AddDays(1).Date;
var timeRange = new TimeRangeUtc(tomorrow.AddHours(10), tomorrow.AddHours(12));
var instance = new ReservationInstance(timeRange) {
    HasAbsoluteQuarantinePriority = false,
    Status = ReservationStatus.Confirmed
};
instance.ResourcesInReservationInstance.Add(new ResourceUsageDefinition(resourceToQuarantine.ID));
```

When a ReservationInstance is added with absolute quarantine priority, an error with reason “ReservationUpdateCausedReservationsToGoToQuarantine” will be returned if this causes any bookings to be quarantined. In that case, the update must be executed using the “forceQuarantine” flag.

> [!NOTE]
>
> - It is possible to add multiple overlapping bookings with AbsoluteQuarantinePriority. If they book the same resource and if results in an overbooking of the resource, one of the instances will be quarantined. If there is no overbooking of the resources between the two bookings with AbsoluteQuarantinePriorit, both bookings will be scheduled.
> - When a booking with AbsoluteQuarantinePriority is removed, the other bookings using the resources will not automatically be taken out of quarantine.
> - Resources that are in quarantine because they overlap with a booking that reserves them with AbsoluteQuarantinePriority will have a QuarantineTrigger with reason “AbsoluteQuarantinePriorityReservationInstance”.

#### Calls requesting eligible resources will now also return information about the available capacity of the resources \[ID_28125\]

The EligibleResourceResult returned by the various GetEligibleResources calls will now contain information about the available capacity of the resources. The ResourceUsageDetails object now includes a CapacityUsageDetails list that contains the maximum available capacities for the requested time frame.

> [!NOTE]
>
> - The available capacity does not take into account the requested capacity.
> - The available capacity for capacities that were not requested in the GetEligible call, but which are present on the resource, will not be calculated, and will therefore not be present in the CapacityUsageDetails list.

#### Triggering an Automation script to reconfigure running bookings after a ProfileInstance was changed \[ID_28186\]

It is now possible to have an Automation script triggered when a profile instance update affects running bookings. That script can then reconfigure the bookings.

##### Configuring the script

The script to reconfigure the bookings can be set on the ProfileManagerConfiguration. See the example below.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
var config = profileHelper.Config.Get();
config.UpdateBookingConfigByReferenceScript = "scriptname";
profileHelper.Config.Set(config);
```

This configuration is automatically synchronized among the Agents in the DMS. Updating the configuration does not require a DMA restart to take effect.

The script will be triggered using a new OnSrmBookingsUpdatedByReference entrypoint. See the example below.

- ProfileInstanceId will contain the ID of the ProfileInstance that was updated.
- reservationIds will contain the IDs of all running ReservationInstances that were reconfigured because of the update.

  This list does not have to include the IDs of the ReservationInstances that, although they did not reference the ProfileInstance, had usages quarantined because the update caused an overbooking.

```csharp
public class Script
{
    [AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmBookingsUpdatedByReference)]
    public void RunEntryPoint(Engine engine, Guid profileInstanceId, List<Guid> reservationIds)
    {
    }
}
```

##### New errors

The UpdateAndApply call for a ProfileInstance can now return a number of additional errors.

When calling UpdateAndApply without forcing quarantine (i.e. with forceQuarantine set to false):

- If no instances need to be quarantined, the update will be applied and the following warning will be returned:

  - A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the running reservations that were reconfigured because of the update.

- If instances need to be quarantined, the update will not proceed and the following errors will be returned:

  - An error with reason ReservationsMustMovedToQuarantine, listing the reservations that need to be quarantined as well as the usages.
  - An error with reason ReservationsMustBeReconfigured, listing the bookings that will be affected by the ProfileInstance update.

When calling UpdateAndApply and forcing quarantine (i.e. with forceQuarantine set to true), the update will proceed and the following TraceData will be returned:

- A warning of type ReservationInstancesMovedToQuarantine, listing the reservations and the usages that were quarantined.
- A warning of type ProfileInstanceChangeCausedBookingReconfiguration, listing the reservations that were reconfigured because of the update.

##### New RequiredProfileInstanceReconfiguration property

A new RequiredProfileInstanceReconfiguration property has been added to the ServiceReservationInstance class. When a ProfileInstance has been updated, all ReservationInstances referencing this ProfileInstance in any of their usages will have this property set to true. This way, solutions can keep track of the bookings that have been reconfigured in case the custom script was interrupted.

See the following example on how to filter on this property:

```csharp
var rmHelper = new ResourceManagerHelper();
rmHelper.RequestResponseEvent += (sender, args) => args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);
var filter = ServiceReservationInstanceExposers.RequiredProfileReconfiguration.Equal(true);
var instancesThatRequiredReconfig = rmHelper.GetReservationInstances(filter);
```

##### Additional information

- If triggering the configured script fails, a notice will be generated with the following text:

  ```txt
  Failed to run script to reconfigure bookings after updating ProfileInstance because an exception occurred. See SLProfileManager.txt logging for more details.
  ```

- When the UpdateBookingConfigByReferenceScript is not configured (i.e. when the setting is empty or null in the profile manager configuration):

  - No attempt will be made to trigger a script.
  - The RequiredProfileInstanceReconfiguration property will not be set to true on the instances.
  - No additional error or warning will be returned in the calls.

#### ResourceManagerHelper.SetReservationDefinitionsAndOverrides method has been rendered obsolete \[ID_28261\]

The ResourceManagerHelper.SetReservationDefinitionsAndOverrides method has been rendered obsolete.

#### ServiceNameInUse check when a ServiceReservationInstance is started \[ID_28327\]

From now on, when a ServiceReservationInstance is started, a check will be performed to see whether a service with the same name is already active. If so, a StartActionsFailureErrorData object will be returned with error reason “ServiceNameInUse”, the error will be logged and the OnStartActionsFailureEvent will be triggered.

The StartActionsFailureErrorData object will also contains the following:

- ReservationInstanceId: The ID of the ServiceReservationInstance that could not be started.
- ServiceId: The ID of the service that has the same name.

#### DVE element will only be updated when certain properties of the FunctionResource are updated \[ID_28450\]

Up to now, each time you updated a FunctionResource, the DVE element would also be updated. From now on, the DVE element will only be updated when one of the following properties of the FunctionResource is updated:

- DmaID
- ElementID
- MainDVEDmaID
- MainDVEElementID
- FunctionName
- FunctionGUID
- PK
- LinkerTableEntries

#### MinReservationStart and MaxReservationCeiling checks have been removed \[ID_28575\]

The MinimumReservationStart and MaximumReservationCeiling checks have been removed.

This means that the start and stop times of ReservationInstances and ReservationDefinitions no longer need to be between the MinimumReservationStart and MaximumReservationCeiling.

Also, the following ResourceManagerErrorData reasons have now all been marked as obsolete:

- BulkAddingFirstOrLastToOLateOrTooEarly
- EndsAfterMaximumReservationCeiling
- StartsBeforeMinimumReservationStart
- ReservationDefinitionMinimumReservationStart
- ReservationDefinitionMaximumReservationCeiling

#### ProfileDefinitions & ProfileInstances: Hiding parameters \[ID_28792\]

A ParameterSettings property has been added to the ProfileDefinition and ProfileInstance classes. Currently, this property can be used to configure whether a parameter should be displayed or not by setting the IsHidden property (which, by default, is false).

ProfileDefinition example:

```csharp
var profileDefinition = new ProfileDefinition()
{
    ID = Guid.NewGuid(),
    Name = "ProfileDefinition name",
    ParameterIDs = { profileParameter },
    ParameterSettings = new Dictionary<Guid, ParameterSettings>()
    {
        {profileParameter, new ParameterSettings() { IsHidden = false }}
    }
};
```

ProfileInstance example:

```csharp
var profileInstance = new ProfileInstance
{
    ID = Guid.NewGuid(),
    Name = $"ProfileInstance name",
    AppliesToID = profileDefinitionId,
    Values = new []
    {
        new ProfileParameterEntry
        {
            Parameter = new ProfileParameter()
            {
                ID = profileParameter
            },
            ParameterSettings = new ParameterSettings()
            {
                IsHidden = true
            }
        }
    }
};
```

#### ServiceDefinitions of type 'ProcessAutomation' \[ID_28799\]

The ServiceDefinition object now has a ServiceDefinitionType property, which can be used to distinguish ProcessAutomation ServiceDefinitions from default ServiceDefinitions.

The default value of ServiceDefinitionType is “Default”.

Example:

```csharp
// Creating a ServiceDefinition with the "ProcessAutomation" type
var serviceDefinition = new ServiceDefinition()
{
    Name = "some name",
    ServiceDefinitionType = ServiceDefinitionType.ProcessAutomation,
}
// Filtering on "ServiceDefinitionType"
var filter = ServiceDefinitionExposers.ServiceDefinitionType.Equal((int) ServiceDefinitionType.ProcessAutomation);
serviceManagerHelper.GetServiceDefinitions(filter);
```

#### Option to remember which view a function DVE was in when it got deactivated \[ID_28884\]

It is now possible for a function DVE that gets deactivated to remember the view it was in. That way, when it gets reactivated again afterwards, it can be placed in the same view as before.

Since this feature will prevent views of inactive function DVEs from being removed from the *Views.xml* file, it can make the *Views.xml* file grow extensively. Therefore, it is disabled by default and has to be enabled manually in the *MaintenanceSettings.xml* file. See the example below.

```xml
<MaintenanceSettings>
  <SLNet>
    <KeepFunctionDveViewsOnDisable>true</KeepFunctionDveViewsOnDisable>
  </SLNet>
</MaintenanceSettings>
```

> [!NOTE]
> When a resource is removed, all associated entries will be removed from the *Views.xml* file.

#### ServiceResourceUsageDefinition now has an IsContributing flag \[ID_28904\]

The ServiceResourceUsageDefinition object now has an IsContributing flag, which can be used to indicate that the resource is being used is a contributing resource.

Example:

```csharp
// Setting the flag
var reservationInstance = new ServiceReservationInstance(new TimeRangeUtc(DateTime.UtcNow.AddHours(1), TimeSpan.FromHours(1)));
reservationInstance.ResourcesInReservationInstance.Add(new ServiceResourceUsageDefinition(resource.ID)
{
    IsContributing = true
});
```

#### EligibleResourceContext can now contain a flag to indicate whether LinkerTableEntries should be filled in or not \[ID_28933\]

When requesting EligibleResources, it is now possible for the EligibleResourceContext to indicate whether the LinkerTableEntries property of the Resources should be filled in or not.

Example:

```csharp
var context = new EligibleResourceContext()
{
    TimeRange = _reservationTimeRange,
    RequiredCapacities = new List<MultiResourceCapacityUsage>()
    {
        new MultiResourceCapacityUsage(_capacityParameterId, 1),
    },
    FillLinkerTableEntries = true
};
resourceManagerHelper.GetEligibleResources(context);
```

> [!NOTE]
> As filling in the LinkerTableEntries can have a negative impact on the overall performance, the LinkerTableEntries flag will by default be set to false.

#### New option to retrieve ProfileInstance parameters from the cache \[ID_29160\]

When the GenerateRequiredCapas method is called on a ProfileInstance, the response will contain all parameters of that instance and its parents. If these parameters are not yet cached on the instances, they will automatically be retrieved from the server. However, in some cases, retrieving them from the server will not be necessary because the script or application in question already cached them.

From now on, the automatic server retrieval can be bypassed by

1. creating a retrieval method that tries to return the parameters that are already cached in the script or application before retrieving them from the server (see the example below), and
1. passing that method to the GenerateRequiredCapas(Func\<ProfileParameterEntry, Parameter> parameterResolver) call.

The following example shows a method that tries to return the parameters that are already cached in the script or application before retrieving them from the server. We first check whether a certain parameter can be found in the local “\_profileParameterCache”. If not, we then retrieve it using the built-in AutoSync collection by means of a get operation on Parameter property.

```csharp
private Parameter GetParameterForParameterEntry(ProfileParameterEntry entry)
{
    if (_profileParameterCache.TryGetValue(entry.ParameterID, out var parameter))
    {
        return parameter;
    }
    // Not found in cache, retrieve using internal AutoSync collection   (by just doing a get on Parameter)
    parameter = entry.Parameter;
    if (parameter == null)
    {
        throw new Exception($"Could not retrieve parameter with ID: {entry.ParameterID}");
    }
    // Add it to our cache
    _profileParameterCache.Add(parameter.ID, parameter);
    return parameter;
}
```

#### New log file: SLResourceManagerAutomation.txt \[ID_29233\]\[ID_29281\]

The following actions will now be logged in the SLResourceManagerAutomation.txt file instead of the SLResourceManager.txt file:

- Actions related to the registering and unregistering of ReservationInstances
- Actions related to the starting of ReservationInstances
- Actions related to the execution of ReservationInstance events

All these log entries will have log level 5.

> [!NOTE]
> In DataMiner Cube, you can access this new log file by going to *System Center \> Logging \> DataMiner \> Resource Manager Automation*.

#### New caching mechanism when retrieving ReservationInstances from Elasticsearch \[ID_29289\]

A caching mechanism involving three separate caches will now be used when retrieving ReservationInstances from an Elasticsearch database, especially when the already saved ReservationInstances have to be checked, e.g. when saving a new ReservationInstance or when requesting the availability of resources in a certain time frame.

##### Overview of the caches

| Cache | Description |
|--|--|
| Hosted ReservationInstance cache | When the ResourceManager module starts, this cache loads the ReservationInstances that are hosted on the agent and schedules the start/stop actions and booking events for these ReservationInstances. Any new instances hosted on the agent that are added or updated while the ResourceManager module is running will also be added to this cache so they can be scheduled. On startup, only the instances starting before a certain point in the future are loaded (default: 1 day). At regular intervals, the database will be checked for instances further in the future. |
| ID cache | When a specific ReservationInstance is requested by ID, the result is cached in this ID cache. When an internal request is made for a specific ID, the cached ReservationInstance will be returned. Used when adding or editing ReservationInstances and when executing start/stop actions and ReservationEvents. |
| Time range cache | When ReservationInstances within a specific time range are requested, all instances in that time range will be cached in this cache. Used when new bookings are created or when eligible resources are requested. |

> [!NOTE]
> GetReservationInstances calls from scripts or clients will go straight to the database. They will not use the caching mechanism.

##### Configuration of the caches

The caches can be configured in the *C:\\Skyline DataMiner\\ResourceManager\\Config.xml* file. See the following example.

```xml
<?xml version="1.0" encoding="utf-8"?>
<ResourceManagerConfig>
  <CacheConfiguration>
    <IdCacheConfiguration>
      <MaxObjectsInCache>100</MaxObjectsInCache>
      <ObjectLifeSpan>P1DT12H</ObjectLifeSpan>
    </IdCacheConfiguration>
    <TimeRangeCacheConfiguration>
      <MaxObjectsInCache>200</MaxObjectsInCache>
      <TimeRangeLifeSpan>PT30M</TimeRangeLifeSpan>
      <CleanupCheckInterval>PT5M</CleanupCheckInterval>
    </TimeRangeCacheConfiguration>
    <HostedReservationInstanceCacheConfiguration>
      <InitialLoadDays>P10D</InitialLoadDays>
      <CheckInterval>PT12H</CheckInterval>
    </HostedReservationInstanceCacheConfiguration>
  </CacheConfiguration>
</ResourceManagerConfig>
```

Overview of the different settings:

| Cache | Setting | Description | Default value |
|--|--|--|--|
| IdCacheConfiguration | MaxObjectsInCache | The maximum amount of objects that will be kept in this cache. When this threshold is exceeded, the oldest objects will be removed. | 500 |
|  | ObjectLifeSpan | The maximum period of time an entry will be kept in the cache. Each time the entry is hit, this timer is reset. This setting has to be formatted according to ISO 8601. | 10 minutes |
| TimeRangeCacheConfiguration | MaxObjectsInCache | The maximum amount of objects that will be kept in this cache. When this threshold is exceeded, the oldest time ranges will be removed. | 3000 |
|  | TimeRangeLifeSpan | The maximum period of time a time range will be kept in the cache. Each time a query hitting this time range is resolved, this timer is reset. This setting has to be formatted according to ISO 8601. | 10 minutes |
|  | CleanupCheckInterval | The interval at which the time ranges to be removed are checked. This setting has to be formatted according to ISO 8601. | 1 minute |
| HostedReservationInstanceCacheConfiguration | InitialLoadDays | The setting that controls how long into the future the ReservationInstances will be loaded at ResourceManager startup. This setting has to be formatted according to ISO 8601. | 1 day |
|  | CheckInterval | The period of time after which the ResourceManager will load new bookings from the database. | 6 hours |

> [!NOTE]
> The ResourceManagerConfig.InitialLoadDays setting no longer has any use, as the ReservationInstances will now be loaded according to the settings in HostedReservationInstanceCacheConfiguration.

##### ClientTest tool

The SLNetClientTest tool now allows you to retrieve the IDs of the currently cached ReservationInstances. To do so, go to *Advanced \> Apps \> SRMSurveyor \> Inspect ReservationInstance Cache*.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

##### Logging

If loglevel 6 is enabled, the caches will log any added, updated or removed items in the SLResourceManagerStorage.txt file.

#### Enhanced performance by implementing ISerializable on the ReservationInstance class using protocol buffer serialization \[ID_29306\]

Overall performance has increased by implementing ISerializable on the ReservationInstance class using protocol buffer serialization.

> [!WARNING]
> Breaking changes:
>
> - The Children and Parent property of a ReservationInstance will no longer be serialized between client and server. When the ResourceManagerHelper is used, backwards compatibility is implemented. However, if you use the messages yourself and receive ResourceManagerEventMessages via subscriptions (which is NOT recommended), you will need to call the GetStitched method on the ReservationInstance class. Saving ReservationInstances with a parent or child instance using messages may also cause issues.
> - When the SetReservationInstances method is called on the ResourceManagerHelper, a random ID will now be assigned before the instances are saved to the server. This could be an issue if scripts expect the ID to be empty and try to reuse the object.

#### ResourceUsageDetails object now has a ConcurrencyLeft property \[ID_29592\]

The ResourceUsageDetails object now has a ConcurrencyLeft property.

When, in the ResourceManagerHelper class, you use the GetEligibleResources method, the returned ResourceUsageDetails object will now include a ConcurrencyLeft property, which will indicate the amount of concurrency left for the resource in question.

When ResourceUsageDetails is equal to null, ConcurrencyLeft will be equal to 0.

#### Binding a VirtualFunctionResource using the primary key \[ID_29648\]

It is now also possible to bind a VirtualFunctionResource using the primary key of an EntryPointTable.

> [!NOTE]
> Binding two resources to the same row, one using the display key and one using the primary key, is not supported and will return a TargetAlreadyBound error.

#### Export and importing ServiceProfileDefinitions and ServiceProfileInstances \[ID_29673\]

Using the ProfileHelper, it is now possible to export and import ServiceProfileInstances and ServiceProfileDefinitions.

##### Exporting ServiceProfileDefinitions and ServiceProfileInstances

The ExportServiceProfiles method allows you to export ServiceProfileDefinitions and ServiceProfileInstances. See the following example.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
var definitionsToExport = new List<Guid>(){ ... };
var instancesToExport = new List<Guid>(){ ... };
var exportResult = profileHelper.ImportExport.ExportServiceProfiles(definitionsToExport, instancesToExport);
```

As shown in the example above, two lists have to be provided:

- A list containing the IDs of the ServiceProfileDefinitions to be exported
- A list containing the IDs of the ServiceProfileInstances to be exported

Based on the information in those lists, the following data will be exported:

- All existing ServiceProfileDefinitions of which the ID is found in the first list.
- All existing ServiceProfileInstances of which the ID is found in the second list.
- All ServiceProfileInstances that are linked to the ServiceProfileDefinitions found in the first list.

> [!NOTE]
>
> - IDs of non-existing objects will be ignored.
> - If you only want to export the ServiceProfileInstances, you can leave the definitionsToExport list empty.

The ExportServiceProfiles method returns a ServiceProfilesExportResult object that contains the following data:

| Property                              | Type                             | Description                                                                  |
|---------------------------------------|----------------------------------|------------------------------------------------------------------------------|
| ZippedData                            | byte\[\]                         | A ZIP file containing all the exported data.                                 |
| ExportedServiceProfileDefinitions | List\<ServiceProfilesObjectInfo> | All ServiceProfileDefinitions that were successfully exported (ID and name). |
| ExportedServiceProfileInstances   | List\<ServiceProfilesObjectInfo> | All ServiceProfileInstances that were successfully exported (ID and name).   |

> [!NOTE]
>
> - When something goes wrong during an export operation, an unknown error will be added to the TraceData. which can be retrieved using profileHelper.ImportExport.GetTraceDataLastCall().
> - To pinpoint any non-existing objects, you can compare the list of IDs you provided to the list of IDs that was returned.
> - When two empty lists are passed to the export method, an ArgumentException will be thrown.

##### Importing ServiceProfileDefinitions and ServiceProfileInstances

The ImportServiceProfiles method allows you to import ServiceProfileDefinitions and ServiceProfileInstances. See the following example.

```csharp
var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
byte[] zippedData = ...;
var importResult = profileHelper.ImportExport.ImportServiceProfiles(zippedData);
```

During an import operation, the objects are first unzipped from the byte array and then saved to the database after a number of compatibility checks.

Checks performed before saving a ServiceProfileDefinition:

- When a ServiceProfileDefinition already exists with the same name but a different ID, the ServiceProfileDefinition will not be imported and an error with reason ServiceProfileDefinitionNameInUse will be returned.
- When not all ProfileParameters referenced in the NodeDefinitionConfiguration exist, the ServiceProfileDefinition will not be imported and an error with reason ServiceProfileDefinitionRefersToNonExistingParameters will be returned.

Checks performed before saving a ServiceProfileInstance:

- When a ServiceProfileInstance already exist with the same name but a different ID, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceNameInUse will be returned.
- When not all ParameterOverrides on the NodeInstanceConfigurations and InterfaceConfigurations refer to existing ProfileParameters, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceRefersToNonExistingParameters will be returned.
- When not all NodeInstanceConfigurations and InterfaceConfigurations refer to existing ProfileInstances, the ServiceProfileInstance will not be imported and an error with reason ServiceProfileInstanceRefersToNonExistingProfileInstances will be returned.

The ImportServiceProfiles method returns a ServiceProfilesImportResult object that contains the following data:

| Property                              | Type                             | Description                                                                  |
|---------------------------------------|----------------------------------|------------------------------------------------------------------------------|
| TraceData                             | TraceData                        | All errors that occurred when importing the objects.                         |
| ImportedServiceProfileDefinitions | List\<ServiceProfilesObjectInfo> | All ServiceProfileDefinitions that were successfully imported (ID and name). |
| ImportedServiceProfileInstances   | List\<ServiceProfilesObjectInfo> | All ServiceProfileInstances that were successfully imported (ID and name).   |

> [!NOTE]
>
> - The TraceData returned by profileHelper.ImportExport.GetTraceDataLastCall() will match the TraceData included in the ServiceProfilesImportResult object.
> - If you want to know why an object was not imported, you can check the TraceData.
> - When an empty byte array is passed to the import method, an ArgumentException will be thrown.

##### ServiceProfilesImportError

When an object cannot be saved to the database during an import operation, a ServiceProfilesImportError will be added to the TraceData. Below, you can find the list of all possible error reasons.

| Error reason | Description |
|--|--|
| Unknown | An unknown error occurred. |
| GeneralFailure | An unexpected exception occurred while importing. The zipped data that was provided is probably invalid.<br> - Exception: The full exception message. |
| UnrecognizedType | The zip file contained an object with an unrecognized type.<br> - EntryName: The name of the unrecognized entry. |
| ExtractingJsonFailed | Something went wrong when trying to extract the JSON data associated with an entry.<br> - Exception: The exception that occurred while extracting.<br> - ObjectType: The type of the entry for which the JSON data was extracted.<br> - ObjectId: The ID of the entry for which the JSON data was extracted. |
| DeserializationFailed | Something went wrong when trying to deserialize the JSON data.<br> - Exception: The exception that occurred while deserializing.<br> - ObjectType: The type of the entry for which the JSON data was deserialized.<br> - ObjectId: The ID of the entry for which the JSON data was deserialized. |
| ErrorOccuredSavingServiceProfileDefinition | An error occurred while saving the ServiceProfileDefinition.<br> - ServiceProfileDefinitionError: The error message.<br> - ObjectId: The ID of the ServiceProfileDefinition.<br> - ObjectName: The name of the ServiceProfileDefinition. |
| ErrorOccuredSavingServiceProfileInstance | An error occurred while saving the ServiceProfileInstance.<br> - ServiceProfileInstanceError: The error message.<br> - ObjectId: The ID of the ServiceProfileInstance.<br> - ObjectName: The name of the ServiceProfileInstance. |
| ServiceProfileDefinitionNameInUse | The name of a ServiceProfileDefinition that is being imported is being used by another ServiceProfileDefinition.<br> - ObjectId: The ID of the ServiceProfileDefinition that is being imported.<br> - ObjectName: The name of the ServiceProfileDefinition that is being imported.<br> - ConflictingId: The ID of the ServiceProfileDefinition that is using the same name.<br> - ConflictingName: The name that is being used. |
| ServiceProfileDefinitionRefersToNonExistingParameters | The NodeDefinitionConfiguration of a NodeDefinition references parameters that do not exist in this system.<br> - ObjectId: The ID of the ServiceProfileDefinition that is being imported.<br> - ObjectName: The name of the ServiceProfileDefinition that is being imported.<br> - MissingIds: The IDs of the missing parameters. |
| ServiceProfileInstanceNameInUse | The name of a ServiceProfileInstance that is being imported is being used by another ServiceProfileInstance.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - ConflictingId: The ID of the ServiceProfileInstance that is using the same name.<br> - ConflictingName: The name that is being used. |
| ServiceProfileInstanceRefersToNonExistingParameters | Either the NodeInstanceConfiguration or the InterfaceConfiguration contains parameter overrides that refer to parameters that do not exist in the system.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - MissingIds: The IDs of the missing parameters. |
| ServiceProfileInstanceRefersToNonExistingProfileInstances | Either the NodeInstanceConfiguration or the InterfaceConfiguration contains references to ProfileInstances that do not exist in this system.<br> - ObjectId: The ID of the ServiceProfileInstance that is being imported.<br> - ObjectName: The name of the ServiceProfileInstance that is being imported.<br> - MissingIds: The IDs of the missing ProfileInstances. |

#### Generating contributing functions for service definitions that use mediated virtual functions on one of more nodes \[ID_29752\]

It is now possible to generate contributing functions for service definitions that use a mediated virtual function on one or more nodes.

> [!NOTE]
>
> - For the replication to work, the profile parameter used to generate the parameter in the contributing protocol needs to contain a ProtocolParameterReference to the parameter in the protocol of the VirtualFunctionDefinition.
> - If a service definition node has both the VirtualFunctionID property (to use a mediated virtual function) and the FunctionID property (to use a protocol function) filled in, the VirtualFunctionID will be used during generation.
> - Only the profile definition of the VirtualFunctionDefinition’s VirtualNode will be taken into account when creating parameters.

#### SRM events can now be forwarded as ProtoBuf events on the NATS bus \[ID_29821\]

When an SRM object is created, updated or deleted, an event message is sent via the SLNet subscription system to notify everyone. The NATS forwarding logic also receives these event messages and will now publish a ProtoBuf event on the NATS bus each time it receives such a message.

##### Proto files

The ProtoBuf event messages are defined by ProtoBuf files, which can be obtained on request.

The events themselves are defined in the API protos, which import shared messages from the main shared folder.

##### Subscribing to the NATS event messages

To subscribe to one of the event messages you will need to compile the required proto files. In general, you need to compile the API proto of the event and the complete shared folder. For example, when you want to subscribe to the ReservationInstanceEvent, you need to compile the *reservation_instance_api.proto* file and everything in the general shared folder.

Alternatively, instead of compiling those files yourself, you can also add copies of those files to your project and include the Protobuf NuGet package. The package will then compile them for you.

When you have the compiled .cs file, you can subscribe to the messages as shown in the following C# code example.

```csharp
private void Run(Engine engine)
{
    // Create the message broker
    var broker = SLMessageBrokerFactorySingleton.Instance.Create();
    // Subscribe to the ReservationInstanceEvent
    var topic = "Skyline.DataMiner.Protobuf.Apps.Srm.ReservationInstance.Api.v1.ReservationInstanceEvent";
    broker.Subscribe(topic).WithHandler(Handler);
}
private void Handler(object sender, HandlerEventArgs e)
{
    // Parse the message
    var message = ReservationInstanceEvent.Parser.ParseFrom(e.Data);
    // Do something with the event message...
}
```

##### Errors

When an SRM event is sent out, in some cases, it cannot be forwarded to NATS because of issues related to the SLMessageBroker. In that case, an error will be logged in the SLResourceManager.txt file, stating that an event could not be forwarded.

Note that no retries will occur and that no messages will be queued.

##### Supported events

- ResourceManagerEventMessage

    When a ResourceManagerEventMessage contains multiple types of objects, it will be split up into multiple proto events. When the ResourceManager sends out one ResourceManagerEvent containing e.g. 2 ReservationInstances and 3 Resources, the forwarder logic will publish one ReservationInstanceEvent (with the 2 objects) and one ResourceEvent (with the 3 objects).

##### ReservationInstance object

| Event message name       | Proto file                         | NATS Topic                                                                          |
|--------------------------|------------------------------------|-------------------------------------------------------------------------------------|
| ReservationInstanceEvent | reservation_instance_api.proto | Skyline.DataMiner.Protobuf.Apps.Srm.ReservationInstance.Api.v1.ReservationInstanceEvent |

##### Resource object

| Event message name | Proto file             | NATS Topic                                                    |
|--------------------|------------------------|---------------------------------------------------------------|
| ResourceEvent      | resource_api.proto | Skyline.DataMiner.Protobuf.Apps.Srm.Resource.Api.v1.ResourceEvent |

#### Profile manager errors with ErrorReason 'ReservationsMustBeReconfigured' now include a ReservationInstanceDetails list \[ID_29914\]

From now on, an error with ErrorReason “ReservationsMustBeReconfigured” will include a ReservationInstanceDetails list containing the ID, the name and the start time of every affected ReservationInstance.

#### Returning all available capacities when requesting the eligible resources \[ID_29939\]

When you request the eligible resources, it is now possible to calculate all remaining capacities on the resources instead of only the requested ones.

To enable this feature, set the CalculateAllCapacities flag of the EligibleResourceContext to true.

Example:

```csharp
public class Script
{
    public void Run(Engine engine)
    {
        // We assume there is a resource named 'resourceWithCapacityTwoCapacities'
        var context = new EligibleResourceContext())
        {
            RequiredCapacities =
            {
                new MultiResourceCapacityUsage(firstCapacityId, 200.0m)
            },
            CalculateAllCapacities = true
        };
        var result = resourceManagerHelper.GetEligibleResources(context);
        var usageDetails = result.UsageDetails.FirstOrDefault(d => d.ResourceId == resourceWithCapacityTwoCapacities.GUID);
        var firstCapacityLeft = usageDetails.CapacityUsageDetails.FirstOrDefault(c => c.CapacityParameterId == firstCapacityId).CapacityLeft;
        // Without the 'CalculateAllCapacities' flag this would not be in the result
        var secondCapacityLeft = usageDetails.CapacityUsageDetails.FirstOrDefault(c => c.CapacityParameterId == secondCapacityId).CapacityLeft;
    }
}
```

#### Availability checks for contributing resources \[ID_30017\] \[ID_30498\]

From now on, the GetEligibleResources and AddOrUpdateReservationInstances calls will determine the availability of a contributing resource during a certain time range based on the following criteria:

- If the contributing booking linked to the resource has Status set to “Canceled”, “Disconnected”, “Interrupted” or “Undefined”, then the resource will be considered unavailable.
- If the contributing booking linked to the resource has Status set to a value other than “Canceled”, “Disconnected”, “Interrupted” or “Undefined”:

  - If the contributing booking linked to the resource has LockLifeCycle set to “Locked”, then the contributing resource will be considered available if the time range of the contributing booking is entire inside the time range.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Locked” and the main booking has a start time in the past but an end time in the future, then the contributing resource will be considered available if the time range of the contributing booking only overlaps the future part of the time range of the main booking.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Unlocked”, then the contributing resource will be considered available if the timing of the contributing booking intersects with the passed time.
  - If the contributing booking linked to the resource has LockLifeCycle set to “Undefined”, then the contributing resource will be considered not available.

Based on those criteria, the GetEligibleResource call will not return any resources that are unavailable.

Adding or updating bookings with resources that are unavailable based on the above-mentioned criteria will cause the complete resource usage to be quarantined. The QuarantineTrigger will have reason ContributingResourceNotAvailable.

If the contributing booking has Status set to “Interrupted”, then the bookings using its linked contributing resources will also have their usages quarantined.

#### More detailed parameter check error messages when generating protocols for virtual functions \[ID_30093\]

When an error occurs during a parameter check while generating a protocol for a virtual function, the error message will now contain more detailed information.

- When a parameter is not of category “Monitoring” or “Configuration”, a CrudFailedException containing a VirtualFunctionDefinitionError with reason InvalidProfileParameterCategory will be thrown.
- When a parameter is of type “discrete” but has no discrete values assigned to it, a CrudFailedException containing a VirtualFunctionDefinitionError with reason InvalidProfileParameterDiscrete will be thrown.

The VirtualFunctionDefinitionError will have the following properties filled in:

- VirtualFunctionDefinitionID: The ID of the VirtualFunctionDefinition.
- ParameterID: The ID of the parameter that cannot be resolved.

#### Profile Manager: Enhanced performance when executing bulk create/update operations against an Elasticsearch database \[ID_30152\]

Because of a number of enhancements to the AddOrUpdateBulk calls of the ProfilesHelper and ProfileManagerHelper, overall performance has increased when creating or updating ProfileParameters, ProfileInstances and ProfileDefinitions in bulk in an Elasticsearch database.

#### Automation - Service & Resource Management: New ServiceResourceUsageDefinition.Role property \[ID_30214\]

A *ServiceResourceUsageDefinition* object now has an extra *Role* property, with the following possible values: *Mapped* (default value), *Unmapped* and *Inheritance*. This property is intended to be used by the Booking Manager app, where it will determine whether a resource is mapped to a node of a service definition.

#### ReservationInstance behavior enhancements \[ID_30295\]

ReservationInstance behavior has been changed in the following ways:

- ReservationInstances that have a start time before the time the ResourceManager was initialized will no longer automatically have their status set to “Interrupted”. Only instances that were unable to start because the ResourceManager was not yet initialized will have their status set to “Interrupted”.
- All ReservationEvents that have not yet run will be scheduled if the ReservationInstance does not have its status set to “Interrupted”. In other words, all missed events will be run immediately when you add a ReservationInstance with a start time.

#### ResourceManagerEventMessage will now be sent when a ReservationInstance property was updated \[ID_30352\] \[ID_30668\]

From now on, a ResourceManagerEventMessage will be sent next to the existing ReservationInstanceChangePropertiesEventMessage when a ReservationInstance property was updated using either ResourceManagerHelper#UpdateProperties or ResourceManagerHelper#SafelyUpdateProperties.

DataMiner Cube has been adapted accordingly.

#### Automation - Service & Resource Management: Option to return time-dependent capabilities when requesting eligible resources \[ID_30576\]

When the eligible resources for a booking are requested, it is now possible to calculate all booked time-dependent capabilities for the eligible resources. For this purpose, the *CalculateAllCapabilities* flag should be set to true on *EligibleResourceContext*. This feature is intended to be used in the DataMiner Booking Manager app.

#### Profile Manager: Server-side user permissions \[ID_30748\]

The public API of the Profile Manager now has the following server-side user permissions.

| Operation                                                                                   | Required user permission                                                                     |
|---------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| Read calls of ProfileParameters, MediationSnippets, ProfileDefinitions and ProfileInstances | ProfileManagerUI                                                                             |
| Create and Update of ProfileParameters, MediationSnippets ProfileDefinitions                | ProfileManagerEditAll                                                                        |
| Delete calls of ProfileParameters, MediationSnippets ProfileDefinitions                     | ProfileManagerDeleteAll                                                                      |
| Create and Update of ProfileInstances                                                       | ProfileManagerEditInstances                                                                  |
| Delete of ProfileInstances                                                                  | ProfileManagerDeleteInstances                                                                |
| Read calls of ServiceProfileInstances and ServiceProfileDefinitions                         | ServiceProfileManagerUI                                                                      |
| Create and Update ServiceProfileInstances                                                   | ServiceProfileManagerEditInstances                                                           |
| Delete of ServiceProfileInstances                                                           | ServiceProfileManagerDeleteInstances                                                         |
| Create and Update of ServiceProfileDefinitions                                              | ServiceProfileManagerEditDefinitions                                                         |
| Delete of ServiceProfileDefinitions                                                         | ServiceProfileManagerDeleteDefinitions                                                       |
| Mediation calls (MediateDeviceToProfile and MediateProfileToDevice)                         | ProfileManagerEditAll, AccessElement and DataDisplayAccess, as well as access to the element |
| Getting the ProfileManagerConfiguration                                                     | ProfileManagerConfiguration                                                                  |
| Setting the ProfileManagerConfiguration                                                     | ProfileManagerConfiguration                                                                  |
| Exporting and importing ServiceProfiles                                                     | ServiceProfileManagerEditInstances and ServiceProfileManagerEditDefinitions                  |
| Exporting and importing Parameters                                                          | ProfileManagerEditAll                                                                        |

The following new permissions will automatically be assigned to existing user groups:

| User permission...                     | will be assigned to...                                           |
|----------------------------------------|------------------------------------------------------------------|
| ProfileManagerDeleteAll                | groups with the ProfileManagerEditAll permission.                |
| ProfileManagerDeleteInstances          | groups with the ProfileManagerEditInstances permission.          |
| ServiceProfileManagerDeleteInstances   | groups with the ProfileManagerEditInstances permission.          |
| ServiceProfileManagerDeleteDefinitions | groups with the ServiceProfileManagerEditDefinitions permission. |
| ProfileManagerConfiguration            | groups with the ProfileManagerEditAll permission.                |

> [!NOTE]
>
> - The AddOrUpdateBulk, RemoveBulk and Create, Read, Update and Delete calls on single objects in the ProfileHelper will throw CrudFailedExceptions if the ThrowExceptionsOnErrorData property is true on the CrudComponent. If not, the TraceData will contain a ManagerStoreError with reason NoPermission.
>
>   The AddOrUpdateBulk and RemoveBulk calls normally never throw exceptions regardless of the ThrowExceptionsOnErrorData property. However, NoPermission is an exception since this makes the entire call fail.
>
> - The calls in the ProfileManagerHelper will always return TraceData (except for the CrudComponent properties on the helper).
> - Import/export of ProfileParameters and mediation messages will throw a DataMinerException.
> - Import/export of the ServiceProfiles will return TraceData. This helper does not have an option to throw exceptions on error data.

#### Resource Manager: Permission checks \[ID_30895\]

The following messages now have server-side permission checks:

| Operation | Required flags | Helper calls |
|--|--|--|
| Read calls of Resources and ResourcePools | ResManResourceUI | GetResources<br> GetEligibleResources<br> GetResourceUsage<br> GetAvailableResources<br> GetResourcePools |
| Adding Resources or ResourcePools | ResManResourceAdd | AddOrUpdateResources<br> AddOrUpdateResourcePools |
| Updating the status of a Resource | ResManResourceEditStatus | AddOrUpdateResources |
| Updating a Resource (unless only the status is updated) or updating a ResourcePool | ResManResourceEditOther | AddOrUpdateResources<br> AddOrUpdateResourcePools |
| Removing a Resource or ResourcePool | ResManResourceDelete | RemoveResources<br> RemoveResourcePools |
| Read calls of ReservationInstances and ReservationDefinitions | ResManReservationUITimeline | GetReservationInstances<br> GetReservationDefinitions |
| Adding ReservationInstances or ReservationDefinitions | ResManReservationAdd | AddOrUpdateReservation<br>Instances<br> AddOrUpdateReservation<br>Definitions |
| Editing ReservationInstances or ReservationDefinitions | ResManReservationEdit | AddOrUpdateReservation<br>Instances<br> AddOrUpdateReservation<br>Definitions<br> (Safely)UpdateReservation<br>InstanceProperties<br> (Safely)UpdateReservation<br>DefinitionProperties |
| Removing ReservationInstances or ReservationDefinitions | ResManReservationDelete | RemoveReservationInstances<br> RemoveReservationDefinitions |

All operations will now return a ResourceManagerErrorData with reason NotAllowed if the user does not have the correct permissions.

#### RemoveResources: New ignoreCanceledReservations flag \[ID_30936\]

When resources are deleted by means of a RemoveResources call, it is now possible to indicate whether errors should be generated when a resource is being used in canceled reservations.

If you set the ignoreCanceledReservations flag to true, no errors will be generated when deleting a resource that is being used in canceled reservations.

```txt
Resource[] RemoveResources(Resource[] resources, bool ignorePassedReservations, bool ignoreCanceledReservations)
```

### DMS Mobile Gateway

#### Getting and setting the value of a table column parameter \[ID_30399\]

It is now possible to get and set values of table column parameters using text messages.

Syntax:

- GET:\<ElementName>:\<ParameterName>\|\<TableIndex>
- SET:\<ElementName>:\<ParameterName>\|\<TableIndex>:\<Value>

Examples:

- Use “GET:MyElement:MyParam\|10113” to get the value stored in row 10113 of parameter “MyParam” of element “MyElement”.
- Use “SET:MyElement:MyParam\|10113:100” to set the value stored in row 10113 of parameter “MyParam” of element “MyElement” to 100.

Using special characters:

- If an argument contains a colon (“:”), a backslash character (“\\”) must be put in front of it. For example, the command “SET:MyElement:MyParam\|a\\:b:100” will set the value stored in row a:b to 100.
- If the table index contains a pipe character (“\|”), a backslash character (“\\”) must be put in front of it. For example, the command “SET:MyElement:MyParam\|a\\:b\\\|c:100” will set the value stored in row a:b\|c to value 100.

> [!WARNING]
> Breaking change: Due to the introduction of this new syntax, it is no longer possible to get and set single-value parameters of which the name contains pipe characters.

### DMS tools

#### Standalone Elasticsearch Cluster Installer will no longer automatically configure TLS and security \[ID_29113\]

From now on, the Standalone Elasticsearch Cluster Installer tool will no longer automatically configure TLS and security.

For instructions on how to install this manually, see [Securing the Elasticsearch database](xref:Security_Elasticsearch).

#### Standalone Cassandra Backup Tool \[ID_29005\] \[ID_30234\]

The StandaloneCassandraBackup.exe tool can be used by an administrator to take a backup of a Cassandra database (either a single node or a cluster).

From DataMiner 10.1.8 onwards, this tool will be available on each DMA server in the folder *C:\\Skyline DataMiner\\Tools*. As it only affects Cassandra files, it can be used on any DataMiner system regardless of version.

For more information on this tool, see [Standalone Cassandra Backup Tool](xref:Standalone_Cassandra_Backup_Tool).

#### New tool to transform a DMS with separate databases into a DMS with a shared Cassandra/Elasticsearch cluster \[ID_31005\] \[ID_31280\] \[ID_31421\] \[ID_31423\] \[ID_31424\] \[ID_31505\] \[ID_31788\]

Using *SLCCMigrator.exe*, you can now transform a DataMiner System consisting of Agents with separate databases into a DataMiner System consisting of Agents that are all connected to a shared Cassandra/Elasticsearch cluster.

For more information on this tool, see [Cassandra Cluster Migrator](https://community.dataminer.services/documentation/sql-to-cassandra-cluster-migrator/) on DataMiner Dojo.

#### SLReset: Hostname can now be passed as an argument \[ID_32002\]

When running SLReset.exe, which can be used to fully reset a DataMiner Agent to its state immediately after installation, it is now possible to pass the hostname in a -ho argument, especially when resetting a DataMiner Agent that only allows you to connect via HTTPS.

```txt
SLReset.exe -ho hostname
```

## Changes

### Enhancements

#### Security enhancements \[ID_29724\] \[ID_29883\] \[ID_30086\] \[ID_30087\] \[ID_30192\] \[ID_30202\] \[ID_30257\] \[ID_30345\] \[ID_30674\] \[ID_31081\] \[ID_31169\] \[ID_31307\] \[ID_32081\]

A number of security enhancements have been made.

#### DataMiner Cube - Alarm Console: Automatic incident tracking will now ignore parameter name changes \[ID_28075\]

From now on, automatic incident tracking will ignore parameter name changes. The name of an alarm group will now always be the name of the parameter as specified in the protocol.

This will prevent parameters with different names ending up in the same alarm group.

#### DataMiner Jobs: New field type 'ServiceDefinitionFieldDescriptor' \[ID_28086\]

A new field type “ServiceDefinitionFieldDescriptor” has been added, which will always require a GUID value referring to a service definition.

This field descriptor can also add service definitions using the ServiceDefinitionIds property (of type List\<Guid>), allowing you to filter service definitions based on service definition IDs.

This feature is intended to support the upcoming PLM app.

#### Dashboards app - Line chart component: Trend percentile calculation will now also take into account the period during which a parameter had a certain value \[ID_28135\]

From now on, trend percentile calculations will also take into account the period during which a parameter had a certain value.

> [!NOTE]
> Percentile calculation is skipped when a parameter is of type discrete or when multiple parameters are displayed in one trend graph.

#### Dashboards app: Enhanced mechanism used to create PDF reports \[ID_28170\]

A number of enhancements have been made to the mechanism used to generate PDF reports.

#### DataMiner Cube - Alarm Console: Reasons mentioned in Value column of group alarms generated by Automatic incident tracking now appear in the UI language \[ID_28189\]

When automatic incident tracking is activated, active alarms that are related to the same incident will automatically be grouped into a new alarm, and the Value column of such an alarm will show the reason why the alarms underneath it were grouped. From now on, that reason will appear in the UI language.

#### DataMiner Cube start window: Animation enhancements \[ID_28190\]

A number of enhancements have been made to the animations in the DataMiner Cube start window.

#### Correlation: Enhanced performance when clearing base alarms \[ID_28201\]

Because of a number of enhancements, overall performance has increased when simultaneously clearing a large number of correlation base alarms.

#### Notice when error occurs after disabling and enabling the data offload configuration \[ID_28220\]

When the data offload configuration was disabled and enabled again, in some rare cases, an error can occur. If so, from now on, the following notice will be generated for database parameter 64599 and added to the *SLElement.txt* log file:

```txt
Central DataBase Offload threads aren't closed in a timely fashion. Potential issues with offloading rate data can occur. Disabling and enabling offload rate settings is advised.
```

#### SLAnalytics will now keep track of configuration changes \[ID_28223\]

From now on, SLAnalytics will keep track of all changes made to its configuration settings.

Each DMA will keep a local configuration history, which will not be synchronized with the other DMAs in the DMS.

#### Dashboards app - Pivot table component: Indices from different tables in different elements with identical names will be displayed on the same row \[ID_28344\]

Up to now, when a pivot table component displayed indices on the same row, they were mapped in memory based on primary key. So, when you had indices from different tables in different elements with identical names, those indices would be displayed on different rows because, in memory, they had different primary keys.

From now on, the display keys will also be taken into account. As a result, indices from different tables in different elements with identical names will be displayed on the same row, regardless of their primary key.

> [!NOTE]
> For this to work, the pivot table should show the indices as rows and all other types as columns. Otherwise, the indices will be split up in separate levels.

#### DataMiner Cube - Service & Resource Management: Enhanced error messages \[ID_28351\]

Up to now, when you left a name empty, one of two different error messages could appear. These messages have now been consolidated into one single error message.

#### SLAnalytics: All log entries will now by default have log level 0 \[ID_28361\]

All log entries generated by SLAnalytics will now by default have log level 0.

#### FileInfoManager: Enhancements & debug UI in SLNetClientTest tool \[ID_28409\]

A number of enhancements have been made to FileInfoManager.

Also, under *Advanced \> Apps \> FileInfo*, the DataMiner SLNetClientTest tool now offers a read-only UI to debug FileInfoManager.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### Dashboards app: Service definition component has a new icon \[ID_28501\]

The service definition component has a new icon.

#### Service & Resource Management: Enhanced performance when executing the start actions of a ReservationInstance \[ID_28525\]

Because of a number of enhancements, overall performance has increased when the start actions of a ReservationInstance are executed.

#### New icons added to Icons.xml file \[ID_28566\]

A set of 6 new colored LED icons has been added to the file *Icons.xml*, located in the folder *C:\\Skyline DataMiner\\Protocols*.

#### SLWatchDog will no longer try to restart NAS and NATS when they are disabled \[ID_28585\]

From now on, SLWatchDog will no longer try to restart NAS and NATS when the services are disabled. Also, when there is an active “NAS/NATS has stopped, restarting...” alarm, it will automatically be cleared after a short time.

#### Alarm Console: Enhanced performance when dragging the history slider \[ID_28639\]

Because of a number of enhancements made to the mechanism used to retrieve alarms from the database, overall performance has increased when dragging the history slider in the Alarm Console.

#### Cassandra: Enabling TLS on database connection \[ID_28646\]\[ID_28827\]

It is now possible to enable TLS on Cassandra database connections.

To enable TLS for a particular Cassandra database, do the following:

1. Enable TLS in the settings of the Cassandra database.

1. Enable TLS in the settings of that database in Db.xml. See the following example:

   ```xml
   <DataBase active="true" local="true" type="Cassandra">
     <DBServer>10.10.10.10</DBServer>
     <UID>myUserId</UID>
     <PWD>myPassword</PWD>
     <DB>SLDMADB</DB>
     <TLSEnabled>true</TLSEnabled>
   </DataBase>
   ```

1. Make sure DataMiner is able to use TCP port 7001.

> [!NOTE]
> Currently, the above-mentioned procedure only enables TLS on the database connection. It does not enable client authentication.

#### DataMiner Cube: Enhanced performance when opening cards \[ID_28743\]

Because of a number of enhancements, overall performance has increased when opening cards in DataMiner Cube.

#### Dashboards app: GQI queries now synchronized in cluster \[ID_28756\]\[ID_28765\]

Queries created with the generic query interface in the Dashboards app will now be synchronized across all DMAs in a cluster.

#### DMS.xml now supports using hostnames instead of IP addresses \[ID_28775\]

From now on, the *DMS.xml* file also supports using hostnames instead of IP addresses.

#### Dashboards app: Profile parameters can now also be included when grouping parameters on component level \[ID_28786\]

Up to now, when parameters were grouped in a line chart, trend statistics or parameter state component, profile parameters would not be included.

From now on, due to a number of enhancements, it is also possible to include profile parameters when grouping parameters on component level.

#### Elasticsearch: Alarm will now be generated when Elasticsearch goes into read-only mode \[ID_28821\]

When disk usage exceeds 90 percent on a server running an Elasticsearch database, the database will go into read-only mode. Up to now, when that happened, only an entry was added to the logs. From now on, also an alarm will be generated.

#### Trending: Trend values will now be rounded after being retrieved from the database \[ID_28840\] \[29758\]

Up to now, trend data values were rounded before being stored in the database. From now on, those values will only be rounded after being retrieved from the database, i.e. before being returned to the client.

#### SLAnalytics will now add a log entry when it goes into or out of flood mode \[ID_29039\]

When SLAnalytics detects a sudden rise in the amount of data to be processed, it will temporarily halt all processing and go into flood mode. Up to now, when going into flood mode, it would generate an alarm of type “notice”. Now, instead of an alarm, it will add an entry to the SLAnalytics log file.

A similar entry will be added to the log file when SLAnalytics goes out of flood mode.

#### Improved error logging during upgrades \[ID_29066\]

Error logging during DataMiner upgrades has been improved, so that the logging contains more information in some specific cases.

#### DataMiner Cube: Improved layout when Alarm Console is displayed as overlay \[ID_29108\]

When the alarm bar is clicked once so that the Alarm Console is displayed as an overlay, a shadow effect will now indicate that is it shown above the rest of the Cube UI. In addition, the icons in the Cube sidebar will now no longer move when the Alarm Console is displayed as an overlay.

#### Service & Resource Management: Enhanced loading of Resource Manager module \[ID_29144\]

Because of a number of enhancements, overall performance has increased when the Resource Manager module is loaded at startup.

#### DataMiner Cube - Services app: Validation of service profile definition names and service profile instance names is now consistent with the name validation routines used in the other SRM apps \[ID_29155\]

In the Services app, the validation of service profile definition names and service profile instance names has now been made consistent with the name validation routines used in the other SRM apps (e.g. Profiles, Resources, Functions, etc.).

#### NATS connection timeout can now be configured \[ID_29172\]

In the *SLCloud.xml* file, the timeout of the NATS server connection can be now specified in the \<ConnectTimeout> element. Minimum value (in milliseconds): 1000

If this element contains a value lower than 1000 or a non-numeric value, that value will be ignored and an error will be logged in the SLMessageBroker.txt file.

#### Live Sharing service now supports both HTTP and HTTPS connections \[ID_29219\]

The Live Sharing service now supports both HTTP and HTTPS connections.

#### SLAnalytics: Enhanced accuracy of proactive cap detection and behavioral anomaly detection \[ID_29255\]

Because of a number of enhancements made to the way in which history set parameter updates are processed, overall accuracy of the proactive cap detection and behavioral anomaly detection features has increased.

#### Service & Resource Management: Enhanced performance when cloning ReservationInstances during quarantine checks \[ID_29408\]

Because of a number of enhancements with regard to the cloning of ReservationInstances, overall performance has increased when performing quarantine checks

#### Web apps: All timespan controls now support timespan grouping \[ID_29441\]

All timespan controls of all web apps (e.g. Monitoring, Jobs, Ticketing, Dashboards, etc.) now support timespan grouping.

#### DataMiner Cube - Visual Overview: Enhanced performance when loading and sorting children shapes \[ID_29448\]

Because of a number of enhancements, overall performance has increased when children shapes are loaded and sorted.

#### DataMiner Cube - Trending: Trend legend enhancements \[ID_29477\]

A number of enhancements have been made to the trend legend:

- The trace and current values will now have tooltips. Hovering over one of those tooltips will reveal the full value, and when there is insufficient space, the value will be ellipsed.
- Trace values will no longer have trailing zeros cut off when that precision is available, which will improve readability.
- The current values will have a thousand separator where necessary.

#### Improved SLNet startup performance due to DNS lookup enhancements \[ID_29522\]

Because of a number of DNS lookup enhancements, SLNet startup performance has increased.

#### Dashboards app: Enhanced performance when opening a dashboard \[ID_29548\]

Overall performance has increased when a dashboard is opened.

When you opened a dashboard, up to now, its edit panel would already be loaded in the background. From now on, the edit panel will only be loaded when you enter edit mode.

#### DataMiner Cube - Visual Overview: Service child shapes will now be updated instead of recreated when a dynamic part changes \[ID_29568\]

When a series of service child shapes contained a dynamic part (e.g. ChildrenFilter, ChildrenSource, etc.), up to now, all those child shapes would be recreated each time one of those dynamic parts changed. From now on, when a dynamic part changes, the child shapes will be updated instead of being recreated.

#### SLNet will now start up asynchronously in a background thread \[ID_29633\]

From now on, SLNet will start up asynchronously in a background thread.

#### Dashboards app - GQI: Enhanced performance when executing queries due to ability to detect redundant operations \[ID_29636\]

GQI is now able to detect any redundant operations contained within a query. As a result, overall performance has increased when executing queries.

#### Dashboards app - State component: Enhanced auto-size behavior \[ID_29654\]

When, in the *Layout* tab of the State component, you select “Auto size” in the *Advanced \> Style* section, an attempt will now always be made to fill up the entire component area with the information to be displayed.

Also, a number of other enhancements have been made with regard to auto-sizing.

#### SLDMS.xml will no longer be refreshed each time SLDataMiner.xml is updated \[ID_29664\]

Up to now, each time *SLDataMiner.xml* was updated, *SLDMS.xml* would also be refreshed. From now on, this will no longer happen.

#### 'Number of backups to keep' setting will now also apply to the number of Elasticsearch backups \[ID_29702\]

In the *Backup* section of *System Center*, you can indicate the number of backups that have to be kept on disk. This setting will now also apply to the number of Elasticsearch backups.

> [!NOTE]
> Whether DataMiner will be able to delete older Elasticsearch backups stored on a network path will depend on the permissions granted to the account used to access that path.

#### Mobile Gateway: Enhanced performance when sending text messages \[ID_29729\]

Because of a number of enhancements, overall performance has increased when text messages are sent.

#### SLDMS will now perform DNS lookups using 'getaddrinfo' instead of 'gethostbyname' \[ID_29740\]

From now on, SLDMS will perform DNS lookups using the getaddrinfo function instead of the deprecated gethostbyname function.

#### Ongoing spectrum recording will now automatically be saved when the session is closed \[ID_29843\]

When a spectrum session is closed while a recording is in progress, from now on, the recording will automatically be saved to the user’s folder in *C:\\Skyline DataMiner\\Users*.

#### Additional logging for actions in SRM modules \[ID_29924\]

Additional information will now be logged in the *SLClient.txt* log file for the following SRM modules:

- Functions (currently only available in soft launch)
- Profiles
- Services
- Resources
- Bookings

The following information will be logged

- The time when a module has been launched by a user.
- The time that is needed to load a module after it is launched, including the initialization, the fetching of data from the server, and the creation of module data.
- The duration of each server call, including the message, the interval, and the filter used in the request, if any. The following server calls are taken into account for this:

  - Resource helper: Retrieving a resource, resource pool, booking definition, or booking instance.
  - Service helper: Retrieving a service definition, service state, or information.
  - Function helper: Retrieving a virtual function, or protocol metadata.

#### Dashboards app - GQI: Enhanced performance when processing GQI query results \[ID_29977\]

Because of a number of enhancements, overall performance has increased when GQI query results are processed.

#### Service & Resource Management: Enhanced error message when a referenced resource capability does not exist \[ID_30065\]

When you created a ReservationInstance that referenced a non-existing capability of an existing resource, up to now, the following error message of type “ResourceCapabilityInvalid” would be displayed:

```txt
Could not find the profile with capability parameter {oneCapabilityUsage.CapabilityProfileID}.
```

From now on, the following error message will be displayed instead:

```txt
Could not find capability parameter {oneCapabilityUsage.CapabilityProfileID} on resource {resource.ID}.
```

#### Service & Resource Management: Enhanced performance when creating bookings \[ID_30116\]

Because of a number of enhancements, overall performance has increased when bookings are created.

#### DataMiner Cube - Visual Overview: Enhanced child shape loading indicator \[ID_30151\]

A number of enhancements have been made with regard to the loading indicator that is shown while automatically generated child shapes are being loaded.

#### Logging: An entry will no longer by default be added to the SLDataMiner.txt and SLErrors.txt log files when the 'C:\\Skyline DataMiner\\Simulations' folder cannot be found at DataMiner startup \[ID_30168\]

Up to now, at DataMiner startup, the following entry would by default be added to the *SLDataMiner.txt* and *SLErrors.txt* log files when no *C:\\Skyline DataMiner\\Simulations* folder could be found:

```txt
CDataMiner::LoadSimulations|ERR|0|Failed to query directory 'C:\Skyline DataMiner\Simulations' with filter 'Simulation_*.xml' (The system cannot find the path specified.).
```

From now on, such entries will no longer by default be added to the above-mentioned log files at DataMiner startup.

#### Service & Resource Management: Enhanced performance when creating bookings \[ID_30209\]

Because of a number of enhancements, overall performance has increased when bookings are created, especially in situations with a large number of overlapping bookings that use a large number of resources.

#### Service & Resource Management: Enhanced performance when adding and updating function resources \[ID_30280\]

Because of a number of enhancements, overall performance has increased when function resources are added or updated, especially when a large number of resources are added on the same parent element.

#### Cassandra cluster: SLA tables now stored in one table \[ID_30369\]

If one Cassandra cluster database is used for the entire DMS, the SLA database tables will now all be stored in one table instead of in a table per SLA. This will improve the performance of Cassandra.

#### Web apps: Enhanced visualization of warnings and errors \[ID_30397\]

A number of enhancements have been made with regard to the visualization of warnings and errors.

#### Enhanced performance of SLNet when managing DVE elements on systems with an offload database \[ID_30439\]

Because of a number of enhancements, overall performance of SLNet has increased when managing DVE elements on systems with an offload database.

#### Profile Manager: Objects added, updated or deleted in bulk will now be grouped into one single event \[ID_30465\]

When profile parameters, profile instances or profile definitions are added, updated or deleted in bulk, from now on, a single event listing all objects will be sent. Up to now, a separate event would be sent for every object.

To prevent events from getting too large, the maximum amount of objects listed in one event has by default been set to 100. Events that contain more than 100 objects will be split into multiple events.

Also, due to a number of enhancements, overall performance has increased when deleting profile objects in bulk.

#### DataMiner Cube - Alarm Console: Enhanced correlation mechanism \[ID_30481\]

Because of a number of enhancements, overall performance of the correlation mechanism has increased, especially when generating Correlation alarms with a large number of sources.

#### DataMiner Cube: Enhanced performance of Booking Manager and Resource Manager \[ID_30483\]

In DataMiner Cube, the Resource Manager and the Booking Manager always run side by side. Up to now, when the Booking Manager was being used, in some cases, data would also be requested from the Resource Manager. A number of enhancements have now been made to prevent this. As a result, overall performance of both the Booking Manager and the Resource Manager has increased.

#### Profiles module: Parameter list improvements \[ID_30530\]

A number of small improvements have been implemented to the list of parameters in the Profiles module:

- When you open the list of parameters, by default no parameter will be selected.
- When you create a new parameter, that parameter is automatically selected.
- It is now possible to search for a parameter in the list by typing its first characters.

#### Dashboards app - GQI: Columns will now be referred to by their unique ID instead of by their display name \[ID_30568\] \[ID_30870\] \[ID_30970\]

In GQI queries, up to now, columns would be identified by their display name. From now on, they will be identified by a unique ID instead.

Each time a user opens a dashboard, any existing GQI queries in table or node edge components on that dashboard referring to columns by display name will be adapted on the fly. When such a dashboard is opened by a user who is allowed to edit dashboards, the adaptation will be saved so that the dashboard will no longer have to be adapted the next time it is opened.

#### Improved logging in case encrypted password in DB.xml cannot be retrieved \[ID_30614\]

If a password is encrypted in DB.xml, but for some reason (e.g. syncing issue) DataMiner is unable to retrieve it, this will now be indicated more clearly in the logging.

#### Ticket migration from Cassandra to Elasticsearch: Notice generated when unsupported characters are found in TicketFieldDescriptors \[ID_30624\]

When unsupported characters are found in TicketFieldDescriptors at the start of a ticket data migration from Cassandra to Elasticsearch, from now on,

- a notice with a link to a “known issues” Dojo article will be generated,
- an entry listing the invalid TicketFieldDescriptors will be added to the SLMigrationManager.txt log file, and
- the migration will be aborted.

See also: [Migration of Ticketing data from Cassandra to Elasticsearch fails](xref:KI_Migration_of_Ticketing_data_from_Cassandra_to_Elasticsearch_fails)

#### Web apps: Notification when reconnect happens in background \[ID_30628\]

When a reconnect happens in the background in the DataMiner web apps, a notification will now be displayed to inform the user.

#### DataMiner Cube - Alarm grouping: Enhanced performance when updating large alarm groups and when grouping alarms using correlation rules \[ID_30670\]

Due to a number of enhancements, overall performance has increased when updating large alarm groups and when grouping alarms using correlation rules.

#### SLAnalytics: pollingtime values in ParameterInfo records can no longer be equal to zero \[ID_30729\]

In a Cassandra database, from now on, pollingTime values in ParameterInfo records will no longer be allowed to be equal to zero. pollingTime values between 0 and 1 seconds will automatically be updated to 1 before they are stored in the database.

#### SAML authentication enhancements \[ID_30749\]

A number of enhancements have been made with regard to SAML authentication.

Also, DataMiner now supports SAML authentication via Okta.

#### Communication between SLNet and SLAnalytics will now use NATS \[ID_30761\]

Communication between SLNet and SLHelper will now use NATS instead of .NET remoting.

#### Dashboards app - GQI: Enhanced performance when fetching trend statistics \[ID_30783\]

Because of a number of enhancements, overall performance has increased when trend statistics are fetched.

#### Automation: Enhanced performance when retrieving large amounts of data via managed DataMiner modules \[ID_30816\]

Because of a number of enhancements, overall performance has increased when large amounts of data are retrieved via managed DataMiner modules like SLManagedAutomation or SLManagedScripting.

#### Communication between SLNet and SLHelper will now use NATS \[ID_30845\]

Communication between SLNet and SLHelper will now use NATS instead of .NET remoting.

#### Improved performance when writing and deleting data on Cassandra clusters \[ID_30860\]

Performance has improved for all write and delete queries on Cassandra clusters. This applies to all data handled by the SLDataGateway process, including alarms, trending, element data, etc.

#### Deprecated web pages have been removed \[ID_30877\]

The following web pages have been removed as they are related to deprecated features:

```txt
http://<DMA>/Tools/CustomerLogoCheck.asp
http://<DMA>/Weather/VerifiyWeathericon.html
http://<DMA>/Weather/WeatherIcon.aspx
```

#### Cassandra: Enhanced handling of unsuccessful connection attempts \[ID_30893\]

When SLDataGateway fails to connect to the Cassandra database, from now on, an exception will be thrown after a configured number of connection retries (default: 60).

#### Response that caused an exception will now be added to the text of the exception \[ID_30919\]

When an exception is thrown, from now on, the response that caused the exception will be added to the text of the exception.

#### DataMiner Cube - Router Control: Enhanced highlighting of IO buttons \[ID_30949\]

A number of enhancements have been made to the Router Control app with regard to IO button highlighting.

- When you connected an input to an output with multiple connections to other inputs and the “output first workflow” option was enabled, in some cases, those other connected inputs would no longer be highlighted. From now on, inputs connected to an output will no longer lose their highlighting when you connect a new input to that same output.
- When you selected an input of a matrix that did not have the “output first workflow” option enabled, up to now, the connected outputs would not be highlighted. From now on, these will be highlighted.

#### DataMiner backup: User-generated dashboards now included in 'Configuration Backup' & 'Configuration Backup without Database' \[ID_30957\]

From now on, user-generated dashboards will by default be included in the following types of backups:

- Configuration Backup
- Configuration Backup without Database

#### DataMiner backup: Process Automation data now included in 'Full Backup' \[ID_30999\]

From now on, Process Automation data will be included in the following types of backups:

- Full backup
- Custom backup with “Create a backup of the database” and “Include Process Automation data in backup” options enabled
- Backup via the StandaloneElasticBackup tool

#### DataMiner Cube: Enhanced performance when loading large bookings \[ID_31097\]

Because of a number of enhancements, overall performance has increased when large bookings are loaded.

#### DataMiner upgrade packages will now include Microsoft .NET Framework 4.8 \[ID_31120\]

From now on, DataMiner upgrade packages will include Microsoft .NET Framework 4.8, which will be installed automatically on servers on which it has not yet been installed earlier.

> [!NOTE]
> If Microsoft .NET Framework 4.8 had to be installed during the DataMiner upgrade, the DataMiner Agent will automatically be rebooted.

#### SLAnalytics - Automatic incident tracking: Enhancements \[ID_31123\]

A number of enhancements have been made to the automatic incident tracking feature, especially with regard to alarm group management.

#### SLAnalytics - Behavioral anomaly detection: Enhancements \[ID_31151\]

A number of enhancements have been made to the behavioral anomaly detection feature, especially with regard to overall performance during startup or when restarting.

#### SLAnalytics: Enhanced creation and clearance of notice events \[ID_31199\]

Notice events will now be generated to inform users in case of reduced accuracy of an SLAnalytics feature due to e.g. a high CPU, database or memory load. Those events will then automatically be cleared as soon as the CPU, database or memory load drops to a normal level.

Other changes:

- The pattern matching notice events that inform users when the memory limit has been reached will now be cleared as soon as memory usage drops below the limit.
- A notice event will now also be generated when the number of trended numeric parameters is too high to be monitored by behavioral anomaly detection and proactive cap detection. The maximum number of parameters that can be monitored by those features is 100,000. When this limit is reached, the rest of the parameters will be ignored.

#### Cassandra: Enhanced performance when writing data to the database \[ID_31361\]

Because of a number of enhancements, overall performance has increased when data is written to a Cassandra database.

#### Enhanced performance when retrieving alarms and information events from the database \[ID_31494\]

Due to a number of enhancements, overall performance has increased when retrieving alarms and information events from the database.

#### DataMiner Cube: Enhanced performance when shutting down \[ID_31543\]

Because of a number of enhancements, overall performance of DataMiner Cube has increased when shutting down, especially when connected to a DataMiner System with an Elasticsearch database.

#### NATS will now be installed during a DataMiner upgrade and re-installed during a factory reset \[ID_31568\]

When it has not yet been installed, NATS will now be installed during a DataMiner upgrade, and it will also be automatically re-installed when performing a factory reset using *SLReset.exe*.

Also, when NATS is uninstalled, the *SLCloud.xml* file will now be deleted.

#### Reports & Dashboards: Enhanced generation of PDF reports \[ID_31582\]

PDF reports will now be generated by a new PDF engine.

All reports will now have a new header and footer. Also, reports created by the legacy Reporter app will no longer have bookmarks and will now have a page number in the footer.

#### DataMiner Cube - Booking app: Enhanced layout of booking blocks in timeline area \[ID_31663\]

In the timeline area of the Bookings app, the layout of the blocks that represent bookings has been enhanced.

#### Dashboards: Improved GQI performance with alarms data source \[ID_31708\]

Performance has improved in case a dashboard contains a query data feed (GQI) using alarms as its source.

#### DataMiner Cube: Enhanced performance when logging in and when opening the Protocols & Templates app \[ID_31709\]

Because of a number of enhancements, overall performance has increased during login and when the *Protocols & Templates* app is opened, especially in SRM systems.

#### Visual Overview: Variables not cleared when booking is no longer selected \[ID_31772\]

In Visual Overview, when you select a booking, the *SelectedReservation*, *SelectedReservationDefinition*, *ResourcesInSelectedReservation* and *TimerangeOfSelectedReservation* variables are filled in automatically. However, these should also be cleared again when you clear the selection, and it could occur that this did not happen.

#### DataMiner Cube - System Center: Enhanced Failover configuration window \[ID_31787\]

In the *Agents* section of *System Center*, a number of enhancements have been made to the Failover configuration window.

- The *OK* and *Cancel* buttons have been replaced by *Apply* and *Close* buttons.
- The *Apply* button will only be enabled when changes have been made to the configuration.
- In the configuration window, you will only be allowed to perform one action: switch or apply.
- After you have performed an action, the window will not close automatically. Instead, it will show a message.

#### CefSharp library loaded primarily from MSI installation folder \[ID_31838\]

To download the CefSharp library, DataMiner Cube will now look in the following locations, in the order specified below:

- The location defined in a registry key created by the Cube MSI installation (*HKLM\\SOFTWARE\\Skyline Communications\\DataMiner Cube\\InstallDir*), by default *C:\\Program Files\\Skyline Communications\\DataMiner Cube*
- *%LocalAppData%\\Skyline\\DataMiner*
- *%ProgramData%\\Skyline\\DataMiner*

#### Enhanced logging when importing groups from Azure AD \[ID_31917\]

From now on, more detailed logging will be added to *SLErrors.txt* when groups are being imported from Azure AD.

#### DataMiner Cube - Service & Resource Management: Enhanced performance when opening a visual overview of a service linked to a booking and when updating a bookings list \[ID_32054\]

Because of a number of enhancements, overall performance has increased when opening a visual overview of a service linked to a booking and when updating a bookings list.

#### Enhanced performance when loading domain users from Azure AD \[ID_32077\]

Due to a number of enhancements, overall performance has increased when loading domain users from Azure AD.

#### DataMiner Cube - Services app: Enhanced performance \[ID_32082\]

Due to a number of enhancements, overall performance has increased when opening the Services app and when updating data in the services list.

#### Embedded Chromium web browser engine updated to v96 \[ID_32194\]

The embedded Chromium web browser engine in DataMiner Cube has been updated from v81 to v96. This also updates the engine used to generate PDF reports and prevents a possible issue where browser controls would stop rendering after a switch between card tabs.

In addition, when Cube downloads and installs the Chromium engine from the DMA, it will now verify the integrity of the download file.

#### DataMiner Cube - Resources app: Enhanced performance when loading the resource pools and resources \[ID_32211\]

Due to a number of enhancements, overall performance has increased when loading all resource pools and resources after opening the Resources app.

#### Elasticsearch: Enhanced data retrieval \[ID_32240\]

A number of enhancements have been made with regard to the retrieval of data stored in Elasticsearch databases.

#### Failover: Enhanced logging \[ID_32265\]

Failover logging has been reviewed. All relevant logging related to switching and Failover setup was moved to INF\|0, ERR\|0 or CRU\|0.

#### Dashboards app: Enhanced performance when retrieving parameter data from elements and services \[ID_32340\]

Due to a number of enhancements, overall performance has increased when retrieving parameter data from elements and services.

#### NATS cluster will now update itself automatically \[ID_32424\]

When a DataMiner Agent joins or leaves an existing DataMiner System or when a Failover configuration is set up or ended, from now on, the NATS cluster will automatically update itself.

### Fixes

#### Problem when deleting an element that had data stored in Elasticsearch \[ID_27663\]

When you deleted an element that had data stored in an Elasticsearch database (e.g. a logger table), in some cases, this would cause errors in other elements that shared data with the element you deleted.

#### Incorrect error message when uploading a protocol with a minimum required version \[ID_27868\]

When you uploaded a protocol of which the Protocol.Compliancies.MinimumRequiredVersion element contained a DataMiner version onto a DataMiner Agent with an older version, in some cases, DataMiner would either throw the incorrect error message “No license for the encrypted protocol found” or no error message at all.

#### Problem with \<SkipCommitLog> option in DB.xml \[ID_27969\]

If you want to optimize the writing speed to a Cassandra database, in the *DB.xml* file, you can specify the \<SkipCommitLog> option to skip the writing of the commit log. However, in some cases, this would no longer work.

#### DataMiner Cube desktop app: Assembly load errors \[ID_28059\]

Certain DLL files would cause assembly load errors to get added to the log file of the DataMiner Cube desktop app.

#### DataMiner Cube - Profiles app: Service profile instance selection box empty after editing profile instance \[ID_28084\]

When you changed both the profile definition and the service profile instance when editing a profile instance, after saving, the service profile instance selection box would be empty, although the data was saved correctly.

#### Dashboards app - Line chart component: Three value columns instead of one in CSV with exported real-time trend data \[ID_28090\]

When you exported real-time trend data to a CSV file, that file would incorrectly have three value columns (avg, min, max). From now on, when you export real-time trend data, the CSV file will only have one value column.

#### DataMiner Cube - Alarm Console: Problem when retrieving alarms that contain metadata \[ID_28118\]

In some cases, an exception could be thrown when retrieving alarms that contain metadata.

#### DataMiner Cube: Problem when connecting to a large system with alarm storm prevention enabled \[ID_28127\]

When, on a large DataMiner System, alarm storm prevention was enabled, in some cases, Cube could freeze when you tried to connect.

#### DataMiner Cube - Trending: Incorrect datetime value sent to the pattern matching engine \[ID_28166\]

In some cases, DataMiner Cube would sent an incorrect datetime value to the pattern matching engine.

#### Monitoring app: Incorrect card opened after clicking service in the list of services \[ID_28215\]

When, in the Monitoring app, you opened a view that contained services, clicked Below this view \> Services, and then clicked one of the listed services, in some cases, an incorrect card would be opened.

#### SLAnalytics: Problem at startup \[ID_28258\]

In some cases, an error could occur in SLAnalytics at startup.

#### Ticketing app: Date filters would incorrectly use dates in local time instead of UTC time \[ID_28267\]

In the Ticketing app, in some cases, the date filters would incorrectly use dates in local time instead of UTC time.

#### Jobs app: Clicking Time \> Now in the date picker would set the time in an incorrect time zone \[ID_28274\]

When you clicked *Time \> Now* in the date picker while creating a new job, in some cases, the time would incorrectly be set in the time zone of the server instead of that of the client.

Also, a number of other issues regarding time zone settings were fixed.

#### Dashboards app: Problem with indices selection of parameter feed component \[ID_28309\]

When a dashboard containing a parameter feed component was refreshed or when a report was generated based on such a dashboard, in some cases, it could occur that the selection of parameter indices was no longer correct

#### Dashboards app: Folder content not scrollable \[ID_28321\]

In the Dashboards app, in some cases, it would not be possible to scroll through the contents of a dashboard folder.

#### DELT export packages would incorrectly not contain logger table data stored in Elasticsearch \[ID_28413\]

When you exported an element containing a logger table that saved its data in an Elasticsearch database, in some cases, the export package would not contain the data that was saved in the Elasticsearch database.

#### SLAutomation would incorrectly be initialized twice \[ID_28416\]

In some cases, SLAutomation would incorrectly be initialized twice.

#### Dashboards app: Error when deleting components \[ID_28426\]

When a dashboard component was deleted, in some cases, the following error could occur:

```txt
Cannot read property 'Data' of undefined'.
```

#### Problem during DataMiner startup when all nodes of an Elasticsearch database were down \[ID_28443\]

When an Elasticsearch database was configured in the *DB.xml* file, in some cases, an error could occur during DataMiner startup when all node of that database were down.

#### DataMiner Cube - Failover: Default SLAnalytics settings would incorrectly always be used \[ID_28471\]

In a Failover system, SLAnalytics would incorrectly always use the default DataMiner Cube SLAnalytics settings. Any updates to those settings would be disregarded.

#### Dashboards app - Line chart component: Parameter header not displayed when only one parameter was selected \[ID_28486\]

When, in a line chart component, only one parameter was selected, in some cases, the parameter header would not be displayed.

#### Dashboards app - Line chart component: Problem with 'Expand legend initially' option \[ID_28487\]

When you refreshed a line chart component that had the “Expand legend initially” option selected, in some cases, the legend would incorrectly not be expanded.

#### Dashboards app: Components not displayed when embedded \[ID_28492\]

In some cases, dashboards components would not be displayed when embedded in e.g. Visual Overview.

#### Dashboards app: Dummy EPM columns displayed \[ID_28495\]

In an EPM Manager driver, it is possible to mark certain columns as dummy columns. Up to now, the Dashboards app would incorrectly display those dummy columns.

#### Dashboards app: Problem when trying to select a folder after manually removing it from the Location box of the Create dashboard window \[ID_28533\]

When, in the *Create dashboard* window, you selected a folder and then removed it manually from the *Location* box, in some cases, it would no longer be possible to select the same folder in the folder tree.

#### Dashboards app - GQI: Problem when retrieving data for a table parameter without using a column filter \[ID_28534\]

In some cases, an exception could be thrown when using an inter-element query to retrieve data for a table parameter without using a column filter.

#### Dashboards app: Duplicated dashboard used default theme instead of original theme \[ID_28552\]

When you duplicated a dashboard, the newly created dashboard would incorrectly use the default dashboard theme instead of the theme used by the original dashboard.

#### Dashboards app: Problem when sharing a dashboard located in a folder \[ID_28610\]

When you wanted to share a dashboard using the Live Sharing Service, in some cases, a parsing error could occur when that dashboard was located in a dashboard folder.

#### Dashboards app: Image representing a moved dashboard could not be found \[ID_28661\]

When you moved a dashboard from one folder to another, and then selected the destination folder, in some cases, the image representing the dashboard you moved could not be found.

#### Empty cluster tag in NATS configuration file \[ID_28663\]

In some cases, the NATS configuration file would incorrectly have an empty cluster tag.

#### Automation: Problem when ejecting of pre-compiled library \[ID_28665\]

In some cases, an exception could be thrown when a library DLL was ejected.

#### Problem when retrieving trend data from a column of a view table based on another view table \[ID_28677\]

In some cases, it was not possible to retrieve trend data from columns of a view table that was based on another view table.

When trend data has to be retrieved from a column of a view table that is based on another view table, another column in that same view table has to have the VIEWTABLEKEY option defined.

#### Uninstalling DataMiner Cube did not remove EXE file \[ID_28704\]

When you uninstalled DataMiner Cube, in some cases, the EXE file would not be removed from the %localappdata%\\Skyline\\DataMiner\\DataMinerCube folder.

#### Dashboards app: Component configuration changes not saved \[ID_28720\]

When, in the Dashboards app, you had made a change to the configuration of a component, in some cases, that change would not get saved.

#### DataMiner Cube desktop app: Problem when started with the '/Hostname=xyz' command line argument \[ID_28774\]

When you started the DataMiner Cube desktop app with the “/Hostname=xyz” command line argument, in some cases, an error could occur when its configuration file was empty or could not be found.

#### Dashboards app: Feeds section of edit pane’s Data tab incorrectly listed feeds using the component names \[ID_28779\]

When you added a feed component to a dashboard (e.g. a drop-down feed) and gave it a title, in the Feeds section of the edit pane’s Data tab, the feed would incorrectly have the name you gave to the component instead of the actual name of the feed.

#### DataMiner Cube: Desktop app could no longer be installed from the landing page \[ID_28802\]

In some cases, it was no longer possible to install the DataMiner Cube desktop app from the DataMiner landing page.

#### Dashboards app: Problem when all data was removed from a table column parameter that acted as data source for a Gauge, Ring or State component \[ID_28806\]

When a Gauge, Ring or State component had a table column parameter as data source, in some cases, an error could be thrown when, in DataMiner Cube, all data was removed from that table.

#### Dashboards app - Line chart component: Problem with the 'Minimum visible gap size' setting \[ID_28810\]

When, while configuring a line chart component, you opened the selection box containing the values of the *Minimum visible gap size* setting, in some cases, that selection box would not be displayed correctly.

#### Dashboards app: Sorting issues \[ID_28850\]

In the Dashboards app, in some cases, table columns would be naturally sorted by display value instead of raw value, resulting in an incorrect order when using dynamic units or a numeric format with spaces.

Also, in the GQI query builder, in some cases, the default columns would be sorted incorrectly when using the “Select columns” option.

#### Dashboards app: Problem when embedding a GQI dashboard component \[ID_28874\]

When an individual GQI dashboard component was embedded into Visual Overview or a web page, in some cases, the URL of that component would not contain all necessary information to run a GQI query.

#### Problem when saving a job or a DomInstance with a section that referred to a non-existing SectionDefinition \[ID_28908\]

When saving a job or a DomInstance containing a section that referred to a non-existing SectionDefinition, up to now, a NullReferenceException would be thrown.

From now on, an error will be stored in tracedata instead:

- an error of type JobError with reason SectionUsedInJobLinksToNonExistingSectionDefinition, or
- an error of type DomInstanceError with reason SectionUsedInDomInstanceLinksToNonExistingSectionDefinition.

#### DataMiner Cube: Problem when previewing a dashboard containing components running GQI queries \[ID_28939\]

When, in DataMiner Cube, you previewed a dashboard that contained components running GQI queries, in some cases, an error could be thrown.

#### DataMiner Cube: Configuration file of start window corrupted when the start window was closed when the file was being updated \[ID_28949\]

When the DataMiner Cube start window was closed while its configuration file was being updated, in some cases, that configuration file could get corrupt.

> [!NOTE]
> In the configuration file of the DataMiner Cube start window, the minimum log level can now be configured.
> Possible log levels: 0 = Verbose, 1 = Debug, 2 = Information, 3 = Warning, 4 = Error, 5 = Fatal

#### SLAnalytics - Automatic incident tracking: Incorrect error messages when the timer switched to the next hour while there are active alarms of type 'Property changed' \[ID_28968\]

When there were active alarms of type “Property changed” when the timer switched to the next hour, in some cases, automatic incident tracking would generate incorrect error messages.

#### DataMiner Cube: Problem when opening start window from the system tray \[ID_29054\]

In some rare cases, an exception could be thrown when opening the DataMiner Cube start window from the Windows system tray.

#### DataMiner Cube start window: Configuration file cleared \[ID_29080\]

When the DataMiner Cube start window was closed, in some rare cases, the configuration file of that start window would incorrectly be cleared.

#### Description of proactive cap detection setting in System Center corrected \[ID_29096\]

A typo has been corrected in the description for the proactive cap detection settings in System Center.

#### DataMiner Cube: New DMS not saved in start window configuration \[ID_29151\]

When the Cube start window was not running in the system tray, and you added a DMS and then immediately connected to it, it could occur that the new DMS was not saved in the start window configuration.

#### SLAnalytics: Problem when calculating a trend prediction for a parameter with missing trend data \[ID_29163\]

In some cases, an error could occur in the SLAnalytics process when a trend prediction was calculated for a parameter with missing trend data.

#### SRM module not starting after Failover switch \[ID_29169\]

In some rare cases, after a Failover switch, it could occur that an SRM module could not be started.

#### Dashboards app: Multiple pop-up windows displayed when Automation script could not be opened \[ID_29218\]

When the Dashboards app tried to open an Automation script that had been renamed or removed in DataMiner Cube, in some cases, a series of pop-up windows would be displayed. From now on, when the Dashboards app cannot open an Automation script, a single pop-up window will be displayed.

#### Suggestion indices not deleted when an Elasticsearch logger table without custom naming was deleted \[ID_29223\]

When an Elasticsearch logger table without custom naming was deleted, the suggestion indices would incorrectly not get deleted.

#### Dashboards app - Pivot table component: Problem when adding indices \[ID_29253\]

When indices were added to a pivot table component, in some cases, the component would not get updated correctly and a spinner icon would appear in its Settings tab.

#### Failover: Exception thrown because of issue caused by PowerShell \[ID_29263\]

In Failover systems, in some cases, a PowerShell problem could cause an exception to be thrown.

#### Problem with SLNet when correlation details were requested for alarm groups \[ID_29265\]

In some cases, an error could occur in SLNet when correlation details were requested for alarm groups.

#### Cassandra: Problem creating the timetrace table when upgrading from an older DataMiner version \[ID_29319\]

In some cases, an error could occur when the timetrace table was created when upgrading from an older DataMiner version (e.g from version 10.0.0 to 10.1.4).

#### Interactive Automation scripts: 'continue script' action triggered after the script had already been detached \[ID_29357\]

In some rare cases, a “continue script” action could incorrectly be triggered after the script in question had already been detached.

#### Jobs app: Fields in newly created copy of a section definition would have an incorrect field type \[ID_29387\]

When you copied a section definition from one job domain to another, in some cases, fields in the newly created section definition would have an incorrect field type.

#### Service & Resource Management: VirtualFunctionResource could not be bound with the same index as another VirtualFunctionResource \[ID_29403\]

In some cases, it was not possible to bind a VirtualFunctionResource when another VirtualFunctionResource was already bound to a different entrypoint table with the same index.

#### SLAnalytics: Problem with automatic incident tracking when a parent of a particular view could not be found \[ID_29419\]

In some cases, an error could occur during automatic incident tracking when a parent of a particular view could not be found.

#### Dashboards app - GQI: Problem when rebuilding a query \[ID_29468\]

In some cases, a query would not get rebuilt correctly after being edited, especially when it contained nodes that were linked to feeds.

#### Dashboards app - Time range feed: Value passed along incorrectly when 'Use quick picks' option was selected \[ID_29471\]

When the “Use quick picks” option was selected, a time range feed would pass along the selected value incorrectly.

Also, custom quick picks would disappear when reloading the dashboard, and when the “Allow refresh” option was selected, the feed would not correctly update the linked trend graph when the refresh counter was reset.

#### Dashboards app - GQI: Inconsistent column order when 'select' or 'get parameters' nodes were linked to a feed \[ID_29479\]

When the “Select” or “Get parameters for element where” nodes of a query were linked to a feed, in some cases, the order of the selected parameter columns would not be consistent with the feed selection.

From now on, the default columns will always come first, followed by the items supplied by the feed.

#### Serial communication: Problem when multiple potential responses were defined in a serial pair \[ID_29496\]

When multiple possible responses were defined in a serial pair, the responses after the first response potentially would not match the received data when header and trailer parameters were not identical.

In the following example, a pair has three responses defined (100, 101, and 102), of which one is expected to match the received data. When the headers and trailers of responses 101 and 102 were identical to those of response 100, the data was matched as expected. However, when the header or trailer was not identical, then a match could be missed for response 101 and 102.

```xml
<Pair id="100">
  <Name>Pair 100</Name>
  <Content>
    <Command>100</Command>
    <Response>100</Response>
    <Response>101</Response>
    <Response>102</Response>
  </Content>
</Pair>
```

#### Cassandra: Incorrect health status \[ID_29502\]

In some cases, the Cassandra health status was incorrect.

#### Web apps: Numeric values in text boxes would be clipped \[ID_29506\]

In some cases, numeric values in text boxes would be clipped.

#### Dashboards app: Strings containing decimal values would be sorted incorrectly \[ID_29512\]

In some cases, strings containing decimal values would be sorted incorrectly.

#### Monitoring app & Dashboards app: Problem with alarm severity counters \[ID_29561\]

In both the Monitoring app and the Dashboards app, after a number of alarm updates had been processed, the alarm severity counters would indicate an incorrect number of alarms.

#### DataMiner Cube - Trending: Problem when exporting average trend data of a trend graph with multiple lines \[ID_29579\]

When you tried to export the average trend data of a trend graph with multiple lines, in some cases, the export operation would fail. The “retrieving data” notice would not disappear and the export file would not get created.

#### Dashboards app - GQI: Filters unnecessarily sent along with SLNet calls \[ID_29583\]

When a GQI query contains a filter to be applied to e.g. a parameter table, then that filter will be sent along with the SLNet call to allow SLElement to apply the filter for performance reasons. However, in some cases, a filter would also be sent along with the SLNet call when this was not applicable (e.g. when there was a join or aggregation operation between the filter and the data source).

#### Elasticsearch: Problem with postfilters \[ID_29602\]

When a client requested data from an Elasticsearch database with a filter, in some cases, an incorrect result set would be returned because the postfilter would incorrectly apply a filter in local time on a field formatted in UTC time. This issue has now been resolved. Also, from now on, postfilters will only be applied when necessary.

#### GetActiveHysteresisInfoResponseMessage contained entries for elements without alarm data \[ID_29604\]

Up to now, when a GetActiveHysteresisInfoMessage request was sent, the GetActiveHysteresisInfoResponseMessage would contain an entry for every element in the DataMiner Agent, whether it had alarm data or not. From now on, elements without active hysteresis data will be removed from the response.

> [!NOTE]
> GetActiveHysteresisInfoMessage now also contains a constructor that accepts a DataMiner ID. That way, an ID will no longer have to be provided after constructing the object.

#### Dashboards app: Group component not showing all included components \[ID_29630\]

In some cases, a Group component would incorrectly not show all included components. The components that were not shown had no height defined or an error had prevented the styling from being applied correctly.

#### Monitoring app & Dashboards app no longer receiving alarm page updates \[ID_29635\]

In some cases, the Monitoring app and the Dashboards app would no longer receive any alarm page updates.

#### SLAnalytics - Alarm focus: Alarms treated as unexpected when baseline values in alarm template were updated automatically because of use of smart baselines \[ID_29670\]

When a user makes a change to an alarm template, SLAnalytics will treat all alarms of the parameters for which a change was implemented in the alarm template as unexpected. However, in some cases, it would incorrectly act in a similar way when, in case of smart baselines, baseline values were updated automatically.

Also, in some cases, no action would be taken when, in case of smart baselines, alarm template settings of table parameters were changed.

#### Problem when deleting a service by name \[ID_29691\]

When a SetDataMinerInfoMessage was used to delete a service using the service name, in some cases, an exception could be thrown.

#### Interactive Automation scripts: Problem when entering double-digit numbers in input controls \[ID_29736\]

In some cases, because of a problem with the WantsOnChange functionality, it would not be possible to enter a double-digit number (e.g. a number of minutes) in an input control. The interactive Automation script would incorrectly already continue after you entered the first digit.

#### Problem when an interactive Automaton script was detached on closure \[ID_29815\]

In some cases, when an interactive Automation script detached on closure, an exception could be thrown in SLAutomation. From now on, interactive Automation scripts will only detach when they are aborted by a user either closing the popup window or clicking the Abort button.

#### Service & Resource Management: Start of bookings delayed when multiple bookings started at the same time \[ID_29880\]

When multiple bookings started at the same time, and each of those bookings required function DVE elements to be enabled, in some cases, the start of the bookings would be delayed.

#### Dashboards - Table component: Problem with scroll bars when using Firefox \[ID_29892\]

When Mozilla Firefox was used, the table component would show scroll bars even in situations where it was not necessary.

Also, in some cases, columns would not resize correctly.

#### Failover: Cassandra nodes would not be removed from the Cassandra cluster when a Failover configuration was ended \[ID_29894\]

When a Failover configuration was ended, in some cases, the Cassandra nodes would not be removed from the Cassandra cluster. From now on, the Cassandra nodes on the main and the backup agent will each be properly removed from the Cassandra cluster and become single nodes.

> [!NOTE]
> After ending a Failover configuration, it is recommended to check the nodetool status on both nodes to make sure the nodes no longer form a cluster.

#### Dashboards app - GQI: Raw values displayed when grouping row after performing an aggregation \[ID_29904\]

When rows were grouped after an aggregation was performed, raw values would incorrectly be displayed instead of display values.

#### Dashboards app - GQI: Problem when applying a filter to a query that used a 'Get parameters for element where' data source \[ID_29907\]

When a filter was applied to a query that used a “Get parameters for element where” data source, in some cases, the filter would incorrectly only get applied to the rows of one element. The rows of the other elements would all be returned, whether they matched the filter or not.

#### Dashboards app - GQI: Edit pane unresponsive when importing query from one dashboard into another \[ID_29922\]

When you imported a query from one dashboard into another dashboard, in some cases, the edit pane could become unresponsive due to a parsing error.

#### DataMiner Cube - Resources app: Contributing resources not visualized correctly \[ID_30031\]

In the Resources app, up to now, contributing resources were not visualized correctly.

#### Dashboards app: Selection not set in parameter feed \[ID_30092\]

In a parameter feed, in some rare cases, it could occur that the selection was not set.

#### DataMiner Cube - Alarm Console: Problem when using the history slider \[ID_30097\]

On systems with a MySQL database, in some cases, a System.AggregateException could be thrown when the history slider was used in DataMiner Cube.

#### DataMiner Cube desktop app: No DataMiner Systems shown in start window \[ID_30100\]

When the DataMiner Cube desktop app was started, in some cases, the start window would not show any DataMiner Systems.

#### Resources and Services modules also loaded functions that were not active \[ID_30107\]

In the Resources and Services modules, it could occur that functions were loaded even though they were not marked as active, which could cause several functions with the same GUID to be loaded.

#### DataMiner Cube: Missing alarms in Active alarms tab \[ID_30126\]

In some rare cases, after connecting to a busy system, it could occur that alarms were missing in the Active alarms tab in the Alarm Console.

#### DataMiner Cube - EPM: Problem opening an EPM card from an alarm when the 'System Name' alarm property contained a trailing space \[ID_30169\]

When the “System Name” property of an alarm contained a trailing space, in some cases, it would not be possible to open the EPM card from the alarm in question.

#### SLAnalytics: Problem when the connection with SLNet was lost \[ID_30238\]

In some rare cases, an error could occur in SLAnalytics when the connection with SLNet was lost.

#### Dashboards app: 'Loading' bar stayed visible longer than necessary \[ID_30343\]

In some cases, the “Loading” bar, which is visible while the Dashboards app is busy loading all components, would stay visible longer than necessary. From now on, it will disappear immediately after all components have been loaded.

#### Not possible to log in to web app using SAML \[ID_30469\]

In some cases, it could occur that it was not possible to log in to the Dashboards or Monitoring app using SAML.

#### Dashboards app - State timeline: Unclear error message when no parameter index had been specified yet \[ID_30485\]

When you dragged a table parameter onto a state timeline component, up to now, the following error would be visible until you specified a table index:

```txt
Failed getting the timeline data from the DMA agent: Empty server response
```

This error will now be replaced by a message that clearly indicates that the table index is still missing and should be specified.

#### Dashboards app: Query with filter on value discrete parameter not working correctly \[ID_30486\]

If a query in a dashboard was filtered on the value of a discrete parameter, it could occur that the filter was not executed correctly. This happened because the filter used the display value of the parameter instead of the actual value.

#### Dashboards app - Tree feed & Parameter feed: Problem with 'Selected only' option \[ID_30510\]

When you open a dashboard containing a tree feed or a parameter feed with a preset selection in the URL, the “Selected only” option of those feeds is selected by default.

Up to now, when you cleared that option in one of those feeds and then selected other items in the feed, the “Selected only” option would incorrectly be selected again.

#### Profile parameter with mediation snippet incorrectly shown as changed \[ID_30530\]

When a profile parameter with a mediation snippet was loaded initially, it would incorrectly be shown as having unsaved changes.

#### Dashboards app - Parameter feed: Indices of selected items not all selected \[ID_30532\]

When you opened a dashboard containing a parameter feed with a preset selection, in some cases, the indices of the selected items would not all be selected.

#### Profiles module: Discrete capability parameter showed actual values instead of display values \[ID_30533\]

In the Profiles module, if a capability parameter of type Discrete was configured in a profile instance, the drop-down box for this parameter showed the actual discrete values instead of the display values.

#### Insufficient information in exception message in case of invalid characters in dictionary keys \[ID_30602\]

When an exception was thrown because invalid characters were used in dictionary keys, it could occur that the message did not include all invalid characters, but only the string array type name.

#### Automation: Problems with datetime filters in scripts \[ID_30611\]

Several issues have been resolved in case data is retrieved using a datetime filter in a script:

- DataMiner will now translate between UTC and local time when necessary. Previously, data objects could be in UTC time while the filter used local time.
- If *DateTime.Kind* is unspecified, now no action is performed.

#### Problem with SLNet because of unhandled exception \[ID_30626\]

In some rare cases, an unhandled exception could cause a problem in the SLNet process.

#### Service & Resource Management: Property updates overwritten by status updates \[ID_30642\]

When the properties of a ReservationInstance were updated in an asynchronous event script while the end actions were running, in some cases, the end actions could overwrite the updated properties, causing the event script’s property update to fail and throw a “PropertiesAlreadyModified” exception.

#### DataMiner Cube - Resources app: Not possible to link virtual function resources to elements of which the protocol version was set to 'production' \[ID_30655\]

In the Resources app, it is possible to create virtual function resources that are linked to compatible elements. Up to now, in some cases, it was not possible to link virtual function resources to elements of which the protocol version was set to “production”.

#### Visual Overview: Property value not shown in shape text \[ID_30696\]

If an element shape was configured with property shape data and contained "\*" as its shape text, it could occur that the property value was not shown even though it was available.

#### Dashboards app: All pages of query initially loaded in table component \[ID_30697\]

If a table component showed a query with multiple pages of data, it could occur that all pages were initially fetched instead of only the first page.

#### Dashboards app: State component showed GQI query ID instead of display name \[ID_30702\]

The State component incorrectly showed the ID of a GQI query instead of its display name.

From now on, when you select the *Display query name* option in the *Layout* tab of the State component, the component will show the display name of the query.

#### Resource Manager would fail to initialize during a DataMiner startup \[ID_30708\]

During a DataMiner startup, in some cases, the Resource Manager would fail to initialize.

#### DataMiner Cube - Bookings app: check added of elastic support when retrieving virtual functions \[ID_30814\]

When, in DataMiner Cube, you opened the Bookings app while being connected to a DataMiner Agent without an Elasticsearch database, in some cases, an error could occur when trying to retrieve virtual function definitions. From now on, Cube will only retrieve virtual function definitions when it is connected to a DataMiner Agent with an Elasticsearch database.

#### DataMiner Cube - Visual Overview: Problems when updating Children shapes \[ID_30924\]

A number of problems with Children shape updates have been fixed:

- When a Children shape was sorted on alarm severity, in some cases, updates to the alarm level of the shape would no longer be processed and the sorting would not be updated.
- When a shape no longer matched a filter, in some cases, it would not be removed from the list of generated shapes.
- In some cases, the (configurable) maximum amount of child shapes would no longer be applied when updates were received.

#### DataMinerCube.exe not shut down when Cube desktop app was closed \[ID_30968\] \[ID_31036\]

When you opened a Cube desktop app without using the start window and connected it to a DataMiner System with an Elasticsearch database, in some cases, the DataMinerCube.exe process would not shut down when you closed the Cube app.

#### DataMiner Cube - Trending: Problem when exporting a trend graph to a CSV file \[ID_30987\]

In some cases, an exception could be thrown when you tried to export a trend graph to a CSV file.

#### Memory usage of SLAnalytics temporary increasing because of alarm focus events not getting cleared from the cache \[ID_31025\]

In some rare cases, overall memory usage of the SLAnalytics process would temporarily increase because alarm focus events did not get cleared from the cache.

#### Enabled soft-launch options could incorrectly be disabled \[ID_31033\]

When no *SoftLaunchOptions.xml* file was found in the *C:\\Skyline DataMiner\\* root directory, soft-launch options that were enabled by default (e.g. the new average trending feature) would incorrectly be disabled.

#### Interactive Automation scripts: Problem with file upload components \[ID_31064\]

After multiple updates had occurred in an interactive Automation script, in some cases, a file upload component could end up in an invalid state and lose all information about the uploaded files.

#### Security: Azure AD access tokens not refreshed \[ID_31067\]

In some cases, Azure AD access tokens would incorrectly not get refreshed.

#### DataMiner Cube: Problem when adding/deleting DataMiner Agent to/from a DMS \[ID_31078\]

In the *Agents* section of *System Center*, up to now, users with *Agents \> Add* permission but without *Agents \> Add DMA to cluster* permission seemed to able to add a DMA to a DMS. However, after *System Center* had been refreshed, the added DMA would not be listed. Also, users with *Agents \> Delete* permission but without *Agents \> Delete DMA to cluster* permission seemed to able to delete a DMA to a DMS. However, after *System Center* had been refreshed, the deleted DMA would still be listed.

From now on, users with only *Agents \> Add* permission or *Agents \> Delete* permission will be able to correctly add or delete DMAs from a DMS.

#### Dashboards app - GQI: Problem when migrating queries that contain joins \[ID_31080\]

Each time the GQI version gets upgraded, all GQI queries are migrated to the new version. In some cases, the migration of a GQI query could fail when that query contained joins.

#### Web apps: Selecting the selected value in a selection box could clear that value \[ID_31089\]

When, in a web app, you opened a selection box and selected the value that was selected, in some cases, that value would incorrectly be cleared.

#### Cassandra cluster: No SLA table created on startup or on creation of an SLA \[ID_31092\]

On a Cassandra cluster, in some cases, no SLA table would be created on startup or on creation of an SLA.

#### Reporter: Problem when retrieving an alarm history on a system with a Cassandra cluster \[ID_31096\]

When, on a system with a Cassandra cluster, you used Reporter to retrieve the alarm history of an element, in some cases, the query would not return any results.

#### Dashboards app: GQI queries in PDF reports sent via an interactive Automation script not migrated correctly \[ID_31127\]

When a PDF report of a dashboard containing GQI queries was generated before being sent by email via an interactive Automation script, in some cases, the GQI queries would not be migrated correctly.

#### Web Services API v0: Exception when CreateElement request did not contain Ports array \[ID_31145\]

In some cases, the CreateElement method could throw an exception when the request did not contain a Ports array. From now on, when the request does not contain a Ports array, an error message will be returned.

#### Dashboards app: Duplicate options in GQI queries \[ID_31206\]

In some cases, options added to GQI queries would incorrectly be added twice.

#### DataMiner Agent could get stuck in offload mode after the database had been unreachable \[ID_31245\]

In some cases, a DataMiner Agent could get stuck in offload mode after the database had been unreachable for a period of time.

#### Users without access to elements were no longer able to retrieve the list of views in which a service is located \[ID_31258\]

In some cases, it would no longer be possible for users without access to elements to retrieve the list of views in which a service is located using, for example, the Web Services API.

#### Interactive Automation scripts: Initial state of non-recursive tree view incorrect \[ID_31302\]

The initial checked/unchecked state of a non-recursive tree item would be incorrect when

- the state of the item in question was “checked”,
- there was no recursive checking,
- the item had children, and
- none of those children were checked.

#### Interactive Automation scripts: Dialog items inherited dimensions of dialog item shown earlier \[ID_31311\]

When an interactive Automation script was launched from a web app, in some cases, a dialog item could incorrectly inherit the dimensions of a dialog item shown earlier.

#### DataMiner Cube - System Center: Server setting updates not saved immediately \[ID_31339\]

When you updated server settings in System Center (e.g. the default browser plug-in), up to now, it could take up to 10 seconds for the changes to be applied. Also, when Cube was closed in the meantime, those latest changes would be lost. From now on, all changes made to system settings will be applied immediately.

#### DataMiner Cube - Alarm Console: Problem after turning on the alarm focus feature \[ID_31343\]

When the alarm focus feature was used for the first time, in some cases, all alarm events would incorrectly be marked with an icon in the *Focus* column.

#### Dashboards app - GQI: Problem when enabling the 'Use feed' option of a select node \[ID_31349\]

When, in a GQI query, the “Use feed” option of a select node had been enabled, in some cases, an error could occur when selecting the default columns.

#### Problem when writing to the database after restarting an SLAnalytics feature or changing a setting of an SLAnalytics feature \[ID_31371\]

When an SLAnalytics feature had been restarted or when a setting of such a feature had been changed, in some cases, an exception could be thrown when data was written to the database.

#### DataMiner Cube - Alarm Console: 'Saved filters' option missing on systems with MySQL database \[ID_31375\]

When, on a system with a MySQL database, you selected *Apply filter...* in a newly created alarm tab, in some cases, the *Saved filters* options could be missing.

#### Dashboards app: Problem when generating a PDF report of a dashboard that contained empty components \[ID_31388\]

When a PDF report was generated for a dashboard that contained empty components, in some rare cases, the PDF generation process could get stuck.

#### Dashboards app: Problem when trying to import a dashboard \[ID_31389\]

When you tried to import a dashboard, in some cases, the system would incorrectly look for the dashboard to be imported in the “Dashboards” folder instead of the “ImportDashboards” folder.

Also, when you tried to import a dashboard on a DataMiner Agent that did not have an “ImportDashboards” folder, the Dashboards app would incorrectly look for the dashboard to be imported in the “Dashboards” folder instead. From now on, when the “ImportDashboards” folder does not exist, a message will appear, saying that no dashboards are available for import.

#### DataMiner Cube - Visual Overview: Session variable 'IDOfSelection' of ListView updated incorrectly \[ID_31395\]

When you embed a list view component in a visual overview and set the Source field to “Bookings”, then the session variable IDOfSelection will contain the ID of the currently selected booking. In some cases, this session variable would be updated incorrectly, especially when you selected a booking in the future after having selected a booking in the past.

#### Dashboards app: Parameter feed could incorrectly continue to feed data when the parameter in question was no longer selected \[ID_31403\]

In some cases, a parameter feed could incorrectly continue to feed data even though the parameter in question was no longer selected.

#### Dashboards Sharing: Incorrect login screen when the shared dashboard you were viewing was unshared \[ID_31503\]

When a shared dashboard was unshared while you were viewing it, up to now, you would incorrectly be redirected to the login screen of the Dashboards app. From now on, you will be redirected to the DataMiner Cloud login screen (i.e. <https://shares.dataminer.services>) instead.

#### Dashboards app: Value for EPM components with only one chain filter not displayed in PDF report \[ID_31563\]

In a PDF report, in some cases, EPM components that only had one active chain filter would incorrectly not display their selected value.

#### Failover: Status of newly installed Failover system not set to 'No problems detected' \[ID_31604\]

In some cases, the status of a newly installed Failover system would incorrectly not be set to “No problems detected” (i.e. green LED).

#### Automation: Possible to add multiple files in file selector of interactive script despite AllowMultipleFiles being set to false \[ID_31614\]

When the *UIBlockDefinition* property *AllowMultipleFiles* is set to false in an interactive Automation script, users should not be able to add multiple files in a file selector. However, it was still possible to get multiple files into the selector by selecting several files at once and dragging them into it. This will now no longer be allowed.

#### Incorrect number of Elasticsearch backups kept \[ID_31701\]

Elasticsearch would incorrectly keep one backup more than was specified in the “number of backups to keep” setting.

For example, when you had specified that 4 backups had to be kept, Elasticsearch would incorrectly keep 5 backups instead.

#### DataMiner Cube - Visual Overview: Connectors without matching DCF connection not hidden \[ID_31727\]

When, on a visual overview, the “ConnectivityLines\|HighlightPath” page option had connectors replace DCF connections, in some cases, connectors without a matching DCF connection would incorrectly not be hidden.

Also, in some cases, hidden shapes linked to EPM objects would incorrectly be visible.

#### DataMiner Cube - Trending: Problem when opening a histogram \[ID_31731\]

In some cases, an exception could be thrown when you opened a histogram.

#### Web apps: 'Refresh now' instead of 'Reconnecting...' message after communication was interrupted \[ID_31753\]

Up now on, when a web app (e.g. Dashboards, Monitoring, Ticketing, etc.) lost communication, a “Reconnecting...” message would appear in the UI. From now on, a “Refresh now” message will appear instead, prompting users to refresh the web page.

#### Failover: DataMiner modules would incorrectly consider the local IP address of the online agent as the primary IP address of the Failover setup \[ID_31756\]

After a Failover configuration had been updated (either manually or after an automatic synchronization), the DataMiner modules would incorrectly consider the local IP address of the online agent as the primary IP address of the Failover setup (instead of the virtual IP address). As a result, when file changes on the Failover setup were forwarded to other agents in the DMS, those agents would reject the changes as the IP address of the sender was unknown to them. Only after a DMA restart or a switchover/switchback operation would the DataMiner modules again use the virtual IP address of the Failover setup.

#### Jobs app: Hidden or required fields no longer hidden or required when domain or section was duplicated \[ID_31758\]

When you duplicated a job domain using the *Duplicate \> Create copies of the sections* option or when you duplicated a job section using the *Create a copy* option, in some cases, hidden or required fields would incorrectly no longer be hidden or required in the newly created domain or section.

#### DataMiner Cube - Alarm Console: Base alarms of a correlated alarm not shown on linked alarm tab \[ID_31789\]

When the Alarm Console had an alarm tab that was linked to an element of which an alarm was the base alarm of a correlated alarm, that alarm would incorrectly not be shown.

#### Problem with SLAnalytics when a large number of element state updates were being generated \[ID_31810\]

In some rare cases, an error could occur in SLAnalytics when a large number of element state updates were being generated.

#### Service & Resource Management: Problem with GetEligibleResources method \[ID_31818\]

In some cases, the GetEligibleResources method could throw NullReference exceptions or KeyNotFound exceptions.

#### Dashboards app - Parameter feed: Enhanced performance when fetching parameter indices \[ID_31841\]

Due to a number of enhancements, overall performance of the parameter feed has increased when fetching parameter indices.

#### Problem with filtered table subscriptions on DVE elements \[ID_31845\]

When a subscription on a table of a DVE element had been created with a filter (e.g. a primary key filter), the client would receive the initial data but no updates.

#### Failover: Problem when setting up a Failover system with a Cassandra database \[ID_31854\]

In some cases, the following exception could be thrown when a Failover system with a Cassandra database was set up:

```txt
System.Exception: Unexpected error from nodetool.
```

#### PDF reports: Incorrect scaling \[ID_31863\]

Up to now, in some cases, the contents of PDF reports would not get scaled correctly to fit the page.

#### DataMiner Cube - Bookings app: Not all booking data flushed from memory when Bookings app was closed \[ID_31880\]

When you closed the Bookings app, in some cases, not all booking data would be flushed from memory.

#### Failover: Agents not coming online after DataMiner restart \[ID_31915\]

When a Failover configuration incorrectly did not have normal heartbeats defined between the two Agents, the Agents would not automatically come online after a DataMiner restart.

#### External authentication via SAML: Problem when logging in with a user account that shared its email address with another account \[ID_31990\]

When, on a system that used external authentication via SAML, you tried to log in with a user account that shared its email address with another user account, up to now, an exception would be thrown. From now on, an error message will be added to the SLSAML.txt log file instead.

#### DataMiner landing page: User icon no longer shown in top-right corner \[ID_32108\]

On the DataMiner landing page, the user icon would incorrectly no longer be shown in the top-right corner.

#### Incorrect error in logging during startup of Failover setup \[ID_32112\]

In a Failover setup, during startup the following incorrect error could briefly be reported in the *SLFailover.txt* log file:

```txt
INVALID CONFIG: Failover is active, but no cluster is defined
```

#### Dashboards app: Problems with GQI \[ID_32142\]

In the Dashboards app, a number of issues with regard to GQI have been resolved.

- Column manipulation by regular expression would not work when all columns contained numeric values.
- Column manipulation by concatenation would concatenate the raw values instead of the display values.
- When data was being aggregated, “group by” operations would use the raw value instead of the display value.

#### Dashboards app: Problem when double-clicking the 'Start editing' button \[ID_32159\]

When, in the Dashboards app, you double-clicked the *Start editing* button, in some cases, the dashboard would keep on going in and out of edit mode.

#### Automation: Minor fixes with regard to the generation of email reports via Dashboards app \[ID_32165\]

In Automation, a number of minor issues have been fixed with regard to the generation of email reports via the Dashboards app.

#### Web apps: All CSS styles would incorrectly be reloaded when the theme colors were updated \[ID_32231\]

When, in a web app, the theme colors were updated, up to now, all CSS styles would incorrectly be reloaded.

#### DataMiner would incorrectly try to connect to 127.0.0.1 when taking a backup of a Cassandra database \[ID_32242\]

When a DataMiner backup included a backup of a Cassandra database, and, in the Cassandra.yml file, the rpc_address setting did not contain “0.0.0.0”, DataMiner would incorrectly assume the database was located at IP address 127.0.0.1. From now on, DataMiner will instead connect to the database located at the IP address specified in the DB.xml file.

#### Dashboards app: Feeds would stop feeding data after refreshing the page \[ID_32251\]

In some cases, feeds in a dashboards would stop feeding data after refreshing the page.

#### Dashboards app: Parameter state component would not show parameter updates for certain column parameters when using table index filters \[ID_32268\]

When a parameter state component was linked to a column parameter from a table using display keys and filtered using a table index filter, the data displayed by that component would not be updated when changes were made to the parameter.

#### Dashboards app: GQI engine would not fall back to the timezone of the browser when the commonServer.ui.DefaultTimeZone setting could not be found \[ID_32283\]

From DataMiner 9.6.11 onwards, the DataMiner web apps format time values based on the commonServer.ui.DefaultTimeZone setting, located in the C:\\Skyline DataMiner\\Users\\ClientSettings.json file. When this setting cannot be found, they will instead use the time zone of the browser. Up to now, the GQI engine would incorrectly not fall back to the time zone of the browser when it was unable to find the commonServer.ui.DefaultTimeZone setting in the ClientSettings.json file.

#### DataMiner Cube: Problem when a user without permission to view service definitions connected to an SRM system \[ID_32309\]

When a user connected to a Service & Resource Management environment, DataMiner Cube would throw an exception when that user did not have permission to view service definitions.

#### Problem when opening DMS Alerter \[ID_32312\]

In some cases, an error could occur when you opened DMS Alerter.

#### Dashboards app: Parameter feeds would incorrectly not load all parameter indices \[ID_32329\]

When loading parameters, in some cases, a parameter feed would incorrectly not load all parameter indices.

#### SLDataGateway would incorrectly try to start the local Cassandra service when a remote Cassandra cluster was configured \[ID_32338\]

In some cases, SLDataGateway would incorrectly try to start the local Cassandra service in situations where a remote Cassandra cluster was configured,

#### DataMiner Cube - Profiles app: Problem when duplicating profile parameters with mediation snippets \[ID_32387\]

When you duplicated a profile parameter with a mediation snippet on one of the configured protocol links, the duplicated mediation snippet would incorrectly not be marked as new. As a result, that snippet would not get added.

#### Failover: Problem with SLDataGateway after losing its connection to SLNet during a Failover switch \[ID_32435\]

When a Failover switch is performed, in some cases, SLDataGateway loses its connection to SLNet and immediately recreates it. However, because it did not receive any SLNet events during the time the connection was lost, up to now, SLDataGateway would be unaware that DataMiner was up and running, causing all write operations that require information from SLNet to get blocked. From now on, as soon as the connection between SLNet and SLDataGateway is re-established, the latter will assume DataMiner is up and running.

#### Dashboards: Component selection not cleared when switching between dashboards \[ID_32452\]

In some cases, component selection was not cleared when you switched between different dashboards in the Dashboards app, which could cause issues when new components were added.

#### SLAnalytics: Pattern matching would no longer work due to a problem while retrieving pattern data from Elasticsearch \[ID_32466\]

In some cases, pattern matching would no longer work due to a problem while retrieving pattern data from the Elasticsearch database.

#### Web apps: 'Refresh now' message would incorrectly appear when opening a web app that did not have an active websocket connection \[ID_32585\]

When your opened a web app (e.g. Dashboards, Monitoring, Ticketing, etc.) that did not have an active websocket connection, a “Refresh now” message would incorrectly appear. From now on, this message will only appear when an active websocket connection was broken.

## Addendum CU1

### CU1 enhancements

#### DataMiner is now able to connect to Cassandra databases that require TLS 1.2 \[ID_31852\]

DataMiner is now able to connect to Cassandra databases that require TLS 1.2.

#### SLElement: Enhanced performance when resolving table relationships \[ID_32176\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving table relationships.

#### Alarms will now be assigned 3 GUIDs (for future use) \[ID_32192\]

Apart from an ID, a PreviousAlarmID and a RootAlarmID, each alarm will now also be assigned the following GUIDs for future use:

- AlarmGuid
- PreviousAlarmGuid
- RootAlarmGuid

#### DataMiner Cube: Enhanced performance when reloading protocols after a protocol update \[ID_32315\]

Due to a number of enhancements, overall performance has increased when reloading protocols after a protocol update.

#### Filtered subscriptions will now be processed similarly to non-filtered subscriptions \[ID_32399\]

Filtered subscriptions will now be processed similarly to non-filtered subscription, regardless of whether the element in question is hosted on the local DMA or a remote DMA.

#### DataMiner Cube - Users/Groups: Permissions needed to edit group membership \[ID_32456\]

When opening their user card, from now on, users will only be able to edit group membership if they have the following permissions:

- Administrator permission, or
- Limited administrator permission as well as “Edit all groups” or “Edit own groups” permission

> [!NOTE]
> Users only need to have the “Edit own groups” permission to be able to configure a group of which they are a member.

#### DataMiner backups will now by default also include SSL certificates and EPMConfig.xml files \[ID_32504\]

Full backups and configuration backups will now by default also include the EPMConfig.xml files and all certificates used by protocols for encrypted communication with devices.

#### Jobs app: Delete button will only be visible to users who have been granted permission to delete jobs \[ID_32507\]

From now on, the *Delete* button will only be visible to users who have been granted permission to delete jobs.

#### DataMiner Cube - Correlation: Using hidden elements when creating correlation rules \[ID_32510\]

When creating a correlation rule in the Correlation app, it is now possible to use a hidden element in both the *Alarm Filter* section and the *Rule Condition* section.

#### Enhanced performance when stopping SNMP elements \[ID_32523\]

Due to a number of enhancements, overall performance has increased when stopping SNMP elements.

#### Dashboards app - Parameter feed: 'Selected only' toggle button has been removed \[ID_32541\]

Up to now, a parameter feed had a *Selected only* toggle button that allowed you to show or hide items that were not selected. Now, this toggle button has been removed.

Also, when a dashboard is loaded with an initial selection (either configured or in the URL), the selected items will now always appear at the top of the list.

#### SNMP forwarding will now take into account alarm storms when resending alarms \[ID_32543\]

Up to now, when an SNMP Manager was configured to resend all active alarms every configured time interval, it would ignore any ongoing alarm storm. From now on, when there is an alarm storm, depending on whether the *Enable alarm storm protection by grouping alarms with the same parameter description* option is enabled, the following will happen:

- If the grouping option is enabled, only the alarms that are not associated with an element parameter in alarm storm will be resent.
- If the grouping option is not enabled, no alarms will be resent during the alarm storm.

> [!NOTE]
>
> - When you manually request all alarms to be resent, the logic described above will also apply.
> - When inform messages are used instead of traps and the receiving party does not return an acknowledgment, then the retry messages will still be sent, even when an alarm storm starts while those retry messages are being sent.

#### DataMiner Cube - Data Display: Row filter will now be shown when opening the alarm template, trend template or information template for a particular parameter table row \[ID_32555\]

When, in Data Display, you drill down to a specific row of a parameter table, you can open the alarm template, trend template or information template for that specific row. From now on, if a filter was configured for the table row in question, it will also be shown in the UI.

#### DataMiner Cube - Automation: SaveAutomationScriptXmlMessage will now be used when importing, saving and updating Automation scripts \[ID_32557\]

Up to now, when an Automation script was imported, the file would not be processed in the same way as when an Automation script was saved or updated. From now on, the same SaveAutomationScriptXmlMessage will be used when importing, saving and updating Automation scripts.

#### Protocols: Allow for different remote element sources in view table columns \[ID_32579\]

When setting up remote columns, up to now, all columns had to refer to the same parameter containing a list of remote elements (e.g. “view=:x:y:z”, where x is the ID of the parameter containing the remote element IDs). From now on, it is possible to have two sets of elements referenced by different columns within the same view table.

In the following example, parameters 201 and 301 each contain a list of remote elements, and both can be used within the same view table (in different ColumnOption tags).

```xml
<ColumnOption idx="3" pid="2004" type="retrieved" options=";view=:201:1000:3"/>
<ColumnOption idx="4" pid="2005" type="retrieved" options=";view=:301:1000:4"/>
```

#### Service & Resource Management: Updated exceptions thrown when the time range of a child ReservationInstance or child ReservationDefinition is invalid \[ID_32581\]

The following exception messages have been enhanced.

##### Exception thrown when the time range of a child ReservationInstance is invalid

This message now includes the ID, the name and the time range of both the parent and the child.

```txt
The TimeRange of the child is not within the boundaries of the parent ReservationInstance (Child: '{Child Name}' ({Child ID}) has range '{Child Range}' & Parent: '{Parent Name}' ({Parent ID}) has range '{Parent Range}')
```

##### Exception thrown when the time range of a child ReservationDefinition is invalid

This message now includes the ID, the name and the time range of both the parent and the child. For the child, the offset has now also been added.

```txt
The timing of the child is not within the boundaries of the parent ReservationDefinition (Child: '{Child Name}' ({Child ID}) has timing with duration '{Child Timing Duration}' and offset '{Child offset}' & Parent: '{Parent Name}' ({Parent ID}) has timing with duration '{Parent Timing Duration}')
```

#### Hanging threads in SLNet will now be logged in SLHangingCalls.txt \[ID_32582\]

Up to now, hanging threads in SLNet would be logged in the SLNet.txt file. From now on, these will be logged in the new SLHangingCalls.txt file instead (without the stack trace).

This file will by default be refreshed every 5 minutes.

#### Dashboards app: Specifying data input for an EPM feed in a URL using 'epm-selections' instead of 'cpes' \[ID_32594\]

Up to now, in a dashboard URL, it was possible to specify data input for an EPM feed by means of a “cpes” data key. This key has now been deprecated in favor of the new “epm-selections” key.

The new “epm-selections” data key consist of the following elements:

- DataMiner ID
- Element ID
- Field parameter ID
- Primary key

The following example shows a JSON object that contains an “epm-selections” data key, which can be passed to a dashboard using a URL parameter of type “data”:

```json
{
    "version": 1,
    "feed": {
        "epm-selections": ["111/222/333/index"]
    }
}
```

> [!NOTE]
> In order to maintain backward compatibility, data provided via a “cpes” object will automatically be converted when necessary.
> Only when any of the fields in the “cpes” object contain forward slashes will you need to use the new “epm-selections” object instead.

#### Enhanced performance when uploading DataMiner upgrade packages \[ID_32597\]

Due to a number of enhancements, overall performance has increased when uploading DataMiner upgrade packages.

#### DataMiner Cube - Spectrum analysis: Additional logging to help pinpoint monitor failures \[ID_32605\]

When, on a spectrum element card, you select *View buffer* in the *monitors* tab of the ribbon, the selection boxes should contain all available monitor buffers.

In DataMiner Cube, additional logging is now available to help pinpoint monitor execution failures by providing information about the monitor buffers that will be shown based on the backend buffer response.

#### DataMiner Cube - Alarm Console: Clearer summary alarm values in case of an alarm storm \[ID_32608\]

When the Alarm Console setting *Enable alarm storm protection by grouping alarms with the same parameter description* is enabled, during an alarm storm, alarms associated with the same parameter will be grouped under a summary alarm.

Up to now, the value of such a summary alarm would state “Parameter (X alarms)” with X being the number of alarm trees rather than the actual number of alarms.

From now on, the value of a summary alarm will instead state “Parameter (X alarm trees - Y alarms)”. This will allow users to see more clearly how many alarms there are left with the same parameter description and how many trees they represent.

#### DataMiner Cube: Information templates will only show the read parameter in case of a toggle button \[ID_32610\]

Up to now, for a write parameter configured as a toggle button, an information template would show two parameters: a read parameter and a write parameter. From now on, toggle buttons will be treated as regular parameters. In an information template, only the read parameter (of type discreet) will be shown.

#### Video thumbnails: New options for HTML5 video player & VLC player \[ID_32626\]

The HTML5 video player and the VLC player have a number of new options.

##### HTML5 video player

The HTML5 video player will now by default mute videos when played automatically.

##### VLC player

When playing videos using the VLC player, it is now possible to specify the volume in the URL. See the following example. The volume has to be specified as a percentage (0 to 100). Default: 0 (i.e. muted).

```txt
https://dma.local/VideoThumbnails/Video.htm?type=VLC&source=https://videoserver/video.mp4&volume=50
```

##### HTML5 video player & VLC player

Using the HTML video player or the VLC player, it is now possible to specify whether a video should be played in a loop. See the following example. Default: false

```txt
https://dma.local/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4&loop=true
```

#### Dashboards app: 'Write' filter removed from Data \> All available data \> Parameters \[ID_32643\]

When, after selecting a component in edit mode, you open the *Data* tab and go to the *All available data \> Parameters* section, you can select an element and then filter the list of parameters of that element by clicking a number of preset filters. The preset filter “Write”, which was used to filter out the parameters of type “write”, has now been removed.

#### Enhanced performance of the interprocess communication between SLDataGateway and SLAnalytics \[ID_32653\] \[ID_32709\]

Due to a number of enhancements, overall performance of the interprocess communication between SLDataGateway and SLAnalytics has increased.

#### Server processes will now use InvariantCulture \[ID_32665\] \[ID_32912\]

Up to now, server processes like SLNet used the default system locale. If this locale was a language other than English, all internal .NET Framework exception stack traces and log messages would be generated in that language, making it harder to interpret or analyze them. From now on, the server processes will now force their threads to use the CultureInvariant culture by default.

> [!NOTE]
> SLManagedAutomation and SLManagedScripting will continue to use the default system locale.

#### Backups will now by default also include the SLAnalytics configuration \[ID_32699\]

Full backups and configuration backups will now by default also include the SLAnalytics configuration.

#### DataMiner Cube - Automation: Specifying an offset value will now be optional in case of a Set action \[ID_32743\]

When, in an Automation script, you configured a Set action for which an offset value could be specified, up to now, it was mandatory to specify that offset value. From now on, specifying an offset value will be optional. Either select “with value offset” and enter a value, or select “without value offset”.

Default: “without value offset”

#### Size of SLMessageBroker.txt log file is now limited to 3MB \[ID_32863\]

The size of the SLMessageBroker.txt log file is now limited to 3MB.

#### NATS: Enhanced handling of serialization issues \[ID_32883\]

A number of enhancements have been made with regard to the handling of serialization issues.

### CU1 fixes

#### Cassandra: Problem when reading DVEElementInfo rows that contained NULL values \[ID_32357\]

Up to now, DataMiner could throw an exception when reading a DVEElementInfo row that contained NULL values.

#### SNMP forwarding: Problem when deleting an SNMP manager and immediately creating an identical one \[ID_32406\]

When you deleted an SNMP manager of type SNMPv3 and then immediately created an identical one, in some rare cases, an exception of type “Float Invalid Operation” would be thrown.

#### Dashboards: No longer possible to switch between visualizations when a component did not require data \[ID_32413\]

When you hovered over a component that did not require data (e.g. text, clock, image, etc.), it would no longer be possible to select another visualization.

#### DataMiner Cube - Services app: Expand/collapse button in front of a service profile definition would disappear when you expanded or collapsed the service profile definition node \[ID_32439\]

When, in the Profiles tab of the Services app, you expanded or collapsed a service profile definition node in the tree on the left, the expand/collapse button in front of that service profile definition would incorrectly disappear. In other words, there was no way to reverse the expand/collapse action.

#### DataMiner Cube - Data Display: Not possible to open the alarm template or trend template of a parameter that was not trended \[ID_32449\]

When, in Data Display, you drill down to a parameter of an element, you can configure the alarm and trend templates for that specific parameter. When you tried to configure the alarm template or the trend template of a parameter that can be trended but wasn’t, up to now, it would incorrectly not be possible to open the alarm template or trend template of that specific parameter.

#### Web apps: Menu would not close after selecting the same option twice \[ID_32461\]

After selected the same menu option twice, the menu would not close until you clicked somewhere else on the page.

#### DataMiner Cube - Profiles app: Problem when trying to retrieve mediation snippets and service profiles on a system without ElasticSearch database \[ID_32488\] \[ID_32539\]

When you tried to open the Profiles app on a DataMiner System with a Service Manager license that did not have an ElasticSearch database, the app would fail to initialize when attempting to retrieve mediation snippets and service profiles. From now on, the presence of an ElasticSearch database will be checked before trying to retrieve mediation snippets and service profiles.

> [!NOTE]
> On systems without an ElasticSearch database, it is not possible to configure mediation snippets.

#### Stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements \[ID_32498\]

Up to now, in some cases, stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements.

#### Problem when trying to delete a protocol \[ID_32522\]

In some cases, an error could occur when you tried to delete a protocol.

#### DataMiner Cube - Visual Overview: Problem with initial page selection \[ID_32527\]

When you assign a Visio drawing to a view or a service, you can specify a default page. This initial page selection would no longer work.

Also, when the *How to show element card Data pages* setting was set to “Show in drop-down box”, initial page selection would no longer work.

#### Dashboards: Problem when sharing a dashboard created in an earlier version of the Dashboards app \[ID_32551\]

If you tried to share a dashboard that was created in an earlier version of the Dashboards app, in some cases, an error could occur.

#### Web services API: Problem with internal GQI calls when web sockets were disabled \[ID_32570\]

When web sockets were disabled on the DataMiner Agent, in some cases, internal GQI calls could throw exceptions.

#### SLProtocol would leak memory when using a 'change after response' trigger \[ID_32572\]

When using a “change after response” trigger, SLProtocol would leak memory on every incoming response. See the following example.

```xml
<Trigger id="2">
  <On id="1">parameter</On>
  <Time>change after response</Time>
  <Type>action</Type>
  <Content>
    <Id>2</Id>
  </Content>
</Trigger>
```

#### Elasticsearch: Problem when using a filter that checked whether a string was empty \[ID_32586\]

In some cases, Elasticsearch would return an incorrect number of records when a query contained a filter that checked whether a string was empty in combination with other filters.

#### Elasticsearch: Page would return empty when requesting the next page of naturally sorted data \[ID_32596\]

When the next page of naturally sorted data was requested from an Elasticsearch database, up to now, that page would return empty.

#### Dashboards app: Shared dashboards still showed 'Share' option \[ID_32618\]

When you clicked the “...” button in the top-right corner of a shared dashboard, the menu would incorrectly include a “Share” command.

As it is not possible to share a dashboard that has already been shared, this command will no longer be available when you open a shared dashboard.

#### SLNet would leak memory whenever a Cube session was closed or disconnected \[ID_32649\]

Whenever a Cube session was closed or disconnected, SLNet would leak memory.

#### Miscellaneous small fixes \[ID_32655\]

A number of miscellaneous, small fixes have been made.

#### Dashboards app - Parameter feed: Problem selecting the element again after clicking 'Clear all' \[ID_32661\]

When, in a parameter feed with a single element, you clicked the *Clear all* option to unselect all selected parameter, in some cases, it would no longer be possible to select the element again.

#### Migration to Cassandra cluster: Alarms and information events would not get migrated \[ID_32666\]

When migrating single Cassandra nodes to a Cassandra cluster, in some cases, the alarms and information events would incorrectly not get migrated, especially on systems with a large number of alarms and information events.

#### Serial protocols: Length check would incorrectly take into account the data before the header \[ID_32669\]

Up to now, when a payload with data before the header was received (e.g. aaaa\<header>payloadwithfixedlength), the data before the header would correctly be stripped off before forwarding the payload to the protocol, but the length check would incorrectly take that data into account.

#### SLNetClientTest: Problems with 'Agent Connections' window \[ID_32679\]

When, in the SLNetClientTest tool, you opened the *Agent Connections* window (by selecting *Diagnostics \> Connections \> View DMA Connections*),

- Agents could incorrectly display a “Disconnected” state while actually being connected.
- The “Calls From” column could incorrectly display “(not available)”.

#### DataMiner Cube - Profiles app: Problem when modifying a profile instance \[ID_32688\]

When a profile instance is modified, the existing instance is copied and the modifications are done on the properties of the newly created copy. However, up to now, the parameter entries of the profile instance would incorrectly not get copied. Instead, new parameter entries would be created. From now on, the parameter entries of the profile instance will be copied along.

#### DataMiner Cube - Alarm templates: Table conditions would no longer be saved correctly \[ID_32691\]

When, in an alarm template, you specified table conditions, in some cases, those conditions would no longer be saved correctly.

#### Dashboards: Missing sidebar when navigating to a dashboard URL for edit mode without having edit access \[ID_32706\]

When you navigate to a dashboard via a URL containing the edit=true parameter, and you do not have permission to edit that dashboard, the dashboard will not be opened in edit mode.

However, up to now, when you navigated to dashboard using a URL with an edit=true parameter and you did not have permission to edit it, although you were not in edit mode the side pane would incorrectly not appear.

#### DataMiner Cube - Asset Manager: UI could become unresponsive when the database configuration was being retrieved \[ID_32766\]

When, in DataMiner Cube, you opened the Asset Manager app, in some cases, the UI could become unresponsive when the database configuration was being retrieved.

#### SLDataGateway: Result set would incorrectly be kept in memory after retrieving alarms from the database \[ID_32788\]

When alarms had been retrieved from the database page by page, in some cases, those pages would be kept in memory indefinitely.

## Addendum CU2

### CU2 enhancements

#### Security enhancements \[ID_32849\] \[ID_32954\] \[ID_32992\] \[ID_33014\] \[ID_33052\]

A number of security enhancements have been made.

#### Dashboards app - GQI: GQI filter can now be linked to query rows \[ID_32552\]

In a filter node of a dashboard query, you can now choose to filter by query rows from a feed. To do so, select the *Use feeds* option, select the feed, select the type *Query rows*, and then select the appropriate column of the table containing the rows. Note that only the columns compatible with the type of column you are filtering will be available for selection.

#### Enhanced performance with regard to the processing of system performance indicators \[ID_32574\]

Because of a number of enhancements, overall performance has increased with regard to the processing of system performance indicators.

#### Dashboards app: Improved loading indicator for bar and pie chart with GQI data \[ID_32806\]

The loading indicator when GQI data are loaded for a bar or pie chart component has been improved to be more in line with the usual dashboard style. Instead of a spinner, now a loading bar is shown at the top of the component.

#### Dashboards app: Live sharing no longer requires users to have permission to edit the dashboards they are sharing \[ID_32812\]

Up to now, when users wanted to share a dashboard, they also needed to have permission to edit the dashboard in question. From now on, users who want to share a dashboard will no longer need permission to edit that dashboard.

> [!NOTE]
> When you do not have *General \> Live sharing \> UI available* permission, you will not see anything related to live sharing. So, make sure to always use this permission in conjunction with the Share permission.

#### Dashboards app - GQI: Enhanced visualization of queries \[ID_32823\]

A number of enhancements have been made with regard to the visualization of GQI queries. For example, raw values (e.g. column IDs, GUIDs, etc.) will be translated to display values when possible.

#### Cassandra Cluster Migrator tool: Increased write timeout \[ID_32829\]

When it is migrating data, basically, the Cassandra Cluster Migrator tool reads a page of data from the original database (Cassandra or SQL) and then writes that page to the target database (Cassandra Cluster or Elasticsearch). The timeout for the write operations has now been increased from 2 minutes to 30 minutes.

#### Dashboards app - GQI: Queries must now all have a unique name \[ID_32836\]

From now on, when you create, update or import a GQI query, a unique query name will be mandatory. Up to now, query names were optional.

- When you create a new query, the system will suggest “New query” as default name. If that name already exists, then a counter will be added (e.g. “New query (1)”, “New query (2)”, etc.

- When you import a query that has no name, the system will suggest “Imported query” as default name. If that name already exists, then a counter will be added (e.g. “Imported query (1)”, “Imported query (2)”, etc.

#### DataMiner upgrade packages: Obsolete upgrade/downgrade actions removed \[ID_32861\]

Obsolete upgrade and downgrade actions for DataMiner versions older than DataMiner 9.6 have now been removed from the DataMiner upgrade packages.

#### Dashboards app - GQI: Node placeholders now have a clearer name \[ID_32866\]

In the GQI query builder, the node placeholders now have a clearer name. For example, the name of the first node has been changed from “Filter” to “Select data source” and all subsequent nodes will now be named “Select operator”.

#### Web Services API: Enhanced handling of errors thrown when processing asynchronous requests \[ID_32933\]

A number of enhancements have been made with regard to the handling of errors thrown when processing asynchronous requests.

#### DataMiner upgrade packages: New prerequisite check that verifies whether the ports used by DataMiner can be reached in between DataMiner Agents \[ID_32944\]

From now on, upgrade packages will perform a prerequisite check that verifies whether the ports used by DataMiner can be reached in between DataMiner Agents. This will prevent situations where a DataMiner System becomes non-functional after an upgrade that uses more or different ports.

Ports currently checked:

- 4222: NATS
- 6222: NATS (only checked when you are not upgrading a standalone agent, a standalone Failover pair or a two-node agent cluster)
- 9090: NAS

If this check fails, you will need to execute the VerifyClusterPorts.dmupgrade package ([download](https://community.dataminer.services/documentation/verifyclusterports-dmupgrade/)). VerifyClusterPorts.dmupgrade will run the same tests as the DataMiner upgrade package, but it will make sure that temporary listening ports are open for the required ports and a temporary local firewall rule is configured. This way, if a firewall or other configuration issue is causing the problem, this will become clear. If no failing ports are reported when you run this package, the regular upgrade package will use this stored result to continue with the upgrade.

#### Enhanced setup of serial connections with SSL/TLS enabled \[ID_32969\]

A number of enhancements have been made with regard to the setup of serial connections with SSL/TLS enabled.

### CU2 fixes

#### Elasticsearch: Casing will now be ignored when sorting fields of type string \[ID_32437\]

From now on, Elasticsearch will ignore casing when sorting fields of type string.

#### DataMiner web apps: Filter issue when using arrow keys in drop-down box \[ID_31472\]

In the DataMiner web apps (e.g. the Dashboards app), when you opened a drop-down box that already had a value selected and used the arrow keys to navigate through the values, the current value was applied as a filter, while this should not occur.

#### Alarm templates: Miscellaneous fixes \[ID_32462\]

A number of issues have been fixed with regard to alarm templates.

- When you updated an alarm template that contained a table parameter with at least two filters, only the last of those filters was calculated.
- When, in an alarm template, you disabled the smart baselines for a table parameter with a filter and then re-enable it, the smart baselines for that table parameter would no longer be calculated.

Also, a number of enhancements have been made with regard to the calculation of smart baselines.

#### Cassandra Cluster Migrator tool would incorrectly not allow multiple IP addresses in the 'Cassandra IP(s)' field \[ID_32554\]

When configuring the Cassandra settings in the Cassandra Cluster Migrator tool, it would incorrectly not be possible to specify multiple IP addresses in the *Cassandra IP(s)* field.

#### DataMiner Cube: Pop-up window asking for new password disappeared after a while \[ID_32623\]

When an administrator enables the “User must change password at next login” setting for a particular local DataMiner user, the next time that user tries to log in to DataMiner Cube, a pop-up window will appear, asking to enter a new password. In some cases, that pop-up window could disappear after a while, even though no new password had been specified.

#### Problem when migrating a Failover system to a Cassandra cluster \[ID_32672\]

When the Cassandra Cluster Migrator tool was used to transform a Failover system consisting of DMAs with separate SQL or Cassandra databases into a Failover system consisting of DMAs that are all connected to a shared Cassandra and Elasticsearch cluster, in some cases, the migration process would incorrectly be initiated on the offline DMA instead of the online DMA. When that happened, the data written during the migration process would not be written to the destination Cassandra Cluster database.

#### Service & Resource Management: GetEligibleResources would ignore the time range passed to it \[ID_32763\]

Up to now, when GetEligibleResources was called, the eligible resources would incorrectly be calculated based on the time range of the ReservationInstance to be ignored. From now on, when the context passed to GetEligibleResources includes a time range, the time range of the ReservationInstance will be ignored.

#### DataMiner Cube: Problem when opening the Ticketing app \[ID_32775\]

Up to now, in some cases, the Cube UI could become unresponsive when you opened the Ticketing app.

#### DataMiner Cube - Visual Overview: SET command linked to a shape would not be executed when the page was displayed in a VdxPage window of type 'Popup' \[ID_32780\]

When a page that was displayed in a VdxPage window of type “Popup” contained a shape linked to a SET command, clicking that shape would incorrectly not execute the SET command.

#### Problems with embedded dashboards components \[ID_32782\]

When a GQI component was embedded in a Visio drawing or a web page, in some cases, that component would not be rendered correctly. Also, in some cases, embedded dashboard components would not be able to retrieve data from the database.

#### DataMiner Cube - Resources app: No resources or resource pools would be loaded when opening the Resources app \[ID_32790\]

When you opened the Resources app, in some cases, no resources or resource pools would be loaded.

#### Dashboards app - GQI: GUIDs of DOM reference fields would be displayed incorrectly \[ID_32807\]

Up to now, the GUIDs of the following types of DOM reference fields would be displayed incorrectly:

- Reservations (i.e. bookings)
- Service definitions
- DOM instances
- Resources

#### Dashboards app: Problem when sorting a table component populated by means of a GQI query \[ID_32814\]

When you sorted a table component populated by means of a GQI query, in some cases, the sorting would be incorrect.

#### Processes would not get registered correctly when a DataMiner upgrade included a reboot \[ID_32818\]

When a DataMiner upgrade included a reboot (either explicitly requested, or e.g. after installing Microsoft .NET 4.8), in some cases, services would not get registered correctly, especially when the new DataMiner version included services that did not previously exist.

#### Dashboards app: Problem when sharing a dashboard with a node edge component \[ID_32822\]

When viewing a shared dashboard with a node edge component that had its nodes configured to use either analytical or alarm colors, the node edge component could not be rendered.

#### Problem with SLDMS hosting agent cache \[ID_32827\]

In some rare cases, the SLDMS hosting agent cache could get corrupted. As a result, it would no longer contain the correct data when processing element updates.

#### Dashboards app: Query name reset when query is edited \[ID_32832\]

In some cases, when the content of a query in a dashboard was changed, it could occur that the name of the query was reset to a previous value.

#### Dashboards app: Display value that was used to refer to an unnamed query would incorrectly contain HTML tags \[ID_32833\]

When a query had not been assigned a name, up to now, the display value that was used to refer to that unnamed query would incorrectly contain HTML tags. From now on, the name “(query)” will be used to refer to an unnamed query.

#### Exception logged in SLNet.txt during startup \[ID_32835\]

Since DataMiner 10.2.0 \[CU0\] and DataMiner 10.2.2, the following exception could be generated in the SLNet.txt log file during DataMiner startup:

```txt
2022-03-09 12:34:38.962|5|Config.Init|Error reading MaintenanceSettings.xml: System.Exception: Re-entrant Facade.Initialize detected. Do not access Facade.Instance directly or indirectly from the Facade constructor. ---> System.Exception: at System.Environment.GetStackTrace(Exception e, Boolean needFileInfo)
   at System.Environment.get_StackTrace()
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.Config.Init()
   at Skyline.DataMiner.Net.Config.get_Instance()
   at Skyline.DataMiner.Net.Facade..ctor()
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.SLNetService.<OnStartInner>b__10_0()
   at System.Threading.Tasks.Task.Execute()
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)
   at System.Threading.Tasks.Task.ExecuteEntry(Boolean bPreventDoubleExecution)
   at System.Threading.ThreadPoolWorkQueue.Dispatch()
   --- End of inner exception stack trace ---
   at Skyline.DataMiner.Net.Facade.get_Instance()
   at Skyline.DataMiner.Net.Config.Init()
```

#### NAS: Incorrect default settings in nas.config file \[ID_32840\]

The default settings in the nas.config file would be incorrect.

#### SLNet would incorrectly log XmlSerializer exceptions \[ID_32859\]

Up to now, SLNet would incorrectly log the following exception each time it was thrown:

```txt
SLNet tried to load DataMinerInstallerCommunication.XmlSerializers
```

#### Dashboards app - GQI: Problem when exporting table data to CSV \[ID_32865\]

When you exported GQI data from a table component to a CSV file, up to now, only the currently loaded page would get exported. From now on, all data in the table will be exported.

> [!NOTE]
> While the export operation is progress, an “exporting to CSV” notification will be shown in the bottom-right corner of the screen.

#### Memory leak in SLElement \[ID_32885\]

In some cases, a problem with subscriptions on views with remote data would cause SLElement to leak memory, which could eventually lead to run-time errors in the parameter thread.

#### Filtered tables could incorrectly receive updates for rows that did not match the applied filter \[ID_32915\]

In some cases, a filtered table could incorrectly receive updates for rows that did not match the applied filter. On EPM setups, this would cause performance issues and run-time errors.

#### DataMiner Cube - Alarm Console: Focus icon would not be displayed when a new alarm was added to an alarm group \[ID_32931\]

When an alarm was added to an alarm group while that group was expanded, the focus icon would incorrectly not be displayed.

#### Online SLA window would not get properly closed \[ID_32946\]

In some cases, an online SLA window would not get properly closed.

#### Memory leak in SLSpiHost \[ID_32970\]

In some cases, the SLSpiHost process could leak memory.

#### DataMiner Cube - Alarm Console: Incident alarms were incorrectly shown twice \[ID_32981\]

When, upon opening DataMiner Cube, the Alarm Console had an active alarms tab page with “Automatic incident tracking” enabled, in some cases, the incident alarms would incorrectly be shown twice.

#### DataMiner Cube: No longer possible to move DVE elements to another view \[ID_32984\]

In some cases, it would incorrectly no longer be possible to move DVE elements to another view.

#### NATS issue could cause a DataMiner Agent to not start up correctly \[ID_33026\]

In some cases, a NATS issue could cause a DataMiner Agent to not start up correctly.

#### Dashboards app - GQI: Problem while creating or updating a query when users did not have permission to view objects retrieved by a data source \[ID_33029\]

When users were creating or modifying a GQI query, in some cases, an exception could be thrown when those users did not have permission to view objects retrieved by a data source.

#### Problem when starting up SLNet \[ID_33033\]

In some cases, the following error would be logged in SLNet.txt with XYZ being the word “AUTHORITY” in a language other than English:

```txt
Connection did not authenticate. Computer: COMPUTERNAME Application: SLDataGateway User: NT-XYZ\SYSTEM
```

The problem would occur on systems installed in a language other than English and was caused by code looking for the NT-AUTHORITY\\SYSTEM user, which on these systems, was named differently.

#### Problem with SLLog when a log file was closed \[ID_33191\]

In some cases, an error could occur in the SLLog process when a log file was closed.

#### DataMiner Cube - Visual Overview: Spectrum shape would incorrectly show a grid instead of text \[ID_33192\]

When a shape was linked to a spectrum parameter with an ID between 50,000 and 60,000, in some cases, the shape would incorrectly show a grid instead of text.

#### Interactive Automation scripts: Slider linked to a numeric text box would incorrectly keep following the mouse pointer \[ID_33204\]

In interactive Automation scripts, in some cases, the slider linked to a numeric text box would incorrectly keep following the mouse pointer, even after the mouse button had been released.

## Addendum CU3

### CU3 enhancements

#### DataMiner Cube - Resources app: Function instance name can now be updated \[ID_32811\]

When updating a resource in the Resources app, it is now possible to change the function instance name, i.e. the name of the DVE element linked to a function resource.

> [!NOTE]
>
> - It is recommended to modify DVE names via the resource instead of via the main DVE element.
> - Names of DVE elements can also be modified in *General Parameters \> Resource Info \> DVE Table*.

#### DataMiner Taskbar Utility: Deprecated launch options for System Display and Cube removed \[ID_32877\]

In the DataMiner Taskbar Utility, the following options have been removed:

- Launching System Display by double-clicking while pressing the SHIFT key.
- Opening the locally installed DataMiner Cube in Microsoft Internet Explorer by double-clicking.

> [!NOTE]
> The following option has been kept:
>
> - Opening Windows file explorer in the C:\\Skyline DataMiner\\ folder by double-clicking while pressing the CTRL key.

#### Enhanced performance when starting up elements \[ID_33023\]

Because of a number of enhancements, overall performance has increased when starting up elements, especially elements containing large amounts of data.

#### DataMiner Cube & legacy Reporter app: Alarm state change graphs now differentiate between masked state and unknown state \[ID_33082\]

From now on, the alarm state change graphs (pie chart and time line) in the legacy Reporter app and the alarm state change pie chart on the REPORTS page of an element card in Cube will differentiate between masked state and unknown state.

Also, in the legacy Reporter app, the default colors have now been aligned with the default DataMiner alarm colors.

#### SLMessageBroker log files are now split per process and limited to 3 MB \[ID_33126\]

The SLMessagebroker log files are now split per process and limited to 3 MB.

These log files are stored in C:\\Skyline DataMiner\\Logging\\SLMessageBroker and are named SLMessageBroker\_\[processname\].txt. When a file exceeds the 3-MB limit, it is renamed to SLMessageBroker\_\[processname\]\_1.txt and a new file is created named SLMessageBroker\_\[processname\]\_2.txt.

> [!NOTE]
> These log files will not be deleted when the DataMiner Agent is upgraded.

#### Visual Overview: Enhanced performance when creating element shapes \[ID_33140\]

Because of a number of enhancements, overall performance has increased when creating element shapes.

#### Monitoring app now also takes into account Param.Message tags \[ID_33162\]

In a protocol.xml file, for every write parameter, you can specify a message to be displayed when users change that parameter on the UI.

Up to now, this *Param.Message* tag was only taken into account by DataMiner Cube. From now on, the Monitoring app will also take it into account.

#### SLDMS process is now large address aware \[ID_33234\]

SLDMS, which is a 32-bit process, will now be started with the /LARGEADDRESSAWARE flag. This way, it will be able to access up to 4GB of memory.

#### Enhanced performance when processing a large number of objects with links to other objects \[ID_33271\]

Because of a number of enhancements, overall performance has increased when processing (e.g. exporting) a large number of objects with links to other objects.

#### IPC channel port names will now always be unique \[ID_33274\]

IPC channel port names will now always be unique.

#### DataMiner Cube - System Center: 'Automatic incident tracking' feature will now be enabled by default \[ID_33286\]

In *System Center \> System settings \> Analytics config*, the *Automatic incident tracking* feature will now be enabled by default.

- If you upgrade from a DataMiner version older than 10.0.11, a new *Automatic incident tracking* section will be added to the *Analytics config* tab, and its *Enabled* setting will by default be set to “True”.
- If you upgrade from DataMiner version 10.0.11 until 10.1.11, the *Automatic incident tracking* section will now by default have its *Enabled* setting set to “True”. Up to now, it would by default be set to “False”.
- If you upgrade from DataMiner version 10.1.12 or newer, the *Automatic incident tracking* section, of which the *Enabled* setting was by default already set to “True”, will now even be set to “True” when it had been manually set to “False” earlier.

> [!NOTE]
> After the upgrade, all settings related to *Automatic incident tracking* will be reset to their default values. Any manual change made to any of these settings prior to the upgrade will be lost.

#### DataMiner Cube: Independent client updates \[ID_33360\]

When you connect DataMiner Cube to a DataMiner Agent with main release version 10.2.0 CU3 (or newer) or feature release version 10.2.6 (or newer), from now on, it will automatically update to the most recent version. This will allow you to use the latest Cube features as soon as they are released without having to wait for a DMA upgrade.

##### Client configuration

If you do not want to wait for the next automatic Cube update, in the start window of the Cube desktop app, click the cogwheel icon in the bottom-right corner, and select *Check for updates*. If a new Cube version is available, it will be downloaded. When the download has finished, a *Restart now* button will appear. Click it to start using the new version.

Two update tracks are available. Click the cogwheel icon in the bottom-right corner, and select *Settings*. If you open the Cube update track setting, you can select one of the following tracks:

| Track                     | Description                                                                                            |
|---------------------------|--------------------------------------------------------------------------------------------------------|
| Release                   | Use the latest released DataMiner Cube version, so you can enjoy all the latest and greatest features. |
| Release (delayed 2 weeks) | Wait to use the latest released DataMiner Cube version until 2 weeks after the release date.           |

If you want to use a specific Cube version to connect to a particular agent or cluster, then right-click an agent or cluster in the start window, and select a specific Cube version.

##### Server configuration

When connected to a particular DataMiner System, users with *Manage client versions* permission can go to *System Center \> System settings \> Manage client versions*, and select one of the following Cube update modes:

- Allow automatic updates
- Force the matching release version (i.e. force users to always use the Cube version that was shipped with the DMA upgrade package)
- Force a specific version (i.e. force users to always use a particular Cube version)

By default, the setting chosen here will apply to all agents in the DMS, including Failover setups. However, it is possible (but not recommended) to configure the Cube update mode per agent.

### CU3 fixes

#### QActionHelper DLL file could incorrectly be loaded twice \[ID_32647\]

In some rare cases, protocols could incorrectly load the QActionHelper DLL file twice.

#### DataMiner Cube - ListView component: Time zone would not be taken into account when setting the default time range interval \[ID_33011\]

When the client and the server did not have the same time zone, in some cases, the default time range interval of a ListView component could be set incorrectly. As a result, filtering by date/time could yield incorrect results.

From now on, the default time range of a ListView component will take into account the DataMiner time in UTC and the server time zone.

#### Hysteresis timer would incorrectly restart when a base line got updated \[ID_33015\]

When a base line got updated while a hysteresis timer was running on a table cell, in some cases, that timer would incorrectly restart.

#### Dashboards app - Node edge graph component: Node would not get positioned correctly by default \[ID_33068\]

Up to now, when the edges were unidirectional, the nodes would not get positioned correctly by default.

#### DataMiner Cube - Resources app: No update notifications would get broadcast within a client session when a resource was deleted from the cache \[ID_33070\]

When a resource was deleted from the cache of a Cube client, in some cases, no update notifications would get broadcast within the same client session.

#### Ticketing app: Problem when using the filter box \[ID_33079\]

When you entered a search string in the filter box, all tickets would incorrectly be returned.

#### DataMiner Cube - Automation: Problem when validating an Automation script \[ID_33084\]

When, in the Automation app, you validated an Automation script that either contained an empty line in the DLL references or had a DLL reference removed, in some cases, an “Empty path name is not legal” error could be thrown.

#### DataMiner Cube: REPORTS page of a masked element would incorrectly indicate that the element was in alarm instead of masked \[ID_33087\]

When you masked an alarm as well as its associated element, in DataMiner Cube, the REPORTS page of the element in question would incorrectly indicate that the element was in alarm instead of masked.

#### Business Intelligence: Problem with SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started \[ID_33098\]

In some cases, an error could occur in SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started.

Also, additional logging has been added to help debug and track SLA issues.

#### SLElement: Display key cache would not get properly cleaned up when a row was deleted \[ID_33114\]

In some cases, the display key cache of SLElement would not get properly cleaned up when a row was deleted. This could cause memory leaks when a protocol added or removed a large amount of rows.

#### DataMiner Cube - Visual Overview: Bitmap images would be missing when opening a cached version of a VDX file \[ID_33116\]

When a Visio file of type VDX contained bitmap images, in some cases, those images would be missing when you opened a cached version of that file.

#### DataMiner Agent would not start up when the computer name contained special characters \[ID_33137\]

In some cases, a DataMiner Agent would fail to start up when the computer name contained special characters (e.g. “ü”).

#### Dashboards app - GQI: Problem when a feed used by a query was changed while the query table was being sorted \[ID_33168\]

When a feed used by a GQI query was changed while the query table was being sorted, in some cases, the UI could become unresponsive.

#### Web apps - GQI: Column references could not be created for columns of which the name contained underscore characters \[ID_33169\]

In some cases, column references could not be created for columns of which the name contained underscore characters.

#### Web apps - GQI: Problem when retrieving ticket fields of type 'drop-down list' \[ID_33177\]

When ticket fields of type “drop-down list” were retrieved using a GQI query, in some cases, those fields would incorrectly not contain any values.

#### Visual Overview: Problems with SelectedServiceDefinition session variable and with commands for ServiceManager component \[ID_33188\]

The following issues could occur in Visual Overview:

- When a service definition was selected, it could occur that the *SelectedServiceDefinition* session variable was not updated.

- When the *Commands* shape data field was used, it could occur that setting commands on page or card level was not possible.

#### SNMP polling: Group with multiple tables of which some had the 'partialSNMP' option enabled would get re-polled indefinitely \[ID_33197\]

When a group that contained multiple tables of which some had the partialSNMP option enabled was polled, in some cases, that same group would incorrectly get re-polled indefinitely.

#### DataMiner Cube: Problem when logging in \[ID_32233\]

When you logged in to DataMiner Cube, in some cases, the loading process would no longer be shown. Also, a “Timeout while retrieving connection settings” error could be thrown.

#### Port 0 would incorrectly be used for serial communication when a dynamic IP parameter did not contain an IP port \[ID_33235\]

When a dynamic IP parameter was set to a value that contained only an IP address instead of an IP address and a IP port, then port 0 would incorrectly be used for serial communication.

From now on, when no IP port is specified, the last port set will be used. And if no port has been set yet, then the port configured in the element wizard will be used.

#### Application framework: Pages could not be loaded when previewing a draft version of an application that had not yet been published \[ID_33241\]

When previewing a draft version of an application, in some cases, pages could not be loaded when there was no published version yet.

#### Application framework: 'This panel' option not available when configuring a 'close a panel' action \[ID_33243\]

When configuring a “close a panel” action, in some cases, the “This panel” option would incorrectly not be available. From now on, this option will always be available and selected by default.

#### Application framework: Application would incorrectly open in edit mode after logging in \[ID_33254\]

When you logged out of an application and then logged back in again, in some cases, the application would incorrectly switch to edit mode.

#### PDF reports generated from a dashboard could no longer be uploaded to a shared folder \[ID_33256\]

When a PDF report was generated from a dashboard, in some cases, it would not be possible to upload that report to a shared folder.

#### Application framework: Table row action buttons would incorrectly always be displayed on the first column of a table \[ID_33258\]

Up to now, table row action buttons would incorrectly always be displayed on the first column of a table. As a result, those buttons would disappear when e.g. a filter was applied that caused the first column to be hidden. From now on, table row action buttons will instead always be displayed on the first visible column of a table.

#### Application framework: An 'http://' prefix would incorrectly be added to any URL that did not start with 'http://' \[ID_33262\]

Up to now, the application framework would incorrectly add an “http://” prefix to any URL that did not start with “http://”. From now on, all URLs will be validated first. Only if the URL is invalid (e.g. “skyline.be”) will an “http://” prefix be added.

#### Problem when trying to retrieve base parameter values after changing the production version of a protocol based on a base protocol \[ID_33288\]

After changing the production version of a protocol based on a so-called base protocol, it would no longer be possible to retrieve values from any of the base parameters (i.e. parameters of the base protocol).

#### Application framework: Minor issues fixed \[ID_33291\]

A number of minor issues have been fixed in the DataMiner Application Framework.

#### Problem when filtering a table with a foreign key relation to a remote table using a filter that contained a value from the remote table \[ID_33294\]

When a table with a foreign key relation to a remote table was filtered using a filter that contained a value from the remote table, up to now, all rows would incorrectly be returned when the remote table was empty. From now on, when the remote table is empty, no rows will be returned.

#### DataMiner Cube - Trending: Problem when zooming out on a trend graph \[ID_33298\]

When you zoomed out on a trend graph with a large number of data points, in some cases, the UI would become unresponsive.

#### Problem with SLDataMiner when a DMA started up while another DMA in the DMS was registering the SLAs \[ID_33303\]

When a DataMiner Agent started up while another DataMiner Agent in the DMS was registering the SLAs, in some cases, an error could occur in the SLDataMiner process.

#### Filtering issue when requesting bookings from 2 different time ranges \[ID_33312\]

When bookings were requested from the server, and a filter was used to first retrieve bookings from the distant future and then from the near future, it could occur that the latter could not be retrieved because of a problem with the filtering.

#### Application framework: Table rows sorted incorrect after refetching the table data \[ID_33323\]

When a table component refetched the table data, in some cases, the table rows would not be sorted correctly.

#### Remote direct views would no longer work when the DirectViewRemoteDataUpdates soft-launch option was disabled \[ID_33326\]

Remote direct views would no longer work when the DirectViewRemoteDataUpdates soft-launch option was disabled.

#### Web apps - Data table component: Query placeholders would incorrectly be displayed as values when the GQI query did not return any rows \[ID_33372\]

When a GQI query did not return any rows, the data table component would incorrectly display the query placeholders as values. From now on, when a GQI query does not return any rows, the data table component will display a message, saying that no data is available.

## Addendum CU4

### CU4 enhancements

#### Security enhancements \[ID_33242\] \[ID_33373\] \[ID_33479\]

A number of security enhancements have been made.

#### New option to enable/disable DCF interface state calculation on system level \[ID_31591\]

On protocol level, you can enable or disable DCF interface state calculation by setting the Protocol.ParameterGroups.Group@calculateAlarmState attribute to either true or false.

From now on, you will also be able to enable or disable this setting on system level. To do so, open the C:\\Skyline DataMiner\\MaintenanceSettings.xml file and set the ProtocolSettings.DCF.CalculateAlarmState element to either true or false.

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
  <ProtocolSettings>
    <DCF>
      <CalculateAlarmState>false</CalculateAlarmState>
    </DCF>
  </ProtocolSettings>
</MaintenanceSettings>
```

> [!NOTE]
>
> - This setting can only be configured in MaintenanceSettings.xml.
> - When you change this setting, the change will only be applied after a DataMiner restart.
> - The protocol-level setting will overrule the system-level setting.

#### QActionTable class - FillArray and FillArrayNoDelete methods: Argument 'row' renamed to 'columns' \[ID_33034\]

The *row* argument of the FillArray and FillArrayNoDelete methods in theQActionTable class has been renamed to *columns*.

#### DataMiner Application Framework: Tooltips on sidebar of root page \[ID_33275\]

When you click the apps button in the top-left corner of the root page and then hover over an app in the app list, a tooltip will now show the name of that app.

#### SLPort: Enhanced performance when processing large HTTP responses \[ID_33128\]

Because of a number of enhancements, overall performance of SLPort has increased when processing large HTTP responses.

#### SLProtocol: SetParameterIndexByKey and SetParametersIndexByKey methods can now also be used to update a single cell \[ID_33198\]

From now on, the SetParameterIndexByKey and SetParametersIndexByKey methods can also be used to update a single cell.

#### System Center - Failover Config: Miscellaneous UI enhancements \[ID_33245\]

A number of enhancements have been made to the Failover Config window. See below for a summary.

##### General

- The status indicator is now clickable and opens the status page when clicked.
- When the status page opens, the status indicator will now show the last known status until the first refresh.
- When the second agent is added,

  - the IP address or hostname of that second agent is checked to determine whether it refers to a valid DataMiner Agent, and
  - the DataMiner IDs of both agents are checked. In a Failover setup, both must be identical.

- Advanced options:

  - Synchronization NICs are automatically suggested for new setups. The list will now display the actual NIC names instead of the corporate/acquisition names.
  - Heartbeats are automatically suggested for new setups. The list will now display the actual NIC names instead of the corporate/acquisition names.
  - When a new heartbeat is added, the first NIC will automatically be selected.

##### Failover with virtual IP address

- Subnet masks for IP inputs will be suggested based on the current subnet of the DMA.
- The local IP address will no longer be suggested as virtual IP address.
- All known information regarding the valid corporate IP addresses will be filled in automatically (hostname, acquisition IP address and subnet masks)
- It is now mandatory to fill in all three corporate IP addresses.
- It is no longer possible to switch from Failover with virtual IP address to Failover with hostnames when Failover with virtual IP address is active.
- In the advanced options, the (virtual) IP address information will be automatically filled in for new setups.

##### Failover with hostnames

- When setting up a new Failover with hostnames, in the hostname setup, the hostname will now be displayed instead of the IP address. If Failover with hostnames has already been set up, the hostname setup will display the currently used hostnames.
- It is now mandatory to fill in all three hostnames.
- It is no longer possible to switch from Failover with hostnames to Failover with virtual IP address when Failover with hostnames is active.

#### DataMiner Cube - System Center: Additional log files \[ID_33355\]

When, in *System Center*, you go to *Logging \> DataMiner*, you can now inspect the following additional log files:

- SLHistoryManager.txt
- SLIncrementManager.txt
- SLManagerStore.txt
- SLMasterSyncerManager.txt
- SLMigrationManager.txt
- SLModuleSettingsManager.txt
- SLProcessAutomationManager.txt
- SLSRMSettableServiceStateManager.txt
- SLVisualManager.txt

#### Ticketing app: Tickets can now be filtered on fields of type 'drop-down list' \[ID_33370\]

In the Ticketing app, tickets can now also be filtered on fields of type “drop-down list”.

#### VerifyClusterPorts.dmupgrade package can no longer be run on a single DMA \[ID_33429\]

The VerifyClusterPorts package can be used to check whether all agents of a DataMiner System are able to reach all other agents in the same DataMiner System over the ports used by NATS. This way, firewall configuration issues between servers can easily be detected.

When you run the package on a single agent, the results may be incorrect or confusing. From now on, the package will report an error when you try to run it on a single agent.

#### SLDataGateway: Enhanced performance \[ID_33464\]

Because of a number of enhancements, overall performance of SLDataGateway has increased.

#### DataMiner Cube - Visual Overview: Shape that displays a page of the Visio drawing linked to a view, service or element will no longer be displayed when the element, service or view in question does not exist \[ID_33484\]

From now on, a shape that displays a page of the Visio drawing linked to a view, service or element (i.e. a shape with a shape data field of type VdxPage) will no longer be displayed when the view, service or element in question does not exist.

#### SLLogCollector will now also collect the VerifyClusterPorts files \[ID_33503\]

SLLogCollector will now also collect the following VerifyClusterPorts files:

- C:\\Skyline DataMiner\\Upgrades\\Helper\\VerifyClusterPorts\\VerifyClusterPorts.crash.txt
- C:\\Skyline DataMiner\\Upgrades\\Helper\\VerifyClusterPorts\\VerifyClusterPorts.LastRun.xml

#### DataMiner Cube: Enhanced performance when using the search box in the Cube header \[ID_33510\]

Because of a number of enhancements, overall performance has increased when using the search box in the Cube header.

#### SLLogCollector will now also collect the log files of the ArtifactDeployer, CloudFeed and Orchestrator processes \[ID_33514\]

SLLogCollector will now also collect the log files of the following cloud processes:

- ArtifactDeployer
- CloudFeed
- Orchestrator

#### SLElement: Enhanced performance when processing service and DCF information \[ID_33635\]

Because of a number of enhancements, overall performance of SLElement has improved when processing service and DCF information.

### CU4 fixes

#### Protocol QActions: Problem when calling FillArray or FillArrayNoDelete with List\<object\[\]\> as columns value \[ID_28573\]

When, in a QAction, protocol.FillArray or protocol.FillArrayNoDelete were called with List\<object\[\]\> as columns value, an exception would be thrown.

#### Problem with synchronization of SLAnalytics configuration settings \[ID_31825\]

In some cases, SLAnalytics configuration settings would be constantly synchronized among agents in a DataMiner System. From now on, automatic synchronization of SLAnalytics configuration settings will be limited to once an hour.

#### DataMiner Cube - Logging: Entries in the 'Communication' tab would not get cleaned up as long as System Center was kept open \[ID_33085\]

When, in *System Center*, you opened the *Logging* section, entries would be added in the *Communication* tab as long as *System Center* was kept open. The cleanup settings specified in *Settings \> Computer \> Advanced \> Communication* would incorrectly not be applied. On systems with a large amount of traffic, this could lead to memory problems.

From now on, the above-mentioned cleanup settings will be applied correctly.

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated \[ID_33153\]

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

#### Failover: Problem when updating agent states in the Failover subtag of DMS.xml \[ID_33160\]

In some cases, an error could occur when updating agent states in the Failover subtag in the DMS.xml file. This could cause both agents to try to go either offline or online.

#### Failover: Problem when the Cassandra service was unexpectedly started by DataMiner during setup \[ID_33161\]

When a Failover system was being set up, an error could occur when the Cassandra service was unexpectedly started by DataMiner.

#### Protocols: WebSocket ports incorrectly interpreted as HTTP ports \[ID_33220\]

When you created an element with a protocol in which a WebSocket connection was configured as shown in the example below, up to now, the connection would incorrectly be interpreted as an HTTP port instead of a WebSocket port.

```xml
<Connections>
  <Connection id="0" name="WebSocket Interface">
    <Http>
      <CommunicationOptions>
        <WebSocket>true</WebSocket>
        <NotifyConnectionPIDs>
          <Connections>6</Connections>
        </NotifyConnectionPIDs>
      </CommunicationOptions>
    </Http>
  </Connection>
</Connections>
```

#### DataMiner Cube - Alarm Console: Incorrect values shown in summary alarms \[ID_33238\]

When, in the Alarm Console, you enable the alarm storm mode, the alarms are grouped into one summary alarm per parameter. In some rare cases, the values shown in those summary alarms could be incorrect.

#### Dashboards: Not possible to share dashboards that contained query components of which the 'Update data' option was enabled \[ID_33267\]

Up to now, it would not be possible for users to share dashboards that contained GQI components of which the *Update data* option was enabled.

#### Replicated main DVE element would incorrectly execute a sequence twice \[ID_33270\]

When, inside a replicated DVE parent element, the exporting DVE table that contained the column with DVE element IDs also contained a column with a \<Sequence>, then that sequence would incorrectly be executed twice on the replicated element.

#### DataMiner Cube - Trending: Legend would incorrectly show a unit when hovering over an exception value \[ID_33280\]

When, in a trend graph, you hovered the mouse pointer over an exception value, the legend would not only show the minimum value, the maximum value and the value of the data point, but also incorrectly a unit. From now on, when you hover over an exception value, the legend will no longer show a unit.

#### Values in a decimal logger table column would lose their decimals when the element was restarted or the database was queried \[ID_33315\]

When, in a logger table, a column with \<ColumnDefinition>DECIMAL\</ColumnDefinition> contained a value with decimals, then those decimals would be lost when the element was restarted or the database was queried.

#### DataMiner Cube - Alarm Console: Problem when playing a spectrum recording \[ID_33335\]

When, in the Alarm Console, you right-clicked an alarm on a spectrum element and selected *Open \> Spectrum recording*, the recording would incorrectly not be played. The spectrum element was opened instead.

#### SNMP forwarding: Problem with OID logging \[ID_33338\]

In the SNMP Managers log, in some cases, OIDs would incorrectly be replaced by hexadecimal numbers.

Also, when a table column contained an OID in an incorrect format, the table would only contain the first row up to the column with that incorrectly formatted OID. The rest of the rows would be missing. From now on, when an incorrectly formatted OID is detected, the table will no longer contain any data and Stream Viewer will show an error containing the OID in question.

#### Incorrect IP address could be added to DMS.xml during a DataMiner startup \[ID_33339\]

When the DataMiner software started up on an agent that was not part of a Failover setup, in some cases, an incorrect IP address could get added to the DMS.xml file. Later on, this could lead to e.g. agent synchronization issues.

#### DataMiner Cube: No longer possible to go to the previous or the next frame after pausing a replay of a spectrum recording \[ID_33349\]

When you paused a replay of a spectrum recording, in some cases, it would no longer be possible to go to either the previous or the next frame.

#### DataMiner upgrades: Problems related to upgrade prerequisites \[ID_33353\]

A number of issues were solved related to how DataMiner executes prerequisites as part of a DataMiner upgrade.

#### Automation scripts would incorrectly succeed even when uploading a report had failed \[ID_33368\]

When, in an Automation script, you had configured an action that uploads a report to a shared folder or FTP, up to now, the script would still succeed even when it had not been able to copy the generated report to the remote location (shared folder or FTP). From now on, when a script is not able to copy a report to a remote location, it will fail.

#### DataMiner Cube - Alarm Console: Incidents would incorrectly appear when enabling 'Automatic incident tracking' in an Information tab \[ID_33382\]

When you enabled the *Automatic incident tracking* option in an Information tab, the incidents (i.e. alarm groups) would incorrectly appear in that tab.

#### DataMiner Cube: Casing incorrectly not taken into account when comparing the name of a newly created property against the existing property names \[ID_33388\]

When you created a new view, element, service or alarm property, up to now, the name of that new property would be checked against all existing property names without taking the casing into account. From now on, when the name of a newly created property is checked against existing property names, the casing will be taken into account.

#### Protocols: Mediation base protocols not available to DVE elements \[ID_33392\]

When a base protocol for a DVE element was configured at runtime, up to now, that base protocol would incorrectly only be taken into account after a DataMiner restart.

Also, after a DataMiner restart, only the base protocols of the main DVE element would be made available, even in situations where DVE child elements did not have the same base protocols as the DVE main element.

#### Protocols: \<UserSettings> element would not be taken into account when a new element was created \[ID_33394\]

When a protocol.xml file using the latest \<Connections> syntax contained a \<UserSettings> element, the user settings specified in the \<UserSettings> element would incorrectly not be taken into account when a new element was created.

#### Errors when different protocol selection for element was incompatible with existing SNMPv1 connection \[ID_33406\]

When a different protocol was selected for an element, causing one of the connections to no longer be compatible with SNMPv1, this could cause "Element not known yet" errors during polling and potentially even RTEs. To prevent this, the element will now be placed in an error state in such a case.

#### Service & Resource Management: Primary key of FunctionResource would be set to an invalid value after an update \[ID_33412\]

When an existing FunctionResource object was updated, in some cases, the primary key would be set to an invalid value.

#### Problems related to alarms \[ID_33413\]

A number of alarm-related issues have been fixed:

- When advanced naming was configured to create a display key that contained parameters from linked tables, in some cases, the service impact of the alarms would be incorrect.

- When a new row was added to a table, in some cases, the conditional monitoring based on service impact alarming would be incorrect.

- In some cases, alarms retrieved from the database would contain outdated fields in the alarm tree.

#### Interactive Automation scripts: Range limits of a numeric IBlockDefinition would be ignored \[ID_33419\]

When an Automation script was launch from the Dashboards app or from a custom web app, in some cases, the range limits of a numeric IBlockDefinition would be ignored when you clicked the Up or Down button.

#### Automation scripts: Problem with processor directives \[ID_33424\]

Up to now, the following preprocessor directives would incorrectly be inserted into the Automation script code, causing syntax errors to appear on the incorrect lines.

- #define DBInfo
- #define DCFv1
- #define ALARM_SQUASHING

#### Log entry containing an incorrect number of timers would be added to the element log file when an element was stopped \[ID_33438\]

When you stopped an element, an entry containing an incorrect number of timers would be added to the element log file. See the example below.

```txt
CProtocol::HaltPolling|INF|0|-- -7599514566606716925 timers to stop
```

#### DataMiner Cube - Visual Overview: No longer possible to filter Alarm Console tabs when clicking an AlarmFilter shape \[ID_33443\]

If you add a shape data field of type *AlarmFilter* to a shape, clicking the shape will cause Alarm Console tabs of type *Active alarms linked to cards* only to show alarms that match the alarm filter specified in the field value. However, in some cases, this no longer worked.

#### Problem when trying to migrate elements of which the name contained square brackets \[ID_33455\]

When you tried to migrate an element with a name containing square brackets (e.g. “\[HQ\] Main Switch”), in some cases, the operation could fail with an error message like “Illegal 'Reference Protocol' syntax”.

#### DataMiner Cube - Visual Overview: Problems with History Mode shape data field \[ID_33456\]

When a shape linked to a parameter had a *History Mode* shape data field set to “State=On”, in some cases, no units would be shown. Also, in case of a parameter with discreet values, the shape would incorrectly show the actual value instead of the display value.

#### Interactive Automation scripts: Tree view component would incorrectly collapse when selecting an item that unselected the previously selected item \[ID_33480\]

When, in a tree view component of an interactive Automation script, you selected an item that unselected the previously selected item, in some cases, the entire tree view component would incorrectly collapse.

#### Automatic Incident Tracking: Clearable base alarms of an incident were cleared when the incident was cleared \[ID_33481\]

When an incident (i.e. alarm group) was cleared, in some cases, its clearable base alarms would incorrectly be cleared as well when the AutoClear option was disabled.

#### Problem when running multiple GQI queries simultaneously \[ID_33482\]

When multiple GQI queries were run simultaneously, in some rare cases, a “There are no open sessions” exception could be thrown.

#### Automation: SetParameterByPrimaryKey would fail to update a write-only parameter when using the parameter name as argument \[ID_33511\]

When, from an Automation script, a write parameter in a column of a table inside an element was updated using a ScriptDummy.SetParameterByPrimaryKey call with the parameter name as argument, the update would fail when that write parameter did not have a matching read parameter.

#### Problem when deleting a DVE child element or a virtual function \[ID_33519\]

When a DVE child element or a virtual function was deleted, all data related to the main DVE element and the other DVE child elements and virtual functions would incorrectly also be deleted from the service cache. As a result, alarm updates would no longer affect the services.

#### VerifyClusterPorts.dmupgrade package failed to run when it no longer had its original name \[ID_33529\]

When the VerifyClusterPorts.dmupgrade package no longer had its original name (e.g. “VerfiyClusterPorts (1).dmupgrade”), it would fail to run.

From now on, the name of the package is allowed to have a prefix and/or a suffix. In other words, its name must match \*VerifyClusterPorts\*.dmupgrade.

#### Problem with SLElement when updating bubble-up levels \[ID_33542\]

In some rare cases, an error could occur in SLElement when updating the bubble-up levels.

#### DataMiner Cube - Resources app: prevent updating new unsaved resource with updated existing resource \[ID_33543\]

In some cases, when the data related to a newly created resource was not yet saved on the DataMiner Agent, in the UI, that data would incorrectly be replaced by data related to another resource.

#### Upgrading to DataMiner 10.2.0 Main Release did not install Microsoft .NET 5 \[ID_33557\]

Up to now, Microsoft .NET 5 would incorrectly not get installed when you upgraded to DataMiner 10.2.0 Main Release.

#### Problem in SLSNMPManager when element using SNMP polling was stopped \[ID_33563\]

When an element using SNMP polling was stopped, a problem could occur in the SLSNMPManager process. The cause of this was that the polling did not stop and requests kept being sent, leading to a stack overflow. To prevent this, now an error has been added when data is requested while the polling is halted.

#### DataMiner Cube desktop app: Problem when installed by means of an MSI package \[ID_33590\]

When using a DataMiner Cube desktop application that had been installed by means of an MSI package, in some cases, the following errors could be thrown:

- *The required version is not available.*
- *Value cannot be null.*

## Addendum CU5

### CU5 enhancements

#### Security enhancements \[ID_33684\]

A number of security enhancements have been made.

#### DataMiner Cube - ListView component: No longer possible to filter on columns of type datetime \[ID_32900\]

In the ListView Component, from now on, it is no longer possible to filter on columns of type datetime.

#### Failover: Current Failover DMA status will now automatically be refreshed every minute \[ID_33426\]

In the *Failover Config* window as well as the *Status* dialog box, the current Failover DMA status will now automatically be refreshed every minute.

#### Enhanced BPA error message \[ID_33393\]

Up to now, when a BPA test could not be executed on an offline Failover agent, it would return the following error message:

```txt
This BPA does not apply for this DataMiner Agent.
```

From now on, it will return the following error message instead:

```txt
This BPA does not apply for this DataMiner Agent: cannot run on Offline Failover Agent.
```

#### GQI queries: Enhanced performance when retrieving custom properties \[ID_33538\]

Because of a number of enhancements, overall GQI query performance has increased when retrieving custom properties for views, services and elements.

#### DataMiner Upgrade: Additional action to delete legacy custom data templates \[ID_33628\]

In DataMiner main version 10.0.0 CU11 and feature version 10.1.1, new Elasticsearch templates for custom data indices were introduced to support adding new fields after index creation. An upgrade action has now been added to remove all legacy Elasticsearch templates from the system. During the first DataMiner startup after the upgrade, the templates will then be recreated.

#### Business Intelligence: Enhancements made to the automatic SLA data clean-up mechanism \[ID_33663\]

A number of enhancements have been made to the automatic SLA data clean-up mechanism.

#### DataMiner Cube - System Center: Enhancements made to Failover Configuration window \[ID_33747\]

In DataMiner Cube, the following enhancements have been made to the *Failover Configuration* window:

- In the *Advanced \> Virtual IP Addresses* tab, the columns are now wide enough to display the full IP address/mask.
- The *Advanced \> Heartbeats* tab now indicates which heartbeats are inverted.

#### Clearer error message will now appear when a DataMiner Agent cannot be reached \[ID_33752\]

When a DataMiner Agent could not be reached, in some cases, an “Attempt to use an unauthenticated connection” error would appear in the log files or on the UI. From now on, a clearer error message will appear instead.

### CU5 fixes

#### Problem with SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped \[ID_33437\]

In some cases, an error could occur in SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped.

#### Problems when migrating data from SQL to Cassandra \[ID_33524\]

In some cases, the following issues could occur when migrating data from SQL to Cassandra:

- Online migration would be executed, but would not get marked as completed in Cube.
- Offline migration would fail to launch.

Also, Cube will no longer throw “System.InvalidOperationException: Collection was modified” errors.

#### DataMiner Cube: Properties of exported elements would not be added to the CSV file in the correct order \[ID_33528\]

When you had exported elements to a CSV file, the element properties would not be added to the CSV file in the correct order.

#### Booking instance created before DMA restart not starting \[ID_33556\]

In some cases, it could occur that a booking instance did not start. More specifically, this happened if the booking instance was created with a start time in the future, and the hosting Agent of the instance was restarted before that start time. After the Agent restart, the booking instance was not immediately loaded into the cache of the hosting Agent. If the custom properties of the booking instance were then updated, but no other updates happened to the booking instance before its start time, it would not start.

#### DataMiner Cube - Data Display: Problems with button and date/time picker sizing \[ID_33601\]

In some cases, the width of a button would not automatically be adapted to the text displayed on the button.

Also, in date/time picker controls, the buttons to pick or clear a date/time would not be displayed correctly.

#### DataMiner Cube - Annotations: Images would get removed when saving an annotation \[ID_33623\]

When you saved an annotation, in some cases, any images added to the annotation would incorrectly get removed.

#### DataMiner Cube - Trending: Creation, update and deletion of a trend pattern would not be communicated to the other DataMiner Agents in the DMS \[ID_33624\]

When you created, updated or deleted a tag, up to now, this would incorrectly not be communicated to the other DataMiner Agents in the DMS.

#### Web apps: Minor theme and color issues \[ID_33631\]

When you opened a side panel that used the Skyline Black theme, in some cases, the overlay would incorrectly use the (default) white theme.

Also, when you opened an app, the name of that app would incorrectly be displayed in green. From now on, the name of the app will be displayed in the color of the app.

#### DataMiner Cube - Data Display: Buttons inside a table would incorrectly be grayed out when scrolling \[ID_33641\]

When scrolling through a table of which the rows contained buttons, in some cases, those buttons would incorrectly be grayed out.

#### DataMiner Cube - Visual Overview: Problem when dynamically generating booking shapes \[ID_33676\]

When, in Visual Overview, a shape had to be created automatically for each booking in a particular set of bookings, in some cases, a subscription error would prevent these shapes from being created.

#### Serializing/deserializing would not work when dictionary key contained spaces \[ID_33677\]

Up to now, serializing/deserializing would not work when creating a filter that contained spaces inside quotes (see the example below).

Example:

```txt
AlarmEventMessageExposers.PropertiesDict.DictStringField($"Booking Manager Element ID").Matches(".+")
```

#### Service & Resource Management: Problem when adding, updating or deleting a resource \[ID_33678\]

When you tried to add, update or delete a resource, a NullReferenceException could be thrown when the Resources.xml file was locked by another process.

#### DataMiner Cube - Spectrum Analysis: Problem with 'Next trace' button and slider after a spectrum recording had been paused \[ID_33718\]

When you had paused the replay of a spectrum recording, in some cases, the “next trace” button and the slider would not work correctly.

#### No alarm would be generated when an element that exported data failed to start \[ID_33744\]

When an error occurred during the startup of an element that exported data (e.g. a DVE or function element), in some cases, no alarm would be generated.

#### Web services API: High CPU usage when executing web methods \[ID_33746\]

In some rare cases, CPU usage would increase when executing web methods.

#### Web apps - Node edge graph: Node tooltips did not have the correct color \[ID_33757\]

In a node edge graph, in some cases, the node tooltips did not have the correct color.

#### SLWatchdog: Problem when generating the database report \[ID_33769\]

In some cases, an error could occur in SLWatchdog when generating the database report.

#### DataMiner Cube - Elements: Problem when selecting the Replicate checkbox before selecting a DMA \[ID_33773\]

When, while creating a new element on a DataMiner Agent in a DMS, you selected the *Replicate* checkbox without first selecting a DataMiner Agent, the *Replicate Element* settings would not be shown and the *Device Details* would remain unavailable.

From now on, the Replicate checkbox will be unavailable as long as no DataMiner has been selected.

#### Failover: Problem with AlwaysBruteForceOffline option \[ID_33775\]

The following problems with the Failover option *AlwaysBruteForceOffline* have now been fixed:

- When configured via an UpdateFailoverConfigMessage in an Automation script, the option would not be applied in the DMS.xml file.
- When configured by manually updating the DMS.xml file, the option would be overwritten.
- When applied, the option would cause the DMA to restart without also restarting SLNet.

> [!NOTE]
> In DataMiner Cube, the *AlwaysBruteForceOffline* option can now be configured by enabling or disabling the *Auto restart agent when going offline* option in the *Advanced options* tab of the *Advanced Failover Configuration* window.

#### DataMiner Cube - System Center: Enforcing a client version would not work \[ID_33802\]

When connected to a particular DataMiner System, users with *Manage client versions* permission can go to *System Center \> System settings \> Manage client versions* and force users to always use a particular Cube version. In some cases, this would not work. The following error message would appear: “Error: file already exists but has incorrect size”.

#### DataMiner Cube: User permission 'Manage client versions' was not positioned correctly in the user permission hierarchy \[ID_33845\]

The “Manage client versions” user permission was not positioned correctly in the user permission hierarchy and did not have a translatable description.

#### SNMP: Former value of updated cell would incorrectly be returned the first time the table was polled after the update \[ID_33855\]

When a cell in a table with “pollingrate” enabled had been updated, the first time the table was polled after the update, the former value of that cell would incorrectly be returned.

#### Protocols: Additional connections with a 'Type' defined would incorrectly be ignored \[ID_33941\]

Additional connections that had a “\<Type>” defined would incorrectly no longer be taken into account.

In the following example, the second connection would incorrectly be ignored.

```xml
<Connections>
  <Connection id="0" name="HTTP Connection">
    <Type>http</Type>
    ...
  </Connection>
  <Connection id="1" name="WebSocket Interface">
    <Type>http</Type>
    ...
```

> [!NOTE]
> Specifying a type with \`\<Type>\` for one connection and specifying a type with e.g. \`\<Http>\` for another connection is not supported.

## Addendum CU6

### CU6 enhancements

#### Security enhancements

A number of security enhancements have been made.

#### SAML authentication: Azure Active Directory B2C now also supported as identity provider ID_32714]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.6 -->

For external authentication using SAML, DataMiner now also supports Azure Active Directory B2C as an identity provider.

Also, when creating a DataMiner user, using an email address as user name is now mandatory.

> [!NOTE]
> If, in DataMiner.xml, the default user name of an identity provider is not a valid email address, you can optionally add a \<PreferredLoginClaim> element that refers to a claim that contains a valid email address.

#### Cassandra Cluster Migrator: Enhanced resilience of the migration process [ID_33467] [ID_33621] [ID_33727]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

The migration process will now be executed partition by partition. This greatly enhances the overall resilience of that process.

When the source database is a Cassandra database, at the end of a migration process, the Migrator tool will now automatically retry to migrate the partitions that could not be migrated the first time. Moreover, when you manually restart a migration with failed partitions, only those failed partitions will be included in the new migration attempt. The migration will no longer have to be redone from scratch.

Also, additional fail-safes have been built in to cope with situations where the target Cassandra database cannot be reached.

#### NATS: Enhancements to the NATS configuration [ID_33558] [ID_33931]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

A number of enhancements have been made to the NATS configuration:

- STAN clustering has been removed.

- New NATSForceManualConfig option to disable the automatic reset timer in NATSCustodian.

  Disabling the timer can be done in one of the following ways:

  - Set the SLNet option **NATSForceManualConfig** to true in the SLNetClientTest tool (default = false).
  - Set the **SLNet.NATSForceManualConfig** tag to true in *MaintenanceSettings.xml*.

  > [!NOTE]
  >
  > - Changing this option in the SLNetClientTest tool can be done at run-time. The change will be applied immediately.
  > - Forcing manual configuration will disable the automatic NATS configuration on the DataMiner System. It will then be up to the user to either manually configure a NATS cluster or manually call NatsCustodianResetNatsMessage when changes are made to the DMS.

- On DataMiner startup, NAS and NATS will now automatically be started if they are not running.

Also, the nats-streaming-server binary has been updated to v0.24.6. However, note that it will not be updated automatically via upgrade actions. It will only be installed during fresh NATS installations or when reinstalling NATS via SLEndpointTool_Console. The previous version (v0.22.0) and the new version (v0.24.6) version are compatible and are able to communicate with each other.

#### Dashboards app: Enhanced 'loading' indication when state component linked to a GQI query receives an update [ID_33640]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

Up to now, each time a state component linked to a GQI query received an update, a *loading* indication would be displayed over the entire component. From now on, when such a component receives an update, a more subtle loader bar will be displayed instead.

Also, when a query error occur, from now on, the actual error will be displayed instead of "No data".

#### GQI: Enhanced performance when running a GQI query with a filter applied to it [ID_33664]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

Because of a number of enhancements, overall performance has improved when running a GQI query with a filter applied to it.

#### Serial connections: Hostname resolution enhancements [ID_33702]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a serial connection was configured with a hostname instead of an IP address, up to now, the hostname would be resolved when the port was initialized. When the hostname suddenly pointed to a different IP address, an element restart or a dynamic IP address change was needed for the serial connection to be aware of that change.

This has now been changed:

- In case of a TCP-oriented serial connection (serial SSL/TLS, SSH and serial TCP), the hostname will be resolved upon every connect.
- In case of a UDP-oriented serial connection (serial UDP), the hostname will be resolved prior to every send.

#### Web apps now also support parameter comments configured in Param.Message elements [ID_33784]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When configuring a parameter in a protocol, you can add a `<Message>` element containing a comment to be displayed in a confirmation box when users change that parameter on the user interface. Up to now, this `<Message>` element was only supported by DataMiner Cube. It is now also supported by web applications like Monitoring and Dashboards.

#### SLPort: Order of parameters in an HTTP session request will be identical to that in the protocol [ID_33796]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In an HTTP session request, the order of the parameters will now always be identical to that in the protocol.

#### Failover: Enhanced performance of SLNet when communicating via NATS [ID_33807]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On Failover systems, because of a number of enhancements, overall performance of SLNet has increased when communicating via NATS.

#### DVE function protocol version of active functions will now be deleted when the main DVE protocol version is deleted [ID_33834]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a version of a DVE protocol with function DVE protocols is deleted from the system while functions are active, from now on, the function DVE protocol versions associated with those active functions will also be removed from the system.

#### Dashboards app: Parameter tables can now expose index values & Edit panel now allows selecting a specific protocol version [ID_33841]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, a parameter table was only able to expose indices as part of a parameter value. From now on, a parameter table will also be able to expose indices as separate values.

Also, the edit panel will now allow users to select a specific protocol version.

#### Alarm Console: Time of history sets will now always be converted to the local time zone [ID_33849]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

From now on, the time of history sets will always be converted to the local time zone.

#### Alarm Console - Proactive cap detection: Reduction of false positive matches [ID_33871]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When trend data is often getting close to the low or high value of a data range, this data range value will no longer be considered as a critical data boundary. This will reduce the number of false positive matches.

#### GQI: Table columns of type decimal can now also be used when filtering or aggregating data [ID_33927]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Table columns of type "decimal" can now also be used when filtering or aggregating data.

#### SLLogCollector: Enhanced processing of SLProtocol memory dumps [ID_33932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, SLLogCollector is now better able to collect SLProtocol memory dumps, especially in cases where there is no reference to an element.

#### SLSNMPManager: Enhanced performance [ID_33940]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the SLSNMPManager process has improved.

#### New BPA test 'Verify Cloud DxM Version' [ID_33956]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 [CU0] -->

This new BPA test checks if the minimum required version is installed for all DxMs in the system.

It is available from DataMiner 10.2.8 and 10.2.0 [CU6] onwards. You can run it in System Center (on the *Agents > BPA* tab), and it also runs automatically when you upgrade to 10.2.0 [CU6]/10.2.8 or higher.

For more information, see [Verify Cloud DxM Version](xref:BPA_Verify_Cloud_DxM_Version).

#### Enhanced error handling in case QActions fail due to a problem with SLScripting [ID_34010]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an error occurs in SLScripting, from now on, a new SLScripting instance will be started and all QActions will be reloaded.

#### Alarm Console: A run-time error will now appear when the Resource Manager failed to initialize [ID_34024]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

From now on, the following run-time error will appear in the Alarm Console when the Resource Manager failed to initialized.

```txt
An unexpected exception has occurred while initializing Resource Manager. Please check the SLResourceManager logging for more information.
```

#### Parameter changes will now only be pushed from SLProtocol to SLElement when needed [ID_34047]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, parameter changes would always be pushed from SLProtocol to SLElement. From now, those changes will only be pushed from SLProtocol to SLElement when needed.

#### Size of the WebSocket messages sent from SLPort to SLProtocol will now be limited to 1024 packets [ID_34049]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 [CU1] -->

In order to prevent SLPort from running out of memory, from now on, the size of the WebSocket messages sent from SLPort to SLProtocol will be limited to 1024 packets.

#### GQI: Properties marked as 'read only' will now also be available [ID_34052]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When creating GQI queries, custom view, element, service and alarm properties that are marked as "read only" will now also be available.

#### Web apps: Enhanced performance when retrieving booking information [ID_34072]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance has increased when retrieving booking information in the Dashboards app and in low-code apps.

#### Dashboards app: Enhanced performance when editing a dashboard containing GQI queries [ID_34096]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in the Dashboards app, you switched to edit mode, all columns of all GQI queries on the dashboard in question would be retrieved. From now, only when you open a specific query on the dashboard you are editing will the columns of that specific query be retrieved.

### CU6 fixes

#### SLAnalytics - Pattern matching: No 'suggestion event' type alarm would be triggered in case of DVE elements [ID_32671]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.5 -->

From DataMiner 10.0.13 onwards, you can activate alarm monitoring of trend patterns, so that a "suggestion event" type alarm is triggered whenever a specific pattern is detected. In case of dynamic virtual elements, in some cases, no "suggestion event" type alarm would be triggered.

#### SLLogCollector would become unresponsive when the name of the process or the path where the files had to be stored contained spaces [ID_33493]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While collecting log information, SLLogCollector would become unresponsive when the name of the process or the path where the collected files had to be stored contained spaces.

#### GQI: Datetime values in retrieved booking information would incorrectly not be converted to UTC time [ID_33607]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When a GQI query retrieved booking information, the datetime values would incorrectly not be converted to UTC time.

#### Monitoring app: Trend graph of table column parameter not displayed when table row index contained forward slash [ID_33661]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 -->

In the Monitoring app, the trend graph of a table column parameter would not be displayed when the table row index contained a forward slash.

#### Dashboards app: No longer possible to select a built-in theme as default theme [ID_33665]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

In the Dashboards app, it would no longer be possible to select a built-in dashboard theme as default theme.

#### SLProtocol would leak memory leak each time a parameter of a replicated element was updated [ID_33745]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

SLProtocol would leak memory each time a parameter of a replicated element was updated.

#### Web services API would incorrectly no longer clear a number of its caches when the connection was lost [ID_33764]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the connection was lost, the web services API would incorrectly no longer clear a number of its caches.

#### Service & Resource Management: Child DVE element would not get activated when the main DVE element was in an error state [ID_33787]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you tried to create a booking with a child DVE element linked to a main DVE element in an error state, the child DVE element would not automatically be activated, causing the booking to fail. Moreover, SLNet would not try to activate this child DVE element, causing subsequent bookings needing that same child DVE element to also fail, even if the main element had already recovered from the error state in the meantime.

#### GQI: Columns of type 'decimal' would incorrectly not be treated as columns of type 'numeric' [ID_33792]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Columns of type "decimal" would incorrectly be treated as columns of type "string" instead of columns of type "numeric".

#### Dashboards app: Options displayed in component headers would not be readable when a dark theme was applied [ID_33805]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When a dark theme was applied, options displayed in the header of certain dashboard components (e.g. “Export to CSV”) would not be readable.

#### Dynamic virtual elements: Problem when processing table columns containing foreign keys [ID_33810]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a table contained multiple foreign keys, invalid foreign key values referring to non-existing rows could prevent those rows from being exported to DVE child elements. This would cause alarms, trend information, subscriptions, etc. to not get updated for specific DVE elements and/or virtual functions.

#### Web apps: Visio files would not get rendered correctly [ID_33812]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, Visio files would not get rendered correctly in web apps (e.g. Dashboards).

#### Cassandra Cluster Migrator tool: Problem when migrating a large amount of data [ID_33821]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When the Cassandra Cluster Migrator tool was migrating a large amount of data, in some cases, an out of memory exception could be thrown.

#### Problem with SLElement when resolving foreign keys took a long time and the the element debug log level was equal to or higher than 1 [ID_33826]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the element debug log level was equal to or higher than 1, an error could occur in SLElement when resolving foreign keys took a long time.

#### Dashboards app - Visual Overview component: Loading bar at the top of the component instead of large loading message on top of the component [ID_33829]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When a Visual Overview component was loading, up to now, a large loading message was displayed on top of the component. From now on, when a Visual Overview component is loading, a loading bar will appear at the top of the component instead.

#### Element card - REPORTS page: Masking and unmasking not shown correctly in the different graphs [ID_33832]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On the REPORTS page of an element card, masking and unmasking (i.e. state changes to "masked" and "unmasked") would not be shown correctly in the different graphs.

#### Alarm Console would incorrectly keep loading while the tickets linked to the alarms were being loaded [ID_33847]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you open DataMiner Cube, it will load the alarms and try to link the existing tickets to them so it can show the ticket information in the Alarm Console.

While this process was ongoing, in some rare cases, the Alarm Console would incorrectly keep on loading.

#### Dashboards app - Service definition component: Function nodes not displaying number of Process Automation tokens in queue or in progress [ID_33848]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a Process Automation definition was added to a *Service definition* component, the function nodes would not display the number of tokens currently in queue or in progress.

#### SNMPv3 credentials would incorrectly be checked when replicating an element with SNMPv3 connections [ID_33859]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you replicated an element with SNMPv3 connections, the SNMPv3 credentials of that element would incorrectly be checked. As a result, alarms like the following one would appear in the Alarm Console:

```txt
Load Element Failed: Error parsing SNMPv3 password for element: <element name>
```

#### Alarm Console: Problem when loading [ID_33860]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an exception could be thrown while the Alarm Console was loading.

#### Alarm Console: Cube could become unresponsive when a large number of alarms were being added and removed in an alarm tab of type 'sliding window' [ID_33870]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in an alarm tab of type "sliding window", a large number of alarms were being added and removed, in some cases, DataMiner Cube could become unresponsive.

#### System Center: Element counter on Agents > Status tab would not be set to 0 when removing all elements from a DMA [ID_33885]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you go to *System Center > Agents > Status*, the *Elements* column shows you how many elements are being hosted by each agent in the DMS.

When, on a particular agent, you removed all elements, the number of elements of that agent would incorrectly not be set to 0. Instead, it would be set to the last-known number of elements on that agent before the element were removed.

#### SLProtocol could leak memory when the NT_UPDATE_PORTS_XML command was sent [ID_33891]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, the SLProtocol process could leak memory when the NT_UPDATE_PORTS_XML command was sent.

#### Certain types of alarms could affect and degrade an SLA [ID_33899]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an alarm of one the following types was generated, in some cases, that alarm could affect and degrade an SLA or be added to the list of active alarms for that SLA (i.e. enhanced service):

- Information Event
- Suggestion Event
- Error Alarm
- Notice Alarm

#### SLSNMPManager: StackOverflow exception while trying to resolve the next Request ID [ID_33901]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, SLSNMPManager could throw a StackOverflow exception while trying to resolve the next Request ID.

#### Spectrum analysis: Recording icon would no longer be displayed while making a spectrum recording [ID_33904]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While making a spectrum recording, in some cases, the recording icon would no longer be displayed.

#### Visual Overview: Wait cursor would still be displayed after the scripts had already finished [ID_33911]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in Visual Overview, you clicked a shape that executed two Automation scripts, the cursor would incorrectly still be displayed as a wait cursor after the two scripts had already finished.

#### Spectrum analysis: Issues when playing a spectrum recording [ID_33918]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a spectrum recording was being played, the following issues could occur:

- The *Forward* and *Backward* buttons would not work after starting and pausing the recording.
- When you adapted the speed of the recording, the new speed would incorrectly only be applied to the next frame and not to the current frame.
- When the recording was being played, the slider could incorrectly not be used.

#### Problems when exporting tables with an IncludedPids option or with a ClientSideRowFilter [ID_33934]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, tables that had the *IncludedPids* option defined would have their data exported to a CSV file incorrectly.

Also, when a table to which a ClientSideRowFilter was applied was exported to a CSV file, up to now, that filter would not be taken into account.

#### Spectrum analysis: Maximum, minimum and average trace would disappear after skipping backward when playing a spectrum recording [ID_33942]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you play a spectrum recording, you can pause the playback and use controls to skip forward or backward. In some cases, after skipping backward, the maximum, minimum and average trace would incorrectly disappear.

#### Alarm Console: Column list not shown when hovering over the 'Add/Remove column' menu command [ID_33967]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you right-clicked a column header in an alarm tab and hovered over the *Add/Remove column* command, in some cases, the column list would incorrectly not be shown if, previously, you had right-clicked the header of the focus column or a header of an action column.

#### Data Display : Update of parameter unit would not be reflected in the UI when the element card was open [ID_34007]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an element card was open on the DATA page, and a parameter on that page had its unit changed (e.g. via an Automation script), that change would incorrectly not be reflected in the UI. To see the new unit, you had to close the element card and re-open it.

#### An alarm property with a name identical to that of an element, service of view property would incorrectly get duplicated when the element with that alarm property was restarted [ID_34021]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you created an alarm property with a name identical to an existing property of an element, service or view, that alarm property would incorrectly be duplicated each time the element with that alarm property was restarted.

> [!NOTE]
> When upgrading to v10.2.0 [CU6] or v10.2.9, an upgrade action will check the *PropertyConfiguration.xml* file for any issues with duplicate properties and correct them.

#### DataMiner upgrade: Upgrade action 'DeletePreRN28047CustomDataTemplates' would fail when Elasticsearch required authentication [ID_34029]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, the upgrade action *DeletePreRN28047CustomDataTemplates* would fail when Elasticsearch required authentication.

#### Connected DMA removed from cluster instead of selected DMA in System Center [ID_34035]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In System Center, when you clicked the *Leave cluster* button on the *Agents* page, this removed the DMA you were connected to from the cluster instead of the selected DMA.

#### Problem with SLSNMPManager when an SNMP Get or Set was put on the queue while the element in question was being stopped [ID_34038]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, an error could occur in the SLSNMPManager process due to an SNMP Get or Set having been put on the queue while the element in question was being stopped.

#### EPM: Incorrect alarm color shown for EPM shapes in Visual Overview [ID_34039]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, to resolve the monitoring state of EPM shapes displayed in Visual Overview, the source table of the EPM front end was used, which could cause an incorrect alarm color to be shown for such shapes. Now, the source table of the back end is used instead, as this is the table the monitoring is applied to.

#### GQI: No longer possible to select another row after collapsing a group containing a selected row [ID_34042]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in a GQI table, you collapsed a group that contained a selected row, it was no longer possible to select another row.

#### GQI: Problem when filtering or aggregating data by custom properties [ID_34058]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, it would no longer be possible to build a GQI query that filtered or aggregated data by custom properties.

#### Incorrect instance alarm level after restart and for view tables [ID_34063]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Since DataMiner 10.1.8 (RN [30044](xref:General_Feature_Release_10.1.8#instancealarmlevel-would-not-fall-back-to-cellactualalarmlevel-when-there-was-bubble-up-information-but-no-instance-information-id_30044)), it could occur that the instance alarm level for a table row did not bubble up correctly, causing alarms for view tables to be displayed incorrectly (e.g. in an EPM environment). This could also occur for tables with an alarm where no saved data was present.

#### Potential minor memory leak in SLProtocol if fixed parameter had length of zero [ID_34064]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If a fixed parameter had a length of zero, a minor memory leak could potentially occur in SLProtocol. Though it is unlikely that this could ever happen, as a fixed parameter usually contains data, this issue will now be prevented.

#### Logger tables not deleted when stopped element was deleted [ID_34067]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a stopped element was deleted, logger tables associated with that element would incorrectly not be deleted if created with `options="database"`.

#### Scheduled task corrupted after it was edited [ID_34084]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an existing scheduled task that was configured to be executed multiple times per day was edited, it could occur that the task was corrupted and could no longer be executed.

#### GQI: Regex filter on empty cell not working correctly [ID_34088]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a filter with a regular expression was applied to an empty cell of a GQI query, it could occur that this did not work correctly. This issue only occurred for custom columns of a DOM instance and for custom data sources.

#### No alarms shown with alarm filter on property value filtering the alarms before they entered Cube [ID_34090]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If an alarm filter that filtered on a property value was used to filter the alarms before they entered Cube, it could occur that no alarms were shown, even if there were alarms matching the filter.

#### GQI queries: Problem when removing a query used as 'start from' query [ID_34093]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an exception could be thrown when removing a query that was used as "start from" query by another query.

From now on, when you try to remove a query that is used as "start from" query, a confirmation box will appear, asking you to confirm the removal of that query.

#### DataMiner Cube: Spectrum recording icon not shown while recording [ID_34097]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a spectrum recording is started, an icon should be shown to the right below the trace to indicate that a recording is being created. However, when the mouse pointer was moved outside the trace area, it could occur that this icon was no longer shown.

#### Visual overview in dashboard or low-code app showed error while fetching its initial data [ID_34100]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a visual overview was embedded in a dashboard or low-code app, it could occur that it showed the error "Could not retrieve Visual Overview information." while fetching its initial data.

#### Visual Overview: Non-linked shape without LinkOptions shape data field not displayed [ID_34102]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If a shape was not linked to a DataMiner object and did not have a *LinkOptions* shape data field, it could occur that the shape was not displayed in Visual Overview.

#### GQI queries: Problem in web APIs when opening session for query with node requiring soft-launch feature [ID_34109]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In the Dashboards app or in a low-code app, when you tried to open a session for a GQI query containing a node that required a soft-launch feature, a problem could occur in the web APIs. Now an error will be shown in such a case instead.

#### GQI queries: Component data not displayed correctly [ID_34118]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a component in a dashboard or low-code app showed a GQI query, it could occur that queries and query keys were not in sync, and that data was still being fetched even though the component seemed to be fully loaded. This could for example cause connections to be missing in a node-edge graph.

#### Navigation issue in visual overview with several tab pages and shapes linked to EPM object [ID_34122]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In a visual overview with several tab pages and shapes linked to an EPM object, if you clicked a shape that opened an EPM object, then clicked the Back button, and then clicked a shape to navigate to another tab page in the same visual overview, this did not work.

#### 'Clear all' button not available for EPM topology chain [ID_34133]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you make a selection in an EPM topology chain, a *Clear all* button becomes available, which allows you to clear the selection again. However, in some cases, this button disappeared again. This was specifically the case when you opened a card of a certain level in the chain, closed this card, and then opened another card from the chain, other than the previous card.

#### GQI queries: Unhandled exception kept other errors from being displayed [ID_34137]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an unhandled exception in the GQI visualization could keep other errors from being displayed in the UI.

## Addendum CU7

### CU7 enhancements

#### Edge WebView2 now preferred when SAML authentication is used [ID_34162]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When SAML authentication is used, Cube will now try to use the Edge WebView2 browser engine instead of CefSharp. It will only fall back to using CefSharp if WebView2 is not available.

This will prevent the following possible issues:

- The CefSharp browser engine version used by Cube is not updated frequently and therefore not always trusted by certain SAML identity provider websites, such as Microsoft Azure. This can cause a lengthy authentication procedure, even if the browser cache is enabled.
- The CefSharp browser engine needs to be downloaded from the DMA before a first authentication (on a new device). However, this is currently not supported for HTTPS-only setups.

### CU7 fixes

#### Jobs app: Corrected start time saved incorrectly \[ID_34043]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When, after receiving a message that it was not possible to save a job because of an invalid start time, you corrected the start time and tried to save the job again, that start time would get saved incorrectly.

#### DataMiner web apps / Visual Overview: Trending not displayed or displayed with incorrect coloring [ID_34101]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.9 -->

If a visual overview was viewed in the web apps (e.g. the Monitoring or Dashboards app), it could occur that trend graphs in that visual overview were not displayed.
In addition, the coloring of the trend lines could be incorrect. Instead of the colors defined in the themes, the lines were shown in black.

#### Visual Overview: SurveyorSearchText variable continued to show cleared search input [ID_34114]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When the text in the Cube advanced search box was selected with Ctrl+A and then deleted, it could occur that the advanced search input was not cleared correctly, so that it continued to be shown by the *SurveyorSearchText* variable in Visual Overview.

#### Visual Overview: Connection highlight based on connection property not updated automatically [ID_34139]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When a connection in Visual Overview was highlighted based on a connection property, and the connection property changed, it could occur that the highlight style was not automatically applied to the connection line, but only after the user triggered a redraw, for example by clicking the highlight.
