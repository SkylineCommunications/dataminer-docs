---
uid: GQI_DxM
---

# GQI DxM

The GQI DxM is a [DataMiner Extension Module (DxM)](xref:DataMinerExtensionModules) that hosts the GQI core engine, enabling efficient data retrieval through [GQI queries](xref:About_GQI).

Running GQI as an extension module has several advantages:

- **Independent updates**: Using a [web-only upgrade package](xref:Upgrading_Downgrading_Webapps), GQI can be updated independently from the main DataMiner core software, eliminating the need for a core software restart during updates.
- **Load balancing**: With the DxM, GQI operations can distribute system load more effectively across multiple DataMiner Agents within a DataMiner System (DMS).
- **Resource visibility**: Running each extension in a separate process provides greater insight into its resource consumption, allowing you to monitor every extension individually.
- **Improved dependency resolving**: Using the DxM simplifies and optimizes the resolution of DLL dependencies, preventing conflicts.
- **Performance enhancements**: The GQI DxM leverages the latest advancements in .NET 8 for improved speed and efficiency, uses proto-first communication, prevents SLNet throttling, etc.

## Installation

The GQI DxM is supported from DataMiner 10.5.0 [CU1]/10.5.4 onwards, and automatically gets installed and updated by upgrade packages from that version onwards. It also gets updated when you install a web-only upgrade package.<!-- RN 41811 --> Earlier DataMiner versions starting from 10.5.0/10.5.2 also include a preview version of the GQI DxM, but this should only be used on staging systems.

> [!IMPORTANT]
> By default, DataMiner web applications will continue to use the SLHelper process for GQI-related operations. To switch to using the GQI DxM, see [Enabling the use of the GQI DxM](#enabling-the-use-of-the-gqi-dxm).

> [!NOTE]
> [Data Aggregator](xref:Data_Aggregator_DxM) currently relies on the SLHelper process to execute GQI queries. Support for the GQI DxM will be introduced in a future version of Data Aggregator.

## Enabling the use of the GQI DxM

To enable the use of the GQI DxM in the DataMiner web apps, add the following configuration key to the *C:\\Skyline DataMiner\\Webpages\\API\\Web.config* file:

```xml
<appSettings>
    <add key="gqi:useDxM" value="true" />
</appSettings>
```

The WebAPI process will automatically restart when you save the file. Once this setting is applied, web applications accessed through the configured server will utilize the GQI DxM. For web applications accessed via other servers, the SLHelper process will continue to be used unless the same configuration is applied to those servers.

From DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!--RN 42003-->, to verify that the GQI DxM is enabled for a web app, open the user menu in the top-right corner and select *About*. If the version of the GQI DxM is displayed next to *GQI*, the web app is using the GQI DxM. If `No DxM` is displayed, the web app is still using the SLHelper process.

![No DxM](~/user-guide/images/NoDxM.png)<br>*About DataMiner pop-up window in DataMiner 10.5.3*

> [!NOTE]
> If you encounter issues when trying to enable the GQI DxM, refer to [GQI DxM repair](xref:Investigating_Web_Issues#gqi-dxm-repair)

## Architecture

The GQI DxM comprises multiple processes that work together to handle GQI requests and execute these efficiently. This architecture ensures modularity, scalability, and efficient communication between the different components.

- **Parent process** (DataMiner GQI.exe - Windows Service)

  The parent process serves as the main entry point for all GQI operations, managing the core functionality, such as query sessions, the built-in data sources and operators, and execution of the query requests. When a query utilizes GQI extensions (ad hoc data sources or custom operators), the parent process spawns one or more child processes to handle these extensions.

  - Technology: .NET 8.
  - Communication: Connects to the DataMiner Agent via gRPC (APIGateway).

- **Child processes** (DataMiner GQI.ExtensionsWorker.Automation.exe)

  Each extension (per library) runs within its own child process, ensuring isolation and modularity. In Task Manager, you can determine the specific extension a child process is executing by checking the command line arguments.

  - Technology: .NET Framework 4.

- **Communication process** (DataMiner GQI.ExtensionsWorker.SLNet.exe)

  The communication process facilitates communication between GQI extensions and the DataMiner Agent through SLNet. All extensions for a given user utilize the same SLNet connection, optimizing resource usage.

  - Technology: .NET Framework 4.
  - Communication: Connects to the DataMiner Agent via IPC (SLNet).

## Configuration

Below you can find an overview of the different settings you can configure in the file *C:\\Program Files\\Skyline Communications\\DataMiner GQI\\appsettings.custom.json*.

Do not edit the file *appsettings.json*, because that file gets overwritten when a new version of the GQI DxM is installed.

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
