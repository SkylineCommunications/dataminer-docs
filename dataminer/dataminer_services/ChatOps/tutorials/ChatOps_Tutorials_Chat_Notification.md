---
uid: ChatOps_Tutorials_Chat_Notification
reviewer: Alexander Verkest
---

# Chat notifications

This tutorial shows you how you can use the Chat Integration examples to send notifications from your DataMiner System to Microsoft Teams.

Estimated duration: 15 minutes.

> [!TIP]
> See also: [Kata #6: Custom ChatOps operator](https://community.dataminer.services/courses/kata-6/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- [A DataMiner System connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- [The latest version of the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions)
- [Admin consent has been granted](xref:Granting_admin_consent) in the [Admin app](https://admin.dataminer.services)

## Overview

- [Step 1: Add the DataMiner app to Microsoft Teams](#step-1-add-the-dataminer-app-to-microsoft-teams)
- [Step 2: Deploy the ChatIntegration Examples package from the Catalog](#step-2-deploy-the-chat-integration-examples-package-from-the-catalog)
- [Step 3: Fetch the private chat for a user and send a notification](#step-3-fetch-the-private-chat-for-a-user-and-send-a-notification)
- [Step 4: Configure a Correlation rule triggered by a specific alarm to send the chat notification](#step-4-configure-a-correlation-rule-triggered-by-a-specific-alarm-to-send-the-chat-notification)

## Step 1: Add the DataMiner app to Microsoft Teams

If you have not yet installed the DataMiner Teams bot, follow the steps below. Otherwise, you can skip this step.

1. In *Microsoft Teams*, go to *Apps*, and search for "DataMiner".

1. Add the *DataMiner* app.

> [!TIP]
> For more detailed information, see [DataMiner Teams bot installation](xref:DataMiner_Teams_bot#dataminer-teams-bot-installation)

## Step 2: Deploy the Chat Integration Examples package from the Catalog

> [!NOTE]
> To learn more about this package, refer to its [README file](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md).

1. Go to <https://catalog.dataminer.services/details/package/5860>.

   ![ChatIntegration Examples page in Catalog](~/dataminer/images/chatops_notification_01_001.png)

1. Click *Deploy* and choose your target DMS.

1. Verify that the package has been installed correctly by accessing the scripts in the Automation module in DataMiner Cube.

   ![ChatIntegration Examples scripts](~/dataminer/images/chatops_notification_01_002.png)

## Step 3: Fetch the private chat for a user and send a notification

1. In the Automation module, select the *Fetch Private Chat Example* script, and click *Execute*.

1. Specify the email address of the user and click *Execute now*.

   ![ChatIntegration Examples Fetch Private Chat](~/dataminer/images/chatops_notification_02_001.png)

1. Click *Close* to exit the *Fetch Private Chat Example* window.

1. Verify that an entry has been added in the *ChatsExample* memory file containing the private chat ID.

   ![ChatIntegration Examples ChatsExample Memory file](~/dataminer/images/chatops_notification_02_002.png)

1. Select the *Send Chat Notification Example* script, and click *Execute*.

1. Select the chat ID, enter the notification you want to send, and click *Execute now*.

   ![ChatIntegration Examples Send Chat Notification](~/dataminer/images/chatops_notification_02_003.png)

1. Click *Close* to exit the *Send Chat Notification Example* window.

1. Verify that the notification has been received in the DataMiner chat.

## Step 4: Configure a Correlation rule triggered by a specific alarm to send the chat notification

1. Configure a Correlation rule so it will be triggered by a specific alarm and will execute the *Send Chat Notification Example* script.

   ![ChatIntegration Examples Correlation Rule](~/dataminer/images/chatops_notification_03_001.png)

   ![ChatIntegration Examples Correlation Rule script](~/dataminer/images/chatops_notification_03_002.png)

1. Trigger an alarm and verify that the notification is received in a Teams chat.

   ![ChatIntegration Examples Teams chat](~/dataminer/images/chatops_notification_03_003.png)

> [!TIP]
> If you are ready for more, continue with the tutorial [Adaptive Card notifications with custom buttons](xref:ChatOps_Tutorials_Custom_Buttons). This is a slightly more advanced tutorial where you will learn how to enable powerful two-way interactions using buttons with custom commands.
