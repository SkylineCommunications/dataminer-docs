---
uid: General_Feature_Release_10.0.5
---

# General Feature Release 10.0.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Support for icons in SVG format \[ID_24841\]

In function protocols and the *C:\\Skyline DataMiner\\Icons\\CustomIcons.xml* file, icons can now also be defined in SVG format.

Also, the default function icon has been updated.

#### SLAnalytics: Trend data prediction now also available for direct view table parameters \[ID_25013\]

Trend data prediction is now also available for direct view table parameters.

### DMS Security

#### Jobs and ReservationInstances now have a SecurityViewID property to control access to them \[ID_24800\]

Jobs and ReservationInstances now have a SecurityViewID property.

If, for a particular job or ReservationInstance, this property contains a view ID, then the job or ReservationInstance will only be accessible to users who have access to the specified view.

- Users who display a list of jobs or ReservationInstances will only see the jobs or ReservationInstances associated with a view to which they have Read access.

- Users who try to create, update or delete a job or a ReservationInstance will only be able to do so if they have Write access to the view associated with that job or ReservationInstance.

> [!NOTE]
>
> - In case of ReservationInstances, it will still be possible to put other ReservationInstances (by updating a ReservationInstance, Resource or ProfileInstance) into quarantine to which you do not have access.
> - When performing scheduling checks, the ReservationInstances to which a user does not have access will still be taken into account.
> - All ReservationInstances in a particular tree must have the same SecurityViewID.
> - If a view specified in the SecurityViewID property of a job or ReservationInstance is deleted, then only Administrators or users with access to all views will have access to that job or ReservationInstance.

### DMS Protocols

#### Authentication via a client certificate when polling an HTTPS server \[ID_25243\]

When configuring an HTTPS session in a DataMiner protocol, you can now specify that authentication should be performed using a client certificate. To do so, in the \<Session> tag, set the loginMethod attribute to “certificate”.

```xml
<Session loginMethod="certificate">
  ...
</Session>
```

If, for a particular session, loginMethod is set to “certificate”, DataMiner will look for the Skyline DataMiner certificate in the Windows personal certificate store of the local machine and will use that certificate to authenticate all requests within that session.

> [!NOTE]
> As some web servers accept certificates even when they do not require them, DataMiner will not send a client certificate by default. It will send an empty certificate list instead. This will prevent any ERROR_WINHTTP-\_CLIENT_AUTH_CERT_NEEDED errors from being thrown.

### DMS Cube

#### Service & Resource Management: Clearer warning messages will now appear when trying to delete resources linked to bookings or elements linked to resources \[ID_24435\]\[ID_25085\]

From now on, clearer warning messages will appear when you try to delete

- a resource linked to a booking, or
- an element linked to one or more resources.

#### Alarm Console now fully compliant with the new Cube X style \[ID_24859\]

The Alarm Console has been redesigned and is now fully compliant with the new Cube X style.

#### Alarm templates: Conditional monitoring based on a cell value from either the same table or another table \[ID_24867\]\[ID_24933\]

In an alarm template, it is now possible to configure a condition on a column parameter based on the value of a cell in either the same table or a different table.

> [!NOTE]
> This feature does not support view tables.

You can define the following:

- A condition on a column parameter receiving its data from an unrelated table.

  In this case, the primary keys of both tables will be matched, and the condition will apply when, in the column used in the condition, the row with the same key is changed.

- A condition on a specific cell of a column parameter.

  - If the two tables are unrelated, the condition will apply to all cells in the monitored column, but only when the cell specified in the condition has changed.

    When any other cell in the same column as the cell specified in the condition changes, it will not have any impact on the monitoring.

  - If the two tables are related, the condition will apply to all cells in the monitored column linked to the row containing the cell specified in the condition.

    All other cells in the monitored column will not be impacted by the condition as they are not linked to the cell specified in the condition.

> [!NOTE]
> When the cell specified in the condition is located in a column of the same table, the behavior will be identical to that of unrelated tables. In other words, the entire monitored column will be impacted.

##### New rule attributes: keyType and keyValue

This new feature relies on two new rule attributes: *keyType* and *keyValue*.

- The *keyType* attribute can have two values: “PK” (primary key) or “DK” (display key).
- The *keyValue* attribute has to contain the value that will be used in the condition.

In the example below, parameter 203 is a column of table 200, and the cell in column 203 that matches the corresponding key will be used in the condition.

```xml
<Condition id="5" name="Condition3">
  <Rule pid="203" comparer="eq" value="4" next="or" keyType="DK"      keyValue="DisplayKey3"/>
  <Rule pid="203" comparer="eq" value="3" keyType="PK"      keyValue="2"/>
</Condition>
```

> [!NOTE]
> Inside a rule, both the *keyType* and *keyValue* have to be filled in for this feature to work.
>
> The *keyValue* attribute will always refer to the key (primary key or display key) of the table containing the column parameter used in the condition, not the key in the column parameter being monitored.

#### Alarm Console: Severity duration column in history alarm tabs \[ID_24942\]

Next to active alarm tab pages, history tab pages now also allow you to display a severity duration column.

On history tab pages, a severity duration column will be available either when no filter is applied or when a filter based on Element ID, DMA ID, Element Type, Parameter ID, Protocol and/or Source ID is applied.

DataMiner Cube will calculate severity durations based on the alarms listed on the history tab page in question. If the duration of an alarm cannot be calculated (e.g. because the next alarm is not listed on the history tab page, or because the alarm has not been cleared while the element is stopped), the severity duration column will show “N/A”.

Additionally, a number of enhancements have been made with respect to severity durations. For instance, it is now also possible to display the severity duration when history tracking is disabled.

#### Visual Overview: Shapes linked to views can now have an 'AlarmLevel' shape data field \[ID_24952\]

To a shape linked to a view, you can now add a shape data field of type “AlarmLevel” to configure which of the view’s alarm levels you want the shape’s background color to display.

| Shape data field | Value |
|--|--|
| AlarmLevel | Instance/BubbleUp/Summary<br> - Instance: Alarm level of the monitored aggregation rules on the view.<br> - BubbleUp: Highest alarm level of any child element or child view.<br> - Summary: Highest of the Instance and BubbleUp alarm levels. |

#### Visual Overview: Using subscription filters when subscribing to tree control tables \[ID_24995\]

From now on, multiple subscription filters can be configured in the *SubscriptionFilter* shape data field of a tree control. Each of the pipe-separated filters will be applied to the corresponding table specified in the *SetVar* shape data field.

In the following example, the first subscription filter (“value=101 == 1”) will be used when subscribing to the first table (with ID 100) and the second subscription filter (“value=201 == A”) will be used when subscribing to the second table (with ID 200).

| Shape data field   | Value                            |
|--------------------|----------------------------------|
| SetVar             | MyVar:\[this elementID\]:100:200 |
| SetVarOptions      | Control=TreeView                 |
| SubscriptionFilter | value=101 == 1\|value=201 == A   |

#### Exporting element data to CSV: Fields added to export file \[ID_25049\]\[ID_25239\]

When you export element data to a CSV file, from now on, the export file will include the following additional fields:

| Array index | Field name           | Description                                                                                            |
|-------------|----------------------|--------------------------------------------------------------------------------------------------------|
| \[49\]      | ReplicationMaxBuffer | *(for future use, currently empty)*                                     |
| \[50\]      | ReplicationMinBuffer | *(for future use, currently empty)*                                     |
| \[51\]      | ProtocolType         | Protocol type per port (can be a list of tab-separated values)                                     |
| \[52\]      | CredentialGUID       | Credential GUID per port (can be a list of tab-separated values)                                   |
| \[53\]      | TLS                  | SSL TLS setting per port (can be a list of tab-separated values)                                   |
| \[54\]      | AllowedIpAddresses   | Comma-separated list of allowed IP addresses per interface (can be a list of tab-separated values) |

#### Visual Overview - ListView: Enhanced filter capabilities \[ID_25114\]

##### View filters

When specifying view filters using the view name instead of the view ID, an alternative syntax can now be used: *ViewName=\<name>*

Also, you can now use the "==" operator instead of the "=" operator. If the *ViewName* syntax is used, DataMiner will first try to filter by name, and then by ID in case the name cannot be found. If the *View* syntax is used, DataMiner will first try to filter by ID ,and then by name if the ID cannot be found. The filter can contain only one *View* or *ViewName* part.

##### Element/service filters

From now on, if you set the *Source* shape data field to “Elements” or “Services”, additional possibilities are available to add an element or service filter in the *Filter* shape data field:

- The following operators are supported: “*==*” (equals), “*!=*” (does not equal), “*contains*”, “*notContains*”, “*startswith*”, “*notStartswith*”, “*endsWith*", “*notEndsWith*", "*\<*" (smaller than, only usable with numbers) and "*\>*" (greater than, only usable with numbers). The value that is being compared with should always be included in single quotes.

- The following terms can be used to filter on:

  | Filter term | Description |
  |-------------|-------------|
  | Element.ID | The ID of an element. |
  | Element.Name | The name of an element. |
  | Element.Description | The description of an element. |
  | Element.DataMiner | The name of the DMA on which an element is located. |
  | Element.AlarmLevel | The technical alarm level of the element. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
  | Element.AlarmState | The alarm state of the element. For the difference with the alarm level, see "Element.AlarmLevel". |
  | Element.AlarmCount | The number of alarms of the element. |
  | Element.Type | The type of element as defined in the protocol. |
  | Element.DisplayType | The display type of the element as defined in the protocol, e.g. *spectrum analyzer*, *element manager*. |
  | Element.IP | The IP of the element. |
  | Element.State | The current state of the element, e.g. Paused, Stopped. |
  | Element.Protocol | The protocol used by the element. |
  | Element.ProtocolVersion | The protocol version used by the element. |
  | Element.ProtocolType | The protocol type used by the element. |
  | Element.AlarmTemplate | The alarm template used by the element. |
  | Element.TrendTemplate | The trend template used by the element. |
  | Element.Property.*PropertyName* | The property of the element with the specified property name. |
  | Service.ID | The ID of a service. |
  | Service.Name | The name of a service. |
  | Service.Description | The description of a service. |
  | Service.DataMiner | The name of the DMA on which a service is located. |
  | Service.AlarmLevel | The technical alarm level of the service. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
  | Service.AlarmState | The alarm state of the service. For the difference with the alarm level, see "Service.AlarmLevel". |
  | Service.AlarmCount | The number of alarms of the service. |
  | Service.Property.*PropertyName* | The property of the service with the specified property name. |

- You can combine different search terms with each other and with one view filter, using pipe characters ("\|"). The pipe character is used as an AND operator.

- Session variables can also be used in these filters.

- Examples:

  - To filter on all elements of which the name contains the word "function" and the element property IDP is set to "Source":

    ```txt
    Element.Name contains 'function'|Element.Property.IDP == 'Source'
    ```

  - To filter on all services of which the name contains the word "\_booking" and that are hosted by the DataMiner Agent "MyDMA":

    ```txt
    Service.DataMiner == 'MyDMA'|Service.Name contains '_booking'
    ```

  - To filter on all elements using the protocol "MyProtocol" with the protocol type "serial" which are not of element type "Relay":

    ```txt
    Element.Protocol == 'MyProtocol'|Element.ProtocolType == 'serial'|Element.Type notContains 'Relay'
    ```

  - To filter on all element using the property IDP with a property value equal to that of the session variable "MySelectedValue":

    ```txt
    Element.Property.IDP == [var:MySelectedValue]
    ```

> [!NOTE]
> The filters are not case-sensitive. For example, a service with the name "MyName" will be found when the filter *Service.Name == 'myname'* is used

### DMS Reports & Dashboards

#### Dashboards app: Service definition visualization and data feed \[ID_25056\]\[ID_25151\]\[ID_25169\] \[ID_25178\]

The *Node edge graph* visualization is no longer available in the Dashboards app. Instead, a *Service definition* visualization is now available, which is very similar to the node edge graph visualization, but specifically adjusted to display service definitions only.

A new service definition data feed is now also available. The *Service definition* component can be configured with a booking data feed or with this new service definition data feed. In the dashboard URL, the service definition data feed can be specified using the argument “service definitions”, by specifying the service definition ID(s), for example: *service definitions=serviceDefinitionID1%2FserviceDefinitionID2*

In case a feed component is used to provide a booking feed to the *Service definition* component, it is possible to use a service definition filter feed on this feed component, so that a booking is only included in the feed if it is based on one the service definitions in the filter.

When the *Service definition* component displays nodes that are linked to particular resources, alarm and element info will now be displayed for these nodes in the graph. The alarm state will be displayed with a colored border at the top of the node, and in the node icon in case the default icon is shown. In addition, a link icon in the node will open the corresponding element card in the Monitoring app when clicked.

In the settings for the *Service definition* component, one or more actions can be defined. For each action, an Automation script and an icon need to be defined, and you need to specify to which node or nodes the action must be added. The icon will then be displayed on the specified node or nodes. When the icon is clicked, the script is launched. The booking ID or service definition ID used in the component and the node ID of the node for which the icon was clicked will be passed to the script as parameter ID 1 and parameter ID 2, respectively. The order of the specified actions can be modified in the *Settings* pane. In case there are too many actions on a node to display them all, clicking the action bar at the bottom of the node will expand the bar to display all the actions.

#### BREAKING CHANGE - Dashboards app: CPE feed component now uses element data feed \[ID_25216\]

To configure the data input of the *CPE feed* component in the Dashboards app, you now have to use a regular element data feed instead of specifying the element in the component settings. This change makes it possible to provide the data input of the *CPE feed* component dynamically using another feed component.

#### Legacy Reporter app: Alarm list component now also returns alarms of enhanced service elements \[ID_25232\]

In the legacy Reporter app, the alarm list component will now also return alarms of enhanced service elements.

### DMS Automation

#### New methods to allows QActions to execute Automation scripts \[ID_24475\]

Two new SLProtocol methods now allow QActions to execute Automation scripts:

- ExecuteScript(string scriptName)
- ExecuteScript(ExecuteScriptMessage message)

Also, the Engine object has a new UserCookie property.

##### ExecuteScript(string scriptName)

This method will execute an Automation script of which the name is passed in the “scriptName” argument.

The script will be executed by the user who is performing the QAction. It will return an “ExecuteScriptResponseMessage”, containing information about the execution of the script.

If you execute a script using this method, it will be executed with all script execution settings set to the default values. If more control is needed, then use the *ExecuteScript(ExecuteScriptMessage message)* method described below.

Example:

```csharp
public static void Run(SLProtocol protocol)
{
    protocol.ExecuteScript("MyScriptName");
}
```

##### ExecuteScript(ExecuteScriptMessage message)

This method will execute an Automation script of which all details and execution settings are passed in the “ExecuteScriptMessage”.

The script will be executed by the user who is performing the QAction. It will return an “ExecuteScriptResponseMessage”, containing information about the execution of the script.

Using this method to execute an Automation script is particularly useful when the script in question needs a dummy or protocol information to run.

Code Example:

```csharp
ExecuteScriptMessage esm = new ExecuteScriptMessage("RT_AUTOMATION_ExecuteAutomationByProtocol_AutomationScriptCode")
{
    Options = new SA(new[]
    {
        "OPTIONS:0",
        "CHECKSETS:TRUE",
        "EXTENDED_ERROR_INFO",
        "DEFER:FALSE"
    })
};
protocol.ExecuteScript(esm);
```

When you execute an Automation script using the “DEFER:FALSE” option, be aware that this will lock any further processing of the protocol. If, for example, the Automation script that is being executed by a QAction sets a parameter of the element containing that same QAction, the parameter will be locked until the Automation script times out. This default behavior can be bypassed in two ways:

- In the protocol, add the “queued” option to the QAction tag, or

- Use “DEFER:TRUE” instead of “DEFER:FALSE”.

    | If you use...   | then...                                                                                                                              |
    |-----------------|--------------------------------------------------------------------------------------------------------------------------------------|
    | DEFER:FALSE     | the QAction will halt while the Automation script is being executed, and will only continue once the Automation script has finished. |
    | DEFER:TRUE      | the QAction will continue while the Automation script is being executed asynchronously.                                              |

##### New property on Engine object: UserCookie

```csharp
string Engine.UserCookie;
```

#### New method to link ReservationInstances to a ticket \[ID_25154\]

In a C# block of an Automation script, you can now link ReservationInstances to a ticket.

See the following example:

```csharp
// Create a ReservationInstanceID object
var reservationInstanceId = new ReservationInstanceID(reservationInstance.ID);
// Create a TicketLink using the static 'Create' method
var ticketLink = TicketLink.Create(reservationInstanceId);
// Add the TicketLink to the ticket
ticket.AddTicketLink("KeyForThisLink", ticketLink);
```

Note that you can use lists of TicketLink objects to retrieve a filtered list of tickets. See the following example:

```csharp
// TicketLink filters are lists of TicketLink objects
var ticketLinkFilter = new[] {ticketLink};
// Use a list of TicketList objects to retrieve tickets by means of the 'GetTickets' method
var tickets = ticketingGatewayHelper.GetTickets(ticketLinkFilter);
```

#### Interactive Automation scripts: Properties added to UIBlockDefinition class \[ID_25183\]\[ID_25253\]

The following properties have been added to the UIBlockDefinition class:

| Property | Description |
|--|--|
| IsRequired | Indicates whether the input control requires a value.<br> Possible value:<br> - true<br> - false<br> If “true”, the control will be marked “Invalid” when empty. |
| PlaceholderText | Text that will be displayed as long as the control is empty (e.g. “In this box, enter...”). |
| ValidationState | Indicates whether the value was validated and whether that value is valid.<br> Possible values:<br> - NotValidated<br> - Valid<br> - Invalid<br> Note: This property can be used to indicate to users that they entered an invalid value. |
| ValidationText | Text that will be displayed when ValidationState is “Invalid”. |

##### Using the ValidationState and ValidationText properties

The ValidationState and ValidationText properties should be used in combination with the WantsOnChange property.

If WantsOnChange is true, the interactive Automation script will have its Engine#ShowUI(...) method return each time the user input changes. This will also be indicated by the \_ONCHANGE key, which is returned in the UIResults.

This functionality will allow you to offer clear feedback on user input.

##### Which input controls support which properties?

|              | IsRequired | Placeholder | ValidationText |
|--------------|------------|-------------|----------------|
| TextBox      | X          | X           | X              |
| PasswordBox  | X          | X           | X              |
| DropDown     | X          | X           | X              |
| Numeric      | X          | X           | X              |
| Calendar     | X          |             | X              |
| FileSelector |            |             | X              |

#### UnSetFlag method now also added to IEngine interface \[ID_25188\]

Since DataMiner 10.0.0/10.0.1, you can use the engine.UnSetFlag method to clear the AllowUndef, NoInformationEvents and NoKeyCaching run-time flags in an Automation script.

This method has now also been added to the IEngine interface.

### DMS Mobile apps

#### Jobs app: New methods to manage job attachments \[ID_24791\]

The *JobManagerHelper* has been expanded with new methods that can be used to manage attachments to jobs:

- *AddJobAttachment(JobID **jobID**, string **fileName**,byte\[\] **fileBytes**)*: Adds an attachment to the specified job.
- *GetJobAttachmentFileNames(JobID **jobID**)*: Retrieves the names of the attachments of the specified job.
- *DeleteJobAttachment(JobID **jobID**, string **attachmentName**)*: Deletes the attachment with the specified name from the specified job.
- *GetJobAttachment(JobID **jobID**, string **attachmentName**)*: Retrieves the content of the specified attachment of the specified job as an array of bytes.

Please note the following regarding job attachments:

- The size limit of job attachments depends on the *Documents.MaxSize* setting in the file *MaintenanceSettings.xml*. By default, this is 20 MB.
- Deleting a job will remove all attachments of this job from the system. These cannot be recovered afterwards.
- Managing job attachments requires the *Jobs* > *UI available* and *Jobs* > *Add/Edit user permissions*.
- Job attachments are backed up with the backup option *All documented located on this DMA*.
- Job attachments are synced in a cluster.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Monitoring app: 'Information', 'Traces' and 'Presets' tabs added to spectrum page of Spectrum Analyzer elements \[ID_25028\]\[ID_25059\]

The following tabs were added to the spectrum page of Spectrum Analyzer elements:

| Tab | Content |
|--|--|
| Information | Shows basic information regarding measurement points, markers, thresholds and parameters. |
| Traces | Allows you to display or hide the current trace, the minimum trace, the maximum trace and the average trace. |
| Presets | Lists the available presets. By default, only the private presets are listed (i.e. the presets that are only available to the current user). To also have the shared presets listed, select the *Show shared presets* option. Those will be indicated with a *Shared* tag. When you select a preset, below the list, a *Load preset* button will allow you to load the selected preset. |

#### Monitoring app: Card header, sidebar and menu available on mobile devices \[ID_25156\]

When you open a card on a mobile device, you will now see a card header instead of the app header, and you will be able to open a card sidebar just like on a desktop device.

Also, the card menu is now accessible through a hamburger button in the top-right corner.

#### Ticketing app: Selection box values can now be assigned a color \[ID_25175\]

The VisualizationHints on the TicketFieldResolver can now store colors for every value listed in a selection box.

These colors can be specified by using the following property:

- TicketFieldResolver#VisualizationHints#VisualFieldEnums (of type List\<VisualFieldEnum>)

For every color linked to a selection box value, a VisualFieldEnum object should be added with the following properties:

| Property  | Description                                                          |
|-----------|----------------------------------------------------------------------|
| FieldName | The name of the selection box (i.e. enum field).                     |
| EnumValue | The selection box value (i.e. the discreet value in the enum field). |
| Color     | The color associated with the selection box value.                   |

#### On mobile devices, the sidebar will now appear at the bottom of the screen \[ID_25225\]

When using a mobile app (Monitoring, Dashboards, Jobs, etc.) on a mobile device, the sidebar, which on a desktop device appears by default on the left-hand side of the screen, will now appear at the bottom of the screen.

#### User picture in top-right corner \[ID_25257\]

The mobile apps (Monitoring, Dashboards, Jobs, etc.) will now show a picture of the user in the top-right corner. If no picture is available, then the user’s initials will be shown instead.

#### Monitoring app: On mobile devices, a redesigned footer will now group all card controls \[ID_25267\]

When using the Monitoring app on a mobile device, all card controls will now be grouped on a redesigned footer.

### DMS Service & Resource Management

#### Mediation snippets \[ID_24610\]

Mediation snippets are pieces of code that will convert a parameter value from the format defined in a protocol to the format defined in a profile parameter (and vice versa).

MediationSnippet objects, defined on profile parameter level, consist of an ID and a string containing the actual snippet code (C#). They can be managed by means of the ProfileManagerHelper#MediationSnippets API.

To a particular profile parameter, you can add only one mediation snippet per protocol version. In other words, linking to both parameter 10 and parameter 20 in version 1.0.0.0 of Protocol X in the same profile parameter is not allowed. However, it is possible to specify a single wildcard character at the end of a protocol version (e.g. “1.0.0.\*”). When there are multiple matches, the most specific entry will be chosen (i.e. “1.0.0.\*” will take precedence over “1.\*”).

> [!NOTE]
>
> - Inside a snippet, it is possible to
>   - mediate multiple device parameters to a single profile parameter, and
>   - mediate a single profile parameter to multiple device parameters.
> - When a mediation snippet is updated or deleted, all DataMiner Agents in the DMS will unload that snippet. In case of a snippet update, the next mediation request will trigger a re-load of the updated version.
> - When an attempt is made to delete a mediation snippet used by a profile parameter, a MediationSnippetError will be thrown (with reason ExistingProfileParameters).
> - When a profile parameter is deleted, all the mediation snippets linked to that profile parameter will also be deleted.
> - When a profile parameter is updated, all the mediation snippets that got unlinked due to that update will be deleted.

To use a mediation snippet, you can send one of the following requests:

- MediateDeviceToProfileRequest (with response MediateDeviceToProfileResponse)

- MediateProfileToDeviceRequest (with response MediateProfileToDeviceResponse)

Both requests require the profile parameter ID, the element ID and the parameter value to be passed along, and will return either the mediated value(s) or a MediationError (which will also be logged in SLProfileManager.txt).

> [!NOTE]
>
> - Using mediation snippets requires a ServiceManager license and requires Indexing Engine to be installed.
> - In Indexing Engine, all mediation snippets are stored under the “cmediationsnippet” index. The compiled snippets are stored in C:\\Skyline DataMiner\\MediationSnippets\\Compiled.
>   - All DLL files are deleted from this folder when the DataMiner Agent starts up.
>   - Snippets are compiled per DataMiner Agent. Snippet DLLs are not synchronized among the agents in a DMS.
> - If you want the mediation snippets to be included in DataMiner backups, make sure to select the “Include the ProfileManager in backup” option.

#### Support for capabilities of type string and for time-dynamic capabilities \[ID_25217\]

Service & Resource Management now supports

- capabilities of type string, and
- time-dependent capabilities.

##### Capabilities of type string

It is now possible to define capabilities of type string:

- The CapabilityParameterValue class has a new property named “ProvidedString”. This can be used to define a string capability on a resource.

- The ResourceCapabilityUsage class has a new property named “RequiredString”. This can be used to define a string capability on a ReservationInstance.

- The CapabilityUsageParameterValue class has a new property named “RequiredString”. This can be used to define default capability values of type string for profile parameters and capability values of type string on profile instance parameters.

> [!NOTE]
> From now on, three types of capabilities can be defined: discreet, rangepoint and string. Up to now, when the value provided/required was a number, a rangepoint capability was used, and if it was not a number, a discreet capability was used. String capabilities will now be used when the value provided/required for a rangepoint capability is not a number and the value provided/required for a discreet capability is NULL or an empty string.

##### Time-dynamic capabilities

Time-dynamic capabilities are capabilities of which the value can differ over time, depending on the reservations that are using the capability. Currently, only capabilities of type string can be turned into time-dynamic capabilities (by setting their “IsTimeDynamic” property to true).

As a time-dynamic capability will be treated as a string capability that can have any value, the CapabilityParameterValue property “ProvidedString” will be disregarded.

When a time-dynamic capability is booked by a ReservationInstance that requires a specific value, the Resource capability will keep that value for the entire duration of the ReservationInstance. This means that overlapping ReservationInstances will be able to use the same time-dynamic capability on the same resource, as long as they require the same string capability.

> [!NOTE]
>
> - It is not possible to schedule multiple overlapping ReservationInstances using the same time-dynamic capability on the same resource with a different required string. This would cause quarantine conflicts. When you try to save a ReservationInstance that conflicts with existing ReservationInstances, the software will resolve the conflict by comparing the quarantine priority of all existing ReservationInstances to the one of the ReservationInstance you are trying to save. If the quarantine priority of the ReservationInstance you are trying to save is higher than that of all existing ones, then all existing ones will go into quarantine. Otherwise, the new ReservationInstance will go into quarantine.
> - Whether a capability is time-dynamic is defined on resource level.

##### New ResourceManagerHelper methods

In the context of time-dynamic capabilities, two new methods have been added to the ResourceManagerHelper:

- GetEligibleResourcesWithUsageInfo
- GetEligibleResourcesForServiceNodeWithUsageInfo

These methods correspond with GetEligibleResources and GetEligibleResourcesForService-Node, but the return value of the new methods contains information about the currently booked usage of each eligible Resource, along with all eligible Resources.

This usage info currently only contains information about the already booked capabilities for each resource. For each capability requested in the call, the usage info will contain a “CapabilityUsageDetails” property, which contains a “HasExistingBookings” property indicating whether the capability of that resource is:

- Not time-dynamic (which means the resource has the requested capability regardless of the time range the booking is in).

    In this case, “HasExistingBookings” will be NULL.

- Time-dynamic (without a booking in the requested time range).

    In this case, “HasExistingBookings” will be false.

- Time-dynamic (with a booking in the requested time range).

    In this case, “HasExistingBookings” will be true.

> [!NOTE]
> The GetEligibleResources and GetEligibleResourcesForServiceNode methods will continue to work correctly, but they will only return the eligible Resources without the extra information.

#### Service & Resource Management: New EmptyResourceInReservation property for ReservationInstance/ServiceReservationInstance \[ID_25220\]

In Service & Resource Management scripts, you can now configure nodes on a ReservationInstance while the resource is not known yet, by using the new *EmptyResourceInReservation* property.

### DMS Spectrum Analysis

#### DataMiner Cube - Spectrum Analysis: Button to apply all settings at once \[ID_25242\]

On a spectrum analyzer element card, an "Apply all" button is now available in the settings pane, so that you can configure several settings and then apply them all at the same time.

#### DataMiner Cube - Spectrum Analysis: Y axis of spectrum graph will no longer show values with 3 decimals if the reference level is shown in dBm and no decimal accuracy is being used \[ID_25250\]

If the reference level is shown in dBm and no decimal accuracy is being used, from now on, the Y axis of a spectrum graph will no longer show values with 3 decimals.

### DMS tools

#### SLLogCollector: New tool to collect log files and memory dumps and send them to Skyline support \[ID_25346\]

From now on, the SLLogCollector tool will be available on all DataMiner Agents.

In case of problems, Skyline support may ask you to use this tool to compress the necessary log files and memory dumps into a zip file, which you can then store in a folder on the DataMiner Agent or upload to Skyline.

On the DataMiner Agent, the tool itself can be found at the following location:

- C:\\Skyline DataMiner\\Tools\\SLLogCollector\\SL_LogCollector.exe

## Changes

### Enhancements

#### SLNet setting 'FlushQueudMessagesInterval' no longer has a minimum value \[ID_24205\]

The “FlushQueuedMessagesInterval” setting controls the interval at which pending messages are flushed to clients through the callback connection. The larger this interval, the less calls will be made, but the longer the delay will be between events being generated and clients receiving them. This setting is a global setting that can be configured per DataMiner Agent, and applies to any client connecting to SLNet.

The default value is 100ms, and up to now the minimum value was 50ms. From now on, this setting no longer has a minimum value. When the interval is set to zero, there will only be a 15ms delay when an iteration did not yield any new callback launches.

#### SLSNMPManager: Enhanced error handling \[ID_24579\]

Due to a number of enhancements, overall error handling has been improved in the SLSNMPManager process.

#### DataMiner Cube - Spectrum analysis: Preset will now also contain the measurement point for which the trace was measured \[ID_24729\]\[ID_24953\]\[ID_25100\]

From now on, when you save a preset, it will not only include a “measurement points" field containing all measurement points you selected, but also a “saved on measurement point” field containing the ID of the measurement point for which the trace was measured.

This will enable spectrum monitors to determine the correct set of frequencies in case the monitor runs a script that loads a preset based on a selected measurement point.

#### Ticketing: Additional logging explaining why it was not possible to delete a ticket field resolver \[ID_24802\]

When it was not possible to delete a ticket field resolver, additional information will now be added to the SLTicketingGateway.txt log file, explaining why the deletion request was denied.

#### DataMiner Cube - Visual Overview: Minor enhancements made to Advanced Editing pane \[ID_24807\]

A number of minor enhancements have been made to the *Advanced Editing* pane:

- The Add shape data list will no longer show a duplicate *ChildrenFilter* entry.

- The message shown when adding a duplicate shape data or when configuring an invalid shape data name will now mention shape data instead of page data.

- Closing the *Advanced Editing* pane will now update the *Advanced Editing* button in the ribbon.

- The current selection will now be taken into account when starting the *Advanced Editing* extension.

#### DataMiner Cube - Correlation: Enhancements with regard to the use of placeholders in 'Send Email' actions of Correlation rules \[ID_24816\]

A number of minor enhancements have been made with regard to the use of placeholders in “Send Email” actions of correlation rules.

#### DataMiner Cube - Visual Overview: Enhanced performance of the Advanced Editing pane \[ID_24825\]

Due to a number of enhancements, overall performance of the *Advanced Editing* pane has increased, especially when editing pages that contain a large amount of shapes.

#### Monitoring app: Enhanced performance when retrieving alarm information \[ID_24831\]

Due to a number of enhancements, overall performance of the Monitoring app has increased when retrieving alarm information.

#### SLNet: Enhanced processing of messages sent asynchronously \[ID_24966\]

Due to a number of enhancements, overall performance of SLNet has increased when processing messages sent asynchronously.

#### DataMiner Cube - Data Display: Redesigned page buttons \[ID_24974\]

All page buttons have now been redesigned in order to match the new DataMiner X style.

#### Indexing Engine: Enhanced mechanism to delete data using filters \[ID_24977\]

A number of enhancements have been made to the mechanism used to delete data from the Indexing Engine, especially when using large filters.

#### Automation: SetPropertyValue method will now only return after having checked that the property was set correctly \[ID_25025\]\[ID_25195\]

From now on, the *SetPropertyValue* method will only return after having checked that the property was set correctly.

Up to now, when the value of an element property was updated using the *SetPropertyValue* method on an *Element* object and immediately retrieved using the *GetPropertyValue* method, in some cases, the value returned by that last method would incorrectly be the previous value.

> [!NOTE]
> The *SetPropertyValue* method will only perform the above-mentioned check when the “check sets” option is enabled.
>
> - Before launching a script in Cube, select the “After executing a SET command, check if the read parameter or property has been set to the new value” checkbox in the script execution window.
> - When launching a script using *ExecuteScriptMessage*, make sure to activate the CHECKSETS option (“CHECKSETS:TRUE”).
>
> With this option enabled, the *SetPropertyValue* method will take slightly longer to execute. When a large number of properties need to be updated which do not need to be retrieved immediately, you can disable this option in order to increase performance.

#### Mobile apps: Confirmation message when leaving page with interactive script or job configuration \[ID_25078\]

When a user leaves a DataMiner mobile app page while in an interactive Automation script or while configuring jobs, a confirmation message will now be displayed. However, note that this is message is not displayed when the mobile apps are used on iOS.

#### DataMiner Cube - Visual Overview: ListView component will not show a set of default columns when no columns are configured in its shape data \[ID_25098\]

When you add a *ListView* component to a Visio page, from now on, that component will display a set of default columns when its shape data does not contain a column configuration.

#### Reports & Dashboards: PDF library updated \[ID_25117\]

The third-party library used to generated PDFs in the legacy Reports & Dashboards app (Winnovative) has been updated to version 15.

#### SLTaskBarUtility: Default Agents to upgrade now set to 'cluster' \[ID_25118\]

Previously, "Agents to upgrade" was by default set to "localhost" in the SLTaskBarUtility upgrade window. In order to ensure that clusters are upgraded completely, now "cluster" is selected by default. However, not that in case the Agent is not running, localhost will still be selected.

#### Spectrum Analysis: Improved spectrum graph axis labels \[ID_25161\]

To make spectrum graphs more easily readable, the unit of measure will now no longer be displayed in every label of the X- and Y-axis of a spectrum graph. Instead, it will only be displayed once at the end of each axis.

#### Enhanced processing of large DELT export operations \[ID_25177\]

A number of enhancements have been made with respect to the DELT export process. This will prevent timeouts in the event the process gets interrupted while exporting large amounts of data.

#### Additional SLPort error logging \[ID_25200\]

Additional log information is now added to the SLPort logging to make it easier to troubleshoot issues in case DataMiner cannot process an incoming read event from a device because of an issue with the socket.

However, note that this logging will only be enabled for a particular element if the IP address for this element is added in PortLog.txt. For more information on how to add this, refer to the DataMiner Help.

#### DataMiner Cube - Visual Overview: ListView component enhancements \[ID_25224\]

In a *ListView* component in Visual Overview that has been configured to display elements, the following columns are now available:

- Protocol
- Protocol Version
- Polling IP
- Element properties \> Created by
- Element properties \> Created at (i.e. creation date)

In addition, it is now also possible to configure a filter on the *ListView* shape using the term "Element.PollingIP", for example *Element.PollingIP == '127.0.0.1'*.

#### DataMiner Cube - Trending: Behavioral anomaly detection will no longer generate nor clear suggestion events when its flood mode is activated \[ID_25244\]

From now on, behavioral anomaly detection will no longer generate nor clear suggestion events when its flood mode is activated.

#### DataMiner Cube: Enhanced behavior of 'Save all changes' and 'Discard all changes' commands in Profiles and Services apps \[ID_25259\]

In the Profiles and Services apps, a number of enhancements have been made with regard to the “Save all changes” and “Discard all changes” commands.

#### Failover: Prevent new elements from receiving the same ID as a deleted element or a disabled function \[ID_25306\]

From now on, when a DataMiner Agent in a Failover setup goes online, SLDataMiner will now retrieve the highest element ID from dataminer.xml. This will prevent new elements from receiving the same ID as an element that was deleted or a function that was disabled.

#### SLDataGateway: Enhanced retrieval of alarms from a MySQL database \[ID_25318\]

Due to a number of enhancements, the method used by the SLDataGateway process to retrieve alarms from a MySQL database has been optimized.

### Fixes

#### DataMiner Cube - Automation: Problem when turning a SET action into a GET action or vice versa \[ID_24498\]

When you added a SET action to an Automation script and then changed it to a GET action (or vice versa), in some cases, it would no longer be possible to configure the action.

#### DataMiner Cube - Visual Overview: Problem when loading a trend group in a trend component \[ID_24590\]

When you embed a trend component on a Visio page, you can have it load a trend group by setting the *Parameters* shape data field to “TrendGroup=\<username>/sharedusersettings:\<groupName>”. When this entry contained a dynamic part (e.g. \[var:xxx\]), in some cases, updates would not get processed correctly and the trend graph would be cleared.

#### Problem with SLSNMPAgent when retrieving the views \[ID_24663\]

In some cases, an error could occur in the SLSNMPAgent process when retrieving the views, especially when elements or services were present in the root view and the system contained a view with the same name as the root view.

#### Ticketing app: Problem when filtering on ticket fields of type GenericEnumEntry \[ID_24689\]

In some cases, it would no longer be possible to filter on ticket fields of type GenericEnumEntry.

#### SLAnalytics: Increased memory usage \[ID_24703\]\[ID_25601\]

Due to a code refactoring error, in some cases, the overall memory usage of the SLAnalytics process could increase by up to 40 percent.

#### DataMiner Cube - Visual Overview: Problem with path highlighting after a DCF connection update \[ID_24741\]

After a DCF connection update, in some cases, the highlighting of a manually drawn connector linked to that DCF connection would be incorrect. The highlight path would incorrectly end at the updated connector.

> [!NOTE]
> This problem only occurred when one or both of the interfaces connected to the connector were of type input/output.

#### Dashboards app: Problem when loading drop-down boxes of interactive Automation scripts \[ID_24888\]

When a dialog box of an interactive Automation script showed multiple drop-down boxes next to each other, in some cases, some of those boxes would become unresponsive when data was being loaded into them.

#### DataMiner Cube - Visual Overview: Views selection boxes on Edit Shape pane were empty when editing a Visio file in Cube \[ID_24900\]

When editing a Visio file in DataMiner Cube using “edit mode”, in some cases, selection boxes listing all views in the DataMiner System displayed on the Edit Shape pane on the right would incorrectly be empty.

#### Problem with SLSNMPManager when registering SNMPv3 elements with empty passwords \[ID_24944\]

In some cases, an error could occur in the SLSNMPManager process when registering SNMPv3 elements with empty passwords.

#### DIS inject would only store the first injected DLL file \[ID_24948\]

When debugging a QAction, in some cases, when DIS injected a DLL, it would no longer update the reference to that file. In other words, when you updated the QAction and re-injected the DLL, the previous version of that DLL would still be referenced.

#### Matrix crosspoint update would not be applied when connected to a DMA other than the one hosting the element \[ID_24950\]

When a matrix crosspoint was updated via a QAction using one of the following calls, in some cases, the update would not be applied when connected to a DataMiner Agent other than the one hosting the element:

- SendToDisplay(pid, x, y);
- SendToDisplay(pid, int\[\], int\[\]);

#### DataMiner Cube - Visual Overview: Line property configuration not taken into account when determining highlight style priorities \[ID_24955\]

When, in a DCF context, you configure highlight styles that are only applied if the path comes from a certain source and (optionally) goes to a certain destination, it is possible to give one style priority over another style. In some case, however, the line property configuration would not correctly be taken into account when determining those priorities.

#### DataMiner Cube - Services app: Problem when updating a service definition diagram \[ID_24959\]

When you updated a service definition diagram, in some cases, the diagram of another service definition would incorrectly be updated instead.

#### DataMiner Cube - Alarm Console: Cube could become unresponsive when the mechanism was triggered to automatically remove information events \[ID_24965\]

When, in the Alarm Console, the list of information events in the *Information events* tab exceeds 1100 items, the oldest 100 events are automatically removed.

When that automatic removal mechanism was triggered, in some rare cases, DataMiner Cube could become unresponsive.

#### Invalid values in SNMPv3 element configurations would cause DataMiner Agents to get disconnected from each other \[ID_24979\]

When SNMPv3 element configurations contained invalid values, in some cases, DataMiner Agents could get disconnected from each other.

#### Update of the SNMP protocol type or credential library of an advanced port would not get saved in the element.xml file \[ID_24983\]

When you updated an element, in some cases, an update of the SNMP protocol type or the credential library of an advanced port would not get saved in the element.xml file.

#### DataMiner Cube - Service & Resource Management: ListView component did not allow sorting on custom property columns \[ID_24984\]

In a ListView component, in some cases, it would not be possible to sort on custom property columns.

#### Indexing Engine: Problem when storing large string values \[ID_25007\]

When a string value larger than 32,000 bytes was written to an Indexing Engine, in some cases, that value would not be indexed and an exception would be thrown.

#### DataMiner Cube: List view column configuration issues \[ID_25009\]

When a custom property column was renamed in a list view component, either embedded in Visio or in the Services or Bookings app, it could occur that the custom name was not applied correctly.

In addition, if the list view column layout was customized via the context menu, it could occur that the column configuration window did not correctly reflect the customized layout.

#### Problem when retrieving CPE-related data from a Cassandra database \[ID_25019\]

In some cases, an exception could be thrown when retrieve CPE-related element data from a Cassandra database.

#### DataMiner Cube: Minor issues with the new DataMiner X UI layout \[ID_25026\]

A number of minor issues with the new DataMiner X UI layout have been fixed.

#### Memory leaks in SLDMS \[ID_25041\]

In some cases, the SLDMS process could leak memory.

#### DataMiner Cube: Problem with unstable DataMiner Agent connections when upgrading an entire DataMiner System \[ID_25043\]

When, in DataMiner Cube, you started an upgrade of the entire DataMiner System, in some cases, the Upgrade window could become unresponsive when one or more of the DataMiner Agents being upgraded had an unstable connection.

From now on, when you start an upgrade of an entire DataMiner System, agents with an unstable connection will no longer be included in the upgrade operation and a warning will be displayed.

#### Problem when sending table data from SLElement to SLDataGateway \[ID_25048\]

In some cases, an error could occur in SLElement when sending table data to SLDataGateway.

#### Dashboards app - CPE feed: Field values for columns other than the primary key would not be applied \[ID_25050\]

When using a CPE feed, in some cases, field values for columns other than the primary key would not be applied.

The URL argument “cpes” now has the following extended format:

```txt
?cpes=dmaID%2FeID%2FFieldPID%2FFieldValue%2FTableIndexPID%2FIndexValue
```

#### After an element restart, the view impact information of alarms retrieved from the database could be incorrect \[ID_25053\]

When, after restarting an element, the alarms associated with that element were retrieved from the database, in some cases, the view impact information in those alarms would be incorrect.

#### Interactive Automation scripts: Problem with checkbox updates \[ID_25054\]

In interactive Automation scripts, in some cases, checkbox components would not be updated correctly.

#### SLDMS run-time errors when connection with remote DMA could not be initialized \[ID_25068\]

When the connection with a remote DMA could not be initialized, run-time errors could occur in the SLDMS process.

#### Active alarms could be displayed incorrectly after restarting a DMA with a MySQL database \[ID_25071\]

When a DataMiner Agent with a MySQL database was restarted, in some cases, the active alarms could be displayed incorrectly after the restart.

#### Problem when retrieving alarms with rootkey equal to 0 from the database \[ID_25073\]

In some rare cases, an error could occur when retrieving alarms with a rootkey equal to 0 from the database. From now on, if the database contains alarms with a rootkey equal to 0, those alarms will be ignored and will not be retrieved.

Also, each time an alarm with rootkey equal to 0 is encountered, an entry will now be added to the SLDBConnection.txt log file.

#### Trending displayed incorrectly in case of multiple trend points in the same second \[ID_25097\]

If there were multiple trend points in the same second, it could occur that these were not sorted correctly, which could cause a trend graph to be displayed incorrectly.

#### DataMiner Cube: Problem when clicking several times in rapid succession or when a log folder was created on a clean client computer \[ID_25099\]

In DataMiner Cube, in some cases, an exception could be thrown when clicking several times in rapid succession or when the *C:\\ProgramData\\Skyline\\DataMiner\\DataMinerCube\\CubeLogging* folder was created on a clean client computer.

#### Monitoring app: Severity color indication not displayed in Alarm Console and on alarms pages \[ID_25106\]

In some cases, it could occur that the severity color indication was not displayed in the Alarm Console and on alarms pages in the Monitoring app.

#### HTML5 apps: Last item in drop-down lists was hidden by the collapse button \[ID_25108\]

In the HTML5 apps (Ticketing, Jobs, etc.), in some cases, the collapse button at the bottom of a drop-down list would hide the last item in the list.

#### SLAnalytics: Trend prediction data would contain incorrectly converted time stamps \[ID_25111\]

In some cases, trend prediction data returned by SLAnalytics would contain incorrectly converted time stamps.

#### Exception when writing empty data set to Elastic database \[ID_25113\]

In some cases, an exception could be thrown when an empty data set was written to the Elastic database.

#### DataMiner Cube - EPM/CPE: No Topology button in sidebar \[ID_25120\]

On EPM/CPE systems, in some cases, no Topology button would be displayed in the sidebar.

#### Missing or incorrect alarm details after retrieving alarms of a restarted element from a MySQL database \[ID_25123\]

When, after an element restart, the alarms of that element were retrieved from a MySQL database, in some cases, a number of alarm fields would either contain incorrect values or be missing.

#### DataMiner Cube - Visual Overview: Embedded Service Manager component would show an empty service definition diagram \[ID_25140\]

In some cases, a Service Manager component embedded on a Visio page would show an empty service definition diagram.

#### Memory leak in SLAnalytics \[ID_25145\]

In some cases, a memory leak could occur in the SLAnalytics process.

#### Dashboards app: Not possible to select items in tree view \[ID_25151\]

In some cases, it could occur that it was not possible to select items in a tree view in the Dashboards app. This could for example be the case in a tree component or in the configuration of a parameter feed.

#### Dashboards app: Minor fixes made to trend graph legend \[ID_25159\]

A number of minor fixes have been made to the trend graph legend.

#### Failover: Remote services not synchronized towards offline Agent \[ID_25173\]

In a Failover setup, it could occur that remote services were not synchronized towards the offline Agent.

#### Number of masked alarm was incorrectly incremented when the severity of a masked alarm was changed \[ID_25182\]

When the severity of a masked alarm was changed, in some cases, the number of masked alarms would incorrectly be incremented.

#### DataMiner Cube - Spectrum analysis: When a user disconnected from a shared session, the other users would stop receiving new traces \[ID_25201\]

When multiple users shared the same spectrum session, in some cases, from the moment one of those users disconnected, all other users would stop receiving new traces.

#### Memory leak in SLLoggerUtil process \[ID_25206\]\[ID_25465\]

In some cases, the SLLoggerUtil process would leak memory. For instance, when the log levels were updated multiple times.

#### Problem with SLPort when closing a serial connection or when changing the security keys of an SSH connection \[ID_25213\]

In some cases, an error could occur in SLPort when closing a serial connection or when changing the security keys of an SSH connection.

#### Problem with SLProtocol when starting a DVE element or a virtual function \[ID_25215\]

In some cases, an error could occur in SLProtocol when starting a DVE element or a virtual function.

#### Run-time error in protocol thread after dynamic IP change or close action of serial connection \[ID_25223\]

If a protocol with serial connection over UDP or TDC/IP used either an action of type "close" on a serial connection or a parameter with type option "dynamic IP", a run-time error could occur in the protocol thread.

#### Automation: Options text in narrow Automation script execution window not fully displayed \[ID_25226\]

In the window displaying the options for the execution of an Automation script, text wrapping was not implemented, so that it could occur that the text was not fully displayed if the window was too narrow.

#### Problem with EPM filters \[ID_25231\]

When an object in an EPM (formerly known as CPE) environment did not have a link to a parent object, it could occur that filters were loading indefinitely or kept showing the previous filter result.

#### Problem with SLElement when the element incorrectly identified as the DMA element was deleted \[ID_25261\]

In some cases, an error could occur in SLElement when the element incorrectly identified as the DataMiner Agent element was deleted.

#### SLProtocol would incorrectly flush timetrace data when only element data had to be flushed \[ID_25273\]

In some cases, when SLProtocol had to flush element data, it would also incorrectly flush timetrace data.

#### Problem when retrieving a large number of alarms from a MySQL database \[ID_25298\]

When, on a system with a MySQL database, a correlation alarm was based on a large number of alarms, in some cases, an exception could be thrown when retrieving those alarms.

#### DataMiner Cube: Problems when renaming/deleting Documents folders \[ID_25323\]

In some cases, it could occur that it was not possible to rename or delete a Documents folder in DataMiner Cube. In addition, when a Documents folder was deleted, it could occur that an incorrect message was displayed, which would remove the folder even if the user clicked "No".

#### Generation of alarm events with root key 0 upon creation of DVE element \[ID_25328\]

When a DVE element was created, in some cases, alarm events with root key 0 would incorrectly be generated for the monitored parameters that were not in an alarm status.

#### Cassandra: When an element was restarted, duplicate timetrace entries would be written to the database \[ID_25385\]

When an element with a large amount of active alarms was restarted, in some cases, duplicate timetrace entries would be written to the Cassandra database

#### DataMiner Cube: Elements would go into timeout after being imported from a CSV file \[ID_25457\]

When you exported elements with non-used SNMP credential library references to a CSV file, those references were incorrectly saved as empty GUIDs. This would cause the elements to go into timeout after being re-imported from that CSV file.
