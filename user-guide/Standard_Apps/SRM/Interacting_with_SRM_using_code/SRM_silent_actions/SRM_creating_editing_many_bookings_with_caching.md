---
uid: SRM_creating_editing_many_bookings_with_caching
---

# Silently creating or editing many bookings using caching

<!-- RN 30986 -->

When a custom script needs to create or edit many bookings at the same time, you can use a caching mechanism to optimize the number of API calls that SRM will need to make to create or edit the bookings.

For this purpose, the custom script will need to create an *SrmCache* object and use one of the following overloaded methods:

- `public ReservationInstance CreateNewBooking(Engine engine, SrmCache srmCache, Booking bookingData, IEnumerable<Function> functions, IEnumerable<Event> events = null, IEnumerable<Property> properties = null);`

- `public ReservationInstance EditBooking(Engine engine, Guid reservationId, SrmCache srmCache, Booking bookingData, IEnumerable<Function> functions = null, IEnumerable<Event> events = null, IEnumerable<Property> properties = null);`

- `public static ServiceReservationInstance AssignResources(this ServiceReservationInstance reservation, Engine engine, SrmCache srmCache, params AssignResourceRequest[] requests)`

- `public static ServiceReservationInstance UnassignResources(this ServiceReservationInstance reservation, Engine engine, SrmCache srmCache, params AssignResourceRequest[] requests)`
