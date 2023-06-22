---
uid: Working_with_spectrum_monitors
---

# Working with spectrum monitors

A spectrum monitor works as a schedule to run a spectrum script, optionally with any combination of measurement points and/or presets. It can be used to make the spectrum device sweep the input signal at regular intervals to measure particular variables.

The following topics provide more information on working with spectrum monitor:

- [Managing spectrum monitors](#managing-spectrum-monitors)

- [Configuring spectrum monitors](#configuring-spectrum-monitors)

- [Watching spectrum buffers](#watching-spectrum-buffers)

- [Taking priority over a spectrum monitor](#taking-priority-over-a-spectrum-monitor)

> [!NOTE]
> Only one spectrum monitor script can be executed on the same element at the same time. If a script is set to run while another script is being executed, DataMiner will wait until the script can obtain exclusive element access.

> [!TIP]
> See also:
> [Spectrum Analyzer – Setting up continuous background RF measurements](https://community.dataminer.services/video/spectrum-analyzer-setting-up-continuous-background-rf-measurements/) ![Video](~/user-guide/images/video_Duo.png)

## Managing spectrum monitors

On a spectrum analyzer card, you can manage the spectrum monitors for one particular element. Managing spectrum monitors across all elements is possible in System Center.

### On a spectrum analyzer card

To access spectrum monitors from a spectrum analyzer card:

- In the *monitors* tab, click either ![](~/user-guide/images/monitoradd_32.png) *New monitor* or ![](~/user-guide/images/monitoredit_32.png) *Edit monitor*.

  This will open the *Edit monitor* window, which has two panes:

  - Left pane: Used for monitor management, contains a tree view and buttons at the bottom.

  - Right pane: Used to edit a monitor selected in the pane on the left.

The following actions are possible to manage the spectrum monitors:

- To add a new spectrum monitor, click the *Add monitor* button. The monitor will be added with the default name *Monitor*, which can be edited later.

- To remove a spectrum monitor, select the monitor in the tree view and click the *Delete* button.

- To find a specific monitor, enter the monitor name or part of the monitor name in the Search box at the top of the left pane. The tree view will then be filtered to only show any monitors matching the name you entered.

### In System Center

To access spectrum monitors in System Center:

- In DataMiner Cube, go to *Apps* > *System Center \> Tools \> configure spectrum monitors*.

  The monitor configuration section is very similar to the *Edit monitor* window described above, with the following differences:

  - In the tree view on the left, the monitors are contained in a separate folder for each spectrum element protocol in the DMS.

  - In the pane on the right, under *Elements*, the elements are selected that are using this monitor. For each element, you can select what measurement points and input presets should be used.

  - Monitors cannot be directly edited in the pane on the left. Instead, to edit a monitor, click the *Edit monitor* button at the bottom.

> [!NOTE]
> You can only access spectrum monitors in System Center if you have the user permission *Spectrum* > *Configure scripts & monitors* and there is at least one spectrum protocol with more than one spectrum element available.

## Configuring spectrum monitors

When you create a spectrum monitor, you can configure custom parameters that can be viewed in real time. These parameters are in fact variables from the spectrum scripts, that are given more user-friendly names.

It is possible to generate trend information for these parameters, and to have them trigger alarms.

> [!NOTE]
>
> - Trace trending is only available when the DMA’s general database is a MySQL database of version 5.0.3 or higher. MSSQL is also supported on DataMiner versions prior to 10.3.0.
> - Trending data for Spectrum Analysis traces is stored in the spectrum_trace table of a DMA’s general database. The data is kept for 12 months (by default) and cleaned up just like average trending data.
> - Settings regarding storage and cleaning of trending data can be configured in the *Trending.TimeSpanSpectrumRecords* tag of the *MaintenanceSettings.xml* file. It is also possible to override the setting per element using an *\<Element>\<Trending>\<TimeSpanSpectrumRecords>* tag in the file *Element.xml*.

Below are the basic steps you can follow to configure a spectrum monitor. Depending on the purpose of the monitor you are creating, not all steps may be required, and you may not necessarily need to do the steps in the proposed order. However, these steps are meant to give you an indication of how spectrum monitors are made.

1. On a spectrum analyzer card, select the spectrum monitor in the tree view on the left. In the pane on the right, the configuration options for the monitor are then displayed.

   Alternatively, in the System Center *configure spectrum monitors* section, you can select the monitor and click *Edit monitor*.

   > [!NOTE]
   > In System Center, if a protocol does not have at least one active element, it will not be possible to add, edit or delete a monitor for this protocol.

1. In the *Name* box, enter a different name for the monitor.

1. Click *Show details*, and fill in a description for the monitor in the *Description* box.

1. Also in the details section, enter the interval at which the script should be executed. You can do so either by entering the interval directly into the *Interval* box, or by selecting the interval with the slider control next to the box.

   > [!NOTE]
   > If you set the script interval to less than 30 minutes, you may receive a warning when you click *Save*. When trended traces are run very frequently, huge amounts of trend data get stored in the database, which could eventually cause database problems.

1. Also in the details section, to create a service matching the monitor, select *Create service*. The generated service will have the same name as the monitor, and will contain all the monitored parameters.

   > [!NOTE]
   >
   > - To remove a service created by a spectrum monitor, you must either disable the *Create Service* option or remove the monitor itself. Unlike a normal service, it cannot be deleted in the Surveyor.
   > - Spectrum monitors for which a service has been created are indicated with a special icon in the Surveyor, instead of the regular service icon: ![](~/user-guide/images/spectrum_monitor.png)

1. In the *script* section, select the script that is to be executed by the monitor.

1. In the *Measurement Points* section, select the measurement points on which the monitor has to execute the script. It is possible to select several measurement points, so that the monitor is run for a series of switch states.

   > [!NOTE]
   > Changing the values of the parameters that are used for a measurement point while the spectrum script is running could lead to unexpected behavior. After it has initially started, the script does not check for changes to the values of these parameters.

1. If the selected script requires a preset selection in the monitor, in the *Input presets* section, select a preset.

1. In the *Monitoring and trending* section, add parameters:

   1. If you want the parameter configuration to be applied for all measurement points at once, make sure the option *Group parameters* is selected. If you wish to configure parameters separately for each measurement point, e.g. to configure different alarm thresholds, clear the selection box next to this option.

   1. Click *Add* and select a script variable to add as a parameter.

   1. Enter a user-friendly name for the parameter next to *Parameter description*.

   1. To enable alarm monitoring, in the *Template editing* section, select *Monitored*, select the *Type* of alarm template, and enter the necessary alarm thresholds.

      > [!NOTE]
      >
      > - For more information on the types of alarm templates, see [Configuring dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds).
      > - Unlike normal parameters, parameters created by a spectrum monitor can only have alarm monitoring configured in the monitor editor. It is not possible to define alarm templates for them in the Protocols & Templates module.

   1. To enable trending for the parameter, select *Trended*.

   1. To be able to view the parameter in real time, select *Displayed on element card*. When this option is selected, the parameters will be added on the card at runtime, and updated after every script execution. All parameters calculated by a single monitor will be grouped together on a single data page with the same name as the monitor. In case the monitor is executed on several measurement points, the name of the measurement point will be added to the parameter name in brackets.

   1. To define the range, units and decimals for the real-time display of the parameter, select *Using Custom Range* and enter the values in question. If these are not defined, no units will be used and other settings will be automatically defined by DataMiner.

   1. Repeat from b. for each parameter you want to add.

   > [!NOTE]
   > From DataMiner 9.5.12 onwards, it is possible to import and export parameters using the buttons at the top of this section:
   >
   > - Import/export files should be comma-separated CSV or TXT files.
   > - To add new parameters with an import, use the parameter ID “-1”.
   > - After an import, the imported parameters will be displayed in this section. You will then still need to click *Apply* to confirm the import.

1. In the *Alarm Recordings* section, customize the number of *Earlier traces* and *Future traces* to be stored when an alarm recording is created. When an alarm occurs, these may help operators to analyze the nature of the problem.

   > [!NOTE]
   > To view an alarm recording for a spectrum monitor alarm, right-click the alarm in the Alarm Console and select *Open* > *Spectrum recording*. However, note that trace recordings are not available for cleared alarms.

> [!NOTE]
> To deactivate the monitor, at the top of the pane, clear the selection from *Enable this monitor*.

## Watching spectrum buffers

When you work in real-time interactive mode, this requires part of the limited measuring capacity of the spectrum analyzer. As such, when you are only interested in seeing some of the measurements, which are already executed by scripts for automated performance monitoring, you can watch the so-called spectrum buffers instead.

To watch a single buffer:

1. In the *monitors* tab of the ribbon, select *View buffer*.

1. Select the monitor, input preset, measurement point and trace, and click *Load*.

   The buffer will be displayed, with a message in the middle of the display area specifying what buffer is being displayed.

1. To stop watching the buffer, in the *monitors* tab, clear the selection from *View buffer*.

To view all buffers:

1. In the *monitors* tab, select *View All Buffers*.

   In this mode, any trace measured by the spectrum analyzer will be displayed on screen, so the display will show one buffer after another. Result traces of manual script execution and traces retrieved for the interactive sessions of other clients are also displayed. In the middle of the spectrum display, a description is provided of what is being displayed.

1. To stop watching the buffer, in the *monitors* tab, clear the selection from *View all buffer*s.

> [!NOTE]
>
> - Spectrum buffers measured during monitor execution are also available in DMS Reporter, and in Visual Overview. See [Element reports](xref:Element_reports) and [Spectrum Buffers](xref:Components_for_one_single_element_or_service#spectrum-buffers) for information on DMS Reporter and [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter) for information on spectrum thumbnails in Visio.
> - While you are watching a spectrum buffer, any options that are only applicable for real-time trace viewing, such as taking trace recordings, are disabled.

> [!TIP]
> See also: [Viewing along with another client](xref:Viewing_spectrum_analyzer_traces#viewing-along-with-another-client)

## Taking priority over a spectrum monitor

When a lengthy script is being executed by a monitor, it is possible that the real-time spectrum display does not receive new trace data. In this case, if you have been granted the permission *Spectrum: Take Priority Over Monitors*, you can take priority over the spectrum monitor in DataMiner Cube.

To do so:

1. In the ribbon of the spectrum analyzer card, go to the *monitors* tab.

1. Click ![](~/user-guide/images/prio_over_monitors_32.png) *Take Priority Over Monitors*.

1. In the message box, click *OK*.

   The active monitor execution will then stop as soon as possible, i.e. after the script run on the current measurement point is completed.
   In the top-right corner of the spectrum graph, a notice will indicate that you are in prioritized mode.

To go back to normal mode, in the *monitors* tab, click *Take Priority Over Monitors* again. The prioritized mode also ends automatically as soon as you enter standby mode.
