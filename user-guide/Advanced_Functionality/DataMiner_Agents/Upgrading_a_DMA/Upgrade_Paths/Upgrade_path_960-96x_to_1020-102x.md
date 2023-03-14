---
uid: Upgrade_path_960-96x_to_1020-102x
---
# DataMiner 9.6.0/9.6.x to DataMiner 10.2.0/10.2.x

## Prerequisites

### Installing .NET and ASP.NET Core

Install the following packages.

- .NET 4.8, DM (uses installer [ndp48-x86-x64-allos-enu.exe](https://go.microsoft.com/fwlink/?linkid=2088631))
- ASP.NET Core 5.0.11 (uses installer [dotnet-hosting-5.0.11-win.exe](https://download.visualstudio.microsoft.com/download/pr/df452763-4b7d-490a-bc03-bd1003d3ff4c/665ee1786528809f33e791558b69cf51/dotnet-hosting-5.0.11-win.exe))

> [!IMPORTANT]
> If you don’t install these packages before the installation, the DataMiner installer will install them, but will require a reboot during the upgrade.
> This can make following the upgrade process much more difficult. Therefore, our recommendation remains to install these packages in advance.

### NATS ports

Open the ports 9090, 4222, 6222 and 8222 (monitoring only) as per [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).
See also [Checking the required open ports in a DMS](xref:MOP_Checking_the_required_open_ports_in_a_DMS) for verification.

## Upgrade path

DataMiner 9.6.0/9.6.x -> DataMiner 10.0.0 CU19 -> DataMiner 10.2.0/10.2.x

> [!IMPORTANT]
> When moving from 9.6.x to DataMiner 10.x or later and you have DVE elements, rolling back using an upgrade package will cause data-loss in the DVE configuration.
> Therefore, it is recommended to have a VM snapshot at the ready.
