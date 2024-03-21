---
uid: ChatOps_Tutorials_Custom_Buttons
---

# Adaptive Card notifications with custom buttons

This tutorial, as a follow up on [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification), shows you how to use buttons in Adaptive Card notifications (or custom command responses) to enable powerful two-way interactions. 

Estimated duration: 15 minutes.

> [!TIP]
> See also: [Kata #63: Custom ChatOps operator: two-way interactions using buttons in Adaptive Cards](https://community.dataminer.services/courses/kata-63/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- [A DataMiner System connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- [The latest version of the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions)
- [Admin consent has been granted](xref:Granting_admin_consent) in the [Admin app](https://admin.dataminer.services)

## Overview

- [Step 1: Make sure you followed the Chat notifications tutorial](#step-1-follow-the-chat-notifications-tutorial)
- [Step 2: Deploy the CustomCommand Examples package from the Catalog](#step-2-deploy-the-customcommand-examples-package-from-the-catalog)
- [Step 3: Fetch the Teams and channels of a Team](#step-3-fetch-the-teams-and-channels-of-a-team)
- [Step 4: Adjust the existing Correlation rule triggered by a specific alarm to send a channel notification with custom buttons in an Adaptive Card instead](#step-4-adjust-the-existing-correlation-rule-triggered-by-a-specific-alarm-to-send-a-channel-notification-with-custom-buttons-in-an-adaptive-card-instead)
- [Step 5: Use the custom buttons from the notification](#step-5-use-the-custom-buttons-from-the-notifications)

## Step 1: Follow the chat notifications tutorial

1. Browse to [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification) and follow the tutorial as we follow up on that one from here.

## Step 2: Deploy the CustomCommand Examples package from the Catalog

In step 5 we will trigger a custom command from this package with a button that we added to an Adaptive Card notification, so we need to deploy this package first.

1. Browse to <https://catalog.dataminer.services/details/package/5863>.

   ![CustomCommand Examples page in Catalog](~/user-guide/images/chatops_notification_01_001.png)

1. Click *Deploy* and choose your target DMS.

1. Verify that the package was correctly installed by accessing the scripts in DataMiner Cube.

   ![CustomCommand Examples scripts](~/user-guide/images/chatops_notification_01_002.png)

1. Make sure that you fill in the organization ID and DMS ID in the *Take Ownership of Alarm* script. You can find these IDs in the URL by opening the DMS overview in the [Admin app](https://admin.dataminer.services). An example is provided in the Automation script.

## Step 3: Fetch the Teams and channels of a Team

   In step 4 we will send a notification in a channel instead of a chat, so we need to fetch the Teams, and the Channels of a Team on beforehand or create new ones.

1. Execute the *Fetch Teams Example* script, or create a new one using *Create Team Example*.

   ![ChatIntegration Examples Fetch Teams](~/user-guide/images/chatops_notification_02_001.png)

1. Verify that an entry was added in the *TeamsExample* memory file containing the Team IDs.

   ![ChatIntegration Examples TeamsExample Memory file](~/user-guide/images/chatops_notification_02_002.png)

1. Execute the *Fetch Channels Example* script with a Team of choice, or create a new channel with *Create Channel Example*.

   ![ChatIntegration Examples Fetch Channels](~/user-guide/images/chatops_notification_02_001.png)

1. Verify that an entry was added in the *ChannelsExample* memory file containing the Channel IDs.

   ![ChatIntegration Examples ChannelsExample Memory file](~/user-guide/images/chatops_notification_02_002.png)

1. Execute the *Send Channel Notification Example* script, select the same Team and a channel of choice, and configure a notification of choice you want to send.

   ![ChatIntegration Examples Send Channel Notification](~/user-guide/images/chatops_notification_02_003.png)

1. Verify if the notification is received in the channel.

   ![ChatIntegration Examples Send Channel Notification](~/user-guide/images/chatops_notification_02_003.png)

## Step 4: Adjust the existing Correlation rule triggered by a specific alarm to send a channel notification with custom buttons in an Adaptive Card

1. Adjust the earlier configured Correlation rule from [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification#step-3-configure-a-correlation-rule-triggered-by-a-specific-alarm-to-send-the-chat-notification) so it will execute the *Send Channel Notification Asking To Take Ownership of an Alarm* script instead and configure the inputs with the Team and channel of that Team that we fetched before in step 3. 

   ![ChatIntegration Examples Correlation Rule](~/user-guide/images/chatops_notification_03_001.png)

   ![ChatIntegration Examples Correlation Rule script](~/user-guide/images/chatops_notification_03_002.png)

1. Trigger an alarm and verify that the notification is received in the channel.

   ![ChatIntegration Examples Teams chat](~/user-guide/images/chatops_notification_03_003.png)

## Step 5: Use the custom buttons from the notification

1. The notification received in the channel contains a few buttons, try them out!

   - **Take ownership**: This button will execute the *Take Ownership of Alarm* custom command that we installed in step 2.
   - Show [element name]: This button will make the DataMiner bot show more information on the element.
   - Show all alarms on [element name]: This button will make the DataMiner bot show all alarms of the element, if any.

   ![ChatIntegration Examples Teams chat](~/user-guide/images/chatops_notification_03_003.png)

1. As you noticed, the *Take ownership* custom command enables you to easily interact with the notification. The response of the custom command can contain an adaptive card with buttons again, which enables you to create user flows, while at the same time it can also still send a notification in another channel or private chat. Taking leverage of this functionality quickly becomes very powerful.
