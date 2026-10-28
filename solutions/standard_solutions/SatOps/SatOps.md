---
uid: SatOps
description: Explore SatOps, the DataMiner standard solution that enables satellite broadcasters to manage their satellite inventory and schedule transponder capacity.
---

# SatOps

SatOps is a standard solution for DataMiner that enables satellite broadcasters to manage their daily operations. It combines a complete model of your satellite fleet with the tools to schedule and book transponder capacity, so that inventory and scheduling stay in sync in one connected environment.

Transponder capacity is a special kind of resource. A transponder is rarely booked as a whole: its bandwidth is used in parts, and the way it can be divided changes over time. SatOps models this explicitly. It treats each transponder as a bookable resource whose capacity can be reserved as a frequency range, and it lets you define exactly which parts of a transponder can be booked using transponder plans. This makes it possible to schedule partial transponder capacity in a flexible way, while still preventing overlapping bookings.

The SatOps solution includes the following applications, which are ready for use out of the box:

<div class="row">
  <div class="column">
  <a href="/solutions/standard_solutions/SatOps/Satellite_Inventory/Satellite_Inventory.html" title="Satellite Inventory" target="_self"><img src="~/solutions/images/SatelliteInventory.svg" alt="Satellite Inventory app icon" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/SatOps/Satellite_Scheduling/Satellite_Scheduling.html" title="Satellite Scheduling" target="_self"><img src="~/solutions/images/SatelliteScheduling.svg" alt="Satellite Scheduling app icon" style="width:100%"></a>
  </div>
</div>

<br>

- [Satellite Inventory](xref:Satellite_Inventory): Model and manage your full satellite inventory, including satellites, beams, transponders, transponder plans, and transponder slots.

- [Satellite Scheduling](xref:Satellite_Scheduling): Browse, book, and manage transponder capacity across your satellite fleet using a transponder timeline.

SatOps builds on [MediaOps Plan](xref:MediaOps.Plan). Satellite resources are kept in sync with Resource Studio, and transponder slots can be booked through the MediaOps Plan Scheduling app.

<style>
.column a {
  display: inline-block;
  padding: 4px;
  border-radius: 4px;
  transition: all 0.2s ease-in-out;
}

.column a:hover {
  background-color: #f0f4ff; /* light background on hover */
  transform: scale(1.05);   /* slightly bigger */
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1); /* subtle shadow */
}
</style>
