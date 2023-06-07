---
uid: Configuring_Microsoft_Visual_Studio
---

# Configuring Microsoft Visual Studio

## Associating XML files with Microsoft Visual Studio

It is recommended to associate XML files with Microsoft Visual Studio. That way, when you double-click a protocol XML file or Automation script XML file in Windows Explorer, it will automatically be opened in Microsoft Visual Studio.

1. Go to *Control Panel \> Default Programs \> Set Associations*.
1. In the list of extensions, double-click “.xml”.
1. In the *Open With* dialog box, select “Microsoft Visual Studio”, and click *OK*.

## Changing the default package management format

To be able to work with the DataMiner DevPacks, you have to change the default package management format in Microsoft Visual Studio.

1. Go to *Tools > Options -> NuGet Package Manager > General*.
1. Set *Default package management format* to "PackageReference".

If any of your existing solutions are using NuGet packages the old way (i.e. using the package management format "packages.config"), you will have to make every project in those solutions use the package management format "PackageReference".

1. In Microsoft Visual Studio, open a solution and go to the Solution Explorer.
1. Navigate to a project, right-click *References*, and select *Migrate packages.config to PackageReference...*.
1. Repeat for every project in the current solution.

> [!NOTE]
> The DataMiner DevPacks (i.e. Skyline.DataMiner.Dev.* NuGet packages) can also be used in solutions other than protocol and Automation script solutions, for example in custom solutions such as the Class Library Community Packages, which are meant to be used as an API within protocol or Automation script solutions. If you have any custom solutions, make sure to the projects in those solutions also use the new DataMiner DevPacks.
