---
uid: Overview_About_DataMiner
---

# About DataMiner

DataMiner is a standard, proven and very widely adopted and endorsed, modular, open, and fully independent software platform, empowering your Digital Transformation.

The success of Digital Transformation programs is the result of:

- bringing together **[people](#people)** who have knowledge about the business domain and technology,
- choosing the right DevOps **[platform](#platform)** and tooling
- adhering to an agile deployment **[methodology](#methodology)**.

![People Platform Methodology](~/dataminer-overview/images/People_platform_methodology.png)

## People

As a company, we have broad experience in the different areas that contribute to the success of a Digital Transformation program. With over 300 ICT and DevOps engineers globally, the Skyline Communications team partners with its global user base on a daily basis to digitize operations and technical workloads. Focus is deeply embedded into our DNA, as is our commitment to continuous growth of expertise working with ICT media & entertainment, data, and broadband companies all the time.

## Platform

In today’s rapidly changing environment, a flexible platform and toolset are essential to **handle the highest-priority workflows first and fast**. Across all complexity, businesses and teams constantly need to adapt and improve.

Looking at modern operational environments, there are many systems in place to run services (data and control plane), manage infrastructure, orchestrate services, and manage business processes (billing, customer care, etc.). Infrastructure functions are increasingly disaggregated (e.g. SDN and NFV) and distributed across on-premises equipment, cloud platforms, and services (SaaS). New software systems and tooling are deployed at a fast speed. Consequently, it has become difficult to achieve the required availability of the services delivered while avoiding excessive and continuously growing infrastructure costs. **Automation and resource planning** have become essential capabilities to any operation.

Business applications are evolving in a similar manner. As businesses continuously evolve and adapt to user needs, so do ICT teams continuously introduce additional tooling. For order processing, CRM, billing, media asset rights, and so on, the modern back office relies on a mixture of standard ICT tools such as ServiceNow, Salesforce.com, or simple Grafana dashboards, and specialist tools such as WHATS’ON for content rights management, satellite carrier planning systems, etc. Of course, every enterprise wants to **limit the number of tools** to the minimum, as each additional tool multiplies the number of interactions (API integrations) in the ecosystem, increases security concerns, and comes with additional training and maintenance costs.

In between all infrastructure and business systems sits an **emerging category of DevOps tools**. In fact, both infrastructure and business systems are no longer "canned" products. Instead they are platforms that can be tuned to the required scale, function, and preferred deployment model (on-premises, VMs, Dockers, public cloud, etc.). As a result, DevOps engineers import an ever-growing number of DevOps tools that help build their pipelines: Jenkins, Puppet, Python, Terraform, Elasticsearch, etc. In practice, organizations have little or no configuration management in this area of the business, resulting in high dependencies on the knowledge and tooling owned by DevOps individuals.

While each tool in the ecosystem used to have its reason of existence, that may no longer be the case over time. In addition, different tools may not be integrated with each other as they should, creating **silos of operation and knowledge**. This is where **DataMiner comes into play as the platform of choice to connect and integrate infrastructure platforms with operational and business systems and workflows, resulting in a real agile, data-driven, and automated operation.** DataMiner is the platform of choice of many users, as it is proven to be best in class to glue together existing systems as needed, and its many powerful features can be used to digitize the overall operation in accordance with its users' preferences.

![Platform in detail](~/dataminer-overview/images/agile_datadriven_automated_operation.png)

DataMiner is a **modular platform**: you select your priorities and use cases, and pick the DataMiner modules you need to achieve your goals.

1. DataMiner comes with a horizontally scalable **data acquisition and control plane, fully agnostic to data formats, data sources, protocols, event log formats, and vendors**. The acquisition ingests any data from external sources and can be enriched to create additional data sets using for example synthetic testing.

1. Keeping a full mirror of your operation is table stakes to create a data-driven and automated operation. The DataMiner **"digital twin"** contains all operational collected KPIs with full history, service and resource scheduling, and provisioning data, but also any business-related data such as contacts, contracts, costing and billing, etc. You can also manage administrative business-related data at scale, entirely customized to your operation, with DataMiner Object Models (DOM). While some of the data resides in the Cassandra and Elasticsearch storage managed by DataMiner itself, it is also possible to access ad hoc data sources external to the DataMiner System.

1. From the ground up, DataMiner has been engineered to be the **best-in-class NMS/EMS system, fully agnostic to the managed technologies**. Not only does DataMiner come with **full FCAPS enterprise features**, the platform also has specialist components tailored to media, data, and broadband applications: easy-to-use button panels, spectrum analysis, etc.

1. **Automation and orchestration** are essential to any business today. DataMiner comes with three flavors:

   - A built-in scripting editor and run-time environment, true DevOps style.
   - A Service and Resource Management (SRM) suite: scheduling, automation, and orchestration.
   - A Process Automation (PA) module that takes care of business processes and user tasks, and that seamlessly executes service and resource technical workflows as well. This is the glue between your business activities and your infrastructure.

1. Systems and people can only act if there is an **easy and intuitive way to consume data and insights**. DataMiner comes with a broad set of capabilities to explore, analyze, and prepare data for easy consumption. Users can access and aggregate any and all data from the DataMiner digital twin in a unified and generic manner. The **DataMiner Generic Query Interface (GQI)** makes it easy for engineers, operators, and business people to access the data of their interest. **DataMiner dashboards** add a rich set of visualization snippets on top, which can be consumed on any screen, and which can be used by anyone to compose their own dashboards. The **DataMiner Low-Code Apps** take this one step further, bundling many dashboards together, and adding context, navigation, and controls, so that each team and tenant in the supply chain now has their own application they can construct, tailored to their needs, all retrieving data from that single digital twin data lake, ensuring that everybody stays in sync at all times. DataMiner is an **open platform**, so we make it easy to consume data from other tools like Power BI, Grafana, etc. **DataMiner User-Defined APIs** accommodate this in the easiest possible manner: the dynamic and tailored API does all the hard work, and the external systems get the results in a single query. Any DataMiner DevOps engineer can develop APIs and publish them in a secure manner.

   ![Digital twin overview](~/dataminer-overview/images/DigitaL_Twin_overview.png)<br>
   *Open this image in a new tab to view the full resolution.*

1. **Artificial intelligence (AI)** is part of our daily life, and media and broadband operations are no different. **DataMiner AI-powered augmented operations** come with an ever-growing suite of features including forecasting trend analysis, behavioral anomaly detection, pattern matching, and much more. A dedicated team of Skyline data analysts is committed to executing the most challenging AI roadmap in the industry of operational support systems.

1. Collaboration and multi-tenant operations across the supply chain are essential to running a digital enabled business. **dataminer.services** (a.k.a. the DataMiner Cloud Platform or DCP) comes with a portfolio of services to facilitate just that: Teams ChatOps, data sharing, Project Collaboration, online DataMiner DevOps services such as the Catalog, etc. Much more is to come, as the vast majority of DataMiner Systems deployed today are all connected to the dataminer.services.

1. Finally, our users and community deploy the modular DataMiner platforms for a [**myriad of different uses**](https://community.dataminer.services/use-cases/):

   production studio – MCR – playouts - multi-screen OTT - video headends - cloud pipelines – SaaS - cloud platforms - ICT data centers - ad insertion - VoD pipelines - Media Asset Management - EPG meta data management - IP L3 networks - IP L2 VLAN networks - CDN networks - optical networks - broadcast SNG - contribution & exchange networks - inter studio networks - core backbones - DTH - DVB-T - ISDB-T - ATSC networks - enterprise VSAT - consumer VSAT - satellite teleports - satellite downlinks - GEO networks - MEO and LEO constellations - DOCSIS networks - DSL access networks - 4G/5G fixed mobile networks - FTTx networks - 5G RAN - 5G broadcast - CDN - IoT - EPG metadata - CPE broadband gate fixed wireless - CPE mobile - WiFi networks - KQI management - ticket and incident management - incident resolution - inventory management - planned maintenance management - facility management - rack management - configuration management - software management - BPM business process management

**DataMiner sample applications** are available for DevOps teams and for the community, to start from real-life examples while creating solutions. Over time, an extensive library of those apps will instantly be accessible from dataminer.services.

## Methodology

Our engagement with you follows the **agile principles**. To ensure your success, our teams focus on what brings value to you first.

Skyline’s **agile coaches** help out to guide and support both your and Skyline's teams so they can walk flawlessly through that process, building on the rich set of experience we have obtained to focus on essentials. Our engagement model is built on a **partnership**, so your teams will need to participate to make any project a success. Working in an agile manner avoids spending time and resources on things that do not matter to your company. In other words, agile engagement is essential to deliver at the lowest cost.
