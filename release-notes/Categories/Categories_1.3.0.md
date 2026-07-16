---
uid: Categories_1.3.0
---

# Categories 1.3.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### DevPack: Support for category icons [ID 45956]

You can now associate an icon with each category by using the new `Icon` property on the category model.

#### Categories app: Category icon selection and configuration support [ID 45957]

The Categories app has been updated so you can now select and configure category icons.

### Fixes

#### Categories app: Default exception shown when scope was missing [ID 45960]

Clicking **New Category** or **Delete Categories** when no scope was defined caused a default exception with a stack trace.

This now shows a clear message indicating that the scope is missing.
