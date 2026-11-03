---
uid: CICD_on_GitHub_getting_started
---
# Getting started with CI/CD using GitHub

## CI/CD using GitHub for connectors

If you and your organization are ready to dive into using GitHub for connectors, you will first need to set up your development environment. Then you can start developing, releasing, and optionally deploying any supported DataMiner artifacts with a CI/CD pipeline in GitHub.

To learn how to do so, follow the tutorial [Setting up complete quality control in CI/CD for connector deployment](xref:CICD_Tutorial_For_Connectors_VisualStudio_And_GitHub).

If you are specifically looking to create a quick custom pipeline to deploy connectors, follow the tutorial [Setting up basic CI/CD for connector deployment in GitHub](xref:CICD_Tutorial_Connector).

## CI/CD using GitHub for non-connector items

For any artifact types beyond connectors, you can use the Visual Studio Templates and the Skyline.DataMiner.SDK.

To get started with this, refer to the following tutorials:

- [Using Visual Studio and DIS](xref:CICD_Tutorial_For_Other_Items_User_Defined_API_VisualStudio_And_GitHub)
- [Using GitHub Codespaces](xref:CICD_Tutorial_For_Other_Items_User_Defined_API_GitHub_Codespaces)
- [Creating multi-artifact packages](xref:CICD_Tutorial_For_Other_Items_Multi-Artifact_DataMiner_Package_VisualStudio_And_GitHub)

Below are a few examples of how to get specific kinds of items into a DataMiner install package (.dmapp file):

- **Automation scripts, user-defined APIs, and ad hoc data sources**: Create these with the [Skyline DataMiner SDK](xref:skyline_dataminer_sdk) Visual Studio templates. You can [add them as extra projects](xref:skyline_dataminer_sdk_dataminer_package_project#adding-extra-artifacts-in-the-same-solution) to the solution of a [DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project), so that they are included in the .dmapp file.

- **Dashboards and low-code apps**: Use a [DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project) and [import them from a DataMiner Agent using DIS](xref:skyline_dataminer_sdk_dataminer_package_project#importing-from-dataminer). DIS places them in the corresponding *PackageContent* folder of the project, so that they are included in the .dmapp file.

- **Visual overviews (Visio files)**: These are not supported out of the box in DataMiner Package Projects yet. Add the Visio file as a companion file of the package, and [implement the necessary logic in the installer code](xref:skyline_dataminer_sdk_dataminer_package_project#executing-additional-code-during-installation) to install the Visio file and assign it to the appropriate DataMiner objects (e.g., elements, services, or views).
