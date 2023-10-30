---
uid: PortLog_txt
---

# PortLog.txt

In the *PortLog.txt* file, you can specify IP addresses of DataMiner elements for which log information has to be added to the *SLPort.txt* log file.

- These files are located in the following folders:

    | File      | Location                         |
    |-------------|----------------------------------|
    | PortLog.txt | C:\\Skyline DataMiner\\Files\\   |
    | SLPort.txt  | C:\\Skyline DataMiner\\Logging\\ |

> [!NOTE]
> This is only applicable for (smart) serial connections.
>
> This file is normally not present in the DataMiner system by itself. You need to create the PortLog.txt file yourself and add it to the above location! This is for debugging purposes only. After debugging it is recommended to remove the file to prevent any issues and crashes during normal use of the element.
>
> To have additional logging for HTTP connections, you can enable WinHTTP logging (see <https://docs.microsoft.com/en-us/windows/win32/wsdapi/capturing-winhttp-logs>). However, this requires a restart to enable or disable the logging.

## Portlog.txt syntax

Each line has to contain the following data, separated by colons (”:”)

- IP address of the device

- IP port of the device

- Local DataMiner port (optional)

- The word “true”

Example:

```txt
10.12.200.121:80:5000:true
```

> [!NOTE]
> - Although the local DataMiner port is optional, each line must contain three colons (”:”).
> - Logging is started when the port in question is initialized, i.e. when the element is restarted or when the IP address or the IP port of the element is changed.
>
