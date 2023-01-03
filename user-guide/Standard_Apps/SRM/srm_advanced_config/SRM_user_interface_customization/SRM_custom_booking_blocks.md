---
uid: SRM_custom_booking_blocks
---

# Customizing the booking blocks on the timeline

On the [Bookings tab](xref:Booking_Manager_Bookings_tab) of the Booking Manager app, a timeline shows when specific bookings are planned.

You can customize the blocks representing bookings on the timeline so that they will show custom information instead of just the booking name. This can be done system-wide, but you can also configure overrides for one or more specific service definitions.

## Configuring a custom booking block height

<!-- RN 29991 -->

If you want booking blocks to display information over more than one line, it is important that you also customize the height of the booking blocks.

1. In the Booking Manager app, go to the *Config* > *Timeline* page.

1. Click the pencil icon next to *Block Height* and enter the new height of the booking block (in pixels).

## Configuring custom booking block info for the entire system

1. In the Booking Manager app, go to the *Config* > *Timeline* page.

1. Make sure the *Custom Block Info* toggle button is set to *Custom*.

1. Configure the custom information in the *Service Info* table below the toggle button.

   Each row in this table represents an item that will be displayed in the booking blocks.

   - To add a row:

     1. Right-click the table and select *Add Block Info*.

     1. In the *Block Info* field, specify the block info (e.g. *\[BOOKINGNAME\]*, or a property name in the format *\[PROPERTY:**Property name**\]*).

        > [!NOTE]
        > You can also combine the above-mentioned placeholders, e.g. `[PROPERTY:VIRTUAL PLATFORM]_[BOOKINGNAME]`. <!-- RN 28995 -->

     1. In the *Order* field, specify in which position on the block the item should be displayed, The lower the number (lowest = 0), the higher the position.

   - To remove a row, right-click the row and select *Delete Selected Item(s)*. Alternatively, you can clear all items in the table at the same time by selecting *Clear Table*.

## Configuring custom booking block info for a specific service definition

<!-- RN 22172 -->

1. In the Services module in DataMiner Cube, go to the *definitions* tab.

1. Select the service definition for which you want to configure custom booking block info.

1. In the pane on the right, go to the *properties* tab.

1. Click the *Add* button to add a property.

1. In the *new property* field, specify the property name *BlockInfo*.

1. Set the value of the property to a *BlockInfo* array as illustrated in the following example:

   ```json
   [
    { "BlockInfo": "FixedString", "Order":3},
    { "BlockInfo": "Name: [BOOKINGNAME]", "Order": 1},
    { "BlockInfo": "Friendly Reference: [PROPERTY:FriendlyReference]", "Order": 2}
   ]
   ```

   In this array, the order of each item must always be specified, as this will determine the order in which the items are displayed (1 = the highest). There is no limit to how many *BlockInfo* items you can add. You can also combine the [BOOKINGNAME] and [PROPERTY:...] placeholders in the same *BlockInfo* item.
