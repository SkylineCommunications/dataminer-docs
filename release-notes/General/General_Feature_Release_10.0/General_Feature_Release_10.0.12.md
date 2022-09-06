---
uid: General_Feature_Release_10.0.12
---

# General Feature Release 10.0.12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS Protocols

#### A message body can now be added to raw HTTP requests \[ID_27438\]

In a QAction, it is now possible to add a message body to raw HTTP requests sent in a multi-threaded timer.

Old syntax:

```csharp
object[] httpRequestInfo = new object[3] { "http", new string[6] { sVerb, sURL, sUser, sPass, httpHeaders, "200" }, new string[1] { httpCommand } };
```

New syntax:

```csharp
object[] httpRequestInfo = new object[3] { "http", new string[6] { sVerb, sURL, sUser, sPass, httpHeaders, "200" }, new object[1] { new string[2] { httpCommand, dataToSend } } };
```

> [!NOTE]
>
> - The old syntax can still be used. If you use the old syntax, no message bodies will be sent. If you use the new syntax for a single resource, no message body needs to be added. In that case, you should define an empty string instead.
> - By adding the message bodies to the last array in the request, the new syntax allows you to send a different message body to each of the different subpages.
> - Using the new syntax, the last array can be an object array of string arrays of size 2:
>   - The first part of each string array is the subpage to which the request needs to be sent.
>   - The second part of each string array is the message body that needs to be sent to that specific subpage.
> - DataMiner does not format the given message body in any way. It is forwarded as received from within the QAction. It is up to the user to correctly format the message body.

#### Updating direct views showing data from elements on remote DMAs \[ID_27547\]

From now on, DirectView updates are supported in the following scenarios:

- DirectView based on a view of the same protocol

    Example:

    ```xml
    Protocol: view=200;directView=905 table config;view=201 column config or view=211:305
    ```

- DirectView based on a view of the same protocol with a single element source.

    Example:

    ```xml
    directView=6298 Pointing to a standalone parameter rather than a column parameter
    ```

- onlyFilteredDirectView based on a view of the same protocol

    > [!NOTE]
    > onlyFilteredDirectView will only return data when a filtered subscription is made on the directView.

- DirectView based on a different protocol

    Example:

    ```xml
    filterChange=DirectViewColumnID A-RemoteDataColumnID A, DirectViewColumnID B-RemoteDataColumnID B, ...
    ```

- DirectView based on a different protocol with a filter specifying the element sources to be included.

    Example:

    ```xml
    directView=6505 => FILTER: value=6501 == REMOTE-DATA-1
    ```

### DMS Cube

#### Alarm Console: Alarm events without a severity change can now be consolidated in the preceding event in the alarm tree \[ID_23234\]\[ID_23526\]\[ID_24462\]\[ID_27413\]

From now on, when an alarm tree contains alarm events that did not change the severity, these events can be consolidated in the previous event.

When you open an alarm card that shows an alarm tree containing consolidated events, you can click *Show all alarm updates* to have the tree expanded to show all events.

> [!NOTE]
>
> - The maximum alarm limit is calculated after alarm event consolidation.
> - Alarm consolidation is disabled by default. To enable it, add an *AlarmSettings.MustSquashAlarms* element to the *MaintenanceSettings.xml* file, and set its value to True.

#### Profiles app: Converters \[ID_27264\]

In the *Profiles* app, it is now possible to configure a converter (i.e. a mediation snippet) for a parameter linked to a profile parameter.

To configure a converter, do the following:

1. Open the *Profiles* app and go to the *Parameters* tab.

1. Open a parameter (or create a new one).

1. In the *Linked with* table at the bottom, add, edit or duplicate an entry.

1. In the *Edit link with protocol* box, activate the *Converter* setting, enter the converter code in the code window, and click *OK*.

   In the *Linked with* table, the *Converter* column will now show either the class name of the converter or, if no class name could be found, the first line of the converter code.

1. Click *Save* to apply the changes you made.

> [!NOTE]
> When you edit a linked parameter with a converter, the *Converter* setting will automatically be activated.

#### Elements hosted by a disconnected DMA will now be indicated as being disconnected \[ID_27313\] \[ID_27613\]

Up to now, when a DataMiner Agent disconnected from the DataMiner System, the elements hosted by it would disappear from the Cube’s Surveyor. From now on, they will remain visible (read-only), and will be indicated as being disconnected by means of a special icon.

> [!NOTE]
>
> - The cache is not persistent.
>   - When the disconnected DMA restarts, its elements will no longer be available to the other DMAs in the DMS.
>   - When another DMA joins the DMS, the elements of the disconnected DMA will not be available to the new DMA.
> - Any messages sent to the disconnected DMA (e.g. to retrieve or update information) will result in an exception being thrown.

#### DataMiner Cube will now always connect to a DataMiner Agent via .NET Remoting \[ID_27354\]

Up to now, DataMiner Cube could use either .NET Remoting or Web Services to connect to a DataMiner Agent. However, as Web Services Enhancements (WSE) for Microsoft .NET is now deprecated, from now on the only way for DataMiner Cube to connect to a DataMiner Agent is by using .NET Remoting.

#### Trending: Renaming of trend prediction types \[ID_27435\]

On a system with a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Four types of trend prediction can be displayed. Those types have now been renamed.

| Old name   | New name       |
|------------|----------------|
| Short-term | High precision |
| Mid-term   | Short-term     |
| Long-term  | Mid-term       |
| Full-term  | Long-term      |

Also, the behavior of the “auto” setting has been enhanced.

#### DataMiner Cube is now able to detect table columns containing MAC addresses \[ID_27503\]

DataMiner Cube is now able to detect table columns containing MAC addresses and to sort them appropriately.

#### Trending: Ignore gaps option in export window \[ID_27506\]

When you export a trend graph to CSV, a new *Ignore gaps* option is now available. If you select this option, the export will skip any gaps in the trend data.

#### Trending: Percentile line \[ID_27533\]

It is now possible to visualize a percentile line on a trend graph in DataMiner Cube. To do so, right-click the graph and select *Show percentile*. By default, the 95th percentile for the data in the current range will then be calculated and visualized with a line on the graph. To the right of the line, you will see the percentile that was calculated and the value of the percentile.

If the range of the graph is adapted, the percentile is not automatically updated, so that you can compare the percentile for a certain range with the data for a larger or smaller time frame. The percentile line will be displayed as a full line over the range for which it was originally displayed, and as a dashed line over the rest of the graph.

When you click the percentile line, a refresh option is displayed that allows you to refresh the percentile to the currently displayed data. Clicking the line also displays the option to adjust the percentile, so that you can e.g. display the 90th percentile instead.

Finally, in the *Trending* tab of the Cube user settings, a new *Show percentile* setting is now available, which can be used to have the percentile line displayed by default whenever a trend graph is opened. If this option is selected, you can also select which percentile should be calculated by default.

#### Alarm Console: FilterElement property of an alarm hyperlink can now include a filter that checks the existence of a dictionary key \[ID_27675\]

A new exposer will now allow filters to check whether a certain key exists in a dictionary.

```csharp
// Filter to check if a key exists
var keyFilter = AlarmEventMessageExposers.PropertiesDict.KeyExists("KeyName").Equal(true);
// Filter to check if a key does not exist
var keyFilter = AlarmEventMessageExposers.PropertiesDict.KeyExists("KeyName").Equal(false);
```

In Alarm Console hyperlinks, these filters can be used in the FilterElement property. See the following example.

```xml
<HyperLink id="1" version="2" name="Issue_ID blank" type="script" alarmColumn="true" menu="root/JIRA" combineParameters="true" filterElement= "(AlarmEventMessage.PropertiesDict.KeyExists:Issue_ID[Bool] == False) OR (AlarmEventMessage.PropertiesDict.Issue_ID[String]=='')">
  Script:dummy script||||Tooltips|NoConfirmation,CloseWhenFinished
</HyperLink>
```

> [!NOTE]
>
> - This type of filters will be applied after the data has been retrieved from the database.
> - It is not recommended to use these filters when retrieving data from Cassandra or ElasticSearch.

#### Name of the DataMiner System can now be displayed in Cube’s header bar \[ID_27714\]

In DataMiner Cube, the name of the DataMiner System can now be displayed in the header bar.

- Open the header bar’s quick menu, and activate or deactivate the *Show cluster name* setting.

    or

- Open the *Settings* window, go to *Computer \> Cube*, and select or clear the *Display cluster name in header* setting.

### DMS Reports & Dashboards

#### Dashboards app: New 'Enable pinning as quick pick' option + support for timespans as input for time range feed \[ID_27357\]

In the Dashboards app, if the layout option *Use quick picks* is selected for a time range component, you can now enable the additional option *Enable pinning as quick pick*. When you do so, a pin icon is displayed next to the time summary in the component. Clicking the icon will add the current time selection as a custom quick pick button. If the current time selection matches the custom quick pick button, clicking the pin icon again will remove the button. You can also remove the button using the garbage can icon on the button itself.

The custom quick pick button is saved on component level, which means it will remain displayed when the dashboard is refreshed, until it is manually removed.

As an additional change, the time range feed has been updated to also accept timespans as input data now. Adding a timespan as input will set the active time range in the feed.

#### Dashboards app: Selecting an empty folder will now cause an 'Add a new dashboard' button to appear \[ID_27362\]

When, in the sidebar of the Dashboards app, you select an empty folder, an *Add a new dashboard* button will now appear in the large pane on the right.

Clicking that button will allow you to create a new dashboard in the folder you selected.

#### Dashboards app: Support for table column parameter as input for State component \[ID_27463\]

When you use a table column parameter as input for a State component in the Dashboards app, it will now display the state for all indices of the column. Optionally, you can add an indices filter in order to display specific indices only.

#### Ordering of data entries used in a dashboard component \[ID_27486\]

For dashboard components that can display multiple data entries and for which it makes sense to modify the order in which these entries are displayed (e.g. State components, Parameter table components, etc.), in the *Data* pane, a new *Data used in component* section is available. This section lists the different data entries used by the selected component, with arrow icons on the right that can be used to change the order in which the entries are displayed.

#### Dashboards app: Support for quick filters of tables in visual overview components \[ID_27517\]

Quick filters are now supported for tables within a visual overview component of a dashboard. The following (case-insensitive) syntax is supported for the filters:

- {column name}{operator}{value}
- {column name}{operator}regex{operator}{regex value}
- {column name}{operator}severity{operator}{alarmstate}
- regex{operator}{regex value}
- severity{operator}{alarmstate}

The following operators are supported in this syntax:

- : (contains)
- !:
- =
- !=
- ==
- !==
- \<=
- \>=
- \>
- \<

#### Dashboard theme configuration improvements \[ID_27553\]

The following improvements have been implemented to dashboard themes:

- It is now possible to customize the colors for the lines displayed in a trend graph. You can do so on dashboard level, by customizing the theme, or on component level, by customizing the component theme. In either case, the colors can be configured under *Color* > *Color palette*.

- While previously, customizing the dashboard theme within a dashboard only provided limited options compared to the theme configuration in the settings of the Dashboards app, now a *New theme* button is available in the dashboard *Layout* pane, which will open a pop-up window where you can fully configure a new theme.

#### Dashboard Gateway \[ID_27558\]

A new Dashboard Gateway now gives users access to the Dashboards app as well as to all other DataMiner web applications (Monitoring, Ticketing, Jobs, etc.) even if they do not have access to DataMiner.

There are two main reasons to consider a Dashboard Gateway setup:

- Security

  Users are allowed to connect to the Dashboard Gateway, but not to the DataMiner Agents directly. Also, it is possible to install only the web applications on the Dashboard Gateway web server(s) to which you want users to have access. If you only install the Dashboards and the Monitoring app, users will not be able to access the Jobs app, the Ticketing or any other app.

- Performance

  Allowing multiple users to connect to the web applications increases the overall load on the DataMiner Agents. When using a Dashboard Gateway, the direct load of the web applications and the HTTP requests shifts to a separate web server, leaving more resources available on the DataMiner Agents. Also, if more performance is needed, multiple Dashboard Gateway web servers can be used in combination with a load balancer.

Requirements:

- At least one web server (running Windows Server)
- A valid SSL certificate signed by a public certificate authority for the FQDN of the Dashboard Gateway (e.g. “gateway.mycompany.com”)
- A DataMiner user account with

  - access to all views, elements and alarms,
  - permission to access the Alarm Console and Data Display, and
  - permission to create, edit and delete dashboards.

- The Dashboard Gateway web server(s) should be able to communicate with a DMA using both a .NET Remoting connection and an HTTP(S) connection (using port 80 or 443, depending on the HTTP(S) configuration of the DataMiner Agent)

Configuration:

1. On the Dashboard Gateway web server(s), install IIS and the URL Rewrite module.

    For IIS, make sure to install Classic ASP, ASP.NET 4.6+, and the WebSocket protocol.

1. In IIS Manager, import the certificate, and update the site binding to use HTTPS with this certificate.

1. Configure URL Rewrite to forward all HTTP traffic to HTTPS

1. From a DataMiner Agent, copy the C:\\Skyline DataMiner\\Webpages\\API folder to the web root folder of the Dashboard Gateway web server (default: C:\\inetpub\\wwwroot) and, in IIS Manager, convert the API into an application.

1. From a DataMiner Agent, copy over the web application(s) (e.g. C:\\Skyline DataMiner\\Webpages\\Dashboard, C:\\Skyline DataMiner\\Webpages\\Monitoring, C:\\Skyline DataMiner\\Webpages\\Jobs, C:\\Skyline DataMiner\\Webpages\\Ticketing, etc.) to the web root folder of the Dashboard Gateway web server.

1. On the Dashboard Gateway web server, edit the web.config in the API folder, and specify the following settings:

   | Setting          | Description                                                                                                              |
   |--------------------|--------------------------------------------------------------------------------------------------------------------------|
   | connectionString   | Host name or IP address of the DataMiner Agent to which the Dashboard Gateway has to connect.                            |
   | connectionUser     | DataMiner user account that the Dashboard Gateway has to use to connect to the DataMiner Agent (user name and password). |
   | connectionPassword |                                                                                                                          |

Known limitations:

- The URL folder structure of the web applications should remain the same as on a DataMiner Agent. The applications have to be accessed using the following URL:

  ```txt
  https://gateway.somecompany.com/dashboard
  https://gateway.somecompany.com/monitoring
  https://gateway.somecompany.com/ticketing
  https://gateway.somecompany.com/jobs
  ```

- The DataMiner user account used by the Dashboard Gateway web server should not have multi-factor authentication enabled.

### DMS Automation

#### Interactive Automation scripts: Support for datetime values in ISO 8601 format \[ID_27565\]

The UIResults.GetDateTime method now also supports datetime values in ISO 8601 format.

Up to now, only datetime values in “dd/MM/yyyy HH:mm:ss” were supported.

#### Interactive Automation scripts: TreeViewItem now has an 'IsCollapsed' property \[ID_27567\]

Each TreeViewItem in a TreeView component now has an “IsCollapsed” property.

This will allow clients to determine the initial state of each TreeViewItem when displaying a TreeView

### DMS EPM

#### DataMiner Cube: Long selection box content in EPM filters will automatically wrap to the next line \[ID_27660\]

From now on, long selection box content in EPM filters will automatically wrap to the next line.

### DMS Web Services

#### Web Services API v1: New GetServicesForFilter method \[ID_27412\]

In the web services API v1, the new method *GetServicesForFilter* is now available. It can be used to retrieve a list of services matching a property filter.

### DMS Mobile apps

#### Monitoring app: Visualizing view properties in the Surveyor \[ID_27411\]

Similar to DataMiner Cube, the Monitoring app now also allows you to visualize view properties in the Surveyor.

#### Loading screen of embedded apps will now show a loading indicator instead of the app icon \[ID_27594\]

The loading screen of all mobile apps (Monitoring, Dashboards, Jobs, etc.) will now show a loading indicator instead of the app icon when opened in embedded mode (i.e. using a URL that contains either the embed=true or embedded=true argument).

### DMS Service & Resource Management

#### New helper method: GetEligibleResources \[ID_27609\]

The ResourceManagerHelper now contains a new method that allows you to simultaneously execute multiple eligible resource queries.

```csharp
/// <summary>
/// Returns the eligible resources for all given contexts. A result can be matched
/// with its context by matching the <see cref="EligibleResourceResult.ForContextId"/>
/// property on the <see cref="EligibleResourceResult"/> with the
/// <see cref="EligibleResourceContext.ContextId"/> of the
/// <see cref="EligibleResourceContext"/>.
/// </summary>
/// <exception cref="ArgumentNullException"><paramref name="contexts"/> is null
/// </exception>
/// <exception cref="ArgumentException"><paramref name="contexts"/> is empty
/// </exception>
/// <param name="contexts">The contexts to calculate the resources for</param>
/// <returns>
/// The result with additional info for all requested contexts that were valid.
/// If one or more contexts were invalid the results for the valid contexts are still
/// returned
/// </returns>
public List<EligibleResourceResult> GetEligibleResources(List<EligibleResourceContext> contexts)
{
    if (contexts == null)
        throw new ArgumentNullException(nameof(contexts));
    if(contexts.Count == 0)
        throw new ArgumentException("At least one context should be provided", nameof(contexts));
    var reqMsg = new GetEligibleResourcesMessage(contexts);
    return InnerGetEligibleResources(reqMsg)?.MultipleResults;
}
```

Also, a number of minor changes were done to make sure that the EligibleResourceResults can be matched to the requested contexts:

- An EligibleResourceContext now has a ContextId, which will automatically be filled in by any constructor.

- When the GetEligibleResources method returns a ReservationInstanceNotFound error or a ServiceNodeResourceUsageNotFound error, the error data will now have an additional  EligibleResourceContextId property. This will allow you to pinpoint any context will faulty data.

### DMS tools

#### SLReset: Factory reset tool \[ID_26026\]\[ID_26408\]\[ID_27227\]

SLReset.exe is a new tool that can be used to fully reset a DataMiner Agent to its state immediately after installation. It is located in the C:\\Skyline DataMiner\\Files\\ folder.

##### Optional argument

| Argument | Description                                                         |
|----------|---------------------------------------------------------------------|
| -y       | Skip any prompts that ask you whether to run online/offline actions |

##### Online actions (i.e. actions that are only run when the DMA being reset is running)

- ResetFailoverOnline

  Deletes the Failover configuration of the DMA if one is present.

- ResetClusterOnline

  Removes the DMA from the DMS if it is part of one.

##### Offline actions (i.e. actions that are always run whether or not the DMA being reset is running)

- StopTaskbarUtility
- StopDataMiner
- UndoIISConfig
- UndoFirewallConfig
- Unregister
- UninstallEndpoints
- DeleteTaskbarAppSettings
- FileCleanup

  > [!NOTE]
  > Deletes any unnecessary files in the C:\\Skyline DataMiner\\ folder.
  >
  > This action uses a whitelist to determine what to keep.
  >
  > On first execution, the default whitelist is added to the C:\\Skyline DataMiner\\Files\\ResetConfig.txt file. Subsequent executions will then check the whitelist found in that text file, to which you can add any file you want to keep.
  >
  > If you delete ResetConfig.txt, SLReset will again use the default whitelist.

- ResetDataMinerXml
- ResetNotifyMail
- ResetDoNotRemoveFiles
- ResetSLNetExeConfig
- ResetProtocolsIconXml
- ResetReportTemplatesXml
- ResetWebpagesWebConfigs
- DeleteExecutableEvents
- DBReset

  > [!NOTE]
  > This action runs the SLDataGateway.Tools.Database.exe located in the C:\\Skyline DataMiner\\Files\\x64\\ folder, and uses the input arguments harvested from DataMiner (DB.xml, credentials,...).
  >
  > For more information on SLDataGateway.Tools.Database.exe, see below.

- Register
- DcomConfig
- ConfigureServices
- FirewallConfig
- IISConfig
- StartSLTaskbarUtility
- StartDataMiner

##### SLDataGateway.Tools.Database.exe

This tool, when run with the factory-reset argument, resets the currently active MySQL, Cassandra or ElasticSearch database(s). When running this tool, you can specify the following arguments:

- `factory-reset`: Mandatory. Argument specifying that a factory reset must be done.

- `-t` or `--database-type <type>`: Mandatory. The type of database:

  - SQL (i.e. MySQL)
  - Cassandra
  - Elastic (i.e. ElasticSearch)

- `-i` or `--ip <ip>`: Mandatory. The IP address of the database host.

- `-u` or `--username <username>`: The username.

  If no account is specified, the following default credentials will be used:

  - MySQL: root (empty password)
  - Cassandra: root/root
  - ElasticSearch: no security

- `-p` or `--password <password>`: The password to be used with the specified username.

- `-f` or `--forced`: Skips all prompts.

  If this argument is not used, the user will be asked for a final confirmation.

- `-d` or `--Database <keyspace>`: The database/keyspace to be cleaned. If this argument is not used, everything will be cleaned.

- `-k` or `--keepcustomcredentials`: Preserves the specified Cassandra credentials (user and password) throughout the factory reset process.

- `-l`: The log level:

  - 0 = Off
  - 1 = Trace (default)
  - 2 = Debug
  - 3 = Info
  - 4 = Warning
  - 5 = Error
  - 6 = Fatal

- `--timeout`: Timeout (in milliseconds). If execution takes longer than the specified timeout, the program is killed.

  Default: int.MaxValue (\~2 billion)

> [!NOTE]
>
> - When you perform a factory reset, no backup of the DataMiner Agent will be taken.
> - SLReset must be run with administrative privileges.

#### BPA tests can now be run from a Windows command line \[ID_27420\]

BPA tests can now be run from a Windows command line.

Syntax:

```txt
BpaExec.exe -options -- tests
```

Example:

```txt
BpaExec.exe -option1 value -option2 value --<PathToTest1> <PathToTest2>
```

Supported options:

| Use... | or...               | in order to...                                             |
|--------|---------------------|------------------------------------------------------------|
| -u     | -username           | specify the user name of the SLNet user.                   |
| -p     | -password           | specify the password of the SLNet user.                    |
| -c     | -corrective-actions | allow the test(s) to take corrective actions if necessary. |
| -h     | -help               | display information on how to use this command.            |

## Changes

### Enhancements

#### Improvements to Change Element States Offline tool \[ID_23833\]

Numerous improvements have been implemented to the Change Element States Offline tool:

- The overall layout of the tool has been improved.

- The state of elements is now added as a suffix to element names.

- A CSV and XML export option for element states is now available in the *File* menu.

- A new *Elements by Protocol* tab has been added, with a tree view showing elements by protocol and protocol version. Checkboxes allow the quick selection of all elements in a node of the tree view.

- A search box has been added to make it easier to find elements in the *Elements by Name* and *Elements by Protocol* tabs. The wildcards "\*" (for any number of characters) and "?" (for exactly one character) can be used in this box. The element state can be included in the search

- The Ctrl+A key combination is now supported to select all elements.

#### Logging: More information stored in errorlog.txt file when an error occurs in SLProtocol \[ID_26630\]

When an error occurs in SLProtocol, from now on, more information about that error will be stored in the errorlog.txt log file.

#### DataMiner Cube - Service & Resource Management: Enhanced retrieval of service states \[ID_27202\]\[ID_27484\]

Due to a number of enhancements, overall performance has increased when retrieving SRM service states in the Cube Surveyor, the Services app and Visual Overview.

#### BPA Framework: BPA tests can now take corrective actions \[ID_27222\]

BPA tests can now be configured to take corrective actions when issues are detected.

When creating a BPA test capable of taking corrective actions, developers have to do the following:

1. Implement a class that inherits the BpaCorrectiveTest class.

1. Create an implementation of the Verify() method that will return

   - True when no issues were detected, and
   - False when issues were detected.

1. Create an implementation of the CorrectiveAction() method that will return

   - True when the corrective action was performed successfully, and
   - False when issues prevented the action from being performed.

A BPA test that was set to take corrected actions will run the Verify() method, which will run the CorrectiveAction() method in case of failure, and will then run the Verify() method again.

> [!NOTE]
>
> - The result returned by a test will tell whether corrective actions were taken and whether they were successful.
> - By default, no corrective actions will be taken in any of the tests that are run, unless requested in the beginning of the test run.

#### DataMiner Cube - Router Control: Enhanced configuration of input/output filters of custom matrices \[ID_27253\]

A number of enhancements have been made with regard to the configuration of input and output filters of custom matrices.

#### Scope of BPA test should now always be specified \[ID_27276\]

Before running a BPA test, the scope of the test should now always be specified using the *bpaRunmode* setting:

| If you specify...      | then...                                           |
|------------------------|---------------------------------------------------|
| BpaRunMode.ClusterOnly | the test(s) will be run on all agents in the DMS. |
| BpaRunMode.LocalOnly   | the test(s) will be run on the local agent only.  |

#### Service & Resource Management - Profile parameters: Default value of 'IsOptional' field has changed from 'Undefined' to 'Yes' \[ID_27286\]

Up to now, the *IsOptional* field of a profile parameter was by default set to “Undefined”. From now on, this field will by default be set to “Yes”.

#### Only the most recent synchronization file will now be kept in the 'C:\\Skyline DataMiner\\system cache\\sync' folder \[ID_27323\]

To prevent too many synchronization files from getting stored in the “C:\\Skyline DataMiner\\system cache” folder, from now on, only the most recent file will be kept in the “C:\\Skyline DataMiner\\system cache\\sync” subfolder.

Whenever a file is added to this folder, all files older than a day will automatically be deleted.

#### Dashboards app: Enhanced tool tip icons \[ID_27331\]

Throughout the Dashboards app, the tool tip icons have been enhanced.

#### Dashboards app: Enhanced component resizing \[ID_27372\]

Due to a number of enhancements, the way to resize dashboard components has been improved, especially on mobile devices.

#### StandAloneBpaExecutor now has to be run with administrative privileges \[ID_27379\]

From now on, the StandAloneBpaExecutor executable has to be run with administrative privileges. When the executable is run, a UAC box will now appear, asking for administrative access.

#### DataMiner Cube - Visual Overview: EPM card Visual pages now only displayed when page-level properties 'Chain' and 'Field' both match \[ID_27392\]

In an EPM environment, you can assign Visual Overview pages to chains and fields by setting the page-level *Chain* and *Field* properties.

Up to now, all Visual pages of an EPM card with a matching *Field* property were displayed, regardless of their *Chain* property. From now on, a Visual page will only be displayed if its *Chain* property is set to either a valid chain or “\*”.

> [!NOTE]
> Setting the *Chain* property of a Visio page to “\*” will display that page on all chains of the CPE Manager.

#### More detailed information in exception message when a BPA test fails to load due to dependencies not being able to load \[ID_27403\]

When a BPA test fails to load due to one or more dependencies not being able to load, from now on, more detailed information will be provided in the exception message.

#### Enhanced performance when applying, updating or removing alarm templates \[ID_27450\]

Due to a number of enhancements, overall performance has increased when applying, updating or removing alarm templates.

#### StandAloneBpaExecutor can now be used to view previously saved BPA test results \[ID_27451\]

When you saved the results of a BPA test to a JSON file, you can now load that file back into the StandAloneBpaExecutor to review the test result. To do so, go to the *Load results* tab, select the file, and click *Load*.

#### Jobs app: Miscellaneous enhancements \[ID_27454\]

A number of enhancements have been made to the user interface of the Jobs app: icons have been replaced, progress bars and tool tips have been added where appropriate, actions showing “remove” now all show “delete” instead, etc. Also, overall performance has increased.

#### DataMiner Cube - System Center: BPA folder will now also be included when taking a full backup or a configuration backup \[ID_27456\]

From now on, the C:\\Skyline DataMiner\\BPA folder will also be included when you take one of the following predefined backups:

- Full backup
- Full backup without database
- Configuration backup
- Configuration backup without database

#### Services app now includes virtual function definitions configured in DataMiner \[ID_27462\]

Previously, the Services module only listed virtual functions that had been uploaded to DataMiner via a Functions.xml file. Now it also includes virtual function definitions that were fully configured in DataMiner.

#### BPA test results now contain an 'Outcome' property \[ID_27476\]

The IBpaTestResult interface now contains an additional property named “Outcome”. This property can have the following values:

- BpaOutcome.NoIssues
- BpaOutcome.IssuesDetected
- BpaOutcome.Warning

#### SLWatchdog will now automatically restart the NAS and NATS services \[ID_27478\]

From now on, when SLWatchdog notices that the NAS and/or NATS services were stopped, it will automatically restart them and generate an alarm.

#### DataMiner Cube: Enhanced performance when loading custom SVG icons during login \[ID_27480\]

Due to a number of enhancements, overall performance has increased when loading custom SVG icons during login.

#### DataMiner Maps: KML layers now always bottom layers of map \[ID_27492\]

In the DataMiner Maps application, KML layers will now always be placed below other layers. Other layers will be drawn from top to bottom as defined in the map configuration.

#### Enhanced performance when saving alarm templates with conditional monitoring \[ID_27493\]

Due to a number of enhancements, overall performance has increased when updating alarm templates with conditional monitoring.

#### Visual Overview: Dynamic units improvement \[ID_27544\]

When dynamic units are used in Visual Overview, and parameter values of parameters with "decimals" set to 1 or less are converted to a bigger unit, these will be displayed with such a number of decimals that there are at least 3 significant figures. For example, 1320 MB will be displayed as 1.32 GB, even if the parameter has 0 decimals defined.

#### Monitoring app/Dashboards app: Support for embedded trend graphs in Visual Overview \[ID_27574\]\[ID_27584\]

The Monitoring app and Dashboards app now support the use of embedded trend graphs in Visual Overview. By default the trend graphs will display the last 24 hours of trending. In a dashboard, the colors of the graph will depend on the theme settings of the dashboard.

#### Support for running BPA tests across a cluster \[ID_27577\]

When interfacing with a DataMiner Agent and its installed BPA tests using the *BpaManagerHelper* object, you can now request the execution of one or more BPA tests across the cluster.

#### Cube launcher tool: Popup windows can be closed by pressing ESC & main window title changed to 'DataMiner Cube' \[ID_27582\]

In the Cube launcher tool, popup windows can now be closed by pressing the ESC button.

Also, the title of the main window has been changed to “DataMiner Cube”.

#### Client application licensing removed \[ID_27595\]

The client application licensing feature has now been removed. This means that if accepted credentials are provided, you can now connect to DataMiner with any client application, even if it is not approved by Skyline.

#### DataMiner Cube - Element properties: Dependency between options \[ID_27597\]\[ID_27725\]

When you add a custom property to an element, you can select a number of options.

From now on, it will only be possible to select *Update alarms on value changed* after selecting *Make this property available for alarm filtering*.

> [!NOTE]
> When an element property, service property or view property is created, the *Update alarm on value* changed option will by default be cleared. However, when an alarm property is created, this option will by default be selected.

#### DataMiner Cube - Data Display: Enhanced scrollbar behavior in tables \[ID_27653\]

In Data Display, a number of enhancements have been made with regard to scrollbar behavior in tables.

#### DataMiner upgrade packages now also include the C:\\Skyline DataMiner\\Resources folder \[ID_27600\]

DataMiner upgrade packages now also include the C:\\Skyline DataMiner\\Resources folder.

#### Standard BPA tests will now be included in DataMiner upgrade packages \[ID_27716\]

DataMiner upgrade packages will now by default place a collection of standard BPA tests in the C:\\Skyline DataMiner\\BPA folder.

### Fixes

#### DataMiner Cube - Visual Overview: Problem with highlighting of grouped shapes when zooming in or out \[ID_22365\]

When the ShapeGrouping feature was used, in some cases, grouped shapes were highlighted incorrectly when you zoomed in or out.

#### Various issues in Change Element States Offline tool \[ID_23833\]

Various issues have been resolved in the Change Element States Offline tool.

#### DMS Alerter: Settings window too small to fit all settings \[ID_27017\]

When, in DMS Alerter, you opened the settings window, in some cases, the window could be too small to fit all settings.

#### Problem with the precision of decimal values \[ID_27136\]

Up to now, when SLElement received a value from SLProtocol, in some cases, the raw value would get rounded to the number of decimals specified in the protocol’s *Display.Decimal* element. In cases where the *Display.Decimal* element defined less decimals than the *Interprete.Decimals* element, the level of precision would drop and would lead to rounding errors.

From now on, values will always be saved to the database with the precision specified in the *Interprete.Decimals* element. Also, that same precision will be taken by raw values sent to client applications.

#### DataMiner Cube: Missing focus icon for correlated alarm \[ID_27168\]

If you expanded a correlated alarm in the Alarm Console in order to see the base alarms and then toggled the *Correlation tracking* option, it could occur that the focus icon was missing for the correlated alarm.

#### DataMiner Cube - Profiles app: Problem when duplicating a profile parameter \[ID_27194\]

When, in the *Profiles* app, you duplicated a profile parameter of type “discrete” and discreteType “number”, in some cases, the discreteType and the raw discrete values would not be copied correctly.

#### DataMiner restart not triggered after process generated crashdump \[ID_27321\]

In some cases, after a DataMiner process had generated a crashdump, it could occur that no DataMiner restart was triggered even though this should have been the case.

#### Interactive Automation scripts: Problems with the UIBlockDefinition.IsEnabled and UIBlockDefinition.InitialValue properties \[ID_27326\]

Up to now, UIBlockDefinition.IsEnabled was not applied for blocks of type “checkbox”. From now on, a block of type “checkbox” will be disabled when the UIBlockDefinition.IsEnabled property is set to False.

Also, UIBlockDefinition.InitialValue was not applied correctly for blocks of type “calendar” when the value was not a valid ISO string. From now on, the UIBlockDefinition.InitialValue property will be ignored and the datetime picker block will be constructed based on the DMAAutomationUICalendarComponent.Timestamp property, which will contain the UTC time stamp the InitialValue represents.

#### Dashboards app: Problems with the color picker \[ID_27329\]\[ID_27365\]

A number of issues have been fixed with regard to the color picker.

#### DataMiner Cube - Visual Overview: DCF interfaces linked to a table entry would lose that link when updated \[ID_27353\]

DCF interfaces that are linked to a table entry can retrieve data from that table via their Parameters property. However, up to now, when an interface was updated, in some cases, it would lose that link. As a result, this could lead to problems in Visual Overview when, for example, the ID of the linked table entry was stored in session variables.

#### Dashboards app: Minor issues with time range feed \[ID_27357\]

The following minor issues could occur with a time range feed component in a dashboard:

- In some cases, the clock icon was not displayed next to the time summary.
- It could occur that the configuration pane of the time range feed was not correctly aligned with the time summary.

#### DataMiner Cube - Profiles app: 'Modified' label would not disappear after saving \[ID_27373\]

When, in the *Profiles* app, you saved a profile definition, a profile instance or a profile parameter, in some cases, the “Modified” tag would incorrectly not disappear.

#### BPA tests would fail when being run with administrative privileges \[ID_27382\]

When being run with administrative privileges, BPA tests that accessed SLNet would throw a “To log in as Administrator, please log on explicitly” error unless you manually specified the user name and password on the Settings page.

From now on, when a BPA test is launched, a popup window will appear, asking you to enter the Administrator password.

#### Multiple RTEs in same process not logged correctly \[ID_27387\]

When multiple RTEs occurred in the same process, it could occur that this was not correctly reported in the logging. Reporting of RTEs has now been improved to prevent this. Error alarms will now also get updates when a new thread encounters an RTE or has an RTE resolved.

#### Dashboards: Problem when changing the theme \[ID_27398\]

When, in the Dashboards app, you changed the theme, the colors of certain components (e.g. analog clock, digital clock,...) would not be changed accordingly.

#### DataMiner upgrade: SNMP service would incorrectly always be stopped \[ID_27400\]

When you launched a DataMiner upgrade, up to now, the SNMP service would incorrectly always be stopped, even when you had cleared the Stop SNMP option.

#### Proactive cap detection: Problem when calculating predictions \[ID_27417\]

When calculating predictions, in some cases, the time of a critical alarm threshold violation would incorrectly lie outside the prediction interval.

#### Problem with SLDataMiner due to locking issue in the alarm level linking module \[ID_27418\]

In some cases, an error could occur in SLDataMiner due to a locking issue in the alarm level linking module.

#### Protocol-level TTL settings would incorrectly not be taken into account when parsing real-time trend data \[ID_27421\]

In some cases, protocol-level TTL settings would incorrectly not be taken into account when parsing real-time trend data.

#### DataMiner Cube: Duplicated excluded column parameter entry in alarm template could not be edited \[ID_27423\]

If a column parameter entry that was set to *Excluded* was duplicated in an alarm template, it could occur that it was not possible to edit the duplicated entry.

#### Problem when a QAction launched an Automation script immediately after the element had been started \[ID_27431\]

When a QAction launched an Automation script immediately after the element had been started, in some cases, an exception could be thrown.

#### DataMiner Cube would no longer receive data updates from the DataMiner Agent it was connected to \[ID_27434\]

In some cases, DataMiner Cube would no longer receive data updates from the DataMiner Agent it was connected to.

#### DataMiner Cube - Visual Overview: Problem when closing Microsoft Visio while a shape was selected in Cube \[ID_27442\]

When, after opening a Visio file in Microsoft Visio, you closed Microsoft Visio while, in DataMiner Cube, a shape of that same file was selected, in some cases, an error could occur in DataMiner Cube.

#### Web Services API v1 - GetAlarms: Problem when filtering on RootAlarmID \[ID_27445\]

When alarms were retrieved using the GetAlarms method with a filter on RootAlarmID, in some cases, the following SOAP error would be returned:

```txt
System.InvalidOperationException: The specified type was not recognized: name='DMAAlarmFilterRootID'.
```

#### Problems with enhanced services \[ID_27465\]

A number of problems with regard to enhanced services have been fixed:

- When an enhanced service was renamed, in some cases, all open alarms associated with that service would incorrectly disappear.
- After an enhanced service had been reloaded, in some cases, element state changes would no longer be forwarded to that enhanced service.

#### Service & Resource Management: A daylight saving time change would incorrectly cause booking durations to get changed \[ID_27468\]

When a daylight saving time change occurred while a booking was active, in some cases, the duration of that booking would incorrectly get changed.

#### Service & Resource Management: Error that appeared when trying to deactivate or delete a function file in use would contain an incorrect file name \[ID_27470\]

Up to now, when you tried to deactivate or delete a function file used by ReservationInstances, ReservationDefinitions, ServiceDefinitions or ServiceProfileDefinitions, the returned error would contain an incorrect file name.

From now on, the error will contain the correct file name, i.e. the name of the file that cannot be deactivated or deleted because it is in use.

#### DataMiner Cube - Bookings app: Bookings list would not get updated when a booking was deleted \[ID_27482\]

In the Bookings app, the bookings are shown both in the list at the top and the timeline at the bottom. Up to now, when a booking was deleted, in some cases, it would disappear from the timeline but incorrectly remain visible in the list.

#### DataMiner Cube - Alarm Console: Problem when opening an alarm card or switching between alarm cards on a system with a large number of alarm properties \[ID_27483\]

On a system with a large amount of alarm properties, in some cases, an error could occur when you either opened a new alarm card or switched between two open alarm cards.

#### DataMiner Cube: Not possible to filter tables on display value \[ID_27490\]

In the quick filter boxes for tables in DataMiner Cube, previously it was only possible to filter on the raw value of the cells, i.e. the value used by the protocol, which is not necessarily the same as the displayed value. Now filtering on the displayed value is also possible.

#### Jobs app: When applying a template, job section fields of type 'User' would incorrectly not be overwritten \[ID_27495\]

When, in the Jobs app, you applied a template to a job, values in job section fields of type “User” would incorrectly not get overwritten with the values from the template.

#### Problem with SLDataGateway \[ID_27498\]

In some cases, the SLDataGateway process would start using an excessive amount of CPU resources, especially in Service & Resource Management environments.

#### Web Services API v1: Problem with GetJobsDomains method \[ID_27500\]

In some cases, the GetJobsDomains method would throw an error when the VisualStructure of a domain was NULL.

#### Dashboards app - Image component: Image selection box would incorrectly also contain non-image files \[ID_27510\]

When, in the Dashboards app, you added an image component and opened the image selection box on its *Settings* tab, in some cases, the selection box would list all files found in the C:\\Skyline DataMiner\\Dashboard\\\_IMAGES\\ folder, including files that were not images. From now on, the image selection box will only list image files.

#### Dashboards app: Table in visual overview component not filtered correctly \[ID_27517\]

When a visual overview component was used in a Dashboards app, it could occur that a table in the visual overview was not filtered properly.

#### DataMiner Cube - Protocols & Templates app: Incorrect warning message when deactivating or deleting a functions file \[ID_27518\]

If you deactivated or deleted a functions file in the Protocols & Templates app, in some cases, an incorrect warning message would be displayed.

#### Mobile apps: Date picker controls would show an incorrect month when the day was greater than or equal to 30 (or 29 in case of a leap year) \[ID_27522\]

In mobile apps (e.g. Jobs), in some cases, date picker controls would show an incorrect month when the day was 30 or 31 (or 29, 30 or 31 in case of a leap year).

#### Dashboards app: Problem with line chart component displaying resource capacity information \[ID_27526\]

When a line chart component in a dashboard was configured to display resource capacity information, and no data was displayed for the current timespan, a problem could occur if you selected the *Use percentage based units* option in the *Settings* pane.

#### DataMiner Cube - Alarm templates: Problem when editing alarm levels of a matrix parameter from the Alarm Console \[ID_27535\]

In some cases, it was no longer possible to edit the alarm levels of a matrix parameter from the Alarm Console.

#### Problem when a direct view table of an element retrieved data from that same element \[ID_27548\]

In some cases, an error could occur when a direct view table belonging to a particular element was retrieving data from that same element.

#### DataMiner Cube - Visual Overview: Memory leak caused by alarm shapes not getting cleaned up properly \[ID_27550\]

In some cases, alarm shapes created as part of a Children shape would not get cleaned up properly.

#### DataMiner Cube: About window would incorrectly show launcher tool version instead of Cube client version when Cube was opened using the launcher tool \[ID_27552\]

When you opened DataMiner Cube using the launcher tool, in some cases, the *About* window would no longer display Cube’s client version. It would show the launcher tool version instead.

From now on, the *About* window will show both the Cube client version and the launcher tool version.

#### Cube launcher tool: Entering text in the Arguments text box could resize the UI \[ID_27559\]

When, in the Cube launcher tool, you edited an agent entry, in some cases, the UI could get resized incorrectly when entering text in the *Arguments* text box.

#### DataMiner Cube - Services app: Problem when trying to assign a service profile instance to a profile instance with a parameter of type 'capability' \[ID_27580\]

When you tried to assign a service profile instance to a profile instance with a parameter of type “capability” (exclusively), in some cases, an exception could be thrown.

#### Alarms for numeric or discrete parameters not read out correctly from MySQL local database \[ID_27585\]

In systems with a MySQL local database, it could occur that alarms for numeric or discrete parameters were not read out correctly from the database when an element restart occurred or an alarm history query was launched.

#### Services containing remote elements would no longer get recalculated when the agent hosting the remote elements was disconnected \[ID_27589\]

In some cases, locally hosted services containing elements hosted on another DataMiner Agent (i.e. remote elements) would no longer get recalculated when the connection with the that other agent was lost.

#### Not possible to delete ticketing resolver \[ID_27603\]

In some cases, it could occur that a ticketing resolver could not be deleted.

#### Dashboards app: Line chart component would not draw the trend graph of a resource capacity \[ID_27606\]

In some cases, a line chart component would not draw the trend graph of a resource capacity.

#### Service & Resource Management: Parameters of type double in generated SRM protocols will now have their lengthtype set to 'next param' instead of 8. \[ID_27617\]

Up to now, parameters of type double in generated SRM protocols would have their rawtype set to “numeric text” and their lengthtype set to 8. As a result, if a parameter of a generated SRM protocol contained a value of more than 8 characters, that value would incorrectly be replicated to 0.

From now on, parameters of type double in generated SRM protocols will have their lengthtype set to “next param” instead.

#### DataMiner Cube: Columns in EPM data pages would be ordered incorrectly when using custom parameter positioning \[ID_27622\]

By default, an EPM card displaying row data as single parameters will automatically position those parameters unless custom positioning is applied on at least one of the columns (using the “CPEIntegration\_” prefix).

In some cases, when parameters were positioned automatically, the columns would not be ordered correctly. They would incorrectly be ordered according to the column definition order instead of the order defined in the options.

#### Dashboards app: Problem with Auto-select all indices option for Parameter feed component \[ID_27623\]

In the Dashboards app, if the *Auto-select number of indices* option was selected for a Parameter feed component, it could occur that the *Auto-select all indices* option did not work.

#### Minor issues in BPA framework \[ID_27625\]

The following minor issues could occur in the BPA framework:

- In some cases, it could occur that BPA tests were not updated correctly if BpaManager.BPAs.Update was used. The BPA info was not stored.
- BpaManager did not always include trace data on exceptions, causing BpaManagerHelper not to throw ManagerStoreExceptions.

#### DataMiner Cube - Alarm Console: Problem with alarm hyperlinks when the first character of the parameter name is hash character \[ID_27641\]

When you right-clicked an alarm associated with a parameter of which the name started with a “#” character and then clicked an alarm hyperlink that ran an Automation script that used that parameter name as input, in some cases, an error could occur.

#### DataMiner Cube: Clicking a pinned or recently opened custom element app would incorrectly cause another app to open \[ID_27642\]

When the *Activities* tab of the navigation pane listed multiple custom element apps of the same type (either pinned or not), in some cases, clicking one of those apps would incorrectly cause another app to open.

#### FileInfoManager: Problem when handling production protocols \[ID_27645\]

In some cases, FileInfoManager would handle production protocols incorrectly.

Also, Automation script IDs will now be case insensitive.

#### SLAnalytics: Problem when updating behavioral anomaly detection suggestion events \[ID_27646\]

In some cases, updates to behavioral anomaly detection suggestion events would contain an incorrect root alarm ID. As a result, a second suggestion event would be created and linked to the same change point. Also, after two hours, only the original alarm would be cleared.

#### Jobs app: Loading problem when selecting the already selected job domain in configuration mode \[ID_27651\]

When, in configuration mode, you selected the job domain that was already selected, in some cases, the loading indicator would remain visible indefinitely.

#### SLLogCollector: Generated packages would have incorrect file names \[ID_27677\]

In some cases, SLLogCollector would fail to include the ID and name of the DataMiner Agent in the file name of the packages it generated.

#### Dashboards app: Problem when pivot table component displayed table parameters with same table index values \[ID_27687\]

In case a pivot table component of a dashboard displayed different table parameters of which the table index values were the same, it could occur that the table index was displayed instead of parameter names.

#### DataMiner Cube - Protocols & Templates: Monitoring conditions would not get reapplied after switching alarm templates \[ID_27696\]

When you switched from an alarm template with conditions that were not used to an alarm template with identical conditions that were used, in some rare cases, conditional monitoring would incorrectly not get reapplied for the parameters using those conditions.

#### On DMAs with a MySQL database, alarms based on parameters of type 'analog' or 'progress' would have an incorrect display value after an element restart \[ID_27715\]

On DataMiner Agents using a MySQL database, in some cases, alarms based on parameters with measurement type “analog” or “progress” would have an incorrect display value after an element restart.

#### DataMiner Cube - Trending: Numbers smaller than 1 could be missing their decimal separator \[ID_27717\]

In some cases, trend data numbers smaller than 1 could be missing their decimal separator.

#### DataMiner Cube - Settings: Default workspace settings would incorrectly be displayed as text boxes instead of selection boxes \[ID_27718\]

In the User \> Cube sides section of the Settings window, when no custom workspaces had been created, the “default workspace” settings would incorrectly be displayed as text boxes instead of selection boxes.

#### Dashboards app: Pivot table component showed an error message \[ID_27724\]

In the Dashboards app, the pivot table component would show the following error message:

```txt
Error trapped: 'Skyline.DataMiner.Web.Common.IPersistentConnectionContainerEx' does not contain a definition for 'GetElementProtocol'
```

#### Dashboards app: Problem when grouping parameter data \[ID_27755\]

When grouping parameter data in components that support parameter data grouping, in some cases, an error could be thrown when you selected either “by element” or “all together” while some of the grouped parameters were single-value parameters without an index.

#### DataMiner Cube: Element and parameter heat lines would incorrectly stay gray \[ID_27767\]

In the Alarm Console and in Reports pages of card, in some cases, element and parameter heat lines would incorrectly stay gray.

#### Problem with SLLogCollector tool \[ID_27769\]

If a user had never used SLLogCollector before, it could occur that this tool failed to include memory dumps in packages generated for this user.

In addition, in some cases, SLLogCollector failed to include the contents of the *System Cache\\Info* folder in a memory dump.

#### DataMiner Cube: Problem when viewing a discrete profile parameter in the Profiles app \[ID_27888\]

In DataMiner Cube, in some cases, an error could occur when you viewed a discrete profile parameter in the Profiles app.

#### DataMiner - Visual Overview: Embedded alarm timeline would not show its summary timeline \[ID_27889\]

In some cases, an embedded alarm timeline component would not show its summary timeline.

#### DataMiner Cube - Correlation: Number of occurrences in 'Sliding window' section could incorrectly not be changed \[ID_27909\]

When you tried to define that a correlation rule had to be triggered when a situation occurred a specific number of times in a specified period of time, in some cases, it would not be possible to change the default number of times (i.e. 1).
