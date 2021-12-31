## Managing alarm templates

In this section:

- [Creating an alarm template](#creating-an-alarm-template)

- [Uploading an alarm template](#uploading-an-alarm-template)

- [Assigning an alarm template](#assigning-an-alarm-template)

- [Deleting an alarm template](#deleting-an-alarm-template)

### Creating an alarm template

To create a new alarm template:

1. Go to *Apps* >* Protocols & Templates*.

2. Select a protocol in the first column and a protocol version in the second column.

3. Right-click in the third column under *Alarm*, and select *New*.

    > [!NOTE]
    > To create a new alarm template that is very similar to one that already exists, it can be handy to duplicate the existing template instead of creating a blank new template. To do so, instead of selecting *New*, select the template that is similar, and then select *Duplicate* in the right-click menu.

 

4. In the *New alarm template* dialog box:

    1. Keep *Alarm Template* selected.

    2. Enter a template name.

        > [!NOTE]
        > Some characters cannot be used in template names. For more information, see [Naming of elements, services, views, etc.](../../part_7/NamingConventions/NamingConventions.md#naming-of-elements-services-views-etc).

    3. Check if the protocol and protocol version are correct and adapt if necessary.

    4. Click *OK*.

    The template editor now opens, where you can further configure the alarm template. For more information, see [Configuring alarm templates](Configuring_alarm_templates.md).

### Uploading an alarm template

To upload an existing alarm template for a particular protocol version:

1. Go to *Apps* >* Protocols & Templates*.

2. Select the protocol in the first column and the protocol version in the second column.

3. Right-click an alarm template under *Alarm* in the third column, and select *Upload*.

4. Browse to the alarm template in question and click *Open*.

    > [!NOTE]
    > Only files that start with *Template\_* will be recognized as alarm templates.

### Assigning an alarm template

You can either assign an alarm template to an item with the Surveyor right-click menu, or in the Protocols & Templates module.

> [!NOTE]
> By default, elements use the alarm template \<No Monitoring>, which disables the alarm thresholds on all parameters.

In the Surveyor:

1. Right-click the item to which you want to assign an alarm template and click *Edit*.

2. In the *Edit* tab, go to *Device Details*.

3. Select the alarm template in the *Alarm Template* selection box.

4. Click *Apply*.

In the Protocols & Templates module:

1. In the first column, select the protocol of the item to which you want to assign the alarm template.

2. In the *Versions* section, select the protocol version of the item.

3. In the *Alarm* section, select the alarm template.

4. Right-click in the *Elements* section, and select *Assign template*. Alternatively, from DataMiner 9.0.5 onwards, you can also click the *Assign elements* button at the top of this section.

5. In the *Assign template* window, use the *Add \>\>* and *\<\< Remove *buttons to assign the template to particular items.

    All items in the column on the right have been assigned this alarm template.

> [!NOTE]
> -  To quickly access the Protocols & Templates module from the Surveyor, right-click an element or enhanced service, and select *Protocols & Templates. *This opens a submenu where you can open the current template, assign a different template or view all available templates.
> -  Right-click an item in the Protocols & Templates module and select *Remove* to quickly remove an alarm template from an item.
> -  Assigning templates is also possible via the *elements* tab of the Protocols & Templates module. See [Working with the elements tab](Working_with_the_elements_tab.md).

### Deleting an alarm template

To delete an existing alarm template for a particular protocol version:

1. Go to *Apps* >* Protocols & Templates*.

2. Select the protocol in the first column and the protocol version in the second column.

3. Right-click the alarm template under *Alarm* in the third column, and select *Delete*.

> [!NOTE]
> If any elements are using the template when you delete it, these will have the template \<No Monitoring> assigned to them instead.
>
