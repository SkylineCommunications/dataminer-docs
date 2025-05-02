---
uid: Data_Sources_Limitations
---

# Limitations

When working with the [Data API](xref:Data_API) and [scripted connectors](xref:Scripted_Connectors), there are limitations:

- Scripted connectors:

  - Operate at a fixed frequency of one minute.

  - Lack support for arguments.

  - Are stored locally on the server.

  - Lack synchronization in a DMS cluster.

  - Are unable to manage data sources.

- Data API:

  - Rejects requests with payloads exceeding 1 MB.<!-- RN 37817 -->

  - Rejects requests from external systems.

  - Supports a nested table structure with multiple child tables pointing to a single parent table, does not currently support a child table with foreign key relations to multiple parent tables.

- Parameters in auto-generated connectors:

  - Only prior to [DataAPI 1.1.3](xref:DataAPI_change_log#1-april-2024---new-feature---dataapi-113---new-configuration-endpoint-for-units-and-decimals-id-39016), lack units, with no adjustable configuration.

  - Are automatically assigned to pages in the element layout, and this allocation cannot be modified.

  - Cannot use any of the names in the [Reserved parameter names](xref:ConnectorBestPracticesReservedParameterNames) list.

> [!NOTE]
> Certain limitations are expected to be addressed in future DataMiner versions.
