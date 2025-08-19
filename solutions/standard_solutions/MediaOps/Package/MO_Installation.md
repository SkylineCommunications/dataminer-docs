---
uid: MO_Installation
---

# Installing MediaOps

The solution can be installed through the 'Deploy' button from the [Catalog](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75). The [prerequisites](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75#prerequisites) to install the latest version of the package are defined on the catalog.

## The installation steps

When installing the MediaOps package the following steps will be executed:

1. Prerequisite check
1. Install/Update automation scripts
1. Install/Update applications
1. Install/Update DOM definitions
1. Initialize the system (fresh install)
1. Migration actions (if any)
1. Cleanup actions (if any)

Migration and cleanup actions will are defined in the install package and will depend on the version you install. To avoid that these actions grow indefinite over the different versions, these actions will be cleaned on every major version (1.x.x => 2.x.x). To ensure all migration and cleanup actions took place, it is advised to first upgrade the MediaOps solution to the latest version of the major version before moving to the next major version without skipping a major version.
