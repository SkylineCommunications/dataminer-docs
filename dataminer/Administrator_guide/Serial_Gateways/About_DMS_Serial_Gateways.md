---
uid: About_DMS_Serial_Gateways
---

# About DMS Serial Gateways

A DMS Serial Gateway offers many advantages. Cabling is much more structured, elements can easily be swapped between DMAs, but most importantly, overall system performance is greatly enhanced.

On a multi-drop serial bus (e.g., RS-485), a DMA is daisy-chained across multiple devices and can only talk to a single device at a time. In other words, the DMA has to go through polling cycles in order to retrieve all the data from all elements connected to the serial bus.

With the DMS Serial Gateway, there is essentially no difference. This device has a single 10/100 Ethernet port and 16 serial ports, which can be addressed individually using the IP address, assigned to the Serial Gateway, and an associated TCP port (e.g., 4000, 4001, 4002, etc. for serial port 1, serial port 2, serial port 3, etc.). Consequently, all communication has to go across the same physical Ethernet, one element after the other.

However, due to the high bandwidth of the Ethernet connection and the unique design of the DMA protocol engine (i.e., one thread per element), the polling of the elements on a Serial Gateway is practically simultaneous. In other words, the deployment of a Serial Gateway results in a significantly increased performance of the overall system.

> [!NOTE]
> - Although the DMS Serial Gateway is an industry-standard serial server device, it has some unique features. If you are using a different serial server device, not all information in this section will apply to your system setup. Please refer to the user manual of your serial server for more details on e.g., configuration.
> - If you purchase your own serial server devices, we strongly advise you to verify whether the device supports so-called raw connections, whereby data sent by applications to the IP address of the serial server on a specific port is transferred onto the associated serial port. Some serial server devices use proprietary methods and require the installation of some type of mapping software that creates virtual COM ports mapped to a port of the serial server.
>
