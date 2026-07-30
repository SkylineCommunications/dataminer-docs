---
uid: SI_Managing_Beams
description: Learn how to add and manage the beams of a satellite in the Satellite Inventory app.
---

# Managing beams

A *beam* represents a coverage area of a [satellite](xref:SI_Managing_Satellites) and groups one or more [transponders](xref:SI_Managing_Transponders). The *Beams* page lists the configured beams and lets you manage them.

![The Beams page listing the configured beams](~/solutions/images/SO_SI_Beams_Page.png)

## Filtering the beam list

At the top of the page, you can filter the beams by:

- *Transmission type*: transmit (Tx), receive (Rx), or carrier-in-carrier (CiC).
- Beam *name*.

To clear a filter, click the cross next to it.

## Adding or editing a beam

1. On the *Beams* page, add a new beam or click the pencil icon to edit an existing one.

   ![The beam dialog with the footprint file, link type, transmission type, and satellite fields](~/solutions/images/SO_SI_Edit_Beam.png)

1. Fill in the beam properties:

   - *Footprint file*: the file that describes the beam footprint. You can embed the file directly, or point to a public URL that hosts it.
   - *Link type*
   - *Transmission type*
   - *Satellite*: the satellite the beam belongs to.

1. Save the beam.

> [!NOTE]
> From SatOps 2.0 onwards, beam footprints are defined with KML files. Support for GeoJSON files is planned for a future release.

## Viewing a beam footprint

When a beam has a footprint file, you can display it on a geographical map to see the area it covers.

![A beam footprint displayed on a geographical map, covering Europe](~/solutions/images/SO_SI_Beam_Footprint.png)

## Deprecating a beam

You can edit a beam or deprecate it, but you cannot delete it.

> [!WARNING]
> Beams can never be deleted, by design. To take a beam out of use, deprecate it instead. This keeps the historical inventory intact.
