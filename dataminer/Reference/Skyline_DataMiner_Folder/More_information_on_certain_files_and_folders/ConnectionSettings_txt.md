---
uid: ConnectionSettings_txt
keywords: enabling gRPC, gRPC configuration, disabling .Net Remoting
---

# ConnectionSettings.txt

This file contains default connection settings to be used by DataMiner client applications when connecting from specific IP addresses.

> [!NOTE]
>
> - An update of this file does not require a restart of the DataMiner software.
> - This file is not synchronized throughout the DataMiner System.

- This file is located in the folder `C:\Skyline DataMiner\WebPages\`.

- ConnectionSettings.txt format:

    ```txt
    [IP address ranges - separated by semicolons] [Options - separated by semicolons]
    ```

- Types of IP address ranges:

    | Type of IP range                    | Example               |
    |---------------------------------------|-----------------------|
    | A single IP address starting with ... | 10.\*                 |
    | A range of IP addresses               | 10.10.1.1-10.10.1.100 |
    | A single IP address                   | 10.10.7.1             |

> [!TIP]
> See also: [DataMiner hardening guide](xref:DataMiner_hardening_guide)

## ConnectionSettings.txt Options

- **type=**

  The type of connection.

  Possible values:

  - *GRPCConnection*: By default enabled from DataMiner 10.5.10/10.6.0 onwards.<!-- RN 43331 --> Supported from DataMiner 10.3.0/10.3.2 onwards. DataMiner will communicate using HTTPS via the API Gateway, using gRPC. By default, this requires the use of the standard HTTPS port 443. <!-- RN 34983 --> When this type is used, the only two other options you can configure are *serverport* and *endpoint* (see [Examples](#examples)).

  - *RemotingConnection*: .NET Remoting. This is the default option in DataMiner versions prior to 10.5.10/10.6.0. However, note that we strongly recommend using *GRPCConnection* instead.<!-- RN 36196 -->
  
  - *LegacyRemotingConnection*: .NET Remoting. Use this to explicitly use .NET Remoting.

  - *WSConnection*: Web Services - deprecated.

- **polling=**

  Polling interval

  Possible values:

  - Number of milliseconds (minimum: 100)

  - 0 (no polling)

  > [!NOTE]
  > This option has no effect when the *GRPCConnection* type is used.

- **serverport=**

  Server port onto which the client has to connect.

  Possible values:

  - Port number

  - 0 (no override - connect to default port)

- **zip=**

  Whether or not the communication has to be zipped.

  Possible values:

  - true

  - false

- **cache=**

  The type of data that has to be cached on the client machine.
  
  When this option is set to its default value ("objects"), a number of objects (e.g. DataMiner Protocols) are cached on the client machine. Once these objects are present on the client, data traffic between DMA and client drops substantially.

  Possible values:

  - all

  - none

  - objects (default)

  - events

- **endpoint=**

  Override for the endpoint. See [Examples](#examples).

- **resolve=**

  Whether or not hostnames have to be resolved to IP addresses before the connection is set up.

  Possible values:

  - true (default)

  - false

> [!NOTE]
>
> - The file lists the most specific ranges first. When looking up the settings for an IP address, the first matching IP range defines the settings.
> - Lines starting with a "#" character are considered to be comments and are ignored.
> - If a client connects to a DataMiner Agent via a load-balancing URL (i.e. a hostname redirecting to different IP addresses when resolved), by default the hostname will be explicitly resolved before the connection is set up. If, for some IP addresses, you want to prevent this from happening, in *ConnectionSettings.txt* specify `"resolve=false"` next to those IP addresses.

## Examples

- To use gRPC by default:

  ```txt
  * type=GRPCConnection
  ```

- To use gRPC with port 443 and the APIGateway endpoint:

  ```txt
  * type=GRPCConnection;serverport=443;endpoint=/APIGateway
  ```

  > [!NOTE]
  > This setup is not recommended and should only be used for debugging or for test setups. This will only work if the APIGateway settings (`C:\Program Files\Skyline Communications\DataMiner APIGateway\appsettings.json`), the certificate bindings, and the firewall are adjusted accordingly.

- To use eventing by default:

  ```txt
  * type=RemotingConnection;polling=0;zip=true
  ```

- To use polling (1000 ms) by default:

  ```txt
  * type=RemotingConnection;polling=1000;zip=true
  ```

- To use either polling or eventing depending on the DMA:

  ```txt
  10.10.7.1 type=RemotingConnection;polling=1000;zip=true
  10.11.*;168.* type=RemotingConnection;polling=1000;zip=false
  * type=RemotingConnection;polling=0;zip=true
  ```
