---
uid: Nuget_Communication_Middleware
---

# Middleware NuGet packages

## Introduction

DataMiner version 10.2.9 (RN33965) enables consuming packages that use external communication, with fewer limitations. However, connection configuration is currently not part of the element configuration card and transferred data is not visible in streamviewer. Asynchronous data setting is no longer an issue, and connection cleanup when the element is stopped is now possible. With this in mind, we expect to see packages that provide OpenConfig, Prometheus, or Ember+ external communication. As these packages bridge the communication api with our scripting environments, we refer to them as middleware packages.

When no middleware is available for your project, please read [Creating a middleware package](#creating-a-middleware-package).

Known packages:
* Skyline.DataMiner.Core.OpenConfig.Gnmi

## OpenConfig

### About

OpenConfig is an open-source project that aims to standardize the way network devices are configured and monitored. At its core, OpenConfig relies on a gRPC connection, which is a high-performance, open-source remote procedure call (RPC) framework. Through this connection, network devices can communicate with the gNMI and gNOI services. The gNMI service definition enables network operators to retrieve and manipulate the configuration and state data of network devices in a standardized way, using YANG models to ensure consistency and interoperability. The gNOI service provides a standardized way for network operators to perform various network operations, such as software upgrades, hardware diagnostics, and device provisioning, also using gRPC and YANG models. By standardizing these operations through gNMI and gNOI, 

> [!NOTE]
> The CommunicationGateway DxM is needed to facilitate the gRPC connection, which requires .NET5 and DataMiner version 10.3.2. The DxM implements the supported gRPC services, which are accessible through middleware packages that communicate over the NATS bus. At the moment, gNMI is supported, while gNOI is not.

### NuGet package

Do the following to use the existing middleware package for OpenConfig:
1. Include the Skyline.DataMiner.Core.OpenConfig.Gnmi NuGet package in your project.
1. Consume the GnmiClient class in your code.
1. Dispose the client object when the QAction class is disposed.

> [!NOTE]
> Ensure that an instance of the CommunicationGateway DxM is running in your cluster. When deploying your code.

## Creating a middleware package

1. Create a `Custom Solutions` repository through the Repo Manager.
    * When creating a vendor-independent solution that communicates with a DxM, 
    * When communicating with a DxM, we suggest storing it under `Custom Solutions -> Generic -> Skyline.DataMiner.Core`
    * When connecting directly to an endpoint, we suggest storing it under `Custom Solutions -> Generic -> Skyline.DataMiner.Utils (ConnectorAPI)`
1. Read and follow the steps in [Producing NuGet packages](xref:Producing_NuGet)

> [!NOTE]
> Don't make your package public if it relies on internal packages.

Take the following into account when writing a middleware package:
* Avoid depending on SLScripting when possible, this will allow the package to be used in code that doesn't run in a QAction. That means the Skyline.DataMiner.Dev.Protocol package should not be included in your project. 
* Try to set up the public methods in such a way that future versions do not change these methods. Make it a major version change if they do change.
* If you rely on an external DLL that is not available as a NuGet package, make sure it is provided with the package unless the license prohibits this.
