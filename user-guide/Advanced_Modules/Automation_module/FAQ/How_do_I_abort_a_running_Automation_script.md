---
uid: How_do_I_abort_a_running_Automation_script
---

# How do I abort a running Automation script?

## [From DataMiner 10.2.12/10.3.0 onwards](#tab/tabid-1)

To abort a running Automation script, close the dialog by clicking the *X* in the top-right corner.

> [!NOTE]
> You can also abort the script by using the following keyboard shortcuts:
>
> - In a web app, press ESC.
> - In DataMiner Cube, press ALT+F4.

## [Prior to DataMiner 10.2.12/10.3.0](#tab/tabid-2)

If the script is an interactive Automation script, and you are the user currently interacting with the script, you can abort the script by clicking the *Abort* button in the dialog, or by simply closing the dialog.

***

> [!NOTE]
> If a user aborts an interactive script, this will generate the exception "InteractiveUserDetachedException", which can optionally be handled in the code of the script. If it is not handled in the script, by default the script will shut down. Otherwise, the further implementation of the code in the script will determine what happens with the script execution.

Alternatively, you can abort a running Automation script by means of the DataMiner SLNetClientTest tool. See [Aborting a running Automation script](xref:SLNetClientTest_aborting_running_script).

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (*C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe*).
