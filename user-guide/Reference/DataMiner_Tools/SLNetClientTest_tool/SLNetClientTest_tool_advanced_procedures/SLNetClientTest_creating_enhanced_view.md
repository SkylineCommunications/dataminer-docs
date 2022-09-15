---
uid: SLNetClientTest_creating_enhanced_view
---

# Creating an enhanced view

From DataMiner 10.0.0/9.6.1 onwards, it is possible to enhance a view with an element, so that the alarm level of the element will affect the alarm level of the view, even if the element is not part of the view, and so that the data pages of this element will be displayed on the card of the view.

To create such an enhanced view:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window.

1. In the *Message Type* drop-down list, select *EnhanceViewWithElementRequestMessage*.

1. Specify the ID of the view you want to enhance and the ID of the element you want to use for this.

1. Click *Send Message*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
