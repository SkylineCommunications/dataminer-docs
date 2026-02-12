---
uid: Preparing_to_upgrade_a_DataMiner_Agent
description: To ensure a successful DataMiner upgrade, first check for known issues and breaking changes, upload the package, and create a backup.
---

# Preparing to upgrade a DataMiner Agent

This section of the documentation contains detailed information on how to prepare to upgrade a DataMiner Agent. To ensure a successful upgrade of your DMA, we strongly recommend that you read through the content of this page.

## Best practices

### Check for known issues and breaking changes

From time to time, issues are detected that might impact a DataMiner System if a particular DataMiner version is installed. Before you upgrade, we therefore recommend that you first check the [Known issues page](xref:Known_issues) to identify if your system might be affected by such an issue.

Make sure you also check the [Breaking changes page](xref:Breaking_changes) to see if any breaking changes will affect your system when you upgrade.

### Upload upgrade packages before an upgrade

We highly recommend that you upload the upgrade package before the actual maintenance window, as this is low risk and does not require a restart of your system, but it will indicate whether all conditions and requirements to upgrade your DataMiner Agent are met, vastly reducing the chance of problems occurring during the eventual upgrade.

To upload an upgrade package:

1. Open DataMiner Cube.

1. Follow the upgrade procedure described in [Upgrading a DataMiner Agent in System Center](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

1. During the final step of the upgrade procedure, instead of clicking *Upgrade*, select *Upload only*.

   ![Upload only](~/dataminer/images/Upload_Only.png)

1. If the upload was successful, you should receive the following upload report:

   ```txt
   Upload report
   Upload has been completed successfully.
   ```

> [!NOTE]
> When you upload a package, several [prerequisite checks](#prerequisite-checks) will be executed, so that you will immediately get informed if certain conditions or requirements for the update are not met yet.

> [!TIP]
> We recommend that you upload the package a few days before you execute the upgrade. This will allow you extra time to perform corrective actions in case any of the prerequisite checks fail.

### Have a backup at the ready

We recommend making a backup of your DataMiner System before executing an upgrade, in case unexpected issues should occur.

Making a backup can be done with a VM snapshot or DataMiner.

#### VM snapshot

[Take a virtual machine (VM) snapshot](xref:MOP_Downgrading_a_DMS#for-a-downgrade-with-vm-snapshot-restore) of the upgraded machines shortly before the update. This will allow a speedy rollback of the DataMiner System.

> [!TIP]
> For more information on how to downgrade your DMS using a VM snapshot restore, see [Downgrade with VM snapshot restore](xref:MOP_Downgrading_a_DMS#downgrade-with-vm-snapshot-restore-preferred).

> [!NOTE]
> The timing for a VM snapshot restore depends on your specific setup.

#### DataMiner backup

Make a backup of your DataMiner Agent using DataMiner Taskbar Utility or DataMiner Cube, as explained in [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent). This will allow a speedy rollback of the DataMiner System by installing the upgrade package of the previous DataMiner version.

### Best practices when upgrading across major versions

If you are upgrading to another major version that does not immediately follow your current version, always follow this general guideline:

**Upgrade to the latest Cumulative Update (CU) of the next major DataMiner version(s) before upgrading to your preferred version**.

![Upgrading across major versions](~/dataminer/images/Upgrading_across_major_versions.png)

This does not apply for upgrades within the same major version. For example, to upgrade from 10.4.0 CU6 to 10.4.0 CU8, it is not necessary to install CU7 first.

Also, please take into account that the following **exceptions** apply:

- If you are on the Feature Release track and want to **switch to a DataMiner version on the Main Release track**, skip the Main Release version that matches your current feature release version. For example, if you have DataMiner 10.4.12 installed, you can upgrade directly to DataMiner 10.5.0, or you can upgrade from DataMiner 10.4.12 to any 10.5.x version and then to 10.6.0. See [DataMiner Main Release vs. Feature Release](xref:DataMiner_MR_vs_FR).
- Upgrading to **DataMiner 10.6.0/10.6.1** or higher requires a [**BrokerGateway migration**](xref:BrokerGateway_Migration), which can only be done from 10.5.0 [CU2]/10.5.5 onwards. This means that an upgrade to 10.5.0 [CU2]/10.5.5 or higher cannot be skipped while upgrading to 10.6.0/10.6.1 or higher.
- If you are upgrading **from a version prior to DataMiner 10.1.x** to 10.2.x or higher, **skip DataMiner 10.1** and proceed directly to the subsequent major version instead (i.e. DataMiner 10.2).
- If you are upgrading **from DataMiner 9.6.0/9.6.x or a DataMiner 10.0.0 Main Release** version prior to DataMiner 10.0.0 [CU19], upgrade to [**DataMiner 10.0.0 [CU19]**](https://community.dataminer.services/download/dataminer-main-release-10-0-0-0-11025-cu19/) as the next major version.

> [!TIP]
> See [Example upgrade path](#example-upgrade-path).

#### Upgrade prerequisites

If you are about to upgrade across major versions, before proceeding with the upgrade, **ensure the following requirements are met**:

- Depending on the target DataMiner version, make sure the corresponding **Microsoft .NET and ASP.NET Core** packages are installed:

  | DataMiner version | Microsoft .NET | ASP.NET Core |
  |--|--|--|
  | DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 and higher | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) | [ASP.NET Core 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.1-windows-hosting-bundle-installer) |
  |DataMiner 10.3.0 [CU12] to 10.3.0 [CU18]<br/>DataMiner 10.4.0 to 10.4.0 [CU6]<br/>DataMiner 10.4.3 to 10.4.9| [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) | [ASP.NET Core 6.0.13](https://download.visualstudio.microsoft.com/download/pr/0cb3c095-c4f4-4d55-929b-3b4888a7b5f1/4156664d6bfcb46b63916a8cd43f8305/dotnet-hosting-6.0.13-win.exe)<br/>[ASP.NET Core 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.1-windows-hosting-bundle-installer) |
  | DataMiner 10.3.9/10.4.1/10.4.2 | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) | [ASP.NET Core 6.0.13](https://download.visualstudio.microsoft.com/download/pr/0cb3c095-c4f4-4d55-929b-3b4888a7b5f1/4156664d6bfcb46b63916a8cd43f8305/dotnet-hosting-6.0.13-win.exe) |
  | DataMiner 10.3.0 Main Release versions from 10.3.0 [CU3] onwards<br/>DataMiner 10.3.3 to 10.3.8 | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) | [ASP.NET Core 5.0.11](https://download.visualstudio.microsoft.com/download/pr/df452763-4b7d-490a-bc03-bd1003d3ff4c/665ee1786528809f33e791558b69cf51/dotnet-hosting-5.0.11-win.exe)<br/>[ASP.NET Core 6.0.13](https://download.visualstudio.microsoft.com/download/pr/0cb3c095-c4f4-4d55-929b-3b4888a7b5f1/4156664d6bfcb46b63916a8cd43f8305/dotnet-hosting-6.0.13-win.exe) |
  | DataMiner 10.3.0 [CU0] up to [CU2]<br/>DataMiner 10.2.0/10.2.x | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) | [ASP.NET Core 5.0.11](https://download.visualstudio.microsoft.com/download/pr/df452763-4b7d-490a-bc03-bd1003d3ff4c/665ee1786528809f33e791558b69cf51/dotnet-hosting-5.0.11-win.exe) |

- Depending on the target DataMiner version, make sure the corresponding minimum version of the **Microsoft Visual C++ x86/x64 redistributables** is installed.

  If you do not install this before the upgrade, it will be installed as part of the DataMiner upgrade when necessary, but this may trigger an automatic **reboot** of the DMA to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

  | DataMiner version | Microsoft VC++ |
  |--|--|
  | DataMiner 10.5.0 [CU11]/10.6.0 [CU1]/10.6.3 and higher<!-- RN 44249 --> | 14.44.35211.0 |
  | DataMiner 10.5.0 [CU0]/10.5.2 and higher<!-- RN 41173+41609 --> | 14.40.33816 |

- Make sure the IP network **ports 9090, 4222, 6222, and 8222** (NATS monitoring only) are opened, as explained in [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

  > [!TIP]
  > See also: [Checking the required open ports in a DMS](xref:MOP_Checking_the_required_open_ports_in_a_DMS)

- If you are upgrading from DataMiner 10.0.0/10.0.x to DataMiner 10.2.0/10.2.x, download [VerifyClusterPorts.dmupgrade from DataMiner Dojo](https://community.dataminer.services/download/verifyclusterports-dmupgrade/) and run it before installing DataMiner 10.2.0/10.2.x.

  > [!IMPORTANT]
  > If you do not run this package before executing the upgrade, the upgrade will fail. This is because DataMiner 10.3 assumes that NAS/NATS services are running, but they are not running in DataMiner 10.0.

#### Example upgrade path

To upgrade from DataMiner 9.6.0 to DataMiner 10.3.0:

1. Install Microsoft .NET 4.8, ASP.NET Core 5.0.11, and ASP.NET Core 6.0.13.

1. Open IP network ports 9090, 4222, 6222, and 8222 (NATS monitoring only).

1. Install DataMiner 10.0.0 [CU19].

1. Download VerifyClusterPorts.dmupgrade and run it.

1. Install DataMiner 10.2.0.

1. Install DataMiner 10.3.0.

## Prerequisite checks

When you upload a DataMiner upgrade, several prerequisite checks are automatically executed. These will verify whether all the necessary conditions for upgrading DataMiner to the selected version and all requirements for the DataMiner Agent to run are met. If the prerequisite checks detect that this is not the case, the upgrade will be canceled.

> [!IMPORTANT]
> We recommend running the prerequisite checks well in advance of the actual upgrade activity, so that you have time to carry out any actions that are required as reported by the checks.

The following prerequisite checks are currently available:

- [Verify BrokerGateway Migration](xref:VerifyBrokerGatewayMigration): Verifies whether the DataMiner System has migrated from the SLNet-managed NATS solution to the BrokerGateway-managed NATS solution. From DataMiner 10.6.0/10.6.1 onwards<!--RN 43861 -->, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify Cloud DxM Version](xref:BPA_Verify_Cloud_DxM_Version): Verifies whether the minimum required version is installed for all DxMs in the system. From DataMiner 10.2.0 [CU6]/10.2.8 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- Verify Cluster Ports: Verifies whether the ports used by DataMiner can be reached in between DataMiner Agents. If this check fails, you will need to install the [VerifyClusterPorts.dmupgrade](xref:VerifyClusterPortsdmupgrade) package. From DataMiner 10.2.0 [CU2]/10.2.5 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify .NET Version](xref:Verify_ASP_Net_Version): Verifies whether the Microsoft ASP.NET 8.0 Hosting Bundle is installed. From DataMiner 10.3.0 [CU12]/10.4.0/10.4.3 onwards<!--RN 37969-->, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify Elastic Storage Type](xref:Verify_Elastic_Storage_Type): Verifies whether the system has successfully switched to an [indexing database](xref:Indexing_Database). From DataMiner 10.4.0/10.4.1 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify gRPC Connection](xref:VerifyGRPCConnectiondmupgrade): Verifies whether all DataMiner Agents in the cluster can communicate via gRPC over HTTPS port 443 and none of the Agents currently have a non-default network configuration.

- [Verify NATS Cluster](xref:VerifyNatsCluster): Verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents. From DataMiner 10.5.0 [CU3]/10.5.6 onwards<!-- RN 42206 -->, this prerequisite is available by default and runs automatically when you upgrade. Prior to this, starting from DataMiner 10.2.0 [CU14]/10.2.7, the [Verify NATS is Running](xref:VerifyNatsIsRunning) check is used instead.

- [Verify No Amazon Keyspaces](xref:Verify_No_Amazon_Keyspaces): Verifies whether the DataMiner Agent is using the Amazon Keyspaces Service on AWS as a Cassandra-compatible database service, which is no longer supported as of DataMiner 10.3.0 [CU8]/10.3.11. From DataMiner 10.5.0/10.5.3 onwards<!--RN 41914-->, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify No Annotations](xref:Verify_No_Annotations): Verifies whether the soft-launch option [LegacyAnnotations](xref:Overview_of_Soft_Launch_Options#legacyannotations) is enabled. As the legacy Annotations module is no longer supported from DataMiner 10.6.0/10.6.1 onwards, upgrading to those DataMiner versions or higher is not possible when this option is enabled.<!-- 44124 -->

- [Verify No Legacy Correlation](xref:VerifyNoLegacyCorrelation): Scans the DataMiner System for any legacy correlation rules. From DataMiner 10.5.1/10.6.0 onwards<!--RN 40834-->, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify No Legacy Reports Dashboards](xref:Verify_No_Legacy_Reports_Dashboards): Scans the DataMiner System for any legacy reports and legacy dashboards. From DataMiner 10.4.0/10.4.1 onwards<!--RN 37922-->, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify No Obsolete API Deployed](xref:Verify_No_Obsolete_API_Deployed): Verifies whether the obsolete *APIDeployment* [soft-launch option](xref:SoftLaunchOptions) is enabled and obsolete APIs are deployed. From DataMiner 10.4.0 onwards<!--RN 37825-->, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify OS Version](xref:Verify_OS_Version): Verifies whether the DataMiner version in the upgrade package supports the version of the operating system that is installed on the DataMiner Agent. From DataMiner 10.5.12/10.6.0 onwards<!--RN 43356-->, this prerequisite is available by default and runs automatically when you upgrade.

- [Service Automatic Properties](xref:BPA_Service_Automatic_Properties): Verifies whether the installed SRM framework version is up to date. From DataMiner 10.2.3/10.3.0 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Validate Connectors](xref:BPA_Validate_Connectors): Scans the DataMiner System for any connectors that are known to be incompatible with the DataMiner version to which the DataMiner Agent is being upgraded. From DataMiner 10.3.4/10.4.0 onwards, this prerequisite is available by default and runs automatically when you upgrade.

> [!NOTE]
> Though this is not recommended, you can bypass these checks by manually removing the *Prerequisites* folder from *Update.zip* in the upgrade package. However, you should only do so if there is a clear reason to assume that the prerequisites do not work because of a bug in the software and they are consequently failing without a proper reason. If you bypass these checks in any other circumstances, and this results in a DataMiner issue, this is **not covered by support**.
