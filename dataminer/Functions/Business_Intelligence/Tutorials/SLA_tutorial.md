---
uid: SLA_tutorial
---

# Using an SLA to monitor a power service

In this tutorial, you will learn how to configure and use a Service Level Agreement (SLA) to monitor a power service. The steps include creating an SLA using an existing service as a starting point and customizing SLA parameters to track service metrics for high availability compliance.

Additionally, you will learn how to configure an alarm template to monitor and visualize alarms for city streets affected by power service degradation.

Expected duration: 20 minutes

> [!TIP]
> See also:
>
> - [Business intelligence](xref:sla)
> - [Connector documentation: Skyline SLA Definition Basic](https://docs.dataminer.services/connector/doc/Skyline_SLA_Definition_Basic.html)
> - [Services](xref:About_services)
> - [Alarm templates](xref:About_alarm_templates)
> - [Kata #36: Manage and monitor your Service Level Agreements](https://community.dataminer.services/courses/kata-36/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.7.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the DataMiner SLA tutorial package from the Catalog](#step-1-deploy-the-dataminer-sla-tutorial-package-from-the-catalog)
- [Step 2: Create a new SLA](#step-2-create-a-new-sla)
- [Step 3: Configure your new SLA](#step-3-configure-your-new-sla)
- [Step 4: Assign and modify an alarm template](#step-4-assign-and-modify-an-alarm-template)
- [Step 5: Analyze the SLA metrics](#step-5-analyze-the-sla-metrics)

## Step 1: Deploy the *DataMiner SLA tutorial* package from the Catalog

1. Go to <https://catalog.dataminer.services/details/ac72d9e5-4c12-4408-a591-2fc2316abebf>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check whether the following items have been added to your DataMiner Agent:

   - A view named "DataMiner SLA tutorial" (1)

   - An element named "Power Monitoring - Miami" (2)

   - A service named "Power Service - South Beach" (3)

   ![DataMiner SLA tutorial](~/dataminer/images/DataMiner_SLA_Tutorial.png)

   If this is the case, the package has been successfully deployed.

   On the *Data* > *Table* page of the element, you will see that the *Street Overview* and *Power Parameters* tables contain pre-provisioned data:

   ![Street Overview and Power Parameters tables](~/dataminer/images/SLA_tutorial_img00.png)

    On the *Data* > *Power Monitoring - Miami* > *Table* page of the service, you will see that the *Power Parameters* table already contains two entries.

    ![Service power parameters](~/dataminer/images/SLA_tutorial_img01.png)

## Step 2: Create a new SLA

Now that you have installed the *DataMiner SLA tutorial* package, you will create a new Service Level Agreement (SLA).

1. In the Surveyor, right-click the *DataMiner SLA tutorial* view and select *New* > *SLA*.

   ![Create SLA](~/dataminer/images/SLA_tutorial_img02.png)

   A card will open.

1. Specify the following information:

   - *Name*: `Power SLA - South Beach`

   - *Service*: `Power Service - South Beach`

   - *Protocol*: `Skyline SLA Definition Basic`

   - *Version*: Production

   ![New SLA screen](~/dataminer/images/SLA_tutorial_img03.png)

1. Click *Create* to add the SLA.

## Step 3: Configure your new SLA

In this step, you will configure different data pages of your newly created SLA.

1. Navigate to the *Data* > *SLA Configuration* page of your SLA.

1. Configure the following parameters:

   - **Window settings**

     - *Type*: Fixed window

     - *Time*: 1

     - *Unit*: Minutes

   - **Alarm settings**

     - *Violation Level*: Warning

     - *Delay Time*: Not used

     - *Minimum outage threshold*: Full outage

   - **Extra settings**

     - *Admin State*: Tracking

     - *Base Timestamp*: 2001/01/01 00:00:00

     - *Time To Keep Outages*: 1 Month

     - *SLA Validity Start Time*: Since creation

     - *SLA Validity End Time*: Forever

   > [!TIP]
   > To save all changes simultaneously, click *Save all* in the lower-right corner.

   ![SLA configuration](~/dataminer/images/SLA_tutorial_img04.png)

1. Navigate to the *Data* > *Compliance Configuration* page of your SLA.

1. Configure the following parameters:

   - **Total violation**

     - *Maximum Total Violations Type*: Absolute

     - *Maximum Total Violations Value*: 20

     - *Maximum Total Violations Unit*: Seconds

   - **Violation count**

     - *Total Violations Before Breach*: 0

   - **Single violation**

     - *Maximum Single Violation Type*: Absolute

     - *Maximum Single Violation Value*: 5

     - *Maximum Single Violation Unit*: Seconds

   > [!TIP]
   > To save all changes simultaneously, click *Save all* in the lower-right corner.

   ![Compliance configuration](~/dataminer/images/SLA_tutorial_img05.png)

1. Navigate to the *Data* > *Advanced Configuration* page.

1. Configure the following parameters:

   - *Active Alarms*: Show

   - *Outages*: Enabled

   ![Advanced configuration](~/dataminer/images/SLA_tutorial_img06.png)

   > [!IMPORTANT]
   > If you do not see the options to change these parameters, you may not have the sufficient parameter access level. In this case, increase your access level:
   >
   > 1. Click the user icon in the top-right corner of the Cube header bar.
   > 1. Select *System Center* and navigate to *Users/Groups*.
   > 1. Go to the *Groups* tab and select the group in question.
   > 1. Enter "1" in the *Group level* field on the *Details* tab.
   > 1. Click *Apply* in the lower-right corner of the tab.
   > 1. Close Cube and restart it.
   >
   > See also: [Configuring a user group](xref:Configuring_a_user_group)
   >
   > If you do not want to change the access level for the entire group, change your own override level:
   >
   > 1. Navigate to *Users/Groups* > *Users* in System Center.
   > 1. Select the account you used to log in to the DMS.
   > 1. Enter "1" in the *Override level* field on the *Details* tab.
   > 1. Click *Apply* in the lower-right corner of the tab.
   > 1. Close Cube and restart it.

## Step 4: Assign and modify an alarm template

In the next step, you will assign an alarm template to the *Power Monitoring - Miami* element. This alarm template came included in the package you installed in a previous step. However, you will need to modify it.

1. In the Cube sidebar, go to *Apps* > *Protocols & Templates*.

1. Under *Protocols*, select *Skyline Generic Virtual Connector*.

1. Under *Alarm*, right-click *DataMiner SLA tutorial* and select *Open*.

   ![Open DataMiner SLA tutorial alarm template](~/dataminer/images/SLA_tutorial_img07.png)

1. Configure the alarm template:

   1. Under *Table*, set the *Power Parameters: Voltage (V)* parameter to *Included*.

   1. Configure the following alarm thresholds:

      - In the *WARN LO* column, enter `115`.

      - In the *NORMAL* column, enter `120`.

      ![Configure DataMiner SLA tutorial alarm template](~/dataminer/images/SLA_tutorial_img08.png)

   1. Click *Apply* and then *OK*.

1. In the Surveyor, right-click the *Power Monitoring - Miami* element and select *Protocols & Templates* > *Assign alarm template* > *DataMiner SLA tutorial*.

1. Confirm that you want to apply this alarm template.

1. Generate an alarm to verify whether the alarm template was correctly configured.

   1. In the Surveyor, select the *Power Monitoring - Miami* element.

   1. Go to the *DATA* > *Table* page, right-click the *Ocean Drive* entry in the *Power Parameters* table, and select *Edit item*.

   1. Lower the Voltage to 115.

      ![Generate a Voltage alarm](~/dataminer/images/SLA_tutorial_img10.png)

   1. Click *OK*.

   The *Power Parameters* table on the *DATA* > *Table* page of your element will now show an alarm in the *Voltage* column of the *Ocean Drive* entry. In the Alarm Console, you will see an alarm of severity *Warning Low* for the *Power Monitoring - Miami* element.

   ![Voltage alarm](~/dataminer/images/SLA_tutorial_img10.1.png)

## Step 5: Analyze the SLA metrics

In this final step, you will learn how to interpret different SLA metrics.

1. Go to the *DATA* > *Main View* page of the *Power SLA - South Beach* SLA element.

   Under *Compliance Info*, you will see that *Compliance* is now set to *Breached* due to the simulated Voltage alarm.

   ![General SLA metrics](~/dataminer/images/SLA_tutorial_img11.png)

   > [!NOTE]
   > It may take a few seconds before the compliance status changes from *Compliant* to *Breached*.

1. Restore service compliance:

   1. Go to the *DATA* > *Table* page of the *Power Monitoring - Miami* element.

   1. Right-click the *Ocean Drive* entry in the *Power Parameters* table, and select *Edit item*.

   1. Set the Voltage to 120.

   1. Click *OK*.

      The Voltage alarm has now been cleared.

1. Return to the *DATA* > *Main View* page of the *Power SLA - South Beach* SLA element.

   Under *Compliance Info*, the *Compliance* status will now be set to *Compliant*.

   > [!NOTE]
   > It may take a few seconds before the compliance status changes from *Breached* to *Compliant*.

1. Go to the *DATA* > *Outage List* page of the SLA.

   On this page, you will find a history of SLA compliance metrics.

   ![SLA outage list](~/dataminer/images/SLA_tutorial_img12.png)

   ![SLA history statistics](~/dataminer/images/SLA_tutorial_img13.png)

> [!TIP]
> Optionally, explore the other pages of the *Power SLA - South Beach* SLA element such as the *Offline window* and *Violation Configuration* pages.
