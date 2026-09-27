---
metadata_version: 1
uid: System_StackOverflowException
description: "Use this connector troubleshooting entry point when recursive QAction code causes a System.StackOverflowException in SLScripting."
---

# System.StackOverflowException

If a connector QAction causes a stack overflow in SLScripting, collect the crash dump and note the connector version. Follow [Investigating StackOverflowException occurrences](xref:TroubleshootingSLScriptingStackOverflowException) to locate the failing method in the QAction assembly. Check for recursion without a terminating condition and correct the connector code if found.

> [!NOTE]
> A stack overflow can terminate SLScripting before it writes a log entry. If the dump does not show a stack overflow, use the [SLScripting troubleshooting procedures](xref:Troubleshooting_SLScripting).
