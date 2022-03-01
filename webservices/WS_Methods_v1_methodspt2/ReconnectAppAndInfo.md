---
uid: ReconnectAppAndInfo
---

# ReconnectAppAndInfo

Available from DataMiner 9.5.5 onwards. Use this method to use a cookie (received using the ConnectAppAndInfo, ConnectAppAndInfoStep2 or ConnectAppAndInfoUsingTicket method, see [ConnectAppAndInfo](xref:ConnectAppAndInfo), [ConnectAppAndInfoStep2](xref:ConnectAppAndInfoStep2) and [ConnectAppAndInfoUsingTicket](xref:ConnectAppAndInfoUsingTicket)) to retrieve the connection string (GUID) needed to be able to connect to the host, together with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted.

## Input

| Item               | Format | Description                                                                                                                          |
|--------------------|--------|--------------------------------------------------------------------------------------------------------------------------------------|
| Host               | String | The host name.                                                                                                                       |
| Cookie             | String | The cookie retrieved using the ConnectAppAndInfo method. (See [ConnectAppAndInfo](xref:ConnectAppAndInfo). |
| ClientAppName      | String | The name of the client application.                                                                                                  |
| ClientAppVersion   | String | The version of the client application.                                                                                               |
| ClientComputerName | String | The name of the client computer.                                                                                                     |

> [!NOTE]
> Prior to DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12, for the *ClientAppName*, a registered app name must be specified. If this is not done, the connection will be removed after 10 minutes. To request a valid *ClientAppName*, contact your Skyline Technical Account Manager. From DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12 onwards, this registration is no longer required.

## Output

| Item                       | Format                                                             | Description                                                                                     |
|----------------------------|--------------------------------------------------------------------|-------------------------------------------------------------------------------------------------|
| ReconnectAppAndInfo­Result | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |

> [!NOTE]
> This method reuses the existing cookie, which means that the cookie included in the output is the same as the cookie used in the input.

