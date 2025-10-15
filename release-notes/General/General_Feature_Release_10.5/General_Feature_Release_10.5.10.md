---
uid: General_Feature_Release_10.5.10
---

# General Feature Release 10.5.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.10](xref:Cube_Feature_Release_10.5.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.10](xref:Web_apps_Feature_Release_10.5.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [DataMiner Object Models: Attachments can now be uploaded to a network share [ID 43114] [ID 43366]](#dataminer-object-models-attachments-can-now-be-uploaded-to-a-network-share-id-43114-id-43366)
- [gRPC now used by default for communication between DataMiner Agents [ID 43190] [ID 43260] [ID 43305] [ID 43331] [ID 43435] [ID 43506]](#grpc-now-used-by-default-for-server-server-and-server-client-communication-id-43190-id-43260-id-43305-id-43331-id-43435-id-43506)
- [DataMiner Object Models: Definition-level security [ID 43380] [ID 43589]](#dataminer-object-models-definition-level-security-id-43380-id-43589)

## New features

#### DataMiner Object Models: Attachments can now be uploaded to a network share [ID 43114] [ID 43366]

<!-- MR 10.6.0 - FR 10.5.10 -->

In `ModuleSettings`, `DomManagerSettings` now contains a new `DomInstanceNetworkAttachmentSettings` class that allows you to save DOM instance attachments to a network share instead of to the *Documents* module.

The `DomInstanceNetworkAttachmentSettings` class contains the following properties:

- `NetworkSharePath` (string)

  The UNC path to the network share where the attachments should be saved.

  This path has to start with `\\` and cannot contain any characters that are illegal for a path (e.g. "<") or strings that allow directory traversal (e.g. "../").

  When the path is left empty, attachments are saved to the `C:\Skyline DataMiner\Documents` folder. This is the default behavior.

- `CredentialId` (GUID)

  The ID of the credentials in the credentials library that will be used to add the attachment to the network share.

  These credentials must be of type *Username and password credentials* and must be the credentials of a user that has read/write access to the path defined in `NetworkSharePath`. In case you have a Windows network share, you need to add the domain name (for a domain user) or hostname (for a local user) in front of the username (e.g. "MYPC\userName").

> [!NOTE]
>
> - When a DOM module is configured to save attachments to a network share, the system will validate whether the user creating/updating the `ModuleSettings` has permission to access the credentials. Once this is set up, any user that has permissions to create or update a `DomInstance` can save attachments to the network share under the configured user.
> - When a DOM module is configured to save attachments to a network share, no migration is done of existing attachments. They will continue to exist in the `C:\Skyline DataMiner\Documents` folder, but will no longer work. You can copy them over or move them to the network share; the folder structure is the same. Likewise, when removing the configuration to save attachments to a network share, no migration is done of attachments available on the previously configured network share.
> - By default, the size of the attachments is limited to 20 MB. See [Documents.MaxSize](xref:MaintenanceSettings.Documents.MaxSize).

#### gRPC now used by default for server-server and server-client communication [ID 43190] [ID 43260] [ID 43305] [ID 43331] [ID 43435] [ID 43506]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, .Net Remoting was used by default for communication between DataMiner Cube and a DataMiner Agent as well as between DataMiner Agents, though it was possible to set gRPC as the default instead (either by adding *Redirect* tags in *DMS.xml* or by disabling .NET Remoting in *MaintenanceSettings.xml* for server-server communication, and by adjusting *ConnectionSettings.txt* for server-client communication). Now gRPC will be the default instead. This means that the *EnableDotNetRemoting* setting in *MaintenanceSettings.xml* is now by default set to *false*, and the connection type in *ConnectionSettings.txt* is now by default set to *GRPCConnection*.

When you upload an upgrade package that includes this change, the *VerifyGRPCConnection* prerequisite check will run to verify whether all DataMiner Agents in the cluster are ready to switch to using gRPC as the default communication type. This check will fail in case a possible configuration issue or connectivity issue is detected. For details, refer to [Upgrade fails because of VerifyGRPCConnection.dll prerequisite](xref:KI_Upgrade_fails_VerifyGRPCConnection_prerequisite).

We recommend uploading the package prior to the maintenance window for the upgrade, so you can already check beforehand whether all requirements for the upgrade are met and address any possible issues.

#### DataMiner Object Models: Definition-level security [ID 43380] [ID 43589]

<!-- MR 10.6.0 - FR 10.5.10 -->

It is now possible to configure DOM instance security based on the DOM definitions the instances are linked to. In other words, you will now be able to configure which DataMiner user groups should have access to the DOM instances of a certain DOM definition.

The following important changes have been made:

- Only users who have been granted the *Modules > System configuration > Object Manager > Module Settings* user permission will be allowed to create, update, and delete DOM configuration objects (i.e. section definitions, DOM definitions, DOM behavior definitions, and DOM templates). This means that, if you want to deploy or change a DOM model, you will now need this permission.

- The DOM module settings now include a new `LinkSecuritySettings` configuration object that will allow you to link a DataMiner user group to a DOM definition by ID. This object contains a collection of `GroupLink` objects, each containing the following properties:

  - `GroupName` (string) : The name of the DataMiner user group
  - `DomDefinitionReferences` (List\<DomDefinitionReference\>) : The list of references to the DOM definitions linked to the user group specified in `GroupName`.

  > [!NOTE]
  > Reinitialize the DOM manager each time you have updated the DOM module settings.

##### General behavior

- When no `GroupLink` objects are defined, definition-level security will not be enabled, but users who want to make changes to the DOM configuration settings will need *Modules > System configuration > Object Manager > Module Settings* permission to do so.

  > [!NOTE]
  > Even when definition-level security is enabled will users need *Modules > System configuration > Object Manager > Module Settings* permission if they want to make changes to the DOM configuration settings.

- From the moment one `GroupLink` object has been defined, definition-level security will be enabled for the entire DOM module. Only users belonging to user groups that have `GroupLink` object defined will have access to the instances of the DOM definitions specified in those `GroupLink` objects.

- If a DOM module with definition-level security enabled contains multiple DOM definitions, no one will be able to access the instances of DOM definitions for which no `GroupLink` objects have been defined yet.

- Currently, `GroupLink` objects grant full access (i.e. read access as well as write access) to the instances of the DOM definitions specified in them.

##### Filtering behavior & restrictions

When definition-level security has been enabled for a DOM module, every read and count filter/query will need to be evaluated to find out whether the person using that filter/query is allowed to do so. As it is only possible to evaluate filters and queries with enough context, a number of restrictions have been set.

###### Read filters/queries

A read filter/query needs to filter by DOM definition or by DOM instance ID.

Examples of allowed filters/queries:

| Example | Description |
|---------|-------------|
| (DOM Definition ID == a1ds5z8)  | Reading all DOM instances that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) && (Field X = "Some Value") | Reading all DOM instances with field X set to "Some Value" that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) \|\| (DOM Definition ID == 5ze7s84a) | Reading all DOM instances that are part of either of the specified DOM definitions. |
| (DOM Instance ID == f4e87d) \|\| (DOM Instance ID == qs4z54) \|\| (DOM Instance ID == ezeasf) | Reading specific DOM instances based on ID. |

Examples of prohibited filters/queries:

| Example | Description |
|---------|-------------|
| TRUEFilterElement\<DomInstance\> | Sending a plain TRUE filter is not supported when the DOM module has definition-level security enabled. |
| (Field X = "Some Value") | This filter does not contain any context. |
| (Status ID = "in_progress") | This filter does not contain any context. |

When a filter/query that reads DOM instances has a DOM definition context the user does not have access to, the read request will fail with a `NoPermission` error. If the DOM instances are read using a DOM instance ID filter, the read request will not fail, but the DOM instances the user does not have access to will not be returned in the result set. Here are a few examples in which the user only has access to DOM definition A.

| Example | Description |
|---------|-------------|
| (DOM Definition ID == A) | Request will be allowed. |
| (DOM Definition ID == A) \|\| (DOM Definition ID == B) | Request will fail with a `NoPermission` error. |
| (DOM Instance ID == \<Instance linked to A\>) \|\| (DOM Instance ID == \<Instance linked to B\>) | Only the DOM instance linked to DOM definition A will be returned. |

###### Count filters/queries

A count filter/query needs to filter by DOM definition. That means that the filter/query should already limit the results based on one or more DOM definitions. Counts filtered by DOM instance ID(s) are not supported.

Examples of allowed filters/queries:

| Example | Description |
|---------|-------------|
| (DOM Definition ID == a1ds5z8) | Counting all DOM instances that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) && (Field X = "Some Value") | Counting all DOM instances with field X set to "Some Value" that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) \|\| (DOM Definition ID == 5ze7s84a) | Counting all DOM instances that are part of either of the specified DOM definitions. |
| (DOM Definition ID = a1ds5z8) && ((DOM Instance ID == f4e87d) \|\| (DOM Instance ID == qs4z54) \|\| (DOM Instance ID == ezeasf)) | Reading specific DOM instances based on ID is only supported if a DOM definition context is specified. |

Examples of prohibited filters/queries:

| Example | Description |
|---------|-------------|
| TRUEFilterElement\<DomInstance\> | Sending a plain TRUE filter is not supported when the DOM module has definition-level security enabled. |
| (Field X = "Some Value") | This filter does not contain any context. |
| (Status ID = "in_progress") | This filter does not contain any context. |
| (DOM Instance ID == f4e87d) \|\| (DOM Instance ID == qs4z54) \|\| (DOM Instance ID == ezeasf) | Reading specific DOM instances based on ID is not supported if no DOM definition context is specified. |

When a filter/query that counts DOM instances has a DOM definition context the user does not have access to, the count request will fail with a `NoPermission` error.

> [!NOTE]
> Filters sent to the DOM manager by standard GQI queries made in a dashboard or low-code app have a DOM definition context by default. No special adjustments have to be made in this case, but keep in mind that GQI queries that retrieve data for DOM definitions the user does not have access to will result in permission errors appearing in the dashboard or low-code app.

##### Additional security when reading/counting DOM instance history records

From now on, when definition-level security is enabled for a DOM module, reading and counting DOM instance history records will only be possible if the following conditions are met:

- The filter must include 'SubjectID Equal' clauses that narrow down the filter to the history of one or more DOM instances. If the filter does not meet this requirement, the request will fail with a `CrudFailedException`, and the `TraceData` will contain a `DomInstanceError` with reason `ReadFilterNotSupportedBySecurity` or `CountFilterNotSupportedBySecurity`.

- The user must have access to all DOM instances for which history records are requested. Also, all specified DOM instances must exist. Otherwise, the request will fail with a `CrudFailedException`, and the `TraceData` will contain `DomInstanceError` with reason `NoPermission`.

##### Event security

The permissions defined by the `GroupLink` objects will also be applied when subscribing on a `DomInstancesChangedEventMessage`. The event should only contain the created, updated or deleted instances the subscribed user is allowed to access. If an event contains multiple objects, and the user does not have access to all of those, the event will be dropped.

The following properties have been added to the `DomInstancesChangedEventMessage` class:

| Property | Description |
|----------|-------------|
| FromSecurityEnabledModule | Determines whether security could be applied to the event.<br>If true, there could be more created, updated, or deleted objects, but the subscribed user may not have access to all of them. |
| SecurityEnabledModuleNotAvailable | An empty event could be received with this boolean property set to true if, for some reason, the security could not be applied.<br>This can occur when a user is subscribed on an agent other than the one that handled the create/update/delete action, and this other agent has connection issues with the database preventing the DOM manager to initialize.<br>If such an event is received, the subscriber may have missed one or more updates. If these events are used to keep a list of cached objects up to date, we recommend reloading them to ensure that the most recent and correct data is visualized. |

##### General notes

- Changing the name of a DataMiner user group will invalidate any existing `GroupLink` objects associated with it. Make sure to adjust these objects when a user group was renamed.
- Reading, adding or removing a DOM instance attachment will now also be blocked if the user does not have permission to read/write that DOM instance.

##### Changes to the SLNetClientTest tool

The SLNetClientTest tool has been updated to support the limitation of not being able to send a TRUEFilterElement to get all DOM instances in a module.

When definition-level security is enabled, you will now need to first select one or more DOM definitions from a filter menu. This menu is accessible for any DOM manager, so it can also be used to retrieve DOM instances more easily for a specified list of DOM definitions.

#### DataMiner upgrade: New prerequisite check 'VerifyBrokerGatewayMigration' [ID 43526]

<!-- MR 10.6.0 - FR 10.5.10 -->

A new *VerifyBrokerGatewayMigration* prerequisite check has been added to prepare for the upcoming mandatory migration to BrokerGateway. However, this check is not yet relevant for users outside of Skyline Communications.

#### New BPA test: Cube CRL Freeze [ID 43539]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

From now on, a new BPA test *Cube CRL Freeze* will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

The test, which will run once a day, will return one of the following messages:

| Message | Description |
|---------|-------------|
| No CRL Freezes are detected. | No problems were found. |
| CRL Freezes are detected. | The test has detected one or more client machines and DataMiner Agents that are affected by the startup freeze.<br>The detailed result section will list the specific client machines that are affected. The full list of affected client machines will be included in the `DetailedJsonResult` as `the following client machines are affected.` |
| CRL Freezes are detected on DataMiner Agents only. | The test has detected one or more DataMiner Agents that are affected by the startup freeze.<br>The detailed result section will list the specific DataMiner Agents that are affected. The full list of affected DataMiner Agents will be included in the `DetailedJsonResult` as `the following DataMiner Agents are affected.` |
| Could not execute test ([message]). | The test has failed to execute for unexpected reasons.<br>The test result details will contain the full exception text, if available. |

##### When issues are detected

When an internet connection is not available on the client machine, the DataMiner Cube application freezes for about 20 seconds during the session. This happens because Windows and .NET try to verify the application's digital signatures by checking an online Certificate Revocation List (CRL). The system times out during this process, causing the delay and impacting user productivity.

To prevent these freezes, please consult your IT administrator. For detailed solutions and workarounds, see [DataMiner Cube freeze on startup](xref:KI_DataMiner_Cube_freeze_on_startup).

## Changes

### Enhancements

#### APIGateway: Kernel response buffering will now be enabled by default [ID 43346]

<!-- MR 10.6.0 - FR 10.5.10 -->

In the APIGateway settings, the `EnableKernelResponseBuffering` setting will now be enabled by default.

If you wish to disable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": false } }
   ```

#### 'Webpages\Public' folder now synced between DataMiner Agents [ID 43458]

<!-- MR 10.6.0 - FR 10.5.10 -->

The folder `C:\Skyline DataMiner\Webpages\Public\` will now be synced between DataMiner Agents in a cluster. As a consequence, files that are installed in this folder can now also be included in the companion files of a DataMiner app package.

#### SLNet-managed NATS solution: Credentials of the local agent will now be compared against the credentials of the primary NAS node [ID 43514]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In the *ResetNATSCheck* timer of the SLNet-managed NATS solution, the credentials of the local agent will now be compared against the credentials of the primary NAS node. If these do not match, the NATS configuration of the local agent will be reset, and the correct credentials of the primary node will be used instead.

#### DataMiner Object Models: Lazy-loading of dropdown fields [ID 43524]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when a DOM form visualized a DOM instance that included one or more dropdown fields, all those fields would be populated immediately. On DOM forms with multiple sections, in some cases, this behavior could trigger a large number of requests, some of which for fields the user would never interact with.

In order to minimize the impact of these population requests, from now on, dropdown fields will only be populated when you navigate to them.

#### DxMs upgraded [ID 43557]

<!-- RN 43557: MR 10.6.0 - FR 10.5.10 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner CloudGateway 2.17.11

The CloudGateway DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, they will not be installed.

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### SLDataMiner issue after connection type of element changed [ID 43249]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a problem could occur in SLDataMiner when the connection type of an element changed. To prevent this, the validation of SNMPv3 usernames has now been improved.

#### Swarming: Problem when redundancy groups contained DVE child elements acting as primary or backup elements [ID 43286] [ID 43492]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When Swarming was enabled, in some rare cases, SLDMS and SLDataMiner could get into a deadlock when the system contained redundancy groups in which DVE child elements acted as primary or backup elements.

#### Slow handling of concurrent requests to retrieve or update bookings [ID 43450]

<!-- MR 10.6.0 - FR 10.5.10 -->

When a lot of concurrent requests had to be processed by the Repository API in the background, e.g. to retrieve or update bookings, this could cause thread starvation in SLDataGateway, causing these requests to be handled much more slowly than usual.

#### SLDataGateway: Problem when NULL values were written to indexed logger tables [ID 43456]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, a `NullReference` exception would be thrown in SLDataGateway when NULL values were written to indexed logger tables.

#### Swarming: Problem when trying to retrieve an element from the SLNet event cache while it was being swarmed [ID 43461]

<!-- MR 10.6.0 - FR 10.5.10 -->
<!-- Not added to MR 10.6.0 -->

In some rare cases, an error could occur when trying to retrieve an element from the SLNet event cache while it was being swarmed.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`

#### SLNet-managed NATS solution: Problem when multiple calls accessed the NATS credentials simultaneously [ID 43504]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when multiple NATSCustodian calls tried to retrieve the NATS credentials simultaneously, in some cases, those credentials could get corrupted.

#### Local IP port configured for a UDP connection would incorrectly be disregarded [ID 43531]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When an element had a UDP connection that had been configured to use a local IP port, up to now, a random port would incorrectly be used instead of the port that had been configured.

#### Problem with gRPC connections [ID 43542]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a deadlock could occur in the `Grpc.Net.Client` library, causing active gRPC connections to get stuck.

#### DataMiner Connectivity Framework: ConnectivityChangedEvent would incorrectly be sent every second [ID 43547]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When an element with DCF connections had correlation rules configured, up to now, a `ConnectivityChangedEvent` would be sent every second, even when nothing had changed.

#### SLNet would interpret the messages incorrectly when matrix crosspoints were loaded or saved over a gRPC connection in DataMiner Cube [ID 43551]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When, in DataMiner Cube, matrix crosspoints were loaded or saved over a gRPC connection, in some cases, SLNet would interpret the messages incorrectly.

#### Problem when processing deserialization exceptions thrown as a result of messages received via gRPC [ID 43758]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 [CU0] -->

When a client application (e.g. DataMiner Cube) sends unsupported messages to a DataMiner Agent, deserialization exceptions are thrown in SLNet.

Up to now, those exceptions would not get processed correctly when the unsupported messages were sent over a gRPC connection, causing the client application to get stuck while waiting for a response that would never arrive.

#### Problem with SLDataGateway after it had removed a storage type in Elasticsearch or OpenSearch [ID 43761]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 [CU0] -->

In some cases, a fatal error could occur in SLDataGateway after it had removed a storage type in an Elasticsearch or OpenSearch database.

Also, in some cases, a fatal error could occur in SLDataGateway when it was shut down.
