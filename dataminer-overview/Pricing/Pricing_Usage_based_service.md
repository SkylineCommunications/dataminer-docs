---
uid: Pricing_Usage_based_service
---

# Usage-based services

The DataMiner Usage-based Services model offers your organization the option to leverage the DataMiner technology on a flexible basis empowering your digital transformation. It's available in both deploy models - private/self-hosted deployments of DataMiner (on the ground, in a private/public cloud, or hybrid) and for Skyline hosted solutions (DataMiner-as-a-Service).
This model provides **maximum operational flexibility**, maximum continuous flexibility in the utilization of DataMiner, at the scale required and leveraging any of the available DataMiner functions as deemed most valuable for the operation at any time, always perfectly aligned with any of the continuously evolving needs of both the operation and the business.

## What do you get?

From a functional and operational perspective, the DataMiner usage-based service is an all-inclusive offering. It provides your DevOps teams with everything they could ever potentially need, in an easy, instant, and on-demand manner, fully aligned with their needs at any time.

This includes:

- All available DataMiner functions, including dataminer.services functions.
- The freedom to deploy as many DataMiner nodes as required, i.e. to scale capacity up or down on demand, or to architect the overall solution in the most optimal way (e.g. considering zoning, geographical locations, continuity, etc.).
- Using any of the existing 7000+ connectors to interface DataMiner with third-party products from over 700 different vendors, on a flexible per need basis.
- Requesting new integrations with third-party products, at no additional cost with [Continuity or Evolve plans](https://community.dataminer.services/support-plans/).
- Continuously benefitting from all DataMiner evolutions available, with regard to the DataMiner functions as well as with regard to the connectors to interface with third-party products.
- Access to Skyline's professional Support Services to support the operation.

## Subscriptions

By default, DataMiner Credits are deducted monthly based on the metered usage (pay-per-use), allowing for variable usage patterns. However, you have the option to reserve a fixed number of units per month per service (available for most services). This approach provides a more predictable budget, suitable for steady, predictable usage. In exchange for committing to this usage level (Monthly Utilization Allowances (MUA)), you can enjoy savings of up to 60%, depending on the quantities subscribed.

|           | Subscription | Pay-per-Use   |
|-----------|:-------------------:|:-------------:|
| Roll-over credits | Unused credits do not roll to the next month. | Unused credits expire 12 months from the start date. |
| Minimum contract duration | 12 months | N/A |
| Annual automatic renewal | Yes | N/A |
| Annual subscription fee | Yes | N/A |
| Over-utilization | Charged at the standard Pay-per-use fee | N/A |
| New connector development | MUA < 200: charged as professional services credits <br> MUA >= 200: included with no additional costs, subject to a fair use policy  |  N/A |
| Support services | MUA < 200: Community Plan <br> MUA >= 200: Continuity/Evolve | Community Plan|


## Billing & metering

### Organization

An "organization" is the billing entity and the highest level in the hierarchy in [dataminer.services](https://admin.dataminer.services/). Among other things, it is where a company manages its settings, subscription, and billing preferences.

- Multiple DataMiner Systems (DMS) can exist in the same organization, but a DMS can only be associated with one organization.
- DMSs in separate organizations are isolated from each other.
- Metering is done on organization level and is the sum of the usage across all of an organization's DMSs.

>[!Note]
> Though we recommend having one organization per company, there is no limit to the number of organizations that can be created under the same company. This might be useful in the following scenarios: test or development accounts, managing multiple concurrent subscriptions on number of credits, or large companies with an Enterprise Agreement with multiple billing entities.

![Business organization overview](~/dataminer-overview/images/Business_organization_Overview.png)

### Usage terms

| Term      | Definition |
|-----------|------------|
| *DataMiner credits* | A flexible form of currency you can use to subscribe to DataMiner software and hosting services. Credits will be deducted automatically when you consume usage-based services. Credits are owned by an organization, and can be consumed among the DataMiner Systems of that organization. The credit balance of an organization is displayed in the [Admin app](https://admin.dataminer.services). |
| *Start Date* | The date when the system comes online. |
| *Duration* | An organization can select a 12-month, 24-month, or 36-month subscription. |
| *Renewal Date* | Subscription date + duration.<br>At the Renewal Date, subscriptions renew automatically for 12 months at the then current credit rates, unless agreed otherwise. |
| *MUA* | Monthly Utilization Allowance.<br> The fixed number of credits available per month under the subscription for each service. <br> The organization MUA is the sum of credits subscribed per service |
| *Credit Rate* | The credit rate depends on (1) the type of plan (subscription plan or pay-per-use plan), (2) the region and (3) the hosting. As to the latter, it depends whether you opt for a Skyline-hosted solution (i.e. DataMiner as a Service) or a self-hosted infrastructure (on-premises or private cloud).<br>The price of a credit is protected for the duration of the contract, i.e. 24-month or 36-month subscriptions protect against potential yearly price adjustments. |

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

| Service      | Definition |
|-----------|------------|
| *Managed Object* | Endpoints directly or indirectly interfaced by DataMiner. Directly interfaced endpoints include data sources, devices, and platforms that expose an interface that allows direct interaction with those endpoints. Indirectly interfaced endpoints include those reported through a mediating data source, for example message brokers (like Apache Kafka or RabbitMQ), databases, or Element and Network Management Systems. |
| *Metrics* | Endpoints with less than 200 metrics are not charged as a *Managed Object*, instead it's metered as the sume of its metrics |
| *Connector Services* | Use of Skyline-developed connectors (also known as DataMiner protocols or interface drivers) made available through the [catalog](https://catalog.dataminer.services/).<br>Connectors developed by the user or other third party are not counted. |
| *Script Runs* | Every time Automation scripts are [triggered](xref:Running_Automation_scripts). Among others, this includes Life cycle Service Orchestration (LSO) scripts, Profile-Load Scripts (PLS), Process Automation activities, DOM instance state transitions, and user-defined API calls. | 
| *Cloud Data Consumption* | Traffic consumed as part of [dataminer.services](xref:Overview_Collaboration). |
| *Storage as a Service (STaaS)* | Charged based solely on data ingress (i.e. data going into the cloud).  No charges apply for data egress (i.e. consumption of data from the cloud).<br>This includes Zone-Redundant Storage (ZRS) in one of the available [regions](xref:STaaS#data-location-and-redundancy), as well as automatic backup every 24 hours with a sliding window of 30 days. Other regions as well as Geo-Redundant Storage (GRS) are available at additional charge.| 

#### Metering Units
| Service      | Metering Unit | Credits |
|-----------|------------------|---------|
| *Managed Object* | Maximum number of active or paused managed objects in a month. | 0.5 |
| *Metrics* | Sum of metrics on managed objects with less than 200 metrics | 2.5 for 1000 metrics |
| *Connector Services* | Sum of used connectors delivered by Skyline. | 8 |
| *Script Runs* | Sum of script runs. | Starting at 5 for 1k script runs <br> unit credit rate decreases with incresead quantities |
| *Cloud Data Consumption* | Sum of total GB of traffic. | 1 |
| *Storage as a Service (STaaS)* | Sum of ingress units. | 0.9 per 100K alarm updates <br> 0.3 per 100K information events <br> 0.3 per 10M data points stored <br> 0.3 per 10M element data updates |

> [!NOTE]
> For DaaS Systems, Managed Objects are limited to 10k metrics, each additional 10k metric on the same Managed Object are counted as an additional Managed Object.
> Example: a Managed Object with 24k metrics is metered as 3 Managed Objects. 

> [!TIP]
> While STaaS charges can vary depending on the specifics of each DataMiner deployment and setup (e.g. specific types of Managed Objects, personal preferences and system configurations, etc.), the above translates to an average charge of 1.7 credits for 100 Managed Objects per month, considering a typical usage scenario of 180 alarm updates, 240 information events, 400,000 stored data points and 100,000 element data updates per Managed Object on average per month.

> [!IMPORTANT]
> The calculation of Service Usage may result in fractional amounts. However, for billing purposes, the total is rounded up to the nearest whole number of credits.

### Metering Period

Metering works in monthly cycles, starting on the first day of each month. MUA is pro-rated for the first and last months.

**Example of a pro-rated calculation:**

MUA: 200 credits<br>Start Date: October 20, 2022<br>Renewal Date: October 19, 2023

- MUA available for the period October 20, 2022 to October 31, 2022 = 200 credits x  12 days / 31 days = 78 credits
- MUA available for the period October 1, 2023 to October 19, 2023 =  200 credits x 19 days / 31 days = 123 credits

### Cancellation

Subscriptions can be canceled up to 30 days before the Renewal Date. The subscription will remain active until the Renewal Date. The amount paid is not refundable.

### Changing subscription

The subscribed MUA level can be changed at any time without altering the Renewal Date.

- When the MUA level is increased, the additional credits are charged at the then current Credit Rate for a minimum 12-month duration. The new MUA can be used immediately.

- When the MUA level is decreased, the original MUA will be in effect until the Renewal Date. At Renewal Date the subscription will be renewed with the new MUA.

**Example of a billing schedule of which the subscribed MUA level is increased:**

Initial MUA: 200 credits<br>Start Date: November 1, 2022<br>Renewal Date: November 1, 2023

MUA increased to 250 credits on August 1, 2023

- Billing on August 1, 2023: 50 credits x original credit rate x 12 months (i.e. paid until August 1, 2024)
- Billing on November 1, 2023 (i.e. Renewal Date): 200 credits x current credit rate x 12 months  +  50 credits x current credit rate x 3 months
