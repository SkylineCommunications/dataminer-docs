---
uid: ConnectApp
---

# ConnectApp

Use this method to retrieve the connection ID (GUID) needed to be able to connect to the host.

> [!CAUTION]
> We strongly recommend that you use a secured connection (HTTPS), as otherwise logon credentials are sent as plain, unencrypted text over the internet.

## Input

| Item               | Format | Description                                                                              |
|--------------------|--------|------------------------------------------------------------------------------------------|
| host               | String | The host name. Obsolete. Keep this field empty.                                          |
| login              | String | The username.                                                                            |
| password           | String | The password.                                                                            |
| clientAppName      | String | The name of the client application                                                       |
| clientAppVersion   | String | The version of the client application. Optional. Used in logging and information events. |
| clientComputerName | String | The name of the client computer. Optional. Used in logging and information events.       |

> [!NOTE]
> The connection will be removed if it has not been used for 5 minutes, if the logout method is called or if IIS is recycling.<!-- Prior to DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12, for the *ClientAppName*, a registered app name must be specified. If this is not done, the connection will be removed after 10 minutes. To request a valid *ClientAppName*, contact your Skyline Technical Account Manager. From DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12 onwards, this registration is no longer required. The client app name is then merely used in the audit trail. -->

## Output

| Item             | Format | Description        |
|------------------|--------|--------------------|
| ConnectAppResult | String | The connection ID. |
