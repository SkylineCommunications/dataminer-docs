---
uid: DCP_2.2
---

# DataMiner Cloud Pack 2.2

## Installing the DataMiner Cloud Pack

For installation information, see [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Upgrading your DataMiner Cloud Pack installation

To upgrade to DataMiner Cloud Pack version 2.2.0, run the installer (available on the [Downloads](https://community.dataminer.services/downloads/) page) on all DataMiner Agents in the cluster that already have the Cloud Pack version 2.0.0 or 2.1.0 installed.

## Component versions

When you install the DataMiner Cloud Pack v2.2.0, the following components are installed. You will be able to find these in the Windows installed programs list.

- DataMiner FieldControl v2.2.1
- DataMiner CoreGateway v2.2.1
- DataMiner CloudGateway v2.2.0

## Features

### Teams Bot

This version of the Cloud Pack will allow you to use the DataMiner Teams Bot.

#### Installation

Install the DataMiner Teams app from the official Microsoft Teams app Store. Depending on the configuration of your Microsoft tenant, your IT admin may need to explicitly allow the installation of the app in your organization. For more information, see the [Microsoft Teams documentation](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

#### Managing access to a DMS

Before dataminer.services users can have access to a DataMiner System via the Teams Bot, their account must be added to the right organization and DMS via the Admin app.

For more information, see [Giving users access to dataminer.services features](xref:Giving_users_access_to_cloud_features).

#### Available options

This first version of the Teams Bot will allow you to have one-on-one conversations with the bot. The following options are available:

- *show dms*: Shows the active DataMiner System of this conversation.
- *change dms*: Changes the active DataMiner System of this conversation.
- *show element ‘element name’*: Shows information about the specified element.
- *show alarms*: Shows the 10 most recent active alarms.
- *show shares*: Shows the dashboards that have been shared with you.
- *help*: Shows more detailed help information, if available.
- *cancel*: Cancels the current action.
- *logout*: Logs out of dataminer.services.

### Automatic HTTPS detection

This version of the Cloud Pack automatically detects if your DMA has been set up with HTTPS.

This means that you no longer have to manually configure the DataMiner CloudGateway module with the correct Web API endpoints.
