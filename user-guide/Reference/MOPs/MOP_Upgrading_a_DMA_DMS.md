---
uid: MOP_Upgrading_a_DMA_DMS
---

# Upgrading a DMA/DMS

The procedure below details how you can implement a DataMiner upgrade in an existing DataMiner System, so that all Agents in the cluster run the new version of DataMiner.

## Requirements

- Access to the servers with administrator rights. This requires a connection dedicated completely or partially to this procedure, via VPN or local network.
- Access to a valid DataMiner upgrade package.
- Technical knowledge of the DMS.
- Technical knowledge of known DataMiner issues.
- Knowledge of DataMiner Main Release and Feature Release paths.

## Procedure

### Determine the upgrade version and time slot

#### Steps

1. Verify when the upgrade should take place.
1. Determine whether a Main Release or Feature Release upgrade is required. In most cases, the Main Release is recommended. When specific features are required, identify which features are required and therefore which Feature Release version.

### Establish the details for the upgrade

#### Prerequisites

- Remote access to the system.
- Credentials with administrator rights.

#### Steps

1. Connect to the system using the designated VPN or host PC.
1. Verify that there are no active problems in the DMS that can endanger the upgrade.
1. Check the key DMS functionalities and verify that these will not be affected by the upgrade.
1. Verify if there are any known issues in the version you intend to upgrade to. See [DataMiner release notes](xref:DataMiner_General_RNs_index) and [Known issues](xref:Known_issues).
1. Check if the minimum requirements are met for the upgrade, and if any additional software will need to be installed to meet these requirements (e.g. .NET Framework upgrade).
1. Check if any hotfixes need to be installed after the upgrade.
1. Determine how much time will be required for the upgrade and make sure this time slot is available on the proposed date of the upgrade.

   The following factors can influence the duration of the upgrade:

   - A large version difference, e.g. an upgrade from 9.6 to 10.2 will take longer than an upgrade from 10.1 to 10.2.
   - The startup time of the DataMiner Agents.
   - Other dependencies, such as extra hotfixes that need to be deployed.

1. Make sure a backup has been taken before the proposed time of the upgrade.

    For a virtual machine, we recommend a snapshot; for a physical machine, we recommend a Windows backup/DataMiner backup.

### Perform a pre-upgrade check on the day before the upgrade

#### Prerequisites

- Remote access to the system.
- Credentials with administrator rights.
- Access to a valid DataMiner upgrade package.

#### Steps

1. Connect to the system using the designated VPN or host PC.
1. Check the system health again.
1. Upload the DataMiner upgrade package(s):

   - If any hotfixes are required, upload these packages as well.
   - To upgrade to a major DataMiner version that is several versions higher than the current version, upload a package for each major version change. For example, to upgrade from 9.6 to 10.2, you will first need to upgrade to 10.0, then to 10.1, and then to 10.2.
   - For cumulative updates of a main release, if the update applies to the same main release, you can use the smaller cumulative update package. Otherwise, for example, to upgrade from 10.0 CU5 to 10.1 CU1, use the full upgrade package.

### Execute the DataMiner upgrade

#### Prerequisites

- Remote access to the system.
- Credentials with administrator rights.
- The pre-upgrade check was successful and the necessary upgrade packages are available.
- A backup of the system has been taken.

#### Steps

1. Open DataMiner Cube.
1. Follow the upgrade procedure described in [Upgrading a DataMiner Agent in System Center](xref:Upgrading_a_DataMiner_Agent_in_System_Center), keeping the following things in mind:

   - Make sure all Agents in the DataMiner System meet the minimum requirements before you upgrade (e.g. install a .NET Framework upgrade if necessary).
   - If you are upgrading a DataMiner System that consists of **more than one Agent**, make sure the **All Agents in cluster** option is selected.
   - If you are upgrading a DMA that is part of a **Failover** pair, check the *Advanced Failover* options and make sure the **Upgrade main and backup Agent simultaneously** option is selected. This is especially important if the upgrade is a major change, but it is also highly recommended otherwise.
   - When you have selected the upgrade packages, **first click *Upload only*** and verify if the packages have been uploaded correctly. Only start the upgrade after you have successfully verified this.

1. When the upgrade is ready, verify that each DMA in the DataMiner System is running and check the key functionalities identified during the [Establish the details for the upgrade](#establish-the-details-for-the-upgrade) step.

## Time estimate

| Item | Activity | Duration |
|------|----------|----------|
| 1    | Determine the upgrade version and time slot | Approx. 30 min. |
| 2    | Establish the details for the upgrade       | Varies depending on the system and upgrade |
| 3    | Perform a pre-upgrade check on the day before the upgrade | 30 min. to 2 hours, depending on whether problems are found and on the upload time |
| 4    | Execute the DataMiner upgrade | Varies depending on version difference, DMA startup time, etc. |
