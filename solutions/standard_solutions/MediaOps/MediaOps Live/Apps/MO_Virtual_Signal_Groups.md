---
uid: MO_Virtual_Signal_Groups
---

# Virtual Signal Groups app

The Virtual Signal Groups app can be used by engineers to create and manage sources and destinations from any device and/or transport technology in large-scale networks. It allows you to create source and destination endpoints for every individual signal using any transport technology in your network. These endpoints can be grouped in source and destination virtual signal groups organized by level, which allows you to connect multiple endpoints with a single command. Virtual signal groups can be grouped into categories which allows operators to more easily navigate their control surfaces to find the relevant sources and destinations for their workflows.

## App overview

The following pages are available in the app:

- **Endpoints**: Allows you to **create**, **edit**, **delete**, **import**, and **export** [endpoints](#endpoints).

- **Virtual Signal Groups**: Allows you to **create**, **edit**, **delete**, **import**, and **export** [virtual signal groups](#virtual-signal-groups). Additionally, this page also allows you to manage the [categories](#categories) that virtual signal groups can be assigned to, and also allows you to assign the virtual signal groups to these categories.

- **Levels**: Allows you to **create**, **edit**, and **delete** [levels](#levels). Additionally, this page also allows to manage the [transport types](#transport-types) available in your network, and allows to configure the transport type for each given level.

## Endpoints

Endpoints are the lowest level data object managed by the Virtual Signal Groups app, as these objects allow users to describe source and destinations of a single (media) flow. Each endpoint should have a name, must be assigned a transport type and can optionally be linked to a DataMiner element.

Apart from the common fields that are required for every sender or receiver, additional fields can also be used to store the transport parameters needed to set up a connection between endpoints of a specific transport type. These fields depend on the selected transport type and can include things like a source and multicast IP address for IP transport, or caller/listener mode for SRT senders or receivers.

> [!IMPORTANT]
> Before you can start creating endpoints, [transport type(s)](#transport-types) need to be created first.

### Transport Types

Transport types define the different transport technologies that will be supported in the system, for example SDI, IP 2110, TSoIP, SRT, etc. When creating a transport type, additional metadata fields can be configured allowing users to enter the values when creating an endpoint of this transport type. For example, when creating an IP transport type, following fields could be added to the transport type: Source IP, Multicast IP, Multicast Port. For every endpoint created of transport type ‘IP’, the system will allow to store a source IP, multicast IP and multicast port, so that this information can be used to set up connections with this endpoint.

> [!NOTE]
> The app currently only supports defining free text fields on a transport type.

## Virtual Signal Groups

Once individual endpoints have been described, users can group them together into a source or a destination virtual signal group. These sources and destinations will be displayed on the [Control Surface app](xref:MO_Control_Surface) and allow to set up connections between them. Additionally, these virtual signal groups and can also be linked to the in- or output of a resource in the [Resource Studio app](xref:MO_Resource_Studio) in order to schedule connections as part of a [Job](xref:MO_Scheduling).

After having created a virtual signal group, users can start adding endpoints to it. Endpoints are added to a virtual signal group on a specific [level](#levels). This allows the system to know which endpoints from the source to connect to which endpoints from the destination, by mapping each destination endpoint with the endpoint at the corresponding level on the source.

> [!NOTE]
> An endpoint can be part of multiple virtual signal groups.  

### Levels

Levels define a logical structure for the virtual signal groups on the system. Each level is assigned a unique level number, a name and a specific [transport type](#transport-types). The transport type specified on a level will be used to only allow adding endpoints of that type on this level in a virtual signal group.

Levels defined in the Virtual Signal Groups app are defined system-wide, meaning that the level structure of all virtual signal groups is the same. However, each individual signal group can contain an endpoint on a level or not.

### Categories

The Virtual Signal Groups app allows to group virtual signal groups into categories. This grouping can be used to more easily find sources and destinations on the [Control Surface app](xref:MO_Control_Surface). When installing the Virtual Signal Groups app, two scopes will automatically be created, one for sources and one for destinations. This allows users to immediately start defining their source and destination categories in the [Categories app](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e).

After defining a category structure, sources and destination can then be assigned to one or more categories within the Virtual Signal Groups app. After assigning a virtual signal group to a category, that category will be displayed as a filter option on the [Control Surface app](xref:MO_Control_Surface).

> [!NOTE]
> Categories are managed in the [Categories app](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) which needs to be installed separately on the system (prior to deploying MediaOps Live).

## Managing endpoints and virtual signal groups at scale

The Virtual Signal Groups app is primarily used as an engineering tool to manage and inspect individual endpoints and virtual signal groups. Bulk editing can be done by either [exporting and/or importing endpoints and/or virtual signal groups](#exporting-and-importing-endpoints-andor-virtual-signal-groups) or by [using the API](#using-the-api) in an automation script to CRUD endpoints and virtual signal groups.

> [!TIP]
> Follow along with the [Generic Matrix Provisioning tutorial](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Manual) to learn how to manually provision endpoints and virtual signal groups.

### Exporting and importing endpoints and/or virtual signal groups

The Virtual Signal Groups app allows to export and import endpoints and virtual signal groups using CSV files, allowing to creating and editing these objects in bulk.

> [!TIP]
> Follow along with the [Generic Matrix Provisioning tutorial](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Import) to learn how to provision endpoints and virtual signal groups using CSV import.

### Using the API

MediaOps Live also exposes an API which allows you (amongst other things) to provision endpoints and virtual signal groups through code.

> [!TIP]
> Follow along with the [Generic Matrix Provisioning tutorial](xref:Tutorial_MediaOpsLive_Tutorial_GenericMatrix_ProvisionEndpointsAndVirtualSignalGroups_Code) to learn how to provision endpoints and virtual signal groups using code.
