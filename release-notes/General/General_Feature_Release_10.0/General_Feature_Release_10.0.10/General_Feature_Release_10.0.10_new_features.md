---
uid: General_Feature_Release_10.0.10_new_features
---

# General Feature Release 10.0.10 – New features

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### DMS core functionality

#### LogHelper API \[ID_26434\]

The new LogHelper API, which combines the SLLoggerUtil API and the LogEntry repository API, can be used in Automation scripts and in QActions to manage log entries stored in Indexing Engine:

- ILogHelper#Log can be used to add new log entries to the database.
- ILogHelper#LogEntries can be used to retrieve log entries from the database.
- LogEntries.Exposers can be used to create filters used when retrieving entries.

##### Using statement

LogHelper should always be created within a using statement. See the following examples.

Automation script example:

```csharp
using(var logHelper = LogHelper.Create(engine.GetUserConnection()))
{
    // ...
 }
```

QAction example:

```csharp
using(var logHelper = LogHelper.Create(protocol.GetUserConnection()))
{
    // ...
 }
```

##### Automation

A new method was added to Engine and IEngine:

- Engine#GetUserConnection() : IConnection

It returns a connection that impersonates the user who ran the script based on Engine#UserCookie. If no user cookie is present on the script, the returned IConnection will act as the SLManagedAutomation connection.

##### QActions

A new method was added on SLProtocol interface:

- SLProtocol#GetUserConnection() : IConnection

It returns a connection that impersonates the user who triggered the QAction based on SLProtocol#UserCookie. If no user cookie is present within the QAction context, the returned IConnection will act as the SLManagedScripting connection.

##### Script and QAction compilation

Automation scripts and QActions will now by default be compiled with a reference to SLLoggerUtil.dll (C:\\Skyline DataMiner\\Files\\SLLoggerUtil.dll).

#### A notice will now be generated at DataMiner startup when duplicate properties are found for views, elements or services \[ID_26705\]

When, at DataMiner startup, duplicate properties are found for views, elements or services, from now on, one agent in the DataMiner System will generate a notice.

If an Administrator clears the notice manually, it will re-appear at the next DataMiner restart if the issue has not yet been resolved.

### DMS Protocols

#### Socket buffer of a serial interface will now be flushed before a command is sent \[ID_26513\]

From now on, each time a command is sent via a serial interface, the socket buffer of that serial interface will be flushed in advance.

#### Replacing QAction DLL dependencies \[ID_26605\]

It is now possible to replace QAction DLL dependencies by installing a .dmprotocol package that contains an Assemblies folder with new DLL dependencies.

By default, the DLL files in the package will be copied to the C:\\Skyline DataMiner\\ ProtocolScripts\\dllImport folder. All DLL files in this folder will be synchronized among all agents in the DMS.

- When you upload a .dmprotocol containing a protocol identical to one that is already present on the system, the elements using that protocol will be restarted if the package contains at least one DLL file.

- If any QActions in protocols other than the one uploaded in the .dmprotocol package use a DLL file that was replaced, the elements using those protocols will not be restarted. QActions of those elements triggered before the .dmprotocol package was uploaded will continue to use the old dependency. Only after restarting DataMiner will the new dependency be used.

- If you want a DLL file to be placed in a subfolder of the dllImport folder, then add a subfolder in the .dmprotocol package. In that case, also specify that subfolder in the dllImport attribute of the QAction. For example, the C:\\Skyline DataMiner\\ProtocolScripts\\ dllImport\\subfolder\\example.dll file will only be found if the QAction references it using the following syntax: \<Qaction id="1" dllImport="subfolder\\example.dll" encoding="csharp" triggers="1">

    > [!NOTE]
    > When a DLL file is referenced using the dllImport attribute of a QAction (e.g. \<QAction id="5" dllImport="somedll.dll" encoding="csharp" triggers="1">), then the dllImport folder will be checked first. If the DLL file cannot be found in that folder, then the ProtocolScripts folder will be checked.

> [!NOTE]
>
> - If an uploaded DLL dependency would break existing QActions, no errors will be returned.
> - It is advised to strong-name DLL files when referring to multiple versions of the same file in different QActions. Not strong-naming DLL files could lead to unexpected behavior.

### DMS Cube

#### Anomaly detection configuration in alarm templates \[ID_24578\]

It is now possible to enable specific anomaly detection options for parameters in an alarm template. To do so, select the *Advanced configuration of anomaly detection* option via the cogwheel button in the alarm template editor. Three additional columns will then be displayed in the alarm template, where you can enable or disable trend monitor, variance monitor and level shift anomaly detection for each monitored parameter.

#### Services app: New and updated booking state icons \[ID_26270\]

In the *Overview* tab of the *Services* app, the booking state of a service is indicated by an icon in the *Booking state* column.

- A new icon has been added to indicate service permanent bookings that start somewhere in the future:

  ![Future permanent booking icon](~/release-notes/images/BookingOngoingPermanentFuture.png)

- The icons used to indicate the state of one or more bookings linked to a service will now be displayed in the following order:

  - Permanent ongoing
  - Ongoing
  - Permanent in future
  - Future
  - Past/None

#### Service & Resource Management - Profiles app: Value of a capability of type 'text' can now be changed regardless of the 'User time-dependent' option \[ID_26538\]

Up to now, when you configured a profile instance, the value of a capability of type “text” could only be changed when the “Use time-dependent" option was selected. From now on, it will be possible to change the value of a capability of type “text” regardless of the “User time-dependent" option.

#### System Center - SNMP forwarding: Generate MIB file \[ID_26591\]

When an SNMP manager is configured to forward SNMPv2 or SNMPv3 traps with custom bindings, then you can now generate a MIB file containing those custom bindings.

To do so, go to the *Notification* tab of the SNMP manager in question, open the pane listing the custom bindings and click the *Generate MIB file...* button.

> [!NOTE]
> The *Generate MIB file...* button will only be enabled when
>
> - *Notification OID* is set to “Use custom bindings”,
> - the list of custom bindings contains at least one entry, and
> - all changes to the SNMP manager in question have been saved.

#### Default browser engine is now Chromium \[ID_26662\]

From now on, Cube will use Chromium as the default browser engine. When that engine is not installed, it will fall back to the first installed browser (currently, on most systems, this will be Microsoft Internet Explorer).

Although it will remain possible to configure that a different browser should be used for specific protocols, it will no longer be possible to configure that a different browser should be used for apps like Dashboards or Ticketing. Those apps will now always use the default browser engine.

When, on a Visio page, you configured a shape to display a web page, that web page will now also by default be rendered using the Chromium browser engine. However, if you want to explicitly specify the browser engine to be used, then add a shape data field of type *Options* to the shape and set its value to either “UseChrome” or “UseIE”.

> [!NOTE]
> Cube also use the default browser engine when displaying annotations.

#### Visual Overview: New option to show table name in parameter control shape \[ID_26694\]

Up to now, a parameter control displaying a parameter value retrieved from a table would by default also show the name of that table. From now on, this will no longer be the case.

If you want a parameter control to also show the name of the table, then specify the “ShowTableName=true” option in the *ParameterControlOptions* data field of the parameter control shape.

| Shape data field        | Value              |
|-------------------------|--------------------|
| ParameterControlOptions | ShowTableName=true |

#### Visual Overview: Factoring in decimals when using the DynamicUnits option \[ID_26697\]

The *DynamicUnits* option allows you to enable the use of dynamic units, i.e. units that can be converted to other units according to rules configured in the protocol. You may decide to enable this feature if you want to have large values converted to more legible values (e.g. to convert 1000 Mb to 1 Gb, 1000 m to 1 km, etc.).

From now on, when using the *DynamicUnits* option, it is also possible to factor in decimals defined in the dynamic units of a protocol parameter. With a configuration like the following, a value of 0.15 m will be shown as 15.0 cm (i.e. with 1 decimal).

```xml
<Display>
  <RTDisplay>true</RTDisplay>
  <Units>m</Units>
  <DynamicUnits>
    <Unit>mm</Unit>
    <Unit decimals=”1”>cm</Unit>
    <Unit decimals=”3”>km</Unit>
  </DynamicUnits>
  <Decimals>2</Decimals>
  ..
</Display>
```

#### Periodic updates of Cube and Cube Launcher \[ID_26725\]\[ID_26986\]

The first time you start Cube Launcher, a task named “Update DataMiner Cube” will be added to Windows Task Scheduler. Every 3 days, that task will start Cube Launcher with the /Update argument. The /Update argument combines the /UpdateClients and /UpdateLauncher arguments. See below.

| Argument | Function |
|--|--|
| /UpdateClients | Checks, for all the DataMiner Systems to which you have connected in the last 100 days, whether a new Cube version is available. If so, it will immediately be downloaded. |
| /UpdateLauncher | Checks for a newer version of Cube Launcher on `https://dataminer.services`. If a newer version is found, it will immediately be downloaded and installed. If no newer version can be found on `https://dataminer.services`, then the 10 DataMiner Systems to which you connected last will be checked for a new version. |

The scheduled task is checked each time you start Cube Launcher, and is removed when you uninstall Cube Launcher. Periodic updates can be suspended by disabling the task in Windows Task Scheduler.

#### Visual Overview / Service & Resource Management: Reservation placeholder now supports Status field \[ID_26859\]

Using the syntax “\[Reservation:\<id>,\<fieldName>\]”, it is possible to resolve a booking field based on the ID and the name of that field.

The Status field has now been added to the list of possible fields. This field indicates the current status of the booking (e.g. “Ended”, “Pending”, “Ongoing”, etc.).

### DMS Reports & Dashboards

#### Dashboards app: New style layout options for State components displaying parameters \[ID_26498\]

In DataMiner v.10.0.9, the layout options for a State component displaying a parameter were adjusted. Now, these new layout options will also be available when a State component displays other DataMiner objects like elements, services, views or redundancy groups:

- *Design*: Allows you to choose one of the following options:

  - *Small:* The component displays a single line containing a label and value.
  - *Large*: The component displays multiple lines with one value and up to three labels.
  - *Auto size*: Similar to the *Large* option, but automatically adjusts the content to fill the entire component.

- *Alarm state coloring*: Allows you to select one of the following options to determine how alarm coloring is displayed:

  - *LED*: The alarm color is displayed by a circular LED to the left of the first label.
  - *Line*: The alarm color is displayed by a bar along the left side of the component.
  - *Text*: The text color of the value matches the alarm color.
  - *Background*: The background of the component displays the alarm color. If this option is selected, an additional option, *Automatically adjust text color to alarm color*, can be selected to make sure the text color is adapted if necessary.
  - *None*: No alarm color is displayed.

#### Dashboard app: New setting to configure number of dashboard columns \[ID_26530\]

It is now possible to configure in how many columns components can be displayed in a dashboard. You can do so via the new *Number of columns* option in the settings of a dashboard. The maximum number of columns is 50. If you change the number of columns to a lower number and the columns currently contain components, a warning will be displayed, saying that components may be relocated.

In addition, when a dashboard is being edited, a new button is now available in the dashboard header bar that allows you to show or hide the grid lines in the dashboard while you are in edit mode.

#### Dashboards app: New Spectrum Analyzer component \[ID_26606\]\[ID_26675\]\[ID_26734\]\[ID_26820\] \[ID_26927\]

When you create or update a dashboard, you can now add Spectrum Analyzer components.

A Spectrum Analyzer component, linked to a Spectrum Analyzer element, will open a new session based on the last session that was closed by the user in DataMiner Cube.

Also, in the DATA pane, you can select a spectrum preset and, for example, have it act as a filter. It is even possible to link a drop-down feed component to a Spectrum Analyzer component and use it to select the preset to be used in the latter.

##### Trigger action to open a new dashboard

For Spectrum Analyzer components, a *Triggers* tab is available in the pane on the right. This tab allows you to configure that another dashboard should be opened when the spectrum graph is clicked. To do so, make sure *Enable trigger* is activated, and select the trigger action *Open dashboard*. Then select the dashboard that should be opened and specify whether it should be opened in a pop-up window, in the current tab (replacing the dashboard that was clicked) or in a new tab.

When the specified dashboard is opened, the Spectrum Analyzer component will pass its data (a spectrum element and optionally a spectrum preset) to that dashboard. The opened dashboard can then use that data as if it was specified in the URL.

#### Dashboards app: Advanced settings \[ID_26659\]

Component settings can now be marked as advanced. When marked as such, they will only be displayed when you opened the Dashboards app with the following URL argument:

- “showAdvancedSettings=true”

#### Dashboards app: Optimization of component visualizations \[ID_26751\]

After adding a component to a dashboard, you can apply a specific visualization. The list of available visualizations has now been optimized.

Up to now, the list of available visualizations depended on the type of component. From now on, that list will instead depend on the type of data linked to the component. In other words, the list will contain all visualizations that are capable of visualizing the type of data currently linked to the component.

The order of the listed visualization has also been optimized. First in the list will be the most obvious ones to visualize the data in question, followed by all other available visualizations sorted alphabetically by name.

Hovering over a visualization will preview the component.

#### Dashboards app: State timeline component \[ID_26772\]

The state timeline component visualizes the alarm state changes over time of a parameter, element or service. By default, it shows a timeline for the last 24 hours, but a time range feed can be added to set the component to a different time range.

To configure the component:

1. Apply an element, service, or protocol/element parameter data feed.

2. Add a filter if necessary:

    - If the component uses a protocol parameter data feed, add an element filter feed.
    - If the component uses a table or column parameter data feed, add an index filter feed.

3. Optionally, add a Time range component to the dashboard and configure the state timeline component to use it as a filter feed.

#### State/Gauge/Ring components now able to show multiple items for several types of feeds \[ID_26780\]

In the Dashboards app, it is now possible to show multiple states with the same *State*, *Ring* or *Gauge* component, even if elements, services, views or redundancy groups are used as the data feed. Previously, this was only supported for parameter feeds.

For the *State* component, the *Layout flow* options in the *Layout* panel allow you to select whether the different states should be displayed in rows or columns. If they are displayed in rows, they will displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.

For the *Ring* and *Gauge* component, if parameter feeds are used, additional options in the layout panel allow you to configure whether the different parameters are displayed next to each other or below each other, and how many rows and columns of parameters can be displayed at the same time. These options are not available for other types of feeds; for those only one item is displayed at the same time and you need to scroll to see the next item.

#### Dashboards app: Dashboards created by users will now be included in DataMiner backup packages \[ID_26836\]

When, in DataMiner Cube, you take a backup, all dashboards created by users (i.e. all files stored in C:\\Skyline DataMiner\\Dashboards) will now be included in the backup package if you selected either “full backup” or “full backup without database”.

### DMS Automation

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

- Users need the *Modules \> Automation \> Edit* permission to be able to upload Automation script dependencies.

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
///    If true:
///    - The app will be forcefully uninstalled, even if the uninstall script fails.
///    - If the uninstall script exits with an exception or could not be run, no exceptions will be thrown.
/// </param>
/// <exception cref="AppUninstallationFailedException">
///    This exception will be thrown in the following cases:
///    - When the specified app is not installed.
///    - When the uninstall script could not be run due to syntax errors.
///    - When the uninstall script exited with an exception.
/// </exception>
/// <exception cref="DataMinerException">
///    This exception will be thrown in all other cases when something goes wrong.
/// </exception>
/// </summary>
///
public void UninstallApp(AppID appId, bool force)
```

##### Uninstall script

Inside every app package, an uninstall script named *uninstall.xml* should be available in the Scripts folder.

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

- When you install an app with the *AllowMultipleInstalledVersions* option set to false, the uninstall script of that app (if present) will automatically be triggered. Also, the uninstall will be executed forcefully, meaning that the app will be removed even when the script fails.

- When an app is being uninstalled, its AppInstallState will be set to BUSY_UNINSTALLING, and if anything goes wrong during the uninstall (and the uninstall was not executed forcefully), its AppInstallState will be set to CORRUPTED.

- An app of which the AppInstallState is set to BUSY_INSTALLING can only be uninstalled forcefully.

- If an uninstall script requires any external DLL files, those can be placed in the C:\\Skyline DataMiner\\Scripts\\UninstallDependencies folder. During an uninstall operation, the dependencies will then automatically be referenced in the uninstall script.

> [!NOTE]
> The DataMiner SLNetClientTest tool now also supports uninstalling app packages. See *Advanced \> Apps \> App Packages*.

#### Automation: Tree view control for interactive Automation scripts \[ID_26840\]\[ID_27041\]

It is now possible to add a tree view control in an interactive Automation script. However, note that Automation scripts with tree view controls are currently only supported in the DataMiner mobile apps. These are not yet supported in DataMiner Cube.

To define a tree view control, create a UIBlockDefinition of type TreeView and add each item of the tree view as a TreeViewItem to the TreeViewItems property. It is not required to fill in the InitialValue or Value of the UIBlockDefinition, as that value is determined based on the TreeViewItem collection.

Each TreeViewItem has the following properties:

- *DisplayValue*: The string value displayed for this item in the UI.

- *KeyValue*: The string value that is used as a key to retrieve the selected state of the item. This is the value that will be used in the destination variable.

- *IsChecked*: Boolean that allows you to have an item selected by default. Do not fill in this property for TreeViewItems that have child items. The selection of such a parent item depends on the selected child items. If some of the child items are selected, the parent item is only partially selected and its value will not be included in the destination variable. If all child items are selected, the parent item is automatically also selected.

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

### DMS Mobile apps

#### HTML5 apps: Sidebar settings will now be stored per user account in the browser's local storage \[ID_26719\]

For each of the HTML5 apps (Monitoring, Jobs, etc.), the size and expand/collapse state of the sidebar will now be stored per user account in the browser’s local storage.

#### Jobs app: Job domains can now be hidden \[ID_26813\]\[ID_26814\]

Up to now, in configuration mode, when you edited a job domain, it was only possible to change the name of that domain. From now on, it is also possible to hide the domain.

#### Jobs app: Duplicating domains \[ID_26844\]

In configuration mode, next to the *New*, *Edit* and *Delete* buttons on the right of the job domain selection box, there is now also a *Duplicate* button. Clicking that button will allow you to select one of the following options:

- **Share sections across domains**: Creates a new domain that shares its sections with the original domain.

  > [!NOTE]
  > Changes made to the sections of the new domain will also be applied to the sections of the original domain (except changes made to the *Color*, *Icon* and *Allow multiple instances* properties of a section).

- **Create copies of the sections**: Creates a new domain by duplicating the entire original domain, including its sections.

  > [!NOTE]
  > Changes made to the sections of the new domain will not be applied to the sections of the original domain.

When the duplication operation has finished, you will automatically be redirected to the newly created domain.

As a result of the above-mentioned changes, adding a new section to a domain has also been changed. The *Add section definition* window now has a *New* tab and an *Existing* tab.

- **New**: Use this tab if you want to create a new section from scratch.
- **Existing**: Use this tab if you want to add an existing section to the domain in question. In this case, apart from having to select the section to be added, you will also have to indicate whether you want to:

  - share the section with the other domain(s) containing that section, or
  - make a separate copy of the section (with a new name).

##### New web methods

- **DuplicateJobsDomain(string connection, DMAJobDomain domain, string domainID, bool byRef)**

  This method will duplicate a job domain, either by reference or by hard copy, and return the ID of the new job domain if the duplication operation was successful.

  - If the *byRef* parameter is set to false, the method will create an entire new job domain that is in no way linked to the original job domain.
  - If the *byRef* parameter is set to true, the method will create a new job domain that shares its sections with the original job domain.

- **DuplicateJobsSectionDefinition(string connection, string domainID, string sourceDomainID, DMASectionDefinition sectionDefinition, bool byRef)**

  This method will duplicate a job section definition, either by reference or by hard copy.

  - If the *byRef* parameter is set to false, the method will add an entire new job section definition to the job domain specified by *domainID*. This job section definition will no way be linked to the original job section definition in the domain specified by *sourceDomainID*.
  - If the *byRef* parameter is set to true, the method will link the existing job section definition specified by *sectionDefinition* to the job domain specified by *domainID*. This same job section definition will then be shared between the two job domains.

- **GetAffectedJobDomains(string connection, string sectionDefinitionID)**

  This method will return the names of all the job domains that contain the job section definition specified by *sectionDefinitionID*.

### DMS Service & Resource Management

#### Mediated virtual functions \[ID_24657\]\[ID_25046\]\[ID_25193\]\[ID_25271\]\[ID_25401\]\[ID_25651\] \[ID_26078\]

Server-side support has been added for mediated virtual functions.

To configure mediated virtual functions, do the following:

1. For every parameter, every column and/or every cell you want to see in the virtual function element, create a profile parameter.
1. If, in the virtual function element, the value of a profile parameter should be transformed, then add a mediation snippet to that profile parameter.
1. Create a profile definition for the node of the function and a profile definition for every interface of the function.

   - In a profile definition, you can group profile parameters in tables if you want them to be shown as tables in the virtual function element.

1. Create a virtual function definition. In it, you can define the following:

   - The profile definition for the node.
   - The amount and type of interfaces and their profile definition.
   - The protocols supported. For every supported protocol, the following can to be defined:

     | Items             | Description                                                                               |
     |-------------------|-------------------------------------------------------------------------------------------|
     | Entry-point table | The (optional) table that holds the multiple instances of a function in a single element. |
     | Interface filters | The (optional) additional table filters that have to be used for the interface tables.    |

   Next to that, you can also define what the virtual protocol should look like:

   - Define the pages you want to see in the protocol.
   - Define which profile parameters from the profile definitions of the node/interfaces should be on each page.
   - Define which tables from the profile definitions of the node/interfaces should be on each page.

   When you save the virtual function definition, a virtual function protocol is generated (with type “virtual-function”) and the metadata associated with that protocol is stored in an automatically created “virtual function protocol meta” object. That object will contain the following information:

   - The IDs of the read/write parameters that were generated for the different profile parameters and nodes/interfaces.
   - The tables that were generated.
   - Profile parameter information (type, ...)

   This protocol metadata will be used:

   - to resolve IDs of generated parameters when binding a resource
   - to be able to re-use parameter IDs when a new version of the protocol is generated
   - to validate the new versions of the generated protocol

1. Create a virtual function resource with a specific virtual function definition.

   The virtual function element with automatically be created using the generated virtual function protocol.

1. Bind the virtual element to an element by updating the virtual resource:

   - Specify the element ID.
   - Specify the entry point table index (if an entry point table was defined).

   All the parameters and tables of the virtual function element, which were set to “not-initialized/empty”, will now be set to the replicated/mediated values of the bound element.

##### Virtual function definitions

Virtual function definitions can be used on service definition nodes. They can be managed by means of the ProtocolFunctionHelper.VirtualFunctionDefinitions API.

Virtual function definitions are stored in Indexing Engine under the cvirtualfunctiondefinition index. When you create a database backup, they will automatically be included in the package when the *Include SRM in backup* option is enabled.

All logging with regard to virtual function definitions will be added to SLFunctionManager.txt.

##### Virtual function protocol metadata

Virtual function protocol metadata is stored in Indexing Engine under the cvirtualfunctionprotocolmeta index. When you create a database backup, this metadata will automatically be included in the package when the *Include SRM in backup* option is enabled.

##### Virtual function resources

A virtual function resource is an extension of a normal resource. It has the following additional properties:

| Property | Content |
|--|--|
| VirtualFunctionID | The ID of the VirtualFunctionDefinition of which it is an instance. |
| PhysicalDeviceDmaId | The ID of the element that is currently bound to the VirtualFunctionElement. |
| PhysicalDeviceElementId |  |
| ElementName | The name of the VirtualFunctionElement that will be created. If none is specified, the resource name will be used instead. |

Virtual function resources can be used on ReservationInstances and ServiceReservation-Instances, and can be managed by means of the ResourceManagerHelper API. They are saved in Resources.xml.

All logging with regard to virtual function resources will be added to SLResourceManager.txt.

##### Logging with regard to element binding

Logging with regard to element binding will be added to the following log files:

- SLResourceManager.txt can contain information about errors that occurred during the element orchestration or during binding/unbinding operations.
- SLFunctionManager.txt can contain information about errors that occurred during binding/unbinding operations. If the resource update request was sent from another agent than the one hosting the virtual function element, then the log file of the hosting agent might contain the error. You might also have to check SLDataMiner.txt.
- SLProfileManager.txt can contain information about errors that occurred during the mediation step of the parameter replication.
- The log file of the virtual function element can contain information about errors that occurred during binding, unbinding or replication operations in general.

#### Tracking the rebinding history of VirtualFunctionResources \[ID_25307\]

The rebinding history of VirtualFunctionResources will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-resource”).

A HistoryChange records contains the following fields:

| Field | Description |
|--|--|
| ID | ID of the HistoryChange record. |
| SubjectId | ID of the VirtualFunctionResource that was changed. |
| Time | Time at which the change was made. |
| FullUsername | Full user name of the person who made the change. If the change was triggered by the DataMiner System, this will be “DataMiner”. |
| DmaId | ID of the DataMiner Agent on which the change was triggered. |
| Changes | List of changes that were made. In case of a VirtualFunctionResource, this can be a RebindChange containing the following information about the binding:<br> - BindBefore (the element ID before the rebind)<br> - BindAfter (the element ID after the rebind)<br> - the type of change (Create/Update/Delete) |

Using the HistoryHelper#Resources API you can read all the history objects for resources. See the following example:

```csharp
ResourceID myResourceID = …
var query =HistoryChangeExposers.SubjectID.Equal(someResourceID.ToFileFriendlyString()).OrderBy(HistoryChangeExposers.Time);
```

> [!NOTE]
>
> - If, for some reason, tracking changes to VirtualFunctionResources would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a backup is configured to include the Service & Resource Management module, this will also include the chistory-resource table.
> - When a VirtualFunctionResource is deleted, all HistoryChange records associated with this VirtualFunctionResource will also be deleted.

> [!NOTE]
> Up to now, when a ReservationInstance was deleted, all HistoryChange records associated with this ReservationInstance were deleted, and a new HistoryChange record was added to indicate when the ReservationInstance was deleted and by whom.
>
> From now on, no new HistoryChange record will be added any longer to indicate when the ReservationInstance was deleted and by whom.

#### Possibility to add attachments to booking instances \[ID_26784\]

To support adding attachments to booking instances (i.e. ReservationInstance objects), a new ReservationInstanceAttachments property is now available in the ResourceManagerHelper. This property allows you to manage booking attachments using the following methods:

| Method                                                                                | Function                                                                         |
|---------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
| Add(ReservationInstanceID reservationInstanceID, string fileName, byte\[\] fileBytes) | Add an attachment to a booking                                                   |
| List\<string> GetFileNames(ReservationInstanceID reservationInstanceID)               | Retrieve the names of all the attachments added to the specified booking.        |
| Delete(ReservationInstanceID reservationInstanceID, string attachmentName)            | Deletes the attachment with the specified name from the specified booking.       |
| byte\[\] Get(ReservationInstanceID reservationInstanceID, string attachmentName)      | Retrieves the content of the attachment with the specified name as a byte array. |

> [!NOTE]
>
> - If a booking is deleted, all its attachments will be deleted as well. They will not be recoverable.
> - The maximum size of booking attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - Manipulating booking attachments requires security permissions on the ReservationInstance. If a SecurityViewId is specified, the view permission on the view is required to retrieve or download attachments, and the write permission on the view is required to add or delete attachments.
> - All booking attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.

### DMS tools

#### StandAloneBpaExecutor now included in tools folder \[ID_26261\]

The StandAloneBpaExecutor tool, which can be used to execute BPA (Best Practice Analysis) tests, is now by default included in the folder C:\\Skyline DataMiner\\Tools of a DMA.

#### DMS Alerter: New 'Set the alarm as read in Cube after the alarm has been acknowledged' setting \[ID_26579\]

When, in DMS Alerter, the new *Set the alarm as read in Cube after the alarm has been acknowledged* setting is enabled, each time you acknowledge an alarm in DMS Alerter, that same alarm will automatically be marked as “read” in DataMiner Cube.

> [!NOTE]
> This feature will only work if one and the same user is running both DMS Alerter and DataMiner Cube on the same client machine.

#### DMS Alerter: New 'Hide the comment window when acknowledging an alarm' setting \[ID_26621\]

A new setting, *Hide the comment window when acknowledging an alarm*, is available in the Alerter app. If this setting is enabled, you can take ownership of an alarm in an Alerter pop-up balloon without having to add a comment.
