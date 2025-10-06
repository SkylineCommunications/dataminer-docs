---
uid: Tutorial_MediaOps_Scheduling_Time_Dependent_Capabilities
---

# Using time-dependent capabilities

In this tutorial, you will learn how time-dependent capabilities can be used to ensure that a steerable antenna can be booked multiple times as long as all overlapping jobs are using the steerable antenna for the same satellite. This way, you can ensure that the antenna is booked correctly, taking into account that it can point to only one satellite at a time.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.9 and MediaOps version 1.4.0.

## Prerequisites

- A DataMiner System using DataMiner 10.5.9 or higher.
- MediaOps 1.4.0 or higher.
- Access to the **Resource Studio** and **Scheduling** applications.

## Overview

- [Step 1: Create resources](#step-1-create-resources)
- [Step 2: Create and assign a time-dependent capability](#step-2-create-and-assign-a-time-dependent-capability)
- [Step 3: Configure which antenna can point to which satellite](#step-3-configure-which-antenna-can-point-to-which-satellite)
- [Step 4: Create jobs for antennas](#step-4-create-jobs-for-antennas)

## Step 1: Create resources

In this first step, you will create resources representing the steerable antennas needed for this tutorial.

1. On the **Resource Pools** page of the Resource Studio app, click **+ New**.

1. Enter the name `Antennas` and click *Save as Completed*.

   ![New resource pool](~/solutions/images/Resource_Studio_TDC_New_Resource_Pool.png)

1. Make sure the *Antennas* resource pool is selected in the *Resource Pools* table on the left, and then click *Add* above the table on the right.

   ![Add resources to the resource pool](~/solutions/images/Resource_Studio_Add_Antenna_Resources.png)

1. Enter the name `Antenna 01`, set the concurrency to `5` (to allow up to 5 jobs to use the resource at the same time), and click *Save as Completed*.

   ![Add Antenna](~/solutions/images/Resource_Studio_Add_Antenna.png)

1. Repeat the two steps above to create another antenna named `Antenna 02`.

## Step 2: Create and assign a time-dependent capability

1. Go to the **Capability Management** page.

1. Click **+ New Capability**, and configure the capability as follows:

   1. Specify the name `Satellite`.

   1. Select the **Is Mandatory** and **Is Time-dependent** checkboxes.

   1. Add the following options to represent the possible satellites the antenna can point to:

      - EUT-01
      - SES-01

   ![New capability configuration](~/solutions/images/Resource_Studio_TDC_New_Capability.png)

## Step 3: Configure which antenna can point to which satellite

1. Go to the **Resource Pools** page.

1. Select the *Antennas* resource pool.

1. Click the *...* icon for *Antenna 01* and select **Assign Capabilities**.

   ![Assign capabilities option](~/solutions/images/Resource_Studio_TDC_Assign_Satellite.png)

1. Select the capability *Satellite* and add both options.

   ![Assign capabilities](~/solutions/images/Resource_Studio_TDC_Assign_Satellite2.png)

1. Do the same for *Antenna 02*.

## Step 4: Create jobs for antennas

1. Go to the **Scheduling** app.

1. On the *Job View* page, click **+ New** to start creating a new job, and configure it as illustrated below:

   ![Create job window](~/solutions/images/Resource_Studio_TDC_Create_Job1.png)

   In this example, a pre-roll of 10 minutes is used to leave sufficient time for the antenna to start tracking the satellite. The job is created in the *Tentative* state to ensure resources are reserved.

1. Click *Next* and then click *Create Job*.

1. Click the pencil icon on the job on the timeline to open the *Edit job* panel.

1. In the *Nodes* section, click *Add Node*.

   ![Add Node](~/solutions/images/Resource_Studio_TDC_Add_Antenna_Job1.png)

1. Select the *Antennas* pool and click the filter icon.

   ![Select the resource pool](~/solutions/images/Resource_Studio_TDC_Add_Antenna_Filter_Job1.png)

1. Add the time-dependent capability *Satellite* with the value *EUT-01*.

   ![Add time-dependent capability](~/solutions/images/Resource_Studio_TDC_Add_Antenna_Filter2_Job1.png)

1. Select *Antenna 01* and click *Add Resource*.

   ![Add resource](~/solutions/images/Resource_Studio_TDC_Add_Antenna2_Job1.png)

1. Close the *Edit job* panel

1. Repeat the previous steps to create a second job that overlaps with the first one, but this time, before adding the resource, play around with the satellite capability to see that *Antenna 01* is only available when *EUT-01* is used.

   For example, below you can see the two overlapping jobs on the timeline.

   ![Jobs on the timeline](~/solutions/images/Resource_Studio_TDC_2Jobs.png)

   If *EUT-01* is used, both resources are available for the second job:

   ![Both resources available with EUT-01](~/solutions/images/Resource_Studio_TDC_2Jobs_EUT.png)

   If *SES-01* is used, *Antenna 01* is unavailable, as indicated by the icon in front of the resource.

   ![Antenna 01 unavailable with SES-01](~/solutions/images/Resource_Studio_TDC_2Jobs_SES.png)

   Note that unavailable resources are shown by default so that you can clearly see how many resources are available in a resource pool, even if they cannot be selected for a specific job. If you only want to see available resources, you can use the *Show available only* toggle button in the top-right corner.
