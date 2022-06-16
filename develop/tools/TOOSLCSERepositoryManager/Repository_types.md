---
uid: Repository_types
---

# Repository types

The SLC SE Repo Manager has different tabs for the different repository types:

![alt text](~/develop/images/repoManagerRepoTypes.png "SLC SE Repo Manager")

The following subsections provide more information about the different repository types.

## Protocols

Repositories listed on the tab are repositories that contain a Visual Studio solution of a specific protocol.
Changes made to a protocol repository triggers their corresponding [protocol CI/CD pipeline](xref:Pipeline_stages_for_protocols).

## Visios

Repositories listed on the tab are repositories that contain a Visio.
Changes made to a Visio repository triggers their corresponding [Visio CI/CD pipeline](xref:Pipeline_stages_for_visual_overviews).

## Custom solutions

This tab lists repositories that contain a Visual Studio solution. These are typically class library solutions that are in turn used by e.g. protocols or Automation scripts.
Changes made to a custom solution repository triggers their corresponding [custom solution CI/CD pipeline](xref:Pipeline_stages_for_custom_solutions).

The custom solutions tab contains an additional icon which, when pressed, adds an additional "JenkinsNuGetConfiguration.xml" file that allows to enabling and configuring NuGet related stages in the pipeline.

![alt text](~/develop/images/repoManagerCustomSolutionsTab.png "Custom solutions tab with enable NuGet creation button")

## Functions

Repositories listed on the tab are repositories that contain a function.
Changes made to a function repository triggers their corresponding [functions CI/CD pipeline](xref:Pipeline_stages_for_functions).

## Automation scripts

Repositories listed on the tab are repositories that contain an Automation script solution, which might consist of one or multiple Automation scripts.
Changes made to an Automation script repository triggers their corresponding [Automation script solution CI/CD pipeline](xref:Pipeline_stages_for_Automation_scripts).

## Dashboards

Repositories listed on the tab are repositories that contain a dashboard.
Changes made to a dashboard repository triggers their corresponding [dashboard CI/CD pipeline](xref:Pipeline_stages_for_dashboards).

## Examples

Repositories listed on the examples tab are repositories that contain an example protocol or Automation script.
Changes made to an example repository triggers their corresponding example CI/CD pipeline.

## Packages

Repositories listed on the packages tab are repositories that defines an install package.
Changes made to a package repository triggers their corresponding [install package CI/CD pipeline](xref:Pipeline_stages_for_install_packages).

## Files

Repositories listed on the files tab are repositories that contain files. These are typically repositories that are used as part of a package.
These repositories are not linked to a CI/CD pipeline.
