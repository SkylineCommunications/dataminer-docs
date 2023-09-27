---
uid: Debugging_connectors_Element_connections
---

# Debugging connectors: Element connections

In some connectors, we use [element connections](xref:Virtual_elements) to transfer data from one element to another. This way you can handle the data from one or more elements while you are using another element in DataMiner.

This particular use case focuses on an element that receives data from multiple elements. During the configuration of the element, unexpected behavior was spotted:

- Element connections were not correctly updated

- The data from the connected elements was not received in the right order

## Investigation

The first indication that something was wrong was in the element itself. There, some of the tables clearly were not getting filled in.

As usual when something goes wrong with an element, the first place we looked was the **element logging**. In the log file for the element, we could see exceptions indicating that while commands were received, no data was returned that made it possible to process these commands. This suggests that something was preventing data from reaching the destination element.

![Debugging connectors 1](~/develop/images/Debuggingconnectors1.png)

The next step was to take a look at the **Element Connections module** in DataMiner Cube. There we spotted several element connections that were configured incorrectly. However, after we corrected these, we noticed that the changes were not being saved.

![Debugging connectors 2](~/develop/images/Debuggingconnectors2.png)

This made the ***ElementConnections.xml file*** the next logical source of information. You can find this file in the folder `C:\Skyline DataMiner\Elements\`. In this file, we spotted *Link* tags with missing or empty *sParam* tags. This was a likely cause for the issues.

![Debugging connectors 3](~/develop/images/Debuggingconnectors3.png)

However, after fixing the issue with the *ElementConnections.xml* file (more on this below), there were still errors in the element logging. These indicated that the connector received data in a **different order than expected**. It expected to receive data from an “Element A” first and would only be able to start processing data for a next “Element B” after it had processed this first data. However, data was received in the opposite order. This is in fact a problem in the connector, not in the element connections.

## Conclusion

We were facing two issues in this use case: one was a problem in the *ElementConnections.xml* file, which did not have anything to do with our connector. The other was an incorrect design of the connector.

To fix the problem in the *ElementConnections.xml* file, we first took a screenshot of all connections in the Element Connections app. Then we stopped all DMAs in the cluster and deleted everything in the *ElementConnections.xml* file on each DMA, except for the *Connections* tag.

![Debugging connectors 4](~/develop/images/Debuggingconnectors4.png)

We then restarted all DMAs and configured the element connections again in the Element Connections app, based on the screenshot we took earlier. Just to be safe, we added them one by one, saving after each element connection was configured. The element connections that were configured incorrectly earlier, we now added correctly instead. After this, the element received data again.

However, to fix the issue of the unexpected order in which data arrived, we needed to change the connector itself. This is because you can never rely on the order in which data will be sent or received through element connections. Imagine, for example, that you have configured your connector to require data from element A first, before it can process data from element B. If element A is stopped or in timeout, you will never receive the data from this element, so every time you receive data from element B, your code will throw an exception.

The solution in our connector was to build in a mechanism to save the received data, check all the data we have, and then only process it when all the required data is available.

## Tips & tricks

- If data is missing in an element, always check the element logging for errors.

- Do not design a connector that requires element connection data from different elements in a specific order, because you cannot count on the order in which you will receive this data.
