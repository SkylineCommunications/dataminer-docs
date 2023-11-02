---
uid: Web_apps_Feature_Release_10.4.1
---

# DataMiner web apps Feature Release 10.4.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.1](xref:General_Feature_Release_10.4.1).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Low-Code Apps: Panels would not stack in the correct order [ID_37696]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Panels would not stack in the correct order. From now on, they will stack in the order in which they were opened, and panels opening as pop-up windows will always stack on top of the left/right panels.

#### Low-Code Apps: Initials would be displayed instead of user icon in edit mode [ID_37700]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In edit mode, the user's initials would be displayed instead of the user icon.

> [!NOTE]
> In all DataMiner web apps, the user's initials will be displayed until the user icon has been retrieved.

#### Web APIs: Changes made to a user's access level would not be applied immediately [ID_37730]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When the access level of a user was changed, up to now, that change would not immediately get applied to existing Web API connections.
