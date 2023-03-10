---
uid: Interactive_Automation_Script_Toolkit
---

# Interactive Automation Script Toolkit

## About

The Interactive Automation Script Toolkit (or “IAS Toolkit” in short) is a class library that can be used to create interactive Automation scripts. Its main purpose is to make developing interactive Automation scripts easier. Where you previously had to deal with UIBlocks of different types, you can now use TextBoxes and Buttons.

Main features:

- Widgets instead of UIBlocks

- Focus on building scripts

- Handling UI updates is done in the background

- Easily create complex and robust scripts

- Introduces eventing

- Reduces development time

## Versions

#### 1.0.4.3

Version 1.0.4.3 is the first version of the toolkit that was made available as a class library. It is compatible with DataMiner version 10.0.5.0-9038 and higher.

- You can download the 1.0.4.3 toolkit from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-4-3/).

- You can download the 1.0.4.3 toolkit documentation from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-4-3-documentation/).

#### 1.0.5.2

Version 1.0.5.2 of the toolkit adds support for TreeViews. It is compatible with DataMiner version 10.1.2.0-9815 and higher.

- You can download the 1.0.5.2 toolkit from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-5-2-10-1-2-0-9815/).

- You can download the 1.0.5.2 toolkit documentation from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-5-2-documentation/).

#### 1.0.6.5

Version 1.0.6.5 of the toolkit fixes some issues with the TreeView widget. It is compatible with DataMiner 10.1.5.0-10032 and higher.

- You can download the 1.0.6.5 toolkit from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-6-5-10-1-5-0-10032/).

- You can download the 1.0.6.5 toolkit documentation from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-6-5-documentation/).

#### 1.0.7.2

Version 1.0.7.2 of the toolkit adds support for uploading files using the FileSelector widget. It is compatible with DataMiner 10.1.8 and higher.

- You can download the 1.0.7.2 toolkit from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-7-2-10-1-8/).

- You can download the 1.0.7.2 toolkit documentation from [DataMiner Dojo](https://community.dataminer.services/download/ias-toolkit-1-0-7-2-documentation/).

## Installation

Installation of the Interactive Automation Script Toolkit is the same as for any other class library.

You will need:

- [Visual Studio](xref:TOOVisualStudio)

- [The DIS plugin](xref:DIS)

- A version of the [IAS Toolkit](#versions) compatible with your DataMiner version

To install the toolkit:

1. Download the version of the toolkit that is compatible with your DataMiner version. You can do so using the links in the version overview above, or via the [overview of the class library packages](https://community.dataminer.services/class-library-packages/). Once you have downloaded your version, you do not need to unzip it. Just place it somewhere where you can easily find it again.

1. In Visual Studio, navigate to the DIS menu and open the DIS settings.

1. In the Class Library tab, add a new class library and link it to the downloaded zip file. It should look something like this:

   ![ClassLibrary](~/develop/images/ClassLibrarySettings.png)

You are now ready to start using the Interactive Automation Script Toolkit.

> [!TIP]
> For more information on how to get started, see [Getting started with the IAS Toolkit](xref:Getting_Started_with_the_IAS_Toolkit).
