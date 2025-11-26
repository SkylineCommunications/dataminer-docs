---
uid: ReconnectAppAndInfo
---

# ReconnectAppAndInfo

Use this method to use a cookie (received using the [ConnectAppAndInfo](xref:ConnectAppAndInfo), [ConnectAppAndInfoStep2](xref:ConnectAppAndInfoStep2) or [ConnectAppAndInfoUsingTicket](xref:ConnectAppAndInfoUsingTicket) method) to retrieve the connection string (GUID) needed to be able to connect to the host, together with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted.

## Input

| Item | Format | Description |
|--|--|--|
| host | String | The host name. |
| cookie | String | The cookie retrieved using the [ConnectAppAndInfo](xref:ConnectAppAndInfo) method. |
| clientAppName | String | The name of the client application. |
| clientAppVersion | String | The version of the client application. |
| clientComputerName | String | The name of the client computer. |

## Output

| Item | Format | Description |
|--|--|--|
| ReconnectAppAndInfoResult | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |

> [!NOTE]
> This method reuses the existing cookie, which means that the cookie included in the output is the same as the cookie used in the input.
