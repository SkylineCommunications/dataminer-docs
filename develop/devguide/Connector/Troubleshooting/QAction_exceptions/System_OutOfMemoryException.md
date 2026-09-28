---
metadata_version: 1
uid: System_OutOfMemoryException
description: "Investigate SLScripting OutOfMemoryExceptions by collecting logs and, if possible, a full-memory dump to trace the source."
---

# System.OutOfMemoryException

If SLScripting reports `System.OutOfMemoryException` during connector QAction execution, or you suspect memory growth in that process, collect its logs and, if possible, a full-memory dump.

To confirm the exception and identify the allocation or connector code involved, refer to [Investigating OutOfMemoryException occurrences](xref:TroubleshootingSLScriptingOutOfMemoryException).

> [!NOTE]
> Confirm that SLScripting is the affected process. Memory growth in another process or a dump without full memory can make the analysis inconclusive.
