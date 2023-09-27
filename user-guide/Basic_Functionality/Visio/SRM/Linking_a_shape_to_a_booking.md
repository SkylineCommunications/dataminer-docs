---
uid: Linking_a_shape_to_a_booking
---

# Linking a shape to a booking

From DataMiner 9.6.4 onwards, it is possible to link a shape to a booking using a **Reservation** shape data field.

> [!NOTE]
> If a parent shape has *Reservation* shape data and a child shape has fields linked to the same booking (e.g. *Info* shape data, shape text placeholders), the child shape will also become a reservation shape linked to the same booking.

## Basic shape data field configuration

Specify a **Reservation** shape data field and set it to one of the following values:

- The GUID of the booking

- A dynamic placeholder, e.g. *\[pagevar:SelectedReservation\]*

- A service name, service ID or placeholder referring to a service, e.g. *\[this service\]*. In that case, the *ReservationID* property of the service will be used.

## Placeholders

The following placeholders can be used in the text displayed on the *Reservation* shape:

- **\[Name\]**

  Will be replaced by the name of the booking linked to the shape.

- **\[Status\]**

  Will be replaced by the value of the *Status* property of the booking linked to the shape.

- **\[Start Time:format=\<format>\]**

  Will be replaced by the start time of the booking, converted to the DataMiner time.

  Optionally a colon (":") can be added within the placeholder, followed by the format in which the start time should be displayed. By default, this is the standard month format, followed by a space and the standard short time format.

  > [!NOTE]
  >
  > - For information on the standard date and time formats, refer to <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings>.
  > - For information on other possible date and time formats, refer to <https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings>.

- **\[End Time:format=\<format>\]**

  Will be replaced by the end time of the booking, converted to the DataMiner time.

  This placeholder supports the same optional format configuration as the *\[Start Time\]* placeholder.

- **\[Elapsed Time:format=\<format>,default=\<defaultValue>\]**

  Will be replaced by the amount of time that has passed since the booking started running. If the booking is not running, it is replaced by the default value. If no default value is specified and the booking is not running, nothing is displayed.

  Optionally, a colon (“:”) can be added within the placeholder, followed by the time format and a default value.

  By default, the format is "\[x days\] hh:mm:ss", where the number of days is only displayed if it is 1 or more, and the local language is used.

  > [!NOTE]
  > For information on other possible time formats, refer to <https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings>.

- **\[Time until start:format=\<format>,default=\<defaultValue>\]**

  Will be replaced by the amount of time that still has to pass until the booking starts. The placeholder is replaced by the default value when the current time is later than the booking start time. If no default value is specified in that case, nothing is displayed.

  This placeholder supports the same options as the *\[Elapsed Time\]* placeholder.

- **\[Remaining time:format=\<format>,default\<defaultValue>\]**

  Will be replaced by the amount of time remaining until the booking ends. The placeholder is replaced by the default value if the booking is not currently running. If no default value is specified in that case, nothing is displayed.

  This placeholder supports the same options as the *\[Elapsed Time\]* placeholder.

- **\[Time since end:format=\<format>,default=\<defaultValue>\]**

  Will be replaced by the amount of time that has passed since the end of the booking. The placeholder is replaced by the default value if the current time is earlier than the booking end time. If no default value is specified in that case, nothing is displayed.

  This placeholder supports the same options as the *\[Elapsed Time\]* placeholder.

- Placeholders referring to **custom booking properties**, in the format \[*PropertyName*\], e.g. *\[Class\]*.

## Making the booking shape display booking information

From DataMiner 10.3.8/10.4.0 onwards<!-- RN 33215+36489 -->, you can make a shape linked to a booking display all data associated with that booking.

To do so, add a **Component** shape data field and set its value to *BookingData*.

For example:

|Shape data field | Value |
|-------------|---------------|
| Reservation | `[pagevar:SRMRESERVATIONS_IDOfSelection]` |
| Component   | `BookingData` |

The shape will show the following information:

- On the left-hand side, a list of resources used by the booking.

  For every resource, this list shows the following information:
  
  - The resource name.

  - An icon indicating the function of the resource.

  - An icon indicating whether the resource is linked to a service definition node.

  - The node label or, if no node label is defined, the name of the function definition.

- On the right-hand side, the profile data of the node or node interface selected in the list on the left:

  - The profile instance (if applicable).

  - The profile parameter values that will be used. Any parameter values defined in the booking override the values defined in the profile instance, which in turn override the values defined in the profile definition.

> [!NOTE]
>
> - To use this component, you need to have a Resource Manager and Service Manager license, as well as the user permissions to access the UI for the [Bookings](xref:DataMiner_user_permissions#modules--bookings--ui-available), [Resources](xref:DataMiner_user_permissions#modules--resources--ui-available), [Services](xref:DataMiner_user_permissions#modules--services--ui-available), [Profiles](xref:DataMiner_user_permissions#modules--profiles--ui-available) and [Functions](xref:DataMiner_user_permissions#modules--functions--read) modules.
> - Prior to DataMiner 10.3.8/10.4.0, this component is available in soft launch. See [BookingData](xref:Overview_of_Soft_Launch_Options#bookingdata).
