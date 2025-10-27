---
uid: Working_with_trace_recordings
---

# Working with trace recordings

In DataMiner Cube, you can make and play back recordings of a trace.

These trace recordings are saved online in the DMS, so that they are accessible from any computer. However, like for presets, you can determine whether a trace recording may be shared or not.

## Making a trace recording

To make a recording:

1. In the *trace* tab of the spectrum analyzer card, go to the *Recording* section, and click *Start Recording*.

   A red dot in the bottom-right corner of the display indicates that a recording is in progress, and an extra menu item, *Stop Recording*, appears in the header bar.

   > [!NOTE]
   > If you intend to make a long recording, make sure that the automatic stand-by option is disabled. Otherwise the screen could freeze after some time, which would consequently end the recording. For more information, see [Toggling the Automatic standby mode](xref:Viewing_spectrum_analyzer_traces#toggling-the-automatic-standby-mode).

1. Click *Stop recording* when ready.

   The *Save Recording As* window appears.

1. In the *Save Recording As* window, enter a name and description for the recording.

1. If you want the recording to be shared between users of the DMS, select *Share recording with other users*. To keep the recording private, leave this checkbox cleared.

1. Click *OK*.

> [!NOTE]
>
> - From DataMiner 10.2.0/10.1.7 onwards, if you close a recording without saving it, it will automatically be saved as a private recording.
> - If a user makes a trace recording, information events will be generated detailing when the recording was started and stopped, and who made the recording.

## Playing a recording

To play back a recording:

1. In the *trace* tab of the spectrum analyzer card, go to the *Recording* section, and click the ![](~/dataminer/images/spectrum_play.png) icon.

1. If you want to select a shared recording, in the pop-up window, select *Show shared recordings*.

1. In the drop-down list next to *Name*, select the recording you want to play.

1. At the bottom of the pop-up window, indicate the way the recording should be played.

   Prior to DataMiner 10.1.9/10.2.0, select one of the following options:

   - *Play Once*: Select this option to play the recording only once. Afterwards, the spectrum interface will return to the interactive mode.

   - *Loop*: Select this option to play the recording in a continuous loop.

   - *Manual*: Obsolete from DataMiner 10.2.0/10.1.7 onwards. Select this option to walk through the recording trace by trace using the step controls at the bottom of the real-time display, instead of viewing the trace at the rate of the recording.

   From DataMiner 10.1.9/10.2.0 onwards, select *Keep repeating the recording* if you want to play the recording in a continuous loop. If you only want to play the recording once, leave this checkbox cleared.

1. Click *OK*.

   While the recording is playing, you can stop it at any time by clicking the ![](~/dataminer/images/spectrum_stop.png) icon in the *Record* section of the ribbon.
   From DataMiner 10.2.0/10.1.7 onwards, below the recording, controls are displayed that allow you to skip forward or backward, pause and play again, and fast forward.

   - Drag the thumb of the slider control to go to any specific point in the recording.

   - If you click the fast forward button again, the playback speed will be further increased. The current playback speed is displayed next to the button.

   - When the controls are not being used, they fade away to show as much of the recording as possible. Hover the mouse pointer near the controls to display them again.

> [!NOTE]
>
> - The traces shown during a recording have an associated date/timestamp, displayed in the bottom-right corner.
> - Spectrum recordings can also be created automatically by a spectrum monitor when an alarm occurs (see [Configuring spectrum monitors](xref:Working_with_spectrum_monitors#configuring-spectrum-monitors)). You can view such a recording by right-clicking the alarm in the Alarm Console and selecting *Show alarm trace recording*.

## Managing recordings

To manage the available recordings:

1. In the *trace* tab of the spectrum analyzer card, go to the *Recording* section, and click the ![](~/dataminer/images/spectrum_recordings.png) icon.

1. If you also want to manage shared recordings, in the Manage recordings window, select *Show shared recordings*.

1. Select a recording in the list, and:

   - If you want to remove it, click the *Delete* button.

   - If you want to change its name or description, click the *Rename* button. Then enter the new name and/or description in the pop-up window and click *OK*.

   - If you want to make a shared recording private or vice versa, click the *Rename* button, change the selection of the checkbox *Share recording with other users*, and click *OK*.

1. When ready, click the *Close* button.
