---
uid: SLNet_exe_config
---

# SLNet.exe.config

The file *SLNet.exe.config* is used for the configuration of settings related to the SLNet process.

This file is located in the following folder: *C:\\Skyline DataMiner\\Files*

It contains among others the following settings:

- DMA communication settings. See [Configuring DMA communication settings in SLNet.exe.config](xref:Configuration_of_DataMiner_processes#configuring-the-ports-for-net-remoting-andor-xml-web-services).

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

> [!NOTE]
> Any changes to these settings only take effect after a full DMA restart.
>
