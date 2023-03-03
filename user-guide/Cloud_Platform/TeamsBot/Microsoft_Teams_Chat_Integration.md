---
uid: Microsoft_Teams_Chat_Integration
---

# Chat integration with Microsoft Teams

If your DataMiner System is connected to dataminer.services, you can integrate your DataMiner System with Microsoft Teams using [Automation](xref:automation).

> [!TIP]
> See also: [dataminer.services](xref:Part51CloudPlatform)

## Prerequisites

### Development

#### Skyline.DataMiner.DcpChatIntegrationHelper NuGet Package

The [Skyline.DataMiner.DcpChatIntegrationHelper NuGet package can be found on nuget.org](https://www.nuget.org/packages/Skyline.DataMiner.DcpChatIntegrationHelper). This NuGet package allows easy integration with business communication platforms from a DataMiner Automation script.

> [!TIP]
> We recommend that you always use the latest version of the Skyline.DataMiner.DcpChatIntegrationHelper NuGet package.

#### DataMiner Integration Studio Visual Studio Extension

The DataMiner Integration Studio Visual Studio extension (also referred to as DIS) is required for development of Automation scripts using the [Skyline.DataMiner.DcpChatIntegrationHelper NuGet package](#skylinedataminerdcpchatintegrationhelper-nuget-package). You can also use DIS to deploy Automation scripts directly from your development environment to your DataMiner Systems.

See [Installing DataMiner Integration Studio](xref:Installing_and_configuring_the_software).

### Usage

#### General

- The DataMiner System must be cloud-connected. See [Connecting your DataMiner System to the cloud](https://docs.dataminer.services/user-guide/Cloud_Platform/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.html).

- The CloudGateway module must be updated to at least version 2.9.0. See [Upgrading nodes to the latest DxM versions](xref:Managing_cloud-connected_nodes).

> [!NOTE]
> We highly recommend that you install the latest version of the DataMiner Cloud Pack. With older versions, not all features may be available.

#### Microsoft Teams

- The [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) must be allowed in your [Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

- [Admin consent must be granted](xref:Granting_admin_consent) in the [Admin app](https://admin.dataminer.services). This access can be revoked at any time.

## Using Chat Integration

> [!TIP]
> For examples of chat integration Automation scripts, refer to [Chat Integration Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/ChatIntegrationExamples) on GitHub.

## Limitations

- Currently you can not fetch existing teams. You can only create a channel using chat integeration if you know the id of the team, which you'll receive when creating the team with chat integration. 
- Currently you can not fetch existing channels. You can only send notifications in a channel using chat integeration if you know the id of the channel, which you'll receive when creating the channel with chat integration. 

## Security

By granting [Admin consent](xref:Granting_admin_consent) from your Microsoft (Teams) Tenant to 'DataMiner', aka Skyline Communications, in the [Admin app](https://admin.dataminer.services), you allow Skyline Communications to do these chat integration actions, in example creating teams, channels, chats, fetching users, chats etc. This access can be revoked at any time as explained in the [Admin consent documentation](xref:Granting_admin_consent).