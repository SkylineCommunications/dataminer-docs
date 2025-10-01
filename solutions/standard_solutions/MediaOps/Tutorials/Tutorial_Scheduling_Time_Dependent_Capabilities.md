---
uid: Tutorial_MediaOps_Scheduling_Time_Dependent_Capabilities
---

# Using time-dependent capabilities

In this tutorial, you will learn how time-dependent capabilities can be used to ensure a steerable antenna can be booked multiple times as long as all overlapping jobs are using the steerable antenna for the same satellite (the steerable antenna can point only to one satellite).

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.9 and MediaOps version 1.4.1.

## Prerequisites

- A DataMiner System using DataMiner 10.5.9 or higher.
- MediaOps 1.4.0 or higher.
- Access to the **Resource Studio** and **Scheduling** applications.

## Overview

- [Step 1: Create resources](#step-1-create-resources)
- [Step 2: Create and assign a time-dependent capability](#step-2-create-and-assign-a-time-dependent-capability)

## Step 1: Create resources

In this first step, you will create resources for our steerable antenna's needed for this tutorial.

1. On the **Resource Pools** page of the Resource Studio app, click **+ New**.

1. Enter the name `Antennas` and click *Save as Completed*.

   ![New resource pool](~/solutions/images/Resource_Studio_TDC_New_Resource_Pool.png)

1. Make sure the *Antennas* resource pool is selected in the *Resource Pools* table on the left, and then click *Add* above the table on the right.

   ![Add resources to the resource pool](~/solutions/images/Resource_Studio_Add_Antenna_Resources.png)

1. Enter the name `Antenna 01`, set the concurrency to `5` (to allow up to 5 jobs to use the resource at the same time) and click *Save as Completed*.

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

   ![New resource pool](~/solutions/images/Resource_Studio_TDC_New_Capability.png)

## Step 3: Assign which antenna can point to which satellite

1. Go to the **Resource Pools** page.

1. Select the *Antennas* resource pool.

1. In the context menu of the each antenna resource, Click on *Assign Capabilities*.

![New resource pool](~/solutions/images/Resource_Studio_TDC_Assign_Satellite.png)

1. Assign both satellites to indicate the antenna can point to both satellites.

![New resource pool](~/solutions/images/Resource_Studio_TDC_Assign_Satellite2.png)

## Step 4: Create jobs for antenna's

1. Go to the **Scheduling** app.

1. Create a new job in tentative (in draft the resource is not reserved). In our example we take a pre-roll of 10min to leave sufficient time for the satellite to start tracking the satellite.

![New resource pool](~/solutions/images/Resource_Studio_TDC_Create_Job1.png)

1. Open the job edit panel by clicking on the pencil button on the job.

1. Click on the *Add Node* button.

![New resource pool](~/solutions/images/Resource_Studio_TDC_Add_Antenna_Job1.png)

1. Select the `Antennas` pool and click on the filter icon.

![New resource pool](~/solutions/images/Resource_Studio_TDC_Add_Antenna_Filter_Job1.png)

1. Add the time-dependent capability `Satellite` with as value `EUT-01`.

![New resource pool](~/solutions/images/Resource_Studio_TDC_Add_Antenna_Filter2_Job1.png)

1. Select `Antenna 01` and click on the *Add Resource* button.

![New resource pool](~/solutions/images/Resource_Studio_TDC_Add_Antenna2_Job1.png)

1. Close the job edit panel

1. Repeat the steps te create a second job that overlaps with the first one, but this time before adding the resource play around with the satellite capability to see that `Antenna 01` is only available when using `EUT-01`.

![New resource pool](~/solutions/images/Resource_Studio_TDC_2Jobs.png)

![New resource pool](~/solutions/images/Resource_Studio_TDC_2Jobs_EUT.png)

![New resource pool](~/solutions/images/Resource_Studio_TDC_2Jobs_SES.png)
