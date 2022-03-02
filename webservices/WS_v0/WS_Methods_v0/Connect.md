---
uid: Connect
---

# Connect

Use this method to log on to the DataMiner System and request authentication.

If the user credentials passed to the method prove to be valid, a connection ID will be returned. This ID has to be passed to each of the methods listed below for identification purposes.

> [!NOTE]
> Each time you call the *Connect* method, the *CleanupConnections* method is called automatically in order to clean up any unused connections before setting up a new one. See [CleanupConnections](xref:CleanupConnections).

## Input

| Item       | Format | Description                                                                                             |
|------------|--------|---------------------------------------------------------------------------------------------------------|
| Connection | String | The IP address or the host name.                                                                        |
| Login      | String | The username. In case of a domain user, you can use: *DomainName\\UserName* |
| Password   | String | The password.                                                                                           |

## Output

| Item          | Format | Description        |
|---------------|--------|--------------------|
| ConnectResult | String | The connection ID. |
