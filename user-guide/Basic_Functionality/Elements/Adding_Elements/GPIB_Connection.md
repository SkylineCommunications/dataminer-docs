---
uid: GPIB_Connection
---

# GPIB connections

For General Purpose Interface Bus (GPIB) connections, you need to specify the connection settings of the GPIB/LAN gateway through which DataMiner will communicate with GPIB-enabled devices, such as a spectrum analyzer and measurement equipment.

![GPIB](~/user-guide/images/GPIB.svg)

DataMiner supports both the SICL API and the VISA API. Depending on whether version M.01.01.04 or version 17.1.20011 of the IO libraries is used, the connection settings should be configured differently.

> [!NOTE]
> On a DMA that has to communicate through a GPIB/LAN gateway, you have to [install and configure the Agilent IO Libraries](xref:Installing_the_Keysight_Agilent_IO_Libraries#installing-the-keysightagilent-io-libraries).

## Using version M.01.01.04 of the IO libraries and SICL communication

Specify the following connection settings:

- **I/O API**: SICL

- **Device address**: gpib0,10

  "gpib0" is the *Remote SICL Interface Name*, and "10" is the GPIB bus address as set on the device (range: 0-30). Default device address: “gpib0”.

  > [!NOTE]
  > If multiple GPIB interfaces or multiple network interfaces are being used, the device address has to be specified as follows: "lan\[machineName\]:gpib0,1".
  >
  > "lan" is the "SICL Interface name" in the IO configuration, and "machineName" is the IP address of the network GPIB interface.

  ![GPIB Connection](~/user-guide/images/GPIB_Connection.png)

## Using version M.01.01.04 of the IO libraries and VISA communication

1. In the IO configuration app, create a new *VISA LAN Client* interface, and enter the IP address of the GPIB interface.

1. Specify the following connection settings:

   - **I/O API**: SICL

   - **Device address**: GPIB10::10::INSTR

     "GPIB10" is the *Visa Interface Name*, "10" is the GPIB bus address as set on the device, and "INSTR" is a fixed string.

## Using version 17.1.20011 of the IO libraries

Specify the following connection settings:

- **I/O API**: Select *SICL* or *VISA*, as appropriate.

- **Device address**: Set to the appropriate VISA or SICL address, which can be found by running *Keysight Connection Expert* and checking the *Instruments* list.

  > [!TIP]
  > See also: [Installing the IO Libraries](xref:Installing_the_Keysight_Agilent_IO_Libraries#installing-the-io-libraries)
