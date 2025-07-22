---
uid: Enabling_notifications_in_case_SNMPv3_traps_cannot_be_processed
---

# Enabling notifications in case SNMPv3 traps cannot be processed

When an SNMPv3 trap or inform message is received that cannot be processed, for example because of authentication problems, DataMiner can generate a notification. However, this feature first needs to be activated in the file *DataMiner.xml*:

1. Stop the DataMiner software.

1. Open `C:\Skyline Dataminer\DataMiner.xml`.

1. In the *\<SNMPv3>* tag, add the attribute *generateNoticeOnIncorrectTrapReceived* and set it to "true".

   For example:

   ```xml
   <DataMiner>
     ...
     <SNMPv3 trapPort="362" generateNoticeOnIncorrectTrapReceived="true" />
     ...
   </DataMiner>
   ```

1. Save the file.

1. Restart the DataMiner software.
