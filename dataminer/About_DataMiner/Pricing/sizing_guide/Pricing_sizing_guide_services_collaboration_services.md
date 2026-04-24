---
uid: Pricing_sizing_guide_services_collaboration_services
---

# Sizing guide: Collaboration Services

Dashboard Sharing allows you to share DataMiner dashboards, including real-time data and interactive controls, with users who do not have a full DataMiner account. This is typically used to give external stakeholders such as customers, partners, or management a live view of operations.

Dashboard Sharing is **billed per unique share**: the combination of a dashboard and a recipient. It is not billed per view, per session, or per user account.

## Service volumes

| Category | Service | Metering unit | Estimation method |
|----------|---------|:-------------:|---------------------|
| Collaboration Services | Dashboard Sharing | `Number of dashboards × number of unique recipients` | Count how many dashboards you plan to share and multiply by the number of distinct recipients. |

## Examples

- Sharing 2 dashboards with 5 email recipients for a full month = 2 × 5 = **10** shares
- Sharing 1 dashboard with 50 external customers = **50** shares

## What does not affect this estimate

- **How often recipients view the dashboard**: Billing is per share, not per session or page load.
- **Number of widgets or data sources on a dashboard**: Dashboard complexity does not affect this service.
- **Internal DataMiner users**: Users with a full DataMiner account accessing dashboards through the standard interface are not counted here.
