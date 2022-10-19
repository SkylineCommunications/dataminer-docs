---
uid: Process_Definition
---

# Process definition

All [activities](xref:PA_Activities) that a process comprises of are defined in a process definition. The process definition also indicates how they are connected with each other.

Example: `PA Start Event -> Watch Folder -> Move File -> Read File -> Extract Materials -> … -> PA End Event`

## Start Event

Each process definition needs to start with one of the following events:

- **PA None Event**: This is the entry point of the process, giving the possibility to trigger the execution of a process initially or wait for an external trigger.

- **PA Timer Start Event**: This is an entry point of the process, giving the possibility to trigger the execution of a process on a regular basis (configurable timespan).

## End Event

Each process definition needs to have one or more end events to indicate the end point(s) of the process.
