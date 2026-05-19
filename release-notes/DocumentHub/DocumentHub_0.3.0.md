---
uid: DocumentHub_0.3.0
---

# DocumentHub 0.3.0 (deprecated)

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.9/10.6.0 or higher
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher

## New features

#### DOM attachments support, protection of sensitive data, and filtering on bucket [ID 45319]

The DocumentHub Solution can now list all documents that are attached to DOM instances through DOM attachments and show the linked instance. To support DOM attachments, a shared drive can be configured.

In addition, in the backend, protection for sensitive data has been implemented so that the Azure App Registration Client Secret (for SP integration) is safely stored.

Finally, filtering on bucket has been implemented. For each storage type, the buckets created in DocumentHub can be viewed and tested.
