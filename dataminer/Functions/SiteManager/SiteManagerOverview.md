---
uid: SiteManagerOverview
---

# About Site Manager

The Site Manager module is available as a DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)). It is used to set up secure communication tunnels enabling communication with selected on-premises data sources from a DaaS system without the need to configure e.g., a site-to-site VPN.

## Prerequisites

Site Manager requires DataMiner 10.5.10/10.6.0 or higher. See [SiteManager DxM installation](xref:SiteManagerGettingStarted#sitemanager-dxm-installation).

It can only be deployed on DataMiner Agents [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud). On DaaS systems, which is where Site Manager is primarily intended to be used, this prerequisite is automatically met.

## Supported connection types and limitations

Site Manager can be used to set up communication tunnels for the following element connection types:

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

The Site Manager module makes use of [zrok](https://zrok.io/), a secure, open-source platform that allows private sharing of data sources. zrok is built on top of [OpenZiti](https://openziti.io/), an open-source zero-trust networking platform by [NetFoundry](https://netfoundry.io/).

The image below shows two data sources, A and B, that have been exposed and are polled by a DaaS system. Each data source has its own dedicated tunnel. Data source C is not exposed and is therefore not visible externally.

![Overview](~/dataminer/images/SiteManagerOverview.png)<br>*Tunneling overview*
