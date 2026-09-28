---
metadata_version: 1
uid: Finalizer_Exception
description: "When a connector throws an exception on the Finalizer thread, collect the SLScripting logs and crash dump and trace the finalizer to its connector code."
---

# Exception in Finalizer

If a connector QAction throws an exception on the .NET Finalizer thread and SLScripting crashes, collect its logs and crash dump. To identify the failing finalizer and trace it back to the connector code, refer to [Investigating exception occurrence on Finalizer thread](xref:TroubleshootingSLScriptingFinalizerException).

> [!NOTE]
> If the dump does not show a finalizer exception, choose a different investigation path from [SLScripting troubleshooting](xref:Troubleshooting_SLScripting).
