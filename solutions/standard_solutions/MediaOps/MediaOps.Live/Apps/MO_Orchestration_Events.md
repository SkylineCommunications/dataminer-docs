---
uid: MO_Orchestration_Events
---

# Orchestration Events app

The Orchestration Events app provides visibility on the orchestration events defined in the system.

![Orchestration Events app](~/solutions/images/MO_OE_app.png)

## App overview

The following pages are available in the app:

- ![Arrivals Board page icon in navigation pane](~/solutions/images/MO_OE_Arrivals_Board_icon.png) **Arrivals Board**: Shows the list of events starting up to 5 minutes in the past and up to 8 hours in the future.

- ![Search Events page icon in navigation pane](~/solutions/images/MO_OE_Search_Events_icon.png) **Search Events**: Allows you to search for specific events by name, time, type, state, or orchestration type.

On both pages, you can access the full details of each event by clicking the *Info* icon.

## Orchestration events

Orchestration events allow the execution of automation scripts at a defined date and time in the future. These events can execute regular automation scripts, but it is also possible to link to specific orchestration scripts, which allows easier manual testing.

Orchestration events can be created using the MediaOps Live API. [MediaOps Plan](xref:MediaOps.Plan) also uses this API to create and update the orchestration events linked to [jobs](xref:MO_Scheduling).

> [!TIP]
> To understand in more detail what can be achieved with orchestration events, follow the tutorial [Creating orchestration events](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents) .

## Orchestration scripts

Any automation script added to the `MediaOps/OrchestrationScripts` folder is be an orchestration script. In addition to the regular script dummies and parameters, you can use profile parameters and definitions as input arguments in these scripts by implementing the `OrchestrationScript` class. For detailed information, refer to [Orchestration scripts](xref:MediaOpsLive_OrchestrationScript).

When an orchestration script is executed manually, and all script dummies and parameters have been filled in, a UI will prompt the user for the orchestration parameters. The UI will also allow the user to select a profile instance instead of providing each parameter value individually.

> [!TIP]
> To understand in more detail how to implement orchestration scripts, follow the tutorial [Creating orchestration scripts](xref:Tutorial_MediaOpsLive_CreateOrchestrationScripts).

### Global and node orchestration scripts

An orchestration event can be defined with a **global orchestration script** and associated values for all arguments. At event time, the script will be launched with the provided arguments.

When nodes that are part of a job need to be configured by specific scripts, a **node orchestration script** can be configured for each node of the job, either as a replacement for or in addition to the global orchestration script. When no global orchestration script is defined, MediaOps Live will execute all node orchestration scripts automatically.

> [!IMPORTANT]
> When a global orchestration script is defined, this script is responsible for triggering the execution of the configured node orchestration scripts.

## Connectivity

Orchestration events can also define expected connectivity between [virtual signal groups](xref:MO_Virtual_Signal_Groups#virtual-signal-groups). At event time, if a global orchestration script is not defined, MediaOps Live will trigger the connection of relevant [endpoints](xref:MO_Virtual_Signal_Groups#endpoints). In case a global orchestration script is defined, it is up to that script to trigger the connection of endpoints.

## Metadata

Metadata can be defined on an orchestration event, allowing easy access to extra information required during execution of the orchestration scripts.

## Service monitoring

When orchestration events are related to a job, it is possible to trigger the creation of a DataMiner service when the very first event is executed. This service can then be deleted when the very last event us executed.

> [!TIP]
> To find out how this is done, follow the tutorial [Creating orchestration events](xref:Tutorial_MediaOpsLive_CreateOrchestrationScripts#step-9-generate-a-service-from-the-orchestration-script).
