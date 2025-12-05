---
uid: ConnectApp
---

# ConnectApp

Use this method to retrieve the connection ID (GUID) needed to be able to connect to the host.

> [!CAUTION]
> We strongly recommend using a secured connection (HTTPS), as otherwise logon credentials are sent as plain, unencrypted text over the internet.

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
> The connection will be removed if it has not been used for 5 minutes, if the logout method is called or if IIS is recycling.

## Output

| Item             | Format | Description        |
|------------------|--------|--------------------|
| ConnectAppResult | String | The connection ID. |
