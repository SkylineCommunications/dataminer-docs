---
uid: Smart_Serial_Connection
---

# Smart-serial connections

For smart-serial connections, you can specify the following connection settings while creating or editing an element:

- **IP address/host**: The polling IP or URL of the destination.

  - In a Failover setup, instead of specifying the local IP address, use 127.0.0.1.

  - If you specify “any” as the host address, DataMiner listens on all IP addresses on the specified port.

  > [!NOTE]
  > [Dynamic polling](#dynamic-polling) (available from DataMiner 10.3.11/10.4.0 onwards<!--RN 37404-->) is only supported when the smart-serial connection acts as a client. Assigning an IP addresses like "127.0.0.1" or "any" makes the element acts as a server, and it cannot switch to a client mode without stopping it. Also, trying to assign a value like "127.0.0.1" to the dynamic IP parameter at runtime will cause an error.

- **IP port**: The IP port of the destination. This is not always required.

- **Accepted IP address**: Available if a smart-serial server port of type TCP is used. Allows you to specify one or more allowed IP addresses for the connection. The element will then only communicate with those IP addresses. This configuration makes it possible for several elements to listen on the same port but communicate exclusively with a different set of IPs.

  To add another accepted IP address, below the box, click *Add*.

  > [!NOTE]
  > This functionality is only available if *AllowedIPAddresses.Disabled* is set to “false” in the user settings of the smart-serial connection in the protocol.

- **Bus address**: The bus address of the device. This is not always required.

- **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

## Dynamic polling

From DataMiner 10.3.11/10.4.0 onwards<!--RN 37404-->, the smart-serial connection supports dynamic polling, allowing you to change the IP address and IP port while the element remains active.
s
To enable dynamic polling for a smart-serial connection, add the following parameter:

`<Type options="dynamic ip">read</Type>`

> [!IMPORTANT]
>
> - Dynamic polling is only supported when the smart-serial connection acts as a client, not as a server.
> - We highly recommend configuring the connection type as *smart-serial single*. This ensures that each connection is assigned a dedicated socket in SLPort. If multiple smart-serial elements hosted on the same DMA share the same IP address and port through the element wizard, they will all use the new IP address if one of them changes the IP address dynamically.
