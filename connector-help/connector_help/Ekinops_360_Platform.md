---
uid: Connector_help_Ekinops_360_Platform
---

# Ekinops 360 Platform

This connector monitors an **Ekinops 360 optical transport platform**. The device has up to 32 slots that modules such as the PM1004V can be plugged into.

This connector collects data from the chassis controller and the available PM1004V modules.

## About

This connector polls the general configuration parameters of an Ekinops 360 Platform, as well as data for all supported cards in the system.
For each supported card, a DVE element will be created that contains detailed information about the module.

Currently only the PM1004V module is supported. To have more modules supported, please contact your TAM, or the [Skyline sales team](mailto:sales@skyline.be).

With a timer, the **chassis-specific parameters** are polled and displayed on several pages. With a second timer, a poll cycle is started to poll each of the **PM1004V modules** that are connected **sequentially**. For each PM1440V module, a Dynamic Virtual Element is created.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.36.18.36*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Parent element pages

The following pages are available on the parent element.

#### General Page

On this page, **status information** of the controller is displayed.

This page also contains a **DCF** parameter that can be *Enabled* or *Disabled*. By default, it is disabled. For more information on DCF, refer to the "DCF" section below.

#### Chassis Page

On this page, you can find device information, as well as some network addresses.

#### Trap Configuration Page

On this page, you can enable or disable traps.

#### Chassis Overview Page

On this page, an overview is displayed of **all PM1004V modules** connected to the chassis. For each row in this table, a DVE is created.

When a module is removed from the chassis, the corresponding row will not be deleted automatically. To delete it, use the **Delete Row** button in the row in question.

#### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### DVE Child Element Pages

For each PM1004V module that is plugged into the chassis, a child DVE element is created with the following pages.

#### Client Status Page

On this page, for each client on the module, **general** and **video protocol status** information is displayed.

#### Client Monitoring Page

This page displays a table with the **received bytes**, **CRC error counters, packet counters, broadcast counters** and **multicast counters** for each client on the module. The status of the counters can also be monitored in the same table.

#### Client Configuration

This page displays three tables, which allow **CAIS/CSF configuration, startup configuration** and **Control Access Loop configuration**.

#### Line Status

For both lines, alarms and status information are displayed on this page.

#### Line Monitoring

On this page, measured values for both lines can be found.

In addition, similar to on the "Client Monitoring" page, **received bytes, CRC error counters** and **packet counters** are displayed with the corresponding status info.

#### Line Configuration

On this page, you can configure the two lines.

## DCF

Currently, DCF is only supported for PM1004V cards.

The DCF feature can be disabled on the **General** page using the **DCF** parameter. In this case, all internal connections (managed by the connector) will be removed. When DCF is disabled, the connector will not create connections between the interfaces, but the interfaces themself will still be maintained.

Note that DCF can only be used on a DMA with **8.5.4** as the minimum version. When the installed DataMiner version does not support DCF, the **DCF** parameter will be disabled and it will not be possible to enable it. The connector will generate a warning alarm if this is attempted anyway, or if the DataMiner version is downgraded so that DCF is no longer supported.

Note that DCF can also be implemented through the DataMiner DCF User Interface and through DataMiner third-party connectors (for instance a manager).

### PM1004V

This card has 12 connectors, which corresponds to 12 interfaces.

All internal connections on the card will include interface X1 or X2. Every (internal) connection between two interfaces on this card has the property **Port Name**. The value of this property is the name of the port other than X1 or X2. This could be *ETH, FE, V2, V3, V4* or *V5.* A signal that is input on one of these ports, will be output on the 'same' port on the connected PM1004V card. However, note that for SDI ports, a signal received on the RX connector will be available at the TX connector at the other side.

Below you can find a list of the interfaces and the connections and properties that can originate from each interface.

- **X1**

  This is an optical connector, used to connect two Ekinops 360 Platforms with each other.

  - Is connected to *ETH* name: *./X1-ETH*

    - *@Port* *Name =* *ETH*

  - Is connected to *FE* name: *./X1-FE*

    - *@Port* *Name =* *FE*

  - Is connected to *V2 Tx* name: *./X1-V2Tx*

    - *@Port* *Name = V2*

  - Is connected to *V3 Tx* name: *./X1-V3Tx*

    - *@Port* *Name = V3*

  - Is connected to *V4 Tx* name: *./X1-V4Tx*

    - *@Port* *Name = V4*

  - Is connected to *V5 Tx* name*:* *./X1-V5Tx*

    - *@Port* *Name = V5*

- **X2**

  This is an optical connector, used to connect two Ekinops 360 Platforms with each other.

  - Is connected to *ETH* name: *./X1-ETH*

    - *Port* *Name =* *ETH*

  - Is connected to *FE* name: *./X1-FE*

    - *@Port* *Name =* *FE*

  - Is connected to *V2 Tx* name: *./X1-V2Tx*

    - *@Port* *Name = V2*

  - Is connected to *V3 Tx* name: *./X1-V3Tx*

    - *@Port* *Name = V3*

  - Is connected to *V4 Tx* name: *./X1-V4Tx*

    - *@Port* *Name = V4*

  - Is connected to *V5 Tx* name*:* *./X1-V5Tx*

    - *@Port* *Name = V5*

- **V2 Rx**

  This is an HD SDI input connector.

  - Is connected to *X1* name *./V2Rx-X1*

    - @Port Name = *V2*

  - Is connected to *X2* name *./V2Rx-X2*

    - @Port Name = *V2*

- **V3 Rx**

  This is an HD SDI input connector.

  - Is connected to *X1* name *./V3Rx-X1*

    - @Port Name = *V3*

  - Is connected to *X2* name *./V3Rx-X2*

    - @Port Name = *V3*

- **V4 Rx**

  This is an HD SDI input connector.

  - Is connected to *X1* name *./V4Rx-X1*

    - @Port Name = *V4*

  - Is connected to *X2* name *./V4Rx-X2*

    - @Port Name = *V4*

- **V5 Rx**

  This is an HD SDI input connector.

  - Is connected to *X1* name *./V5Rx-X1*

    - @Port Name = *V5*

  - Is connected to *X2* name *./V5Rx-X2*

    - @Port Name = *V5*

- **V2 Tx**

  This is an HD SDI output connector.

- **V3 Tx**

  This is an HD SDI output connector.

- **V4 Tx**

  This is an HD SDI output connector.

- **V5 Tx**

  This is an HD SDI output connector.

- **ETH**

  This is a standard Ethernet connector (RJ45)

  - Is connected to *X1* name *./ETH-X1*

    - @Port Name = *ETH*

  - Is connected to *X2* name *./ETH-X2*

    - @Port Name = *ETH*

- **FE**

  This is a Fast Ethernet connector.

  - Is connected to *X1* name *./FE-X1*

    - @Port Name = *FE*

  - Is connected to *X2* name *./FE-X2*

    - @Port Name = *FE*
