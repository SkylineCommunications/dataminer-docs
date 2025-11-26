---
uid: Monitor_a_spectrum_signal_by_comparing_it_with_thresholds
---

# Monitoring a spectrum signal by comparing it with thresholds

For many international football games, a good livestream across the globe is of the utmost importance to make sure all football fans can watch the game live. Satellite communication plays a crucial role in this. A good example of this use case could be the Champions League Final of June 1st, 2024, broadcast from the legendary Wembley stadium in London. In this simulated use case, the satellite dish at the Skyline HQ receives the signal, behaving like a TV broadcaster to spread it to the Belgian living rooms. In this tutorial, you will learn how to monitor the signal and generate alarms when the signal is for example altered by rain fade or a sudden frequency change.

You will learn how to:

- Deploy an application package from the Catalog
- Add and manage a spectrum preset
- Alter the settings to get the trace window applicable for your use case
- Add and edit thresholds
- Add and edit spectrum analyzer scripts
- Add and edit spectrum analyzer monitors

Expected duration: 20 minutes.

> [!TIP]
> See also:
>
> - [Kata #32: Using the spectrum analyzer](https://community.dataminer.services/courses/kata-32/) on DataMiner Dojo
> - [Skyline Spectrum Simulation connector](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7)

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner 10.4.5.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the 'Spectrum Simulation' package from the Catalog](#step-1-deploy-the-spectrum-simulation-package-from-the-catalog)
- [Step 2: Initialize the use case](#step-2-initialize-the-use-case)
- [Step 3: Add a first threshold (to detect the rain fade)](#step-3-add-a-first-threshold-to-detect-the-rain-fade)
- [Step 4: Add a spectrum script](#step-4-add-a-spectrum-script)
- [Step 5: Add a first spectrum monitor to detect the rain fade](#step-5-add-a-first-spectrum-monitor-to-detect-the-rain-fade)
- [Step 6: Test the rain fade effect](#step-6-test-the-rain-fade-effect)
- [Step 7: Add a second threshold to detect a sudden shift in frequency](#step-7-add-a-second-threshold-to-detect-a-sudden-shift-in-frequency)
- [Step 8: Edit the spectrum script](#step-8-edit-the-spectrum-script)
- [Step 9: Add a second spectrum monitor to detect the shifted carrier](#step-9-add-a-second-spectrum-monitor-to-detect-the-shifted-carrier)
- [Step 10: Test the shifted frequency effect](#step-10-test-the-shifted-frequency-effect)

## Step 1: Deploy the 'Spectrum Simulation' package from the Catalog

1. Go to <https://catalog.dataminer.services/details/01ea2334-0cbb-4dfe-ae6b-07a7ed425df4>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Check whether the package has been successfully deployed:

   - Open DataMiner Cube and check whether a view "Spectrum Simulation (SPCTRM)" and element named "SPCTRM Spectrum Simulation" have been added to your DataMiner Agent.

     ![Spectrum Simulation element](~/dataminer/images/Tutorial_Spectrum_Champions_League_img00.png)

   - Open the Automation module in DataMiner Cube and check if the Automation script *SPCTRM_AS_SkylineSpectrumSimulation* has been added.

   - On the home page of your DataMiner System, check whether the low-code app "Skyline Spectrum Simulation" has been added.

     > [!TIP]
     > See also: [Accessing the web apps](xref:Accessing_the_web_apps)

## Step 2: Initialize the use case

1. Open the low-code app "Skyline Spectrum Simulation".

1. At the bottom of the window, click the button *Initialize Signal*.

   ![Initialize Signal](~/dataminer/images/Tutorial_Spectrum_Champions_League_img01.png)

1. Add a preset to the spectrum simulation element:

   1. Open DataMiner Cube.

   1. In the Surveyor, select the element *SPCTRM Spectrum Simulation*.

   1. On the *Spectrum Analyzer* data page, select the *Presets* tab in the pane on the right, and click the *Manage* button at the bottom of the pane.

   1. Click *New* and specify the necessary data:

      - Add a name, e.g. `myPreset`.

      - Optionally, add a description.

      - Select the checkbox *Share preset with other users*.

      ![Add preset](~/dataminer/images/Tutorial_Spectrum_Champions_League_img03.png)

   1. Click *OK*.

   > [!TIP]
   > See also: [Using spectrum analysis presets](xref:Using_Spectrum_Analysis_presets)

1. Select the *Manual* tab in the pane on the right, and configure the following settings:

   - *Frequency span*: 400 MHz
   - *Center frequency*: 11 750 MHz
   - *Sweeptime*: 100 ms

   The carrier of the main live feed and SNG feed will appear in the spectrum trace.

   ![Spectrum Trace](~/dataminer/images/Tutorial_Spectrum_Champions_League_img02.png)

> [!NOTE]
> When you edit settings of the preset later, you should regularly close and reopen the element card. This will ensure that the UI is updated with the latest changes.

## Step 3: Add a first threshold to detect the rain fade

1. Make sure your preset is loaded:

   1. In the *Presets* pane, select *Show shared presets*.

   1. Select your preset, and click the *Load* button.

1. Add a threshold to detect the rain fade:

   1. In the ribbon at the top of the card, select *thresholds* and click *Threshold edit mode*.

   1. In the details pane to the right of the spectrum display, click *Add threshold*.

   1. Draw the threshold on the spectrum real-time display so that it is slightly below the main signal (which has a center frequency of 11 750 MHz) in terms of amplitude.

      ![Spectrum Trace](~/dataminer/images/Tutorial_Spectrum_Champions_League_img04.png)

1. Save the preset:

   1. At the bottom of the *Presets* pane, select the preset you made earlier in the dropdown list.

      ![Save spectrum preset](~/dataminer/images/Tutorial_Spectrum_Champions_League_img05.png)

   1. Click *Save*.

   1. In the dialog box, click *Yes*.

1. Close and reopen the element card.

> [!TIP]
> See also: [Configuring spectrum thresholds](xref:Configuring_spectrum_thresholds)

## Step 4: Add a spectrum script

1. Create a script that calculates a boolean value "rainFadeDetected":

   1. In the ribbon at the top of the card, select *monitors* and click *New script*.

   1. Specify a name for the script, e.g. `myScript`.

   1. Configure the script contents as illustrated below:

      ![Creating the first script](~/dataminer/images/Tutorial_Spectrum_Champions_League_img06.png)

   1. Click *Apply* to save the script, and close the script window.

1. Save the preset and reload the element card, like in the previous step.

> [!TIP]
> See also: [Working with spectrum scripts](xref:Working_with_spectrum_scripts)

## Step 5: Add a first spectrum monitor to detect the rain fade

In this step, you will add a rain fade monitor that generates a major alarm when the "rainFadeDetected" boolean is evaluated as true.

1. In the ribbon at the top of the card, select *monitors* and click *New monitor*.

1. If this is the first monitor that gets added to the system, in the new monitor window, click *Add monitor*.

1. Specify a name for the monitor, e.g. `rainFadeMonitor`.

1. Expand *Show details*, and set *Interval* to 5 seconds (instead of the default value of 5 minutes).

   ![Set the monitor interval to 5 seconds](~/dataminer/images/Tutorial_Spectrum_Champions_League_img08.png)

   This will make sure that the monitor is triggered every 5 seconds, causing a quick reaction when the rain fade kicks in.

1. Make sure your script (e.g. "myScript") is selected in the *script* dropdown box.

1. Under *Monitoring and trending*, click *Add* and select *Script variable rainFadeDetected* to add this as a parameter.

1. Configure the parameter as illustrated below:

   ![Creating the first monitor](~/dataminer/images/Tutorial_Spectrum_Champions_League_img07.png)

1. Click *Apply* to save the monitor, and close the monitor window.

> [!TIP]
> See also: [Working with spectrum monitors](xref:Working_with_spectrum_monitors)

## Step 6: Test the rain fade effect

1. Open the Spectrum Simulation low-code app and click the button *Let it rain*.

   ![Let it rain](~/dataminer/images/Tutorial_Spectrum_Champions_League_img09.png)

   This will make the main carrier go below the configure threshold, simulating the rain fade causing a sudden drop in amplitude.

1. Check in the Alarm Console in Cube if a major alarm is generated.

   ![Rain alarm detected](~/dataminer/images/Tutorial_Spectrum_Champions_League_img10.png)

   > [!NOTE]
   > As you configured the monitor to execute the script with an interval of 5 seconds, it can take up to 5 seconds before the alarm is generated after the start of the rain fade. By default, this interval is even set to 5 minutes.

1. In the Spectrum Simulation low-code app, click the button *Let the sun shine*.

   This will cause the alarm to go away again.

## Step 7: Add a second threshold to detect a sudden shift in frequency

1. Go back to the spectrum analyzer page in Cube and make sure your preset is loaded.

1. Add a second threshold that is just a bit above your SNG Feed signal (with a small amplitude) and that goes all the way to the right of the current trace window:

   ![Second threshold](~/dataminer/images/Tutorial_Spectrum_Champions_League_img11.png)

1. Save the preset and reload the element card.

## Step 8: Edit the spectrum script

In this step, you will further elaborate the script you created earlier, so that the new threshold 2 is used to detect if the SNG feed carrier has shifted to the right. While there are [multiple ways to calculate booleans in spectrum scripts](xref:Spectrum_Analyzer_script_actions), in this tutorial, you will build on what you used earlier and therefore use the *Trace above maximum threshold* option.

1. In the ribbon at the top of the card, select *monitors* and click *Edit scripts*.

1. Select the script you created earlier and add the script content indicated below:

   ![Shifted Carrier Detected boolean](~/dataminer/images/Tutorial_Spectrum_Champions_League_img12.png)

1. Click *Apply* to save the script, and close the script window.

1. Save the preset and reload the element card.

## Step 9: Add a second spectrum monitor to detect the shifted carrier

In this step, you will add a second, separate monitor that will generate a critical alarm when a shifted carrier is detected.

1. In the ribbon at the top of the card, select *monitors* and click *New monitor*.

1. Specify a name for the monitor, e.g. `shiftedCarrierMonitor`.

1. Expand *Show details*, and set *Interval* to 5 seconds.

1. Make sure your script (e.g. "myScript") is selected in the *script* dropdown box.

1. Under *Monitoring and trending*, click *Add* and select *Script variable shiftedCarrierDetected* to add this as a parameter.

1. Configure the parameter as illustrated below:

   ![Shifted carrier spectrum monitor](~/dataminer/images/Tutorial_Spectrum_Champions_League_img13.png)

1. Click *Apply* to save the monitor, and close the monitor window.

## Step 10: Test the shifted frequency effect

1. Open the Spectrum Simulation low-code app and click the button *Frequency Shift of SNG Feed (+150 MHz)*.

   ![Frequency Shift of SNG Feed](~/dataminer/images/Tutorial_Spectrum_Champions_League_img14.png)

   This will shift the SNG feed carrier by 150 MHz, which will bring it above the threshold monitored in the second spectrum monitor you added.

1. Check in the Alarm Console in Cube if a critical alarm is generated.

    ![Shifted Carrier detected](~/dataminer/images/Tutorial_Spectrum_Champions_League_img15.png)
