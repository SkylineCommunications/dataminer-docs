---
uid: GatewayModeOverview
keywords: Site Manager, Edge Manager, DataMiner Edge
description: Learn how Gateway mode creates secure tunnels between DataMiner and remote data sources without a site-to-site VPN.
---

# About Gateway mode

DataMiner Edge's Gateway mode is available through the SiteManager DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)). It sets up secure tunnels for communication with remote locations. For example, you can use it to communicate with selected on-premises data sources from a DaaS system without configuring a site-to-site VPN.

> [!NOTE]
> Gateway mode sets up communication tunnels. To run connector integrations locally on a managed runtime, use [Edge Nodes](xref:About_Edge_Nodes).

## Prerequisites

Gateway mode requires DataMiner 10.5.10/10.6.0 or higher. See [SiteManager DxM installation](xref:GatewayModeGettingStarted#sitemanager-dxm-installation).

It can only be deployed on DataMiner Agents [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud). On DaaS systems, this prerequisite is automatically met.

## Supported connection types and limitations

Gateway mode can be used to set up communication tunnels for the following element connection types:

- SNMP
- HTTP
- WebSocket
- Serial
- Smart serial
- SSH

The following limitations apply:

- SNMP traps are currently not supported.
- Elements that act as a server (e.g., a smart-serial server) are currently not supported.
- The *Test connection* button in Cube is not supported for testing connections to data sources on a remote site.
- All tunnels route through Europe (Amsterdam). Depending on the location of DataMiner and the data source, latency may vary.

## Architecture

DataMiner Edge's Gateway mode uses [zrok](https://zrok.io/), a secure, open-source platform that allows private sharing of data sources. zrok is built on top of [OpenZiti](https://openziti.io/), an open-source zero-trust networking platform by [NetFoundry](https://netfoundry.io/).

The image below shows two data sources, A and B, that have been exposed and are polled by a DaaS system. Each data source has its own dedicated tunnel. Data source C is not exposed and is therefore not visible externally.

![Overview](~/dataminer/images/EdgeManagerOverview.png)<br>*Tunneling overview*
