---
uid: General_Main_Release_10.0.0_new_features_4
---

# General Main Release 10.0.0 - New features (part 4)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> From DataMiner 10.0.0/10.0.2 onwards, DataMiner Service & Resource Management also requires DataMiner Indexing.

### DMS Reports & Dashboards

#### Reporter: New method that allows sending an email from inside a custom report \[ID_20031\]

Reporter now has a method that allows sending an email from inside a custom report:

```csharp
template.sendEmail(string toAddress, string toFriendly, string fromAddress, string fromFriendly, string subject, string message, bool isHtml);
```

If *fromAddress* is empty, then the email address specified in System Center \> Agents \> System \> System Info will be used.

#### Reporter: Update 'Reservation' to 'Booking' and new booking list template component \[ID_21998\]

In the Reporter app, the term “Reservation” has been replaced by “Booking” to be in line with the rest of the Cube UI. In addition, in the template builder, the “Bookings” component can now be configured to show a list of bookings.

#### New Dashboards app \[ID_19638\]\[ID_20719\]\[ID_20739\]\[ID_21182\]\[ID_21199\]\[ID_21213\]\[ID_21220\] \[ID_21223\]\[ID_21234\]\[ID_21263\]\[ID_21340\]\[ID_21437\]\[ID_21706\]\[ID_21848\]\[ID_21932\]\[ID_21957\] \[ID_22072\]\[ID_22117\]\[ID_22273\]\[ID_22325\]\[ID_22517\]\[ID_22672\]\[ID_22761\]\[ID_22855\]\[ID_22874\] \[ID_23080\] \[ID_23097\]\[ID_23131\]\[ID_23161\]\[ID_23173\]\[ID_23176\]\[ID_23245\]\[ID_23249\]\[ID_23293\] \[ID_23401\]\[ID_23481\]\[ID_23546\]\[ID_23563\]\[ID_23671\] \[ID_23692\]\[ID_23747\]\[ID_23754\]\[ID_23839\] \[ID_24171\]

A completely redesigned Dashboards app is now available. This new app features HTML5 responsive design, with the ability to run across desktops, tablets and mobile platforms. It allows you to create and use interactive dashboards more easily and intuitively.

You can access the app via the link `https://[MyDataMiner]/dashboard` or `http://[MyDataMiner]/dashboard`, depending on your setup. We recommend to use Google Chrome to access the app. Mozilla Firefox and Microsoft Edge are also supported.

The new app consists of the following main areas:

- A header bar with a search box and a user icon. Clicking the user icon opens a menu where you can find user information and app version info, log out, or access the app settings. Via the app settings, you can manage dashboard themes.

- A navigation pane listing all the available dashboards in the system, sorted into folders. The navigation pane has a recent items tab that lists the dashboards you recently used. Via the context menu of the navigation pane, you can copy or move a dashboard, delete or rename a dashboard or dashboard folder, import an example dashboard, add a new dashboard or create a new folder.

- The main area of the app, which displays the currently selected dashboard. If no dashboard is selected, buttons are available that allow you to quickly create a new dashboard, either starting from scratch or from an example, or to open a recently used dashboard. If a dashboard is selected, buttons at the top of the dashboard allow you to refresh the displayed data or go to editing mode.

> [!NOTE]
> If the app is viewed using a mobile device, no options to create or edit dashboards will be available.

##### Creating a new dashboard

To create a new dashboard, you can either start from scratch with a blank dashboard, or modify an example dashboard.

There are several ways to start creating a new blank dashboard:

- On the home page, click *Start with a new blank dashboard*.

- Click the “...” icon in the top-right corner of the navigation pane, and select *New dashboard*.

- Select a folder or dashboard in the list of dashboards on the left and select *New dashboard* in the right-click menu, or click the *New dashboard* button in the header bar.

    Whichever way you choose, a pop-up window will be opened where the name of the dashboard and the folder containing the dashboard can be specified. Once the dashboard has been created, you can start editing it.

To create a dashboard based on an example, you can either first import the example via the context menu of the navigation pane and then edit it, or click *Start with an example dashboard* on the home page of the app.

> [!NOTE]
> The following characters are not allowed in the name of a dashboard or dashboard folder: `/ \ : ; * ? < > | °`

##### Editing a dashboard

If a dashboard is selected in the navigation button, you can enter edit mode by clicking the edit button in the top-right corner. To stop editing, click the button in the same location.

In edit mode, you can adapt the dashboard in the following ways:

- To customize the default dashboard layout, go to the *Layout* tab while no component is selected. In this tab, you can customized the dashboard theme and default component settings, such as the title, borders, etc. You can also a custom theme for later use or load a saved theme.

- To customize the general dashboard settings, go to the *Settings* tab while no component is selected. The settings that can be customized include the dashboard name, WebSocket communication and polling timers.

- To add a new component, see “Adding a component” below.

- To edit a component that has already been added to the dashboard, select the component and configure it in the same way as when you add a new component.

- To duplicate one of the existing components, hover the mouse pointer over the component and click the duplicate icon.

- To remove one of the existing components, hover the mouse pointer over the component, click the recycle bin icon, and click *Yes* to confirm the removal.

- To move a component, hover the mouse pointer over the component, click and hold the move icon, and then drag the component to a different position on the dashboard.

- To resize a component, move the mouse pointer to the edge of the component and drag it until the component has the desired size.

##### Adding a component

There are several ways to add a new component. First you need to indicate where the component should be located. You can do so in the following ways:

- By dragging a visualization from the visualizations pane on the left onto the dashboard.
- By dragging a data feed from the data pane on the right onto the dashboard.

The component then needs to be further configured. As soon as you click on the component or hover the mouse pointer under the component, a quick menu will provide access to quick configuration actions, allowing you to select a visualization or data feed on the fly. This quick menu also allows you to move the component, duplicate the component or delete it.

Once the visualization and data feed(s) have been selected, you can fine-tune the way the component is displayed in the *Layout* and *Settings* panes on the right.

##### Overview of available dashboard components

Currently, the following components can be added to a dashboard.

- General

    | Component     | Description                                                                                                                                                                                       |
    |-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Block           | Acts as a divider between other components.                                                                                                                                                       |
    | Clock (analog)  | Shows an analog clock that indicates either the local time or the DataMiner time (i.e. the time of the DataMiner Agent to which you are connected).                                               |
    | Clock (digital) | Shows a digital clock that indicates either the local time or the DataMiner time (i.e. the time of the DataMiner Agent to which you are connected).                                               |
    | Generic map     | Displays a DataMiner map.                                                                                                                                                                         |
    | Group\]         | Displays a group of components. This allows you to display the same set of components for each item in a group feed, for example for each parameter in a group of parameters.                     |
    | Image           | Shows an image. Note: This component not only allows you to select an image that was uploaded earlier, it also allows you to upload new images.                                               |
    | Text            | Shows a block of static text. In the *Layout* tab, you can configure the styling of the text (font, font size, bold, italic, underline, horizontal alignment). |
    | Web             | Displays either a block of static HTML or a web page.                                                                                                                                             |

- States

    | Component | Description                                                                                                                                                                                               |
    |-------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Gauge       | This component displays the value of one or more numeric parameters with a gauge.                                                                                                                         |
    | Ring        | This component displays the name and, if applicable, the value of a DataMiner object within a colored ring matching the state of the object. This can be an element, a view, one or more parameters, etc. |
    | State       | This component displays the state, name and, if applicable, the value of a DataMiner object. This can be an element, a view, one or more parameters, etc.                                                 |

- Tables

    | Component     | Description                                                                                                                                                                                                                      |
    |-----------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Parameter table | Displays a data table of an element, optionally filtered by table indices or using a dynamic table filter.                                                                                                                       |
    | Pivot table     | Displays a status report for a number of parameters of the elements using the selected protocol and protocol version. Via the ... button in the top-right corner of the component, the status report can be exported to CSV. |

- Charts

    | Component            | Description                                                                                                                                                                                                                     |
    |------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Bar chart              | Displays the elements or services in a view that caused the most or the least alarms in a selected time range and were in an alarm state for the longest or the shortest period of time.                                        |
    | Bar chart (horizontal) | Displays the same information as a regular bar chart, but with horizontal bars.                                                                                                                                                 |
    | Line chart             | Displays a trend graph. If graphs are displayed in this component, you can configure grouping by parameter, by element, by table index (if relevant) or by all of the above together. Also, a percentile line can be added. |

- Other

    | Component      | Description                                                                                                                                                                                            |
    |------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Parameter page   | Displays a data page of an element.                                                                                                                                                                    |
    | Trend statistics | Shows the minimum, average and maximum values of one or more trended parameters.                                                                                                                       |
    | Visual overview  | Shows a Visio file linked to an element, a service or a view. Note that if this Visio file contains a shape linked to an Automation script, that script will be executed when you click the shape. |

- Feeds

    | Component | Description                                                                                                                                                                     |
    |-------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | CPE         | Allows the user to make a filter selection for a particular CPE Manager element and CPE chain.                                                                                  |
    | Drop-down   | This feed allows the user to select an item in a drop-down list. The selectable items can be based on any data feed.                                                            |
    | List        | This feed allows the user to select one or more items in a list. The selectable items can be based on any data feed.                                                            |
    | Parameter   | This feed allows the user to select one or more parameters. Default column order: Parameters, Elements, Indices. Note: The element list will load per page of 100 items. |
    | Time range  | This feed allows the user to specify a time range.                                                                                                                              |
    | Tree        | This feed allows the user to select one or more items in a tree view. The selectable items can be based on any data feed.                                                       |

##### Specifying data input in a dashboard URL

If a dashboard has been configured with one or more feed components, it is possible to specify data input for these feeds in a dashboard URL. This way, you can immediately make the dashboard display specific data when it is opened.

Within the dashboard URL, the following objects can be specified:

- Elements (using the argument *elements*): By specifying the DMA ID and element ID.

- Services (using the argument *services*): By specifying the DMA ID and service ID.

- Redundancy groups (using the argument *redundancy groups*): By specifying the DMA ID and redundancy group ID.

- Parameters (using the argument *parameters*):

  - By protocol: By specifying the protocol name, protocol version and protocol ID.

  - By element: By specifying the DMA ID, the element ID, the parameter ID and optionally the parameter index.

- Views (using the argument *views*): By specifying the view ID.

- SLAs (using the argument *slas*): By specifying the DMA ID and element ID.

- DataMiner Agents (using the argument *agents*): By specifying the DMA ID.

- Protocols (using the argument *protocols*): By specifying the protocol name and protocol version.

- Data Display pages:

  - By protocol (using the argument *protocol pages*): By specifying the protocol name, protocol version and page name.

  - By element (using the argument *parameter pages*): By specifying the DMA ID, the element ID and the page name.

- Indices (using the argument *indices*): By specifying the index.

- Timespans (using the argument *time spans*): By specifying the start and end timestamp.

- A CPE filter (using the argument *cpes*): By specifying the DMA ID, the element ID, the field PID, the table PID and the value.

Within one object, use a slash (“/”) as the separator between its components. If different objects of the same type are specified, use “%1D” as the separator between the objects.

For example:

- `http://myDma/Dashboard/#/myDashboard?elements=1/1%1D1/2&views=1&parameters=1/1/1%1D1/1/2/myIndex`

    This URL opens a dashboard in which the elements 1/1 and 1/2, view 1 and parameters 1/1/1 and 1/1/2/myIndex are selected by default.

- `http://myDma/Dashboard/#/myDashboard?time%20spans=1549753200000/1549835265007`

    This URL opens a dashboard with a time range filter from 1549753200000 to 1549835265007.

> [!NOTE]
>
> - If, in the *timespans* argument, you specify “/1531814522191” (i.e. leaving out the first timestamp), this will be interpreted as “from midnight to X”.
> - If, in the *timespans* argument, you specify “1531810522191” (i.e. leaving out the second timestamp), this will be interpreted as “from X to now”.

##### New methods added to Web Services API v1

A number of new methods have been added to the Web Services API v1 to support the new app. This includes the following methods:

- GetActiveAlarmCountForElement
- GetActiveAlarmCountForService
- GetActiveAlarmCountForView
- GetAlarmCountForElement
- GetAlarmCountForService
- GetAlarmStatesForElement
- GetAlarmStatesForParameter
- GetAlarmStatesForService
- GetMonitoredParametersForElement
- GetMonitoredParametersForService
- GetParametersForProtocolFiltered
- GetTrendDataCustomTimespanForParameter
- GetTrendStatisticsForParameter
- GetTrendStatisticsForService
- IsFeatureAvailable

##### Configurable maxJSONLength setting

Up to now, the maxJSONLength setting, which is used when serializing and deserializing WebSocket messages, was always set to 4MiB. This setting is now configurable.

To set maxJSONLength to a specific value, do the following:

1. Open the *Web.config* file located in the *C:\\Skyline DataMiner\\Webpages\\API* folder.

2. Make sure that the *configuration.appSettings* section contains an element similar to the following one:

    ```xml
    <add key="maxJsonLength" value="?10485760?" />
    ```

    Note that the value should be specified in bytes. In the example above, maxJSONLength was set to 10 MiB.

> [!NOTE]
> If no maxJSONLength value is specified in the Web.config file, this setting will be set to 20 MiB by default.

#### Reporter: Accessing parameter values of paused elements \[ID_23829\]

In Reporter, status queries and parameter pages of elements are now able to access the parameter data of elements that are paused.

Example of how to access parameter data of paused elements in a custom report:

```csharp
var iOptions = O_SQ_INC_ELEMENTS_PAUSED;
template.insertStatusQueryBlock(null, null, iOptions);
```

#### Dashboards app: Separator used in CSV exports based on CSV separator setting in Cube \[ID_24161\]

The separator used in CSV exports from the Dashboards app is based on the “CSV separator” setting in Cube. If this setting cannot be retrieved, in Internet Explorer the system will fall back to the Windows regional settings, while other browsers will fall back to the local browser settings.

### DMS Automation

#### .NET Compiler Platform now used for C# Automation scripts \[ID_20746\]

All C# Automation scripts will now be validated and compiled using the .NET Compiler Platform (also known as "Roslyn"), which will enable the use of syntax of C# version 6.0 and higher.

#### New IDPResource and IDPManagerHelper class \[ID_20892\]

A new *IDPResource* and *IDPManagerHelper* class are now available in DMS Automation. The *IDPResource* class defines resources that can be used with an IDP license, and the *IDPManagerHelper* class allows you to manage these resources.

IDP resources can only be created if an IDP license is present. Such a license allows you to add up to 10 IDP resources, as well as to create booking instances and resource pools using IDP resources. The booking instances using IDP resources are not taken into account for the SRM volume license.

#### Radio button lists can now be added to interactive Automation script dialog boxes \[ID_21475\]

It is now possible to add radio button lists to an interactive Automation script dialog box.

First, create the list:

```csharp
UIBlockDefinition blockRadioButtonList = new UIBlockDefinition();
blockRadioButtonList.Type = UIBlockType.RadioButtonList;
```

Then, add buttons to the list:

```csharp
foreach (string sOption in dropDownOptions)
{
    uibDef.AddRadioButtonListOption(sOption);
}
```

> [!NOTE]
> When no initial value is passed to this list, no radio button will be selected by default.

#### Password boxes can now be added to interactive Automation script dialog boxes \[ID_21518\]

It is now possible to add password boxes to an interactive Automation script dialog box.

```csharp
UIBlockDefinition blockPasswordBox = new UIBlockDefinition();
blockPasswordBox.Type = UIBlockType.PasswordBox;
```

Optionally, you can set the HasPeekIcon property to display an icon that, when clicked, will allows you to display the value inside the password box.

```csharp
blockPasswordBox.HasPeekIcon = allowPeek;
```

#### Dialog box of an interactive Automation script can now have a custom title \[ID_21552\]

When defining a dialog box of an interactive Automation script, you can now specify a custom title.

Example:

```csharp
UIBuilder uibDialogBox = new UIBuilder();
uibDialogBox.Title = “My dialog box title”;
```

#### AlarmTemplateHelper \[ID_21878\]

The AlarmTemplateHelper will allow Automation scripts to manipulate alarm templates.

##### Types of methods and calls

The AlarmTemplateHelper contains four types of methods:

- Get (retrieves a row)
- Delete (deletes a row)
- Merge (copies a row to another template)
- Update (updates a row)

Each of the above-mentioned types of methods has three possible calls:

- Retrieve/delete/merge/update a single row on the client (e.g. GetAlarmTemplateRow)
- Retrieve/delete/merge/update multiple rows on the client (e.g. GetAlarmTemplateRows)
- Retrieve/delete/merge/update multiple rows on the DataMiner Agent (e.g. GetAlarmTemplateRowsFromServer)

##### Defining the alarm template and the alarm template rows to be manipulated

Before you send a call, you have to define the alarm template of which you want to retrieve, delete, merge or update rows, and the row(s) to be retrieved, deleted, merged or updated.

- To define the alarm template, you have to create an AlarmTemplateID object with the protocol name, the protocol version and the alarm template name.
- To define the row(s), you have to create one or more AlarmTemplateRowID objects with the parameter ID, the condition name (empty in case of no condition) and the filter (empty in case of no filter).

See the following example:

```csharp
AlarmTemplateHelper helper =new AlarmTemplateHelper(Engine.SLNetRaw.HandleMessages);
var id = new AlarmTemplateID("AlarmTemplate", "Protocol", "1.0.0.0");
var rowId = new AlarmTemplateRowID(1, "condition", "filter");
var rowList = new List<AlarmTemplateRowID> {rowId};
var row = helper.GetAlarmTemplateRowsFromServer(id, rowList);
helper.DeleteAlarmTemplateRowsOnServer(id, row);
```

> [!NOTE]
>
> - A row will be returned as an AlarmTemplateRow object containing the AlarmTemplateRowID, all parameter values (in a GetAlarmTemplateResponseMessage) and the full condition.
> - When a row is deleted, the condition will only be deleted if it is not used by any other parameter.
> - When an existing row is merged, the parameter values will be updated, and the parameter will have the same index in the list.
> - When a new row is merged, it will be added at the bottom of the list.
> - Only parameter rows that are set to “Included” can be extracted and merged.

##### Exceptions

The AlarmTemplateHelper can throw the following exceptions:

| Exception                                   | Cause                                                                                                                                     |
|---------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| ArgumentNullException                       | “null” values were passed to the method.                                                                                                  |
| ConditionDoesNotExistException              | The condition specified in the AlarmTemplateRow could not be found in the alarm template.                                                 |
| ConditionMergeException                     | A condition used in a merge call has the same name as an existing condition with a different content.                                     |
| InvalidAlarmTemplateRowException            | The AlarmTemplateRow contains an ID object that does not match the parameter ID, the parameter filter or the condition in the row object. |
| NoAlarmTemplateRowToUpdateException        | The AlarmTemplateRow to be updated does not exist.                                                                                        |
| ParameterDoesNotExistException              | The parameter specified in the AlarmTemplateRow could not be found.                                                                       |
| RetrievingAlarmTemplateFromServerException | The alarm template could not be retrieved from the server.                                                                                |

> [!IMPORTANT]
> When creating or updating an alarm template row for a table column parameter, also specify the filter (default: “\*”). Setting the filter value to “” or null will prevent alarms from being triggered.

#### Passing information from a subscript to the parent script \[ID_21952\]

In an Automation script, it is now possible to pass information from a subscript to the parent script.

##### Retrieving a dictionary with key/value pairs from a subscript

In the parent script, prepare the subscript using the ScriptOptions object, and start it by running StartScript(). Once the subscript is running, you can then use GetScriptResult() to retrieve information from the subscript and store it in e.g. a dictionary\<string, string>. See the following example.

```csharp
Dictionary<string, string> result = scriptOptions.GetScriptResult();
```

##### Adding key/value pairs to the dictionary before it is passed to the parent script

In a subscript, use the following line to add a key/value pair to the dictionary before it is passed to the parent script.

```csharp
engine.AddScriptOutput("key", "value");
```

#### Service & Resource Management: Adding custom text to a booking block on the timeline \[ID_22068\]

By default, on the booking timeline, booking blocks display the name of the booking. Now, it is also possible to override this default name with custom text using the *Visual.BlockContent* property. See the following example.

```csharp
...
public void Run(Engine engine)
{
    var from = DateTime.UtcNow.Date.AddHours(8);
    var until = DateTime.UtcNow.Date.AddHours(16);
    var reservation =new Skyline.DataMiner.Net.ResourceManager.Objects.ReservationInstance(new TimeRangeUtc(from, until));
    reservation.ID = new Guid("{47CF35C2-C265-447A-A01C-FEF72881C99F}");
    reservation.Status = ReservationStatus.Confirmed;
    reservation.Name = "My First Booking";
    reservation.Properties.Add(new KeyValuePair<string, object>("Visual.BlockContent", "*** custom block text ***\r\nThe time is now " + DateTime.UtcNow));
    var msg = new SetReservationInstanceMessage(reservation);
    engine.SendSLNetSingleResponseMessage(msg);
}
...
```

> [!NOTE]
> The value of the Visual.BlockContent property can be a multiline, but take into account that half of the block height is reserved for displaying subbookings or event markers.

#### Finding an interactive client by user cookie \[ID_22227\]

In Automation scripts and QActions, it is now possible to find an interactive client by user cookie instead of by user name.

General syntax of the FindInteractiveClient method:

```csharp
_engine.FindInteractiveClient(string Message, int timeoutTime, string allowedGroups, AutomationScriptAttachOptions options)
```

Example of how to find a client by user cookie:

```csharp
bool ok =_engine.FindInteractiveClient("Some text", 100, "userCookie:" + connection.ConnectionID, AutomationScriptAttachOptions.None);
```

#### Engine.FindElements can now also be used to find enhanced service elements \[ID_22631\]

It is now possible to use the Engine.FindElements method to find enhanced service elements.

To do so, set the *IncludeServiceElements* option to true and add it to the ElementFilter.

> [!NOTE]
> By default, the *IncludeServiceElements* option is set to false.

#### Element.SetParameter and Element.SetParameterByPrimaryKey methods now allow control of information event generation \[ID_22783\]

Both the *Element.SetParameter* and *Element.SetParameterByPrimaryKey* methods now allow you to add an optional boolean indicating whether an information event should be generated when the parameter is set.

```csharp
void SetParameter(int pid, object value, bool? generateInformation)
void SetParameter(string name, object value, bool? generateInformation)
void SetParameter(int pid, string index, object value, bool? generateInformation)
void SetParameter(string name, string index, object value, bool? generateInformation)
void SetParameterByPrimaryKey(string name, string index, object value, bool? generateInformation)
void SetParameterByPrimaryKey(int pid, string index, object value, bool? generateInformation)
```

> [!NOTE]
> This works as an override for the option *RunTimeFlags.NoInformationEvents* which can be set with the *Engine.SetFlag* method.

#### C# code blocks can now be compiled as separate libraries \[ID_23504\]\[ID_23699\]

When you add an action of type “C# code” to an Automation script, you can now indicate that you want to have this code block compiled as a separate library.

To do so, open the *Advanced* section, and do the following:

1. Select the *Compile as library with name* option, and

1. Enter a valid library name.

   > [!NOTE]
   >
   > - Library names cannot contain periods (“.”).
   > - An Automation script cannot contain multiple libraries with the same name. Library names must be unique within a particular Automation script.

Once you have compiled a C# code block as a library, you can then import that library into other Automation scripts. To do so, in the *Advanced* section of a C# code block of a given Automation script, do the following:

- In the *Script references* box, enter a reference to the library that you want to import.

  > [!NOTE]
  >
  > - A reference to a library has to contain the script name and the library name, separated by a colon: *ScriptName:LibraryName*
  > - In the above-mentioned two-part reference, the ScriptName part can be replaced by the \[AutomationScriptName\] placeholder, which will be resolved to the name of the script in which the library is defined.

> [!NOTE]
>
> - To optimize performance and use of resources, it is advised to create each library in a separate Automation script. This will minimize the amount of recompilations and DLL generations.
> - When you recompile a library, all Automation scripts and libraries that use that library will also be recompiled.
> - The order of the C# blocks in an Automation script will define the order in which the libraries will be compiled.
> - When you delete an Automation script that contains a library, all files belonging to that library will also be deleted. As a result, you will not be able to recompile any of the depending scripts until you add the deleted library again (with the same script name and library name).
> - When you delete a library C# block from an Automation script and then save the script, the DLL of that deleted library will not be deleted. The DLL file and all references to that deleted library should be removed manually.
> - When you compile a library, its DLL file (and, if compiled in debug mode, its PDB and CS files) are stored in *C:\\Skyline DataMiner\\Scripts\\Libraries*. When the first Automation-related action (i.e. creating, editing or deleting an Automation script, or validating a C# code block) is performed after a DataMiner restart, this folder is cleaned up. After cleaning, of each library it will only contain the most recent version.

#### Interactive Automation scripts: Uploading files from a client computer \[ID_23950\]\[ID_24144\]\[ID_24164\]

In an interactive Automation script, it is now possible to upload files from a client computer.

To allow users to do so, you need to add a file selector control to the script in the following manner:

```csharp
UIBlockDefinition uiBlock = new UIBlockDefinition();
uiBlock.Type = UIBlockType.FileSelector;
uiBlock.DestVar = "varUserUploadedFile";
```

When the UI is then shown using *Engine#ShowUI(...)*, *UIResults* will contain the path to the file:

```csharp
UIResults results = engine.ShowUI(uiBuilder);
string uploadedFilePath = results.GetUploadedFilePath("varUserUploadedFile");
```

When you have selected a file, the actual upload will only start after you click a button to make the script continue (e.g. Close, Next, etc.). Once the upload has started, a *Cancel* option will appear, allowing you to abort the upload operation.

All files uploaded by users will by default be placed in the *C:\\Skyline DataMiner\\TempDocuments* folder, which is automatically cleared at every DataMiner startup.

#### New engine.UnSetFlag method to clear run-time flags \[ID_23961\]

In an Automation script, you can now use the engine.UnSetFlag method to clear the following run-time flags:

- RunTimeFlags.AllowUndef
- RunTimeFlags.NoInformationEvents
- RunTimeFlags.NoKeyCaching

This will allow you to, for instance, perform silent parameter sets. See the following example:

```csharp
public void SetParameterSilent(int pid, object value) {
    // Set the NoInformationEvents flag to disable information events
    _engine.SetFlag(RunTimeFlags.NoInformationEvents);
    // Perform a silent parameter set without triggering an information event
    element.SetParameter(pid, value);
    // Re-enable information events by clearing the NoInformationEvents flag
    _engine.UnSetFlag(RunTimeFlags.NoInformationEvents);
}
```

### DMS Correlation

#### Support for 'elementdesc' placeholder in notifications sent as a result of some triggered correlation rule \[ID_22105\]

When defining a notification message template in the *NotifyTemplates.xml* file, you can use a number of placeholders.

From now on, the “elementdesc” placeholder (i.e. element description) can also be used in templates for notification messages sent as a result of some triggered Correlation rule. Up to now, it could only be used in templates for notification messages that are sent independently (not as a result of some triggered correlation rule).

#### New event to trigger Correlation rules at DataMiner startup \[ID_22622\]

At DataMiner startup, a new event will now signal when the Correlation engine is up and running. This event will make it possible to trigger correlation rules at DataMiner startup.

Event properties:

- Element Name: DMANAME
- Parameter Description: Correlation engine (DataMiner Element Control Protocol)
- Value: Started

### DMS Maps

#### Service & Resource Management: Markers for multiple individual elements and elements in services \[ID_21800\]

A map layer that has its sourceType set to “objects”, can display markers for any type of DataMiner object and can retrieve marker data from parameters and/or properties.

Currently, only markers for elements and service elements are supported, but, in the future, markers for services, CPE objects and enhanced views will also be supported.

In the \<ObjectsSourceInfo> tag of an “objects” layer, you can configure a collection of sources:

- \<Element> for individual elements
- \<ServiceChildren> for service child objects (currently only elements and services elements)

##### Attributes for \<Element>

| Attribute | Description |
|--|--|
| id | Element name or element ID (dmaId/elementId) |
| idVar | Name of a variable that can be provided in the Maps URL, which will then be used as a dynamic ID. Example: idVar="MyElement" will resolve the ID with the URL parameter dMyElement. |

##### Attributes for \<ServiceChildren>

| Attribute | Description |
|--|--|
| id | Service name or service ID (dmaId/serviceId) |
| idVar | Name of a variable that can be provided in the Maps URL, which will then be used as a dynamic ID. Example: idVar="MyService" will resolve the ID with the URL parameter dMyService. |
| recursive | If true, elements of child services will be included. Note: Using recursive="true" will also allow you to show markers from contributing services. If the service contains an enhanced service element (or an associated DVE), children of that enhanced service will be included as well. |

##### Subtags of \<Element> and \<ServiceChildren>

| Tag          | Description                                                  |
|--------------|--------------------------------------------------------------|
| \<Latitude>  | Latitude coordinate (required)                               |
| \<Longitude> | Longitude coordinate (required)                              |
| \<Title>     | Marker title (optional, uses the DMA object name by default) |

Any of the above-mentioned subtags can contain raw text, a name of a property or a parameter ID (with optional table index). See the following examples:

- \<Latitude>12.34\</Latitude>
- \<Longitude>\<Property>MyLongitudeProperty\</Property>\</Longitude>
- \<Title>\<Parameter>\<ID>123\</ID>\<Index>MyTableIndex\</Index>\</Parameter>\</Title>

#### Visualizing DCF connections as lines between markers \[ID_21923\]

Map layers can now visualize DCF connections as lines between markers.

To have DCF connections displayed as lines between markers, do the following:

1. Create a new \<Layer>, and set its sourceType attribute to “connectivity”.

1. To this new layer, add a \<LayerSourceInfo> tag in which you specify the name of the layer that contains the objects of which you want the connections to be visualized.

    > [!NOTE]
    >
    > - The sourceType attribute of the layer specified in the \<LayerSourceInfo> tag has to be set to “objects”.
    > - The style of the connections can be configured in a \<LineOptions> tag.
    > - If you want to show a DCF connection property in the \<PopupSkeleton> template, then add a \<Detail> tag inside the \<PopupDetails> tag, and set its *type* attribute to “property” and its *property* attribute to the correct connection property name.

> [!NOTE]
> In order to be displayed consistently, DCF connections and DCF properties need to be defined on both source and destination elements.

#### Enhanced service parameters can now be specified in \<Detail> tags \[ID_22009\]

In a service context, it is now possible to specify parameters of enhanced services in \<Detail> tags inside \<PopupDetails> or \<MarkerDetails> tags.

The detail placeholders can then be used in \<PopupSkeleton> or \<MarkerImage> tags respectively.

Examples:

```xml
<Detail name="MyVariable" type="parameter" pid="12345" idx="MyDisplayKey" />
```

```xml
<Detail name="MyVariable" type="marker/parameter" pid="12345" idx="MyDisplayKey" />
```

```xml
<Detail name="MyVariable" type="service/parameter" service="MyService" pid="12345" idx="MyDisplayKey" />
```

### DMS CPE Management

#### Enhanced views \[ID_19316\]\[ID_21944\]

The new “enhanced view” feature allows an element to become part of a view. This means that the alarm state of an element included in a view will now influence the alarm state of that view.

See also: [New properties added to the ViewStateEventMessage \[ID_21375\]\[ID_21547\]](#new-properties-added-to-the-viewstateeventmessage-id_21375id_21547)

> [!NOTE]
> When a view was enhanced with an element, the alarms associated with that element will have the view specified in their “View impact” column.

#### CPE Manager: Dummy items in CPE diagram and filters can now be hidden \[ID_19658\]

CPE tables often contain dummy items, i.e. virtual items that merely act as a link between two actual items. From now on, it is possible to hide these dummy items in CPE diagrams and CPE filters.

To be able to mark items as dummy items in a particular CPE table, add an extra column of type “double”, and specify the “CPEDummyColumn” option in its column definition. See the following example:

```xml
<ArrayOptions index="0" displayColumn="1">
  ...
  <ColumnOption idx="9" pid="1616" type="retrieved" options=";save;disableHeaderSum;CPEDummyColumn"/>
  ...
</ArrayOptions>
```

When, in DataMiner Cube, you now want to mark an item as a dummy item in that table, then go to the row that represents the item, and add “1” in the column defined as “CPEDummyColumn”.

> [!NOTE]
>
> - Items marked as dummy items will not be displayed in CPE diagrams nor in CPE filters, unless selected from a direct filter.
> - Parents of a dummy item will be linked to its children, and children of a dummy item will be linked to its parents.
> - There can only be one dummy item per topology level. For example, a street cannot have two parents “Dummy1” and “Dummy2”. These two dummy items must be combined into one.

#### CPE Manager: Right-click menu now allows you to copy values from a diagram node and a KPI list \[ID_20541\]

In a CPE environment, right-click menus now allow you to copy certain values:

- When you right-click a diagram node, you can copy the title of the node as well as the values displayed on the node.
- When you right-click a value in a KPI list, you can copy that specific value.

#### CPE Manager: Masking nodes in CPE diagrams \[ID_20653\]\[ID_24010\]

It is now possible to mask nodes in CPE diagrams. To mask a node, right-click it, and select “Mask”.

However, note that it is only possible to mask a node for a limited period of time or until unmasked. The option to mask until the alarm is cleared, which is available for other DataMiner objects, is not available for CPE objects.

#### CPE Manager: New 'skipInDiagram' option to skip level in CPE diagram \[ID_20893\]

It is now possible to configure a chain in a CPE protocol so that a level is skipped in the CPE diagram. To do so, add the option "skipInDiagram" in the relevant "Field" tag in the chain.

The level linked to this field will then not be displayed in the diagram, unless the currently selected object is actually of that level.

Example:

```xml
<Chains>
   ...
   <Chain name="Example Hide Room/Rack">
      <Field name="Location" options="MaxDiagramsOnRow:3;ShowCPEChilds;details:1000-KPI|1500;displayInFilter;tabs:1000-KPI|1500|1600" pid="1002">
         <DiagramTitleFormat>{rowDK} (temp:{pid:1004})</DiagramTitleFormat>
         <DiagramPids>1004,1006</DiagramPids>
     </Field>
     <Field name="Room" options="SkipInDiagram;DiagramSort:1506|DESC:1;ShowCPEChilds;details:1500-KPI|1600;displayInFilter;KPIsInDiagram:{rowDK}\nCode: {pid:1504}, Temperature: {pid:1506}\nRoomAVGDeviceTemp:{pid:1506}" pid="1502">
         <DiagramTitleFormat>{rowDK} ({pid:1506}°C)</DiagramTitleFormat>
         <DiagramPids>1504,1506</DiagramPids>
         <DiagramSorting>1506|DESC</DiagramSorting>
     </Field>
     <Field name="Rack" options="SkipInDiagram;ShowCPEChilds;details:1600-KPI|1700|1900;detailTabs:1700-SeverityColumn-ListKPIHide;displayInFilter;tabs:1600-KPI|1700|1900;ShowBubbleupAndInstanceAlarmLevel" pid="1602"/>
     <Field name="Device-TileList" options="detailTabs:1700-KPI-SeverityColumn-ListKPIHide,1800;ShowCPEChilds;displayInFilter;tabs:1700-KPI|1800|14,14,1800;TabOrder:2,1,0;TileList;ShowBubbleupAndInstanceAlarmLevel;KPIsInDiagram:Online:\t{pid:1710}\nOffline:\t {pid:1714}" pid="1704"/>
   </Chain>
   ...
</Chains>
```

> [!NOTE]
> If you configure the filter of a field to not be displayed (i.e. you leave out the "displayInFilter" option), the "showTree" option is required, as otherwise the diagram would immediately stop at the level corresponding to this field. In that case, depending on whether the "skipInDiagram" option is specified, the diagram will either be shown as if the filter was displayed, or shown without this particular level.

#### New CPECollectorHelper function to retrieve table rows that are linked via topology \[ID_21101\]\[ID_21122\]\[ID_21206\]\[ID_21465\]\[ID_21746\]

The following CPECollectorHelper function allows client apps to retrieve table rows that are linked via topology:

- GetLinkedDMAObjectRefGroupsThroughTopology

Note that this function requires that, in the protocols of the CPE collector elements, the Topology.Cell tags map to names of table cells on the CPE Manager elements that have to be polled, and that each of those Topology.Cell tags also contains an Exposer tag.

In the example below, the “Amplifier” cell has been exposed to the CPE crawler, which will retrieve the data. This means, that table 500 can be searched using the above-mentioned function.

Also note that, inside the Exposer element, you can add linked tables. In the example below, table 1000 is linked to table 500 using column parameter ID 1001.

Example:

```xml
<Topologies>
  <Topology>
    <Cell name="Amplifier" table="500">
      <Exposer enabled="true">
        <LinkedIds>
          <LinkedId columnPid="1001">1000</LinkedId>
        </LinkedIds>
      </Exposer>
    </Cell>
  </Topology>
</Topologies>
```

A typical CPE environment usually contains one front-end manager element and multiple back-end manager elements. All those elements, which contain the same CPE topology and refer to the same data in the background, will by default be polled by the CPE crawler.

To force the CPE crawler to only poll the front-end manager element, indicate which of the manager elements is the front-end manager. You can do this by adding to it a parameter of type “double” named “ElementManagerType”, and set its value to “1”.

> [!NOTE]
>
> - The LinkedId@columnPid attribute is only required when the tables have no foreign key linking to each other.
> - If a protocol contains at least one Protocol.Topologies.Topology.Cell element, two properties will be created on the DataMiner Agent: “System Type” and “System Name”. Alarms generated in tables defined in Cell@table attributes will have their “System Type” property set to the value of the Cell@name attribute and their “System Name” property set to the row's display key.
>   - If an exposer is defined with a LinkedId, it will receive the same property values. The “System Name” property will be set to the display key of the table defined in Cell@table as resolved by the foreign key relations. If no link can be resolved, then the display key of the original row will be used.
>   - If a LinkedId element has a columnPid attribute containing a column parameter ID in the LinkedId table, then the alarm's “System Name” property will be set to the value found in the specified column.
> - If the topology contains view tables instead of physical tables, then the above-mentioned alarm properties will also be filled in. However, note that, if view tables are used, secondary tables are currently not able to retrieve display keys of primary tables.
> - This feature will only work with Protocol.Topologies.Topology elements, not with legacy Protocol.Topology elements.

#### New properties added to the ViewStateEventMessage \[ID_21375\]\[ID_21547\]

The following new alarm level properties have been added to the view state:

| Property                       | Description                                                                                                                                                                                                                                                                                                                                                                       |
|--------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| DirectEnhancedLatchLevel       | Latch level of the enhanced element linked to the view.                                                                                                                                                                                                                                                                                                                           |
| DirectEnhancedRawLevel         | Alarm level of the enhanced element linked to the view.                                                                                                                                                                                                                                                                                                                           |
| DirectEnhancedTimeout          | Timeout state of the enhanced element linked to the view.                                                                                                                                                                                                                                                                                                                         |
| DirectSystemObjectLevel        | Alarm level of the “system object”, without objects below it. The system object contains the view, the enhancing element and all rows linked to the view via viewImpact.                                                                                                                                                                                                      |
| DirectViewImpactsBubbleupLevel | Bubble-up alarm level of the rows linked to the view via viewImpact.                                                                                                                                                                                                                                                                                                              |
| DirectViewImpactsLevel         | Instance alarm level of the rows linked to the view via viewImpact.                                                                                                                                                                                                                                                                                                               |
| EnhancedLatchLevel             | The most severe state of the DirectEnhancedLatchLevel and SubEnhancedLatchLevel.                                                                                                                                                                                                                                                                                                 |
| EnhancedRawLevel               | The most severe state of the DirectEnhancedRawLevel and SubEnhancedRawLevel.                                                                                                                                                                                                                                                                                                     |
| EnhancedTimeout                | The most severe state of the DirectEnhancedTimeout and SubEnhancedTimeout.                                                                                                                                                                                                                                                                                                       |
| SubEnhancedLatchlevel          | Latch level of the enhanced element linked to the subviews.                                                                                                                                                                                                                                                                                                                       |
| SubEnhancedRawLevel            | Alarm level of the enhanced element linked to the subviews.                                                                                                                                                                                                                                                                                                                       |
| SubEnhancedTimeout             | Timeout state of the enhanced element linked to the subviews.                                                                                                                                                                                                                                                                                                                     |
| SubSystemObjectLevel           | Alarm level of the items below the “system object”. The system object contains the view, the enhancing element and all rows linked to the view via viewImpact. The items below the system object are the items in the view and the subviews, the aggregation rules of the subviews, the enhancing elements of the subviews and the bubble-up alarm levels of the linked rows. |
| SystemObjectLevel              | Alarm level of the “system object” and the objects below it.                                                                                                                                                                                                                                                                                                                      |

> [!NOTE]
> The EnhancedExtraLevel property has been removed.

#### CPE tables can now have a ViewImpact column \[ID_21401\]

It is now possible to add a “view impact” column to a CPE table (by specifying the “ViewImpact” option in its column definition). In each of the table rows, the “view impact” column can then contain the IDs of the views that are impacted by that particular row.

- The highest alarm among all rows that impact a particular view will be copied to the DirectViewImpactsLevel property of the ViewStateEventMessage class.
- The bubble-up level will be copied to the DirectViewImpactsBubbleupLevel property of the ViewStateEventMessage class.

#### DataMiner Cube: A chain can now have several list tabs displaying the same data but with a different filter \[ID_21704\]

A chain can now have several list tabs displaying the same data but with a different filter.

#### CPECollector API: New methods \[ID_21755\]

The following methods have been added to the CPECollector API:

`GetMaskedDMAObjectRefTrees(FilterElement<IDMAObjectRef>)`

This method returns all masked object trees that match the specified filter. If no filter is passed, then all masked object trees are returned.

In the following example, a filter is passed to check whether the view with ID 2 is masked.

```csharp
var managedFilter = new ManagedFilter<DMAObjectRefTree,IDMAObjectRef> (DMAObjectRefTreeExposers.Data,Comparer.Equals,new ViewID(2),null);
```

**GetMaskedDMAObjectRefTrees(managedFilter);**

This method returns mask operations stored in the transaction store (i.e. masking of topology data or views).

#### Topology cells configured on a direct view table will now provision 'System Type' and 'System Name' properties on alarms originating from the source table \[ID_22238\]

If a topology cell is configured as in the example below, and the specified table is a direct view showing data from a source table that has monitoring enabled, then the alarms originating from that source table will now have their “System Type” and “System Name” properties provisioned with the cell name (in the example below: “Amplifier”) and the row key of the source table.

```xml
<Topologies>
  <Topology>
    <Cell name="Amplifier" table="4200"/>
  </Topology>
</Topologies>
```

#### New general parameters: \[Alarm System Type\] and \[Alarm System Name\] \[ID_22632\]

Two new general parameters have been added:

- \[Alarm System Type\]
- \[Alarm System Name\]

When no topology cell is defined for a monitored parameter, then the values of the alarm properties “System Type” and “System Name” will be set to the values found in the above-mentioned general parameters.

> [!NOTE]
>
> - When no alarm properties named “System Name” and “System Type” exist within the DataMiner System, they will not be created. Only creating an element with a topology cell definition will cause these alarm properties to be created.
> - Updating these general parameters will not cause the values defined by a topology cell definition to be overwritten.
> - Updating these general parameters will trigger a “Property Changed” update on the active alarms of the element, even on alarms relying on the topology cell definition in the protocol rather than these general parameters.
> - As to these two new general parameters, DVE elements will not inherit the values of the main element. Alarms on values exported to a DVE element will only use the values of the general parameters of that particular DVE element.
> - When using virtual functions, an alarm is linked to the main element instead of to the virtual function (i.e. the virtual element). This means that alarms will inherit the \[Alarm System Type\] and \[Alarm System Name\] parameters of the main element. Currently, the \[Alarm System Type\] and \[Alarm System Name\] parameters of virtual functions are not yet being used.
