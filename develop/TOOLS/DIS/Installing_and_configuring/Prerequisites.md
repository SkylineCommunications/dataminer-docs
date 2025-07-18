---
uid: Prerequisites
---

# Prerequisites

## Communication

DataMiner Integration Studio has to be able to connect to addresses in the following ranges:

```txt
https://login.microsoftonline.com/*
https://aadcdn.msftauth.net/*
https://dataminerservices.b2clogin.com/*
https://*.dataminer.services/*
https://*.skyline.be/*
https://cdnjs.cloudflare.com/*
https://stackpath.bootstrapcdn.com/*
```

> [!NOTE]
> To use NuGet packages, you will need to establish a connection with the required NuGet package sources, e.g. <https://api.nuget.org/v3/index.json>

## Microsoft Visual Studio

- DIS versions up to v2.0.3 require at least Microsoft Visual Studio 2010.
- DIS versions as from v2.0.4 require at least Microsoft Visual Studio 2012.
- DIS versions as from v2.20.1 require at least Microsoft Visual Studio 2015.
- DIS versions as from v2.35.1 require at least Microsoft Visual Studio 2017.
- DIS versions as from v2.41 require at least Microsoft Visual Studio 2019.
- DIS versions as from v3.0 require at least Microsoft Visual Studio 2022.

> [!NOTE]
> Make sure your version of Visual Studio is up to date. If you have an outdated version, the installer may detect missing prerequisites and therefore prevent you from installing the extension.

> [!IMPORTANT]
> DIS works with Visual Studio Community, Visual Studio Professional, and Visual Studio Enterprise. Visual Studio Code and Visual Studio for Mac are not supported.

### nuget.org configuration

Make sure you have configured and enabled [nuget.org](https://api.nuget.org/v3/index.json) in Visual Studio.

This is a requirement to be able to automatically install DataMiner templates when Microsoft Visual Studio is opened after DIS is installed (which happens as of DIS 2.42).

### Required user permissions

You need the following DataMiner user permissions to have access to all DIS functionality:

- [Modules > Automation > UI available](xref:DataMiner_user_permissions#modules--automation--ui-available)
- [Modules > Automation > Add](xref:DataMiner_user_permissions#modules--automation--add)
- [Modules > Automation > Edit](xref:DataMiner_user_permissions#modules--automation--edit)
- [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute)
- [Modules > Protocols & Templates > Protocols > UI available](xref:DataMiner_user_permissions#modules--protocols--templates--protocols--ui-available)
- [Modules > Protocols & Templates > Protocols > Add](xref:DataMiner_user_permissions#modules--protocols--templates--protocols--add)
- [Modules > Protocols & Templates > Protocols > Edit](xref:DataMiner_user_permissions#modules--protocols--templates--protocols--edit)
- [Modules > System configuration > Agents > Install App packages](xref:DataMiner_user_permissions#modules--system-configuration--agents--install-app-packages)
