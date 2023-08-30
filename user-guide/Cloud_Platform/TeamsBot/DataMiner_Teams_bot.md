---
uid: DataMiner_Teams_bot
---

# DataMiner Teams bot

If your DataMiner System is connected to dataminer.services with a recent version of the DataMiner Cloud Pack (2.2 or higher), you can interact with your DataMiner System in Microsoft Teams using the DataMiner Teams bot.

> [!NOTE]
> We highly recommend that you install the latest version of the DataMiner Cloud Pack. With older versions, not all DataMiner Teams bot features may be available.

> [!TIP]
> See also: [dataminer.services](xref:AboutCloudPlatform)

## DataMiner Teams bot installation

To install the DataMiner Teams bot, [click here](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925).

Alternatively, you can also download the bot as follows:

1. In Microsoft Teams, select *Apps* in the app bar.

   > [!NOTE]
   > Depending on the configuration of your Microsoft tenant, your IT admin may need to explicitly allow the installation of the [DataMiner bot](https://teams.microsoft.com/l/app/9a09d087-5d07-4481-b34f-cd053eab7925) in your organization. For more information, refer to the [Microsoft documentation](https://docs.microsoft.com/en-us/microsoftteams/manage-apps).

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

1. It is possible that you will still need to link your DataMiner account to your dataminer.services account. In that case, you will be prompted to do so.

   1. Click the *Link Account* button. This will open a browser tab showing the DataMiner account and dataminer.services account that will be linked.

   1. If the displayed accounts are indeed the accounts you want to link, click *Continue to log on*.

   1. Log in with your DataMiner account.

   1. Click *Link accounts*.

> [!NOTE]
>
> - The DataMiner Teams bot can also be used in group chats and channel conversations.
> - To be able to use the Teams bot, you need to be a member of a DMS that is connected to dataminer.services. See [Giving a user access to dataminer.services features](xref:Giving_users_access_to_cloud_features).

## Available commands

You can use the following out-of-the-box commands to interact with the DataMiner Teams bot:

- **show dms**: Shows the active DataMiner System of this conversation.

- **change dms**: Changes the active DataMiner System of this conversation.

- **show elements**: Shows the first 10 elements from your active DataMiner System.

- **show element *element name***: Shows information about the specified element.

- **show alarms**: Shows the 10 most recent active alarms.

- **show shares**: Shows the dashboards that have been shared with you via dataminer.services from any DataMiner System.

- **show outgoing shares**: Shows the dashboards shared by anyone in your active DataMiner System.

- **show view *view name***: Shows the visual overview of the specified view

- **show command *command name***: Displays the matching command with its description and a button to run the command. See [Adding commands for the Teams bot to a DMS](#adding-custom-commands-for-the-teams-bot-to-a-dms).

- **show commands**: Displays the first 10 commands found in the active DataMiner System with their description and buttons to run each command. See [Adding commands for the Teams bot to a DMS](#adding-custom-commands-for-the-teams-bot-to-a-dms).

- **run *command name***: Runs the matching command on the active DataMiner System. When necessary, the user will be asked for input and/or confirmation. See [Adding commands for the Teams bot to a DMS](#adding-custom-commands-for-the-teams-bot-to-a-dms).

- **help**: Shows more detailed help information, if available.

- **cancel**: Cancels the current action.

- **login**: Logs into dataminer.services. Note that any other command used while not logged in will have the same result as this command.

- **logout**: Logs out of dataminer.services.

> [!NOTE]
>
> - If the latest version of the DataMiner Cloud Pack is not yet installed in your DMS, some of these options may not be available yet.
> - For many of these commands, the bot will also understand variations. For example, instead of "run command *command name*", you can simply specify "run *command name*" to get the same result.

## Adding custom commands for the Teams bot to a DMS

To add a custom command for the Teams bot to your DMS, create an [Automation script](xref:automation) in the folder "bot" in the DMS.

> [!TIP]
>
> - For examples of command scripts, refer to [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.
> - For a video guide on creating custom commands, see [Elevate your DataMiner ChatOps game](https://www.youtube.com/watch?v=Sr6EEp2DFps). ![Video](~/user-guide/images/video_Duo.png)

### Input and output of the commands

The commands allow dynamic input, such as [dummies](xref:Script_variables#creating-a-dummy), [parameters](xref:Script_variables#creating-a-parameter), [parameters with value files](xref:Script_variables#creating-a-parameter), and [memory files](xref:Script_variables#creating-a-memory-file).

They support the following output:

- Key values.

- Adaptive card body elements.

- JSON, which is displayed as plain text.

For examples, see [Custom Command Examples](https://github.com/SkylineCommunications/ChatOps-Extensions/tree/main/CustomCommandExamples) on GitHub.

> [!NOTE]
> The size of output is limited to a maximum of 35 KB.

### Limitations

- Interactive Automation scripts are not supported.
- Commands that run longer than 30 seconds are currently not supported. When a command takes too long, the bot will show that the request has been aborted. However, note that the command will keep running in the DMS once it has been initiated, but if it eventually completes, the bot will not display any feedback or output. This means that strictly speaking this feature could be used to trigger long-running commands, but in that case the commands should ideally be triggered asynchronously from within a command's Automation script. You could for instance add a trigger command and a check output command to check if the action is done.
- Issues with the adaptive card output will not result in proper error feedback. You need to make sure the provided JSON is valid code and that it has valid content for Teams (i.e. an array of body elements). You can validate your JSON output using the [designer](https://adaptivecards.io/designer/) by adding it in the body array of an adaptive card.
- Output cannot exceed 35 KB.

### Security

- A command is only visible for users of the bot if they have the appropriate rights in DataMiner Cube.
- If users have the necessary rights to view a command, but they do not have the rights needed for certain input for the command (e.g. a dummy input in case the user has no rights for any elements in the DMS), the bot will inform them that the command cannot be executed.
- In case a command cannot be executed because the relevant elements or protocols are missing in the DMS, the bot will inform users that they have no access or that the command's input is malformed in such a way that it can never be executed. In that case, the CoreGateway DxM will log which input is involved.
