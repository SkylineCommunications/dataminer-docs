---
uid: MediaOpsGeneral
---

# MediaOps

MediaOps is available on the dataminer.services catalog as a package that contains multiple low-code applications. There are multiple ranges available of the package that can be used for different purposes. The use of low-code applications within media operations simplifies the customization of user experiences. For instance, a booking team may opt for viewing schedule timelines for all tasks, while an MCR team typically prefers a sorted list of tasks, with the earliest upcoming job displayed at the top of the list.

Below is an overview of the out-of-the-box DataMiner applications that come with the dataminer.MediaOps installation package.

## Virtual Signal Groups

![Virtual Signal Groups app icon](~/user-guide/images/mediaops_vsg_dm-logo.png)

The Virtual Signal Groups app is used to manage the database of all sources and destinations in the media network. It allows to define video, audio and data signals using a variety technology, including IP ST-2110, IP ST-2022, SDI, SRT etc. Each signal is typically described by its location in the network (element and optionally interface), the required transmission information to set up a connection and a set of user-defined metadata, like labels.

These individual signals can be bundled into virtual signal groups, which can then be used by operators to route a large number of signals, potentially coming from different devices and with a main and a back-up, in one click. The app also allows to organize sources and destinations into area's & domains to more easily find the one you're looking for from a control surface, for example.

For more detailed information on this application, see: [Virtual Signal Groups application](xref:virtual_signal_groups_app).

## Control Surface

![Control Surface app icon](~/user-guide/images/mediaops_cs_dm-logo.png)

The MediaOps control surfaces allow users to build their own user interfaces where they can set up connectivity between sources & destinations, configure devices and view monitoring information coming from the devices. The MediaOps installation package comes with a sample control surface out-of-the-box. It shows the sources and destinations on the system and allows users to do an instant connect or disconnect, or schedule a connection to happen at a later time.

Users can use this sample app, as-is, they can take it as a starting point and further customize it or they can build their own control surface from scratch.

For more detailed information on this application, see: [Control Surface application](xref:control_surface_app).

## Flow Engineering

![Flow Engineering icon](~/user-guide/images/mediaops_fe_dm-logo.png)

Unlike the other components listed on this page, Flow Engineering is not an application that end-users interact with. It's the engine running in the background to successfully execute requests to set up flows in the network. It's responsible for three things:

* Flow path calculation: Flow Engineering first calculates the path between the source and the destination of the requested flow. For this, it runs a Dijkstra algorithm on the elements in DataMiner and the physical connectivity defined between them (stored in DataMiner's DCF database)
* Flow execution: when the flow path has been calculated, all elements in the path need to be informed of the request to set up the flow. This is done using a standardized message sen to the elements. The connector is then responsible for making sure that the flow is correctly set up on its underlying product.
* Flow documentation: the result of the path calculation is also stored, so it can be used for monitoring (see: Flow Monitoring) and other purposes.

For more detailed information on this application, see: [Flow Engineering](xref:flow_engineering_app).

## Flow Monitoring

![Flow Monitoring app icon](~/user-guide/images/mediaops_fm_dm-logo.png)

The goal of the Flow Monitoring app is to provide visibility on the path of all flows going through the media network. The app distinguishes between as-engineered flow paths and as-is flow paths. They both show the path of a flow over DataMiner elements, from the flow source to its destination and everything in between. The exact information shown for the as-engineered and as-is path is a different though.  

The as-engineered paths represent the expected state of flows in the network, as they have been set up by DataMiner. Whenever DataMiner is instructed to set up a connection between a source and a destination, it documents the result of its path calculation in the as-engineered flow database (for more information, see 'Flow Engineering'). This as-engineered flow path documentation is independent of the connector used by the elements in the path, and therefore works with any element.

The as-is flow path, on the other hand, shows the flows as reported by the elements on the DataMiner system. It therefore reflects the actual current state of the flows in the network. This can then be compared to the as-engineered path if the actual state of the network corresponds to the desired state. To be able to reconstruct the as-is path, elements in the path need to report the incoming and outgoing flows on the underlying product in a standardized format. This is therefore only supported for elements that are integrated with the MediaOps solution.

For more detailed information on this application, see: [Flow Monitoring application](xref:flow_monitoring_app).

## Scheduling

![Scheduling app icon](~/user-guide/images/mediaops_s_dm-logo.png)

The Scheduling application is a one-stop shop for scheduling and orchestrating of resources and workflows. Using a Job, users can easily schedule specific resources, request a resource for a given pool of resources, schedule an entire workflow or a hybrid of each of the options. The full lifecycle of a Job can be managed with tools created for requestors,Booking Teams on to your Operational Teams.

Jobs provide the means to:

* Track information about the Job itself from who's requesting it, when the Job starts and ends and Job priorities
* The Resources and Resource Pools being used for the Job that guarantee that resource's availability for the scheudled time
* Visual Indicators to easily see when a Job needs additional input prior to the Job's start
* Cost & Billing information generated based on assign Contracts and actual usage of the resource

For more detailed information on this application, see: [Scheduling application](xref:scheduling_app).

## Workflow Designer

![Workflow Designer app icon](~/user-guide/images/mediaops_wfd_dm-logo.png)

The workflow designer is an operator-level DevOps environment to create technical workflows. In the app, users can define what needs to happen when creating a connection between a source and a destination, when executing a certain job, delivering a type of service etc. This is done by describing workflows. Each workflow consists of a set of nodes and a set of connections between these nodes. These typically describe how a source signal (virtual signal group) is transported to a destination and how it gets processed in between. These workflows can then be executed ad-hoc (from a control surface) or scheduled (for example by scheduling a job in the scheduling app)

Additionally, a workflow describes:

* How the nodes in the workflow need to be connected by Flow Engineering
* What automation is run as part of the workflow execution
* Whether or not resources and capacity are reserved or not
* If and how the service needs to be monitored

For more detailed information on this application, see: [Workflow Designer application](xref:workflow_designer_app).

## Cost and Billing

![Cost and Billing app icon](~/user-guide/images/mediaops_cb_dm-logo.png)

Cost and Billing is a robust application designed to streamline financial operations within a media environment. Its Contract module offers a comprehensive framework for managing agreements, defining validity periods, and incorporating flexible billing options. Users can apply discounts during billing calculations and navigate intricate details like Speed Order Fees, providing choices between fixed or incremental charges based on the job's booking confirmation. The app's versatility extends to cancellation fees, allowing users to opt for fixed or incremental charges. Billing flexibility is further enhanced by the app's capability to facilitate billing based on workflows, resources, or a combination of both. Additionally, the app enables precise customization through default and specific rate card assignments to workflows, resources, and resource pools.

Within the Ratecards module, the app seamlessly associates with job nodes, such as workflows, resources, and resource pools, offering detailed charging mechanisms based on usage duration. The module also allows users to specify the currency for billing or cost descriptions, ensuring accuracy in financial transactions. The inclusion of rates based on various time units or single use adds granularity to the billing structure, making the Cost and Billing app a comprehensive financial management tool. The Currencies module efficiently manages multiple currencies. This functionality facilitates seamless currency conversion for precise billing and cost calculations across nodes with different ratecards, ensuring a globally adaptable and efficient financial ecosystem.

For more detailed information on this application, see: [Cost and Billing application](xref:cost_billing_overview).

## People and Organizations

![People and Organizations app icon](~/user-guide/images/mediaops_po_dm-logo.png)

Upgrade your business operations with our People and Organizations app! Simplify personnel management by effortlessly creating, editing, and tracking records for individuals and teams. With features like team booking, optimizing personnel allocation for the right job has never been easier. Moreover, streamline organization management by overseeing categories, contracts, billing contacts, and company affiliation — all from a single intuitive interface. Try our solution today and witness the difference it can make in your media operations.

For more detailed information on this application, see: [People and Organizations application](xref:people_organizations_overview).

## Resource Studio

![Resource Studio app icon](~/user-guide/images/mediaops_rs_dm-logo.png)

The Resource Studio app serves as a comprehensive platform for creating, managing, and optimizing resource utilization. Its key features include the ability to create diverse resources, ranging from network inventory to services and other limited availability items such rooms, people, vehicles etc. Users can organize these resources into pools, simplifying workflow and job resource selection. Capabilities and capacities can be assigned to resources, facilitating precise resource allocation based on specific job requirements. Additionally, users can store supplementary information as properties, enhancing the resource management process. Utilization metrics provided by the app offer valuable insights, enabling users to optimize resource deployment and maximize operational efficiency.

For more detailed information on this application, see: [Resource Studio application](xref:resource_studio_app).
