---
uid: cost_billing_overview
---

# Cost and Billing

Welcome to the **Cost and Billing application**!

1. [Contracts](xref:cost_billing_contracts): Learn about contract management.
1. [Ratecards](xref:cost_billing_ratecards): Understand pricing structures.
1. [Currencies](xref:cost_billing_currencies): Explore multi-currency support.
1. [Billing Calculation](xref:cost_billing_billing_calculation): The process and components that take part in calculating the bill for a job.
1. [Cost Calculation](xref:cost_billing_cost_calculation): The process and components that take part in calculating the cost of a job.

## Features

The Cost and Billing application lets you measure, analyze, forecast and optimize cost and revenues in the heart of your operation.

### Billing

- Create **contracts** for **suppliers** and **customers**.
- Reuse contracts for **specific events**.
- Reuse contracts for **multiple customers**.
- Contracts have a **validity interval**.
- Contracts have **billing ratecards** for **workflows**, resource **pools** and even individual **resources**.
- **Ratecards** with minimal billing time interval, time based volume discounts, and pay-per-use.
- Define **uplift pricing** per contracts.
- Define **cancellation fees** per contract and late cancellation notification time. interval.

### Costing

- **Cost ratecards** with minimal cost time interval, time based volume discounts, and pay-per-use
- Can be attached to **resource pools** or individual **resources**
- DataMiner automated job scheduling **prevents unnecessary cloud cost**

### Reporting and Analysis

- **Manual** cost and billing override.
- **Extensive analysis of costing and billing** rates per contract, per customer, per workflow, per resource pool, per resource, per currency, etc...
- **Automatic generation of costing and billing details** per individual job (invoice line-items).
- Cost and Billing details on **a (shared) dashboard**.
- **User-defined currencies** and **exchange rates**.
- Share Cost and Billing details over API with **3rd party billing systems**.

In this comprehensive guide, we'll explore how to navigate contracts, understand ratecards, and manage currencies effectively. Whether you're a seasoned user or new to the system, this documentation will empower you to make informed decisions and streamline your cost and billing processes. Let's dive in!

## Data Model

### Contract

<table>
    <thead>
        <tr>
            <th>Field Name</th>
            <th>Type</th>
            <th>Description</th>
            <th>Possible Values</th>
            <th>Default Value</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td colspan=5 style="text-align:center;">Contract Info</td>
        </tr>
        <tr>
          <td>Name</td>
          <td>String</td>
          <td>The name of the contract</td>
          <td>Any alphanumeric text</td>
          <td></td>
        </tr>
        <tr>
          <td>Valid From</td>
          <td>DateTime</td>
          <td>The date and time when the contract will come into effect.</td>
          <td>Any date and time</td>
          <td></td>
        </tr>
        <tr>
          <td>Valid Until</td>
          <td>DateTime</td>
          <td>The date and time when the contract will expire.</td>
          <td>Any date and time</td>
          <td></td>
        </tr>
        <tr>
        <td colspan=5 style="text-align:center;">Billing</td>
        </tr>
        <tr>
          <td>Uplift (%)</td>
          <td>Double</td>
          <td>The amount in percentage by which the charged rates will be increased when calculating the bill.</td>
          <td>Any double precision numeric value.</td>
          <td></td>
        </tr>
        <tr>
          <td>Discount (%)</td>
          <td>Double</td>
          <td>The amount in percentage that the calculated total amount will be reduced when producing the bill.</td>
          <td>Any double precision numeric value.</td>
          <td></td>
        </tr>
        <tr>
          <td>Currency</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the currency used by this contract.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Currency.</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Speed Order Billing (multiple)</td>
        </tr>
        <tr>
          <td>Hours before event start</td>
          <td>Double</td>
          <td>The amount of time during which the job is allowed to be confirmed and started before incurring higher fees.</td>
          <td>Any double precision numeric value representing the amount of hours.</td>
          <td></td>
        </tr>
        <tr>
          <td>Fixed Fee</td>
          <td>Double</td>
          <td>The flat fee that is charged in case this speed order fee applies.</td>
          <td>Any double precision numeric value representing the amount to charge.</td>
          <td></td>
        </tr>
        <tr>
          <td>Increment on top of billing price (%)</td>
          <td>Double</td>
          <td>The percentage of the estimated total net amount to be added to the billing total in case this speed order fee applies.</td>
          <td>Any double precision numeric value</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Cancellation Fee Billing (multiple)</td>
        </tr>
        <tr>
          <td>Hours before event start</td>
          <td>Double</td>
          <td>The amount of hours before the start of the job, that is possible to cancel before incurring higher fees.</td>
          <td>Any double precision numeric value representing the amount of hours.</td>
          <td></td>
        </tr>
        <tr>
          <td>Fixed Fee</td>
          <td>Double</td>
          <td>The flat fee that is charged in case this cancellation fee applies.</td>
          <td>Any double precision numeric value representing the amount to charge.</td>
          <td></td>
        </tr>
        <tr>
          <td>Increment on top of billing price (%)</td>
          <td>Double</td>
          <td>The percentage of the estimated total net amount to be added to the billing total in case this cancellation fee applies.</td>
          <td>Any double precision numeric value</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Billing ratecards</td>
        </tr>
        <tr>
          <td>Billing type</td>
          <td>Enum</td>
          <td>Determines whether this contract will bill based on workflow only, resource only or both</td>
          <td>Workflow, Resource, Workflow+Resource</td>
          <td></td>
        </tr>
        <tr>
          <td>Default workflow ratecard</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the ratecard to be used on workflows by default.</td>
          <td>Any valid Guid identifier referring to a valid existing DOM object of type Billing Ratecard.</td>
          <td></td>
        </tr>
        <tr>
          <td>Default resource ratecard</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the ratecard to be used on resources by default.</td>
          <td>Any valid Guid identifier referring to a valid existing DOM object of type Billing Ratecard</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Workflow Specific Ratecards (multiple)</td>
        </tr>
        <tr>
          <td>Ratecard</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the ratecard to be used to describe how to charge the workflow specified on the Workflow field.</td>
          <td>Any valid Guid identifier referring to a valid existing DOM object of type Billing Ratecard.</td>
          <td></td>
        </tr>
        <tr>
          <td>Workflow</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the workflow to be charged according to the specified ratecard in the Ratecard field.</td>
          <td>Any valid Guid identifier referring to a valid existing DOM object of type Workflow</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Pool Specific Ratecards (multiple)</td>
        </tr>
        <tr>
          <td>Ratecard</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the ratecard to be used to describe how to charge the resource pool specified on the Resource Pool field.</td>
          <td>Any valid Guid identifier referring to a valid existing DOM object of type Billing Ratecard.</td>
          <td></td>
        </tr>
        <tr>
          <td>Resource Pool</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the resource pool to be charged according to the specified ratecard in the Ratecard field.</td>
          <td>Any valid Guid identifier referring to a valid existing DOM object of type Resource Pool</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Resource Specific Billing Ratecards (multiple)</td>
        </tr>
        <tr>
          <td>Ratecard</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the ratecard to be used to describe how to charge the resource specified on the Resource field.</td>
          <td>Any valid Guid identifier referring to a valid existing DOM object of type Billing Ratecard.</td>
          <td></td>
        </tr>
        <tr>
          <td>Resource</td>
          <td>Guid</td>
          <td>The unique identifier to another DOM object representing the resource to be charged according to the specified ratecard in the Ratecard field. </td>
          <td>any valid Guid identifier referring to a valid existing DOM object of type Resource.</td>
          <td></td>
        </tr>
    </tbody>
</table>

### Ratecard (Cost or Billing)

<table>
    <thead>
        <tr>
            <th>Field Name</th>
            <th>Type</th>
            <th>Description</th>
            <th>Possible Values</th>
            <th>Default Value</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td colspan=5 style="text-align:center;">Ratecard Info</td>
        </tr>
        <tr>
          <td>Name</td>
          <td>String</td>
          <td>The name of this ratecard.</td>
          <td>Any alpha numeric text representing the name of the ratecard.</td>
          <td></td>
        </tr>
        <tr>
          <td>Ratecard Currency</td>
          <td>Guid</td>
          <td>A unique identifier to another DOM object representing the currency to be used by this ratecard.</td>
          <td>A valid Guid identifier referring to a valid existing DOM object of type Currency.</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Ratecard Details</td>
        </tr>
        <tr>
          <td>Minimal time interval</td>
          <td>Double</td>
          <td>The minimum amount of time that will be charged even of the job duration is shorter.</td>
          <td>Any double precision numeric value representing the amount of time in the units specified by the Minimal time interval unit field.</td>
          <td></td>
        </tr>
        <tr>
          <td>Minimal time interval unit</td>
          <td>Enum</td>
          <td>The unit of time qualifying the minimal time interval numeric value.</td>
          <td>Min(s), Hour(s), Day(s)</td>
          <td></td>
        </tr>
        <tr>
          <td>Minimal time increment</td>
          <td>Double</td>
          <td>The increment of time in multiples of which the job duration will be charged if that duration extends beyond the minimal time interval.</td>
          <td>Any double precision numeric value representing the amount of time in the units specified by the Minimal time increment unit field.</td>
          <td></td>
        </tr>
        <tr>
          <td>Minimal time increment unit</td>
          <td>Enum</td>
          <td>The unit of time qualifying the minimal time increment numeric value.</td>
          <td>Min(s), Hour(s), Day(s)</td>
          <td></td>
        </tr>
        <tr>
          <td>Capped rate per job</td>
          <td>Double</td>
          <td>The maximum amount that will ever be charged to a job node in case the real amount exceeds it.</td>
          <td>Any double precision numeric value.</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Rates (multiple)</td>
        </tr>
        <tr>
          <td>Rate</td>
          <td>Double</td>
          <td>The amount to be charged per each unit of time that the node or workflow was in use.</td>
          <td>Any double precision numeric value.</td>
          <td></td>
        </tr>
        <tr>
          <td>Unit</td>
          <td>Enum</td>
          <td>The unit of time that qualifies the rate specified on the Rate field.</td>
          <td>Min(s), Hour(s), Day(s), Per Use</td>
          <td></td>
        </tr>
    </tbody>
</table>

### Currency

<table>
    <thead>
        <tr>
            <th>Field Name</th>
            <th>Type</th>
            <th>Description</th>
            <th>Possible Values</th>
            <th>Default Value</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td colspan=5 style="text-align:center;">Currency</td>
        </tr>
        <tr>
          <td>Currency</td>
          <td>Enum</td>
          <td>The currency ISO code.</td>
          <td>USD, EUR, GBP, etc...</td>
          <td></td>
        </tr>
        <tr>
          <td>Rate to nominal</td>
          <td>Double</td>
          <td>The rate of converstion against the currency set as nominal.</td>
          <td>Any double precision numeric value.</td>
          <td></td>
        </tr>
        <tr>
          <td>Tag</td>
          <td>String</td>
          <td>The currency ISO Code in its string format.</td>
          <td>USD, EUR, GBP, etc...</td>
          <td></td>
        </tr>
    </tbody>
</table>
