---
uid: ConnectAppAndInfo
---

# ConnectAppAndInfo

Use this method to retrieve the connection string (GUID) needed to be able to connect to the host, together with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted.

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

| Item | Format | Description |
|--|--|--|
| ConnectAppAndInfoResult | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |

> [!NOTE]
>
> - When two-step authentication is required, the MessageType property will contain “Challenge” and the Message property will contain the challenge to which the user has to respond.
> - Prior to DataMiner 10.5.0 [CU21]/10.6.0 [CU9]/10.6.12 onwards<!--RN 46714-->, the response contains a cookie with a timestamp, client info hash, username and password. The client application can store that cookie to allow the user to reconnect in the same session or automatically log in with the "Remember me" option. From DataMiner 10.5.0 [CU21]/10.6.0 [CU9]/10.6.12 onwards, the `Cookie` property and the [ReconnectAppAndInfo](xref:ReconnectAppAndInfo) method are obsolete. To remain signed in after a client or server restart, use external authentication via [SAML](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML).
