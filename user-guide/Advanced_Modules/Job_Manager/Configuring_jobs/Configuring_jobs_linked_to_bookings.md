---
uid: Configuring_jobs_linked_to_bookings
---
# Configuring jobs linked to bookings
When you are configuring a booking type job section, you can specify a booking script that handles the creation, modification and deletion of a booking. See [Configuring job sections](xref:Configuring_job_sections).

The script will need 4 script parameters.
1. **JobID**: This will be the id of the job that you want to link the booking to.
2. **BookingManagerID**: This will be the DataMinerID/ElementID of the BookingManager that you linked in the booking section.
3. **BookingIDs**: This will be an comma separated list of booking IDs that you want to execute an action on.
4. **Command**: This will be 1 of 3 possible values (Add/Edit/Delete). The command will allow you to differentiate which action the booking script should execute inside the script.

The script should have a method that does creation, updating and deleting of a booking in this script.

Example of the creation logic:
1. Create the booking.
2. Fetch the job with the JobID.
3. Check if there already is a booking section on the job (otherwise create one).
4. Fetch the SectionDefinition from the Section via the SectionDefinitionID.
5. Find the ReservationFieldDescriptor on the SectionDefinition.
6. Link the bookingID to the section by using the following line of code.

`[A].AddOrReplaceFieldValue(new FieldValue([B]) { Value = new ValueWrapper<Guid>([C])};`

Replace [A] with the booking section of the job from step 3.

Replace [B] with the ReservationFieldDescriptor from step 5.

Replace [C] with the ID of the booking (This has to be a Guid).
