---
uid: Nuget_Communication_Middleware
---

# Middleware NuGet packages

## Introduction

DataMiner version 10.2.9 (RN 33965) enables consuming packages that use external communication, with fewer limitations. However, connection configuration is currently not part of the element configuration card, and transferred data is not visible in Stream Viewer. Asynchronous data setting is no longer an issue, and connection cleanup when the element is stopped is now possible. With this in mind, we expect to see packages that provide OpenConfig, Prometheus, or Ember+ external communication. As these packages bridge the communication API with our scripting environments, we refer to them as middleware packages.

If no middleware is available for your project, please read [Creating a middleware package](#creating-a-middleware-package).

Known packages:

- [Skyline.DataMiner.DataSources.OpenConfig.Gnmi](xref:DSI_OpenConfig_Middleware)

## Creating a middleware package

1. Create a `Custom Solutions` repository through the Repo Manager.

   - Add it to the folder `Custom Solutions > Generic > Skyline.DataMiner.Utils (DataSources)`.

   - Use the following namespace in your solution: *Skyline.DataMiner.DataSources.\**

1. Read and follow the steps under [Producing NuGet packages](xref:Producing_NuGet)

> [!NOTE]
> Do not make your package public if it relies on internal packages.

> [!NOTE]
> Take the following into account when writing a middleware package:
>
> - Avoid depending on SLScripting when possible. This will allow the package to be used in code that does not run in a QAction. That means the Skyline.DataMiner.Dev.Protocol package should not be included in your project.
> - Try to set up the public methods in such a way that future versions do not change these methods. Make it a major version change if they do change.
> - If you rely on an external DLL that is not available as a NuGet package, make sure it is provided with the package unless the license prohibits this.
