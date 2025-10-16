---
uid: Smart_Serial_Connection
---

# Smart-serial connections

For smart-serial connections, you can specify the following connection settings while creating or editing an element:

- **Site**: The remote site. Set to `<None>` if a direct connection needs to be set up instead of a tunnel. This dropdown is only visible if the Site Manager DxM is installed and remote sites are configured. For more information, refer to [Site Manager](xref:SiteManagerOverview). Note that a smart-serial element acting as a server is not supported on remote sites.

- **IP address/host**: The polling IP or URL of the destination.

  - In a Failover setup, instead of specifying the local IP address, use 127.0.0.1.

  - If you specify “any” as the host address, DataMiner listens on all IP addresses on the specified port.

  > [!NOTE]
  > [Dynamic polling](xref:ConnectionsSmartSerialDynamicPolling) (available from DataMiner 10.3.11/10.4.0 onwards<!--RN 37404-->) is only supported when the smart-serial connection acts as a client. Assigning IP addresses like "127.0.0.1" or "any" makes the element act as a server, and it cannot switch to client mode without stopping first. Also, trying to assign a value like "127.0.0.1" to the dynamic IP parameter at runtime will cause an error.

- **IP port**: The IP port of the destination. This is not always required.

- **Accepted IP address**: Available if a smart-serial server port of type TCP is used. Allows you to specify one or more allowed IP addresses for the connection. The element will then only communicate with those IP addresses. This configuration makes it possible for several elements to listen on the same port but communicate exclusively with a different set of IPs.

  To add another accepted IP address, below the box, click *Add*.

  > [!NOTE]
  > If *AllowedIPAddresses.Disabled* is set to "true" in the user settings of the smart-serial connection in the protocol, this functionality will not be available. See [Specifying the allowed IP address](xref:ConnectionsSmartSerialServer#specifying-the-allowed-ip-addresses).

- **Bus address**: The bus address of the device. This is not always required.

- **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.
