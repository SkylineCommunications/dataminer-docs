---
uid: Installing_MediaOps
---

# Installing dataminer.MediaOps

> [!NOTE]
> The MediaOps package is currently not yet available for deployment from the Catalog.

## Prerequisites

- A DaaS system.

  > [!NOTE]
  > If you do not have a DaaS system available yet, [spin up a new DaaS system](xref:Creating_a_DMS_on_dataminer_services).

- The latest version of the [SRM framework](xref:deploying_srm). TODO THIS WILL NO LONGER BE NEEDED

- The following Soft-launch options:

  - TODO

- The following user permissions:

  - [General > DataMiner web apps](xref:DataMiner_user_permissions#general--dataminer-web-apps)

  - [General > Elements > Access](xref:DataMiner_user_permissions#general--elements--access)

  - [General > Elements > Data Display > Access](xref:DataMiner_user_permissions#general--elements--data-display--access)

  - [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute)

  - [Modules > Bookings](xref:DataMiner_user_permissions#modules--bookings)

  - [Modules > Profiles > UI available](xref:DataMiner_user_permissions#modules--profiles--ui-available)

  - [Modules > Profiles > All except instances > Add/Edit](xref:DataMiner_user_permissions#modules--profiles--all-except-instances--addedit)

  - [Modules > Profiles > All except instances > Delete](xref:DataMiner_user_permissions#modules--profiles--all-except-instances--delete)

  - [Modules > Resources](xref:DataMiner_user_permissions#modules--resources)

  - [Modules > Scheduler](xref:DataMiner_user_permissions#modules--scheduler)

  - [Modules > Services > UI available](xref:DataMiner_user_permissions#modules--services--ui-available)

  - [Modules > User-definable apps > View apps](xref:DataMiner_user_permissions#modules--user-definable-apps--view-apps)

## Deploying the MediaOps package

dataminer.MediaOps is not yet available in the DataMiner Catalog, but a package can be provided upon request.

If you want to try out the apps using demo data, you can then run the *Generate Demo Data* script in the Automation module in DataMiner Cube. This script is included in the MediaOps package. Keep in mind that this script will generate a significant amount of data and will take some time to complete. It will also generate a number of elements in the system. If you no longer want these later, you will need to remove them manually.

> [!TIP]
> If you have any questions or need assistance to get started with dataminer.mediaOps, contact <support.mediaops@skyline.be>.
