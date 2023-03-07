---
uid: General_Main_Release_10.3.0_new_features_2
---

# General Main Release 10.3.0 – Other new features (part 2)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

### DMS Service & Resource Management

#### Retrieving bookings in a paged way and sorted by property [ID_31982]

<!-- MR 10.3.0 - FR 10.2.5 -->

It is now possible to retrieve bookings in a paged way and sorted by one of the following properties:

- CreatedAt
- CreatedBy
- Description
- LastModifiedAt
- LastModifiedBy

> [!NOTE]
> Depending on the configuration of the Elasticsearch database, DataMiner Agents running one of the following DataMiner versions may potentially not be able to sort by the above-mentioned properties.
>
> - v10.0.0 (CU10)
> - v10.1.0 (CU0)
> - v10.1.1 (CU0)

#### ProfileInstances: New parameter property 'InheritIsHidden' [ID_32131]

<!-- MR 10.3.0 - FR 10.2.3 -->

In the ParameterSettings property of a profile instance, you can now use the “InheritIsHidden” property to indicate whether a profile instance should inherit the “IsHidden” property of a profile parameter. This property is false by default.

A few examples:

- If a parameter of profile definition A is hidden, and you want profile instance A to inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to true.
- If a parameter of profile definition A is hidden, and you want profile instance B to not inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to false and “IsHidden” to true.

#### ResourceUsageInfoManager [ID_32512]

<!-- MR 10.3.0 - FR 10.2.5 -->

SLNet now includes a ResourceUsageInfoManager, which will keep track of the Resources being used by ReservationInstances. Each time a change is detected as to Resource usage, this manager will send out a ResourceUsageStatusEventMessage containing the DMA ID and a list of UpdatedResourceUsageStatuses.

A ResourceUsageStatus contains a ResourceId and a list of UsingReservationInstances. That list will contain a ReservationInstanceUsageDetails object for every ReservationInstance that is using the Resource. Currently, the object only contains a ReservationInstanceId property.

Normally, a ResourceUsageStatusEventMessage will be sent out the moment a Resource is being used in an ongoing reservation or when a ReservationInstance using that resource ends. When a Resource is no longer used in any reservation, an event will be sent out with a ResourceUsageStatus containing an empty list.

ResourceUsageStatus objects can be retrieved by means of a GetResourceUsageStatusList (FilterElement\<Resource> filter) call on the ResourceManagerHelper. This call will return all status objects for the resources that match the filter and that are currently being used by ongoing reservations.

#### ReservationInstances now have a ReservationInstanceType [ID_32624]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring a ReservationInstance, you now have to specify a ReservationInstanceType:

- Default
- Process Automation
- Custom Process Automation

> [!NOTE]
>
> - In case of a ServiceReservationInstance, the type of the instance must be identical to the type of the ServiceDefinition. Otherwise, the ResourceManager will throw a “ServiceDefinitionTypeDoesNotMatch” error.
> - A new exposer has been added to allow filter ReservationInstanceType.

#### ResourceManagerEventMessage: New LostInterestReservationInstances property [ID_32801]

<!-- MR 10.3.0 - FR 10.2.5 -->

When, for example, a table is populated with ReservationInstances using ResourceManagerEventMessages with a SubscriptionFilter, you can now use the LostInterestReservationInstances property to retrieve the IDs of the ReservationInstances that no longer match the current filter after an update.

> [!NOTE]
> This list will only contain ReservationInstances to which the user has access.
> To retrieve the IDs of the ReservationInstances to which the user no longer has access, you can call the GetHiddenReservationInstances method.

#### Subscribing to ResourceUsageStatusEvents for specific resources [ID_32979]

<!-- MR 10.3.0 - FR 10.2.6 -->

From now on, it is possible to only receive ResourceUsageEventMessages for a specific resource. Using ResourceUsageStatusEventExposers, you can now filter by ResourceId.

#### ReservationInstanceType and ServiceDefinitionType: New values 'ResourceScheduling' and 'ResourceOrchestration' [ID_33390]

<!-- MR 10.3.0 - FR 10.2.7 -->

ReservationInstanceType and ServiceDefinitionType can now be set to the following additional values:

- ResourceScheduling
- ResourceOrchestration

#### Resource migration to Elasticsearch [ID_33797] [ID_33946] [ID_34105] [ID_34207] [ID_34296] [ID_34522] [ID_34568] [ID_34784] [ID_35067] [ID_35155]

<!-- MR 10.3.0 - FR 10.3.2 -->

It is now possible to migrate the resources and resource pools from the *Resources.xml* file to Elasticsearch. This improves the scalability and performance on systems that have a large number of resources.

To start the migration, you can use the SLNetClientTest tool. The migration app is available under *Advanced* > *Migration*.

> [!WARNING]
>
> - Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
> - All Resource Manager instances in the cluster will restart during the migration.

> [!TIP]
> For detailed information on the migration, refer to [Resource migration to Elasticsearch](xref:Resources_migration_to_elastic).

If for any reason the migration fails, you can find information in the ``SLMigrationManager.txt`` and ``SLResourceManager.txt`` log files. In this case, the existing XML setup will continue to be used and the configuration will not switch to Elasticsearch.

Note that there are differences when resources and resource pools are stored in Elasticsearch, as compared to in XML:

- When XML storage is used, it is not possible to remove a resource when one of the DMAs in the cluster cannot be reached, as this could cause syncing issues. No such restrictions apply when Elasticsearch storage is used.

- The following restrictions apply for the properties stored in Elasticsearch:

  - Property names must not start with the character ``_``.

  - Property names must not contain the characters ``.`` (period), ``#`` (hashtag), ``*`` (star), ``,`` (comma), ``"`` (double quote) or ``'`` (single quote).

  - Property names must not be empty or contain only whitespace characters.

  - Property values must not be ``null``.

  > [!NOTE]
  > If Elasticsearch storage is enabled, and a resource or resource pool with invalid properties is added or updated, the API will return a ``ResourceManagerErrorData`` in the ``TraceData``, with reason ``InvalidCharactersInPropertyNames``.

- Field names in Elasticsearch have a maximum length of 32766 bytes, which means any field of a resource or resource pool indexed in Elasticsearch can only contain 32766 bytes.

  > [!NOTE]
  > If there is an attempt to save a resource or resource pool with a field that is too big, the API will return an ``UnknownError``. The ``SLResourceManager.txt`` log file will contain the actual exception, which will mention the field that could not be indexed in Elasticsearch.

- When a resource is indexed in Elasticsearch, all its properties, capacities, and capabilities will be indexed as well. This means that each unique property name and unique capacity and capability ID will become a field mapping in Elasticsearch. If there is an unusually large number of capacities, capabilities, and/or property names, this may lead to reduced performance of Elasticsearch. During testing, this was noticed when more than 300 unique field mappings were present.

- If XML storage is used and you subscribe to the *ResourceManagerEventMessage*, you will receive an initial event with all resources and resource pools. This event is not sent when Elasticsearch storage is used, in order to prevent sending a message to the client containing thousands of resources.

- If XML storage is used, all Resource Manager instances in the cluster will sync the resources in their XML file on startup and during the midnight sync. If Elasticsearch storage is used, DataMiner relies on Elasticsearch to do the syncing, so this does not happen during the midnight sync or on startup. However, Resource Manager will refresh the cached resources during the midnight sync by reading all resources and resource pools again from Elasticsearch.

#### BREAKING CHANGE: Capacity property will no longer be initialized on new Resources [ID_34856]

<!-- MR 10.3.0 - FR 10.3.2 -->

From now on, the *Capacity* property will no longer be initialized on new Resources.

As a result, in DataMiner Cube, the resources module will no longer require the legacy capacity to be initialized. Newly created resources will no longer have a legacy capacity. The concurrency of a resource will still be stored in *Resource.MaxConcurrency*.

##### Impact of this change

Since *Capacity* is no longer initialized on a new Resource, *GetEffectiveMaxConcurrency* will take into account *MaxConcurrency*. *MaxConcurrency* will now be initialized with 1 as is the case with *Capacity.MaxConcurrency*.

If *GetEffectiveMaxConcurrency* should still use the value of *Capacity.MaxConcurrency*, *MaxConcurrency* should be set to 0.

To restore legacy behavior, a new resource should be initialized as follows:

```csharp
var resource = new Resource()
{
  MaxConcurrency = 0,
  Capacity = new ResourceCapacity(),
};
```

This change in behavior will impact results for both *GetAvailableResources* and *GetResourceUsage* on ResourceManagerHelper, both marked as obsolete since 9.6.5. For both methods, newly created resources will now, by default, always be considered unavailable.

### DMS Mobile Gateway

#### Additional logging after sending a 'send SMS' request to an SMSEagle device [ID_32785] [ID_32911]

<!-- MR 10.3.0 - FR 10.2.5 -->

When an HTTP request of type “send SMS” is sent to an SMSEagle device, the following information will now be logged in the SLGSMGateway log file:

- The response message and code (level “debug”).

    Example:

    ```txt
    Response of sending SMS 'This is a test' to '+324799789789' - Status: HTTP/1.1 200 OK (200) - Response data: OK; ID=25464
    ```

- The response itself as well as the error string retrieved from the HTTP engine used by SLGSMGateway (level “info”) when the response does not start with “OK;”.

    Example:

    ```txt
    Sending the SMS 'This is a test' to '+324799789789' may have failed. Received response: '' (HTTP/1.1 200 OK/200). Error info: 'Error : 12029. [ERROR_WINHTTP_CANNOT_CONNECT]'
    ```

### DMS tools

#### Standalone Elasticsearch Cluster Installer: New RepoPath setting [ID_33055]

<!-- MR 10.3.0 - FR 10.2.6 -->

The optional RepoPath configuration setting (which corresponds with the Path.Repo Elasticsearch setting) allows you to define a snapshot path. For a cluster, this should be a shared file location. If this setting is not filled in, it will be commented out in the Elasticsearch configuration.

When you run the installer with the “generate” option (run-stand-alone -g), the sample configuration will now include a \<RepoPath> element and a \<DiscoveryHosts> element. See the following example:

```xml
<ElasticConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ElasticYamlSettings>
    <ClusterName>DMS</ClusterName>
    <NodeName>DataMinerBestMiner</NodeName>
    <DataPath>C:\ProgramData\Elasticsearch</DataPath>
    <RepoPath>C:\ProgramData\RepoPath</RepoPath>
    <NetworkHost>0.0.0.0</NetworkHost>
    <NetworkPublishHost>0.0.0.0</NetworkPublishHost>
    <DiscoveryHosts>
      <string>"IP1"</string>
      <string>"IP2"</string>
    </DiscoveryHosts>
    <MinimumMasterNodes>1</MinimumMasterNodes>
    <MasterNode>true</MasterNode>
    <DataNode>true</DataNode>
  </ElasticYamlSettings>
  <InstallerDependenciesDirectory>unspecified</InstallerDependenciesDirectory>
  <ElasticTargetDirectory>C:\Program Files\Elasticsearch</ElasticTargetDirectory>
</ElasticConfiguration>
```

#### QA Device Simulator renamed to Skyline Device Simulator [ID_33680] [ID_34530] [ID_34555]

<!-- RN 33680: MR 10.3.0 - FR 10.2.7 -->
<!-- RN 34530/34555: MR 10.3.0 - FR 10.2.12 -->

The *QA Device Simulator* tool has been renamed to *Skyline Device Simulator* and now targets Microsoft .NET Framework 4.8.

Also, the following command-line parameters have been added:

| Parameters | Function |
|------------|----------|
| `/packetloss <packet loss %>`<br>`/delayms <delay ms>`<br>`/delaypct <delay % of packets>` | Specifying packet loss and packet delay parameters on startup. |
| `/dbmaxvaloid <max nbr of entries per OID>` | Configuring the number of entries loaded in memory per OID when working with database simulations. |

> [!NOTE]
> In the UI of the *Skyline Device Simulator*, the help link now directs you to the *Skyline Device Simulator* help pages on <https://docs.dataminer.services/>.

> [!CAUTION]
> This tool is provided "As Is" with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### SLNetClientTest tool - 'Connect' window: Enhanced 'Connection Type' and 'Authentication' sections [ID_34712]

<!-- MR 10.3.0 - FR 10.3.1 -->

In the *SLNetClientTest* tool, to connect to a DataMiner Agent, you select *Connection* > *Connect*, and specify the necessary information in the *Connect* window. That window has now been updated.

In the *Connection Type* section, you now have to indicate how the connection has to be established:

| Select...              | in order to... |
|------------------------|----------------|
| Autodetect             | connect to the local machine or a remote machine using the method that will be detected automatically. |
| gRPC                   | connect to the local machine or a remote machine via the APIGateway service using the GRPCWeb protocol.<br>When you choose this option, you can specify a custom port (default: `443`) and a custom endpoint (default: `/APIGateway`). |
| .NET Remoting (legacy) | connect to the local machine or a remote machine using .NET Remoting.<br>When you choose this option, you can specify a custom port (default: `8004`) |
| IPC (only local)       | connect to the local machine using IPC. |

In the *Authentication* section (formerly known as *User Info* section), you now have the following authentication options:

- Single sign-on

    > [!NOTE]
    > External authentication not yet supported.

- Explicit credentials (with *Force Authenticate Local User* option)

- Ticket

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
