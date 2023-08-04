---
uid: Prerequisites
---

# Prerequisites

## Communication

DataMiner Integration Studio has to be able to connect to addresses in the following ranges:

```txt
https://login.microsoftonline.com/*
https://aadcdn.msftauth.net/*
https://*.dataminer.services/*
https://*.skyline.be/*
```

> [!NOTE]
> To use NuGet packages, you will need to establish a connection with the required NuGet package sources, e.g. <https://api.nuget.org/v3/index.json>

## Microsoft Visual Studio

- DIS versions up to v2.0.3 require at least Microsoft Visual Studio 2010.
- DIS versions as from v2.0.4 require at least Microsoft Visual Studio 2012.
- DIS versions as from v2.20.1 require at least Microsoft Visual Studio 2015.
- DIS versions as from v2.35.1 require at least Microsoft Visual Studio 2017.
- DIS versions as from v2.41 require at least Microsoft Visual Studio 2019.

> [!NOTE]
> Make sure your version of Visual Studio is up to date. If you have an outdated version, the installer may detect missing prerequisites and therefore prevent you from installing the extension.

> [!IMPORTANT]
> DIS works with Visual Studio Community, Visual Studio Professional, and Visual Studio Enterprise.
> Visual Studio Code and Visual Studio for Mac are not supported.
