---
uid: Pricing_Perpetual_Use_Licensing
---

# Perpetual-Use Licensing

DataMiner Perpetual-Use Licensing is based on three main product categories:

- [Data collection and control plane](#data-collection-and-control-plane)
- [Data sources](#data-sources)
- [Special-purpose licenses](#special-purpose-licenses)

## Data collection and control plane

A DataMiner System (DMS) consists of one or more DataMiner nodes (DMAs), interconnected by an IP network. A DMA typically manages a subset of the objects subject to monitoring and control. A single DMA is a fully operational and functional DataMiner System by itself, and multiple DMAs interconnected by an IP network behave like a single consolidated network management system towards the user (i.e. DMS or DataMiner System).

DMAs can be distributed across the operational environment to increase the overall availability and resilience. Alternatively, they can be co-located at regional or central sites in a regionalized or centralized architecture. The number of DMAs is defined by the number of objects that need to be managed and the application, and their location is a matter of preference in terms of architecture. However, in any case, and in any scenario, all DMAs combined automatically behave like a single consolidated system towards the user.

Depending on the application, licensing is available as **server-based licenses**, i.e.one license per DMA in the DataMiner System, and system-wide **volume-based licenses**, irrespective of the number of DMAs need.

| Application | License | Available capacity tiers |
|--|--|--|
| Management of system **core processing** infrastructure.<br>From a handful to several thousands of objects. | Standard DataMiner Agent, Server-based | 5, 10, 25, 50, 100, 250, 500, 1000 Managed Objects (500 & 1000 only for selected approved applications, i.e. management of low-end complexity devices) | 
| Management of high-volume **distribution infrastructure** objects.<br>From 1,000 up to several 100s of thousands of objects. | System Volume Equipment (SVE), Volume-based | Starting from a volume of 1000 Managed Objects, and then onwards in multiples of 5,000 up to 50,000 Managed Objects capacity licenses. |
| Management of high-volume **service-delivery endpoints**.<br>From 25,000 up to several millions of endpoints. | Experience and Performance Management, Volume-based | 25K, 50K, 100K, 250K, 500K, 1000K service-delivery endpoints. |
| Local Management of **remote assets**.<br>From 5 to 50 objects per remote location. | DataMiner Probe, Server-based | 5, 10, 25, 50 Managed Objects |

> [!IMPORTANT]
> All volume-based licenses are cumulative undividable capacity packages. For example, to manage 17,000 objects you can either buy one 20K capacity license or one 15K and two 1K capacity licenses.

> [!NOTE]
> The license restriction on the number of Managed Objects applies to active and paused element objects (not stopped elements), including both regular element objects and virtual element objects (a.k.a. DVEs), and objects representing applications and data aggregators. It does not apply to service objects, enhanced service objects, element objects derived from redundancy groups, and SLA objects.

### Optional modules

In addition to the [standard modules](https://community.dataminer.services/core-features/) included in a DataMiner System, depending on the type of application and/or functional requirements, some advanced functional modules may be required. These modules are licensed together with the corresponding server-based licenses (i.e. per DMA) and volume-based licenses above.

| Module | Standard <br>DataMiner <br>Agents | System <br>Volume <br>Equipment <br>Licenses | Experience & <br>Performance <br>Management <br>Licenses | DataMiner <br>Probes |
|--|--|--|--|--|
| Correlation | o | x | x | o |
| Automation | o | x | x | o |
| Dashboards App | o | x | x | o |
| Low-Code Apps | o | o | o | N/A |
| Process Automation | o | o | o | N/A |
| DataMiner Object Models (DOM) | o | o | o | N/A |
| Spectrum Analysis | o | o | o | N/A |
| Infrastructure Discovery and Provisioning | o | o | o | N/A |

*Included (x), optional (o), or not applicable (N/A).*

## Data sources

DataMiner connectors are used to interface a DataMiner System with a specific object, i.e. a product or platform from any vendor. One connector license is required for each object type managed by a DataMiner System.

Connectors are designed in an open XML format, capable of modeling any communication protocol, industry-standard or proprietary, and can be developed by anybody, including Skyline Communications as well as any other qualified third party.

The license cost is a **fixed fee, independent of the number of Managed Objects** of that specific type, and independent of the number of DataMiner nodes in the system.

> [!IMPORTANT]
> The perpetual-use connector license includes development costs. Skyline Communications does not charge additional non-recurring engineering (NRE) fees, whether the connector already exists or still needs to be developed.

There are two main categories of connector licenses, i.e. Product and System Connectors:

- **Product Connectors** are typically used to interface directly with devices and other equipment.
- **System Connectors** are used to interface with other platforms (e.g. business applications, billing or asset management platforms, Element and Network Management Systems, Operations Support Systems, etc).

## Special-purpose licenses

### Service &  Resource Management (SRM)

DataMiner Service and Resource Management (SRM) enables a suite of tools useful for resource and service orchestration use cases.

This product is licensed per DataMiner System, based on the maximum number of concurrent services running in the system at any point in time. Capacity licenses are available for 1, 10, 50, 100, 500, and 1000 simultaneous services.

> [!NOTE]
> Not sure if your orchestration use case requires SRM licenses? Consult the [Service & Resource Management](https://community.dataminer.services/service-resource-management/) page on DataMiner Dojo.

> [!TIP]
> For more information, see [Service & Resource Management Framework](xref:srm_index)

### Custom apps

In addition to the standard core DataMiner licenses, which allow anybody to design, build, and deploy comprehensive multi-vendor end-to-end network management and orchestration solutions, you can also opt to license custom, purpose-built DataMiner applications from Skyline Communications.

### Staging

All products are available as a so-called staging version. These licenses are similar in functionality and capacity to the general-purpose licenses, but they are offered with a special discount, with the explicit condition that the license is only used for staging purposes. This means that DMAs or DMPs with a staging license cannot be integrated into a regular DMS, they cannot be used for the monitoring of an operational environment, and they can only be used for testing, validation, demonstration, beta evaluation, etc.

DataMiner Product/System Connectors are also available for staging purposes provided that they are available off the shelf. New connectors are not developed by Skyline Communications for staging purposes.
