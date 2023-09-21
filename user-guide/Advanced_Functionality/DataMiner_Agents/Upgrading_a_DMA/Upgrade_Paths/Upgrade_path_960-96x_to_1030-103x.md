---
uid: Upgrade_path_960-96x_to_1030-103x
---
# DataMiner 9.6.x to DataMiner 10.3.0/10.3.x

## Installing .NET and ASP.NET Core

Install the following packages:

- [Microsoft .NET 4.8](https://go.microsoft.com/fwlink/?linkid=2088631)

- [ASP.NET Core 5.0.11](https://download.visualstudio.microsoft.com/download/pr/df452763-4b7d-490a-bc03-bd1003d3ff4c/665ee1786528809f33e791558b69cf51/dotnet-hosting-5.0.11-win.exe)

- [ASP.NET Core 6.0.13](https://download.visualstudio.microsoft.com/download/pr/0cb3c095-c4f4-4d55-929b-3b4888a7b5f1/4156664d6bfcb46b63916a8cd43f8305/dotnet-hosting-6.0.13-win.exe)

> [!IMPORTANT]
> If you do not install these packages before executing the upgrade, the DataMiner installer will install them for you, but this will require a reboot during the upgrade. As this can make following the upgrade process more difficult, we recommend installing these packages in advance.

## NATS ports

Make sure the IP network ports 9090, 4222, 6222, and 8222 (NATS monitoring only) are opened, as explained in [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

> [!TIP]
> See also: [Checking the required open ports in a DMS](xref:MOP_Checking_the_required_open_ports_in_a_DMS)

## Installing the DataMiner upgrade

1. Install [DataMiner 10.0.0 [CU19]](https://community.dataminer.services/download/dataminer-main-release-10-0-0-0-11025-cu19/).

1. Download [VerifyClusterPorts.dmupgrade from DataMiner Dojo](https://community.dataminer.services/download/verifyclusterports-dmupgrade/) and run it.

   > [!IMPORTANT]
   > If you do not run this package before executing the upgrade, the upgrade will fail. This is because DataMiner 10.3 assumes that NAS/NATS services are running, but they are not running in DataMiner 10.0.

1. Install [DataMiner 10.3.0 or 10.3.x](https://community.dataminer.services/dataminer-server-upgrade-packages/).

> [!IMPORTANT]
> If your DMA contains DVE elements when upgrading from DataMiner 9.6.x to DataMiner 10.x or higher, rolling back this upgrade using an upgrade package will cause data loss in the DVE configuration. Therefore, we recommend that you first take a [VM snapshot](xref:Preparing_to_upgrade_a_DataMiner_Agent#vm-snapshot).
