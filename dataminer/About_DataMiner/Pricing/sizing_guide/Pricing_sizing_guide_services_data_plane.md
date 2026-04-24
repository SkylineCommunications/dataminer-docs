---
uid: Pricing_sizing_guide_services_data_plane
---

# Sizing guide: Data Plane

The data plane is the operational foundation of your DataMiner System, the digital twin of your operation. Every asset, service, and data source you bring into DataMiner becomes part of a living model of your operational fabric, enabling the intelligence and automation that drive you toward autonomous operations.

- **Managed Objects** are any data sources DataMiner actively interfaces with. This could be a device, service, virtual function, or software instance. How many credits a Managed Object consumes depends on its data volume, i.e., the number of metrics DataMiner is actively collecting from it.

  A Managed Object is metered as either **Standard or Light**, never both. The boundary is 200 metrics.

  Analysis across hundreds of thousands of production endpoints confirms that the large majority of endpoints are under 10,000 metrics. In practice, close to half of those elements fall below 200 metrics, meaning that **real-world costs are often lower** than the 1:1 estimate suggests.

  The main **exception are high-density platforms** that generate significantly more metrics per element: GPON platforms, CCAP headend equipment, or video quality and network analysis probes. For these, the number of metrics per endpoint can be 10 to 20 times higher than the default.

- **Unmanaged Objects** are structured records stored by DataMiner. These can be tickets, assets, work orders, contracts, jobs, or any custom record type defined in your system.

## Service volumes

| Category | Service | Metering unit | Estimation method |
|----------|---------|:-------------:|---------------------|
| Data Plane | Standard Managed Objects | `Count of endpoints with ≥ 200 metrics` <br>`Every additional 10,000 metrics = an additional unit`. | For most endpoints, 1 endpoint = 1 Managed Object. |
| Data Plane | Light Managed Objects | `Sum of all metrics across endpoints with < 200 metrics` | Billed per metric, not per endpoint. Count total metrics across all lightweight endpoints. |
| Data Plane | Unmanaged Objects | `Sum of all active record instances` | All record types combined: tickets, assets, work orders, contracts, jobs. Count every active instance regardless of type. |

> [!NOTE]
>
> - A Managed Object is metered as either Standard or Light, but never as both. The classification is based on the average daily metric count.
> - Large volumes of similar endpoints, such as subscribers, modems, or sensors, are typically managed differently in DataMiner and billed in 10,000-metric steps rather than per endpoint. For example, Starlink terminals are reported through a single telemetry API and metered accordingly. See [Starlink](xref:Pricing_sizing_guide_solutions_Starlink).

## Examples

### Standard Managed Objects

- A server with 800 metrics = **1** Standard Managed Object
- A network switch with 24,000 metrics = **3** Standard Managed Objects
- 8,000 sensors with 20 metrics each = 160,000 metrics total, billed in 10,000-metric steps = **16** Standard Managed Objects

### Light Managed Objects

- A Managed Object with 150 metrics has a metered value of **150**
- 40 UPS with 20 metrics each = **800** total metrics

### Unmanaged Objects

- A system with 5,000 tickets and 25,000 assets has a metered value of **30,000**

## What does not affect this estimate

- **Deleted or stopped objects**: Active and paused Managed Objects are both metered. Only deleted or stopped elements are excluded.
- **Read operations**: Querying, viewing, or retrieving data from Managed Objects does not generate billable events.

> [!TIP]
> DataMiner Community Edition lets you observe actual Managed Object counts before committing to a subscription. Connecting to your data sources first gives you a reliable basis for sizing.
