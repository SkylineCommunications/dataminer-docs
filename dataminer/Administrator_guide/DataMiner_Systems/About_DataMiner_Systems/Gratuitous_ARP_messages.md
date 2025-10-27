---
uid: Gratuitous_ARP_messages
---

# Gratuitous ARP messages

DataMiner broadcasts a gratuitous ARP message after adding virtual IP addresses (belonging to a redundant pair of DMAs or to elements). This way, remote clients will be able to update their ARP cache as soon as they receive that message.

Note that DataMiner did not broadcast this message when legacy Windows versions prior to Windows Vista, Windows Server 2008 or Windows 7 were used, as these versions already broadcast such messages themselves.

## WinPcap

To be able to broadcast gratuitous ARP messages, DataMiner needs WinPcap. As a consequence, WinPcap must be installed on servers hosting the DataMiner software.

> [!NOTE]
> If you install the DataMiner software using the DataMiner installer, the installation of WinPcap is included in the process.

> [!TIP]
> See also:
> <http://www.winpcap.org/>

## Error in case WinPcap is missing

If WinPcap has not been installed on the DMA, everything will work, but no ARP messages will be broadcast. In the SLErrors log file, you will notice an error similar to this example:

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
