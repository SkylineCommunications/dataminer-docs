---
uid: TCPIP_UDPIP_Connection
---

# TCP/IP and UDP/IP connections

For **TCP/IP** or **UDP/IP** connections, you can specify the following connection settings while creating or editing an element:

- **Site**: The remote site. Set to `<None>` if a direct connection needs to be set up instead of a tunnel. This dropdown is only visible if the Site Manager DxM is installed and remote sites are configured. For more information, refer to [Site Manager](xref:SiteManagerOverview). Note that a serial element acting as a server is not supported on remote sites.

- **IP address/host**: The polling IP or URL of the destination.

- **IP port**: The IP port of the destination. This is not always required.

- **Bus address**: The bus address of the device. This is not always required.

- **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

- **SSL/TLS**: Select this checkbox to enable SSL/TLS encryption (for TCP/IP connections only).

  > [!NOTE]
  >
  > - TLS elements and non-TLS elements sharing the same TCP/IP port is not supported.
  > - To use this feature for smart-serial elements acting as server, the system must be configured to support this encryption. See [Enabling TLS encryption](xref:Enabling_TLS_encryption).
