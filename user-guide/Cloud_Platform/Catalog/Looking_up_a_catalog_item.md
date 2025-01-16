---
uid: Looking_up_an_item_in_the_catalog
---

# Looking up an item in the Catalog with UI

When you open up the Catalog, a search box is displayed.

1. In the search box, you can enter:

   - (Part of) the name of the item you are looking for (e.g. a connector, a package, etc.).

   - (Part of) a tag given to the item you are looking for (e.g. Master Clock System, Element Manager, etc.)<!--RN 40259-->.

   As you type, a list with the top 5 results will be displayed under the search box.

1. If you cannot find the item you are looking for in the list, click *View all results* at the bottom of the list to open the browse page.

   This page contains all search results, and has filters on the left that allow you to narrow down your search.

   If you only want to see the items that have been registered by your organization, you can use the *All/Public/Private* filter:

   - **All**: This will return search results from all items in the Catalog that you have access to. This includes the private items that are only visible to people in your organization.
   - **Public**: This will only return results that are publicly available to everyone.
   - **Private**: This will only return results from the private items that are only visible to people in your organization.

1. If you see the item you are looking for, click it to open a page where you can see information about that item and its versions.

   From here, you can also [deploy the item to your DataMiner System](xref:Deploying_a_catalog_item).

   > [!TIP]
   > See also: [Versioning of Catalog items](xref:About_the_Catalog_module#versioning-of-catalog-items)

# Looking up versions of an item with the API

The catalog API call allows you to retrieve version information of a Catalog item.

> [!NOTE]
> The API calls are authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). Make sure you use a key that has the *Read catalog items* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

### API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "/api/key-catalog/v2-0/catalogs/{catalogId}/versions" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the call on the production Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g. [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

### HTTP method

GET

### Route parameters

- Route parameter "catalogId" is the ID of the Catalog item of which you want to look up versions from, which is the same as the ID used to [register the Catalog item](#registering-a-catalog-item-with-the-api). This must be a valid GUID.

To obtain this ID for an existing Catalog item, navigate to its details page in the [Catalog](https://catalog.dataminer.services/). The ID is the last part of the URL.