---
uid: Web_apps_Feature_Release_10.4.11
---

# DataMiner web apps Feature Release 10.4.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.11](xref:General_Feature_Release_10.4.11).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps - Time range component: New 'Set value' action [ID 40569]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

It is now possible to configure a *Set value* action for a *Time range* component.

This action will allow users to set the current value of the component in question to either a preset range (today, yesterday, next year, ...) or a custom range (which can be either a static value or a feed).

## Changes

### Enhancements

#### Dashboards/Low-Code Apps - Time range component: Apply and Cancel buttons [ID 40622]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Up to now, when you set a custom time range in the *Time range* component, the feed of the component would immediately be updated. From now on, the feed will only be updated when you click the *Apply* button.

Clicking the *Cancel* button will close the time range picker without updating the feed.

### Fixes

#### Low-Code Apps - Form component: Dropdown fields containing elements, resources or service definitions would show an incorrect warning message [ID 40399]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Up to now, dropdown fields defined as `ElementFieldDescriptor`, `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor` would display all items. However, when there were more than 100 items, an incorrect message would appear, stating that not all values were being displayed.

This behavior has now changed:

- If a dropdown field is defined as `ElementFieldDescriptor`, the above-mentioned message will no longer appear. The field will always show all elements.

- If a dropdown field is defined as `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor`, it will now initially show only 100 items. When there are more than 100 items, a message will appear, indicating that there are more items.

Also, dropdown fields defined as `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor` will now use a paging mechanism (in case of the former, only if the DataMiner server version is 10.4.9 or newer).

> [!NOTE]
>
> - If a resource is found in multiple resource pools, it will appear in a dropdown field multiple times (i.e. once for every pool it is found in).
> - If a dropdown field defined as `ResourceFieldDescriptor` or `ServiceDefinitionFieldDescriptor` contains more than 100 items, it is advised to adapt the filter in order to reduce the number of items in the dropdown field.

#### Dashboards app: Folders of which the name contained a slash ('/') or a backslash ('\\') character would stay hidden [ID 40532]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you created a dashboard folder of which the name contained a slash ("/") or a backslash ("\\") character, up to now, the folder would be created, but would stay hidden. It would not appear in the folder structure.

From now on, when you enter a folder name containing a slash ("/") or a backslash ("\\") character, an `Invalid folder name message` will appear.

#### Dashboards app: Inconsistent folder selection behavior [ID 40561]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When a dashboard folder contained child folders, up to now, the main folder would open when you clicked it once, while the child folders would only open when you clicked them twice. From now on, all dashboard folders will open when you click their chevron once.
