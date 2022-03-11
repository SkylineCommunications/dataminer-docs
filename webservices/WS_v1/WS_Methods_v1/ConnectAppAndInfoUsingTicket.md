---
uid: ConnectAppAndInfoUsingTicket
---

# ConnectAppAndInfoUsingTicket

This method retrieves the connection string, along with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted, by using a DataMiner connection ticket.

The method is used to display web apps inside DataMiner Cube, so that it is not necessary to log into the web app again when you are already logged into Cube.

## Input

| Item               | Format | Description                                                                              |
|--------------------|--------|------------------------------------------------------------------------------------------|
| ConnectionTicket   | String | The connection ticket.                                                                   |
| ClientAppName      | String | The name of the client application as registered by Skyline.                             |
| ClientAppVersion   | String | The version of the client application. Optional. Used in logging and information events. |
| ClientComputerName | String | The name of the client computer. Optional. Used in logging and information events.       |

> [!NOTE]
> Prior to DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12, for the *ClientAppName*, a registered app name must be specified. If this is not done, the connection will be removed after 10 minutes. To request a valid *ClientAppName*, contact your Skyline Technical Account Manager. From DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12 onwards, this registration is no longer required. The client app name is then merely used in the audit trail.

## Output

| Item | Format | Description |
|--|--|--|
| ConnectAppAndInfo­UsingTicketResult | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |
