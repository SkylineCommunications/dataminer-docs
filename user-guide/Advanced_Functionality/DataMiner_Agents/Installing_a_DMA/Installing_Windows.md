---
uid: Installing_Windows
---

# Installing Windows

Below, you can find information concerning the installation of the Windows operating system.

If Windows has already been installed on the machine you are preparing, you can skip this entire "Installing Windows" section.

## Supported Windows versions

A DataMiner Agent can be hosted on machines running the following operating systems.

- Windows 8
- Windows 10
- Windows 2012 Server
- Windows 2016 Server
- Windows 2019 Server

> [!NOTE]
> Whatever operating system you use, make sure you have installed the latest service pack.

## Important remarks

- If the computer has RAID controller hardware, depending on the type of hardware, you may need to install Windows on one HD first. Then, after the installation is
completed, you can insert the second HD and let it rebuild. Check the documentation of the raid controller if you are not sure about this.

- If the DMA is configured to use the SATA RAID, the BIOS should be set as follows:
 
    1. Enter the BIOS (e.g. by pressing *DELETE*).
    1. Go to *Advanced > Onboard device > SATA configuration*.
    1. Do the following:
    
        - Set **Onchip Serial SATA** to "ENHANCED MODE".
        - Set **SATA mode** to "RAID".

- If you are installing a COMPAQ computer, you must first boot it with the "SMARTSTART FOR SERVERS" CD. This will prepare the computer for a Windows installation.
Follow the wizard and choose the correct OS. If it is not available in the list, choose OTHER OS. The installation of Windows may fail during setup if you do not prepare the computer using the above-mentioned CD.

- After installing Microsoft Windows make sure to log on with the Administrator account before you continue. Do not use a regular user account with administrative rights.

## Installation

1. Insert the Windows installation CD and restart the computer. If the computer does not boot from the CD, then check the boot sequence in the BIOS settings.

1. Follow the Windows installation procedure. The HD must be formatted using the NTFS file system.

    > [!NOTE]
    > It is recommended to create only one partition because the DataMiner software only needs one. If there is a second physical HD available, it can be used:
    >
    > - for backup, in case the first HD fails, or
    > - to host the database, in order to spread the load onto 2 physical HDs.

    In the installation wizard, the following settings are possible. These can be set differently according to preference:

    - Regional settings: English US (default)
    - Name: DataMiner
    - Organization: Skyline Communications
    - Computer Name: DataMiner-1
    - Time Zone: Brussels
    - Default: Typical TCP/IP Settings
    - Workgroup: SKYLINE

1. Activate Windows.

> [!NOTE]
> After installing Microsoft Windows:
> - Make sure to log on with the Administrator account before you continue. Do not use a regular user account with administrative rights.
> - Make sure the Windows setting *fast startup* is not activated.

## Installing the Windows device drivers

It is important that all drivers are installed and that nothing in the Device Manager is marked with an exclamation icon.

- If a driver CD is available, insert it and install all the necessary drivers. There is no need to install additional applications that are not really necessary,
as this will only slow down the start-up time and consume precious resources.

After installing the necessary drivers, you might need to install some additional drivers for hardware like multiport IO cards. Check the Device Manager:

1. Go to *Start > Control Panel > System*, go to the *Hardware* tab if necessary, and click *Device Manager*.
1. If you notice any items marked with an exclamation icon, proceed to step 3. Otherwise, close the Device Manager.
1. Right-click an item marked with an exclamation icon, and select *Properties*. Then choose to reinstall the driver.
1. Select *Search for a suitable driver for my device (recommended)*, and click *Next*.
1. Insert the CD containing the driver for the device in question, and click *Next*.
1. Finish the wizard.
1. Repeat steps 3 to 6 for all other items marked with an exclamation icon.

> [!NOTE]
> The driver for the PCI serial port can be found on the MOXA CD:
> - DRIVERS\WIN...\SMARTIO\MXSER.INF
> When this driver is installed, the Found New Hardware wizard will start. Follow the wizard and let it search for the suitable driver on the MOXA CD:
> - DRIVERS\WIN...\SMARTIO\MXSPORT.INF
