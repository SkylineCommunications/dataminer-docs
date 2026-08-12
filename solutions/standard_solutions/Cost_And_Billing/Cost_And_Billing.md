---
uid: Cost_Billing_Intro
---

# Cost & Billing

The Cost & Billing solution provides financial visibility into your operations by linking financial information to operational activities. Contracts and rate cards defined within the application are used to determine both internal costs and customer-facing billable charges.
By linking financial data directly to operational events, Cost & Billing transforms operational data into clear, traceable financial insights.

With the Cost & Billing solution, you can:

- **Manage customer contracts**, including validity periods, uplifts, discounts, rounding rules, and the applicable billing rate cards.
- **Manage cost and billing rate cards**, defining both the cost of operational activities and the charges billed to customers, with support for rules such as minimum time intervals, minimum increments, and capped rates.
- **Work with multiple currencies** by defining **value units** and exchange rates relative to a **nominal value unit** in which all final results are expressed.
- **Synchronize the operational inventory**, including items, groups, and billable events from external systems through adapters.
- **Calculate costs and billable charges** for billable events at any stage of their lifecycle, and freeze the results when they are ready to be finalized.

## Sample solution

Cost & Billing provides a sample integration with **MediaOps Plan**. Resources, resource pools, workflows, and jobs created in MediaOps Plan are synchronized with Cost & Billing, where time-based costs and billable charges can be calculated.

The solution consists of the following components:

- **Cost & Billing** — The core component that provides the generic Cost & Billing data model and the user interface. **This component is source-agnostic and must always be installed, regardless of the external system being integrated.**
- **MediaOps Plan Adapter** — The sample component responsible for synchronizing resources, resource pools, workflows, and jobs from MediaOps Plan into the generic Cost & Billing data model.
- **MediaOps Plan Calculation Script** — The script responsible for performing the time-based cost and billing calculations for this sample integration.

## Designed to be extended

While this sample covers just the integration with **MediaOps Plan**, the solution was deliberately designed to be flexible:

- **Other billing models.** The Cost & Billing component currently focuses on time-based cost and billing only. Its model, however, is flexible enough to later support other billing models. Supporting these models requires expanding the Cost & Billing solution itself — for example with subscription contract and rate card definitions.
- **Other external solutions.** To integrate with another time-based external system, only a **new adapter** and a **new calculation script** need to be developed. The sample MediaOps Plan components simplify this process: the **MediaOps Plan Calculation Script** can be reused when no integration-specific calculation logic is required, while the **MediaOps Plan Adapter** can serve as the foundation for implementing the new adapter.

For a detailed description of how the components fit together, see the [Architecture](architecture.md) section. To get started, see [Installation](Installation.md) and [How to use](Configuration_Usage.md).
