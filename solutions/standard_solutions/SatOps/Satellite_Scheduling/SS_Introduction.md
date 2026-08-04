---
uid: SS_Introduction
description: Get an introduction to the Satellite Scheduling app and its transponder timeline for booking transponder capacity.
---

# Introduction

The Satellite Scheduling app lets you schedule the use of the transponder capacity modeled in the [Satellite Inventory](xref:Satellite_Inventory) app. It is an add-on to the [MediaOps Plan](xref:MediaOps.Plan) Scheduling app that adds specialized functionality for booking transponder resources.

## Transponder timeline

At the center of the app is a **transponder timeline** that shows all transponder slots and their bookings. Color coding at the top of the timeline indicates the slot sizes (e.g., 3 MHz, 9 MHz, 18 MHz, 36 MHz), making it easy to see how capacity is distributed.

![The Satellite Scheduling transponder timeline in read mode, showing transponder slots and existing bookings](~/solutions/images/SO_SS_Timeline_Read_Mode.png)

On the left, you can filter the timeline:

- Search by *Job name*.
- Search by *Satellite*.

The timeline shows one transponder at a time with its slots listed vertically. Each slot shows its name and bandwidth size (e.g., "A9 - 9 MHz").

## Read and edit mode

The app has two modes, toggled with the *Read* and *Edit* buttons at the top left:

- **Read mode**: browse the timeline and view existing bookings. You can scroll horizontally and vertically but cannot make changes.
- **Edit mode**: make new bookings by clicking on available slots in the timeline.

## Making a booking

To book transponder capacity directly from the Satellite Scheduling app:

1. Switch to *Edit* mode.

1. Click on an available slot in the timeline at the desired time.

   The *Create Job* dialog opens.

   ![The Create Job dialog with job name, start and end time, and frequency fields](~/solutions/images/SO_SS_Create_Job.png)

1. Optionally enter a custom *Job Name*. If you leave it empty, the system generates a default name.

1. Adjust the *Start Date Time* and *End Date Time* if needed.

1. Click *Create Job*.

   A MediaOps job is created with the transponder resource already booked.

> [!NOTE]
> You can also make bookings from the MediaOps Plan Scheduling app. For more information, see [Link with scheduling app](xref:SS_Link_With_Scheduling_App).

## Draft and tentative bookings

The state a new booking gets depends on when it is scheduled relative to the current time (the "now" line on the timeline):

- A booking placed in the future becomes a **tentative** booking. Tentative bookings reserve transponder capacity and appear on the timeline right away. You can then confirm the job to move it further along its lifecycle.
- A booking placed entirely in the past becomes a **draft** booking. Draft bookings do not reserve any capacity, so they are not shown on the timeline by design, even though the underlying job is created in the background.

> [!TIP]
> When you want to book new capacity, keep the "now" line toward the left of the time view so that there is room to place bookings in the future. Capacity you book to the right of "now" is reserved as tentative and is shown immediately.

## Moving a booking

In edit mode, you can drag and drop an existing booking to change it. Dragging a booking horizontally along the timeline reschedules it in time, while dragging it vertically adjusts its frequencies and transponder. The frequencies and transponder of a booking can only be changed by dragging it vertically, not by typing values in the dialog. The system prevents you from creating overlapping bookings.

## Opening and deleting a booking

Click on an existing booking in the timeline to open it. From there you can view the details of the associated job or delete the booking.

## Default slot size

When you open a transponder in Satellite Scheduling, the timeline initially shows slots at the *default slot size* configured in the transponder plan in [Satellite Inventory](xref:Satellite_Inventory). You can filter the timeline to show only slots of a specific size using the color-coded size buttons at the top.

> [!TIP]
> To book a slot of a specific size (e.g., 6 MHz), first filter to that size at the top of the timeline. Only slots that match the selected size are available for booking.

## Navigation between apps

- Click a transponder name in the timeline to navigate to that transponder in the Satellite Inventory app.
- From the Satellite Inventory slots view, click *Open in Satellite Scheduling* to jump to the timeline for that transponder.
