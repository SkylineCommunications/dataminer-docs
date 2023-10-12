---
uid: Creating_a_simulated_spectrum_element
---

# Creating a simulated spectrum element

For demo purposes, it can be useful to set up a simulated spectrum element. This element will show data from a spectrum recording, rather than actual real-time data.

To do so:

1. Save a spectrum recording as a shared recording with the name “simulation”. See [Working with trace recordings](xref:Working_with_trace_recordings).

    Alternatively, you can also manually copy a recording into the folder “*C:\\Skyline DataMiner\\Users\\SharedUserSettings\\Spectrum Recordings\\*” and rename it to “*ProtocolName*.simulation.dat”.

2. Create a new spectrum analyzer element. See [Adding elements](xref:Adding_elements)

3. Stop the DMA. See [Starting or stopping DataMiner Agents in your DataMiner System](xref:Starting_or_stopping_a_DMA_in_DataMiner_Cube).

4. In the *Element.xml* file for the element you have just created, change the element ID so that it is in the range 50000-50100. This will mark the spectrum element as being in simulated mode.

    > [!NOTE]
    > For this to work, the DMA ID must be less than 500.

5. Restart the DMA.

    As soon as the spectrum analyzer card is opened, the simulation will begin, with the recording playing in a continuous loop.

> [!NOTE]
> - Only one simulation can be configured. This simulation will be used for all simulated spectrum elements using the same protocol.
> - Since this is a simulation, modifying parameters such as the start or stop frequency will have no effect.
> - The simulated traces are also available for spectrum monitors.
> - If no simulation recording file is found, the element will display a random triangle trace.
