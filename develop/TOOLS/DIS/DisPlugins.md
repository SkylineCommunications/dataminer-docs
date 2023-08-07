---
uid: DisPlugins
---

# Plugins

## Generate driver help

Generates the driver help.

## Add After Startup

Adds the after startup logic to the protocol. DIS will check whether the *protocol.xml* file contains an after startup trigger, and will add one if none was found. Apart from the trigger, it will also add all remaining items of the after startup flow.

See also [Executing a QAction after startup](xref:LogicExamples#executing-a-qaction-after-startup)

## Add matrix...

Adds a matrix and/or Inputs and Outputs tables to the protocol.

## Add SNMP System Info...

Adds the following SNMP System Info parameters to the protocol:

- System Description (1.3.6.1.2.1.1.1)
- System Object ID (1.3.6.1.2.1.1.2)
- System Uptime (1.3.6.1.2.1.1.3)
- System Name (1.3.6.1.2.1.1.5)
- System Contact (1.3.6.1.2.1.1.4)
- System Location (1.3.6.1.2.1.1.6)

## Add SNMP Trap Receiver...

Adds an SNMP trap receiver and a QAction with boilerplate code to process received traps.

## Add Table Context Menu...

Adds a custom context menu to a table in the protocol. You can choose between the following:

- Rows Manager (User-definable Keys): A default context menu that provides add, duplicate, edit, and delete functionality.
- Rows Manager (Auto-incremented Keys): An extension of the previous type that allows developers to work with an auto-increment key parameter.
- Custom: Opens a wizard that allows you to specify the options.
