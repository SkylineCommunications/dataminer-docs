---
uid: Booking_Manager_Config_tab
---

# The Config tab

This tab of the Booking Manager app provides an overview of all configuration parameters for the Booking Manager.

## General subtab

### Application Setup settings

- **Default Virtual Platform**: The virtual platform of the Booking Manager. This is used among others to filter service definitions and resources. In the Booking Wizard, service definitions will only be shown if their *Virtual Platform* property is set to the identifier specified in this setting. For resources, the name of a resource pool that should be used with this virtual platform should start with the specified identifier followed by a period. For example, if *Default Virtual Platform* is set to *VPA*, a valid name for a resource pool would be *VPA.Decoder*.

- **Resource Pool**: Deprecated. Defines the Source Resource Pool name, so that Source resources can be identified and displayed on the first page of the Booking Wizard. This setting is no longer available from SRM 1.2.12 onwards. <!-- RN 29276 -->

- **Contributing Booking Type**: Determines whether standard or "lite" contributing resources are used. <!-- RN 31488 --> See [Enabling lite contributing bookings](xref:Service_Orchestration_contrib_bookings#enabling-lite-contributing-bookings).

- **Custom Events**: Determines whether event customization is enabled, which allows the user to add extra events to a booking.

- **Custom Properties**: Determines whether property customization is enabled, which allows the user to add predefined properties to a booking.

- **Booking Locking**: If this parameter is enabled, new bookings will be assigned an owner, which is initially the person who created the booking. Only the owner of a booking will be able to do any changes to it. Changing ownership is possible with the *Owner* button in the Booking Manager.

- **Refresh Time for Next Quarantined Booking**: Allows you to configure the rate at which the parameter *Time for Next Quarantined Booking* (on the *Bookings* tab) is refreshed, which determines the delay between the current time and the start time of the next booking in quarantine. By default, this is set to 5 minutes. Minimum value: 1 minute.

- **Column Configuration**: The column configuration to be used in the list of bookings on the *Bookings* tab. See [Customizing the columns of the Bookings list](xref:SRM_custom_bookings_list).

- **Booking Start Failure Script**: See [Configuring a custom script in case orchestration fails](xref:Service_Orchestration_service_states#configuring-a-custom-script-in-case-orchestration-fails).

- **Create Booking Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

- **Reservation Action Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

- **Service Profile Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

- **Leave Quarantine Script**: See [Configuring the Booking Manager app to use custom scripts](xref:SRM_custom_scripts).

### History and Logs settings

- **Booking logging location**: The path that indicates where the booking logs will be saved. Click *Settings* to open a window where you can customize this path and configure the logging date/time format, maximum file size, minimum logging level, and logging cleanup. For more information, see [Configuring SRM logging](xref:SRM_logging_config).

### Type of Booking settings

- **Single**: Enables or disables the single booking type.

- **Permanent**: Enables or disables the permanent booking type.

### Services settings

- **Persistent service**: Determines whether a service is created for a booking before the booking has actually started, which also continues to exist after the end of the booking.

- **App. services view**: Predefines the view in which the new services will be added when a booking is created.

### Automation settings

- **Optional resources configuration**: Adds a *Configure Resources* option to the Booking Wizard, which allows the user to indicate whether a read-only booking should be created, so that no configuration changes are made on devices in the network.

### Cluster Calibration settings

When bookings and/or associated objects are created and/or manipulated in a DataMiner System consisting of multiple Agents, scripts included in the SRM framework sometimes have to wait for the DMS synchronization to happen. You can use these *Cluster Calibration* settings to define how long the scripts should wait and how often the framework should check if the synchronization has happened. <!-- RN 25610 -->

- **Retry Timeout**: The retry timeout time for retrieval of SRM data in a DataMiner cluster. Default: *20 s*.

- **Retry Interval**: The retry interval for retrieval of SRM data in a DataMiner cluster. Default: *15 ms*.

### Monitoring settings

See [Configuring SRM alarm monitoring](xref:SRM_alarm_monitoring)

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

- **Use Node Label as Element Alias**: If this option is enabled, when the service associated with a booking is created, DataMiner will use the label of the node in the service definition as the alias for the corresponding element in the service. If this option is disabled, service elements will be displayed with the resource DVE names. See [Configuring the element alias](xref:Service_Orchestration_bookings_advanced#configuring-the-element-alias)<!-- RN 25236 -->

### Contributing Reservations settings

- **Include Contributing Service in Parent Service**: Determines whether a contributing service is included as a child service within the parent service that makes use of it. If this option is disabled, only resource elements will be included in the parent service.

- **Delete Unlocked Contributing Resources**: Determines whether unlocked contributing resources should be automatically deleted when specific conditions are met.

  If this option is enabled, an unlocked contributing resource is deleted when:

  - A contributing booking ends and the contributing resource is no longer used by an active booking.
  - A main booking ends and the contributing booking for which the contributing resource was generated has also ended.
  - A contributing booking is canceled and the resource has been removed from the main booking that made use of it.

  > [!TIP]
  > See also: [Contributing booking behavior](xref:Service_Orchestration_contrib_bookings#contributing-booking-behavior)

### Default booking configurations settings

- **Hosting DMA IDs to Orchestrate Reservation**: Contains the DMA ID(s) of the DMA(s) where bookings will be stored. The SRM framework will store all bookings evenly over the DMAs specified with this setting.

  > [!NOTE]
  > Prior to SRM 1.2.29, this setting is called *DMA IDs to Store Reservations*. <!-- RN 34882 -->

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

- **Partial**: The color used in the Booking Manager for bookings in the "Partial" state.

- **Confirmed**: The color used in the Booking Manager for bookings in the "Confirmed" state.

- **On-Hold**: The color used in the Booking Manager for bookings in the "On hold" state.

- **Pre-roll**: The color used in the Booking Manager for bookings in the "Pre-roll" state.

- **Service Active**: The color used in the Booking Manager for bookings in the "Service active" state.

- **Post-roll**: The color used in the Booking Manager for bookings in the "Post-roll" state.

- **Completed**: The color used in the Booking Manager for bookings in the "Completed" state.

- **Canceled**: The color used in the Booking Manager for bookings in the "Canceled" state.

- **Quarantined**: The color used in the Booking Manager for bookings in the "Quarantined" state.

- **Failed**: The color used in the Booking Manager for bookings in the "Failed" state.

> [!TIP]
> See also: [Defining custom state colors](xref:Service_Orchestration_life_cycle_states#defining-custom-state-colors)

## Services and SLA subtab

### Service states settings

These settings can be used to customize which service state corresponds with which booking life cycle stage. In the Service State Transitions table, you can also configure which transitions between service states are allowed. For more information, see [Service Orchestration service states configuration](xref:Service_Orchestration_service_states).

### SLA settings

- **SLA**: Determines whether the SLA option is displayed in the Booking Wizard.

- **SLA View**: Allows you to specify an existing view where the SLA should be located.

- **SLA Tracking Mode**: Determines whether SLA tracking depends on the service state, on the booking state, or both.

- **SLA Tracking (Pre-roll)**: Allows you to specify whether SLA tracking should be enabled during pre-roll, in case *SLA tracking mode* is set to *Reservation State* or *Combined*.

- **SLA Tracking (Active)**: Allows you to specify whether SLA tracking should be enabled when the booking is running, in case *SLA tracking mode* is set to *Reservation State* or *Combined*.

- **SLA Tracking (Post-roll)**: Allows you to specify whether SLA tracking should be enabled during post-roll, in case *SLA tracking mode* is set to *Reservation State* or *Combined*.

- **SLA Tracking (Service State)**: In this table, you can configure for which service states SLA tracking should be enabled if *SLA tracking mode* is set to *Reservation State* or *Combined*.

## Timeline subtab

- **Block Height**: Determines the height of the booking blocks on the timeline (in pixels). See [Configuring a custom booking block height](xref:SRM_custom_booking_blocks#configuring-a-custom-booking-block-height).

- **Custom Block Info**: Can be set to *Default* or *Custom*. If you set this to *Custom*, you can configure custom information to display in the booking blocks on the timeline using the **Service Info** table. See [Configuring custom booking block info for the entire system](xref:SRM_custom_booking_blocks#configuring-custom-booking-block-info-for-the-entire-system).

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

The settings on this subtab are used to configure custom events for Service Orchestration.

See [Service Orchestration custom events configuration](xref:Service_Orchestration_custom_events).

## Backup subtab

The settings on this subtab are used to export and import the configuration for the Booking Manager. <!-- RN 31593 -->

- **Export Settings**: Exports the settings of the Booking Manager to the *Skyline Booking Manager* > *Configurations* documents folder.

- **Import Settings**: Use this option to import settings **from a different DMS**. The button opens a pop-up window where you can select a file to import. The setting *DMA IDs to Store Reservations* or *Hosting DMA IDs to Orchestrate Reservation* is not included in the import.

- **Restore Settings**: Use this option to restore settings **from the same DMS**. The button opens a pop-up window where you can select a file to restore. The setting *DMA IDs to Store Reservations* or *Hosting DMA IDs to Orchestrate Reservation* is included in the restored settings.

- **Full Configuration Export**: Exports the full configuration of the Booking Manager and all associated SRM components (service definitions, custom scripts, functions, etc.) to the *Skyline Booking Manager* > *Full Configurations* documents folder. The result of the export will be displayed in a pop-up window<!--  RN 33452 -->.
