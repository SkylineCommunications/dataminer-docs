---
uid: Tutorial_MediaOps_Scheduling_Time_Dependent_Capabilities
---

# Using time dependent capabilities

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.9 and MediaOps version 1.4.1.

## Prerequisites

- A DataMiner System using DataMiner 10.5.5 or higher.
- Access to the **Resource Studio** and **Scheduling** applications.

## Overview

- [Step 1: Create Resources](#step-1-create-resources)
- [Step 2: Create and assign time dependent capability](#step-2-create-and-assign-time-dependent-capability)

## Step 1: Create Resources

First, let's head over to the _Resource studio_ app and create some resources that we're going to need for this tutorial.

1. Create a new resource pool named "Antennas".
    ![New resource pool](~/solutions/images/Resource_Studio_TDC_New_Resource_Pool.png)
    
1. Add several new resources named "Antenna 01", "Antenna 02", etc.

1. _Assign_ these resources to the resource pool you created.

    ![New resource pool](~/solutions/images/Resource_Studio_TDC_Assign_Resources.png)

## Step 2: Create and assign time dependent capability

1. Go to the _Capability Management_ page.

1. Create `Satellite` time dependent capability with the following options, which represent the satellite the antenna is currently pointing to:
    * EUT-01
    * EUT-02
    * EUT-03
    * SES-01
    * SES-02
    * SES-03

    ![New resource pool](~/solutions/images/Resource_Studio_TDC_New_Capability.png)

    > [!NOTE]
    > Make sure to tick the "Is Time-Dependent" box.

In this tutorial we will see the time depentend capabilities feature in action by creating a satellite communication system. The system will contain several satellites with steerable 
antennas used for beaming data to the satellites.

Each steerable antenna can only point to one satellite at a time, and this will be modelled as a time dependent capability.

## Satellite data

Time dependant capability name: Satellitek
Options:

When using steerable antenna to point towards the satellite and beam the data, it can be used for multiple satellites, but each antenna can point to one satellite at a time.
Tha's why it's time dependent.

We can add couple of antennas as resource pools. We can set each antenna to be able to point to a satellite.

## Scheduling

1. Try to book an antenna. Create a new job and select the antenna resource. When configuring it, configure so that the antenna is pointing to a specific satellite.

If we want to swap, others don't work.
