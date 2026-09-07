---
uid: InfraOps_1.1.0_CU2
---

# InfraOps 1.1.0 CU2

## Fixes

#### Various fixes [ID 45793]

Several issues have been resolved:

- Fixed an issue where rack layout images were not loading correctly in the visual rack editor because of incorrect file paths.
- Fixed the Room Designer web component not rendering because the low-code app Web component had sandbox mode enabled, which kept the embedded page from loading.
- Removed duplicate-name validation from Facility Manager create/edit wizards, as it was incorrectly preventing users from creating entities with the same name in different parent locations.
