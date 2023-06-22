---
uid: Alarm_template_groups
---

# Alarm template groups

## About alarm template groups

Alarm templates can be combined in alarm template groups. With these, users can build alarm template hierarchies allowing alarm thresholds for one or more parameters to be overruled without having to change the base template.

> [!TIP]
> See also: [Creating an alarm template group](#creating-an-alarm-template-group)

### Example of an alarm template group

For this example, we will assume that you apply a template group with three alarm templates (1, 2 and 3) to a protocol with five parameters (A, B, C, D and E).

The following table shows which parameters will be monitored and how. Remember that the order of the alarm templates in a template group is very important as every alarm template in the template group overrules the one below it.

| TEMPLATE GROUP | Parameter A | Parameter B | Parameter C | Parameter D | Parameter E |
|--|--|--|--|--|--|
| Template 1 | Excluded | Excluded | Included<br>Not monitored | Excluded | Excluded |
| Template 2 | Included<br>Not monitored | Excluded | Included<br>Monitored (Threshold 350) | Included<br>Monitored (Threshold 400) | Excluded |
| Template 3 | Included<br>Monitored (Threshold 100) | Included<br>Monitored (Threshold 200) | Included<br>Monitored (Threshold 300) | Included<br>Not monitored | Excluded |
| TEMPLATE GROUP RESULT | Included<br>Not monitored | Included<br>Monitored (Threshold 200) | Included<br>Not monitored | Included<br>Monitored (Threshold 400) | Excluded |

Parameter C, for example, is monitored in both template 2 and template 3 (with different threshold values) but is not monitored in template 1. As a result, parameter C will not be monitored.

> [!NOTE]
> If a filtered table parameter is used in one or more alarm templates in the group, each filtered entry in the alarm template is treated as if it were a separate parameter.

### Including and excluding parameters in an alarm template

In an alarm template, every parameter can have one of three monitoring states:

| Configuration                | Included in the alarm template | Monitored |
|------------------------------|--------------------------------|-----------|
| Included & checkbox selected | Yes                            | Yes       |
| Included & checkbox cleared  | Yes                            | No        |
| Excluded                     | No                             | No        |

> [!NOTE]
> When you edit an alarm template, do not forget to select the *Allow include/exclude parameters* option in the alarm template settings.

## Creating an alarm template group

To create a new alarm template group:

1. Go to *Apps* > *Protocols & Templates*.

1. Select a protocol in the first column and a protocol version in the second column.

1. For each alarm template you want to add to the group, do the following:

   1. Right-click the alarm template you want to add and select *Open*.

   1. Click the cogwheel button at the top of the alarm template editor and make sure the option *Allow include/exclude parameters* is selected.

   1. In the *Included* column, check if the correct parameters are included or excluded for alarm template grouping:

      - If the *Included* column is not displayed, click the settings button and select *Allow include/exclude parameters (used for alarm template grouping).*

      - For each parameter, a button is displayed that shows *Included* or *Excluded*. Click this button to change a parameter from included to excluded or vice versa.

      > [!NOTE]
      > It is also possible to include or exclude parameters through the template editor right-click menu.

   1. Click *OK*.

1. In the Protocols & Templates module, right-click in the third column under *Alarm*, and select *New*.

   > [!NOTE]
   > To create a new alarm template group that is very similar to one that already exists, you can instead duplicate the existing template, by selecting *Duplicate* in the right-click menu.

1. In the *New alarm template* dialog box:

   1. Select *Alarm Template Group*.

   1. Enter a template group name.

   1. Check if the protocol and protocol version are correct and adapt if necessary.

   1. Click *OK*.

1. In the template group editor, click *Add Alarm Template* and select a template in the drop-down list. Repeat until all the necessary alarm templates are included in the group.

   > [!NOTE]
   > Under the list with the added alarm templates, the consolidated alarm template is shown. You can use this as a reference to see the combined effect of the different alarm templates in the group.

1. Hover the mouse over an alarm templates and click the small up and down arrows to change the order, if necessary.

   > [!NOTE]
   > The order of the alarm templates in a template group is very important as every alarm template in the group overrules the one below it.

1. To remove an alarm template from the group, hover the mouse over the alarm template and click the *x*.

1. Click *OK*.

> [!NOTE]
>
> - Any alarm templates that are only used in an alarm template group will have the notice *Used in group* next to the template name in the Protocols & Templates module. If a user tries to delete such an alarm template, he will receive a warning that indicates in which group or groups the template is used.
> - If scheduled alarm templates are used in an alarm template group, they will not be in use in the group at the moment when they are scheduled to be inactive.
