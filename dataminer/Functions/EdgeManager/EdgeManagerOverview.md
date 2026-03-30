---
uid: EdgeManagerOverview
keywords: Site Manager
---

# About Edge Manager

DataMiner Edge Manager is available via the SiteManager DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)). It is used to set up secure communication tunnels for communication with locations where a DataMiner Edge Node has been deployed. You can among others use it for communication with selected on-premises data sources from a DaaS system without the need to configure, for instance, a site-to-site VPN.

## Prerequisites

Edge Manager requires DataMiner 10.5.10/10.6.0 or higher. See [SiteManager DxM installation](xref:EdgeManagerGettingStarted#sitemanager-dxm-installation).

It can only be deployed on DataMiner Agents [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud). On DaaS systems, this prerequisite is automatically met.

## Supported connection types and limitations

Edge Manager can be used to set up communication tunnels for the following element connection types:

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

To communicate with Edge Nodes, the Edge Manager module makes use of [zrok](https://zrok.io/), a secure, open-source platform that allows private sharing of data sources. zrok is built on top of [OpenZiti](https://openziti.io/), an open-source zero-trust networking platform by [NetFoundry](https://netfoundry.io/).

The image below shows two data sources, A and B, that have been exposed and are polled by a DaaS system. Each data source has its own dedicated tunnel. Data source C is not exposed and is therefore not visible externally.

![Overview](~/dataminer/images/EdgeManagerOverview.png)<br>*Tunneling overview*
