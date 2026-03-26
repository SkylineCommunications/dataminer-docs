---
uid: DIS_Troubleshooting_CompilationFailure
keywords: dis publish issue, dis compile issue, dis copy to clipboard issue
---

# Package creation problems

## Problem

- Publishing a connector or script fails with an exception in DIS.

- Saving a compiled connector or script fails with an exception in DIS.

- *Copy Protocol to Clipboard* fails with an exception in DIS.

## Possible causes

- Invalid configuration.

- No access to internet (when using NuGet packages).

- Syntax that is not supported yet.

## Possible solutions

Check if the configuration is correct:

- Make sure proper XML is used.

- Use the PackageReference package management format (see [Consuming NuGet packages](xref:Consuming_NuGet)).

If this does not solve the problem, it likely involves an unexpected scenario with the solution and the parsing within DIS. Report the issue to the DIS team, making sure to include a copy of the solution and the output logging of Visual Studio. For more info, see [Retrieving information in case a problem occurs](xref:DIS_Troubleshooting_RetrieveInformation).
