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

   ![Link to forks](~/dataminer/images/Contributing_Update_Branch.png)

## Adding cross-references

To avoid adding duplicate information, use cross-references to refer to information that is already available in the documentation.

When you add a cross-reference to a different file, make sure that you always link to the file’s UID. While it is possible to link to the actual file instead, this should be avoided as such a link is broken when the file name or file structure changes. For more information, see [Links and cross-references](xref:CTB_Markdown_Syntax#links-and-cross-references).