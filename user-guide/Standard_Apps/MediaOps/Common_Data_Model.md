---
uid: CDM
---

# Common Data Model (CDM)

Several low-code apps available in the DataMiner Catalog, including all MediaOps applications, are built on the Common Data Model (CDM). In this model, each object is described by a definition.

Definitions that are functionally related are grouped into modules. Below is an overview of the different modules.

### Contracts

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Contract Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>The name of the contract</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Valid from</td>
			<td>DateTime</td>
			<td> The date and time when the contract will come into effect.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Valid until</td>
			<td>DateTime</td>
			<td>The date and time when the contract will expire.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Billing</td>
		</tr>
		<tr>
			<td>Uplift (%)</td>
			<td>Double</td>
			<td>The amount in percentage by which the charged rates will be increased when calculating the bill.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Discount (%)</td>
			<td>Double</td>
			<td>The amount in percentage that the calculated total amount will be reduced when producing the bill.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Currency</td>
			<td>Guid</td>
			<td>A reference to another DOM object representing the currency used by this contract.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Speed order billing</td>
		</tr>
		<tr>
			<td>Hours before event start</td>
			<td>Double</td>
			<td>The amount of time during which the job is allowed to be confirmed and started before incurring higher fees.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Fixed fee</td>
			<td>Double</td>
			<td>The flat fee that is charged in case this speed order fee applies.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Increment on top of billing price (%)</td>
			<td>Double</td>
			<td>The percentage of the estimated total net amount to be added to the billing total in case this speed order fee applies.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Cancellation fee billing</td>
		</tr>
		<tr>
			<td>Hours before event start</td>
			<td>Double</td>
			<td>The amount of hours before the start of the job, that is possible to cancel before incurring higher fees.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Fixed fee</td>
			<td>Double</td>
			<td>The flat fee that is charged in case this cancellation fee applies.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>% of billing price</td>
			<td>Double</td>
			<td>The percentage of the estimated total net amount to be added to the billing total in case this cancellation fee applies.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Billing rate cards</td>
		</tr>
		<tr>
			<td>Billing type</td>
			<td>GenericEnum`1</td>
			<td>Determines whether this contract will bill based on workflow only, resource only or both</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Default workflow ratecard</td>
			<td>Guid</td>
			<td>The unique identifier to another DOM object representing the ratecard to be used on workflows by default.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Default resource ratecard</td>
			<td>Guid</td>
			<td>The unique identifier to another DOM object representing the ratecard to be used on resources by default.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow specific billing ratecards</td>
		</tr>
		<tr>
			<td>Ratecard</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Workflow</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Pool specific billing ratecards</td>
		</tr>
		<tr>
			<td>Ratecard</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Resource Pool</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource specific billing ratecards</td>
		</tr>
		<tr>
			<td>Ratecard</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Reource</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">[Obsolete] Costing</td>
		</tr>
		<tr>
			<td>Currency</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Cost Ratecards

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td> The name of this ratecard.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Ratecard currency</td>
			<td>Guid</td>
			<td>A unique identifier to another DOM object representing the currency to be used by this ratecard.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard Details</td>
		</tr>
		<tr>
			<td>Minimal time interval</td>
			<td>Double</td>
			<td>The minimum amount of time that will be charged even of the job duration is shorter.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time interval unit</td>
			<td>GenericEnum`1</td>
			<td> The unit of time qualifying the minimal time interval numeric value.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment</td>
			<td>Double</td>
			<td>The increment of time in multiples of which the job duration will be charged if that duration extends beyond the minimal time interval.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment unit</td>
			<td>GenericEnum`1</td>
			<td>The unit of time qualifying the minimal time increment numeric value.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Capped rate per job</td>
			<td>Double</td>
			<td>The maximum amount that will ever be charged to a job node in case the real amount exceeds it.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Rates</td>
		</tr>
		<tr>
			<td>Rate</td>
			<td>Double</td>
			<td>The amount to be charged per each unit of time that the node or workflow was in use.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Unit</td>
			<td>GenericEnum`1</td>
			<td> The unit of time that qualifies the rate specified on the Rate field.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Billing Ratecards

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td> The name of this ratecard.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Ratecard currency</td>
			<td>Guid</td>
			<td>A unique identifier to another DOM object representing the currency to be used by this ratecard.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard Details</td>
		</tr>
		<tr>
			<td>Minimal time interval</td>
			<td>Double</td>
			<td>The minimum amount of time that will be charged even of the job duration is shorter.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time interval unit</td>
			<td>GenericEnum`1</td>
			<td> The unit of time qualifying the minimal time interval numeric value.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment</td>
			<td>Double</td>
			<td>The increment of time in multiples of which the job duration will be charged if that duration extends beyond the minimal time interval.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment unit</td>
			<td>GenericEnum`1</td>
			<td>The unit of time qualifying the minimal time increment numeric value.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Capped rate per job</td>
			<td>Double</td>
			<td>The maximum amount that will ever be charged to a job node in case the real amount exceeds it.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Rates</td>
		</tr>
		<tr>
			<td>Rate</td>
			<td>Double</td>
			<td>The amount to be charged per each unit of time that the node or workflow was in use.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Unit</td>
			<td>GenericEnum`1</td>
			<td> The unit of time that qualifies the rate specified on the Rate field.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### App Data

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">App Data Currencies</td>
		</tr>
		<tr>
			<td>Nominal Currency</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Currencies

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Currency</td>
		</tr>
		<tr>
			<td>Currency</td>
			<td>GenericEnum`1</td>
			<td>The currency ISO code</td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Rate to nominal</td>
			<td>Double</td>
			<td> The rate of converstion against the currency set as nominal.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Tag</td>
			<td>String</td>
			<td>The currency ISO Code in its string format.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Capability

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Capability info</td>
		</tr>
		<tr>
			<td>Capability name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Capability type</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### CapabilityEnumValue

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Capability enum value details</td>
		</tr>
		<tr>
			<td>Capability</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Value</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### ResourceProperty

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Property info</td>
		</tr>
		<tr>
			<td>Property name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Capacity

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Capacity info</td>
		</tr>
		<tr>
			<td>Capacity name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Units</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Min. Range</td>
			<td>Double</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Step size</td>
			<td>Double</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Max. Range</td>
			<td>Double</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Decimals</td>
			<td>Int64</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### ResourcePool

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource pool info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Allow bookings on pool level</td>
			<td>Boolean</td>
			<td>Indicates if the pool is bookable in case it does not matter what actual resource in the pool is booked</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Error details</td>
			<td>String</td>
			<td>Details in case an error occurs in synchronizing with DMA</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Domain</td>
			<td>Guid</td>
			<td>Pools can be grouped into domains for filtering purposes in certain apps</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource pool cost</td>
		</tr>
		<tr>
			<td>Cost ratecard</td>
			<td>Guid</td>
			<td>Default ratecard for all resource in the pool to calculate cost of usage</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource pool internal properties</td>
		</tr>
		<tr>
			<td>resource_ids</td>
			<td>String</td>
			<td>comma separated list of guids of resource DOMs that belong to the resource pool</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>pool_resource_id</td>
			<td>Guid</td>
			<td>guid of the resource in dataminer representing the pool in case the pool is bookable</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>resource_pool_id</td>
			<td>String</td>
			<td>guid of the resource pool in dataminer</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource pool capabilities</td>
		</tr>
		<tr>
			<td>capability</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>capability_enum_values</td>
			<td>List`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>capability_string_value</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource pool links</td>
		</tr>
		<tr>
			<td>Linked resource pool</td>
			<td>Guid</td>
			<td>When booking the current resource pool , a resource from the linked resource pool will also need to be booked (automatic or manual)</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource selection type</td>
			<td>GenericEnum`1</td>
			<td>Should a resource from the linked resource pool be selected automatically or manually selected by the user?</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">External metadata</td>
		</tr>
		<tr>
			<td>Module Id</td>
			<td>String</td>
			<td>The module id of the DOM definition that the resource was created for</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>DOM instance id</td>
			<td>String</td>
			<td>the DOM instance id of the instance that the resource was created from</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Error script</td>
			<td>String</td>
			<td>Name of automation script to execute when error occurs in managing the resource in Resource Studio</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Externally managed</td>
			<td>Boolean</td>
			<td>Indicates if this resource was created from another app or managed solely  by resource studio</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Booking Extension Script</td>
			<td>String</td>
			<td>Script which will be triggered when the current resource is being booked. This allows to include related resources into the same booking based on predefined relations or custom logic. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Resource

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Type</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Error details</td>
			<td>String</td>
			<td>Details in case an error occurs while synchronizing with DMA</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Favourite</td>
			<td>Boolean</td>
			<td>Indicates that this resource can be used as a default for resource duplication/bulk creation</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Pending</td>
			<td>Boolean</td>
			<td>Indicates if the resource is already in place or not. To be used for resources that will become available in the future, but can already be added to jobs in the future. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Element</td>
			<td>String</td>
			<td>If resource is of type Element, select a specific element to link the resource to</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Service</td>
			<td>String</td>
			<td>If resource is of type Service, define a specific service to link the resource to</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Concurrency</td>
			<td>Int64</td>
			<td>indicates how many times this resource can be booked during the same time interval</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Link details</td>
			<td>String</td>
			<td>summarizes how the resource is linked (to an element, function...)</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource internal properties</td>
		</tr>
		<tr>
			<td>pool_ids</td>
			<td>String</td>
			<td>comma separated list of guids of resource pool DOMs to which the resource belongs</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>resource_id</td>
			<td>Guid</td>
			<td>resource in DataMiner</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Function Name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Function Table Index</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Protocol Name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource Metadata</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource connection management</td>
		</tr>
		<tr>
			<td>input vSGs</td>
			<td>Guid</td>
			<td>link resource to input virtual signal groups that can be used to setup connections to the resource</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>output vSGs</td>
			<td>Guid</td>
			<td>link resource to input virtual signal groups that can be used to output connections from the resource</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource capacities</td>
		</tr>
		<tr>
			<td>Capacity</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Capacity value</td>
			<td>Double</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource properties</td>
		</tr>
		<tr>
			<td>Property</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Property value</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource control</td>
		</tr>
		<tr>
			<td>Automation script name</td>
			<td>String</td>
			<td>Specify script to configure resource ad-hoc</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource cost</td>
		</tr>
		<tr>
			<td>Cost</td>
			<td>Double</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Cost unit</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Currency</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Cost ratecard</td>
			<td>Guid</td>
			<td>Used to calculate cost of resource usage. If not defined, the ratecard assigned on pool level will be used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource hierachy</td>
		</tr>
		<tr>
			<td>contains</td>
			<td>List`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>capacity</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>contained capacity value</td>
			<td>Int64</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource other</td>
		</tr>
		<tr>
			<td>Icon image</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>URL</td>
			<td>String</td>
			<td>link to visio or monitoring page for resource</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Capability enum value details</td>
		</tr>
		<tr>
			<td>Capability</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Value</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Capability info</td>
		</tr>
		<tr>
			<td>Capability name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Capability type</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">External metadata</td>
		</tr>
		<tr>
			<td>Module Id</td>
			<td>String</td>
			<td>The module id of the DOM definition that the resource was created for</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>DOM instance id</td>
			<td>String</td>
			<td>the DOM instance id of the instance that the resource was created from</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Error script</td>
			<td>String</td>
			<td>Name of automation script to execute when error occurs in managing the resource in Resource Studio</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Externally managed</td>
			<td>Boolean</td>
			<td>Indicates if this resource was created from another app or managed solely  by resource studio</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Booking Extension Script</td>
			<td>String</td>
			<td>Script which will be triggered when the current resource is being booked. This allows to include related resources into the same booking based on predefined relations or custom logic. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Slots

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Slot</td>
		</tr>
		<tr>
			<td>Transponder</td>
			<td>Guid</td>
			<td>A link to the Satellite DOM instance to which this slot belongs.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Transponder Plan</td>
			<td>Guid</td>
			<td>A link to the DOM instance that represents to which Beam the transponder belongs.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Slot name</td>
			<td>String</td>
			<td>A system name for the generated Slot. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Slot size</td>
			<td>String</td>
			<td>Shows the size of the slot as generated by the Transponder Plan. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Center frequency</td>
			<td>String</td>
			<td>Indicates the starting frequency value of this transponder.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Slot start frequency</td>
			<td>String</td>
			<td>The frequency at which this slot starts.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Slot end frequency</td>
			<td>String</td>
			<td>The frequency at which this slot ends.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource</td>
			<td>Guid</td>
			<td>A link to the Resource DOM instance that was created for this Slot.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Transponder Plans

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Transponder Plan</td>
		</tr>
		<tr>
			<td>Plan name</td>
			<td>String</td>
			<td>A meaningful name for this plan such as “Standard C Band 36MHz.”</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Applied transponder IDs</td>
			<td>String</td>
			<td>Stores a CSV value.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Slot Definition</td>
		</tr>
		<tr>
			<td>Definition Slot name</td>
			<td>String</td>
			<td>A name for this slot definition.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Definition Slot size</td>
			<td>Double</td>
			<td>Defined the size of slot that will be created. For ex., if the slots size is 9MHz and this plan is applied to a full transponder, four 9MHz slots would be created.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Relative start frequency</td>
			<td>Double</td>
			<td>This value provides an offset from the transponder’s start frequency where the slots will start to be generated. For ex., if you want slots to only be created on the bottom half of a 36MHz transponder, this Relative start frequency would be 18.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Relative end frequency</td>
			<td>Double</td>
			<td>Similar to the Relative start frequency, this value is an offset from the transponders start frequency at which point the slots will stop being built. For ex., if the Relative start frequency is 0 and the Relative end frequency is 18, slots will only be built for the first 18 units of the transponder.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Beams

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Beam</td>
		</tr>
		<tr>
			<td>Beam name</td>
			<td>String</td>
			<td>A descriptive name of the Beam. For ex., AMC 11 – C Band Americas.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Beam Satellite</td>
			<td>Guid</td>
			<td>A link to the Satellite DOM instance for this beam.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Link type</td>
			<td>GenericEnum`1</td>
			<td>An enumeration that describes if this is a Feeder or User type.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Transmission type</td>
			<td>GenericEnum`1</td>
			<td>Describes if this beam is a Transmit, Receive or Carrier in Carrier type beam.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Footprint file</td>
			<td>String</td>
			<td>Stores the KML file used to visualize the beam on a map.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Transponders

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Transponder</td>
		</tr>
		<tr>
			<td>Transponder Satellite</td>
			<td>Guid</td>
			<td>A link to the Satellite DOM instance for this Transponder.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Beam</td>
			<td>Guid</td>
			<td>A link to the DOM instance that represents to which Beam the transponder belongs.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Transponder name</td>
			<td>String</td>
			<td>The name of the transponder. For ex, Galaxy 19 T01.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Band</td>
			<td>GenericEnum`1</td>
			<td>Indicates what band the Transponder operates on, such as C Band or Ku Band.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bandwidth</td>
			<td>Double</td>
			<td>Describes how much bandwidth is available on the transponder.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Start frequency</td>
			<td>Double</td>
			<td>Indicates the starting frequency value of this transponder.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Stop frequency</td>
			<td>Double</td>
			<td>Indicates the ending frequency of this transponder.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Polarization</td>
			<td>GenericEnum`1</td>
			<td>Describes the polarization of this transponder.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Satellites

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">General</td>
		</tr>
		<tr>
			<td>Satellite name</td>
			<td>String</td>
			<td>The full name of the Satellite that will be the primary reference throughout the application.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Satellite abbreviation</td>
			<td>String</td>
			<td>A short abbreviation (3-5 characters are suggested) that will be used to reference this satellite when a shorter name reference is needed like when building slot names. For ex., Galaxy 19 might be shortened to G19 or GAL19.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Orbit</td>
			<td>GenericEnum`1</td>
			<td>An enumeration describing the type of orbit the satellite uses.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Hemisphere</td>
			<td>GenericEnum`1</td>
			<td>Indicates which hemisphere the satellite is in.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Azimuth</td>
			<td>String</td>
			<td>The horizontal position of the satellite.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Longitude for GEO (degrees)</td>
			<td>Double</td>
			<td>The satellite’s position in the Geostationary orbit.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Inclination (degrees)</td>
			<td>Double</td>
			<td>The angle of the satellite’s orbital plan and the plane of the equator.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Satellite</td>
		</tr>
		<tr>
			<td>Operator</td>
			<td>String</td>
			<td>The company that operates the Satellite.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Coverage</td>
			<td>String</td>
			<td>A description of the satellite’s coverage area.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Applications</td>
			<td>String</td>
			<td>Describes the general application for this satellite.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Info</td>
			<td>String</td>
			<td>Other information relevant to the satellite.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Origin</td>
		</tr>
		<tr>
			<td>Manufacturer</td>
			<td>String</td>
			<td>The name of the manufacturer of the satellite.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Country</td>
			<td>String</td>
			<td>The country from which the satellite originated.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Launch Information</td>
		</tr>
		<tr>
			<td>Launch info</td>
			<td>String</td>
			<td>Information related to the launch of the satellite, such as the vehicle or flight number.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Launch in service date</td>
			<td>DateTime</td>
			<td>The date the satellite was put into service.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Experience

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Experience information</td>
		</tr>
		<tr>
			<td>Experience</td>
			<td>String</td>
			<td>i.e. Junior, Senior, Manager, etc...</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Skills

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Skill information</td>
		</tr>
		<tr>
			<td>Skill</td>
			<td>String</td>
			<td>i.e. Producer, Director, Video Editor, Audio Mixer, etc...</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Category

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Category information</td>
		</tr>
		<tr>
			<td>Category</td>
			<td>String</td>
			<td>i.e. Software Company, Social Media, Production Studio, etc...</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Role

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Role Information</td>
		</tr>
		<tr>
			<td>Role</td>
			<td>String</td>
			<td>The role a contact takes when assigned to a team</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### People

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">People information</td>
		</tr>
		<tr>
			<td>Full name</td>
			<td>String</td>
			<td>This contact's full name</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Personal skills</td>
			<td>Guid</td>
			<td>i.e. Producer, Director, Video Editor, Audio Mixer</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Experience level</td>
			<td>Guid</td>
			<td>i.e. Junior, Senior, Manager, etc...</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Contact info</td>
		</tr>
		<tr>
			<td>Email</td>
			<td>String</td>
			<td>This contact's email address</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Phone</td>
			<td>String</td>
			<td>This contact's phone number</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Street address</td>
			<td>String</td>
			<td>This contact's current residing street address</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>City</td>
			<td>String</td>
			<td>This contact's current residing city</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Zip</td>
			<td>Int64</td>
			<td>This contact's current zip code</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Country</td>
			<td>GenericEnum`1</td>
			<td>This contact's current residing country</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Organization</td>
		</tr>
		<tr>
			<td>Organization</td>
			<td>Guid</td>
			<td>This contact's current organization</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Team</td>
		</tr>
		<tr>
			<td>Team</td>
			<td>Guid</td>
			<td>This contact's team membership</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Team role</td>
			<td>Guid</td>
			<td>This contact's current role in the specified team</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource</td>
		</tr>
		<tr>
			<td>Linked resource</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Teams

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Team information</td>
		</tr>
		<tr>
			<td>Team name</td>
			<td>String</td>
			<td>This team's name</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Team email</td>
			<td>String</td>
			<td>This team's email address</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Team description</td>
			<td>String</td>
			<td>What does this team do?</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Team expertise(s)</td>
			<td>Guid</td>
			<td>i.e. Video Editing, Audio Mixing, Contribution, OTT</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bookable</td>
			<td>Boolean</td>
			<td>Can this team's time be booked and scheduled?</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource Pool</td>
		</tr>
		<tr>
			<td>Linked Resource Pool</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Collaboration</td>
		</tr>
		<tr>
			<td>Create MS teams channel</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Create MS team</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>MS team name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Channel id</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Team id</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Expertises

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Expertise information</td>
		</tr>
		<tr>
			<td>Expertise</td>
			<td>String</td>
			<td>i.e. Video Editing, Audio Mixing, Contribution, OTT, etc...</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Organizations

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Organization information</td>
		</tr>
		<tr>
			<td>Organization name</td>
			<td>String</td>
			<td>The name of this organization</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Category</td>
			<td>Guid</td>
			<td>i.e. Software Company, Social Media, Production Studio, etc...</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Contracts</td>
		</tr>
		<tr>
			<td>Contract</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bill to</td>
			<td>Guid</td>
			<td>The billing contact for this contract</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Workflows

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow Info</td>
		</tr>
		<tr>
			<td>Workflow name</td>
			<td>String</td>
			<td>A short name for the Workflow. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Workflow description</td>
			<td>String</td>
			<td>A description of the Workflow that could include what the workflow does, steps, etc. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Favorite</td>
			<td>Boolean</td>
			<td>Flag that indicates if this Workflow is a favorite. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Priority</td>
			<td>GenericEnum`1</td>
			<td>Describes the relative importance of the Workflow.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow Execution</td>
		</tr>
		<tr>
			<td>Workflow execution script</td>
			<td>String</td>
			<td>Can optionally be used to specify a script that should be triggered when this workflow is executed</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Monitoring Settings</td>
		</tr>
		<tr>
			<td>At job start</td>
			<td>GenericEnum`1</td>
			<td>Determines if and when a service will be created for this workflow. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>At job end</td>
			<td>GenericEnum`1</td>
			<td>If a service was created for this workflow, should it be deleted.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service template</td>
			<td>String</td>
			<td>The name of the Service Template that will be used to create a service when the Workflow is run. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service ID</td>
			<td>String</td>
			<td>The ID of the service associated to this Job. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Nodes</td>
		</tr>
		<tr>
			<td>Node ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this Node within the Job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node alias</td>
			<td>String</td>
			<td>Allows the user to provide a more user friendly name for the node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node type</td>
			<td>GenericEnum`1</td>
			<td>Specifies the category or function of a node within a Job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the resource, resource pool, etc that this node represents. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node parent reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the parent resource, resource pool, etc that this node represents. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node icon</td>
			<td>String</td>
			<td>The name of the Icon that will be used for the Workflow visualization.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Automatic configuration?</td>
			<td>Boolean</td>
			<td>Indicates if the Node needs to be configured when the Job is run.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Configuration parameters</td>
			<td>String</td>
			<td>A JSON defining a list of configuration parameters and values for elements and virtual functions for the user to set. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Ad-hoc control script</td>
			<td>String</td>
			<td>Is an automation script name that will be run to configure this node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Visualization order</td>
			<td>Int64</td>
			<td>Controls the order in which the Nodes are shown in the visualization. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration execution order</td>
			<td>Int64</td>
			<td>Indicates the order in which the Nodes will be configured. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Manual configuration complete?</td>
			<td>Boolean</td>
			<td>This flag is TRUE if the node still need some sort of manual configuration applied. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Reserve node?</td>
			<td>Boolean</td>
			<td>If checked, a booking will be created for this Node and therefore guarantee reource availability. Leave unchecked if the Node doesn't require a booking.  </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Hidden?</td>
			<td>Boolean</td>
			<td>When makred TRUE, this node will be reserved as part of the booking, however it will not be shown as part of the Job, nor will it factor in the calculation of rates or costs. </td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Capability requirements</td>
			<td>String</td>
			<td>Specifies which capabilities are requried for this node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Capacity requirements</td>
			<td>String</td>
			<td>Specifies who much capacity will be consumed for this node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node start time</td>
			<td>DateTime</td>
			<td>If different from the Job Start time, the time when the resource started being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node end time</td>
			<td>DateTime</td>
			<td>If different from the Job End time, the time when the resource was finished being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Linked booking IDs</td>
			<td>String</td>
			<td>If the Node resource has an associated SRM Booking, this field stores the Booking ID from SRM. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select mode</td>
			<td>GenericEnum`1</td>
			<td>Indicates how and at what time the resource assignment is expected to be done</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select state</td>
			<td>GenericEnum`1</td>
			<td>Indicates in what state the resource selection process is</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Connections</td>
		</tr>
		<tr>
			<td>Connection ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this Edge within the Workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Source node ID</td>
			<td>String</td>
			<td>The ID of the Node that is the Source of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination node ID</td>
			<td>String</td>
			<td>The ID of the Node that is the Destination of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection alias</td>
			<td>String</td>
			<td>An optional user friendly name for the connection should the user wish to provide one. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution order</td>
			<td>Int64</td>
			<td>Indicates the oder in which the connections will be made. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection type</td>
			<td>GenericEnum`1</td>
			<td>Defines if this connection will be made based on the levels or the tags of its source and destination</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection subtype</td>
			<td>GenericEnum`1</td>
			<td>Further specifies how connection will be made. 'All': all matching levels or tags between source node and destination node will be connected. 'Predefined subset': only valid for level-based connections. In this case, only a subset of the matching levels between source node and destination node will be connected, for example all audio levels. 'Custom subset': the subset of matching levels or tags that will be connected can be freely defined, for example level three to five. Shuffle: levels or tags can be freely mapped from source to destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Predefined subset</td>
			<td>GenericEnum`1</td>
			<td>In case of a level-based connection of subtype 'predefined subset', this indicates the subset of levels to be used. This subset is combination of all video levels ('V'), all audio levels ('A') and/or all data levels ('D').</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection Details</td>
			<td>String</td>
			<td>In case of a 'custom subset' or 'shuffle' connection, this field contains the exact mapping of levels or tags between source and destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution script</td>
			<td>String</td>
			<td>Can optionally be used to specify a script that should be used when setting up this connection during during execution of the workfow or job</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Job Statuses

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job States</td>
		</tr>
		<tr>
			<td>Job State</td>
			<td>String</td>
			<td>A user defined Job Status that allows more customization over how Jobs are processed.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job DOM state</td>
			<td>GenericEnum`1</td>
			<td>User defined status for a job. The job DOM state is the base job state that this userdefined job status maps to. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Default</td>
			<td>Boolean</td>
			<td>The default state to set on creation of a job</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Active</td>
			<td>Boolean</td>
			<td>Only active states will be available on the job</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Session Data

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Session Data User</td>
		</tr>
		<tr>
			<td>user</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Session Data Store</td>
		</tr>
		<tr>
			<td>Job Id</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Session Filter</td>
		</tr>
		<tr>
			<td>Filter Type</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Filter Key</td>
			<td>String</td>
			<td>Guid of the DOM instance which represents the key we are filtering on</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Filter Values</td>
			<td>String</td>
			<td>Values to filter on (comma separated list of DOM guids)  </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### App Settings

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job Settings</td>
		</tr>
		<tr>
			<td>Job id prefix</td>
			<td>String</td>
			<td>The prefix is a string that will be pre-pended to each Job ID</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job id minimum digits</td>
			<td>Int64</td>
			<td>Defines the minimum number of digits in the auto generated value. Values should be limited between 1 and 20</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job id starting seed</td>
			<td>Int64</td>
			<td>Provides the "starting seed" when first configuring the Job IDs</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job id increment</td>
			<td>Int64</td>
			<td>an integer that defines the increment in which the auto generated ID increases. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job id next sequence</td>
			<td>Int64</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Jobs

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job Info</td>
		</tr>
		<tr>
			<td>Job ID</td>
			<td>String</td>
			<td>Human-readable ID of a job, auto-generated for each job instance in a certain format, e.g. SLC_0001.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Name</td>
			<td>String</td>
			<td>A short name for the Job. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Job Description</td>
			<td>String</td>
			<td>A description of the Workflow that could include what the workflow does, steps, etc.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Workflow</td>
			<td>Guid</td>
			<td>If the job was created starting from a workflow, this field links to that workflow object.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Status</td>
			<td>Guid</td>
			<td>The user defined status value indicting where in it's life cycle a job is at. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Start</td>
			<td>DateTime</td>
			<td>The time the Job starts. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Job End</td>
			<td>DateTime</td>
			<td>The time the Job ends. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Approx out duration</td>
			<td>TimeSpan</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Approx out time</td>
			<td>DateTime</td>
			<td>Optional time that could be used at the end of a Job if the Job goes longer than the scheduled End Time. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Priority</td>
			<td>GenericEnum`1</td>
			<td>Describes the relative importance of the Job. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Recurrence</td>
			<td>Guid</td>
			<td>If the job is part of a recurrence, this field links to that specific recurrence.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Source</td>
			<td>String</td>
			<td>Tracks the source of a Job. Potential values would be from a user, from the API, from an element, etc. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Notes</td>
			<td>String</td>
			<td>General note field to communicate on anything job related</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Original Job Start</td>
			<td>DateTime</td>
			<td>The start date/time of the job at the time of job confirmation</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Original Job End</td>
			<td>DateTime</td>
			<td>The end date/time of the job at the time of job confirmation</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Confirmation</td>
			<td>DateTime</td>
			<td>The date/time the job was set to confirmed</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Cancellation</td>
			<td>DateTime</td>
			<td>The date/time the job was canceled</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Action Status</td>
			<td>GenericEnum`1</td>
			<td>Indicates if the job still needs manual resource selection</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Monitoring Settings</td>
		</tr>
		<tr>
			<td>At job start</td>
			<td>GenericEnum`1</td>
			<td>Determines if and when a service will be created for this workflow. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>At job end</td>
			<td>GenericEnum`1</td>
			<td>If a service was created for this workflow, should it be deleted.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service template</td>
			<td>String</td>
			<td>The name of the Service Template that will be used to create a service when the Workflow is run. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service ID</td>
			<td>String</td>
			<td>The ID of the service associated to this Job. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job Execution </td>
		</tr>
		<tr>
			<td>Job Execution</td>
			<td>String</td>
			<td>A script that will be run when the Job is started. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Nodes</td>
		</tr>
		<tr>
			<td>Node ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this Node within the Job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node alias</td>
			<td>String</td>
			<td>Allows the user to provide a more user friendly name for the node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node type</td>
			<td>GenericEnum`1</td>
			<td>Specifies the category or function of a node within a Job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the resource, resource pool, etc that this node represents. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node parent reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the parent resource, resource pool, etc that this node represents. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node icon</td>
			<td>String</td>
			<td>The name of the Icon that will be used for the Workflow visualization.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Automatic configuration?</td>
			<td>Boolean</td>
			<td>Indicates if the Node needs to be configured when the Job is run.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Configuration parameters</td>
			<td>String</td>
			<td>A JSON defining a list of configuration parameters and values for elements and virtual functions for the user to set. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Ad-hoc control script</td>
			<td>String</td>
			<td>Is an automation script name that will be run to configure this node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Visualization order</td>
			<td>Int64</td>
			<td>Controls the order in which the Nodes are shown in the visualization. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration execution order</td>
			<td>Int64</td>
			<td>Indicates the order in which the Nodes will be configured. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Manual configuration complete?</td>
			<td>Boolean</td>
			<td>This flag is TRUE if the node still need some sort of manual configuration applied. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Reserve node?</td>
			<td>Boolean</td>
			<td>If checked, a booking will be created for this Node and therefore guarantee reource availability. Leave unchecked if the Node doesn't require a booking.  </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Hidden?</td>
			<td>Boolean</td>
			<td>When makred TRUE, this node will be reserved as part of the booking, however it will not be shown as part of the Job, nor will it factor in the calculation of rates or costs. </td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Capability requirements</td>
			<td>String</td>
			<td>Specifies which capabilities are requried for this node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Capacity requirements</td>
			<td>String</td>
			<td>Specifies who much capacity will be consumed for this node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node start time</td>
			<td>DateTime</td>
			<td>If different from the Job Start time, the time when the resource started being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node end time</td>
			<td>DateTime</td>
			<td>If different from the Job End time, the time when the resource was finished being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Linked booking IDs</td>
			<td>String</td>
			<td>If the Node resource has an associated SRM Booking, this field stores the Booking ID from SRM. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select mode</td>
			<td>GenericEnum`1</td>
			<td>Indicates how and at what time the resource assignment is expected to be done</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select state</td>
			<td>GenericEnum`1</td>
			<td>Indicates in what state the resource selection process is</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Connections</td>
		</tr>
		<tr>
			<td>Connection ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this Edge within the Workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Source node ID</td>
			<td>String</td>
			<td>The ID of the Node that is the Source of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination node ID</td>
			<td>String</td>
			<td>The ID of the Node that is the Destination of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection alias</td>
			<td>String</td>
			<td>An optional user friendly name for the connection should the user wish to provide one. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution order</td>
			<td>Int64</td>
			<td>Indicates the oder in which the connections will be made. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection type</td>
			<td>GenericEnum`1</td>
			<td>Defines if this connection will be made based on the levels or the tags of its source and destination</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection subtype</td>
			<td>GenericEnum`1</td>
			<td>Further specifies how connection will be made. 'All': all matching levels or tags between source node and destination node will be connected. 'Predefined subset': only valid for level-based connections. In this case, only a subset of the matching levels between source node and destination node will be connected, for example all audio levels. 'Custom subset': the subset of matching levels or tags that will be connected can be freely defined, for example level three to five. Shuffle: levels or tags can be freely mapped from source to destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Predefined subset</td>
			<td>GenericEnum`1</td>
			<td>In case of a level-based connection of subtype 'predefined subset', this indicates the subset of levels to be used. This subset is combination of all video levels ('V'), all audio levels ('A') and/or all data levels ('D').</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection Details</td>
			<td>String</td>
			<td>In case of a 'custom subset' or 'shuffle' connection, this field contains the exact mapping of levels or tags between source and destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution script</td>
			<td>String</td>
			<td>Can optionally be used to specify a script that should be used when setting up this connection during during execution of the workfow or job</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Costing and Billing</td>
		</tr>
		<tr>
			<td>Organization</td>
			<td>Guid</td>
			<td>The Organziation that owns this Job or for which the Job is being performed. The Organization drives which Contacts and Contracts can be assigned to the Job. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job Owner</td>
			<td>Guid</td>
			<td>The main contact for this Job. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Additional Contacts</td>
			<td>List`1</td>
			<td>Contacts associated to this particular Job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Contract</td>
			<td>Guid</td>
			<td>Indicates the Contract used to calculate the Billing Rates and Costs for the Job. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job status</td>
			<td>String</td>
			<td>The status of the job at the moment when the cost or billing calculation started</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Contract uplift (%)</td>
			<td>Double</td>
			<td>Tracks the amount a Job's Rate will be increased, if any. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Contract discount (%)</td>
			<td>Double</td>
			<td>Tracks the amount the Job is discounted, if any. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Speed order increment on top of billing price (%)</td>
			<td>Double</td>
			<td>The billing price based % to be charged on top of the billing price if the job started earlier than scheduled</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Speed order fixed fee</td>
			<td>Double</td>
			<td>A fixed fee to be charged in addition to the % on top of the billing price if the job started earlier than scheduled</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Cancellation % of billing price</td>
			<td>Double</td>
			<td>% of the billing price to be charged due to job cancellation</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Cancellation fixed fee</td>
			<td>String</td>
			<td>A fixed fee to be charged in addition to the % of the billing price if the job was cancelled</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Last bill calculation</td>
			<td>DateTime</td>
			<td>The date and time the of the last calculation of costs and pricing. </td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Total bill net amount</td>
			<td>Double</td>
			<td>Result of total bill after fees</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total bill net override amount</td>
			<td>Double</td>
			<td>Override value for the total bill net amount</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total cost net amount</td>
			<td>Double</td>
			<td>Result of total cost calculation</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total cost net override amount</td>
			<td>Double</td>
			<td>Override value for the total cost net amount</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bill currency</td>
			<td>Guid</td>
			<td>The currency used for Rate calculations. By Default the Currency for the Job is set by the selected Contract. READ ONLY</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Costing and Billing Details </td>
		</tr>
		<tr>
			<td>Line item type</td>
			<td>GenericEnum`1</td>
			<td>Determines whether this cost and billing record is a billing or costing record</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Object Type</td>
			<td>GenericEnum`1</td>
			<td>The type of the object whose cost or billing is being calculated. Can be a Node or a Workflow</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Object ID</td>
			<td>String</td>
			<td>Captures the Object ID for which the Cost & Billing applies. Depending on the Object Type field, this can be either the ID of a Workflow or a Node</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Description </td>
			<td>String</td>
			<td>A system field that describes the Cost & Billing entry. This could be the name of the node that generated the entry, the name of the Workflow, etc. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Rate card</td>
			<td>Guid</td>
			<td>The Rate Card associated to the node or workflow that is used to calculate the total amount.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total net override amount</td>
			<td>Double</td>
			<td>Allows a user override for the Total Net Amount and is the value used by the system when calculating the total Rate of the Job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Currency</td>
			<td>Guid</td>
			<td>The currency in which the total net amount, or its override will be expressed in. When billing, this currency is dervied from the Contract. When calculating Cost, this currency will be dervied from the rate card in use</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Rates</td>
			<td>List`1</td>
			<td>The rates used to charge the current workflow or node containing total amount and total net amount after discount</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Node Capacities</td>
		</tr>
		<tr>
			<td>Capacity</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Capacity Value</td>
			<td>Double</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node Id</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Node Relationships</td>
		</tr>
		<tr>
			<td>Parent node ID</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Child node ID</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Relationship type</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job Error</td>
		</tr>
		<tr>
			<td>Error Type</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>State at Error</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Error Message</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Recurrences

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Recurrence details</td>
		</tr>
		<tr>
			<td>Start time</td>
			<td>DateTime</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>End time</td>
			<td>DateTime</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Type</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Rates

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Rate</td>
		</tr>
		<tr>
			<td>Qty</td>
			<td>Int64</td>
			<td>The quantity of units ( units being expressed in Qty Type) ex: 10 EUR per Hour</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Qty type</td>
			<td>GenericEnum`1</td>
			<td>Determines whether this rate is charging by the minute, hour, day or per use</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Amount per unit</td>
			<td>Double</td>
			<td>The price by each the quantity type. Quantity type being determined by Qty Type field and can be minute, hour, day or per use. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total amount</td>
			<td>Double</td>
			<td>The quantity multiplied by the amount per unit, before discount</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total net amount</td>
			<td>Double</td>
			<td>The total amount with the discount applied</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Job Node Relationship Actions

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job Node Relationship General Actions</td>
		</tr>
		<tr>
			<td>Relationship</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Booking Action</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Delete Action</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job Node Relationship Replace Actions</td>
		</tr>
		<tr>
			<td>Replace Action</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Execute Pool Links</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Execute Booking Extension Script</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Level

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Level.Info</td>
		</tr>
		<tr>
			<td>Level Number</td>
			<td>Int64</td>
			<td>Unique numerical identifier of a level</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>TypeOld</td>
			<td>GenericEnum`1</td>
			<td>Select a level type (Video, Audio or Data).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Type</td>
			<td>List`1</td>
			<td>Indicates whether this level is meant to contain a signal carrying video, audio, data or a combination of these three</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### VirtualSignalGroup

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>Enter a name for your virtual signal group.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Description</td>
			<td>String</td>
			<td>Enter a description for your virtual signal group.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Role</td>
			<td>GenericEnum`1</td>
			<td>Select whether this virtual signal group acts as a source or a destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Operational State</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this virtual signal group is currently operational or not.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative State</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this virtual signal group can currently be used by operators or not. As long as the Administrative state is set to 'Down' this virtual signal group will not appear in operator control panels.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Type</td>
			<td>Guid</td>
			<td>This Virtual Signal Group Type will be used to determine the behavior when connecting this virtual signal group</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Locked By</td>
			<td>String</td>
			<td>Indicated who locked this virtual signal group.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.SystemLabels</td>
		</tr>
		<tr>
			<td>UMD Label</td>
			<td>String</td>
			<td>This label will be shown below monitor displays.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Button Label</td>
			<td>String</td>
			<td>This shorter label will be shown on control panels because there is not enough room to display the entire name of the virtual signal group.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.LinkedFlows</td>
		</tr>
		<tr>
			<td>Flow Level</td>
			<td>Guid</td>
			<td>Level on which this virtual signal group is to contain a sender or receiver</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Blue Flow ID</td>
			<td>Guid</td>
			<td>ID of the flow senders or receiver assigned as 'blue' on this level </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Red Flow ID</td>
			<td>Guid</td>
			<td>ID of the flow senders or receiver assigned as 'red' on this level </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.DomainInfo</td>
		</tr>
		<tr>
			<td>Domains</td>
			<td>List`1</td>
			<td>List of Domains this Virtual Signal Group is part of</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Domain IDs</td>
			<td>String</td>
			<td>Comma separated string of Domains this Virtual Signal Group is part of</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.AreaInfo</td>
		</tr>
		<tr>
			<td>Areas</td>
			<td>List`1</td>
			<td>List of Areas this Virtual Signal Group is part of</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Area IDs</td>
			<td>String</td>
			<td>Comma separated string of Areas this Virtual Signal Group is part of</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Workflow Mappings

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow.Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>Give a name to the workflow so you can easily identify it.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Workflow</td>
			<td>Guid</td>
			<td>Link to the workflow DOM instance</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow.VirtualSignalGroupTypes</td>
		</tr>
		<tr>
			<td>Source Type</td>
			<td>Guid</td>
			<td>Type of source virtual signal group that should trigger this workflow.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Destination Type</td>
			<td>Guid</td>
			<td>Type of destination virtual signal group that should trigger this workflow.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Virtual Signal Group Types

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">GroupType.Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>Name of this Virtual Signal Group Type</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Flow

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Flow.Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>Enter a name for this flow sender or flow receiver</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Transport Type</td>
			<td>GenericEnum`1</td>
			<td>Select a transport technology type (IP, SDI, SRT ...).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Operational State</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this flow is currently operational or not.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative State</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this flow can currently be used by operators or not.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Flow.Path</td>
		</tr>
		<tr>
			<td>Element</td>
			<td>String</td>
			<td>Specify the element on which this flow sender/receiver is present</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Interface</td>
			<td>String</td>
			<td>Optionally specify the interface on which this flow sender/receiver is present on the element (DCF Interface ID)</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Interface Name</td>
			<td>String</td>
			<td>Specify the interface name of the element on which this flow originates/is received (optional).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Sub Interface</td>
			<td>String</td>
			<td>Identifier of the row in parameter table where this sender/receiver can be found. For example: for flows on NMOS IS-05 elements, specify the ID of the NMOS senders/receiver to be used for this flow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Source Flow</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Path Order</td>
			<td>Int64</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Flow Direction</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this flow is a sender (Tx) or receiver (Rx).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Flow.Transport</td>
		</tr>
		<tr>
			<td>Source IP</td>
			<td>String</td>
			<td>Source IP address of this flow. Only applies to IP flows, can be left empty for other flows.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination IP</td>
			<td>String</td>
			<td>Destination IP address of this flow, typically a multicast address. Only applies to IP flows, can be left empty for other flows.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination Port</td>
			<td>Int64</td>
			<td>Destination port of this flow. Only applies to IP flows, can be left empty for other flows.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bitrate (Mbps)</td>
			<td>Double</td>
			<td>Bitrate that needs to be transported over the media network for this flow. Only applies to IP flows, can be left empty for other flows.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>CoS</td>
			<td>GenericEnum`1</td>
			<td>Specify service class for this flow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">SRT Transport</td>
		</tr>
		<tr>
			<td>SRT Mode</td>
			<td>GenericEnum`1</td>
			<td>Indicates the SRT mode of this senders/receiver (caller, listener or rendezvous)</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT Listener IP</td>
			<td>String</td>
			<td>IP address of the listener</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT Listener port</td>
			<td>Int64</td>
			<td>Port on which listener listens for a caller</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT Source port</td>
			<td>Int64</td>
			<td>Port that SRT source is using</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT Destination port</td>
			<td>Int64</td>
			<td>Port that SRT desination is using</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Flow.Group</td>
		</tr>
		<tr>
			<td>Linked Signal Group</td>
			<td>List`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Linked Signal Group IDs</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Connection

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Connection.Overview</td>
		</tr>
		<tr>
			<td>Source Vsg</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Destination Vsg</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Lock</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Comment</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td></td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Connection.Connections</td>
		</tr>
		<tr>
			<td>Path Order</td>
			<td>Int64</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>From Vsg</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>From Flow</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>To Vsg</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>To Flow</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Area

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Area.Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>Area name.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Button Label</td>
			<td>String</td>
			<td>This label will is used on control panels where there is not enough room to display the entire name of the area.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative State</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this area can currently be used by operators or not. As long as the Admin state is set to 'Down' this area will not appear in operator control panels.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Domain IDs</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Domains</td>
			<td>List`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Domain

<table>
	<thead>
		<tr>
			<th>Field Name</th>
			<th>Type</th>
			<th>Description</th>
			<th>Access</th>
			<th>Constraints</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Domain.Info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>Domain name.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Button Label</td>
			<td>String</td>
			<td>This label will is used on control panels where there is not enough room to display the entire name of the domain.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative State</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this domain can currently be used by operators or not. As long as the Admin state is set to 'Down' this domain will not appear in operator control panels.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Area IDs</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Areas</td>
			<td>List`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>
