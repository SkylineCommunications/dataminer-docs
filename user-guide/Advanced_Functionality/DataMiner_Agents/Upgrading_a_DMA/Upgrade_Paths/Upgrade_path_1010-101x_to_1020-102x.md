---
uid: Upgrade_path_1010-101x_to_1020-102x
---
# DataMiner 10.1.0/10.1.x to DataMiner 10.2.0/10.2.x

## Installing .NET and ASP.NET Core

Install the following packages:

- [Microsoft .NET 4.8](https://go.microsoft.com/fwlink/?linkid=2088631)

- [ASP.NET Core 5.0.11](https://download.visualstudio.microsoft.com/download/pr/df452763-4b7d-490a-bc03-bd1003d3ff4c/665ee1786528809f33e791558b69cf51/dotnet-hosting-5.0.11-win.exe)

> [!IMPORTANT]
> If you do not install these packages before executing the upgrade, the DataMiner installer will install them for you, but this will require a reboot during the upgrade. As this can make following the upgrade process more difficult, we recommend installing these packages in advance.

## NATS ports

Make sure the IP network ports 9090, 4222, 6222, and 8222 (NATS monitoring only) are opened, as explained in [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

> [!TIP]
> See also: [Checking the required open ports in a DMS](xref:MOP_Checking_the_required_open_ports_in_a_DMS)

## Installing the DataMiner upgrade

Install the DataMiner [DataMiner 10.2.0 or 10.2.x](https://community.dataminer.services/dataminer-server-upgrade-packages/) upgrade package.
