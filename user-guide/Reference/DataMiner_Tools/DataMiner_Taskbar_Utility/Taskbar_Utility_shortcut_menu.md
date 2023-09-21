---
uid: Taskbar_Utility_shortcut_menu
---

# Taskbar Utility shortcut menu

When you right-click the DataMiner Taskbar Utility system tray icon, a menu appears with the following commands:

- **Launch \> DataMiner Cube**

    Starts DataMiner Cube as a web application.

- **Launch \> Tools \> Client Test**

    Starts the SLNetClientTest program.

    > [!WARNING]
    > The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

    > [!TIP]
    > See also:
    > [SLNetClientTest tool](xref:SLNetClientTest_tool)

- **Launch \> Tools \> Clean Client Files**

    Starts SLCleanCabFiles.exe, which is located in C:\\Skyline DataMiner\\Tools\\.

- **Launch \> Tools \> Log Collector**

    Starts the SLLogCollector tool. (Available in the shortcut menu from DataMiner 9.6.0 CU23/10.0.0 CU13/10.1.0 CU2/10.1.5 onwards.)

    > [!TIP]
    > See also: [SLLogCollector](xref:SLLogCollector)

- **Upgrade**

    Allows you to upgrade the DataMiner Agents in your DataMiner System.

    > [!NOTE]
    >
    > - If an upgrade is started using the DataMiner Taskbar Utility, from DataMiner 9.6.5 onwards, a button is available that allows you to abort the upgrade in progress. However, be very careful with this functionality, as aborting an upgrade can potentially cause a DMA to no longer start up.
    > - From DataMiner 10.1.0 [CU19]/10.2.0 [CU7]/10.2.10 onwards, this option also allows you to install .dmapp packages. In earlier DataMiner versions, only .dmupgrade packages are supported.

    > [!TIP]
    > See also:
    > [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility)

- **Maintenance \> Backup**

    Allows you to take a full or partial backup of the DataMiner Agent you are connected to.

    > [!TIP]
    > See also:
    > [Backing up a DataMiner Agent using DataMiner Taskbar Utility](xref:Backing_up_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility)

- **Maintenance \> Restore**

    Allows you to restore a backup package on the server you are connected to.

    > [!TIP]
    > See also:
    > [Restoring a DMA using the DataMiner Taskbar Utility](xref:Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility)

- **Maintenance \> Upload dmprotocol**

    Allows you to upload a protocol package to the DataMiner Agent you are connected to.

    > [!TIP]
    > See also:
    > [Adding a protocol or protocol version to your DataMiner System](xref:Adding_a_protocol_or_protocol_version_to_your_DataMiner_System)

- **Start DataMiner**

    Starts the DataMiner Agent software on the server you are connected to.

- **Stop DataMiner**

    Stops the DataMiner Agent software on the server you are connected to.

- **Stop DataMiner (forced)**

    Available from DataMiner 9.6.5 onwards. Immediately stops all processes of the DataMiner Agent software on the server you are connected to. This option should only be used in case an issue has occurred that prevents the DMA from shutting down properly.

- **Restart DataMiner**

    Restarts the DataMiner Agent software on the server you are connected to.

- **Options**

    Allows you to specify a number of program options:

    - The DataMiner user credentials used to connect to the SLNet process. If empty, the credentials of the current Windows user will be used.

    - The folder on the DataMiner Agent in which the backup packages are stored.

    - The setting that controls whether or not the DataMiner Taskbar Utility program will start up automatically each time the server is restarted.

    In the *About* tab, the options window also displays the version number of the Taskbar Utility application.

    > [!NOTE]
    > To avoid issues in a DMS that is configured to only use HTTPS/SSL communication, go to *Options* > *slnet* and select the checkbox *HTTPS Support*. (Available from DataMiner 9.5.0 CU12/9.6.3 onwards.)

- **Exit**

    Closes the DataMiner Taskbar Utility program.
