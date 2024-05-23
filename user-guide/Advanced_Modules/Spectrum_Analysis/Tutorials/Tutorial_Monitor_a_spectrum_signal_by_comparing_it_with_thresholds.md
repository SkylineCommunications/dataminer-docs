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

> [!TIP]
> See also:
> -[Kata #32: Using the spectrum analyzer](https://community.dataminer.services/courses/kata-32/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
> -[Skyline Spectrum Simulation protocol](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7)

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner 10.4.5

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

## Step 1: Deploy the 'Spectrum Simulation' package from the Catalog

1. Go to <https://catalog.dataminer.services/details/32274506-07a4-4ecb-98d3-bea773c3903e>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check whether a view and element named "Info template quick tips" have been added to your DataMiner Agent.

   If this is the case, the package has been successfully deployed.

   On the *Data* > *Table* page of the element, you will see that the Master Table of the element contains pre-provisioned data:

   ![Master Table](~/user-guide/images/Info_Template_Quick_Tips_img00.png)

## Title of the next main step

1. First step

1. Second step

1. ...

<!-- Add as many subtitles as needed to describe the main steps. -->

## Next steps

<!-- Optionally add this title, with a link to a tutorial that logically follows this one. If there is no such tutorial, leave this out. -->
