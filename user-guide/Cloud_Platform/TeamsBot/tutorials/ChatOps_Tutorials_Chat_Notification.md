---
uid: ChatOps_Tutorials_Chat_Notification
---

# Chat notifications

This tutorial shows you how you can use our Chat Integration examples to send notifications from your DataMiner System to Microsoft Teams.

Estimated duration: 15 minutes.

> [!TIP]
> See also: [Kata #6: Custom ChatOps operator](https://community.dataminer.services/courses/kata-6/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- [A DataMiner System connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- [The latest version of the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions)
- [Admin consent has been granted](xref:Granting_admin_consent) in the [Admin app](https://admin.dataminer.services)

## Overview

- [Step 1: Deploy the ChatIntegration Examples package from the Catalog](#step-1-deploy-the-chatintegration-examples-package-from-the-catalog)
- [Step 2: Fetch the private chat for a user and send a notification](#step-2-fetch-the-private-chat-for-a-user-and-send-a-notification)
- [Step 3: Configure a Correlation rule triggered by a specific alarm to send the chat notification](#step-3-configure-a-correlation-rule-triggered-by-a-specific-alarm-to-send-the-chat-notification)

## Step 1: Deploy the ChatIntegration Examples package from the Catalog

1. Browse to <https://catalog.dataminer.services/catalog/3129>.

   ![ChatIntegration Examples page in Catalog](~/user-guide/images/chatops_notification_01_001.png)

1. Click *Deploy* and choose your target DMS.

1. Verify that the package was correctly installed by accessing the scripts in DataMiner Cube.

   ![ChatIntegration Examples scripts](~/user-guide/images/chatops_notification_01_002.png)

## Step 2: Fetch the private chat for a user and send a notification

1. Execute the *Fetch Private Chat Example* script with the email address of the user.

   ![ChatIntegration Examples Fetch Private Chat](~/user-guide/images/chatops_notification_02_001.png)

1. Verify that an entry was added in the *ChatsExample* memory file containing the private chat ID.

   ![ChatIntegration Examples ChatsExample Memory file](~/user-guide/images/chatops_notification_02_002.png)

1. Execute the *Send Chat Notification Example* script, select the chat ID, and configure the notification you want to send.

   ![ChatIntegration Examples Send Chat Notification](~/user-guide/images/chatops_notification_02_003.png)

## Step 3: Configure a Correlation rule triggered by a specific alarm to send the chat notification

1. Configure a Correlation rule so it will be triggered by a specific alarm and will execute the *Send Chat Notification Example* script.

   ![ChatIntegration Examples Correlation Rule](~/user-guide/images/chatops_notification_03_001.png)

   ![ChatIntegration Examples Correlation Rule script](~/user-guide/images/chatops_notification_03_002.png)

1. Trigger an alarm and verify that the notification is received in a Teams chat.

   ![ChatIntegration Examples Teams chat](~/user-guide/images/chatops_notification_03_003.png)
