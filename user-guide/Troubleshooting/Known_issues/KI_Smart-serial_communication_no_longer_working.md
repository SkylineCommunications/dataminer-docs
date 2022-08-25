---
uid: KI_Smart-serial_communication_no_longer_working
---

# Smart-serial communication no longer working

## Affected versions

- DataMiner 10.1.0 and older
- DataMiner 10.0.13 and older

## Cause

Windows 2019 upgrade/installation

## Fix

SLPort automatically resizes the socket buffer before receiving data from a socket [[ID_27891](xref:General_Main_Release_10.1.0_enhancements#slport-now-automatically-resizes-the-socket-buffer-before-receiving-data-from-a-socket-id_27891)]

## Issue description

On a Windows 2019 server, the TCP socket buffer increased from the default 64 kB to 128 kB. However, SLPort expected an incoming size of at most 64 kB. If it received larger data sizes, the packet was not processed and no error was logged.

This means that on a DMA running on Windows 2019 Server, SLPort did not process large packets of TCP data or small amounts of TCP data that were sent at a high rate. The (smart-)serial element listening to the TCP stream would never get the data. Even though you could see the data in Wireshark, the firewall was OK, and the header/trailer seemed fine, no data could be seen in the Stream Viewer for the element and there was no error logged (unless PortLog was activated for that specific socket).

For more information, see the question [Not receiving smart-serial data in driver](https://community.dataminer.services/question/not-receiving-smart-serial-data-in-driver/) on DataMiner Dojo.
