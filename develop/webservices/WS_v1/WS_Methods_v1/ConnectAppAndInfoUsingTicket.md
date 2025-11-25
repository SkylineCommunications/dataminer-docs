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
> By default, the ticket remains valid for 30 seconds. This is determined by the [AuthenticationTicketExpirationTime](xref:Configuration_of_DataMiner_processes#customizing-how-long-a-connection-ticket-remains-valid) setting in *MaintenanceSettings.xml*.

## Output

| Item | Format | Description |
|--|--|--|
| ConnectAppAndInfoUsingTicketResult | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |
