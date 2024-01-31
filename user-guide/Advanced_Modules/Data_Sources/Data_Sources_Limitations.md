---
uid: Data_Sources_Limitations
---

# Limitations

When working with the [Data API](xref:Data_API) and [scripted connectors](xref:Scripted_Connectors), there are limitations:

- Scripted Connectors:

  - Operate on a fixed frequency of one minute.

  - Lack support for arguments.

  - Locally stored on the server.

  - Lack synchronization in a DMS cluster.

  - Inability to manage data sources.

- Data API:

  - Rejects requests with payloads exceeding 1MB.

  - Rejects requests from external systems.

  - Requires a field "Id" in JSON Arrays, serving as the primary key in the element's table.

- Parameters in auto-generated connectors:

  - Lack units, with no adjustable configuration.

  - Automatically assigned to pages in the element layout, and this allocation cannot be modified.

> [!NOTE]
> Certain limitations are expected to be addressed in future DataMiner versions.
