---
uid: ClientSettings_json
---

# ClientSettings.json

Within the subfolder `C:\Skyline DataMiner\Users`, there is a file *ClientSettings.json*, which contains client settings that apply for all users. Some of these settings, e.g. *MaxNumberOfSimultaneousNewAlarmsBeforeDelayingSort*, can only be configured directly within this file. You can find more information about these below.

The folder also contains a subfolder for each user, which in turn contains a user-specific *ClientSettings.json* file. However, all settings in that file can be configured via the Cube UI.

## Setting the maximum number of alarms before alarm sorting is delayed

There is a limit to the number of alarms that can be generated within 100 ms before sorting of the Alarm Console is paused. When more alarms are generated, a "Loading" message is displayed until 250 ms have passed without any new alarm.

It is possible to customize this threshold limit:

1. Make sure there are currently no open Cube sessions.

1. Open the file *ClientSettings.json*, and specify a different value for the setting *commonServer.ui.Alarmconsole.MaxNumberOfSimultaneousNewAlarmsBeforeDelayingSort*.

   By default, this value is set to 50. We recommend a minimum value of 20 and a maximum value of 250.

   ```json
   {
    "Name": "Cube common serverside settings",
    "Version": 1,
    "Settings": [
    ...
    {
    "Name": "commonServer.ui.Alarmconsole.MaxNumberOfSimultaneousNewAlarmsBeforeDelayingSort",
    "Value": 50,
    "VersionNumber": 0,
    "Mode": 0,
    "InVisible": false
    }
    ]
   }
   ```

> [!NOTE]
> In a DataMiner System, make sure all DataMiner Agents have this setting set to the same value.

## Setting demo languages to be available in Cube

By default, only officially supported languages are available in the Cube user settings. Currently, these are Dutch, English, French, German, Spanish, Russian (up to DataMiner 10.2.6), and Portuguese (Portugal).

A number of other languages can be made available in Cube for demo purposes. These include Arabic, Brazilian Portuguese, Catalan, German, Italian and Japanese. However, when the UI is set to one of these demo languages, you are likely to encounter sections that are still in English.

To be able to select a demo language, do the following:

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`.

1. For the value of the setting *commonServer.ui.Include_All_Uilocale* from *false* to *true*.

1. Save and close the file.

1. If Cube was already open, reconnect to Cube.

## Limiting the properties to which Cube subscribes

To improve the memory usage of DataMiner Cube in systems with many properties, you can configure Cube so that it only subscribes to a subset of properties, instead of all the properties of the DMS.

You can do so using the settings *commonServer.ui.Subscribe_To_All_Properties* and *commonServer.ui.Property_Cache* in the *ClientSettings.json* file:

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`.

1. Set the setting *commonServer.ui.Subscribe_To_All_Properties* to *false*:

   ```json
   {
       "Name": "commonServer.ui.Subscribe_To_All_Properties",
       "Value": “False”,
       "VersionNumber": 0,
       "Mode": 0,
       "InVisible": false
   },
   ```

1. In the setting *commonServer.ui.Property_Cache*, specify the properties to which Cube should subscribe, separated by commas.

   For example, to only subscribe to two properties called Property1 and Property2, specify the following configuration:

   ```json
   {
       "Name": "commonServer.ui.Property_Cache",
       "Value": [
           "Property1", "Property2"
       ],
       "VersionNumber": 0,
       "Mode": 0,
       "InVisible": false
   }
   ```

1. Save and close the file.

1. If Cube was already open, reconnect to Cube.

## Configuring caching of specific table parameters

It is possible to configure that certain table parameters have to be cached. These can for instance be tables containing connections between dynamically positioned shapes.

If a table parameter with a large number of rows is cached, DataMiner Cube will retrieve the table data from the cache instead of from the server, which will lower the overall load on both the client and the server. However, as this will increase memory usage in DataMiner Cube, caching table parameters should only be used in specific cases.

For example, to have two table parameters cached, specify the following configuration.

```json
{
    "Name": "commonServer.ui.Parameter_Cache",
    "Value": [
        {
            "DataMinerID": 234,
            "ElementID": 2,
            "ParameterID": 200,
            "SubscriptionFilter": "value=202 == 2;columns=202,203,204,205"
        },
        {
            "DataMinerID": 234,
            "ElementID": 103,
            "ParameterID": 5000,
            "SubscriptionFilter": "value=5005 == 5"
        }
    ],
    "VersionNumber": 0,
    "Mode": 0,
    "InVisible": false
}
```

From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43457-->, it is possible to cache specific columns of a table using the optional `ColumnIDs` property. If no `ColumnIDs` property is specified, the entire table will be cached.

For example, the following configuration shows how to cache only specific columns of a table parameter:

```json

{
    "DataMinerID": 956,
    "ElementID": 1846,
    "ParameterID": 1500,
    "SubscriptionFilter": null,
    "ColumnIDs": "1512"
}
```

> [!NOTE]
>
> - A `columns=` option can also be provided in the `SubscriptionFilter`. In this case, it takes priority over the separate `ColumnIDs` setting.
> - When `columns=` is used in `SubscriptionFilter`, only requests that use the same `SubscriptionFilter` will use the cache. For the separate `ColumnIDs` setting, any request that matches the other cache settings will use the cached data if the requested column matches the cached column.
> - Make sure that all the required columns are being retrieved when you use the "columns=" option. If this does not match, the cache will not be used.

The \[Param:\] placeholder in Visual Overview uses data from the cache. However, the subscription filter used for the placeholder needs to match the subscription filter in the configuration minus any "columns=" options. (See [Filtering the data of a cached table parameter](xref:Filtering_the_data_of_a_cached_table_parameter).)

From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43457-->, Visual Overview also supports using the parameter cache for:

- Parameter parts (parameters used in conditional statements)
- Parameter placeholders that target a full column rather than a specific row

From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43457-->, wildcard characters can be used in table keys when requesting data from cached tables:

- `*` matches any number of characters.
- `?` matches exactly one character.

For example, if the display keys of a table are in the format `qaTable 500_x`, you can use a request such as: `<A>-A|MyElement|Parameter:507,qaTable*5|=Active`. This will match the row with display key `qaTable 500_5`.

It is also possible to cache table parameters that are configured as matrix parameters in the Router Control module. In this case, the subscription filter you specify must exactly match the subscription filter on the table. (See [Adding a matrix represented by two table parameters](xref:Designing_a_matrix_tab_page_in_the_Router_Control_module#adding-a-matrix-represented-by-two-table-parameters).)

The following example illustrates how to configure the caching of an input table and an output table:

```json
{
    "Name": "commonServer.ui.Parameter_Cache",
    "Value": [
        {
            "DataMinerID": 1,
            "ElementID": 2,
            "ParameterID": 1000,
            "SubscriptionFilter": "value=1002 in_range 0/100; COLUMNS=1001,1002,1003,1004;"
        },
        {
            "DataMinerID": 1,
            "ElementID": 5,
            "ParameterID": 2000,
            "SubscriptionFilter": "value=PK in_range 1/60; value=PK in_range 70/100;"
        }
    ],
    "VersionNumber": 0,
    "Mode": 0,
    "InVisible": false
}
```

> [!NOTE]
> After you update this setting, force a synchronization of the *ClientSettings.json* file in the DataMiner System. See [Forcing synchronization of a file with the DMS](xref:Synchronizing_data_between_DataMiner_Agents#forcing-synchronization-of-a-file-with-the-dms).

## Configuring EPM card behavior based on Surveyor selection

It is possible to configure whether an EPM card is opened based on a selection in the Surveyor or not. By default, an EPM card will only be opened if a launch button is clicked in the Surveyor topology. However, it is possible to customize this behavior for a specific user so that an EPM card will be opened as soon the user selects an item in the Surveyor topology.

To do so:

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`\\*\[User name\]*.

1. Set the value of the setting *Surveyor.CPE.LaunchCPECardOnSelect* to true.

   ```json
   {
    "Name":"Surveyor.CPE.LaunchCPECardOnSelect",
    "Value": true,
    "VersionNumber": 0,
    "Mode": 0,
    "InVisible": false
   }
   ```

1. Save and close the file.

1. If Cube was already open, reconnect to Cube.

## Enabling or disabling the advanced editing Visio add-in

If a Visio file is opened from Visual Overview, an advanced editing add-in is available in Visio (see [Using DataMiner features in Visio](xref:Working_with_shape_data_in_Microsoft_Visio#using-dataminer-features-in-visio)).

In the shared client settings file, it is possible to enable or disable this add-in:

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`.

1. Set the setting *commonServer.ui.EnableVisioExtension* to *true* to enable the add-in or to *false* to disable it:

   ```json
   {
       "Name": "commonServer.ui.EnableVisioExtension",
       "Value": “False”,
       "VersionNumber": 0,
       "Mode": 0,
       "InVisible": false
   },
   ```

1. Save and close the file.

1. If Cube was already open, reconnect to Cube.

## Setting the default time zone for DataMiner web apps

The time displayed in the DataMiner web apps (e.g. the Dashboards app) is based on a time zone setting in the file `C:\Skyline DataMiner\users\ClientSettings.json`. If this setting is not configured, the time zone of the client browser is used instead.

To configure this setting:

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`.

1. Set the setting *commonServer.ui.DefaultTimeZone* to the time zone you want.

   For example:

   ```json
   {
       "Name": "commonServer.ui.DefaultTimeZone",
       "Value": "Pacific Standard Time;-480;(UTC-08:00) Pacific Time (US & Canada);Pacific Standard Time;Pacific Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];",
       "VersionNumber": 0,
       "Mode": 0,
       "InVisible": false
   }
   ```

   To retrieve this time zone value, you can run the following commands in a PowerShell prompt on the server:

   ```powershell
   $timezones = [System.TimeZoneInfo]::GetSystemTimeZones()
   $timezone = $timezones | Where-Object {$PSItem.StandardName -eq [System.TimeZone]::CurrentTimeZone.StandardName }
   Set-Clipboard -Value $timezone.ToSerializedString()
   ```

   This last line will paste the required string to the clipboard.

   > [!NOTE]
   > For more information on the *TimeZoneInfo.ToSerializedString* method, see <https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo.toserializedstring>.

1. Save and close the file.

1. Perform an IIS restart to apply the time zone changes.

   > [!NOTE]
   > Prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4<!--RN 42202-->, an IIS restart is not necessary, and changes made to the time zone in *ClientSettings.json* will take effect immediately as soon as the web app is refreshed.

## Configuring settings for Cube UI freezing

The Cube logging can display logs of type "Freeze" to indicate when the Cube UI has been frozen. In `C:\Skyline DataMiner\users\ClientSettings.json`, you can configure how long the Cube UI has to be frozen before an entry is logged in the Cube logging. In addition, you can also configure how long the UI has been frozen before a pop-up is displayed.

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`.

1. Set the setting *commonServer.client.ui.logging.FreezeLogTime* to the number of seconds the Cube UI has to be frozen before a "Freeze" log entry is made (default: 10).

1. Set the setting *commonServer.client.ui.logging.FreezePopupTime* to the number of seconds the Cube UI has to be frozen before a pop-up message is displayed (default: 30).

1. Save and close the file.

Example:

```json
 {
 "Name": "commonServer.client.ui.logging.FreezeLogTime",
 "Value": 10,
 "VersionNumber": 0,
 "Mode": 0,
 "InVisible": false
 },
 {
 "Name": "commonServer.client.ui.logging.FreezePopupTime",
 "Value": 30,
 "VersionNumber": 0,
 "Mode": 0,
 "InVisible": false
 },
```

## Making Cube unload data pages when you navigate away

It is possible to enable a setting that clears each data page from memory when you navigate to a different page. Enabling this setting can be useful to decrease memory usage, but may result in reduced responsiveness when navigating between data pages in Cube.

To enable this setting:

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`.

1. Set the setting *commonServer.ui.datadisplay.PageUnloadOnNavigatingAway* to *true*.

   ```json
   {
    "Name": "commonServer.ui.datadisplay.PageUnloadOnNavigatingAway",
    "Value": true,
    "VersionNumber": 0,
    "Mode": 0,
    "InVisible": false
   }
   ```

1. Save and close the file.

## Having a forward button displayed in card headers

By default, the header of cards in DataMiner Cube does not display a forward button. However, it is possible to configure a setting in *ClientSettings.json* to make sure such a button is displayed:

1. Open the file *ClientSettings.json* in the folder `C:\Skyline DataMiner\Users`.

1. Set the setting commonServer.card.DisplayForwardButton to *true*.

   ```json
   {
    "Name": "commonServer.card.DisplayForwardButton",
    "Value": true,
    "VersionNumber": 0,
    "Mode": 0,
    "InVisible": false
   }
   ```

1. Save and close the file.
