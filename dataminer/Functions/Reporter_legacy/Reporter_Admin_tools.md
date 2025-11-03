---
uid: Reporter_Admin_tools
---

# Reporter Admin tools

The Reporter app has a tools page containing options and information that can be useful to troubleshoot DMS Reporter.

You can access this page at *http(s)://\[DmaIp\]/Reports/Tools.asp*.

The page consists of the following sections:

- **View info**: Allows you to request information that can be useful in order to troubleshoot the Reporter app, such as information on the loaded protocols and DataMiner Agents.

- **Reload element**: Reloads the information for a particular element.

- **Reload element (by element name)**: Functions in the same way as the reload element option, except that you must enter the name of the element manually, instead of selecting in a dropdown list.

- **Reload Agent**: Reloads all elements of the DMA you select.

- **Reload Agent (by IP)**: Functions in the same way as the Reload Agent option, except that you must enter the IP of the DMA manually, instead of selecting the DMA in a dropdown list.

- **Reload protocol meta info**: Reloads the information regarding the loaded protocols, i.e. the available versions, production version and protocol type.

- **Reload protocol**: Reloads a particular protocol version, which can be of use when the protocol has changed but Reporter still uses the old version.

- **Clear parameter stats**: Data for parameters is initialized in the database when it is requested for the first time and is then retained as long as it is requested regularly. This option drops the data for the indicated parameter from the database.

- **Cleanup database**: Removes any data that is older than the indicated number of months to keep from the Reporter database tables containing information about element and parameter severity changes and new alarms. The database cleanup normally occurs automatically, but can be forced with this option. This option can only be used with a legacy database, not with a Cassandra database.

- **Add local IP**: Used to manually add an IP address to the list of local IP addresses kept by the Reporter engine. Not needed in normal circumstances.

- **Remove local IP**: Used to manually remove an IP address from the list of local IP addresses kept by the Reporter engine. Not needed in normal circumstances.

- **Timeline cache**: See [SLASPConnection](xref:DataMiner_processes#slaspconnection).
