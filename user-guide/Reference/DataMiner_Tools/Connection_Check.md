---
uid: Connection_Check
---

# Connection Check

This tool can be used to verify the connection between a client or server and a DataMiner Agent. This can for instance be of use to check if disconnection issues are caused by problems in the network, such as firewalls or intermittent problems with traffic between two locations.

> You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/connectioncheck/).

To use this tool:

1. Extract the archive you just downloaded to the client or server where you want to check the connection to the DMA.

1. Run the tool using a command prompt window, providing the hostname and credentials for the target DMA. 

   For example:

   `Connectioncheck.exe /host:10.2.1.4 /user:Administrator /pwd:hunter2 /method:Remoting`

The following methods can be specified:

- `Ping`: Pings the host. Expected outcome: `Ping result: Success`

- `HTTP`: Does HTTP requests to `http://{host}/EndPoints.txt`. Should succeed unless the host only allows HTTPS. Expected outcome: `HTTP Result: OK`

- `Bad`: Does HTTP requests to `http://{host}/Bogus.txt`. Should get a failure back from the web server indicating the file is missing. Expected outcome: `Bad HTTP result: NotFound`

- `SLNet`: Does HTTP requests to `http://{host}:8004/SLNetService`. Should give an internal server error if you can reach the SLNet process via port 8004. Expected outcome: `SLNet HTTP result: InternalServerError`

- `Remoting`: The default method. Creates a remoting connection that uses polling, and verifies that connection every second. Expected outcome: `Connection OK!`

The tool wil repeat the test every second, until you press `Ctrl + C`. If the remoting method is used, the polling connection status will be verified every second.

If an unexpected exception occurs, for example because the server cannot be reached, the application quits with an exception printed to the console.

> [!NOTE]
> The tool expects the remote DMA to run on port 8004, and expects HTTP traffic to be enabled on the DMA on port 80.
