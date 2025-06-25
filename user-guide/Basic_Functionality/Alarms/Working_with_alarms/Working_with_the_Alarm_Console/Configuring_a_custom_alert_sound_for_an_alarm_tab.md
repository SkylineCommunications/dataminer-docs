---
uid: ConfiguringACustomAlertSoundForAnAlarmTab
---

# Configuring a custom alert sound for an alarm tab

It is possible to configure Cube to display a custom alert sound when an alarm enters an alarm tab or increases in severity while it is not yet acknowledged or read (depending on the settings). This is possible for all alarm tabs except tabs showing history alarms or alarms in a sliding window.

> [!NOTE]
>
> - If you open Cube on a client machine that does not have Windows Media Player installed, this feature will not be available.
> - If you do not have the right to add audio files, you will not be able to select the *Audible alert* option as long as no audio files have been added yet. Cube checks for the availability of these files when you connect, so if another user adds a file, the *Audible alert* option becomes available after a reconnect.

To do so:

1. Make sure you have the necessary user permissions, as these are required in order to make changes to custom alert sounds.

   - [General > Alarms > Audible Alert > Add audio files](xref:DataMiner_user_permissions#general--alarms--audible-alert--add-audio-files)
   - [General > Alarms > Audible Alert > Edit audio files](xref:DataMiner_user_permissions#general--alarms--audible-alert--edit-audio-files)
   - [General > Alarms > Audible Alert > Delete audio files](xref:DataMiner_user_permissions#general--alarms--audible-alert--delete-audio-files)

1. While the alarm tab is selected, click the hamburger button in the top-left corner of the Alarm Console and select the option *Audible alert*.

1. In the *Audible alert* window, select the checkbox *Enable audible alert.*

1. Next to *Audio file*, select the audio file that should be used. If the file is not yet available, select *\<Add audio file>* and browse to the desired file.

   > [!NOTE]
   > - When you add a sound file, it is placed in the folder `C:\Skyline DataMiner\Sounds`.
   > - The following file extensions are supported: ".asf", ".wmv", ".wm", ".asx", ".wax", ".wvx", ".wmx", ".wpl", ".wmd", ".mpg", ".m1v", ".mp2", ".mp3", ".mpa", ".mpe", ".m3u", ".mid", ".midi", ".rmi", ".aif", ".aifc", ".aiff", ".au", ".snd", ".wav", ".cda", ".ivf", ".wmz", ".wms".
   > - You can also delete an audio file in the drop-down list, by hovering the mouse pointer over the file and then clicking the *X*.
   > - If you add, update or delete a sound file, an information event is generated. If a sound is updated or deleted, a recycle bin entry is generated.

1. When you have selected a sound file, optionally check what it sounds like by clicking the button to the right of the *Audio file* drop-down list. The same button can then be used to stop the sound again.

1. Below the *Audio file* drop-down list, you can select the following options:

   - *Repeat*: If you select this option, the audio file will be repeated.

   - *Stop playing after ... seconds*: If you select this option, the audio file will stop playing after the specified number of seconds.

1. At the bottom of the window, select whether the sound should stop playing when *all alarms are acknowledged* or *when all alarms are read*.

   > [!NOTE]
   > The user setting *Condition to set an alarm unread* determines whether alarms are set to unread again after any update or only after an increase in severity. To further fine-tune audible alerts, it can be useful to adjust this setting. See [Alarm Console settings](xref:User_settings#alarm-console-settings).

1. Click *OK*.

   An icon in the header of the alarm tab will now indicate that audible alerts have been configured for this tab.
