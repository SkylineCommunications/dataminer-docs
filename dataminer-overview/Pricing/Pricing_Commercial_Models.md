---
uid: Pricing_Commercial_Models
description: DataMiner is available in two commercial models, i.e. perpetual-use licenses or usage-based services, combined with your preferred deploy model.
---

# Commercial & deploy models summary

The DataMiner software is available in two commercial models: [**Perpetual-Use Licenses**](xref:Pricing_Perpetual_Use_Licensing) or [**Usage-based services**](xref:Pricing_Usage_based_service). This can be combined with your preferred deploy model.

| Deploy models | DataMiner nodes | Storage nodes | Commercial models available |
|--|--|--|--|
| Recommended - Hybrid | Self-Managed: Private/public cloud or on-premises | Storage as a Service (STaaS) | Perpetual-Use Licenses<br>Usage-based services |
| Recommended - Managed service | DataMiner as a Service (DaaS) |  STaaS | Usage-based services |
| Not Recommended (subject to additional engineering charges, security & availability risks) - Self-managed | Self-Managed Private/public cloud or on-premises | Self-Managed Private/public cloud or on-premises | Perpetual-Use Licenses<br>Usage-based services |

## Perpetual-Use Licenses

Perpetual-Use Licensing is based on the proven and flexible DataMiner Licensing Scheme, which has been available for several years. Licenses are available for **DataMiner nodes** (which are available in different capacity tiers to manage a set number of Managed Objects), for **optional modules**, and for **connectors** that interface DataMiner with different third-party products (the latter irrespective of the total number of elements managed with the connector, and with a fixed price regardless of whether the connector exists or still needs to be developed).

Perpetual-Use Licenses are a one-off expenditure.

> [!NOTE]
> Perpetual-Use License deployments are typically further complemented by the optional [DataMiner Support Services](xref:Overview_Support_DMS_M_and_S), which provide both technical support as well as unlimited access to all available DataMiner software upgrades and updates. For Perpetual-Use Licenses, the cost for DataMiner Support Services is an annual recurring fee, relative to the value of the deployed Perpetual-Use Licenses.

## Usage-based services

> [!TIP]
> See also: [Usage-based services](xref:Pricing_Usage_based_service)

DataMiner's usage-based services offers a flexible and transparent software utilization offering. The utilization of the different services is measured in **DataMiner credits**. These credits, allocated to an organization, can be used across various services, adapting monthly to meet evolving needs and priorities.

By default, it works on a Pay-per-Use model, where the number of credits consumed matches the actual utilization measured or recorded in any given month.

In addition, you also have the option to subscribe to certain services, by reserving a fixed number of units per month, for the duration of 1 or 3 years, resulting in a well-defined and controlled expenditure and in potential savings on the number of credits consumed.

### DataMiner Community Edition

The DataMiner Community Edition allows you to deploy a standalone, fully featured DataMiner System per [organization](xref:Pricing_Usage_based_service#organization). It can be deployed on self-managed infrastructure or as a service.

This is the perfect way to get started, allowing anyone to use the platform and build up knowledge on the many possibilities it has to offer. When ready to scale up, you can move to the standard usage-based services by purchasing credits.

- **Self-managed**: Community Edition systems deployed on your own infrastructure (on-premises or in a private/public cloud) are free, but must be renewed every 12 months.

- **DataMiner as a Service**: Community Edition systems [deployed as a service](xref:Creating_a_DMS_in_the_cloud) are free for the first 7 days, with a subscription after that.

The DataMiner Community Edition is a flavor of the usage-based services, but with a fixed allowance per service type.

Limitations of DataMiner Community Edition:

- Only for standalone systems (without the option to expand)

- Community support only

- Limited to 20 managed objects and 2000 script runs. Number of connectors is unlimited.

Once the above-mentioned limits have been reached, users have the option to transition to the standard usage-based model.

> [!TIP]
> See also:
>
> - [Usage-based services](xref:Pricing_Usage_based_service)
> - [DataMiner usage-based pricing](https://community.dataminer.services/usage-based-pricing/) on DataMiner Dojo

## DataMiner Perpetual-Use Licenses vs Usage-based services

The Perpetual-Use model offers perpetual ownership over a named license through a one-time purchase with an optional recurrent cost for support services and software updates and upgrades.

Usage-based services are charged based on the actual monthly usage of services, where credits can be used freely in any combination of services that can change anytime.

|         | Perpetual licensing scheme | Usage-based services |
|---------|----------------------------|----------------------|
| System capacity | Server-based licenses, each with fixed capacity tiers of managed objects: 5, 10, 25, 50, 100, 250, 500 , 1000. | Volume-based, per managed object or monitored metric per month. Independent from the number of nodes deployed. |
| Failover | Server-based license. | Included. Users can deploy additional nodes for Failover without paying additional fees since billing is based on the active number of managed objects or monitored metrics in a month. |
| Optional functions | Licensed per node: Correlation and Automation engines, Dashboard app, Low-Code Apps, Process Automation, DataMiner Object Models (DOM), and Spectrum Analysis. | Not applicable. All optional modules are included. |
| Automation & orchestration | Based on the volume of concurrent services running. | Based on the volume of script runs. |
| Connectors | Single connector license fee for new and existing connectors. One connector license per different, interfaced product, per DataMiner System (DMS). | Charged per connector used per month. |
| Custom applications (e.g. PTP app) | Licensed per app. | Charged as engineering services. |
| Sample applications | Included. | Included. |
| DataMiner Solutions | Some solutions may not be offered in the perpetual model.  | Usage-based, follows the standard metering units. |
| Cloud services | Usage-based | Usage-based. |
| Support services | Optional annual recurring fee, relative to the value of the deployed Perpetual-Use Licenses. | Included (see [Support plans](xref:Overview_Support_Plans)). |
| DataMiner Probes | Server-based licenses, each with fixed capacity tiers of managed objects.  | N/A |

> [!NOTE]
> DataMiner Probes (DMP) are not clustered with a DataMiner System, which means perpetual-licensed DMPs can be used to bring data from remote locations to a DataMiner System running as a usage-based service.

> [!IMPORTANT]
> The system must be connected to dataminer.services in order to enable metering for systems that are self-managed by the user (on-premises or private cloud). The system will stop working if disconnected for longer than 24 hours.
