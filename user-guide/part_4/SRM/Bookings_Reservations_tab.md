## Bookings / Reservations tab

To view a default report of bookings within the system:

1. On the home page of the Reporter app, under *System*, click *Bookings *or (prior to DataMiner 9.6.7) *Reservations*.

    Alternatively, to open this report page directly outside of DataMiner Cube, browse to the following URL: *http://*\<DMA name>*/Reports/SRM.asp*.

2. In the boxes at the top, specify the start time and the end time of the interval for which bookings need to be retrieved.

    > [!NOTE]
    > A DataMiner Agent stores all booking start and end times in UTC format. However, Reporter will request and display booking start and end times in the local time of the DataMiner Agent.
    >
    > As such, when you request a list of bookings in Reporter, enter a time range in the local time of the DataMiner Agent. In the list of bookings that will then be returned, all time ranges will also be displayed in the local time of the DataMiner Agent.

3. In the *Name filter* box, optionally enter a booking name to filter by.

4.  Click *Show bookings *or (prior to DataMiner 9.6.7) *Show Reservations*.

    A list of all bookings within the specified time span will be displayed. For each booking, the list shows the GUID, the name, the start time and the end time.

5. To open a page with details for a particular booking, click the GUID for this booking.

    If you know the GUID for a particular booking, you can also open the detailed information page for this booking directly outside DataMiner Cube by browsing to the following URL: *http://\<DMA name>/Reports/SRM-Reservation.asp?reservation=\<Reservation GUID>*      This page contains the following components:

    - A component to dynamically add more booking info from a booking manager element (e.g. “Booking Manager”). (Up to DataMiner 9.5.5 only)

        To add additional booking info:

        1. Select the manager element.

        2. Select the table in the manager element that contains the booking info.

        3. Select the columns to be displayed.

        4. Select whether to display the info like any other booking property (“As detail property”) or in a separate table (“As info table”). If you select the latter, you can select multiple rows from the source table.

            To select multiple rows from the source table, you can use other tables from the manager element to link the booking to the extra info (“Relational tables”). The order and key/data columns of the relational tables determine how the tables are linked.

        5. Select a key property. This is the booking property that has to be used as the key to retrieve the extra info.

        6. Update the report. Extra info will now be added in the components below.

        If, for example, you want to show a table with all the contacts linked to a booking, specify the following:

        - Table source: “Contacts”

        - Columns: “Contact name”, “Contact email”, “Contact status”

        - Relational table: “Bookings” - Key column: “Booking GUID” - Data column: “Internal ID”

        - Relational table: “Booking-Contacts” - Key column: “Booking ID” - Data column: “Contact ID”

        - Booking key property: “GUID”

    - A component where you can select specific properties to include in the report. (From DataMiner 9.5.6 onwards.) The component allows you to select static properties, such as the name, description or service ID, and dynamic properties. When you have selected one or more of these properties, you can update the report to only display these properties.

    - A component listing booking details:

        Shows a list of static and variable properties of the booking. The extra info specified in the above-mentioned component is added at the bottom.

    - A component with a signal path image:

        A default drawing of the signal path from the service definition.

    - A component with affected resources:

        A table of all resources that are affected by the booking (including resource name and element name).

    - A component with an alarm timeline:

        Shows any alarms that have occurred on the service during the booking.
