---
uid: Repository_types
---

# Repository types

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

The SLC SE Repo Manager has different tabs for the different repository types:

![SLC SE Repo Manager](~/develop/images/repoManagerRepoTypes.png)

The following subsections provide more information about the different tabs.

## Protocols

This tab lists repositories that contain a Visual Studio solution of a specific protocol.

Changes made to a protocol repository trigger the corresponding [protocol CI/CD pipeline](xref:Pipeline_stages_for_protocols).

## Visio files

This tab lists repositories that contain a Visio file.

Changes made to a Visio repository trigger the corresponding [Visio CI/CD pipeline](xref:Pipeline_stages_for_visual_overviews).

## Custom solutions

This tab lists repositories that contain a Visual Studio solution. These are typically class library solutions that are in turn used by e.g., protocols or automation scripts.

Changes made to a custom solution repository trigger the corresponding [custom solution CI/CD pipeline](xref:Pipeline_stages_for_custom_solutions).

The *Custom Solutions* tab contains an additional icon that, when clicked, adds another *JenkinsNuGetConfiguration.xml* file that allows you to enable and configure NuGet-related stages in the pipeline.

![Custom solutions tab with enable NuGet creation button](~/develop/images/repoManagerCustomSolutionsTab.png)

## Functions

This tab lists repositories that contain a function.

Changes made to a function repository trigger the corresponding [functions CI/CD pipeline](xref:Pipeline_stages_for_functions).

## Automation scripts

This tab lists repositories that contain an automation script solution, which might consist of one or multiple automation scripts.

Changes made to an automation script repository trigger the corresponding [automation script solution CI/CD pipeline](xref:Pipeline_stages_for_Automation_scripts).

## Dashboards

This tab lists repositories that contain a dashboard.

Changes made to a dashboard repository trigger the corresponding [dashboard CI/CD pipeline](xref:Pipeline_stages_for_dashboards).

## Examples

This tab lists repositories that contain an example protocol or automation script.

Changes made to an example repository trigger the corresponding example CI/CD pipeline.

## Packages

This tab lists repositories that define an install package.

Changes made to a package repository trigger the corresponding [install package CI/CD pipeline](xref:Pipeline_stages_for_install_packages).

## Files

This tab lists repositories that contain files. These are typically repositories that are used as part of a package.

These repositories are not linked to a CI/CD pipeline.
