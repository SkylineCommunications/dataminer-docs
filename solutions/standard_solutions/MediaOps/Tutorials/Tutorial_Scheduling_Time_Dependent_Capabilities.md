---
uid: Tutorial_MediaOps_Scheduling_Time_Dependent_Capabilities
---

# Using time-dependent capabilities

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.9 and MediaOps version 1.4.1.

## Prerequisites

- A DataMiner System using DataMiner 10.5.5 or higher.
- Access to the **Resource Studio** and **Scheduling** applications.

## Overview

- [Step 1: Create resources](#step-1-create-resources)
- [Step 2: Create and assign a time-dependent capability](#step-2-create-and-assign-a-time-dependent-capability)

## Step 1: Create resources

In this first step, you will create the resource needed for this tutorial.

1. On the **Resource Pools** page of the Resource Studio app, click **+ New**.

1. Enter the name `Antennas` and click *Save as Completed*.

   ![New resource pool](~/solutions/images/Resource_Studio_TDC_New_Resource_Pool.png)

1. Make sure the *Antennas* resource pool is selected in the *Resource Pools* table on the left, and then click *Add* above the table on the right.

1. Enter the name `Antenna 01` and click *Save as Completed*.

1. Repeat the two steps above to also add resources named `Antenna 02`, `Antenna 03`, etc. up to `Antenna 06`.

   ![Add resources to the resource pool](~/solutions/images/Resource_Studio_Add_Antenna_Resources.png)

## Step 2: Create and assign a time-dependent capability

1. Go to the **Capability Management** page.

1. Click **+ New Capability**, and configure the capability as follows:

   1. Specify the name `Satellite`.

   1. Select the **Is Mandatory** and **Is Time-dependent** checkboxes.

   1. Add the following options to represent the possible satellites the antenna can point to:

      - EUT-01
      - EUT-02
      - EUT-03
      - SES-01
      - SES-02
      - SES-03

   ![New resource pool](~/solutions/images/Resource_Studio_TDC_New_Capability.png)

In this tutorial we will see the time-dependent capabilities feature in action by creating a satellite communication system. The system will contain several satellites with steerable 
antennas used for beaming data to the satellites.

Each steerable antenna can only point to one satellite at a time, and this will be modelled as a time-dependent capability.

## Satellite data

Time-dependent capability name: Satellitek
Options:

When using steerable antenna to point towards the satellite and beam the data, it can be used for multiple satellites, but each antenna can point to one satellite at a time.
That is why it is time-dependent.

We can add couple of antennas as resource pools. We can set each antenna to be able to point to a satellite.

## Scheduling

1. Try to book an antenna. Create a new job and select the antenna resource. When configuring it, configure so that the antenna is pointing to a specific satellite.

If we want to swap, others do not work.
