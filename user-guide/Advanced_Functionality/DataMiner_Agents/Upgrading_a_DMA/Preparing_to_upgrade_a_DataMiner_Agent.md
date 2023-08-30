---
uid: Preparing_to_upgrade_a_DataMiner_Agent
---

# Preparing to upgrade a DataMiner Agent

This section of the documentation contains detailed information on how to best prepare to upgrade a DataMiner Agent. To ensure a successful upgrade of your DMA, we strongly recommend that you read through the content of this page.

## Uploading upgrade packages before an upgrade

We highly recommend that you upload the upgrade package before the actual maintenance window, as this is low risk and does not require a restart of your system, but it will indicate whether all conditions and requirements to upgrade your DataMiner Agent are met, vastly reducing the chance of problems occurring during the eventual upgrade.

To upload an upgrade package:

1. Open DataMiner Cube.

1. Follow the upgrade procedure described in [Upgrading a DataMiner Agent in System Center](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

1. During the final step of the upgrade procedure, instead of clicking *Upgrade*, select *Upload only*.

   ![Upload only](~/user-guide/images/Upload_Only.png)

1. If the upload was successful, you should receive the following upload report:

   ```txt
   Upload report
   Upload has been completed successfully.
   ```

> [!TIP]
> To be safe, upload the package at least a week before executing the upgrade.

## Prerequisites

Prerequisites are small self-contained apps that run during the upload phase of a DataMiner upgrade. Their purpose is to detect whether all the necessary conditions for upgrading DataMiner to the selected version and all requirements for the DataMiner Agent to run are met. If the prerequisites detect that this is not the case, the upgrade will be canceled.

The following prerequisites are currently available:

- Verify Cluster Ports: Verifies whether the ports used by DataMiner can be reached in between DataMiner Agents. If this check fails, you will need to install the [VerifyClusterPorts.dmupgrade](xref:VerifyClusterPortsdmupgrade) package. From DataMiner 10.2.0 [CU2]/10.2.5 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify NATS is Running](xref:VerifyNatsIsRunning): Verifies whether the crucial NATS service used by DataMiner is running on all required DataMiner Agents. From DataMiner 10.2.0 [CU14]/10.2.7 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Verify Cloud DxM Version](xref:BPA_Verify_Cloud_DxM_Version): Verifies whether the minimum required version is installed for all DxMs in the system. From DataMiner 10.2.0 [CU6]/10.2.8 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Service Automatic Properties](xref:BPA_Service_Automatic_Properties): Verifies whether the installed SRM framework version is up to date. From DataMiner 10.2.3/10.3.0 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Validate Connectors](xref:BPA_Validate_Connectors): Scans the DataMiner System for any connectors that are known to be incompatible with the DataMiner version to which the DataMiner Agent is being upgraded. From DataMiner 10.3.4/10.4.0 onwards, this prerequisite is available by default and runs automatically when you upgrade.

- [Firewall Configuration](xref:BPA_Firewall_Configuration): Checks the firewall configuration. From DataMiner 10.3.7/10.4.0 onwards, this prerequisite runs automatically when you upgrade, to ensure TCP port 5100 is correctly configured to allow inbound communication. This port is required for communication to the cloud via the endpoint hosted in DataMiner CloudGateway.

> [!NOTE]
> Though this is not recommended, you can bypass these checks by manually removing the *Prerequisites* folder from *Update.zip* in the upgrade package. However, you should only do so if there is a clear reason to assume that the prerequisites do not work because of a bug in the software and they are consequently failing without a proper reason. If you bypass these checks in any other circumstances, and this results in a DataMiner issue, this is **not covered by support**.

## Having a backup at the ready

We recommend making a backup of your DataMiner System before executing an upgrade, in case unexpected issues should occur.

Making a backup can be done with a VM snapshot or DataMiner.

### VM snapshot

[Take a virtual machine (VM) snapshot](xref:MOP_Downgrading_a_DMS#for-a-downgrade-with-vm-snapshot-restore) of the upgraded machines shortly before the update. This will allow a speedy rollback of the DataMiner System.

> [!TIP]
> For more information on how to downgrade your DMS using a VM snapshot restore, see [Downgrade with VM snapshot restore](xref:MOP_Downgrading_a_DMS#downgrade-with-vm-snapshot-restore-preferred).

> [!NOTE]
> The timing for a VM snapshot restore depends on your specific setup.

### DataMiner backup

Make a backup of your DataMiner Agent using DataMiner Taskbar Utility or DataMiner Cube, as explained in [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent). This will allow a speedy rollback of the DataMiner System by installing the upgrade package of the previous DataMiner version.
