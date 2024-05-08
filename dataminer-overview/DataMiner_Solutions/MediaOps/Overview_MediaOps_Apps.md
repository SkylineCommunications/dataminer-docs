---
uid: Overview_MediaOps_Apps
---

# MediaOps apps

dataminer.MediaOps will soon be available in the DataMiner Catalog<!-- TBD: update when available --> as a package containing multiple low-code apps. Using these apps within media operations simplifies the customization of user experiences. For instance, a booking team may opt to view schedule timelines for all tasks, while an MCR team typically prefers a sorted list of tasks, with the earliest upcoming job displayed at the top of the list.

Below is an overview of the out-of-the-box DataMiner applications included in the dataminer.MediaOps installation package.

## Virtual Signal Groups

![Virtual Signal Groups app icon](~/dataminer-overview/images/DM_VirtualSignalGroup.png)

The Virtual Signal Groups app is used to manage the database of all sources and destinations in the media network. It allows you to define video, audio, and data signals using a variety technology, including IP ST-2110, IP ST-2022, SDI, SRT, etc. Each signal is typically described by its location in the network (element and optionally interface), the required transmission information to set up a connection, and a set of user-defined metadata, such as labels.

Individual signals can be bundled into virtual signal groups, which can then be used by operators to route a large number of signals, potentially coming from different devices and with a main and a backup, in one click. The app also allows you to organize sources and destinations into areas and domains so you can find them more easily, for example when you are looking from a control surface.

For more detailed information about this application, see [Virtual Signal Groups application](xref:Overview_MediaOps_Virtual_Signal_Groups).

## Control Surface

![Control Surface app icon](~/dataminer-overview/images/DM_ControlSurface.png)

The MediaOps control surfaces allow users to build their own user interfaces where they can set up connectivity between sources and destinations, configure devices, and view monitoring information coming from the devices. The MediaOps installation package comes with a sample control surface out of the box. It shows the sources and destinations in the system and allows users to do an instant connect or disconnect, or to schedule a connection to happen at a later time.

Users can use this sample app as is, they can take use it as a starting point and further customize it, or they can build their own control surface from scratch.

For more detailed information about this application, see [Control Surface application](xref:Overview_MediaOps_Control_Surface).

## Flow Engineering

![Flow Engineering icon](~/dataminer-overview/images/DM_FlowEngineering.png)

Unlike the other apps listed on this page, Flow Engineering is not an application that end users interact with. It is the engine running in the background to successfully execute requests to set up flows in the network. It is responsible for three things:

- **Flow path calculation**: Flow Engineering first calculates the path between the source and the destination of the requested flow. For this, it runs a Dijkstra algorithm on the elements in DataMiner and the physical connectivity defined between them (stored in DataMiner's DCF database).

- **Flow execution**: When the flow path has been calculated, all elements in the path need to be informed of the request to set up the flow. This is done using a standardized message sent to the elements. The connector is then responsible for making sure that the flow is correctly set up on its underlying product.

- **Flow documentation**: The result of the path calculation is also stored, so it can be used for [monitoring](#flow-monitoring) and other purposes.

For more detailed information about this application, see: [Flow Engineering application](xref:Overview_MediaOps_Flow_Engineering).

## Flow Monitoring

![Flow Monitoring app icon](~/dataminer-overview/images/DM_FlowMonitoring.png)

The goal of the Flow Monitoring app is to provide visibility on the path of all flows going through the media network. The app makes a distinction between as-engineered flow paths and as-is flow paths. For both, the path of a flow over DataMiner elements is shown, from the flow source to its destination, with everything in between. The exact information shown for as-engineered and as-is paths is a different, though.

- **As-engineered paths** represent the expected state of flows in the network, as they have been set up by DataMiner. Whenever DataMiner is instructed to set up a connection between a source and a destination, it documents the result of its path calculation in the as-engineered flow database (see [Flow Engineering](#flow-engineering)). This as-engineered flow path documentation is independent of the connector used by the elements in the path, and therefore works with any element.

- **As-is flow paths** show the flows as reported by the elements in the DataMiner System. These therefore reflect the actual current state of the flows in the network. These can then be compared to the as-engineered paths to see if the actual state of the network corresponds to the desired state. To be able to reconstruct the as-is path, elements in the path need to report the incoming and outgoing flows on the underlying product in a standardized format. This is therefore only supported for elements that are integrated with the MediaOps solution.

For more detailed information about this application, see [Flow Monitoring application](xref:Overview_MediaOps_Flow_Monitoring).

## Scheduling

![Scheduling app icon](~/dataminer-overview/images/MediaOps_ICON_7.png)

The Scheduling application is a comprehensive solution for the scheduling and orchestration of resources and workflows. Using a job, users can easily schedule specific resources, request a resource for a given pool of resources, schedule an entire workflow, or a combination of each of the options. The full life cycle of a job can be managed with tools created for requestors, booking teams, or operational teams.

Among others, the app includes the following features:

- Tracking information about a job, including who is requesting it, when the job starts and ends, and job priorities.
- Guaranteeing that a resource used in a job is available for the scheduled time.
- Easily spotting when a job needs additional input prior to the job's start.
- Generating cost and billing information based on assign contracts and actual usage of the resource.

For more detailed information about this application, see [Scheduling application](xref:Overview_MediaOps_Scheduling).

## Workflow Designer

![Workflow Designer app icon](~/dataminer-overview/images/DM_WorkflowDesigner.png)

The workflow designer is an operator-level DevOps environment to create technical workflows. In the app, users can define what needs to happen when a connection is created between a source and a destination, when a certain job is executed, when a type of service is delivered, etc. This is done by describing workflows. Each workflow consists of a set of nodes and a set of connections between these nodes. These typically describe how a source signal (virtual signal group) is transported to a destination and how it gets processed in between. These workflows can then be executed ad hoc (from a control surface) or based on a schedule (for example by scheduling a job in the [Scheduling app](#scheduling)).

Additionally, a workflow describes:

- How the nodes in the workflow need to be connected by [Flow Engineering](#flow-engineering).
- What automation is run as part of the workflow execution.
- Whether or not resources and capacity are reserved.
- If and how the service needs to be monitored.

For more detailed information about this application, see [Workflow Designer application](xref:Overview_MediaOps_Workflow_Designer).

## Cost and Billing

![Cost and Billing app icon](~/dataminer-overview/images/cost-billing-dm-logo.png)

Cost and Billing is a robust application designed to streamline financial operations within a media environment. It consists of several modules.

Its **Contracts** module offers a comprehensive framework for managing agreements, defining validity periods, and incorporating flexible billing options. Users can apply discounts during billing calculations and navigate intricate details like speed order fees, providing choices between fixed or incremental charges based on the job's booking confirmation. The app's versatility extends to cancellation fees, allowing users to opt for fixed or incremental charges. Billing flexibility is further enhanced by the app's capability to facilitate billing based on workflows, resources, or a combination of both. Additionally, the app enables precise customization through default and specific rate card assignments to workflows, resources, and resource pools.

Within the **Rate Cards** module, the app seamlessly associates with job nodes, such as workflows, resources, and resource pools, offering detailed charging mechanisms based on usage duration. The module also allows users to specify the currency for billing or cost descriptions, ensuring accuracy in financial transactions. The inclusion of rates based on various time units or single usage adds granularity to the billing structure, making the Cost and Billing app a comprehensive financial management tool.

The **Currencies** module efficiently manages multiple currencies. This functionality facilitates seamless currency conversion for precise billing and cost calculations across nodes with different rate cards, ensuring a globally adaptable and efficient financial ecosystem.

For more detailed information about this application, see [Cost and Billing application](xref:Overview_MediaOps_Cost_and_Billing).

## People and Organizations

![People and Organizations app icon](~/dataminer-overview/images/DM_PeopleOrganizations.png)

Upgrade your business operations with our People and Organizations app. This app simplifies personnel management by enabling you to effortlessly create, edit, and track records for individuals and teams. With features like team booking, optimizing personnel allocation for the right job has never been easier. You can also streamline organization management by overseeing categories, contracts, billing contacts, and company affiliation — all from a single intuitive interface.

For more detailed information about this application, see [People and Organizations application](xref:Overview_MediaOps_People_and_Organization).

## Resource Studio

![Resource Studio app icon](~/dataminer-overview/images/DM_ResourceStudio.png)

The Resource Studio app serves as a comprehensive platform for creating, managing, and optimizing resource utilization. Its key features include the ability to create diverse resources, ranging from network inventory to services and other limited-availability items such as rooms, people, vehicles etc. Users can organize these resources into pools, simplifying workflow and job resource selection. Capabilities and capacities can be assigned to resources, facilitating precise resource allocation based on specific job requirements. Users can also store supplementary information as properties, enhancing the resource management process. Utilization metrics provided by the app offer valuable insights, enabling users to optimize resource deployment and maximize operational efficiency.

For more detailed information on this application, see [Resource Studio application](xref:Overview_MediaOps_Resource_Studio).
