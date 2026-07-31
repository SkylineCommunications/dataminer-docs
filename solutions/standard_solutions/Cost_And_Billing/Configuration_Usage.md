---
uid: Cost_Billing_Use
---
# How to use

This section explains how to use the Cost & Billing application: from the initial configuration of value units, over the creation of ratecards and contracts, to synchronizing data from the external system and calculating the cost and billing of billable events.

After installing the solution, open the **Cost & Billing Low-Code App** in DataMiner. All configuration and day-to-day operations described below are done from this app.

## Value Units

A value unit is a unit of value in which rates and amounts are expressed — typically a currency such as USD or EUR. All value units used across the application are managed centrally on the **Value Units** page.

![Cost & Billing value units](images/value-units.png)

### Setting the nominal value unit

The first thing that must be done after installation is defining the **nominal value unit**. This is the unit in which the final cost and billing calculation results will be given.

To set the nominal value unit, click the **Set Nominal Unit** option on the page. A pop up will appear where you will be able to select the nominal unit from a drop-down menu. When finished click Save.

### Defining currency exchange rates

Ratecards and contracts in the application can be defined in different value units. However, since the final calculations are always expressed in the nominal value unit, exchange rates must be defined for every other value unit you want to use.

Only the units listed in the Value Units table will be available for selection when creating a ratecard or a contract.

To create a value unit conversion:

1. Click the **+ New Value Unit** button.
2. In the pop-up window, select the **value unit**, and fill in the **Rate to Nominal Value** (the exchange rate from this unit to the nominal value unit. X Value Unit = 1 Nominal Value Unit).
3. By default, the **state** is set to *Active*.

All value unit conversion rates are visible on the Value Units page.

### Editing and deprecating value units

Each value unit can be edited afterwards. A value unit can also be **deprecated**: a deprecated value unit can no longer be used when creating new contracts or ratecards, or when performing calculations. Value Units can also be deprecated in bulk with the action buttons: Deprecate All and Deprecate Selected.

## Ratecards

Ratecards define the rates used by the calculation. Go to the **Ratecards** page to manage all ratecards.

There are two kinds of ratecards, each with a different purpose:

- **Cost ratecards** — define the internal cost of an item (what it costs your organization).
- **Billing ratecards** — define the customer-facing rates, and are assigned to contracts.

![Cost & Billing ratecards](images/ratecards.png)

### Creating a ratecard

To create a ratecard, click **+ New Ratecard**. The following fields are available:

**General**

| Field | Description |
| --- | --- |
| **Name** | The name of the ratecard. |
| **Ratecard Type** | Whether this is a **Cost** or a **Billing** ratecard. |
| **State** | The initial state of the ratecard. Create it as **Draft** if it is not yet officially ready to be used, or directly as **Active**. |
| **Value Unit** | The value unit in which the rates of this ratecard are expressed. Only value units defined on the Value Units page are available. |

**Rules**

| Field | Description |
| --- | --- |
| **Minimum Time Interval** | The minimum duration that will be charged. If the actual usage is shorter than this interval, the minimum is charged instead. |
| **Minimum Time Increment** | The increment in which usage time is charged. Usage is rounded up to the next multiple of this increment. |
| **Capped Rate** | When enabled, the total amount calculated with this ratecard is capped at the given maximum value. |

**Rates**

Each ratecard holds one or more rates, each expressed against a **unit**: per minute, per hour, per day, or per use. Fill in the rate value and select the corresponding unit, and use **+ Add Rate** to add additional rate lines. A rate line can be removed with the **X** button.

Click **Save** to create the ratecard.

### Ratecard states

A ratecard always follows the same state flow: **Draft → Active → Deprecated**.

- **Draft** — the ratecard is being prepared and is not officially ready to be used.
- **Active** — the ratecard can be use.
- **Deprecated** — the ratecard is retired. Once a ratecard is deprecated, it can **no longer be edited or set back** to the Active or Draft state.

Ratecards can be edited as long as they are not deprecated. It is also possible to change the state of multiple selected ratecards at once through the **action buttons** on the Ratecards page.

## Contracts

On the **Contracts** page you can manage all contracts: create new ones and edit existing ones.

![Cost & Billing contracts](images/contracts.png)

### Creating a contract

To create a contract, click **+ New Contract**. The following fields are available:

**General**

| Field | Description |
| --- | --- |
| **Name** | The name of the contract. |
| **State** | The initial state of the contract (**Draft** or **Active**). |
| **Valid From / Valid Until** | The validity period of the contract. |

**Billing**

| Field | Description |
| --- | --- |
| **Billing Type** | Defines how the billing calculation is performed for this contract: based on **Items**, on **Groups**, or on **Items and Groups**. For example, with *Item*, only the items involved in a billable event are billed; with *Group*, only the groups; with *Item and Group*, both are included in the billing calculation. |
| **Uplift %** | A percentage added on top of the calculated billing total. |
| **Discount %** | A percentage subtracted from the calculated billing total. |
| **Total Override Amount** | When set, this fixed amount overrides the calculated billing total. |
| **Currency** | The value unit in which the contract is expressed. Only value units defined on the Value Units page are available. |

**Rounding**

| Field | Description |
| --- | --- |
| **Decimal Precision** | The number of decimals to which calculated amounts are rounded. |
| **Rounding Mode** | How amounts are rounded (only applicable when no decimal precision is selected). |

Click **Save** to create the contract.

### Assigning billing ratecards

For each contract, it is possible to assign the **billing ratecards** to be used in the calculation. Assignments can be made at different levels:

- **Item level** — a billing ratecard assigned to a specific item.
- **Group level** — a billing ratecard assigned to a specific group.
- **Category level** — every item and group has a category assigned. Categories can be used to define **default billing ratecards per category**, which apply to all items or groups of that category that do not have a specific assignment.

### Contract states

Contracts follow the same state flow as ratecards: **Draft → Active → Deprecated**, with the same rules — once deprecated, a contract can no longer be edited or brought back to Active or Draft. The **action buttons** on the Contracts page also allow changing the state of multiple selected contracts in bulk.

## Items & Groups

The **Items & Groups** page shows the inventory that has been brought into Cost & Billing from the third-party solution via the adapter:

- The **Items table** lists all items synced from the external system. In the sample solution integrating with MediaOps Plan, these are the **resources and resource pools**. In this table it is possible to assign a **cost ratecard** to an item.
- The **Groups table** lists all groups synced via the adapter. In the MediaOps Plan sample, these are the **workflows**.

![Cost & Billing items and groups](images/items-groups.png)

### Missing state

When an item or group is removed or deprecated in the third-party solution, it is **not deleted** in Cost & Billing. Instead, its state changes to **Missing**. This is intentional: the item or group may still be linked to an older job, and that relation must be preserved for calculation purposes.

### Syncing items and groups

The page contains a **Sync** button. Clicking it triggers the logic in the interface script, which in turn calls the adapter to synchronize with the third-party solution, keeping the inventory up to date.

## Billable Events

A **billable event** is the event being costed and billed — the entity on which the calculation is performed. On the **Billable Events** page you can manage all billable events brought in from the third-party solution. In the MediaOps Plan sample, the billable events are the **jobs**.

For each billable event, it is possible to:

- See the **linked items and groups** involved in the event.
- Perform the **cost and billing calculation**, at any stage of the billable event.

![Cost & Billing billable events](images/billable-events.png)

### Syncing billable events

The Billable Events page also contains a **Sync** button, which brings in all billable events from the third-party solution.

> **Important:** In the sample solution the sync must be performed **at least every 24 hours**. It is therefore important to schedule the execution of the sync via the **Scheduler app** in DataMiner.
>
> The reason is the following: on initial installation, the MediaOps Plan Adapter retrieves every available billable event. After that, each sync retrieves the billable events from the **last 24 hours onwards**. If more than 24 hours pass without a sync, changes that happened before that window will not be reflected in Cost & Billing.

### Calculation

To calculate the cost and billing of a billable event make sure the event has a **Contract** assigned. After this click on the corresponding Financial Summary button, this will open the Financial Summary Panel. Once open click on the button **Calculate Cost & Billing**, the details of the cost and billing will be displayed.

![Cost & Billing calculation](images/calculation.png)

#### How the calculation works

> **Note:** This section describes the calculation as implemented in the **MediaOps Plan sample calculation script**, which is **time-based**. As with the adapter, this script is specific to the MediaOps sample integration: it can be **reused as-is** for other time-based integrations, or **used as a base and customized** where a different integration needs different logic. The behavior described below reflects the sample script only — a customized script may calculate differently.

When a calculation is triggered on a billable event, the sample script produces a set of **billable items** (calculation lines) for that event: one side for **cost** (what the activity costs your organization) and one side for **billing** (what the customer is charged). The two sides are calculated independently but follow the same time-based logic.

##### Cost calculation

Cost is calculated per item of the billable event, in four steps:

1. **Resolve the cost ratecard.** For each item, the script looks for a cost ratecard assigned to the item itself. If the item has none, it falls back to the ratecard of its **parent item** (in MediaOps terms, the resource pool the resource belongs to). If neither has a cost ratecard, the item is skipped and logged as an error — it contributes nothing to the cost.
2. **Determine the charged time.** The item's real duration (end time − start time) is adjusted by the ratecard's timing rules:
   - **Minimum time interval** — the floor. Usage shorter than the interval is charged as the full interval.
   - **Minimum time increment** — the step size beyond the interval. Any excess above the interval is rounded **up** to the next whole increment.
3. **Apply the rates.** The charged time is converted into an amount using the ratecard's rates (per minute, per hour, per day). Larger units are filled first, and the smallest available unit absorbs the remainder, rounded up, so no used time is charged as zero. A **per-use** rate, if present, adds a fixed amount on top regardless of duration. If a **capped rate** is set, the item's cost cannot exceed it.
4. **Write the result.** Each rate produces a billable item line, and the lines are summed into the item's total cost.
5. **Override an item's cost (optional)**. After the calculation, the Total Calculated Amount of any billable item can be overridden manually. This value replaces that item's calculated cost entirely, and it is preserved on recalculation: when the event's total cost is computed again, the override is used in the total cost sum instead of the recalculated value.

##### Billing calculation

Billing is calculated in a similar way, but driven by the **contract** assigned to the billable event, and only if the event falls within the contract's validity period.

1. **Determine what is billed.** The contract's **billing type** decides whether billing is calculated for **Items**, **Groups**, or **Items and Groups**. With *Item and Group*, both are calculated independently and their totals are summed.
2. **Resolve the billing ratecard.** For each item or group, the script looks for a billing ratecard assignment on the contract at the most specific level available: the specific item (or its parent item), the specific group, or the **category** default. If none is found, that entry is skipped and logged as an error.
3. **Determine the charged time.** The same timing rules as the cost calculation apply — minimum time interval, minimum time increment, and capped value behave identically on the billing side.
4. **Apply the contract's commercial modifiers.** After the base amount is calculated, the contract's rules are applied:
   - **Uplift %** — a percentage increase, applied first.
   - **Discount %** — a percentage reduction, applied *after* the uplift (so `base × (1 + uplift) × (1 − discount)`).
   - **Total bill override amount** (per contract) — when set, the whole event total becomes that fixed amount and no per-entry billing is calculated.
5. **Apply rounding.** Finally, the contract's **rounding mode** (no rounding, round up, round down) and **decimal precision** are applied to each billable item and to the event total.
6. **Override an item or group billing (optional)**. After the calculation, the Total Calculated Amount of any billable item and group can be overridden manually. This value replaces that calculated bill, and it is preserved on recalculation: when the event's total bill is computed again, the override is used in the total bill sum instead of the recalculated value.

##### Currency conversion

Ratecards may be defined in a different value unit than the solution's **nominal value unit**. Any amount produced by a ratecard is converted into the nominal value unit — using the exchange rate valid at the time of the billable event — before it is written to the billable item and rolled into the event totals. This ensures every total on the event is expressed in the same nominal unit.

#### Finalize summary

After a calculation, at any point, you can mark the billable event as **Finalized** — a button available in the calculation panel. This **freezes** the calculated results: the billable event can no longer be recalculated.

This is useful when, for example, a ratecard configuration or a contract condition changes afterwards: freezing the result guarantees that such changes will not affect it. Note that this action is **irreversible** — once a billable event is Finalized, it cannot be unfrozen or recalculated, and there is no way back.