---
uid: MediaOps_Integration
---

# Integration Notes

## Customizing the visualization

When you want to customize any of the [MediaOps apps](xref:MediaOps_apps) it is advised to make a duplicate of the app. This way when a new version of MediaOps is deployed and the MediaOps apps are updated it will not update your duplicated app.

> [!IMPORTANT]
> We don't guarantee that any customized apps remain compatible with newer versions of MediaOps as the ad-hoc data sources used can change in the future.

## Creating custom applications

The helper classes/library (TODO PROVIDE DOCS) provide an API that is backwards compatible. By making custom applications that do not make use of any of the MediaOps scripts except for the helper classes it is possible to guarantee your applications will keep working for all versions of MediaOps within the same major range. TODO CHECK WITH SQUAD AND ADD VERSIONING INFO