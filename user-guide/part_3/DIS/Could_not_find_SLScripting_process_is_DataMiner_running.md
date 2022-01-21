---
uid: Could_not_find_SLScripting_process_is_DataMiner_running
---

## Could not find SLScripting process, is DataMiner running?

### Problem

After clicking *Attach* in the *DIS Inject* window, you get the following error:

```txt
Visual Studio needs to run as administrator to perform this action.
```

### Cause

Microsoft Visual Studio is not allowed to attach to the DataMiner SLScripting process.

### Resolution

Run Microsoft Visual Studio as an administrator.

#### To change the privilege level of VSLauncher.exe

1. Exit Microsoft Visual Studio

2. In Windows Explorer, go to *C:\\Program Files\\Common Files\\microsoft shared\\MSEnv*

3. Right-click *VSLauncher.exe* and select *Properties*.

4. In the *Properties* dialog box of *VSLauncher.exe*, go to the *Compatibility* tab.

5. In the *Privilege Level* section, select the *Run this program as an administrator* checkbox.

6. Click *OK*.

#### To associate XML files with VSLauncher.exe

1. Right-click an XML file and select *Open With \> Choose Default Program.*

2. In the *Open With* dialog box, click *Browse.*

3. Go to *C:\\Program Files\\Common Files\\microsoft shared\\MSEnv*, select *VSLauncher.exe* and click *Open*.

4. Select the *Always use the selected program to open this kind of file* checkbox and click *OK*.
