---
uid: SI_Managing_Beams
description: Learn how to add and manage the beams of a satellite in the Satellite Inventory app.
---

# Managing beams

A *beam* represents a coverage area of a [satellite](xref:SI_Managing_Satellites) and groups one or more [transponders](xref:SI_Managing_Transponders). The *Beams* page lists the configured beams and lets you manage them.

![The Beams page showing the filter bar with transmission type, link type, and status filters](~/solutions/images/SO_SI_Beams_Page.png)

## Filtering the beam list

At the top of the page, you can narrow down the list using three filter groups:

- **Transmission type**: *All*, *Tx*, *Rx*, or *CiC* (carrier-in-carrier).
- **Link type**: *All*, *User*, *Feeder*, *Uplink*, or *Downlink*.
- **Status**: *All*, *Active*, *Draft*, *Deprecated*, or *Error*.

You can also search by beam name. To clear a filter, click the cross next to it.

## Adding a beam

1. On the *Beams* page, click *Add beam*.

1. Fill in the beam properties:

   ![The Add Beam dialog showing the link type dropdown with Feeder, User, Uplink, and Downlink options](~/solutions/images/SO_SI_Add_Beam.png)

   - *Beam Name*: a descriptive name for the beam.
   - *Beam Satellite*: the satellite the beam belongs to.
   - *Link Type*: the link type of the beam (*Feeder*, *User*, *Uplink*, or *Downlink*).
   - *Transmission Type*: the transmission type (*TX*, *RX*, or *Carrier in Carrier*).
   - *Footprint File*: a path or URL to the KML file that describes the beam footprint.

1. Click *Create Beam*.

> [!NOTE]
> Beam footprints are defined with KML files. Support for GeoJSON files is planned for a future release. You can point to a public URL or upload the file via the document hub.

## Editing a beam

To edit a beam, click the ![Edit](~/solutions/images/SO_SI_Edit_Icon.png) pencil icon on the right side of the beam row. This opens a dialog where you can change any of the beam properties. Click *Update Beam* to save.

![The Update Beam dialog with the beam name, satellite, link type, transmission type, and footprint file fields](~/solutions/images/SO_SI_Edit_Beam.png)

## Activating a beam

After you create a beam, you must activate it before it becomes available in the system.

> [!IMPORTANT]
> A newly created beam starts in the *Draft* state. To activate it, click *More* (the ![More](~/solutions/images/SO_SI_More_Icon.png) "..." button) and select the activate action.

## Viewing a beam footprint

When a beam has a footprint file, you can display it on a geographical map to see the area it covers. Click the footprint icon in the beam row to open the map view.

![The Satellite Inventory app with a beam footprint shown on a geographical map in a side panel, covering Europe and the Mediterranean](~/solutions/images/SO_SI_Beam_Footprint.png)

The map opens as a side panel over the beam list, so you keep the context of the beam you are inspecting.

> [!NOTE]
> The footprint shown above comes from a self-made KML file that is used for documentation purposes only. Real beam footprints have a more irregular shape that reflects the actual signal coverage of the beam.

## Deprecating a beam

You can edit a beam or deprecate it, but you cannot delete it. To deprecate a beam, click *More* and select the deprecate action.

> [!WARNING]
> Beams can never be deleted, by design. To take a beam out of use, deprecate it instead. This keeps the historical inventory intact.
