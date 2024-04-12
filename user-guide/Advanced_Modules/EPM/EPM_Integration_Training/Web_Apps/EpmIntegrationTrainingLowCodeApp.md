---
uid: EpmIntegrationTrainingLowCodeApp
---

# EPM and Low-Code Apps

The [DataMiner Low-Code Apps](xref:Application_framework) module is similar to the Dashboards, but provides a lot more functionality, so that it can be used to create complete custom applications that interact with data from the EPM setup.

When you have deployed the *EPM Integration Training* package, the **EPM Integration Training** low-code app will be available. This app is designed to facilitate a hands-on understanding of EPM systems. It consists of the following pages:

- **Topology Chains**: This page contains buttons corresponding to each topology type. Clicking a button opens a window showcasing the topology chain filter. It links directly to the Monitoring app for a filtered view based on the chain name, using a link in the format `http(s)://<DMA IP>/monitoring/element/<DMA ID>/<element ID>/chain/<chain name>`.

- **Entities Overview**: This page illustrates how foreign keys are used to filter EPM tables. It showcases how to streamline the viewing and management of interconnected data within the EPM ecosystem.

- **Customer**: This page uses an EPM feed to filter on customer information within the EPM customer table. This approach simplifies the process of accessing and analyzing customer data by applying targeted filters to streamline data searches.
