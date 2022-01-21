---
uid: Upgrading_a_DataMiner_Agent
---

# Upgrading a DataMiner Agent

This section provides an overview of how you can upgrade a DataMiner Agent [in the Update Center](Upgrading_a_DataMiner_Agent_in_the_Update_Center.md), [with DataMiner Taskbar Utility](Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility.md) or [in System Center](Upgrading_a_DataMiner_Agent_in_System_Center.md), with additional information on how you can [check the upgrade history](Checking_the_upgrade_history_of_a_DataMiner_Agent.md) and how you can [roll back a DataMiner upgrade](Rolling_back_a_DataMiner_upgrade.md).

From DataMiner 9.6.0 \[CU24\]/10.0.0 \[CU16\]/10.1.0 \[CU5\]/10.1.8 onwards, if a **BPA test** is available to check if the system meets the requirements to upgrade to the target version, this test will run before the upgrade is started. If the test fails, the upgrade will be canceled. For more information about BPA tests, see [Running BPA tests](../DataminerSystems/Running_BPA_tests.md). Though this is not recommended, it is possible to bypass this check by manually removing the *Prerequisites* folder from *Update.zip* in the upgrade package.

> [!NOTE]
> - To set default options for upgrades, go to *System Center* > *System Settings \> Upgrade*.
> - Each upgrade creates a folder under *C:\\Skyline DataMiner\\Upgrades\\Packages*, which contains the upgrade package that has been used, together with a log file (progress.log) and (prior to DataMiner 10.0.0/10.0.3) the rollback package. From DataMiner 10.0.3 onwards, a rollback package is no longer included, as it is better to downgrade by using the full installation package of the version you want to go back to instead.
> - DMPs can be upgraded in System Center like regular DMAs, though additional options will be available in the upgrade window. If the DMP is not ready for an upgrade, or no connection can be established, by default after 10 seconds a warning will appear.

> [!WARNING]
> To make sure the system functions correctly, all DMAs in a cluster must run the same DataMiner version.

> [!TIP]
> Check out the following videos on Dojo:
> - [Rui's Rapid Recap – DataMiner Upgrade](https://community.dataminer.services/video/ruis-rapid-recap-dataminer-upgrade/)
> - [Agents – Upgrading a DataMiner System](https://community.dataminer.services/video/agents-upgrading-a-dataminer-system/)
>
