---
uid: ConnectionsSmartSerialLogging
---

# Logging incoming data

When a smart-serial client connection receives incoming data, it will forward that data to SLProtocol and display it in Stream Viewer. However, when the incoming data does not match the configured response, the connection will forward TIMEOUT to SLProtocol, making it hard to find out what data was received by SLPort.

If you enable a specific connection in [PortLog.txt](xref:PortLog_txt) and set SLPort debug logging to level 4 or higher, log entries like the one below will be added to SLPort.txt. These entries contain the IP address and port of the server, the size of the incoming data and the data itself.

```txt
2021/05/14 15:30:57.452|SLPort.exe 8.5.1519.6|39680|39544|

CSmartIP::ProcessIncomming|DBG|4|Incoming data from 127.0.0.2:4598 (total length: 5

bytes) - 000000 576F72642E Word.
```
