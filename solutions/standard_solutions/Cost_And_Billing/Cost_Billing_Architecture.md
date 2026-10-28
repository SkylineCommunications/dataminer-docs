---
uid: Cost_Billing_Architecture
description: "Learn how the Cost & Billing architecture separates core domain objects, adapters, and external systems for source-agnostic integrations."
---

# Cost & Billing architecture

## External integration architecture

The external integration architecture of the solution is built around three clearly separated layers:

![Solution integration overview](~/solutions/images/CostAndBilling_architecture-overview.png)

| Layer | Role |
| --- | --- |
| **Cost & Billing** | The core module. It owns the generic domain model (items, groups, billable events, contracts, and rate cards). It is completely **source-agnostic**, i.e., it contains no references to any external system. This component always has to be installed, regardless of the external system being integrated. |
| **Adapter** | The component responsible for fetching data from the external system and mapping it to the Cost & Billing domain objects (e.g., resources → items, jobs → billable events). The adapter is the only component that knows about both worlds. |
| **External system** | The external operations platform (MediaOps Plan or any equivalent solution). It acts as the source of truth for operational data that must be reflected in Cost & Billing. It is accessed exclusively through the adapter. |

The Cost & Billing core **never communicates directly with an external system**, and external systems never touch Cost & Billing internals. All translation happens in the adapter.

> [!TIP]
> For more details on the external integration, refer to [Integration with other solutions](xref:Cost_Billing_Integration).

## Solution components

This is the full component stack of the solution:

| Component | Description and role |
| --- | --- |
| **Low-code app** | The user-facing DataMiner interface. This is where users manage contracts and rate cards, browse the synced items and billable events, and calculate the cost and billing of those billable events. |
| **Interface script** | A dedicated automation script that acts as the communication layer between the low-code app and whichever adapter is deployed. The low-code app always calls this script; the script calls the correct adapter. This decouples the low-code app from adapter-specific implementation, which means that **swapping or adding adapters requires no changes to the low-code app**. |
| **Automation scripts** | The solution contains a series of DataMiner automation scripts (ad hoc, interactive, and basic automation). These are mainly used through the low-code app to retrieve data, handle user interactions such as creating or saving data, and perform logic. |
| **Cost & Billing Dev Pack** | A reusable package containing the SDM (Standard Data Model): the DOM interaction layer that provides typed read/write access to the Cost & Billing DOM instances (rate cards, contracts, items, billable events, etc.). |
| **Adapter** | The system-specific component (e.g., the MediaOps Plan Adapter). Fetches external data and maps it to Cost & Billing domain objects. |
| **External system** | The external operations platform, which serves as the source of truth for operational data. Accessed only through the adapter. |

![Cost & Billing component stack](~/solutions/images/CostAndBilling_component-stack.png)

## Domain entities

The Cost & Billing domain model operates on the following generic concepts:

| Concept | Description |
| --- | --- |
| Item | The individual entity that can be costed and billed. An item should have a **cost rate card** assigned, representing its internal cost. An item also has a `category` attribute (e.g., `Resource` and `Resource Pool`). Cost & Billing stores the category as a string and uses it for default **billing rate card** resolution in a **contract** without interpreting its meaning. The meaning of each category is defined by the adapter. Items are created and managed by the adapter. |
| Group | A standalone billing entity within a billable event. Unlike an item, a group does not represent a physical resource; it exists purely as a billing unit. Each group also has a `category` attribute (e.g., `Workflow`). A group can only be billed, never costed; cost is always tracked at the item level. |
| Node | The middle layer between a billable event and its items. A billable event does not reference a list of items directly; it references a list of nodes. Each node holds a reference to an item and, optionally, a reference to a **parent item**. This makes it possible to express that an item belongs to another item within the context of the event. In MediaOps Plan terms, a node indicates the item (a resource) and the parent item (the resource pool it belongs to). |
| Cost rate card | The internal cost rate for an item (the cost to the organization), independent of any customer contract. In the time-based sample, this is a rate applied against usage duration. |
| Billing rate card | The customer-facing rate, always assigned within the context of a **contract**. The same item can carry different billing rates under different contracts. In the time-based sample, this is a rate applied against the duration that an item or group was used. |
| Contract | The commercial agreement with a customer. It defines which items and groups drive the billing calculation, holds billing rate card assignments, specifies the billing value unit, and carries commercial rules such as uplifts and discounts. |
| Contract rate card assignment | Links a billing rate card to a contract at one of three levels of granularity: a **specific item**, a **specific group**, or a **category** (a default for all items or groups of that category). |
| Value unit | A supported cost and billing unit (currency, token, or other unit of value) with its exchange rate relative to the nominal unit. The exchange rate applied during calculation is the one valid at the time of the billable event. |
| Billable event | The source event or period being billed, and the entry point for any calculation. A billable event has **groups** and **nodes**: the groups represent the standalone billing entities involved, and the nodes represent the items used in the event (including their parent item relationships). It stores a source reference (external ID) and source type; Cost & Billing does not interpret these; the adapter uses them to know which external event to retrieve data from. |
| Billable item | One calculation line within a billable event; one is created per item/group and rate used in the event. Billable items are replaced on recalculation and **frozen once the financial summary is finalized**, protecting the values sent to finance. |

## Entity mapping - MediaOps Plan example

Mapping between MediaOps and Cost & Billing is automatic and handled entirely by the adapter:

| MediaOps concept | Cost & Billing concept |
| --- | --- |
| Resource / resource pool | Item |
| Workflow | Group (category `workflow`) |
| Job | Billable event |

A different adapter may map entirely different source concepts to these same classes without any changes to the Cost & Billing core.
