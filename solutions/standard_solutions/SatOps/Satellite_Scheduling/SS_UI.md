---
uid: SS_UI
description: Explore the Satellite Scheduling UI, including the transponder timeline, filtering options, read and edit modes, and navigation between apps.
---

# Satellite Scheduling UI

## Transponder timeline

The Satellite Scheduling UI is centered around a **transponder timeline**  that shows all transponder slots and existing bookings.

![The Satellite Scheduling transponder timeline in read mode, showing transponder slots and existing bookings](~/solutions/images/SO_SS_Timeline_Read_Mode.png)

Each slot is listed vertically and shows its name and bandwidth size, for example "A9 - 9 MHz". The border color of each slot indicates the slot size (e.g., 3 MHz, 9 MHz, etc.), which makes it easy to see how capacity is distributed.

The timeline initially shows slots at the *Default Slot Size*, configured for the transponder plan in the [Satellite Inventory app](xref:SI_Transponder_Plans). However, you can then [filter the timeline](#filtering-the-timeline) to show only slots of a specific size.

## Filtering the timeline

On the left, you can filter the timeline:

- Search by *Job name*.

- Search by *Satellite*.

You can also filter the timeline by slot size using the color-coded size buttons at the top.

> [!NOTE]
> To book a slot of a specific size (e.g., 6 MHz), first filter the timeline to that size. Only slots that match the selected size are then available for booking.

## Read and edit mode

The app has two modes, which you can select with the *Read* and *Edit* buttons at the top left:

- **Read mode**: Browse the timeline and view existing bookings. You can scroll horizontally and vertically, but you cannot make changes.

- **Edit mode**: Create or change bookings by interacting with the timeline.

## Navigating between apps

You can navigate between the Satellite Scheduling and Satellite Inventory apps:

- Click a transponder name in the timeline to navigate to that transponder in the Satellite Inventory app.

- From the Satellite Inventory *Slots* panel, click *Open in Satellite Scheduling* to jump to the timeline for that transponder.
