---
uid: Pricing_sizing_guide_services_StaaS
---

# Sizing guide: Storage as a Service

For **Brownfield deployments**, i.e. for existing systems migrating to STaaS, the most reliable approach is to take a 24-hour sample: DataMiner writes to STaaS alongside your current storage, giving you a real consumption sample you can extrapolate from. This has consistently proven to be the most accurate sizing method for migration scenarios. For more information, see [Requesting a cost estimation for STaaS](xref:STaaS_cost_estimation).

For **Greenfield deployments**, while STaaS charges vary depending on the specifics of each DataMiner deployment and setup (e.g., types of Managed Objects, system configuration, and user preferences), the rule of thumb below is a good starting point estimate, representing the typical average system.

> [!TIP]
> One of the biggest benefits of STaaS is that it scales naturally as your system grows; there is no need to provision for peak usage on day one.

## Service volumes

| Category | Service | Metering unit | Estimation method |
|----------|---------|:-------------:|---------------------|
| Storage as a Service | Alarm Updates | Sum of alarm update writes | ~300 alarm updates per Managed Object per month, based on typical network behavior. |
| Storage as a Service | Information Events | Sum of information event writes | ~300 information events per Managed Object per month. |
| Storage as a Service | Trend Data Points | Sum of trend data point writes | ~400,000 trend data points per Managed Object per month. |
| Storage as a Service | Element Data | Sum of element data writes | ~100,000 element data writes per Managed Object per month. |

> [!IMPORTANT]
> The rates above apply to Zone-Redundant Storage (ZRS). For Geo-Redundant Storage (GRS) deployments, all STaaS rates are charged at 2× the listed rates. Confirm your storage redundancy configuration before sizing. For more information, see [Data location and redundancy](xref:STaaS_features#data-location-and-redundancy).

For typical deployments, size STaaS directly from your Standard Managed Object count:

| Configuration | Average per month |
|---|---|
| STaaS services (ZRS) | **1.7 credits per 100 Managed Objects** |
| STaaS services (GRS) | **3.4 credits per 100 Managed Objects** |

## What does not affect this estimate

- **Reads**: Viewing dashboards, loading trend graphs, or querying historical data does not generate any storage cost, regardless of frequency or volume.
- **Number of users or dashboards**: STaaS usage is driven by system write activity, not by how many users access the data or how many dashboards exist.

> [!TIP]
> STaaS volume is a consequence of your Data Plane sizing, not an independent input. Size your Managed Objects first, then apply the rule of thumb above. Adjust if your specific deployment has unusually high alarm rates or very high polling frequency.
