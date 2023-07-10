---
uid: Configuring_Microsoft_Visual_Studio
---

# Configuring Microsoft Visual Studio

## Associating XML files with Microsoft Visual Studio

It is recommended to associate XML files with Microsoft Visual Studio. That way, when you double-click a protocol XML file or Automation script XML file in Windows Explorer, it will automatically be opened in Microsoft Visual Studio.

1. Go to *Control Panel \> Default Programs \> Set Associations*.
1. In the list of extensions, double-click ".xml".
1. In the *Open With* dialog box, select "Microsoft Visual Studio", and click *OK*.

## Configuring the default package management format

To be able to work with NuGet packages, you have to change the default package management format in Microsoft Visual Studio.

1. Go to *Tools > Options -> NuGet Package Manager > General*.
1. Set *Default package management format* to "PackageReference".

> [!NOTE]
> This setting is only applicable to legacy-style projects. For SDK-style projects, *PackageReference* is the only supported package management format.

If projects in your existing solutions are using the *packages.config* package management format, you will have to migrate these project to use the *PackageReference* package management format.

1. In Microsoft Visual Studio, open a solution and go to the Solution Explorer.
1. Navigate to a project, right-click *References*, and select *Migrate packages.config to PackageReference...*.
1. Repeat for every project in the current solution.
