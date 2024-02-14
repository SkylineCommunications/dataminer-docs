---
uid: CTB_Watch_out_for
---

# Things to watch out for

## Make sure your fork is up to date

When you are working on your own fork, make sure you regularly **check in GitHub whether your fork is still up to date** with the main repository. To do so:

1. Go to <https://github.com/SkylineCommunications/dataminer-docs>.

1. In the About section on the right, click the link to the forks:

   ![Link to forks](~/images/Contrib_Forks.png)

1. Look up your fork in the list, and click the link to go the page for your own fork.

1. Check the top of your fork page. If it says the branch is a number of commits behind SkylineCommunications:main, your fork is no longer up to date. If there is no such indication, there is no need to continue with this procedure.

   ![Indication of outdated fork](~/images/Contributing_Sync_Fork.png)

1. To update your fork, click the triangle button next to *Sync fork* and select *Update branch*.

   ![Link to forks](~/user-guide/images/Contributing_Update_Branch.png)

## Adding a new page

When you add a page to the documentation:

- Make sure there is a UID at the top of your new file. Add this UID in a metadata section. For example:

  ```md
  ---
  uid: contributing
  ---
  ```

  > [!NOTE]
  > Do not use spaces in a UID.

- Add the new page to the relevant *toc.yml* file so that it is included in the table of contents. To do so, specify the name and UID as follows:

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
    - topicUid: The file UID of the new page
  ```

- Check if there are any smaller content overviews that also need to be updated with a link. For example, if you add something in the user guide, usually there is a page at a higher level in the guide that gives an overview of all underlying pages. Add a link to your new page on that page.

## Adding cross-references

To avoid adding duplicate information, use cross-references to refer to information that is already available in the documentation.

When you add a cross-reference to a different file, make sure that you always link to the file’s UID. While it is possible to link to the actual file instead, this should be avoided as such a link is broken when the file name or file structure changes. For more information, see [Links and cross-references](xref:CTB_Markdown_Syntax#links-and-cross-references).