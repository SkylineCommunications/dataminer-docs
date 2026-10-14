---
uid: Installing_an_Edge_Node_on_Windows
description: Install, configure, and manage a DataMiner Edge Node on a Windows machine.
---

# Installing an Edge Node on Windows

> [!IMPORTANT]
> At present, this feature is only available in preview, if the [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Before you continue, make sure the [general prerequisites](xref:Installing_an_Edge_Node) are met.

## Prerequisites

The Windows machine must meet the following requirements:

- An x86-64 architecture

- .NET

- ASP.NET

- [Microsoft Visual C++ 2015 Redistributable](https://aka.ms/vc14/vc_redist.x64.exe), also known as VC++ 14.0

## Installing the Edge Node

1. Obtain the [Windows MSI installer](https://community.dataminer.services/edge-node-installers/) for the Edge Node.

1. Run the installer as an administrator.

1. Follow the setup wizard:

   - Select how the Edge Node should connect to the DataMiner System.

   - Enter the DataMiner System key or pre-shared key, depending on the selected connection mode.

After the installation has completed, the DataMiner EdgeNode service starts automatically.

## Changing the configuration (optional)

If necessary, you can change the Edge Node configuration after installation.

The configuration is stored in the following file: `C:\Program Files\Skyline Communications\DataMiner EdgeNode\edgenode.json`.

The file contains the following connection configuration:

```json
{
  "EdgeNode": {
    "Key": "<key>",
    "Url": "wss://relay.dataminer.services"
  }
}
```

Configure the properties as follows:

- `Key`: The DataMiner System key or pre-shared key used to register the Edge Node. See [Prerequisites](xref:Installing_an_Edge_Node#prerequisites).

- `Url`: The WebSocket endpoint through which the Edge Node connects to the DataMiner System. The URL must use the `wss://` scheme, for example: `wss://dataminer-agent1.example.local`.

  - For a connection through dataminer.services, leave `Url` set to `wss://relay.dataminer.services`.

  - For a direct connection, replace the value of `Url` with the fully qualified domain name of the DataMiner Agent.

## Starting the Edge Node service

If you have configured the Edge Node through the installation wizard, the DataMiner EdgeNode service will start automatically.

If you have manually changed the configuration, restart the service for the changes to take effect:

1. Open PowerShell as an administrator.

1. If the service is not running, start it: `Start-Service -Name "DataMiner EdgeNode"`.

1. If the service is already running, restart it: `Restart-Service -Name "DataMiner EdgeNode"`.

1. Verify that the service is running: `Get-Service -Name "DataMiner EdgeNode"`.

   The status of the service should be *Running*.

> [!NOTE]
> You can also manage the service through the Windows Services application.
