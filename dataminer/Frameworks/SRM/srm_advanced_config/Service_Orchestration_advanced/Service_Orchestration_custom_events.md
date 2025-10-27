---
uid: Service_Orchestration_custom_events
---

# Service Orchestration: custom events configuration

Next to the standard events (start of pre-roll, stop of pre-roll, start of post-roll, and stop of post-roll), the Booking Manager app can be configured to generate extra events. However, note that these cannot be executed at the exact same time as the standard events<!-- RN 28730 -->.

To use custom events:

1. On the *Config* > *Events* tab of the Booking Manager app, set the *Custom events* toggle button to *Enabled*.

1. In the *Events* table below that, configure the events as detailed below.

## Configuring custom events

On the *Config* > *Events* tab of the Booking Manager app, right-clicking the *Events* table opens a context menu that allows you to add an event, duplicate an event, or delete one or more events from the table.

In addition, in each column of the table, you can edit the configuration of a custom event:

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
