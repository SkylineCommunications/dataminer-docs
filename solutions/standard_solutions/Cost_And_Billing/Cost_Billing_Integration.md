---
uid: Cost_Billing_Integration
description: "Learn how to integrate Cost & Billing with external solutions using adapters and calculation scripts, with MediaOps Plan as a practical example."
---

# Integration with other solutions

The Cost & Billing Solution is designed to be **source-agnostic**. It operates on generic concepts that are independent of any external system. All integrations with external systems are handled by dedicated **adapters**. These adapters translate source-specific concepts into the generic Cost & Billing model. This way, the Cost & Billing core never references external modules directly.

> [!TIP]
> For more details on the external integration architecture, refer to [Architecture](xref:Cost_Billing_Architecture).

## Sample integration with MediaOps Plan

Cost & Billing provides a sample integration with **MediaOps Plan**. Resources, resource pools, workflows, and jobs created in MediaOps Plan are synchronized with Cost & Billing, where time-based costs and billable charges can be calculated.

To support this integration, the following components are available:

- **MediaOps Plan Adapter**: The sample component responsible for synchronizing resources, resource pools, workflows, and jobs from MediaOps Plan into the generic Cost & Billing data model.
- **MediaOps Plan Calculation Script**: The script responsible for performing the time-based cost and billing calculations for this sample integration.

## Integrating with another solution

The sample solution with MediaOps Plan includes a dedicated adapter and calculation script, but the same Cost & Billing core supports any integration. To connect a different external solution:

- **Build a new adapter** for that solution. Cost & Billing has a dedicated Dev Pack that will allow any new adapter to interact with the Cost & Billing domain.
- **Build a new calculation script** for the new integration. The calculation script created for MediaOps Plan manages basic time-based concepts. This script can be reused or customized depending on the requirements.
- **No changes to the Cost & Billing core are required** as long as the billing model is already supported. If a new billing model is required, Cost & Billing will have to be modified directly.

One adapter must be developed per integration.

The sample MediaOps Plan components simplify the development: the **MediaOps Plan Calculation Script** can be reused when no integration-specific calculation logic is required, while the **MediaOps Plan Adapter** can serve as the foundation for implementing the new adapter.

## Synchronization

Synchronization between the external system and Cost & Billing is performed through the adapter and can be triggered in two ways:

- **Scheduled daily sync**: A routine that runs automatically once per day, keeping Cost & Billing up to date with the external system.
- **On-demand sync**: A button in the Cost & Billing interface that allows you to trigger a synchronization at any time. (See [Syncing items and groups](xref:Cost_Billing_Managing_Items_Groups#syncing-items-and-groups) and [Syncing billable events](xref:Cost_Billing_Managing_Billable_Events#syncing-billable-events).)

Because of the daily sync strategy, changes made in the external system during the day are not reflected in Cost & Billing until the next sync runs. If you cannot find an expected event (e.g., a job created mid-day), you can **trigger a manual sync** to reconcile all differences between the external system and Cost & Billing. Note that this may take some time depending on data volume.

Items, groups, and events that no longer exist in the external system are **not deleted** from Cost & Billing. They transition to a *Missing* state, preserving historical billing records and rate card links.
