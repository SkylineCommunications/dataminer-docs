---
uid: General_Main_Release_10.3.0_new_features_1
---

# General Main Release 10.3.0 – Other new features (part 1) - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

### DMS core functionality

#### New read-only service properties [ID_29978] [ID_33196] [ID_33363]

<!-- MR 10.3.0 - FR 10.2.6 -->

When a service is created or updated, the following read-only properties will now be filled in automatically:

| Property | Description |
|--|--|
| Created | DateTime (UTC) at which the service was initially created. |
| Created by | User name of the user who created the service. |
| Modified | DateTime (UTC) at which the service was last modified. |
| Modified by | User name of the user who last modified the service. |

> [!NOTE]
>
> - When you upgrade to DataMiner version 10.3.0, a check will be performed to make sure your system includes an up-to-date SRM solution. If the installed SRM solution is not up to date, you will be asked to update it before you continue with the DataMiner upgrade.
> - These properties will only be added to existing services the first time those services are updated.
> - These properties will not be available in alarms that are included in a service.

#### DataMiner Object Model: FieldDescriptors can now be configured to allow multiple values [ID_31905] [ID_32904]

<!-- RN 31905: MR 10.3.0 - FR 10.2.3
RN 32904: MR 10.3.0 - FR 10.2.5 -->

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

#### EPM: Aliases for topology cells, chains and search chains can now be specified on element level [ID_32028]

<!-- MR 10.3.0 - FR 10.2.2 -->

In an EPM environment, since DataMiner feature release version 10.1.7, it has been possible to override the names of topology cells, chains, and search chains specified in a protocol with aliases specified in a system-level *EPMConfig.xml* file stored in the C:\\Skyline DataMiner\\ folder. Now, it is also possible to add *EPMConfig.xml* files on element level.

If you want certain aliases for topology cells, chains and search chains to only be applied to a particular element, then create an *EPMConfig.xml* file and place it in the folder of that element (e.g. C:\\Skyline DataMiner\\Elements\\\<ElementName>\\).

> [!NOTE]
> Aliases specified in an element-level EPMConfig.xml file will override aliases specified in the system-level EPMConfig.xml file.

#### DataMiner Object Model: DomInstanceValueFieldDescriptor [ID_32326]

<!-- MR 10.3.0 - FR 10.2.3 -->

A new field descriptor is now available: DomInstanceValueFieldDescriptor

This field descriptor can be used to define a field that will contain the ID of a DomInstance. However, compared to the DomInstanceFieldDescriptor, this descriptor also references a specific value of that DomInstance.

The configuration of this new descriptor is identical to that of the DomInstanceFieldDescriptor, apart from a FieldDescriptorId property, which references a specific FieldValue.

#### New messages that support uploading larger files [ID_32398]

<!-- MR 10.3.0 - FR 10.2.4 -->

The SLNet process can now use the following new messages to upload files to the DataMiner System.

##### StartUploadMessage

This message initiates an upload and returns a *StartUploadResponse* message containing an upload cookie of type int.

| Argument | Type | Description |
|--|--|--|
| DataChunk | byte\[\] | The initial chunk of data to be uploaded. |
| ReservedSize | long | The total size (in bytes) that should be reserved for the full dataset. |
| Name | string   | Optional name of the upload. Naming an upload allows you to retrieve its upload status by means of a FindUploadSlotMessage. |

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

#### DataMiner Object Model: New event message for DomInstance status transitions [ID_32418]

<!-- MR 10.3.0 - FR 10.2.5 -->

With the introduction of the DomInstanceStatusChangedEventMessage, it is now possible to subscribe to DomInstance status transitions. This message contains the DomInstanceId, the FromState, the ToState and the Username (i.e. the name of the user who changed the status).

IModuleEvents are now filtered by IModuleEventSubscriptionFilter first, before any other filter is applied.

#### Service templates: Referencing table parameter cells by means of the primary key [ID_32549]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring a service template, you can use placeholders to reference a parameter value. When referencing a column, up to now, it was only possible to identify a cell by means of the display key. From now on, it is also possible to identify a cell by means of the primary key. See the following example:

```txt
[element:1:param:1002:^pk^myPrimaryKey]
```

#### New property added to PaToken class: Dictionary\<string,DomInstanceId> UserDomInstances [ID_32599]

<!-- MR 10.3.0 - FR 10.2.4 -->

The PaToken class has a new property: Dictionary\<string,DomInstanceId> UserDomInstances.

This is intended to be used in the Process Automation framework.

#### Process Automation: New ProcessAutomationResourcePool object [ID_32657]

<!-- MR 10.3.0 - FR 10.2.4 -->

A new Process Automation object class has been created (which inherits the regular ResourcePool class): *ProcessAutomationResourcePool*

This new object has a property that will be used to store the queue element associated with a resource pool: *public ElementId QueueElement*

#### Service & Resource Management: Service templates now also accept ServiceID and ReservationID as input data [ID_32668]

<!-- MR 10.3.0 - FR 10.2.4 -->

In Service & Resource Management environments, a service template used to generate a service associated with a booking will now also accept a ServiceID and a ReservationID as input data.

#### Running memory-intensive elements in separate SLProtocol and SLScripting instances [ID_32742] [ID_32917]

<!-- MR 10.3.0 - FR 10.2.5 -->

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

#### SetAlarmStateMessage can no longer be used to change the alarm state of an incident [ID_33273]

<!-- MR 10.3.0 - FR 10.2.6 -->

From now on, it will no longer be possible to change the alarm state of an incident by means of a SetAlarmStateMessage. If you attempt to do so, an exception will be thrown.

#### DataMiner Object Model: Defining a script execution action that will execute an interactive Automation script [ID_33513]

<!-- MR 10.3.0 - FR 10.2.8 -->

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

#### Clearing an incident now clears any clearable base alarms it contains [ID_34112]

<!-- MR 10.3.0 - FR 10.2.10 -->

If an incident (also known as an alarm group) is cleared manually, any clearable base alarms of that incident will now also be cleared. This way, this behavior is consistent with the standard behavior for Correlation alarms.

### DMS Security

#### Azure Active Directory: Secret expiry notices/errors [ID_33916]

<!-- MR 10.3.0 - FR 10.2.9 -->

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

#### Elasticsearch: Defining a logger table of type DirectConnection with a primary key [ID_32375]

<!-- MR 10.3.0 - FR 10.2.3 -->

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

#### NT_UPDATE_DESCRIPTION_XML (127) now supports overriding parameter units [ID_32891]

<!-- MR 10.3.0 - FR 10.2.5 -->

Using NT_UPDATE_DESCRIPTION_XML (127), it is now possible to override parameter units.

#### New \<ProcessAutomation> element to pass parameter values to the Service Definition component of the Dashboards app [ID_32910]

<!-- MR 10.3.0 - FR 10.2.5 -->

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

<!-- MR 10.3.0 - FR 10.2.9 -->

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

#### Making all elements using a particular protocol.xml run in separate SLScripting and SLProtocol instances [ID_33358]

<!-- MR 10.3.0 - FR 10.2.7 -->

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

#### QActions are now IDisposable and the SLProtocol object remains available outside of the run scope [ID_33965]

<!-- MR 10.3.0 - FR 10.2.9 -->

The SLProtocol(Ext) object in QActions will now retain all of its data members outside of the run scope. This means that, while Notifies were already available out of scope earlier, members such as the QActionID will now also remain available when a QAction run ends. In addition, the SLNet connection can now be set up at any time.

If the QAction class is not static and implements the IDisposable interface, the Dispose() function will be called when the QAction instance is released (i.e. when the element is stopped). The same goes for any other class the entrypoint may be in. This coincides with the IsActive property of the SLProtocol object being set to false, which prevents further function calls to the object from being executed.

The Dispose is called by a separate thread than the one stopping the element. Its purpose is to release lingering resources and connections when the element is stopped.

In addition, up to now only one instance was retained per QAction, so when entrypoints pointed to different classes, the instances were not kept. Now these separate instances will also be stored correctly.

### DMS Automation

#### Engine object: TriggeredByName property added [ID_33122]

<!-- MR 10.3.0 - FR 10.2.6 -->

A TriggeredByName property has been added to the Engine object. This property of type string will contain the full name of the user who started the Automation script (e.g. “John Doe”).

When an Automation script is triggered by the scheduler, a correlation rule or a redundancy group, the TriggeredByName property will contain one of the following strings:

- “Scheduled task \<name task>”
- “Correlation-rule \<name rule>”
- “Redundancy”

#### New subscript option 'ExtendedErrorInfo' [ID_33306]

<!-- MR 10.3.0 - FR 10.2.7 -->

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

#### Added the option to skip the 'script started' information event [ID_33666]

<!-- MR 10.3.0 - FR 10.2.8 -->

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

#### EPM: Relation contextuality taken into account for user selections [ID_34083]

<!-- MR 10.3.0 - FR 10.2.9 -->

When multiple selections are made in the EPM topology tree, the possible many-to-many relations between the fields are now taken into account to load further possible selections for other fields. Previously, only the last selected field was taken into account.

For example, if a topology contains a CCAP Core field and a Node Leaf field lower in the topology, and a value is selected for both, previously only the Node Leaf selection was taken into account for the possible selections in the RPD field further down in the topology, whereas now the CCAP Core selection will also be taken into account if the RPD field is related to both fields.

### DMS Web Services

See [General Main Release 10.3.0 – Highlights](xref:General_Main_Release_10.3.0_highlights#dms-web-services)
