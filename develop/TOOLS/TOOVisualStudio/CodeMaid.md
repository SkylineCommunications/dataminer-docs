---
uid: CodeMaid
---

# CodeMaid

Visual Studio plugin that can be used to clean up code and fix formatting issues.

## Installation

1. In Visual Studio, go to *Tools* > *Extensions and Updates*.

2. In the pop-up window, select *Online* and search for *CodeMaid*.

	![](~/develop/images/Codemaid_download.png)

3. Click *Download* for the CodeMaid result. (Normally this will be the only available result.)

4. Restart Visual Studio.

## Configuration

- By default, CodeMaid does not handle rule SA1516 for single-line properties. To enable this:

    1. Go to *CodeMaid* > *Options*.

    2. In the *CodeMaid Options* window, go to *Cleaning* > *Insert.*

    3. Click *single-line properties* to enable this option and click *Save*.

	![](~/develop/images/codemaid_options.png)

- By default, the *CodeMaid Spade* panel will be opened.

    Close this panel to save memory and prevent Visual Studio from running more slowly.

	![](~/develop/images/codemaid_spade.png)

## Usage

CodeMaid has, among others, two features that allow automatic StyleCop fixes: reorganize and cleanup.

Take into account the following example:

![](~/develop/images/codemaid_example.png)

- First reorganize the active document: right-click and select *CodeMaid* > *Reorganize Active Document*.

	![](~/develop/images/codemaid_reorganize.png)

    The document will then be reordered. This may take some time for large QActions.     Reordering a document will fix:

    - SA1201

    - SA1202

    - SA1203

    - SA1204

    - SA1215

    - SA1216

- Then clean up the active document (this should be always done in this order, because reordering will not respect spacing rules):

	![](~/develop/images/codemaid_cleanup.png)

    All other warnings will then be fixed. There is no complete list of all StyleCop warning that it will fix. More information can be found here: <br><http://www.codemaid.net/documentation/#cleaning>.

- For large QActions (e.g. Cisco DCM QAction 1), these operations can fail, causing an OutOfMemory exception. In that case, you should split the code into smaller pieces (one namespace at a time) in a new Visual Studio window and perform the operation with those.
