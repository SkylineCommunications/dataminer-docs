---
uid: SI_Transponder_Plans
description: Learn how to define permanent and temporary transponder plans in the Satellite Inventory app and generate bookable transponder slots.
---

# Transponder plans and slots

A *transponder plan* defines how the bandwidth of a [transponder](xref:SI_Adding_Editing_Transponders) is divided into slots. The *transponder slots* generated from a plan are the bookable units of capacity that appear in the [Satellite Scheduling app](xref:Satellite_Scheduling).

You manage transponder plans from the *Slots* panel of a transponder.

## Permanent and temporary plans

There are two types of transponder plans:

- Permanent plan: The base plan of a transponder. It applies unless a temporary plan overrides it. A transponder can have **only one permanent plan**.

- Temporary plan: A time-boxed plan that overrides the permanent plan during a specific date range. Temporary plans **cannot overlap**.

The following diagram shows how permanent and temporary plans combine over time. The upper row shows the plans configured for the transponder. The lower row shows the effective plan used by Satellite Scheduling. During the temporary plan’s date range, the temporary plan overrides the permanent plan. Before and after that date range, the permanent plan applies.

![Illustration that shows that when there is a permanent plan and a temporary plan at the same time, the permanent plan is overridden during that time range and the Satellite Scheduling app uses that plan for bookings](~/solutions/images/SO_SI_Plan_Types_Timeline.png)

The following example shows an existing permanent plan for transponder 1 of Eutelsat 7C. The transponder has a bandwidth range of 36 MHz, and the plan defines slots of 3, 6, 12, and 18 MHz. The permanent plan is marked with an infinity icon.

![An existing permanent transponder plan with slots of 3, 6, 12, and 18 MHz](~/solutions/images/SO_SI_Permanent_Plan.png)

## Creating a plan

1. On the *Transponders* page, click the ![Slots](~/solutions/images/SO_SI_Slots_Icon.png) *Slots* icon in the row of the transponder for which you want to create a transponder plan.

1. Click *Add plan* in the lower-left corner.

   ![The Create plan dialog with several bandwidth rows](~/solutions/images/SO_SI_Create_Plan.png)

1. Specify the plan details:

   - *Plan Name*: Enter a name for the plan.

   - *Permanent Plan*: Enable this setting to create a permanent plan. If you leave this setting disabled, a temporary plan is created.

   - *Start Date Time* (temporary plans only): Specify the date and time from which the plan applies.

   - *End Date Time* (temporary plans only): Specify the date and time until which the plan applies.

   - *Default Slot Size (MHz)*: Specify the slot size selected by default when the plan is opened in Satellite Scheduling.

1. Under *Transponder Plan Config*, click the "+" button to add one or more bandwidth rows.

   Each row generates a set of slots.

1. Specify the following settings for each row:

   - *Bandwidth (MHz)*: The width of each slot.

   - *Step Size (MHz)*: The distance between the start of one slot and the start of the next.

     - The step size cannot be smaller than the bandwidth.

     - If the step size is larger than the bandwidth, a gap is left between consecutive slots.

     - If the step size equals the bandwidth, the slots are placed back to back.

   - *Offset (MHz)*: The frequency at which the first slot in the row starts.

   - *Limit*: The maximum frequency that the slots in the row can reach. By default, this value corresponds to the bandwidth range of the transponder.

1. Click *Create plan*.

   The plan is added to the overview in the pane on the right. An infinity icon in front of the plan name identifies a permanent plan.

   By default, the plan is in the *Draft* state. Before the plan can take effect, you [must activate it](#activating-a-plan).

### Examples

The following rows illustrate how the settings interact for a transponder with a bandwidth range of 36 MHz:

- Bandwidth 36, step size 36, offset 0, limit 36: Generates one slot that uses the entire capacity.

- Bandwidth 18, step size 18, offset 0: Generates 18 MHz slots placed back to back.

- Bandwidth 18, step size 18, offset 7: Generates the same arrangement, but the first slot starts at 7 MHz instead of 0 MHz.

- Bandwidth 9, step size 12, offset 2: Generates 9 MHz slots with a 3 MHz gap between consecutive slots because the step size is 3 MHz larger than the bandwidth.

- Bandwidth 3, step size 3, offset 0, limit 12: Generates 3 MHz slots up to the 12 MHz limit. As a result, only the first 12 MHz of the available 36 MHz capacity is used.

## Generating slots

Creating a plan does not automatically generate its slots.

To generate the slots:

1. On the *Slots* panel, click the ![Create slots](~/solutions/images/SO_SI_Create_Slots_Icon.png) *Create Slots* icon next to the transponder plan for which you want to generate slots.

   ![The Create slots (play) button on a transponder plan](~/solutions/images/SO_SI_Generate_Slots.png)

1. In the pop-up window, select *Create Slots*.

   > [!IMPORTANT]
   > Any previously generated slots for the plan will be replaced.

   The slots are generated based on the *Transponder Plan Config* settings configured for the plan.

   The app immediately shows a visualization of the resulting slot layout. A details pane provides more information about the transponder. This information is relevant because slot frequencies are expressed relative to the start and end frequencies of the complete transponder.

   ![The generated transponder slots with a details pane](~/solutions/images/SO_SI_Transponder_Slots.png)

## Editing a slot

After generating the slots, you can change the auto-generated name and the start frequency of an individual slot:

1. Click the ![Edit](~/solutions/images/SO_SI_Edit_Icon.png) *Edit* icon next to the slot.

   The *Update Slot* dialog opens.

1. Modify the *Slot Name* and *Slot Start Frequency*.

1. Click *Update Slot* to save your changes.

![The Update Slot dialog where you can change the slot name and start frequency](~/solutions/images/SO_SI_Update_Slot.png)

## Activating a plan

After a plan is created, its state is automatically set to *Draft*. You must activate the plan before it takes effect.

To activate a plan:

1. Click the ![More](~/solutions/images/SO_SI_More_Icon.png) *More* icon next to the transponder plan name.

1. Select *Activate* from the context menu.

## From plan to schedule

The generated slots are the units of capacity that can be booked in Satellite Scheduling. From a plan, you can go directly to the corresponding view in the [Satellite Scheduling app](xref:Satellite_Scheduling) to see the bookings and then return to the transponder in the Satellite Inventory app.

Because the effective plan can change over time, the scheduling timeline always reflects the plan that applies at each point in time. In the example below, 6 MHz slots are bookable under the permanent plan, while 9 MHz slots become bookable while the temporary plan is active in August.

![The Slots panel showing permanent and temporary transponder plans in the plan overview](~/solutions/images/SO_SI_Plan_Overview.png)
