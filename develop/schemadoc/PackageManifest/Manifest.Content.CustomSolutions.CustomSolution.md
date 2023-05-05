---
uid: Manifest.Content.CustomSolutions.CustomSolution
---

# CustomSolution element

Specifies a custom solution to include in the package.

## Parent

[CustomSolutions](xref:Manifest.Content.CustomSolutions)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[RepoPath](xref:Manifest.Content.CustomSolutions.CustomSolution.RepoPath)||Specifies the repository path of the custom solution.|
|&nbsp;&nbsp;[Selections](xref:Manifest.Content.CustomSolutions.CustomSolution.Selections)|[0, 1]|Allows you to specify the items of the custom solution to include. By default, all the DLL files from the bin folder will be included.|
|&nbsp;&nbsp;[Version](xref:Manifest.Content.CustomSolutions.CustomSolution.Version)||Specifies the version of the custom solution.|
