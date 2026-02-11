---
uid: Swarming_Tutorial_Enable
keywords: swarming, swarming tutorial
---

# Enabling Swarming

In this tutorial, you will learn how to enable [Swarming](xref:Swarming) in your DMS and swarm your first element. The tutorial makes use of an example automation script to demonstrate how you need to adjust scripts to make sure you can enable Swarming.

The content and screenshots for this tutorial have been created using DataMiner version 10.5.3.

> [!TIP]
> See also: [Kata #61: Getting started with Swarming](https://community.dataminer.services/courses/kata-61/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

For this tutorial, you will need a DataMiner System that meets the following requirements:

- [Connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Using DataMiner 10.5.1/10.6.0 [CU0] or higher.
- Containing two or more Agents, but no Failover Agents. If you are using a single Agent, you can follow along, but you will not be able to do the last step (swarming an element).
- Using [STaaS](xref:STaaS) or a [dedicated clustered storage](xref:Configuring_dedicated_clustered_storage) setup.
- Without [data offloads](xref:Offload_database) configured.
- The [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) is not enabled.

Other prerequisites for Swarming will be addressed later in this tutorial.

## Overview

- [Step 1: Deploy the tutorial package from the Catalog](#step-1-deploy-the-tutorial-package-from-the-catalog)
- [Step 2: Create a basic test element](#step-2-create-a-basic-test-element)
- [Step 3: Create a DataMiner backup (optional)](#step-3-create-a-dataminer-backup-optional)
- [Step 4: Enable Swarming](#step-4-enable-swarming)
- [Step 5: Swarm your first element](#step-5-swarm-your-first-element)

## Step 1: Deploy the tutorial package from the Catalog

To deploy the package:

1. Go to the [Tutorial - Getting started with Swarming](https://catalog.dataminer.services/details/b087dd80-8a62-4ef0-9321-76964ac4e039) package in the Catalog.

1. Deploy the latest version of the package on your DMA using the *Deploy* button.

1. When the package has been deployed, open DataMiner Cube and check whether you can see the following scripts in the *Kata - Swarming* folder of the Automation module:

   - *Mask Critical Alarms*: This is a demo script to mask the critical alarms of an element.

   - *Enable Swarming*: This interactive automation script takes you through the enabling procedure for Swarming.

   ![Package Content](~/dataminer/images/Swarming_Tutorial_Enable_Package_Content.png)

## Step 2: Create a basic test element

In this tutorial, you will swarm an element. To avoid impacting ongoing operations, start by adding a new test element.

You can either [create a new basic test element](xref:Adding_elements) yourself or import a demo element, e.g. by deploying the [Satellite Earth Station Uplink](https://catalog.dataminer.services/details/c8adec4a-e7be-47a4-b7a4-e574e0381fe6) package.

If you choose to create a new element yourself, you can select any protocol of your choice for it, except for a spectrum protocol or a DVE protocol, as these would not result in a swarmable element.

## Step 3: Create a DataMiner backup (optional)

Once you enable Swarming, the element configuration of the DMS will be moved from disk to database, which is a change that cannot easily be rolled back. This is why taking a backup of your DataMiner Agents before you enable Swarming is highly recommended.

For detailed steps, refer to [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent).

## Step 4: Enable Swarming

Swarming has its own set of prerequisites. In this step, you will use a script from the deployed package to make sure these are met and then enable Swarming.

1. In the Automation module in DataMiner Cube, select the *Enable Swarming* script and click the *Execute* button.

   ![Execute the Enable Swarming script](~/dataminer/images/Swarming_Tutorial_Run_script.png)

1. In the pop-up window, click *Execute now*.

   Information about the Swarming prerequisites will be displayed.

1. Take a look at the mentioned static requirements.

   These are the DMS requirements that are more difficult to change, such as the database type or Failover configuration. Based on the prerequisites for this tutorial, all prerequisites should be met, except possibly the requirement for compatible enhanced services.

   ![Static requirements](~/dataminer/images/Swarming_Tutorial_Enable_Static_Requirements.png)

1. In case *No incompatible enhanced services* is *Not Ok*:

   1. Check in the Catalog if a more recent version of the enhanced service connectors is available and upgrade to the latest version if possible.

   1. If upgrading to a more recent version is not possible, follow the instructions to [prepare enhanced service connectors for Swarming](xref:SwarmingPrepare#enhanced-service-connectors)

   1. Run the *Enable Swarming* script again.

1. Click the *Analyze* button to start checking the alarm ID usage.

   This button will only be available once all static requirements are met. It will analyze the use of the unique identifiers of alarms in scripting (automation scripts and QActions), as this has been modified to support Swarming. (See [About the alarm ID changes](xref:SwarmingPrepare#about-the-alarm-id-changes).)

   This check can take up to several minutes, depending on the number of scripts and connectors in the system.

   ![Alarm ID usage](~/dataminer/images/Swarming_Tutorial_Enable_AlarmID_Usage.png)

   > [!NOTE]
   > It is not possible to scan dependencies (e.g. NuGets) with this script, so these may still contain outdated references. However, if this should be the case, running these scripts on a system where Swarming is enabled will throw a clear error message.

1. Take a look at the results of the analysis.

   ![Alarm ID usage problem](~/dataminer/images/Swarming_Tutorial_Enable_AlarmID_Usage_Problem.png)

   The *Mask Critical Alarms* script will be displayed as one of the problems that have been found. This script takes as input a reference to an element and will mask all critical alarms of this element. It does so by using a *SetAlarmStateMessage* and includes an identifier reference to the alarm it should mask, but this identifier still uses the old style of referring to an alarm, i.e. a **DataMiner ID/alarm ID** integer combination. This is must be changed to a **tree ID** instead.

1. Open the *Mask Critical Alarms* script in the Automation app, scroll down, and click *Validate* to check for errors and warnings.

   You will see that a warning is detected.

   ![AlarmID Usage Problem Warning](~/dataminer/images/Swarming_Tutorial_Enable_AlarmID_Usage_Problem_Warning.png)

   Note that you could also open the script via DIS in Visual Studio instead, if you have this installed. In that case, if you target the *Skyline.DataMiner.Dev.Automation* package version 10.5.1 or higher, you will also see an obsolete warning for this script.

1. Update the code in the *foreach* block (line 85) as follows:

   Before:

   ```csharp
      var maskRequest = new SetAlarmStateMessage();
      maskRequest.DataMinerID = alarm.DataMinerID;
      maskRequest.AlarmId = alarm.AlarmID;
      maskRequest.DesiredStatus = AlarmUserStatus.Mask;
      maskRequests.Add(maskRequest);
    ```

   After:

   ```csharp
      var maskRequest = new SetAlarmStateMessage(alarm.TreeID, AlarmUserStatus.Mask, "");
      maskRequests.Add(maskRequest);
   ```

1. Click *Validate* again to see if all warnings and errors are gone.

   ![Alarm ID usage problem fix](~/dataminer/images/Swarming_Tutorial_Enable_AlarmID_Usage_Problem_Fix.png)

1. Click *Execute* to run the script and test if it still works correctly.

1. If any other scripts or protocols are shown in the alarm ID usage summary, update these in a similar way to make sure they refer to the tree ID or alarm tree ID and validate and test them.

   For detailed information, refer to [Preparing scripts and connectors for Swarming](xref:SwarmingPrepare)

1. Run the *Enable Swarming* script again and click the *Analyze* button again.

   If you have indeed correctly updated all scripts and protocols, a new button will be displayed at the bottom of the window. If you do not see this button, check which scripts or protocols still need to be updated and adjust them as mentioned above.

   ![AlarmID Usage Problem Fix](~/dataminer/images/Swarming_Tutorial_Enable_No_Problems.png)

1. Click *Restart DMS and enable Swarming*.

   The script will now double-check the requirements (which will again take some time), enable Swarming, and restart DataMiner.

   > [!IMPORTANT]
   > This will restart all DataMiner Agents in your DMS.

## Step 5: Swarm your first element

Once DataMiner has restarted, you can test the Swarming functionality by moving an element from one host to another host in your DMS. You will only be able to follow these steps if you are using a DataMiner System consisting of multiple Agents.

1. Go to *System Center* > *Agents* > *Status* and click the *Swarm* button in the lower-right corner.

   If you see a *Migrate* button here instead, this means Swarming has not been successfully enabled.

   ![Cube Status](~/dataminer/images/Swarming_Tutorial_Enable_Cube_Status.png)

1. On the left, select the test element you created in [step 2](#step-2-create-a-basic-test-element).

   Note that you can select more elements to swarm if you want, but keep in mind that swarming an element involves an element restart, which will result in a brief downtime of the element.

1. On the right, select the destination DMA.

   ![Cube Swarm](~/dataminer/images/Swarming_Tutorial_Enable_Cube_Swarm.png)

1. Click *Swarm*.

   A message will be displayed when the element has been successfully swarmed:

   ![Cube Success](~/dataminer/images/Swarming_Tutorial_Enable_Cube_Success.png)

> [!TIP]
> For more details about Swarming elements, see [Swarming elements](xref:SwarmingElements).
