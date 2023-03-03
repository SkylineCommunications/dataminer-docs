---
uid: KI_Local_user_unable_to_access_DMA_after_first_reboot_after_installation
---

# Local user unable to access DMA after first reboot after installation

## Affected versions

DataMiner 10.3.3

## Cause

When you install and configure DataMiner using a local user, this user is added to the *security.xml* file but not the *syncinfo* file, which contains a list of all known users. This means that while you can connect to the DMA once, you will be prevented from accessing the DMA after a server restart or DataMiner upgrade because the local user is considered a mismatch and was consequently removed from the *security.xml* file.

## Fix

No fix is available yet.

## Issue description

After a DataMiner upgrade or server restart, the local user is unable to connect to the DataMiner Agent when it is the first reboot after installing DataMiner.

## Workaround

- If you are planning to upgrade your DMA or restart the server, first copy the *security.xml* file to your local machine. If after the reboot the local user was removed from the *security.xml* file, replace this file with the copy.

- After installing and configuring DataMiner using a local user, go to *System Center > Users / Groups* to manually add the user. Check whether the user was added to the *syncinfo* file `{DO_NOT_REMOVE_68EE4388-...}` as well, which can found in the `C:\Skyline DataMiner\Files\SyncInfo\` folder.
