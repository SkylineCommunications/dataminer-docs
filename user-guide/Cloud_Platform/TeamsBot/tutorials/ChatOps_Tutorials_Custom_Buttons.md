---
uid: ChatOps_Tutorials_Custom_Buttons
---

# Adaptive Card notifications with custom buttons

This tutorial, which follows [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification), shows you how to use buttons in Adaptive Card notifications (or custom command responses) to enable powerful two-way interactions.

Estimated duration: 15 minutes.

## Prerequisites

- [A DataMiner System connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- [The latest version of the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions)
- [Admin consent has been granted](xref:Granting_admin_consent) in the [Admin app](https://admin.dataminer.services)

## Overview

- [Step 1: Follow the chat notifications tutorial](#step-1-follow-the-chat-notifications-tutorial)
- [Step 2: Deploy the CustomCommand Examples package from the Catalog and configure the scripts](#step-2-deploy-the-customcommand-examples-package-from-the-catalog-and-configure-the-scripts)
- [Step 3: Fetch the Teams and channels of a Team](#step-3-fetch-the-teams-and-channels-of-a-team)
- [Step 4: Adjust the existing Correlation rule triggered by a specific alarm to send a channel notification with custom buttons in an Adaptive Card instead](#step-4-adjust-the-existing-correlation-rule-triggered-by-a-specific-alarm-to-send-a-channel-notification-with-custom-buttons-in-an-adaptive-card-instead)
- [Step 5: Use the custom buttons from the notification](#step-5-use-the-custom-buttons-from-the-notification)

## Step 1: Follow the chat notifications tutorial

1. Go to [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification), and follow the tutorial.

## Step 2: Deploy the CustomCommand Examples package from the Catalog and configure the scripts

In step 5, you will trigger a custom command from this package with a button added to an Adaptive Card notification, so deploy the package first.To learn more about it, see its [README file](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/CustomCommandExamples/README.md).

1. Go to <https://catalog.dataminer.services/details/package/5863>.

   ![CustomCommand Examples page in Catalog](~/user-guide/images/chatops_notification_part_02_02_001.png)

1. Click *Deploy*, and select the target DMS.

1. Verify that the package was installed correctly by accessing the scripts in DataMiner Cube.

   ![CustomCommand Examples scripts](~/user-guide/images/chatops_notification_part_02_02_002.png)

   ![Take Ownership of Alarm CustomCommand Example script](~/user-guide/images/chatops_notification_part_02_02_003.png)

1. Find your system's IDs in the URL by opening the DMS overview in the [Admin app](https://admin.dataminer.services). Use the top-right organization selector to pick your organization, and the left-side menu to select your DMS.

   ![How to find IDs in the Admin app](~/user-guide/images/chatops_notification_part_02_02_004.gif)

1. Fill in the organization ID '*organizationId*' and the DMS ID '*dmsId*' in the *Take Ownership of Alarm* script.

   ![How to fill in the IDs in the Take Ownership of Alarm CustomCommand Example script](~/user-guide/images/chatops_notification_part_02_02_005.gif)

   ![Take Ownership of Alarm CustomCommand Example script with IDs filled in](~/user-guide/images/chatops_notification_part_02_02_006.png)

1. Fill in the organization ID '*organizationId*' and the DMS ID '*dmsId*' in the *Send Channel Notification Asking To Take Ownership of an Alarm* script.

## Step 3: Fetch the Teams and channels of a Team

In step 4, you will send a notification in a channel instead of a chat, so you first need to fetch the Teams and the Channels of a Team. Create new ones if you do not have any.

1. Execute the *Fetch Teams Example* script, or create a new one using *Create Team Example*.

1. Verify that an entry was added in the *TeamsExample* memory file that contains the Team IDs.

1. Execute the *Fetch Channels Example* script with a Team of choice, or create a new channel with *Create Channel Example*.

1. Verify that an entry was added in the *ChannelsExample* memory file that contains the Channel IDs.

1. Execute the *Send Channel Notification Example* script, select the same Team and a channel of choice, and configure the notification you want to send.

1. Verify that the notification is received in the channel on Microsoft Teams.

## Step 4: Adjust the existing Correlation rule triggered by a specific alarm to send a channel notification with custom buttons in an Adaptive Card instead

1. Adjust the Correlation rule from [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification#step-3-configure-a-correlation-rule-triggered-by-a-specific-alarm-to-send-the-chat-notification) you configured earlier so it will execute the *Send Channel Notification Asking To Take Ownership of an Alarm* script instead, and configure the inputs with the Team and channel of that Team that we fetched in step 3.

   ![Configure the Correlation rule](~/user-guide/images/chatops_notification_part_02_04_001.png)

   ![Configure the Correlation rule with the *Send Channel Notification Asking To Take Ownership of an Alarm* script](~/user-guide/images/chatops_notification_part_02_04_002.png)

1. Trigger an alarm, and verify that the notification is received in the channel.

   ![The *Send Channel Notification Asking To Take Ownership of an Alarm* notification received in the channel](~/user-guide/images/chatops_notification_part_02_04_003.png)

## Step 5: Use the custom buttons from the notification

1. The notification received in the channel contains a few buttons. Try them!

   - **Take ownership**: Executes the *Take Ownership of Alarm* custom command that we installed in step 2.
   - Show [element name]: Makes the DataMiner bot show more information on the element.
   - Show all alarms on [element name]: Makes the DataMiner bot show all alarms of the element, if any.

   ![Use the custom button of the Adaptive Card and Take Ownership of the alarm as an example](~/user-guide/images/chatops_notification_part_02_05_001.gif)

The *Take ownership* custom command enables you to easily interact with the notification. The response of the custom command can contain an adaptive card with buttons again, which enables you to create user flows, while at the same time it can also still send a notification in another channel or private chat. Taking leverage of this functionality quickly becomes very powerful.
