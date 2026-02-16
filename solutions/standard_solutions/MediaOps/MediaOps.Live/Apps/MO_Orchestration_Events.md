---
uid: MO_Orchestration_Events
---

# Orchestration Events app

The Orchestration Events app allows to inspect the orchestration events on the system.

## App overview

The following pages are available in the app:

- **Arrivals Board**: Shows the list of events that started up to 5 minutes in the past and are starting up to 8 hours in the future.

- **Search Events**: Allows to search for specific events by name, time, type, state or orchestration type.

Both pages allow to access the full details of each event by clicking the 'Info' icon.

## Orchestration Events

Orchestration events allow to execute automation scripts at a defined datetime in the future. These events support executing regular automation scripts, but also allow to link specific orchestration scripts, which allow to more easily test them manually.

Orchestration events can be created using an API, but are also integrated in [MediaOps Plan](xref:MediaOps.Plan) and can be used to support the orchestration of [Jobs](xref:MO_Scheduling).

## Orchestration Scripts

Orchestration scripts are regular automation scripts using a dedicated helper allowing to have typed input arguments, and a preset feature to fill in all input arguments at once.
These scripts can still use regular script dummies and params, and can also be associated with a Profile Definition allowing for extra typed input arguments.

When executing an orchestration script manually, and after having filled in all script dummies and script params, a UI will prompt the user for the typed parameters. The UI will also have a control allowing to select a Profile Instance instead of providing each parameter value individually.

### Global Orchestration Script

An orchestration can be defined with a Global (Orchestration) script, and associated values for all arguments. At Event time the script will be launched with the provided arguments.

### Node Orchestration Script

For an architecture where a job would require to configure different nodes with different automation scripts, node orchestration scripts can be defined for each node of the job, replacing or in addition to the global orchestration script.

When no global orchestration script is defined, Live will execute all node orchestration scripts. When a global orchestration script is defined, the global orchestration script will have to trigger the execution of the node orchestration scripts.

## Connectivity

Orchestration events can also define expected connectivity between [virtual signal groups](xref:MO_Virtual_Signal_Groups#virtual-signal-groups). At event time, if a global orchestration script is not defined, Live will trigger the connection of relevant [endpoints](xref:MO_Virtual_Signal_Groups#endpoints). In case a global orchestration script is defined, it is up to that script to trigger the connection of endpoints.

## Metadata

Metadata can be defined on an orchestration event, allowing easy access to extra information required during execution of the orchestration scripts.

## Service Monitoring

When the orchestration event(s) are related to a job, there is an option to trigger the creation of a DMA Service at execution of the very first Event, and to delete it at the execution of the very last event.
