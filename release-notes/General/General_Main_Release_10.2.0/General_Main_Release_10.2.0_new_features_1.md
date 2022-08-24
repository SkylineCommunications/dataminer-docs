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
