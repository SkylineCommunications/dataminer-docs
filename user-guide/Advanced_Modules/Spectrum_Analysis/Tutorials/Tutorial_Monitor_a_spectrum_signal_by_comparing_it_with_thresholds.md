---
uid: Monitor_a_spectrum_signal_by_comparing_it_with_thresholds
---

# Monitor a spectrum signal by comparing it with thresholds

For many international football games, a good live stream across the globe is of utmost importance to let all football fans watch the game live. Satellite communication plays a crucial role in this. A good example of this use case, could be the Champions League Final in London of the 1st of June, 2024, broadcasted from the legendary Wembley stadium in London. In this simulated use case, the satellite dish on the top of the Skyline HQ receives the signal, behaving like a TV broadcaster to spread it through the Belgian house chambers. In this tutorial, we are going to learn how to monitor the signal and generate alarms when the signal is for example altered by rain fade or a sudden frequency change.

In this tutorial, you will learn how to:

- Deploy an application package from the DataMiner Catalog
- Open the Spectrum Analyzer component
- Add and manage a preset
- Alter the settings to get the trace window applicable for your use case
- Add and edit thresholds
- Add and edit spectrum analyzer scripts
- Add and edit spectrum analyzer monitors

Expected duration: 20 minutes.

- [Monitor a spectrum signal by comparing it with thresholds](#monitor-a-spectrum-signal-by-comparing-it-with-thresholds)
  - [Prerequisites](#prerequisites)
  - [Step 1: Deploy the 'Spectrum Simulation' package from the Catalog](#step-1-deploy-the-spectrum-simulation-package-from-the-catalog)
  - [Step 2: Initialize use case](#step-2-initialize-use-case)
  - [Step 3: Add a first threshold (to detect the rain fade)](#step-3-add-a-first-threshold-to-detect-the-rain-fade)
  - [Step 4: Add a first spectrum script](#step-4-add-a-first-spectrum-script)
  - [Step 5: Add a monitor to detect the Rain Fade](#step-5-add-a-monitor-to-detect-the-rain-fade)
  - [Step 6: Test the Rain Fade effect](#step-6-test-the-rain-fade-effect)
  - [Step 7: Add a second threshold (to detect the sudden shift in frequency)](#step-7-add-a-second-threshold-to-detect-the-sudden-shift-in-frequency)

> [!TIP]
> See also:
> -[Kata #32: Using the spectrum analyzer](https://community.dataminer.services/courses/kata-32/) on DataMiner Dojo
> -[Skyline Spectrum Simulation connector](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7)

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner 10.4.5

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Step 1: Deploy the 'Spectrum Simulation' package from the Catalog

1. Go to <https://catalog.dataminer.services/details/01ea2334-0cbb-4dfe-ae6b-07a7ed425df4>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

    > [!TIP]
    > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check whether a view "Spectrum Simulation (SPCTRM)" and element named "SPCTRM Spectrum Simulation" have been added to your DataMiner Agent.

   If this is the case, the package has been successfully deployed.

   ![Spectrum Simulation element](~/user-guide/images/Tutorial_Spectrum_Champions_League_img00.png)

1. Open the Automation module of your Cube and check if the Automation script "SPCTRM_AS_SkylineSpectrumSimulation" has been added.

1. Check the home of dataminer.services whether the Low Code App "Skyline Spectrum Simulation" has been added.

> [!TIP]
> See also:
> -[Accessing a custom low code app on your system](xref:Accessing_custom_apps)

## Step 2: Initialize use case

1. Open the Low Code App "Skyline Spectrum Simulation"

1. Click on the button "Initialize Signal"

   ![Initialize Signal](~/user-guide/images/Tutorial_Spectrum_Champions_League_img01.png)

1. Go to Cube and open the element card "SPCTRM Spectrum Simulation", and add a preset called e.g. "myPreset". It is important to check the checkbox "Share preset with other users".

    ![Add preset](~/user-guide/images/Tutorial_Spectrum_Champions_League_img03.png)

> [!TIP]
> See also:
> -[Using spectrum analysis presets](xref:Using_Spectrum_Analysis_presets)

1. Set the center frequency to 11 750 MHz, the frequency span to 400 MHz and the sweep time to 100 ms. The carrier of the main live feed and SNG feed will appear in the spectrum trace.

    ![Spectrum Trace](~/user-guide/images/Tutorial_Spectrum_Champions_League_img02.png)

> [!NOTE]
> Upon editing settings of the preset in the next steps, it is a good practice to reopen the element card at a regular base. This is to let the UI know of the latest changes.

## Step 3: Add a first threshold (to detect the rain fade)

1. Make sure your preset is loaded. Add a threshold that is just a bit below (in terms of amplitude) the main signal (which has a center frequency of 11 750 MHz). This will be threshold 1 that will be used to detect the rain fade.

    ![Spectrum Trace](~/user-guide/images/Tutorial_Spectrum_Champions_League_img04.png)

1. Save the preset and reload the element card.

    ![Save spectrum preset](~/user-guide/images/Tutorial_Spectrum_Champions_League_img05.png)

> [!TIP]
> See also:
> -[Configuring spectrum thresholds](xref:Configuring_spectrum_thresholds)

## Step 4: Add a first spectrum script

1. Create a script (e.g. called "myScript") that is calculating a boolean value "rainFadeDetected", making use of the many spectrum script possibilities.

    ![Creating the first script](~/user-guide/images/Tutorial_Spectrum_Champions_League_img06.png)

1. Save the preset and reload the element card.

> [!TIP]
> See also:
> -[Working with spectrum scripts](xref:Working_with_spectrum_scripts)

## Step 5: Add a monitor to detect the Rain Fade

1. Add a Rain Fade Monitor that is using the rainFadeDetected param, monitor it and generate a Major alarm when this boolean is evaluated to true.

    ![Creating the first monitor](~/user-guide/images/Tutorial_Spectrum_Champions_League_img07.png)

1. It is recommended for the tutorial to also edit the details of the rainFadeMonitor and change the Interval to 5 seconds (default value is 5 minutes). This will make sure that the monitor is triggered every 5 seconds, causing a quick reaction when the Rain Fade kicks in.

    ![Set the monitor interval to 5 seconds](~/user-guide/images/Tutorial_Spectrum_Champions_League_img08.png)

> [!TIP]
> See also:
> -[Working with spectrum monitors](xref:Working_with_spectrum_monitors)

## Step 6: Test the Rain Fade effect

1. Open the Spectrum Simulation app and click on the button 'Let it rain'.

    ![Let it rain](~/user-guide/images/Tutorial_Spectrum_Champions_League_img09.png)

1. If everything has been configured correctly, a major alarm should be generated because the main carrier is now below your threshold because the rain fade caused a sudden drop in amplitude.

    ![Rain alarm detected](~/user-guide/images/Tutorial_Spectrum_Champions_League_img10.png)

## Step 7: Add a second threshold (to detect the sudden shift in frequency)

<!-- Optionally add this title, with a link to a tutorial that logically follows this one. If there is no such tutorial, leave this out. -->
