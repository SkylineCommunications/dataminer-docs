---
uid: General_Main_Release_10.1.0_new_features_5
---

# General Main Release 10.1.0 - New features_5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> **Internet Explorer Support**
>
> Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.
>
> The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.
>
> However, if you do wish to use DataMiner Cube in a browser, this remains possible:
>
> - Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.
> - You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet.

### DMS Automation

#### Possibility to add, update or clear the script output \[ID_23936\]

Up to now, when a parent script added keys to the script output and then ran a subscript that also added keys to the script output, the keys added by the parent script would be deleted. From now on, the keys added by the parent script will by default no longer be deleted. If you want those keys to be deleted, then have the parent script call the engine.ClearScriptResult() method before starting the subscript.

Up to now, the following engine objects could be used to manipulate the script output:

- engine.AddScriptOutput(string key, string value)

    Adds a key to the script output if it has not yet been added. If the key already exists, an exception will be thrown.

- subScriptOptions.GetScriptResult()

    Returns a copy of the script output of the current script and, if the *InheritScriptOutput* option is set to “true”, the child scripts. For more information, see below.

From now on, you can also use the following new engine objects:

- engine.AddOrUpdateScriptOutput(string Key, string Value)

    Adds a key to the script output if it has not yet been added. If the key already exists, it will update it with the specified value.

- engine.ClearScriptResult()

    Clears the script output.

- engine.ClearScriptOutput(string key)

    Removes a key from the script output. Returns NULL when the specified key cannot be found.

- engine.GetScriptResult()

    Returns a copy of the script output of the current script and, if the *InheritScriptOutput* option is set to “true”, the child scripts. For more information, see below.

- engine.GetScriptOutput(string key)

    Returns the script output of the specified key. Returns NULL when the specified key cannot be found.

> [!NOTE]
> When a subscript fails or throws an exception, its script output will still be filled in.

Also, a new *InheritScriptOutput* script option will now allow you to control whether a parent script will inherit the script output of its subscripts. Default value: true

Example:

```csharp
var scriptOptions = engine.PrepareSubScript("MyScript");
scriptOptions.InheritScriptOutput = true;
scriptOptions.StartScript();
```

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

Example:

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

#### Injecting a DLL into an Automation script \[ID_24945\]

It is now possible to inject DLL files into an Automation script.

##### To inject a DLL

1. Create an *AutomationDllInjectionItem* object that contains the following data:

    | Item     | Description                                                                                              |
    |------------|----------------------------------------------------------------------------------------------------------|
    | ScriptName | The name of the script into which the DLL will be injected.                                              |
    | ExeId      | The ID of the script action that will be replaced. Note: This script action must be a C# code block. |
    | Path       | The path to the DLL that will be injected. Note: This file must have the extension “.dll”.           |

1. Send the object to the server using an *InjectAutomationDllRequestMessage*.

The server will send back an *InjectAutomationDllResponseMessage*. If any errors would have occurred, they will be included as errors of type *AutomationErrorData* in the message’s *TraceData* object. Possible errors include:

| Value           | Description                                                                                                                                       |
|-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------|
| Unknown         | An unknown error occurred.                                                                                                                        |
| NotAllowed      | The user who sent the message does not have the correct permissions.                                                                              |
| DllPathInvalid  | The DLL path is invalid. The file does not exist or does not have the extension “.dll”.                                                           |
| NotLicensed     | The DataMiner Agent is not licensed to use the Automation module.                                                                                 |
| InjectionFailed | The injection operation failed in SLAutomation. For more information, check the *SLAutomationErrors* property. |

To determine whether the injection was successful, you can check TraceData.HasSucceeded.

##### To request an overview of the injected DLLs

Send a *GetAutomationDllOverviewRequestMessage* to the server. This message does not have any properties.

The server will send back a *GetAutomationDllOverviewResponseMessage* containing a list of *AutomationDllInjectionItem* objects.

##### To eject a DLL

If you eject a previously injected DLL from an Automation script, this will cause the script to behave as it did before the injection. To do so, send an *EjectAutomationDllRequestMessage* containing the name of the script and the Exe ID (i.e. the ID of the script action).

The server will send back a EjectAutomationDllResponseMessage. If any errors would have occurred, they will be included as errors of type *AutomationErrorData* in the message’s *TraceData* object. Possible errors include:

| Value | Description |
|--|--|
| Unknown | An unknown error occurred. |
| NotAllowed | The user who sent the message does not have the correct permissions. |
| NotLicensed | The DataMiner Agent is not licensed to use the Automation module. |
| EjectionFailed | The ejection operation failed in SLAutomation. For more information, check the *SLAutomationErrors* property. Note: This error will never be returned after injecting a DLL. See “To eject a DLL” below. |

##### To execute a script

Send an ExecuteScriptMessage to the server.

> [!NOTE]
>
> - Users who send the above-mentioned messages must have the “Automation \> Edit” permission to be able to inject or eject DLLs.
> - DLLs can be injected in scripts that have not yet been run.
> - When you restart the DataMiner Agent, the injected DLL will no longer be applied.

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
| PlaceholderText | Text that will be displayed as long as the control is empty.<br> (e.g. “In this box, enter...”) |
| ValidationState | Indicates whether the value was validated and whether that value is valid.<br> Possible values:<br> - NotValidated<br> - Valid<br> - Invalid<br> Note: This property can be used to indicate to users that they entered an invalid value. |
| ValidationText | Text that will be displayed when ValidationState is “Invalid”. |

##### Using the ValidationState and ValidationText properties

The ValidationState and ValidationText properties should be used in combination with the WantsOnChange property.

If WantsOnChange is true, the interactive Automation script will have its Engine#ShowUI(...) method return each time the user input changes. This will also be indicated by the \_ONCHANGE key, which is returned in the UIResults.

This functionality will allow you to offer clear feedback on user input.

##### Which input controls support which properties?

|              | IsRequired | Placeholder | ValidationText |
|--------------|------------|-------------|----------------|
| TextBox      | X          | X           | X              |
| PasswordBox  | X          | X           | X              |
| DropDown     | X          | X           | X              |
| Numeric      | X          | X           | X              |
| Calendar     | X          |             | X              |
| FileSelector |            |             | X              |

#### Possibility to add Attachments to tickets \[ID_25612\]

In a C# block of an Automation script, you can now add attachments to tickets.

In the TicketingHelper class and TicketingGatewayHelper, the “AttachmentsHelper Attachments” property will allow to manage ticket attachments using the following methods:

| Method                                                      | Function                                                                                     |
|-------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| Add(TicketID ticketID, string fileName, byte\[\] fileBytes) | Add an attachment to a ticket                                                                |
| List\<string> GetFileNames(TicketID ticketID)               | Retrieve the names of all the attachments added to the ticket with the specified ticket ID.  |
| Delete(TicketID ticketID, string attachmentName)            | Deletes the attachment with the specified name from the ticket with the specified ticket ID. |
| byte\[\] Get(TicketID ticketID, string attachmentName)      | Retrieves the content of the attachment with the specified name as a byte array.             |

> [!NOTE]
>
> - The maximum size of ticket attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - Manipulating ticket attachments requires the same user permissions as normal ticket management operations: Read permission to view and download attachments and Edit permission to add and delete attachments.
> - If a ticket is deleted, all its attachments will physically be deleted from disk. They will not be recoverable.
> - All ticket attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.
> - The Documents API can also be used to manage ticket attachments. Instead of using the above-mentioned methods, you can also use AddDocumentMessage, DeleteDocumentMessage, GetBinaryFileMessage and GetDocumentMessage. If you do so, specify the directory as “TICKET_ATTACHMENTS\\{DataminerID}\_{TicketId}” and make sure the property ID of type DMAObjectRef contains the ticket ID.

#### Run-time flag 'NoCheckingSets' now allows the 'After executing a SET command' option to be changed while a script is being run \[ID_25847\]

When you launch an Automation script, you can choose to select the “After executing a SET command” option. If you do so, every time the script performs a parameter or property update, it will wait for a return value indicating whether or not the update was successful.

From now on, the “NoCheckingSets” run-time flag will allow this option to be changed while a script is being run.

#### Connecting a DMS to a remote ElasticSearch cluster from an Automation script \[ID_26569\]

It is now possible to have a DMS connect to the nodes of a remote ElasticSearch cluster from an Automation script by sending an InstallElasticAndMigrateRequest message.

This message will add the IP addresses of the remote ElasticSearch nodes to the db.xml file.

#### Replacing Automation script DLL dependencies \[ID_26605\]

It is now possible to replace an Automation script DLL dependency from an Automation script by sending an UploadScriptDependencyMessage.

By default, the DLL file will be uploaded to the C:\\Skyline DataMiner\\scripts\\dllImport folder, but it is possible to specify a subfolder if required. The uploaded DLL file will be synchronized among all agents in the DMS.

- The name of the new DLL file in the UploadScriptDependencyMessage must be identical to the name of the old DLL file. If not, the file will no longer be found after a DataMiner restart.
- Automation scripts using a DLL file should always refer to that file using its full path. If you upload a DLL file named “MyDependency.dll”, the scripts using it should refer to it using “C:\\Skyline DataMiner\\Scripts\\DllImport\\MyDependency.dll”.
- DLL files in the C:\\Skyline DataMiner\\Scripts\\DllImport folder are loaded from bytes rather than from file. They will not be locked by SLAutomation after being loaded. Note that, in some rare cases, DLL files loaded from bytes will not work properly. An example of a file that will not work when loaded from bytes is Microsoft.Exchange.WebServices.
- When a script dependency is uploaded using an UploadScriptDependencyMessage

  - all scripts that directly reference the file will be recompiled when executed, and
  - all libraries that reference the file (and all libraries that use those libraries) will be recompiled immediately.

- When you reference a DLL file stored in C:\\Skyline DataMiner\\Scripts\\DllImport while a DLL file with the same name is present in C:\\Skyline DataMiner\\Files, the former will take precedence.
- Users need the *Modules \> Automation \> Edit* permission to be able to upload Automation script dependencies.

> [!NOTE]
>
> - If an uploaded DLL dependency would break existing scripts and/or libraries, no errors will be returned.
> - It is advised to strong-name DLL files when referring to multiple versions of the same file in different scripts. Not strong-naming DLL files could lead to unexpected behavior.

#### Uninstalling app packages \[ID_26643\]

App packages can now be uninstalled using the new AppPackageHelper method UninstallApp.

```csharp
/// <summary>
/// Uninstalls the app with ID <paramref name="appId"/>
///
/// <param name="appId">The ID of the app to be uninstalled.</param>
/// <param name="force">
///    If true:
///    - The app will be forcefully uninstalled, even if the uninstall script fails.
///    - If the uninstall script exits with an exception or could not be run, no exceptions will be thrown.
/// </param>
/// <exception cref="AppUninstallationFailedException">
///    This exception will be thrown in the following cases:
///    - When the specified app is not installed.
///    - When the uninstall script could not be run due to syntax errors.
///    - When the uninstall script exited with an exception.
/// </exception>
/// <exception cref="DataMinerException">
///    This exception will be thrown in all other cases when something goes wrong.
/// </exception>
/// </summary>
///
public void UninstallApp(AppID appId, bool force)
```

##### Uninstall script

Inside every app package, an uninstall script named *uninstall.xml* should be available in the Scripts folder.

An uninstall script has to be triggered using the UninstallApp entrypoint (see below for an example). As soon as the uninstall script has finished, the installation folder of the app in question will be removed on all agents in the DMS.

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.UninstallApp)]
public void Uninstall(Engine engine, AppUninstallContext context)
{
    ...
}
```

##### Remarks

- When an app package does not contain an uninstall script (or when the uninstall script is not a valid XML file), triggering the non-existing uninstall script will cause the installation folder of the app in question to be removed on all agents in the DMS.

- Only users with “Install App Packages” permission will be able to trigger an uninstall script.

- It is up to the creator of an app package to provide an uninstall script that properly cleans up the installed app. DataMiner does not keep track of the objects that are installed when installing an app and will not do any cleanup except removing the installation folder.

- If the uninstall script contains syntax errors it will still be installed.

- When you install an app with the *AllowMultipleInstalledVersions* option set to false, the uninstall script of that app (if present) will automatically be triggered. Also, the uninstall will be executed forcefully, meaning that the app will be removed even when the script fails.

- When an app is being uninstalled, its AppInstallState will be set to BUSY_UNINSTALLING, and if anything goes wrong during the uninstall (and the uninstall was not executed forcefully), its AppInstallState will be set to CORRUPTED.

- An app of which the AppInstallState is set to BUSY_INSTALLING can only be uninstalled forcefully.

- If an uninstall script requires any external DLL files, those can be placed in the C:\\Skyline DataMiner\\Scripts\\UninstallDependencies folder. During an uninstall operation, the dependencies will then automatically be referenced in the uninstall script.

> [!NOTE]
> The DataMiner SLNetClientTest tool now also supports uninstalling app packages. See *Advanced \> Apps \> App Packages*.

#### Automation: Tree view control for interactive Automation scripts \[ID_26840\]\[ID_27041\]\[ID_27756\]

It is now possible to add a tree view control in an interactive Automation script. However, note that Automation scripts with tree view controls are currently only supported in the DataMiner mobile apps. These are not yet supported in DataMiner Cube.

To define a tree view control, create a UIBlockDefinition of type TreeView and add each item of the tree view as a TreeViewItem to the TreeViewItems property. It is not required to fill in the InitialValue or Value of the UIBlockDefinition, as that value is determined based on the TreeViewItem collection.

Each TreeViewItem has the following properties:

- *DisplayValue*: The string value displayed for this item in the UI.

- *KeyValue*: The string value that is used as a key to retrieve the selected state of the item. This is the value that will be used in the destination variable.

- *IsChecked*: Boolean that allows you to have an item selected by default. Do not fill in this property for TreeViewItems that have child items. The selection of such a parent item depends on the selected child items. If some of the child items are selected, the parent item is only partially selected and its value will not be included in the destination variable. If all child items are selected, the parent item is automatically also selected.

- IsCollapsed: Boolean that allows you to indicate whether the item should be collapsed or expanded.

    > [!NOTE]
    > This property will not be updated when you collapse or expand tree view items in the UI.

- *ItemType*: Determines the type of item in the tree view. The following values are possible:

  - *Empty*: Only the DisplayValue will be displayed for this item.
  - *CheckBox*: A checkbox will be shown next to the DisplayValue.

- *ChildItems*: List of TreeViewItems that are child items of this item.

Optionally, you can enable the WantsOnChange option for the tree view control, in which case it will send an update each time the selected state of a TreeViewItem changes.

To retrieve the results:

- The UIResult, which can be returned using *engine.ShowUI()*, contains the KeyValue of the selected items.
- The GetString(UIBlockDefinition *destvar*) method to retrieve a semicolon-separated string of the KeyValues.
- The GetChecked(UIBlockDefinition *destvar*, KeyValue *value*) method can be used to check if a specific KeyValue was selected.

Example:

```csharp
{
   UIBuilder uib = new UIBuilder();
   uib.Title = "Treeview - default";
   uib.RequireResponse = true;
   uib.RowDefs = "*,*";
   uib.ColumnDefs = "*";

   UIBlockDefinition tree = new UIBlockDefinition();
   tree.Type = UIBlockType.TreeView;
   tree.Row = 0;
   tree.Column = 0;
   tree.DestVar = "treevar";
   tree.TreeViewItems = new List<TreeViewItem>
   {
      new TreeViewItem("Core Teams", "1", new List<TreeViewItem>
      {
         new TreeViewItem("Team A", "1/1", new List<TreeViewItem>
         {
            new TreeViewItem("Brian", "1/1/1", true) { ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("John", "1/1/2"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Kevin", "1/1/3", true){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("David", "1/1/4"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Joe", "1/1/5", true){ ItemType = TreeViewItem.TreeViewItemType.CheckBox }
         }){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
         new TreeViewItem("Team B", "1/2", new List<TreeViewItem>
         {
            new TreeViewItem("Jane", "1/2/1"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Sarah", "1/2/2"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Emily", "1/2/3"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Anne", "1/2/4"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Florence", "1/2/5"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox }
         }) { ItemType = TreeViewItem.TreeViewItemType.CheckBox }
      }){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
      new TreeViewItem("Team C", "2") { ItemType = TreeViewItem.TreeViewItemType.CheckBox }
   };
   uib.AppendBlock(tree);

   UIBlockDefinition next = new UIBlockDefinition();
   next.Type = UIBlockType.Button;
   next.Row = 1;
   next.Column = 0;
   next.Text = "Next";
   next.DestVar = "Next";
   uib.AppendBlock(next);

   _treeResults = _engine.ShowUI(uib);
} while (!_treeResults.WasButtonPressed("Next"));

ShowResult();
```

#### Interactive Automation scripts: Support for datetime values in ISO 8601 format \[ID_27565\]

The UIResults.GetDateTime method now also supports datetime values in ISO 8601 format.

Up to now, only datetime values in “dd/MM/yyyy HH:mm:ss” were supported.

#### Interactive Automation scripts: TreeViewItem now has an 'IsCollapsed' property \[ID_27567\]

Each TreeViewItem in a TreeView component now has an “IsCollapsed” property.

This will allow clients to determine the initial state of each TreeViewItem when displaying a TreeView

### DMS Maps

#### Open Street Maps can now be accessed offline \[ID_25928\]

It is now possible to access Open Street Maps offline when, in the server configuration file, you set AppVersion to “1” and MapsProvider to “OSM”.

See the following example of a ServerConfig.xml file.

```xml
<MapsServerConfig>
  <VirtualHosts>
    <VirtualHost hostname="*">
      <AppVersion>1</AppVersion>
      <MapsProvider>OSM</MapsProvider>
      <TilesServer>
        <BaseLayers>
          <BaseLayer key="..." name="..." url="..."/>
          <BaseLayer key="..." name="..." url="..."/>
          <BaseLayer key="..." name="..." url="..."/>
        </BaseLayers>
      </TilesServer>
      <GoogleMaps key="..."/>
      <MapQuest key="..."/>
      <OWM key="..."/>
    </VirtualHost>
  </VirtualHosts>
</MapsServerConfig>
```

Custom base layers can be defined in TilesServer.BaseLayers.BaseLayer tags. Those have the following attributes:

| Attribute | Description                                                                                               |
|-----------|-----------------------------------------------------------------------------------------------------------|
| key       | Key used to refer to a base layer acting as default map (in the MapType tag of a map configuration file). |
| name      | The name of the base layer that will be displayed in the base map selection box.                          |
| url       | The URL of the layer tiles exposed by the offline maps server.                                            |

### DMS EPM

#### DataMiner Cube: Term 'CPE' replaced by 'EPM' \[ID_24568\]

In DataMiner Cube, the term “CPE” (Customer Premises Equipment) has been replaced by “EPM” (Experience and Performance Management).

#### Discreet parameters now supported in EPM search chains \[ID_25862\]

When a filter in an EPM search chain refers to a column parameter of type discreet, the filter will be displayed as a drop-down box rather than a text box.

If the filter is used for multiple tables, it will be displayed as a drop-down box as soon as one of the columns represents a discreet parameter.

When multiple columns have different discreet values, all these values will be displayed as long as they have a unique value and display string.

> [!NOTE]
> Dynamic discreet parameters are currently not supported.

#### CPECollectorHelper API: Timeout parameters can now be configured in the SLNetClientTest tool \[ID_26247\]

When a call is performed via the CPECollectorHelper API, a timeout is calculated based on the amount of requested items using the following formula:

`Total Timeout = ((requested number of items / EPMBulkCount) + 1) * EPMASyncTimeout`

In the SLNetClientTest tool, it is now possible to configure the following parameters:

| Parameter       | Description                                                                                |
|-----------------|--------------------------------------------------------------------------------------------|
| EPMAsyncTimeout | The base value for a timeout when the CPECollector contacts another DataMiner Agent.       |
| EPMBulkCount    | The maximum number of items that can be requested in bulk before the timeout is increased. |

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### DataMiner Cube: Long selection box content in EPM filters will automatically wrap to the next line \[ID_27660\]

From now on, long selection box content in EPM filters will automatically wrap to the next line.

### DMS Web Services

#### BREAKING CHANGE - Web Services API v1: New and updated methods to manage job data \[ID_26006\]

In the Web Services API v1, the job management methods have all been modified to support job domains.

##### Changes to classes

The DMAJobDomain class, which now extends from the newly added DMAJobDomainLite class, contains a new SectionDefinitions property. That property will contain an array of DMASectionDefinitions that are linked to the JobDomain.

> [!NOTE]
>
> - Configuration has been marked obsolete. All client information will be available in the Info property of each SectionDefinition.
> - In DMASectionDefinitionInfo, the CustomSectionDefinitionExtensionID property has been marked obsolete.

##### Methods to manage job domains

- CreateJobsDomain(string connection, string name)

    Creates a job domain with a unique name, containing a default section definition. If the job domain was created successfully, the ID of the created job domain will be returned.

- GetJobsDomains(string connection)

    Retrieves all available job domains and sorts them naturally by name. Returns an array of JobDomainLite objects.

- GetJobsDomain(string connection, string domainID)

    Retrieves a job domain by ID. If no ID is provided, then the first domain found will be returned. Also, the method will migrate the client information in the user’s VisualData to JobDomain.VisualStructure.

- UpdateJobsDomain(string connection, string id, string name)

    Updates a job domain. If the job domain was updated successfully, the ID of the updated job domain will be returned.

- DeleteJobsDomain(string connection, string id)

    Deletes a job domain. If the job domain was deleted successfully, the method will return TRUE.

- UpdateDomainSectionDefinitionConfiguration(string connection, string domainID, DMASectionDomainConfig\[\] configuration)

    This method, which was formerly named SaveJobsSectionDomainConfig, updates all client information of each section definition in JobDomain.VisualStructure.

##### Methods to manage job section definitions

- CreateJobsSectionDefinition(string connection, string domainID, string name, DMABookingLink bookingLinkInfo, DMASectionDefinitionInfo info)

    This method, which now includes a domain ID, now creates a section definition in the specified domain. If the section definition was created successfully, the section definition ID will be returned.

- GetJobsSectionDefinitions(string connection)

    Retrieves all section definitions.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobsSectionDefinitionsV2 method instead (see below).

- GetJobsSectionDefinitionsV2(string connection, string domainID)

    Retrieves all section definitions from the specified domain and parses them using the client information in the VisualStructure of the domain in question.

- GetJobsSectionDefinition(string connection)

    Retrieves a specific section definition.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobsSectionDefinitionV2 method instead (see below).

- GetJobsSectionDefinitionV2(string connection, string domainID. string sectionDefinitionID)

    Retrieves a specific section definition from the specified domain and parses it using the client information in the VisualStructure of the domain in question.

- UpdateJobsSectionDefinition(string connection, string domainID, string sectionDefinitionID, string name, DMABookingLink bookingLinkInfo, DMASectionDefinitionInfo info)

    This method, which now includes a domain ID, now updates the specified section definition in the specified domain. If the section definition was updated successfully, the section definition ID will be returned.

- DeleteJobsSectionDefinition(string connection string sectionDefinitionID)

    > [!NOTE]
    > This method is no longer supported. It will return an error indicating that you should use the new DeleteJobsSectionDefinitionFromDomain method instead (see below).

- DeleteJobsSectionDefinitionFromDomain(string connection, string domainID, string sectionDefinitionID)

    Removes the specified section definition from the specified domain and the client information for that domain from the VisualStructure.

    > [!NOTE]
    > This method does not physically delete a section definition. It only removes the link between the section definition and the job domain.

- UnhideJobsSectionDefinition(string connection, string domainID, string sectionDefinitionID)

    Unhides the specified section definition of the specified domain.

- UpdateSectionDefinitionFieldOrder(string connection, string domainID, string sectionDefinitionID, string\[\] fieldOrder)

    Updates the field order in the specified section definition of the specified domain.

##### Methods to manage job section definition fields

- AddOrUpdateJobsSectionDefinitionField(string connection, string domainID, string sectionDefinitionID, DMASectionDefinitionField field, DMAJobFieldPossibleValueUpdate\[\] possibleValueUpdates)

    Adds or updates a section definition field in the specified section definition of the specified domain.

- DeleteJobsSectionDefinitionField(string connection, string sectionDefinitionID, string fieldID)

    Removes a section definition field from the specified section definition of the specified domain.

- UnhideJobSectionDefinitionField(string connection, string domainID, string sectionDefinitionID, string fieldID)

    Unhides the specified section definition field in the specified section definition of the specified domain.

##### Methods to manage jobs

- DeleteJobs(string connection, string domainID, string\[\] jobIDs)

    Deletes the specified jobs and returns an DMARemoveInfo object containing an array with all successful and failed removals.

##### Methods to manage job templates

- GetJobTemplates(string connection)

    Retrieves all job templates.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobTemplatesV2 method instead (see below).

- GetJobTemplatesV2(string connection, string domainID)

    Retrieves all job templates for the specified domain.

#### Web Services API v1: DMASpectrumBuffer object now contains VariableID property instead of Name property \[ID_27092\]

In the web services API, the web method *GetSpectrumBuffersByMonitorId* will now return *DMASpectrumBuffer* results containing a *VariableID* property instead of a *Name* property.

#### Web Services API v1: New GetServicesForFilter method \[ID_27412\]

In the web services API v1, the new method *GetServicesForFilter* is now available. It can be used to retrieve a list of services matching a property filter.
