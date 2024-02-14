---
uid: Configuring_spectrum_thresholds
---

# Configuring spectrum thresholds

In DataMiner Cube, you can define thresholds that can be used in scripts to detect spectrum threshold violations.

> [!NOTE]
> For more information on spectrum scripts, see [Working with spectrum scripts](xref:Working_with_spectrum_scripts).

## Threshold Edit Mode

To create or edit thresholds, you must first activate the Threshold edit mode:

1. On a spectrum analyzer card, go to the *thresholds* tab.

1. Click *Threshold edit mode*.

   The threshold editing options are now available, and in the information pane, the thresholds section is expanded.

To leave the mode, in the *thresholds* tab, click *Threshold edit mode* again.

## Creating spectrum thresholds

To create a threshold, while in Threshold edit mode:

1. Either in the *threshold* tab of the ribbon, or in the *threshold* section of the details pane, click *Add threshold*.

1. Click and drag in the display area to create a first section of the threshold, consisting of a starting and an ending point.

1. Repeat the previous step until you have drawn the complete threshold.

   To make changes as you work, you can do the following:

   - To move the threshold, click any of its sections and drag it to its new position.

   - To move a point, drag it to its new position. Points can be moved in any direction, but cannot be moved past adjacent points. While you are moving the point, a label will show its exact coordinates.

   - To delete a point, right-click it and select *Delete Point*.

   - To create an additional point right next to an existing point, right-click the existing point and select *Split*.

   - To create an additional point in the middle of an existing section, right-click the section and select *Split*.

   - To connect two adjacent points, right-click one of the points and select *Connect*.

   - To delete a section, right-click it and select *Delete Section*.

   - To delete a section adjacent to a point, you can also right-click the point and select *Delete left segment* or *Delete right segment*.

   - To remove all sections of the selected threshold, right-click anywhere on the threshold and select *Delete all*.

     Alternatively, you can also click *Remove threshold* in the *threshold* tab of the ribbon in order to remove a threshold completely.

1. To add an additional threshold, click *Add threshold* again, and repeat the procedure above.

> [!NOTE]
> To change the color of the thresholds on the display, in the *threshold* tab of the ribbon, click *Threshold color* and select the new color.
