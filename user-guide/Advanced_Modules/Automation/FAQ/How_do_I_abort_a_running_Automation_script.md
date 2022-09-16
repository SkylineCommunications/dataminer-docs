---
uid: How_do_I_abort_a_running_Automation_script
---

# How do I abort a running Automation script?

If the script is an interactive Automation script, and you are the user currently interacting with the script, you can abort the script by clicking the *Abort* button in the dialog box, or by simply closing the dialog box.

> [!NOTE]
> If a user aborts an interactive script, this will generate the exception "InteractiveUserDetachedException", which can optionally be handled in the code of the script. If it is not handled in the script, by default the script will shut down. Otherwise, the further implementation of the code in the script will determine what happens with the script execution.

Otherwise, you can abort a running Automation script by means of the DataMiner SLNetClientTest tool. See [Aborting a running Automation script](xref:SLNetClientTest_aborting_running_script).

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (*C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe*).
