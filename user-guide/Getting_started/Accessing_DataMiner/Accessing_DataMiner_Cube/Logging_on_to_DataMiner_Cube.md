---
uid: Logging_on_to_DataMiner_Cube
---

# Logging on to DataMiner Cube

When you open DataMiner Cube, in most cases you will be logged on automatically with your current Windows account. However, if, for example, you explicitly logged out of your previous DataMiner Cube session, or your system uses external authentication, the DataMiner Cube logon screen will be displayed.

## Logging on to DataMiner Cube

### [DataMiner 10.0.0/10.0.2 or higher](#tab/tabid-1)

1. Check if the IP or name that is displayed below the DataMiner logo is that of the DMA you want to connect to. If not, click the IP or name and specify a different IP or name in the box.

1. Specify your credentials if necessary:

   - To log in with the current Windows user account, no credentials need to be specified.

   - To log in with a different user account, click the gray user icon at the bottom of the page and then specify the username and password.

1. Optionally select *Remember me* in order to log in automatically next time.

   > [!TIP]
   > If you do not want to log in automatically, hold the `Shift` key during DataMiner Cube startup.

1. Click the blue arrow icon below the user information to log on.

> [!NOTE]
>
> - When you log out of a DMS using the Cube desktop app, you are returned to the logon screen, but no dropdown box will be available to modify the DMA you connect to. This is intended to ensure that you do not connect to a DMA with a different software version. However, if for some reason, for example for testing or debugging purposes, you do wish to connect to a different DMS using the current DataMiner version, keep `Ctrl + Alt+ Shift` pressed, and you will be able to select a different DMS. Note that this feature should never be used in normal circumstances, as it can cause unexpected behavior.
> - From DataMiner 10.1.3 onwards, after you have logged out using the Cube desktop app, you can click the arrow button to go back to the start window and select a different DMA to connect to.

### [Earlier versions](#tab/tabid-2)

#### Logging on using one of the listed user accounts

1. If you are using the DataMiner Cube desktop application, check the name of the DataMiner Agent in the *Connect to* box. If necessary, specify a different DMA.

   > [!NOTE]
   >
   > - If you are using the DataMiner Cube browser application and want to connect to a different Agent, click *Connect to another Agent* and specify the DMA in the *Connect to* box.
   > - From DataMiner 9.0 onwards, the logon window will adopt the theme of the Agent selected in the *Connect to* box.

1. Click one of the listed users and enter the password if necessary.

   > [!NOTE]
   > If you log on with your current Windows user account, you will not need to specify a password.

1. If you do not want to have to enter the password again the next time you log on, select *Save my user name and password*.

1. Click *Log on*.

#### Logging on with a user account that is not in the list

1. If you are using the DataMiner Cube desktop application, check the name of the DataMiner Agent in the *Connect to* box. If necessary, specify a different DMA.

   > [!NOTE]
   >
   > - If you are using the DataMiner Cube browser application and want to connect to a different Agent, click *Connect to another Agent* and specify the DMA in the *Connect to* box.
   > - From DataMiner 9.0 onwards, the logon window will adopt the theme of the Agent selected in the *Connect to* box.

1. Click *Other User*.

1. Enter the username or email address and the password.

1. If you do not want to have to enter the password again the next time you log on, select *Save my user name and password*.

1. Click *Log on*.

> [!NOTE]
> If, on the client computer, no cached user settings can be found for the user account you logged on with, DataMiner Cube will load the default user settings stored on the DataMiner Agent.

***

## Overriding the default connection type

By default, the type of connection that will be established between DataMiner Cube and the DMA will be the type of connection that is specified in the file *connectionsettings.txt* (located in the following directory on the DMA: *C:\\Skyline DataMiner\\Webpages*). However, on the logon screen, you can override that default connection type for the connection you are about to establish.

To do so, before you log on, do the following:

### [DataMiner 10.0.0/10.0.2 or higher](#tab/tabid-1)

1. On the login page, click the cogwheel button in the lower right corner and select *Options* in the menu.

1. In the *Edit Settings* window, set the *Connection Type* to one of the following values:

   - *Auto*: DataMiner will automatically select the connection settings.

   <!-- - *gRPC*: Available from DataMiner 10.3.0/10.3.x onwards. DataMiner will communicate using HTTPS via the API Gateway, using gRPC GZIP compression. By default, this requires the use of the standard HTTPS port 443. -->

   - *Remoting*: DataMiner will communicate using .NET Remoting.

     - This option is used by default.

     - The default port used for Remoting is port 8004.

     - By default, [eventing](xref:Eventing_or_polling) is used, but the client will automatically fall back to polling if the callback port cannot be reached (e.g. if a firewall blocks the requests).

   - *Web Services*: Legacy option available prior to DataMiner 10.0.0 \[CU6\]/10.0.11. As WSE is deprecated, this option is no longer available in recent DataMiner versions. Connecting via web services is not possible if WSE is not installed on the DMA.

<!--    > [!NOTE]
   > The selected connection type will be **used to connect to any DMA from the current computer**. Keep this in mind, for example in case you have selected *gRPC* and you want to connect to DataMiner versions prior to 10.3.0/10.3.2, which do not support gRPC yet. -->

1. If necessary, adjust the settings for the selected connection type:

   - **Destination port**: Select this option to specify a custom destination port number. If you specify “-1”, the port will be detected automatically.

   - **Polling interval**: The frequency at which the client application should poll the DMA, in milliseconds. If you want to use remoting and there are firewalls in your network or NAT is used, make sure this option is selected, to ensure that polling is used instead of eventing. For Web Services, this option is enabled by default.

   - **Use data compression** (Remoting only): Determines whether data are compressed or not. By default, this option is selected, in order to reduce network traffic.

   - **Custom binding IP address** (Remoting only): Only needed in case the server cannot automatically resolve the IP address that it needs to send callback events to the client, which can be the case when a VPN connection is used. The option only applies when eventing has been configured.

1. Click *OK*.

### [Earlier versions](#tab/tabid-2)

  1. At the bottom of the logon screen, click *Options*.

  1. In the *Edit Settings* window, set the *Connection Type* to either *Remoting* or *Web services* and modify the different settings if necessary (destination port, polling interval, ...).

  > [!NOTE]
  > Connecting via web services is not possible if WSE is not installed on the DMA.

  1. Click *OK*.

***

> [!NOTE]
> It is also possible to change the connection settings once you are logged on. To do so, go to *Settings \> computer \> Connection*. See [Manual configuration of client communication settings](xref:DMA_configuration_related_to_client_applications#manual-configuration-of-client-communication-settings).

## Logging off from DataMiner Cube

### [DataMiner 10.0.0/10.0.2 or higher](#tab/tabid-1)

- In the header bar, click the user icon and select *Sign out*.

### [Earlier versions](#tab/tabid-2)

1. In the header bar, click the name of the user who is currently logged on.

1. At the top of the *Contacts* window, click *Log Off*.

***
