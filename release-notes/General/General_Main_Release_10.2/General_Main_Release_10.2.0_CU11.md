---
uid: General_Main_Release_10.2.0_CU11
---

# General Main Release 10.2.0 CU11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLLogCollector will now first check for default.xml files in the LogConfig folder in the same location as SL_LogCollector.exe [ID_34739]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, SLLogCollector expected custom collector configuration files named `default.xml` to always be placed in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

From now on, it will first check the `LogConfig` folder in the same location as `SL_LogCollector.exe`. If that `LogConfig` folder does not exist, if the folder is empty or if the `default.xml` file in that folder cannot be deserialized, it will fall back on the `default.xml` file in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

#### DataMiner Cube - Visual Overview: Enhanced performance when loading sorted tree view controls [ID_34795]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when loading sorted tree view controls.

#### NAS service will now have a quoted image path [ID_34989]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, the NAS service had an unquoted image path. From now on, it will instead be installed with a quoted path.

When you want the NAS service on existing setups to have a quoted path, do the following:

1. Execute the following command:

   `sc config NAS binPath="\"C:\Skyline DataMiner\NATS\nats-account-server\nssm.exe\""`

1. Restart NAS and NATS.

#### DataMiner Cube - Trending: Trend points with value "0" will now also be exported to CSV [ID_35124]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

Up to now, when you exported real-time trend data to a CSV file, trend points with value "0" would not be included. From now on, those values will be exported as well.

### Fixes

#### DataMiner Cube: Latest script updates would not be shown when opening a script in the Automation app [ID_34738]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened the *Automation* app in DataMiner Cube and selected an unmodified script, the latest updates made to that script by another Cube client or another program (e.g. DataMiner Integration Studio) would not be shown. From now on, when you open a script in the Automation app that has not yet been changed in that same app, the latest version of that script will now automatically be retrieved from the server.

#### Problem with Elasticsearch health monitoring [ID_34744]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an Elasticsearch cluster used by DataMiner was hosted on servers that host IPv6 addresses, the Elasticsearch health monitoring in DataMiner would fail to assess the Elasticsearch cluster state and conclude that the indexing database was unavailable.

#### DataMiner Cube - Alarm Console: Alarm tab of type 'Active alarms linked to cards' would incorrectly not show any alarms when you opened a function card [ID_34799]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU11] - FR 10.3.2 -->

When the Alarm Console had an alarm tab of type *Active alarms linked to cards*, that tab would incorrectly not show any alarms when you opened a function card, even when that function had active alarms.

Also, when you added a new alarm tab, clicked *Apply filters*, and added an element filter, then you would incorrectly also be able to select virtual functions from the list of elements. From now on, only when you add a function filter will you be able to select virtual functions from the list of functions.

#### Alarm Console: Masking a correlated alarm would incorrectly cause the base alarms to disappear from the 'Active alarms' tab [ID_34815]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, when you masked a correlated alarm, the alarm would not only be moved to the *Masked alarms* tab together with all its sources. The base alarms would also disappear from the *Active alarms* tab. From now on, when you mask a correlated alarm, its base alarms will remain visible in the *Active alarms* tab.

#### DataMiner Cube - Protocols & Templates: Function protocols would incorrectly be listed multiple times [ID_34885]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened the *Protocol & Templates* module, in some rare cases, function protocols would incorrectly be listed multiple times in the protocol list.

#### DataMiner Cube: Renaming your local DataMiner user would incorrectly cause that user to disappear [ID_34918]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you renamed your local DataMiner user with administrative access while being logged in as that user, the user would incorrectly get (partially) removed.

#### Alarm state changes could be generated at an incorrect time in the trend graph of a monitored parameter that needed to be compared to a relative baseline value [ID_34952]

<!-- MR 10.2.0 [CU11] - FR 10.3.1 -->

In the trend graph of a monitored parameter that needed to be compared to a relative baseline value, in some cases, alarm state changes could be generated at an incorrect time.

> [!NOTE]
> When both the baseline and the factor are stored in parameters, then the baseline parameter, the factor parameter and the monitored parameter must all have the history set option enabled. Also, all history sets should be executed chronologically.

#### Cassandra cluster: Nullreference exceptions [ID_34964]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

On systems with a Cassandra cluster, in some cases, messages to SLDataGateway could cause `nullreference` exceptions to be thrown.

Example of an exception stored in the `SLDBconnection.txt` log file:

```txt
SLDBConnection|Skyline.DataMiner.Net.Messages.SLDataGateway.DataRequest`1[Skyline.DataMiner.Net.Messages.SLDataGateway.Alarm]|INF|0|285|System.NullReferenceException: Object reference not set to an instance of an object.
   at SLCassandraClassLibrary.DBGateway.DBGateway.ExecuteRequest[T](DataRequest`1 request)
   at SLCassandraClassLibrary.DBGateway.IncomingConnection.$_executor_ExecuteRequest(BaseRequest request)
```

#### Problem with SLDataMiner when loading an alarm template schedule failed [ID_34988]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, an error could occur in SLDataMiner when loading an alarm template schedule failed.

#### DataMiner Cube: Problem when opening scheduled tasks, Automation scripts or Correlation rules containing actions that include PDF reports [ID_34997]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU11] - FR 10.3.2 -->

When, in *Scheduler*, *Automation* or *Correlation*, you opened scheduled tasks, Automation scripts or Correlation rules containing actions that include PDF reports, in some rare cases, the data linked to those reports (i.e. the elements and services in view selection) could not be loaded. This data will now be loaded correctly. Also, a "Loading" indicator will now be displayed and the actions will remain disabled while the data is being loaded. When an error occurs while loading the protocols associated with said data, a clear warning entry will also be added to the Cube logging.

> [!NOTE]
> From now on, in the *Elements and services in view selection* list, it will also be possible to select parameters of enhanced services.

#### DataMiner Cube - Spectrum Analysis: Selected measurement point no longer selected after playing a spectrum recording [ID_35001]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you selected a measurement point of a spectrum trace, and then played a spectrum recording in which other measurement points were used, the measurement point you selected would incorrectly no longer be selected when the spectrum recording stopped playing.

#### Web apps - Visual Overview: Certain actions would no longer work [ID_35012]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, *Card*, *Script*, *Link* and *Popup* actions would no longer work in visual overviews opened in web apps.

#### DataMiner Cube - Alarm Console: Cube freezes when loading a large sliding window [ID_35032]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened an alarm tab of type "sliding window" with a large number of alarm trees, in some cases, the UI could become unresponsive.

#### DataMiner Cube: Y-axis values could be missing when opening a trend graph [ID_35060]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened the trend graph of a parameter that contained discrete values or exceptions, in some cases, Y-axis values could be missing.

#### SLLogCollector would only take a dump of the first process when multiple processes were specified in the -d command-line option [ID_35074]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you ran SLLogCollector via the command line and specified multiple processes for which dumps had to be taken (e.g. `SL_LogCollector.exe -c -d=46436,61652`), it would incorrectly only take a dump of the first process.

#### Automation: Memory leak when using the engine.AddScriptOutput method to pass script output of type string [ID_35119]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an engine.AddScriptOutput method was used to pass output data of type string from a script to the application that executed it or from a subscript to the script that executed that subscript, that output data of type string would incorrectly not get cleared from memory.

#### DataMiner Cube - Alarm Console: Incorrect error would appear when a DataMiner cluster had an IDP license but no Resource Manager license [ID_35123]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a DataMiner cluster had an IDP license but no Resource Manager license, an error would incorrectly appear in the Alarm Console when the agents were synchronized.

#### Protocols: Problem when using the 'partialSNMP' option when polling tables using the 'multipleGetNext' or 'multipleGetBulk' method [ID_35147]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When the *partialSNMP* option was used when polling tables using the *multipleGetNext* or *multipleGetBulk* method, up to now, rows and values would be skipped when one or more columns did not contain values for one or more rows. This caused the next partial requests to jump forward by the amount of empty cells, resulting in missing rows and unexpected empty cells.

Also, a problem with the detection of infinite loops for SNMPv3 when receiving end-of-mib-view errors has been fixed.

#### DataMiner Cube - Trending: Trend graph would start to flicker when its data was updated [ID_35181]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened a trend graph and left it open for a while, it would start to flicker when its data was updated.
