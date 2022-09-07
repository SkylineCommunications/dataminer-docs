---
uid: General_Feature_Release_10.0.2_new_features
---

# General Feature Release 10.0.2 – New features

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### DMS core functionality

#### DataMiner Indexing \[ID_13370\]\[ID_13406\]\[ID_13504\]\[ID_13571\]\[ID_13623\] \[ID_13622\]\[ID_13629\]\[ID_13695\]\[ID_13769\]\[ID_13912\]\[ID_14001\]\[ID_14038\] \[ID_16287\]\[ID_16896\]\[ID_16915\]\[ID_16935\]\[ID_16959\]\[ID_17081\]\[ID_17166\] \[ID_17328\]\[ID_17851\]\[ID_18562\]\[ID_18714\]\[ID_19337\]\[ID_19437\]\[ID_19443\] \[ID_19691\]\[ID_20373\]\[ID_20845\]\[ID_20998\]\[ID_21205\]\[ID_21257\]\[ID_21634\] \[ID_22378\]\[ID_22927\]\[ID_23049\]\[ID_23998\]\[ID_24054\]\[ID_24158\]

On DataMiner Agents running Cassandra, it is possible to install a dedicated indexing database (e.g. Elasticsearch). If this so-called Indexing Engine is installed, new search features will now become available in the Alarm Console. Additional features are also being developed that will make use of the Indexing Engine in the future.

##### Indexing system requirements

DataMiner Indexing Engine can only be installed on DataMiner Agents with the following characteristics:

- Operating system: Windows Server 2008 R2 or higher (64-bit).

- Free RAM: At least 10 GB.

    > [!NOTE]
    > This requirement refers to the amount of free RAM in the system, not the total amount of RAM. DataMiner Indexing will always reserve 8 GB of RAM when it is in use, and an additional 2 GB of free RAM must be available to ensure that the system can run correctly.

- Average CPU usage: Lower than 70%.

- Local database type: Cassandra.

- Free hard disk space: Same amount as used by Cassandra.

- Separate hard disk from the one containing the Cassandra database.

    > [!NOTE]
    > At least 20% of the disk must remain free at all times.

- Microsoft .Net version: 4.6 or higher.

- If multiple indexing databases will be used, the latency between those databases must be less than 50 ms.

- The minimum number of nodes required in order to install DataMiner Indexing Engine depends on the number of alarms that occurred in the 24 hours prior to the installation. One node is required for every 30,000 alarms per day in the DMS.

> [!NOTE]
> If not all DMAs in the DataMiner System use Cassandra, the button to start the Indexing Engine installation wizard is unavailable. Other system requirements can be checked in the first step of the wizard.

##### Installing the Indexing Engine

To install the Indexing Engine, go to DataMiner Cube’s System Center, select *Search & Indexing*, click the button *Install Indexing Engine...*, and then follow the wizard.

> [!NOTE]
> The *Search & Indexing* page in System Center is only available for users with the user permission *Modules* > *System configuration* > *Indexing engine* > *Configure*.

Like the wizard for the Cassandra migration, the wizard will first check whether the system requirements are met. If necessary, you can close the wizard again in order to continue later after the necessary changes have been made. In case changes are implemented while the wizard is open, a button is available that allows you to refresh the validation data.

Once the installation process is completed, reconnect to DataMiner to make sure all functionality is available.

Please note the following regarding the indexing database:

- In the wizard, you can select on which DMAs in a DMS you install DataMiner Indexing. You will only be able to start the installation if the required minimum number of Agents in the DMS is selected. This minimum number depends on the total number of DMAs in the system. If there are 3 or less DMAs in the system, all DMAs must be selected, otherwise at least 3 DMAs must be selected.

- When several DMAs in a DataMiner System have an indexing database installed, all indexes in all those indexing databases will be linked. That way, when a user launches a search on one DMA, all indexing databases in the DataMiner System will be queried.

- If an indexing database is installed on a Failover system, a database instance will be installed on each of the DMAs, and both instances will be clustered. Also, when a DMA with an indexing database and a DMA without an indexing database are combined into a Failover system, a new database instance will be created on the latter DMA, and both instances will be clustered. When a DMA is removed from a Failover system, the indexing database instance on that DMA is removed from the cluster.

- During the setup of the DataMiner Indexing installation, a backup path has to be specified. For more information, refer to [Configuring DataMiner Indexing backups](#configuring-dataminer-indexing-backups).

- In a DataMiner System, there must be at least 2 master nodes. By default, the 3 DataMiner Agents with the lowest DataMiner ID will act as master node.

- Alarms in the indexing database are kept in two separate tables, one for active alarms and one for closed alarms.

##### DB.xml Indexing configuration

When the DataMiner Indexing Engine installation is complete, the *Db.xml* file will contain an additional \<DataBase> section with the connection information of the indexing database. The "search" attribute will be set to true.

```xml
<DataBases xmlns="http://www.skyline.be/config/db">
  ...
  <DataBase active="true" search="true" type="Elasticsearch">
    ...
```

> [!NOTE]
>
> - Changes to the settings of an indexing database in DataMiner Cube will take effect immediately and do not require a DataMiner restart. A DataMiner restart is only required when a named database is deleted.
> - When the Indexing Engine has been installed, the file *Indexing.xml* file is also added to the Skyline DataMiner folder, containing the configuration of the engine itself.

##### DBMaintenance.xml and DBMaintenanceDMS.xml Indexing configuration

In *DBMaintenance.xml* and *DBMaintenanceDMS.xml*, each \<TTL> tag can have an \<Indexing> subtag, allowing you to specify an override for the default TTL setting for a table that is part of the indexing database. It is possible to specify "infinite" as the indexing TTL, in which case these data will be kept indefinitely.

##### Configuring DataMiner Indexing backups

Backups of the Indexing database are not included in a DataMiner restore package. Instead, the backups are stored in a fixed location, which must be specified during the installation of DataMiner Indexing. This location is the same for all Indexing servers in the cluster.

A number of restrictions apply for the backup path. For more information on these restrictions, refer to the DataMiner Help.

Once DataMiner Indexing has been installed, it is possible to change the backup path using the *Backup path* parameter on the *Backup* page in System Center.

> [!NOTE]
>
> - After you have changed the path in System Center, it is possible that the UI is temporarily disabled while the Indexing nodes are restarted to implement the change. As such, we recommend to only change the backup path if this is absolutely necessary.
> - Only one Indexing data backup can be made per day.
> - Deleting any files from the backup file location will cause a restore to fail.

##### Indexing features configuration in System Center

Once DataMiner Indexing Engine has been installed, the *Search & Indexing* section in System Center contains an additional *Enable indexing on alarms* option. This option must be enabled in order to use the new Alarm Console features mentioned below.

There is also a button available that can be used to migrate booking data to the Indexing database. For more information, see DataMiner Cube: New Migrate booking data to Indexing Engine wizard [ID_21935] [ID_23674] [ID_24410] [ID_24424].

##### Enhanced search in alarm tab pages

When you open a new alarm tab page in the Alarm Console while connected to a DataMiner Agent that has indexing enabled on alarms, a search box at the top of that alarm tab page will now allow you to search for particular alarms or information events.

You can also right-click text in the Alarm Console while holding the left CTRL key (or a different key depending on the *Mouse word highlighting in Alarm Console* user setting), and select *Search for \<text> in new tab*. This will open a new tab with the text in question filled in in the search box.

Next to the search box, you can select a timespan (default: last 24 hours). When you start typing in the search box, the most relevant suggestions that are returned by the server will be displayed below. If a suggestion is too large to be displayed completely, you will be able to view it completely by hovering the mouse over it. However, if it consists of multiple lines, only the first line will be displayed.

After you press Enter or select a suggestion, the alarms matching your search phrase will be retrieved in batches of 50. If there are more than 50 alarms that match your search phrase, a *More results* button will be displayed at the bottom of the list. If you click that *More results* button, any alarms that were added or changed will blink briefly.

Once the first 50 alarms have been retrieved, a graphical representation of the alarm distribution will also be displayed.

By default, different instances of the same alarm will be combined in a single alarm tree in the search results. If you want them to be displayed separately, disable the *History tracking* checkbox.

In the search box, you can use the following special keywords, followed by a colon (“:”) and a search phrase:

- Severity
- Description
- Parameter_description
- Owner
- Value
- Time of arrival
- Status
- Elementname
- Viewnames
- Parentviews
- Protocolname
- ElementProperty\_\<propertyName>
- Viewproperty\_\<PropertyName>
- ServiceProperty\_\<PropertyName>

For example, if you want to search for alarms associated with elements of which the name resembles “probe”, you can enter “Elementname:probe”.

##### New user permission

In the Users / Groups module, in the category *Modules* > *System configuration* > *Indexing engine*, the following user permission is now available:

- *Configure*: Determines whether the user can make any changes to the Indexing Engine configuration.

##### Indexing log information

Log information about the Indexing Engine can be found in a new “Search” log file in the *Logging* section of *System Center*.

In addition, the system will continuously monitor the connection with the Indexing database. If for some reason a node of the Indexing database goes down, an alarm will be displayed in the Alarm Console.

##### GetIndexCountRequest method

A new *GetIndexCountRequest* method has been added in DataMiner, which can be used to retrieve the number of documents in the indexing database.

This method can for instance be used as follows for a logger table:

```csharp
GetIndexCountRequest<LoggerTableData> message = new GetIndexCountRequest<LoggerTableData>(new LoggerTableDataIndex(503,52,1000));
```

### DMS Security

#### HTML5 apps: External user authentication via SAML \[23905\]

The DataMiner HTML5 apps (e.g. Dashboards, Jobs, etc.) now all support external user authentication via Security Assertion Markup Language (SAML).

### DMS Protocols

#### SLProtocol class refactored to an interface \[ID_23787\]

To allow for easier testing, the SLProtocol class has been refactored to an interface.

#### NT_SNMP_GET (295): Possibility to specify the maximum number of repetitions \[ID_23888\]

When sending an NT_SNMP_GET request from within a QAction, it is now possible to pass along the maximum number of repetitions in the elementInfo array.

See the following example:

```csharp
elementInfo[13] = maxRepetitions;
object[] result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, tableOids);
```

elementInfo\[13\] should contain a 32-bit integer value (Int32) of at least 1. If no value is specified, or if the value is 0 or less, then the default number of repetitions (6) will be passed along.

> [!NOTE]
> Apart from the maximum value of an Int32 (2^31-1), there are no constraints as to maximum value you can specify. So, use this option with caution. The higher this value is set, the higher the stress on the network and the device in question will be.

#### DataMiner Mediation Layer: Base protocols and device protocols can now contain value mappings \[ID_24127\]

In base protocols and device protocols linked to base protocols, you can now specify \<ValueMapping> tags inside \<LinkTo> tags.

A \<ValueMapping> tag has two attributes:

- a *remoteValue* attribute that refers to the value in the other protocol, and
- a *value* attribute that refers to the value in the current protocol.

Here is an example of a value mapping defined in a base protocol:

```xml
<Mediation>
  <LinkTo protocol="Skyline Discreet Values" pid="10" ops="/:1000000">
    <ValueMapping remoteValue="-1" value="-2"/>
  </LinkTo>
</Mediation>
```

Here is example of a value mapping defined in a device protocol:

```xml
<Mediation>
  <LinkTo pid="70005">
    <ValueMapping remoteValue="1" value="5"/>
    <ValueMapping remoteValue="2" value="7"/>
  </LinkTo>
</Mediation>
```

> [!NOTE]
>
> - Value mappings can be defined for both single-value and column parameters of type string or double. If you define them for parameters with Interprete type “high nibble”, they will be ignored.
> - In case of read/write parameters, value mappings have to be defined on both. Note, however, that they should not be identical. If a value mapping match is found when reading or writing a parameter, then the *ops* attribute of the *LinkTo* tag will be ignored. However, if no relevant mappings could be found for the value in question, the *ops* attribute will be taken into account. This can prove useful in case of exception values.

### DMS Cube

#### DataMiner Analytics: Behavioral anomaly detection and suggestion events \[ID_15723\]\[ID_15914\]\[ID_15916\]\[ID_15951\]\[ID_15952\]\[ID_15976\]\[ID_16001\]\[ID_16050\]\[ID_16163\]\[ID_17279\]\[ID_17462\]\[ID_19224\]\[ID_24095\]\[ID_24126\]\[ID_24147\]

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

1. From the trend data of the parameter, DataMiner will fetch all change points that occurred during the last X seconds. X being the number of seconds specified in the *arrowWindowLength* parameter, found in *C:\\Skyline DataMiner\\Files\\SLAnalytics.config*. Default value: 3600 seconds.

2. If some of the change points are anomalous, then the following trend state icon is selected:

    - Type = Type of most recent anomalous change point
    - Color = Red

    Example: A red, upwards level shift.

    > [!NOTE]
    > If the most recent anomalous change point is an unlabeled change, then the standard trend graph icon is selected.

3. If none of the change points are anomalous, then the following trend state icon is selected:

    - Type = Type of the most recent change point of which the severity is equal to or greater than 0.5. If there are no change points of which the severity is equal to or greater than 0.5, then see step 4.
    - Color = Black

4. In all other cases, one of the following trend state icons is selected, based on the behavior of the parameter value in the last *arrowWindowLength* seconds: a flat arrow, an upward arrow, a downward arrow, or the standard trend graph icon.

##### Suggestion events

By default, a so-called “suggestion event” is generated whenever an anomalous level shift, trend change or variance change is detected for a particular parameter.

In case of a level shift, for example, the value of the suggestion event will be either “Level increased by X (from Y to Z)” or “Level decreased by X (from Y to Z)”. X will be the size of the jump, Y will be an estimation of the previous level and Z will be an estimation of the new data level.

To view these suggestion events, you can create a new tab in the Alarm Console and select to display suggestion events. This is possible for tabs displaying current alarms, history alarms and alarms in a sliding window.

> [!NOTE]
>
> - Currently, no suggestion events are generated for outliers and unlabeled change points.
> - Suggestion events have severity “Information” and source “Suggestion Engine”.
> - Suggestion events generated to indicate a behavioral anomaly are automatically cleared 2 hours after their creation time or their last update time.

#### Possibility to enable SSL/TLS encryption when creating or editing TCP/IP elements \[ID_23262\]\[ID_23617\]\[ID_23836\]\[ID_23947\]

When creating or editing a TCP/IP element, you can now enable SSL/TLS encryption.

To enable TLS, do the following on every DataMiner Agent in a DataMiner System containing elements that use TLS encryption:

1. In the C:\\Skyline DataMiner\\Certificates folder, place a PKCS12 file with (default) name “server.pfx”, containing the certificates and the private key.

1. Send a ConfigureTLSMessage with the following arguments:

   | Argument        | Description                                                                                                                        |
   |-------------------|----------------------------------------------------------------------------------------------------------------------------------|
   | DataMinerID       | ID of the DataMiner Agent ID.                                                                                                    |
   | EncryptedPassword | Encrypted password that will be used with the certificate in question. This is encrypted using the public key of the connection. |
   | Certificate       | Name of the certificate for which the password is set. Default: server.pfx                                                       |
   | ID                | ID of the certificate for which the password is set. Currently, DataMiner will always use the certificate with ID 0.             |

> [!NOTE]
>
> - DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1). It will negotiate the highest supported TLS version with the client. If the client supports TLS up to version 1.2, DataMiner will use version 1.2.
> - PFX files are not synchronized among the agents in a cluster.
> - When, on a DataMiner Agent, you replace a PKCS12 file, then all elements using the TCP/IP port in question have to be stopped and restarted for the changes to take effect.
> - TLS elements and non-TLS elements sharing the same TCP/IP port is not supported.

#### Redesigned DataMiner Cube layout \[ID_23427\]\[ID_23486\]\[ID_23540\]\[ID_23628\]\[ID_23646\]\[ID_23813\]\[ID_23822\]\[ID_23904\]\[ID_23982\]\[ID_24036\]\[ID_24044\]\[ID_24079\]\[ID_24086\]\[ID_24129\]\[ID_24143\]\[ID_24160\]\[ID_24165\]\[ID_24189\]\[ID_24218\]\[ID_24518\]

The design of DataMiner Cube has been updated to be more user-friendly and more in line with other DataMiner apps. Aside from numerous small layout changes, there have been a number of large changes, as detailed below.

##### Redesigned header bar

- In the header bar, the date and time and the four squares indicating the four "sides" of Cube are no longer displayed by default. A drop-down arrow in the header bar provides quick access to settings that allow you to display these again if you prefer this. These settings are also available on the *Cube* tab of the Cube settings card.

- In the middle of the header bar, there is now a search box. This search box features improved search possibilities compared to the search box that was previously included in the side panel. As soon as you click the search box, a list of suggestions is shown below. Initially, this list shows recent items, but it is updated with search results as soon as you type anything in the box. You can click a suggestion to immediately open the corresponding card, or click *Advanced search* at the bottom of the list to open a complete list of search results in the side panel. This list will stay visible until another tab is selected.

    > [!NOTE]
    > Hidden elements are no longer included in the search results.

- Cube settings, card layout settings, updates, and other options that were previously available via various menus of the header bar are now available in one single menu, which can be accessed via the user icon in the top-right corner.

- If an alarm storm occurs, this is no longer displayed in the header bar. Instead, a button is now displayed at the bottom of the Alarm Console. A tooltip on the button provides more information.

- The alarm banner has been replaced with a notification in the header bar. A new Cube setting is available, which allows you to choose between a wide or compact alarm banner.

##### Redesigned side panel

- The side panel on the left or right side of the Cube UI is now by default displayed as a blue bar containing the *Surveyor*, *Activity*, *Apps* and *Workspace* icons. Clicking these icons opens the corresponding panel.

- The *Activity* panel replaces the former *Recent* tab of the side panel, but functions in the same way as this tab, allowing you to pin items to the top of the list of recent activity.

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

- A number of buttons are now available, based on the status of the logon and the DMA. While you are logging onto a DMA, you can click *Back* to return to the logon screen. If a DMA is upgrading or migrating when you log on, you can click the *Monitor* button to monitor the progress. If a DMA is stopped, you can click *Start*, and if a DMA is offline, you can click *Set online*.

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

In the *Active alarms* tab page, for each alarm that can be considered “unexpected”, an icon will be displayed in the new *Focus* column, which is located between the *Icon* column and the *Element name* column.

Also, in the blue footer of the *Active alarms* tab page, you will notice a new focus icon. If you click this icon, the current tab page will only display the alarms with a focus icon in the *Focus* column.

> [!NOTE]
> If an alarm template changes, all alarms of the parameters that were assigned that alarm template will have their focus score reset and will get the focus icon. All historical focus data for those alarms will be lost.

##### In the event of an alarm storm

During an alarm storm, focus scores of persistent alarms will not be updated, but as soon as a storm has ceased, all active alarms will have their focus scores updated with the most recent values.

Also, an information event will be generated when alarm focus calculation goes into and out of alarm storm mode.

##### When will alarm focus values be recalculated from scratch?

Alarm focus values will be calculated for the first time after an upgrade to DataMiner version 10.0.2. They will only be recalculated from scratch when SLAnalytics notices that, for whatever reason, the Alarm Focus database table has been cleared.

When calculating alarm focus values for the first time, or when recalculating them from scratch, SLAnalytics will take into account the alarm history of the last week. The time taken by such a recalculation, will depend on the amount of alarms to be updated.

#### New system-wide ClientSettings.json setting to configure whether Data Display pages should be unloaded from memory when you navigate away from them \[ID_23913\]

In the *ClientSettings.json* file, the new system-wide *commonServer.ui.datadisplay.PageUnloadOnNavigatingAway* setting allows you to configure whether Data Display pages should be unloaded from memory when you navigate away from them.

Default value: False

#### Visual Overview: New option to collapse empty rows and columns in the connectivity chain of a service instance \[ID_23941\]

By adding a data field of type ‘ServiceInstance’ to a shape, it is possible to have the connectivity chain of a service instance drawn automatically in Visual Overview.

When configuring such a shape, from now on, you can use the *CollapseEmptyRowsAndColumns* option to automatically collapse all empty rows and columns in the connectivity chain.

Example:

| Shape data field | Value                            |
|------------------|----------------------------------|
| ServiceInstance  | \[this service\]                 |
| Options          | CollapseEmptyRowsAndColumns=True |

#### Settings: 'Table export column separator' setting replaced by 'CSV separator' setting \[ID_23986\]

The *Table export column separator* setting (on the *User \> Data Display* page of the *Settings* window) has now been replaced by the *CSV separator* setting (on the *User \> Regional* page of the *Settings* window).

The separator you select in this new setting will be used in all CSV files exported from Cube.

> [!NOTE]
>
> - This *CSV separator* setting is a Cube-only setting. When a CSV file export is initiated directly by a DataMiner Agent, this setting will be disregarded.
> - Before you import a CSV file that was exported using a previous version of Cube, make sure to check the separator used in that file.
> - When you copy data to the Windows clipboard, that data will always be delimited by TAB characters, regardless of the delimiter specified in the CSV separator setting.

#### Automation/Correlation/Scheduler - Email action: List of reports to be included now indicates whether a report is a legacy report or a Dashboards app report \[ID_24015\]

When, in Automation, Correlation or Scheduler, you configure an email action, you can specify whether the email message has to include a report. To do so, you select the *Include report or dashboard* checkbox and select a report from the list.

From now on, each report listed in the report selection box will have an icon that indicates whether it is a legacy report or a Dashboards app report.

#### DataMiner Cube will now be built as an AnyCPU application \[ID_24168\]

As from DataMiner X, DataMiner Cube will be built as an AnyCPU application.

ClickOnce StandAlone and MSI versions will run as 64-bit processes on 64-bit systems and as 32-bit processes on 32-bit systems.

> [!NOTE]
> Microsoft Internet Explorer always launches PresentationHost.exe as a 32-bit process. As a result, ClickOnce XBAP versions of Cube will always run as 32-bit processes.

#### New sidebar docking position setting \[ID_24178\]

In the restyled Cube X, the docking position of the sidebar can now be controlled by means of the *User \> Surveyor \> Sidebar docking position* setting.

Default: left

#### System Center: Agent state displayed on Agents page and total number of agents displayed on Agents, Database and Backup pages \[ID_24230\]

In *System Center*,

- the state of every agent in the DataMiner System is now displayed on the *Agents* page, and
- the total number of agents in the DataMiner System is now displayed on the *Agents* page, the *Database* page, and the *Select Agents to back up* window (which appears when you click *Execute backup* on the *Backup* page).

#### Visual Overview - Trend component: Filtering the legend’s element list and collapsing or expanding the legend by default \[ID_24349\]

When a shape is showing a trend component, it is now possible to

- filter the list of elements in the legend based on the value of a property of the Visio shape (see the *Filter* data item in the example below), and
- collapse or expand the legend by default (see the *ParametersOptions* data item in the example below).

Example:

| Shape data field  | Value                                                                |
|-------------------|----------------------------------------------------------------------|
| Component         | Trending                                                             |
| Parameters        | *DmaID:ElementID:ParameterID*         |
| ParametersOptions | CollapseLegend:true                                                  |
| Filter            | Property:*PropertyName=PropertyValue* |

#### Visual Overview: Linking a shape to an alarm via the root alarm ID \[ID_24367\]

From now on, a shape can also be linked to an alarm via the root alarm ID.

To do so, add a shape data field of type “Alarm” to the shape, and set its value to DmaID/RootAlarmID. If the alarm cannot be found, the shape will not be displayed.

If you want a shape linked to an alarm to visualize the root alarm ID, you can add a shape data field of type “Info”, and set its value to “ROOT ALARM ID”.

Example:

| Shape data field | Value             |
|------------------|-------------------|
| Alarm            | DmaID/RootAlarmID |
| Info             | ROOT ALARM ID     |

> [!NOTE]
>
> - If a shape is linked to an alarm, you can now also use the Info keywords in the shape text (enclosed in square brackets). For example: “The value of the alarm is \[value\].”
> - Note that, when you link shapes to alarms, only active alarms can currently be shown.

#### Visual Overview: Filtering an alarm tab by clicking an AlarmSummary shape \[ID_24380\]

By linking a shape to an alarm filter using an *AlarmSummary* data item, you can show statistical information about the alarms that match the filter. From now on, it is also possible to have the alarms displayed in an alarm tab, filtered according to the filter specified in the shape.

To do so, add a data item of type *AlarmTab*, and set its value to “Name=”, followed by the name of an alarm tab. See the example below.

When you click the shape, Cube will open the specified alarm tab (if it has a filter applied) and apply the alarm filter specified in the *AlarmSummary* data item. If the alarm tab specified in the *AlarmTab* data item has no alarm filter applied or if no alarm tab exists with that name, one will first be created.

| Shape data field | Value                                                                |
|------------------|----------------------------------------------------------------------|
| AlarmSummary     | type\|sharedfiltername\|ApplyLinkedViewServiceOrElementFilter\|Alarm |
| AlarmTab         | Name=AlarmTabName                                                    |

#### Visual Overview: Using 'info keywords' in all data items of a shape linked to an alarm \[ID_24485\]

Up to now, there were two ways to have a shape linked to an alarm show information about that alarm:

- Add an *Info* data item and set its value to a particular alarm keyword, and type a “\*” character in the shape text. The “\*” character will then be replaced by the value of the keyword you specified in the *Info* data item.
- Enter one or more alarm keywords (wrapped in square brackets) in the shape text. Those will then be replaced by their corresponding value.

From now on, it is also possible to specify alarm keywords in shape data items other than *Info*.

Example:

| Shape data field | Value                        |
|------------------|------------------------------|
| Alarm            | 10/20/500                    |
| SetVar           | MyVariable:\[root alarm id\] |

> [!NOTE]
>
> - To prevent infinite loops, do not specify alarm keywords in a shape data item of type *Alarm*.
> - Currently, it is not yet possible to use these keywords inside other keywords.

#### Visual Overview: Displaying a Visio page when the shape is not linked to an element, a view or a service \[ID_24507\]

Up to now, it was only possible to display a page of a Visio file associated with an object linked to a shape. To have a page named “Details” of a Visio file associated with an element named “MyElement” displayed in a separate window, for example, you had to add two data items to a shape: one of type *Element* set to “MyElement”, and one of type *VdxPage* set to “Details\|Window”.

From now on, it is also possible to display a page from the current Visio file by only adding a single data item of type *VdxPage* to a shape, without any reference to an element, view or service. This will allow you to also display Visio pages when a shape is linked to e.g. an alarm. See the following example:

| Shape data field | Value           |
|------------------|-----------------|
| VdxPage          | Details\|Window |

> [!NOTE]
> If you do not specify a window type suffix (“Window”, “Popup” or “ToolTip”), the Visio page will be displayed inside the shape.

### DMS Reports & Dashboards

#### Dashboards app: Quick-pick buttons added to time range feed \[ID_23133\]

The time range feed can now be configured to show a list of quick-pick buttons that will allow users to enter a preset time range by clicking a single button.

To configure the list of quick-pick buttons to be shown when users click a time range feed, go to edit mode, select the time range feed, open the *Layout* tab, select *Use quick picks*, and select the buttons to be shown.

#### Dashboards app: Enhanced theme configuration \[ID_23258\]

In the dashboard settings page, which is now named “*Dashboards settings*”, the dashboard theme configuration has been enhanced. On this page, you can create, copy and delete themes. When editing a theme, you can now also mark it as the default theme.

Also, there are now two system themes: “Light” and “Dark”. These are fixed themes that cannot be edited or deleted.

Per dashboard, a theme can be selected in the *Layout* tab, which has now also been restyled. From now on, this tab will only allow you to change the layout of a dashboard after selecting the *Override* option.

> [!NOTE]
> When you save a customized dashboard layout as a new theme, you will be asked to confirm this save operation as this will undo all changes you made to the layout of the dashboard you are editing.

#### Dashboards app: New shortcut menu option to move dashboards \[ID_23839\]

When you right-click the name of a dashboard in the navigation pane, there is now a new option that allows you to move that dashboard to another folder.

Also, that right-click menu has been optimized. The *Duplicate* option has been renamed to *Copy*, and the list of menu options has been restructured.

#### Dashboards app: Line chart component can now visualize resource capacity \[ID_23901\]

When you add a line chart component to a dashboard and drag resources onto it, it will display the resource capacity parameters as a stacked trend chart.

If you then click the chart and select a point in time, the legend will list all bookings for that specific point in time. To clear the list, right-click the chart or close the legend.

The resource capacity parameters displayed in the chart can be grouped by parameter or by resource.

#### Dashboards app: Separator used in CSV exports based on CSV separator setting in Cube \[ID_24161\]

The separator used in the CSV exports is based on the “CSV separator” setting in Cube. If this setting cannot be retrieved, in Internet Explorer the system will fall back to the Windows regional settings, while other browsers will fall back to the local browser settings.

#### Dashboards app: UI adapted to new DataMiner X style \[ID_24171\]

The header, sidebar and login screen of the Dashboards app have now been adapted to the new DataMiner X style.

#### Dashboards app: New 'Clear all' action + settings to pin actions \[ID_24356\]

In the dashboard settings, you can now "pin" actions to the header bar. When they are pinned, actions will be displayed as full buttons in the dashboard header bar, e.g. the *Start editing* button. When they are not pinned, the actions can be accessed via an arrow button in the top-right corner of the dashboard.

If a dashboard contains at least one feed, a new *Clear all* action is now available in the dashboard header, which can be used to clear the selection of the feeds in the dashboard.

It is possible to view this new action even when the dashboard is embedded, if "subheader=true" is added to the URL. However, not that this is only the case for the *Clear all* action.

For example: `http://[DMA IP]/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true`

#### Dashboards app: New 'Node edge graph' visualization \[ID_24433\]

A new *Node edge graph* visualization is now available in the *Other* category in the Dashboards app. This visualization can be used to display a service definition as a node edge graph. It can display the graph based on a service data filter, based on a service definition ID, or based on a reservation instance ID. If several of these inputs are specified, the input that was specified last will be used.

Several options are available to fine-tune the layout of the component. You can select whether node IDs and/or interfaces should be displayed, whether zooming is enabled, and which edge style is used.

### DMS Automation

#### Possibility to add, update or clear the script output \[ID_23936\]

Up to now, when a parent script added keys to the script output and then ran a subscript that also added keys to the script output, the keys added by the parent script would be deleted. From now on, the keys added by the parent script will by default no longer be deleted. If you want those keys to be deleted, then have the parent script call the engine.ClearScriptResult() method before starting the subscript.

Up to now, the following engine objects could be used to manipulate the script output:

- engine.AddScriptOutput(string key, string value)

    Adds a key to the script output if it has not yet been added. If the key already exists, an exception will be thrown.

- subScriptOptions.GetScriptResult()

    Returns a copy of the script output of the current script and, if the InheritScriptOutput option is set to “true”, the child scripts. For more information, see below.

From now on, you can also use the following new engine objects:

- engine.AddOrUpdateScriptOutput(string Key, string Value)

    Adds a key to the script output if it has not yet been added. If the key already exists, it will update it with the specified value.

- engine.ClearScriptResult()

    Clears the script output.

- engine.ClearScriptOutput(string key)

    Removes a key from the script output. Returns NULL when the specified key cannot be found.

- engine.GetScriptResult()

    Returns a copy of the script output of the current script and, if the InheritScriptOutput option is set to “true”, the child scripts. For more information, see below.

- engine.GetScriptOutput(string key)

    Returns the script output of the specified key. Returns NULL when the specified key cannot be found.

> [!NOTE]
> When a subscript fails or throws an exception, its script output will still be filled in.

Also, a new InheritScriptOutput script option will now allow you to control whether a parent script will inherit the script output of its subscripts. Default value: true

Example:

```csharp
var scriptOptions = engine.PrepareSubScript("MyScript");
scriptOptions.InheritScriptOutput = true;
scriptOptions.StartScript();
```

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

When you have selected a file, the actual upload will only start after you click a button to make the script continue (e.g. Close, Next, etc.). Once the upload has started, a *Cancel* option will appear, allowing you to abort the upload operation.

All files uploaded by users will by default be placed in the *C:\\Skyline DataMiner\\TempDocuments* folder, which is automatically cleared at every DataMiner startup.

#### New engine.UnsetFlag method to clear run-time flags \[ID_23961\]

In an Automation script, you can now use the engine.UnsetFlag method to clear the following run-time flags:

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
    _engine.UnsetFlag(RunTimeFlags.NoInformationEvents);
}
```

### DMS Web Services

#### Web Services API v1: 'GetTableForParameterV2' method has new 'as-kpi' table filter option \[ID_23928\]

The GetTableForParameterV2 method now supports filtering based on the following table column KPI options:

- KPIHideWrite
- HideKPI
- HideKPIWhenNotInitialized
- KPIShowDisplayKey
- KPIShowPrimaryKey
- DisableHistogram

To enable KPI option filtering when calling the *GetTableForParameterV2* method, specify the “as-kpi” filter in the *Filters* input field.

### DMS Mobile apps

#### New Monitoring & Control app \[ID_21736\]\[ID_22023\]\[ID_22209\]\[ID_22750\]\[ID_22801\]\[ID_22888\]\[ID_22943\]\[ID_23025\]\[ID_23036\]\[ID_23090\]\[ID_23387\]\[ID_23798\]\[ID_23874\]\[ID_24017\]\[ID_24059\]\[ID_24072\]\[ID_24080\]\[ID_24114\]\[ID_24134\]\[ID_24180\]\[ID_24192\]

The DataMiner HTML5 app has now been replaced by the new Monitoring & Control app, of which the overall look and feels closely resembles that of the newly redesigned Cube X.

- Redesigned header bar:

  - The app title “Monitoring & Control” is now a button that redirects the user to the app’s homepage.
  - Like in Cube X, the Search box has now been moved from the side panel to the middle of the header bar.
  - On the right, there is now one single user icon, which, when clicked, opens a menu that allows users to access to the settings window and the About box.

    Currently, the settings window allows you to specify the default pages for element and view cards.

- A new homepage similar to the Cube X homepage, listing recently used items.
- Redesigned (collapsible) side panel, on which alarm states are now indicated by colored circles.
- Redesigned element, service, view and alarm cards, which can be accessed directly using the following URLs:

  - `http://<DMAIP>/monitoring/element/<DMAID>/<EID>/data/<PAGENAME>`
  - `http://<DMAIP>/monitoring/element/<DMAID>/<EID>/visual/<PAGENAME>`
  - `http://<DMAIP>/monitoring/element/<DMAID>/<EID>/chain/<CHAINNAME>`
  - `http://<DMAIP>/monitoring/view/<VIEWID>/<PAGENAME>`
  - `http://<DMAIP>/monitoring/view/<VIEWID>/visual/<PAGENAME>`
  - `http://<DMAIP>/monitoring/alarm/<DMAID>/<ALARMID>`

> [!NOTE]
> To open this new Monitoring & Control app from the address bar of your internet browser, enter the IP address of the DataMiner Agent, followed by “/monitoring”.
>
> Alternatively, you can go to the landing page of the DataMiner Agent (by entering its IP address), and then click the *Monitoring & Control* button.

#### Legacy Monitoring & Control app: New settings to specify the default page for element, service and view cards \[ID_24017\]

In the *Settings* window of the legacy Monitoring & Control app, it is now possible to specify the default pages for element, service and view cards.

#### Jobs app: UI adapted to new DataMiner X style \[ID_24157\]

The header and login screen of the Jobs app have now been adapted to the new DataMiner X style.

#### New DataMiner landing page \[ID_24239\]

When you open a browser window and enter the IP address or host name of a DataMiner Agent, you are now directed to a new DataMiner landing page (“/root”).

After signing in, you will be presented with a list of apps (e.g. Monitoring, Dashboards, etc.).

Clicking the user menu in the upper-right corner will allow you to open the Tools page, the About page and DataMiner Help.

### DMS Service & Resource Management

#### DataMiner Cube: New Migrate booking data to Indexing Engine wizard [ID_21935] [ID_23674] [ID_24410] [ID_24424]

In DataMiner Cube, a new wizard has been added to the *Search & Indexing* section of *System Center*. This wizard allows you to migrate booking data from the Cassandra database to the Indexing database.

As some booking property names can contain characters that are considered invalid by the Indexing engine, the wizard will ask you to rename certain booking properties before starting the migration. To ensure the correct functionality of the Service & Resource Management module, some properties will be renamed automatically. For example, the *Visual.Background* and *Visual.Foreground* properties will automatically be renamed as *VisualBackground* and *VisualForeground*.

When you have successfully migrated all booking data, the button to start the wizard will disappear from the UI. Also, when the migration has finished, a *Retrieve report* button will allow you to generate a report showing a summary of that migration.

> [!NOTE]
>
> - After migrating the booking data to the Indexing database, make sure to check your Automation scripts and Visio files and adjust the booking property names where necessary.
> - When configuring backup settings in the *Backup* section of *System Center*, a new *Include SRM in backup* option is now available under the *Create a backup of the database* option. Select this option if you want the booking data in the Indexing database to be included in the backup package.
> - An Indexing database takes about twice as much disk space to store booking data compared to a Cassandra database.
> - A number of methods in the ServiceManagerHelper and ResourceManagerHelper classes have been adapted to allow them to manage booking data stored in an Indexing database.

#### Improvements ResourceManagerHelper class for deletion of resources \[ID_24002\]\[ID_24563\]

If there is an error deleting resources using the *ResourceManagerHelper* class, additional feedback is now returned:

- If one or more resources are deleted using the *ResourceManagerHelper* class, and at least one of the resources fails to be deleted, a single error, *ResourceDeleteFailed*, is returned, which now contains a *UsingIDs* property with all the IDs of the resources that failed. Any possible other resources are still successfully deleted.

- If a resource is deleted that is in use or in maintenance mode, the error *ResourceDeleteInUseOrMaintenanceMode* is returned. If the resource is included in scheduled, ongoing or quarantined bookings, the IDs of these bookings are now returned in the *FutureOrOngoingReservationIds* property.

If a resource that is used in past bookings is deleted, the deletion now fails by default, returning the error *ResourceDeleteInUseOrMaintenanceMode* with the boolean property *HasPastBookings* set to true.

In addition, the following new method is now available in the *ResourceManagerHelper* class: `Resource[] RemoveResources(Resource[] resources, bool ignorePastReservations);`

If *ignorePastReservations* is false, this method works in the same way as existing calls to remove resources. If it is set to true, past bookings will be ignored during the deletion checks. This can be used to delete resources that are only used in past bookings; however, note that these bookings may then contain invalid references to resources.

#### DataMiner will now generated an error when it detects a ServiceManager license but no ElasticSearch instance \[ID_24329\]

From now on, a DataMiner Agent will generated the following DataMiner run-time error when it detects a ServiceManager license but no Elasticsearch instance:

*The Service Manager is licensed, but no ElasticSearch database is active on the system. Therefore, Resource Manager and Service Manager will not initialize.*
