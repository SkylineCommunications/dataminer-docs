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

## Configuring the default solution file format (VS 2026)

Microsoft Visual Studio 2026 defaults to using the new `.slnx` as the solution file format, while DIS currently only supports the `.sln` format. To ensure compatibility and proper functionality with DIS, solutions must remain in the `.sln` format until support for `.slnx` is added.

Follow these steps to configure Visual Studio to always use the `.sln` format when creating new solutions:

1. Open **Tools > Options** in Visual Studio.
1. Navigate to the **Projects and Solutions** section.
1. Set the **Default Solution File Format** to `.sln (Visual Studio 2010-2022 Solution File Format)`.

To convert an existing `.slnx` solution to a `.sln` solution:

1. Open the solution in Visual Studio.
1. In the **Solution Explorer**, select the solution by clicking its name at the top of the hierarchy.
1. Go to **File > Save \[Solution Name\] As...**.
1. In the **Save As** dialog box, choose file type `.sln`.
1. Click **Save**.