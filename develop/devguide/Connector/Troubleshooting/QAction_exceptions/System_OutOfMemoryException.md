---
metadata_version: 1
uid: System_OutOfMemoryException
description: "Use this connector troubleshooting entry point when SLScripting reports System.OutOfMemoryException while executing QAction code."
---

# System.OutOfMemoryException

If SLScripting reports `System.OutOfMemoryException` during connector QAction execution, or you suspect memory growth in that process, collect its logs and, if possible, a full-memory dump. Follow investigating OutOfMemoryException occurrences to confirm the exception and identify the allocation or connector code involved.

> [!NOTE]
> Confirm that SLScripting is the affected process. Memory growth in another process or a dump without full memory can make the analysis inconclusive.
