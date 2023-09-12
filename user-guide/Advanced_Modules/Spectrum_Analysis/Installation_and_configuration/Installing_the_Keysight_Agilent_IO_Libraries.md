---
uid: Installing_the_Keysight_Agilent_IO_Libraries
---

# Installing the Keysight/Agilent IO Libraries

On a DataMiner Agent that has to communicate through a GPIB/LAN gateway, you have to install and configure the Keysight IO Libraries (known as Agilent up till 2014).

> [!NOTE]
> After installing the IO Libraries or after changing the IO configuration, restart the DMA software.

> [!NOTE]
> Both the Keysight Agilent IO Libraries and the NATS module within DataMiner use IP port 9090. This can result in NATS issues and prevent DataMiner from starting. To fix this, see [Investigating NATS issues](xref:Investigating_NATS_Issues#check-if-port-is-already-in-use). This procedure must be followed for every DMA running DataMiner 10.1.0/10.1.1 or higher.

## Installing the IO Libraries

The minimum version for the IO libraries is 17.1.20011.

> [!NOTE]
> Although you can continue to use the IO Libraries version M.01.01.04, upgrading to version 17.1.20011 or higher is recommended. However, if you still have the M.01.01.04 version of the IO libraries installed, this will first need to be removed before you can install version 17.1.20011 or higher:
>
> - Go to *C:\\Program Files (x86)\\InstallShield Installation Information\\{04107B50-CCF1-11D3-931C-00108301D203}\\* <br>(which is typically a hidden folder).
> - In the file properties of *Setup.exe*, indicate that you want the file to run in *Windows XP compatibility mode*.
> - Run *Setup.exe*. This should remove the existing IO libraries, IVI shared components, and VISA shared components. Go to *Programs and features* if you want to check whether all those items were removed.

- You can download the most recent version of the IO libraries from the following website:<br><http://www.keysight.com/main/software.jspx?ckey=2175637&lc=dut&cc=BE&nid=-33330.977662&id=2175637&pageMode=PV>

- After installing the IO libraries, run *Keysight Connection Expert*, either from the right-click menu of the IO libraries taskbar icon or from the Windows start menu.

  - Go to *Manual Configuration \> Edit Existing Instruments/Interfaces*. In the list, there should be an automatically created interface named “Lan Interface TCPIP0”.

  - Go to *Manual Configuration \> Add New Instruments/Interfaces*, click *Remote GPIB interface*, and change the default settings if necessary. The IP address is mandatory.

  - Go to *Instruments*, and click *Rescan*. All instruments connected to the interface should start to appear.

  - In the *Instruments* list, you can find the VISA addresses and SICL addresses of each device. These are the addresses to be used when you specify a device address in DataMiner.

  - If you want to set up VISA aliases, go to *Settings \> Aliases*. In DataMiner, these aliases can also be used as device address (VISA only).

> [!TIP]
> See also: [GPIB connections](xref:GPIB_Connection)

## Configuring the IO interfaces

> [!NOTE]
> You need system administrator privileges to run **IO Config**.

1. Right-click the blue IO icon in the Windows system tray, and select *Run IO Config*.

1. In the *Available Interface Types* list on the left, select “\*LAN Client (LAN Instruments)”, and click *Configure*.

   *SICL Interface Name* contains the unique name of the LAN Client. The name of each LAN Client starts with the word “lan”, optionally followed by a number from 0 to 99. Note that you will have to enter this interface name when configuring a Spectrum Analyzer Element on the DataMiner Agent. See [GPIB connections](xref:GPIB_Connection).

1. In the *Default Protocol* box, specify the default protocol.

   - Select “SICL-LAN” if the GPIB/LAN gateway uses the SICL-LAN protocol.

   - Select “VXI-11 (TCP/IP Instrument Protocol)” if the GPIB/LAN gateway uses the TCP/IP Instrument protocol.

   - Select “Auto” if you want the LAN Client to automatically detect the protocol being used.

1. Click *OK* to save the configuration.
