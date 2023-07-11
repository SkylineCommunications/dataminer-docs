---
uid: VisualStudioTemplates
---

# Visual Studio Templates

The .NET SDK comes with many templates and also allows the creation of custom templates. By default, when you install .NET SDK, this includes many templates that you can, among others, use via the [dotnet new](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) command. For example, to create a new console application via the command line or a terminal in Visual Studio Code, you can use the following command:

```dotnetcli
dotnet new console -n ExampleConsoleApp
```

It is also possible to create custom templates. We have created DataMiner-related templates that are stored in a public [GitHub repository](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates). The templates have been released as a NuGet package [Skyline.DataMiner.VisualStudioTemplates](https://www.nuget.org/packages/Skyline.DataMiner.VisualStudioTemplates).

> [!NOTE]
> There is also another NuGet package, [Skyline.DataMiner.VisualStudioTemplates.Internal](https://www.nuget.org/packages/Skyline.DataMiner.VisualStudioTemplates.Internal), to be used by Skyline employees only.

If you use Visual Studio 2022, the new templates will also be available for you in Visual Studio when you create a new project. Select *File* > *New* > *Project*, and you will see them in the *Create a new project* window.

![Visual Studio Create a new project window](~/develop/images/VisualStudioTemplates1.png)

These new templates are supported in DIS from v2.42 onwards. It automatically installs the templates package when you open Visual Studio. As soon as more recent versions become available, they will also automatically get installed.

You can also make your own customized templates based on the templates we have introduced. If you fork our [GitHub repository](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates), you will be able to customize the template exactly the way you want it (e.g. add your own copyright, add default values such as the provider in the connector template, etc.). Then create a NuGet package for your customized templates and install that NuGet package instead of the one we provide.

In DIS, you can then also make sure your own customized templates are used by specifying the NuGet package ID in the settings window.

![DIS Settings window](~/develop/images/VisualStudioTemplates2.png)

You can also use the *dotnet new* command to manage the templates. To install the templates, use the *dotnet new install* command:

```dotnetcli
dotnet new install Skyline.DataMiner.VisualStudioTemplates
```

This will install the NuGet package. When that is done, you can create a connector or Automation script solution via the dotnet CLI. For example, to create a new Automation script solution, you can use the following command:

```dotnetcli
dotnet new dataminer-automation-solution -name "ExampleScript" -auth "Joe"
```

To see all the available options for a template, use the command `dotnet new <template-name> --help`. For example:

```dotnetcli
dotnet new dataminer-connector-solution --help
```
