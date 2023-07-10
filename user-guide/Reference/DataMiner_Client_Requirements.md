---
uid: DataMiner_Client_Requirements
---

# DataMiner Client Requirements

## Hardware

Recommended DataMiner client configuration:

- Processor: Min. 4 physical cores and 5000+ PassMark CPU benchmark

- Memory: 8–16 GB DDR4 RAM

- Graphics memory: 512 MB

## Software

### Operating system

- Microsoft Windows 8

- Microsoft Windows 10

- Microsoft Windows 11

- Windows Server 2012

- Windows Server 2016

- Windows Server 2019

- Windows Server 2022

### Microsoft .NET Framework

Microsoft .NET Framework 4.6.2

> [!IMPORTANT]
> We recommend always upgrading to the latest .NET Framework version.

> [!NOTE]
> When you connect to DataMiner using HTTPS, TLS 1.0 is required to install Cube. It is also possible to use TLS 1.1 or TLS 1.2, but in that case Microsoft .NET Framework 4.6.2 is required.

### Skyline certificates

To install the Skyline certificates:

1. Depending on your setup, go to either of the following URLs, replacing [DMA] with the IP address or name of the DataMiner Agent:

   - http://[DMA]/tools

   - https://[DMA]/tools

1. Under *DataMiner Tools*, click *Register Skyline Certificates*, and then click *Run*.

> [!IMPORTANT]
> As a security precaution, **running *SLRegCerts.exe* is optional** unless you specifically require offline functionality on Windows Server 2012 R2 servers or Windows 8 clients without internet connectivity.

> [!NOTE]
>
> - The tool will try to install the certificates for all users of the computer. If this is not possible because of insufficient rights, it will try to install the certificates for the current user only.
> - When the installation is complete, a message "Certificates have been installed (current user)" or "Certificates have been installed (all users)" will be displayed.
> - This tool (SLRegCerts.exe) also supports a "/silent" option that suppresses any message box output, so that it can be used in automatic installations.

### Web browser

If DataMiner Cube will be run as a web application instead of a desktop application, you will need one of the following browsers:

- Microsoft Internet Explorer (v9.0 or above)

- Microsoft Edge (using IE compatibility mode)

> [!TIP]
> For more information, see [Internet Explorer Support](https://community.dataminer.services/documentation/internet-explorer-support/).

### Optional software

**Microsoft Visio (Standard or Professional, version 2013 or later)**:

Optional software, only to be installed for users who will be creating or adapting Microsoft Visio drawings.
