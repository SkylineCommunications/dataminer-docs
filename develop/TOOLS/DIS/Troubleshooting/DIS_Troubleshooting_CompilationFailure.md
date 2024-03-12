---
uid: DIS_Troubleshooting_CompilationFailure
keywords: dis publish issue, dis compile issue, dis copy to clipboard issue
---

# Publishing, Save Compiled As, Copy Protocol To Clipboard (Issue during creating of package)

## Problem

Publishing a connector or script fails with an exception in DIS.
Saving compiled connector or script fails with an exception in DIS.
Copy Protocol to Clipboard fails with an exception in DIS.

## Possible causes

- Invalid configuration.
- No access to internet (when using NuGet packages).
- Syntax that wasn't covered yet.

## Possible solutions

Check if the configuration is correct:

- Proper XML
- Using PackageReference (2nd note of [Consuming NuGet packages](xref:Consuming_NuGet))

In most scenario's it is probably an unexpected scenario with the solution and the parsing within DIS.

When reporting the issue make sure to include a copy of the solution and the output logging of Visual Studio. For more info, see [Retrieve Information](xref:DIS_Troubleshooting_RetrieveInformation).
