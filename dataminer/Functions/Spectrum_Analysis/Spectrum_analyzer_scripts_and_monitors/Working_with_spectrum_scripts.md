---
uid: Working_with_spectrum_scripts
---

# Working with spectrum scripts

To access spectrum scripts, in the *monitors* tab of a spectrum analyzer element, click either ![](~/dataminer/images/script_new_32.png) *New script* or ![](~/dataminer/images/script_edit_32.png) *Edit script*.

This will open the *Edit script* window, which has two panes:

- Left pane: used for script management, contains a tree view and buttons at the bottom.

- Right pane: used to edit scripts selected in pane on the left.

## Managing scripts

In the left pane of the *Edit script* window, the following actions are possible:

- To add a new spectrum script, click the *Add script* button. The script will be added with the default name *Script*, which can be edited later.

- To remove a spectrum script, select the script in the tree view and click the *Delete* button.

- To find a specific script, enter the script name or part of the script name in the Search box at the top of the left pane. The tree view will then be filtered to only show any scripts matching the name you entered.

## Editing scripts

To edit a script, in the *Edit script* window, select the script in the pane on the left. In the pane on the right, you can then do the following:

- Enter a different name for the script in the *Name* box.

- Optionally, enter a description for the script in the *Description* box.

- Specify a first line for the script. This is usually a script action of the type *Get preset*, which loads one of the public presets to define which settings you want to measure a trace with.

- Click *Add* to specify further script actions. A wide range of possibilities is available. However, note that some actions will only become available if other actions have been entered in the script first.

  Usually, the following actions are used early in the script:

  - **Set measurement point**: Determines at what points measurements are to be taken.

    > [!NOTE]
    > Alternatively, measurement points can also be defined in the monitor. In that case, a generic script is used describing what is to be measured, rather than where. This script can then potentially be used more than once, if the monitor has several measurement points. Generally, measurement points are determined in the script if specific measurements need to be performed on a limited number of measurement points. By contrast, if a limited number of measurements need to be performed on a large number of measurement points, the measurement points are usually determined in the monitor.

  - **Get trace**: Performs a trace measurement with the presets defined earlier in the script.

  - For more information on script actions, refer to [Spectrum Analyzer script actions](xref:Spectrum_Analyzer_script_actions).

- Change the position of a script action, by moving the mouse pointer over the action in question, and clicking the up/down arrows that appear to the right of it.

- Delete a script action, by moving the mouse pointer over the action in question, and clicking the *x* that appears to the right of it.

  > [!NOTE]
  > When the measurements in a script are executed, this results in new parameters. For instance, a new parameter C/N can be created by executing a script that measures a trace, takes the difference between the noise level and the carrier level and assigns that value to C/N. The new parameters can then be used for trending and alarming. for more information, see [Working with spectrum monitors](xref:Working_with_spectrum_monitors).

## Using global constants

Within a script, it is possible that you often use fixed variables to perform a calculation (e.g. a correction factor). Though you can enter this value directly in the script, it is also possible to create a global variable that refers to that global value in the script. This option makes it easier to maintain your scripts.

To access the global constants, in the *Edit script* window, click the *Globals* button.

This opens the *Edit global constants* window, where the following actions are possible:

- To add a new global constant, click the *Add global constant* button.

- To edit an existing global constant, select it in the tree view on the left, and edit the *Name*, *Value* or *Description* fields as required. Click *Apply* to apply your changes.

- To remove a global constant, select it in the tree view pane, and then click the *Delete* button.

## Executing scripts without running a monitor

Though usually scripts are executed by a monitor, it is also possible for users to execute a script manually in DataMiner Cube.

To do so:

1. In the *monitors* tab of the ribbon, select *Execute Script*.

1. In the *Execute Script* window, select a script and measurement point, and if necessary also a preset.

1. To only show results for parameters that are monitored, select *Only return results on the script's variables on which monitored parameters have been configured*. If this option is not selected, all variables in the script will be shown.

1. Click *Execute* to start running the script.

   The window then shows the *script results*, with the values of the variables.     You can then:

   - Click *Copy to Clipboard* to copy the results to the clipboard in order to paste them into, for instance, a report or an email.

   - Click *Export to CSV* to export the results to a CSV file.

   - Click the back button in the top left corner to select a different script and/or measurement point.

   - Click *Close* to close the window.

   > [!NOTE]
   >
   > - When you manually run a spectrum script, a message in the middle of the real-time display will indicate that “view script mode” is activated, and mention when the selected trace has a result.
   > - While you are manually executing a script or viewing the script results, you will not be able to use certain functionalities for real-time trace viewing, such as trace recording and measurement point selection.
