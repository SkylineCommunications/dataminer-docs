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

To quickly set up an environment for evaluation, you can import satellite demo data from a predefined template.
