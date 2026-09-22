---
metadata_version: 1
uid: CTB_Adding_New_Page
description: Add a new DataMiner documentation page with valid front matter, navigation, cross-references, and the version 1 metadata contract.
area: contributing
content_type: conceptual
authority: reference
authority_source: CTB_Documentation_Metadata
applies_to:
  - DataMiner documentation
version: unversioned
owner: unknown
---

# Adding a new page

To add a new page to the documentation:

1. In Visual Studio Code, add a new markdown file to the correct folder in the repository, ensuring it carries the `.md` extension.

   ![New .md file](~/contributing/images/New_md_File.png)

1. Add version 1 metadata at the top of your new file. The metadata must include a unique UID and every required field described in [Documentation metadata contract](xref:CTB_Documentation_Metadata). Select the content type that describes the page rather than the folder where the file is stored. The contract includes complete examples for conceptual, schema, API, example, release-note, and legacy pages.

   ```md
   ---
   metadata_version: 1
   uid: My_new_page
   description: Describe the page in 100 to 155 characters so search results and page previews explain the page clearly.
   area: dataminer
   content_type: conceptual
   authority: reference
   authority_source: unknown
   applies_to:
     - DataMiner
   version: unversioned
   owner: unknown
   ---
   ```

   > [!NOTE]
   > Do not use spaces in a UID.

   > [!TIP]
   > You can also add a `keywords` line to make the page easier to find based on specific search queries. See [Keywords](xref:CTB_Markdown_Syntax#keywords).

   > [!IMPORTANT]
   > Do not invent an owner handle, product applicability, or version notation. Use an existing value, or use the exact `unknown`, `not_applicable`, or `unversioned` value allowed by the metadata contract. Preserve an existing UID and published URL when you edit a page.

1. Add the new page to the relevant *toc.yml* file so that it is included in the table of contents. To do so, specify the name and UID as follows:

   ```yml
   - name: The name of the page as it should appear in the table of contents
     topicUid: The file UID
   ```

   For example:

   ```yml
   - name: Basic concepts
     topicUid: BasicConcepts
   ```

   To add the new page at a lower level in the table of contents, use the following syntax:

   ```yml
   - name: The name of the page at the level above the page you are adding
     topicUid: The file UID
     items:
       - name: The name of the new page as it should appear in the table of contents
         topicUid: The file UID of the new page
   ```

   ![Add new page to toc.yml file](~/contributing/images/New_page_TOC.gif)

1. Check if there are any smaller content overviews that also need to be updated with a link, for example on a page at a higher level in the table of contents. See [Links and cross-references](xref:CTB_Markdown_Syntax#links-and-cross-references).

1. Validate the metadata for the new page from the repository root:

   ```powershell
   .\scripts\validate-documentation-metadata.ps1 -RepositoryRoot . -Path .\path\to\new-page.md -RequireVersion1
   ```

   The validator reads the approved schema and rejects missing fields, undocumented keys, invalid controlled values, invalid dates, and ambiguous `unknown` or `not_applicable` values.

1. When your page is ready, [create a pull request](xref:CTB_Creating_PR).
