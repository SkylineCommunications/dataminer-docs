---
uid: Simulated_elements
---

# Simulated elements

On a DataMiner System, you can create simulated elements. These elements behave as if they are communicating with a physical device, but in fact they are merely displaying data from a simulation file.

> [!WARNING]
> Element simulations should be used for demo purposes only. Moreover, it is advisable to only simulate SNMP devices. As simulation files only contain data captured at one specific point in time, simulating serial devices is likely to result in unrealistic behavior.

## About simulated elements

A regular DataMiner element communicates with a physical device using a DataMiner protocol, which translates the commands and the responses that are being exchanged.

A simulated DataMiner element communicates with a simulation file, which is a file containing a set of parameter values captured at a certain point in time while the actual communication between a regular DataMiner element and a physical device was being monitored. These parameter values are then used to construct commands and responses according to the rules set out in the DataMiner protocol. That way, a communication stream between a DataMiner element and a non-existent device is simulated.

![Simulated elements](~/user-guide/images/SimulatedElements.jpg)

### Limitations

Although simulated elements behave like regular DataMiner elements, there are limitations.

If you restart a simulated element, all parameters of that element will be reset to the values stored in the simulation file.

## Creating a simulated element

For information on how to create a simulated element, see [Creating a simulated element](xref:Creating_a_simulated_element).

## What happens when you enable simulation?

1. In the file *Element.xml* for the element in question, the “simulation” attribute will be set to TRUE:

   ```xml
   <Element ... simulation="true">
   ```

1. The element will start using the simulation file (located in the folder *C:\\Skyline DataMiner\\simulations\\*) of which the *protocol* and *version* attributes match the protocol and protocol version of the element. If no such file can be found, then the one of which only the *protocol* attribute matches the protocol of the element will be used:

   ```xml
   <Simulation name="..." protocol="..." version="...">
   ```

## Using a specific simulation file

If you want the element to use a specific simulation file, specify the name of that file (without “Simulation\_” prefix and without ”.xml” extension) in the *simulation* attribute of that element’s *Element.xml* file.

If, for example, you want to use the file named “Simulation_MyDevice.xml”, specify the following:

```xml
<Element ... simulation="MyDevice">
```
