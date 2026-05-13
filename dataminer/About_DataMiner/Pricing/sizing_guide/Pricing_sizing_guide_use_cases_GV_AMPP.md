---
uid: Pricing_sizing_guide_use_cases_GV_AMPP
---

# Sizing guide: GV AMPP

The main sizing decision for this use case comes from the intended scope:

- **AMPP Control**: Monitor and manually control your GV AMPP workloads, snapshots and productions from a DataMiner web interface.

  The cost of monitoring and controlling a GV AMPP environment is almost negligible. Regardless of how many workloads are running, DataMiner interfaces with the AMPP Manager as a **single integration**: one connector, resulting in the equivalent of two Managed Objects.

- **AMPP Orchestration**: Schedule and manage the full lifecycle of GV AMPP events, including automated deployment, real-time monitoring, cost tracking, and cost optimization.

  When DataMiner actively orchestrates job execution, the cost model follows the **same logic as MediaOps Plan**. The only additions are the Automation Actions to execute the job. In a **typical scenario**, each state (pre-roll, start, stop, post-roll) triggers a single Automation Action that activates all required workloads in one shot. It is not one Automation Action per workload.

> [!IMPORTANT]
> The Orchestration example in this guide is a **use case illustration**, not a standard packaged solution. The actual number of Automation Actions depends on your specific orchestration configuration, i.e., the workflows you define, the states you handle, and any custom logic. Use the figures below as a reference point, not a fixed formula, and validate against your actual design.

## Parameters

| Parameter | Description |
|-----------|-------------|
| Mode | Control only, or Control + Orchestration |
| Jobs per month | Production workflows orchestrated through DataMiner each month (Orchestration mode only) |
| Other records | Resources, contracts, people, organizations, workflows (Orchestration mode only) |
| Retention | How long jobs are kept in the system (default: 12 months) |
| SaaS | Whether the solution is Skyline-hosted (DaaS) |

## Service volumes

| Category | Service | Control only | Control + Orchestration | Calculation method |
|----------|---------|:------------:|:-----------------------:|---------------------|
| Data Plane | Standard Managed Objects | `2` | `2` | The AMPP Manager is represented as ~2 Managed Objects. Scales only at very large workload counts. |
| Data Plane | Unmanaged Objects | — | `(jobs × retention) + other records` | All job and resource records accumulate over the retention window. |
| Data Sources | Connector Services | `1` | `1` | One connector for the AMPP Manager, regardless of workload count. |
| Automation | Actions | — | `jobs × 11` | **Typical implementation**: 7 job lifecycle scripts (same as MediaOps Plan) + 4 workload state transitions (pre-roll, start, stop, post-roll). |
| Storage as a Service | Information Events | — | `jobs × 100` | ~100 information events per job across its lifecycle. |
| DataMiner as a Service | Hosted Managed Objects | `1,000,000 metrics (min)` | `1,000,000 metrics (min)` | DaaS baseline. Does not grow with job or workload volume. |

## Configured examples

| | Control | Orchestration S | Orchestration M |
|-|-------------|---------------------|---------------------|
| Jobs / month | — | 1,000 | 5,000 |
| Other records | — | 50,000 | 50,000 |
| Retention | — | 12 mo | 12 mo |
| SaaS | Yes | Yes | Yes |
| **Standard Managed Objects** | 2 | 2 | 2 |
| **Unmanaged Objects** | — | 62,000 | 110,000 |
| **Connector Services** | 1 | 1 | 1 |
| **Actions** | — | 11,000 | 55,000 |
| **Information Events** | — | 100,000 | 500,000 |
| **Hosted Managed Objects** | 1,000,000 | 1,000,000 | 1,000,000 |

> [!TIP]
> [Run your own estimate in the Admin app](https://admin.dataminer.services).

## What does not affect this estimate

- **Number of AMPP workloads**: In most deployments, all AMPP workloads are represented through the AMPP Manager, which is typically equivalent to 2 Standard Managed Objects. This only changes at very large scale: systems with thousands of workloads have reached up to the equivalent to 10 Managed Objects as additional workload counts add more metrics to that Managed Object. For the majority of deployments, this is not a variable worth sizing separately.

> [!NOTE]
> Optionally, individual workload types can each be spun into a Managed Object (e.g., a dedicated object for all Clip Players), providing more granular monitoring and parameter control over that specific workload type. This is only relevant when detailed visibility or control over individual workload parameters is needed; the core AMPP Control solution covers start/stop at the fabric level.
