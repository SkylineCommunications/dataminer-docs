---
uid: TryConnectAndInfo
---

# TryConnectAndInfo

Use this method to retrieve the connection string using the configured authentication method, together with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted.

## Input

| Item               | Format | Description                                                                              |
|--------------------|--------|------------------------------------------------------------------------------------------|
| clientAppUrl       | String | The URL of the client application.                                                       |
| clientAppName      | String | The name of the client application                                                       |
| clientAppVersion   | String | The version of the client application. Optional. Used in logging and information events. |
| clientComputerName | String | The name of the client computer. Optional. Used in logging and information events.       |

> [!NOTE]
>
> - Prior to DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12, for the *ClientAppName*, a registered app name must be specified. If this is not done, the connection will be removed after 10 minutes. To request a valid *ClientAppName*, contact your Skyline Technical Account Manager. From DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12 onwards, this registration is no longer required.
> - The connection will be removed if it has not been used for 5 minutes, if the logout method is called or if IIS is recycling.

## Output

| Item | Format | Description |
|--|--|--|
| TryConnectAndInfoResult | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |

> [!NOTE]
> When two-step authentication is required, the MessageType property will contain “Challenge” and the Message property will contain the challenge to which the user has to respond.
