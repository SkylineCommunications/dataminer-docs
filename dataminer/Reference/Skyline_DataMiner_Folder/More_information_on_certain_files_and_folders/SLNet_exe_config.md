---
uid: SLNet_exe_config
---

# SLNet.exe.config

The file *SLNet.exe.config* is used for the configuration of settings related to the SLNet process.

This file is located in the following folder: `C:\Skyline DataMiner\Files`

It contains among others the following settings:

- DMA communication settings. See [Configuring DMA communication settings in SLNet.exe.config](xref:Configuration_of_DataMiner_processes#configuring-the-port-for-net-remoting).

- The number of log files generated for the SLNet process, determined by the value for the *LogFileRotateAmount* key in the *appSettings* section. For example:

    ```xml
    <appSettings>
     ...
     <add key="LogFileRotateAmount" value="3" />
     ...
    </appSettings>
    ```

- The file size (in MB) of the log files generated for the SLNet process, determined by the value for the *LogFileSize* key in the *appSettings* section. For example:

    ```xml
    <appSettings>
     ...
     <add key="LogFileSize" value="3" />
     ...
    </appSettings>
    ```

- The minimum number of threads the .NET threadpool creates on demand (supported from DataMiner 10.6.4/10.7.0 onwards<!-- RN 44843 -->). Increasing these values can improve performance on systems that experience a high burst of incoming request messages. The correct setting is system‑dependent; using values that are too low or too high can negatively impact overall performance. This is configured via the *ThreadPoolMinWorkerThreads* and *ThreadPoolMinIOThreads* keys in the *appSettings* section. For more information, refer to [ThreadPool.SetMinThreads](https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadpool.setminthreads?view=netframework-4.7.1#remarks).

  For example:

  ```xml
  <appSettings>
      ...
      <add key="ThreadPoolMinWorkerThreads" value="32" />
      <add key="ThreadPoolMinIOThreads" value="32" />
      ...
  </appSettings>
  ```

> [!NOTE]
> Any changes to these settings will only take effect after a full DMA restart.
