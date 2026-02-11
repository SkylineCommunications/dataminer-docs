---
uid: ChatOps_Tutorials_Custom_Buttons
reviewer: Alexander Verkest
---

# Adaptive Card notifications with custom buttons

This tutorial, which comes after the [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification) tutorial, shows you how to use buttons in Adaptive Card notifications (or custom command responses) to enable powerful two-way interactions.

Estimated duration: 15 minutes.

> [!TIP]
> See also: [Kata #27: Custom ChatOps Operator: Use buttons in Adaptive Cards](https://community.dataminer.services/courses/kata-27/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- [A DataMiner System connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- [The latest version of the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions)
- [Admin consent has been granted](xref:Granting_admin_consent) in the [Admin app](https://admin.dataminer.services)

## Overview

- [Step 1: Follow the chat notifications tutorial](#step-1-follow-the-chat-notifications-tutorial)
- [Step 2: Deploy the Custom Command Examples package from the Catalog](#step-2-deploy-the-custom-command-examples-package-from-the-catalog)
- [Step 3: Fetch the teams and the channels of a team](#step-3-fetch-the-teams-and-the-channels-of-a-team)
- [Step 4: Adjust the chat notification Correlation rule to send a notification with custom buttons](#step-4-adjust-the-chat-notification-correlation-rule-to-send-a-notification-with-custom-buttons)
- [Step 5: Use the custom buttons from the notification](#step-5-use-the-custom-buttons-from-the-notification)

## Step 1: Follow the chat notifications tutorial

If you have not yet done so, go to [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification) and follow the tutorial. Otherwise, you can skip this step.

## Step 2: Deploy the Custom Command Examples package from the Catalog

Later in this tutorial, you will trigger a custom command from the *Custom Command Examples* package with a button added to an Adaptive Card notification. To make this possible, this package first needs to be deployed.

> [!NOTE]
> To learn more about this package, refer to its [README file](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/CustomCommandExamples/README.md).

1. Look up the [Custom Command Examples](https://catalog.dataminer.services/details/9405093d-bbcf-45cf-88bb-c9207644346b) package in the Catalog.

   ![Custom Command Examples page in Catalog](~/dataminer/images/chatops_notification_part_02_02_001.png)

1. Click *Deploy*, and select the target DMS.

1. Verify that the package has been installed correctly by accessing the scripts in the Automation module in DataMiner Cube.

   You should see the scripts illustrated below:

   ![Custom Command Examples scripts](~/dataminer/images/chatops_notification_part_02_02_002.png)

   ![Take Ownership of Alarm CustomCommand Example script](~/dataminer/images/chatops_notification_part_02_02_003.png)

## Step 3: Fetch the teams and the channels of a team

To be able to send a notification in a channel later in this tutorial, you will first need to fetch the teams and the channels of a team, or create new ones if you do not have any yet.

1. In DataMiner Cube, open the Automation module.

1. Fetch or create the teams:

   - To fetch the existing teams:

     1. Execute the *Fetch Teams Example* script.

     1. In the *Teams* box, select the memory file where the teams should be stored (*TeamsExample*).

     1. Click *Execute now*.

     1. Click *Close* to exit the *Fetch Teams Example* window.

   - To create a new team:

     1. Execute the *Create Team Example* script.

     1. Specify the email address of the team owner, the name of the team, and the memory file where the team should be stored (*TeamsExample*).

     1. Click *Execute now*.

     1. Click *Close* to exit the *Create Team Example* window.

1. Go to the *memory files* tab and verify that the *TeamsExample* memory file has been updated accordingly.

1. Fetch the channels of a team or create a new channel:

   - To fetch the existing channels:

     1. Execute the *Fetch Channels Example* script.

     1. Select the team and the memory file where the channels of that team should be stored (*ChannelsExample*).

     1. Click *Execute now*.

     1. Click *Close* to exit the *Fetch Channels Example* window.

   - To create a new channel:

     1. Execute the *Create Channel Example* script.

     1. In the *Team ID* box, select the ID of the team where the channel should be added.

     1. Specify the name and description for the new channel.

     1. In the *Channels* box, select the memory file where the channel should be stored (*ChannelsExample*).

     1. Click *Close* to exit the *Create Channel Example* window.

1. Go to the *memory files* tab and verify that the *ChannelsExample* memory file has been updated accordingly.

1. Send a notification to a channel:

   1. Execute the *Send Channel Notification Example* script.

   1. Select the team and the channel, enter the notification you want to send, and click *Execute now*.

   1. Click *Close* to exit the *Send Channel Notification Example* window.

1. Go to the Microsoft Teams channel you specified, and check whether the notification is displayed.

## Step 4: Adjust the chat notification correlation rule to send a notification with custom buttons

In this step, you will adjust the Correlation rule from the [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification#step-4-configure-a-correlation-rule-triggered-by-a-specific-alarm-to-send-the-chat-notification) tutorial so that it sends a channel notification with custom buttons in an Adaptive Card when it is triggered by a specific alarm.

1. In DataMiner Cube, open the Correlation module.

1. Select the Correlation rule you created during the [Chat notifications](xref:ChatOps_Tutorials_Chat_Notification#step-4-configure-a-correlation-rule-triggered-by-a-specific-alarm-to-send-the-chat-notification) tutorial.

1. In the *Run script* action of the rule, select the script *Send Channel Notification Asking To Take Ownership of an Alarm* instead, and specify the team and channel from [step 3](#step-3-fetch-the-teams-and-the-channels-of-a-team) as input.

   ![Configure the Correlation rule](~/dataminer/images/chatops_notification_part_02_04_001.png)

   ![Configure the Correlation rule with the *Send Channel Notification Asking To Take Ownership of an Alarm* script](~/dataminer/images/chatops_notification_part_02_04_002.png)

1. Trigger an alarm that will trigger the Correlation rule.

1. Go to the Microsoft Teams channel you specified, and check whether the notification is displayed.

   For example:

   ![The *Send Channel Notification Asking To Take Ownership of an Alarm* notification received in the channel](~/dataminer/images/chatops_notification_part_02_04_003.png)

## Step 5: Use the custom buttons from the notification

The notification in the channel contains a few buttons. Give them a try:

- **Take ownership**: Executes the custom *Take Ownership of Alarm* command from the Custom Command Examples package.

  With such commands, you can easily interact with the notification. The response of the custom command can again contain an adaptive card with buttons. This enables you to create user flows, while a notification can still be sent in another channel or private chat. This functionality offers a multitude of possibilities.

- **Show *[element name]***: Makes the DataMiner bot show more information about the element in question.

- **Show all alarms on *[element name]***: Makes the DataMiner bot show any alarms associated with the element in question.

![Use the custom button of the Adaptive Card and Take Ownership of the alarm as an example](~/dataminer/images/chatops_notification_part_02_05_001.gif)
