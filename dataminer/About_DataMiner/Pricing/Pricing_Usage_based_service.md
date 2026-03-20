---
uid: Pricing_Usage_based_service
description: The usage-based services model provides high operational flexibility, allowing you to leverage any available DataMiner function
---

# Usage-based services

The DataMiner usage-based services model provides **high operational flexibility** in the utilization of DataMiner. It allows organizations to leverage any available DataMiner function as their operational and business needs evolve. It is available in both deployment models:

- Self-managed deployments of DataMiner (on the ground, in a private/public cloud, or hybrid), and
- Skyline-hosted solutions (DataMiner as a Service).

## What do you get?

From a functional and operational perspective, the DataMiner usage-based service is an all-inclusive offering. It provides your DevOps teams with everything they could ever potentially need, in an easy, instant, and on-demand manner, fully aligned with their needs at any time.

This includes:

- All available DataMiner functions, including dataminer.services functions.
- The freedom to deploy as many DataMiner nodes as required, i.e., to scale capacity up or down on demand, or to architect the overall solution in the most optimal way (e.g., considering zoning, geographical locations, continuity, etc.).
- Using any of the existing 7000+ connectors to interface DataMiner with third-party products from over 700 different vendors, on a flexible per need basis.
- Requesting new integrations with third-party products, at no additional cost with [Continuity or Evolve plans](https://community.dataminer.services/support-plans/).
- Continuously benefitting from all DataMiner evolutions available, with regard to the DataMiner functions as well as with regard to the connectors to interface with third-party products.
- Access to Skyline's professional Support Services to support the operation.

## Subscriptions

By default, DataMiner credits are deducted monthly based on the metered usage (pay-per-use), allowing for variable consumption over time. As an alternative, organizations can **subscribe to a fixed number of service units per month**. This provides greater budget predictability and is best suited for steady or predictable usage patterns.

Monthly Utilization Allowance (MUA) represents the total number of credits committed per month across all services. In exchange for this commitment, organizations can benefit from savings of **up to 60%**, depending on the subscribed quantities and services.

|   | Subscription | Pay-per-Use |
|---|:---:|:---:|
| Roll-over credits | Unused credits do not roll to the next month. | Unused credits do not expire. |
| Minimum contract duration | 12 months | N/A |
| Annual automatic renewal | Yes | N/A |
| Annual subscription fee | Yes | N/A |
| Support services | MUA < 200: Community Plan<br>MUA >= 200: Continuity/Evolve | Community Plan |
| Use any existing connectors from the [Catalog](https://catalog.dataminer.services/) | Yes | Yes |
| New connector development & changes to existing connectors | Included for MUA ≥ 200 <br>Professional Services credits for MUA < 200 | Charged as Professional Services credits |

> [!IMPORTANT]
> New connector development and changes to existing connectors are subject to a **fair use policy** and are intended to support normal platform usage and evolution.

> [!NOTE]
> As an exception, organizations under 200 MUA may opt to purchase a connector as a **perpetual license** instead of paying professional services for new connector development. Regular usage fees still apply whenever the connector is used. If the organization also operates DataMiner Systems under a perpetual‑use license, the connector may also be used on those systems.

## Billing & metering

### Organization

An "organization" is the billing entity and the highest level in the hierarchy in [dataminer.services](https://admin.dataminer.services/). It is where a company manages its settings, subscriptions, and billing preferences.

- Multiple DataMiner Systems (DMS) can exist in the same organization, but a DMS can only be associated with one organization.
- DMSs in separate organizations are fully isolated from each other.
- Metering is done on organization level and is the sum of the usage across all DMSs within the organization.

By default, subscriptions apply to the **aggregated usage of the organization**.

Optionally, a subscription can be **scoped to a specific DataMiner System** to reserve the subscribed quantities for that system. This is typically used to control or guarantee system‑level budgets. When a subscription is scoped to a DMS, any **unused subscription capacity is not shared** with other systems in the organization and remains unconsumed, with one important **exception**: **connector usage** is shared across the organization and is not restricted by system‑assigned subscriptions.

> [!NOTE]
> Though we recommend having one organization per company, there is no limit to the number of organizations that can be created under the same company. This might be useful to isolate test or development systems, or for large companies with an Enterprise Agreement with multiple billing entities.

![Business organization overview](~/dataminer/images/Business_organization_Overview.png)

### Metering requirements

Metering and billing require an active connection to dataminer.services to ensure accurate usage reporting. In the event of a short-term connection loss (e.g., a few days), usage data is not lost.

For offline or air-gapped environments, local usage logging is supported through the following options:

- Monthly manual export: Usage data is logged locally and must be securely exported by the end user within 5 calendar days following the end of each month (e.g., via file transfer, physical media, or email relay).

- Quarterly auditing (exceptional cases): A scheduled audit session (remote or on-site) to verify usage directly on the system. Please contact your Account Manager to discuss eligibility and setup.

### Usage terms

| Term      | Definition |
|-----------|------------|
| *DataMiner credits* | A flexible form of currency you can use to subscribe to DataMiner software and hosting services. Credits will be deducted automatically when you consume usage-based services. Credits are owned by an organization, and can be consumed among the DataMiner Systems of that organization. The credit balance of an organization is displayed in the [Admin app](https://admin.dataminer.services). |
| *Start Date* | The date when the system comes online. |
| *Duration* | An organization can select a 12-month, 24-month, or 36-month subscription. |
| *Renewal Date* | Subscription date + duration.<br>At the Renewal Date, subscriptions renew automatically for 12 months at the then current credit rates, unless agreed otherwise. |
| *MUA* | Monthly Utilization Allowance.<br>The fixed number of credits available per month under the subscription for each service.<br>The organization MUA is the sum of credits subscribed per service. |
| *Credit Rate* | The credit rate depends on the region and is protected for the duration of the contract, i.e., 24-month or 36-month subscriptions protect against potential yearly price adjustments. |

### Invoicing

| Duration  | Invoicing |
|-----------|------------|
| 12 months | Start date: 100% |
| 24 months | Start date: 60%<br>Start date + 12 months: 40% |
| 36 months | Start date: 60%<br>Start date + 12 months: 20%<br>Start date + 24 months: 20% |

At the Renewal Date, the subscription will be invoiced yearly, unless replaced by a new contract.

Consumption above the contracted Monthly Utilization Allowance (MUA) is possible, with the additional consumed credits being invoiced monthly, at the then current Pay-per-Use Credit Rate.

---

### Services

| Category | Service | Definition |
|---|---|---|
| Data Plane   | *Standard Managed Object*       | Endpoints directly or indirectly interfaced by DataMiner with 200 or more metrics. |
| Data Plane   | *Light Managed Object*          | Endpoints with less than 200 metrics. |
| Data Plane   | *Unmanaged Object*              | Unmanaged Object instances available in the system (see [DataMiner Object Models](xref:DOM)). |
| Data Sources | *Connector Services*            | Use of Skyline-developed connectors made available through the [Catalog](https://catalog.dataminer.services/). Connectors developed by the user or a third party are not counted. |
| Automation   | *Automation Actions*            | [**Automation script runs**](xref:Running_Automation_scripts),  and **new Unmanaged Object instances** added to the [DataMiner Object Models](xref:DOM). |
| Collaboration Services | *Dashboard Sharing*   | Sharing dashboards with real-time data and controls with both internal and external organization users. |
| Storage as a Service (STaaS) | *Alarm Updates* | New alarm updates written to the storage service. |
| Storage as a Service (STaaS) | *Information Events*| New information events written to the storage service.|
| Storage as a Service (STaaS) | *Trend data points* | New data point updates from trended metrics written to the storage service. |
| Storage as a Service (STaaS) | *Element data*| Metrics from Managed Objects written to the storage service. |
| DataMiner as Service (DaaS)  | *Hosted Managed Objects* | Managed Objects hosted as a service, metered as the total sum of their metrics. |
| DataMiner as Service (DaaS)  | *Hosted nodes*  | Additional hosted DataMiner nodes provisioned to increase resiliency or availability beyond the default hosted setup. |
| DataMiner Assistant | *Document Intelligence* | Document processing operations executed via the [Document Intelligence tool](https://aka.dataminer.services/document-intelligence) in DataMiner Automation. |
---

#### Data Plane

The Data Plane is the operational foundation of your DataMiner system — the digital twin of your operation. Every asset, service, and data source you bring into DataMiner becomes part of a living model of your operational fabric, enabling the intelligence and automation that drive you toward autonomous operations.

| Service | Metering unit | Starting at |
|---|---|---|
| *Standard Managed Object* | Count of 10K metrics on Managed Objects with 200 or more metrics | 0.4 credits per managed object |
| *Light Managed Object* | Sum of metrics on Managed Objects with fewer than 200 metrics | 2 credits per 1,000 metrics |
| *Unmanaged Object* | Sum of instances across all Unmanaged Object types | 4 credits per 100,000 instances |


*Managed Objects* are any data sources DataMiner actively interfaces with — a device, service, virtual function, or software instance. How many credits a Managed Object consumes depends on its data volume, i.e. the number of metrics DataMiner is actively collecting from it. Managed Objects with 200 or more metrics are billed as **Standard Managed Object**; those with fewer than 200 metrics are considered **Light Managed Objects** and are billed per metric.

> [!IMPORTANT]
> A Managed Object is metered as either Standard or Light — never both. The classification is based on its average daily metric count.

> [!NOTE]
> Only active and paused Managed Objects are metered.

*Unmanaged Objects* are structured records DataMiner stores — tickets, assets, work orders, contracts, jobs, and any custom record type defined in your system. See [DataMiner Object Models](xref:DOM).

##### Standard Managed Objects

**How to size:**

For budgetary purposes, **1 element = 1 Managed Object** is usually a reliable default. Analysis across hundreds of thousands of production elements confirms that the large majority of elements are under 10,000 metrics. In practice, close to half of those elements fall below 200 metrics — meaning real-world costs are often lower than the 1:1 estimate suggests.

The main exceptions are high-density platforms that generate significantly more metrics per element: GPON platforms, CCAP headend equipment, video quality probes, and high-volume network analytics connectors. For these, the metered value per element can be 10–20× higher than the default.

Whenever possible, connect to your data sources first. The Community Edition lets you observe actual Managed Object counts before committing, giving you confidence in your sizing before you spend.

> [!IMPORTANT]
> If you're managing **thousands or millions of similar endpoints** — subscribers, modems, sensors — these are typically managed differently in DataMiner and billed in 10,000-metric steps rather than per endpoint. The same applies to indirectly managed endpoints — for example, Starlink terminals, where the Starlink Telemetry API acts as a single data source reporting on all terminals.


**Examples:**
- A server with 800 metrics = **1 Standard Managed Object**
- A network switch with 24,000 metrics = **3 Standard Managed Objects**
- 8,000 sensors with 20 metrics each = 160,000 metrics total, billed in 10,000-metric steps = **16 Standard Managed Objects**


##### Light Managed Objects

A Light Managed Object is any endpoint interfaced by DataMiner with fewer than 200 metrics.

**How to size:**

Count the total number of metrics across all endpoints with fewer than 200 metrics each. Simple polling endpoints, basic SNMP devices, and lightweight telemetry sources typically fall here.

**Example:**

- A Managed Object with 150 metrics has a metered value of 150. 40 simple IP devices with 20 metrics each = 800 total metrics, metered value of 800.



##### Unmanaged Objects

> [!NOTE]
> New Unmanaged Object instances also count toward Automation Actions — each new instance created is metered as 5 Automation Actions. See [Automation Actions](#automation-actions).

**How to size:**

Count all active record instances across every object type in your system.

**Example:**

- A system with 5,000 tickets and 25,000 assets has a metered value of 30,000, consuming 30,000 × 4 / 100,000 = 1.2 credits per month.

---

#### Data Sources

Data Sources covers the integrations DataMiner uses to collect data from third-party products and systems.

| Service | Metering unit | Starting at |
|---|---|---|
| *Connector Services* | Maximum number of Skyline-developed connectors concurrently active | 8 credits per connector |

> [!IMPORTANT]
> Connector usage is always counted at organization level and is not restricted by system-level subscription scoping.

**How to size:**

Count the number of distinct vendor systems or product types you plan to interface — one connector per product type, regardless of how many instances you have.

**Examples:**

- Using 20 different connectors across a month, but with a maximum of 5 active at any given time, the metered value is 5. 
- A deployment with 100 Cisco routers and 50 Juniper switches uses 2 connectors.

---

#### Automation

Automation covers all script executions and workflow actions driven by DataMiner.

| Service | Metering unit | Starting at |
|---|---|---|
| *Automation Actions* | Sum of script runs and new Unmanaged Object instances | 5 credits per 1,000 actions. <br>**Rate decreases with volume** |

*Automation Actions* include:

- Each **Automation script run** counts as **1 Action**. This includes [Lifecycle Service Orchestration (LSO) scripts](xref:Running_Automation_scripts), Profile-Load Scripts (PLS), and any other Automation script execution.
- Each **new Unmanaged Object instance created** counts as **5 Actions**.

> [!NOTE]
> Some objects in Skyline’s [Standard Data Model](xref:SOL_About#standard-data-model) may create more than the default 5 Automation Actions because they can trigger multi‑step orchestration workflows.


**How to size:**

Based on analysis across multiple hundreds of live DataMiner systems, automation usage follows a clear pattern that depends on the system's operational profile and maturity. Most deployments start conservatively and grow automation over time.

| Monthly Actions | System profile | What it looks like operationally |
|---|---|---|
| < 10,000 | Monitoring, alarm handling, early-stage automation | Less than 2 automated actions per hour in 24/7 operations. Scheduled health checks, manual-trigger workflows. In practice, 70%+ of systems fall under this tier. |
| 10,000 – 50,000 | Active automation, basic orchestration | Up to ~70 actions per hour. Alarm enrichment, auto-ticketing, basic provisioning flows. |
| 50,000 – 200,000 | High-frequency orchestration | Up to ~280 actions per hour. Automated service lifecycle management, dynamic resource allocation. |
| 200,000+ | Autonomous operations at scale | 300+ actions per hour. Continuous real-time end-to-end service automation. |

For greenfield deployments, this service scales well as your automation grows. The credit rate per Action decreases progressively with volume — up to a 70% reduction in rate per action. The more you automate, the lower the unit cost. Investing in automation doesn't just improve operations; it becomes proportionally cheaper as you scale.

Whenever possible, test and observe real consumption to extrapolate to a projection.

**Example:**

- An object "Ticket", creating 100 new tickets results in a metered value of 500 Actions.

---

#### Collaboration Services

| Service | Metering unit | Starting at |
|---|---|---|
| *Dashboard Sharing* | Sum of unique shares (dashboards × recipients) | 0.5 credits per share |

*Dashboard Sharing* allows you to share DataMiner dashboards — with real-time data and controls — with both internal and external users, including those outside your DataMiner System. If you want to give external stakeholders — customers, partners, management — a live view of your operations without giving them a full DataMiner account, that's what Shares are for.

**How to size:**
Count how many dashboards you plan to share and multiply by the number of unique recipients.

**Example:**
- Sharing 2 dashboards with 5 email recipients for a full month results in a metered value of 2 × 5 = 10 shares, consuming 5 credits.

---

#### Storage as a Service (STaaS)

| Service | Metering unit | Starting at |
|---|---|---|
| *Alarm Updates* | Sum of alarm update writes | 0.9 credits per 100,000 |
| *Information Events* | Sum of information event writes | 0.4 credits per 100,000 |
| *Trend Data Points* | Sum of trend data point writes | 0.3 credits per 10,000,000 |
| *Element Data* | Sum of element data writes | 0.1 credits per 10,000,000 |

> [!IMPORTANT]
> The rates above apply to **Zone-Redundant Storage (ZRS)**. For **Geo-Redundant Storage (GRS)** deployments, all STaaS rates are charged at **2× the listed rates**.

**How to size:**

While STaaS charges can vary depending on the specifics of each DataMiner deployment and setup (e.g., types of Managed Objects, system configuration, and user preferences), the above translates to an average charge of:
- **1.7 credits per 100 Managed Objects per month** (ZRS)
- **3.4 credits per 100 Managed Objects per month** (GRS)

This assumes a typical usage pattern of 300 alarm updates, 300 information events, 400,000 trend data points, and 100,000 element data updates per Managed Object per month.


---

#### DataMiner as a Service (DaaS)

DataMiner as a Service covers the hosting of DataMiner nodes and Managed Objects by Skyline. Self-hosted deployments — on-premises or private cloud — do not incur these charges.

| Service | Metering unit | Starting at |
|---|---|---|
| *Hosted Managed Objects* | Sum of metrics across all hosted Managed Objects | 0.1 credits per 10,000 metrics |
| *Hosted Nodes* | Number of additional hosted nodes provisioned for additional resiliency | 6 credits per node |

##### Hosted Managed Objects

If Skyline hosts your DataMiner nodes, the total metric count across all hosted Managed Objects is metered as Hosted Managed Objects.

> [!IMPORTANT]
> When the Hosted Managed Objects service is activated, a minimum charge equivalent to **1,000,000 metrics per month** applies.

> [!NOTE]
> Only active and paused Managed Objects are counted.

**Example:**
- A hosted system with 500 Managed Objects at 2,000 metrics each plus 1,000 Managed Objects at 80 metrics each results in a total of 1,080,000 metrics.


##### Hosted Nodes

Additional DataMiner nodes provisioned beyond the default hosted setup to increase resiliency or availability.


> [!NOTE]
> One node is included by default per 1,000,000 hosted metrics. Additional nodes are only needed if you require resiliency or availability beyond the default configuration.

---

#### DataMiner Assistant

| Service | Metering unit | Starting at |
|---|---|---|
| *Document Intelligence* | Sum of processed document pages | 9 credits per 1,000 pages |

*Document Intelligence* using the DataMiner Assistant allows to process documents (PDF, Word, Excel, images) using AI as part of your DataMiner powered workflow (See [Docs](https://aka.dataminer.services/document-intelligence) for more information)

**Example:**

- Processing 1,500 PDF documents with 2 pages each = 3,000 × 9 / 1,000 = 27 credits.


---
### Metering Period

Metering works in monthly cycles, starting on the first day of each month. The units above reflect the base credit rates per month; metering is pro-rated per day.

Example:

- March 1 through 7, the maximum number of concurrent connectors used each day is 5.
- For the rest of the month, the maximum number of concurrent connectors used each day is always 4.

The number of credits consumed for Connector Services is calculated as the maximum number of concurrent connectors used per day, times the monthly credit rate, divided by 31 days (for March):

- Monthly Service Consumption = 5 connectors x 7 days x 8 credits / 31 + 4 connectors x 24 days x 8 credits / 31 days

### Cancellation

Subscriptions can be canceled up to 30 days before the Renewal Date. The subscription will remain active until the Renewal Date. The amount paid is not refundable.

### Changing subscription

The subscribed MUA level can be changed at any time without altering the Renewal Date.

- When the MUA level is increased, the additional credits are charged at the then current Credit Rate for a minimum 12-month duration. The new MUA can be used immediately.

- When the MUA level is decreased, the original MUA will be in effect until the Renewal Date. At Renewal Date the subscription will be renewed with the new MUA.

**Example of a billing schedule of which the subscribed MUA level is increased:**

Initial MUA: 200 credits<br>Start Date: November 1, 2022<br>Renewal Date: November 1, 2023

MUA increased to 250 credits on August 1, 2023

- Billing on August 1, 2023: 50 credits x original credit rate x 12 months (i.e., paid until August 1, 2024)
- Billing on November 1, 2023 (i.e., Renewal Date): 200 credits x current credit rate x 12 months  +  50 credits x current credit rate x 3 months

### Overage

**No penalties**: Service overage usage is charged at the standard pay-per-use fees, using the current credit rate.

**No throttling**: Your service performance will not be throttled or degraded because of overage.

**Monthly billing**: Overage charges will be included in your bill at the end of the month. If you have pay-per-use credits available, they will be deducted to cover the overage at the end of the month. If you do not have sufficient credits, the additional costs will be invoiced at the end of the month.

**Service suspension**: If overage fees are not settled by the due date, service may be temporarily suspended until payment is received.

**Notification**: You will receive alerts when you are approaching your usage limit and once you have exceeded it.

**Avoid overages**: Although you are not penalized, the cost of overage is at the service's pay-per-use credit rate, which may be higher than the subscription rate. If you expect this overage to be **continuous**, you may want to **review your subscriptions** to benefit from more favorable pricing.
