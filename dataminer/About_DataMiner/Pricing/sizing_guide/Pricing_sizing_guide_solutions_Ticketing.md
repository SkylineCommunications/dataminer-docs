---
uid: Pricing_sizing_guide_solutions_Ticketing
---

# Sizing guide: Ticketing

Ticketing cost is driven primarily by **ticket volume created per month**, not by the number of agents, queues, or fields on a ticket.

## Parameters

| Parameter | Description |
|-----------|-------------|
| Tickets per month | New incident or ticket records created each month |
| Retention | How long closed tickets are kept in the system (default: 12 months) |
| SaaS | Whether the solution is Skyline-hosted (DaaS) |
| Third-party integration | Whether DataMiner connects to an external ticketing platform (ServiceNow, Jira, etc.) |

## Service volumes

| Category | Service | Units / month | Calculation method |
|----------|---------|:-------------:|---------------------|
| Data Plane | Unmanaged Objects | `Tickets × retention` | Each ticket is an object model record retained for the full retention period. |
| Automation | Actions | `Tickets × 5` | Each new ticket triggers the equivalent to 5 Automation Actions. |
| Storage as a Service | Information Events | `Tickets × 100` | Each ticket generates ~100 information events across its lifecycle. |
| DataMiner as a Service | Hosted Managed Objects | `1,000,000 metrics (min)` | Standalone DaaS baseline. Does not grow with ticket volume. |

> [!NOTE]
> **Third-party integration**, i.e., connecting to an external platform (ServiceNow, Jira, Remedy, etc.) adds at least one Connector Service and one Standard Managed Object per connected instance. Bi-directional sync also adds Automation Actions. Size these separately using the [Data Plane](xref:Pricing_sizing_guide_services_data_plane) and [Data Sources](xref:Pricing_sizing_guide_services_data_sources) guides.

## Configured examples

| | S | M | L |
|-|-------|-------|-------|
| Tickets / month | 800 | 2,000 | 5,000 |
| Retention | 12 mo | 12 mo | 12 mo |
| SaaS | Yes | Yes | Yes |
| **Unmanaged Objects** | 9,600 | 24,000 | 60,000 |
| **Actions** | 4,000 | 10,000 | 25,000 |
| **Information Events** | 80,000 | 200,000 | 500,000 |
| **Hosted Managed Objects** | 1,000,000 | 1,000,000 | 1,000,000 |

> [!TIP]
> [Run your own estimate in the Admin app](https://admin.dataminer.services).

## What does not affect this estimate

- **Number of agents or queues**: Not metered.
- **Fields per ticket**: Ticket schema complexity does not change object model instance count. One ticket is one record regardless of how many fields it contains.
- **Read operations**: Querying, searching, or viewing tickets does not generate billable events.
- **Automation and Unmanaged Objects included in the standard solution**: The Standard Ticketing Solution triggers multiple automation flows as part of normal operation and leverages many other supporting Unmanaged Objects. These are already included in the cost of **creating tickets** within the standard solution and do not generate additional Automation Action charges.

> [!IMPORTANT]
> This applies to the **standard solution only**. If you extend the solution with custom automation, for example, to make workflows more intelligent, add approval steps, or trigger external actions, those Automation Actions are charged in addition to this estimate. The same applies when you are integrating with a third-party platform (e.g., ServiceNow) or with different endpoints (Managed Objects in DataMiner). Size those separately using the [Data Plane](xref:Pricing_sizing_guide_services_data_plane), [Data Sources](xref:Pricing_sizing_guide_services_data_sources), and [Automation](xref:Pricing_sizing_guide_services_automation) sizing guides.
