---
uid: Cost_and_Billing_1.0.1
---

# Cost & Billing 1.0.1

## New features

### Financial configuration [ID 46283]

Cost & Billing now allows you to define the financial building blocks required to calculate internal costs and customer-facing billing for operational activities.

With this release, you can:

- Define value units (e.g., currencies), configure exchange rates, and set the nominal value unit in which final calculation results are expressed.
- Create and manage cost rate cards to define internal item costs, including support for multi-time rates, minimum time constraints, and capped rates.
- Create and manage billing rate cards, defining customer-facing charges, with the same timing and capping rules.
- Create and manage customer contracts, including validity periods, billing type (item, group, or item and group), uplift and discount percentages, rounding rules, and an optional total override amount.
- Assign billing rate cards to a contract at item level, group level, or category level (as a default for all items or groups of that category).
- Move contracts and rate cards through their lifecycle states (*Draft*, *Active*, and *Deprecated*), including bulk deprecation.

### Operational sync and calculation [ID 46284]

Cost & Billing now allows you to synchronize operational inventory from an external system and calculate cost and billing figures for each billable event.

With this release, you can:

- Synchronize items and groups from an integrated external system and assign a cost rate card to each item.
- Keep historical billing records when synced items or groups are no longer present in the external system by transitioning them to a *Missing* state instead of deleting them.
- Synchronize billable events and calculate internal cost and customer-facing billing values for each event.
- Calculate the cost and billing for a billable event at any stage of its lifecycle, based on its assigned contract and the applicable rate cards.
- Manually override the calculated cost or billing amount of an individual billable item, with the override preserved on recalculation.
- Finalize a billable event to freeze its financial summary, protecting the values sent to finance from later changes.
- View any errors encountered during calculation (e.g., missing rate card assignments) on the *Logs* page.

> [!NOTE]
> To sync items, groups, and billable events, and calculate their cost and billing, you will need an adapter and a calculation script for the external system you integrate with. A sample integration with MediaOps Plan, including a ready-to-use adapter and calculation script, is [available in the DataMiner Catalog](https://catalog.dataminer.services/details/4c6e38cd-495c-417d-bd6b-f54c4f77e407).
