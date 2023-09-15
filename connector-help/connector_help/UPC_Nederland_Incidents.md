---
uid: Connector_help_UPC_Nederland_Incidents
---

# UPC Nederland Incidents

This connector is intended to present in a table incidents where the **Event Property** *Trap* is set to *Yes*.

## About

This connector will show in the table the information about incidents where the **Property** *Trap* was set to *Yes*. The table will be populated automatically in two occasions:

- Automatically: for each **Alarm** in the system where the the **Alarm** **Property** was set to **Yes** - done via a **Correlation Rule (CR)**/**Automation Script (AS)**;
- Manually: an **Information Event** created manually that will follow the same flow as explained before - done via a specific **Visio** file that will load an **Interactive Automation Script (IAS)**. It will ask for the event details.

## Installation and configuration

As this is a virtual connector there aren't any settings when creating an element.

## Usage

### General

On the General page you have access to the **Alarm Information** table. Also available is the **Command Parameter**. It shows the information inside the **Alarm/Information Event** that was generated.

The **Properties Set Interactively** parameter is set with the details that will be asked in the **IAS**.

To test adding a row with static information use the **Generate Static Alarm To Test** parameter. First create an **Alarm Template** on top of this parameter. Then create a **CR** that will trigger on the generated alarm. Set the **CR** **Action** to trigger the **Add Static Row To Table** **AS**.

## Notes

This connector works in conjunction with two **AS** and one **CR**. They are the **Add Static Row To Table** and the **Create Alarm**.
