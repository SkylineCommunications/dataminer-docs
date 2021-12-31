## Restoring the DMA configuration only

If you do not use the Taskbar Utility to restore the DMA, there are two ways to restore the DMA configuration:

- Manually

- Using StandAloneUpgrade.exe

### Restoring the configuration manually

You can manually restore a DMA configuration by copying the *C:\\Skyline DataMiner\\* directory from one server to another.

1. Copy the entire *C:\\Skyline DataMiner\\* directory from the original server to the destination server.

    Make sure that all existing files and directories are overwritten.

2. In the *C:\\Skyline DataMiner\\* directory, delete *DMS.xml*.

### Restoring the configuration using StandAloneUpgrade.exe

On servers running Microsoft Windows Server 2008 or higher, backups are taken using *StandAloneUpgrade.exe*. You can restore such a backup as follows:

1. Make sure the DMA is prepared for the restoration. See [Preparing the destination server for a DMA restoration](Preparing_the_destination_server_for_a_DMA_restoration.md).

2. In the *C:\\Skyline DataMiner\\Tools\\* directory, double-click *StandAloneUpgrade.exe*.

3. Click *File \> Open*.

4. Set *Files of type* to “Zip Files (\*.zip)”, select the backup file (*DataMinerBackup.zip*), and click *Open*.

5. Wait until the backup file has been loaded.

6. Click *Upgrade \> Start.*

7. In the *Confirm* dialog box, click *Yes*.

8. Wait until you see a “Finished” message.

9. In the *C:\\Skyline DataMiner\\* directory, delete *DMS.xml*.

> [!NOTE]
> When certain items (e.g. protocols) have not been included in the backup, you can copy them manually from another DMA or you can have them synchronized automatically when you add the DMA to the DMS. Note that a manual copy operation is faster.
>
