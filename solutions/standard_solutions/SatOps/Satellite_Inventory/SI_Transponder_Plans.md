---
uid: SI_Transponder_Plans
description: Learn how to define permanent and temporary transponder plans in the Satellite Inventory app and generate the bookable transponder slots.
---

# Transponder plans and slots

A *transponder plan* defines how the bandwidth of a [transponder](xref:SI_Adding_Editing_Transponders) is divided into slots. The *transponder slots* generated from a plan are the bookable units of capacity that appear in the [Satellite Scheduling](xref:Satellite_Scheduling) app. You manage plans from the *Slots* page of a transponder.

## Permanent and temporary plans

There are two kinds of plan:

- Permanent plan: the base plan of a transponder. It always applies unless a temporary plan overrides it. A transponder can have only one permanent plan.
- Temporary plan: a time-boxed plan that overrides the permanent plan for a specific date range.

The following diagram shows how the two combine over time. Wherever a temporary plan is active, Satellite Scheduling books against it. Outside that range, it falls back to the permanent base plan.

![Diagram showing a permanent base plan overridden by a temporary plan for a date range, and the resulting effective plan used by Satellite Scheduling](~/solutions/images/SO_SI_Plan_Types_Timeline.png)

> [!WARNING]
> A transponder can have only one permanent plan. Temporary plans must not overlap each other.

The example below shows an existing permanent plan for transponder 1 of Eutelsat 7C. It has a range of 36 MHz and defines slots of 3, 6, 12, and 18 MHz. The permanent (base) plan is marked with an infinity icon.

![An existing permanent transponder plan with slots of 3, 6, 12, and 18 MHz](~/solutions/images/SO_SI_Permanent_Plan.png)

## Creating a plan

1. Open the *Slots* page of a transponder and start a new plan.

   ![The Create plan dialog with several bandwidth rows](~/solutions/images/SO_SI_Create_Plan.png)

1. Fill in the plan details:

   - *Name*: a name for the plan.
   - *Date range* (temporary plans only): the period during which the plan applies, for example 1 August to 31 August.
   - *Default slot size*: the slot size used when the plan opens in Satellite Scheduling.

1. Add one or more bandwidth rows. Each row generates a set of slots and has the following settings:

   | Setting | Description |
   |---------|-------------|
   | Bandwidth | The width of each slot in this row, in MHz. |
   | Step size | The distance between the start of one slot and the start of the next. It cannot be smaller than the bandwidth. |
   | Offset | The frequency at which the first slot of the row starts. |
   | Limit | The maximum frequency the slots of this row can reach. By default, this equals the bandwidth range of the transponder. |

1. Click *Create plan*.

### Worked example

The following rows illustrate how the settings interact on a 36 MHz transponder:

- Bandwidth 36, step size 36, offset 0, limit 36: one slot that fills the entire capacity.
- Bandwidth 18, step size 18, offset 0: slots of 18 MHz placed back to back, 18 MHz apart.
- Bandwidth 18, step size 18, offset 7: the same, but the first slot starts at 7 MHz instead of 0.
- Bandwidth 9, step size 12, offset 2: because the step size (12) is larger than the bandwidth (9), a 3 MHz gap is left between consecutive slots.
- Bandwidth 3, step size 3, offset 0, limit 12: 3 MHz slots that stop at 12 MHz, so only the first 12 MHz of the 36 MHz capacity is used.

> [!NOTE]
> The step size of a row can never be smaller than its bandwidth. When the step size is larger than the bandwidth, a gap is left between consecutive slots. When it equals the bandwidth, the slots are placed back to back.

## Generating slots

Creating a plan does not generate its slots automatically. You generate them from the plan itself.

1. Select the plan and click the *Create slots* (play) button.

   ![The Create slots (play) button on a transponder plan](~/solutions/images/SO_SI_Generate_Slots.png)

   > [!WARNING]
   > Generating slots overrides any slots that were previously generated for that plan.

1. The slots are generated based on the plan configuration.

   The app immediately shows a visualization of the resulting slot layout. A details pane provides more information about the transponder, because the slots are expressed as relative frequencies that take the start and end frequency of the full transponder into account.

   ![The generated transponder slots with a details pane](~/solutions/images/SO_SI_Transponder_Slots.png)

## Editing a slot name

After generating slots, you can override the name and start frequency of individual slots. Click the ![Edit](~/solutions/images/SO_SI_Edit_Icon.png) pencil icon next to a slot to open the *Update Slot* dialog.

![The Update Slot dialog where you can change the slot name and start frequency](~/solutions/images/SO_SI_Update_Slot.png)

- *Slot Name*: override the auto-generated name with a custom one.
- *Slot Start Frequency (MHz)*: adjust the start frequency of the slot.

Click *Update Slot* to save the change.

> [!WARNING]
> If you regenerate the slots for a plan by clicking *Create slots* again, any custom slot names or start frequencies you set are overwritten.

## Activating a plan

> [!IMPORTANT]
> After you create a plan, you must activate it. A plan that is not activated has no effect.

Once activated, the plan appears in the plan overview together with the other plans of the transponder. In the overview, you can clearly distinguish the permanent plan (marked with the infinity icon), the temporary plans, and the plan that is currently active.

![The plan overview showing the permanent, temporary, and active plans of a transponder](~/solutions/images/SO_SI_Plan_Overview.png)

## From plan to schedule

The generated slots are what Satellite Scheduling books against. From a plan, you can jump straight to the corresponding view in the [Satellite Scheduling](xref:Satellite_Scheduling) app to see what is booked, and jump back to the transponder in Satellite Inventory. Because the effective plan changes over time, the scheduling timeline always reflects the plan that applies at each moment. In the example, 6 MHz slots are bookable under the permanent plan, while 9 MHz slots become bookable during the temporary plan in August.
