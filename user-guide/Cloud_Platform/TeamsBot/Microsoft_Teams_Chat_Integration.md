---
uid: Microsoft_Teams_Chat_Integration
---

# Chat integration with Microsoft Teams

If your DataMiner System is connected to dataminer.services, you can integrate your DataMiner System with Microsoft Teams using [DataMiner Automation](xref:automation).

> [!TIP]
> See also: [dataminer.services](xref:AboutCloudPlatform)

## Prerequisites

### Development prerequisites

If you want to create chat integration Automation scripts, you will need to make sure the following are installed:

- **Skyline.DataMiner.DcpChatIntegrationHelper NuGet package**: You can find this package on [nuget.org](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper). It allows easy integration with business communication platforms from a DataMiner Automation script.

  > [!TIP]
  > We recommend that you always use the **latest version** of the Skyline.DataMiner.DcpChatIntegrationHelper NuGet package.

- **DataMiner Integration Studio (DIS) Visual Studio extension**: DIS is required for development of Automation scripts using the Skyline.DataMiner.DcpChatIntegrationHelper NuGet package. You can also use DIS to deploy Automation scripts directly from your development environment to your DataMiner Systems.

  > [!TIP]
  > See [Installing DataMiner Integration Studio](xref:Installing_and_configuring_the_software).

### Server-side prerequisites

- The DataMiner System must be [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- The Cloud Gateway module must be updated to version 2.9.0 or higher. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes).

> [!NOTE]
> We highly recommend that you install the **latest version** of the **DataMiner Cloud Pack**. With older versions, not all features may be available.

#### Microsoft Teams prerequisites

- You must allow the [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) in Microsoft Teams. For more information, refer to the [Microsoft documentation](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- [Admin consent must be granted](xref:Granting_admin_consent) in the [Admin app](https://admin.dataminer.services). You can revoke this consent at any time.

> [!NOTE]
> You may need to regrant admin consent to enable new released features. This will be indicated in [the dataminer.services change log](xref:DCP_change_log).

## Using chat integration

The following features are available:

- Creating teams
- Fetching all teams
- Creating channels
- Fetching all channels of a team
- Adding members or owners to your teams
- Sending notifications in channels in the name of the DataMiner Teams bot
- Creating a private chat between someone and the DataMiner Teams bot
- Fetching a private chat between someone and the DataMiner Teams bot
- Sending notifications in private chats in the name of the DataMiner Teams bot

To get started, you can find several example Automation scripts with more information on [GitHub](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/ChatIntegrationExamples).

After you have made sure the above-mentioned prerequisites are in place, you can download and deploy [the DcpChatIntegrationExamples DMAPP](https://github.com/SkylineCommunications/ChatOps-Extensions/blob/main/ChatIntegrationExamples/README.md#getting-started) to your DataMiner System and immediately try out these examples.

## Limitations

- Notifications cannot exceed 35 KB.

## Security

By granting [Admin consent](xref:Granting_admin_consent) from your Microsoft (Teams) tenant to "DataMiner" (i.e. Skyline Communications) in the [Admin app](https://admin.dataminer.services), you allow Skyline Communications to execute these chat integration actions. This includes creating teams, channels, and chats, fetching users, chats, etc.

You can revoke this access at any time. See [Granting admin consent for Teams Chat Integration](xref:Granting_admin_consent).

> [!NOTE]
> You may need to regrant admin consent to enable new released features. This will be indicated in [the dataminer.services change log](xref:DCP_change_log).
