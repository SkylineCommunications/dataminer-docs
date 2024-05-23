---
uid: Monitor_a_spectrum_signal_by_comparing_it_with_thresholds
---

# Monitoring a spectrum signal by comparing it with thresholds

For many international football games, a good live stream across the globe is of the utmost importance to make sure all football fans can watch the game live. Satellite communication plays a crucial role in this. A good example of this use case could be the Champions League Final of June 1st, 2024, broadcast from the legendary Wembley stadium in London. In this simulated use case, the satellite dish at the Skyline HQ receives the signal, behaving like a TV broadcaster to spread it to the Belgian living rooms. In this tutorial, you will learn how to monitor the signal and generate alarms when the signal is for example altered by rain fade or a sudden frequency change.

You will learn how to:

- Deploy an application package from the DataMiner Catalog
- Add and manage a spectrum preset
- Alter the settings to get the trace window applicable for your use case
- Add and edit thresholds
- Add and edit spectrum analyzer scripts
- Add and edit spectrum analyzer monitors

Expected duration: 20 minutes.

> [!TIP]
> See also: [Skyline Spectrum Simulation connector](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7)

<!-- Replace the tip above with this one when the kata is released:
> [!TIP]
> See also:
> -[Kata #32: Using the spectrum analyzer](https://community.dataminer.services/courses/kata-32/) on DataMiner Dojo
> -[Skyline Spectrum Simulation connector](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7) -->

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

     ![Spectrum Simulation element](~/user-guide/images/Tutorial_Spectrum_Champions_League_img00.png)

   - Open the Automation module in DataMiner Cube and check if the Automation script *SPCTRM_AS_SkylineSpectrumSimulation* has been added.

   - On the homepage of your DataMiner System, check whether the low-code app "Skyline Spectrum Simulation" has been added.

     > [!TIP]
     > See also: [Accessing the Low-Code Apps module](xref:Accessing_custom_apps)

## Step 2: Initialize the use case

1. Open the low-code app "Skyline Spectrum Simulation".

1. At the bottom of the window, click the button *Initialize Signal*.

   ![Initialize Signal](~/user-guide/images/Tutorial_Spectrum_Champions_League_img01.png)

1. Add a preset to the spectrum simulation element:

   1. Open DataMiner Cube.

   1. In the Surveyor, select the element *SPCTRM Spectrum Simulation*.

   1. On the *Spectrum Analyzer* data page, select the *Presets* tab in the pane on the right, and click the *Manage* button at the bottom of the pane.

   1. Click *New* and specify the necessary data:

      - Add a name, e.g. "myPreset".

      - Optionally, add a description.

      - Select the checkbox *Share preset with other users*.

      ![Add preset](~/user-guide/images/Tutorial_Spectrum_Champions_League_img03.png)

      > [!TIP]
      > See also: [Using spectrum analysis presets](xref:Using_Spectrum_Analysis_presets)

   1. Click *OK*.

1. Select the *Manual* tab in the pane on the right, and configure the following settings:

   - *Frequency span*: 400 MHz
   - *Center frequency*: 11 750 MHz
   - *Sweeptime*: 100 ms

   The carrier of the main live feed and SNG feed will appear in the spectrum trace.

   ![Spectrum Trace](~/user-guide/images/Tutorial_Spectrum_Champions_League_img02.png)

> [!NOTE]
> When you edit settings of the preset later, you should regularly close and reopen th element card. This will ensure that the UI is updated with the latest changes.

## Step 3: Add a first threshold to detect the rain fade

1. Make sure your preset is loaded:

   1. In the Presets pane, select *Show shared presets*.

   1. Select your preset, and click the *Load* button.

1. Add a threshold to detect the rain fade:

   1. In the ribbon at the top of the card, select *thresholds* and click *Threshold edit mode*.

   1. In the details pane to the right of the spectrum display, click *Add threshold*.

   1. Select the new threshold entry in the pane, and draw the threshold on the spectrum real-time display so that it is slightly below the main signal (which has a center frequency of 11 750 MHz) in terms of amplitude.

   ![Spectrum Trace](~/user-guide/images/Tutorial_Spectrum_Champions_League_img04.png)

1. Save the preset and reload the element card.

   ![Save spectrum preset](~/user-guide/images/Tutorial_Spectrum_Champions_League_img05.png)

> [!TIP]
> See also: [Configuring spectrum thresholds](xref:Configuring_spectrum_thresholds)

## Step 4: Add a spectrum script

1. Create a script (e.g. called "myScript") that is calculating a boolean value "rainFadeDetected", making use of the many spectrum script possibilities.

   ![Creating the first script](~/user-guide/images/Tutorial_Spectrum_Champions_League_img06.png)

1. Save the preset and reload the element card.

> [!TIP]
> See also: [Working with spectrum scripts](xref:Working_with_spectrum_scripts)

## Step 5: Add a first spectrum monitor to detect the rain fade

1. Add a Rain Fade Monitor that is using the rainFadeDetected param, monitor it and generate a Major alarm when this boolean is evaluated to true.

    ![Creating the first monitor](~/user-guide/images/Tutorial_Spectrum_Champions_League_img07.png)

1. It is recommended for the tutorial to also edit the details of the rainFadeMonitor and change the Interval to 5 seconds (default value is 5 minutes). This will make sure that the monitor is triggered every 5 seconds, causing a quick reaction when the Rain Fade kicks in.

    ![Set the monitor interval to 5 seconds](~/user-guide/images/Tutorial_Spectrum_Champions_League_img08.png)

> [!TIP]
> See also: [Working with spectrum monitors](xref:Working_with_spectrum_monitors)

## Step 6: Test the rain fade effect

1. Open the Spectrum Simulation app and click on the button 'Let it rain'.

    ![Let it rain](~/user-guide/images/Tutorial_Spectrum_Champions_League_img09.png)

1. If everything has been configured correctly, a major alarm should be generated because the main carrier is now below your threshold because the rain fade caused a sudden drop in amplitude.

    ![Rain alarm detected](~/user-guide/images/Tutorial_Spectrum_Champions_League_img10.png)

1. Save the preset and reload the element card.

## Step 7: Add a second threshold to detect a sudden shift in frequency

1. Make sure your preset is loaded. Add a second threshold that is just a bit above your SNG Feed signal (that has a small amplitude) and that is also covering until the right end of the current trace window.

    ![Second threshold](~/user-guide/images/Tutorial_Spectrum_Champions_League_img11.png)

1. Save the preset and reload the element card.

## Step 8: Edit the spectrum script

1. The script needs to be elaborated, as we want to use this new threshold 2 to detect if the SNG Feed carrier shifted to the right. Note that, as described in the [spectrum scripts page](xref:Working_with_spectrum_scripts) there are multiple ways to calculate booleans. In this tutorial, it was chosen to build further upon what we already used before, and use the 'trace above maximum threshold'-option.

    ![Shifted Carrier Detected boolean](~/user-guide/images/Tutorial_Spectrum_Champions_League_img12.png)

1. Apply the script, save the preset and reload the element card.

## Step 9: Add a second spectrum monitor to detect the shifted carrier

1. Similar to step 5, you need to add a second separate monitor that can shift the Detected Carrier. This time, we choose to generate a critical alarm.

    ![Shifted Carrier Spectrum Monitor](~/user-guide/images/Tutorial_Spectrum_Champions_League_img13.png)

## Step 10: Test the shifted frequency effect

1. Open the Spectrum Simulation app and click on the button 'Frequency Shift of SNG Feed (+150 MHz)'.

    ![Frequency Shift of SNG Feed](~/user-guide/images/Tutorial_Spectrum_Champions_League_img14.png)

1. If everything has been configured correctly, a critical alarm should be generated because the SNG Feed carrier has shifted 150 MHz and as it is above the threshold now detected by the second spectrum monitor you added.

    ![Shifted Carrier detected](~/user-guide/images/Tutorial_Spectrum_Champions_League_img15.png)
