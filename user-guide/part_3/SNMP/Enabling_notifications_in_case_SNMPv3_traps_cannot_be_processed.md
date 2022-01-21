---
uid: Enabling_notifications_in_case_SNMPv3_traps_cannot_be_processed
---

## Enabling notifications in case SNMPv3 traps cannot be processed

When an SNMPv3 trap or inform message is received that cannot be processed, for example because of authentication problems, from DataMiner 9.6.3 onwards, DataMiner can generate a notification. However, this feature first needs to be activated in the file *DataMiner.xml*.

To activate this feature:

1. Stop the DataMiner software.

2. Open *C:\\Skyline DataMiner\\DataMiner.xml*.

3. In the *\<SNMPv3>* tag, add the attribute *generateNoticeOnIncorrectTrapReceived* and set it to “true”.

    For example:

    ```xml
    <DataMiner>
      ...
      <SNMPv3 trapPort="362" generateNoticeOnIncorrectTrapReceived="true" />
      ...
    </DataMiner>
    ```

4. Save the file.

5. Restart the DataMiner software.
