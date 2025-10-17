---
uid: Deploy_Low_Code_App_from_catalog
reviewer: Stephen Lanszweert
---

# Deploying a Low Code App from a Catalog Package

When you deploy a **Low Code App** that is included in a Catalog package, the **version of the app in the package determines the resulting state** of the application on your DataMiner System.

If the app already exists, it will be **overwritten by the version included in the package**.  
The **imported version is always marked as active**, regardless of whether it represents a published or draft version.

## Understanding Deployment Behavior

Each Low Code App can have multiple versions. Each version can be one of the following:

- **Published (P):** The version currently live and accessible to users.
- **Draft (D):** A working version under development, not yet published.

At any given time, a Low Code App can have a maximum of two active versions: one published and one draft.

- When a draft is created, DataMiner uses the currently published version as the base. If the app is newly created and has no published version, the draft starts from an empty state.
- When a draft is published, DataMiner promotes the active draft version to the published version. The draft thereby becomes the new public version of the app.

When importing a package that contains a Low Code App, DataMiner compares the **version in the package** with the **existing versions** on your system and updates the app accordingly.

The following table summarizes how different combinations of existing and imported versions are handled.

| Existing App      | Package App  | Import Result                                                                       | Resulting Versions         |
| ----------------- | ------------ | ----------------------------------------------------------------------------------- | -------------------------- |
| –                 | v5 published | The package v5 is added as a new published version.                                 | **P: 5**, **D: 0**         |
| –                 | v5 draft     | The package v5 is added as a new draft version.                                     | **P: 0**, **D: 5**         |
| v5 published      | v6 published | The existing v5 is replaced by the package v6 (published).                          | **P: 6**, **D: 0**         |
| v5 published      | v6 draft     | The existing v5 remains published. The package v6 becomes the new draft.            | **P: 5**, **D: 6**         |
| v5 draft          | v6 published | The existing v5 remains as draft. The package v6 becomes the new published version. | **P: 6**, **D: 5**         |
| v5 draft          | v6 draft     | The package v6 replaces the v5 draft as the active draft. The existing v5 remains.  | **P: untouched**, **D: 6** |
| v5 draft          | v4 draft     | The package v4 draft is made the active draft.                                      | **P: untouched**, **D: 4** |
| v16–v25 published | v5 published | The package v5 becomes the new active version.                                      | **P: 5**, **D: 0**         |
| v16–v25 published | v5 draft     | The existing published versions remain. The package v5 is added as a draft.         | **P: untouched**, **D: 5** |
| v5 published      | v5 published | The existing v5 is replaced by the package v5 (same version).                       | **P: 5**, **D: untouched** |
| v5 published      | v4 draft     | The package v4 draft is added as a new draft version.                               | **P: 5**, **D: 4**         |
| v5 published      | v5 draft     | The existing published version remains. The package v5 is added as a draft.         | **P: 5**, **D: 5**         |

## Example Scenarios

To better understand how this table applies in practice, here are some typical deployment cases:

### 1. No App Exists Yet

If your system does not yet contain the app and you import a **package with version 5 (published)**,  
DataMiner creates a new app with version **5** as the active published version.

➡️ **Result:** P: 5, D: 0

If instead the package contains version **5 (draft)**,  
the app is added as a **draft**, ready to be published later.

➡️ **Result:** P: 0, D: 5

### 2. Updating an Existing Published App

Suppose your system already has version **5 (published)** and you import a **package containing version 6 (published)**.  
The new version **6** replaces version **5** as the active version.

➡️ **Result:** P: 6, D: 0

If the imported version is **6 (draft)**, then version **5** remains live, and version **6** is added as a draft.

➡️ **Result:** P: 5, D: 6

### 3. Updating a Draft App

If you have version **5 (draft)** on your system and import **version 6 (published)**,  
then version **6** becomes the new active published version, while your existing **draft 5** is preserved.

➡️ **Result:** P: 6, D: 5

If you instead import **version 6 (draft)**,  
your previous draft (**v5**) is replaced by the new draft (**v6**).

➡️ **Result:** P: untouched, D: 6

### 4. Older or Mixed Versions

If your system has **multiple published versions (e.g., v16–v25)** and you import a **package with version 5 (published)**,  
version **5** becomes the new published version.

➡️ **Result:** P: 5, D: 0

If the imported version is **5 (draft)**, your existing published versions remain untouched,  
and a new **draft version 5** is added.

➡️ **Result:** P: untouched, D: 5

## Additional Notes

If an app exists at **version 30** and a **package with version 6** is imported:

- Version **6** is added and marked as **active**.
- A new draft will start from version 6, resulting in **version 31**.

Only the **last 15 versions** are stored in the file system.

- When a new version is created, the **oldest non-active version** is automatically deleted.
- In this example, version **15** (the oldest non-active one) will be deleted.

### See Also

- [Deploying a Catalog Item to Your System](../catalog/deploying-a-catalog-item.md)
- [Viewing Information on Deployments](../admin/viewing-deployments.md)
- [DataMiner Documentation Home](https://docs.dataminer.services/dataminer/DataMiner_index.html)
