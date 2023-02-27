---
uid: Generating_shapes_representing_bookings
---

# Generating shapes representing bookings

From DataMiner 10.0.9 onwards, you can specify that a shape should be created automatically for each booking in a particular set of bookings.

To do so:

1. Create the shape representing a booking, and add the necessary child-level shape data fields to it. See [Child-level shape data](#child-level-shape-data).

1. Put the shape into a group, and add the necessary group-level shape data fields to the group. See [Group-level shape data](#group-level-shape-data).

   By default, from DataMiner 10.2.0 [CU10]/10.3.1 onwards, all bookings from one day in the past up to one day in the future are shown. Prior to DataMiner 10.2.0 [CU10]/10.3.1, all bookings in the Cube cache are shown. If that cache does not contain any bookings, then a default set of bookings is retrieved (i.e. from 1 day in the past up to 1 day in the future).

> [!NOTE]
> Dynamically generated booking shapes are functionally identical to shapes linked to bookings using a *Reservation* data field. For example, they support the same placeholders. See [Linking a shape to a booking](xref:Linking_a_shape_to_a_booking).

## Child-level shape data

The following shape data fields can be added to a shape that has to represent a booking:

- **ChildType**: In this mandatory shape data field, specify the following value:

  - Booking

- **ChildMargin**: In this optional shape data field, you can specify the space between the different child items within the container shape.

  - A space relative to the width of the shape representing a child item, or
  - A fixed space (in pixels).

  Examples:

  ```txt
  1/20
  ```

  If the child shapes have a width of 100 px, the space between the child shapes will be 5 px (a twentieth of 100 px).

  ```txt
  5
  ```

   The space between the child shapes will always be 5 px

## Group-level shape data

The following shape data fields can be added to the group containing the booking shapes:

- **Children**: In this mandatory shape data field, specify the following value:

  - Booking

  > [!NOTE]
  > With the DataMiner Cube user setting *Maximum number of child shapes in a Children container shape*, you can control the maximum number of Visio shapes allowed in a **Children** container shape. Default: 100

- **ChildrenOptions**: In this optional shape data field, you can specify the following option:

  - **Center**: If you want the generated shapes to be centered, then add a shape data field of type **ChildrenOptions** to the container shape, and set its value to "Center".

- **ChildrenSort**: In this optional shape data field, you can specify how the different child item shapes should be sorted. The following values are supported in this shape data field:

  - `Name`: Sorts by name. This is the default setting.
  - `Property|property=Start`: Sorts on the booking start time + the pre-roll time (based on the *Start* custom property of the *ReservationInstance* object). Supported from DataMiner 10.2.0 [CU10]/10.3.1 onwards.
  - `Property|Start time`: Sorts on the booking start time (based on the *Start* field of the *ReservationInstance* object).
  - `Property|End time`: Sorts on the booking end time (based on the *End* field of the *ReservationInstance* object).
  - `Property|property=End`: Sorts on the booking end time minus the post-roll time (based on the *End* custom property of the *ReservationInstance* object). Supported from DataMiner 10.2.0 [CU10]/10.3.1 onwards.

  Optionally, you can also add `,asc` (i.e. the default order) or `,desc` to specify the sort order, e.g. `Property|Start time,asc`.

  > [!NOTE]
  > If you want to sort on start or end time based on a custom property, make sure the property is stored as a DateTime object.

- **ChildrenFilter**: To filter the bookings, add a **ChildrenFilter** shape data field to the shape group and set its value to a booking filter, using the same filter format as is used when specifying a *ListView* filter. See [List view filters](xref:Creating_a_list_view#list-view-filters).

- **ChildrenPanel**: In this optional shape data field, you can specify how the child items have to be organized within the container shape.

  Possible values:

  - Stack
  - StackHorizontal
  - StackVertical
  - Grid\|Cols=999
  - Grid\|Rows=999
  - Wrap
  - WrapVertical
  - WrapHorizontal

- **ChildrenSource**: To add bookings from a specific time range, add a **ChildrenSource** shape data field to the shape group and set its value to that time range (e.g. “StartTime=\<dateTime>|EndTime=\<dateTime>”).

  > [!NOTE]
  >
  > - From DataMiner 10.2.0 [CU13]/10.3.4 onwards, if no *ChildrenSource* shape data field is configured, by default the start time is NOW - 8 hours and the end time is NOW + 16 hours. Prior to DataMiner 10.2.0 [CU10]/10.3.1, if no *ChildrenSource* shape data field is configured, by default the start time is yesterday (NOW - 1 day) and the end time is tomorrow (NOW + 1 day).
  > - Prior to DataMiner 10.2.0 [CU10]/10.3.1, using a *ChildrenSource* shape data field set to a specific time range will add the bookings in this time range to the ones that are already in the cache. This means that if there were other bookings in the cache already, shapes will be generated for those as well. If you want to filter the bookings to only show shapes in a specific time range, use a *ChildrenFilter* shape data field instead.
