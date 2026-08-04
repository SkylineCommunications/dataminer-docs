---
uid: SI_Introduction
description: Get an introduction to the Satellite Inventory app and its main concepts, including satellites, beams, transponders, transponder plans, and slots.
---

# Introduction

The Satellite Inventory app lets you build and maintain a complete model of your satellite fleet. It is structured around the following main concepts:

- **Satellite**: The top-level entry in the inventory. A satellite groups one or more beams.
- **Beam**: A coverage area of a satellite. Beam footprints and satellite coverage areas can be displayed on a geographical map using KML files. A beam groups one or more transponders.
- **Transponder**: A repeater on the satellite that relays signal within a beam. Each transponder has a bandwidth that is divided into slots.
- **Transponder plan**: A time-boxed (or permanent base) layout that defines how a transponder's bandwidth is divided into slots. Transponder slots are generated from these plans.
- **Transponder slot**: A bookable unit of transponder capacity, scheduled in the [Satellite Scheduling](xref:Satellite_Scheduling) app.

The satellite hierarchy (satellite, beams, transponders) can be visualized in an interactive node edge graph, and transponder plan layouts can be inspected slot by slot.

![The interactive node edge graph for the Eutelsat 7C satellite, showing the satellite node connected to its transponders (T-01 and T-02) and beams (Europe A 1 and Europe A 2)](~/solutions/images/SO_SI_Node_Edge_Graph.png)

To quickly set up an environment for evaluation, you can import satellite demo data from a predefined template.

> [!NOTE]
> The Satellite Inventory app works on top of the [MediaOps Plan](xref:MediaOps.Plan) Resource Studio. Each transponder you create is also a DataMiner resource, so the transponders you manage here are the same ones that [Satellite Scheduling](xref:Satellite_Scheduling) books against. Satellite Inventory adds the satellite-specific structure, such as satellites, beams, transponder plans, and slots, on top of those resources.

## Navigating the app

Open the left panel to switch between the four pages of the app: *Satellites*, *Transponders*, *Beams*, and *About*. The *Satellites* page is the main page and your usual starting point.

![The navigation panel of the Satellite Inventory app showing the Satellites, Transponders, Beams, and About pages](~/solutions/images/SO_SI_Navigation.png)

## About page

The *About* page shows the version of the app and the version of the SatOps Catalog package you are working with. This is useful to know exactly which version of the standard solution you are on. At the bottom of the page, the *Help* button links to the official SatOps documentation on DataMiner Docs.

![The About page showing the app version and the SatOps package version](~/solutions/images/SO_SI_About_Page.png)
