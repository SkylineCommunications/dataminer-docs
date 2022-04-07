---
uid: srm_scripting
---

# SRM scripting

This section explains the main kinds of scripting used in the SRM framework.

## Profile-Load Script (PLS)

A Profile-Load Script (PLS) is an Automation script that is used to apply profile instances or values onto a virtual function resource. This script is executed when a booking enters a specific state. For example, at the start time of the booking, a PLS is used to apply a profile instance.

A PLS is typically linked to a specific virtual function. The name of the PLS can therefore be added to the profile definition connected to the virtual function. As multiple connectors can expose the same virtual function, multiple PLSs can be linked to the same profile definition. A PLS requires a "FunctionDve" dummy linked to the connector exposing the virtual function, which ensures that the correct PLS will automatically be executed.

For example, different connectors can expose the same "Encoding" virtual function. As it is the same virtual function, one profile definition will be used for the virtual function. The Profile-Load Scripts for the various connectors can be linked to this profile definition. When the booking is orchestrated, the correct PLS will be executed.

## Life cycle Service Orchestration (LSO) script

LSO scripts are only used in the context of Service Orchestration.

The LSO script is responsible for the orchestration of bookings according to service state transitions (e.g. Start, Stop, Standby, etc.). For every supported service state transition, the LSO script will call the various Profile-Load Scripts for each virtual function included in the service definition and pass the appropriate service state. As a result, all the PLSs will apply the profile instance for that specific service state to the associated function resource.

The LSO script is called at the following stages of the booking:

- When pre-roll starts
- When pre-roll ends
- When post-roll starts
- When post-roll ends

For each of these stages, a "Service State" can be defined in the Booking Manager. The LSO script will execute all PLSs with the relevant service state and update the booking to this specific state.

## Data Transfer Rules (DTR)

Data Transfer Rules are only used in the context of Service Orchestration.

Data Transfer Rules are used at the moment when a booking is created, to transfer data between several virtual functions of the selected service definition. This way, a user will not have to request the same information several times during the booking creation process, but instead logic is applied to copy or even process specific information from one virtual function to another.

Data Transfer Rules are implemented as custom Automation scripts.

Two types of DTR exist:

- Regular DTR
- Service Profile DTR

### Regular Data Transfer Rules

A regular DTR script can be triggered when the following actions happen:

- A profile instance is selected
- A resource is selected
- A parameter is updated

The DTR script can retrieve data from the selected profile instance or resource, or automatically update a (capability/capacity) parameter value on a node, so that users do not need to provide a parameter value manually. The script is not interactive and cannot be used to modify the booking itself or to configure its resources.

If a DTR script is defined, it will be executed whenever a booking is created, no matter how the booking is created: with the regular Booking Wizard, with the Service Profile Wizard, or using a custom front end.

Whenever a DTR script is executed, this will generate an update of the booking. This feature should therefore be used with caution, as too many DTR script executions will slow down the booking creation time.

### Service Profile Data Transfer Rules

When a booking is created using a service profile, a Service Profile Data Transfer Rules script can be launched. It is used to transfer data between nodes of the booking, and even between main and contributing bookings. A Service Profile DTR script is not interactive and cannot be used to modify the booking itself or to configure its resources.

When a Service Profile DTR script is executed, this does not immediately update the booking. The transfer of data happens in memory and is used at the end of the booking creation process to silently create the booking. Therefore, any transfer happening in the script will not have an impact on booking creation time.

## Custom events

## Contributing conversion script

## Created booking script
