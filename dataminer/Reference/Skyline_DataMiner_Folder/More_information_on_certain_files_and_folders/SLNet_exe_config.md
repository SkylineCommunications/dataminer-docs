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

Determines whether SLNet uses server garbage collection. By default, the .NET runtime automatically reclaims memory from objects that are no longer reachable by the application.

With server garbage collection, the .NET runtime uses a separate heap and a dedicated garbage collection thread for each logical processor. This can make garbage collection faster on servers with multiple processors, but it can also use more memory and CPU.

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

Limits the number of heaps and garbage collection threads used by server garbage collection. This setting only has an effect when *gcServer* is enabled. The actual number of heaps cannot exceed the number of processors available to the SLNet process.

For example, to enable server garbage collection and limit it to eight heaps:

```xml
<runtime>
    ...
    <gcServer enabled="true" />
    <GCHeapCount enabled="8" />
    ...
</runtime>
```

For more information, refer to [GCHeapCount element](https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/gcheapcount-element).
