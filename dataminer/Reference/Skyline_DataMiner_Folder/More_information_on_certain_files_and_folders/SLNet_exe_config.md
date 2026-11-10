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

- .NET runtime settings for the SLNet process, configured in the *runtime* section. See [Runtime settings](#runtime-settings).

> [!NOTE]
> Any changes to the settings in this file will only take effect after a full DMA restart.

## Runtime settings

The *runtime* section contains .NET runtime settings for the SLNet process, such as the garbage collection settings below. These settings can improve SLNet performance on some servers, but the optimal configuration depends on the hardware and workload, so evaluate the effect of any change on the system.

> [!NOTE]
> From DataMiner 10.8.0/10.7.1 onwards<!-- RN 46905 -->, DataMiner upgrades keep the existing *gcServer* and *GCHeapCount* settings in *SLNet.exe.config*. All other settings in the *runtime* section are replaced by those of the upgrade package, so any other changes you make in this section will be lost after an upgrade.

### gcServer

The *gcServer* element determines whether SLNet uses server or workstation garbage collection. Garbage collection itself is always active; this setting only selects the mode. The *enabled* attribute defaults to *false*, which selects workstation garbage collection.

Server garbage collection uses one heap and one dedicated garbage collection thread for each processor available to the process. This can improve performance on multiprocessor systems, but can also use more memory and CPU.

To enable server garbage collection, set the *enabled* attribute to *true*:

```xml
<runtime>
    ...
    <gcServer enabled="true" />
    ...
</runtime>
```

For more information, refer to [gcServer element](https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/gcserver-element).

### GCHeapCount

The *GCHeapCount* element limits the number of heaps and garbage collection threads used by server garbage collection. It only applies when *gcServer* is enabled. The actual number of heaps is the lower of the configured value and the number of processors the process is allowed to use.

Despite its name, the *enabled* attribute of this element takes the number of heaps. For example, to enable server garbage collection and use at most eight heaps:

```xml
<runtime>
    ...
    <gcServer enabled="true" />
    <GCHeapCount enabled="8" />
    ...
</runtime>
```

For more information, refer to [GCHeapCount element](https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/gcheapcount-element).
