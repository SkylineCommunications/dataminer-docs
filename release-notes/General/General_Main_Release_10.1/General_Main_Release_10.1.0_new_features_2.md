---
uid: General_Main_Release_10.1.0_new_features_2
---

# General Main Release 10.1.0 - New features (part 2)

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

### DMS Cube

#### Data Display: Table column layout can now be customized and saved per table \[ID_22866\]

It is now possible to save the layout of a table column after having customized it.

After changing the width, the position and/or the visibility of a column, right-click its header, and select *Save layout*. To reset the column layout to the default settings, select *Reset layout*.

#### Alarm Console: Alarm events without a severity change can now be consolidated in the preceding event in the alarm tree \[ID_23234\]\[ID_23526\]\[ID_24462\]\[ID_27413\]

From now on, when an alarm tree contains alarm events that did not change the severity, these events can be consolidated in the previous event.

When you open an alarm card that shows an alarm tree containing consolidated events, you can click *Show all alarm updates* to have the tree expanded to show all events.

> [!NOTE]
>
> - The maximum alarm limit is calculated after alarm event consolidation.
> - Alarm consolidation is disabled by default. To enable it, add an *AlarmSettings.MustSquashAlarms* element to the *MaintenanceSettings.xml* file, and set its value to True.

#### Possibility to enable SSL/TLS encryption when creating or editing TCP/IP elements \[ID_23262\]\[ID_23617\]\[ID_23836\]\[ID_23947\]

When creating or editing a TCP/IP element, you can now enable SSL/TLS encryption.

To enable TLS, do the following on every DataMiner Agent in a DataMiner System containing elements that use TLS encryption:

1. In the C:\\Skyline DataMiner\\Certificates folder, place a PKCS12 file with (default) name “server.pfx”, containing the certificates and the private key.

1. Send a ConfigureTLSMessage with the following arguments:

   | Argument | Description |
   |----------|-------------|
   | DataMinerID | ID of the DataMiner Agent ID. |
   | EncryptedPassword | Encrypted password that will be used with the certificate in question. This is encrypted using the public key of the connection. |
   | Certificate | Name of the certificate for which the password is set. Default: server.pfx. |
   | ID | ID of the certificate for which the password is set. Currently, DataMiner will always use the certificate with ID 0. |

> [!NOTE]
>
> - DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1). It will negotiate the highest supported TLS version with the client. If the client supports TLS up to version 1.2, DataMiner will use version 1.2.
> - PFX files are not synchronized among the agents in a cluster.
> - When, on a DataMiner Agent, you replace a PKCS12 file, then all elements using the TCP/IP port in question have to be stopped and restarted for the changes to take effect.
> - TLS elements and non-TLS elements sharing the same TCP/IP port is not supported.

#### Elements that request data from a device via a serial port of type TCP/IP now support SSL/TLS encryption \[ID_23462\]

Elements that request data from a device via a serial port of type TCP/IP now support SSL/TLS encryption.

If you want such an element to use SSL/TLS encryption, then do the following:

1. Right-click the element, and select *Edit*.
1. In the *Edit* tab, go to the *Serial connection* section containing the settings of the port in question, and select the *SSL/TLS* checkbox.

> [!NOTE]
> DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1).
>
> Elements acting as SSL/TLS client will negotiate the highest supported SSL/TLS version with the server. If the server supports TLS up to version 1.2, the element will use version 1.2.

#### Service & Resource Management: Clearer warning messages will now appear when trying to delete resources linked to bookings or elements linked to resources \[ID_24435\]\[ID_25085\]

From now on, clearer warning messages will appear when you try to delete

- a resource linked to a booking, or

- an element linked to one or more resources.

#### Anomaly detection configuration in alarm templates \[ID_24578\]

It is now possible to enable specific anomaly detection options for parameters in an alarm template. To do so, select the *Advanced configuration of anomaly detection* option via the cogwheel button in the alarm template editor. Three additional columns will then be displayed in the alarm template, where you can enable or disable trend monitor, variance monitor and level shift anomaly detection for each monitored parameter.

#### Service & Resource Management - ListView: Alarm count column can now indicate the number of alarms as a colored icon \[ID_24598\]

In the ListView component, which is used in the Bookings and Services apps as well as in Visual Overview, the *Alarm count* column can now be configured to indicate the number of alarms as an icon taking the color of the most severe alarm.

#### New setting to display a Forward button in card header bar menus \[ID_24844\]

In the new Cube X layout, by default, cards no longer have a Forward button in their header bar menu.

If you want card header bar menus to contain a Forward button, then open the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file, and set the *commonServer.card.DisplayForwardButton* option to true.

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

This new feature relies on two new rule attributes: *keyType* and *keyValue*.

- The *keyType* attribute can have two values: “PK” (primary key) or “DK” (display key).

- The *keyValue* attribute has to contain the value that will be used in the condition.

In the example below, parameter 203 is a column of table 200, and the cell in column 203 that matches the corresponding key will be used in the condition.

```xml
<Condition id="5" name="Condition3">
  <Rule pid="203" comparer="eq" value="4" next="or" keyType="DK"      keyValue="DisplayKey3"/>
  <Rule pid="203" comparer="eq" value="3" keyType="PK"      keyValue="2"/>
</Condition>
```

> [!NOTE]
> Inside a rule, both the *keyType* and *keyValue* have to be filled in for this feature to work.
>
> The *keyValue* attribute will always refer to the key (primary key or display key) of the table containing the column parameter used in the condition, not the key in the column parameter being monitored.

#### Trending: Automatic pattern matching \[ID_24893\]\[ID_25708\]

On systems with a Cassandra database and an Indexing Engine, from now on, DataMiner will be able to automatically recognize recurring patterns in trend data called “tags”.

To define a tag:

1. In a trend graph showing trend information for one single parameter, select the portion of the graph that you identify as being a recurring pattern.
1. Enter a tag name and click the check mark to save.

Any matching patterns in the current trend graph will immediately be highlighted in orange. Matches found for the same element/parameter as the one for which a tag was defined will appear in bright orange, whereas matches associated with tags created for another element/parameter will appear in a slightly lighter hue.

> [!NOTE]
> If automatic pattern matching is enabled, each time you open a trend graph of a parameter for which patterns have been defined, all trend graph portions that match one of the saved patterns will be highlighted.

To edit a tag:

1. Click the tag button above the (highlighted) pattern you want to edit.
1. To edit the tag name, click the pencil icon and change the name.
1. To redefine the pattern, adjust its boundaries.
1. To save any modifications, click the check mark.

> [!NOTE]
> If you edit a tag, the pattern will always be overwritten, even if you did not redefine the pattern in any way.

To delete a tag:

1. Click the tag button above the (highlighted) pattern you want to delete.
1. Click the delete icon.
1. In the confirmation box, click *Yes*.

> [!NOTE]
>
> - If you delete a tag, all pattern matches associated with that tag will also be deleted.
> - If a protocol is deleted, all patterns defined for parameters of that protocol will also be deleted the first time the SLAnalytics service restarts.

##### Current limitations

Currently, automatic pattern matching has the following limitations:

- Patterns must have a size between 8 and 50,000 data points and should not have more than 5 percent missing values.
- Pattern matching can only be performed on trended parameters containing numeric values.
- If pattern matching is performed on a trend graph showing more than 100,000 data points, an aggregated level of detail will be used to improve performance at the cost of accuracy. If, at the most aggregated level, the number of data points exceeds 100,000 data points, no pattern matching will be performed.

##### Changes as to trend graph mouse button actions

In the *User \> Trending* section of the *Settings* window, the *Left mouse button action on graph* and *Right mouse button action on graph* settings can now be set to one of four values:

- Select (new option, allowing you to select part of a trend graph)
- Zoom (former “Select” option, default right mouse button action)
- Pan (default left mouse button action)
- None

In case of the (new) “Select” option, a quick menu will appear, allowing you to either zoom to the part of the trend graph you selected or to create a tag (see above). On both sides of the selection, thumb draggers will also appear to allow you to resize the area you selected.

Also, apart from the *Left mouse button action on graph* and *Right mouse button action on graph* settings, two new settings have been added:

| Setting                                    | Description                                                                                                                                |
|--------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| Hotkey for mouse button action on graph    | The key that, when pressed while clicking the left mouse button, will cause the “hotkey + left mouse button action” to be performed.       |
| Hotkey + left mouse button action on graph | Action to be performed when you press the “hotkey for mouse button action” while clicking the left mouse button: Select, Zoom, Pan or None |

#### Alarm Console: Severity duration column in history alarm tabs \[ID_24942\]

Next to active alarm tab pages, history tab pages now also allow you to display a severity duration column.

On history tab pages, a severity duration column will be available either when no filter is applied or when a filter based on Element ID, DMA ID, Element Type, Parameter ID, Protocol and/or Source ID is applied.

DataMiner Cube will calculate severity durations based on the alarms listed on the history tab page in question. If the duration of an alarm cannot be calculated (e.g. because the next alarm is not listed on the history tab page, or because the alarm has not been cleared while the element is stopped), the severity duration column will show “N/A”.

Additionally, a number of enhancements have been made with respect to severity durations. For instance, it is now also possible to display the severity duration when history tracking is disabled.

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

#### System Center: New “Analytics config” system settings section \[ID_25124\]\[ID_26388\]\[ID_26912\]

In *System Center*, the *System settings* section now contains a new *Analytics config* page, which allows you to configure a number of SLAnalytics settings.

> [!NOTE]
> If you take a DMA out of a cluster, we strongly recommend to restart it in order to prevent issues with the analytics configuration in case the DMA is added to the cluster again later.

#### Alarm Console: Automatic incident tracking \[ID_25162\]\[ID_25802\]\[ID_25905\]\[ID_26592\]\[ID_27027\]\[ID_27299\]\[ID_27336\]\[ID_27877\]

This new DataMiner Analytics feature groups active alarms that are related to the same incident, so that the Alarm Console provides a better overview of the current issues in the system. Unlike *Correlation tracking*, this happens completely automatically, without any configuration by the user. Based on what it has learned from past alarm activity in your system and based on a broad range of auxiliary data, DataMiner Analytics automatically detects which alarms share a common trait and groups them as one incident.

To activate this feature, in the Alarm Console hamburger menu, select *Automatic incident tracking*. However, note that the feature must also be activated in System Center (see “Configuration in System Center” below).

Several factors are taken into account for the grouping:

- The polling IP (for timeout alarms only)
- Service information
- The IDP location (only in case the IDP Solution is deployed)
- Element information
- Parameter information
- Time
- Alarm focus information

If no suitable match is found, alarms will not be grouped. Note that, since only alarms with a focus score are taken into account, automatic incident tracking does not apply to information events, suggestion events or notice messages. In addition, if the alarm focus feature is disabled on one or more DMAs in the DataMiner System, only partial results will be available.

The grouping of alarms into incidents is updated in real time whenever appropriate:

- New alarms are added to existing groups if they match.
- A group is cleared if its base alarms are cleared or if the reason for its original creation comes to an end.
- If a group is cleared, any alarms in the group that are still active may be regrouped if other matching alarms exist, either in a new group or in an existing one.

In the Alarm Console, alarm groups are displayed as a special kind of alarm entries:

- The icon of an alarm group is similar to that of a correlated alarm.
- The alarm color of an alarm group entry reflects the highest severity of the alarms within the group, but the severity of the group itself is *Suggestion*.
- The parameter description of the entry is *Alarm Group*.
- The value of the entry is the reason why the alarms are grouped. If there is no single obvious reason, the value will be *Group with multiple reasons*.
- The root time of the group is the root time of the most recent alarm in the group at the time when the group was created.
- If alarms are added to a group or removed from a group, the alarm type will be updated from *New alarm* to *Base alarms changed*.
- You can expand the group to view all alarms within it.
- If all alarm entries within an alarm group are masked, the group is automatically masked as well. However, as soon as one of the entries is unmasked, the group is also unmasked.

> [!NOTE]
>
> - Using automatic incident tracking with history sets is supported; however, keep in mind that this may trigger the creation and immediate clearing of a large number of alarm groups.
> - When an element is stopped or paused, the alarms associated with that element will not be taken into account when grouping alarms. Also, alarms associated with elements that are stopped or paused will be removed from any existing alarm group.

In DataMiner Cube, you can enable this feature in *System Center*, via *System settings \> analytics config \> automatic incident tracking*. The following settings are available there:

| Setting | Description |
|--|--|
| Leader DataMiner ID | The DMA performing all incident tracking calculations. By default, this is the DMA with the lowest DataMiner ID at the time when alarm grouping is enabled. |
| Enabled | Allows you to activate or deactivate this feature. Note that when you upgrade to DataMiner 10.0.11, the feature is automatically disabled, unless it had been previously been activated as a soft-launch feature. |
| Maximum time interval | The maximum time interval between alarms that can be grouped as one incident. If the root times of alarms are further apart than the configured interval, the alarms will not be grouped. |

#### Alarm hyperlinks: \[DisplayValue\] keywords now allows to display the value of a discreet parameter \[ID_25294\]

In second-generation alarm hyperlinks, you can now use the \[DISPLAYVALUE\] keyword to display the value of a discreet parameter.

#### Client machines running Cube now require Microsoft .NET Framework v4.6.2 \[ID_25309\]

Client machines running DataMiner Cube now require Microsoft .NET Framework 4.6.2.

#### Profiles app: Support for capability parameters of type 'text' \[ID_25345\]

The *Profiles* app now also allows you to create and edit profile parameters of category “Capability” and type “Text”.

#### DataMiner Cube - Alarm templates: Conditional monitoring now support checking whether a parameter value is equal or not equal to 'Not Initialized' \[ID_25352\]\[ID_25644\]

In an alarm template, it is now possible to configure monitoring conditions that check whether a parameter value is equal or not equal to “Not Initialized”.

A drop-down box now allows you to choose between “Value” (default) and “Not initialized”. Note that, when you choose “Value” and enter a parameter value, that value will not be cleared when you later select “Not initialized”.

#### Creating an element simulation file \[ID_25353\]

On a DataMiner System, you can create simulated elements. These elements behave as if they are communicating with a physical device, but in fact they are merely displaying data from a simulation file.

From now on, in Cube, you can not only enable a simulation file, but also create one. To do so, in the navigation pane on the left, right-click the element for which you want to create a simulation file, and select *Actions \> Create simulation*.

When you open an element card, you can also access this same command via the card’s hamburger menu.

The simulation file will be stored on the DataMiner Agent, in the protocol folder of the element in question: *C:\\Skyline DataMiner\\Protocols\\NAME\\VERSION\\Simulation_ELEMENTNAME.xml*

#### Resources app: Time-dependent capabilities \[ID_25409\]

When, in the *Resources* app, you assign a capability parameter to a resource, instead of specifying a fixed value for that parameter, you can now indicate that its value will be time-dependent, i.e. that the capability of the resource can change over time.

#### Alarm Console: Special Indexing Engine search tab is now available without enabling the 'System configuration \> Indexing Engine \> UI Available' user permission \[ID_25429\]

On systems on which the alarms were migrated to an Indexing Engine, up to now the special Indexing Engine search tab would only be available in the Alarm Console of users who had been granted the “System configuration \> Indexing Engine \> UI Available” user permission. From now on, that search tab will be available to all users, regardless of whether they were granted the above-mentioned user permission.

#### Analytics tables in Elasticsearch database can now be included or excluded in custom DataMiner backup \[ID_25572\]

When you configure a custom backup in Cube, you can now select whether the Analytics tables in the Elasticsearch database, which are used for pattern matching, should be included. To do so, in System Center, go to the *content* tab of the *Backup* page, select the *Use custom backup* option, select *Create a backup of the database*, and either select or clear the selection of the checkbox *Include analytics tables in backup*. By default, this option is selected.

#### View cards: New columns added to view card list view \[ID_25715\]

On view cards, the list view now has two additional columns:

- *Element timeout time*: The total timeout time for each of the element’s connections (in milliseconds). This is the timeout time that corresponds with the element setting *The element goes into timeout state when \[...\]*. For multiple connections, the values are separated by commas.

- *Host ID*: The ID of the DMA hosting the element, service, SLA or redundancy group.

#### SNMP Managers: New alarm storm prevention option 'Group alarms with the same parameter name' \[ID_25717\]\[ID_25984\]

When you have enabled alarm storm prevention while configuring an SNMP manager, you can now choose to select the “Group alarms with the same parameter name” option.

If this option is selected, alarm storm prevention will happen based on the number of alarms occurring per parameter; otherwise, it will happen based on the number of alarms across parameters.

By default, this option is selected.

#### Services app: New 'Profiles' tab page \[ID_26111\]

The Services app now has a new “Profiles” tab page, which will allow you to manage Service Profile Definitions and Service Profile Instances.

#### Services app: Profile can now be referred to by value or by reference when configuring a service definition node \[ID_26118\]

When you configure a node in a service definition, a toggle button now allows you to specify whether the selected profile will be assigned by value or by reference.

#### Data Display: Number groups in numeric values will now be separated by a thin space \[ID_26251\]

In Data Display, three-digit number groups in numeric values will now by default be separated by a thin space. This will make large numbers more legible.

> [!NOTE]
> This so-called thousands separator will only be used to display numbers. Numbers that are copied, edited or exported will not contain any number group separators.

#### Services app: New and updated booking state icons \[ID_26270\]

In the *Overview* tab of the *Services* app, the booking state of a service is indicated by an icon in the *Booking state* column.

- A new icon has been added to indicate service permanent bookings that start somewhere in the future:

  ![Future permanent booking icon](~/release-notes/images/BookingOngoingPermanentFuture.png)

- The icons used to indicate the state of one or more bookings linked to a service will now be displayed in the following order:

  - Permanent ongoing
  - Ongoing
  - Permanent in future
  - Future
  - Past/None

#### DataMiner Cube start window: New method to install a DataMiner Cube desktop application \[ID_26282\]\[ID_26381\]\[ID_26725\]\[ID_26752\]\[ID_26788\]\[ID_26986\]

From now on, you can use the DataMiner Cube start window to install DataMiner Cube as a desktop application.

This offers a number of advantages. It allows you to deploy multiple Cube versions side by side, and it will automatically select the correct Cube version when you connect to a DMA.

1. Browse to your DMA using a different browser than Internet Explorer.
1. Enter your username and password to log in.
1. Select *Desktop installation* and run the downloaded file.
1. In the installation window, open the *Options* section and adjust the options depending on whether you want a shortcut to be added to the desktop and/or start menu and on whether you want DataMiner Cube to start with Microsoft Windows.
1. Click *Install*.

##### Host name validation

When you add a new DataMiner Agent or DataMiner System to the start window, the host name you enter will be validated:

- Is it a valid IP address or host name?

    > [!NOTE]
    > If the host name cannot be validated, you will be able to add it, but a warning message will appear.

- Is it accessible over HTTP and/or HTTPS?

    > [!NOTE]
    > If the DMA is accessible over HTTPS, the configuration will be modified to make sure Cube will always connect to that agent over HTTPS. However, if there are any issues with the HTTPS certificate, those issues will be indicated and HTTP will be used instead.

- Is it a DataMiner Agent?

> [!NOTE]
>
> - Although it is still possible to install a DataMiner Cube desktop application using an MSI installation package, it is strongly advised to use the new installation method instead.

##### Periodic updates of DataMiner Cube

The first time you open the start window, a task named “Update DataMiner Cube” will be added to Windows Task Scheduler. Every 3 days, that task will open the start window with the /Update argument. The /Update argument combines the /UpdateClients and /UpdateLauncher arguments. See below.

| Argument | Function |
|--|--|
| /UpdateClients | Checks, for all the DataMiner Systems to which you have connected in the last 100 days, whether a new Cube version is available. If so, it will immediately be downloaded. |
| /UpdateLauncher | Checks for a newer version of DataMiner Cube on <https://dataminer.services>. If a newer version is found, it will immediately be downloaded and installed. If no newer version can be found on <https://dataminer.services>, then the 10 DataMiner Systems to which you connected last will be checked for a new version. |

The scheduled task is checked each time you open the start window, and is removed when you uninstall DataMiner Cube. Periodic updates can be suspended by disabling the task in Windows Task Scheduler.

#### SNMP Managers: Polling IP address can now be added as a custom trap binding \[ID_26339\]

When configuring an SNMP manager, you can now add the polling IP address as a custom trap binding.

#### Profiles app: Display value configuration possible for capability profile parameters of type discrete \[ID_26379\]

Previously, when you configured a capability profile parameter of type discrete, it was not possible to specify display values for the raw values of the parameter. Now, with the *Discrete type* drop-down box, you can specify whether the display values are text or a number. Depending on this selection, the selection box for the discrete parameter will be either a text box or a spin box. When you specify the possible values for the parameter, there is now also an additional *Display value* column where you can specify the display value corresponding with each raw value. Both a raw value and a display value always need to be specified. The raw values always have to be unique, but this limitation does not apply for the display values.

Capability profile parameters of type discrete that were configured before this change will have no discrete type selected. For these parameters, the display value will remain equal to the raw value, unless they are reconfigured.

#### Export: Selecting multiple items to be exported / New option to export data as displayed in view card \[ID_26450\]

From now on, it is possible to select multiple objects in a list and export them together in one file.

Also, when indicating which data to export, it is now possible to select the *Data as displayed in view card* option.

#### Service & Resource Management - Profiles app: Value of a capability of type 'text' can now be changed regardless of the 'User time-dependent' option \[ID_26538\]

Up to now, when you configured a profile instance, the value of a capability of type “text” could only be changed when the “Use time-dependent" option was selected. From now on, it will be possible to change the value of a capability of type “text” regardless of the “User time-dependent" option.

#### System Center - SNMP forwarding: Generate MIB file \[ID_26591\]

When an SNMP manager is configured to forward SNMPv2 or SNMPv3 traps with custom bindings, then you can now generate a MIB file containing those custom bindings.

To do so, go to the *Notification* tab of the SNMP manager in question, open the pane listing the custom bindings and click the *Generate MIB file...* button.

> [!NOTE]
> The *Generate MIB file...* button will only be enabled when
>
> - *Notification OID* is set to “Use custom bindings”,
> - the list of custom bindings contains at least one entry, and
> - all changes to the SNMP manager in question have been saved.

#### Default browser engine is now Chromium \[ID_26662\]

From now on, Cube will use Chromium as the default browser engine. When that engine is not installed, it will fall back to the first installed browser (currently, on most systems, this will be Microsoft Internet Explorer).

Although it will remain possible to configure that a different browser should be used for specific protocols, it will no longer be possible to configure that a different browser should be used for apps like Dashboards or Ticketing. Those apps will now always use the default browser engine.

When, on a Visio page, you configured a shape to display a web page, that web page will now also by default be rendered using the Chromium browser engine. However, if you want to explicitly specify the browser engine to be used, then add a shape data field of type *Options* to the shape and set its value to either “UseChrome” or “UseIE”.

> [!NOTE]
> Cube also use the default browser engine when displaying annotations.

#### Alarm Console: 'Show in banner' option can now also be set in the Settings window \[ID_26993\]

The *Show in banner* option, which up to now could only be set in the hamburger menu of the Alarm Console, can now also be set in *Alarm Console* section of the *Settings* window, both as a user setting and a group setting.

> [!NOTE]
> This option can only be set for one alarm tab page. When you activate the option for a particular tab page, it will automatically be deactivated for all other tab pages.

#### DataMiner Cube desktop app: Update release tracks \[ID_27086\]\[ID_27121\]

To allow a phased rollout of new versions of the DataMiner Cube desktop app, multiple release tracks have now been introduced: a release track with the latest version, and 3 phased release tracks.

To update to the release track with the latest version, you can use the *Check for updates* option, which is now available via the cogwheel button in the DataMiner Cube start window.

Updates to the phased release tracks happen automatically through periodic updates. The update track used for these updates is randomly selected and saved in the configuration of the app.

New versions are first made available in the release track with the latest version and in one of the phased release tracks. If no issues are detected, the other phased release tracks are also updated one by one.

The updates are retrieved from dataminer.services or from the most recently connected DataMiner Systems if dataminer.services cannot be reached.

#### Profiles app: Converters \[ID_27264\]

In the *Profiles* app, it is now possible to configure a converter (i.e. a mediation snippet) for a parameter linked to a profile parameter.

To configure a converter, do the following:

1. Open the *Profiles* app and go to the *Parameters* tab.

2. Open a parameter (or create a new one).

3. In the *Linked with* table at the bottom, add, edit or duplicate an entry.

4. In the *Edit link with protocol* box, activate the *Converter* setting, enter the converter code in the code window, and click *OK*.

    In the *Linked with* table, the *Converter* column will now show either the class name of the converter or, if no class name could be found, the first line of the converter code.

5. Click *Save* to apply the changes you made.

> [!NOTE]
> When you edit a linked parameter with a converter, the *Converter* setting will automatically be activated.

#### Trending: Full-term trend prediction \[ID_27281\]\[ID_27320\]

On a system with a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Up to now, three types of trend prediction could be displayed: short-term, mid-term and long-term prediction. From now on, you can also choose to display full-term prediction, which is based on either daily data points or a server-side aggregated set of one-hour data points.

#### DataMiner Cube will now display more detailed information when you try to connect to a DataMiner Agent that is starting up \[ID_27308\]\[ID_27770\]

When you try to connect to a DataMiner Agent that is starting up or that is being restarted, DataMiner Cube will now display more detailed information regarding the startup process.

Examples of messages that will be displayed:

- Offloaded files are currently being restored to Cassandra

- Starting element X

#### Elements, services and redundancy groups hosted by a disconnected DMA will now be indicated as being disconnected \[ID_27313\]\[ID_27611\]\[ID_27613\]\[ID_27760\]

Up to now, when a DataMiner Agent disconnected from the DataMiner System, the elements, services and redundancy groups hosted by it would disappear from the Cube’s Surveyor. From now on, they will remain visible (read-only), and will be indicated as being disconnected by means of a special icon.

> [!NOTE]
>
> - The cache is not persistent.
>   - When the disconnected DMA restarts, its elements, services and redundancy groups will no longer be available to the other DMAs in the DMS.
>   - When another DMA joins the DMS, the elements, services and redundancy groups of the disconnected DMA will not be available to the new DMA.
> - Any messages sent to the disconnected DMA (e.g. to retrieve or update information) will result in an exception being thrown.

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

#### Trending: Exclude gaps option in export window \[ID_27506\]\[ID_28067\]

When you export a trend graph to CSV, a new *Exclude gaps* option is now available. If you select this option, the export will skip any gaps in the trend data.

#### Correlation/Automation/Scheduler: Email report configuration \[ID_27521\]\[ID_27812\]\[ID_27878\] \[ID_28032\] \[ID_28038\]\[ID_28081\]

In an *Email* action of a Correlation rule, an Automation script or a scheduled task, as well as in the *Upload report to FTP* and *Upload report to shared folder* actions in an Automation script, if you add a report based on a dashboard, you can now click a *Configure* button to open an embedded browser window where you can configure the necessary data feed selections as well as the following options:

- *Add DMS info*: Determines whether company details are displayed in the report.

- *Add DMS logo*: Determines whether the company logo is displayed in the report.

- *Include feeds*: Determines whether feed components are included in the report. By default, this option is not enabled.

- *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

- *Dashboard width*: Allows you to select a custom width for the report.

#### Trending: Percentile line \[ID_27533\]

It is now possible to visualize a percentile line on a trend graph in DataMiner Cube. To do so, right-click the graph and select *Show percentile*. By default, the 95th percentile for the data in the current range will then be calculated and visualized with a line on the graph. To the right of the line, you will see the percentile that was calculated and the value of the percentile.

If the range of the graph is adapted, the percentile is not automatically updated, so that you can compare the percentile for a certain range with the data for a larger or smaller time frame. The percentile line will be displayed as a full line over the range for which it was originally displayed, and as a dashed line over the rest of the graph.

When you click the percentile line, a refresh option is displayed that allows you to refresh the percentile to the currently displayed data. Clicking the line also displays the option to adjust the percentile, so that you can e.g. display the 90th percentile instead.

Finally, in the *Trending* tab of the Cube user settings, a new *Show percentile* setting is now available, which can be used to have the percentile line displayed by default whenever a trend graph is opened. If this option is selected, you can also select which percentile should be calculated by default.

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

- Open the header bar’s quick menu, and activate or deactivate the *Show cluster name* setting.

    or

- Open the *Settings* window, go to *Computer \> Cube*, and select or clear the *Display cluster name in header* setting.

#### DataMiner Cube desktop app: Silent installation, modification and uninstallation of Cube \[ID_27795\]

Using the following command-line arguments, it is now possible to silently install, modify and uninstall the DataMiner Cube desktop app without any user interface.

##### General syntax

```txt
PathToCubeExe.exe <arguments>
```

> [!NOTE]
> All arguments and options are case insensitive.

##### Arguments to install DataMiner Cube

| Argument | Description |
|--|--|
| /Install | Check whether DataMiner is installed, and if not, open the installation wizard. |
| /Install /Silent | Check whether DataMiner is installed, and if not, install DataMiner Cube and exit when done.<br> If no options are specified using an /InstallOptions argument, the default installation options will be used. |
| /InstallOptions | Comma-separated list of additional installation options:<br> - DesktopShortcut (add a desktop shortcut)<br> - NoDesktopShortcut (do not add a desktop shortcut)<br> -  StartMenuShortcut (add a start menu shortcut)<br> - NoStartMenuShortcut (do not add a start menu shortcut)<br> - StartOnLogin (start Cube in the system tray after login)<br> -  NoStartOnLogin (do not start Cube in the system tray after login)<br> - OpenAfterInstall (open the start window after installation)<br> - NoOpenAfterInstall\* (do not open the start window after installation)<br> \* Default option for silent installs |

Example of a silent command to install DataMiner Cube when no installation could be found:

```txt
PathToCubeExe.exe /Install /Silent /InstallOptions:StartOnLogin
```

##### Arguments to modify DataMiner Cube after installation

| Argument | Description |
|--|--|
| /Modify | Open the “Modify installation” window. If there is a /ModifyOptions argument, the options specified in that argument will be preselected. |
| /Modify /Silent | Silently modify the DataMiner Cube installation using the options specified in the /ModifyOptions argument. |
| /ModifyOptions | Comma-separated list of modification options:<br> - ClearProtocolCache<br> - ClearVisioCache<br> - ClearVersionCache (remove all cached versions)<br> - RemoveVersion:versionnumber (remove the specified version from the cache) |

Example of a silent command that will clear the protocol cache, clear the Visio cache and remove two versions from the cache:

```txt
PathToCubeExe.exe /Modify /Silent /ModifyOptions:ClearProtocolCache,ClearVisioCache,RemoveVersion:9.5.1638.4080,RemoveVersion:10.0.2042.1636
```

##### Arguments to uninstall DataMiner Cube

| Argument          | Description                        |
|-------------------|------------------------------------|
| /Uninstall        | Open the uninstall window.         |
| /Uninstall/Silent | Silently uninstall DataMiner Cube. |

#### Protocols & Templates: Information template editor now also allows you to configure parameters of type Button and ToggleButton \[ID_27823\]

As to button parameters, up to now, the information template editor only allowed you to configure parameters of type PageButton. From now, it will also be possible to configure parameters of type Button and ToggleButton.

#### DataMiner Cube: Buttons to join and leave cluster renamed \[ID_27863\]

On the *Agents* > *Manage* page in System Center, the *Add cluster* and *Delete cluster* buttons have been renamed to *Join cluster* and *Leave cluster*, respectively.

#### New EPM card settings \[ID_27874\]

In the DataMiner Cube user settings, you can now configure the following EPM card settings:

- Default EPM card page

- How to show EPM card Visual pages

#### Trending - Pattern matching: New options when adding or editing a tag \[ID_27954\]

When adding or editing a tag, you can now select the following additional options:

| Option                       | Description                                                                                                  |
|------------------------------|--------------------------------------------------------------------------------------------------------------|
| '\<instanceName>' only       | Select this option if you want the tag to only match one specific display key and parameter.                 |
| Generate alarm when detected | Select this option if you want suggestion events to be generated when a match is detected in the trend data. |

> [!NOTE]
> When you save a tag after selecting the *Generate alarm when detected* option, a message box may appear, saying that suggestion events cannot be generated for that tag. This is due to the range of the tag being too large. The tag itself will be saved and detected.

#### Trending: Trend percentile will now be calculated using either average or real-time trend data \[ID_27965\]

Up to now, the trend percentile was calculated using the most detailed data set that was available. In cases where the trend window contained both real-time and average trend data, it would be calculated using both types of data.

From now on, from the moment the trend window contains average data points in its most detailed set, only average data will be used for the calculation. This is also be reflected in the percentile menu, where a warning icon will be shown. A tool tip on the warning icon will indicate when only average data will be used.

#### DataMiner Cube start window: Aliases \[ID_27975\]\[ID_27999\]\[ID_28161\]

When defining a DataMiner Agent in the start window, apart from the host name or IP address, you can now also specify an alias.

By default, the alias will be identical to the cluster name. If you specify a custom alias, it will replace the cluster name in the Cube header and the Windows task bar.

Command-line arguments: /Alias=Xyz /Host=hostname

> [!NOTE]
> Always use the /Alias argument in conjunction with the /Host argument.
>
> The alias will be used as long as the client is connected to the host specified in the Host argument.

#### System Center: Enhanced Database section \[ID_27976\]\[ID_28196\]

The *Database* section of *System Center* now has three main tab pages.

- In the *General* tab page, you can select “Database per agent” or “Database per cluster”.

  - When you select “Database per agent”, you can configure the local databases per agent.
  - When you select “Database per cluster”, you can configure a Cassandra cluster acting as a shared local database.

- In the *Offload* tab page, you can configure the data offloads to a central database.
- In the *Other* tab page, you can configure an additional database.

> [!NOTE]
> Throughout DataMiner Cube, the term “central database” has now been replaced by “offload database”.

#### Trending: Real-time pattern matching \[ID_28054\]

Up to now, pattern matching happened on the fly when a trend graph was opened. Now, apart from this so-called static pattern matching, DataMiner is also able to perform real-time pattern matching and generate an alarm as soon as a pattern is detected.

When you create a pattern in DataMiner Cube, you can now select the following new options:

- When you select the *Generate an alarm when detected* option, DataMiner will track the pattern in real time and trigger a suggestion event each time it detects the pattern.

  When you do not select this option, DataMiner will behave as before and use static pattern matching instead.

- When specifying the parameter, in case of a table parameter, you can now also add the display key.

  > [!NOTE]
  > This option is not linked to the type of pattern matching that is being used (static or real-time).

##### Limitations

- If you tag a pattern for a parameter of which the polling time is specified in the protocol, then the pattern must have less than 5000 real-time points. If the polling time is not specified in the protocol, then the pattern must be shorter than 24 hours. When you select a longer pattern, DataMiner Cube will display a warning and revert to static pattern matching for that specific pattern.

- For real-time pattern matching, DataMiner will only use a maximum of 2 GB of internal memory.

  - As soon as DataMiner uses more than 1.5 GB of internal memory for real-time pattern matching, the following notice will appear in the Alarm Console:

    *Pattern matching memory high, adding more patterns or parameters might reduce matching accuracy.*

    This notice will appear at most every 2 weeks or after a DataMiner restart.

    In order to reduce memory usage, users can either remove patterns that are being tracked in real time or restrict the number of parameters for which patterns are being tracked in real time (e.g. by specifying a display key in case of table parameters).

  - As soon as DataMiner uses more than 2 GB of internal memory for real-time pattern matching, the following notice will appear in the Alarm Console:

    *Pattern matching memory critical, patterns with suggestion events enabled may not match properly.*

    This notice will appear at most every 2 weeks or after a DataMiner restart.

    Also, when users create a pattern, DataMiner will now always revert to static pattern matching, even if they selected the *Generate an alarm when detected* option.

  - DataMiner checks all changes made to parameters for which patterns are being tracked in real time. If there are more than 6000 parameter changes per second, the following notice will appear in the Alarm Console:

    *High load on pattern matching functionality: reduced pattern match accuracy.*

##### Suggestion events

In case of real-time pattern matching, pattern occurrences are communicated to the user by means of suggestion events in the Alarm Console, i.e. alarms with severity “Information” and source “Suggestion Engine”. These events can be displayed in a separate *Suggestion events* alarm tab.
