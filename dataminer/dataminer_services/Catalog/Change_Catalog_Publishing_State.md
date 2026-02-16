---
uid: Change_Catalog_Publishing_State
reviewer: Alexander Verkest
---

# Change the publishing state of a Catalog item

Catalog items can have the "public" or "private" publishing state. All users can see public items, but private items are only available to users within the organization that published those items.

To make a private item available to all users, or to make a public item available to the publishing organization only, you need to change the publishing state of the item. You can do so [using the Catalog UI](#changing-the-publishing-state-using-the-catalog-ui) or [using the Catalog API](#changing-the-publishing-state-using-the-catalog-api).

## Changing the publishing state using the Catalog UI

1. Navigate to the [Catalog](https://catalog.dataminer.services/) and make sure you are signed in.

1. Make sure the correct organization is selected in the top-right corner.

1. [Go to the details page](xref:Looking_up_an_item_in_the_catalog) of the Catalog item.

1. At the top of the page, click the ![Context menu button](~/dataminer/images/Catalog_context_menu.png) button and select *Make private* or *Make public*.

   If you cannot see these options, double-check whether the correct organization is selected, because these will only be shown for members of the organization that published the item.

> [!NOTE]
> You must have the Owner or Admin role in the organization that published the Catalog item in order to change the publishing state. If you have the Member role, you will be able to see the option to change the publishing state, but an error message will be shown if you try to use it.

## Changing the publishing state using the Catalog API

The *publishing-state* API call allows you to change the publishing state of a Catalog item using an HTTP PATCH request and an organization key to authenticate.

> [!NOTE]
> The API calls are authenticated using [organization keys](xref:Managing_dataminer_services_keys#organization-keys). Make sure you use a key that has the *Update Catalog publishing state* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

### API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "publishing-state" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the publishing-state call on the Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g., [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

### HTTP method

PATCH

### Body

The body of the request should contain the publishing state in the body of the PATCH request (use raw - json).

- A value of *true* will result in the Catalog item being published as publicly available.
- A value of *false* will result in the Catalog item being published as private, i.e., only accessible to users included in the organization to which the item is linked.
- If the patch was successful, an *HTTP 200 OK* response will be returned with the updated value of the state in the body.
