---
uid: TestElementDeviceConnectivity
---

# TestElementDeviceConnectivity

This method allows you to test a connection to a device, without actually creating an element.

<!-- Available from DataMiner 9.5.12 onwards. -->

## Input

| Item | Format | Description |
|--|--|--|
| connection    | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID         | Integer | The DataMiner Agent ID. |
| configuration | [DMAElementConfiguration](xref:DMAElementConfiguration) | The element configuration for which the connection is to be tested. |

## Output

| Item | Format | Description |
|--|--|--|
| ConnectionState | String | The current state of the connection.     |
| Error           | String | The text of the error that was returned. |
| ErrorCode       | String | The code of the error that was returned. |
