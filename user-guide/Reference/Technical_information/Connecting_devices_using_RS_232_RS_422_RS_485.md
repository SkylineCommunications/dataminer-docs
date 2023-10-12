---
uid: Connecting_devices_using_RS_232_RS_422_RS_485
---

# Connecting devices using RS-232/RS-422/RS-485

> [!CAUTION]
> This section of the documentation is merely intended by way of information on third-party products that are often used with DataMiner. However, Skyline Communications is not responsible for this content. For more information or support, please contact the vendor of the product.

One of the main functionalities of DataMiner is to monitor devices. Most modern devices can be monitored and controlled over Ethernet (RJ-45) and can immediately be connected to your network.

However, there are still devices out there that do not have an Ethernet card. In most cases, those devices rely on serial communication or on IO pins. Here, we focus on devices that use serial communication, more particularly using the standards RS-232, RS-422 or RS-485.

One of the first widely used serial communication standards was **RS-232**, which was introduced in 1962. Even today, devices are still in use that support this standard. RS-232 is a single-ended data transmission (one signal line) and can be used for cables up to 15 m (up to 300 m with low-capacitance cables). The original standard advises 25-pin (DB-25) connectors, but there are over 20 different connection variants described in the standard. In many devices, there are a lot of pins that are not used, and therefore, to reduce cost and to save space, smaller connectors came into use (e.g. DE-9 and recently also RJ-45 connectors).

![Connectors](~/user-guide/images/Connectors.png)

**RS-422** (first issued in 1975) was created to replace RS-232. It uses differential data transmission (the signal is measured between two cables that are twisted), which results in less noise on the cable. This resulted in possible distances up to 1200 m (up to 100 kbits/s) and speeds up to 10 Mbits/s (up to 12 m). The same DB-25 connectors were planned to be used for the RS-422 standard. However, just like with the RS-232 standard, not all pins were always used, and therefore smaller connectors were also used.

![RS-422_Cabling](~/user-guide/images/RS-422_Cabling.png)<br>
*RS-422 Cabling between two devices [(Source)](http://docplayer.net/22370634-A-practical-guide-to-using-rs-422-and-rs-485-serial-interfaces-v-1-0.html)*

**RS-485** (first introduced in 1983) uses three-state logic, allowing transmitters to be deactivated. For this reason, only two wires are needed for full-duplex communication. The speed and distances that can be achieved with this standard are similar to RS-422.

To monitor devices in DataMiner through RS-232, RS-422, or RS-485, you will need a gateway that translates IP messages to serial commands. A well-known provider of such gateways is [Moxa](https://www.moxa.com/en/products/industrial-edge-connectivity/serial-device-servers/general-device-servers), which is by default supported by DataMiner. The pin layout for the Moxa NPort 5650 gateway can be found in the image below for clarification. However, keep in mind that your device can have a different pin layout and that it is best to check in the user manual of your device to find the correct pin layout.

![NPort](~/user-guide/images/MoxaExamplepinLayout.png)<br>
*Source: NPort 5600 Series User’s Manual, 12th edition, page 110*
