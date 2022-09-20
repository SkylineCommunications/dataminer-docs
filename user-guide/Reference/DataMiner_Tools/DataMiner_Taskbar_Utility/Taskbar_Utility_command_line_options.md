---
uid: Taskbar_Utility_command_line_options
---

# Taskbar Utility command line options

From DataMiner 9.0.1 onwards, it is possible to make the SLTaskbarUtility perform actions using the command prompt, without any further user interaction.

To do so:

1. Open a *Command Prompt* window.

1. Navigate to the SLTaskbarUtility installation folder.

   For example:

   ```txt
   cd c:\Program Files (x86)\Skyline Communications\Skyline Taskbar Utility
   ```

1. Enter “*start /wait SLTaskbarUtility.exe*”, followed by one of the commands and the necessary arguments listed under [List of possible commands](#list-of-possible-commands).

   ```txt
   start /wait SLTaskbarUtility.exe [command] [arguments]
    ```

   “start /wait” is used to await the return code of the command, which can be checked using the *%errorlevel%* environment variable.

   > [!NOTE]
   > It is still possible to open the SLTaskbarUtility user interface by either double-clicking a file with a DataMiner extension (e.g. dmupgrade, dmbackup, etc.) or entering the path to such a file in a *Command Prompt* window.

## List of possible commands

| Command&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; | Function |
|--|--|
| -uploadprotocol | Upload a DataMiner protocol package.<br> Mandatory argument: File path to a *dmprotocol* file. |
| -rollback | Roll back the local DataMiner Agent to the previous DataMiner software version using the most recent valid rollback package found on the DataMiner Agent.<br> Note that this is no longer supported from DataMiner 10.0.0/10.0.3 onwards. |
| -restore | Restore a DataMiner backup package.<br> Mandatory argument: File path to a *dmbackup* file. |
| -backup | Make a backup of the local DataMiner Agent.<br> Mandatory arguments:<br> -  File path to a *BackupSettings.xml* file.<br> -  ID of a predefined backup setting in the *BackupSettings.xml* file. |
| -stop | Stop the local DataMiner Agent. |
| -start | Start the local DataMiner Agent. |
| -restart | Restart the local DataMiner Agent. |
| -upgrade | Upgrade the DataMiner Agent(s).<br> Arguments:<br> -  File path to an *.dmupgrade* file or (from DataMiner 10.1.0 [CU19]/10.2.0 [CU7]/10.2.10 onwards) a *.dmapp* file. This argument is mandatory.<br> -  File path to an *UpgradeInfo.xml* file. This argument is optional and only used for .dmupgrade files. If you do not specify an *UpgradeInfo.xml* file, the .dmupgrade will only be installed on the local DataMiner Agent, with the default upgrade options.<br> For more information about *UpgradeInfo.xml* files, see [UpgradeInfo.xml](#upgradeinfoxml). |
| -help | List information about the above-mentioned commands.<br> -  If you want information about all commands, pass the *-help* command without any argument.<br> -  If you want information about one specific command, pass the *-help* command followed by that specific command (e.g. *-help -help*). |

## UpgradeInfo.xml

When using the *-upgrade* command, you can specify that the upgrade options have to be taken from an *UpgradeInfo.xml* file.

The options in this file reflect the options available in the Taskbar Utility’s upgrade window. For a Failover setup, the same options can be specified in the *\<FailoverPolicy>* tag as in the Taskbar Utility UI:

- UseDefault

- Simultaneously

- BackupFirst

- BackupFirstWithSwitchback

> [!TIP]
> See also: [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility)

### Example

```xml
<UpgradeInfo>
  <Agents>
    <IP>localhost</IP>
    <IP>999.999.99.99</IP>
  </Agents>
  <IsCluster>true</IsCluster>
  <ExtractAllFiles>true</ExtractAllFiles>
  <DelayedStart>true</DelayedStart>
  <AutomaticStartServices>true</AutomaticStartServices>
  <StopSNMP>false</StopSNMP>
  <RebootAfterUpgrade>false</RebootAfterUpgrade>
  <FailoverPolicy>UseDefault</FailoverPolicy>
</UpgradeInfo>
```
