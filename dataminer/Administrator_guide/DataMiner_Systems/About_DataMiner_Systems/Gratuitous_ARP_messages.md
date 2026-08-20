---
uid: Gratuitous_ARP_messages
description: "Learn more about gratuitous ARP messages sent by DataMiner after virtual IP addresses are added, allowing remote clients to update their ARP cache."
---

# Gratuitous ARP messages

DataMiner broadcasts a gratuitous ARP message after adding virtual IP addresses (belonging to a redundant pair of DMAs or to elements). This way, remote clients will be able to update their ARP cache as soon as they receive that message.

## Npcap or WinPcap

To be able to broadcast gratuitous ARP messages, DataMiner needs Npcap or WinPcap (deprecated). As a consequence, this must be installed on servers hosting the DataMiner software.

> [!TIP]
> See also: [Using the DataMiner Installer](xref:Installing_DM_using_the_DM_installer)

## Error in case Npcap or WinPcap is missing

If Npcap or WinPcap has not been installed on the DMA, everything will work, but no ARP messages will be broadcast. In the SLErrors log file, you will notice an error similar to this example:

```txt
2011/02/17 09:48:15.220|SLDataMiner.txt|SLDataMiner.exe 6.5.1.2|4120|7112| CHardware::AddIPAddress()|ERR|-1|Failed to send out Gratuitous ARP message for added IP address 10.10.51.98. WinPcap is probably not installed on the system. (0xc0000135h; C:\Skyline DataMiner\Tools\SLSendGARP.exe 10.10.51.98  -if "rpcap://\Device\NPF_{4EE7C71A-D4AC-44D0-A812-D5FE1DA66175}")
```

## SLSendGARP.exe

If you have to broadcast a gratuitous ARP message manually towards a given IP address, you can use SLSendGARP.exe, which is located in the `C:\Skyline DataMiner\Tools` directory.

At the command prompt, enter the following command:

```txt
SLSendGARP IpAddress [-if Name]
```

- **IpAddress**: This needs to be a local IP address. A GARP request will be broadcast on the corresponding interface.

- **Name**: By default, SLSendGARP will try to find the matching interface for the given IP address automatically.

    When the IP address is a virtual IP address, an interface name can be manually specified.     Example:

    ```txt
    rpcap://\Device\NPF_{4EE7C71A-D4AC-44D0-A812-D5FE1DA66175}
    ```
