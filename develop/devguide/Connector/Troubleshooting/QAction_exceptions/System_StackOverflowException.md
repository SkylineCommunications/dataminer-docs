---
metadata_version: 1
uid: System_StackOverflowException
description: "Investigate QAction stack overflows in SLScripting by collecting a crash dump, noting the connector version, and checking for unbounded recursion."
---

# System.StackOverflowException

If a connector QAction causes a stack overflow in SLScripting, collect the crash dump and note the connector version.

To locate the failing method in the QAction assembly, refer to [Investigating StackOverflowException occurrences](xref:TroubleshootingSLScriptingStackOverflowException). Check for recursion without a terminating condition and correct the connector code if found.

> [!NOTE]
> A stack overflow can terminate SLScripting before it writes a log entry. If the dump does not show a stack overflow, use the [SLScripting troubleshooting procedures](xref:Troubleshooting_SLScripting).
