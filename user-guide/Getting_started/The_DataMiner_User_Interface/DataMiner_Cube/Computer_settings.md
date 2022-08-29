---
uid: Computer_settings
---

# Computer settings

Any user preferences in DataMiner Cube pertaining to the user’s computer are grouped in the *computer* tab of the *Settings* window.

Like the user settings, the DataMiner Cube computer settings are divided in several different sections:

- [Connection settings](#connection-settings)

- [Cube settings](#cube-settings)

- [Debug settings](#debug-settings)

- [Performance settings](#performance-settings)

- [Visual Overview settings](#visual-overview-settings)

- [Advanced settings](#advanced-settings)

## Accessing the computer settings

To access the computer settings in DataMiner Cube:

1. Go to the *Settings* window:

   - From DataMiner 10.0.0/10.0.2 onwards:

     - Click the apps button in the sidebar and select *Settings* at the bottom of the apps panel, or

     - Click the user icon in the header bar and select *Settings* in the menu.

   - Prior to DataMiner 10.0.0/10.0.2:

     - In the navigation pane, click the apps button and select *Settings*, or

     - Click the current user in the header bar, and click *Settings*.

1. Click the *computer* tab.

   The tab consists of 5 pages that you can navigate between using the table of contents on the left.

> [!NOTE]
> For more information on the user settings tab, see [User settings](xref:User_settings).

## Overview of the computer settings

### Connection settings

On this page, you can select settings related to the connection of your computer to DataMiner Cube. These settings are also available in the Cube logon window. See [Logging on to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube).

- **Automatic log-on with saved user name and password**: Select this setting to have DataMiner Cube remember your username and password, so that you do not have to enter these except after an explicit logout.

- **Connection type**: Select a connection type in the drop-down list. By default, this is set to *Auto*. If you select *Remoting* instead, more settings will be displayed that need to be specified (destination port, polling interval, etc.).

  > [!NOTE]
  > Prior to DataMiner 10.0.0 \[CU6\]/10.0.11, you can also select the option *Web Services*. However, as WSE is deprecated, this option is no longer available in recent DataMiner versions. Connecting via web services is not possible if WSE is not installed on the DMA.

  > [!TIP]
  > See also: [Manual configuration of client communication settings](xref:DMA_configuration_related_to_client_applications#manual-configuration-of-client-communication-settings)

### Cube settings

This page is available from DataMiner 10.0.12 onwards. It contains the following setting:

- **Display cluster name in header**: Select this option to have the name of the DataMiner System displayed in the Cube header by default.

### Debug settings

This page contains the following debug settings:

- **Debug settings visible**: Select this setting along with the user setting *Show General Parameters debug page* to show an additional Data Display page called *General parameters DEBUG*. This page contains general parameters that are only used for debug purposes and that are not usually displayed.

  > [!TIP]
  > See also: [Data Display settings](xref:User_settings#data-display-settings)

- **Trace mode**: When you enable this setting, Cube debug logging is saved in a file in the following folder: *C:\\ProgramData\\Skyline\\DataMiner\\DataMinerCube\\Traces*. This mode is meant to solve issues, and will not be needed in normal circumstances.

- **Enable trend logging**: This setting is available from DataMiner 9.5.11 onwards. If you enable this setting, a number of log files will be kept with regard to trending.

  > [!NOTE]
  > This setting is disabled by default. Enabling it will cause memory usage to increase substantially. Therefore, it is recommended to only enable it temporarily for debugging purposes.

### Performance settings

This page contains settings that are related to your computer’s performance:

- **Use of animation**: Enables animations in the Cube UI.

  > [!NOTE]
  > Up to DataMiner 9.0.3, this setting is called *3D effects*.

- **Use hardware rendering**: Select this setting to set the graphics rendering mode to hardware rendering.

- **Frame rate**: Determines the frame rate of all animations used in DataMiner Cube, including the “progress bar” animation in the logon screen that starts when you click the *Log on* button. Set to 60 by default.

  > [!NOTE]
  > When you change this frame rate setting, restart DataMiner Cube to have the change take effect.

- **Trend update frame rate**: Available from DataMiner 9.5.7 onwards. Determines the rate at which trend graphs are redrawn.

### Visual Overview settings

There is only one setting on this page:

- **Working folder**: Select this setting and specify the folder where you want to keep all Visio files that have been edited on your computer. In this folder, the Visio files can be edited offline, so that they can be synchronized later.

### Advanced settings

On the main *Advanced* page, the following settings are available:

- **Connection timeout (ms)**: In the box next to this setting, you can specify the number of milliseconds for the connection timeout.

- **Enable browser cache**: Available from DataMiner 10.2.4/10.3.0 onwards. Select this checkbox to enable the cache of the Chromium browser engine. Enabling this cache can make web applications load faster and can provide a better single sign-on experience in case SAML authentication is used.

  > [!NOTE]
  > Enabling this setting involves a potential security risk: If multiple DataMiner users share the same Windows account on a particular computer, they will also share the same browser cache and, as a consequence, the same authentication on third-party websites.

- **DataMiner Cube computer \[computername\] reset**: Click the button next to this setting to reset all computer settings back to default. In normal circumstances, this option should never have to be used.

There are also two subpages: *Logging* and *Communication*.

#### Logging

This page allows you to determine the number of log entries kept in the DataMiner logging, as well as the general log level.

- **Minimum number of log entries**: The minimum number of log entries that will be kept when older entries are deleted.

- **Maximum number of log entries**: The maximum number of log entries that will be stored in memory. When this number is reached, the oldest entries are deleted.

- **Level of logging**: The level of detail of the log entries. The higher the value, the more detailed the logging.

> [!NOTE]
> Be careful about applying the higher levels like *Log_Everything* or *Development_Logging*, as these require a lot of resources.

#### Communication

This page contains a number of settings regarding communication between the computer and the DMS.

- **Maximum number of sent messages**: In the box to the right of this setting, enter the maximum number of sent messages that should be stored.

- **Maximum number of received messages**: In the box to the right of this setting, enter the maximum number of received message that should be stored.

- **Fallback sent messages**: In the box to the right of this setting, enter the minimum number of sent messages that will be kept when older messages are deleted.

- **Fallback received messages**: In the box to the right of this setting, enter the minimum number of received messages that will be kept when older messages are deleted.

- **Store full messages**: As soon as you apply this setting, details will be stored for each message. These can be viewed in a separate *Details* pane when you click the message in the communication logging. See [Consulting the DataMiner logs in DataMiner Cube](xref:Consulting_the_DataMiner_logs_in_DataMiner_Cube).
