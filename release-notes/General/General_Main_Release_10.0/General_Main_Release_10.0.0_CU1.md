---
uid: General_Main_Release_10.0.0_CU1
---

# General Main Release 10.0.0 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Logging: Setting log levels per DataMiner log file \[ID_23244\]\[ID_24771\]

In the *Logging* section of *System Center*, it is now possible to set log levels per DataMiner log file, overriding the ones specified on system level.

##### Overriding the system-wide log levels for a specific log file

1. In the tab listing the DataMiner log files (default tab name: “dataminer”), select the log file in the left-hand pane.

1. At the top of the right-hand pane, open the *Log settings* section, select the *Override log levels* option, specify a level for each of the three log levels (info, debug and error), and click *Apply levels*.

> [!NOTE]
>
> - If you want to set the same non-default log levels for multiple log files, then note that you can select more than one file in step 1. To select more than one file, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive files, click the first one in the list and then click the last one while holding down the SHIFT key.
> - In the left-hand pane, the current log levels for each of the DataMiner log files are displayed next to the name of the file.
>   - If a file inherits the system-wide log levels, the log levels displayed next to the file will appear in gray.
>   - If a file has specific log levels defined (i.e. if the system-wide levels are overridden), the log levels displayed next to the file will appear in black.
> - If you clear the *Override log levels* option for a particular log file, that file will again inherit the system-wide log levels.

##### Setting the system-wide log levels

1. In the tab listing the DataMiner log files (default tab name: “dataminer”), select the first entry in the left-hand pane, marked “\<Default>”.

1. At the top of the right-hand pane, open the *Log settings* section, specify a level for each of the three log levels (info, debug and error), and click *Apply levels*.

#### SLNet setting 'FlushQueuedMessagesInterval' no longer has a minimum value \[ID_24205\]

The “FlushQueuedMessagesInterval” setting controls the interval at which pending messages are flushed to clients through the callback connection. The larger this interval, the less calls will be made, but the longer the delay will be between events being generated and clients receiving them. This setting is a global setting that can be configured per DataMiner Agent, and applies to any client connecting to SLNet.

The default value is 100ms, and up to now the minimum value was 50ms. From now on, this setting no longer has a minimum value. When the interval is set to zero, there will only be a 15ms delay when an iteration did not yield any new callback launches.

#### DataMiner Cube - Alarm Console: Enhanced performance when adding property columns \[ID_24545\]

Due to a number of enhancements, performance has increased when adding property columns in alarm tab pages.

#### DataMiner installer will no longer install Web Services Enhancements \[ID_24547\]

From now on, the DataMiner installer will no longer install Web Services Enhancements for Microsoft .NET.

#### SLSNMPManager: Enhanced error handling \[ID_24579\]

Due to a number of enhancements, overall error handling has been improved in the SLSNMPManager process.

#### Logging related to smart baselines will now be added to a dedicated log file \[ID_24627\]

Up to now, all logging related to smart baselines was added to the *SLNet.txt* log file. From now on, this logging will be added to the *SLSmartBaselineManager.txt* file instead.

#### BPA tests: Minimum version set to '0.0.0.0' by default \[ID_24634\]

When you create a BPA test, from now on, it will have its minimum version set to “0.0.0.0” by default, meaning that it will run on any DataMiner version.

#### Migrating booking data to Indexing Engine: Enhanced message in case of successful migration \[ID_24671\]\[ID_25101\]

When a booking data migration to Indexing Engine completed successfully, up to now, the following message would appear:

```txt
The migration is done with 0 failed merge(s), but without exceptions or errors.
```

From now on, the following message will appear instead:

- In case there are no failed merges:

    ```txt
    The migration has successfully been completed.
    ```

- In case there are failed merges:

    ```txt
    The migration has been completed with X failed merge(s). There were no exceptions or errors.
    ```

#### Migrating booking data to Indexing Engine: 'Show all properties' option will now by default not be selected \[ID_24717\]

When migrating booking data to Indexing Engine, up to now, the “Show all properties” option would be selected even when there were no properties to be changed. From now on, this option will by default not be selected.

#### DataMiner Cube - Spectrum analysis: Preset will now also contain the measurement point for which the trace was measured \[ID_24729\]\[ID_24953\]\[ID_25100\]

From now on, when you save a preset, it will not only include a “measurement points" field containing all measurement points you selected, but also a “saved on measurement point” field containing the ID of the measurement point for which the trace was measured.

This will enable spectrum monitors to determine the correct set of frequencies in case the monitor runs a script that loads a preset based on a selected measurement point.

#### DataMiner Cube - Service & Resource Management: ListView enhancements \[ID_24736\]

A number of enhancements have been made to the ListView component, which is used in the Bookings and Services apps as well as in Visual Overview:

- The *Add/Remove Column \> More…* shortcut menu option was moved up one level and renamed to *Manage column configuration…*
- The title of the column configuration window, which was named *Choose details*, has now been renamed to *Column configuration*.

#### DataMiner Cube - Visual Overview: Advanced editing pane improvements \[ID_24772\]\[ID_24794\]

The *Advanced Editing* pane now provides better support for DataMiner stencils.

From now on, this pane will

- no longer display shape data that is marked “hidden”, and
- no longer show underlying formulas in shape data, but the actual value.

Also, a few general enhancements have been made with regard to scrolling and keyboard focus.

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

#### DataMiner Cube - Service & Resource Management: Property columns will now automatically be updated upon property changes \[ID_24826\]

In ListView components embedded in Visio pages, from now on, columns referring to element properties will automatically be updated upon property changes.

#### DataMiner Cube - Alarm Console: Element state changes no longer trigger a refresh of filtered alarm tab pages \[ID_24832\]

Up to now, element state changes would trigger a refresh of filtered alarm tab pages. From now on, this will no longer happen.

#### Web Services API v1: Enhanced retrieval of trend data \[ID_24848\]

From now on, the GetTrendDataForTableParameter and GetTrendDataForTableParameterV2 methods will automatically try to retrieve real-time trend data when no average trend data is available (and vice versa).

#### DataMiner Cube will now be shipped with Segoe MDL2 Assets font \[ID_24853\]

Because client computers running a Microsoft Windows version prior to Windows 10 do not have the Segoe MDL2 Assets font installed by default, from now on, that font will be shipped with DataMiner Cube.

#### SLDMS: SLElement/SLDMS throttle removed \[ID_24862\]

Previously, the amount of simultaneous calls that native SLElement and SLDMS modules could make to the local SLNet process was limited to 1 and 5 respectively. This limit has now been removed. Both now use the same limit as other processes, i.e. 10 simultaneous calls.

If you prefer to keep the call limits as they were, you can specify the following option in the *\<appSettings>* section of the *C:\\Skyline DataMiner\\Files\\SLNetCOM.dll.config* file:

```xml
<add key="UseLegacyThrottle" value="true" />
```

When you set this *UseLegacyThrottle* option to true, the Application/DataMiner event viewer log will show entries for SLElement.exe and SLDMS.exe indicating “Applied throttle: 1” (SLElement) or “Applied throttle: 5” (SLDMS).

#### DataMiner Cube: Option to connect over Web Services will now be hidden when Web Services Enhancements is not installed on the DataMiner Agent \[ID_24918\]

When you try to connect to a DataMiner Agent that does not have Web Services Enhancements for Microsoft .NET installed, from now on, you will no longer be able to set *Connection type* to “Web services” in the logon options window of DataMiner Cube.

#### DataMiner Cube: Undocked cards now have an updated DataMiner logo in the upper-left corner \[ID_24920\]

Undocked cards now have an updated DataMiner logo in the upper-left corner.

#### Indexing Engine: A search string will only be added to the list of suggestions when the search yields results \[ID_24927\]

When, on a system with an Indexing Engine, you perform a search, from now on, the search string you entered will only be added to the list of suggestions when the search yields results.

#### SLDMS: Enhanced file locking mechanism \[ID_24954\]

A number of enhancements have been made to the file locking mechanism in SLDMS.

#### SLNet: Enhanced processing of messages sent asynchronously \[ID_24966\]

Due to a number of enhancements, overall performance of SLNet has increased when processing messages sent asynchronously.

#### DataMiner Cube - Data Display: Redesigned page buttons \[ID_24974\]

All page buttons have now been redesigned in order to match the new DataMiner X style.

#### DataMiner Cube - Visual Overview: Using subscription filters when subscribing to tree control tables \[ID_24995\]

From now on, multiple subscription filters can be configured in the *SubscriptionFilter* shape data field of a tree control. Each of the pipe-separated filters will be applied to the corresponding table specified in the *SetVar* shape data field.

In the following example, the first subscription filter (“value=101 == 1”) will be used when subscribing to the first table (with ID 100) and the second subscription filter (“value=201 == A”) will be used when subscribing to the second table (with ID 200).

| Shape data field   | Value                            |
|--------------------|----------------------------------|
| SetVar             | MyVar:\[this elementID\]:100:200 |
| SetVarOptions      | Control=TreeView                 |
| SubscriptionFilter | value=101 == 1\|value=201 == A   |

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

#### Service & Resource Management: Enhanced performance when retrieving available resources \[ID_25061\]

Due to a number of enhancements, overall performance has increased when retrieving available resources (e.g. by means of the GetAvailableResource method).

#### DataMiner Cube - Visual Overview: ListView component will not show a set of default columns when no columns are configured in its shape data \[ID_25098\]

When you add a *ListView* component to a Visio page, from now on, that component will display a set of default columns when its shape data does not contain a column configuration.

#### SLTaskBarUtility: Default Agents to upgrade now set to 'cluster' \[ID_25118\]

Previously, "Agents to upgrade" was by default set to "localhost" in the SLTaskBarUtility upgrade window. In order to ensure that clusters are upgraded completely, now "cluster" is selected by default. However, not that in case the Agent is not running, localhost will still be selected.

#### Enhanced processing of large DELT export operations \[ID_25177\]

A number of enhancements have been made with respect to the DELT export process. This will prevent timeouts in the event the process gets interrupted while exporting large amounts of data.

#### Automation: UnSetFlag method now also added to IEngine interface \[ID_25188\]

Since DataMiner 10.0.0/10.0.1, you can use the engine.UnSetFlag method to clear the AllowUndef, NoInformationEvents and NoKeyCaching run-time flags in an Automation script.

This method has now also been added to the IEngine interface.

#### Additional SLPort error logging \[ID_25200\]

Additional log information is now added to the SLPort logging to make it easier to troubleshoot issues in case DataMiner cannot process an incoming read event from a device because of an issue with the socket.

However, note that this logging will only be enabled for a particular element if the IP address for this element is added in PortLog.txt. For more information on how to add this, refer to the DataMiner Help.

#### Security: LDAP queries will now time out after 5 minutes \[ID_25214\]

From now on, LDAP queries will, by default, time out after 5 minutes.

This setting can be configured in the *DataMiner.xml* file. Enter a value in seconds. If the LDAP.QueryTimeout tag is not present, a default value of 300 seconds (i.e. 5 minutes) will be taken. See the example below.

```xml
<DataMiner>
  <LDAP>
    <QueryTimeout>300</QueryTimeout>
  </LDAP>
</DataMiner>
```

> [!NOTE]
> This timeout applies to every individual LDAP query. As a result, a request to refresh all groups (which consists of multiple requests) could have a total timeout that is much larger than 5 minutes.

#### Legacy Reporter app: Alarm list component now also returns alarms of enhanced service elements \[ID_25232\]

In the legacy Reporter app, the alarm list component will now also return alarms of enhanced service elements.

#### DataMiner Cube - Trending: Behavioral anomaly detection will no longer generate nor clear suggestion events when its flood mode is activated \[ID_25244\]

From now on, behavioral anomaly detection will no longer generate nor clear suggestion events when its flood mode is activated.

#### DataMiner Cube: Enhanced behavior of 'Save all changes' and 'Discard all changes' commands in Profiles and Services apps \[ID_25259\]

In the Profiles and Services apps, a number of enhancements have been made with regard to the “Save all changes” and “Discard all changes” commands.

#### DataMiner Cube: Improved vertical alignment of hint text in password box of login screen \[ID_25303\]

In Cube’s login screen, the vertical alignment of the hint text in the password box has been improved.

#### DataMiner Cube - Alarm Console: Reduced memory consumption \[ID_25340\]

Due to a number of enhancements, the overall memory consumption of the Alarm Console has been reduced.

#### Backup: Backup.log file added to backup package \[ID_25347\]

When a backup package is created, from now on, the log information regarding the creation of that package will now be stored in the Backup.log file, which will be included in the package.

#### DataMiner Cube - Data display: Partial tables with protocol-defined sorting now have a refresh button \[ID_25354\]

Partial tables with protocol-defined sorting now have a refresh button.

#### DataMiner Cube - Header bar search box: Hidden and enhancing elements will no longer be included in the search results \[ID_25403\]

From now on, when you perform a search using the header box search box, the result set will no longer include hidden elements or view-enhancing elements.

#### Enhanced performance when writing data to Indexing Engine \[ID_25411\]

Due to a number of enhancements, overall performance has increased when writing data to the Indexing Engine.

#### Service & Resource Management: When checking whether a boolean ReservationInstance property is true or false, it is now also possible to specify the type as 'Bool' \[ID_25415\]

When checking whether a boolean ReservationInstance property is set to true or false, you can now specify the type as “Bool” as well as “Boolean”. See the following example:

```csharp
"ReservationInstance.Properties.\"Contributing Service\"[Bool]==false"
```

> [!NOTE]
>
> - Do not enclose the values true and false in single quotes. This would cause those values to be interpreted as string values instead of boolean values.
> - Do not enclose the filter in round brackets (...).

#### Service & Resource Management: Checking whether a boolean ReservationInstance property is true or false \[ID_25415\]

It is now possible to check whether a boolean ReservationInstance property is set to true or false. See the following example:

```csharp
"ReservationInstance.Properties.\"Contributing Service\"[Bool]==false"
```

> [!NOTE]
>
> - Do not enclose the values true and false in single quotes. This would cause those values to be interpreted as string values instead of boolean values.
> - Do not enclose the filter in round brackets (...).
> - To indicate the type, you can use either \[Bool\] or \[Boolean\].

#### Dashboards app - Line chart component: Timestamp will now always remain visible in the legend \[ID_25421\]

When hovering over trend graph values in a line chart component, the associated timestamp will now always remain visible in the legend.

When the legend is collapsed, instead of not showing any timestamp, it will now show the timestamp above the trend values. When the legend is expanded, it will show the timestamp as it did before.

#### DataMiner Cube: User name box on login screen can now display user names with a length of up to 64 characters \[ID_25426\]

On the login screen, the user name box can now display user names with a length of up to 64 characters. Longer names will be displayed with a trailing ellipsis character (“...”).

### Fixes

#### DataMiner Cube - System Center: Agent name would not get updated after a Failover switch \[ID_24468\]

In the *Agents* section of *System Center*, after a Failover switch, in some cases, the agent name would not get updated to the name of the online agent.

#### DataMiner Cube - Automation: Problem when turning a SET action into a GET action or vice versa \[ID_24498\]

When you added a SET action to an Automation script and then changed it to a GET action (or vice versa), in some cases, it would no longer be possible to configure the action.

#### DataMiner Cube - Protocols & Templates: Problem when trying to select another protocol version in the 'List based on protocol version' box \[ID_24499\]

If an information template is based on an older protocol version that does not have the same parameters as the latest protocol version, a warning is displayed at the bottom of the information template. Above the warning, a drop-down list allows you to select a different protocol version to load those parameters instead.

In some cases, selecting a different protocol version in this drop-down list would no longer be possible.

#### DataMiner Cube - Services app: Problem when duplicating service definitions \[ID_24500\]

In some cases, when duplicating a service definition, some data would not get copied to the newly created duplicate.

#### Alarm level linking would not be initialized or updated correctly \[ID_24509\]

In some cases, alarm level linking would not be initialized or updated correctly.

#### Failover: 'AlwaysBruteForceOffline' option would not work correctly when releasing virtual IP addresses took more than 10 seconds \[ID_24535\]

When a Failover setup with the *AlwaysBruteForceOffline* option enabled had to go offline, in some cases, the agent would not be restarted when releasing the virtual IP addresses took more than 10 seconds. The agent would incorrectly remain in an undefined state. Also, when the agent eventually went online at a later stage, problems could occur. On systems with a MySQL database, for example, incorrect element alarms would start to appear.

#### DataMiner Cube - Visual Overview: Problem when loading a trend group in a trend component \[ID_24590\]

When you embed a trend component on a Visio page, you can have it load a trend group by setting the *Parameters* shape data field to “TrendGroup=\<username>/sharedusersettings:\<groupName>”. When this entry contained a dynamic part (e.g. \[var:xxx\]), in some cases, updates would not get processed correctly and the trend graph would be cleared.

#### Problem with file synchronization cache \[ID_24620\]

Due to a problem with the file synchronization cache, in some cases, old file versions could incorrectly get synchronized again among the agents in a DataMiner System.

#### Service & Resource Management: Booking state not updated in services list \[ID_24650\]

In the list of services in the Bookings and Services apps, it could occur that the booking state was not up to date. This information will now be refreshed in real time.

#### Problem with SLSNMPAgent when retrieving the views \[ID_24663\]

In some cases, an error could occur in the SLSNMPAgent process when retrieving the views, especially when elements or services were present in the root view and the system contained a view with the same name as the root view.

#### DataMiner Cube - Alarm Console: Not possible to have the 'Focus' column displayed in 'active alarms' tabs listing different types of alarms and events \[ID_24680\]

In an “active alarms” tab showing masked alarms, non-masked alarms, information events and suggestion events, in some cases, it would not be possible to have the Focus column displayed.

#### Problems with recursive tables \[ID_24683\]

When a recursive table was queried directly using dynamic table queries, incorrect results would be returned when a “FK=xxx” filter was used on that same recursive table.

Also, when an element with bubble-up alarms in a recursive table was restarted, some of those alarms would incorrectly be counted twice. This would produce incorrect results when alarm severities dropped.

#### Service & Resource Management: Problem when retrieving profile manager data immediately after that data had been updated \[ID_24688\]

When profile manager data (profile parameters, profile instances or profile definitions) was retrieved immediately after that data had been updated, in some cases, old data would be returned.

#### DataMiner Cube - Trending: Problem when exporting trend data to CSV while trend logging was disabled \[ID_24699\]

When you exported a trend graph to a CSV file after selecting the *Everything* option, in some cases, none or only part of the trend data would get exported when trend logging was disabled. Also, afterwards, data could be missing from the trend graph when selecting e.g. “Previous month”.

#### DataMiner Cube - Bookings app: Problem when zooming to last/next month in the bookings timeline \[ID_24704\]

When, in the bookings timeline, you zoomed to last/next month, in some cases, the timeliine would zoom to an incorrect time range (e.g. one day).

#### DataMiner Cube - Services app: Problem with service definition diagram updates \[ID_24707\]

In the *Services* app, in some cases, the diagram of a service definition would not be updated properly when the service definition was embedded on a Visio page and the *AutoLoadExternalChanges* option was set to true.

#### DataMiner Cube - Visual Overview: Problem with path highlighting after a DCF connection update \[ID_24741\]

After a DCF connection update, in some cases, the highlighting of a manually drawn connector linked to that DCF connection would be incorrect. The highlight path would incorrectly end at the updated connector.

> [!NOTE]
> This problem only occurred when one or both of the interfaces connected to the connector were of type input/output.

#### DataMiner Cube - Data Display: Problem with lite drop-down controls when the listed parameter values were dependent on other parameter values \[ID_24743\]

In some cases, lite drop-down controls would not contain the correct values, especially when the listed parameter values were dependent on other parameter values.

#### DataMiner Cube - Advanced search: Problem when matches could only be found for one of the state filter options \[ID_24758\]

When, in the advanced search, you filter by item type (e.g. “Element”), an additional state filter appears. When you selected that state filter, in some cases, Cube would stop working when matches could only be found for one of the state filter options.

#### Problem when creating virtual function based on entry point tables that were part of the same relation \[ID_24770\]

In some cases, an error could occur when creating virtual functions based on two different entry point tables that were part of the same relation.

#### DataMiner Cube - Router Control: Problem when loading tab page IO buttons in configuration mode \[ID_24779\]

When, in configuration mode, the first tab of a tab control was loaded, in some cases, the IO buttons in that tab would not be loaded.

#### DataMiner Cube: Redesigned Cube X alarm icons incorrectly indicated timeouts and did not fully support alarm severity capping \[ID_24785\]

In DataMiner Cube, in some cases, the redesigned Cube X alarm icons would incorrectly indicate timeouts, especially for items included in a service. Also, up to now, those alarm icons would not fully support alarm severity capping.

#### Ticketing app: Problem when opening the app \[ID_24786\]

When opening the Ticketing app, in some cases, the following error could be thrown:

```txt
“Error trapped: An entry with the same key already exists.”
```

#### DataMiner Cube - Data Display: Problem when searching for a parameter in an element card \[ID_24801\]

In some cases, DataMiner Cube would become unresponsive when, in an element card, you searched for a parameter using the search box in the top-left corner of the card.

#### Problem when masking an entire table \[ID_24805\]

In some cases, it would not be possible to mask an entire table.

Also, the following masking issues have been solved:

- When a row was added to a masked table or a masked column and an alarm was generated for that row, the alarm would immediately be masked. In some cases, however, the number of masked alarms (a counter found in the general parameters) would not get incremented.

- When a row was added to a masked table or a masked column and an alarm was generated for that row, the alarm would immediately be masked. In some cases, however, the comment in the alarm would incorrectly be set to “Masked by” instead of “Parameter masked by”. As a result, after the element was restarted, the number of masked alarms (a counter found in the general parameters) would incorrectly be doubled.

#### DataMiner Cube - Service & Resource Management: ListView component embedded on a Visio page would no longer get updated properly \[ID_24808\]

In some cases, a ListView component embedded on a Visio page would no longer get updated properly.

#### DataMiner Cube - Service & Resource Management: Column headers in ListView components could lose their filter and sort controls \[ID_24814\]

In a ListView component, which is used in the Bookings and Services apps as well as in Visual Overview, in some cases, column headers could lose their filter and sort controls.

#### DataMiner Cube: Sidebar would stay invisible until Cube window was resized \[ID_24819\]

When you log in to a DataMiner Cube of which the sidebar was collapsed, in some cases, the sidebar would stay invisible until the entire Cube window was resized.

#### HTML5 apps: Value changes made by the program were not detected \[ID_24822\]

When, in an HTML5 app, a value had been updated manually, in some cases, the input control would not take into account subsequent updates of that same value made by the program.

#### When an unmonitored element in timeout was masked and then unmasked when it was no longer in timeout, its alarm state would be set to 'normal' instead of 'undefined' \[ID_24838\]

When an unmonitored element in timeout was masked and then unmasked after it had gone out of timeout, its alarm state would incorrectly be set to “normal” instead of “undefined/not monitored”.

#### DataMiner Cube: Problem when initializing the Element Connections module \[ID_24847\]

In some rare cases, an exception could be thrown when the Element Connections module was being initialized.

#### DataMiner Cube - Service & Resource Management: ListView component embedded on a Visio page would incorrectly display booking property updates \[ID_24854\]

In some cases, a ListView component embedded on a Visio page would not correctly display booking property updates.

#### 'Address length of 0' error added to SLErrors.txt when loopback network adapters were found during a DataMiner startup \[ID_24864\]

When DataMiner was started on a system with loopback network adapters, the following error would be added to the SLErrors.txt log file:

```txt
L::GetLocalMAC|ERR|-1|Address length of 0
```

#### DataMiner Cube: Problem when entering special characters in header search box \[ID_24869\]

When, in the header search box, you searched for special characters (e.g. “++”), no results would be returned, even when results were available.

#### DataMiner Maps: Problem retrieving the alarm level for a marker from a column different from the primary key \[ID_24870\]

In some cases, it would no longer be possible to retrieve the alarm level for a marker from a column different from the primary key.

#### DataMiner Cube - Trending: Problem when saving a trend group \[ID_24875\]

When you saved a trend group after editing it, in some cases, an exception would be thrown and no changes would be saved.

#### DataMiner Cube: Collapsing the sidebar would cause it to go into an invalid state \[ID_24877\]

In some cases, collapsing the sidebar would cause it to go into an invalid state.

#### Dashboards app: Problem with CPE feed \[ID_24884\]

In some cases, the Dashboards app would become unresponsive after selecting a chain and a field in a CPE feed.

#### DataMiner Cube - Scheduler: No 'next runtime', 'last runtime' or 'last runtime result' information displayed when a DMA in the DMS was unreachable \[ID_24894\]

On the List tab of the Scheduler app, in some cases, no “next runtime”, “last runtime” or “last runtime result” information would be displayed when one of the DataMiner Agent in the DMS was unreachable or disconnected.

#### Db.xml: 'oldstyle' argument of Offload tags would be removed when database settings were updated via Cube \[ID_24895\]

When a user had manually specified an *oldstyle* argument in an *\<Offload>* tag of the *Db.xml* file, that argument would be removed the first time the central database settings were updated via DataMiner Cube. From now on, Cube will no longer remove manually added *oldstyle* arguments.

#### DataMiner Cube - Visual Overview: Views selection boxes on Edit Shape pane were empty when editing a Visio file in Cube \[ID_24900\]

When editing a Visio file in DataMiner Cube using “edit mode”, in some cases, selection boxes listing all views in the DataMiner System displayed on the Edit Shape pane on the right would incorrectly be empty.

#### 'Unknown Parameter: Rollback' notice when installing Cassandra or Indexing Engine \[ID_24913\]

During a Cassandra or Indexing Engine installation, in some cases, an “Unknown parameter: NoRollback” notice would be generated.

From now on, upgrade packages will ignore the “SetOption NoRollback” command and will add an “info” line to the log saying “Ignoring NoRollback option (legacy)”.

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

#### DataMiner Cube: 'Spectrum settings:' label incorrectly displayed on 'Advanced element settings' pane of element without Spectrum Analyzer settings \[ID_24956\]

When editing an element without any Spectrum Analyzer settings, in some cases, when you opened the *Advanced element settings* pane, a “Spectrum settings:” label would incorrectly be displayed at the bottom of the pane.

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

#### Problem with SLDMS when synchronizing a file with a name containing percentage character while the log level was set to 5 or 6 \[ID_24985\]

During a midnight synchronization, in some cases, an error could occur in the SLDMS process when a file with a name containing “%” was being synchronized while the log level was set to 5 or 6.

#### DataMiner Cube - Services app: Selected node, edge or interface would no longer be selected after a service definition was refreshed \[ID_24994\]

When, in the Services app, a service definition was refreshed, in some cases, the node, edge or interface that was selected before the refresh would no longer be selected after the refresh.

#### DataMiner Cube: Newly created service not selected in card breadcrumbs \[ID_25005\]

When you created a new service, in some rare cases, the name of that service would incorrectly not be selected in the breadcrumbs of the service card.

#### Indexing Engine: Problem when storing large string values \[ID_25007\]

When a string value larger than 32,000 bytes was written to an Indexing Engine, in some cases, that value would not be indexed and an exception would be thrown.

#### DataMiner Cube: List view column configuration issues \[ID_25009\]

When a custom property column was renamed in a list view component, either embedded in Visio or in the Services or Bookings app, it could occur that the custom name was not applied correctly.

In addition, if the list view column layout was customized via the context menu, it could occur that the column configuration window did not correctly reflect the customized layout.

#### Problem when retrieving CPE-related data from a Cassandra database \[ID_25019\]

In some cases, an exception could be thrown when retrieve CPE-related element data from a Cassandra database.

#### CPE Management: Problem when resolving recursively linked keys \[ID_25023\]

In some cases, recursively linked keys would be resolved incorrectly. This would especially affect the retrieval of CPE data (e.g. alarm properties).

#### DataMiner Cube: Minor issues with the new DataMiner X UI layout \[ID_25026\]

A number of minor issues with the new DataMiner X UI layout have been fixed.

#### Memory leaks in SLDMS \[ID_25041\]

In some cases, the SLDMS process could leak memory.

#### DataMiner Cube: Problem with unstable DataMiner Agent connections when upgrading an entire DataMiner System \[ID_25043\]

When, in DataMiner Cube, you started an upgrade of the entire DataMiner System, in some cases, the Upgrade window could become unresponsive when one or more of the DataMiner Agents being upgraded had an unstable connection.

From now on, when you start an upgrade of an entire DataMiner System, agents with an unstable connection will no longer be included in the upgrade operation and a warning will be displayed.

#### Dashboards app - CPE feed: Field values for columns other than the primary key would not be applied \[ID_25050\]

When using a CPE feed, in some cases, field values for columns other than the primary key would not be applied.

The URL argument “cpes” now has the following extended format:

```txt
?cpes=dmaID%2FeID%2FFieldPID%2FFieldValue%2FTableIndexPID%2FIndexValue
```

#### Interactive Automation scripts: Problem with checkbox updates \[ID_25054\]

In interactive Automation scripts, in some cases, checkbox components would not be updated correctly.

#### SLDMS run-time errors when connection with remote DMA could not be initialized \[ID_25068\]

When the connection with a remote DMA could not be initialized, run-time errors could occur in the SLDMS process.

#### SLDataMiner: Memory leak when retrieving security group information from the user directory \[ID_25080\]

In some cases, SLDataMiner could leak memory when retrieving security group information from the user directory.

#### Trending displayed incorrectly in case of multiple trend points in the same second \[ID_25097\]

If there were multiple trend points in the same second, it could occur that these were not sorted correctly, which could cause a trend graph to be displayed incorrectly.

#### DataMiner Cube: Problem when clicking several times in rapid succession or when a log folder was created on a clean client computer \[ID_25099\]

In DataMiner Cube, in some cases, an exception could be thrown when clicking several times in rapid succession or when the *C:\\ProgramData\\Skyline\\DataMiner\\DataMinerCube\\CubeLogging* folder was created on a clean client computer.

#### HTML5 apps: Last item in drop-down lists was hidden by the collapse button \[ID_25108\]

In the HTML5 apps (Ticketing, Jobs, etc.), in some cases, the collapse button at the bottom of a drop-down list would hide the last item in the list.

#### DataMiner Cube - EPM/CPE: No Topology button in sidebar \[ID_25120\]

On EPM/CPE systems, in some cases, no Topology button would be displayed in the sidebar.

#### DataMiner Cube - Visual Overview: Embedded Service Manager component would show an empty service definition diagram \[ID_25140\]

In some cases, a Service Manager component embedded on a Visio page would show an empty service definition diagram.

#### Problem with implicitly launched downgrade actions during other than full upgrades \[ID_25158\]

Up to now, other than full upgrades that restarted DataMiner would implicitly have downgrade actions executed as part of the “Start” step. When the upgrade package contained a buildinfo.bin file with an old version number, in some cases, that could leave the system in a corrupted state.

#### Dashboards app: Minor fixes made to trend graph legend \[ID_25159\]

A number of minor fixes have been made to the trend graph legend.

#### Primary key(s) would be parsed incorrectly when reading from a logger table \[ID_25167\]

When reading from a logger table, in some cases, the primary key(s) would be parsed incorrectly.

#### SLNetClientTest tool: Messages/events displayed incorrectly in follow session \[ID_25184\]

In some cases, in a follow session of the SLNetClientTest tool, it could occur that some messages or events were displayed as "*Skyline.DataMiner.Net.Serialization.ProtoBufSerializedMessage*", making it impossible to check their content.

#### DataMiner Cube - EPM: Duplicate parameters in EPM details \[ID_25199\]

In some cases, when DataMiner Cube polled a direct view table for updates, it could occur that EPM (formerly known as CPE) parameters in the corresponding EPM details overview were duplicated.

#### DataMiner Cube - Spectrum analysis: When a user disconnected from a shared session, the other users would stop receiving new traces \[ID_25201\]

When multiple users shared the same spectrum session, in some cases, from the moment one of those users disconnected, all other users would stop receiving new traces.

#### DataMiner Cube - System Center: Not possible to delete unused Visio files \[ID_25209\]

In some cases, it would no longer be possible to delete unused Visio files in the Tools section of System Center.

#### Problem with SLProtocol when starting a DVE element or a virtual function \[ID_25215\]

In some cases, an error could occur in SLProtocol when starting a DVE element or a virtual function.

#### ActiveDirectory.txt log file missing \[ID_25218\]

In some cases, it could occur that the *ActiveDirectory.txt* log file was not generated.

#### Problem with SLNet when performing a diagnostic request in the SLNetClientTest tool while view states were being recalculated \[ID_25219\]

In some cases, an error could occur in SLNet when you performed a diagnostic request (*Diagnostics \> Connections \> OpenConnections*) in the SLNetClientTest tool while view states were being recalculated.

#### Run-time error in protocol thread after dynamic IP change or close action of serial connection \[ID_25223\]

If a protocol with serial connection over UDP or TDC/IP used either an action of type "close" on a serial connection or a parameter with type option "dynamic IP", a run-time error could occur in the protocol thread.

#### Automation: Options text in narrow Automation script execution window not fully displayed \[ID_25226\]

In the window displaying the options for the execution of an Automation script, text wrapping was not implemented, so that it could occur that the text was not fully displayed if the window was too narrow.

#### Problem with EPM filters \[ID_25231\]

When an object in an EPM (formerly known as CPE) environment did not have a link to a parent object, it could occur that filters were loading indefinitely or kept showing the previous filter result.

#### Memory leak in SLNet when multiple documents were being added or deleted in rapid succession \[ID_25234\]

When multiple documents were being added or deleted in rapid succession, in some rare cases, SLNet could start leaking memory.

#### Mobile Gateway: Possible error when updating the cache due to a locking issue \[ID_25238\]

When SLGSMGateway updated its cache after an element had been added, updated or deleted, in some cases, an error could occur due to a locking issue.

#### Problem when the view column of a table containing DVE child elements to be created contained single view IDs \[ID_25255\]

A table containing DVE child elements to be created can have a column that contains the view(s) the child element has to be created in (i.e. a column with option=”view”). In the cells of this column, you can enter a single view ID, a single view name, a list of view IDs separated by semicolons, a list of view names separated by semicolons or a mixed list of view IDs and view names separated by semicolons.

In some cases, a problem could occur when single view IDs had been entered in this column.

#### Service & Resource Management: Capabilities marked 'ByProfileInstanceReference' would never go into quarantine \[ID_25260\]

When a capability usage on a ReservationInstance was updated by updating and applying a ProfileInstance, capability usages that needed to be quarantined would never be quarantined.

#### SLNet: Problem when restarting a DataMiner Agent \[ID_25263\]

In some rare cases, the following exception could be thrown when restarting a DataMiner Agent:

```txt
Exception during startup of SLNet: System.IO.IOException: The process cannot access the file 'c:\skyline dataminer\logging\SLClient.txt' because it is being used by another process.
```

#### DataMiner Maps: Clusters would not get refreshed when panning on a map that only contained layers of which the LimitToBounds attribute was set to False \[ID_25265\]

When panning on a map that only contained layers of which the *limitToBounds* attribute was set to False, in some cases, the clusters would not get refreshed.

#### Dashboards app - Service Definition component: Elements disappeared from service definition nodes when web sockets were disabled \[ID_25275\]

When a Service Definition component was added to a dashboard, in some cases, elements would incorrectly disappear from service definition nodes when web sockets were disabled.

#### Problem with SLNet when retrieving CPU usage or memory usage \[ID_25279\]

In some cases, an error could occur in SLNet when retrieving the CPU usage or the memory usage.

#### Automation: Scripts using a library could no longer be executed after a DataMiner restart \[ID_25282\]

After a DataMiner restart, in some cases, Automation scripts that used a library could no longer be executed because the DataMiner Agent was not able to find the DLL file of that library.

#### DataMiner Cube - Workspaces: A saved workspace could no longer be opened in an undocked window \[ID_25308\]

In some cases, it would no longer be possible to open a saved workspace in an undocked window.

#### DataMiner Cube - Data Display: When a multiple parameter update was canceled, the parameter values would stay marked as modified \[ID_25313\]

When you updated multiple parameter values in one go and then canceled the update, in some cases, the parameter values in question would stay marked as modified.

Also, after updating other values, the multiple update window would incorrectly keep displaying the values for which the update had been canceled.

#### DataMiner Cube - System Center: Colored background remained visible when no filter was applied on the Logging page \[ID_25316\]

When, on the Logging page in System Center, you apply a filter, the background turns blue to indicate that you are viewing a filtered list. In some cases, the background would remain blue after the filter had been removed.

#### DataMiner Cube - Correlation: New analyzer would incorrectly be created when opening the Correlation app via a workspace \[ID_25320\]

When you opened the *Correlation* app by opening a workspace, in some cases, the *Analyzers* tab would be selected and a new analyzer would incorrectly be created.

#### Service & Resource Management: When a resource was updated, usages of other resources would incorrectly also be quarantined \[ID_25322\]

When, for a particular resource, a capacity or capability was deleted or a capability was downgraded, not only would all usages of that resource be quarantined, but also all usages of other resources using the same capacity or capability profile as the one used by the resource that was updated.

#### DataMiner Cube: Problems when renaming/deleting Documents folders \[ID_25323\]

In some cases, it could occur that it was not possible to rename or delete a Documents folder in DataMiner Cube. In addition, when a Documents folder was deleted, it could occur that an incorrect message was displayed, which would remove the folder even if the user clicked "No".

#### Problem with subscriptions on virtual functions \[ID_25326\]

In some cases, subscriptions on virtual functions would not return the correct data.

#### Dashboards app - Service definition component: System function nodes did not show images \[ID_25329\]

In some cases, images would be missing from system function nodes displayed on a service definition component.

#### DataMiner Cube - Visual Overview: Filtered ListView listing services would not get updated when the filter value changed \[ID_25335\]

When, in Visual Overview, a ListView component was listing services and was filtered on a view, in some cases, the services list would not get updated when the filter value changed.

#### Problem with duplicate trend data points when retrieving real-time trend data from a MySQL database \[ID_25337\]

When real-time trend data was retrieved from a MySQL database, in some cases, duplicate trend data points could incorrectly be returned.

#### DataMiner Cube - EPM: Filters would not correctly handle user filter and partial table pages when linked to a diagram \[ID_25339\]

In some cases, EPM filters linked to a diagram would not correctly handle partial table pages and user filters. Only the first page of the result set would be loaded into the selection box, and a custom filter entered by the user would not be applied.

#### When a function resource was deleted, its row in the \[Generic DVE Linker Table\] would incorrectly not be removed \[ID_25356\]

When a function resource is created, a row is added to both the \[Generic DVE Table\] and the \[Generic DVE Linker table\]. When a function resource was deleted, in some cases, only the row in the \[Generic DVE Table\] was deleted. The row in the \[Generic DVE Linker table\] would incorrectly not get deleted.

#### Problem with interface properties of DVE elements \[ID_25360\]

When, in the DataMiner Connectivity Framework page of the General Parameters of an element, the \[Interface Properties\] table was updated, in some cases, some of the information in that table would not get synchronized correctly to the interfaces of the Virtual Function elements when linking them.

#### DataMiner Cube - Trending: Problem when export a trend graph to a CSV file \[ID_25369\]

When you exported a trend graph to a CSV file, in some cases, that CSV file would be formatted incorrectly, especially when the exported graph contained multiple lines.

#### Invalid alarm levels were passed to the parent items when bubble-up severity was identical to that of the table row and one of them got cleared \[ID_25383\]

When the bubble-up severity was identical to that of the table row itself, and one of those was cleared, in some cases, an invalid alarm level would be passed to the parent items.

#### Web Services API v0: GetActiveAlarmsFromView SOAP call would return alarms from parameters not included in the services found in the specified view \[ID_25391\]

When a GetActiveAlarmsFromView SOAP call was performed, all alarms of all elements in the services found in the specified view would be returned, even those associated with parameters that were not included in the services in question.

#### Element connections: Problem with 'Include element state' option \[ID_25418\]

In the *Element Connections* app, in some cases, the states of the source element would incorrectly be passed to the destination element(s) when the *Include element state* option was not selected.

#### DataMiner Cube - Services app: Problem when dragging and dropping in a service definition diagram \[ID_25434\]

In the *Services* app, in some rare cases, an exception could be thrown when performing drag and drop operations in a service definition diagram.

#### Service & Resource Management: No longer possible to save a service definition with an empty diagram \[ID_25439\]

In the Services app, in some cases, it was no longer possible to save a service definition with an empty diagram.

#### Alarm templates: Monitoring conditions would not get re-evaluated after a row or table update \[ID_25453\]

When, in an alarm template, conditional monitoring was configured, in some cases, conditions would not get re-evaluated after a row or table update.

#### Problem with SLDataMiner \[ID_25458\]

In some rare cases, an *OwnershipUpdateThread* error could occur in SLDataMiner.

#### DataMiner Cube - Visual Overview: Problem with FollowPathColor option \[ID_25460\]

In some rare cases, the *FollowPathColor* option would not get applied, especially when the connection lines ran between interfaces with an undefined alarm level state while the parent element had a different state.

#### DataMiner Cube: Inconsistent user initials \[ID_25464\]

Up to now, in some cases, user initials in DataMiner Cube would be inconsistent. Now, user initials will always be the first letters of the full name.

Note that, by design, the user selector at the bottom of the login screen will still display only one letter (i.e. the first letter of the full name).

#### DataMiner Cube - Services app: Items in diagram would still appear to be selected after switching from one tab to another \[ID_25468\]

When, in the Services app, you switched from one tab to another, in some cases, the items selected in the diagram would still appear to be selected although they were not.

#### DataMiner Cube - Data Display: Problem with filtering on discreet or numerical column parameters using wildcards \[ID_25472\]

In some cases, it would no longer be possible to filter on discreet or numerical column parameters using wildcards.

#### DataMiner Cube: Element/service not visible if moved from inaccessible view \[ID_25474\]

If an element or service was created in a view to which a particular user did not have access and then moved to a view to which that user did have access, it could occur that the user could not see the element or service until Cube was reloaded.

#### Problem when MaintenanceSettings.xml contained Trending tag without TimeSpan tag \[ID_25478\]

If the *MaintenanceSettings.xml* file contained a *Trending* tag that did not contain a *TimeSpan* tag, a problem could occur with the file.

#### Monitoring app: Problem when viewing a trend histogram for a column parameter with a primary key containing lowercase characters \[ID_25481\]

In the Monitoring app, in some cases, no data would be returned when viewing a trend histogram for a column parameter with a primary key containing lowercase characters.

#### Dashboards app - Parameter feed: Bottom arrow not displayed when 100 indices had been loaded \[ID_25492\]

When, in the parameter feed component, you had loaded 100 indices, the bottom arrow to load more indices would not be displayed.

#### DataMiner Cube - Element Connections: Problems with table parameters \[ID_25496\]

In the *Element Connections* app, in some cases, issues could occur with regard to table column parameters. Some rows would not disappear after being deleted and some rows would be missing data.

#### Web Services API v0/v1: Methods would return parameters to which users had not been granted access \[ID_25544\]

Some of the web methods would incorrectly return parameters to which users had not been granted access. From now on, a number of parameter-related methods will also require the “SDElementOverview” flag.

Also, the GetTableForParameterV2 method would incorrectly return table columns that had “width=0” defined in the protocol, and, in some cases, it would incorrectly be possible to update a parameter of an element marked as “read only”.

#### Trending data not cleaned up in Failover MySQL database \[ID_25552\]

If a Failover pair used MySQL local databases, it could occur that trending data was not removed from the database when its time to live had elapsed.

#### DataMiner Cube - Alarm Console: Correlation source alarms were sorted incorrectly \[ID_25570\]

When, in the Alarm Console, you opened a correlation alarm to view its source alarms, in some cases, those source alarms would not be sorted correctly.
