---
uid: Pricing_sizing_guide_solutions_Starlink
---

# Sizing guide: Starlink

Cost scales with terminal count through Managed Objects. The number of Managed Objects depends on which data options are enabled. Below, you can find how many terminals are approximately equal to one Managed Object. Enabling Service Usage Stats can have a significant impact on costs.

## Parameters

Identify your terminal count and which service usage data you need. This determines your Managed Object count, from which everything else follows.

| Configuration | Approx. terminals per Managed Object |
|---------------|:------------------------------------:|
| Base telemetry only | ~200 |
| Base + monthly data usage | ~63 |
| Base + daily data usage | ~3 |

> [!NOTE]
> **Daily data usage is not enabled by default.** At 12 months retention, a fleet of 1,000 terminals requires ~5 Managed Objects without usage stats, ~16 with monthly usage stats, and ~333 with daily usage stats. Evaluate carefully before enabling.

## Calculation method

Each terminal contributes a fixed number of metrics depending on which data is collected:

- Base telemetry: 50 metrics per terminal
- Base + monthly data usage: 50 + (9 × 12 months) = 158 metrics per terminal
- Base + daily data usage: 50 + (9 × 365 days) = 3,335 metrics per terminal

Standard Managed Objects are billed per 10,000 metrics: Terminals per Managed Object = 10,000 ÷ metrics per terminal, assuming 12 months retention and one service line per terminal.

## Service volumes

| Category | Service | Units / month | Calculation method |
|----------|---------|:-------------:|---------------------|
| Data Plane | Standard Managed Objects | `Terminals ÷ terminals per Managed Object` | Use the table above to determine terminals per MO based on your data configuration. |
| Data Sources | Connector Services | `1` | One Starlink connector regardless of terminal count. |
| Automation | Actions | `1,000` | The base solution uses minimal automation. 1,000 actions/month is sufficient for standard deployments. |
| Storage as a Service | Alarm Updates | `Managed Object count × 300` | ~300 alarm updates per Managed Object per month. |
| Storage as a Service | Information Events | `Managed Object count × 300` | ~300 information events per Managed Object per month. |
| Storage as a Service | Trend Data Points | `Managed Object count × 400,000` | ~400,000 trend data points per Managed Object per month. |
| Storage as a Service | Element Data | `Managed Object count × 100,000` | ~100,000 element data writes per Managed Object per month. |
| DataMiner as a Service | Hosted Managed Objects | `max(Managed Object metrics, 1,000,000)` | DaaS minimum applies. For small fleets, the 1M floor is the entire DaaS cost. |

## Configured examples

| | S | M | L |
|-|-------|-------|-------|
| Active terminals | 1,000 | 2,000 | 5,000 |
| Monthly data usage | Yes | Yes | Yes |
| Daily data usage | No | No | No |
| **Standard Managed Objects** | 16 | 32 | 79 |
| **Connector Services** | 1 | 1 | 1 |
| **Automation Actions** | 1,000 | 1,000 | 1,000 |
| **Alarm Updates** | 4,800 | 9,600 | 23,700 |
| **Information Events** | 4,800 | 9,600 | 23,700 |
| **Trend Data Points** | 6,400,000 | 12,800,000 | 31,600,000 |
| **Element Data** | 1,600,000 | 3,200,000 | 7,900,000 |
| **Hosted Managed Objects** | 1,000,000 | 1,000,000 | 1,000,000 |

> [!TIP]
> [Run your own estimate in the Admin app](https://admin.dataminer.services).

## What does not affect this estimate

- **Automation beyond the base solution**: The 1,000-action baseline covers standard fleet operations. Custom workflows built on top of the solution will add to this. Size those separately using the [Automation sizing guide](xref:Pricing_sizing_guide_services_automation).
