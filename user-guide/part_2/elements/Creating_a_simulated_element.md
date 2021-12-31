## Creating a simulated element

To create a simulated element:

1. Verify if a simulation file is available that uses the relevant protocol. To do so, in the folder *C:\\Skyline DataMiner\\simulations\\*, look for an .xml file with a file name consisting of the term “Simulation” and the name of the protocol.

    If no simulation file is available yet, it will first need to be created. See [Creating a simulation file](#creating-a-simulation-file).

2. In DataMiner Cube, right-click the view where you want to create the simulated element, and select *New \> Element*.

3. Enter the element name and protocol, like during the creation of a normal element. See [Adding and deleting elements](Adding_and_deleting_elements.md).

4. For the IP address and port, enter the localhost IP, *127.0.0.1*, and specify a port that is not used.

5. Finish element creation as for a normal element.

    The element will be added in the Surveyor, and should go into timeout state after a short time.

6. Right-click the element, and select *Actions \> Enable simulation*. The element will then restart and begin using the simulation file for its responses.

    > [!NOTE]
    > -  Make sure you only do this with elements for which there is a simulation file in the folder *C:\\Skyline DataMiner\\simulations\\*. Otherwise, the element will become unresponsive.
    > -  Simulations of elements with HTTP protocols are currently not yet supported.

> [!TIP]
> See also:
> [Simulated elements](Simulated_elements.md)

### Creating a simulation file

> [!NOTE]
> This feature is available in DataMiner Cube from DataMiner 10.0.6 onwards. Prior to this DataMiner version, it is only included in the legacy System Display application, which is no longer available from DataMiner 9.6.0 onwards.

From DataMiner 10.0.6 onwards, simulation files can be created in DataMiner Cube.

To do so:

1. Right-click the element for which you want to create a simulation file.

2. In the context menu, select *Actions* > *Create simulation*.

    A message box will appear to indicate that the simulation file has been created.

3. Click *OK* in the message box.

4. On the DMA, go to the following directory: *C:\\Skyline DataMiner\\Protocols\\NAME\\VERSION\\*

5. Copy the file named Simulation_ELEMENTNAME.xml to the following directory:

    *C:\\Skyline DataMiner\\simulations\\*

6. Restart the DMA.

Prior to DataMiner 10.0.6, simulation files can only be created using the System Display client application.

To do so:

1. Open System Display. See [How can I open the legacy System Display and Element Display applications?](../../part_6/faq/DataMiner_client_applications.md#how-can-i-open-the-legacy-system-display-and-element-display-applications)

2. Go to *Admin \> Elements*, and double-click the element for which you want to create a simulation file.

    This will open the element in Element Display.

3. Right-click anywhere on the Element Display page, and select *Scripts \> Create Simulation* from the shortcut menu.

    A message box will appear to indicate that the simulation file has been created.

4. Click *OK* in the message box.

5. On the DMA, go to the following directory: *C:\\Skyline DataMiner\\Protocols\\NAME\\VERSION\\*

6. Copy the file named Simulation_ELEMENTNAME.xml to the following directory:

    *C:\\Skyline DataMiner\\simulations\\*

7. Restart the DMA.
