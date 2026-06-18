---
uid: Pricing_sizing_guide_solutions_InfraOps
---

# Sizing guide: InfraOps

InfraOps cost is primarily driven by **total asset count** (charged under Automation at onboarding) and by the total **number of other records** in the object model.

## Parameters

| Parameter | Description |
|-----------|-------------|
| Total assets | Number of assets (equipment items) registered in the system |
| Other records | Facilities, rooms, floors, zones, rows, racks, asset classes, connections |
| SaaS | Whether the solution is Skyline-hosted (DaaS) |
| Third-party integration | Whether DataMiner connects to an external DCIM or CMDB platform |

## Service volumes

| Category | Service | Units / month | Calculation method |
|----------|---------|:-------------:|---------------------|
| Data Plane | Unmanaged Objects | `Assets + other records` | Every asset and supporting record (rack, room, facility, connections, etc.) is an object model instance. Use 4–5× the asset count as a reference multiplier for other records if not known. |
| Automation | Actions | `Assets × 5` | Each asset triggers the equivalent to 5 Automation Actions at onboarding. This is a **one-time cost**. |
| Storage as a Service | Information Events | `200,000 (min)` | Based on normal solution usage. Does not necessarily scale with asset count.|
| DataMiner as a Service | Hosted Managed Objects | `1,000,000 metrics (min)` | InfraOps has negligible device metrics. The 1M metric DaaS minimum baseline always applies for hosted deployments. |

> [!IMPORTANT]
> **Automation Actions are a one-time onboarding charge**, at the time the asset is added to DataMiner, not a recurring monthly cost. If all assets are onboarded in a single month, you can size your Automation subscription for that month at `Assets × 5` Actions.

> [!NOTE]
> **Third-party integration** (connecting to an external CMDB, or asset management platform) adds at least one Connector Service and one Standard Managed Object per connected instance. Bi-directional sync may also add recurring Actions depending on how the solution is designed. Size these separately using the [Data Plane](xref:Pricing_sizing_guide_services_data_plane) and [Data Sources](xref:Pricing_sizing_guide_services_data_sources) guides.

## Configured examples

| | Community | UC-01 | UC-02 | UC-03 |
|-|-----------|-------|-------|-------|
| Total assets | 750 | 10,000 | 50,000 | 150,000 |
| Other records | 20,000 | 50,000 | 50,000 | 100,000 |
| SaaS | Yes | Yes | Yes | Yes |
| **Unmanaged Objects** | 20,750 | 60,000 | 100,000 | 250,000 |
| **Automation Actions** (onboarding, one-time) | 3,750 | 50,000 | 250,000 | 750,000 |
| **Information Events** | 200,000 | 200,000 | 200,000 | 200,000 |
| **Hosted Managed Objects** | 1,000,000 | 1,000,000 | 1,000,000 | 1,000,000 |

> [!TIP]
> Actual Unmanaged Object counts depend on how granularly facilities, zones, and connections are modeled. The examples above assume approximately 4–5× the asset count for supporting records.

## What does not affect this estimate

- **Number of users**: DataMiner is not seat-licensed. User count has no impact on usage or pricing.

> [!IMPORTANT]
> This applies to the **standard InfraOps solution** only. If you extend the solution with custom automation — for example, to trigger workflows on asset state changes, integrate with procurement systems, or automate lifecycle transitions — those Automation Actions are charged in addition to this estimate.
