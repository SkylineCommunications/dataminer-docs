---
uid: cost_billing_cost_calculation
---

# Cost calculation

This section will cover the process by which the costing of a job is calculated.

## Stages

1. Find the Ratecard
1. Determine Units Used
1. Determine Calculated Duration
1. Calculate Rates
1. Stored results

The cost calculation consists of iterating all Resource or Resource Pool nodes in a job and calculating the cost for each one. Only Resources or Resource Pools are counted for cost calculation. In this page, Resources or Resource Pools will simply be referred to as Nodes.

### 1. Find the Ratecard

If the Node is a Resource, it will attempt to read the Cost Ratecard from the "Ratecard" field in "Resource Cost" section of a "Resource" DOM object.

If no Ratecard is found, then it will attempt to find Cost Ratecard from the parent Resource Pool of this Resource. This Ratecard will be read out from the "Ratecard" field inside the "Resource Pool Cost" section inside the "Resource Pool" DOM object.

If no Ratecard is still not found, then the Cost calculation will be aborted.

If the Node is a Resource Pool, it will attempt to read the Cost Ratecard from the "Ratecard" field inside the "Resource Pool Cost" section of the "Resource Pool" DOM object.

When a Ratecard is found, the following fields will be set in the "Cost and Billind Details" section of the Job:

- **Ratecard**: The unique reference id to the ratecard being used to charge this node.

- **Line Item Type**: The type of the invoice line, in this case it is the "cost" text value.

- **Object Type**: The type of the object being charged, in is always "node" value when calculating cost.

- **Object ID**: The unique reference id to the object being charged, that in this case to the Node DOM object.

- **Description**: The name of the object being charged, that in this case is the Node name.

- **Currency**: The currency specified in the Ratecard used to charge this node.

If no ratecard is found, then this Workflow cannot be charged and will be ignored in the bill.

### 2. Determine Units Used

The "Units Used" is simply the node's usage duration in minutes (minimum chargeable time unit). It is calculated by finding the difference between the node's "end time" and node's "start time" DOM fields.

### 3. Determine Calculated Duration

The "Calculated Duration" is the "Units Used" as the Ratecard's "Minimal Time Interval" + multiples of "Minimal Time Increments" rounded up (if the "Units Used" exceeds the Minimal Time Interval). In other words, if the "Units Used" is smaller than the Ratecard's "Minimal Time Interval", the "Calculated Duration" will be the "Minimal Time Interval". If the "Units Used" exceeds the Ratecard's "Minimal Time Interval", then the "Calculated Duration" is the "Minimal Time Interval" + an amount of "Minimal Time Increments" until the "Units Used" are covered.

### 4. Calculate Rates

The available Rates are found on the Ratecard and can be a combination of Daily, Hourly and Minute rates. Depending on the rates available, these will be used to charge the "Calculated Duration", starting from the highest possible time-based rate to the lowest. In other words, for a Ratecard with all three time-based rates available (Day, Hour and Minute), the Daily rate will be used to charge most of the "Calculated Duration" before exceeding it. At which point, the next biggest time-based rate (Hour) will be used to charge the remaining "Calculated Duration" before exceeding it, and until all available time-based units are exhausted and the "Calculated Duration" is completely charged.

### 5. Stored Results

The Rates used to charge the "Calculated Duration" for this node are stored on the a collection of Rates (DOM Objects) referred by the "Rates" DOM field in the "Cost and Billing Details" of this job.
