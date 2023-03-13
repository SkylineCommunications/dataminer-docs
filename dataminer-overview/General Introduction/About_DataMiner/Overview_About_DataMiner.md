---
uid: Overview_About_DataMiner
---

# About DataMiner

DataMiner is a standard, proven and very widely adopted and endorsed, modular, open and fully independent software platform, empowering your Digital Transformation.

![People Platform Methodology](~/dataminer-overview/images/People_platform_methodology.png)

The success of Digital Transformation programs is the result of bringing together **(1) [people](#people)** who have knowledge about the business domain and technology, **(2)** choosing the right DevOps **[platform](#platform)** and tooling, and **(3)** adhering to an agile deployment **[methodology](#methodology)**.

## People

![People](~/dataminer-overview/images/People_picto.png)

As a company, we have broad experience in all three areas to success. With over 300 ICT and DevOps engineers globally, the Skyline Communications team partners with its global customer base on a daily basis to digitize operations and technical workloads. Focus is deeply embedded into our DNA, as is our commitment to continuous growth of expertise working with ICT media & entertainment, data, and broadband companies all the time.

## Platform

![Platform](~/dataminer-overview/images/DataMiner_picto.png)

In today’s fast changing environment, a flexible platform and toolset is essential to handle highest priority workflows first and fast. Across all complexity, businesses and teams are in constant need to adapt and improve.

Looking at modern operational environments, there are many systems in place to runs services (data and control plane), manage infrastructure, orchestrate services, and manage business processes (billing, customer care, …). As infrastructure functions are increasingly disaggregated (e.g. SDN and NFV), and distributed across on-premises and cloud platforms & services (SaaS), consequently new software systems and tooling are deployed at a fast speed, making it difficult to achieve the required availability of the services delivered while avoiding excess and continuously growing infrastructure costs. **Automation and resource planning** have become essential capabilities to any operation.

A similar movement is noticed on the business applications. As the business continuously evolves and adapts to the customer needs, so do ICT teams continuously introduce additional tooling. Order processing, CRM, billing, media asset rights, etc. : the modern back office relies on a mixture of standard ICT tools such as ServiceNow, Salesforce.com or simple Grafana dashboards just to name a few of them, and specialist tools such as WHATS’ON for content rights management, satellite carrier planning system, etc. Of course, being an enterprise, the desire is to limit the number of tools to the minimum as each additional tool simply doubles the number of interactions (API integrations) in the eco-system, increases security concerns and of course comes with additional training and maintenance costs.

In between all infrastructure and business systems sits an emerging category of devops tools. In fact, infrastructure as well as business systems are not canned products anymore. Rather, they are platforms that can be tuned to scale, function, and preferred deployment model (on-prem, VMs, Dockers, public cloud, etc.). As a result, devops engineers import an ever growing number of devops tools that help building their pipelines: Jenkins, Puppet, Python, Terraform, Elastic, … In practice, organizations have little or no configuration management in this area of the business, resulting in high dependencies to knowledge and tooling owned by devops individuals.

Of course, each tool in the ecosystem used to have its reason of existence, but that may not be the case over time. Adding to that, **tooling may not be integrated with each other as it should, creating silos of operation and knowledge. Here’s where DataMiner comes into play: platform of choice to connect and integrate infrastructure platforms with operational and business systems and workflows resulting into a real agile, data-driven, and automated operation.** DataMiner is the platform of choice of many customers, as it is proven to be best in class to glue together existing systems as needed and digitizes the overall operation using the power of many DataMiner features of choice.

![Platform](~/dataminer-overview/images/agile_datadriven_automated_operation.png)<br>

**DataMiner is a modular platform: you select your priorities and use cases, and pick the relevant modules of DataMiner as needed to achieve your goals.**

1. DataMiner comes with a horizontally scalable **data acquisition and control plane, fully agnostic to data formats, data sources, protocols, event log formats, vendors**. The acquisition ingests any data from external sources, and can be enriched to create additional data sets using synthetic testing as an example.

1. Keeping a full mirror of your operation is table stakes to creating a data-driven and automated operation. The **DataMiner Digital Twin contains all operational collected KPI’s with full history, service and resource scheduling and provisioning data, but also any business-related data such as contacts, contracts, costing and billing, etc**. Skyline released a brand-new state-aware data store to manage administrative business-related data in at scale and highly customized to the operations: DataMiner Object Models (DOM)
Important to notice is that some of the data resides in the DataMiner deployment (Cassandra and Elastic stores managed in the DataMiner deployment itself), but equally well data sources can be accessed external to the DataMiner system (ad-hoc)

1. From ground up, DataMiner has been engineered to be **best-in-class NMS/EMS system fully agnostic to the managed technologies**. Not only does DataMiner come with **full FCAPS enterprise features**, the platform also has specialist components tailored to the media, data and broadband applications: easy-to-use button panels, spectrum analysis, etc.

1. **Automation and orchestration** are essential to any business today. DataMiner comes with 3 flavors:

   - A built-in scripting editor and run-time environment, true devops style
   - A suite of service and resource management (SRM): scheduling, automation and orchestration
   - A Process Automation (PA) module that takes care of business processes, user tasks, and seamlessly executes service and resource technical workflows as well. This is the glue between your business activities, and your infrastructure.

1. Systems and humans can only act if there is an **easy and intuitive way to consume data and insights**. DataMiner comes with a broad set of capabilities to explore, analyze and prepare data for easy consumption. Easy consumption means that users can access and aggregate any and all data from the DataMiner digital twin in a unified and generic manner. **DataMiner Generic Query Interface (GQI)** makes it easy for engineers, operators, and business people to access data of their interest. **DataMiner Dashboards** add a rich set of visualization snippets on top that can be consumed on any screen: anyone can now compose their own dashboards. **DataMiner Low-Code Apps** take it one step further, bundling many dashboards together, adding context and navigation, and controls: each team and tenant in the supply chain now has their own application they can construct, tailored to their needs, all retrieving data from that single digital twin data lake, so everybody stays in sync at all times. DataMiner is an **open platform**, so we make it easy to consume data from other tools like Power BI, Grafana, etc. **DataMiner User-Defined APIs** accommodate that in the easiest possible manner: the dynamically and tailored API does all the hard work whereas the external systems get the results in a single query. Any DataMiner devops engineer can develop API’s and publish them in a secure manner.

![Digital twin overview](~/dataminer-overview/images/DigitaL_Twin_overview.png)<br>
*Open this image in a new tab to view the full resolution.*

1. **Artificial intelligence (AI)** is part of our daily life, media and broadband operations are no different. **DataMiner AI-powered augmented operations** comes with an ever-growing suite of features including forecasting trend analysis, behavioral anomaly detection, pattern matching, and much more. A dedicated team of Skyline data analysts is committed to execute on the most challenging AI roadmap in the industry of operational support systems.

1. Collaboration and multi-tenant operations across the supply chain is essential to running a digital enabled business. **DataMiner.Services** (aka the DataMiner Cloud Platform (DCP)) comes with a portfolio of services to facilitate just that: Teams ChatOps, data sharing, Project Collaboration, the online DataMiner devops services such as the Catalog, etc. Of course, much more to come as the vast majority of DataMiner systems deployed today are all connected to the DataMiner.Services.

1. Finally, our customers and community deploy the modular DataMiner platforms for a **myriad of different uses**.

   ![Methodology](~/dataminer-overview/images/myriad_of_use_cases.png)<br>

**DataMiner sample applications** are available for devops teams and the community to start from real-life examples while creating solutions. Over time, an extensive library of those apps will instantly be accessible from the DataMiner Cloud Platform.

## Methodology

![Methodology](~/dataminer-overview/images/Methodology_picto.png)<br>

Our engagement with you follows the **agile principles**. Without doubt, having our teams focused on what brings value first to you is the key to success.

Skyline’s agile coaches will be helping out to guide and support both your and Skyline's teams to walk flawlessly through that process, building on a rich set of experiences we obtained to focus on essentials. Of course, our engagement model is built on a partnership, so your teams will need to participate to make any project a success! Working in an agile manner avoids spending time and resources to things that do not matter to your company, in other words, agile engagement is essential to deliver at lowest cost.
