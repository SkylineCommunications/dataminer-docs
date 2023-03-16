---
uid: Upgrade_path_960-96x_to_1020-102x
---
# DataMiner 9.6.0/9.6.x to DataMiner 10.2.0/10.2.x

## Installing .NET and ASP.NET Core

Install the following packages:

- [Microsoft .NET 4.8](https://go.microsoft.com/fwlink/?linkid=2088631)

- [ASP.NET Core 5.0.11](https://download.visualstudio.microsoft.com/download/pr/df452763-4b7d-490a-bc03-bd1003d3ff4c/665ee1786528809f33e791558b69cf51/dotnet-hosting-5.0.11-win.exe)

> [!IMPORTANT]
> If you do not install these packages before executing the upgrade, the DataMiner installer will install them for you, but this will require a reboot during the upgrade. As this can make following the upgrade process more difficult, we recommend to install these packages in advance.

## NATS ports

Make sure the IP network ports 9090, 4222, 6222, and 8222 (NATS monitoring only) are opened, as explained in [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

> [!TIP]
> See also: [Checking the required open ports in a DMS](xref:MOP_Checking_the_required_open_ports_in_a_DMS)

## Upgrade path

Never directly upgrade to a major DataMiner version that is several versions higher than the current version. To prevent issues and make it easier to find the root cause if anything goes wrong after an upgrade, we highly recommend that you follow this upgrade path:

DataMiner 9.6.0/9.6.x -> DataMiner 10.0.0 [CU19] -> DataMiner 10.2.0/10.2.x

> [!IMPORTANT]
> If your DMA contains DVE elements when upgrading from DataMiner 9.6.x to DataMiner 10.x or higher, rolling back this upgrade using an upgrade package will cause data loss in the DVE configuration. Therefore, we recommend you to first take a [VM snapshot](xref:Preparing_to_upgrade_a_DataMiner_Agent#vm-snapshot).
