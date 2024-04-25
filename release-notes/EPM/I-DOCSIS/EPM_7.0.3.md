---
uid: EPM_7.0.3_I-DOCSIS
---

# EPM 7.0.3 I-DOCSIS (preview)

> [!IMPORTANT]
> We are still working on this release. Release notes may still be added, modified, or moved to a later release. Check back soon for updates!

## New features

#### EPM_I_DOCSIS_AddNewCcapCmPair improvements [ID_39450]

Several improvements have been implemented in the EPM_I_DOCSIS_AddNewCcapCmPair script, which is used to create a new CCAP.

- Every page now includes a *Cancel* button, which you can use the terminate the script.
- Validation on fields now prevents the user from proceeding if fields still need to be filled in.
- When the script has been fully executed, a final page is now displayed with important information regarding the element creation process. If a message labeled as "[ERROR]" is shown in this window, this means that the creation of a specific element could not be completed. If a message labeled as "[INFO]" is shown, this message contains important information regarding the creation of elements.
