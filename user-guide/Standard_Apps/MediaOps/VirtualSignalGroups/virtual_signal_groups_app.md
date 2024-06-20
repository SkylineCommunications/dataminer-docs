---
uid: virtual_signal_groups_app
---

# Virtual Signal Groups app

The Virtual Signal Groups app is used by media engineers to manage sources and destinations from any device and a variety of transport technologies in large scale media networks. The app allows to:

* Create flow senders and flows receivers. This can either be done by filling in the sender or receiver details manually, or by automatically exporting them through a supported connector.
* Bundle multiple flow senders into a source, or multiple flow receivers into a destination. These sources and destinations are referred to generally as 'Virtual Signal Groups'. Creating virtual signal groups ensures that operators can route multiple flows, potentially coming from different devices, in one go.
* Automatically generate senders, receivers, sources and destinations, either through a supported connector (e.g. for NMOS compatible devices) or from a CSV file.
* Define a level structure to be used when adding flow senders or receivers to a virtual signal group.
* Organize virtual signal groups into area's & domains. This allows operators to more easily navigate their control surfaces and find the relevant sources & destinations for their workflows.
* Configure the desired behavior of the system when connecting sources & destinations. This is done by defining virtual signal group types and specifying a workflow to be executed when connecting a source of a certain type to a destination of a certain type.

![screenshot](~/user-guide/images/mediaops_vsg_overview.png)
*The 'vSGroups' page of the app.*

## Flow senders & receivers

The flow level is the lowest level of data that is managed by the Virtual Signal Groups app. The app lets users describe senders and receivers of a single flow. Each sender and receiver should have name, be linked to an element in DataMiner and be assigned to a transport type. Following transport types are currently supported:

* SDI
* IP 2022-6
* IP 2110-20
* IP 2110-30
* IP 2110-40
* IP 2110-21
* IP 2110-31
* IP 2110-41
* SRT
* ASI

Apart from the common fields that are required for every sender or receiver, they can also contain some additional fields to store the required transport parameters needed to set up an atual flow between senders & receiver. These fields are depending on the selected transport type and include things like a multicast IP address for IP transport, or caller/listener mode for SRT senders or receivers.

## Virtual signal groups

Once the individual senders and receivers have been described, users can group multiple of them into a source or a destination respectively. These sources and destinations will then appear on an operator's control surface to allow them to create connections between multiple senders and receivers in one go. A sender or receiver can be part of multiple virtual signal groups.

Virtual signal groups have the follwing metadata on them:

* Administrative state: allows to control wether or not the source or destination gets displayed on the [control surface](xref:control_surface_app). This allows to control when operators should be able to use them for connection.
* Operational state: can be used to indicate to operators whether a source or destination is currently operational or not.
* Button label: allow to provide a short-form name for the virtual singal group to be displayed on a control surface.

Both senders, receivers, sources and destinations can be created manually through forms, or can be automatically generated in one of the below ways:

* From an element: for supported connectors, senders, receivers and optionally sources and destinations with all necessary information can be automatically created for a specific element. A list of supported connectors can be found [here](xref:mediaops_connectors) by looking at the 'Virtual Signal Groups' column.
* From a csv file: users can also supply a csv file witht a list of senders & receivers or sources & destinations to automatically create them. By combining this with the export to csv functions, this can be used for bulk editing of existing instances as well.
* From a DataMiner automation script: developers can also create them from code in an automation script, allowing for automatic creation in many different scenarios and use cases.

## Levels

Levels define a logical structure for the virtual signal groups on a system. Each level is assigned a uniqe level number, has a name and can be of type 'Video', 'Audio', 'Data' or a combination of multiple of these three. Levels are defined in the Virtual Signal Groups app system-wide, meaning that the level structure of all virtual signal groups is the same (of course, each individual singal group can contain something on a level or not).

When adding senders or receivers to a virtual signal group, this always needs to happen on a specific level. This is done so that when a source and destination need to be connected, the system can know which senders from the source to connect to which receivers from the destination by mapping certain source levels to certain destination levels. For redundancy purposes, each level in a virtual signal group can be assigned two senders or receivers: a 'red' one and a blue' one.

## Area's & domains

Media networks can contain huge numbers of sources and destinations, managed by many different people or even teams. To be able to keep the overview, users can organize them into domains, and further organize the domains into area's. Each virtual signal group can be part of multiple domains, and domains can also be part of multiple area's. Area's & domains can then be used to easily find back sources & destinations in other applications such as the control surface, flow monitoring and scheduling.

## Virtual signal group types and workflow mapping

The virtual signal groups app not only allows to describe sources & destinations with their technical specifications, but also what needs to happen when connecting a source and a destination. This is done by defining virtual signal group types, and then assigning every virtual signal group to one of these types.

The connecting behavior can then be defined by listing combinations of a source virtual signal groups type and a destination virtual signal group type, and mapping these to a workflow. For this, dataminer.MediaOps is shipped with a [Workflow Designer](xref:workflow_designer_app), which allows engineers to describe how signals (virtual signal groups) are processed from source to destination using a sequence of resources, called a 'workflow'.

When a connect command is then executed from a [control surface](xref:control_surface_app), the system will look up the type of the selected source and the type of the selected destination in this mapping table, and execute the corresponding workflow. More detailed information on how a workflow gets executed can be found here: [Describing workflow execution behavior](xref:workflow_designer_app#describing-workflow-execution-behavior).
