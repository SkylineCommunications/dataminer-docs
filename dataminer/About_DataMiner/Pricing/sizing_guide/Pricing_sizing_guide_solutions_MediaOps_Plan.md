---
uid: Pricing_sizing_guide_solutions_MediaOps_Plan
---

# Sizing guide: MediaOps Plan

MediaOps cost is primarily driven by **number of new jobs** per month (charged under Automation). Alarm and trending storage are usually negligible. The cost impact of Unmanaged Objects (Data Plane) is usually a small fraction when compared to Automation.

## Parameters

| Parameter | Description |
|-----------|-------------|
| Jobs per month | Planned events or production workflows created each month |
| Other records | Resources, contracts, people, organizations, workflows |
| Retention | How long jobs are kept in the system (default: 12 months) |
| SaaS | Whether the solution is Skyline-hosted (DaaS) |

## Service volumes

| Category | Service | Units / month | Calculation method |
|----------|---------|:-------------:|---------------------|
| Data Plane | Unmanaged Objects | `(jobs × retention) + other records` | Jobs accumulate over the retention window. At 12 months, each job creates 12 stored records before expiry. The sum of all **other records** also needs to be added as they also live on the platform.  |
| Automation | Actions | `jobs × 7` | Each job triggers the equivalent to 7 Automation Actions across its lifecycle. |
| Storage as a Service | Information Events | `jobs × 100` | Each job generates ~100 information events: status changes, user actions, system confirmations. |
| DataMiner as a Service | Hosted Managed Objects | `1,000,000 metrics (min)` | MediaOps has negligible device metrics. The 1M metric DaaS minimum baseline always applies for hosted deployments. |

## Configured examples

| | S | M | L |
|-|-------|-------|-------|
| Jobs / month | 1,000 | 5,000 | 10,000 |
| Other records | 50,000 | 50,000 | 100,000 |
| Retention | 12 mo | 12 mo | 12 mo |
| SaaS | Yes | Yes | Yes |
| **Unmanaged Objects** | 62,000 | 110,000 | 220,000 |
| **Actions** | 7,000 | 35,000 | 70,000 |
| **Information Events** | 100,000 | 500,000 | 1,000,000 |
| **Hosted Managed Objects** | 1,000,000 | 1,000,000 | 1,000,000 |

> [!TIP]
> Actual volumes may vary depending on workflow complexity and retention policy. [Run your own estimate in the Admin app](https://admin.dataminer.services).

## What does not affect this estimate

- **Number of users**: DataMiner is not seat‑licensed. User count has no impact on usage or pricing.
- **Automation and Unmanaged Objects included in the standard solution**: The MediaOps Plan Solution triggers multiple automation flows as part of normal operation and leverages many other supporting Unmanaged Objects (Resources, Contracts, People). These are already included in the cost of **creating jobs** within the standard solution and do not generate additional Automation Action charges.

> [!IMPORTANT]
> This applies to the **standard MediaOps Plan Solution** only. If you extend the solution with custom automation, for example, to make workflows more intelligent, add approval steps, or trigger external actions, those Automation Actions are charged in addition to this estimate. The same applies when integrating with a third-party scheduler or production system: receiving, creating, updating, or deleting jobs from an external platform generates additional Automation Actions, requires a Connector Service for each integrated system, and requires Managed Objects for each connected instance. Size those separately using the [Data Plane](xref:Pricing_sizing_guide_services_data_plane), [Data Sources](xref:Pricing_sizing_guide_services_data_sources), and [Automation](xref:Pricing_sizing_guide_services_automation) sizing guides.
