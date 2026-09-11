---
uid: SatOps_2.0.0
---

# SatOps 2.0.0

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.
> - [MediaOps Plan 1.5.1](xref:MediaOps_Plan_1.5.1) or higher.

## New features

#### Satellite Inventory: Google Maps key can now be configured directly [ID 46425]

You can now configure your own Google Maps key directly from the Satellite Inventory app, similar to how this can be done in the InfraOps [Facility Manager](xref:Facility_Manager) app.

#### Five new satellite equipment resource icons available [ID 46427]

Five new resource icons for satellite equipment are now available in MediaOps [Resource Studio](xref:MO_Resource_Studio), representing an antenna control unit, LNB, spectrum analyzer, SSPA, and transponder. You can use these icons in Workflow Designer drawings.

The icons are included with SatOps and are only available when SatOps is installed.

## Changes

### Enhancements

#### SatOps converted to SDM-compliant code [ID 46424]

SatOps has been converted to SDM-compliant code using the SDM Code Generator (SatOps DevPack), aligning it with the other DataMiner Standard Solutions.

This version requires MediaOps Plan 2.0.0 and MediaOps.Plan-nuget 2.0.0. The conversion also lays the groundwork for future DataMiner Assistant support, for example to configure Satellite Inventory or create a Satellite Scheduling booking through the agentic framework.

#### Satellite Inventory: GeoJSON support replaces KML for map overlays [ID 46426]

Satellite Inventory now uses GeoJSON instead of KML for satellite footprint and beam overlays, as KML layers in the Google Maps JavaScript API will no longer work from August 2026 onward.

You can reference a GeoJSON file by its web path or store it locally through a DocumentHub integration. DocumentHub is optional: you will only need this if you want to store GeoJSON files locally.
