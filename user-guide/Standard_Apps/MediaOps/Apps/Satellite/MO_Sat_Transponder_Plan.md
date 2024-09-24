---
uid: MO_Sat_Transponder_Plan
---

# Transponder Plan

Transponders are capacity-based resource, meaning that there is a fixed amount of bandwidth available on the Transponder. Each booking on a Transponder will use up a certain amount of that space. How many bookings can made on the Transponder depends on how big the Transponder is and the amount of bandwidth used by each booking.  

But when it comes to accounting for the capacity used on the resource, unlike a standard capacity-based resource like a 10 GB fiber line where it’s simply a matter of tracking how much of the capacity is used, Transponder capacity is “locational.” Meaning, not only do you have to account for how much, but you also have to account for WHERE on the transponder the capacity has been removed in order to prevent transmission overlaps which will render the feeds inoperable.  

To accomplish this, MediaOps subdivides the Transponder into Slots. When a slot is booked, MediaOps will check the availability not only of the requested slot, but also of the overlapping slots (see the animation below). If all of the slots are available, the system will reserve the necessary space in all resource to guarantee that portion of the Transponder will be available at the time the Job starts.

![Transponder Plan](~/user-guide/images/mo_sat_transponder_plans.gif)

## How to build a plan and deploy slots

Since a single transponder could consist of a large number of bookable slots, to make resource creation easy, MediaOps uses a Transponder Plan to help you define how the slots should look. That plan can then be assigned to a Transponder and the system will automatically create the bookable Slot Resources in the Resource Studio.

![Transponder Slots](~/user-guide/images/mo_sat_transponder_slots.png)

The Plan consists of Slot Definitions that define how Slots should be built across an assigned transponder. Each definition contains the following fields:

- **Slot Group Name**: is a descriptive name for the grouping. When the resources are generated when a Transponder Plan is assigned to a Transponder, a Resource Pool will be created to contain the Slot Resources. The value in this field will be used as part of the Resource Pool Name by appending the Slot Group Name to the work “Transponder.” For example, if the Slot Group Name was “18 MHz Slots,” the Resource Pool for this group of slots would be called “Transponder 18 MHz Slots.”

- **Slot Size**: this value define how big each slot will be, which also indirectly affects how many slots are generated. Using the offset values described below, the system will create as many slots of the specified size as possible until it runs out of space. For example, if a plan with a definition that includes Slot Size of 9 (MHz) is applied to a 36 MHz transponder without offsets, a total of 4 slots will be created

- **From offset**: The From and To offsets allow you to have more control over the shaping of the slots if you do not wish the slots to cover the whole transponder. The From offset is the distance between the starting frequency of a transponder and where MediaOps will start to build slots.

- **To offset**: is the point at which slot creation on a transponder will stop. The value is a measure of the distance from the start of the transponder to the point slots should no longer be created.

Below screenshots demonstrate how offsets can be used for the creation of 4.5MHz slots on a 18MHz Transponder. If we define no offsets, then the full 18MHz transponder slot will be used:
![Transponder Offsets](~/user-guide/images/mo_sat_transponder_offsets.png)

If we define a **From Offset** of 9MHz, then slots will only be created from 9MHz:
![Transponder Offsets](~/user-guide/images/mo_sat_transponder_offsets_from.png)

If we define a **To Offset** of 9MHz, then slots will only be created up to 9MHz before the Stop frequency of the Transponder:
![Transponder Offsets](~/user-guide/images/mo_sat_transponder_offsets_to.png)
