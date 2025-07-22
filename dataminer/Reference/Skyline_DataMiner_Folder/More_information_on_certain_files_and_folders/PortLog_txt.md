---
uid: PortLog_txt
---

# PortLog.txt

By default, the *PortLog.txt* file is not present in the DataMiner System. You can create it for debugging purposes and add it in the folder detailed below. After debugging, **remove the file again** to prevent possible issues during normal use of the system.

In the *PortLog.txt* file, you can specify IP addresses of DataMiner elements for which log information has to be added to the *SLPort.txt* log file.

- These files are located in the following folders:

  | File        | Location                         |
  |-------------|----------------------------------|
  | PortLog.txt | `C:\Skyline DataMiner\Files\`    |
  | SLPort.txt  | `C:\Skyline DataMiner\Logging\`  |

> [!NOTE]
> This is only applicable for (smart) serial connections. To have additional logging for HTTP connections, you can enable WinHTTP logging (see <https://docs.microsoft.com/en-us/windows/win32/wsdapi/capturing-winhttp-logs>). However, this requires a restart to enable or disable the logging.

## Portlog.txt syntax

Each line has to contain the following data, separated by colons (":")

- IP address of the device

- IP port of the device

- Local DataMiner port (optional)

- The word "true"

Example:

```txt
10.12.200.121:80:5000:true
```

> [!NOTE]
>
> - Although the local DataMiner port is optional, each line must contain three colons (":").
> - Logging is started when the port in question is initialized, i.e. when the element is restarted or when the IP address or the IP port of the element is changed.
> - The IP addresses provided in the PortLog.txt file must match **exactly** with those provided in the element editor. For example, using `localhost` and `127.0.0.1` in combination with each other will not work.
