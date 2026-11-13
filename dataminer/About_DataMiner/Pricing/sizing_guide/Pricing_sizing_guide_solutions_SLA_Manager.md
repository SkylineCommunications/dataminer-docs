---
uid: Pricing_sizing_guide_solutions_SLA_Manager
description: "Use this SLA Manager sizing guide to estimate SLA onboarding actions, object model records, storage volumes, and hosted baseline volumes for pricing."
---

# Sizing guide: SLA Manager

SLA Manager cost is primarily driven by the **number of SLAs created** (charged under Automation at onboarding) and by the **number of SLAs in the system**, which determines the recurring storage and hosting volumes.

## Parameters

| Parameter | Description |
|-----------|-------------|
| SLAs | Number of SLAs in the system. Primary and secondary SLAs each count as one SLA |
| Other records | Other object model records used by the solution |
| Trended SLA parameters | Number of SLA parameters (e.g. compliance, outage time, violations) for which trending is enabled |
| SaaS | Whether the solution is Skyline-hosted (DaaS) |

## Service volumes

| Category | Service | Units / month | Calculation method |
|----------|---------|:-------------:|---------------------|
| Data Plane | Unmanaged Objects | `SLAs + other records` | Each SLA is an object model record. The sum of all **other records** also needs to be added as they also live on the platform. SLA calculations do not create additional records. |
| Data Plane | Managed Objects | `0` | SLA elements are **not** counted as Managed Objects. |
| Data Sources | Connector Services | `1` | One SLA connector per DataMiner System, regardless of the number of SLAs. |
| Automation | Actions | `SLAs × 20` | Each new SLA triggers the equivalent to 20 Automation Actions at onboarding. This is a **one-time cost**. |
| Storage as a Service | Information Events | `SLAs × 200` | Each SLA generates ~200 information events per month: state changes, violations, user actions. |
| Storage as a Service | Alarm Updates | `SLAs × 50` | Alarm state changes of the SLA elements, for example on violations. |
| Storage as a Service | Trend Data Points | `SLAs × trended parameters` | Assuming average trending of the trended SLA parameters. Real-time trending of fast-changing parameters increases this volume significantly. |
| DataMiner as a Service | Hosted Managed Objects | `1,000,000 metrics (min)` | A typical SLA element has around 350 metrics. The 1M metric DaaS minimum baseline always applies for hosted deployments. |

> [!IMPORTANT]
> **Automation actions are a one-time onboarding charge**, at the time the SLA is created, not a recurring monthly cost. If all SLAs are onboarded in a single month, you can size your Automation subscription for that month at `SLAs × 20` Actions. A subscription shorter than 12 months does not get the volume discount, but it locks the rate of the volume band you subscribe to for the full quantity. SLAs added later are charged as Automation Actions, on pay-as-you-go or under an Automation subscription.

> [!NOTE]
> **Perpetual-license systems** use the same model, with these differences: SLA elements are not counted against the Managed Object license, the SLA connector is covered by the SLA Manager license (with yearly support) instead of a Connector Service, and DataMiner as a Service does not apply. Onboarding (Automation), Unmanaged Objects and Storage as a Service (if used) are charged as usage-based services. See [Perpetual-use licensing](xref:Pricing_Perpetual_Use_Licensing).

> [!NOTE]
> Before sizing large deployments, check the number of SLAs per DataMiner Agent and per DataMiner System in [DataMiner metrics](https://docs.dataminer.services/dataminer/Reference/Metrics/dataminer_metrics.html).

## Configured examples

| | Community | S | M | L |
|-|-------:|-------:|-------:|-------:|
| SLAs | 200 | 500 | 1,000 | 5,000 |
| Other records | 10 | 10 | 20 | 50 |
| Trended SLA parameters | 10 | 10 | 10 | 10 |
| SaaS | Yes | Yes | Yes | Yes |
| **Unmanaged Objects** | 210 | 510 | 1,020 | 5,050 |
| **Connector Services** | 1 | 1 | 1 | 1 |
| **Automation Actions** (onboarding, one-time) | 4,000 | 10,000 | 20,000 | 100,000 |
| **Information Events** | 40,000 | 100,000 | 200,000 | 1,000,000 |
| **Alarm Updates** | 10,000 | 25,000 | 50,000 | 250,000 |
| **Trend Data Points** | 18,780,000 | 46,950,000 | 93,900,000 | 469,500,000 |
| **Hosted Managed Objects** | 1,000,000 | 1,000,000 | 1,000,000 | 1,750,000 |

> [!TIP]
> Actual volumes depend on how many SLA parameters are trended, how they are trended, and how often SLAs change state. The Community example runs within the [Community Edition](xref:Pricing_Commercial_Models) allowances. [Run your own estimate in the Admin app](https://admin.dataminer.services).

## What does not affect this estimate

- **Number of users**: DataMiner is not seat-licensed. User count has no impact on usage or pricing.
- **SLA Managed Objects**: SLA elements are not counted as Managed Objects, regardless of their number of metrics.
- **Day-to-day SLA handling**: Edits, outage corrections, motivations and penalty box pinning on existing SLAs do not generate additional Automation Action charges.
- **SLA calculations**: Compliance is calculated in real time by the SLA element. SLA history and outages are stored in the SLA element itself, not as object model records, so they do not add Unmanaged Objects. Only trended SLA parameters add volume (see Trend Data Points).
- **Complexity of the monitored service**: The number of elements or alarms in the service an SLA monitors does not change the SLA Manager estimate. The monitored elements themselves are sized with the [Data Plane](xref:Pricing_sizing_guide_services_data_plane) guide.

> [!IMPORTANT]
> This applies to the **standard SLA Manager solution** only. If you extend the solution with custom automation, for example, to create tickets on violations, generate customer reports, or trigger external actions, those Automation Actions are charged in addition to this estimate. The same applies when integrating with a third-party ticketing or CRM platform: this requires a Connector Service for each integrated system and Managed Objects for each connected instance. Size those separately using the [Data Plane](xref:Pricing_sizing_guide_services_data_plane), [Data Sources](xref:Pricing_sizing_guide_services_data_sources), and [Automation](xref:Pricing_sizing_guide_services_automation) sizing guides.