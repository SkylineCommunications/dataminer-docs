---
uid: Installing_an_Edge_Node_on_Linux
description: Install, configure, and start a DataMiner Edge Node on a Debian-based Linux machine.
---

# Installing an Edge Node on Linux

> [!IMPORTANT]
> At present, this feature is only available in preview, if the [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Before you continue, make sure the [general prerequisites](xref:Installing_an_Edge_Node) are met.

## Prerequisites

The Linux machine must meet the following requirements:

- An x86-64 architecture.

- A Debian-based Linux distribution.

- glibc 2.17 or higher.

  > [!TIP]
  > To check the installed glibc version, run `ldd --version`.

## Installing the Edge Node

1. Obtain the [Linux DEB package](https://community.dataminer.services/edge-node-installers/) for the Edge Node.

1. Open a terminal.

1. Install the package: `sudo dpkg -i <package>`.

## Configuring the Edge Node

Once the package has been installed, you will need to configure the Edge Node in the following file: `/etc/skyline-communications/dataminer-edge-node/edgenode.json`.

This file contains the following connection configuration:

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

1. Start the DataMiner Edge Node service: `sudo systemctl start dataminer-edge-node`.

1. Verify that the service is running: `sudo systemctl status dataminer-edge-node`.

   The output should contain the following status: `Active: active (running)`.
