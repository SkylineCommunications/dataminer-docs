---
uid: General_Main_Release_10.3.0
---

# General Main Release 10.3.0 – preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

## New features

### DMS core functionality

#### New read-only service properties \[ID_29978\] \[ID_33196\] \[ID_33363\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

When a service is created or updated, the following read-only properties will now be filled in automatically:

| Property    | Description                                                |
|-------------|------------------------------------------------------------|
| Created     | DateTime (UTC) at which the service was initially created. |
| Created by  | User name of the user who created the service.             |
| Modified    | DateTime (UTC) at which the service was last modified.     |
| Modified by | User name of the user who last modified the service.       |

> [!NOTE]
>
> - When you upgrade to DataMiner version 10.3.0, a check will be performed to make sure your system includes an up-to-date SRM solution. If the installed SRM solution is not up to date, you will be asked to update it before you continue with the DataMiner upgrade.
> - These properties will only be added to existing services the first time those services are updated.
> - These properties will not be available in alarms that are included in a service.

#### BREAKING CHANGE: GetSpectrumTrendTraceDataMessage will now always require a time range \[ID_31402\] \[ID_32016\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

When a GetSpectrumTrendTraceDataMessage was used to retrieve spectrum data, up to now, it was possible to pass an optional time range (i.e. RangeStart and RangeEnd) next to an ID (i.e. RecordID). From now on, passing a time range next to an ID will be mandatory.

#### DataMiner Object Model: FieldDescriptors can now be configured to allow multiple values \[ID_31905\] \[ID_32904\]

<!-- RN 31905: Main Release Version 10.3.0 - Feature Release Version 10.2.3
RN 32904: Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

From now on, the following types of FieldDescriptor can be configured to allow multiple values:

- DomInstanceFieldDescriptor
- DomInstanceValueFieldDescriptor
- ElementFieldDescriptor
- ResourceFieldDescriptor
- ReservationFieldDescriptor
- ServiceDefinitionFieldDescriptor

To make a FieldDescriptor allow multiple values, set its FieldType to “List\<type>”.

- When the FieldType of a FieldDescriptor is set to “List\<type>”, the FieldValue will be the following:

    ```csharp
    Value = new ListValueWrapper<type>(new List<type>...)
    ```

- If you want to add/update the value of a field of which the FieldDescriptor has its FieldType set to “List\<type>”, then use the AddOrUpdateListFieldValue method. The AddOrUpdateFieldValue method can only be used to add or update fields with a single value.

> [!NOTE]
> The Jobs app currently does not support using FieldDescriptors of which FieldType is set to “List\<type>”.

#### EPM: Aliases for topology cells, chains and search chains can now be specified on element level \[ID_32028\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

In an EPM environment, since DataMiner feature release version 10.1.7, it has been possible to override the names of topology cells, chains, and search chains specified in a protocol with aliases specified in a system-level *EPMConfig.xml* file stored in the C:\\Skyline DataMiner\\ folder. Now, it is also possible to add *EPMConfig.xml* files on element level.

If you want certain aliases for topology cells, chains and search chains to only be applied to a particular element, then create an *EPMConfig.xml* file and place it in the folder of that element (e.g. C:\\Skyline DataMiner\\Elements\\\<ElementName>\\).

> [!NOTE]
> Aliases specified in an element-level EPMConfig.xml file will override aliases specified in the system-level EPMConfig.xml file.

#### DataMiner Object Model: DomInstanceValueFieldDescriptor \[ID_32326\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

A new field descriptor is now available: DomInstanceValueFieldDescriptor

This field descriptor can be used to define a field that will contain the ID of a DomInstance. However, compared to the DomInstanceFieldDescriptor, this descriptor also references a specific value of that DomInstance.

The configuration of this new descriptor is identical to that of the DomInstanceFieldDescriptor, apart from a FieldDescriptorId property, which references a specific FieldValue.

#### New messages that support uploading larger files \[ID_32398\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

The SLNet process can now use the following new messages to upload files to the DataMiner System.

##### StartUploadMessage

This message initiates an upload and returns a *StartUploadResponse* message containing an upload cookie of type int.

| Argument     | Type     | Description                                                                                                                     |
|--------------|----------|---------------------------------------------------------------------------------------------------------------------------------|
| DataChunk    | byte\[\] | The initial chunk of data to be uploaded.                                                                                       |
| ReservedSize | long     | The total size (in bytes) that should be reserved for the full dataset.                                                         |
| Name         | string   | Optional name of the upload. Naming an upload allows you to retrieve its upload status by means of a FindUploadSlotMessage. |

##### ContinueUploadMessage

This message continues an already initiated upload and returns an empty *ContinueUploadResponse* message.

| Argument | Type | Description |
|--|--|--|
| Cookie | int | The cookie returned by the StartUploadMessage. |
| DataChunk | byte\[\] | The next chunk of data to be uploaded. |
| CurrentPosition | long | Optional index location that specifies where the next chunk of data should be appended. Allows you to perform a basic data integrity check. When this location does not match the actual server-side location, the upload will fail. |

> [!NOTE]
>
> - The above-mentioned messages will be used when uploading a large data stream by means of the SendLargeStream method in the SLNetTypes FileUploader helper class.
> - The existing SendFile method will use SendLargeStream in the background when it detects a file larger than 2 GB. The default chunk size is 100 KB. When sending large files, it is recommended to slightly increase this default chunk size to prevent a large number of small messages.
> - As the AppPackageHelper uses the FileUploader helper class to upload DataMiner packages, it will now also support uploading larger packages.

#### DataMiner Object Model: New event message for DomInstance status transitions \[ID_32418\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

With the introduction of the DomInstanceStatusChangedEventMessage, it is now possible to subscribe to DomInstance status transitions. This message contains the DomInstanceId, the FromState, the ToState and the Username (i.e. the name of the user who changed the status).

IModuleEvents are now filtered by IModuleEventSubscriptionFilter first, before any other filter is applied.

#### Service templates: Referencing table parameter cells by means of the primary key \[ID_32549\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When configuring a service template, you can use placeholders to reference a parameter value. When referencing a column, up to now, it was only possible to identify a cell by means of the display key. From now on, it is also possible to identify a cell by means of the primary key. See the following example:

```txt
[element:1:param:1002:^pk^myPrimaryKey]
```

#### New property added to PaToken class: Dictionary\<string,DomInstanceId> UserDomInstances \[ID_32599\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

The PaToken class has a new property: Dictionary\<string,DomInstanceId> UserDomInstances.

This is intended to be used in the Process Automation framework.

#### Process Automation: New ProcessAutomationResourcePool object \[ID_32657\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

A new Process Automation object class has been created (which inherits the regular ResourcePool class): *ProcessAutomationResourcePool*

This new object has a property that will be used to store the queue element associated with a resource pool: *public ElementId QueueElement*

#### DataMiner Object Model: Defining a TLL for DomTemplates, DomInstances and DomInstance history \[ID_32662\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

It is now possible to define a "time to live" property for the following types of DomManager objects:

| Object type                        | Property              |
|------------------------------------|-----------------------|
| DomInstance                        | DomInstanceTtl        |
| DomTemplate                        | DomTemplateTtl        |
| HistoryChange (DomInstanceHistory) | DomInstanceHistoryTtl |

Times are defined as TimeSpan objects. By default, these will be set to TimeSpan.Zero, i.e. no TTL. When, for a particular type of object, the TTL is set to e.g. 1 year, those objects will be automatically removed when they were last modified more than a year ago.

Example:

```csharp
var moduleSettings = new ModuleSettings("example")
{
    DomManagerSettings = new DomManagerSettings()
    {
        TtlSettings = new TtlSettings()
        {
            DomTemplateTtl = TimeSpan.Zero,                 // No TTL
            DomInstanceHistoryTtl = TimeSpan.FromDays(365), // 1 Year
            DomInstanceTtl = TimeSpan.FromDays(730)         // 2 Years
        }
    }
};
```

> [!NOTE]
> TTL settings are checked every 30 minutes. When you configure a very short TTL (e.g. 15 minutes), keep in mind that the objects in question will only be removed during the next cleanup cycle.

#### Service & Resource Management: Service templates now also accept ServiceID and ReservationID as input data \[ID_32668\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

In Service & Resource Management environments, a service template used to generate a service associated with a booking will now also accept a ServiceID and a ReservationID as input data.

#### Running memory-intensive elements in separate SLProtocol and SLScripting instances \[ID_32742\] \[ID_32917\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

As some element protocols have QActions that require a large amount of memory to execute, they can cause SLScripting to run out of memory when they run together with other elements. From now on, elements that require a large amount of memory can be run in their own SLProtocol and SLScripting instance.

In *DataMiner.xml*, the \<ProcessOptions> element can now contain a \<SeparateProcesses> element listing all element protocols that have to be run in a separate SLProtocol and SLScripting instance. See the example below.

When a protocol is flagged to run in separate instances, every element using that protocol will be started in a new instance of SLProtocol and SLScripting. When the element is stopped, these instances are taken down again, and when the element restarts, new instances are created.

Example:

```xml
<DataMiner>
  ...
  <ProcessOptions protocolProcesses="3" scriptingProcesses="protocol">
    <SeparateProcesses>
      <Protocols>
        <Protocol>
          <Name>MyElementProtocol</Name>
        </Protocol>
      </Protocols>
    </SeparateProcesses>
  </ProcessOptions>
  ...
</DataMiner>
```

See also [Making all elements using a particular protocol.xml run in separate SLScripting and SLProtocol instances \[ID_33358\]](#making-all-elements-using-a-particular-protocolxml-run-in-separate-slscripting-and-slprotocol-instances-id_33358).

> [!NOTE]
>
> - It is recommended to stop the DataMiner Agent before changing its *DataMiner.xml* file. Besides, any changes made to the *DataMiner.xml* will only be applied when starting the DataMiner Agent.
> - Using the protocolProcesses option, you can specify how many SLProtocol processes will be launched to host the other elements in.
> - Currently, a separate SLScripting process must be launched for every SLProtocol process. This means that when at least one protocol name is specified in the SeparateProcesses tag, the configured or default behavior of the scriptingProcesses attribute will be overridden to “protocol”. Note that when the scriptingProcesses attribute is set to “\[Service\]”, the following system notice will be generated:
>
>   *\[n\] separate protocols have been configured in the DataMiner.xml, while SLScripting is configured as service, which is not a compatible setup. To run the elements of these protocols in a separate SLProtocol and SLScripting instance, please unregister SLScripting and remove the scriptingProcesses=\\"\[Service\]\\" tag from DataMiner.xml.*
>
> - *DataMiner.xml* files are not synchronized among the different Agents in a DataMiner System. If your DMS includes different Agents, then you will need to edit the *DataMiner.xml* file on each of the Agents.

#### SetAlarmStateMessage can no longer be used to change the alarm state of an incident \[ID_33273\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

From now on, it will no longer be possible to change the alarm state of an incident by means of a SetAlarmStateMessage. If you attempt to do so, an exception will be thrown.

#### DataMiner Object Model: Defining a script execution action that will execute an interactive Automation script \[ID_33513\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

It is now possible to define a script execution action that will execute an interactive Automation script.

Process:

1. A client requests the execution of a DOM action in which the execution of an interactive Automation script has been defined via the domHelper.DomInstances.ExecuteAction() method.

   To indicate that the Automation script is an interactive Automation script, the IsInteractive property of the ExecuteScriptDomActionDefinition must be set to true.

1. The domHelper.DomInstances.ExecuteAction() method replies immediately.

   - Its TraceData contains a DomActionInfo object in which type is set to DomActionInfo.Type.ScriptExecutionId.

   - The info object has an ExecutionId property that contains the execution ID of the script that was triggered by the DOM action.

1. The client sends a ScriptControlMessage of type Launch using the script ID that was returned and will then receive ScriptProgressEventMessages.

> [!NOTE]
> The connection used by the DomHelper sending the DOM action execution request should also be used to interact with the script.

#### DataMiner upgrade: When VerifyClusterPorts prerequisite fails the user will now receive more information on why it failed \[ID_33979\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU0] -->

When, during a DataMiner upgrade, the VerifyClusterPorts prerequisite fails, you will now receive more information on why it failed. For example, the DMS.xml file could contain faulty IP addresses or NATS may have silently failed.

### DMS Security

#### SLSSH: Enhanced HMAC, cypher and key exchange algorithm support \[ID_32664\] \[ID_32786\]

<!-- RN 32664: Main Release Version 10.3.0 - Feature Release Version 10.2.4
RN 32786: Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

SLSSH now supports the following additional HMAC, cyphers and key exchange algorithms:

- HMAC-SHA2-512
- AES256CRT
- ECDHSHA2NISTP384
- ECDHSHA2NISTP521

DataMiner now supports the encryption methods detailed below (in order of preference).

##### HMACs

- HMAC-SHA2-512
- HMAC-SHA2-256
- HMAC-SHA1
- HMAC-MD5

##### Key exchange algorithms

- ecdh-sha2-nistp521
- ecdh-sha2-nistp384
- ecdh-sha2-nistp256
- diffie-hellman-group14-sha1
- diffie-hellman-group1-sha1
- diffie-hellman-group-exchange-sha1

##### Ciphers

- Aes-256-CTR
- Aes-128-CTR
- Aes-128-CBC
- 3des-CBC

#### SLSSH: Enhanced host key verification algorithm support \[ID_33132\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

When acting as an SSH client, DataMiner now supports the following host key verification algorithms (in order of preference):

- ecdsa-sha2-nistp521 (new)
- ecdsa-sha2-nistp384 (new)
- ecdsa-sha2-nistp256 (new)
- ssh-rsa
- ssh-dss

#### Azure Active Directory: Secret expiry notices/errors \[ID_33916\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When Azure Active Directory is used as an identity provider, DataMiner Cube will now show

- a notice when the secret will expire in less than a week, and
- an error when the secret has expired.

Also, more detailed entries will now be added to the logs when setup errors have been detected (missing permissions, missing configurations, expired secrets, etc.).

> [!IMPORTANT]
> Note that, for this enhancement to work, the following changes have to be made to the Azure configuration and the *DataMiner.xml* file.
>
> - In Azure, add the API permission *Application.Read.All*.
> - Copy the Azure app object ID (Azure AD \> App registrations \> \[your application\] \> Object ID) and, in *DataMiner.xml*, add it to the *objectId* attribute of the AzureAD element.

### DMS Protocols

#### Elasticsearch: Defining a logger table of type DirectConnection with a primary key \[ID_32375\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

It is now possible to define a logger table of type DirectConnection with a primary key.

In the \<Param> element of the logger table, do the following:

- Set ArrayOptions@index to “1”.
- In Database, Set IndexingOptions@enabled to “true” and Connection.Type to “Directconnection”.

See the following example:

```xml
<Param>
  <ArrayOptions index="1" options=";database" ...>
    ...
  </ArrayOptions>
  <Database>
    <IndexingOptions enabled="true" />
    <Connection>
      <Type>Directconnection</Type>
    </Connection>
  </Database>
</Param>
```

##### Overview of the possible ArrayOptions@index and Connection.Type combinations

- Connection type: DirectConnection

  - No index defined: The data will be pushed via the direct connection and the ID will be assigned by the database. Updating the data will not be possible in this case.

  - Index defined: The data will be pushed via the direct connection and the ID will be assigned by the column template that is being sent via the direct connection by means of an “InitializeWriteAction”.

  > [!NOTE]
  > When using directconnection in combination with a defined index, the TTL of the table should always be infinite.

- Connection type: SLProtocol

  - No index defined: Currently not supported.

  - Index defined: Default logger table configuration.

- No connection type defined

  - No index defined: Fallback to connection type “DirectConnection” with no index defined.

  - Index defined: Fallback to connection type “SLProtocol” with index defined.

#### NT_UPDATE_DESCRIPTION_XML (127) now supports overriding parameter units \[ID_32891\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

Using NT_UPDATE_DESCRIPTION_XML (127), it is now possible to override parameter units.

#### New \<ProcessAutomation> element to pass parameter values to the Service Definition component of the Dashboards app \[ID_32910\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

The new \<ProcessAutomation> element allows you to pass parameter values to the Service Definition component of the Dashboards app.

See the example below. For every value you want to pass, you have to add a \<ProcessAutomationOption> element with the following attributes:

- name (i.e. the name assigned to the value)
- pid (i.e. the ID of the parameter containing the value to be passed)

Example:

```xml
<Protocol>
  ...
  <ProcessAutomation>
    <ProcessAutomationOptions>
      <ProcessAutomationOption name="Queue" pid="501" />
      ...
    <ProcessAutomationOptions>
  <ProcessAutomation>
  ...
</Protocol>
```

#### Direct view tables using columns from different protocols [ID_33253]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

It is now possible to build a direct view table using multiple columns from multiple different protocols. This can be done using the new *CrossDriverOptions* element.

For example:

```xml
<Protocol>
...
   <Params>
   ...
      <Parameter id="50000">
       ...
          <ArrayOptions index="0" options=";view=1;directView=105">
          ...
          </ArrayOptions>
          <CrossDriverOptions>
             <CrossDriverOption protocol="Protocol1" remoteTablePID="30000">
                 <PIDTranslation local="50002" remote="30002"/>
                 <PIDTranslation local="50004" remote="30005"/>
             </CrossDriverOption>
             <CrossDriverOption protocol="Protocol2" remoteTablePID="20000">
                 <PIDTranslation local="50003" remote="20002"/>
                 <PIDTranslation local="50005" remote="20003"/>
              </CrossDriverOption>
          </CrossDriverOptions>
      </Parameter>
      ...
   </Params>
   ...
</Protocol>
```

#### Making all elements using a particular protocol.xml run in separate SLScripting and SLProtocol instances \[ID_33358\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In a protocol.xml file, you can now define that all elements using that protocol.xml file should run in a separate SLScripting and SLProtocol instance.

To do so, use the following syntax:

```xml
<Protocol>
  <SystemOptions>
    <RunInSeparateInstance>true</RunInSeparateInstance>
  </SystemOptions>
</Protocol>
```

> [!NOTE]
> If SLScripting is registered as a service, this functionality is not available. Elements running a protocol.xml file in which RunInSeparateInstance is set to true will then create a notification alarm to indicate a potential memory problem.

See also [Running memory-intensive elements in separate SLProtocol and SLScripting instances \[ID_32742\] \[ID_32917\]](#running-memory-intensive-elements-in-separate-slprotocol-and-slscripting-instances-id_32742-id_32917).

##### DataMiner.xml: scriptingProcesses option now accepts integer values

From now on, in *DataMiner.xml*, you can set the scriptingProcesses option to an integer value, indicating the exact number of SLScripting processes that have to be launched. The SLProtocol processes will then be assigned one of the available SLScripting processes in a round-robin way.

For example, if protocolProcesses is set to 5 (i.e. the default value), and scriptingProcesses is set to 3, then...

- SLScripting 1 will host SLProtocol #1 and #4
- SLScripting 2 will host SLProtocol #2 and #5
- SLScripting 3 will host SLProtocol #3

> [!NOTE]
>
> - Assigning more SLScripting processes than SLProtocol processes will simply give every SLProtocol its own instance without launching additional SLScripting processes.
> - Up to now, the allowed values for scriptingProcesses were “\[service\]” and “protocol”. If scriptingProcesses is set to “protocol”, an SLScripting process is initialized for every SLProtocol process. This should not be confused with setting protocolProcesses to “protocol”. In that case, an SLProtocol process is launched for every protocol name.

### DMS Automation

#### Engine object: TriggeredByName property added \[ID_33122\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

A TriggeredByName property has been added to the Engine object. This property of type string will contain the full name of the user who started the Automation script (e.g. “John Doe”).

When an Automation script is triggered by the scheduler, a correlation rule or a redundancy group, the TriggeredByName property will contain one of the following strings:

- “Scheduled task \<name task>”
- “Correlation-rule \<name rule>”
- “Redundancy”

#### New subscript option 'ExtendedErrorInfo' \[ID_33306\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

The SubScriptOptions class now has an ExtendedErrorInfo property (default: false).

If an error occurs in a subscript with extended error info, the HadError property will be set to true. Calling the SubScript.GetErrorMessages method will then retrieve the actual error messages.

Example:

```csharp
var script = engine.PrepareSubScript("MySubScript");
script.ExtendedErrorInfo = true;
script.SelectScriptParam("Info", "{}");
script.SelectScriptParam("ProfileInstance", "{}");
script.SelectDummy("dummy1", dmaId, elementId);
script.StartScript();
if (script.HadError)
{
    string[] errors = script.GetErrorMessages();
    // Handle errors...
}
```

> [!NOTE]
> Up to now, when an element was not running, the following error message would be thrown:
>
> *Element {elementName} is not active, not available or does not exist*
>
> From now, when an element is not running, the following error message (in which elementState will have one of the following values: paused, stopped, in timeout or not active) will be thrown instead:
>
> *Element {elementName} is {elementState}*

#### Added the option to skip the 'script started' information event \[ID_33666\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

When sending an ExecuteScriptMessage, you can now specify that no “Script started” information event should be generated when the script is executed. To do so, add the SKIP_STARTED_INFO_EVENT:TRUE option to the string array as shown in the following example.

```csharp
ExecuteScriptMessage esm = new ExecuteScriptMessage("Script")
{
    Options = new SA(new[]
    {
        "OPTIONS:0",
        "CHECKSETS:TRUE",
        "EXTENDED_ERROR_INFO",
        "SKIP_STARTED_INFO_EVENT:TRUE"
    })
};
engine.ExecuteScript(esm);
```

Also, the SubScriptOptions class has been extended with a SkipInitialInfoEvent property that can be used to pass the above-mentioned option to subscripts. See the following example.

```csharp
var options = engine.PrepareSubScript("SubScript");
options.Synchronous = true;
options.PerformChecks = false;
options.SkipStartedInfoEvent= true;
options.StartScript();
```

### DMS Maps

*No DMS Maps features have been added to this release yet.*

### DMS EPM

*No DMS EPM features have been added to this release yet.*

### DMS Web Services

#### Web Services API v1: New methods to manage service templates \[ID_31612\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

Using the following methods, it will now be possible to manage service templates via the web services API:

- CreateServiceTemplate
- DeleteServiceTemplate
- GetServiceTemplate
- UpdateServiceTemplate

### DMS web apps

#### Jobs app: Name, Start Time and End Time fields in default job section can now be set read-only \[ID_31485\] \[ID_31506\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

In the default job section, the *Name*, *Start Time*, and *End Time* fields can now be set read-only.

#### Ticketing app: System name will now be checked for illegal characters \[ID_31496\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

From now on, the system name of a ticket will no longer be allowed to start with an underscore character or contain one of the following characters: . # \* , " '

When the system name contains one of these illegal characters, an error message will appear.

#### Jobs app: Fields will automatically be set to 'not required' when hidden \[ID_31513\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

From now on, when you hide a job field, you will receive a message that it will automatically be set to “not required”.

> [!NOTE]
> When you unhide a hidden field, it will remain set to “not required”.

#### Dashboards app - GQI: Element, service and view data sources now also return an 'In timeout' column \[ID_31671\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

The element, service and view data sources now return an additional “In timeout” column.

| Data source | Meaning of “True” in “In timeout” column                                                                        |
|-------------|-----------------------------------------------------------------------------------------------------------------|
| Element     | The (replication) element is in timeout.                                                                        |
| Service     | One of the elements in the service is in timeout.                                                               |
| View        | The enhancing element, one of the first-level child elements or one of the recursive child views is in timeout. |

#### Dashboards app - Node edge graph: Option to visualize the direction of the edges \[ID_32519\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When configuring a node edge graph, it is now possible to have the graph visualize the direction of the edges.

To do so, enable the *Visualize directions* setting and select one of the following options:

| Option         | Description                                                                                                                                                           |
|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Flow (default) | The direction is visualized by means of animated edges.                                                                                                               |
| Arrows         | The direction is visualized by means of arrows drawn on the edges. If you select this option, you can also specify the exact position of the arrows on the edges. |

#### Dashboards app: Default index filter for parameter feed component \[ID_32595\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

It is now possible to add a default index filter to a parameter feed component. This way, it's not necessary to apply your filter to the component again whenever the dashboard is refreshed.

This new option is available as an advanced setting that is not displayed by default. To be able to configure it, you therefore first need to add the *showAdvancedSettings=true* option to the dashboard URL. In the *Data* pane of the dashboard edit mode, a new *Parameter table filters* section will then become available. You can configure the default filter in this section and then drag it to a component to apply it.

#### Dashboards app: GQI now supports external data \[ID_32656\] \[ID_32659\] \[ID_32930\] \[ID_33795\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4
RN 33795: Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

It is now possible to configure the Generic Query Interface to retrieve external data, so that dashboard users can use a query data source based on data that is for example retrieved from a CSV file, a MySQL database, or an API endpoint. This is configured through a DataMiner Automation script that is compiled as a library. The GQI will make use of this library to load the external data.

##### Configuring an external data source in a query

This is the most basic procedure to use an external data source in a query:

1. In the Automation app, add a script containing a new class that implements the *IGQIDatasource* interface (see below for more detailed info).

1. Above the class, add the *GQIMetaData* attribute in order to configure the name of the data source as displayed in the Dashboards app.

   For example (see [Example script](#example-script) for a full example):

   ```csharp
   using Skyline.DataMiner.Analytics.GenericInterface;

   [GQIMetaData(Name = "People")]
   public class MyDataSource : IGQIDataSource
   {
   ...
   }
   ```

   > [!NOTE]
   > This is the name that will be shown to the user when they select the data in the Dashboards app. If you do not configure this name, the name of the class is displayed instead, which may not be very user-friendly.

1. [Compile the script as a library](https://docs.dataminer.services/user-guide/Advanced_Modules/Automation/Using_CSharp/Compiling_a_CSharp_code_block_as_a_library.html#compiling-the-library). You can use the same name as defined in the *GQIMetaData* attribute, or a different name. If there are different data sources for which the same name is defined in the *GQIMetaData* attribute, the library name is appended to the metadata name.

1. Validate and save the script. It is important that you do this *after* you have compiled the script as a library, as otherwise the compiler will detect errors.

1. In the Dashboards app, configure a query and select the data source *Get ad hoc data*.

1. In the *Data source* drop-down box, select the name of your ad hoc data source.

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the *IGQIInputArguments* interface in the script to define that a specific argument is required, for instance to filter the displayed data. For more information, refer to the sections below.

##### Interfaces

An ad hoc data source is represented as a class that implements predefined interfaces. The interfaces you can use are detailed below.

- **IGQIDataSource**: This is the only **required** interface. It must be implemented for the class to be detected by GQI as a data source. This interface has the following methods:

    | Method    | Input arguments       | Output arguments | Description                       |
    |-------------|-----------------------|------------------|-----------------------------------|
    | GetColumns  |                       | GQIColumn\[\]    | The GQI will request the columns. |
    | GetNextPage | GetNextPageInputArgs | GQIPage          | The GQI will request data.        |

- **IGQIInputArguments**: This interface can be used to have the user specify an argument, for example the CSV file from which data should be parsed, or a filter that should be applied. This interface has the following methods:

    | Method              | Input arguments                | Output arguments                | Description                                                                       |
    |-----------------------|--------------------------------|---------------------------------|-----------------------------------------------------------------------------------|
    | GetInputArguments    | \-                             | GQIArgument\[\]                 | Asks for additional information from the user when the data source is configured. |
    | OnArgumentsProcessed | OnArgumentsProcessedInputArgs | OnArgumentsProcessedOutputArgs | Event to indicate that the arguments have been processed.                         |

    > [!NOTE]
    > The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.

- **IGQIOnInit**: This interface is called when the data source is initialized, for example when the data source is selected in the query builder or when a dashboard using a query with ad hoc data is opened. It can for instance be used to connect to a database. This interface has one method:

    | Method | Input arguments | Output arguments | Description                                               |
    |----------|-----------------|------------------|-----------------------------------------------------------|
    | OnInit   | OnInitInputArgs | OnInitOutputArgs | Indicates that an instance of the class has been created. |

- **IGQIOnPrepareFetch**: This interface is used to implement optimizations when data is retrieved. This can for instance be used to limit the retrieved data. This interface has one method:

    | Method       | Input arguments          | Output arguments          | Description                                     |
    |----------------|--------------------------|---------------------------|-------------------------------------------------|
    | OnPrepareFetch | OnPrepareFetchInputArgs | OnPrepareFetchOutputArgs | Indicated that the GQI has processed the query. |

- **IGQIOnDestroy**: This interface is called when the instance object is destroyed, which happens when the session is closed, e.g. in case of inactivity or when all the necessary data has been retrieved. It can for instance be used to end the connection with a database. This interface has one method:

    | Method  | Input arguments     | Output arguments     | Description                                    |
    |-----------|---------------------|----------------------|------------------------------------------------|
    | OnDestroy | OnDestroyInputArgs | OnDestroyOutputArgs | Indicates that the GQI will close the session. |

##### Life cycle

All methods discussed above are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following flowchart illustrates the GQI life cycle when a query is created:

![GQI query creation life cycle](~/user-guide/images/GQICreateQuery.png)

The following flowchart illustrates the GQI life cycle when a query is fetched:

![GQI query fetching life cycle](~/user-guide/images/GQIFetchQuery.png)

##### Objects

To build the ad hoc data source, you can use the objects detailed below.

- **GQIColumn**: This is an abstract class with the derived types *GQIStringColumn*, *GQIBooleanColumn*, *GQIIntColumn*, *GQIDateTimeColumn* and *GQIDoubleColumn* and with the following properties::

    | Property | Type           | Required | Description                                                                                                                                                                                                                                                                                                                                  |
    |------------|----------------|----------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Name       | String         | Yes      | The column name.                                                                                                                                                                                                                                                                                                                             |
    | Type       | GQIColumnType | Yes      | The type of data in the column. *GQIColumnType* is an enum that contains the following values: *String*, *Int*, *DateTime*, *Boolean* or *Double*. |

- **GQIPage**, with the following properties:

    | Property  | Type       | Required | Description                                                                                                                                              |
    |-------------|------------|----------|----------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Rows        | GQIRow\[\] | Yes      | The rows of the page.                                                                                                                                    |
    | HasNextPage | Boolean    | No       | *True* if additional pages can be retrieved, *False* if the current page is the last page. |

- **GQIRow**, with the following properties:

    | Property | Type        | Required | Description           |
    |------------|-------------|----------|-----------------------|
    | Cells      | GQICell\[\] | Yes      | The cells of the row. |

- **GQICell**, with the following properties:

    | Property   | Type   | Required | Description                    |
    |--------------|--------|----------|--------------------------------|
    | Value        | Object | No       | The value of the cell.         |
    | DisplayValue | String | No       | The display value of the cell. |

    > [!NOTE]
    > The type of value of a cell must match the type of the corresponding column.

- **GQIArgument**: This is an abstract class, with the derived types *GQIStringArgument* and *GQIDoubleArgument*, and with the following properties:

    | Property | Type    | Required | Description                                 |
    |------------|---------|----------|---------------------------------------------|
    | Name       | String  | Yes      | The name of the input argument.             |
    | IsRequired | Boolean | No       | Indicates whether the argument is required. |

##### Example script

Below you can find an example script that forwards dummy data to the GQI. The name of the data source, as defined in the *GQIMetaData* attribute, will be “People”.

First the *IGQIDataSource* interface is implemented, then *GetColumns* is used to define the custom columns for the data source. In this case, there are 5 columns. The *GetNextPage* method then returns the actual data to the GQI. In this case these are 3 rows, defined as an array of cells. For each cell, a display value can also be defined. In this case, this is done for the cells within the *Height* column to indicate the unit of measure. The *HasNextPage* property is set to *False* to indicate that no additional pages need to be fetched.

The optional *IGQIInputArguments* interface is also implemented in the example, in this case to allow the user to add an input argument indicating the minimum age for the records that will be retrieved. The argument is indicated as required, so the user will have to specify it to be able to configure the query. The argument value is retrieved with *OnArgumentsProcessedInputArgs* and used to filter the returned data.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "People")]
public class MyDataSource : IGQIDataSource, IGQIInputArguments
{
    private GQIDoubleArgument _argument = new GQIDoubleArgument("Age") { IsRequired = true };
    private double _minimumAge;

    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
            new GQIStringColumn("Name"),
            new GQIIntColumn("Age"),
            new GQIDoubleColumn("Height (m)"),
            new GQIDateTimeColumn("Birthday"),
            new GQIBooleanColumn("Likes apples")
        };
    }

    public GQIArgument[] GetInputArguments()
    {
        return new GQIArgument[] { _argument };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _minimumAge = args.GetArgumentValue(_argument);
        return new OnArgumentsProcessedOutputArgs();
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var rows = new List<GQIRow>() {
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Alice" },
                        new GQICell() { Value = 32 },
                        new GQICell() { Value = 1.74, DisplayValue = "1.74 m" },
                        new GQICell() { Value = new DateTime(1990, 5, 12) },
                        new GQICell() { Value = true }
                    }),
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Bob" },
                        new GQICell() { Value = 22 },
                        new GQICell() { Value = 1.85, DisplayValue = "1.85 m" },
                        new GQICell() { Value = new DateTime(2000, 1, 22) },
                        new GQICell() { Value = true }
                    }),
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Carol" },
                        new GQICell() { Value = 27 },
                        new GQICell() { Value = 1.67, DisplayValue = "1.67 m" },
                        new GQICell() { Value = new DateTime(1995, 10, 3) },
                        new GQICell() { Value = false }
                    })
            };

        var filteredRows = rows.Where(row => (int)row.Cells[1].Value > _minimumAge).ToArray();

        return new GQIPage(filteredRows)
        {
            HasNextPage = false
        };
    }
}
```

#### Dashboards app - GQI: Linking feeds to arguments of external data sources \[ID_32658\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When you build a GQI query that uses an external data source, it is now possible to link feeds to arguments of that external source.

#### Dashboards app: User groups can now be selected in dashboard security \[ID_32681\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When you configure who can view or edit a specific dashboard, it is now possible to select entire user groups instead of only individual users. Groups are indicated with a different icon to make the difference clear. In the selection box, they are listed together with individual users. Natural sorting is applied, with individual users being sorted by full name and groups being sorted by group name.

#### Dashboards - Data panel: Enhanced element selection \[ID_32769\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

A number of enhancements have been made to the *Elements* section of the Data panel.

Up to now, when you switched to edit mode, the first 10,000 elements would be loaded. From now on, the elements will be loaded in batches and a “Load more” button will allow you to load in the next batch.

Also, there is now an element search box as well as a number of element filter options:

- a view filter to only show elements in a particular view (and its subviews),
- a protocol filter to only show elements running a particular protocol,
- an *EPM managers* checkbox to only show EPM Manager elements, and
- a *Spectrum analyzers* checkbox to only show Spectrum elements.

#### Dashboards app: New sidebar icons to list private and shared dashboards \[ID_32854\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In the sidebar, next to the *All dashboards* and *Recent dashboards* icons, there are now two new icons:

- *Private dashboards*, and
- *Shared dashboards*.

The first icon will only be available when there are private dashboards, the second icon will only be available when the DataMiner Agent is connected to the cloud and there are shared dashboards.

#### Dashboards app - Service definition component: Arrows will now automatically be drawn when a Process Automation definition was added \[ID_32960\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the component will now automatically draw the necessary arrows to indicate the connections between the different blocks/nodes in the diagram.

#### Dashboards app: Using the script output of an interactive Automation script as a feed \[ID_32977\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When building a GQI query, you can now also use the script output of an interactive Automation script as a feed.

#### Dashboards app - Service definition component: Function shapes will now reflect the function type \[ID_32995\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When a Process Automation definition is added to the Service definition component, the added function shapes will now reflect the function type (UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent or EndEvent).

#### DataMiner Low-Code Apps \[ID_33002\] \[ID_33040\] \[ID_33208\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5
RN 33208: Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

With the DataMiner Low-Code Apps (also known as the "Application Framework"), you can create custom low-code applications that interact with data from a DataMiner System or an external source.

These applications can be created on the root web page of a DataMiner System and can be organized into sections. To place an application in one or more specific sections, open the App.info.json file in the correct application folder (C:\\Skyline DataMiner\\applications\\APP_ID) and add the section names to the Sections array.

> [!NOTE]
> The “Low-code Apps” license is required to use or access the DataMiner Low-Code Apps.

##### Pages and panels

Pages and panels are the basic building blocks of an application. On a page or a panel, or even between pages and panels, data can be fed between components to create dynamic visualizations. Pages and panels can also each have a header bar with different buttons that are used to execute actions via events. Each button can have a customized icon and label.

The application sidebar allows you to navigate between the different pages, which can each have a label and an icon. It is also possible to hide pages. That way they will not appear in the sidebar and will only be accessible via actions.

Panels are used to group data on a page. They can be displayed on the left side of a page, on the right side of a page or as a popup, and can be shown or hidden via actions that are executed when an event occurs. Panels can be reused on different pages.

##### Events and actions

In an application, you can configure actions that will be executed each time one of the following events occur:

- A new page is loaded.
- A (header bar) button is clicked.

At present, the following actions can be configured:

| Action | Description |
|--|--|
| Launch a script | Launch an Automation script with a specific configuration and a specific number of inputs (which can be linked to feeds like e.g. the Query Row feed). |
| Navigate to a URL | Navigate to a specific URL (in a new tab). |
| Open a page | Open a (hidden) page in the same application. |
| Open a panel | Open a panel on the current page. Panels can appear on the left side of a page, on the right side of the page or as a popup. |
| Close a panel | Close a panel that was open on the current page. |
| Open an app | Navigate to another application. |
| Execute component action | Execute a component action. E.g. select an item in a table, create a new instance, etc. |

By default, actions are executed asynchronously. However, it is also possible to configure chains of actions that should be executed synchronously, i.e. only when the preceding action was executed successfully.

Also, by combining different actions into one, you can create complex behavior. For example, open a page, open a panel and launch an Automation script that updates parameters displayed on that panel while it is being opened. This complex action can then be linked to e.g. a header bar button.

##### Versioning

The DataMiner Low-Code Apps include a versioning system that allows different versions of the same application to exist simultaneously. These different versions can be accessed via the versions panel of the application, which also allows the versions to be edited.

When you create a new application, a first draft version of that application is created. That version can then be published, i.e. made accessible to end users. Each time the published version of an application is edited, a new draft version will be created. Draft versions are meant to be used as prototypes for testing purposes.

Per application, there can be up to 15 versions: 14 draft versions and one published version. When a 16th version is created, the oldest draft version will automatically be deleted. The published version will never be deleted. As there can be only one published version, whenever you publish a version, the previously published version will automatically be demoted to draft version.

##### Security

The Low-Code Apps have two levels of security:

- on DataMiner level, user permissions control access to the Low-Code Apps in general, and
- on application level, user permissions control access to specific applications.

Access to the Low-Code Apps is controlled by the following user permissions that can be configured per user or user group:

- View applications
- Add new applications
- Edit applications
- Delete applications
- Publish applications

> [!NOTE]
> Users without “View applications” permission do not have access to the Low-Code Apps. Even if they have been granted some of the other user permissions, they will not be able to perform any action whatsoever within the Low-Code Apps.

Access to a specific application can be configured in the application itself. Per application, you can define a list of users with view and/or edit permission. By default, no restrictions will be applied, meaning that everyone will be allowed to view and edit the application.

#### Dashboards app - Service definition component: Function nodes will now display the number of Process Automation tokens in queue or in progress \[ID_33025\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When a Process Automation definition is added to the Service definition component, all function nodes will now display the number of tokens currently in queue or in progress.

The token counters will be updated every 10 seconds.

#### Web apps - Data table component: Search box \[ID_33385\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you hover over a data table component (e.g. a GQI table), a search box will now appear in the bottom-right corner. When you enter a search string, a case-insensitive client-side search will be performed.

#### Web apps: Dashboards, app pages and app panels now all have a 'Fit to view' setting \[ID_33401\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In the Dashboards app and the Low-Code Apps, dashboards, app pages, and app panels now all have a “Fit to view” setting that, when enabled, will make sure the items in question are automatically adapted to fit the screen.

#### Web apps - Data table component: Sorting, grouping and filtering options \[ID_33403\] \[ID_33433\] \[ID_33454\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you right-click a column header of a data table component (e.g. a GQI table), you will now be presented with a number of sorting, grouping and filtering options.

- To sort by the column in question, select a sort order (e.g. A \> Z, Z \> A, etc.).

- To group by the column in question, select *Group*.

- To filter the data in the table, construct a single or composite condition depending on the column type:

    | Column type | Filter option |
    |-------------|---------------|
    | String/GUID | One or more of the following conditions (combined with OR):<br> - contains some text (case insensitive)<br> - does not contains some text (case insensitive)<br> - matches a regular expression<br> - does not match a regular expression<br> - equals some text (case insensitive)<br> - does not equal some text (case insensitive) |
    | Numeric/DateTime | One or more ranges (combined with OR) |
    | Boolean | True or false |

    > [!NOTE]
    >
    > - You can specify multiple column filters. If you do, they will be combined with AND.
    > - Column filters can be used in combination with the component’s search box.
    > - Grouping and column filters are not persistent. When you leave the page, all grouping and filtering will be cleared.

#### Web apps - Data table component: Copy cell/row/column/table \[ID_33440\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you right-click a non-empty cell in a data table component (e.g. a GQI table), you can now choose to copy the cell value, the entire row, the entire column or the entire table.

If you choose to copy the entire row or the entire table, the data will be copied in CSV format.

> [!NOTE]
>
> - If you copy a cell or an entire column, the values will not be enclosed in double quotes.
> - If you copy an entire row or an entire table, the values will be enclosed in double quotes.
> - If a value contains double quotes, they will be escaped upon copying.

#### Dashboards app: Service Definition component now supports both types of process automation service definitions \[ID_33615\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

The Service Definition component now supports both types of process automation service definitions:

- Skyline Process Automation
- Custom Process Automation

#### Dashboards app / Low-Code Apps - Service Definition component: Text displayed on process automation service definition node will now be the value of that node's Label property [ID_33754]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, when a Service Definition component displayed a service definition of type "Skyline Process Automation" or "Custom Process Automation", the name of the associated function definition would be displayed on the nodes. From now on, the text displayed on a particular node will be the value of that node's *Label* property. Only when no *Label* property could be found will the name of the associated function definition be displayed instead.

#### DataMiner web apps updated to Angular 13 \[ID_33869\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The DataMiner mobile apps that use Angular (e.g. low code apps, Dashboards, Monitoring, Ticketing, Jobs and Automation) now use Angular 13 instead of Angular 12.

#### Dashboards app - GQI: 'Line & area chart' component is now able to visualize GQI query results as a single line \[ID_33879\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The “Line & area chart” component is now able to visualize GQI query results as a single line.

1. Add GQI query data to the chart component.

1. In the component settings tab:

   - Select the query.

   - Select the X axis column.

   - Select the Y axis column.

1. In the component layout, adapt the style of the chart.

> [!NOTE]
> If you want the component to show a classic trend chart, make sure the query result is sorted by the X axis column.

#### GQI: When all data is requested, the page size will now be calculated based on the amount of columns that are retrieved \[ID_33935\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, when all GQI data was requested, the page size would always be set to 50. From now on, the page size will be set to a number between 50 and 1000, based on the amount of columns that are retrieved (max. 3000 cells).

### DMS Service & Resource Management

#### Retrieving bookings in a paged way and sorted by property \[ID_31982\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

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

#### ProfileInstances: New parameter property 'InheritIsHidden' \[ID_32131\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

In the ParameterSettings property of a profile instance, you can now use the “InheritIsHidden” property to indicate whether a profile instance should inherit the “IsHidden” property of a profile parameter. This property is false by default.

A few examples:

- If a parameter of profile definition A is hidden, and you want profile instance A to inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to true.
- If a parameter of profile definition A is hidden, and you want profile instance B to not inherit the “IsHidden” setting of that parameter, then set “InheritIsHidden” to false and “IsHidden” to true.

#### Replacing system functions by uploading an XML file \[ID_32264\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

It is now possible to replace the system protocol functions by uploading an XML file using the ProtocolFunctionHelper. See the following example.

```csharp
var pfHelper = new ProtocolFunctionHelper(engine.SendSLNetMessages);
var xmlContent = File.ReadAllText("...");
pfHelper.ReplaceActiveSystemFunctionDefinitions(xmlcontent);
```

> [!NOTE]
>
> - If the uploaded file is not a valid XML file, a DataMinerException will be thrown and the system functions will not be replaced.
> - Each function in the XML file must have a valid ID. Functions without a valid ID will be ignored.

#### ResourceUsageInfoManager \[ID_32512\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

SLNet now includes a ResourceUsageInfoManager, which will keep track of the Resources being used by ReservationInstances. Each time a change is detected as to Resource usage, this manager will send out a ResourceUsageStatusEventMessage containing the DMA ID and a list of UpdatedResourceUsageStatuses.

A ResourceUsageStatus contains a ResourceId and a list of UsingReservationInstances. That list will contain a ReservationInstanceUsageDetails object for every ReservationInstance that is using the Resource. Currently, the object only contains a ReservationInstanceId property.

Normally, a ResourceUsageStatusEventMessage will be sent out the moment a Resource is being used in an ongoing reservation or when a ReservationInstance using that resource ends. When a Resource is no longer used in any reservation, an event will be sent out with a ResourceUsageStatus containing an empty list.

ResourceUsageStatus objects can be retrieved by means of a GetResourceUsageStatusList (FilterElement\<Resource> filter) call on the ResourceManagerHelper. This call will return all status objects for the resources that match the filter and that are currently being used by ongoing reservations.

#### ReservationInstances now have a ReservationInstanceType \[ID_32624\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When configuring a ReservationInstance, you now have to specify a ReservationInstanceType:

- Default
- Process Automation
- Custom Process Automation

> [!NOTE]
>
> - In case of a ServiceReservationInstance, the type of the instance must be identical to the type of the ServiceDefinition. Otherwise, the ResourceManager will throw a “ServiceDefinitionTypeDoesNotMatch” error.
> - A new exposer has been added to allow filter ReservationInstanceType.

#### Modified AbsoluteQuarantinePriority behavior and several new SRM features \[ID_32654\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

Several changes to the SRM framework have been introduced:

- Modified *AbsoluteQuarantinePriority* behavior.
- New *ConcurrencyUsageType* property for ResourceUsageDefinition
- Possibility to book complete resource capacity
- Possibility to include elements in bookings

##### Modified AbsoluteQuarantinePriority behavior

The behavior of the *AbsoluteQuarantinePriority* property has been modified. Up to now, if this property was set to true for a booking instance, all overlapping booking instances using the same resources were forced into quarantine. Now this property will only determine the priority of the booking when a quarantine is needed.

To implement a quarantine, overbooked capacity is now removed from bookings according to the following order of priority:

1. Bookings that are already in the quarantined state.
1. Bookings for which *AbsoluteQuarantinePriority* is not specified or false.
1. Bookings that are in a "Pending" state.
1. Bookings with the latest start time.
1. Booking of which the name comes last alphabetically.
1. Bookings of which the GUID comes last alphabetically.

The image below illustrates a situation where the quarantine behavior has changed. Previously, booking A would have been quarantined, as it uses resource 1. Now this will no longer happen as the capacity is actually not overbooked.

![Quarantine behavior example](~/release-notes/images/32654_1.png)

The following image also illustrates the modified behavior. If booking B does not have *AbsoluteQuarantinePriority* set to true, its capacity will be moved, as it has a later start time. If *AbsoluteQuarantinePriority* is set to true, the overbooking will be resolved by moving the capacity from booking A.

![Quarantine behavior example](~/release-notes/images/32654_2.png)

##### New ConcurrencyUsageType property for ResourceUsageDefinition

A ResourceUsageDefinition now has the property *ConcurrencyUsageType*, which can have the following values:

- *ConcurrencyUsageType.Default*: The default value. The ResourceUsageDefinition takes one concurrency of the resource.
- *ConcurrencyUsageType.All*: The ResourceUsageDefinition takes all the concurrency of the resource.
- *ConcurrencyUsageType.None*: The ResourceUsageDefinition does not take any concurrency of the resource.

Resource usage can only overlap with a ResourceUsageDefinition with *ConcurrencyUsageType.All* if it is set to *ConcurrencyUsageType.None*. This limitation is also in place for a single booking: if a booking has a resource with complete concurrency and another resource with 1 concurrency, the booking will be quarantined because it requests more concurrency than is available. If a complete concurrency usage is quarantined to resolve a concurrency conflict (as determined by the priority defined on booking level), it will be moved in its entirety – there is no option to only move part of the concurrency to quarantine.

The actual concurrency of a ResourceUsageDefinition with *ConcurrencyUsageType.All* is determined at runtime, as the *MaxConcurrency* value of the resource at the moment when it is needed, e.g. when *GetEligibleResources* is called or when quarantine checks are done to add or update a booking instance or resource.

Code example:

```csharp
var booking = new ReservationInstance(new TimeRangeUtc(DateTime.UtcNow, DateTime.UtcNow.AddHours(10)))
{
    Name = "Booking 123",
    ID = Guid.NewGuid()
};

var resourceUsage = new ResourceUsageDefinition(resourceId)
{
    ConcurrencyUsageType = ConcurrencyUsageType.All
};

booking.ResourcesInReservationInstance.Add(resourceUsage);
```

##### Booking complete resource capacity

It is now possible to book all the capacities of a resource for their complete value, by setting the *UsesCompleteCapacity* property for the ResourceUsageDefinition to true. If the resource has more than one capacity defined, this will reserve all capacities. By default, this property is set to false.

No other usage can overlap in case complete capacity is used. This limitation is also in place for a single booking: if a booking has a resource with complete capacity and another resource with 100 capacity, the booking will be quarantined because it requests more capacity than is available. If a complete capacity usage is quarantined to resolve a conflict (as determined by the priority defined on booking level), it will be moved in its entirety.

The actual capacity in case *UsesCompleteCapacity* is true is determined at runtime, e.g. when *GetEligibleResources* is called or when quarantine checks are done to add or update a booking instance or resource.

Code example:

```csharp
var booking = new ReservationInstance(new TimeRangeUtc(DateTime.UtcNow, DateTime.UtcNow.AddHours(10)))
{
    Name = "Booking 123",
    ID = Guid.NewGuid()
};

var resourceUsage = new ResourceUsageDefinition(_resource.ID)
{
    UsesCompleteCapacity = true
};

booking.ResourcesInReservationInstance.Add(resourceUsage);
```

##### Including elements in bookings

It is now possible to define an ElementUsageDefinition to include an element in a booking. When the element is included, ResourceUsageDefinitions will automatically be added for all the resources linked to the element. These resources will have the new *IsAutoGenerated* property set to true.

ElementUsageDefinition has three properties:

- *ElementUsageImpact*: Determines if the element can be used in overlapping bookings. If set to *None*, overlapping bookings can use the same element. If set to *Full* (the default value), no overlapping bookings can use the same element, even if they have impact *None*. If the *AddOrUpdateReservationInstances* call fails because there are overlapping bookings using the same element with *Full* impact, no changes will be saved and an error of type *ElementUsageOverflow* will be returned.

- *IncludeCapacityBehavior*: Can be set to *All* or *None*. If this is set to *All*, the generated ResourceUsageDefinitions will have the *UsesCompleteCapacity* property set to true.

- IncludeConcurrencyBehavior: Can be set to *All* or *None*. If this is set to *All*, the generated ResourceUsageDefinitions will have the *ConcurrencyUsageType* property set to *ConcurrencyUsageType.All*.

Code example:

```csharp
var booking = new ReservationInstance(new TimeRangeUtc(DateTime.UtcNow, DateTime.UtcNow.AddHours(10)))
{
    Name = "Booking 123",
    ID = Guid.NewGuid()
};

var elementUsage = new ElementUsageDefinition(new ElementID(123,456))
{
    ElementUsageImpact = ElementUsageImpact.Full,
    IncludeCapacityBehavior = IncludeCapacityBehavior.All,
    IncludeConcurrencyBehavior = IncludeConcurrencyBehavior.All
};

booking.ObjectUsages.Add(elementUsage);
```

The following resources are added when an element is included in a booking:

- Resources that reference the element with the *DmaID* and *ElementID* properties.
- Function resources that have the referenced element as their parent element (based on *MainDveDmaId* and *MainDveElementId* properties).
- Virtual function resources linked to the element (based on *PhysicalDeviceDmaId* and *PhysicalDeviceElementId* properties).

Whenever the booking is updated or a relevant resource is created or updated, the element usage is automatically updated. Any changes you do to auto-generated usage will be overwritten by the core software. When the auto-generated usage is updated, the TraceData of the *AddOrUpdateResource* call will contain ResourceManagerInfoData of type ResourceUsagesGeneratedForReservationInstances.

The deletion of resources in auto-generated bookings is blocked in the same way as deletion of resources that were not added automatically is blocked.

This new feature has an *ElementUsages* exposer, which can be used to filter bookings that include a certain element. For example:

```csharp
var elementToSearchFor = new ElementID(123, 789);
var filter = ReservationInstanceExposers.ElementUsages.Contains(elementToSearchFor.ToString());
var bookings = rmHelper.GetReservationInstances(filter);
```

#### ResourceManagerEventMessage: New LostInterestReservationInstances property \[ID_32801\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

When, for example, a table is populated with ReservationInstances using ResourceManagerEventMessages with a SubscriptionFilter, you can now use the LostInterestReservationInstances property to retrieve the IDs of the ReservationInstances that no longer match the current filter after an update.

> [!NOTE]
> This list will only contain ReservationInstances to which the user has access.
> To retrieve the IDs of the ReservationInstances to which the user no longer has access, you can call the GetHiddenReservationInstances method.

#### Functions.xml file: Assigning a function type to a function \[ID_32851\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

It is now possible to assign a function type to each function defined in a functions.xml file.

A function can be assigned one of the following types:

- UserTask
- ScriptTask
- ResourceTask
- Gateway
- NoneStartEvent
- TimeStartEvent
- EndEvent

Default function type: NULL

Example:

```xml
<Functions>
  <Function id="..." name="..." maxInstances="..." profile="...">
    ...
    <FunctionType>UserTask</FunctionType>
  </Function>
  ...
</Functions>
```

> [!NOTE]
> If you add a \<FunctionType> element inside a \<Function> element, it must be the last child element inside the \<Function> element.

#### Subscribing to ResourceUsageStatusEvents for specific resources \[ID_32979\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

From now on, it is possible to only receive ResourceUsageEventMessages for a specific resource. Using ResourceUsageStatusEventExposers, you can now filter by ResourceId.

#### ReservationInstanceType and ServiceDefinitionType: New values 'ResourceScheduling' and 'ResourceOrchestration' \[ID_33390\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

ReservationInstanceType and ServiceDefinitionType can now be set to the following additional values:

- ResourceScheduling
- ResourceOrchestration

#### BREAKING CHANGE: Removing a Resource or ResourcePool object will now always require a valid ID \[ID_33836\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, it was possible to delete Resource and ResourcePool objects in a filtered way by passing an “incomplete” object to the associated remove method of the ResourceManagerHelper. Moreover, passing an empty list or NULL would remove all resources on the system. This will no longer be possible.

From now on, it will only be possible to remove Resource objects by ID or name (case sensitive) and ResourcePool objects by ID.

When DataMiner detects a remove request that contains an object with an empty ID (and an empty name in case of a request to remove a Resource object, one of the following messages will be added to the ResourceManager.txt log file (type: info):

- In case of a request to remove a Resource object:

    ```txt
    Detected a resource delete request that contained at least one object without an ID. Deleting resources with resource object filters is not supported anymore.
    ```

- In case of a request to remove a ResourcePool object:

    ```txt
    Detected a resource pool delete request that contained at least one object without an ID. Deleting resource pools with object filters is not supported anymore.
    ```

> [!NOTE]
> From now on, the log entries added when creating or deleting resources or resource pools will no longer contain the IDs of all objects that were created or deleted. Instead, they will only contain the IDs of the first 10 objects that were created or deleted.

### DMS Mobile Gateway

#### Additional logging after sending a 'send SMS' request to an SMSEagle device \[ID_32785\] \[ID_32911\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

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

#### Standalone Elasticsearch Cluster Installer: New RepoPath setting \[ID_33055\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

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

#### QA Device Simulator: Help link now directs users to the QA Device Simulator help pages on <https://docs.dataminer.services/> [ID_33680]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In the UI of the QA Device Simulator, the help link now directs users to the QA Device Simulator help pages on <https://docs.dataminer.services/>.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

## Changes

### Enhancements

#### Security enhancements \[ID_31045\] \[ID_31054\] \[ID_31761\] \[ID_32055\] \[ID_32566\] \[ID_33069\] \[ID_33078\] \[ID_33218\] \[ID_33365\] \[ID_33583\]

A number of security enhancements have been made.

#### Function.xml files can now contain functions without entry points and maxInstance set to 1 \[ID_31480\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

In a functions.xml file, it is now possible to define functions without entry points and maxInstance set to 1. When all criteria are met, then a function of this type will affect all tables and column parameters defined for that particular function.

> [!NOTE]
> When you defined a function without entry points and maxInstance set to 1, \[Generic Linker Table\] entries will not be taken into account. This function will still affect all table and column parameters defined for it.

#### Filtering alarms on alarm focus: Enhanced performance \[ID_31484\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

Due to a number of enhancements, especially with regard to caching, overall performance has increased when filtering alarms on alarm focus.

#### Enhanced performance when reading data from a MySQL or SQLServer database \[ID_31532\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading data from the database, especially when reading trend data during the migration to another type of database.

#### Enhanced performance when reading trend data from a MySQL or SQLServer database page by page \[ID_31535\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading trend data from the database page by page.

#### Trending: Pattern matching enhancements \[ID_31668\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

From DataMiner 10.0.7 onwards, on systems using a Cassandra and an Elasticsearch database, DataMiner Analytics can automatically recognize recurring patterns in trend data.

A number of enhancements have now been made to this pattern matching mechanism. Also, from now on, all occurrences of recognized trend data patterns will be stored in the Elasticsearch database.

#### Alarm templates: Enhanced performance when adding alarm templates with smart baselines \[ID_31670\]

<!-- Main Release Version 10.3.0 - Feature Release Version (REVERTED) 10.2.3 [CU0] -->

Due to a number of enhancements, overall performance has increased when adding alarm templates with smart baselines.

#### Cassandra will no longer store ArrowWindowRecords and PatternMatchOccurrenceRecords \[ID_31944\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

Cassandra databases will no longer store the following data:

- ArrowWindowRecords
- PatternMatchOccurrenceRecords

The latter will now be stored in Elasticsearch instead.

#### Behavioral anomaly detection: Change point flood notice will now be cleared sooner \[ID_32013\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

From now on, the notice created when the rate of newly detected behavioral changes reaches an upper limit will be cleared sooner. It will now be cleared when the rate has dropped under the limit again and there is no new flood situation in the following 15 minutes. Up to now, the notice would not be cleared for at least 2 hours, even when the actual flood situation had only lasted for a few seconds.

The notice will contain the following message:

```txt
Detection of behavioral anomalies temporarily disabled on DMA ...: maximum allowed rate of behavioral change points reached.
```

#### SLAnalytics - Alarm focus: Enhanced performance \[ID_32270\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time. Due to a number of enhancements, overall performance of this alarm focus feature has increased.

#### Analytics: Prefetching mechanism for trend icons \[ID_32300\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4
Reverted in 10.2.4 -->

During the first few minutes that DataMiner Analytics is running, it is still calculating which trend icons should be displayed. Previously, during this initial period, the trend icons to be displayed were retrieved from the Cassandra database. However, because of changes to the database, this is no longer possible. For this reason, a prefetching mechanism has now been implemented, so that when a trend icon is requested, it is calculated based on prefetched trend data. As there are safeguards in place to ensure that not too many database requests are done at the same time, this does mean that not all trend icons may be displayed immediately.

#### SLAnalytics: A notice event will no longer be generated when entering change point flood mode \[ID_32402\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

Up to now, a notice event would be generated whenever SLAnalytics had entered change point flood mode. From now on, this event will no longer be generated.

> [!NOTE]
> As before, an entry will be added to the SLAnalytics log whenever behavioral anomaly detection has temporarily been disabled because change point flood mode was activated.

#### SLAnalytics: Enhanced accuracy of proactive cap detection \[ID_32591\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

Because of a number of enhancements, proactive cap detection accuracy has been increased.

#### SLMessageBroker: Default connection timeout is now 10 minutes \[ID_32884\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

The Connect() and Publish() methods of SLMessageBroker now have a default connection timeout of 10 minutes.

Also, the interval at which another reconnect is attempted has been increased from 1 second to 10 seconds.

#### Enhancements with regard to Automation scripts \[ID_33129\] \[ID_33226\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

A number of enhancements have been made with regard to Automation scripts.

- When a script is launched, from now on, only the parameters/dummies with missing values will be shown. Automatically filled in values will no longer be shown.
- When script input is filled in with feed data, users will no longer be asked to change that input manually.
- Script input (parameters/dummies) linked to a feed is now filled in at the moment a script action is triggered. Subsequent changes in the feed will have no effect.
- In the DataMiner Low-Code Apps, the option to mark specific script parameters and dummies as required has been removed.
- When, in the Dashboards app, users mark a script parameter as required, they no longer need to fill in a value.
- From now on, a page load event will only trigger after the application page has been fully initialized. This will ensure that, when launching script actions with input linked to feeds, those feeds have been initialized.

#### Service & Resource Management: Enhanced logging \[ID_33183\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

Up to now, when the SRM log files were set to “No logging”, no information would be logged if e.g. a Reservation event had failed. All ResourceManager, ResourceManagerAutomation and FunctionManager logging has now been re-evaluated, and the log settings have been optimized. All critical issues occurring in those modules will now be logged.

#### Profile instance list for PA service definition node now also contains child instances \[ID_33187\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6
See also: DMS Cube - Fix was moved to 10.2.0 CU3 by RN 33188 -->

When you configure a service definition node in the Services app, a list of profile instances is shown for the selected profile definition. For service definitions of type "Skyline Process Automation" and "Custom Process Automation", this list will now also contain instances for child definitions of the configured profile definition.

#### Anomaly detection: Enhanced performance when generating suggestion events and alarms \[ID_33283\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

Because of a number of enhancements, overall performance has increased when generating anomaly detection suggestion events and alarms.

#### DataMiner upgrade will not be performed if NATS is not installed and running \[ID_33304\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you launch a DataMiner upgrade, from now on, the upgrade process will not be allowed to start if NATS is not installed and running.

> [!NOTE]
> This check will be skipped if the current DataMiner version is older than version 10.1.0.

#### SLDMS will now use less memory when storing service information \[ID_33318\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, the SLDMS process will now use less memory when storing service information.

#### QADeviceSimulator: Enhanced CPU usage when running SNMPv3 simulations \[ID_33376\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, overall CPU usage of the QADeviceSimulator has improved when running SNMPv3 simulations.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Service & Resource Management: Function resources will no longer be deleted when their parent DVE element cannot be reached \[ID_33415\] \[ID_33668\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

From now on, the deletion of a function resource will be blocked when the deletion of its parent DVE element fails.

The ResourceManagerHelper now contains a new method to delete resources:

`public Resource[] RemoveResources(Resource[] resources, ResourceDeleteOptions options)`

> [!NOTE]
> Contributing resources can be deleted even when no parent element can be found. The parent element of a contributing resource is an enhanced service element. When the contributing booking is no longer running, the enhanced service element will no longer exist.

#### SLAnalytics: Enhanced performance when retrieving parameter information \[ID_33458\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, overall performance has increased when retrieving parameter information.

#### Web apps: Enhancements with regard to the rendering of GQI tables \[ID_33463\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

A number of enhancements have been made with regard to the rendering of GQI tables.

#### Alarm templates: All behavioral change points will now be considered anomalous \[ID_33476\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

From DataMiner 10.0.3 onwards, you can enable alarm monitoring on specific types of anomalies for parameters in an alarm template. Up to now, when you enabled this, an alarm was generated whenever the SLAnalytics engine considered a behavioral change point anomalous. From now on, all behavior change points will be considered anomalous and will hence trigger an alarm.

#### QADeviceSimulator: Enhanced performance when loading a MySQL database at the start of a MySQL database simulation \[ID_33555\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, overall performance of the QADeviceSimulator has improved when loading a MySQL database at the start of a MySQL database simulation.

Also, the overall memory footprint of MySQL database simulations has been reduced.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Service & Resource Management: A booking will now be set to 'interrupted' when whatever event related to that booking could not be executed \[ID_33576\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

Up to now, when DataMiner was unavailable when a booking was supposed to start or stop, its state was set to “interrupted” when DataMiner started up again.

This functionality has now been extended. A booking will now also be set to “interrupted” when whatever event related to that booking could not be executed.

#### Frequency of smart baseline calculations is now configurable \[ID_33584\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

It is now possible to change the frequency of smart baseline calculations. On systems that aggregate large amounts of data from parameters with smart baselines, it is recommended to increase this frequency, which is 5 minutes by default.

To change this setting, do the following:

1. Open the SLNetClientTest tool.
1. Go to *Advanced \> Options \> SLNet Options*.
1. Select the *SmartBaselineThreadTime* option and change its value.

Minimum value: 1 minute - Default value: 5 minutes

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### QA Device Simulator: Enhanced performance \[ID_33761\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the QA Device Simulator tool has improved.

#### Service & Resource Management: Enhancements made to ResourceManagerHelper [ID_33993]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A number of enhancements have been made to the ResourceManagerHelper class.

For example, from now on, an ArgumentNullException will be thrown when a NULL argument is provided. Also, when a collection with one or more NULL objects is provided, those objects will be ignored.

### Fixes

#### SLAnalytics: Problem with trend prediction \[ID_31352\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

In some rare cases, an error could occur in SLAnalytics when calculating trend predictions.

#### Proactive cap detection: Problem with frequency of trend prediction calculations \[ID_31447\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

The “proactive cap detection” feature predicts future issues based on trend data in the Cassandra database, using advanced techniques that consider repeating patterns, information on the rate at which a parameter value increases or decreases, etc.

Up to now, in some cases, the frequency with which trend predictions were calculated would either be too low or too high.

#### Alarm templates: Incorrect calculation of smart baselines \[ID_31601\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

In some cases, smart baselines would be calculated incorrectly, especially when the “Skip the last X hours in the configured trend window” and “Handle weekend days separately” options were enabled.

#### Factory reset tool SLReset.exe did not remove a number of .lic files \[ID_31722\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

The factory reset tool C:\\Skyline DataMiner\\Files\\SLReset.exe can be used to fully reset a DataMiner Agent to its state immediately after installation.

When run, it will now also remove the following files:

- ClientApps.lic
- request.lic (will be recreated after a DataMiner restart)
- chartDir.lic

#### Dashboards app: Dashboard names would incorrectly be allowed to contain backslash characters \[ID_31735\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

Up to now, it would incorrectly be allowed to enter a name containing backslash characters when creating or renaming a dashboard. From now on, this will no longer be allowed.

#### Elasticsearch: NewPagingSearchRequest was incorrectly not able to query an alias grouping two logger tables \[ID_31767\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

Up to now, a NewPagingSearchRequest was incorrectly not able to retrieve data from an alias that grouped two logger tables.

#### Service & Resource Management: Retrieving ReservationInstances sorted by a property of type string would return an incorrectly sorted result set \[ID_32003\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

When a list of ReservationInstances were retrieved sorted by a property of type string, that list would be returned in an incorrect sort order.

#### Mobile apps: Clients would not immediately receive updates when items were added \[ID_32042\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

When new items were added in one client, in some cases, those items would not immediately appear in other clients. For example, when a user created a ticket for a particular domain, other users viewing the list of tickets for that same domain would not immediately have their ticket list updated.

#### Cassandra: Problem when a NULL value was encountered in a logger table during a database migration \[ID_32358\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

When migrating a database to a Cassandra cluster, in some cases, an error could be thrown when a NULL value was encountered in a logger table.

#### Jobs app: No 'loading' indication when job sections were being loaded \[ID_32616\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When configuring jobs, no “loading” indication would appear when job sections were being loaded.

#### Web services API: Problem with GetServiceTemplate \[ID_32625\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

The GetServiceTemplate method would throw an exception when requesting a service template with Text inputs that had neither of the following options:

- Require a valid element name
- Allow 'N/A' to indicate empty value

#### SLAnalytics: Inaccurate short-term trend predictions \[ID_32731\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

If the DataMiner Agent uses a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Up to now, in some cases, short-term trend predictions could be inaccurate due to a longer seasonality being detected on a higher level.

#### Alarms and information events not migrated during migration to Cassandra Cluster \[ID_32755\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When a DataMiner cluster with multiple DMAs was migrated to a Cassandra Cluster database, it could occur that the migration of alarms and information events failed because the DMAs tried to truncate the same table at the same time. Truncation will now take place in the initialization phase to prevent this problem, and if it fails, this will be logged but will not stop the migration. This will also prevent a rare problem where data could be missing after DMAs were migrated one by one.

#### SLAnalytics: Unneeded error was thrown when an upgrade action tried to remove the pattern match occurrences table from a non-existing Elasticsearch database \[ID_32772\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

On systems without an Elasticsearch database, the following messages were thrown when an upgrade action tried to remove the pattern match occurrences table from the non-existing Elasticsearch database:

```txt
10.102.0.12|2022-03-03 09:33:57|information|Elastic was not detected in DB.xml. Will not remove obsolete Elastic indices.
10.102.0.12|2022-03-03 09:33:58|error|Couldn't remove Elastic indices. Cause: Object reference not set to an instance of an object.
```

From now on, when no Elasticsearch database can be found, only the above-mentioned information event will be thrown.

#### Elasticsearch: TTL settings would not be applied correctly \[ID_32913\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

In some cases, TTL settings defined in an Elasticsearch database would not be applied correctly. As a result, certain data (e.g. profile instance data) would not get properly cleaned up.

#### Web Services API: Problem when opening the soap.asmx page \[ID_32939\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

In some cases, an exception could be thrown when you tried to open the following page: `http://DmaNameOrIpAddress/API/v1/soap.asmx`

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated \[ID_33153\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

#### SLPort would incorrectly split WebSocket messages larger than 65kB \[ID_33182\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

Up to now, when SLPort received a WebSocket message larger than the WebSocket buffer (i.e. 65 kB), it would incorrectly split that message in multiple chunks before passing it to the protocol.

#### Alarm templates: Problem with anomaly detection alarms \[ID_33216\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

When you created an element with an alarm template in which anomaly detection alarms were configured for table parameters, in some cases, none of the enabled types of change points would trigger an alarm.

#### CSLCloudBridge library would incorrectly not take into account the connection timeout specified in SLCloud.xml \[ID_33322\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 [CU0]  -->

Up to now, the CSLCloudBridge library would incorrectly not take into account the connection timeout specified in the SLCloud.xml file. In some cases, this could lead to run-time errors in the MessageBrokerReconnectThread.

The connection timeout specified in SLCloud.xml is the maximum time it can take to set up a connection with NATS (in milliseconds). Minimum value is 1000 ms, default value is 5000 ms.

```xml
<SLCloud>
  ...
  <ConnectTimeout>5000</ConnectTimeout>
  ...
</SLCloud>
```

#### ResourceManager module would fail to initialize on systems with a MySQL database \[ID_33327\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

On systems with a MySQL database, the ResourceManager module would fail to initialize.

#### SLCloud.xml files would incorrectly refer to the local agent using the IP address instead of the hostname when the agents were configured to use HTTPS \[ID_33342\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When, in a DataMiner System, agents were configured to use HTTPS, the SLCloud.xml files of each of those agent would incorrectly refer to the local agent using the IP address instead of the hostname.

#### Web apps: Only part of the value would be selected when moving the mouse pointer over a selection box that had the focus \[ID_33379\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you moved the mouse pointer over a selection box that had the focus, in some cases, only part of the value would be selected.

#### SLAnalytics: Problem when predicting the trend of a history set parameter \[ID_33389\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Up to now, negative status values in the trend data due to element restarts could cause the trend prediction engine to incorrectly interpret the trend data of a history set parameter.

#### Dashboards app - GQI: Values of profile parameters without decimals defined would incorrectly be replaced by the maximum integer value \[ID_33418\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When a profile parameter of type “number” had no decimals defined, its value would incorrectly be displayed as the maximum value that can be assigned to a parameter of type integer. From now on, when a profile parameter has no decimals defined, its value will be displayed as is, without decimals.

#### Ticketing app: Problem with ticket domains incorrectly marked as masked \[ID_33449\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

If, in the Ticketing app, you tried to edit a ticket of a domain linked to an element, in some cases, that domain would incorrectly be marked as “masked”.

#### Issues with NATS request/response actions \[ID_33487\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

A number of issues with NATS request/response actions have been solved.

#### Problem with SLDataGateway when updating parameters \[ID_33535\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In some cases, an error could occur in SLDataGateway when updating parameters.

#### Ticketing app: Problem when trying to add a value to the State field of a ticket domain \[ID_33537\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you tried to add a new value to the State field of a ticket domain, the following error would be thrown when the change was saved:

```txt
Error trapped: Unable to cast object of type 'Skyline.DataMiner.Web.Common.v1.DMATicketFieldPossibleValue' to type 'Skyline.DataMiner.Web.Common.v1.DMATicketStateFieldPossibleState'.
```

#### Dashboards app: Dashboard would incorrectly scroll up when you selected a field in an EPM feed \[ID_33650\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

When, on a dashboard, an EPM feed was surrounded by other components, in some cases, the dashboard would incorrectly scroll up when you selected a field in the EPM feed.

#### Run-time errors due to MessageBrokerReconnectThread problems in SLCloudBridge \[ID_33716\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU0] -->

In some cases, run-time errors could occur due to MessageBrokerReconnectThread problems in the SLCloudBridge process.

#### SLDataGateway: Communication via NATS could get stopped when a large number of parameter changes were being processed \[ID_33731\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 [CU0] -->

When a large number of parameter changes were being processed, up to now, communication entering or leaving SLDataGateway via NATS could get stopped.

#### Problem with SLAnalytics when an element or a parameter was deleted \[ID_33788\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When an element or a parameter was deleted, in some rare cases, an error could occur in the SLAnalytics process.

#### SLAnalytics: Error messages could get added to the log file due to a problem with the automatic incident tracking algorithm \[ID_33820\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Due to a problem with the automatic incident tracking algorithm, error messages similar to the following one could incorrectly get added to the SLAnalytics log file:

```txt
2022/06/08 23:54:36.684|SLAnalytics|Counter.h(61): containers::Counter<ServiceInfo>::decrease)|ERR|0|Decreasing counter for key that is not in the map
```

#### Problem with SLDataGateway while a DataMiner Agent was being shut down [ID_33839]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU0] -->

When a DataMiner Agent was being shut down, in some cases, an error could occur in the SLDataGateway process.

#### DataMiner upgrade: VerifyNatsRunning prerequisite could fail due to SLCloudBridge.dll having been renamed [ID_33875]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU0] -->

During a DataMiner upgrade, the VerifyNatsRunning prerequisite could fail due to the SLCloudBridge.dll file having been renamed to SLMessageBroker.dll in DataMiner versions 10.2.0/10.1.5.

#### Azure Active Directory: Domain users who were only a member of a domain group could be deleted during an LDAP synchronization \[ID_33916\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When using Azure Active Directory as an identity provider, up to now, during an LDAP synchronization, all domain users who were only a member of a domain group would incorrectly be deleted when the Azure AD client secret had expired.

#### DataMiner Object Model: FieldValues would not get concatenated correctly \[ID_33989\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When a name concatenation for a DomInstance had been defined in either the ModuleSettings or the DomDefinition, in some cases, the FieldValues would not get concatenated correctly.

#### Elasticsearch: Closed alarms were incorrectly not migrated to the dms-alarms index when the associated element had been migrated from another DMS \[ID_34020\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When, on a system with an Elasticsearch database, an alarm was closed, that alarm would incorrectly not get moved from the dms-Activealarms index to the dms-alarms index when the associated element had been migrated from another DMS.

#### Jobs app: Corrected start time would be saved incorrectly \[ID_34043]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When, after receiving a message that it was not possible to save a job because of an invalid start time, you had corrected the start time and tried to save the job again, that start time would get saved incorrectly.

#### DataMiner upgrade: AnalyticsDropUnusedCassandraTables upgrade action would fail \[ID_34091]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, in some cases, the *AnalyticsDropUnusedCassandraTables* upgrade action would fail.

#### SLAnalytics RTEs after upgrading DMS with Cassandra Cluster \[ID_34180]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 CU2 -->

After a DMS with a Cassandra Cluster setup was upgraded to 10.2.8 (CU1), it could occur that the Alarm Console showed run-time errors related to the SLAnalytics process. This was caused by an upgrade action that was not triggered for such a setup.
