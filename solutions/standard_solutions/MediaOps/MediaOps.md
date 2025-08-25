---
uid: MediaOps
---

# dataminer.MediaOps

## Deliver content faster, better, and cheaper

dataminer.MediaOps seamlessly blends information and communication technology (ICT) with media technology and workflows, introducing a new era of data-driven, automated, and simplified media operations. Central to its architecture is the concept of the digital twin of the media operation—housing all network statistics, metrics, counters and configurations, coupled with vital business information like event schedules, asset inventory, playlists, electronic program guide (EPG) data, and more. This digital twin allows for unprecedented opportunity for resource planning and management, live media operations and automation of file and asset workflows.

While dataminer.MediaOps encompasses the entire media operation, it allows each tenant — whether within the organization or external stakeholders like customers, contractors, network providers, rental companies, and reporters — to work independently within their designated area, while maintaining seamless harmony with other teams.

![MediaOps for planned, live, and file-based operations](~/dataminer/images/mediaops_plan_live_file.png)

## Who can benefit from dataminer.MediaOps?

Many users rely on dataminer.MediaOps for their specific needs:

- Booking teams schedule resources spanning staffing, transponder slots, IP network capacity, and technical resources.
- MCR and Tx room operators perform ad hoc and scheduled processor control and connection management, smart monitoring, and redundancy switching.
- Engineering teams design, automate, and test media workflows running on-premises, in the cloud, or in a hybrid setup.
- Media asset teams automate asset and file workflows, from ingest to distribution, publication, and archiving.
- IT and SecOps teams manage ICT infrastructure, automate security workflows, and track IP multicast flows.
- Media and ICT cloud teams dynamically deploy and undeploy workloads on demand or according to the master event schedule.
<!-- - Finance and procurement teams analyze resource utilization and costs, and generate billing records. -->
- ...

In essence, dataminer.MediaOps revolutionizes media operations by combining modern ICT practices with deep media domain knowledge for any tenant in the organization and outside. With dataminer.MediaOps, M&E companies deliver better service quality and user experience, responding faster to business needs and technology innovations while increasing productivity and cost-effectiveness.

## What can you do with dataminer.MediaOps?

dataminer.MediaOps simplifies and automates your media supply chain. It comes with a [set of ready-made applications](#mediaops-applications), which can be extended with your own customized applications to tailor the UEx (User Experience) to the user's role. It can also be extended with workflows, automation, and even user-defined APIs to integrate with your existing systems.

The use cases offered by dataminer.MediaOps are listed below. <!-- The solution's focus spans from inventory management to planning and reservation, to live operations, up to finishing events and managing costs and billing.  -->This list will continue to grow over time as new releases become available for dataminer.MediaOps. As a user, you can pick and choose the functions of interest to you at any given moment. A MediaOps solution can be highly focused on a single use case, but it can also address multiple use cases, delivering value to multiple teams and tenants. The choice is yours. Over time, more functions will be added to the solution roadmap, and more use cases will be supported.

These uses cases are supported by default without any customization:

- **Inventory**: The management of various inventories includes the creation and oversight of technical resources and pools, facility and personnel resource management, and satellite transponder slot resource management. Media operations also involve the management of incoming and outgoing signals (signal database), which can optionally sync with IS-04 registries, the management of IP multicast address ranges (integrated with IPAM systems), and general asset management including asset discovery and integration with CMDBs, among other tasks.

- **Plan**: Every operation requires planning functions. Examples include planning production events, news events, OU lines over satellite, fiber, or internet (SRT – RIST), and planning asset and file ingest. Planning is essential not only on the content creation and ingest side but also on the content delivery side of the business, encompassing multi-platform channel delivery for OTT, IPTV, cable TV, DTH, DTT, and more. Beyond media teams, ICT teams also require planning tools for maintenance such as software updates, repairs, infrastructure setup, remote field installation, and commissioning. Every team plans workflows, and all teams access the same resources. dataminer.MediaOps is here to share inventory information in a collaborative manner, but also to ensure that no resource conflicts arise.

- **Reserve**: Reservation closely aligns with planning and involves making reservations on resources as per the plans to avoid conflicts. This includes both instant reservations and future reservations to ensure resource availability and suitability, thereby creating a predictable and deterministic operation. Reservations can be made on various technical resources, technical capacities, personnel, facilities and rooms, satellite transponder slots, file transcoders in the cloud, file quality analysis functions in the cloud, and more.

The following functions can be achieved by means of orchestration scripts that set up your devices and allow optional monitoring services:

- **Deploy**: As infrastructure becomes virtualized or is delivered as a service, dynamic deployment becomes crucial for any technical workflow. Examples include loading the right FPGA image on a media gateway, deploying the appropriate appliance, virtual machine, or K8S workload in the data center, and initiating cloud deployments or activating cloud inventory and SaaS services on demand, in accordance with the plan. dataminer.MediaOps facilitates automation, reduces human error, and saves costs in these deployment processes.

- **Configure**: At the onset of an event and after the initial deployment of cloud platforms and media functions, initial configurations need to be loaded or set manually. dataminer.MediaOps provides full access to configure media functions, IP network functions, ICT functions (DNS, DHCP, etc.), file recorders, vision mixers, intercoms, cloud transcoders, etc.

- **Connect**: Making connections is fundamental in any media operation, involving the acquisition, aggregation, processing, and delivery of content to the audience. dataminer.MediaOps facilitates setting up connections across various technologies, including SMPTE ST 2110, SMPTE ST 2022, SDI, ASI, L-Band, and over the internet (SRT and RIST). dataminer.MediaOps is here to set up the connections across any technology.

- **Control**: Ad hoc (parameter) control is like the gear shift in your car. You always need it, and it should be conveniently at hand. It is essential for any media function workflow, allowing for adjustments such as audio shuffling, audio delays, video gain, etc.

- **Monitor**: DataMiner intelligently monitors infrastructure, cloud inventory, precision time protocol (PTP), IP flows, services, and service level agreements (SLA), filtering out devices that are not in use or under maintenance to prevent unnecessary alarms.

- **QoS/QoE**: Tracking end-user experience and service quality is crucial. DataMiner collects metrics from the network and end-user CPE devices, utilizing key performance indicators (KPIs) and key quality indicators (KQIs) to enhance service offerings based on solid data sets.

- **Finish**: Cleaning up the network post-event is essential, involving tasks such as removing multicast routes from switches, deactivating cloud infrastructure (eliminating excess cost), and adjusting host and flow policies to enhance network security.

<!-- - **Cost & billing**: At the end of the day, M&E enterprises need to manage costs and income. dataminer.MediaOps provides reports on resource utilization, cost, and sales billing prices for each event, enabling M&E companies to understand their costs and allocate them to shows, channels, categories, content providers, customers, and more. dataminer.MediaOps can also generate raw billing information and integrate it into your billing system. -->

## MediaOps applications

dataminer.MediaOps is available in the [Catalog](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) as a package containing multiple low-code apps. Using these apps within media operations simplifies the customization of user experiences. For instance, a booking team may opt to view schedule timelines for all tasks, while an MCR team typically prefers a sorted list of tasks, with the earliest upcoming job displayed at the top of the list.

These are the out-of-the-box DataMiner applications that are currently included in the dataminer.MediaOps installation package:

<div class="row">
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/Apps/People_Organizations.html" title="People & Organizations" target="_self"><img src="~/solutions/images/mo_PeopleOrganizations.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/Apps/MO_Resource_Studio.html" title="Resource Studio" target="_self"><img src="~/solutions/images/mo_ResourceStudio.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/Apps/MO_Workflow_Designer.html" title="Workflow Designer" target="_self"><img src="~/solutions/images/mo_WorkflowDesigner.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/Apps/MO_Scheduling.html" title="Scheduling" target="_self"><img src="~/solutions/images/mo_Scheduling.svg" style="width:100%"></a>
  </div>
</div>

> [!TIP]
> To deploy the MediaOps package, go to the [MediaOps Standard Solution](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) in the Catalog. Make sure to first read the installation information on that page before you deploy the package.

<!-- 
[For later]: ## Building upon the standard applications

[For later]: When the standard MediaOps apps are insufficient to meet the needs of the users, you can create your own custom apps that interact with MediaOps. More information can be found under the [Integration Notes](xref:MediaOps_Integration). -->
