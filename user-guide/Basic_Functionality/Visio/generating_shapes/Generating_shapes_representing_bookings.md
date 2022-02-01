---
uid: Generating_shapes_representing_bookings
---

# Generating shapes representing bookings

From DataMiner 10.0.9 onwards, you can specify that a shape should be created automatically for each booking in a particular set of bookings.

To do so:

1. Create the shape representing the booking items, add a **ChildType** shape data field to that shape, and set its value to *Booking*.

2. Create a shape group containing the ChildType shape, add a **Children** shape data field to the shape group, and set its value to *Booking*.

    By default, all bookings in the Cube cache will be shown. If that cache does not contain any bookings, then a default set of bookings will be retrieved (i.e. from 1 day in the past to 2 days in the future).

3. Optionally, you can further refine which bookings should be shown:

    - To add bookings from a specific time range, add a **ChildrenSource** shape data field to the shape group and set its value to that time range (e.g. “StartTime=\<dateTime>; EndTime=\<dateTime>”).

        > [!NOTE]
        > Using a *ChildrenSource* shape data field set to a specific time range will add the bookings in this time range to the ones that are already in the cache. This means that if there were other bookings in the cache already, shapes will be generated for those as well. If you want to filter the bookings to only show shapes in a specific time range, use a *ChildrenFilter* shape data field instead.

    - To filter the bookings, add a **ChildrenFilter** shape data field to the shape group and set its value to a booking filter, using the same filter format as is used when specifying a *ListView* filter. See [List view filters](xref:Creating_a_list_view#list-view-filters).

    - To sort the bookings, add a **ChildrenSort** shape data field to the shape group and set its value to “Name” (i.e. the default setting), “Property\|Start time” or “Property\|End time”, optionally followed by “,asc” (i.e. the default order) or “,desc”.

> [!NOTE]
> Dynamically generated booking shapes are functionally identical to shapes linked to bookings using a *Reservation* data field. For example, they support the same placeholders.
>
