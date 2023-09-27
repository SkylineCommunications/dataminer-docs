---
uid: Booking_Manager_Bookings_tab
---

# The Bookings tab

This tab of the Booking Manager app displays information about current, past and future bookings.

- At the top of the page, there is an expandable filter area, where you can select which content should be displayed:

  - On the left, checkboxes are displayed representing each of the possible booking states. Select one or more of these boxes to only have bookings in those particular states displayed.

  - Next to this, time controls allow you to determine for which time period booking info should be displayed.

  - On the right, several toggle buttons allow you to show or hide specific information:

    - **Contributing**: Determines whether contributing bookings are displayed.

    - **Bookings List**: Determines whether the list of bookings is displayed below the timeline on this tab.

    - **Single Booking**: Determines whether all bookings matching the current filters are displayed, or whether only one single booking is displayed at a time.

    - **Resources Timeline**: Determines whether the timeline shows booking or resources.

- Below this, the app displays a timeline and a list of bookings. The list of bookings functions in the same way as in the Bookings module. For more information, see [Bookings list](xref:The_Bookings_module#bookings-list).

- If a booking is selected on the timeline or in the list, detailed information on the selected booking is displayed at the bottom of the tab. This timeline functions in the same way as in the Bookings module. For more information, see [Bookings timeline](xref:The_Bookings_module#bookings-timeline).

- Both above the timeline and below the list of bookings, several buttons can be displayed. The displayed buttons depend on whether a booking is selected and what the status of the selected booking is. The behavior and availability of some of these buttons also depends on the configuration of specific settings in the *Config* tab (see [The Config tab](xref:Booking_Manager_Config_tab)).

  The following buttons are always displayed:

  - **New**: Allows you to create a new booking. By default, the standard Booking Wizard is used for this, but this can be customized (see [Using custom scripts instead of the default SRM wizards](xref:SRM_custom_scripts)).

  - **New (Service Profile)**: Allows you to create a new booking using a service profile. Doing so will require less input during booking creation, as the selected service profile will determine which service definition and profile instances are used.

    > [!NOTE]
    > The *New (Service Profile)* button is only available if the Service Profile feature is enabled (via [Config > Wizard > Service Profile](xref:Booking_Manager_Config_tab#type-of-wizard-settings)).

  The following buttons are displayed if any booking is selected:

  - **Duplicate**: Allows you to create a new booking based on the selected booking.

  - **Force Take Ownership**: Only displayed in case another user has ownership of the selected booking. Click this button to take ownership of the booking.

    > [!NOTE]
    > The *Force Take Ownership* button is only available if the Booking Locking feature is enabled (via [Config > General > Booking Locking](xref:Booking_Manager_Config_tab#application-setup-settings)).

  - **Take Ownership**: Only displayed in case the currently selected booking has no owner. Click this button to take ownership of the booking.

    > [!NOTE]
    > The *Take Ownership* button is only available if the Booking Locking feature is enabled (via [Config > General > Booking Locking](xref:Booking_Manager_Config_tab#application-setup-settings)).

  - **Release Ownership**. Only displayed in case you are the current owner of the booking. Click this button to release ownership of the booking.

    > [!NOTE]
    > The *Release Ownership* button is only available if the Booking Locking feature is enabled (via [Config > General > Booking Locking](xref:Booking_Manager_Config_tab#application-setup-settings)).

  - **Resources** / **Bookings**: This button is displayed in the bottom-left corner of the tab, and allows you to switch between the bookings and resources timeline.

  - **Rescue**: Displayed at the bottom of the tab. This button can be used in case a booking was interrupted for some reason, e.g. because DataMiner became unavailable. It takes the booking out of the interrupted state so that it can start like a normal booking. For this purpose, the start date is adjusted when necessary.

    > [!NOTE]
    > Prior to SRM 1.2.23, instead of a *Rescue* button, a *Leave Interrupted* button is available, which has the same functionality. <!-- RN 28472 -->

  - **Debug Log**: Displayed at the bottom of the tab. Allows you to open the debug log file. See [SRM logging](xref:SRM_logging).

  - **Action Log**: Displayed at the bottom of the tab. Allows you to open the action log file. See [SRM logging](xref:SRM_logging).

  The following buttons are displayed if the selected booking is currently running:

  - **Finish**: Allows you to finish the booking before the configured end time.

  - **Adjust Stop Time**: Allows you to change the end time of the booking.

  - **Extend**: Allows you to add a time extension to a booking. This can be useful if you want to quickly add some time to an ongoing booking, without having to worry about the rest of the booking configuration.

  The following button is displayed for any booking that has not been canceled:

  - **Cancel**: Allows you to cancel the booking.

  The following buttons are only displayed for bookings that have been confirmed, but have not started yet:

  - **Start**: Allows you to start the booking immediately instead of at the scheduled start time.

  - **On-Hold**: Allows you to temporarily set the booking to *On Hold* status, so that it will not be activated.

  The following buttons are displayed both for confirmed bookings that have not started yet and partial bookings (i.e. bookings that have not yet been fully configured):

  - **Edit**: Allows you to make changes to the booking, e.g. selecting different resources.

  - **Adjust time**: Allows you to change the start and/or end time of the booking.

  The following button is only displayed for partial bookings or bookings that are on hold:

  - **Confirm**: Allows you to finish the configuration of a partial booking and confirm the booking.

  The following buttons are displayed for canceled bookings only:

  - **Delete**: Allows you to delete a canceled booking.

  - **Delete Service**: Allows you to remove the service associated with the booking.

  The following button is only displayed if a booking is quarantined:

  - **Try Leave Quarantine**: Starts the wizard to take the booking out of quarantine.
