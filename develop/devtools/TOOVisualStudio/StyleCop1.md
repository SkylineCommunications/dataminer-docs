---
uid: StyleCop1
---

# StyleCop

Visual Studio plugin that analyzes C# source code to enforce a set of style and consistency rules.

## Installation

- Install StyleCop using one of the following options:

    - Installer package file (.msi): download from <https://github.com/StyleCop>.

    - Visual Studio extension (.vsix):

		![](~/develop/images/stylecop_vsix.png)
		<br>Figure 158: *Visual StyleCop extension*

- When DIS is installed, a StyleCop rules file will automatically be applied.

## Running StyleCop

In order to run StyleCop, open a QAction, right-click in the code editor to open to the context menu and select *Run StyleCop*.

The *Error List* window will display the StyleCop rules that have been violated (if any).

![](~/develop/images/StyleCop.png)
<br>Figure 159: Visual Studio Error List window

> [!NOTE]
> It is advised to sort the items in the *Error List* window by line number from bottom to top. This way, you can fix the items from top to bottom and keep the correct line indications.

## About Hungarian notation

StyleCop will check if Hungarian notation is used and verifies it against the prefixes described in the section [Local variables](xref:Local_variables), which are defined in its configuration file.

However, it does not check whether it is valid Hungarian notation. For example, no warning will be thrown for string iName in the following screenshot:

![](~/develop/images/Stylecop_hungarian.png)
