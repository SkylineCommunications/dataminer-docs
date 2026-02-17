---
uid: SOL_About
---

# About DataMiner Solutions

DataMiner solutions represent **pre-configured implementations that operate on top of the DataMiner stack**. Leveraging the extensive suite of DataMiner functionalities, these solutions are designed to seamlessly integrate into your system, offering the flexibility to be **utilized as-is or fine-tuned** to suit specific requirements.

Accessible through the [Catalog](xref:About_the_Catalog_app), these solutions encompass a diverse array of configured DataMiner functions, including connectors, alarm and trend templates, visual summaries, automation scripts, dashboards, low-code apps, and user-defined APIs, among others. The composition of components varies across different solutions.

## Solution apps

DataMiner Solutions can include two types of applications: those designed by Skyline to be used "as is" with minimal configuration (DataMiner applications), and sample applications provided for DevOps teams as illustrative examples (sample applications).

### DataMiner applications

DataMiner applications are intended to be used as they are and will continuously evolve with releases that enhance the user experience and features. DataMiner users can obtain copies of these applications and customize them according to their requirements. However, users who choose to customize these applications will not automatically receive updates.

The icons of DataMiner applications are marked with a DataMiner icon to distinguish them from sample applications.

![icon of a dataminer application](~/dataminer/images/DM_Scheduling.png)

### Sample applications

Sample applications are primarily utilized for use cases requiring extensive customization in media operations, such as customer-facing applications. As the name suggests, these applications are merely DevOps examples available in the Catalog, and these are not intended for direct deployment in production environments.

The icons of sample applications are not marked with a DataMiner icon.

![icon of a sample application](~/dataminer/images/FacilityAssetManager.png)

## Standard Data Model

***The backbone model for your business and operation.***

The DataMiner Solutions leverage shared metadata, known as the DataMiner Standard Data Model (SDM), which facilitates interoperability across multiple solutions. For instance, solutions involving scheduled jobs or planned maintenance schedules utilize common datasets defining resources. Consequently, the SDM encompasses DataMiner Object Model (DOM) definitions for various entities, such as jobs, maintenance schedules, and resources, along with the relationships between them. For example, a trouble ticketing DOM object can reference the resources object model, reflecting the attachment of tickets to specific resources.

The SDM serves as the **central repository for managing and organizing your business and operational metadata** in the DataMiner digital twin. It provides a unified structure for capturing various aspects of your organization, including resources, personnel, transponder slot details, jobs, workflows, rate cards, media signals, assets, and more. Designed with flexibility and scalability in mind, the SDM ensures that your data management efforts remain streamlined and future-proof.

Key features:

- **Comprehensive data capture**: The SDM captures a wide range of business and operational metadata, covering essential components such as resources, people, transponders, jobs, workflows, rate cards, services, trouble tickets, assets, and more.

- **Single unified model**: With only one Standard Data Model in existence, your organization benefits from a standardized approach to data management that continues to evolve and grow over time.

- **Based on DataMiner Object Models (DOM) technology**: Leveraging DataMiner Object Model technology, the SDM combines data with states to provide a comprehensive understanding of your organization's dynamics.

- **Relationship descriptions**: The SDM describes relationships between various DataMiner Object Models, unifying all data into a single model.

- **Backwards compatibility**: Datasets (instances) within the Standard Data Model are designed to be backwards compatible, ensuring smooth transitions and minimal disruptions during updates or migrations.

- **Extendable and customizable**: Users can extend the Standard Data Model by linking custom DataMiner Object Models into the SDM, tailoring the framework to their specific organizational needs and requirements

## Updates

Continually evolving along a roadmap, the DataMiner solutions are subject to updates, ensuring compatibility with newer versions while preserving backward compatibility. Updates are facilitated by deploying updated solution packages from the Catalog. You have full autonomy over solution implementations, so you can modify visuals, automation scripts, and more, according to your preferences.

However, keep in mind that if you modify components of a solution, these will be overwritten when you deploy an update of the solution. Consequently, if you intend to tailor solutions to your unique context, we recommend that you **create customized versions** by copying (or branching) them and then applying necessary adjustments, thereby preserving the original solution for future updates.

## Global DOM Modules

This section serves as a centralized registry of well-known DOM modules that are used by solutions. Each entry documents the intended purpose and which solution owns the DOM module. Below DOM modules must not be reused for other purposes.

| Module                       | Solution                                                                                         | Purpose                               |
|------------------------------|--------------------------------------------------------------------------------------------------|---------------------------------------|
| (slc)categories              | [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e)    | Organize items hierarchical.          |
| (slc)connectivity_management | [MediaOps.LIVE](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) | Manage your connections.              |
<!-- TODO: Should errors still be used? -->
| (slc)errors                  | [MediaOps](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75)      | Define errors.                        |
| (slc)orchestration           | [MediaOps.LIVE](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) | Contains the orchestration events.    |
| (slc)people_organizations    | [MediaOps](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75)      | Manage people and organizations.      |
| (slc)relationships           | [MediaOps](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75)      | Make links between different objects. |
| (slc)resource_studio         | [MediaOps](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75)      | Define your resources.                |
| (slc)workflow                | [MediaOps](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75)      | Manage your jobs and workflows.       |
