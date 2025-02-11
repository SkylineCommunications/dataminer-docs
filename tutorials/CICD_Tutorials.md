---
uid: CICD_Tutorials
keywords: connector, protocol, driver, cicd, pipeline, workflow
---

# CI/CD tutorials

CI/CD, also known as [continuous integration and continuous delivery/deployment](xref:CICD), allows teams to deliver software more quickly, with higher quality and reliability, by automating the build, test, and deployment process.

Different technology stacks, such as [Azure](xref:CICD_Azure_DevOps_Examples), [Concourse](xref:CICD_Concourse_Examples), [GitHub](xref:CICD_GitHub_Examples), [GitLab](xref:CICD_GitLab_Examples), and [Jenkins](xref:CICD_Jenkins_Examples), are used to handle CI/CD, which is why Skyline Communications provides additional tooling and libraries that can run any of these. See also: [Platform-independent CI/CD](xref:Platform_independent_CICD).

You can also run our tooling through [command line](xref:CICD_Command_Line_Examples) on both Windows and Ubuntu.

For non-connector development (Automation Script, User Defined API, Ad-Hoc datasource, ...) we also provide a very powerful [Skyline DataMiner Software Development Kit](xref:skyline_dataminer_sdk) that automatically runs our tooling for you in the background, directly within the standard .NET Compilation and Publishing.

## Tutorials

### **For Non-Connector Items**

| Name | Description |
|------|-------------|
| [Registering a new version of a User-Defined API to the Catalog using Visual Studio and GitHub](xref:CICD_Tutorial_For_Other_Items_User_Defined_API_VisualStudio_And_GitHub) | Set up CI/CD pipelines using Visual Studio and GitHub to register new versions of User-Defined APIs to the DataMiner Catalog. |
| [Registering a new version of a User-Defined API to the Catalog using GitHub Codespaces](xref:CICD_Tutorial_For_Other_Items_User_Defined_API_GitHub_Codespaces) | Learn how to use GitHub Codespaces to set up CI/CD pipelines and register User-Defined APIs to the DataMiner Catalog. |
| [Registering a new version of a Multi-Artifact DataMiner Package to the Catalog using Visual Studio and GitHub](xref:CICD_Tutorial_For_Other_Items_Multi-Artifact_DataMiner_Package_VisualStudio_And_GitHub) | Manage multi-artifact DataMiner packages by setting up CI/CD pipelines using Visual Studio and GitHub for version registration. |

---

### **For Connectors**

| Name | Description |
|------|-------------|
| [Setting up basic CI/CD for connector deployment in GitHub](xref:CICD_Tutorial_Connector) | Set up basic quality control and automatic deployment for a DataMiner connector to a staging system using a custom CI/CD pipeline in GitHub. |
| [Registering a new version of a connector in the Catalog using a GitHub Action](xref:Tutorial_Register_Catalog_Version_GitHub_Actions) | Learn how to package and upload a DataMiner connector as a private item to the [DataMiner Catalog](https://catalog.dataminer.services/) through a CI/CD pipeline in GitHub. |
| [Setting up complete quality control in CI/CD for connector deployment](xref:CICD_Tutorial_For_Connectors_VisualStudio_And_GitHub) | Set up end-to-end quality control for DataMiner connectors using Visual Studio and GitHub, ensuring robust CI/CD practices. |
| [Setting up basic CI/CD for connector deployment in Azure DevOps](xref:CICD_Tutorial_For_Connectors_VisualStudio_And_AzureDevOps) | Configure CI/CD pipelines in Azure DevOps to deploy and maintain DataMiner connectors with essential quality control measures. |