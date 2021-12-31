## Script types

The following types of scripts are supported:

- Life cycle Service Orchestration (LSO) scripts – see [LSO scripts](#lso-scripts)

- Custom Event scripts – see [Custom Event scripts](#custom-event-scripts)

- Profile Load scripts – see [Profile Load scripts](#profile-load-scripts)

- Contributing scripts (deprecated) – see [Contributing scripts](#contributing-scripts)

- Created Booking scripts – see [Created Booking scripts](#created-booking-scripts)

- Data Transfer Rules (DTR) scripts – see [DTR scripts](#dtr-scripts)

- Contributing conversion scripts - see [Contributing Conversion scripts](#contributing-conversion-scripts)

- Workflow scripting – see [Workflow scripting](#workflow-scripting)

### LSO scripts

For each service definition, a Life cycle Service Orchestration (LSO) script is created. This script is used to orchestrate the configuration of the resources for various events of a booking.

An LSO script cannot be used to directly configure resources or modify a booking (changing timing, adjusting resources, modifying events, etc.).

Instead it triggers the configuration of resources (via the dedicated methods of the SRM framework). It can also be used to generate a report and to send booking information to a third-party system.

> [!NOTE]
> The very last event of the booking should never trigger the configuration of a resource, as this could cause a conflict with a booking following immediately afterwards that makes use of the same resource.

### Custom Event scripts

Custom events can be added to a booking and they can even be scheduled to start before the booking start time. These events can execute custom scripts. Such custom event scripts cannot be used to modify the booking itself or to configure resources.

### Profile Load scripts

Profile Load scripts are used to apply a configuration to a resource. They are triggered from LSO scripts. They cannot be used to modify the booking itself or to configure different resources.

### Contributing scripts

Contributing scripts are used to initiate the creation of a contributing booking during the creation of a main booking. In the Booking Wizard, these scripts can be started with a button. The script can ask a user for information, or create a contributing booking without any user interaction. However, this script cannot be used to modify the main booking.

This functionality is considered **deprecated**. We recommend that you use a Created Booking script instead (see [Created Booking scripts](#created-booking-scripts)). If you decide to use contributing scripts after all, the following limitations will apply:

- These scripts are only supported in the standard Booking Wizard, not in Service Profiles wizard, i.e. the wizard to create bookings based on service profiles.

- These scripts cannot be used if the main booking is created without user interaction.

### Created Booking scripts

A Created Booking script is executed as soon as someone tries to confirm a booking. It can be used to finalize the configuration of the booking based on custom rules, for example to assign resources to hidden nodes.

Created Bookings scripts do not support user interaction. They cannot be used to modify booking events, timing or resources assigned in the Booking Wizard. They can also not be used to configure resources.

### DTR scripts

Data Transfer Rules (DTR) scripts are used during the booking creation process to transfer values from one node of a service definition to another node. A DTR script is triggered when a profile instance or a resource is selected in the Booking Wizard.

A DTR script can be used to retrieve data from a selected profile instance or resource. It can also update a (capability/capacity) parameter value on a node (similar to what would happen if a user manually provided a parameter value, but automated with a script).

A DTR script is not interactive and cannot be used to modify the booking itself or configure resources.

### Contributing Conversion scripts

Contributing Conversion scripts are executed after a booking is converted to a contributing resource. They can only be used to update capacities, capabilities or properties on the generated resource.

### Workflow scripting

For features that are not by default supported by the app or by the available scripts, custom scripts can be created.

These can for example be used to:

- Ask the user for specific information and then create a booking without further interaction.

- Change the state of a booking when a notification is received from a third-party system.

- Create a fully customized booking wizard.

- …

However, note that a custom script should never do a full edit on a running booking (i.e. a booking for which an event has already been executed). Dedicated functions should be used instead to:

- Assign a resource (see [Assigning resource, profile and parameter values](Silent_actions.md#assigning-resource-profile-and-parameter-values))

- Change the state of a booking (see [Applying booking life cycle transitions](Silent_actions.md#applying-booking-life-cycle-transitions))

- Change the timing of a booking (see [Updating the timing of a booking](Silent_actions.md#updating-the-timing-of-a-booking))
