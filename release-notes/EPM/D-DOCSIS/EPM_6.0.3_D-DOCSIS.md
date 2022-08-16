---
uid: EPM_6.0.3_D-DOCSIS
---

# EPM 6.0.3 D-DOCSIS

## New features

#### Extended MAC state filter on CM page \[ID_32039\]

On the CM page, the following filters have been added to allow further filtering of the MAC state:

- *All Online*: Shows all cable modems with *Online* in their MAC state.
- *Init*: Shows all cable modems with *Init* in their MAC state.
- *Reject*: Shows all cable modems with *Reject* in their MAC state.
- *Expired*: Shows all cable modems with *Expire* in their MAC state.

#### Core Leaf, Spine, and Node Leaf topology levels integrated in DAA Overview topology \[ID_32040\]

The Core Leaf, Spine, and Node Leaf topology levels have been added to the DAA Overview chain. Now all collectors and devices shown in the topology can visualize how all these systems in the solution are connected to one another, adding contextuality to the RPDs and cable modems.

#### DCF interfaces table now contains ae1 and ae2 interfaces \[ID_32048\]

The *ae1* and *ae2* interfaces have been added to the DCF interfaces table.

## Changes

### Enhancements

#### Collectors now show more complete RPD-associated data \[ID_31858\]\[ID_31859\]

The CISCO CBR-8 CCAP Platform Collector will now join data from the device itself with auxiliary Smart PHY data to show all RPD-associated data (Fiber Nodes, Node Segments, Controllers, RPDs, and Service Groups). The auxiliary Smart PHY data will include all associated RPDs for the collector, instead of only the specific RPDs the collector is aware of. This way, all the data the system is aware of will be shown, instead of just the data points from the perspective of the collector.

#### Workflow Manager data source interfacing adjustments \[ID_31860\]

To prevent possible issues where deprecated data is read, the Workflow Manager now no longer performs ad-hoc requests. Instead it will process requests as they come in and export responses accordingly. In addition, more status information will now be provided, so that more context information is available in case issues need to be debugged.

#### Optics table cleanup method improved \[ID_31962\]

The cleanup method of the optics table has been adjusted so that it no longer removes all rows every polling cycle.

#### Dashboards for EPM entities now preloaded with relevant information \[ID_32036\]

When you click a dashboard link for a specific entity, the information for that entity will now be preloaded in the dashboard. In addition, using the EPM selector in a dashboard will fill in all pertinent component information, so that the user does not have to keep selecting the same entity.

#### Improved visualization of interface alarms \[ID_32037\]

The EPM Visual Overview has been updated to show the overall alarm status for interfaces of the Core Leaf, Spine, and Node Leaf entities. The alarm template has also been updated to trigger an alarm on *Operational Status* when *Admin Status* is *Up* while *Operational Status* is *Down*, as this means that the interface is down when it should not be.

#### Improved RPD Association pages for Core Leaf and Node Leaf entities \[ID_32038\]

The RPD Association pages for the Core Leaf and Node Leaf entities have been updated so that they truly show the available RPDs under their levels, instead of the RPDs of the associated hub of these devices.

#### Improved contextuality for RPD Relations page \[ID_32041\]

To add more contextuality, the RPD Relations page now shows RPD relation connections related to the specific RPD level instead of to the entire solution.

#### Data Sources document updated with additional information \[ID_32044\]

The Data Sources document (i.e. EPM_D-DOCSIS_Data_Sources_v7.xlsx) has been updated with additional information about KPIs such as OIDs, details about calculation performance, etc.

#### Improved processing of DCF requests \[ID_32046\]

When not all CI Types were found, up to now the workflow manager stopped processing DCF requests. Now the process will instead continue to process requests for existing CI Types. If a CI Type is not found, all DCF connections remain "Received".

### Fixes

#### '-1' displayed instead of 'N/A' on RPD details page \[ID_31963\]

On the RPD details page, it could occur that parameters displayed *-1* instead of the *N/A* exception value.

#### Predecessor fields not resolved when selecting node segment \[ID_31964\]

When a node segment was selected in the topology chain, it could occur that the predecessor fields were not resolved.

#### Additional Cores column missing in RPD Association table \[ID_31965\]

In the RPD Association table, the Additional Cores column was missing.

#### Serial numbers missing in Optics table \[ID_31966\]

Because of a CLI parsing issue, it could occur that serial numbers were missing in the Optics table.

#### Node Segment table not shown for CCAP level \[ID_31967\]

The Node Segment table was not displayed for the CCAP level, even when there were node segments for the CCAPs.

#### Incorrect fiber node CM count on Market/Hub utilization page \[ID_32043\]

Incorrect mapping from cable modems to fiber nodes could result in an incorrect CM count for fiber nodes.

#### "-1" displayed instead of exception value for RPD system info \[ID_32047\]

For some RPDs, system info parameters displayed -1 when an exception value had to be displayed instead.
