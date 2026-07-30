---
uid: SI_Managing_Transponders
description: Learn how to manage transponders, transponder plans, and transponder slots in the Satellite Inventory app.
---

# Managing transponders

A *transponder* belongs to a [beam](xref:SI_Managing_Beams) and relays signal within that beam. Its bandwidth is divided into bookable slots through [transponder plans](xref:SI_Transponder_Plans). The *Transponders* page lists the configured transponders and lets you manage them.

![The Transponders page listing the configured transponders](~/solutions/images/SO_SI_Transponders_Page.png)

## Adding a transponder

1. On the *Transponders* page, click *Add transponder*.

   ![The Add transponder dialog with the transponder fields](~/solutions/images/SO_SI_Add_Transponder.png)

1. Fill in the transponder fields (see [Transponder fields](#transponder-fields) below).

1. Click *Create transponder*.

   By default, a new transponder is created in the *Draft* state.

> [!NOTE]
> As with satellites, take care when filling in numeric fields such as the bandwidth or center frequency: position the cursor at the correct digit before typing.

## Editing and activating a transponder

- To activate a transponder, click *More* and select the activate action.
- To edit a transponder, click the pencil icon, change the fields you need, and click *Update transponder*.

## Transponder fields

| Field | Description |
|-------|-------------|
| Name | The name of the transponder. |
| Satellite | The satellite the transponder belongs to. |
| Beam | The beam the transponder belongs to. |
| Band | The frequency band. |
| Bandwidth | The bandwidth of the transponder, in MHz. |
| Polarization | The polarization type: linear or circular. |
| Downlink center frequency | The center frequency of the downlink. |
| Hard end date | The date on which the transponder stops being available. |
| Phone number | A contact phone number. |
| Uplink and downlink polarization | The uplink and downlink polarization, for example horizontal or vertical. |

## Transponder plans and slots

Each transponder's bandwidth is divided into slots by one or more transponder plans. From a transponder, you can open the *Slots* page to create plans and generate the slots that become bookable in Satellite Scheduling. For more information, see [Transponder plans and slots](xref:SI_Transponder_Plans).
