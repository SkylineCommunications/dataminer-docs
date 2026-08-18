---
uid: SI_Managing_Beams
description: Learn how to filter, add, edit, activate, view, and deprecate satellite beams in the Satellite Inventory app.
---

# Managing beams

A *beam* represents a coverage area of a [satellite](xref:SI_Managing_Satellites) and groups one or more [transponders](xref:SI_Adding_Editing_Transponders). The *Beams* page lists the configured beams and lets you manage them.

![The Beams page showing the filter bar with transmission type, link type, and status filters](~/solutions/images/SO_SI_Beams_Page.png)

## Filtering the beam list

At the top of the page, you can use four filters to narrow down the list of beams:

- Search by beam name.

- Filter by transmission type (*Tx*, *Rx*, or *CiC* (carrier-in-carrier)).

- Filter by link type (*User*, *Feeder*, *Uplink*, or *Downlink*).

- Filter by state (*Active*, *Draft*, *Deprecated*, or *Error*).

## Adding a beam

To add a beam:

1. On the *Beams* page, click *Add beam*.

1. Provide the following information about the beam:

   - *Beam Name*: A descriptive name for the beam.
   - *Beam Satellite*: The satellite to which the beam belongs.
   - *Link Type*: The beam's link type (*Feeder*, *User*, *Uplink*, or *Downlink*).
   - *Transmission Type*: The beam's transmission type (*TX*, *RX*, or *Carrier in Carrier*).
   - *Footprint File*: A path or URL to the KML file that describes the beam footprint.

   ![The Add Beam dialog showing the link type dropdown with Feeder, User, Uplink, and Downlink options](~/solutions/images/SO_SI_Add_Beam.png)

1. Click *Create Beam*.

> [!NOTE]
> Beam footprints are defined using KML files. Support for GeoJSON files is planned for a future release. You can specify a public URL or upload a KML file via the document hub.

## Editing a beam

To edit a beam:

1. Click the ![Edit](~/solutions/images/SO_SI_Edit_Icon.png) *Edit* icon in the beam's row.

   This opens a panel where you can modify the beam properties.

1. Click *Update Beam* to save your changes.

![The Update Beam dialog with the beam name, satellite, link type, transmission type, and footprint file fields](~/solutions/images/SO_SI_Edit_Beam.png)

## Activating a beam

After you create a beam, its state will automatically be set to *Draft*. You must first activate the beam before it becomes available in the system.

To activate a beam:

1. Click the ![More](~/solutions/images/SO_SI_More_Icon.png) *More* icon in the beam's row.

1. Select *Activate*.

## Viewing a beam footprint

If a beam has a footprint file configured, you can view its coverage area on a map.

To view a beam footprint, click the ![Footprint](~/solutions/images/SO_SI_Footprint_Icon.png) *Footprint* icon in the beam's row. A side panel opens, displaying the beam footprint on a geographical map.

![The Satellite Inventory app with a beam footprint shown on a geographical map in a side panel, covering Europe and the Mediterranean](~/solutions/images/SO_SI_Beam_Footprint.png)<br>*The footprint shown here comes from a KML file created specifically for documentation purposes. Actual beam footprints typically have a more irregular shape that reflects the beam's real signal coverage.*

The map opens in a side panel over the beam list, allowing you to keep the context of the beam you are inspecting.

## Deprecating a beam

Beams cannot be deleted. To remove a beam from active use, deprecate it instead. This preserves historical inventory data.

To deprecate a beam:

1. Click the ![More](~/solutions/images/SO_SI_More_Icon.png) *More* icon in the beam's row.

1. Select *Deprecate*.
