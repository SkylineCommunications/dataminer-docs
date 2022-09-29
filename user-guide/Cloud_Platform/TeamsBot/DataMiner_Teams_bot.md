---
uid: DataMiner_Teams_bot
---

# DataMiner Teams bot

If your DataMiner System is connected to the cloud with a recent version of the DataMiner Cloud Pack (2.2 or higher), you can interact with your DataMiner System in Microsoft Teams using the DataMiner Teams bot.

> [!NOTE]
> We highly recommend that you install the latest version of the DataMiner Cloud Pack. With older versions, not all DataMiner Teams bot features may be available.

> [!TIP]
> See also: [DataMiner Cloud Platform](xref:Part51CloudPlatform)

## DataMiner Teams bot installation

To install the DataMiner Teams bot, [click here](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925).

Alternatively, you can also download the bot as follows:

1. In Microsoft Teams, go to the apps store.

   > [!NOTE]
   > Depending on the configuration of your Microsoft tenant, your IT admin may need to explicitly allow the installation of the app in your organization.

1. Search for DataMiner. You should get the following search result:

   ![DataMiner app in Teams apps store](~/user-guide/images/DataMinerTeamsApp.png)

1. Click this DataMiner search result and click *Add*. This will start a private conversation between you and the DataMiner Teams bot.

   You can also immediately add the Teams bot to a specific team, chat, or meeting. To do so, click the triangle button next to *Add* and select the relevant option.

   ![DataMiner app in Teams apps store](~/user-guide/images/DataMinerTeamsAppAddTo.png)

## Starting a conversation with the Teams bot

When you start a conversation with the Teams bot, you will first need to log in:

1. Enter any command. This can be the *login* command, but any other command will have the same result if you are not logged in yet.

   The Teams bot will display a *Log in* button in its reply.

1. Click the *Log in* button.

1. Select a login method. Preferably, this should be the same login method as you usually use to connect to dataminer.services.

1. If you have no active DataMiner System configured yet, you will first need to configure it:

   1. Select your organization and click *Submit*.

   1. Select a DMS if necessary. If only one DMS is available for the selected organization, it will automatically be selected.

1. It is possible that you will still need to link your DataMiner account to your DataMiner Cloud Platform account. In that case, you will be prompted to do so.

   1. Click the *Link Account* button. This will open a browser tab showing the DataMiner account and DataMiner Cloud Platform account that will be linked.

   1. If the displayed accounts are indeed the accounts you want to link, click *Continue to log on*.

   1. Log in with your DataMiner account.

   1. Click *Link accounts*.

> [!NOTE]
>
> - The DataMiner Teams bot can also be used in group chats and channel conversations.
> - To be able to use the Teams bot, you need to be a member of a cloud-connected DMS. See [Giving a user access to cloud features](xref:Giving_users_access_to_cloud_features).

## Available options

You can use the following options to interact with the DataMiner Teams bot:

- **show dms**: Shows the active DataMiner System of this conversation.

- **change dms**: Changes the active DataMiner System of this conversation.

- **show elements**: Shows the first 10 elements from your active DataMiner System.

- **show element ‘*element name*’**: Shows information about the specified element.

- **show alarms**: Shows the 10 most recent active alarms.

- **show shares**: Shows the dashboards that have been shared with you across the entire DataMiner Cloud Platform.

- **show outgoing shares**: Shows the dashboards shared by anyone in your active DataMiner System.

- **show view ‘*view name*’**: Shows the visual overview of the specified view

- **help**: Shows more detailed help information, if available.

- **cancel**: Cancels the current action.

- **login**: Logs into the DataMiner Cloud Platform. Note that any other command used while not logged in will have the same result as this command.

- **logout**: Logs out of the DataMiner Cloud Platform.

> [!NOTE]
> If the latest version of the DataMiner Cloud Pack is not yet installed in your DMS, some of these options may not be available yet.
