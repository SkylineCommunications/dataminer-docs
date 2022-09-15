---
uid: ConnectAppAndInfo
---

# ConnectAppAndInfo

Use this method to retrieve the connection string (GUID) needed to be able to connect to the host, together with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted.

> [!CAUTION]
> We strongly recommend that you use a secured connection (HTTPS), as otherwise logon credentials are sent as plain, unencrypted text over the internet.

## Input

| Item               | Format | Description                                                                              |
|--------------------|--------|------------------------------------------------------------------------------------------|
| host               | String | The host name. Obsolete. Keep this field empty.                                          |
| login              | String | The username.                                                                           |
| password           | String | The password.                                                                            |
| clientAppName      | String | The name of the client application                                                       |
| clientAppVersion   | String | The version of the client application. Optional. Used in logging and information events. |
| clientComputerName | String | The name of the client computer. Optional. Used in logging and information events.       |

> [!NOTE]
>
> - Prior to DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12, for the *ClientAppName*, a registered app name must be specified. If this is not done, the connection will be removed after 10 minutes. To request a valid *ClientAppName*, contact your Skyline Technical Account Manager. From DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12 onwards, this registration is no longer required. The client app name is then merely used in the audit trail.
> - The connection will be removed if it has not been used for 5 minutes, if the logout method is called or if IIS is recycling.

## Output

| Item | Format | Description |
|--|--|--|
| ConnectAppAndInfoResult | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |

> [!NOTE]
>
> - When two-step authentication is required, the MessageType property will contain “Challenge” and the Message property will contain the challenge to which the user has to respond.
> - From DataMiner 9.5.5 onwards, the response contains a cookie with a timestamp, client info hash, username and password. The client application can then store that cookie to allow the user either to reconnect in the same session or to automatically log in with the "Remember me" option. To reconnect to the Web Services API, you can use the *ReconnectAppAndInfo* method. This method is identical to the *ConnectAppAndInfo* method, except that the username and password combination is replaced by a cookie parameter. Also, the *ReconnectAppAndInfo* method will reuse the existing cookie instead of generating a new one. See [ReconnectAppAndInfo](xref:ReconnectAppAndInfo).
