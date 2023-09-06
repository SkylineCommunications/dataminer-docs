---
uid: Connector_help_APA_Sound_Monitoring
---

# APA Sound Monitoring

This connector can be used to interact with a media monitoring solution from APA-Comm. Test results of radio streams, podcasts, and audio streams are available for each different test device. Current audio streams, e.g. podcasts, are available for each channel.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, default: *80.*

### Redundancy

There is no redundancy defined.

## How to Use

### General page

On the left side of thispage, the **standalone parameters** from the **RadiothekMonitor** link are shown:

- Last Streams Update
- Last Check Duration
- Overall Status
- Response times

On the right side of thispage, you can configure the **polling speed** of the requests.

The device monitoring result sends two requests, one for the Android and one for the iOS results.

### Stream Loader page

This page contains the **Stream Loader** table. You can configure how rows with row status *Deleted* will be processed.

The subpages of this page contain the SQL Query Result table and the Podcast table.

If you delete a stream loader, the children of this stream in the Podcast table and SQL Query table will also be deleted.

### Streams page

This page contains the **Streams** table. You can configure how rows with row status *Deleted* will be processed. In addition, you can also trigger the immediate polling of the data.

The subpages of this page contain the Device table and the Device Tests table.

If you delete a stream, the children of this stream in the Device table will be deleted, and the children of the device in the Device Tests table will be deleted.

### Podcast subpage

This subpage contains standalone parameter **Auto Delete Time** and **Podcast** table.

When the date in the Date column of the Podcast table is older than the current date and time minus the Auto Delete Time, and the row has the *Deleted* status, this row will be deleted automatically.

If Auto Delete Time is set to *No Auto Delete*, no rows will be deleted automatically.
