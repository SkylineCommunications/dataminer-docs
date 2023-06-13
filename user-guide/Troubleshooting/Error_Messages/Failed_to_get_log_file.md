---
uid: Failed_to_get_log_file
---

# Failed to get log file

If Cube isn't able to load its log files, it will show an error code like this:

```txt
Failed to get log file (<HTTP Error Code> - <ErrorMessage>)
```

This can happen due to various reasons, we'll discuss some potential root causes in the next sections.


## 401 - Unauthorized
```txt
Failed to get log file (401 - Unauthorized)
```

### Possible Cause 1
Some DLLs and/or services might not have the correct rights.

### Resolution
On the server, go to C:/Skyline Dataminer/Tools and run dcomConfig.exe as administrator

### Possible Cause 2
When HTTPS got configured recently and you get this error, something might be misconfigured.
If this is the root cause, you might also get an additional popup mentioning "Your connection is not private", giving you the option to proceed or to not enter the site. However this is dependent on the type of certificate used.

### Resolution
Double-check your HTTPS configuration. The https tag within MaintenanceSettings.xml was most likely forgotten.

> [!TIP]
> See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA) and [BPA: HTTPS Configuration](xref:BPA_Https_Configuration)

## 403 - Forbidden
```txt
Failed to get log file (403 - Forbidden)
```
### Possible Cause
Most often, this is caused because a proxy server is configured.
How to know if a proxy server is configured? Open command prompt on the server and execute command:
```txt
netsh winhttp show proxy
```

### Resolution
We recommend to add all IPs and hostnames of the DMAs to the proxy exception list.
This can be done by opening command prompt on the server and executing:

```txt
netsh winhttp set proxy proxy-server=”<proxy-server IP>” bypass list=”<IPs/hostnames to be excluded>”
```

## 500 - Internal Server Error
```txt
Failed to get log file (500 - Internal Server Error)
```

### Possible Cause
This could indicate an issue with the permissions on either C:/Skyline Dataminer or C:/Skyline Dataminer/Logging.


### Resolution
Go to C:/Skyline Dataminer/Tools and run ConfigureIIS.bat as administrator.
If that doesn't work, verify that permissions are granted to groups Users and/or Authenticated Users, this on both C:/Skyline Dataminer and C:/Skyline Dataminer/Logging.


## General Troubleshooting
If the above didn't help, then following might. It could also help us if you decide to ask us for help.

- Test if you can retrieve the log file via the ViewLog Tools:
  ```txt
  http://<DMA IP>/tools/ViewLog.asp?log=SLDataMiner&host=<DMA IP>
  ```
  This will retrieve the raw log file. 
- Have a look at C:\inetpub\logs\LogFiles\W3SVC1

If you're still stuck, you might find a similar case on our Dojo Community, you can also post your use case as well.
