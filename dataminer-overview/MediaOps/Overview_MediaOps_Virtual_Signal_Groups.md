---
uid: Overview_MediaOps_Virtual_Signal_Groups
---

# Virtual Signal Groups app

The Virtual Signal Groups app is used by media engineers to manage sources and destinations from any device and a variety of transport technologies in large-scale media networks. The app allows users to:

- **Create flow senders and flows receivers**, either by filling in the sender or receiver details manually, or by automatically exporting them through a supported connector.
- **Bundle multiple flow senders** into a source, **or multiple flow receivers** into a destination. These sources and destinations are referred to generally as "Virtual Signal Groups". Creating virtual signal groups ensures that operators can route multiple flows, potentially coming from different devices, in one go.
- **Automatically generate senders, receivers, sources and destinations**, either through a supported connector (e.g. for NMOS compatible devices) or from a CSV file.
- **Define a level structure** to be used when adding flow senders or receivers to a virtual signal group.
- Organize virtual signal groups into **areas and domains**. This allows operators to more easily navigate their control surfaces and find the relevant sources and destinations for their workflows.
- **Configure the desired behavior** of the system **when connecting sources and destinations**. This is done by defining virtual signal group types and specifying a workflow to be executed when connecting a source of a certain type to a destination of a certain type.

![Virtual Signal Groups app UI](~/dataminer-overview/images/Screenshot_VSG_app.png)<br>
*The "vSGroups" page of the app.*<!-- Is this the actual name of the page? It seems like an odd abbreviation. -->

## Flow senders and receivers

The flow level is the lowest level of data managed by the Virtual Signal Groups app. The app lets users describe senders and receivers of a single flow. Each sender and receiver should have a name, be linked to an element in DataMiner, and be assigned to a transport type.

The following transport types are currently supported:

- SDI
- IP 2022-6
- IP 2110-20
- IP 2110-30
- IP 2110-40
- IP 2110-21
- IP 2110-31
- IP 2110-41
- SRT
- ASI

Apart from the common fields that are required for every sender or receiver, additional fields can also be used to store the transport parameters needed to set up an actual flow between senders and receivers. These fields depend on the selected transport type and include things like a multicast IP address for IP transport, or caller/listener mode for SRT senders or receivers.

## Virtual signal groups

Once the individual senders and receivers have been described, users can group multiple senders or receivers into a source or a destination, respectively. These sources and destinations will be displayed on an operator's control surface to allow them to create connections between multiple senders and receivers in one go. A sender or receiver can be part of multiple virtual signal groups.

Virtual signal groups have the following metadata:

- **Administrative state**: Determines whether the source or destination gets displayed on the [control surface](xref:Overview_MediaOps_Control_Surface). This allows you to control when operators should be able to use them for connections.
- **Operational state**: Can be used to indicate to operators whether a source or destination is currently operational.
- **Button label**: Allows you to provide a short-form name for the virtual signal group, to be displayed on a control surface.

Senders, receivers, sources, and destinations can be created manually through forms, or they can be generated automatically in one of the following ways:

- From an **element**: For supported connectors<!-- TBD: List of supported connectors still needs to be added; we can add a link here as soon as that's done -->, it is possible to automatically create senders, receivers, and optionally sources and destinations for a specific element with all the necessary information.
- From a **CSV file**: Users can also supply a CSV file with a list of senders and receivers or sources and destinations to automatically create them. By combining this with the export to CSV functionality, this can also be used for bulk editing of existing instances.
- From a DataMiner **Automation script**: Developers can also create senders, receivers, sources, and destinations from code in an Automation script, allowing for automatic creation in many different scenarios and use cases.

## Levels

Levels define a logical structure for the virtual signal groups on a system. Each level is assigned a unique level number, has a name, and can be of type "Video", "Audio", "Data" or a combination of these three. Levels defined in the Virtual Signal Groups app are defined system-wide, meaning that the level structure of all virtual signal groups is the same. However, each individual signal group can contain something on a level or not.

When adding senders or receivers to a virtual signal group, this always needs to happen on a specific level. This is done so that when a source and destination need to be connected, the system can know which senders from the source to connect to which receivers from the destination by mapping certain source levels to certain destination levels. For redundancy purposes, each level in a virtual signal group can be assigned two senders or receivers: a "red" one and a blue" one.

## Areas and domains

Media networks can contain huge numbers of sources and destinations, managed by many different people or even teams. To be able to keep an overview, users can organize them into domains, and further organize the domains into areas. Each virtual signal group can be part of multiple domains, and domains can also be part of multiple areas. Areas and domains can then be used to easily find back sources and destinations in other applications such as the [Control Surface](xref:Overview_MediaOps_Control_Surface), [Flow Monitoring](xref:Overview_MediaOps_Flow_Monitoring), or [Scheduling](xref:Overview_MediaOps_Scheduling) app.

## Virtual signal group types and workflow mapping

The virtual signal groups app not only allows to describe sources & destinations with their technical specifications, but also what needs to happen when connecting a source and a destination. This is done by defining virtual signal group types, and then assigning every virtual signal group to one of these types.

The connecting behavior can then be defined by listing combinations of a source virtual signal groups type and a destination virtual signal group type, and mapping these to a workflow. For this, dataminer.MediaOps is shipped with a [Workflow Designer](xref:Overview_MediaOps_Workflow_Designer), which allows engineers to describe how signals (virtual signal groups) are processed from source to destination using a sequence of resources, called a "workflow".

When a connect command is then executed from a [control surface](xref:Overview_MediaOps_Control_Surface), the system will look up the type of the selected source and the type of the selected destination in this mapping table, and execute the corresponding workflow. <!-- More detailed information on how a workflow gets executed can be found here: [Describing workflow execution behavior](xref:). -->
