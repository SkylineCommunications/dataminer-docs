---
uid: Process_Definition
---

# Process definition

All [activities](xref:PA_Activities) that a process comprises of are defined in a process definition. The process definition also indicates how they are connected with each other.

Example: *PA Start Event -> Watch Folder -> Move File -> Read File -> Extract Materials -> … -> PA End Event*

## Start Event

Each process definition needs to start with one of the following events:

- **PA None Event**: This is the entry point of the process, giving the possibility to trigger the execution of a process immediately or wait for an external trigger.

<!-- Comment:  immediately? manually? (original version: initially) + the/an?-->

- **PA Timer Start Event**: This is an entry point of the process, giving the possibility to trigger the execution of a process on a regular basis (configurable time span).

## End Event

Each process definition needs to have one or more end events to indicate the end point(s) of the process.

## Activation window

For process definition to be usable, it must be instantiated, which means that an activation window must be created, defining when the process can be used.

The activation window defines the start and stop time of the period in which the process can be used. It also allows you to define a process name, which can be used by external triggers for the execution of a process.

## Gateway

For more complex processes, gateways can be used. These allow you to create multiple branches or paths in a process and decide which path(s) to take based on the result of previous activities.
