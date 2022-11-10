---
uid: PA_Process_Definition
---

# Process definition

All [activities](xref:PA_Activities) in a process are defined in the process definition. The process definition also indicates how they are connected with each other.

Example: *PA Start Event -> Watch Folder -> Move File -> Read File -> Extract Materials -> … -> PA End Event*

![Process definition](~/user-guide/images/Process_Definition.png)

> [!TIP]
> See also: [Creating and configuring a process definition](xref:PA_Creating_and_Configuring_a_Process_Definition)

### Start Event

Each process definition needs to start with one of the following events:

- **PA None Event**: This is an entry point of the process, giving the possibility to trigger the execution of a process immediately or wait for an external trigger.

- **PA Timer Start Event**: This is an entry point of the process, giving the possibility to trigger the execution of a process on a regular basis (configurable time span).

### End Event

Each process definition needs to contain one or more end events to indicate the end point(s) of the process.

### Activation window

For a process definition to be usable, it must be instantiated. This means that an activation window must be created, defining when the process can be used.

The activation window defines the start and stop time of the time period in which the process can be used. It also allows you to define a process name, which can be used by external triggers for the execution of a process.

> [!TIP]
> See also: [Creating and configuring a process definition](xref:PA_Creating_and_Configuring_a_Process_Definition#creating-an-activation-window)

### Gateway

For more complex processes, such as non-linear processes, gateways can be used. These allow you to create multiple branches or paths in a process and to decide which path(s) to take based on the result of previous activities.

The behavior of a gateway is defined by so-called routing rules.

A gateway is a function with 5 inputs and 5 outputs. Routing rules indicate the condition to generate one or multiple tokens at one or several outputs of the gateway.

> [!TIP]
> See also: [Integrating gateways](xref:PA_Integrating_Gateways)
