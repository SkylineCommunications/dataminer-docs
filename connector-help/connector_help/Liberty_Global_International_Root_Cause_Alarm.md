---
uid: Connector_help_Liberty_Global_International_Root_Cause_Alarm
---

# Liberty Global International Root Cause Alarm

This protocol allows correlation for root cause alarms on services, based on alarms from included elements.

## About

The **Root Cause Alarm** will be set based on different rules configured in the **Alarm Matrix** table. Each **Root Cause Alarm** can store a specific Resolve Platform and Service Highway query.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

Create a new service that requires root cause alarm correlation. In the edit tab of the service creation card, open the "Advanced" section and select the service definition "Liberty Global International Root Cause Alarm".

## Usage

### Alarm Matrix

On this page you can fully configure the **Alarm Matrix** and view the parameter values from the **Root Cause Alarm** and **Matrix Validation**.

Each cell of the **Alarm Matrix**, except the **Matrix ID**, is editable. The following table columns are displayed:

- **Matrix ID \[IDX\]:** Specific index for the table.

- **The Root Cause Alarm (Alarm Matrix)**: States the root cause alarm that this row applies to. Upon editing, the user is free to choose the value of this cell.

- **Root Cause Rule (Alarm Matrix):** States the root cause rule that this row applies to. Upon editing, the user is free to choose the value of this cell.

- **Component Alias (Alarm Matrix)**: States the element or service considered for this row. Upon editing, a selection of the included elements and services in this service will be shown.

- **Alarmed Parameter (Alarm Matrix):** States the considered parameter for this row. Upon editing, a selection of the possible alarms from this element or service will be shown.

- **Expected Severity (Alarm Matrix)**: States the expected severity for this row. Upon editing, a selection of possible severities will be shown:

- *Any*: Any severity other than normal.
  - *Critical*: Only critical severities are considered.
  - *Major*: Only major severities are considered.
  - *Minor*: Only minor severities are considered.
  - *Warning*: Only warning severities are considered.

- **Rule Type (Alarm Matrix)**: States the condition type for this row. Upon editing, a selection of rule types will be shown:

- *Required*: This condition is required to raise the corresponding root cause alarm.
  - *Forbidden*: If this condition is not met, the corresponding root cause alarm is raised.
  - *Root Cause*: This type will add information from the matching alarm into the root cause alarm.

When you right-click this table, a context menu is displayed were you can:

- Duplicate rules.
- Delete selected rows.
- Clear all rules.
- Export rules to similar services, based on the service description.
- Fetch rules from a specific service.
- Export table to CSV.
- Import table from CSV.

### Add Root Cause Alarm Matrix Rule

When you click the button **Add New Rule**, a new page is shown where you can configure a new row to add to the previous table:

- **Selected Rule:** States the root cause rule which this row applies to. Upon editing, the user is free to choose the value of this cell.

- **Raised Root Cause Alarm**: States the root cause alarm which this row applies to. Upon editing, the user is free to choose the value of this cell.

- **Selected Component Alias**: States the element or service considered for this row. Upon editing, a selection of the included elements and services in this service will be shown.

- **Selected Alarm Parameter**: States the considered parameter for this row. Upon editing, a selection of the possible alarms from this element or service will be shown.

- **Expected Severity**: States the expected severity for this row. Upon editing, a selection of possible severities will be shown:

- *Any*: Any severity other than normal.
  - *Critical*: Only critical severities are considered.
  - *Major*: Only major severities are considered.
  - *Minor*: Only minor severities are considered.
  - *Warning*: Only warning severities are considered.

- **Selected Type**: States the condition type for this row. Upon edition, a selection of rule types will be shown:

- *Required*: This condition is required to raise the corresponding root cause alarm.
  - *Forbidden*: If this condition is not met, the corresponding root cause alarm is raised.
  - *Root Cause*: This type will add information from the matching alarm into the root cause alarm.

### Rule Priorities

When you click the button **Rule Priorities**, a new page is shown with the table **Root Cause Alarm Rule Priorities**. The following table columns are displayed:

- **Rule Name \[IDX\]**: States the root cause rule.
- **Alarm Name**: States the respective root cause alarm that this rule will raise.
- **Rule Priority**: Shows the priority value of this rule. Higher priority values will make the rule trigger before other rules with less priority, even if both rules meet their conditions. Only one root cause alarm will be active at any given time.

When you right-click this table, a context menu is displayed were you can increase, decrease and remove specific rule priorities.

### Alarm Scripts

On this page you can fully configure the **Root Cause Alarm Scripts** table with saved scripts for each Root Cause Alarm.

When you right-click this table, a context menu is displayed were you can:

- Set resolve platform runbook to selected root cause alarm.
- Set service highway runbook to selected root cause alarm.
- Clear scripts from selected row(s).
- Export scripts to similar services, based on the service description.
- Fetch scripts from a specific service.
- Export table to CSV.
- Import table from CSV.

### Alarm Structure

This page shows the root cause alam tree structure, where parent root cause alarms have child rules and each rule shows the specific conditions that need to be met.

### Service Status

This page shows an overview of the service status **Active Service Alarms** and **Service Element Status** tables.
