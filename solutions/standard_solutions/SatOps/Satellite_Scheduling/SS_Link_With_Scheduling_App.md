---
uid: SS_Link_With_Scheduling_App
description: Learn how to book transponder slots from the MediaOps Plan Scheduling app using the Slot Picker integration.
---

# Link with scheduling app

The Satellite Scheduling app is tightly integrated with the [MediaOps Plan](xref:MediaOps.Plan) Scheduling app. You can book transponder capacity in two ways:

- Directly from the Satellite Scheduling app (see [Introduction](xref:SS_Introduction)).
- From the MediaOps Plan Scheduling app, by adding a transponder resource pool to a job. This is described below.

Both approaches create the same result: a MediaOps job with a booked transponder resource.

## Booking from the Scheduling app

To book transponder capacity from the MediaOps Plan Scheduling app:

1. In the Scheduling app, create a new job. Set the *Start Date Time*, *End Date Time*, and optionally a *Job Name*.

   > [!TIP]
   > Set the job status to *Tentative* to immediately confirm the booking.

1. In the job, scroll down to the *Nodes* section and click *Add Node*.

1. Add a **Transponders** resource pool.

   ![A job in the Scheduling app with a Transponders resource pool added to the Nodes section](~/solutions/images/SO_SS_Scheduling_Job_Transponder.png)

1. Click the configuration icon on the Transponders resource pool to configure the capabilities.

   The *Select Configuration* dialog opens.

   ![The Select Configuration dialog where you select the satellite and bandwidth size capabilities](~/solutions/images/SO_SS_Capabilities_Dialog.png)

1. Under *Capabilities*, select the satellite and optionally the bandwidth size to narrow down which transponder slots are offered.

1. Click *Update*.

1. Click the hand icon on the Transponders resource pool to select a slot.

   The **Slot Picker** page opens in Satellite Scheduling. It shows the available slots on the transponder timeline, filtered by the capabilities you selected.

   ![The Slot Picker page showing available transponder slots for the selected capabilities](~/solutions/images/SO_SS_Slot_Picker.png)

1. Click an available slot (shown with a green outline) to book it.

   The booking is confirmed and the job now has a transponder resource assigned.

1. Return to the Scheduling app and confirm the job.

> [!NOTE]
> The Slot Picker page opens automatically because the system recognizes that a transponder resource pool requires a special booking flow through Satellite Scheduling.

## Swapping resources

If you need to move a booking to a different slot, you can swap the transponder resource. In the Slot Picker, the currently booked slot is shown with a red outline and the other available slots are shown with a green outline. Click a different available slot to move the booking to it. The slot name of the transponder is shown between brackets next to the transponder name for easy identification.

![The Slot Picker in Satellite Scheduling showing a booked slot and the available slots it can be swapped to](~/solutions/images/SO_SS_Swap_Resource.png)
