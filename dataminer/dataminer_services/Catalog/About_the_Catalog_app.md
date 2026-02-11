---
uid: About_the_Catalog_app
reviewer: Alexander Verkest
---

# About the Catalog app

As part of dataminer.services, the Catalog app allows Skyline customers and DataMiner Strategic Partners to browse and deploy available DataMiner connectors, packages, Visio drawings, automation scripts, dashboards, and more.

![Catalog](~/dataminer/images/DataMiner_Catalog.png)

## Accessing the Catalog app

There are several ways to access the Catalog app:

- Go directly to <https://catalog.dataminer.services/>.

- Go to <https://dataminer.services>, [sign in](xref:Logging_on_to_dataminer_services), and click *Catalog* on the landing page.

- Go to the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page), and click *Browse Catalog* in the top-right corner of the Low-Code Apps section (from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->).

- In DataMiner Cube, go to *Apps* > *Catalog* (from DataMiner 10.2.9/10.3.0 onwards).

> [!NOTE]
> While you do not have to sign in to view Catalog items, not all functionality will be available if you are not signed in. To sign in, click the button in the top-right corner of the Catalog UI.

## About Catalog items

A Catalog item is a small package that contains one or more artifacts that can be deployed on a DataMiner System. Different types of Catalog items are supported. For example, an item could be a single connector, or it could be an application package containing multiple dashboards, automation scripts, and connectors.

At present, the following types of Catalog items are supported:

| Type | Description |
|--|--|
| Connector | Contains a [DataMiner XML connector](xref:Protocols1), integrating a specific third-party product with DataMiner for monitoring and control of that third-party product. Deploying the component will make it available on the target DataMiner System, where it can be used to create new elements. Connectors provided by Skyline are subject to updates. If you want to benefit from these updates, you should therefore not alter these connectors. |
| Scripted Connector | Contains a [DataMiner scripted connector](xref:Scripted_Connectors), enabling DataMiner to extract data from a third-party product for monitoring purposes. Deployment of the component will make it available on the target DataMiner System, where it can be used to create new elements. Scripted connectors provided by Skyline are subject to updates. If you want to benefit from these updates, you should therefore not alter these scripted connectors. |
| Ad Hoc Data Source | Contains a [DataMiner ad hoc data source integration](xref:GQI_Ad_hoc_data_sources), which allows you to make data from third-party products and various data sources available for ad hoc display in DataMiner low-code apps and dashboards. Data from an ad hoc data source is not continuously extracted from the third-party product, so it cannot be used for fault management, performance management, and various other background functions in DataMiner. Deploying the component will make it available on the target DataMiner System. Ad hoc data sources provided by Skyline are subject to updates. If you want to benefit from these updates, you should therefore not alter these ad hoc data sources. |
| Data Transformer | Contains a data transformer, which allows you to transform data queried from DataMiner through a [GQI data query](xref:About_GQI) prior to serving it to users in low-code apps or dashboards. Deployment of the component will make it available on the target DataMiner System, where it can be used as is, as part of your GQI data queries, or where you can further adjust it to meet your specific needs. |
| Automation | Contains a general-purpose [DataMiner Automation script](xref:automation) to execute automation routines, triggered either on demand by users, based on a time schedule, or based on specific events that occur. Deploying the component will make it available on the target DataMiner System, where it can be used as is, or where you can further adjust it to meet your own specific needs. |
| User-Defined API | Contains a [user-defined API](xref:UD_APIs), which adds a new endpoint to your DataMiner System tailored to a specific use case, and which enables third-party applications to consume selective data from your DataMiner System. Deploying the component will make it available on the target DataMiner System, where it can be used as is, or where you can further adjust it to meet your own specific needs. You will then have to make that new user-defined API accessible by generating and sharing a token with the intended party. |
| Dashboard | Contains a [DataMiner dashboard](xref:newR_D). This can be a standard out-of-the-box dashboard or a sample dashboard, which can for example be used for training and reference purposes or to serve as a quick start template. Deploying the component will make it available on the target DataMiner System, where it can be used as is, or where you can further adjust it to meet your own specific needs. |
| Visual Overview | Contains a [Microsoft Visio design](xref:visio), intended to be used for the DataMiner Visual Overview bubble-up and drill-down graphical UI. Deploying the component will make it available on the target DataMiner System, where it then needs to be assigned to the desired views, elements, or services. Optionally, you can further adapt or evolve the design to your own specific needs or preferences. |
| ChatOps Extension | Contains a [ChatOps](xref:About_ChatOps) extension, which provides new custom commands to be used in Microsoft Teams ChatOps, enabling users to interact with DataMiner through chat. Deploying the component will make it available on the target DataMiner System, where it can be used as is, or where you can further adjust it to meet your own specific needs. |
| Product Solution | Vendor-specific integration, leveraging the DataMiner platform to provide superior value and centralized control. |
| Standard Solution | Standard solutions are DataMiner Solutions that are out-of-the-box solutions for specific use cases or applications. They are designed to require as little configuration and setup work as possible. Standard solutions are typically owned and managed by a Product Owner, who will release updates and evolutions of the standard solutions. If you want to benefit from those future updates and new versions, you should therefore not alter or change standard solutions. |
| Custom Solution | Flexible solution tailored for unique requirements, enabling adaptation to specific operational needs. |
| Learning & Sample | Educational resources and examples to explore or demonstrate DataMiner features. |
| DevTool | Tools for advanced customization, debugging, and optimization of your DataMiner environment. |
| System Health | Components to monitor performance, detect issues, and maintain system reliability. |

### Public and private Catalog items

**Public** Catalog items are items that are available for anyone within the community to use.

**Private** Catalog items are items that are only available within your own organization. This gives users the possibility to develop app packages, automation scripts, or any type of Catalog item and redeploy them within their organization on various systems.

### Versioning of Catalog items

Catalog items can have multiple versions. To make sure that the versioning of items is easy to understand for everyone, [semantic versioning](https://semver.org/) is recommended. Extra labels can be assigned to versions to indicate that a certain version is not an official release (e.g. 1.2.3-alpha).

For Catalog items that follow semantic versioning, versions are grouped by **range**. Versions following semantic version A.B.C.D will be displayed in an A.B.C range, versions following semantic version A.B.C will be displayed in an A range, and all other version formats will be displayed in the "Other" range.<!-- RN 41243 -->

Tags can be assigned to specific versions and ranges, for instance to indicate the main range of a connector. If you are a member of the organization that published an item, you can manage these tags via the ![Context menu button](~/dataminer/images/Catalog_context_menu.png) button for each item.<!-- RN 40030 -->

The Catalog will recommend certain versions based on the following conditions:

- The latest version of a range that is tagged as the "Main" version (visualized in green).
- The latest version of a range that is tagged with a custom tag (visualized in gray).
- If neither of the above apply, the latest version of the highest active range will be recommended.

> [!NOTE]
> Versions and ranges that are not supported (i.e. deprecated ranges and versions marked as pre-release or unlisted) are not shown by default. To view these, use the *Unsupported versions* toggle button.<!-- RN 39903 -->

> [!TIP]
> For detailed information about semantic versioning practices and best practices for the creation of Catalog items, see [Best practices when creating Catalog items](xref:Best_Practices_When_Creating_Catalog_Items#use-semantic-versioning).
