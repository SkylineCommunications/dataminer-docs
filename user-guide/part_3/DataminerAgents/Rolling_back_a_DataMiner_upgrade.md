## Rolling back a DataMiner upgrade

By default, prior to DataMiner 10.0.0/10.0.3, when you upgrade a DataMiner Agent, a rollback package is created. This package contains all files replaced during the upgrade. If, for any reason, the DataMiner Agent has to revert to some previous state, you can unpack a rollback package using the DataMiner Taskbar Utility or StandaloneUpgrade.exe. 

However, rollback packages are no longer created in recent DataMiner versions. We recommend that you instead downgrade by using the full upgrade package of the version you want to go back to.

> [!TIP]
> See also:
> [DataMiner Taskbar Utility](../../part_7/DataminerTools/DataMiner_Taskbar_Utility.md)

### Rolling back an upgrade using the DataMiner Taskbar Utility

> [!NOTE]
> This is no longer possible from DataMiner 10.0.0/10.0.3 onwards. To downgrade, install the upgrade package of the version you want to downgrade to. See [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility.md).

1. In the Windows taskbar, right-click the DataMiner Taskbar Utility icon and click *Maintenance \> Rollback*.

    The upgrade window will open, with the most recent rollback package selected as the upgrade package.     If no recent package is available, a notification will appear suggesting an upgrade/downgrade instead.
    You can also select a different rollback package with the *...* button.

    > [!NOTE]
    > Rollback packages are zip files named *Rollback_YYYY_MM_DD_HH_MM_SS.zip*. They can be found in the relevant upgrade folders in the directory *C:\\Skyline DataMiner\\Upgrades\\Packages*.

2. Click *Upgrade* to start the rollback.

    Similar to when you execute an upgrade, the different steps of the rollback process will be displayed.

3. When the rollback is complete, click *Finished*.

> [!NOTE]
> If you roll back a DataMiner Agent using a Cassandra database to a version of DataMiner that does not yet support Cassandra, the upgrade process will try to detect an old SQL configuration and switch back to it if possible. However, it will not check whether this database contains the old data.

### Rolling back an upgrade using StandaloneUpgrade.exe

> [!NOTE]
> This is no longer supported from DataMiner 10.0.0/10.0.3 onwards. To downgrade, install the upgrade package of the version you want to downgrade to. See [Upgrading a DataMiner Agent](Upgrading_a_DataMiner_Agent.md).

1. Stop the DataMiner Agent.

2. Unpack the relevant rollback package using StandaloneUpgrade.exe.

    > [!NOTE]
    > Rollback packages are zip files named *Rollback_YYYY_MM_DD_HH_MM_SS.zip*. They can be found in the relevant upgrade folders in the directory *C:\\Skyline DataMiner\\Upgrades\\Packages*.
    >
