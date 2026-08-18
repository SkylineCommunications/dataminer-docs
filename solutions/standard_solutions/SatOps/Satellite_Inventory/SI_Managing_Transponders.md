---
uid: SI_Adding_Editing_Transponders
description: Learn how to manage transponders, transponder plans, and transponder slots in the Satellite Inventory app.
---

# Adding and editing transponders

A *transponder* belongs to a [beam](xref:SI_Managing_Beams) and relays signals within that beam. Its bandwidth is divided into bookable slots through [transponder plans](xref:SI_Transponder_Plans). The *Transponders* page lists the configured transponders and lets you manage them.

![The Transponders page listing the configured transponders](~/solutions/images/SO_SI_Transponders_Page.png)

## Adding a transponder

To add a transponder:

1. On the *Transponders* page, click *Add transponder*.

   ![The Add transponder dialog with the transponder fields](~/solutions/images/SO_SI_Add_Transponder.png)

1. Provide the following information about the transponder:

   - *Transponder Name*: The name of the transponder.
   - *Transponder Satellite*: The satellite the transponder belongs to.
   - *Beam*: The beam the transponder belongs to.
   - *Band*: The frequency band.
   - *Bandwidth (MHz)*: The bandwidth of the transponder, expressed in MHz.
   - *Center Frequency (MHz)*:
   - *Polarization*: The polarization type: *Linear* or *Circular*.
   - *Downlink Center Frequency (MHz)*:The center frequency of the downlink.
   - *Hard End Date*: The date on which the transponder stops being available.
   - *Phone Number*: A contact phone number.
   - *Uplink Polarization*: The uplink polarization within the selected polarization type (e.g., *Horizontal* or *Vertical*).
   - *Downlink Polarization*: The downlink polarization within the selected polarization type (e.g., *Horizontal* or *Vertical*).

1. Click *Create transponder*.

> [!NOTE]
> When editing numeric fields such as the *Bandwidth* or *Downlink Center Frequency*, position the cursor on the digit you want to modify before typing. This is a known usability limitation that may be addressed in a future release.

## Activating a transponder

After you create a transponder, its state will automatically be set to *Draft*. You must first activate the transponder before it becomes available in the system.

To activate a transponder:

1. Click the ![More](~/solutions/images/SO_SI_More_Icon.png) *More* icon in the transponder's row.

1. Select *Activate*.

## Editing a transponder

To edit a transponder:

1. Click the ![Edit](~/solutions/images/SO_SI_Edit_Icon.png) *Edit* icon in the transponder's row.

   This opens a panel where you can modify the transponder properties.

1. Click *Update transponder* to save your changes.

## Transponder plans and slots

Each transponder's bandwidth is divided into slots by one or more transponder plans. From a transponder, you can open the *Slots* page to create plans and generate the slots that become bookable in Satellite Scheduling. For more information, see [Transponder plans and slots](xref:SI_Transponder_Plans).
