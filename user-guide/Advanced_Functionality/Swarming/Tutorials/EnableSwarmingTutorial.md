---
uid: Swarming_Tutorial_Enable
keywords: swarming, swarming tutorial
---

# Enabling Swarming Tutorial

In this tutorial, you will learn how to enable Swarming in your DMS and swarm your first element.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](https://docs.dataminer.services/user-guide/Cloud_Platform/Connecting_to_cloud/Connecting_your_DataMiner_System_to_the_cloud.html).
- The DataMiner version is 10.5.1/10.6.0[CU0] or higher.
- Swarming has its own set of prerequisites, more on that later during the tutorial.

## Overview

- [Step 1: Deploy the tutorial package from the Catalog](#step-1-deploy-the-tutorial-package-from-the-catalog)
- [Step 2: Create a dummy element](#step-2-create-a-dummy-element)
- [Step 3: Enabling Swarming](#step-3-enabling-swarming)
- [Step 4: Swarming your first element](#step-4-swarming-your-first-element)

## Step 1: Deploy the tutorial package from the Catalog

To deploy the package:

1. Go to the [Kata Swarming package](https://catalog.dataminer.services/details/b087dd80-8a62-4ef0-9321-76964ac4e039) in the DataMiner Catalog.

1. Deploy the latest version of the package on your DMA using the *Deploy* button.

    While the package is being deployed, you can follow the progress of the deployment in the [Admin app](xref:Accessing_the_Admin_app), on the *Deployments* page for your DMS. Make sure to use the *Refresh* button in the top-left corner.

    The package will deploy the following components:

    - The **Mask Critical Alarms** Automation script, which is a demo script to mask the critical alarms of some elements.

    - The **Enable Swarming** Automation script, which is an interactive automation script to go through the enabling procedure for Swarming.

    Both scripts can be found under the **Kata - Swarming** folder.

## Step 2: Create a dummy element

In this tutorial we will Swarm an element.
To not impact any ongoing operation, you can create a new basic element.

## Step 3: Enabling Swarming

Swarming has its own set of prerequisites.
You can use the **Enable Swarming** script deployed with the Catalog package to go through them dynamically.

1. Static requirements:

   Launch the script for the first time and it will quickly verify the static requirements.
   These are requirements not easily changed in your DMS such as database type or failover configuration.

   ![Static requirements](~/user-guide/images/Swarming_Tutorial_Enable_Static_Requirements.png)

   You will see the status for your DMS and which requirements are met.
   If not all requirements are met, you will not be able to enable Swarming.
   If you are using a Skyline protocol for enhanced services, you will need to update it to use the latest version.

1. AlarmID usage:

   Once the static requirements are met, we can move on to the AlarmID usage.
   This section will automatically appear when above requirements are met.
   The AlarmID usage refers to the unique identifier of alarms and their usage in scripting (Automation/QActions).

   ![AlarmID Usage](~/user-guide/images/Swarming_Tutorial_Enable_AlarmID_Usage.png)

   In order for Swarming to work, this identifier has been updated which is a breaking change.
   To prevent possible issues as much as possible, there is a check to analyze your scripts automatically for problems.
   This is not perfect and does not scan everything but will already catch some obvious problems.

   Press the **Analyze** and wait for a bit until the results appear. This can take a while, up to several minutes depending on how many scripts and protocols you have.

   ![AlarmID Usage Problem](~/user-guide/images/Swarming_Tutorial_Enable_AlarmID_Usage_Problem.png)

   After analysis is done, the **Mask Critical Alarms** script should appear as one of the found problems.
   This script takes as input a reference to an element and will mask all critical alarms of this element.
   It does so by using a **SetAlarmStateMessage** and includes an identifier reference to the alarm it should mask.
   This identifier still uses the old style of **DataMinerID/AlarmID** integer combination. This is no longer correct and will need a **TreeID** instead.
   If you were to open this script via DIS in Visual Studio, you would see the obsolete warnings.

   Update the code in the foreach block (Line 85) as follows:

    ```csharp
        var maskRequest = new SetAlarmStateMessage(alarm.TreeID, AlarmUserStatus.Mask, "");
        maskRequests.Add(maskRequest);
    ```

   Press the **validate** button to see if all warnings and errors are gone.

   ![AlarmID Usage Problem Fix](~/user-guide/images/Swarming_Tutorial_Enable_AlarmID_Usage_Problem_Fix.png)

   If any other scripts or protocols appear, this will also need an update.
   There will always be an overload or constructor you can use instead, which will refer to the **TreeID** or **AlarmTreeID**.

   Please verify any updated script or protocol still works.

1. Enabling Swarming

   Once the static requirements are met and there are no AlarmID usage problems detected. A button will appear that you can enable Swarming.
   Pressing this button will send the enable command to your DMS and will **restart the whole DMS**. Afterwards, Swarming will be enabled.

   ![AlarmID Usage Problem Fix](~/user-guide/images/Swarming_Tutorial_Enable_No_Problems.png)

## Step 4: Swarming your first element

Now it's time to swarm your first element.
In general, Swarming means moving the functionality from one host to another host in the same cluster.

For elements this is more or less equivalent with a full element restart, but the stop and start are executed on different hosts.
Swarming elements is possible via the DataMiner Cube client as well as an automation API.

To swarm elements in DataMiner Cube:

1. Go to *System Center* > *Agents* > *Status* and click the *Swarm* button in the lower right corner.

    If you do not see any *Swarm* button here, this means you are not in a cluster environment and working with a single agent. As you cannot swarm to another host, this button is not present.

    If you see a *Migrate* button here instead, this means Swarming was not successfully enabled. If you open this window, you will be using the DELT Export + Import flow instead.

1. On the left, select the element(s) you want to swarm.

1. On the right, select the destination DMA.

1. Click *Swarm*.

For more details about Swarming elements, see the [docs](xref:SwarmingElements).
