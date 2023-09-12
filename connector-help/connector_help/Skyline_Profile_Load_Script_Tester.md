---
uid: Connector_help_Skyline_Profile_Load_Script_Tester
---

# Skyline Profile Load Script Tester

For resource-based use cases, it is now possible to create an element to facilitate the testing/validation of Profile Load scripts and to keep track of metrics.

## About

With the *Profile Load Script Tester* connector and the associated Automation scripts, you can test the following use cases:

- **Manual**: a quick profile load execution on a (virtual) function resource that can be selected by the user, next to the profile and state.
- **Semi-manual**: a test case is predefined by providing a (virtual) function resource. The user needs to select a profile and state.
- **Script**: a test case is predefined by providing an Automation script, based on SRM_ProfileLoadScriptTesterScriptExample. The (virtual) function resources, profiles and states are hard-coded in the custom script. This will cover basic and advanced use cases. The script can combine several profile load executions.

### Version Info

| **Range**            | **Key Features**                                                  | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Test Profile Load scripts. Requires SRM version 1.2.21 or higher. | \-           | \-                |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Specify the **Booking Manager** element name of the related virtual platform on the **General** page, so that the connector can retrieve the necessary settings (e.g. the logging location).

### Redundancy

There is no redundancy defined.

## How to use

### Manual Test Case

On the **Manual Test Case** page, select the function to filter the resource for which a profile should be loaded. In the same section of the Visual page, click Apply to select the profile and state.

No results or logging are gathered for this test case.

### Automated Test Cases

On the **Test Cases** page, you can predefine semi-manual and script tests. To add or duplicate a test, right-click the Test Cases table and select **Add Script** or **Add Semi-Manual**. Give the test case a unique name to identify it easily. You can also use the automatically proposed name.

For each case, the status, the last execution date and the duration are displayed. Each case can be executed or deleted.

Note: You can refresh the selection lists by clicking the **Refresh** button.

For a **semi-manual** test case, a resource has to be selected. Select a function to filter the available resources. When you execute the test case, the profile and state will be requested.

For a **script** test case, select the name of the custom Automation Script.
