---
uid: Overview_DCP
---

# DataMiner Cloud Services

The DataMiner Cloud Services represent a genuine paradigm shift, offering innovative and game-changing solutions, which support the transition into the emerging ICT media and broadband landscape and empower digital transformation programs.

The name **DataMiner Cloud Services** refers to the combined overall cloud ecosystem, which consists of different components:

- [Cloud-connected DataMiner Systems](#cloud-connected-dataminer-systems)
- [DataMiner Dojo (a.k.a. Community)](#dataminer-dojo-community)
- [DataMiner Project Collaboration](#dataminer-project-collaboration)
- [DataMiner Cloud Services](#dataminer-cloud-services)

The services are bundled into different tiers to which users can subscribe. Each tier contains a set of functionalities and capacities. For more information, see [DataMiner Cloud Services](https://community.dataminer.services/dataminer-cloud-platform-services/).

> [!TIP]
> For more information on how to access the DataMiner Cloud Platform, see [DataMiner Cloud Services](https://skyline.be/dataminer/cloud-services).

![Cloud services](~/dataminer-overview/images/CC_cloud_services.png)

## Cloud-connected DataMiner Systems

By making your DataMiner System cloud-connected, i.e. connecting it to the DataMiner Cloud Platform via a single and secured connection, you gain a host of additional capabilities (e.g. ChatOps, dashboard sharing, and custom applications).

The DataMiner Cloud Platform acts as a pivotal central component, opening up a new world of possibilities with respect to how DataMiner integrations are done and how interactions with partners, customers, and technology vendors take place.

Private DataMiner Systems, deployed on premises, off premises, or in a hybrid manner, can be connected to the DataMiner Cloud Platform, with different teams working on them. At the same time, the Skyline DevOps team, also connected to the DataMiner Cloud Platform, can design and deliver solutions through a sophisticated and highly automated CI/CD pipeline. And finally, strategic partnerships and easy integration with platforms such as Azure, AWS, Teams, etc. become easier than ever.

> [!TIP]
> See also: [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud)

## DataMiner Dojo (Community)

DataMiner Dojo, which is open to everyone, brings people from the ICT media and broadband industry together to exchange knowledge and expertise, both on DataMiner specifically and on any other hot industry topics relevant to building and managing an agile, data-driven operation.

The entire Skyline community, counting well over 350 subject-matter experts, uses Dojo as the primary platform to publish and share information and knowledge. As a result, knowledge and experience can flow more easily and generously than ever before between community members from across the world.

> [!TIP]
> See also: [DataMiner Community](xref:Community)

## DataMiner Project Collaboration

The DataMiner Project Collaboration module is specifically tailored towards managing design and development activities for modern ICT media and broadband solutions. It enables agile collaboration between members of a distributed DevOps team, ensuring the delivery of maximum value in a continuous manner.

![DataMiner Project Collaboration](~/dataminer-overview/images/CC_collaboration_1.png)

Skyline provides a full-fledged and fully integrated cloud-based collaboration ecosystem for project squads, named DataMiner Project Collaboration. It allows the squads, which typically consist of both Skyline staff and users of a DataMiner Solution, to manage the entire design and deployment process of the solution.

When a DataMiner Solution is ordered, the intake process will train and prepare the users of the solution for the project. As part of this, they will be provided access to the Project Collaboration module in the DataMiner Cloud Platform.

![Project Collaboration – Board view](~/dataminer-overview/images/CC_collaboration_2.png)

DataMiner Project Collaboration is tailored specifically towards the deployment of complex ICT media and broadband solutions and fully aligns with agile concepts. It features built-in workflows to ensure that the joint project squad can efficiently collaborate in a distributed constellation and focus their energy on maximizing the value delivery.

> [!TIP]
> See also: [Project Collaboration](xref:Collaboration)

## DataMiner Cloud Services

The DataMiner Cloud Services are a range of innovative services that augment a private DataMiner System, whether it is running in the cloud or on premises, by connecting it to the DataMiner Cloud Platform. This includes integration with online services (such as Microsoft Teams), tools to effectively collaborate with anyone inside or outside your organization, interaction and exchange with a vibrant community of industry peers, and much more.

Currently, the DataMiner Cloud Services include:

- [DataMiner Catalog](#dataminer-catalog)
- [DataMiner Live Sharing Service](#dataminer-live-sharing-service)
- [Online integration and collaboration through Microsoft Teams](#online-integration-and-collaboration-through-microsoft-teams)

> [!TIP]
> Accessing the DataMiner Cloud Services only takes a couple of clicks. See [DataMiner Cloud Services](https://skyline.be/dataminer/cloud-services).

### DataMiner Catalog

The DataMiner Catalog is destined to become the central repository for all kinds of components to facilitate and accelerate the use of DataMiner for anybody.

While the initial version already offers access to DataMiner’s vast library of interface connectors, which provide out-of-the-box integrations with over 7000 products, the catalog is also slated to support easy deployment services for dashboards, automation workflows and much more.

> [!TIP]
> See also: [DataMiner Catalog](xref:Catalog)

### DataMiner Live Sharing Service

The DataMiner Live Sharing Service ensures that the right data is readily available for the right people inside and outside your organization. With a click of a button, you can share any live data on your DataMiner platform. The built-in security allows you to decide which data to share, with whom, and for how long.

- **Easy**: Instantly share any data in your DataMiner System with the click of a button.
- **Secure**: Share data over a single secured connection via the DataMiner Cloud Platform.
- **Automated**: Automatically share data with your stakeholders upon certain events in DataMiner (e.g. an incident, a new service set up for a customer, etc.).

![Shared dashboard](~/dataminer-overview/images/CC_sharing.png)

The Live Sharing Service includes multiple security gates:

- Shares can only be created by DataMiner users who are allowed to do so in your organization.
- When creating a share, you can control:

  - With whom to share, by specifying a list of email addresses.
  - During which period of time to share. If you add an expiration date, the share will be stopped automatically when it expires.

- Sharing recipients need to authenticate with Azure AD B2C in order to access the shared data.

  - Microsoft Azure's cloud-based identity and access management service takes care of the safety of the authentication platform and automatically handles threats like DoS, password spray, or brute force attacks.
  - Users can use their preferred enterprise or social identity for authentication or create a dedicated DataMiner Cloud Platform account.
  - Compliance with a broad range of global, regional, and industry-specific security standards, including ISO 27017 and CSA-STAR (Security Trust Assurance and Risk).

> [!TIP]
> See also:
>
> - [DataMiner Sharing](xref:Sharing)
> - [Example of DataMiner Live Dashboard Sharing](https://community.dataminer.services/use-case/dataminer-live-data-sharing/)

### Online integration and collaboration through Microsoft Teams

Microsoft Teams integration offers instant notifications and follow-up actions, and allows you to create Teams channels on the fly.

You can control DataMiner via Microsoft Teams with commands such as "show alarms" or "show view Downlink". This allows remote teams to collaborate easily even if they are not in the same physical location.

This allows intuitive scenario-driven interactive conversations, for example:

![Teams bot conversation](~/dataminer-overview/images/CC_teams_conversation.png)

> [!TIP]
> See also: [DataMiner Teams bot](xref:DataMiner_Teams_bot)
