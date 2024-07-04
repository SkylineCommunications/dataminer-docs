---
uid: Catalog_API
---

# Catalog API

The Catalog API can be used to interact with the DataMiner Catalog, for example to [register a Catalog item](xref:Register_Catalog_Item#using-the-catalog-api).

Below you can find an overview of the methods available in the Catalog API (V2).

- GET api/user-catalog/v2-0/catalogs/search

  Searches for Catalog items.

- GET api/user-catalog/v2-0/catalogs/{catalogId}

  Fetches a Catalog item by ID.

- GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/download

  Downloads a specific version of a specific Catalog item.

- GET api/user-catalog/v2-0/catalogs/{catalogId}/ranges?organizationId={organizationId}

  Fetches the ranges for a specific Catalog item.

- PATCH api/user-catalog/v2-0/catalogs/{catalogId}/ranges/{rangeId}?organizationId={organizationId}/custom-tag

  Updates a custom tag of a specific range of a specific Catalog item.

- DELETE api/user-catalog/v2-0/catalogs/{catalogId}/ranges/{rangeId}?organizationId={organizationId}/custom-tag

  Removes a custom tag of a specific range of a specific Catalog item.

- GET api/user-catalog/v2-0/catalogs/{catalogId}/versions?organizationId={organizationId}&rangeId={rangeId}

  Fetches the versions for a specific Catalog item.

- GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/latest?organizationId={organizationId}

  Fetches the latest available version of a specific Catalog item.

- GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/recommended?organizationId={organizationId}

  Fetches the recommended versions of a specific Catalog item.

- GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/can-deploy?organizationId={organizationId}

  Verifies if a Catalog item version can be deployed.

- GET api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/can-deploy-dms?organizationId={organizationId}

  Verifies if a Catalog item version can be deployed on the available DataMiner Systems.

- POST api/user-catalog/v2-0/catalogs/{catalogId}/ranges/versions/{versionId}/deploy

  Deploys a specific version of a specific Catalog item.

- POST api/user-catalog/v2-0/catalogs/register

  Registers a Catalog item.

- PATCH api/user-catalog/v2-0/catalogs/{catalogId}/publishing-state?organizationId={organizationId}

  Sets the publishing state of a Catalog item.

- PATCH api/user-catalog/v2-0/catalogs/{catalogId}/version/{versionId}/publishing-state?organizationId={organizationId}

  Sets the publishing state of a Catalog version.

- PATCH api/user-catalog/v2-0/catalogs/{catalogId}/ranges/{rangeId}/state?organizationId={organizationId}

  Sets the state of a specific range of a specific Catalog item.

- PATCH api/user-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/state?organizationId={organizationId}

  Sets the state of a specific version of a specific Catalog item.
