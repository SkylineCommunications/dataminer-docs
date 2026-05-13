---
uid: Pricing_sizing_guide_services_data_sources
---

# Sizing guide: Data sources

Connectors are billed per distinct integration type in concurrent use, not per device or per instance counts. For example, a single connector managing 500 routers counts as one.

## Service volumes

| Category | Service | Metering unit | Estimation method |
|----------|---------|:-------------:|---------------------|
| Data Sources | Connector Services | `Maximum number of Skyline-developed connectors concurrently active` | Count distinct vendor systems or product types you plan to interface with. One connector per product type, regardless of instance count. Measured at peak concurrency per day. |

> [!NOTE]
>
> - Connector usage is counted at **organization level**, not at system level. A connector active on any system within your organization counts toward your total.
> - Connectors developed by your team or a third party are not billed. Only connectors sourced from the Skyline Catalog count.

## Examples

- Using 20 different connectors across a month, but with a maximum of 5 active at any given time = metered value of **5**
- A deployment with 100 Cisco routers and 50 Juniper switches = **2** connectors

## What does not affect this estimate

- **Number of devices per connector**: Whether a connector manages 1 or 10,000 endpoints of the same type, it counts as one.
- **Custom or third-party connectors**: Only Skyline Catalog connectors are billed.
