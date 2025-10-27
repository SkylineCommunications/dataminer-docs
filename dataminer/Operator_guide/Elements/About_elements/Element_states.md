---
uid: Element_states
---

# Element states

An element can be in one of three states:

- **Active**: This is the default state of an element. The DMA is polling the element and the virtual IP address of the element is active.

- **Paused**: Communication between the DMA and the element has been paused, but the virtual IP address of the element is still active. This means that the element and all associated resources can still be accessed.

- **Stopped**: Communication between the DMA and the element has been stopped and the virtual IP address of the element has been destroyed.

> [!NOTE]
> When an element is paused, no changes are made to open connections. This means that if the connection was open, it will remain open. However, if an element is in paused state and the DMA is restarted, the connection will not be initiated again.

> [!TIP]
> See also: [Changing the state of an element](xref:Changing_the_state_of_an_element)
