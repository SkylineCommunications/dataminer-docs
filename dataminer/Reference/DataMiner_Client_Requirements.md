---
uid: DataMiner_Client_Requirements
description: To run the DataMiner Cube client application, a recent Windows OS is required, on a system with sufficient CPU and (graphics) memory.
---

# DataMiner Client Requirements

## Hardware

Recommended DataMiner client configuration:

- Processor: Min. 4 physical cores and 5000+ PassMark CPU benchmark

- Memory: 8–16 GB DDR4 RAM

- Graphics memory: 512 MB

## Software

### Operating system

- Microsoft Windows 10

- Microsoft Windows 11

- Windows Server 2016

- Windows Server 2019

- Windows Server 2022

- Windows Server 2025

### Microsoft .NET Framework

Microsoft .NET Framework 4.7.2

> [!IMPORTANT]
> We recommend always upgrading to the latest .NET Framework version.

### Microsoft WebView2

From DataMiner Cube 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43429-->, WebView2 must be installed. In earlier DataMiner versions, it is possible to use Chromium instead.

WebView2 is available for all [supported operating systems](#operating-system). The most recent versions of Windows all come with WebView2 Runtime pre-installed. However, for less recent versions of Windows, you may need to [install WebView2 Runtime manually](https://developer.microsoft.com/en-us/microsoft-edge/webview2/consumer/).

> [!NOTE]
> Make sure to run the WebView2 Runtime installer **as administrator**. After the installation, a **reboot** may be needed before WebView2 can be used.

### Skyline certificates

To install the Skyline certificates:

1. Depending on your setup, go to either of the following URLs, replacing [DMA] with the IP address or name of the DataMiner Agent:

   - http://[DMA]/tools

   - https://[DMA]/tools

1. Under *DataMiner Tools*, click *Register Skyline Certificates*, and then click *Run*.

> [!NOTE]
>
> - From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41844-->, this tool is no longer available.
> - Running this tool is an optional security precaution.
> - The tool will try to install the certificates for all users of the computer. If this is not possible because of insufficient rights, it will try to install the certificates for the current user only.
> - When the installation is complete, a message "Certificates have been installed (current user)" or "Certificates have been installed (all users)" will be displayed.
> - This tool (SLRegCerts.exe) also supports a "/silent" option that suppresses any message box output, so that it can be used in automatic installations.

### Optional software

**Microsoft Visio (Standard or Professional, version 2013 or later)**:

Optional software, only to be installed for users who will be creating or adapting Microsoft Visio drawings.
