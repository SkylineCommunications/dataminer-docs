---
uid: Overriding_Cube_connection_type
---

# Overriding the default connection type

Before you log on to a DataMiner Agent, on the login page, you can override that default connection type for the connection you are about to establish.

Alternatively, if you are already logged on, you can also change the connection settings in Cube. To do so, go to *Settings* > *Computer* > *Connection*.

To change the connection settings on the login page:

1. On the login page, click the cogwheel button in the lower-right corner and select *Options* in the menu.

1. In the *Edit Settings* window, set the *Connection Type* to one of the following values:

   - *Auto*: DataMiner will automatically select the connection settings. From DataMiner 10.5.10/10.6.0 onwards<!-- RN 43331 -->, gRPC will be used by default. Prior to this, the default connection type depends on the configuration in [ConnectionSettings.txt](xref:ConnectionSettings_txt).

   <!-- - *gRPC*: Only available for Skyline users. DataMiner will communicate using HTTPS via the API Gateway, using gRPC GZIP compression. By default, this requires the use of the standard HTTPS port 443. -->

   - *Remoting*: DataMiner will communicate using .NET Remoting.

     - The default port used for Remoting is port 8004.

     - By default, [eventing](xref:Eventing_or_polling) is used, but the client will automatically fall back to polling if the callback port cannot be reached (e.g. if a firewall blocks the requests).

1. If necessary, adjust the settings for the selected connection type:

   - **Destination port**: Select this option to specify a custom destination port number. If you specify “-1”, the port will be detected automatically.

   - **Polling interval**: The frequency at which the client application should poll the DMA, in milliseconds. If you want to use remoting and there are firewalls in your network or NAT is used, make sure this option is selected, to ensure that polling is used instead of eventing. For Web Services, this option is enabled by default.

   - **Use data compression** (Remoting only): Determines whether data are compressed or not. By default, this option is selected, in order to reduce network traffic.

   - **Custom binding IP address** (Remoting only): Only needed in case the server cannot automatically resolve the IP address that it needs to send callback events to the client, which can be the case when a VPN connection is used. The option only applies when eventing has been configured.

1. Click *OK*.

If you are already logged in, changing the connection settings in Cube is similar. For detailed information, see [Manual configuration of client communication settings](xref:DMA_configuration_related_to_client_applications#manual-configuration-of-client-communication-settings).
