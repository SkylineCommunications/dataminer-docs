---
uid: Linking_an_element_to_a_fixed_DMA_Force_Agent
---

# Linking an element to a fixed DMA: Force Agent

> [!NOTE]
> This feature is only included in the legacy System Display application, and is no longer available from DataMiner 9.6.0 onwards.

In a Failover setup, all elements are installed on both the primary DMA and the backup DMA. Those on the online DMA will be active, while those on the offline DMA will not.

However, certain special elements (e.g. elements that are used for time synchronization) should always be active, regardless of whether the DMA hosting them is online or offline. To make sure such an element always remains active, enable the *Force Agent* option during element creation and specify the DMA to which the element has to be linked. In that case, when the DMA to which the element is linked goes offline, the counterpart of the element on the online DMA will run in replication mode.

## Applying the Force Agent option

To create an element that always remains active on one DMA in a Failover setup:

1. Create a new element in System Display (by going to *Admin* > *Elements*, and then clicking *New*).

   > [!TIP]
   > See also: [How can I open the legacy System Display and Element Display applications?](xref:DataMiner_client_applications#how-can-i-open-the-legacy-system-display-and-element-display-applications)

1. During the step in the Element Wizard where you choose the DMA on which the element is to be added, click the *Force Agent* button.

1. In the *Force Failover Agent* dialog box, select the DMA that has to keep hosting the element, even when the DMA is offline.

1. Still in the same dialog box, specify the user credentials (username and password) to be used by the element’s counterpart running in replication mode on the other DMA.

1. Click *OK* and continue with the element creation.
