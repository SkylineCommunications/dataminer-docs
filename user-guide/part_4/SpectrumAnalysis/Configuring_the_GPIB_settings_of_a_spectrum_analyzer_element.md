## Configuring the GPIB settings of a spectrum analyzer element

When adding or updating a spectrum analyzer element, at some point during element creation, you can specify the settings of the GPIB/LAN gateway through which DataMiner will communicate with the spectrum analyzer.

> [!NOTE]
> -  On a DataMiner Agent that has to communicate through a GPIB/LAN gateway, you have to install and configure the Agilent IO Libraries. See [Installing the Keysight/Agilent IO Libraries](Installing_the_Keysight_Agilent_IO_Libraries.md#installing-the-keysightagilent-io-libraries).
> -  From DataMiner 9.0.0 onwards, these settings are configured in a different way than in legacy versions of DataMiner.

> [!TIP]
> See also:
> [Adding and deleting elements](../../part_2/elements/Adding_and_deleting_elements.md) 

#### Using DataMiner version 9.0.0 and higher

From DataMiner 9.0.0 onwards, DataMiner supports both the SICL API and the VISA API. Depending on whether version M.01.01.04 or version 17.1.20011 of the IO libraries is used, the settings during element creation should be configured in a different way.

##### Using version M.01.01.04 of the IO libraries, and SICL communication:

- During element creation, set the *Device address* to “*gpib0,10*”.

    “*gpbib0*” is the *Remote SICL Interface Name*, and *10* is the GPIB bus address as set on the device (range: 0-30). Default device address: “gpib0”.

    > [!NOTE]
    > If multiple GPIB interfaces or multiple network interfaces are being used, the device address has to be specified as follows: “*lan\[machineName\]:gpib0,1*”.<br>“*lan*” is the “SICL Interface name” in the IO configuration, and “*machineName*” is the IP address of the network GPIB interface.

- In the *I/O API* field, select *SICL*.

##### Using version M.01.01.04 of the IO libraries, and VISA communication:

- In the IO configuration app, create a new *VISA LAN Client* interface, and enter the IP address of the GPIB interface.

- During element creation, set the *Device address* to “*GPIB10::10::INSTR*”.

    “*GPIB10*” is the *Visa Interface Name*, *10* is the GPIB bus address as set on the device, and “*INSTR*” is a fixed string.

- In the *I/O API* field, select *SICL*.

##### Using version 17.1.20011 of the IO libraries:

- During element creation, set the *Device address* to the appropriate VISA or SICL address, which can be found by running *Keysight Connection Expert *and checking the *Instruments* list.

    > [!TIP]
    > See also:
    > [Installing the IO Libraries](Installing_the_Keysight_Agilent_IO_Libraries.md#installing-the-io-libraries)

- Set the *I/O API* field, select *SICL *or* VISA*, as appropriate.

#### Using legacy DataMiner versions

Up to DataMiner 8.5, the following settings are available:

- **Gateway IP Address**: The IP address of the GPIB Gateway.

    > [!NOTE]
    > You should be able to “ping” this IP address from the DataMiner Agent that manages the element.

- **LAN Client Interface Name**: The interface name of the LAN client configured in the IO Libraries.

    > [!NOTE]
    > To retrieve this name, in the Windows system tray, right-click the blue IO icon. Then select *run IO Config* and double-click the interface used by the element. At the top of the page, you can find the “Interface Name”.

- **GPIB SICL Interface Name**: The symbolic name of the GPIB interface in the GPIB/LAN gateway.

    > [!NOTE]
    > To retrieve this name, in Internet Explorer, go to the URL of the GPIB/LAN gateway (or connect to the gateway via a telnet session):
    > - If the GPIB/LAN gateway uses the TCP/IP Instrument Protocol, the SICL Interface Name will be *gpib*. - If the GPIB/LAN gateway uses the SICL/LAN Protocol, the SICL Interface Name will be *hpib*, *hpib\[n\]* or *gpib\[n\]*.

- **Device Address**: The IP address of the spectrum analyzer.
