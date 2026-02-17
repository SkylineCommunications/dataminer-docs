---
uid: Best_Practices_When_Creating_Catalog_Items
keywords: catalog, description, solution, tag, metadata, kata, publish, upload, topic
---

# Best practices when creating Catalog items

On this page, you will find recommendations for creating Catalog items. These will ensure that when you publish a Catalog item, users can easily find it, and they can clearly understand what it is meant for.

> [!TIP]
> To find out how you can publish Catalog items, follow the tutorial [Registering a new version of a user-defined API to the Catalog using Visual Studio and GitHub](xref:CICD_Tutorial_For_Other_Items_User_Defined_API_VisualStudio_And_GitHub).

## Optimize the visibility of your Catalog item

You can optimize the visibility of your Catalog item by making sure the [**Manifest file**](xref:Register_Catalog_Item#manifest-file) is correctly defined:

- Ensure the **name** is clear to the user, so they will know what the solution is meant to be used for. Avoid using technical terms.

- Assign the correct **type** to your Catalog item. Generally, avoid using "Custom Solution" for public Catalog items. For more information about the different types, see [About Catalog items](xref:About_the_Catalog_app#about-catalog-items).

- Add **tags** to help users find your Catalog item. The main goal of tags is to expose the Catalog item to relevant searches. Follow these rules of thumb for the tags:

  - Do not use the name of your Catalog item as a tag.
  - Do not use the type of your Catalog item as a tag.
  - Tags should be user-centric or market-centric.
  - Do not use general DataMiner terms (e.g., "dataminer").
  - Avoid uncommon abbreviations.
  - Use at most 5 tags for one Catalog item.
  - Avoid using plurals when not necessary (e.g., use "Source" instead of "Sources").
  - Use [title case](xref:Title_case).
  - Use at most three words per tag.

- Assign an **icon** to your Catalog item to catch the user's attention. You can do this by defining a vendor for your Catalog item with the `vendor_id` field in the [Manifest file](xref:Register_Catalog_Item#manifest-file). If you need assistance with this, please reach out to your technical contact.

## Optimize the accessibility of your Catalog item

### Add clear and attractive documentation

Help users understand what your Catalog item is, what it does, and what it looks like, by **adding documentation**. This will be shown in the item's description. For details, refer to [Best practices when documenting Catalog items](xref:Best_Practices_When_Documenting_Catalog_Items).

### Use semantic versioning

When you release a version of a Catalog item, make sure to **adhere to [semantic versioning](https://semver.org/)** to ensure clarity and predictability for users. Most Catalog items (except connectors) should follow the standard **A.B.C** semantic versioning format:

- **A (MAJOR)**: Incremented for incompatible changes, breaking changes, or major architectural redesigns that may require user action.

- **B (MINOR)**: Incremented for new functionality added in a backward-compatible manner.

- **C (PATCH)**: Incremented for backward-compatible bug fixes. When a new version range is introduced, the PATCH version (C) should always start at 0, not 1.

**Connectors** use a special **A.B.C.D** format for more detailed versioning. For more information about connector versioning, see [Protocol version semantics](xref:ProtocolVersionSemantics).

> [!NOTE]
> The "CUx" suffix (e.g., 1.2.3-CU2) should only be used exceptionally, in case a critical issue is discovered after a release deployment. In such cases, the released version should be unlisted and a new cumulative update should be released.

### Use clear version descriptions

When you add a new version of a Catalog item, in the version description, clearly state what has changed and if there are bug fixes or new features. Use the following phrases as appropriate: "Change:", "Fix:", "New Feature:". Each phrase can be used multiple times.

### Make sure ranges are tagged correctly

For Catalog items that follow semantic versioning, versions are grouped by range. Tags can be assigned to specific versions and ranges, for instance to indicate the main range of a connector.

Some rules of thumb:

- There should be **only one Main range**, and as **few *Active* ranges as possible**.
- When a range is *Active*, this indicates that the range is still being maintained and bug fixes should always be added to these ranges.
- The *Main* range indicates the latest and most recommended range to install.
- Custom tags on a range should only be used in exceptional cases, where two ranges might be considered but each has its specifics.

### Ownership

Each Catalog item requires at least one owner. The owner should be an individual person, not a team.

- **name**: Full name of the owner. Do not include the email address in this field.
- **email**: Email address of the owner. This is recommended, although it is currently not used in the Catalog interface.
- **url**: A URL associated with the owner, such as a GitHub account URL.

You can specify multiple owners by adding additional entries to the list.

## Keep the limitations in mind

When creating Catalog items, be mindful of the following size limitations:

- **Catalog item packages**: Maximum 250 MB per .zip file upload.
- **Version files**: Maximum 250 MB per .dmprotocol or .dmapplication file.
- **Vendor logos and custom icons**: Maximum 250 KB per image file.

> [!NOTE]
> Images included in your README.md (within the *images* folder) are not subject to the 250 KB per image limitation. This restriction only applies for vendor logos and custom icons.

> [!TIP]
> See also: [Versioning of Catalog items](xref:About_the_Catalog_app#versioning-of-catalog-items)

## Follow the naming conventions

See [Naming conventions for Catalog item components](xref:Naming_Conventions_For_Catalog_Item_Components).
