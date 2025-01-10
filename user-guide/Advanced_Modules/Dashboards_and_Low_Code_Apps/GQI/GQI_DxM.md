---
uid: GQI_DxM
---

# GQI DxM

The GQI DxM is a [DataMiner Extension Module (DxM)](xref:DataMinerExtensionModules) that hosts the GQI core engine, enabling efficient data retrieval through [GQI queries](xref:About_GQI).

Running GQI as an extension module benefits from several key improvements:

* Independent updates: GQI can be updated independently from the main DataMiner core software, eliminating the need for a core software restart during updates.
* Load balancing: GQI operations can now distribute system load more effectively across multiple DataMiner Agents within a DataMiner System (DMS).
* Resource visibility: enhanced monitoring capabilities provide greater insight into the resource consumption of individual extensions.
* Improved dependency resolving: simplifies and optimizes the resolution of DLL dependencies, avoiding conflicts.
* Performance enhancements: leverages the latest advancements in .NET 8 for improved speed and efficiency, uses proto-first communication, no SLNet throttling, etc.

## Installation

The GQI DxM gets installed automatically when installing or upgrading to DataMiner version 10.5.2/10.5.0.<!-- RN 41811 -->

> [!IMPORTANT]
> By default, DataMiner web applications will continue using the SLHelper process for GQI-related operations. To switch to the new GQI DxM, see the instructions below.

> [!NOTE]
> The [Data Aggregator](xref:Data_Aggregator_DxM) currently relies on the SLHelper process to execute GQI queries. Support for the GQI DxM will be introduced in a future version of the Data Aggregator.

## Soft launch

To enable the DataMiner web apps to use the GQI DxM, add the following configuration key to the *C:\\Skyline DataMiner\\Webpages\\API\\Web.config* file:

```xml
<appSettings>
    <add key="gqi:useDxM" value="true" />
</appSettings>
```

The WebAPI process will automatically restart upon saving the file. Once this setting is applied, web applications accessed through the configured server will utilize the GQI DxM. For web applications accessed via other servers, the SLHelper process will continue to be used unless the same configuration is applied to those servers.

## Architecture

The GQI DxM comprises multiple processes that work together to handle GQI requests and execute core functionalities efficiently. The architecture ensures modularity, scalability, and efficient communication between the different components.

### Parent process (DataMiner GQI.exe - Windows Service)

The parent process serves as the main entry point for all GQI operations, managing the core functionality like query sessions, the build-in data sources and operators, and execution of the query requests. When a query utilizes GQI extensions (ad-hoc data sources or custom operators), the parent process spawns one or more child processes to handle these extensions.

* Technology: .NET 8.
* Communication: Connects to the DataMiner Agent (DMA) via gRPC (APIGateway).

### Child processes (DataMiner GQI.ExtensionsWorker.Automation.exe)

Each extension (per library) runs within its own child process, ensuring isolation and modularity. In Task Manager, you can determine the specific extension a child process is executing by checking the command line arguments.

* Technology: .NET Framework 4.

### Communication process (DataMiner GQI.ExtensionsWorker.SLNet.exe)

Facilitates communication between GQI extensions and the DataMiner Agent (DMA) through SLNet. All extensions for a given user utilize the same SLNet connection, optimizing resource usage.

* Technology: .NET Framework 4.
* Communication: Connects to the DataMiner Agent (DMA) via IPC (SLNet).

## Configuration

Below you can find an overview of the different settings you can configure in the file *C:\\Program Files\\Skyline Communications\\DataMiner GQI\\appsettings.custom.json*. Do not edit *appsettings.json* since this file gets overwritten when installing a new version.

### Logging

See [GQI logging](xref:GQI_Logging) and [GQI extensions logging](xref:GQI_Extensions_Logging).

### Termination of idle child processes

In the *appsettings.custom.json* file, you can specify when idle child processes should be terminated.

See the following example. Idle child processes will be terminated within the configured *WorkerExpiration* (in this case 1 day) + 30 seconds.

```json
{
  "GQIOptions": {
    "Extensions": {
      "WorkerExpiration": "1.00:00:00",
    }
  }
}
```
