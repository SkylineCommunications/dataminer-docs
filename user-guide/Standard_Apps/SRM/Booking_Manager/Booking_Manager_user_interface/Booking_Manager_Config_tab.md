---
uid: Booking_Manager_Config_tab
---

# The Config tab

This tab of the Booking Manager app provides an overview of all configuration parameters for the Booking Manager.

## General subtab

### Application Setup settings

- **Default Virtual Platform**: The virtual platform of the Booking Manager. This is used among others to filter service definitions and resources. In the Booking Wizard, service definitions will only be shown if their *Virtual Platform* property is set to the identifier specified in this setting. For resources, the name of a resource pool that should be used with this virtual platform should start with the specified identifier followed by a period. For example, if *Default Virtual Platform* is set to *VPA*, a valid name for a resource pool would be *VPA.Decoder*.

- **Resource Pool**: Deprecated. Defines the Source Resource Pool name, so that Source resources can be identified and displayed on the first page of the Booking Wizard. This setting is no longer available from SRM 1.2.12 onwards. <!-- RN 29276 -->

- **Custom Events**: Determines whether event customization is enabled, which allows the user to add extra events to a booking.

- **Custom Properties**: Determines whether property customization is enabled, which allows the user to add predefined properties to a booking.

- **Booking Locking**: If this parameter is enabled, new bookings will be assigned an owner, which is initially the person who created the booking. Only the owner of a booking will be able to do any changes to it. Changing ownership is possible with the *Owner* button in the Booking Manager.

- **Refresh Time for Next Quarantined Booking**: Allows you to configure the rate at which the parameter *Time for Next Quarantined Booking* (on the *Bookings* tab) is refreshed, which determines the delay between the current time and the start time of the next booking in quarantine. By default, this is set to 5 minutes. Minimum value: 1 minute.

- **Column Configuration**: The column configuration to be used in the list of bookings on the *Bookings* tab. For more information on how to work with column configurations, see [Bookings list](xref:The_Bookings_module#bookings-list).

- **Booking Start Failure Script**: Determines which script will be triggered in case the start actions for a booking instance fail. An example script, *SRM_BookingStartFailureTemplate*, is included for this in the SRM package.

- **Create Booking Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

- **Reservation Action Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

- **Service Profile Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

- **Leave Quarantine Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

### History and Logs settings

- **Booking logging location**: The path that indicates where the booking logs will be saved. Click *Settings* to open a window where you can customize this path and configure the logging date/time format, maximum file size, minimum logging level, and logging cleanup.

### Type of Booking settings

- **Single**: Enables or disables the single booking type.

- **Permanent**: Enables or disables the permanent booking type.

### Services settings

- **Persistent service**: Determines whether a service is created for a booking before the booking has actually started, which also continues to exist after the end of the booking.

- **App. services view**: Predefines the view in which the new services will be added when a booking is created.

### Automation settings

- **Optional resources configuration**: Adds a *Configure Resources* option to the Booking Wizard, which allows the user to indicate whether a read-only booking should be created, so that no configuration changes are made on devices in the network.

### Cluster Calibration settings

- **Retry Timeout**: The retry timeout time for retrieval of SRM data in a DataMiner cluster. Default: *20 s*.

- **Retry Interval**: The retry interval for retrieval of SRM data in a DataMiner cluster. Default: *15 ms*.

## Custom Actions subtab

See [Adding custom scripts for additional controls](xref:SRM_custom_scripts#adding-custom-scripts-for-additional-controls).

## Wizard subtab

### Type of Wizard settings

- **Standard**: Determines whether the standard booking creation wizard is available.

- **Service Profile**: Determines whether the booking wizard using service profiles is available.

### Booking wizard options settings

- **Maximum Time to Enter Bookings**: The maximum configuration time of a Booking Wizard instance. If a user fails to complete the configuration of a booking within this time, the booking will not be validated and the booking creation procedure will be aborted.

- **Resources Availability Guard Interval**: When this parameter is enabled, during the configuration of a booking, the Booking Wizard will first list the resources that are both available during the duration of the booking and during the extra guard intervals before and after the booking duration.

- **Resources Ordering Rule**: Determines whether resources that cannot be ordered by priority (because priority is not or not correctly configured) will be ordered alphabetically or randomly.

- **Pool Resource**: Determines whether a pool resource can be used instead of a specific resource when a booking is created. The pool resource will then be replaced by a specific resource at the start of the booking.

- **Show Information Events**: Determines whether information events are displayed.

- **Auto Expand Profiles**: Determines whether profile parameters are automatically expanded in the Booking Manager.

- **Use Node Label as Element Alias**: If this option is enabled, a node label is used as service element alias, so that an element in a service will be displayed with the label associated with the corresponding node in the service definition. If this option is disabled, service elements will be displayed with the resource DVE names.

### Contributing Reservations settings

- **Include Contributing Service in Parent Service**: Determines whether a contributing service is included as a child service within the parent service that makes use of it. If this option is disabled, only resource elements will be included in the parent service.

- **Delete Unlocked Contributing Resources**: Determines whether unlocked contributing resources should be automatically deleted when specific conditions are met.

  If this option is enabled, an unlocked contributing resource is deleted when:

  - A contributing booking ends and the contributing resource is no longer used by an active booking.
  - A main booking ends and the contributing booking for which the contributing resource was generated has also ended.
  - A contributing booking is canceled and the resource has been removed from the main booking that made use of it.

### Default booking configurations settings

- **DMA IDs to Store Reservations**: Contains the DMA ID(s) of the DMA(s) where bookings will be stored.

- **Start delay**: The default delay period before a booking starts.

- **Duration**: The default duration of a booking.

- **Pre-roll**: Determines whether there is a pre-roll phase before bookings start.

- **Pre-roll duration**: The default duration of the pre-roll phase of a booking.

- **Post-roll**: Determines whether there is a post-roll phase after bookings end.

- **Post-roll duration**: The default duration of the post-roll phase of a booking.

- **Shrink Post-roll**: Determines whether post-roll shrinking is enabled. When this feature is enabled, a booking will end as soon as the necessary post-roll actions have been completed, regardless of the configured post-roll period, and the end delay (if any) has elapsed. However, note that post-roll shrinking will always be applied in case a user manually finishes a booking, even if *Shrink Post Roll* is disabled.

- **Default service definition**: The default service definition.

- **Event rescheduling delay**: Indicates the delay period before a booking ends or starts when its timing is adjusted. When the *Finish* button is pressed for an ongoing booking, the action to stop the booking will be executed after this delay time. When the *Start* button is pressed for a confirmed booking, the delay between the time the button is pressed and the new start time of the booking.

- **Friendly booking reference**: Allows you to specify a user-friendly booking reference. This reference will be used in the Booking ID field in the Booking Wizard and will also be mentioned in the booking overview tables.

## Lifecycle colors subtab

### Lifecycle colors settings

- **Partial**: The color used in the Booking Manager for bookings in the “Partial” state.

- **Confirmed**: The color used in the Booking Manager for bookings in the “Confirmed” state.

- **On-Hold**: The color used in the Booking Manager for bookings in the “On hold” state.

- **Pre-roll**: The color used in the Booking Manager for bookings in the “Pre-roll” state.

- **Service Active**: The color used in the Booking Manager for bookings in the “Service active” state.

- **Post-roll**: The color used in the Booking Manager for bookings in the “Post-roll” state.

- **Completed**: The color used in the Booking Manager for bookings in the “Completed” state.

- **Canceled**: The color used in the Booking Manager for bookings in the “Canceled” state.

- **Quarantined**: The color used in the Booking Manager for bookings in the “Quarantined” state.

- **Failed**: The color used in the Booking Manager for bookings in the “Failed” state.

## Services and SLA subtab

### Service states settings

- **Initial Service State**: Predefines the initial state of the service associated with a booking.

- **Service State (Pre-roll)**: Predefines the state of the service during the pre-roll phase of a booking.

- **Service State (Service Active)**: Predefines the state of the service associated with a booking immediately after the pre-roll phase ends.

- **Service State (Post-roll)**: Predefines the state of the service during the post-roll phase of a booking.

- **Service State (Ended)**: Predefines the state of the service associated with a booking immediately after the post-roll phase ends.

- **Service State Transitions**: In this table, you can configure which transitions between service states are allowed.

### SLA settings

- **SLA**: Determines whether the SLA option is displayed in the Booking Wizard.

- **SLA View**: Allows you to specify an existing view where the SLA should be located.

- **SLA Tracking Mode**: Determines whether SLA tracking depends on the service state, on the booking state, or both.

- **SLA Tracking (Pre-roll)**: Allows you to specify whether SLA tracking should be enabled during pre-roll, in case *SLA tracking mode* is set to *Reservation State* or *Combined*.

- **SLA Tracking (Active)**: Allows you to specify whether SLA tracking should be enabled when the booking is running, in case *SLA tracking mode* is set to *Reservation State* or *Combined*.

- **SLA Tracking (Post-roll)**: Allows you to specify whether SLA tracking should be enabled during post-roll, in case *SLA tracking mode* is set to *Reservation State* or *Combined*.

- **SLA Tracking (Service State)**: In this table, you can configure for which service states SLA tracking should be enabled if *SLA tracking mode* is set to *Reservation State* or *Combined*.

## Timeline subtab

This subtab displays a toggle button, *Custom*, which determines whether custom information is displayed in the booking blocks on the timeline.

If you enable this feature, you should configure the custom information in the *Service Info* table below the toggle button. Each row in this table represents an item that will be displayed in the booking blocks.

To add a row:

1. Right-click the table and select *Add Block Info*.

2. In the *Block Info* field, specify the block info (e.g. *\[BOOKINGNAME\]*, or a property name in the format *\[PROPERTY:**Property name**\]*).

3. In the *Order* field, specify in which position on the block the item should be displayed, The lower the number (lowest = 0), the higher the position.

To remove a row, right-click the row and select *Delete Selected Item(s)*. Alternatively, you can clear all items in the table at the same time by selecting *Clear Table*.

## Properties subtab

This subtab displays a toggle button, *Custom properties*, which determines whether property customization is enabled. This feature allows you to choose which properties should be added to a booking.

To make use of custom properties, you should configure these in the *Properties* table below the toggle button.

Via the right-click menu of this table, you can add a property, duplicate a property, and delete one or more properties from the table. In each column of the table, the configuration of a property can be edited:

- **Name**: The name of the property.

- **Property Type**: Currently not used.

- **Type**: Determines whether the value of the property is of type discrete, double or string.

- **Discreet Values**: If the property is of type *Discreet*, in this column the different discrete values must be specified, separated by semicolons.

- **Default Value**: The default value of the property.

- **Action**: Currently not used.

- **Copy to Created Service**: Determines whether the property is copied to the service created for the booking.

- **Visibility**: Determines whether the property is displayed in the Booking Wizard.

- **Requirement**: Currently not used.

- **UI Row**: Determines the priority of the property in the sort order in the Booking Wizard. The lower the number (lowest = 0), the higher the position in the sort order. If nothing is specified here, the property will be sorted automatically.

- **Added by default**: If enabled, the property is added to the booking by default.

- **Delete**: Allows you to remove the property. However, for any previously created bookings that use the deleted property, the property will remain available.

## Events subtab

This subtab displays a toggle button, *Custom events*, which determines whether event customization is enabled. This feature allows you to choose which events should be added to a booking.

To make use of custom events, you should configure these in the *Events* table below the toggle button.

Via the right-click menu of this table, you can add an event, duplicate an event, and delete one or more events from the table. In each column of the table, the configuration of an event can be edited:

- **Name**: The name of the event.

- **Time Value**: Determines how many seconds after or before (depending on the *Timing Type*) the time reference point the event will take place. If -1 is specified, the event is executed immediately.

- **Time Reference Point**: Determines whether this is a start or stop event.

- **Timing Type**: Determines whether the event takes place before or after the time reference point.

- **Script**: Allows you to specify a script that should be executed during the event, using the same syntax as to specify a script in Visio. See [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script).

  > [!NOTE]
  > The following two placeholders are supported in the script configuration: *\[RESERVATIONGUID\]* and *\[SERVICEDEFINITION:\<PropertyName>\]*.
  >
  > For example:
  > *Script:Test\|Reservation=\[RESERVATIONGUID\]\|Reservation2=\[RESERVATIONGUID\]\|Virtual Platform= \[SERVICEDEFINITION:Virtual Platform\]\| DeriverFrom = \[SERVICEDEFINITION:DerivedFrom\]*

- **Description**: Allows you to add a description of the event.

- **Visibility**: Allows you to select one of the following values:

  - **Not visible**: The event will not be displayed in the Booking Wizard.

  - **Not able to change**: The event will be displayed in the Booking Wizard, in read-only mode.

  - **Able to enable/disable**: The event will be displayed in the Booking Wizard, but the user will only be able to enable or disable it.

  - **Able to update**: The event will be displayed and fully editable in the Booking Wizard.

- **UI Row**: Determines the priority of the event in the sort order in the Booking Wizard. The lower the number (lowest = 0), the higher the position in the sort order. If nothing is specified here, the event will be sorted automatically.

- **Added by Default**: If enabled, the event is added to the booking by default.

- **Delete**: Allows you to remove a particular entry.
