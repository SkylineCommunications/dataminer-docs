---
uid: Change_Catalog_Publishing_State
---

# Change publishing state of a Catalog item

In order to make a Catalog item available to everyone or to the publishing organization only, you can use the UI or Catalog API.
- [Change publishing state with Catalog UI](#change-publishing-state-with-the-catalog-ui)
- [Change publishing state with the API](#change-publishing-state-with-the-api)

## Change publishing state with the Catalog UI

Navigate to [Catalog](https://catalog.dataminer.services/), sign in with your account and open the details page of the Catalog item.
A "Make private" or "Make public" button is shown in the top of the page.

> [!IMPORTANT]
> You must be Owner or Admin of the organization that published the Catalog item in order to change the publishing state. You will still see the button as a Member, but an error message will be returned if you try to update the state.

> You must have the publishing organization selected in order to see the "Make private" or "Make public" button.

## Change publishing state with the API

The publishing-state API call allows you to change the publishing state of a Catalog item using a HTTP PATCH request and an organization key to authenticate.

> [!IMPORTANT]
> The API calls are authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). Make sure you use a key that has the *Update catalog publishing state* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

### API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "publishing-state" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the publishing-state call on the Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g. [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

### HTTP method

PATCH

### Body

The body of the request should contain the publishing state in the body of the PATCH request (use raw - json).
- A value of true will result in having the catalog item published as publicly available.
- A value of false will result in having the catalog item published as private, i.e. only accessible to users included in the organization to which the item is linked.
- If the patch was successful, an HTTP 200 OK response will be returned with the updated value of the state in the body.