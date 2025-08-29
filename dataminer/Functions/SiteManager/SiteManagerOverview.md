---
uid: SiteManagerOverview
---

# Overview

## Prerequisites

The Site Manager DxM extension module requires DataMiner 10.5.10.

The Site Manager DxM is shipped with the DaaS image of DataMiner 10.5.10. In case you are running an older DaaS version, an upgrade is required and the Site Manager DxM will need to be installed. For more information on how to upgrade DataMiner and install a DxM, refer to [Upgrading a DataMiner Agent](xef:Upgrading_a_DataMiner_Agent).

## Supported connection types and limitations

SiteManager allows setting up communication tunnels for the following element connection types:

- SNMP
- HTTP
- WebSocket
- Serial
- Smart serial

Limitations:

- SNMP traps are currently not supported
- Elements which act as a server (e.g. a serial or smart serial server) are currently not supported
- The *test connection* button in Cube is not supported for testing connections to data sources on a remote site

## Architecture

The Site Manager DxM makes use of [zrok](https://zrok.io/), a secure, open-source platform that allows privately sharing data source. zrok is built on top of [OpenZiti](https://openziti.io/), an open source zero-trust networking platform by [NetFoundry](https://netfoundry.io/).

![Overview](~/dataminer/images/SiteManagerOverview.png)<br>*Tunneling overview*
