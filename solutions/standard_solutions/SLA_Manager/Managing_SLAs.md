---
uid: Managing_SLAs
description: Learn how to create, edit, delete, and synchronize SLAs in the DataMiner SLA Manager app, including cascading deletes for primary SLAs.
---

# Managing SLAs

## Creating an SLA

To create an SLA, click the *New SLA* button and complete the wizard:

1. Select the service you want to track.

   The service must already exist on your DataMiner System. SLA Manager does not create services.

1. Optionally select a configuration template to prefill the tracking window and violation budget settings.

   For more information, see [Managing SLA templates](xref:Managing_SLA_Templates).

1. Specify the service level tier, tracking window, admin state, and objective type.

1. Confirm to create the SLA.

## Editing an SLA

To edit an SLA, open its detail view and click *Edit*. You can change the name, service level tier, objective type, validity window, and admin state. A summary of your changes is shown before you save them.

## Deleting an SLA

To delete an SLA, open its detail view and click *Delete*.

> [!NOTE]
> Deleting a primary SLA also deletes its secondary SLAs. You must confirm this cascading delete before it is applied.

## Synchronizing the inventory

Click the *Sync* button in the app header to synchronize the inventory with the SLA elements on your DataMiner System. Synchronization also runs automatically right after installation.
