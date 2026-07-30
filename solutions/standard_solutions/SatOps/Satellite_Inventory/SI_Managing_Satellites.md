---
uid: SI_Managing_Satellites
description: Learn how to add and manage satellites in the Satellite Inventory app.
---

# Managing satellites

The *Satellites* page is the main page of the Satellite Inventory app. It lists every satellite configured in SatOps and is your starting point for adding satellites and drilling down into their beams and transponders. A *satellite* is the top-level entry in the inventory and groups one or more [beams](xref:SI_Managing_Beams).

![The Satellites page listing the configured satellites](~/solutions/images/SO_SI_Satellites_Page.png)

## Filtering the satellite list

At the top of the page, you can narrow down the list:

- Search by satellite *name*.
- Filter by *hemisphere*.
- Filter by *state*: *Active*, *Draft*, or *Deprecated*.

## Adding a satellite

You can add satellites in several ways:

- Manually, through the *Add satellite* dialog.
- In bulk, by importing an Excel file. You can download a predefined template from the app, fill it in, and import it.
- From code, because Satellite Inventory is built on a DataMiner DevPack. You can create or edit satellites from an Automation script or through an agent in the DataMiner assistant.

To add a satellite manually:

1. On the *Satellites* page, click *Add satellite*.

   ![The Add satellite dialog with the satellite fields](~/solutions/images/SO_SI_Add_Satellite.png)

1. Fill in the satellite fields (see [Satellite fields](#satellite-fields) below).

1. Click *Next* to fill in the additional metadata, such as the manufacturer, country, and launch dates.

   To set a date, use the date picker or type the date directly.

1. Click *Create satellite*.

> [!NOTE]
> When you fill in numeric fields such as the longitude or inclination, position the cursor at the correct digit before typing. This is a known usability limitation that may be improved in a later release.

## Editing and activating a satellite

- To edit a satellite, click the pencil (*Edit satellite*) icon on the right. This opens a panel where you can change any of the fields. Click *Update satellite* to save, or click outside the panel to discard your changes. If a value is not valid, the panel flags it and prevents you from saving until you correct it.

  ![The edit panel of a satellite showing its fields](~/solutions/images/SO_SI_Edit_Satellite.png)

- To activate a satellite, click *More* and select the activate action.

## Satellite fields

| Field | Description |
|-------|-------------|
| Name | The name of the satellite. |
| Abbreviation | A short abbreviation for the satellite. |
| Orbit | The orbit type: *Geo*, *Meo*, or *Leo*. |
| Hemisphere | The hemisphere the satellite covers: eastern or western. |
| Longitude | The orbital longitude. This is an important field for satellites in a geostationary (*Geo*) orbit. |
| Inclination | The orbital inclination. For a geostationary orbit, this is 0. |
| Operator | The satellite operator. |
| Coverage | The coverage of the satellite. |
| Application | The application of the satellite, for example broadcast. |
| Information | Free-form additional information. |
| Manufacturer | The manufacturer of the satellite. |
| Country | The country associated with the satellite. |
| Launch and in-service dates | The launch and in-service dates, set with the date picker. |
