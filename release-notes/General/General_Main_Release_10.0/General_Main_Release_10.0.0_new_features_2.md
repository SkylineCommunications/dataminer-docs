---
uid: General_Main_Release_10.0.0_new_features_2
---

# General Main Release 10.0.0 - New features (part 2)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> From DataMiner 10.0.0/10.0.2 onwards, DataMiner Service & Resource Management also requires DataMiner Indexing.

### DMS Cube

#### DataMiner Analytics: Behavioral anomaly detection and suggestion events \[ID_15723\]\[ID_15914\] \[ID_15916\]\[ID_15951\]\[ID_15952\]\[ID_15976\]\[ID_16001\]\[ID_16050\]\[ID_16163\]\[ID_17279\]\[ID_17462\] \[ID_19224\]\[ID_24095\]\[ID_24126\]\[ID_24147\]

The DataMiner Analytics software now allows you to configure behavioral anomaly detection and to display suggestion events in the Alarm Console.

The purpose of this new feature is to detect anomalous changes in the behavior of individual parameters in real time.

> [!NOTE]
> Behavioral anomaly detection and suggestion events are only available on DMAs using a Cassandra database. If none of the DMAs in a cluster use Cassandra, the anomaly configuration options are not displayed.

##### Current limitations

- Only possible for trended parameters with numeric values.
- Not possible for partial table parameters.
- Anomaly detection is limited to 100,000 parameters per DataMiner Agent.
- Processing of change points (see below) is limited to 1,000 points per second. If the buffer receives more than 100,000 change points in rapid succession, some of those may be disregarded.

##### Change points

Any change in behavior is called a change point. At present, there are five types of change points:

- **Outlier**: A value that suddenly spikes upwards or downwards, but returns to its previous, normal behavior after a few points.
- **Level shift**: A value that shifts upwards or downwards (similar to an outlier) and then stays at that new level.

  Example: A value fluctuating around 0 which starts fluctuating around 10.

- **Variance change**: A value of which the variance either increases or decreases.

  Example: A series like 0.5, 0.6,-0.5,-0.2, 1,… 5,8,9,-5,-6,-2.1,… indicates a variance increase. At some point, a value that is fluctuating around 0 between 1 and -1, starts fluctuating around 0 between 10 and -10.

- **Trend change**: A value that suddenly starts increasing or decreasing at a rate different from the normal behavior.

  Examples:

  - A value fluctuating around 10 (i.e. a trend slope of 0) which suddenly starts increasing 1 unit per second (i.e. a trend slope of 1).
  - A value fluctuating around a line with slope 1 which suddenly starts fluctuating around a line with slope -1.

- **Unlabeled change**: If a change point cannot be classified as one of the above-mentioned change points, it is considered an unlabeled change.

##### Behavioral anomalies

Some change points are more significant or unexpected than others. The stranger the current change point is compared to past change points, the higher its significance will be.

Of every new change point, its significance is calculated based on its characteristics (change point type, direction, absolute or relative change size, etc.), taking into account the parameter's change point history of the last month. The change points that are considered the most significant, i.e. the most “surprising”, are labeled “anomalous”.

Level shifts which are higher or which have a different direction than previous recent jumps, or which jump to a previously unseen level, will typically be labeled “anomalous”. Similarly, trend or variance changes will be labeled “anomalous” when no earlier trend or variance changes in the same direction appeared during the last weeks.

Currently, no change points of type “outlier” or “unlabeled” will be labeled “anomalous”.

##### Change points visible in trend graphs

On a trend graph, a change point is indicated by a bar below the graph. The length of the bar indicates the approximate time frame in which the change started, the height of the bar indicates the importance of the change, and the color of the bar indicates the severity.

When you hover the mouse pointer over a change point bar, a semi-transparent ribbon will appear over the entire height of the trend graph, showing more information about the change point.

Labels of change points of type “trend change” will indicate the level of increase or decrease in seconds, minutes, hours or days depending on the value. If, for example, the value increases by 0.01 per second (i.e. 0.6 per minute, 36 per hour or 864 per day), the label will show an increase of 36 per hour as it is the smallest amount greater than 1.

##### Trend state icons next to parameters in DATA pages

When you open an element card, each trended parameter on that card gets one of the following trend state icons. When you hover over one of those icons, a popup will open, showing additional information.

| Icon | Description |
|--|--|
| ![trend graph icon](~/release-notes/images/StandardTrendGraphIcon.png) | Standard trend graph icon |
| ![upward arrow icon](~/release-notes/images/ArrowRight60.png) | Upward arrow |
| ![downward arrow icon](~/release-notes/images/ArrowRight120.png) | Downward arrow |
| ![flat arrow icon](~/release-notes/images/ArrowRight.png) | Flat arrow |
| ![upward level shift icon](~/release-notes/images/LevelShiftIncrease.png) ![red upward level shift icon](~/release-notes/images/LevelShiftIncreaseRed.png) | Upward level shift |
| ![downward level shift icon](~/release-notes/images/LevelShiftDecrease.png) ![red downward level shift icon](~/release-notes/images/LevelShiftDecreaseRed.png) | Downward level shift |
| ![upward trend change icon](~/release-notes/images/ArrowTrendChangeUp.png) ![red upward trend change icon](~/release-notes/images/ArrowTrendChangeUpRed.png) | Upward trend change |
| ![downward trend change icon](~/release-notes/images/ArrowTrendChangeDown.png) ![red downward trend change icon](~/release-notes/images/ArrowTrendChangeDownRed.png) | Downward trend change |
| ![variance increase icon](~/release-notes/images/ArrowVarianceChangeUp.png) ![red variance increase icon](~/release-notes/images/ArrowVarianceChangeUpRed.png) | Variance increase |
| ![variance decrease icon](~/release-notes/images/ArrowVarianceChangeDown.png) ![red variance decrease icon](~/release-notes/images/ArrowVarianceChangeDownRed.png) | Variance decrease |
| ![upward outlier icon](~/release-notes/images/ArrowOutlierUp.png) ![red upward outlier icon](~/release-notes/images/ArrowOutlierUpRed.png) | Upward outlier |
| ![downward outlier icon](~/release-notes/images/ArrowOutlierDown.png) ![red downward outlier icon](~/release-notes/images/ArrowOutlierDownRed.png) | Downward outlier |

DataMiner will do the following to select a trend state icon for a particular parameter:

1. From the trend data of the parameter, DataMiner will fetch all change points that occurred during the last X seconds. X being the number of seconds specified in the *arrowWindowLength* parameter, found in *C:\\Skyline DataMiner\\Files\\SLAnalytics.config*. Default value: 3600 seconds.

2. If some of the change points are anomalous, then the following trend state icon is selected:

    - Type = Type of most recent anomalous change point
    - Color = Red

    Example: A red, upwards level shift.

    > [!NOTE]
    > If the most recent anomalous change point is an unlabeled change, then the standard trend graph icon is selected.

3. If none of the change points are anomalous, then the following trend state icon is selected:

    - Type = Type of the most recent change point of which the severity is equal to or greater than 0.5. If there are no change points of which the severity is equal to or greater than 0.5, then see step 4.
    - Color = Black

4. In all other cases, one of the following trend state icons is selected, based on the behavior of the parameter value in the last *arrowWindowLength* seconds: a flat arrow, an upward arrow, a downward arrow, or the standard trend graph icon.

##### Suggestion events

By default, a so-called “suggestion event” is generated whenever an anomalous level shift, trend change or variance change is detected for a particular parameter.

In case of a level shift, for example, the value of the suggestion event will be either “Level increased by X (from Y to Z)” or “Level decreased by X (from Y to Z)”. X will be the size of the jump, Y will be an estimation of the previous level and Z will be an estimation of the new data level.

To view these suggestion events, you can create a new tab in the Alarm Console and select to display suggestion events. This is possible for tabs displaying current alarms, history alarms and alarms in a sliding window.

> [!NOTE]
>
> - Currently, no suggestion events are generated for outliers and unlabeled change points.
> - Suggestion events have severity “Information” and source “Suggestion Engine”.
> - Suggestion events generated to indicate a behavioral anomaly are automatically cleared 2 hours after their creation time or their last update time.

#### SNMP forwarding: Enhanced authentication and encryption algorithm support \[ID_19471\]\[ID_19693\]\[ID_23031\]\[ID_23322\]\[ID_23586\]

When configuring SNMPv3 trap forwarding in System Center, it is now possible to make DataMiner use the following authentication and encryption algorithms:

Authentication algorithms:

- MD5
- SHA128
- SHA224
- SHA256
- SHA384
- SHA512

Encryption algorithms:

- AES128
- AES192
- AES256
- DES

> [!NOTE]
>
> - Default setting (when no default algorithms are specified in the protocol): SHA512 authentication in combination with AES256 encryption.
> - Some of the above-mentioned authentication and encryption algorithms cannot be combined.

#### Improved import/export UI \[ID_19999\]

The import/export UI in Cube has been improved as follows:

- When you select to do an import, you will now first have to select whether you want to import a .dmimport package or a CSV file.
- Similarly, for an export, you will first need to select either an export to a .dmimport package or to a CSV file, to the clipboard or to a printer. This will improve performance of export operations where a .dmimport package is not involved.

#### DataMiner Cube: New user setting to keep track of the history of a correlated alarm \[ID_19718\]

A new setting is available in the Cube user settings app: *Keep track of the full history of a correlated alarm*. If this option is selected, the entire alarm tree will be shown for a correlated alarm in the Alarm Console. Otherwise, only the most recent alarm will be displayed, and its sources will be displayed underneath. By default, the option is selected. If you change this setting, you will need to reconnect Cube to make the change take effect.

#### URL parameters / Alarm hyperlinks: Opening a card on a specific data page \[ID_19898\]

Up to now, it was possible to configure a DataMiner Cube URL or an Alarm Console hyperlink to open an element, service or view card either in Visual Overview mode or in Data Display mode. From now on, it is also possible to specify the exact page that has to be opened.

In the following examples, we open an element in Data Display mode and go directly to subpage “Ping” of page “Performance”:

- Using a DataMiner Cube URL:

  `http://myDma/DataMinerCube/DataMinerCube.xbap?element=48/70:data:performance/ping`

- Using an Alarm Console hyperlink specified in Hyperlinks.xml:

  `<HyperLink type="OpenElement" name="Open Ping page" version="2" id="4">[EID]:Data:Performance/Ping</HyperLink>`

All pages shown in a card’s side panel can be selected. If you want to select a page that is grouped neither under VISUAL nor under DATA, then omit the “visual” (“v”) or “data” (“d”) argument (without omitting any “:” separators). See the following examples:

- `http://myDma/DataMinerCube/DataMinerCube.xbap?element=48/70::help`
- `http://myDma/DataMinerCube/DataMinerCube.xbap?element=48/70::alarms`
- `http://myDma/DataMinerCube/DataMinerCube.xbap?service=48/105::alarms`
- `http://myDma/DataMinerCube/DataMinerCube.xbap?view=SLC::aggregation`

> [!NOTE]
> Names of pages and subpages do not need to be capitalized. All character casing will be ignored.

#### Forced view table refresh & configurable view table polling interval \[ID_20300\]\[ID_20394\]\[ID_20577\]

##### Forcing a (direct) view table refresh from within a protocol

It is now possible to force a refresh of a (direct) view table displayed in DataMiner Cube from within a protocol.

- To configure this, create a string parameter named “\[TableName\]\_REFRESHVIEWFORKEY”, and set its RTDisplay property to “True”.

When values in a particular row have changed due to a forced poll by the user (i.e. a user clicking a row’s *Update*, *Force poll* or *Refresh* button), then set the “\[TableName\]\_REFRESHVIEWFORKEY” parameter to the following value: the primary key of the row in question, followed by a pipe character (“\|”) and a random value (e.g. the current time).

If, for example, you have a direct view table named “View_Cable Modems”, and the protocol has a parameter named “View_Cable Modems_REFRESHVIEWFORKEY”, then you can force an immediate update of that table in DataMiner Cube by setting that parameter to the following value: “ABCDEF\|124831898” (in which ABCDEF is the primary key of the row and 124831898 is a random value).

> [!NOTE]
>
> - It is advised not to use this refresh mechanism too often, but to limit its use to when the contents of a row have changed due to some user action.
> - This force refresh can also be used to refresh child tables displayed in the CPE Manager KPI list.

##### Setting the view table polling interval

DataMiner Cube does not automatically receive updates for direct view tables and view tables with a *disableViewRefresh* option. Up to now, it polled these tables once a minute, but from now on, it will no longer poll these tables automatically.

If you want DataMiner Cube to automatically poll these tables, then do the following:

- Open the *Users\\ClientSettings.json* file, and set the *commonServer.ui.ViewTableRefresh.PollInterval* setting to a number of seconds.

    A negative or zero value will disable view table polling (which is the default behavior).

If, for example, you set this setting to “900”, all (direct) view tables opened in DataMiner Cube will be refreshed every 15 minutes.

> [!NOTE]
>
> - If, in DataMiner Cube, you hover over the “last updated on” box in the top-right corner of a (direct) view table, the polling interval will be shown in a tooltip.
> - A number of enhancements have been made to the automatic (direct) view table polling mechanism. It will now, for example, also apply to direct view tables and view tables displayed in CPE KPI windows and in Visual Overview.

#### DataMiner Cube - Data display: Table columns can now be shown or hidden using the table header’s right-click menu \[ID_20466\]

In Data Display, table columns can now be shown or hidden by selecting or deselecting them in the table header’s shortcut menu.

> [!NOTE]
>
> - These settings are not saved. When you close a card and then open it again, all column selections you made from a table header’s shortcut menu will be reset.
> - Table columns that have their width set to 0 will be hidden by default. If you want a zero-width column to be shown, then right-click the table header, open the *Columns* submenu, and select it in the list.

#### DataMiner Cube: Enhanced logging & freeze detection \[ID_20600\]\[ID_21259\] \[ID_23363\]\[ID_23719\]

In DataMiner Cube, a number of enhancements have been made to the internal error logging mechanism as well as to the *Logging* section of System Center. Also, an automatic freeze detection has been added.

##### Enhanced Cube tab in Logging section of System Center

On the *Cube* tab of System Center’s *Logging* section:

- Icons now visually indicate the category of each message.

- Of each message, you can now see how many times it was generated (by checking the *Count* column).

- When you click a message in the list, more information about that message will appear in the details pane at the bottom. Clicking the *Open* button in that details pane will make a new card appear, showing all information about that message.

- The *Show debug logging* checkbox now allows you to have the list also display debug log items. By default, this checkbox is not selected.

- At the bottom of the screen, the *Open log folder...* button now allows you to open the folder on the client PC in which the client-side log files are stored.

##### New values for computer setting 'Level of logging'

From now on, the *Level of logging* setting (*Settings \> Computer \> Advanced \> Logging*) will only have two values: “Log everything (5)” and “No logging (0)”.

##### Two types of log entries

In Cube, you can now consult two types of log entries:

| Type        | Location in Cube                                | Location on disk                                                                                   |
|-------------|-------------------------------------------------|----------------------------------------------------------------------------------------------------|
| Client-side | System Center \> Logging \> Cube                | C:\\ProgramData\\Skyline\\DataMiner\\DataMinerCube\\CubeLogging\\SLCubeLog_YYYY_MM_DD_HH_MM_SS.txt |
| Server-side | System Center \> Logging \> DataMiner \> Client | C:\\Skyline DataMiner\\logging\\SLClient.txt                                                       |

> [!NOTE]
> Each time a new Cube session is started, all client-side log files older than 1 week will automatically be deleted.

##### Updated log entry categories

These are the new log entry categories:

- **ClientSystem**: Entries containing information about a Cube client: Microsoft Windows version, Microsoft .Net version, processor type, amount of RAM, etc.

- **Connection**: Entries indicating how long Cube took to set up a connection and load all initial data.

- **Debug**: Entries containing debugging information for developers.

  By default, messages of this category are hidden. To consult them, go to *System Center \> Logging \> Cube*, and select the *Show debug logging* checkbox.

- **Error**: Entries generated due to events that have an impact on overall Cube functionality.

  These entries mostly indicate exceptions that were caught, but which could not be dealt with by the software.

  > [!NOTE]
  > These entries will always be forwarded to the DataMiner Agent to which Cube is connected.

- **Exception**: Entries indicating unhandled exceptions that were thrown in Cube.

  > [!NOTE]
  > These entries will always be forwarded to the DataMiner Agent to which Cube is connected.

- **ForwardDebug**: Entries of category “Debug” that will always be forwarded to the DataMiner Agent to which Cube is connected.

- **ForwardInfo** Entries of category “Info” that will always be forwarded to the DataMiner Agent to which Cube is connected.

- **Freeze**: Entries indicating that Cube became unresponsive at some point.

- **Info**: Entries containing general information.

  Examples: connection time, load time, fetch time, etc.

  > [!NOTE]
  > The log entry category “Default” no longer exists and has been replaced by “Info”.

- **Warning**: Entries generated due to events that had an unexpected outcome, but which did not have an impact on overall Cube functionality.

  Examples: user input that was validated as being incorrect, imported drivers that were validated as being faulty, problems that occurred while reading or writing files or settings, etc.

  > [!NOTE]
  > These entries will always be forwarded to the DataMiner Agent to which Cube is connected.

##### Messages of category Warning, Error and Exception now indicated in Cube header

Up to now, messages of category Warning, Error and Exception were displayed in a pop-up window. Now, instead an icon will be displayed in the Cube header if an error message is logged. Clicking the icon will open the Logging section of System Center. Icons can also be displayed for warning and exception messages, but this does not occur by default. To view these icons in the header, add the following argument to the Cube URL: *?enablefeature=loggingnotifications*

##### Automatic freeze detection

If DataMiner Cube remains unresponsive for a number of seconds, a pop-up window will now appear, asking you whether to keep waiting or to exit Cube.

You can configure this detection mechanism by means of the following system settings in the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file:

| Setting                                            | Description                                                                                             |
|----------------------------------------------------|---------------------------------------------------------------------------------------------------------|
| commonServer.client.ui.logging.FreezeLogTime   | Minimum number of seconds Cube must be unresponsive before a log entry is created. Default: 10 seconds      |
| commonServer.client.ui.logging.FreezePopupTime | Minimum number of seconds Cube must be unresponsive before a pop-up window will appear. Default: 30 seconds |

#### Alarm Console: Icons of alarms associated with an element in timeout state will now have an orange X \[ID_20725\]

From now on, icons of alarms associated with an element in timeout state will have an orange X.

#### Protocols & Templates: Viewing protocol version differences when changing the protocol version of an existing element \[ID_20742\]

When you change the protocol version of an existing element, and the protocol XML files of both the old and the new protocol version contain version history information (i.e. inside a \<VersionHistory> element), an icon will now appear next to the *Version* box. When you click that icon, a pop-up window will show an overview of the differences between the two versions.

A protocol version number is made up of four parts:

`Branch.SystemVersion.MajorVersion.MinorVersion (e.g. 2.1.0.1)`

The level of information shown in the pop-up window will depend on the version number part that has changed:

- If *Branch* changed, then only the features in the new branch will be listed.

- If *Branch* did not change, then all changes in *SystemVersion*, *MajorVersion*, *MinorVersion*, and all the versions on which the new version is based will be listed.

- If *Branch* or *MajorVersion* changed, then a warning icon will appear, and you will get the option to have the element recreated (meaning that the existing element will be deleted and a new element will be created with a new element ID) or to continue editing the current element (default setting).

- If *Branch* and *MajorVersion* did not change, then an info icon will appear.

#### New annotations editor \[ID_20838\]

DataMiner Cube now features an entirely new annotations editor.

#### Ticketing: Ticket fields can now automatically be populated with alarm information \[ID_20961\] \[ID_21136\]

When creating a ticketing domain, it is now possible to link ticket fields to alarm fields.

This will allow ticket fields to automatically inherit alarm field contents when Cube users right-click an alarm in the Alarm Console and select *Ticket \> New ticket*.

##### Linking an alarm field to a ticket field

1. In the Ticketing app, click the cogwheel icon in the header, open a ticket domain, and add a new ticket field (or edit an existing ticket field).
1. In the *Edit field* window, open the *Alarm field* box, select the alarm field that you want to link to the ticket field, and click OK.

When you now right-click an alarm in the Alarm Console and select *Ticket \> New ticket*, you will notice that the ticket field that you linked to an alarm field will have inherited the contents of that alarm field.

#### Service & Resource Management: Profiles app now supports profile parameters of type Capacity and Capability \[ID_21296\]

The Profiles app now supports profile parameters of type Capacity and Capability.

#### Contacts window: More user-friendly application name displayed when hovering over a user in the list \[ID_21561\]

When, in the Contacts window, you hover over a user, the tooltip will now display a user-friendly description of the application that person is using to connect to the DMS. If such a name is not available, the name as used up to now will be displayed instead.

Format of the text in the tooltip:

```txt
[ClientAppDisplayName or ClientAppName] Online since [ConnectTime]
```

#### Documents: Uploading a document linked to an element and only storing it on the DMA hosting the element \[ID_21690\]\[ID_21993\]\[ID_21997\]

It is now possible to upload a document, link it to a specific element, and have it stored only on the DataMiner Agent hosting the element in question.

When you upload a document and link it to an element:

- The document will only be stored in the *C:/Skyline DataMiner/Elements/ElementName/Documents* folder on the DataMiner Agent hosting that element. It will not be synchronized to the other agents in the DataMiner System.

- A small, single-byte file with the same name as the document will be stored in the *C:/Skyline DataMiner/Documents/Elements/ElementName* folder. Contrary to the document itself, this small file will be synchronized among all agents in the DataMiner System, and will be used to make all agents aware of this element-level document.

##### Uploading a document and linking it to a specific element

1. Open the element card, and go to the *Documents* page.
2. Select the folder with the same name as the element, right-click in the document list, and select *Add document*.
3. Under the *Documents* option, click *Browse*, and browse to the document you want to add.
4. Under *Location*, select *Local*, and select the element to which you want to link the document.
5. Click *OK*.

> [!NOTE]
> From now on, in the *Documents* app, a progress bar will be displayed when you are uploading or downloading a document.

#### All Cube clients will now display 'broadcast popups' sent from QActions, Automation scripts, etc. \[ID_21733\]\[ID_21928\]\[ID_22089\]

When a QAction, an Automation script, etc. sends a BroadCastPopupRequestMessage with the following arguments, a BroadCastPopupEventMessage will now be sent to all recipients specified in the UserNames and GroupNames arguments, causing a so-called “broadcast popup” to appear.

| Argument | Format | Description |
|--|--|--|
| Source | GUID | A GUID indicating the entity that sent the message. |
| Title | String | The title of the message. |
| Message | String | The contents of the message. |
| UserNames | List\<string> | The list of users who will receive the message.<br> User name format:<br> - Domain users: “domainname\\username”<br> - Local users: “username” |
| GroupNames | List\<string> | The list of user groups of which the members will receive the message.<br> Group name format:<br> - Domain groups: “domainname\\groupname”<br> - Local groups: “groupname” |
| Expiration | DateTime | The date/time until which the message will be shown.<br> Note:<br> - If no Expiration argument is specified, the message will never expire.<br> - If you set Expiration to DateTime.MinValue (default setting) or DateTime.MaxValue, the message will never expire.<br> - If you set Expiration to a date more than one year into the future, the expiration date of the message will not be displayed. |

- All messages received in a BroadCastPopupEventMessage will be listed in the same message box.

- When a BroadCastPopupEventMessage is received with a GUID identical to that found in a message received earlier, then that earlier message will be replaced by the new message.

    > [!NOTE]
    > When a BroadCastPopupEventMessage is received with a GUID identical to that found in a message received earlier and an Expiration date/time in the past, then that earlier message will be cleared.

- When both the UserNames and GroupsNames arguments are empty, the message will be sent to all clients.

- When a user acknowledges a message, the message will only disappear in that particular Cube session. It will remain visible on all other Cube clients that received the same message.

- Each message will show the time at which it was received and the time until which it will be shown (if such a time was specified in the BroadCastPopupRequestMessage).

- In the Message argument (i.e. the contents of a message), you can include some of the placeholders that can be included in Visio shape data values. As this kind of broadcast messages do not have any context, placeholders like e.g. \[this element\] or \[cardvar:abc\] will not work. For a list of Visio placeholders, see [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

#### New ClientSettings.json setting to determine CPE card behavior \[ID_21822\]

A new setting is available in the file ClientSettings.json, *Surveyor.CPE.LaunchCPECardOnSelect*, which determines what happens when a CPE card is opened based on the Surveyor topology. If this setting is set to true, a CPE card will be opened as soon as an item is selected in the Surveyor topology. If this setting is set to false (which is the default configuration), the CPE card will only be opened if the launch button is clicked in the Surveyor topology.

For example:

```json
{
   "Name":"Surveyor.CPE.LaunchCPECardOnSelect",
   "Value": false,
   "VersionNumber": 0,
   "Mode": 0,
   "InVisible": false
}
```

#### Alarm Console - Custom hyperlinks: filterElement attribute supports alarm property names that contain spaces \[ID_22178\]

In a \<Hyperlink> tag, from now on, the filterElement attribute supports alarm property names that contain spaces.

If, in a filterElement attribute, you specify a property name that contains spaces (e.g. “System Type”, “System Name”, etc.), then you must enclose it in XML-encoded double quotes. See the following example.

```txt
filterElement="AlarmEventMessage.PropertiesDict.&quot;System Type&quot;[String] == 'OLT'"
```

#### DataMiner Cube - Data Display: Tooltips can now be displayed for icons in table cells containing discrete values \[ID_22884\]\[ID_23003\]

In a protocol, it is now possible to define a tooltip for every discrete parameter value. That tooltip will then be displayed when the mouse pointer hovers over the icon displayed in a table cell containing the discrete parameter value to which it is linked.

In the following example, a tooltip was defined that displays data found in other columns of the same table (see also the note regarding placeholders below).

```xml
<Discreets>
  <Discreet iconRef=”CAT”>
    <Display>Two</Display>
    <Value>2</Value>
    <Tooltip>
      Number ‘{pid:1003}’\n
      dateTime ‘{pid:1004}’
    </Tooltip>
  </Discreet>
  ...
</Discreets>
```

> [!NOTE]
>
> - When you define tooltips for discrete values, note that, within a given \<Discreets> tag, all \<Discreet> tags should have a \<Tooltip> tag. If no value should be defined for a particular \<Discreet> tag, leave the \<Tooltip> tag empty.
> - If you defined a tooltip for a particular discrete value, you cannot set the displayIconAndLabel attribute to “true”.
> - For the list of placeholders that can be used inside the text of a tooltip, refer to the “Protocol.Params.Param.Measurement.Discreets.Discreet” section in the Protocol Development Library.

#### Alarm Console: New 'Keep active alarms' option to prevent active alarms from disappearing from a sliding window alarm tab \[ID_23056\]

Up to now, when you created an alarm tab of type “sliding window”, it would only display active alarms as long as they occurred within the sliding window. From now on, when you create an alarm tab of type “sliding window”, you can enable the *Keep active alarms* option to prevent the active alarms from disappearing from the alarm tab the moment they are no longer within the sliding window.

#### Data Display: Full-screen button on Data pages \[ID_23187\]

Similar to the one on Visual Overview pages, from now on, there is also a full-screen button on Data pages.

> [!NOTE]
> When, on a Data page in full-screen mode, you maximize a table and then exit the full-screen mode, the normal Data page viewing mode will be restored.

#### Alarm Console: 'Merge alarm trees...' option \[ID_23200\]

In the list of Alarm Console settings, which you can access by clicking the hamburger button in the top-left corner of the console, you can now find the new *Merge alarm trees...* option.

If you click this option, you can choose to merge all alarm trees for the same element/parameter combination (active tree and cleared trees) into one. If you choose to do so, you can also indicate that you only want to merge trees of which the time difference is less than X seconds.

> [!NOTE]
> This new option will only be available when *History tracking* is enabled, *Freeze* is disabled and automatic alarm clearing is disabled.

#### More detailed error message will now appear when an interactive Automation script fails \[ID_23251\]\[ID_23561\]

Up to now, when an interactive Automation script failed, a generic popup message was displayed, stating that something went wrong.

From now on, when an interactive Automation script fails, a popup message will appear, containing more detailed information about why the script failed (e.g. the user aborted the script while it was running, the script ran for too long and went into timeout, etc.).

#### Redesigned DataMiner Cube layout \[ID_23427\]\[ID_23486\]\[ID_23540\]\[ID_23628\]\[ID_23646\] \[ID_23813\]\[ID_23822\]\[ID_23904\]\[ID_23982\]\[ID_24036\]\[ID_24044\]\[ID_24079\]\[ID_24086\]\[ID_24129\] \[ID_24143\]\[ID_24160\]\[ID_24165\]\[ID_24189\]\[ID_24218\]\[ID_24518\]

The design of DataMiner Cube has been updated to be more user-friendly and more in line with other DataMiner apps. Aside from numerous small layout changes, there have been a number of large changes, as detailed below.

##### Redesigned header bar

- In the header bar, the date and time and the four squares indicating the four "sides" of Cube are no longer displayed by default. A drop-down arrow in the header bar provides quick access to settings that allow you to display these again if you prefer this. These settings are also available on the *Cube* tab of the Cube settings card.

- In the middle of the header bar, there is now a search box. This search box features improved search possibilities compared to the search box that was previously included in the side panel. As soon as you click the search box, a list of suggestions is shown below. Initially, this list shows recent items, but it is updated with search results as soon as you type anything in the box. You can click a suggestion to immediately open the corresponding card, or click *Advanced search* at the bottom of the list to open a complete list of search results in the side panel. This list will stay visible until another tab is selected.

    > [!NOTE]
    > Hidden elements are no longer included in the search results.

- Cube settings, card layout settings, updates, and other options that were previously available via various menus of the header bar are now available in one single menu, which can be accessed via the user icon in the top-right corner.

- If an alarm storm occurs, this is no longer displayed in the header bar. Instead, a button is now displayed at the bottom of the Alarm Console. A tooltip on the button provides more information.

- The alarm banner has been replaced with a notification in the header bar. A new Cube setting is available, which allows you to choose between a wide or compact alarm banner.

##### Redesigned side panel

- The side panel on the left or right side of the Cube UI is now by default displayed as a blue bar containing the *Surveyor*, *Activity*, *Apps* and *Workspace* icons. Clicking these icons opens the corresponding panel.

- The *Activity* panel replaces the former *Recent* tab of the side panel, but functions in the same way as this tab, allowing you to pin items to the top of the list of recent activity.

- The icons in the Surveyor and apps panel have been updated. These are now the most commonly used icons:

  | Icon                                                                  | Description      |
  |-----------------------------------------------------------------------|------------------|
  | ![element icon](~/release-notes/images/CubeXElement.png)              | Element          |
  | ![service icon](~/release-notes/images/CubeXService.png)              | Service          |
  | ![redundancy group icon](~/release-notes/images/CubeXRedunGroup.png)  | Redundancy group |
  | ![SLA icon](~/release-notes/images/CubeXSLA.png)                      | SLA              |
  | ![view icon](~/release-notes/images/CubeXView.png)                    | View             |

  If an alarm is present on an element, service, redundancy group or SLA, this is indicated by a colored circle in the bottom-right corner of the icon. For a view, the entire icon is colored according to the alarm severity.

  However, note that these new icons do not support latch level, aggregation level and split view level indications. As such, a new user setting is available, *Use modern icons*, which can be cleared to use the previous icons again.

##### Redesigned logon screen

- The logon screen now features a minimalist design, showing only the DataMiner logo, the IP of the DMA, the login info and a configuration button. With a button at the bottom of the window, you can switch between the current Windows user and a different user profile. The configuration button provides access to options, the "about" information and logging.

- A number of buttons are now available, based on the status of the logon and the DMA. While you are logging onto a DMA, you can click *Back* to return to the logon screen. If a DMA is upgrading or migrating when you log on, you can click the *Monitor* button to monitor the progress. If a DMA is stopped, you can click *Start*, and if a DMA is offline, you can click *Set online*.

#### Smart-serial server elements can now have a list of allowed IP addresses configured \[ID_23592\]\[ID_23673\]\[ID_23694\]\[ID_23739\]

When, while editing an element in DataMiner Cube, you configure a smart-serial server port of type TCP, it is now possible to specify a number of allowed IP addresses for that particular port.

Up to now, when multiple elements were using the same smart-serial server port, each of those elements would

- receive all messages from all elements using that port, and
- forward all messages to all elements using that port.

From now on, for each of their smart-serial server ports of type TCP, elements can have a list of IP addresses configured from which they will accept incoming messages and to which they will forward messages.

- When, for a particular smart-serial server port, an element has a list of allowed IP addresses configured, it will from now on

  - accept messages only from those IP addresses, and
  - forward messages only to those IP addresses.

- When, for a particular smart-serial server port, an element does not have a list of allowed IP addresses configured, it will from now on

  - accept messages from all IP addresses that have not been added to an “allowed IP addresses” list linked to that port, and
  - forward messages only to IP addresses that have not been added to an “allowed IP addresses” list linked to that port.

> [!NOTE]
>
> - If none of the elements that use a particular smart-serial server port have allowed IP addresses configured for that port, they will behave as before.
> - By default, this “allowed IP addresses” functionality is disabled. For more information on how to enable it, see below.

##### Enabling the 'allowed IP addresses' functionality in the Protocol.xml file

In the Protocol.xml file of a smart-serial element, you can enable or disable the AllowedIPAddresses functionality by setting AllowedIPAddresses.Disabled to “false” in the user settings of the smart-serial connection. In the following example, it has been enabled.

```xml
<Connections>
  <Connection name="Smart-Serial Server" id="0">
    <SmartSerial>
      <UserSettings>
        <AllowedIPAddresses>
          <Disabled>false</Disabled>
        </AllowedIPAddresses>
      </UserSettings>
    </SmartSerial>
  </Connection>
</Connections>
```

#### DataMiner Analytics: Alarm focus \[23911\]\[ID_24083\]\[ID_24102\]\[ID_24128\]

The DataMiner Analytics software will now by default assign an estimated likelihood, called a focus score, to each active alarm after analyzing the short-term history and current behavior of incoming alarms in real time.

Focus scores are numbers ranging from 0 (completely unexpected) to 1 (fully expected). They are stored in AlarmFocusEvents that are generated by SLAnalytics and cached by SLNet. Each AlarmFocusEvent contains an alarm ID and a likelihood field containing the focus score.

The decision whether an alarm is expected is based on likelihood and frequency:

- Likelihood scores are used to spot daily patterns. If an alarm occurs at the same time every day, it will be assigned a high likelihood value at that time.

    > [!NOTE]
    > Likelihood values are based on UTC time. As a result, when daylight saving time goes into or out of effect, patterns following local time might be off for approximately one week.

- Frequency scores are used to detect parameters that frequently go into and out of alarm, or alarms that persist over a long time.

The focus score that is assigned to an alarm is a combination of likelihood, frequency and severity.

> [!NOTE]
>
> - Currently, every DataMiner Agent is responsible for calculating the focus scores of the alarms it is hosting.
> - Currently, no focus score is assigned to the following types of alarms: Correlation alarms, external alarms and information events. By default, those alarms are assigned a focus score equal to null.

##### New column in Alarm Console: Focus

In the *Active alarms* tab page, for each alarm that can be considered “unexpected”, an icon will be displayed in the new *Focus* column, which is located between the *Icon* column and the *Element name* column.

Also, in the blue footer of the *Active alarms* tab page, you will notice a new focus icon. If you click this icon, the current tab page will only display the alarms with a focus icon in the *Focus* column.

> [!NOTE]
> If an alarm template changes, all alarms of the parameters that were assigned that alarm template will have their focus score reset and will get the focus icon. All historical focus data for those alarms will be lost.

##### In the event of an alarm storm

During an alarm storm, focus scores of persistent alarms will not be updated, but as soon as a storm has ceased, all active alarms will have their focus scores updated with the most recent values.

Also, an information event will be generated when alarm focus calculation goes into and out of alarm storm mode.

##### When will alarm focus values be recalculated from scratch?

Alarm focus values will be calculated for the first time after an upgrade to DataMiner version 10.0.2. They will only be recalculated from scratch when SLAnalytics notices that, for whatever reason, the Alarm Focus database table has been cleared.

When calculating alarm focus values for the first time, or when recalculating them from scratch, SLAnalytics will take into account the alarm history of the last week. The time taken by such a recalculation, will depend on the amount of alarms to be updated.

#### New system-wide ClientSettings.json setting to configure whether Data Display pages should be unloaded from memory when you navigate away from them \[ID_23913\]

In the *ClientSettings.json* file, the new system-wide *commonServer.ui.datadisplay.PageUnloadOnNavigatingAway* setting allows you to configure whether Data Display pages should be unloaded from memory when you navigate away from them.

Default value: False

#### Settings: ‘Table export column separator’ setting replaced by ‘CSV separator’ setting \[ID_23986\]

The *Table export column separator* setting (on the *User \> Data Display* page of the *Settings* window) has now been replaced by the *CSV separator* setting (on the *User \> Regional* page of the *Settings* window).

The separator you select in this new setting will be used in all CSV files exported from Cube.

> [!NOTE]
>
> - This *CSV separator* setting is a Cube-only setting. When a CSV file export is initiated directly by a DataMiner Agent, this setting will be disregarded.
> - Before you import a CSV file that was exported using a previous version of Cube, make sure to check the separator used in that file.
> - When you copy data to the Windows clipboard, that data will always be delimited by TAB characters, regardless of the delimiter specified in the CSV separator setting.

#### Automation/Correlation/Scheduler - Email action: List of reports to be included now indicates whether a report is a legacy report or a Dashboards app report \[ID_24015\]

When, in Automation, Correlation or Scheduler, you configure an email action, you can specify whether the email message has to include a report. To do so, you select the *Include report or dashboard* checkbox and select a report from the list.

From now on, each report listed in the report selection box will have an icon that indicates whether it is a legacy report or a Dashboards app report.

#### DataMiner Cube will now be built as an AnyCPU application \[ID_24168\]

As from DataMiner X, DataMiner Cube will be built as an AnyCPU application.

ClickOnce StandAlone and MSI versions will run as 64-bit processes on 64-bit systems and as 32-bit processes on 32-bit systems.

> [!NOTE]
>
> - Microsoft Internet Explorer always launches PresentationHost.exe as a 32-bit process. As a result, ClickOnce XBAP versions of Cube will always run as 32-bit processes.

#### New sidebar docking position setting \[ID_24178\]

In the restyled Cube X, the docking position of the sidebar can now be controlled by means of the *User \> Surveyor \> Sidebar docking position* setting.

Default: left

#### System Center: Agent state displayed on Agents page and total number of agents displayed on Agents, Database and Backup pages \[ID_24230\]

In *System Center*,

- the state of every agent in the DataMiner System is now displayed on the *Agents* page, and

- the total number of agents in the DataMiner System is now displayed on the *Agents* page, the *Database* page, and the *Select Agents to back up* window (which appears when you click *Execute backup* on the *Backup* page).
