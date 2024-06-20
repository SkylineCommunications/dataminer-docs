---
uid: cost_billing_billing_calculation
---

# Billing calculation

This section will cover the process by which billing is calculated.

## Stages

1. Find and check Contract
2. Calculate Sub-Total
3. Calculate fees
4. Save results

### 1. Find and Check Contract

The first step to calculate the bill for a job is to find the contract attached to the job. the contract DOM reference can be found on the Job DOM object, under the Cost and Billing section, on the Contract field.

The uplift, discount, currency fields and billing type will be read from the contract.

If the contract does not exist the billing calculation will be aborted.

If the contract is no longer valid, meaning the time of the calculation is outside the contract start date and end date, the billing calculation will be aborted.

### 2. Calculate Sub-Total

The second step to calculate the bill for a job is to calculate the sub-total. the sub-total is usually the sum of the total net amount charged by each individual node contained inside the job. a node can be a workflow or a resource. a job can have 0 to 1 workflow, and 0 to multiple resources.

A job has a (multiple) "Cost and Billing Details", each one representing the billing results for a Workflow and/or the multiple Resources of that job.

If the contract's billing type is "Workflow", only the Workflow referring in the job will be taken into account to calculate the bill.

If the contract's billing type is "Resource", then only the Resources referred in the job will be taken into account to calculate the bill.

If the contract's billing type is "Workflow+Resource", then both Workflow and Resources referred in the job will be taken into account to calculate the bill.

Calculation process to determine the total net amount for a workflow and for a resource are different.

#### Billing a workflow

##### Find Ratecard

First it will look at the contract to check if there's a ratecard attached specifically to this Workflow. If yes, that will be the ratecard used to charge this Workflow

If not, then it will look in the contract to check if there's a default Ratecard for all Workflows. If yes, that will be the ratecard used to charge this Workflow.

When a ratecard is found, the following fields will be set in the "Cost and Billind Details" section of the Job:

- **Ratecard**: The unique reference id to the ratecard being used to charge this workflow.

- **Line Item Type**: The type of the invoice line, in this case it is the "bill" text value.

- **Object Type**: The type of the object being charged, in this case it is the "workflow" text value.

- **Object ID**: The unique reference id to the object being charged, that in this case to the Workflow DOM object.

- **Description**: The name of the object being charged, that in this case is the Workflow name.

If no ratecard is found, then this Workflow cannot be charged and will be ignored in the bill.

##### Units Used

The "Units Used" is simply the job's duration in minutes (minimum chargeable time unit). It is calculated by finding the difference between the job's "end time" and job "start time" DOM fields.

When a job is confirmed, the current start and end time will be recorded as "original start time" and "original end time", which are separate DOM fields, and will never be adjusted or changed again.

If the job start and/or end time has been changed (re-scheduled) after the job has been confirmed, then the job start time will become the earliest of the "original start time" and "start time". The job's end time will be the earliest of the "original end time" and "end time".

##### Calculated Duration

The "Calculated Duration" is the "Units Used" as the Ratecard's "Minimal Time Interval" + multiples of "Minimal Time Increments" (if the "Units Used" exceeds the Minimal Time Interval) rounded up. In other words, if the "Units Used" is smaller than the Ratecard's "Minimal Time Interval", the "Calculated Duration" will be the "Minimal Time Interval". If the "Units Used" exceeds the Ratecard's "Minimal Time Interval", then the "Calculated Duration" is the "Minimal Time Interval" + an amount of "Minimal Time Increments" until the "Units Used" are covered.

##### Calculate Rates

The available Rates are found on the Ratecard and can be a combination of Daily, Hourly and Minute rates. Depending on the rates available, these will be used to charge the "Calculated Duration", starting from the highest possible time-based rate to the lowest. In other words, for a Ratecard with all three time-based rates available (Day, Hour and Minute), the Daily rate will be used to charge most of the "Calculated Duration" before exceeding it. At which point, the next biggest time-based rate (Hour) will be used to charge the remaining "Calculated Duration" before exceeding it, and until all available time-based units are exhausted and the "Calculated Duration" is completely charged.

> [!NOTE]
> The charged rates are then subject to uplift by the value stipulated by the contract.

The Rates used to charge the "Calculated Duration" are stored on the a collection of Rates (DOM Objects) referred by the "Rates" DOM field in the "Cost and Billing Details". These rates are now uplifted.

##### Total Amount and Total Net Amount

The Workflow's Total Amount is the `SUM` of all charged rates. The Workflow's Total Net Amount is the Total Amount discounted with the value stipulated by the contract.

#### Billing a Node (Resource)

##### Find Ratecard

First it will look at the contract to check if there's a ratecard attached specifically to this Resource. If yes, that will be the ratecard used to charge this Resource.

If not, then it will determine if this Resource is assigned to a Resource Pool. If it is, it will check in the Contract if that Resource Pool as a Ratecard specifically attached to it. If yes, then that will be the Ratecard used to charge this Resource.

If not, then it will look in the contract to check if there's a Default Ratecard for all Resources. If yes, that will be the ratecard used to charge this Resource.

When a ratecard is found, the following fields will be set in the "Cost and Billind Details" section of the Job:

- **Ratecard**: The unique reference id to the ratecard being used to charge this Resource.

- **Line Item Type**: The type of the invoice line, in this case it is the "bill" text value.

- **Object Type**: The type of the object being charged, in this case it is the "node" text value.

- **Object ID**: The unique reference id to the object being charged, that in this case to the Resource DOM object.

- **Description**: The name of the object being charged, that in this case is the Resource name.

If no ratecard is found, then this Workflow cannot be charged and will be ignored in the bill.

##### Units Used

The "Units Used" is simply the Resource's usage duration in minutes (minutes are the minimum chargeable time unit). It is calculated by finding the difference between the Resource's "end time" and Resource's "start time" DOM fields.

When a job's start and end time is adjusted or changes, the underlying resource nodes start and end time will be adjusted according to the job.

##### Calculated Duration

The calculated duration is determined the same way as for Worfklows.

The "Calculated Duration" is the "Units Used" as the Ratecard's "Minimal Time Interval" + multiples of "Minimal Time Increments" rounded up (if the "Units Used" exceeds the Minimal Time Interval). In other words, if the "Units Used" is smaller than the Ratecard's "Minimal Time Interval", the "Calculated Duration" will be the "Minimal Time Interval". If the "Units Used" exceeds the Ratecard's "Minimal Time Interval", then the "Calculated Duration" is the "Minimal Time Interval" + an amount of "Minimal Time Increments" until the "Units Used" are covered.

##### Calculate Rates

The calculated rates are determined the same way as for Workflows.

The available Rates are found on the Ratecard and can be a combination of Daily, Hourly and Minute rates. Depending on the rates available, these will be used to charge the "Calculated Duration", starting from the highest possible time-based rate to the lowest. In other words, for a Ratecard with all three time-based rates available (Day, Hour and Minute), the Daily rate will be used to charge most of the "Calculated Duration" before exceeding it. At which point, the next biggest time-based rate (Hour) will be used to charge the remaining "Calculated Duration" before exceeding it, and until all available time-based units are exhausted and the "Calculated Duration" is completely charged.

> [!NOTE]
> The charged rates are then subject to uplift by the value stipulated by the contract.

The Rates used to charge the "Calculated Duration" are stored on the a collection of Rates (DOM Objects) referred by the "Rates" DOM field in the "Cost and Billing Details". These rates are now uplifted.

##### Total Amount and Total Net Amount

The Resource's Total Amount is the `SUM` of all charged rates. The Workflow's Total Net Amount is the Total Amount discounted with the value stipulated by the Contract.

### 3. Calculate Fees

In addition to the Total Net Amount of all Worflows and/or Resources being charged, fees can also apply depending on how short notice the Job starts compared to its confirmation date, or on whether the job gets cancelled.

#### Speed Order Billing fees

Speed order fees apply when a Job is Confirmed late notice. The Speed order fees are documented in the Costing & Billing Contract, and depend on the amount of time between the Job Confirmation and the job Start Time or the Original Job Start Time, which ever is smallest. Consequently, the speed order time interval is calculated as:

`Speed order time interval = Min(Job Start Time, Original Job Start Time) – Confirmation Time`

If multiple Speed Order Billing fees are available in the Contract, then the Fee with the lowest amount of *Hours before event start* that is higher than the *Speed order time interval* will be selected.

`MIN (Hours before event start > Speed order time interval)`

#### Cancellation fees

Cancellation fees apply when a Job is cancelled once it has been Confirmed before. The Cancellation fees are documented in the Costing & Billing Contract, and depend on the amount of time between the Job Cancellation and the Job Start Time or the Original Job Start Time, which ever is smallest. Cancellation can only happen before a Job gets into Running state. Consequently, the cancellation time interval is calculated as:

`Cancellation time interval = Min(Job Start Time, Original Job Start Time) – Cancellation Time`

If multiple Cancellation fees are available in the Contract, then the Fee with the lowest amount of *Hours before event start* that is higher than the *Cancellation time interval* will be selected.

`MIN (Hours before event start > Cancellation time interval)`

### 4. Saving Results

Finally, the results can now be saved on the Cost and Billing section of the Job DOM object. The following fields will be filled in:

- **Speed order increment on top of billing price (%)**: This field will be set with a double value representing the percentage of the billing price additionally charged as speed order fee.

- **Speed order fixed fee**: This field will be filled with a double value representing a flat speed order fee in the currency set by the Contract.

- **Cancellation % on top of billing price**: This field will be set with a double value representing the percentage of the billing price additionally charged as a cancellation fee.

- **Cancellation fixed fee**: This field will be filled with a double value representing a flat cancellation fee in the currency set by the Contract.

- **Last bill calculation**: This field will be filled with a DateTime value containing the date and time the last billing calculation was executed.

- **Total Bill Net Amount**: This field will contain the sum of all charged rates of the Workflows and/or Resoruces, uplifted and discounted. It does not include any Speed Order Billing Fees or Cancellation Fees.

### More details about "Units Used"

### Job Units Used

- The job units used is the metric that is used as the basis duration for costing and billing calculations of the job workflows. This means that units used will be the metric representing the use of a job workflow and job node before the rate card logic is applied.

- Resource utilization is not billed during pre and post roll time intervals

- The job units used is calculated as follows:

  - `Job units used = Max(Job End Time, Job Original End Time) – Min(Job Start Time, Job Original start time)`

  - Entire effective used interval. Calculate a possible early start time after job was Confirmed, or overrun, but always the minimum the scheduled interval that was Confirmed

  - Remark : we do not have rate cards specific to Approx out units used

  - Remark : we do not charge for pre and post roll

  - In case Job was never confirmed, node units used will be zero.

### Node Units Used

The nodes units used is the metric that is used as the basis duration for costing and billing calculations of nodes.

The nodes units used is the same as the job units used in case the nodes have the same schedule as the job. Therefore:

`Node units used = Jobs units used`

Applies to nodes following the master Job schedule

Else, in case nodes have either a Node Start Time different from Job Start Time, or Node End Time different from Job End Time :

`Node units used = Node End Time – Node Start Time`

Always charge for the actual duration used or duration scheduled once Job was Confirmed)
> *Remark: we do not charge for pre and post roll.*

In case Job was never confirmed, node units used will be zero.
