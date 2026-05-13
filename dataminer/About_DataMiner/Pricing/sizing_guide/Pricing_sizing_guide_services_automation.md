---
uid: Pricing_sizing_guide_services_automation
---

# Sizing guide: Automation

Automation Actions cover script executions and object creation together. The rate decreases fast progressively with volume, up to a 70% reduction. Investing in automation becomes proportionally cheaper as you scale.

## Service volumes

| Category | Service | Metering unit | Estimation method |
|----------|---------|:-------------:|---------------------|
| Automation | Automation Actions | `Script runs + new Unmanaged Object instances` | Each automation script run = 1 action. Each new object model instance created = 5 actions. User-definable API calls = 1 per 1,000 calls. |

Automation Actions include:

- Lifecycle Service Orchestration (LSO) scripts
- Profile-Load Scripts (PLS)
- Any other automation script execution
- New Unmanaged Object instances (tickets, jobs, assets, work orders, or any custom record type)

> [!NOTE]
> Some objects in Skyline's Standard Data Model may generate more than 5 actions per instance because they trigger multi-step orchestration workflows.

## Sizing by operational profile

Analysis across hundreds of live DataMiner Systems shows automation usage follows a clear pattern based on operational maturity:

| Monthly actions | System profile | What it looks like operationally |
|----------------|---------------|----------------------------------|
| < 10,000 | Monitoring, alarm handling, early-stage automation | Less than 2 actions per hour in 24/7 operations. Scheduled health checks, manual-trigger workflows. Over 70% of systems fall under this tier. |
| 10,000 – 50,000 | Active automation, basic orchestration | Up to ~70 actions per hour. Alarm enrichment, auto-ticketing, basic provisioning flows. |
| 50,000 – 200,000 | High-frequency orchestration | Up to ~280 actions per hour. Automated service lifecycle management, dynamic resource allocation. |
| 200,000+ | Autonomous operations at scale | 300+ actions per hour. Continuous real-time end-to-end service automation. |

> [!TIP]
> For greenfield deployments, start conservatively. Observe real consumption during a trial and extrapolate to a projection before committing.

## Examples

- Creating 100 new tickets = 100 × 5 = **500** Automation Actions
- A workflow that runs 3 scripts per alarm, processing 1,000 alarms per month = **3,000** Automation Actions

## What does not affect this estimate

- **Reading or querying records**: Only creation of new instances is metered, not reads, updates, or deletes.
- **Number of users triggering automation**: Manual script triggers count the same as automated ones, i.e., 1 action per run regardless of who or what initiates the script.
- **Automation from packaged solutions**: If you are running MediaOps, Ticketing, or another solution, the solution's automation is already accounted for in that solution's sizing guide. See [Solutions](xref:Pricing_sizing_guide_solutions).
