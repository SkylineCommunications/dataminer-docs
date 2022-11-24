---
uid: Pricing_Usage_based_service
---

# Usage-based services

The DataMiner usage-based service models, **Subscription Plan** and **Pay-per-Use Plan**, offer organizations the option to leverage the DataMiner technology on a flexible basis to empower their digital transformation. They are available both for private/self-hosted deployments of DataMiner (on the ground, in a private cloud, or hybrid) and for Skyline cloud-hosted solutions (DataMiner Software as a Service).

The key benefits of the DataMiner Subscription Service include:

- **Maximum operational flexibility**: Maximum continuous flexibility in the utilization of DataMiner, at the scale required and leveraging any of the available DataMiner functions as deemed most valuable for the operation at any time, always perfectly aligned with any of the continuously evolving needs of both the operation and the business.

- **Predefined budget aligned with the business**: Operating within the boundaries of a predefined chosen budget, ensuring a well-controlled expenditure perfectly aligned with the business, as well as benefiting from growth incentives to support further acceleration of your business.

## What do you get?

From a functional and operational perspective, the DataMiner usage-based service is an all-inclusive offering. It provides your DevOps teams with everything they could ever potentially need, in an easy, instant, and on-demand manner, fully aligned with their needs at any time.

This includes:

- All available DataMiner functions, including the DataMiner Cloud Platform functions.
- The freedom to deploy as many DataMiner nodes as required, i.e. to scale capacity up or down on demand, or to architect the overall solution in the most optimal way (e.g. considering zoning, geographical locations, continuity, etc.).
- Using any of the existing 7000+ connectors to interface DataMiner with third-party products from over 700 different vendors, on a flexible per need basis.
- Requesting new integrations with third-party products, at no additional cost.
- Continuously benefitting from all DataMiner evolutions available, with regard to the DataMiner functions as well as with regard to the connectors to interface with third-party products.
- Accessing our professional technical support services to support the operation.

## Free DataMiner System

Every organization can get started with one free standalone DataMiner System, a functionally full-featured DataMiner platform, only limited by the credit allowance per service.

This is the perfect way to get started, allowing anyone to use the platform and build up knowledge on the many possibilities it has to offer, within this free allowance.

When ready to scale up, the user can set up a yearly subscription or start with a number of credits in the Pay-per-Use model.

> [!NOTE]
>
> - Self-hosted/on-premises free DataMiner Systems are not time-limited. An organization can use the system as long as it remains reachable (with DataMiner Cloud Services enabled).
> - Skyline-hosted free DataMiner Systems (DataMiner as a Service) are only available for a predetermined trial period. Contact your Account Manager for details.

## Commercial models

The two commercial models for DataMiner usage-based services, **Pay-per-Use Plan** and **Subscription Plan**, provide the exact same service with different service rates and are contracted differently.

A Subscription Plan presents a more predictable budget. It is more suitable for steady usage and rewards users with a more favorable credit rate for the longer-term commitment. With a Subscription Plan, users subscribe to a Monthly Utilization Allowance (MUA) that stipulates the maximum number of credits that can be used in a month.

In case of a Pay-per-Use plan, user pay for what they use, giving ultimate flexibility and allowing for varying usage patterns (e.g. ad-hoc usage spikes during special events).

|           | Subscription Plan   | Pay-per-Use   |
|-----------|:-------------------:|:-------------:|
| Monthly utilization and metering | The user subscribes to a **fixed number of credits** per month (Monthly Utilization Allowance - MUA) that can be used towards any combination of services throughout the month within the contracted MUA. | The user sets an allowance that can be freely used in any combination of services. Usage is metered on a monthly basis and deducted from the allowance, allowing for **variable usage** patterns. |
| Roll-over credits | Unused credits do not roll to the next month. | Unused credits expire 12 months from the start date. |
| Minimum contract duration | 12 months | - |
| Automatic renewal | X | - |
| Annual subscription fee | X | - |
| Over-utilization | Charged at a premium fee | - |
| Support services | Support tier depends on the MUA level | Community |

> [!IMPORTANT]
> The system must have DataMiner Cloud Services enabled in order to enable metering for systems that are hosted by the user (on-premises or private cloud). The system will stop working if disconnected for longer than 24 hours.

### Managing subscriptions

#### Subscription terms

| Term      | Definition |
|-----------|------------|
| *Start Date* | The date when the system comes online. |
| *Duration* | An organization can select a 12-month, 24-month or 36-month subscription. |
| *Renewal Date* | Subscription date + duration.<br>At the Renewal Date, subscriptions renew automatically for 12 months at the then current credit rates, unless agreed otherwise. |
| *MUA* | Monthly Utilization Allowance.<br>A fixed number of credits available per month under the subscription. |
| *Credit Rate* | The credit rate depends on (1) the type of plan (subscription plan or pay-per-use plan), (2) the region and (3) the hosting. As to the latter, it depends whether you opt for a Skyline-hosted solution (i.e. DataMiner as a Service) or a self-hosted infrastructure (on-premises or private Cloud).<br>The price of a credit is protected for the duration of the contract, i.e. 24-month or 36-month subscriptions protect against potential yearly price adjustments. |

#### Metering

Metering works in monthly cycles, starting on the first day of each month. MUA is pro-rated for the first and last months.

**Example of a pro-rated calculation:**

MUA: 200 credits<br>Start Date: October 20, 2022<br>Renewal Date: October 19, 2023

- MUA available for the period October 20, 2022 to October 31, 2022 = 200 credits x  12 days / 31 days = 77.4 credits
- MUA available for the period October 1, 2023 to October 19, 2023 =  200 credits x 19 days / 31 days = 122.6 credits

Metering for *Data collection and control plane service* is calculated as the sum of the maximum number of active Managed Objects (for Managed Objects with 100+ metrics) and Metrics (Managed Objects under 100 metrics) at any given time. For this service metering follows the 95% percentile, i.e. it is calculated as the maximum usage after skipping the peak 5% usage, in practice allowing some room (36h per month) for tests or burst of usage.

#### Billing and invoicing

| Duration  | Invoicing |
|-----------|------------|
| 12 months | Start date: 100% |
| 24 months | Start date: 60%<br>Start date + 12 months: 40% |
| 36 months | Start date: 60%<br>Start date + 12 months: 20%<br>Start date + 24 months: 20% |

At Renewal Date, the subscription will be invoiced yearly, unless replaced by a new contract.

Consumption above the contracted Monthly Utilization Allowance (MUA) is possible, with the additional consumed credits being invoiced monthly, at the then current Pay-per-Use Credit Rate.

#### Cancellation

Subscriptions can be canceled up to 30 days before the anniversary date. The subscription will remain active until the anniversary date. The amount paid is not refundable.

#### Changing subscription

The subscribed MUA level can be changed at any time without altering the Renewal Date.

- When the MUA level is increased, the additional credits are charged at the then current Credit Rate for a minimum 12-month duration. The new MUA can be used immediately.

- When the MUA level is decreased, the original MUA will be in effect until the Renewal Date. At Renewal Date the subscription will be renewed with the new MUA.

**Example of a billing schedule of which the subscribed MUA level is increased:**

Initial MUA: 200 credits<br>Start Date: November 1, 2022<br>Renewal Date: November 1, 2023

MUA increased to 250 credits on August 1, 2023

- Billing on August 1, 2023: 50 credits x current credit rate x 12 months (i.e. paid until August 1, 2024)
- Billing on November 1, 2023 (i.e. Renewal Date): 200 credits x current credit rate x 12 months  +  50 credits x current credit rate x 4 months
