---
metadata_version: 1
uid: Finalizer_Exception
description: "Use this connector troubleshooting entry point when an exception on a QAction finalizer thread causes SLScripting to crash."
---

# Exception in Finalizer

If a connector QAction throws an exception on the .NET Finalizer thread and SLScripting crashes, collect its logs and crash dump. Follow [Investigating exception occurrence on Finalizer thread](xref:TroubleshootingSLScriptingFinalizerException) to identify the failing finalizer and trace it back to the connector code.

> [!NOTE]
> If the dump does not show a finalizer exception, choose a different investigation path from [SLScripting troubleshooting](xref:Troubleshooting_SLScripting).
