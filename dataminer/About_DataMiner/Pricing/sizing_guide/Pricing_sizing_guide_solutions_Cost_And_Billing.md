---
uid: Pricing_sizing_guide_solutions_Cost_Billing
description: "Use this Cost & Billing sizing guide to estimate calculations, retention records, automation actions, and hosted baseline volumes."
---

# Sizing guide: Cost & Billing

The cost of **Cost & Billing** is determined primarily by the number of **calculations**, **finalizations**, and **synchronizations** executed per month, all of which are charged under Automation.

## Parameters

| Parameter | Description |
|-----------|-------------|
| Calculations per month | Cost & Billing calculations executed each month, including recalculations |
| Synchronizations per month | Synchronizations executed each month between the Cost & Billing and the third-party source|
| Finalizations per month | Finalized calculations executed each month |
| Financial records | Contracts, Rate Cards, Value Units, Groups, Items, and other configuration records |
| Retention | How long Billable Events and calculation records are kept in the system (default: 12 months) |
| SaaS | Whether the solution is Skyline-hosted (DaaS) |

> [!NOTE]
> Cost & Billing is sized on **calculations** rather than events, because a Billable Event may be recalculated multiple times during its lifecycle.

## Service volumes

| Category | Service | Units / month | Calculation method |
|----------|---------|:-------------:|---------------------|
| Data Plane | Unmanaged Objects | `(events × retention × records per event) + financial records` | Billable Events accumulate over the retention window. Configuration records are added separately. |
| Automation | Actions | `calculations + finalizations + (synchronizations × 2)` | Each calculation executes the Calculation scripts. When a calculation needs to be finalized, a Finalization script is executed. Each synchronization executes an Event Synchronization script and an Item & Group Synchronization script. |
| Storage as a Service | Information Events | `calculations × 3 + finalizations × 1 + synchronizations × 4` | Each calculation generates 3 information events and each finalization generates 1. Every synchronization process generates 4 information events, capturing both user actions and execution results. |
| DataMiner as a Service | Hosted Managed Objects | `1,000,000 metrics (min)` | Cost & Billing has negligible device metrics. The 1M metric DaaS minimum baseline always applies for hosted deployments. |

> [!NOTE]
> Billable Events, Nodes, and Billable Items are persisted as separate DOM entities. Contracts, Rate Cards, Value Units, Assignments, Items, and Groups are referenced and reused rather than created per event.

## Configured examples

## Configured examples

## Configured examples

| | S | M | L |
|-|-------|-------|-------|
| Events / month | 1,000 | 5,000 | 10,000 |
| Calculations / month | 2,000 | 10,000 | 20,000 |
| Finalizations / month | 2,000 | 10,000 | 20,000 |
| Synchronizations / month | 31 | 31 | 31 |
| Financial records *(assumption)* | 5,000 | 20,000 | 50,000 |
| Retention | 12 mo | 12 mo | 12 mo |
| SaaS | Yes | Yes | Yes |
| **Unmanaged Objects** *(32 × events × retention) + financial records* | 389,000 | 1,940,000 | 3,890,000 |
| **Actions** *calculations + finalizations + (synchronizations × 2)* | 4,062 | 20,062 | 40,062 |
| **Information Events** *(calculations × 2) + finalizations + (synchronizations × 2)* | 6,062 | 30,062 | 60,062 |
| **Hosted Managed Objects** | 1,000,000 | 1,000,000 | 1,000,000 |

For sizing purposes, the following assumptions were used: 

- **32 Retained records per event**: 1 Billable Event + 10 Nodes + 1 Group + 10 Cost Billable Items + 10 Billing Billable Items.
- **Calculations**: 2 calculations per event lifecycle.
- **Synchronization**: Default synchronization every 24 hours (31 per month).

The values above are planning assumptions intended to represent a typical operational deployment.   

> [!TIP]
> Actual volumes may vary depending on event complexity, calculation frequency, and retention policy. [Run your own estimate in the Admin app](https://admin.dataminer.services).

## What does not affect this estimate

- **Number of users**: DataMiner is not seat‑licensed. User count has no impact on usage or pricing.
- **Calculated financial amount**: The cost or billing total has no impact on platform usage.
- **MediaOps jobs**: If Cost & Billing is integrated with MediaOps, jobs are already accounted for in the [MediaOps sizing model](xref:Pricing_sizing_guide_solutions_MediaOps_Plan) and are not charged again in Cost & Billing.
- **Standard configuration entities**: Contracts, Rate Cards, Value Units, Assignments, Items, and Groups typically contribute only a small fraction of the overall footprint.

> [!IMPORTANT]
> This applies to the **standard Cost & Billing Solution** only, which includes synchronization, calculation, recalculation, and finalization workflows as part of normal operation. If the solution is extended  with custom automation, approval workflows, ERP or accounting integrations, invoice-generation workflows, or third-party financial platforms, those Automation Actions are charged in addition to this estimate. The same applies when integrating with external financial or operational systems: receiving, creating, updating, or deleting financial records from external platforms can generate additional Automation Actions.Also may require Connector Services, and additional Managed Objects. Size those separately using the [Data Plane](xref:Pricing_sizing_guide_services_data_plane), [Data Sources](xref:Pricing_sizing_guide_services_data_sources), and [Automation](xref:Pricing_sizing_guide_services_automation) sizing guides.