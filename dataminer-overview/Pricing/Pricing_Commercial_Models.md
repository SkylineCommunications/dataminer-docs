---
uid: Pricing_Commercial_Models
---

# Commercial models summary

DataMiner can be used with **Perpetual-Use Licenses** or with two flavors of usage-based service models, namely the **Subscription Plan** and the **Pay-per-Use Plan**.

For the usage-based models, pricing is available for both self-hosted (on-premises or in a private cloud) and Skyline-hosted (referred to as *DataMiner as a Service*) systems.

## Perpetual-Use Licenses

Perpetual-Use Licensing is based on the proven and flexible DataMiner Licensing Scheme, which has been available for several years. Licenses are available for **DataMiner nodes** (which are available in different capacity tiers to manage a set number of Managed Objects), for **optional modules**, and for **connectors** that interface DataMiner with different third-party products (the latter irrespective of the total number of elements managed with the connector, and with a fixed price regardless of whether the connector exists or still needs to be developed).

Perpetual-Use Licenses are a one-off expenditure.

> [!NOTE]
> Perpetual-Use License deployments are typically further complemented by the optional [DataMiner Support Services](xref:Overview_Support_DMS_M_and_S), which provide both technical support as well as unlimited access to all available DataMiner software upgrades and updates. For Perpetual-Use Licenses, the cost for DataMiner Support Services is an annual recurring fee, relative to the value of the deployed Perpetual-Use Licenses.

## Usage-based services

> [!TIP]
> See also: [Usage-based services](xref:Pricing_Usage_based_service)

### Subscription Plan

DataMiner Subscription Plan is a yearly subscription built around a flexible, simple and transparent software utilization offering whereby a **Monthly Utilization Allowance (MUA)** is available for the operational teams to leverage DataMiner and to evolve it easily and continuously as dictated by their momentary needs, in terms of scale, in terms of utilization of its wealth of modular functions, and in terms of interfacing with third-party products.

The Subscription Plan offering results in a well-defined and controlled expenditure, combined with maximum freedom for the operational teams to leverage any of the many capabilities of DataMiner without any limitation, in any way deemed of value for the operation.

### Pay-per-Use

DataMiner Pay-per-Use is the most flexible model, very similar to the Subscription Service, but with no fixed Monthly Utilization Allowance nor annual contract or commitments. DataMiner usage is simply metered on a monthly basis and deducted from the prepaid credit allowance.

## Free DataMiner System

Every organization can get started with one free standalone DataMiner System, a functionally full-featured DataMiner platform, only limited by the credit allowance per service.

This is the perfect way to get started, allowing anyone to use the platform and build up knowledge on the many possibilities it has to offer, within this free allowance.

When ready to scale up, the user can set up a yearly subscription or start with a number of credits in the Pay-per-Use model.

> [!NOTE]
>
> - Self-hosted/on-premises free DataMiner Systems are not time-limited. An organization can use the system as long as it remains reachable (connected to dataminer.services).
> - Free Skyline-hosted DataMiner Systems (SaaS) are limited to a maximum of 30 days. Note that these are not yet publicly available. Contact your Account Manager for details.

## DataMiner Perpetual-Use Licenses vs Usage-based services

The Perpetual-Use model offers perpetual ownership over a named license through a one-time purchase with an optional recurrent cost for support services and software updates and upgrades.

Usage-based services are charged based on the actual monthly usage of services, where an **Utilization Allowance** can be used freely in any combination of services that can change anytime.

|         | Perpetual licensing scheme | Usage-based services |
|---------|----------------------------|----------------------|
| System capacity | Server-based licenses, each with fixed capacity tiers of managed objects: 5, 10, 25, 50, 100, 250, 500 , 1000. | Volume-based, per managed object or monitored metric per month. Independent from the number of nodes deployed. |
| Failover | Server-based license. | Included. Users can deploy additional nodes for Failover without paying additional fees since billing is based on the active number of managed objects or monitored metrics in a month. |
| Optional functions | Licensed per node: Correlation and Automation engines, Dashboard app, No-Code Apps, Low-Code Apps, Process Automation, DataMiner Object Models (DOM), and Spectrum Analysis. | Not applicable. All optional modules are included. |
| Automation & orchestration | Based on the volume of concurrent services running. | Based on the volume of script runs. |
| Connectors | Single connector license fee for new and existing connectors. One connector license per different, interfaced product, per DataMiner System (DMS). | Charged per connector used per month. |
| Custom applications (e.g. PTP app) | Licensed per app. | Charged as engineering services. |
| Sample applications | Included. | Included. |
| Cloud services | [Tier-based](https://community.dataminer.services/dataminer-cloud-platform-services/). | Usage-based. |
| Support services | Optional annual recurring fee, relative to the value of the deployed Perpetual-Use Licenses. | Included (see [DataMiner Support Plans](https://community.dataminer.services/support-services/)). |
| DataMiner Probes | Server-based licenses, each with fixed capacity tiers of managed objects.  | N/A |

> [!NOTE]
> DataMiner Probes (DMP) are not clustered with a DataMiner System, which means perpetual-licensed DMPs can be used to bring data from remote locations to a DataMiner System running as a usage-based service.

## Subscription Plan vs Pay-per-Use Plan

The two commercial models for DataMiner usage-based services, **Pay-per-Use Plan** and **Subscription Plan**, provide the exact same service with different service rates and are contracted differently.

A Subscription Plan presents a more predictable budget. It is more suitable for steady usage and rewards users with a more favorable credit rate for the longer-term commitment. With a Subscription Plan, users subscribe to a Monthly Utilization Allowance (MUA) that stipulates the maximum number of credits that can be used in a month.

In case of a Pay-per-Use plan, user pay for what they use, giving ultimate flexibility and allowing for varying usage patterns (e.g. ad-hoc usage spikes during special events).

|           | Subscription Plan   | Pay-per-Use   |
|-----------|:-------------------:|:-------------:|
| Monthly utilization and metering | The user subscribes to a **fixed number of credits** per month (Monthly Utilization Allowance - MUA) that can be used towards any combination of services throughout the month within the contracted MUA. | The user sets an allowance that can be freely used in any combination of services. Usage is metered on a monthly basis and deducted from the allowance, allowing for **variable usage** patterns. |
| Roll-over credits | Unused credits do not roll to the next month. | Unused credits expire 12 months from the start date. |
| Minimum contract duration | 12 months | N/A |
| Annual automatic renewal | Yes | N/A |
| Annual subscription fee | Yes | N/A |
| Over-utilization | Charged at a premium fee | N/A |
| New connector development | MUA < 200: charged as professional services credits <br> MUA >= 200: included with no additional costs, subject to a fair use policy  |  N/A |
| Support services | MUA < 200: Community Plan <br> MUA >= 200: Continuity/Evolve | Community Plan|

> [!IMPORTANT]
> The system must be connected to dataminer.services in order to enable metering for systems that are hosted by the user (on-premises or private cloud). The system will stop working if disconnected for longer than 24 hours.
