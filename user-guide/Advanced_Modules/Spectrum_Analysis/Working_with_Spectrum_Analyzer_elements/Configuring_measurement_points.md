---
uid: Configuring_measurement_points
---

# Configuring measurement points

A measurement point is a series of sets that is executed on devices to select an input for a spectrum analyzer device, e.g. to set a switch to the correct position. This way, multiple signals can be measured with one single spectrum analyzer.

The following sections provide more information on how to configure measurement points:

- [The measurement point configuration window](#the-measurement-point-configuration-window)

- [Configuring a measurement point](#configuring-a-measurement-point)

- [Displaying measurement points](#displaying-measurement-points)

> [!TIP]
> See also:
> [Spectrum Analyzer – About presets and measurement points](https://community.dataminer.services/video/spectrum-analyzer-about-presets-and-measurement-points/) ![Video](~/user-guide/images/video_Duo.png)

## The measurement point configuration window

On a spectrum analyzer card, go to the *Measurement points* tab in the overhead ribbon, and click *New measurement point* or *Edit measurement point* to open the measurement point configuration window.

The measurement point configuration window consists of:

- A list pane on the left containing all measurement points in the DMS.

- A details pane on the right where a selected measurement point can be configured. See [Configuring a measurement point](#configuring-a-measurement-point).

- A number of buttons at the bottom of the list pane:

    - The *Add measurement point* button, which can be used to add a new, unconfigured measurement point to the list.

    - The *Delete* button, which can be used to delete a selected measurement point.

    - The *Export* button, which can be used to export the measurement points to a CSV or TXT file (comma-separated format).

    - The *Import* button, which can be used to import measurement points from a CSV or TXT file.

        Any measurement points with ID -1 in the import file will be added as new measurement points. The imported measurement points will be shown in the list pane with the label *\[modified\]* or *\[new\]*, and the changes will need to be applied before they are saved.

> [!NOTE]
> - If the current trace is hidden, this will be reflected in the measurement point. See [Spectrum trace acquisition](xref:Viewing_spectrum_analyzer_traces#spectrum-trace-acquisition).
> - If no measurement points have been configured yet, the *Edit measurement point* option will not be available.

## Configuring a measurement point

To configure a new or existing measurement point:

1. Select the measurement point in the list pane of the measurement point configuration window.

2. At the top of the details pane, next to *Name*, specify a name for the measurement point.

3. In the *Setup* section, select either to set up the measurement point via a parameter set, or via an Automation script, and then select the parameter set or the script in question.

    > [!NOTE]
    > - To configure a parameter set of a matrix parameter, when you have selected the parameter, click the value field. A pop-up box will then appear in which you can select the input and output and indicate whether these should be connected.
    > - For more information on configuring a measurement point to execute an Automation script, see [Making a measurement point execute a script before taking a trace](xref:Making_a_measurement_point_execute_a_script_before_taking_a_trace).

4. Optionally, in the *Advanced* section:

    - Specify a *Delay for Parameter Set Verification*, i.e. set a number of ms that DataMiner should wait before taking a spectrum sweep after setting the measurement point.

    - Specify a *Frequency offset*, i.e. shift the trace in frequency.

    - Select the checkbox next to *Invert spectrum* in order to flip the trace around the center frequency.

        > [!NOTE]
        > The *Frequency offset* and *Invert spectrum* options can be of use when the spectrum analyzer is operating behind frequency downconverters, which apply an offset to the spectrum and sometimes also invert it.

    - Add an amplitude correction. See [Specifying an amplitude correction](xref:Specifying_an_amplitude_correction).

## Displaying measurement points

To display a measurement point, in the settings pane, go to *Manual* > *Measurement points*, and select the measurement point you want to display. To quickly find a particular measurement point, use the quick filter in the top right corner.

Two additional display options are available in the *Measurement points* tab:

- **![](~/user-guide/images/measptvisualize_16.png) Visualize measurement points**:

    Adds the measurement points as services in the same view as the spectrum analyzer element. These services contain the monitored alarm parameters for the measurement point.

    > [!NOTE]
    > - Measurement points have their own specific icon in the Surveyor: ![](~/user-guide/images/measurement_point_icon.png)
    > - A service representing a measurement point will only include the spectrum element if there is at least one monitor with at least one parameter that uses this measurement point.
    > - The default opening behavior of measurement point cards can be configured in the user settings. The cards can either open as a service or as a spectrum analyzer card. The alternative opening behavior can be accessed via the measurement point’s context menu. See [Card settings](xref:User_settings#card-settings).

- **![](~/user-guide/images/combined_measpt_16.png) Combined measurement point view**:

    When this option is enabled, you can display multiple measurement points at once by selecting them in the *Manual \> Measurement points* tab of the settings pane.
