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

### Services

#### Definition

| Category | Service | Definition |
|---|---|---|
| Data Plane   | *Standard Managed Object*       | Endpoints directly or indirectly interfaced by DataMiner with 200 or more metrics. |
| Data Plane   | *Light Managed Object*          | Endpoints with less than 200 metrics. |
| Data Plane   | *Unmanaged Object*              | Unmanaged Object Instances available in the system (see [DataMiner Object Models](xref:DOM)). |
| Data Sources | *Connector Services*            | Use of Skyline-developed connectors (also known as DataMiner protocols or interface drivers) made available through the [Catalog](https://catalog.dataminer.services/).<br>Connectors developed by the user or another third party are not counted. |
| Automation   | *Automation Actions*            | - [**Automation scripts**](xref:Running_Automation_scripts), e.g., Lifecycle Service Orchestration (LSO) scripts and Profile-Load Scripts (PLS). <br> - **New Unmanaged Object Instances** added to the [DataMiner Object Models](xref:DOM), e.g., a new tickets, work order, asset, or contract record. |
| Collaboration Services | *Dashboard Sharing*   | Sharing dashboards with real-time data and controls with both internal and external organization users. |
| Storage as a Service (STaaS) | *Alarm Updates* | New alarm updates written to the storage service. |
| Storage as a Service (STaaS) | *Information Events*| New information events written to the storage service.|
| Storage as a Service (STaaS) | *Trend data points* | New data point updates from trended metrics written to the storage service. |
| Storage as a Service (STaaS) | *Element data*| Metrics from Managed Objects written to the storage service. |
| DataMiner as Service (DaaS)  | *Hosted Managed Objects* | Managed Objects hosted as a service, metered as the total sum of their metrics. |
| DataMiner as Service (DaaS)  | *Hosted nodes*  | Additional hosted DataMiner nodes provisioned to increase resiliency or availability beyond the default hosted setup. |
| DataMiner Assistant | *Document Intelligence* | Document processing operations executed via the [Document Intelligence tool](xref:docintel) in DataMiner Automation. |

> [!NOTE]
> Only active and paused Managed Objects are counted for Managed Objects, Connector Services, and DaaS. Directly interfaced endpoints include data sources, devices, and platforms that expose an interface that allows direct interaction with those endpoints. Indirectly interfaced endpoints include those reported through a mediating data source, for example message brokers (like Apache Kafka or RabbitMQ), databases, or Element and Network Management Systems.

#### Metering units

| Service | Metering unit | Credits per month | Example |
|---|---|---|---|
| *Standard Managed Object*     | Count of 10K metrics on Managed Objects with 200 or more metrics.                     | 0.4                        | A Managed Object with 24K metrics, the metered value is 3. |
| *Light Managed Object*        | Sum of metrics on Managed Objects with less than 200 metrics.                         | 2 for 1K metrics         | A Managed Object with 150 metrics, the metered value is 150. |
| *Unmanaged Object*            | Sum of instances from all Unmanaged Objects.  | 4 per 100K instances. | A system with 5K tickets and 25K assets, the metered value is 30k x 4 / 100k = 1.2. |
| *Connector Services*          | Sum of connectors delivered by Skyline, concurrently used.                            | 8 | Using 20 connectors a month, but with a maximum of 5 at any given time, the metered value is 5. |
| *Automation Actions*          | Sum of automation script runs (1x per run) and new Unmanaged Object instances (5x new instance)    | Starting at 5 for 1K actions.<br> Decreases with volume. | For an object "Ticket", when creating 100 new tickets, the metered value equals 500 |
| *Dashboard Sharing*           | Sum of number of unique shares.                                                       | 0.5 | Sharing 2 dashboards with 5 email recipients for a full month, the metered value is 2 dashboards x 5 recipients = 10. |
| *Alarm Updates*               | Sum of alarm update writes.       | 0.9 per 100K alarm updates. | |
| *Information Events*          | Sum of information event writes.  | 0.4 per 100K information events. | |
| *Trend data points*           | Sum of trend data point writes.   | 0.3 per 10M trend data points. | |
| *Element data*                | Sum of element data writes.       | 0.1 per 10M element data updates. | |
| *Hosted Managed Objects*\* | Sum of metrics of all Managed Objects hosted. | 0.1 for 10K metrics | A hosted system with 2 Managed Objects, one with 24K metrics and the other with 150 metrics. The metered value is 24&thinsp;150 x 0.1 / 10K = 0.2415 |
| *Hosted nodes* | Number of additional hosted nodes provisioned for additional resiliency. | 6 per node | |
| *Document Intelligence*       | Sum of the processed document pages.  | 9 per 1K pages. | Processing 1.5K PDF documents with 2 pages each results in 3K processed pages, yielding a metered value of 3K x 9 / 1K = 27. |

\* When the *Hosted Managed Objects* service is activated, a minimum charge equivalent to **1M metrics per month** applies.

> [!NOTE]
> Instead of a fixed number of 5 actions, some objects defined in Skyline's [Standard Data Model](xref:SOL_About#standard-data-model) may trigger a different number of Automation Actions when new unmanaged object instances are created.

##### STaaS Billing

The credit rates listed above for STaaS services (*Alarm Updates*, *Information Events*, *Trend data points*, and *Element data*) apply to **Zone‑redundant storage (ZRS)** deployments.

For **Geo‑redundant storage (GRS)** deployments, the metered usage for these services is charged at **2× the listed credit rates**.

>[!NOTE]
> While STaaS charges can vary depending on the specifics of each DataMiner deployment and setup (e.g., types of Managed Objects, system configuration, and user preferences), the above translates to an average charge of:
>
> - **1.7 credits per 100 Managed Objects per month (ZRS)**
> - **3.4 credits per 100 Managed Objects per month (GRS)**
>
> For this, a typical usage pattern is assumed of 300 alarm updates, 300 information events, 400&thinsp;000 stored trend data points, and 100&thinsp;000 element data updates per Managed Object per month.

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
