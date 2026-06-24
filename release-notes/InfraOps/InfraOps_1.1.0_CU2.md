---
uid: InfraOps_1.1.0_CU2
---

# InfraOps 1.1.0 CU2

## Fixes

#### Various fixes [ID 45793]

Several issues have been resolved:

- Fixed an issue where rack layout images were not loading correctly in the visual rack editor due to incorrect file paths.
- Fixed the Room Designer web component not rendering because the LCA Webpage component had sandbox mode enabled, which restricted the embedded page from loading.
- Removed duplicate-name validation from Facility Manager create/edit wizards that was incorrectly preventing users from creating entities with the same name in different parent locations.
