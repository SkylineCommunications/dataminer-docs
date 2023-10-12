---
uid: UD_APIs_Viewing_in_Cube
---

# Managing APIs and tokens in DataMiner Cube

> [!NOTE]
> Before you try to execute these procedures, make sure you have the user permissions available under [Modules > User-Defined APIs](xref:DataMiner_user_permissions#modules--user-defined-apis).

## Configuring APIs and tokens

1. Go to *System Center* > *User-Defined APIs*.

1. Use the buttons below the table to create an API or token, or to edit or delete the selected API or token.

![API module in DataMiner Cube](~/user-guide/images/UDAPIS_Client_API_Module.png)<br>
*User-Defined APIs page in DataMiner 10.3.6*

> [!NOTE]
>
> - You can also create an API and tokens in the Automation app. See [Creating an API and tokens in DataMiner Automation](xref:UD_APIs_Define_New_API#creating-an-api-and-tokens-in-dataminer-automation). This is very similar to the creation in System Center, except you can only configure the APIs and tokens for one specific script at a time.
> - It is not possible to delete a token that is in use by an API. You first need to unassign the token from all APIs using it before you can delete it. If you want to block access to a token rapidly, you can disable it instead.

## Enabling or disabling API tokens

1. Go to *System Center* > *User-Defined APIs*.

1. Right-click the token in the *Tokens* table and select *Enable* or *Disable*.

![Enabling or disabling an API token in DataMiner Cube](~/user-guide/images/UDAPIS_DisableToken.png)<br>
*Enabling or disabling an API token in DataMiner 10.3.6*

## Getting the API URL blueprint

1. Go to *System Center* > *User-Defined APIs*.

1. Right-click the API in the APIs table and select *Copy URL*.

![Copying an API URL in DataMiner Cube](~/user-guide/images/UDAPIS_CopyAPIURL.png)<br>
*Copying an API URL in DataMiner 10.3.6*
