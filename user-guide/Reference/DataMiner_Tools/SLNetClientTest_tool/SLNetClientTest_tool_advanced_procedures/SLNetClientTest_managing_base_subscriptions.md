---
uid: SLNetClientTest_managing_base_subscriptions
---

# Managing base subscriptions

The "base subscriptions" feature allows you to increase performance when retrieving element and parameter information by caching the data in SLNet.

When a client (e.g. DataMiner Cube) opens an element card, a subscription is made for that element. SLNet then retrieves the element data from the other processes (SLDataminer, SLElement, etc.), caches it, and makes arrangements so that changes get pushed to it immediately. When a client closes an element card, the subscription is removed, and the cached data is cleared.

However, if a base subscription has been defined for an element, the subscription for this element stays open permanently. As a consequence, when you open an element card for such an element, SLNet will send the data to the client instantly, as it does not have to do any initial setup. This is particularly useful for elements that are accessed very frequently.

The base subscriptions for a DMA can be found in *C:\\Skyline DataMiner\\BaseSubscriptions.xml*.

In order to ensure that the subscription for a particular element stays open:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select *BaseSubscriptionMessage*.

1. Select the *BaseSubscriptions* row and click the ... button on the right in order to open the *BaseSubscription Collection Editor*.

1. Click the *Add* button to add a new element subscription.

1. Fill in the following properties, and then click *OK*:

   - The *DmaID* and *ElementID* of the element.

   - The *MessageType*, usually "ParameterChangeEventMessage".

   - The *Name* of the subscription, e.g. "MyElementSubscription".

   - The *Type*, in this case "Element".

     > [!NOTE]
     > The *Type* determines how specific the subscription is. If, for instance, you select "Parameter" instead of "Element", you subscribe to all ParameterChangeEvents for a specific parameter only. In that case, the *ParameterID* field also needs to be filled in.

1. In the *Build Message* tab, make sure "Set" is selected as the *Type*, and click *Send Message* to save the subscription.

1. After you have received a positive response, in the *Build Message* tab, select "Subscribe" as the *Type*, and click *Send Message*.

> [!NOTE]
>
> - To remove the subscription, in the *Build Message* tab, select "Remove" as the *Type*, and click *Send Message*.
> - After you have set the subscription, you can test the functionality by going to *Diagnostics* > *Connection Details* > *BaseSubscriptionManager*. In the subscription set, you will then be able to see all the elements you are subscribed to.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
