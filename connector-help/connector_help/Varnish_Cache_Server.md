---
uid: Connector_help_Varnish_Cache_Server
---

# Varnish Cache Server

Varnish Cache is a web application accelerator, also known as a caching HTTP reverse proxy. It can be installed in front of any server that communicates using HTTP, and configured to cache the contents.

The Varnish Cache Server driver will communicate via HTTP with the web application and get certain information from the cache server. The retrieved information will be displayed in the element in DataMiner.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Server cache.    | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *6085*)\].
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

There is only one page in this connector. On this page, several parameters display information about the connection to the cache server:

- The **Service** **Status** parameter shows whether the current cache server that was selected as **IP** **address** is up or down. With the **Virtual** **IP** parameter, you can set an **IP** **address** to see which **cache** **server** is currently active.
- The parameter **Number** **of** **Client** **Connections** **Per** **Time** **Period** displays the number of client connections made in the time period specified with the **Time** **Period** parameter. The same applies to the **Number of Backend Connections Per Time Period**.

## Notes

#### Service Status is not initialized

In the 1.0.0.x version of the connector, the **Service Status** is not yet functional. This will require a firmware update by the vendor.

#### Simulation

After you upload a new version, always verify if new data is coming in (i.e. verify when a parameter changes if the **x Per Time Period** parameter is not 0).
If this is not the case, it may be because *\#define SIMULATE* is activated in the connector. You can disable this in the connector by prefixing it with two forward slashes (*//#define SIMULATE*).
In this case, contact the TAM or System Developer.

#### All parameters are not initialized (after a new element is created)

This connector uses an external DLL: *System.Web.Extensions.dll*. In most systems, this DLL will be pre-installed. If it is not, most parameters will remain empty and the log file will contain compiler errors stating that a file/DLL is missing.
In this case, contact Skyline Communication to request this DLL. (Note that this DLL is provided by Microsoft, so it is also possible to download it from the internet or from another server.)
When you have received the DLL, place it in the folder *C:/Skyline DataMiner/ProtocolScripts/* and restart the element.
