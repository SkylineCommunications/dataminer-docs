---
uid: Configuring_jobs_linked_to_bookings
---

# Configuring jobs linked to bookings

You can configure the Jobs app to create and manage bookings linked to each job.

For this purpose, when you configure the relevant job section (see [Configuring job sections](xref:Configuring_job_sections)), specify the Booking Manager element and the booking script you want to use.

The booking script is a script that handles the creation, modification, and deletion of bookings. This script needs to have the following script parameters:

- **JobID**: The ID of the job the booking should be linked to.
- **BookingManagerID**: The DataMiner ID/Element ID combination of the Booking Manager specified in the job section configuration.
- **BookingIDs**: A comma-separated list of booking IDs an action should be executed on.
- **Command**: The command *Add*, *Edit*, or *Delete*. This command allows you to determine which action the booking script should execute in the script.

The script has to contain a method that takes care of the creation, updating, and deletion of a booking.

Example of the creation logic:

1. Create the booking.
1. Fetch the job with the job ID.
1. Check if there already is a booking section in the job (otherwise create one).
1. Fetch the section definition from the section via the section definition ID.
1. Find the "ReservationFieldDescriptor" of the section definition.
1. Link the booking ID to the section by using the following line of code:

   `[A].AddOrReplaceFieldValue(new FieldValue([B]) { Value = new ValueWrapper<Guid>([C])};`

   - Replace [A] with the booking section of the job from step 3.

   - Replace [B] with the ReservationFieldDescriptor from step 5.

   - Replace [C] with the ID of the booking (this has to be a GUID).
