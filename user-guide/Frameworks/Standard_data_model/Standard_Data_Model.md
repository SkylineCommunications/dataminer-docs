---
uid: SDM
keywords: Common Data Model, CDM
---

# Standard Data Model (SDM)

Several low-code apps available in the DataMiner Catalog, including all MediaOps applications, are built on the Common Data Model (CDM). In this model, each object is described by a definition.

Definitions that are functionally related are grouped into modules to enhance data management, interoperability, and efficiency. Below, you can find an overview of the different modules.

> [!TIP]
> See also: [Standard Data Model](xref:Overview_DataMiner_Solutions#standard-data-model)

## (slc)cost_billing

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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Contract info</td>
		</tr>
		<tr>
			<td>Name</td>
			<td>String</td>
			<td>The name of the contract.</td>
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
			<td>The amount (in percentage) by which the charged rates will be increased when calculating the bill.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Discount (%)</td>
			<td>Double</td>
			<td>The amount (in percentage) by which the calculated total amount will be reduced when producing the bill.</td>
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
			<td>The number of hours before the start of the job during which it can be canceled without incurring higher fees.</td>
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
			<td>Determines whether this contract will bill based on workflow only, resource only, or both.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Default workflow ratecard</td>
			<td>Guid</td>
			<td>The unique identifier for another DOM object representing the default ratecard to be used for workflows.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Default resource ratecard</td>
			<td>Guid</td>
			<td>The unique identifier for another DOM object representing the default ratecard to be used for resources..</td>
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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard info</td>
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
			<td>A unique identifier for another DOM object representing the currency to be used by this ratecard.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard details</td>
		</tr>
		<tr>
			<td>Minimal time interval</td>
			<td>Double</td>
			<td>The minimum amount of time that will be charged, even if the job duration is shorter.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time interval unit</td>
			<td>GenericEnum`1</td>
			<td>The unit of time that specifies the minimum time interval's numeric value.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment</td>
			<td>Double</td>
			<td>The increment of time in multiples of which the job duration will be charged if that duration extends beyond the minimum time interval.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment unit</td>
			<td>GenericEnum`1</td>
			<td>The unit of time that specifies the minimum time increment's numeric value.</td>
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
			<td>The amount to be charged for each unit of time that the node or workflow was in use.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Unit</td>
			<td>GenericEnum`1</td>
			<td> The unit of time that qualifies the rate specified in the 'Rate' field.</td>
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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard info</td>
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
			<td>A unique identifier for another DOM object representing the currency to be used by this ratecard.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Ratecard details</td>
		</tr>
		<tr>
			<td>Minimal time interval</td>
			<td>Double</td>
			<td>The minimum amount of time that will be charged, even if the job duration is shorter.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time interval unit</td>
			<td>GenericEnum`1</td>
			<td>The unit of time that specifies the minimum time interval's numeric value.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment</td>
			<td>Double</td>
			<td>The increment of time in multiples of which the job duration will be charged if that duration extends beyond the minimum time interval.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Minimal time increment unit</td>
			<td>GenericEnum`1</td>
			<td>The unit of time that specifies the minimum time increment's numeric value.</td>
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
			<td>The amount to be charged for each unit of time that the node or workflow was in use.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Unit</td>
			<td>GenericEnum`1</td>
			<td> The unit of time that qualifies the rate specified in the 'Rate' field.</td>
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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">App data currencies</td>
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
			<td>The currency ISO code.</td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Rate to nominal</td>
			<td>Double</td>
			<td> The conversion rate against the currency set as nominal.</td>
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

## (slc)satellite_management

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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Transponder plan</td>
		</tr>
		<tr>
			<td>Plan name</td>
			<td>String</td>
			<td>A meaningful name for this plan, such as 'Standard C Band 36MHz'.</td>
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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Slot definition</td>
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
			<td>Defines the size of the slot to be created. For example, if the slot size is 9 MHz and this plan is applied to a full transponder, four 9 MHz slots will be created.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Relative start frequency</td>
			<td>Double</td>
			<td>This value provides an offset from the transponder's start frequency for slot generation. For example, to create slots only on the bottom half of a 36 MHz transponder, the relative start frequency would be 18.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Relative end frequency</td>
			<td>Double</td>
			<td>Similar to the relative start frequency, this value provides an offset from the transponder's end frequency at which slot generation stops. For example, if the relative start frequency is 0 and the relative end frequency is 18, slots will only be created for the first 18 units of the transponder.</td>
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
			<td>A descriptive name for the beam, e.g. AMC 11 – C Band Americas.</td>
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
			<td>An enumeration that describes if this is a 'Feeder' or 'User' type.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Transmission type</td>
			<td>GenericEnum`1</td>
			<td>Describes if this beam is a 'Transmit', 'Receive' or 'Carrier in Carrier' type beam.</td>
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
			<td>The name of the transponder, e.g. Galaxy 19 T01.</td>
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
			<td>The full name of the satellite, which will be the primary reference throughout the application.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Satellite abbreviation</td>
			<td>String</td>
			<td>A short abbreviation (3-5 characters are suggested) that will be used to reference this satellite when a shorter name is needed, such as when building slot names. For example, Galaxy 19 might be shortened to G19 or GAL19.</td>
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
			<td>The company that operates the satellite.</td>
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
			<td>Describes the general application of this satellite.</td>
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
			<td>The satellite's country of origin.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Launch information</td>
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

## (slc)people_organizations

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
			<td>For example, Junior, Senior, Manager, etc.</td>
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
			<td>For example, Software Company, Social Media, Production Studio, etc.</td>
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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Role information</td>
		</tr>
		<tr>
			<td>Role</td>
			<td>String</td>
			<td>The role a contact assumes when assigned to a team.</td>
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
			<td>This contact's full name.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Experience level</td>
			<td>Guid</td>
			<td>For example, Junior, Senior, Manager, etc.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Profile Image</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Personal skills</td>
			<td>String</td>
			<td>For example, Producer, Director, Video Editor, Audio Mixer, etc.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Contact info</td>
		</tr>
		<tr>
			<td>Email</td>
			<td>String</td>
			<td>This contact's email address.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Phone</td>
			<td>String</td>
			<td>This contact's phone number.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Street address</td>
			<td>String</td>
			<td>This contact's current street address of residence.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>City</td>
			<td>String</td>
			<td>This contact's current city of residence.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Country</td>
			<td>GenericEnum`1</td>
			<td>This contact's current country of residence.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>ZIP</td>
			<td>String</td>
			<td>This contact's current ZIP code.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Organization</td>
		</tr>
		<tr>
			<td>Organization</td>
			<td>Guid</td>
			<td>This contact's current organization.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Team</td>
		</tr>
		<tr>
			<td>Team</td>
			<td>Guid</td>
			<td>This contact's team membership.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Team role</td>
			<td>Guid</td>
			<td>This contact's current role in the specified team.</td>
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
			<td>This team's name.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Team email</td>
			<td>String</td>
			<td>This team's email address.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Team description</td>
			<td>String</td>
			<td>A description of the team's functions and responsibilities.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bookable</td>
			<td>Boolean</td>
			<td>Indicates whether this team's time can be booked and scheduled.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Icon</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Team expertise(s)</td>
			<td>String</td>
			<td>For example, Video Editing, Audio Mixing, Contribution, OTT, etc.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Resource pool</td>
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
			<td>The name of this organization.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Category</td>
			<td>Guid</td>
			<td>For example, Software Company, Social Media, Production Studio, etc.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Icon</td>
			<td>String</td>
			<td>The relative qualified path to the organization's icon. This is a backend field descriptor.</td>
			<td>Read/Write</td>
			<td>Optional</td>
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
	</tbody>
</table>

## (slc)workflow

### App settings

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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job settings</td>
		</tr>
		<tr>
			<td>Job ID prefix</td>
			<td>String</td>
			<td>The prefix is a string that will be prepended to each Job ID.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job ID minimum digits</td>
			<td>Int64</td>
			<td>Defines the minimum number of digits in the auto-generated value, which must be between 1 and 20.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job ID starting seed</td>
			<td>Int64</td>
			<td>Provides the "starting seed" when first configuring the job IDs.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job ID increment</td>
			<td>Int64</td>
			<td>An integer defining the increment by which the auto-generated ID increases.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job ID next sequence</td>
			<td>Int64</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### Session data

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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Session data user</td>
		</tr>
		<tr>
			<td>user</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Session data store</td>
		</tr>
		<tr>
			<td>Job Id</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Session filter</td>
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
			<td>The GUID of the DOM instance representing the key being filtered.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Filter Values</td>
			<td>String</td>
			<td>Values to filter on (a comma-separated list of DOM GUIDs).</td>
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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job info</td>
		</tr>
		<tr>
			<td>Job ID</td>
			<td>String</td>
			<td>A human-readable ID for a job, auto-generated for each job instance in a specific format, e.g. SLC_0001.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job name</td>
			<td>String</td>
			<td>A short name for the job. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Job description</td>
			<td>String</td>
			<td>A description of the workflow, including its purpose, steps, and functionality.</td>
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
			<td>Job start</td>
			<td>DateTime</td>
			<td>The time the job starts. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Job end</td>
			<td>DateTime</td>
			<td>The time the job ends. </td>
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
			<td>An optional time that may be used at the end of a job if it exceeds the scheduled end time.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job priority</td>
			<td>GenericEnum`1</td>
			<td>Describes the relative importance of the job. </td>
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
			<td>Job source</td>
			<td>String</td>
			<td>Tracks the source of a job, with potential values including user, API, element, etc.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job notes</td>
			<td>String</td>
			<td>A general note field for job-related communication.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Original job start</td>
			<td>DateTime</td>
			<td>The start date/time of the job at the time of job confirmation.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Original job end</td>
			<td>DateTime</td>
			<td>The end date/time of the job at the time of job confirmation.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job confirmation</td>
			<td>DateTime</td>
			<td>The date/time the job was confirmed.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job cancellation</td>
			<td>DateTime</td>
			<td>The date/time the job was canceled.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Action status</td>
			<td>GenericEnum`1</td>
			<td>Indicates if the job still needs manual resource selection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Action needed</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Locked by</td>
			<td>String</td>
			<td>Indicates who locked this job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Monitoring settings</td>
		</tr>
		<tr>
			<td>At job start</td>
			<td>GenericEnum`1</td>
			<td>Determines whether and when a service will be created for this workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>At job end</td>
			<td>GenericEnum`1</td>
			<td>Determines whether and when a service will be deleted for this workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service template</td>
			<td>String</td>
			<td>The name of the service template, which will be used to create a service when the workflow is run. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service ID</td>
			<td>String</td>
			<td>The ID of the service associated to this job. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job execution </td>
		</tr>
		<tr>
			<td>Job execution script</td>
			<td>String</td>
			<td>A script that will run when the job starts.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job configuration</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job configuration status</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Nodes</td>
		</tr>
		<tr>
			<td>Node ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this node within the job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node alias</td>
			<td>String</td>
			<td>Allows the user to provide a more user-friendly name for the node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node type</td>
			<td>GenericEnum`1</td>
			<td>Specifies the category or function of a node within a job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the resource, resource pool, or other entity that this node represents.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node parent reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the parent resource, resource pool, or other entity that this node represents.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node icon</td>
			<td>String</td>
			<td>The name of the icon that will be used for the workflow visualization.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Automatic configuration?</td>
			<td>Boolean</td>
			<td>Indicates if the node needs to be configured when the job is run.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Configuration parameters</td>
			<td>String</td>
			<td>A JSON object defining a list of configuration parameters and values for elements and virtual functions for user configuration.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Ad-hoc control script</td>
			<td>String</td>
			<td>An Automation script name that will be executed to configure this node.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration execution order</td>
			<td>Int64</td>
			<td>Indicates the order in which the nodes will be configured. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Reserve node?</td>
			<td>Boolean</td>
			<td>If checked, a booking will be created for this node to ensure resource availability. Leave unchecked if the node does not require a booking.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Hidden?</td>
			<td>Boolean</td>
			<td>When marked TRUE, this node will be reserved as part of the booking but will not be displayed in the job or included in the calculation of rates or costs.</td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Node start time</td>
			<td>DateTime</td>
			<td>If different from the Job Start time, this indicates when the resource started being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node end time</td>
			<td>DateTime</td>
			<td>"If different from the Job End time, this indicates when the resource finished being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Linked booking IDs</td>
			<td>String</td>
			<td>If the node resource has an associated SRM booking, this field stores the corresponding booking ID from SRM.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select mode</td>
			<td>GenericEnum`1</td>
			<td>Indicates how and when the resource assignment is expected to be made.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select state</td>
			<td>GenericEnum`1</td>
			<td>Indicates the current state of the resource selection process.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Billable?</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration status</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Connections</td>
		</tr>
		<tr>
			<td>Connection ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this edge within the workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Source node ID</td>
			<td>String</td>
			<td>The ID of the node that is the source of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination node ID</td>
			<td>String</td>
			<td>The ID of the node that is the destination of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection alias</td>
			<td>String</td>
			<td>An optional user-friendly name for the connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution order</td>
			<td>Int64</td>
			<td>Indicates the order in which the connections will be made. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection type</td>
			<td>GenericEnum`1</td>
			<td>Defines whether this connection is based on the levels or tags of its source and destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection subtype</td>
			<td>GenericEnum`1</td>
			<td>Further specifies how the connection will be made. 'All': All matching levels or tags between the source and destination nodes will be connected. 'Predefined subset': Only valid for level-based connections. Only a predefined subset of matching levels between the source and destination nodes will be connected, for example, all audio levels. 'Custom subset': A freely defined subset of matching levels or tags will be connected, for example, level three to five. 'Shuffle': Levels or tags can be freely mapped from source to destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Predefined subset</td>
			<td>GenericEnum`1</td>
			<td>In the case of a level-based connection of subtype 'predefined subset,' this indicates the subset of levels to be used. This subset is a combination of all video levels ('V'), all audio levels ('A'), and/or all data levels ('D').</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection details</td>
			<td>String</td>
			<td>For 'custom subset' or 'shuffle' connections, this field contains the exact mapping of levels or tags between the source and destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution script</td>
			<td>String</td>
			<td>Optionally specifies a script to be used when setting up this connection during the execution of the workflow or job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Costing and billing</td>
		</tr>
		<tr>
			<td>Organization</td>
			<td>Guid</td>
			<td>The organization that owns this job or for which the job is being performed. The organization determines which contacts and contracts can be assigned to the job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Job owner</td>
			<td>Guid</td>
			<td>The main contact for this job. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Additional contacts</td>
			<td>List`1</td>
			<td>Contacts associated with this particular job.</td>
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
			<td>The status of the job when cost or billing calculation started.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Contract uplift (%)</td>
			<td>Double</td>
			<td>Tracks the percentage by which a job's rate will be increased, if any.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Contract discount (%)</td>
			<td>Double</td>
			<td>Tracks the percentage by which the job is discounted, if any.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Speed order increment on top of billing price (%)</td>
			<td>Double</td>
			<td>The percentage added to the billing price if the job starts earlier than scheduled.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Speed order fixed fee</td>
			<td>Double</td>
			<td>If a job starts earlier than scheduled, a fixed fee will be added to the existing percentage fee calculated on the total billing price.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Cancellation % of billing price</td>
			<td>Double</td>
			<td>Percentage of the billing price to be charged due to job cancellation.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Cancellation fixed fee</td>
			<td>String</td>
			<td>If a job was canceled, a fixed fee will be added to the existing percentage fee calculated on the total billing price.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Last bill calculation</td>
			<td>DateTime</td>
			<td>The date and time of the last calculation of costs and pricing. </td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Total bill net amount</td>
			<td>Double</td>
			<td>The total bill amount after fees.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total bill net override amount</td>
			<td>Double</td>
			<td>An override value for the total bill net amount.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bill currency</td>
			<td>Guid</td>
			<td>The currency used for rate calculations. By default, the job's currency is set by the selected contract. READ ONLY.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Costing and billing details </td>
		</tr>
		<tr>
			<td>Line item type</td>
			<td>GenericEnum`1</td>
			<td>Determines whether this record is a billing or costing record.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Object type</td>
			<td>GenericEnum`1</td>
			<td>The type of object for which cost or billing is being calculated (node or workflow).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Object ID</td>
			<td>String</td>
			<td>Captures the object ID for which the cost & billing apply. Depending on the object type, this can be the ID of either a workflow or a node.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Description </td>
			<td>String</td>
			<td>A system field describing the cost and billing entry, such as the name of the node or the workflow that generated it.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Rate card</td>
			<td>Guid</td>
			<td>The rate card associated with the node or workflow used to calculate the total amount.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total net override amount</td>
			<td>Double</td>
			<td>Allows a user override for the total net amount and is the value used by the system to calculate the job's total rate.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Currency</td>
			<td>Guid</td>
			<td>The currency in which the total net amount or its override will be expressed. When billing, this currency is derived from the contract. When calculating cost, this currency is derived from the rate card in use.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Rates</td>
			<td>List`1</td>
			<td>The rates used to charge the current workflow or node, including the total amount and total net amount after discounts.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Node relationships</td>
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
			<td>Relationship action</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Errors</td>
		</tr>
		<tr>
			<td>Error Code</td>
			<td>String</td>
			<td>The code of the error, which has to be unique for the linked object</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Error Message</td>
			<td>String</td>
			<td>The message explaining why the error was raised</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
	</tbody>
</table>

### Job node relationship actions

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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job node relationship general actions</td>
		</tr>
		<tr>
			<td>Booking action</td>
			<td>GenericEnum`1</td>
			<td>Action taken when a node is added to a job.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Delete action</td>
			<td>GenericEnum`1</td>
			<td>Action taken when a node is removed from a job.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Job node relationship replace actions</td>
		</tr>
		<tr>
			<td>Replace action</td>
			<td>GenericEnum`1</td>
			<td>Action taken when a node is replaced in a job.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Execute pool links</td>
			<td>Boolean</td>
			<td>Defines whether to apply pool links (if available) during a replace action.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Execute booking extension script</td>
			<td>Boolean</td>
			<td>Defines whether to execute booking extension scripts (if available) during a replace action.</td>
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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow info</td>
		</tr>
		<tr>
			<td>Workflow name</td>
			<td>String</td>
			<td>A short name for the workflow. </td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Workflow description</td>
			<td>String</td>
			<td>A description of the workflow, which can include its purpose, steps, and functionality.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Favorite</td>
			<td>Boolean</td>
			<td>Flag that indicates whether this workflow is a favorite. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Priority</td>
			<td>GenericEnum`1</td>
			<td>Describes the relative importance of the workflow.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow execution</td>
		</tr>
		<tr>
			<td>Workflow execution script</td>
			<td>String</td>
			<td>Specifies a script to be triggered when this workflow is executed (optional).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Workflow configuration</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Monitoring settings</td>
		</tr>
		<tr>
			<td>At job start</td>
			<td>GenericEnum`1</td>
			<td>Determines whether and when a service will be created for this workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>At job end</td>
			<td>GenericEnum`1</td>
			<td>Determines whether and when a service will be deleted for this workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service template</td>
			<td>String</td>
			<td>The name of the service template, which will be used to create a service when the workflow is run. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Monitoring service ID</td>
			<td>String</td>
			<td>The ID of the service associated to this job. </td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Nodes</td>
		</tr>
		<tr>
			<td>Node ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this node within the job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node alias</td>
			<td>String</td>
			<td>Allows the user to provide a more user-friendly name for the node. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node type</td>
			<td>GenericEnum`1</td>
			<td>Specifies the category or function of a node within a job.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the resource, resource pool, or other entity that this node represents.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node parent reference ID</td>
			<td>String</td>
			<td>The DOM GUID of the parent resource, resource pool, or other entity that this node represents.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node icon</td>
			<td>String</td>
			<td>The name of the icon that will be used for the workflow visualization.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Automatic configuration?</td>
			<td>Boolean</td>
			<td>Indicates if the node needs to be configured when the job is run.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Configuration parameters</td>
			<td>String</td>
			<td>A JSON object defining a list of configuration parameters and values for elements and virtual functions for user configuration.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Ad-hoc control script</td>
			<td>String</td>
			<td>An Automation script name that will be executed to configure this node.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration execution order</td>
			<td>Int64</td>
			<td>Indicates the order in which the nodes will be configured. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Reserve node?</td>
			<td>Boolean</td>
			<td>If checked, a booking will be created for this node to ensure resource availability. Leave unchecked if the node does not require a booking.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Hidden?</td>
			<td>Boolean</td>
			<td>When marked TRUE, this node will be reserved as part of the booking but will not be displayed in the job or included in the calculation of rates or costs.</td>
			<td>Read</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Node start time</td>
			<td>DateTime</td>
			<td>If different from the Job Start time, this indicates when the resource started being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node end time</td>
			<td>DateTime</td>
			<td>"If different from the Job End time, this indicates when the resource finished being used.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Linked booking IDs</td>
			<td>String</td>
			<td>If the node resource has an associated SRM booking, this field stores the corresponding booking ID from SRM.</td>
			<td>Read</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select mode</td>
			<td>GenericEnum`1</td>
			<td>Indicates how and when the resource assignment is expected to be made.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Resource select state</td>
			<td>GenericEnum`1</td>
			<td>Indicates the current state of the resource selection process.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Billable?</td>
			<td>Boolean</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Node configuration status</td>
			<td>GenericEnum`1</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Connections</td>
		</tr>
		<tr>
			<td>Connection ID</td>
			<td>String</td>
			<td>An auto-assigned value representing the ID of this edge within the workflow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Source node ID</td>
			<td>String</td>
			<td>The ID of the node that is the source of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination node ID</td>
			<td>String</td>
			<td>The ID of the node that is the destination of this connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection alias</td>
			<td>String</td>
			<td>An optional user-friendly name for the connection.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution order</td>
			<td>Int64</td>
			<td>Indicates the order in which the connections will be made. </td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection type</td>
			<td>GenericEnum`1</td>
			<td>Defines whether this connection is based on the levels or tags of its source and destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection subtype</td>
			<td>GenericEnum`1</td>
			<td>Further specifies how the connection will be made. 'All': All matching levels or tags between the source and destination nodes will be connected. 'Predefined subset': Only valid for level-based connections. Only a predefined subset of matching levels between the source and destination nodes will be connected, for example, all audio levels. 'Custom subset': A freely defined subset of matching levels or tags will be connected, for example, level three to five. 'Shuffle': Levels or tags can be freely mapped from source to destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Predefined subset</td>
			<td>GenericEnum`1</td>
			<td>In the case of a level-based connection of subtype 'predefined subset,' this indicates the subset of levels to be used. This subset is a combination of all video levels ('V'), all audio levels ('A'), and/or all data levels ('D').</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection details</td>
			<td>String</td>
			<td>For 'custom subset' or 'shuffle' connections, this field contains the exact mapping of levels or tags between the source and destination.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Connection execution script</td>
			<td>String</td>
			<td>Optionally specifies a script to be used when setting up this connection during the execution of the workflow or job.</td>
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
			<td>The quantity of units (expressed in Qty Type), e.g. 10 EUR per hour.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Qty type</td>
			<td>GenericEnum`1</td>
			<td>Determines whether this rate is charged by the minute, hour, day, or per use.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Amount per unit</td>
			<td>Double</td>
			<td>The price per unit based on the quantity type, which can be minute, hour, day, or per use.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total amount</td>
			<td>Double</td>
			<td>The quantity multiplied by the amount per unit, before applying any discounts.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Total net amount</td>
			<td>Double</td>
			<td>The total amount after applying the discount.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

### MCR cockpit

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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">MCR_TimeStepper_CurrentRange</td>
		</tr>
		<tr>
			<td>User</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>End</td>
			<td>DateTime</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Start</td>
			<td>DateTime</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>LastSet</td>
			<td>DateTime</td>
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

### Configuration

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
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Configuration info</td>
		</tr>
		<tr>
			<td>Profile definition ID</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Preset ID</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Profile parameter values</td>
		</tr>
		<tr>
			<td>Profile parameter ID</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>String value</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Double value</td>
			<td>Double</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Reference ID</td>
			<td>String</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
	</tbody>
</table>

## (slc)virtualsignalgroup

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
			<td>Level number</td>
			<td>Int64</td>
			<td>Unique numerical identifier for a level.</td>
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
			<td>Select a level type (Video, Audio, or Data).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Type</td>
			<td>List`1</td>
			<td>Indicates whether this level is meant to carry a signal that includes video, audio, data, or a combination of these three.</td>
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
			<td>Operational state</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this virtual signal group is currently operational or not.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative state</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this virtual signal group can currently be used by operators or not. As long as the administrative state is set to 'Down', this virtual signal group will not appear in operator control panels.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Type</td>
			<td>Guid</td>
			<td>This virtual signal group type will define the behavior when connecting to this virtual signal group.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Locked by</td>
			<td>String</td>
			<td>Indicates who locked this virtual signal group.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.SystemLabels</td>
		</tr>
		<tr>
			<td>UMD label</td>
			<td>String</td>
			<td>This label will be shown below monitor displays.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Button label</td>
			<td>String</td>
			<td>This shorter label will be shown on control panels because there is not enough room to display the entire name of the virtual signal group.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.LinkedFlows</td>
		</tr>
		<tr>
			<td>Flow level</td>
			<td>Guid</td>
			<td>Level on which this virtual signal group contains a sender or receiver.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Blue flow ID</td>
			<td>Guid</td>
			<td>ID of the flow senders or receivers assigned as 'blue' on this level.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Red flow ID</td>
			<td>Guid</td>
			<td>ID of the flow senders or receivers assigned as 'red' on this level.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.DomainInfo</td>
		</tr>
		<tr>
			<td>Domains</td>
			<td>List`1</td>
			<td>List of domains to which this virtual signal group belongs.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Domain IDs</td>
			<td>String</td>
			<td>Comma-separated string of domains to which this virtual signal group belongs.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">VirtualSignalGroup.AreaInfo</td>
		</tr>
		<tr>
			<td>Areas</td>
			<td>List`1</td>
			<td>List of areas to which this virtual signal group belongs.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Area IDs</td>
			<td>String</td>
			<td>Comma-separated string of areas to which this virtual signal group belongs.</td>
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
			<td>Link to the workflow DOM instance.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">Workflow.VirtualSignalGroupTypes</td>
		</tr>
		<tr>
			<td>Source type</td>
			<td>Guid</td>
			<td>Type of source virtual signal group that should trigger this workflow.</td>
			<td>Read/Write</td>
			<td>Mandatory</td>
		</tr>
		<tr>
			<td>Destination type</td>
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
			<td>Name of this virtual signal group type.</td>
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
			<td>Transport type</td>
			<td>GenericEnum`1</td>
			<td>Select a transport technology type (e.g. IP, SDI, SRT, etc.).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Operational state</td>
			<td>GenericEnum`1</td>
			<td>Indicate whether this flow is currently operational or not.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative state</td>
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
			<td>Specify the element on which this flow sender/receiver is present.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Interface</td>
			<td>String</td>
			<td>Optionally specify the interface on which this flow sender/receiver is present on the element (DCF Interface ID).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Interface name</td>
			<td>String</td>
			<td>Specify the interface name of the element on which this flow originates/is received (optional).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Sub interface</td>
			<td>String</td>
			<td>Identifier of the row in the parameter table where this sender/receiver can be found. For example, specify the ID of the NMOS sender/receiver for flows on NMOS IS-05 elements.</td>
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
			<td>Source flow</td>
			<td>Guid</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Path order</td>
			<td>Int64</td>
			<td></td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Flow direction</td>
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
			<td>Source IP address of this flow. Only applicable to IP flows; can be left empty for other flow types.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination IP</td>
			<td>String</td>
			<td>Destination IP address of this flow, typically a multicast address. Only applicable to IP flows; can be left empty for other flow types.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Destination port</td>
			<td>Int64</td>
			<td>Destination port for this flow. Only applicable to IP flows; can be left empty for other flow types.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Bitrate (Mbps)</td>
			<td>Double</td>
			<td>Bitrate that must be transported over the media network for this flow. Only applicable to IP flows; can be left empty for other flow types.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>CoS</td>
			<td>GenericEnum`1</td>
			<td>Specify the service class for this flow.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td colspan=5 style="text-align:center; background-color:lightgrey; font-weight: bold">SRT transport</td>
		</tr>
		<tr>
			<td>SRT mode</td>
			<td>GenericEnum`1</td>
			<td>Indicates the SRT mode of this senders/receiver (caller, listener, or rendezvous).</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT listener IP</td>
			<td>String</td>
			<td>IP address of the listener.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT listener port</td>
			<td>Int64</td>
			<td>Port on which a listener listens for a caller.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT source port</td>
			<td>Int64</td>
			<td>Port used by the SRT source.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>SRT destination port</td>
			<td>Int64</td>
			<td>Port used by the SRT destination.</td>
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

## (slc)media_ops

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
			<td>Button label</td>
			<td>String</td>
			<td>This label will be used on control panels where there is insufficient room to display the full name of the area.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative state</td>
			<td>GenericEnum`1</td>
			<td>Indicates whether this area can currently be used by operators or not. As long as the admin state is set to 'Down', this area will not appear in operator control panels.</td>
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
			<td>Button label</td>
			<td>String</td>
			<td>This label will be used on control panels where there is insufficient room to display the full name of the domain.</td>
			<td>Read/Write</td>
			<td>Optional</td>
		</tr>
		<tr>
			<td>Administrative state</td>
			<td>GenericEnum`1</td>
			<td>Indicates whether this domain can currently be used by operators or not. As long as the admin state is set to 'Down', this domain will not appear in operator control panels.</td>
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
