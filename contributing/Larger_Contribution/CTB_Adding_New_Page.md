---
uid: CTB_Adding_New_Page
---

# Adding a new page

To add a new page to the documentation:

1. In Visual Studio Code, add a new markdown file to the correct folder in the repository, ensuring it carries the `.md` extension.

   ![New .md file](~/contributing/images/New_md_File.png)

1. Add a UID at the top of your new file. Add this UID in a metadata section. For example:

   ```md
   ---
   uid: contributing
   ---
   ```

   > [!NOTE]
   > Do not use spaces in a UID.

   > [!TIP]
   > Optionally, you can also add a line with keywords below the UID to make the page easier to find based on specific search queries. See [Keywords](xref:CTB_Markdown_Syntax#keywords).

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

1. When your page is ready, [create a pull request](xref:CTB_Creating_PR).
