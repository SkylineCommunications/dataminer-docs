---
uid: DMA_configuration_related_to_client_applications
---

# DMA configuration related to client applications

## Configuring client communication settings

Users can define whether DataMiner Cube has to automatically detect the settings to be used when establishing a connection toward a certain DataMiner Agent.

If it is set to automatically detect the connection settings, Cube will connect to a DataMiner Agent according to the communication settings defined on the DataMiner Agent to which it is connecting. As a consequence, no settings will have to be changed when a user opens multiple instances of DataMiner Cube, all pointing to different DataMiner Agents.

> [!TIP]
> See also:
>
> - [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)
> - [Configuring SLNet settings in MaintenanceSettings.xml](xref:Configuration_of_DataMiner_processes#configuring-slnet-settings-in-maintenancesettingsxml)

### .NET Remoting with or without eventing

By default, clients connecting to a DataMiner Agent use .NET Remoting with eventing.

- **.NET Remoting with eventing**: When a client uses .NET Remoting with eventing, the DataMiner Agent will send server-initiated notifications to the client. When a client application such as DataMiner Cube connects to a DataMiner Agent, it will open a random port on the client to which the DMA will send its notifications.

- **.NET Remoting without eventing**: When a client uses .NET Remoting without eventing, the DataMiner Agent will not send server-initiated notifications to the client. Instead, the client application will continuously poll the DataMiner Agent for notifications.

> [!NOTE]
> When a fallback from polling to eventing occurs, an information event is generated that contains the IP address and port that the events are sent to. Clients can use this information to detect why they cannot receive events via the callback method. When a client connects, the log files and diagnostic info also contain the external client IP address as seen from the DataMiner Agent.

### Manual configuration of client communication settings

To customize how Cube connects to a DMA for a specific computer:

1. In the Cube header bar, click the user icon or the username (in versions prior to DataMiner 10.0.0/10.0.2), and select *Settings*.

1. Go to the *computer* tab of the *Settings* window.

1. On the *Connection* page, next to *Connection type*, select one of the following options:

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

> [!NOTE]
>
> - You can also configure this in the DataMiner Cube logon screen, before you actually log on. See [Overriding the default connection type](xref:Logging_on_to_DataMiner_Cube#overriding-the-default-connection-type).
> - The procedure above only applies to the one computer where it is done. If you want to change the default client communication settings for a DMA, you can do so in the file *ConnectionSettings.txt*. See [ConnectionSettings.txt](xref:ConnectionSettings_txt#connectionsettingstxt).

## Managing client versions

From DataMiner 10.2.0 \[CU3]/10.2.6 onwards, Cube can automatically update to a more recent version than the DataMiner version installed on the server. This way, users can use the latest Cube features as soon as these are released without having to wait for a server upgrade. However, in the Cube system settings, you can configure limitations on which client version should be used:

1. In DataMiner Cube, go to System Center > *System settings* > *Manage client versions*.

1. Select which client versions should be used:

   - **Allow automatic updates**: This will allow automatic updates to higher versions of Cube, depending on the [configuration in the Cube start window](xref:Managing_the_start_window#selecting-your-cube-update-track).

     > [!NOTE]
     > When a new DMA is added to a cluster, that DMA will by default use this setting. If you use a different setting, keep in mind that you will still need to adjust this for this DMA.

   - **Force the matching release version**: This will force users to always use the Cube version that was shipped with the current DataMiner upgrade package.

   - **Force a specific version**: This will force users to always use a particular Cube version. When you select this option, a dialog will be displayed where you will need to select a *Cube.zip* and *versions.txt* file. You can obtain these files from the folder `/Webpages/DataMinerCubeStandAlone/` in an upgrade package or on another DataMiner Agent (e.g. a staging platform).

     > [!TIP]
     > Use this option if you are using a hotfix package with a Cube fix. Otherwise, users connecting to the DMA may use a more recent Cube version, obtained through dataminer.services, that does not yet contain the fix.

> [!NOTE]
>
> - To access this configuration, you need the user permissions [Modules > Documents > Add](xref:DataMiner_user_permissions#modules--documents--add), [Modules > System settings > System settings available](xref:DataMiner_user_permissions#modules--system-configuration--system-settings--system-settings-available), and [Modules > System settings > Manage client versions](xref:DataMiner_user_permissions#modules--system-configuration--system-settings--manage-client-versions).
> - By default, this is configured for the entire DMS. If you select the checkbox *Allow individual agent configuration*, you can configure different client version settings per DMA instead. However, this is not recommended as users will end up using a different version of Cube depending on which DMA they connect to.
