---
uid: Data_Sources_Limitations
---

# Limitations

When working with the Data API and Scripted Connectors, it's essential to be aware of specific limitations:

- Scripted Connectors
  - Operate on a fixed frequency of one minute.
  - Lack support for arguments.
  - Are locally stored on the server.
  - Are not synchronized in a DMS cluster.
  - Cannot be employed to manage data sources.
- Data API
  - Does not handle requests with payloads exceeding 1MB.
  - Does not accept requests from external systems.
  - Expects a field Id in JSON Arrays, serving as the primary key in the element's table.
- Parameters in auto-generated connectors
  - Lack units, and this configuration cannot be adjusted.
  - Are automatically assigned to pages in the element layout, and this allocation cannot be modified.

Certain limitations are expected to be lifted in future versions.
