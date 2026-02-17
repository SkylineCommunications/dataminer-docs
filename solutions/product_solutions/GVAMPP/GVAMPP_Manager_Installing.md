---
uid: GVAMPP_Manager_Installing
---

# Installing the Grass Valley AMPP Manager Application

## Prerequisites

- **DataMiner 10.4.4/10.5.0** or higher

- A DataMiner System [**connected to dataminer.services**](xref:Connecting_your_DataMiner_System_to_the_cloud)

- **.NET 8.0** (the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))

  This must be installed on the DataMiner Agent where you will deploy the app. If you are running DataMiner 10.4.10 or higher, this should already be installed, as this is also a requirement for recent DataMiner versions.

- A connection to an **AMPP tenancy** via its URL (e.g., `https://mytenancy.gvampp.com`)

- An **API key** generated using the AMPP Identity Manager.

  > [!TIP]
  > Refer to the AMPP documentation hub for specific instructions.

## Deploying the Grass Valley AMPP Manager app

1. Look up the [*GV AMPP Manager Application* package](https://catalog.dataminer.services/details/56870962-1ade-45d2-b7ac-2fbb84383307) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

The *Grass Valley AMPP Manager Application* package includes:

- The **Grass Valley AMPP Manager** connector

- The **GV AMPP Manager** low-code app

- The **AMPP** automation script folder, which includes scripts used in the app to gather data and perform workload and snapshot control operations

- The **SignalR Forwarder application**, which is a .NET Core ASP API application that utilizes Microsoft SignalR libraries for communication with AMPP. It forwards notifications to a listener in a DataMiner element via the GV AMPP Manager connector. Typically, this application is installed on the same DataMiner Agent as the GVAMPP Manager element. It is usually hosted in IIS.

## Installing and configuring the communication component

The Grass Valley AMPP Manager app relies on an external component to communicate with the designated AMPP tenancy. This component must be installed and configured on each DataMiner Agent where an AMPP Manager element will be created.

An automation script included in the package helps with both the installation of this component and the creation of the AMPP Manager element. To run the script:

1. Go to the DataMiner landing page (`https://[DMA]/root/`).

1. Open the *GV AMPP Manager* app.

1. In the app, click the cogwheel ![cogwheel](~/dataminer/images/GV_AMPP_Manager_Configuration_page.png) icon in the sidebar to open the *Setup* page.

   This page provides initial instructions and a link to download and install the Microsoft .NET 8.0 Hosting Bundle, in case this is not installed yet.

1. Click the *Configure* button to launch the configuration script.

   ![AMPP Setup Script](~/dataminer/images/GVAMPP_Setup_Script.png)

1. In the *Dialog* window, provide the following information:

   - **GVAMPP Endpoint**: The URL of the target AMPP tenancy, e.g., `https://mytenancy.gvampp.com`.

   - **API Key**: The key generated using the Identity Manager.

   - **DMA**: For a DMS, select the Agent where the component should be installed and configured.

> [!IMPORTANT]
> If the target Agent already hosts an AMPP Manager element, the script will recognize this and avoid any further configuration.
