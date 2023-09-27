---
uid: ConnectAppAndInfoStep2
---

# ConnectAppAndInfoStep2

Use this method for the second step in a two-step authentication process, in order to retrieve the connection string, along with information about the DataMiner Agent (time, alarm colors, etc.) and the user permissions granted.

> [!CAUTION]
> We strongly recommend that you use a secured connection (HTTPS), as otherwise logon credentials are sent as plain, unencrypted text over the internet.

## Input

| Item              | Format | Description                                                       |
|-------------------|--------|-------------------------------------------------------------------|
| connection        | String | The connection ID.                                                |
| challengeResponse | String | Response from the user to the challenge issued in the first step. |

> [!NOTE]
> The connection ID and challenge are returned in the first step of the authentication. For more info, see [ConnectAppAndInfo](xref:ConnectAppAndInfo).

## Output

| Item | Format | Description |
|--|--|--|
| ConnectAppAndInfoStep2Result | [DMAConnectAndInfo](xref:DMAConnectAndInfo) | The connection string, information about the DataMiner Agent, and the user permissions granted. |
