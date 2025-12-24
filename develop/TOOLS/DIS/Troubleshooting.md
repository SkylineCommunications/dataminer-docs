---
uid: DIS_Troubleshooting
---

# Problem in DIS?

DIS is a complex program that can do a lot of things. It can happen that something breaks or was not taken in account.

## Preliminary checks

Before you report the issue or spend time trying to debug, please check the following items:

- Are you using the latest version of Visual Studio?

- Are you using the latest version of DIS?

- Are all [prerequisites](xref:Prerequisites) met?

When you have checked all this, and the issue persists, your next step is to [gather and check the necessary information](xref:DIS_Troubleshooting_RetrieveInformation).

## Feeling adventurous?

A big portion of our code has been extracted and put into [NuGet packages](xref:Platform_independent_CICD#nuget-libraries). Based on the stacktrace of the exception or the topic, you could have a look at the NuGet libraries to see if you can spot the problem. You can then create an issue or pull request on GitHub to help out with the code.

## Common problems

- [Licensing problem](xref:DIS_Troubleshooting_LicenseIssue)
- [DIS Inject problems](xref:DIS_Troubleshooting_DisInject)
- [Package creation problems](xref:DIS_Troubleshooting_CompilationFailure)
- [Publishing problems](xref:DIS_Troubleshooting_UploadFailure)
