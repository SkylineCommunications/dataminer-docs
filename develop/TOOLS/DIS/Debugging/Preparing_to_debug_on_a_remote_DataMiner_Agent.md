---
uid: Preparing_to_debug_on_a_remote_DataMiner_Agent
---

# Preparing to debug on a remote DataMiner Agent

Proceed as follows if you want to debug a QAction or an automation script located on the DataMiner Agent that is running on another machine.

1. Copy or install Remote Debugging Monitor (msvsmon.exe) on the remote DataMiner Agent.

   - To install Remote Debugging Monitor on the remote DataMiner, either download and run the installer, or copy all files from the following local folder to a random folder on the remote DataMiner Agent:

     `C:\Program Files\Microsoft Visual Studio\<version>\Professional\Common7\IDE\Remote Debugger\x86`

     Example: `C:\Program Files\Microsoft Visual Studio\18\Professional\Common7\IDE\Remote Debugger\x86`

     > [!NOTE]
     >
     > - Remote Debugging Monitor (msvsmon.exe) can run with any user account that has Administrator rights.
     > - Make sure that the version of Remote Debugging Monitor on the remote DataMiner Agent is the version supplied with the version of Visual Studio you are using on your local computer.

1. On the remote DataMiner Agent, log on with an account that has Administrator rights, and start Remote Debugging Monitor as an Administrator.

   - Make sure Remote Debugging Monitor uses "Windows Authentication". To check this setting, go to *Tools \> Options*.

   > [!NOTE]
   > It might be necessary to change certain firewall settings.

1. Run Visual Studio as an Administrator.

1. Make sure that, in the *DMA* tab of the *DIS Settings* window, you have added the DataMiner Agent with the correct user account and that, in its *Debugging* tab, you have selected the *Enable remote debugging* option and configured the following settings:

   | Setting | Description |
   | --- | --- |
   | Debugger qualifier | The qualifier supplied by Remote Debugging Monitor (msvsmon.exe) in a log entry at startup.<br>Format: dmaname:ipport |

   See [DMA](xref:DIS_settings#dma)

You are now ready to start debugging. See [Debugging a connector](xref:Debugging_a_connector) or [Debugging an automation script](xref:Debugging_an_Automation_script).
