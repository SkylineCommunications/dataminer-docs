---
uid: Booking_reports
---

# Booking reports

To view a default report of bookings within the system:

1. On the home page of the Reporter app, under *System*, click *Bookings*.

   Alternatively, to open this report page directly outside of DataMiner Cube, browse to the following URL: *http://*\<DMA name>*/Reports/SRM.asp*.

1. In the boxes at the top, specify the start time and the end time of the interval for which bookings need to be retrieved.

   > [!NOTE]
   > A DataMiner Agent stores all booking start and end times in UTC format. However, Reporter will request and display booking start and end times in the local time of the DataMiner Agent.
   >
   > As such, when you request a list of bookings in Reporter, enter a time range in the local time of the DataMiner Agent. In the list of bookings that will then be returned, all time ranges will also be displayed in the local time of the DataMiner Agent.

1. In the *Name filter* box, optionally enter a booking name to filter by.

1. Click *Show bookings*.

   A list of all bookings within the specified time span will be displayed. For each booking, the list shows the GUID, the name, the start time and the end time.

1. To open a page with details for a particular booking, click the GUID for this booking.

   If you know the GUID for a particular booking, you can also open the detailed information page for this booking directly outside DataMiner Cube by browsing to the following URL: *http://\<DMA name>/Reports/SRM-Reservation.asp?reservation=\<Reservation GUID>*

   This page contains the following components:

   - A component where you can select specific properties to include in the report. The component allows you to select static properties, such as the name, description or service ID, and dynamic properties. When you have selected one or more of these properties, you can update the report to only display these properties.

   - A component listing booking details:

     Shows a list of static and variable properties of the booking. The extra info specified in the above-mentioned component is added at the bottom.

   - A component with a signal path image:

     A default drawing of the signal path from the service definition.

   - A component with affected resources:

     A table of all resources that are affected by the booking (including resource name and element name).

   - A component with an alarm timeline:

     Shows any alarms that have occurred on the service during the booking.
