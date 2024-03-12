---
uid: DIS_Troubleshooting
---

# Problem in DIS?

DIS is a complex program that can do a lot of things. It can happens that something breaks or was not taken in account.

## Preliminary checks

Before you report the issue or lose time trying to debug, please check the following items:

- Are you on the latest version of Visual Studio?
- Are you on the latest version of DIS?
  - DIS also has an [insider version](https://community.dataminer.services/dataminer-integration-studio-other-downloads/). This could already contain a fix for your issue. Do note that this version could receive more hotfix changes as this is primarily used by Skyline employees to filter out any issues before it becomes the main release.
- Have you checked the [prerequisites](xref:Prerequisites)?

Next step would be to look at available information or gathering it. More information can be found [here](xref:DIS_Troubleshooting_RetrieveInformation).

## Feeling adventurous?

A big portion of our code has been extracted and put into [NuGet packages](xref:Platform_independent_CICD#nuget-libraries). Based on the stacktrace of the exception or the topic, you could have a look at the NuGet libraries to see if you can spot the problem. We keep an eye if people make issues or pull requests, so feel free if you want to help out on the code.

## Common scenario's

- [Account not licensed](xref:DIS_Troubleshooting_LicenseIssue)
- [DIS Inject - Common scenario's](xref:DIS_Troubleshooting_DisInject)
- [Publishing, Save Compiled As, Copy Protocol To Clipboard (Issue during creating of package)](xref:DIS_Troubleshooting_CompilationFailure)
- [Publishing (Issue during upload of package to DataMiner)](xref:DIS_Troubleshooting_UploadFailure)
