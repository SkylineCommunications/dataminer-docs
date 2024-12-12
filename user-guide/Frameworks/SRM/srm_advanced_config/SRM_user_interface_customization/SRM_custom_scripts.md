---
uid: SRM_custom_scripts
---

# Using custom scripts instead of the default SRM wizards

The SRM framework contains standard scripts to perform actions such as creating a booking:

- The standard Booking Wizard allows users to select a resource and one or more profiles for each node.
- The standard Service Profile Wizard allows users to select a service profile instance, which defines the service definition and all profile instances at once.

To execute these "wizards", users can click buttons on the *Bookings* page of the Booking Manager app.

These default wizards included in the SRM framework can be used to support basic use cases. However, we highly recommend that you implement custom wizards tailored to the needs of your end users.

## Configuring the Booking Manager app to use custom scripts

To make sure a custom script is executed for specific actions: <!-- RN 26883 -->

1. In DataMiner Cube, add your custom script(s) in the Automation module.

1. In the Booking Manager app, go to the *Config* > *General* page.

1. Select the script you want to use for one or more of the following settings:

   - *Create Booking Script*: The script used to create a new booking, edit a booking, or duplicate a booking. By default, this is *SRM_CreateNewBooking*.

   - *Reservation Action Script*: The script used for various actions such as Adjust Time, Cancel, Finish, Start, Confirm, etc. By default, this is *SRM_ReservationAction*.

   - *Service Profile Script*: The script used to create a booking using a service profile. By default, this is *SRM_DefineBooking*.

   - *Leave Quarantine Script*: The script used when you click Try Leave Quarantine. By default, this is *SRM_LeaveQuarantine*.

## Adding custom scripts for additional controls

The *Bookings* page of the Booking Manager app can be extended with up to five extra controls that launch custom scripts for a selected booking. These can be configured with a custom icon. <!-- RN 28784 -->

The custom controls are displayed in the booking details area below the bookings list. For example:

![Bookings page with custom icon](~/user-guide/images/SRM_custom_script_icon.png)

To configure this:

1. Create a Visio drawing that contains one page for each icon you want to use, and add the icon to the relevant page. No shape data are required.

1. In DataMiner Cube, create a view and assign the Visio drawing to that view. See [Set as active Visio file](xref:Editing_a_visual_overview_in_DataMiner_Cube#set-as-active-visio-file).

1. In the Booking Manager app, go to *Config* > *Custom Actions*.

1. Set the *Custom Booking Actions* parameter to *Enabled*.

1. In the *Actions* table, for each action you want to configure:

   1. Set the *Action Type* parameter to *Script*.

   1. Set the *Icon View Name* parameter to the view to which you assigned the Visio file containing the icons.

   1. Set the *Icon Page Name* parameter to the name of the page containing the icon for the action.

   1. Set the *Action Argument* parameter to a string defining the script to be executed for the action.

      > [!NOTE]
      > The following placeholders are supported:
      >
      > - `[cardvar:varBookingId]`: This will pass the reference (GUID) of the selected booking.
      > - `[this Element]`: This will pass the Booking Manager element as a script dummy.

      Example:

      ```txt
      SRM_TEST_TransitionToServiceState|BookingManagerElement=[this Element]|BookingId=[cardvar:varBookingId];TargetServiceState=Standby||Set To Standby|NoConfirmation,CloseWhenFinished
      ```
