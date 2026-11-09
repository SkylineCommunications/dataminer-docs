---
uid: GQI_DxM
description: "Learn how to configure the DataMiner GQI DxM, including session and CPU limits, logging, message handling, and idle child process termination."
---

# GQI DxM

The GQI DxM is a [DataMiner Extension Module (DxM)](xref:DataMinerExtensionModules) that hosts the GQI core engine, enabling efficient data retrieval through [GQI queries](xref:About_GQI).

Running GQI as an extension module has several advantages:

- **Independent updates**: Using a [web-only upgrade package](xref:Upgrading_Downgrading_Webapps), GQI can be updated independently from the main DataMiner core software, eliminating the need for a core software restart during updates.
- **Load balancing**: With the DxM, GQI operations can distribute system load more effectively across multiple DataMiner Agents within a DataMiner System (DMS).
- **Resource visibility**: Running each extension in a separate process provides greater insight into its resource consumption, allowing you to monitor every extension individually.
- **Improved dependency resolving**: Using the DxM simplifies and optimizes the resolution of DLL dependencies, preventing conflicts.
- **Performance enhancements**: The GQI DxM leverages the latest advancements in .NET 10 for improved speed and efficiency, uses proto-first communication, prevents SLNet throttling, etc.

## Installation

The GQI DxM is supported from DataMiner 10.5.0 [CU1]/10.5.4 onwards, and automatically gets installed and updated by upgrade packages from that version onwards. It also gets updated when you install a web-only upgrade package.<!-- RN 41811 --> Earlier DataMiner versions starting from 10.5.0/10.5.2 also include a preview version of the GQI DxM, but this should only be used on staging systems.

> [!NOTE]
>
> - [Data Aggregator](xref:Data_Aggregator_DxM) supports queries via the GQI DxM from version 3.1.0 onwards. See [Using the GQI DxM for queries](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries).
> - From DataMiner 10.5.0 [CU11]/10.6.2 onwards, it is possible to use the GQI DxM on a Dashboard Gateway server. See [Dashboard Gateway installation](xref:Dashboard_Gateway_installation).<!-- RN 44134 +44344-->

## Enabling or disabling the use of the GQI DxM

Whether DataMiner web apps use the GQI DxM depends on the DataMiner version and configuration:

- **Prior to DataMiner 10.5.0 [CU1]/10.5.4**: GQI queries always run in the [SLHelper process](xref:About_GQI#architecture).

- **From DataMiner 10.5.0 [CU1]/10.5.4 onwards**<!-- RN 41811 -->: You can explicitly enable the GQI DxM by setting `gqi:useDxM` to `true` in the *appSettings* section of `C:\Skyline DataMiner\Webpages\API\Web.config`:

  ```xml
  <appSettings>
      <add key="gqi:useDxM" value="true" />
  </appSettings>
  ```

  The WebAPI process restarts automatically when you save this file. The setting applies to web apps accessed through that server; other servers use their own configuration.

- **From DataMiner 10.5.0 [CU10]/10.6.0/10.6.1 onwards**<!-- RN 44058 -->: The GQI DxM is used by default. You can explicitly disable it by setting `gqi:useDxM` to `false` in the *appSettings* section of `C:\Skyline DataMiner\Webpages\API\Web.config`:

  ```xml
  <appSettings>
      <add key="gqi:useDxM" value="false" />
  </appSettings>
  ```

  The WebAPI process restarts automatically when you save this file. The setting applies to web apps accessed through that server; other servers use their own configuration.

- **From DataMiner 10.7.0/10.7.1 onwards**<!-- RN 46927 -->: GQI via SLHelper has reached [End of Support](xref:Software_support_life_cycles) and is disabled by default. If `gqi:useDxM` is set to `false`, the [GQI in SLHelper upgrade prerequisite](xref:EndOfSupport_SLHelperGQI) blocks the upgrade to this version.<!-- RN 46957 --> Remove the setting so that the GQI DxM is used by default.

## Checking the GQI DxM version

From DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!-- RN 42003 -->, you can check which version of the GQI DxM a web app uses by opening the user menu in the upper-right corner of the app and selecting *About*. The version is displayed next to *GQI*. If `No DxM` is displayed instead, the web app uses GQI via SLHelper.

If `No DxM` is displayed even though the GQI DxM is enabled, see [GQI DxM repair](xref:Investigating_Web_Issues#gqi-dxm-repair).

## Configuration

The GQI DxM can be configured via JSON configuration files. The default configuration can be found in `C:\Program Files\Skyline Communications\DataMiner GQI\appsettings.json`. Do **not** use this file to change settings, because it will be overwritten whenever a new version of the GQI DxM is installed.

To change configuration settings, use the configuration file named `appsettings.custom.json` in `C:\Program Files\Skyline Communications\DataMiner GQI\`. If this file does not exist yet, create it in the mentioned location.

> [!CAUTION]
> Changing the configuration closes all existing query sessions on that GQI instance.

Below you can find an overview of the settings that can be configured in this file.

### Logging

See [GQI logging](xref:GQI_Logging) and [GQI extensions logging](xref:GQI_Extensions_Logging).

### Termination of idle child processes

In the *appsettings.custom.json* file, you can specify when idle child processes should be terminated.

See the following example. Idle child processes will be terminated within the configured *WorkerExpiration* time (in this case 1 day) + 30 seconds.

```json
{
  "GQIOptions": {
    "Extensions": {
      "WorkerExpiration": "1.00:00:00"
    }
  }
}
```

### CPU usage limits

Available starting from DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11.<!-- RN 46509 -->

To prevent GQI from consuming all available CPU resources, you can configure limits for the GQI service and its child processes in the *appsettings.custom.json* file.

```json
{
  "GQIOptions": {
    "CpuLimitPercent": 80,
    "Extensions": {
      "ChildProcessesCpuLimitPercent": 80
    }
  }
}
```

- **CpuLimitPercent**: Maximum percentage of the total CPU capacity that all GQI processes can use, including both the GQI core process and all extension workers. The default is 80%.
- **ChildProcessesCpuLimitPercent**: Maximum percentage of the GQI CPU limit that all [extension workers](xref:GQI_Extensions_Architecture#extension-worker-processes) can use together. The default is 80%, which allows the extension workers to use up to 64% (i.e., 80% of 80%) of the total CPU capacity when the default values are used.

Both settings accept integer values from 1 through 100. After changing either setting, restart the GQI service for the change to take effect.

### Maximum number of concurrent sessions

Available starting from DataMiner Web 10.5.0 [CU21]/10.6.0 [CU9]/10.6.12.<!-- RN 46819 -->

You can configure the maximum number of concurrent sessions per GQI instance with **MaxSessionCount** under `GQIOptions` in the *appsettings.custom.json* file.

```json
{
  "GQIOptions": {
    "MaxSessionCount": 500
  }
}
```

The default is 500. The setting accepts integer values from 1 through 10,000. When the limit is reached, new session requests will be rejected until existing sessions are closed or expire.

Changes apply automatically when you save the configuration file, without restarting the GQI service.

> [!CAUTION]
> Change this setting at your own risk. Allowing too many resource-intensive query sessions can overload the system.

### Message handler configuration

The `MessageHandler` manages requests from clients to the GQI DxM. Requests are placed in a queue, and a specified number of requests can be processed concurrently.

You can configure the following options in the `MessageHandlerOptions` in the *appsettings.custom.json* file:

- **RequestTimeout**: Maximum time a request can take before timing out (default: 15 minutes). This includes the time in the queue.
- **MaxConcurrentRequests**: Maximum number of requests that can be processed at the same time (default: 100). Note that prior to DataMiner 10.5.0 [CU8]/10.5.11<!-- RN 43730 -->, a lower default number of 20 is applied.
- **MaxPendingRequests**: Maximum number of requests allowed in the queue (default: 1000).

Example configuration:

```json
{
  "MessageHandlerOptions": {
    "RequestTimeout": "00:15:00",
    "MaxConcurrentRequests": 100,
    "MaxPendingRequests": 1000
  }
}
```
