---
uid: Connector_help_Vecima_CableVista
---

# Vecima CableVista

The Vecima CableVista connector performs MPEG decoding, modulation and upconversion for up to 24 NTSC or 12 PAL channels.

This connector can be used to display and configure information of the related device.

## About

This connector uses **SNMP** to retrieve information from the device, and allows the user to monitor and configure the Vecima CableVista.

The connector also allows access to the **Web Interface** of the device.

### Version Info

| **Range**    | **Description**                                                 | **DCF Integration** | **Cassandra Compliant** |
|---------------------|-----------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x             | Initial Version                                                 | No                  | No                      |
| 1.1.0.x\[SLC Main\] | Based on version 1.0.0.7 Support for RF Dual and Baseband Cards | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: 161
- **Get community string**: public
- **Set community string**: private

## Usage

### General

This page displays general information about the device.

- **System Name:** The system name.

- **System Description:** The system description with the version and compilation date.

- **System Uptime:** Time that the device has been operating.

- **Model Number:** Decoder model number.

- **Serial Number:** Unit serial number.

- **Config Modified:** Indicates whether or not the configuration has been modified.

- **Save Status:** Save status state.

- **Reboot:** Reboots the device.

- **Interfaces:** Contains information about the state of the existing interfaces.

- **Interf. Type:** The type of interface. Additional values are assigned by the Internet Assigned Numbers Authority (IANA), through updating the syntax of the IANA Interf. Type textual convention.
  - **Interf. Mtu:** The size of the largest packet which can be sent/received on the interface, specified in octets. For interfaces that are used for transmitting network datagrams, this is the size of the largest network datagram that can be sent on the interface.
  - **Interf. Speed:** An estimate of the interface's current bandwidth in Mbits per second. For interfaces which do not vary in bandwidth or for those where no accurate estimation can be made, this object should contain the nominal bandwidth.
  - **Interf. MAC Address:** The interface's address at its protocol sub-layer. For example, for an 802.x interface, this parameter normally contains a MAC address.
  - **Interf. Admin State:** The desired state of the interface. The testing state indicates that no operational packets can be passed. When a managed system initializes, all interfaces start with **Interf. Admin State** in the *Down* state. As a result of either explicit management action or per configuration information retained by the managed system, **Interf. Admin State** is then changed to either the *Up* or *Testing* states (or remains in the *Down* state).
  - **Interf. Oper. State:** The current operational state of the interface. The testing state indicates that no operational packets can be passed. If **Interf. Admin State** is *Down* then **Interf. Oper. State** should be *Down*. If **Interf. Admin State** is changed to *Up* then **Interf. Oper. State** should change to *Up* if the interface is ready to transmit and receive network traffic; it should change to dormant if the interface is waiting for external actions (such as a serial line waiting for an incoming connection); it should remain in the *Down* state if and only if there is a fault that prevents it from going to the *Up* state; it should remain in the not present state if the interface has missing (typically, hardware) components.
  - **Interf. In Octets:** The total number of octets received on the interface, including framing characters. Discontinuities in the value of this counter can occur at re-initialization of the management system.
  - **Interf. In Rate:** Rate of received octets.
  - **Interf. In Unicast Packets:** The number of packets, delivered by this sub-layer to a higher sub-layer, which were not addressed to a multicast or broadcast address at this sub-layer.
  - **Interf. In Discards:** The number of inbound packets which were chosen to be discarded even though no errors had been detected to prevent their being deliverable to a higher-layer protocol. One possible reason for discarding such a packet could be to free up buffer space.
  - **Interf. In Errors:** For packet-oriented interfaces, the number of inbound packets that contained errors preventing them from being deliverable to a higher-layer protocol. For character-oriented or fixed-length interfaces, the number of inbound transmission units that contained errors preventing them from being deliverable to a higher-layer protocol.
  - **Interf. Out Octets:** The total number of octets transmitted out of the interface, including framing characters.
  - **Interf. Out Rate:** Transmitted octets rate.
  - **Interf. Out Unicast Packets:** The total number of packets that higher-level protocols requested be transmitted, and which were not addressed to a multicast or broadcast address at this sub-layer, including those that were discarded or not sent.
  - **Interf. Out Discards:** The number of outbound packets which were chosen to be discarded even though no errors had been detected to prevent their being transmitted. One possible reason for discarding such a packet could be to free up buffer space.
  - **Interf. Out Errors:** For packet-oriented interfaces, the number of outbound packets that could not be transmitted because of errors. For character-oriented or fixed-length interfaces, the number of outbound transmission units that could not be transmitted because of errors.

- **Processor Identity:** A table of Identity Information items for a CableVista Processor Card within a chassis.

- **Serial Number:** The processor card's serial number.
  - **Model Number:** The processor card's model number.
  - **Hardware Revision:** The processor card's hardware revision.
  - **PCB Software Revision:** The processor card's PCB software revision.
  - **Bootloader Software Revision:** The processor card's bootloader software revision.
  - **Kernel Software Revision:** The processor card's kernel software revision.
  - **Ramdisk Software Revision:** The processor card's ramdisk software revision.
  - **Microcontroller Software Revision:** The processor card's microcontroller software revision.
  - **Gigabit Ethernet FPGA Software Revision:** The processor card Gigabit Ethernet Input FPGA software revision.
  - **ASI FPGA Software Revision:** The processor card ASI Input FPGA software revision.
  - **PLD Software Revision:** The processor card's PLD software revision.

- **Voltage 12V:** Real voltage of 12V Power.

- **Voltage 5V:** Real voltage of 5V Power.

- **Voltage 3V:** Real voltage of 3V Power.

- **PCB Temperature:** The temperature of the PCR board.

- **CPU Temperature:** The temperature of the CPU.

- **GbE Temperature:** The temperature of the PCR board.

- **BGA Temperature:** The temperature of the BGA processor.

- **Fan 1:** Rpm of Fan 1.

- **Fan 2:** Rpm of Fan 2.

- **CPU Fan 1:** Rpm of Fan 1 of CPU.

### Overview Cards

Provides an overview of the Quad Cards for the table Output Cards related to the table RF Quad Port Status Table and the RF Quad Channel Status Table, all from the Output page.

### Overview Streams

Displays an overview of the Input Stream Table (Transport Stream page) related to the Video Program Table (Program page), Video PID Table and Video Descriptor Table, these last two are displayed in the PID page.

### Input

Use this page to configure the input related parameters.

- **Input Mode:** The source for input data, this is the preferred way of switching between ASI or one of the Gigabit Ethernet ports.

- **Ethernet Table:** A table of Status items for Fast Ethernet devices on the processor card.

- **Ethernet Status Mode:** The current Link mode of the Fast Ethernet port.
  - **Ethernet Speed:** The current Link speed of the Fast Ethernet port.
  - **Ethernet DHCP:** The DHCP client is enabled on the Fast Ethernet port.
  - **Ethernet IP Type:** The Fast Ethernet network address type.
  - **Ethernet Static IP:** The Fast Ethernet IP address used when not in DHCP mode.
  - **Ethernet Static Subnet:** The Fast Ethernet subnet mask used when not in DHCP mode.
  - **Ethernet IP:** The Fast Ethernet IP address.
  - **Ethernet Subnet:** The Fast Ethernet subnet mask.
  - **Ethernet Broadcast:** The Fast Ethernet broadcast address.
  - **Ethernet MAC:** The Fast Ethernet mac address.
  - **Ethernet MTU:** The current MTU used by the Fast Ethernet port.
  - **Ethernet Pt In:** The number of incoming packets processed by the Fast Ethernet port.
  - **Ethernet By In:** The number of incoming bytes processed by the Fast Ethernet port.
  - **Ethernet Err In:** The number of incoming packets that were found to have an error.
  - **Ethernet Pt Out:** The number of outgoing packets processed by the Fast Ethernet port.
  - **Ethernet By Out:** The number of outgoing bytes processed by the Fast Ethernet port.
  - **Ethernet Err Out:** The number of outgoing packets that were found to have an error.
  - **Ethernet In Rate:** Ethernet In Rate.
  - **Ethernet Out Rate:** Ethernet Out Rate.

- **GbE Table:** A table of Status items for Gigabit Ethernet devices on the processor card.

- **GbE State:** This value indicates whether the GbE port for this row is up (enabled) or down (disabled).
  - **GbE LinkState:** The current link state of the Gigabit Ethernet port.
  - **GbE MTU:** The current MTU used by the Gigabit Ethernet port.
  - **GbE Encap:** The current ARP encapsulation mode used by the Gigabit Ethernet port.
  - **GbE Speed:** The current Link speed of the Gigabit Ethernet port.
  - **GbE Loop:** The current state of the loopback feature of Gigabit Ethernet port. It is either *enabled* or *disabled*. Caution must be used when enabling this, as it forwards all received packets out the transmit line of the active GbE link.
  - **GbE Mode:** The current Link mode of the Gigabit Ethernet port. If both GbE ports are disabled then this object is not settable.
  - **GbE IP Type:** The Gigabit Ethernet network address type.
  - **GbE IP:** The Gigabit Ethernet IP address.
  - **GbE Subnet:** The Gigabit Ethernet subnet mask.
  - **GbE Broadcast:** The Gigabit Ethernet broadcast address.
  - **GbE MAC:** The Gigabit Ethernet mac address.
  - **GbE Commit:** Indicates the state of the values for this row in this table.
  - **GbE ARP Replies:** Control whether or not ARP packets will be blocked at the GbE interface.
  - **GbE ICMP Replies:** Control whether or not ICMP packets will be blocked at the GbE interface.
  - **GbE Gratuitous ARP:** Control whether or not we use Gratuitous ARP mode.
  - **GbE Inband Manage:** Control whether or not we use GbE in-band management.
  - **GbE Inbs:** The number of Megabits (1,000,000 bits) per second currently being received by the Gigabit Ethernet port.
  - **GbE Inps:** The number of packets per second currently being received by the Gigabit Ethernet port.
  - **GbE Pt In:** The number of incoming packets processed by the Gigabit Ethernet port.
  - **GbE By In:** The number of incoming bytes processed by the Gigabit Ethernet port.
  - **GbE In Broadcast:** The number of incoming broadcast packets processed by the Gigabit Ethernet port.
  - **GbE In Unicast:** The number of incoming unicast packets processed by the Gigabit Ethernet port.
  - **GbE In Multicast:** The number of incoming multicast packets processed by the Gigabit Ethernet port.
  - **GbE In Runtime:** The number of runtime packet errors received by the Gigabit Ethernet port.
  - **GbE In Gian:** The number of giant packet errors received by the Gigabit Ethernet port.
  - **GbE In Errors:** The total number of packet errors received on the Gigabit Ethernet port.
  - **GbE In Errors CRC:** The total number of CRC packet errors received on the Gigabit Ethernet port.
  - **GbE In Errors Overflow:** The total number of overflow errors received on the Gigabit Ethernet port.
  - **GbE In Discard:** The total number of discarded packets on the Gigabit Ethernet port.
  - **GbE In Congestion:** The total number of congestion errors on the Gigabit Ethernet port.
  - **GbE In Continuity:** The total number of continuity errors on the GigabitEthernet port.
  - **GbE In Alignment:** The total number of alignment errors on the GigabitEthernet port.
  - **GbE In Miss:** The total number of missed packets on the Gigabit Ethernet port.
  - **GbE In Errors Lost Carrier:** The total number of lost carrier errors on the Gigabit Ethernet port.
  - **GbE In Errors No Carrier:** The total number of no carrier errors on the Gigabit Ethernet port.
  - **GbE Pt Out:** The number of outgoing packets processed by the Gigabit Ethernet port.
  - **GbE By Out:** The number of outgoing bytes processed by the Gigabit Ethernet port.
  - **GbE Out Errors:** The total number of output errors on the Gigabit Ethernet port.
  - **GbE Outbs:** The number of bytes per second currently being transmitted by the Gigabit Ethernet port.
  - **GbE Outps:** The number of packets per second currently being transmitted by the Gigabit Ethernet port.

- **ASI Table:** A table of Asi items for Processor Card Modules within a CableVista I chassis.

- **ASI 1 Status:** The current state of the ASI port. This may be set only if **Input Mode** is set to *ASI Input.* Disabling a port will remove any assigned mappings.
  - **ASI 2 Status:** The current state of the ASI port. This may be set only if **Input Mode** is set to *ASI Input.* Disabling a port will remove any assigned mappings.
  - **ASI 3 Status:** The current state of the ASI port. This may be set only if **Input Mode** is set to *ASI Input.* Disabling a port will remove any assigned mappings.
  - **ASI Output Source Type:** If the system supports ASI output, this must be set to either *ASI* or *OutputChannel*. Otherwise, if the system does not support ASI output, (e.g., nonexistant or unsupported) this can not be *ASI* or *OutputChannel*. If the output is set to *ASI* do not use **Asi Output Slot** or **Asi Output Channel.** **Asi Output Port** will be the ASI input stream used for output. This may be set only if **InputMode** is *ASIInput*.
  - **ASI Output Slot:** If **ASI Output Source Type** is *OutputChannel*, this is the slot of the Marv card which will be used as an input stream. This can be set to a different slot without changing source type, port or channel number. If the **ASI Output Source Type** is *ASI*, *Unset*, or *Unavailable*, this cannot be set and will be 0.
  - **ASI Output Port:** If **ASI Output Source Type** is *OutputChannel*, this is the port of the Marv card in the specified slot which will be used as an input stream. This can be set to a different port without hanging source type, slot or channel number. If **ASI Output Source Type** is *ASI*, this is the ASI port which will be used as an input stream. This can be set to a different port without changing source type. If the ASI output source type is *Unset* or *Unavailable*, this cannot be set and will be 0.
  - **ASI Output Channel:** If **ASI Output Source Type** is *OutputChannel*, this is the channel of the specified port for the Marv card in the specified slot which will be used as an input stream. This can be set to a different slot without changing source type, port or channel number. If the **ASI Output Source Type** is *ASI*, *Unset*, or *Unavailable*, this cannot be set and will be 0.



### Output

This page provides a table of Identity Information items for a CableVista Output Card within a chassis.

Furthermore, each type of card has a Status, Port and Channel pages.

For the Status pages of the three cards you can find a card status table where the **Temperature** information is available, the **Backup State** value can be set and it's possible to **Reboot** the output card affecting all ports and channels on the respective card and on the RF Dual and RF Quad you also set a correction factor to precisely calibrate the actual power output in units of 0.1 dBmV with the parameter **Block Power Offset**. A table with the card alarm state is also available.
Also for the three cards a table of status items for ports/connectors on a baseband output card were you can enable or disable the output and for the RF Dual and RF Quad cards you can set the **Automatic Level Correction**, **Target Power** and **Carrier Wave Mode**.
Finally, every card has a Channel page which holds Video and Audio alarms and a table of status items for channels on an output card port.

### Mapping

View and edit the **Input Map Table** that contains the mappings of InputStreams to output ports.

You can also add two types of mappings: Program bases and PID based configuring the options in **Add Program-based Mapping** or in **Add PID Based Mapping** respectively. Delete mappings is also available.

### Transport Stream

Use this page for the retrieval, creation, and deletion of input streams.

### Program

Use this page to retrieve Program information from Input Streams.

### PID

This page provides information about the input stream PIDs.

### Configuration for Download/Upload

Download and Upload configurations.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
