---
uid: Cost_Billing_Architecture
---

# Architecture

Cost & Billing is a solution for managing the financial side of daily operations. It calculates both the internal cost and the customer-facing billing of operational activities, based on contracts and rate cards defined within the application.

The solution is designed to be **source-agnostic**. It operates on generic concepts that are independent of any external system. All integrations with external systems are handled by dedicated **adapters**: the adapter translates source-specific concepts into the generic Cost & Billing model. This way, the Cost & Billing core never references external modules directly. 

The Cost & Billing model currently only supports **time-based** cost and billing, but the solution is flexible enough so that if required other billing models could also be added in the future.

The available sample solution integrates with **MediaOps Plan**. Any other integration with a solution that requires time-based cost and billing calculations would require a new Adapter and Calculation Script.

## Overview

The solution is built around three clearly separated layers:

![Cost & Billing architecture overview](~/solutions/images/CostAndBilling_architecture-overview.png)


| Layer | Role |
| --- | --- |
| **Cost & Billing** | The core module. It owns the generic domain model (Items, Groups, Billable Events, Contracts and Rate cards). It is completely **source-agnostic**: it contains no references any external system. |
| **Adapter** | The component responsible for fetching data from the external system and mapping it to the Cost & Billing domain objects (e.g. resources → Items, jobs → Billable Events). The adapter is the **only** component that knows about both worlds. |
| **Third-party system** | The external operations platform (MediaOps Plan in the sample, or any equivalent solution). It acts as the source of truth for operational data that must be reflected in Cost & Billing. It is accessed exclusively through the adapter. |

This separation is the key design principle of the solution: **the Cost & Billing core never communicates directly with an external system, and external systems never touch Cost & Billing internals.** All translation happens in the adapter.

## Integrating with another solution

The sample solution with a MediaOps Plan includes a dedicated Adapter and Calculation Script, but the same Cost & Billing core supports any integration. To connect a different third-party system:

1. **Build a new adapter** for that system. Cost & Billing has a dedicated Dev Pack that will allow any new Adapter to interact with the Cost & Billing domain.
2. **Build a new calculation script** for the new integration. The calculation script created for MediaOps Plan manages basic time-based concepts. This script can be reused or customized depending on the requirements.
2. **No changes to the Cost & Billing core are required** as long as the billing model is already supported. If a new billing model is required, Cost & Billing will have to be modified directly. 

One Adapter should be developed per integration.

## Solution Components

The full component stack of the sample solution:

| Component | Description & role |
| --- | --- |
| **LCA (Low-Code App)** | The user-facing DataMiner interface. This is where users manage contracts and rate cards, browse the synced items and billable events, and calculate the cost and billing of those billable events. |
| **Interface Script** | A dedicated Automation Script that acts as the  communication layer between the LCA and whichever adapter is deployed. The LCA always calls this script; the script calls the correct adapter. This decouples the LCA from adapter-specific implementation — **swapping or adding adapters requires no changes to the LCA**. |
| **Automation Scripts** | The solution contains a series of DataMiner Automation Scripts (ad-hoc, interactive, and basic automation). These are mainly used through the LCA to retrieve data, handle user interactions such as creating or saving data, and perform logic. |
| **Cost & Billing Dev Pack** | A reusable package containing the SDM (Standard Data Model): the DOM interaction layer that provides typed read/write access to the Cost & Billing DOM instances (rate cards, contracts, items, billable events, etc.). |
| **Adapter** | The system-specific component (MediaOps Plan Adapter in the sample). Fetches external data, maps it to Cost & Billing domain objects.
| **Third-party system** | The external operations platform. Source of truth for operational data. Accessed only through the adapter. |

![Cost & Billing component stack](~/solutions/images/CostAndBilling_component-stack.png)

## Domain entities

The Cost & Billing domain model operates purely on generic concepts:

- **Item** — the individual entity that can be costed and billed. Every Item should have a **Cost Rate Card** assigned, representing its internal cost. An item carries a `category` attribute (e.g. `Resource` and `Resource Pool`); Cost & Billing stores the category as a string and uses it for default **Billing Rate card** resolution in a **Contract** without interpreting its meaning. The meaning of each category is defined by the adapter. Items are created and managed by the adapter.
- **Group** — a standalone billing entity within a Billable Event. Unlike an Item, a Group does not represent a physical resource — it exists purely as a billing unit. Each Group also carries a `category` attribute (e.g. `Workflow`). A Group can only be billed, never costed — cost is always tracked at the Item level.
- **Node** — the middle layer between a Billable Event and its Items. A Billable Event does not reference a list of Items directly; it references a list of Nodes. Each Node holds a reference to an Item and, optionally, a reference to a **parent Item**. This makes it possible to express that an Item belongs to another Item within the context of the event. In MediaOps Plan terms, a Node indicates the Item (a resource) and the parent Item (the resource pool it belongs to).
- **Cost Rate Card** — the internal cost rate for an Item (what it costs the organization), independent of any customer contract. In the time-based sample this is a rate applied against usage duration.
- **Billing Rate Card** — the customer-facing rate, always assigned within the context of a **Contract**. The same Item can carry different billing rates under different contracts. In the time-based sample this is a rate applied against the duration that an item or group was used.
- **Contract** — the commercial agreement with a customer. It defines which Items and Groups drive the billing calculation, holds Billing Rate Card assignments, specifies the billing value unit, and carries commercial rules such as uplifts and discounts.
- **Contract Rate Card Assignment** — links a Billing Rate Card to a Contract at one of three levels of granularity: a **specific Item**, a **specific Group**, or a **category** (a default for all Items or Groups of that category).
- **Value Unit** — a supported cost and billing unit (currency, token, or other unit of value) with its exchange rate relative to the nominal unit. The exchange rate applied during calculation is the one valid at the time of the Billable Event.
- **Billable Event** — the source event or period being billed, and the entry point for any calculation. A Billable Event has **Groups** and **Nodes**: the Groups represent the standalone billing entities involved, and the Nodes represent the Items used in the event (including their parent Item relationships). It stores a source reference (external ID) and source type; Cost & Billing does not interpret these — the adapter uses them to know which external event to retrieve data from.
- **Billable Item** — one calculation line within a Billable Event; one is created per Item/group and rate used in the event. BillableItems are replaced on recalculation and **frozen once the Financial Summary is finalized**, protecting the values sent to finance.

## Entity mapping - MediaOps Plan Example

Mapping between MediaOps and Cost & Billing is automatic and handled entirely by the adapter:

| MediaOps concept | Cost & Billing concept |
| --- | --- |
| Resource / Resource Pool | Item |
| Workflow | Group (category `workflow`) |
| Job | BillableEvent |

A different adapter may map entirely different source concepts to these same classes without any change to the Cost & Billing core.

## Synchronization

Synchronization between the external system and Cost & Billing is performed through the adapter and can be triggered in two ways:

- **Scheduled daily sync** — a routine that runs automatically once per day, keeping Cost & Billing up to date with the external system.
- **On-demand sync** — a button in the Cost & Billing interface that lets a user trigger a full synchronization at any time.

Because of the daily sync strategy, changes made in the external system during the day are not reflected in Cost & Billing until the next sync runs. When a user cannot find an expected event (e.g. a job created mid-day), they can **trigger a manual sync**, which reconciles all differences between the external system and Cost & Billing (this may take some time depending on data volume).

Items, groups and events that no longer exist in the external system are **not deleted** from Cost & Billing. They transition to a *Missing* state, preserving historical billing records and rate card links.

