---
uid: Pricing_Commercial_Models
description: DataMiner is available in two commercial models, i.e. perpetual-use licenses or usage-based services, combined with your preferred deploy model.
---

# Commercial & deploy models summary

The DataMiner software is available in two commercial models: [**Perpetual-Use Licenses**](xref:Pricing_Perpetual_Use_Licensing) or [**Usage-based services**](xref:Pricing_Usage_based_service). This can be combined with your preferred deploy model.

| Deploy models | DataMiner nodes | Storage nodes | Commercial models available |
|--|--|--|--|
| Recommended: Hybrid | Self-Managed: Private/public cloud or on-premises | Storage as a Service (STaaS) | Perpetual-Use Licenses<br>Usage-based services |
| Recommended: Managed Service | DataMiner as a Service (DaaS) |  STaaS | Usage-based services |
| Not recommended (subject to additional engineering charges, security & availability risks): Self-Managed | Self-Managed: Private/public cloud or on-premises | Self-Managed: Private/public cloud or on-premises | Perpetual-Use Licenses<br>Usage-based services |

## Perpetual-Use Licenses

Perpetual-Use Licensing is based on the proven and flexible DataMiner Licensing Scheme, which has been available for several years. Licenses are available for **DataMiner nodes** (which are available in different capacity tiers to manage a set number of Managed Objects), for **optional modules**, and for **connectors** that interface DataMiner with different third-party products (the latter irrespective of the total number of elements managed with the connector, and with a fixed price regardless of whether the connector exists or still needs to be developed).

Perpetual-Use Licenses are a one-off expenditure.

> [!NOTE]
> Perpetual-Use License deployments are typically further complemented by the optional [DataMiner Support Services](xref:Support_Services), which provide both technical support as well as unlimited access to all available DataMiner software upgrades and updates. For Perpetual-Use Licenses, the cost for DataMiner Support Services is an annual recurring fee, relative to the value of the deployed Perpetual-Use Licenses.

## Usage-based services

> [!TIP]
> See also: [Usage-based services](xref:Pricing_Usage_based_service)

DataMiner's usage-based services offer a flexible and transparent software utilization offering. The utilization of the different services is measured in **DataMiner credits**, a single product and price. These credits, allocated to an organization, can be used across various services, adapting monthly to meet evolving needs and priorities.

By default, it operates on a Pay-per-Use model, where prepaid credits are deducted monthly based on actual service consumption.

In addition, you also have the option to subscribe to certain services by reserving a fixed number of units per month (Monthly Utilization Allowances or MUA), for the duration of 1 or 3 years, resulting in a well-defined and controlled expenditure and substantial savings on the number of credits consumed.

### DataMiner Community Edition

The DataMiner Community Edition allows you to deploy a standalone, fully featured DataMiner System per [organization](xref:Pricing_Usage_based_service#organization). It can be deployed on self-managed infrastructure or as a service.

This is the perfect way to get started, allowing anyone to use the platform and build up knowledge on the many possibilities it has to offer. When ready to scale up, you can move to the standard usage-based services by purchasing credits.

- **Self-managed**: Community Edition systems deployed on your own infrastructure (on-premises or in a private/public cloud) are free, but must be renewed every 12 months.

- **DataMiner as a Service**: Community Edition systems, easily deployed as a service with [just a few clicks](xref:Creating_a_DMS_in_the_cloud), are free for the first 7 days. After this trial period, a monthly subscription costs 480 EUR or 660 USD (depending on the end user region). Users who opt for an annual subscription can enjoy 12 months of access while only paying for 10 months.

The DataMiner Community Edition is a flavor of the usage-based services, but with a fixed allowance per service type. It has the following limitations:

- Only for standalone systems (without the option to expand).

- Community support only.

- Service limits per month:

  - 8 credits for [Standard Managed Objects](xref:Pricing_Usage_based_service#definition).
  - 4 credits for [Light Managed Objects](xref:Pricing_Usage_based_service#definition).
  - 8 credits for [Automation](xref:automation).
  - 2 credits for [Collaboration](xref:Pricing_Usage_based_service#definition).
  - 2 credits for [STaaS](xref:DM_selfhosted_and_StaaS) (not applicable to self-managed).
  - 2 credits for [DaaS](xref:DaaS_hosting) (not applicable to self-managed).
  - Number of [connectors](xref:FAQ_What_is_a_connector) is unlimited.

There might come a time when you need to increase your system's capacity to go above the limits mentioned above. If that happens, you have two options: you can either create a new system while keeping your Community Edition separate, or you can transition your existing Community Edition to a subscription or to pay-per-use (PPU) credits. In either case, a system cannot remain on the Community Edition while it continues to exceed the limits.

> [!TIP]
> See also: [Usage-based services](xref:Pricing_Usage_based_service)

## DataMiner Perpetual-Use Licenses vs Usage-based services

The Perpetual-Use model offers perpetual ownership over a named license through a one-time purchase with an optional recurrent cost for support services as well as software updates and upgrades.

Usage-based services are charged based on the actual monthly usage of services, where credits can be used freely in any combination of services that can change anytime.

|         | Perpetual-use licensing | Usage-based services |
|---------|----------------------------|----------------------|
| System capacity | Server-based licenses, each with fixed capacity tiers of managed objects: 5, 10, 25, 50, 100, 250, 500, 1000. | Volume-based, per managed object or monitored metric per month. Independent from the number of nodes deployed. |
| Failover | Server-based license. | Included. Users can deploy additional nodes for Failover without paying additional fees since billing is based on the active number of managed objects or monitored metrics in a month. |
| Optional functions | Licensed per node. | Not applicable. All optional functions are included. |
| Automation & orchestration | Based on the volume of concurrent services running. | Based on the automation volume. |
| Connectors | Single connector license fee for new and existing connectors. One connector license per different, interfaced product, per DataMiner System (DMS). | Charged per connector used per month. |
| Support services | Optional annual recurring fee, relative to the value of the deployed Perpetual-Use Licenses. | Included (see [Support plans](xref:Overview_Support_Plans)). |
| DataMiner Probes | Server-based licenses, each with fixed capacity tiers of managed objects.  | N/A |

> [!NOTE]
> DataMiner Probes (DMP) are not clustered with a DataMiner System, which means perpetual-licensed DMPs can be used to bring data from remote locations to a DataMiner System running as a usage-based service.

> [!IMPORTANT]
> The system must be connected to dataminer.services in order to enable metering for systems that are self-managed by the user (on-premises or private cloud). The system will stop working if disconnected for longer than 24 hours.
