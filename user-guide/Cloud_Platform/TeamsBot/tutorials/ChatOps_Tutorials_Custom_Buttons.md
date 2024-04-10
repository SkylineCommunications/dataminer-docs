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
- [Step 2: Deploy the Custom Command Examples package from the Catalog and configure the scripts](#step-2-deploy-the-custom-command-examples-package-from-the-catalog-and-configure-the-scripts)
- [Step 3: Fetch the teams and the channels of a team](#step-3-fetch-the-teams-and-the-channels-of-a-team)
- [Step 4: Adjust the existing Correlation rule triggered by a specific alarm to send a channel notification with custom buttons in an Adaptive Card](#step-4-adjust-the-existing-correlation-rule-triggered-by-a-specific-alarm-to-send-a-channel-notification-with-custom-buttons-in-an-adaptive-card)
- [Step 5: Use the custom buttons from the notification](#step-5-use-the-custom-buttons-from-the-notification)

## Step 1: Follow the chat notifications tutorial

1. Go to [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification), and follow the tutorial.

## Step 2: Deploy the Custom Command Examples package from the Catalog and configure the scripts

In step 5, you will trigger a custom command from this package with a button added to an Adaptive Card notification, so deploy the package first.To learn more about it, see its [README file](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/CustomCommandExamples/README.md).

1. Go to <https://catalog.dataminer.services/details/package/5863>.

   ![Custom Command Examples page in Catalog](~/user-guide/images/chatops_notification_part_02_02_001.png)

1. Click *Deploy*, and select the target DMS.

1. Verify that the package was installed correctly by accessing the scripts in DataMiner Cube.

   ![Custom Command Examples scripts](~/user-guide/images/chatops_notification_part_02_02_002.png)

   ![Take Ownership of Alarm CustomCommand Example script](~/user-guide/images/chatops_notification_part_02_02_003.png)

1. Go to the [Admin app](https://admin.dataminer.services), open the DMS overview, and copy the URL (which contains your system's organization ID and DMS ID). If necessary, use the top-right organization selector to pick your organization, and the left-side menu to select your DMS.

   ![How to find IDs in the Admin app](~/user-guide/images/chatops_notification_part_02_02_004.gif)

1. In the *Take Ownership of Alarm* script, enter the organization ID '*organizationId*' and the DMS ID '*dmsId*' in the following lines:

   ```csharp
   var organizationId = Guid.Parse("");
   var dmsId = Guid.Parse("");
   ```

   ![How to fill in the IDs in the Take Ownership of Alarm CustomCommand Example script](~/user-guide/images/chatops_notification_part_02_02_005.gif)

   ![Take Ownership of Alarm CustomCommand Example script with IDs filled in](~/user-guide/images/chatops_notification_part_02_02_006.png)

1. Fill in the organization ID '*organizationId*' and the DMS ID '*dmsId*' in the *Send Channel Notification Asking To Take Ownership of an Alarm* script.

   ```csharp
   var organizationId = Guid.Parse("");
   var dmsId = Guid.Parse("");
   ```

## Step 3: Fetch the teams and the channels of a team

In step 4, you will send a notification in a channel instead of a chat, so you first need to fetch the teams and the channels of a team. Create new ones if you do not have any yet.

1. To fetch the existing teams, execute the *Fetch Teams Example* script. Select the memory file in which the teams should be stored (*TeamsExample*), and click *Execute now*.

   If you want to create a new team, execute the *Create Team Example* script instead.

1. Click *Close* to exit the *Fetch Teams Example* window.

1. Verify that the teams were added to the *TeamsExample* memory file.

1. To fetch the channels of a specific team, execute the *Fetch Channels Example* script. Select the team and the memory file in which the channels of that team should be stored (*ChannelsExample*), and click *Execute now*.

   If you want to create a new channel, execute the *Create Channel Example* script instead.

1. Click *Close* to exit the *Fetch Channels Example* window.

1. Verify that the channels were added to the *ChannelsExample* memory file.

1. Execute the *Send Channel Notification Example* script. Select the team and the channel, enter the notification you want to send, and click *Execute now*.

1. Click *Close* to exit the *Send Channel Notification Example* window.

1. Verify that the notification was received in the specified Microsoft Teams channel.

## Step 4: Adjust the existing Correlation rule triggered by a specific alarm to send a channel notification with custom buttons in an Adaptive Card

1. Adjust the Correlation rule from [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification#step-4-configure-a-correlation-rule-triggered-by-a-specific-alarm-to-send-the-chat-notification) you configured earlier so it will execute the *Send Channel Notification Asking To Take Ownership of an Alarm* script instead. Make sure to specify the team and channel used in step 3 as input.

   ![Configure the Correlation rule](~/user-guide/images/chatops_notification_part_02_04_001.png)

   ![Configure the Correlation rule with the *Send Channel Notification Asking To Take Ownership of an Alarm* script](~/user-guide/images/chatops_notification_part_02_04_002.png)

1. Trigger an alarm, and verify that the notification is received in the channel.

   ![The *Send Channel Notification Asking To Take Ownership of an Alarm* notification received in the channel](~/user-guide/images/chatops_notification_part_02_04_003.png)

## Step 5: Use the custom buttons from the notification

1. The notification received in the channel contains a few buttons. Try them!

   - **Take ownership**: Executes the custom *Take Ownership of Alarm* command that you configured in step 2.

     The custom *Take ownership* command enables you to easily interact with the notification. The response of the custom command can again contain an adaptive card with buttons. This enables you to create user flows, while a notification can still be sent in another channel or private chat. This functionality offers a multitude of possibilities.

   - Show [element name]: Makes the DataMiner bot show more information about the element in question.
   - Show all alarms on [element name]: Makes the DataMiner bot show all alarms associated with the element in question (if any).

   ![Use the custom button of the Adaptive Card and Take Ownership of the alarm as an example](~/user-guide/images/chatops_notification_part_02_05_001.gif)
