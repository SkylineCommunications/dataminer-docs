---
uid: Best_Practices_When_Creating_Catalog_Items
keywords: catalog, description, solution, tag, metadata, kata, publish, upload, topic
---

# Best practices when creating Catalog items

On this page, you will find information about what is necessary when creating Catalog items. When publishing a Catalog item, ensure that users can easily find the item and, once found, clearly understand what it is about. You can add metadata to augment the Catalog item and improve its discoverability.

> [!TIP]
> Learn more about publishing Catalog Items [here](xref:CICD_Tutorial_For_Other_Items_User_Defined_API_VisualStudio_And_GitHub).

## Increase visibility

You can increase the visibility of your Catalog item by making sure the [Manifest file](xref:Register_Catalog_Item#manifest-file) is correctly defined.

- Ensure the name is clear to the user and addresses the solution rather than using technical terms.
- Assign the correct type to your Catalog item. Generally, avoid using 'Custom Solution' for public Catalog items. More information about the different types can be found [here](xref:About_the_Catalog_app#about-catalog-items).

Furthermore, you can add tags to help users find your Catalog item. The main goal of tags is to expose the Catalog item to relevant searches. Follow these rules of thumb:

- Do not use the name of your Catalog item as a tag.
- Do not use the type of your Catalog item as a tag.
- Tags should be user- or market-centric.
- Do not use general DataMiner terms (e.g., "dataminer").
- Avoid uncommon abbreviations.
- Use no more than 5 tags.
- Avoid using plurals when not necessary (e.g., use "Source" instead of "Sources").
- Use Title Case.
- Do not use more than three words per tag.

Finally, catch the user's attention by assigning an icon to your Catalog item. You can do this by defining a vendor for your Catalog item with the 'vendor_id' field in the [Manifest file](xref:Register_Catalog_Item#manifest-file). Please reach out to your technical contact for assistance.

## Increase accessibility

Once the user is viewing your Catalog item, provide additional information to help them understand what the item is, what it does, and ideally how it looks. It is highly recommended to follow the [Best practices when documenting Catalog items](xref:Best_Practices_When_Documenting_Catalog_Items). Documentation should be concise and not reveal too many technical details. Technical documentation should not be available directly in the Catalog, but you can add a link (see *documentation_url* in the [Manifest file](xref:Register_Catalog_Item#manifest-file)) to direct users to more detailed documentation. For substantial solutions developed by Skyline, this is typically found on [DataMiner Solutions](xref:solution_index); for smaller items, this could be a link to markdown pages in the public source code repository.

If the source code is open source, you can also provide a link using the *source_code_url* field in the [Manifest file](xref:Register_Catalog_Item#manifest-file).

When releasing a version, make sure to adhere to [Semantic Versioning (A.B.C)](xref:About_the_Catalog_app#versioning-of-catalog-items). Using a postfix (such as -CU1) is only necessary in exceptional circumstances (e.g., if you released a version that you immediately unlisted due to a severe bug. You should not delete this version, but unlist it. Once a fix has been made, it is appropriate to use CU to clarify the situation to users). For the version description, clearly state what has changed, if there are bug fixes, or new features. Use the following phrases as appropriate: "Change: ", "Fix: ", "New Feature: ". Each phrase can be used multiple times.

Use the appropriate state for the Range (Active, Main, custom tag, or Deprecated). As a rule of thumb, there should be only one Main range, and as few *Active* ranges as possible. Having an *Active* range indicates that the range is still being maintained and bug fixes should always be added to these ranges. The *Main* range indicates the latest and most recommended range to install. *Custom tags* on a Range should only be used in exceptional cases, where two ranges might be considered but each has its specifics.
