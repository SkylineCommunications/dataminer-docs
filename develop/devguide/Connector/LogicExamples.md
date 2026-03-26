---
uid: LogicExamples
---

# Examples

The following examples illustrate how protocol components can be combined in order to implement functionality.

- Periodically retrieving a MIB variable
- Periodically incrementing a parameter value
- Executing a QAction after startup

## Periodically retrieving a MIB variable

In order to periodically retrieve a MIB variable, a timer needs to be defined and set to the desired interval (e.g., 10s). Then a group is defined of type "poll", containing a parameter to be polled. The parameter definition includes the OID of the variable that must be retrieved via SNMP.

![Periodically retrieving a MIB variable](~/develop/images/Periodically_Inspecting_a_MIB_Variable.jpg)

## Periodically incrementing a parameter value

The following diagram shows the components needed to let a parameter increment its value every 10 seconds. In this example, an action of type "increment" is used on a parameter.

![Periodically incrementing a parameter value](~/develop/images/Periodically_Incrementing_a_Parameter_Value.jpg)

## Executing a QAction after startup

The following example illustrates how to execute logic defined in a QAction after a DMA element has completely started. First, a trigger is defined triggering after startup (time "after startup") of the protocol (on "protocol"). This trigger will execute an action that adds group 1 to the group execution queue.

This group in turn executes an action of type "run actions" on parameter 100. Actions of type "run actions" execute the QAction linked with the specified parameter.

![Executing a QAction after startup](~/develop/images/Executing_a_QAction_after_Startup.jpg)

By using a group, we ensure that the QAction will be executed after the group execution queue of the main protocol thread has started.
