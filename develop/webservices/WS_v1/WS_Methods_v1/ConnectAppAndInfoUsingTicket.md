---
uid: ConnectAppAndInfoUsingTicket
---

# ConnectAppAndInfoUsingTicket

This method retrieves the connection string, along with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted, by using a DataMiner connection ticket.

The method is used to display web apps inside DataMiner Cube, so that it is not necessary to log into the web app again when you are already logged into Cube.

## Input

| Item               | Format | Description                                                                              |
|--------------------|--------|------------------------------------------------------------------------------------------|
| connectionTicket   | String | The connection ticket.                                                                   |
| clientAppName      | String | The name of the client application as registered by Skyline.                             |
| clientAppVersion   | String | The version of the client application. Optional. Used in logging and information events. |
| clientComputerName | String | The name of the client computer. Optional. Used in logging and information events.       |

> [!NOTE]
>
> - By default, the ticket remains valid for 30 seconds. This is determined by the [AuthenticationTicketExpirationTime](xref:Configuration_of_DataMiner_processes#customizing-how-long-a-connection-ticket-remains-valid) setting in *MaintenanceSettings.xml*.
> - Prior to DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12, for the *ClientAppName*, a registered app name must be specified. If this is not done, the connection will be removed after 10 minutes. To request a valid *ClientAppName*, contact your Skyline Technical Account Manager. From DataMiner 9.6.0 CU19/10.0.0 CU7/10.0.12 onwards, this registration is no longer required. The client app name is then merely used in the audit trail.

## Output

| Item | Format | Description |
|--|--|--|
| ConnectAppAndInfoUsingTicketResult | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |
