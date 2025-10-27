---
uid: Simulated_elements
keywords: element simulation
---

# Simulated elements

On a DataMiner System, you can create simulated elements. These elements behave as if they are communicating with a physical device, but in fact they are merely displaying data from a simulation file.

> [!WARNING]
> Element simulations should be used for demo purposes only. Moreover, it is advisable to only simulate SNMP devices. As simulation files only contain data captured at one specific point in time, simulating serial devices is likely to result in unrealistic behavior.

> [!TIP]
> For information on how to create a simulated element, see [Creating a simulated element](xref:Creating_a_simulated_element).

## About simulated elements

A regular DataMiner element communicates with a physical device using a DataMiner protocol, which translates the commands and the responses that are being exchanged.

A simulated DataMiner element communicates with a simulation file, which is a file containing a set of parameter values captured at a certain point in time while the actual communication between a regular DataMiner element and a physical device was being monitored. These parameter values are then used to construct commands and responses according to the rules set out in the DataMiner protocol. That way, a communication stream between a DataMiner element and a non-existent device is simulated.

![Simulated elements](~/dataminer/images/SimulatedElements.jpg)

### Limitations

Although simulated elements behave like regular DataMiner elements, there are limitations.

If you restart a simulated element, all parameters of that element will be reset to the values stored in the simulation file.
