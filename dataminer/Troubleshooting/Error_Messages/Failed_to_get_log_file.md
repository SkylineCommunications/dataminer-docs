---
uid: Failed_to_get_log_file
---

# Failed to get log file

If Cube is unable to load its log files, it will show an error code in the following format:

```txt
Failed to get log file (<HTTP Error Code> - <ErrorMessage>)
```

This can have various causes, depending on the error code and message. You can find more detailed information about this below.

## 401 - Unauthorized

```txt
Failed to get log file (401 - Unauthorized)
```

This error code and message can have the following possible causes:

- **Possible cause**: Some DLLs and/or services do not have the correct rights.

  **Resolution**: On the server, go to `C:\Skyline DataMiner\Tools` and run *dcomConfig.exe* as administrator.

- **Possible cause**: When HTTPS got configured recently and you get this error, something is likely to be misconfigured. If this is the root cause, you may also get a pop-up message mentioning "Your connection is not private", giving you the option to proceed or to not enter the site. This depends on the type of certificate used.

  **Resolution**: Double-check your HTTPS configuration. The most likely cause is that the *HTTPS* tag in *MaintenanceSettings.xml* was not correctly configured.

  > [!TIP]
  > See also:
  >
  > - [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA)
  > - [HTTPS Configuration BPA](xref:BPA_Https_Configuration)

## 403 - Forbidden

```txt
Failed to get log file (403 - Forbidden)
```

This error code and message can have the following possible cause:

- **Possible cause**: This usually occurs when a proxy server is configured. To check if this is indeed the case, open a command prompt on the server and execute the following command:

  ```txt
  netsh winhttp show proxy
  ```

  If the result shows the proxy server used and the bypass list, a proxy server is indeed configured.

  **Resolution**: Add all IPs and hostnames of the DMAs to the proxy exception list. You can do so by opening a command prompt on the server and executing the following command:

  ```txt
  netsh winhttp set proxy proxy-server="<proxy-server IP>" bypass list="<IPs/hostnames to be excluded>"
  ```

## 500 - Internal Server Error

```txt
Failed to get log file (500 - Internal Server Error)
```

This error code and message can have the following possible cause:

- **Possible cause**: This can be caused by an issue with the permissions on either `C:\Skyline DataMiner` or `C:\Skyline DataMiner\Logging`.

  **Resolution**: Go to `C:\Skyline Dataminer\Tools` and run *ConfigureIIS.bat* as administrator. If this does not work, verify that permissions are granted to the groups *Users* and/or *Authenticated Users* on both `C:\Skyline DataMiner` and `C:\Skyline DataMiner\Logging`.

## General troubleshooting

If none of the possible causes above apply, here is how you can gather more information:

- Test if you can retrieve the log file via the ViewLog tool:

  ```txt
  http://<DMA IP>/tools/ViewLog.asp?log=SLDataMiner&host=<DMA IP>
  ```

  This will retrieve the raw log file.

- Check the log files in the folder `C:\inetpub\logs\LogFiles\W3SVC1`.

To troubleshoot further, take a look at the [questions on DataMiner Dojo](https://community.dataminer.services/questions/) and check if someone has already encountered a similar problem. If not, post a question of your own with your specific use case.
