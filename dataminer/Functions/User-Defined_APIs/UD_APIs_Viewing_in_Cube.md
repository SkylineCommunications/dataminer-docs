---
uid: UD_APIs_Viewing_in_Cube
---

# Managing APIs and tokens in DataMiner Cube

> [!NOTE]
> Before you try to execute these procedures, make sure you have the user permissions available under [Modules > User-Defined APIs](xref:DataMiner_user_permissions#modules--user-defined-apis).

## Configuring APIs and tokens

1. Go to *System Center* > *User-Defined APIs*.

1. Use the buttons below the table to create an API or token, or to edit or delete the selected API or token.

![API module in DataMiner Cube](~/dataminer/images/UDAPIS_Client_API_Module.png)<br>
*User-Defined APIs page in DataMiner 10.6.9*

> [!NOTE]
>
> - You can also create an API and tokens in the Automation app. See [Creating an API and tokens in DataMiner Automation](xref:UD_APIs_Define_New_API#creating-an-api-and-tokens-in-dataminer-automation). This is very similar to the creation in System Center, except you can only configure the APIs and tokens for one specific script at a time.
> - It is not possible to delete a token that is in use by an API. You first need to unassign the token from all APIs using it before you can delete it. If you want to block access to a token rapidly, you can disable it instead.

## Enabling or disabling API tokens

1. Go to *System Center* > *User-Defined APIs*.

1. Right-click the token in the *Tokens* table and select *Enable* or *Disable*.

![Enabling or disabling an API token in DataMiner Cube](~/dataminer/images/UDAPIS_DisableToken.png)<br>
*Enabling or disabling an API token in DataMiner 10.3.6*

## Configuring a rate limit for an API token

From DataMiner 10.6.9/10.7.0 onwards<!--RN 45751-->, when creating or editing an API token, you can configure a rate limit for that token. The rate limit restricts the number of requests a client can make within a specified time window.

### [Creating a new token](#tab/tabid-1)

1. Go to *System Center* > *User-Defined APIs*.

1. Under *Tokens*, select *Create* in the lower-right corner.

   New tokens are created with a default rate limit of 60 requests per minute.

1. If you want to change the default rate limit, configure the following settings:

   - *Limit* (1): Maximum number of requests allowed within the configured window (from 1 to 100).

   - Window (2): Sliding time window during which the limit applies (from 1 second to 1 day).

   ![*Create API token* pop-up window](~/dataminer/images/Create_API_Token.png)<br>*Create API token window in DataMiner 10.6.9*

1. Select *Generate token*.

### [Editing an existing token](#tab/tabid-2)

1. Go to *System Center* > *User-Defined APIs*.

1. Right-click a token in the *Tokens* table and select *Edit*.

1. Make sure the *Limit* checkbox is selected.

   The default rate limit will be set to 60 requests per minute.

1. If you want to change the default rate limit, configure the following settings:

   - *Limit* (1): Maximum number of requests allowed within the configured window (from 1 to 100).

   - Window (2): Sliding time window during which the limit applies (from 1 second to 1 day).

   ![*Edit API token* pop-up window](~/dataminer/images/Edit_API_Token.png)<br>*Edit API token window in DataMiner 10.6.9*

1. Select *Save and close*.

***

> [!NOTE]
> A configured rate limit restricts the number of requests a client can make within a specified time window. However, it does not guarantee that the server can process all requests up to that limit. Actual throughput depends on several factors, including the execution time of the API script, the number of concurrently active tokens, and overall server load.

## Getting the API URL blueprint

1. Go to *System Center* > *User-Defined APIs*.

1. Right-click the API in the APIs table and select *Copy URL*.

![Copying an API URL in DataMiner Cube](~/dataminer/images/UDAPIS_CopyAPIURL.png)<br>
*Copying an API URL in DataMiner 10.3.6*
