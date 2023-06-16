---
uid: Creating_a_ticket
---

# Creating a ticket

This action is only available if:

- The [soft-launch option](xref:SoftLaunchOptions) *CorrelationTicketAction* is enabled.

- The DMA has a Ticketing license and uses a Cassandra database.

> [!WARNING]
> This is a deprecated soft-launch feature. While you can still use it for now, it will never be released, and it will at some point become unavailable. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Use this action to create a ticket linked to the correlated alarm.

In the *Actions* section of the details pane:

1. Click *Add Action* and select *Create ticket*.

1. Next to *In domain*, click the underlined field and select the ticket domain.

   When a domain has been selected, a list of the different ticket fields will be displayed below this, which also lists any default alarm fields that are linked to the ticket fields.

1. To customize the values in the ticket field, in the *Override* column, click the underlined field and select a different value:

   - *No override*: A value will only be displayed in case the field is linked to an alarm field by default.

   - *Static value*: Allows you to specify a static value for the field in the *Value* column. The values you can specify may be limited depending on the ticket field configuration.

     For ticket fields of type string, multiple values can be combined. To do so, click the + icon to duplicate the field and specify an additional value. The arrow icons next the + icon allow you to modify the order in which the values are combined. Values can be deleted again with the x icon.

   - *Alarm field*: Allows you to link the field to a custom alarm field.
