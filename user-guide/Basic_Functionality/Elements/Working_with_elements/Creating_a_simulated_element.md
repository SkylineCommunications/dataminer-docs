---
uid: Creating_a_simulated_element
---

# Creating a simulated element

To create a simulated element:

1. Verify if a simulation file is available that uses the relevant protocol. To do so, in the folder *C:\\Skyline DataMiner\\simulations\\*, look for an .xml file with a file name consisting of the term “Simulation” and the name of the protocol.

   If no simulation file is available yet, it will first need to be created. See [Creating a simulation file](#creating-a-simulation-file).

1. In DataMiner Cube, right-click the view where you want to create the simulated element, and select *New \> Element*.

1. Enter the element name and protocol, like during the creation of a normal element. See [Adding elements](xref:Adding_elements).

1. For the IP address and port, enter the localhost IP, *127.0.0.1*, and specify a port that is not used.

1. Finish element creation as for a normal element.

   The element will be added in the Surveyor, and should go into timeout state after a short time.

1. Right-click the element, and select *Actions \> Enable simulation*. The element will then restart and begin using the simulation file for its responses.

   > [!NOTE]
   >
   > - Make sure you only do this with elements for which there is a simulation file in the folder *C:\\Skyline DataMiner\\simulations\\*. Otherwise, the element will become unresponsive.
   > - Simulations of elements with HTTP protocols are currently not yet supported.

> [!TIP]
> See also: [Simulated elements](xref:Simulated_elements)

## Creating a simulation file

From DataMiner 10.0.6 onwards, simulation files can be created in DataMiner Cube.

To do so:

1. Right-click the element for which you want to create a simulation file.

1. In the context menu, select *Actions* > *Create simulation*.

   A message box will appear to indicate that the simulation file has been created.

1. Click *OK* in the message box.

1. On the DMA, go to the following directory: *C:\\Skyline DataMiner\\Protocols\\NAME\\VERSION\\*

1. Copy the file named Simulation_ELEMENTNAME.xml to the following directory: *C:\\Skyline DataMiner\\simulations\\*

1. Restart the DMA.
