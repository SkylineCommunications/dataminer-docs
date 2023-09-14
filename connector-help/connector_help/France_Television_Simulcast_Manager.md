---
uid: Connector_help_France_Television_Simulcast_Manager
---

# France T‚l‚vision Simulcast Manager

The **France T‚l‚vision Simulcast Manager** connector is an Element Manager used for job occultation.

## About

With this connector, you can **occult** jobs shown by the element. Only the jobs linked to the element name are visible. You can occult **Manually**, with **Duration** time or with a **Schedule** time.

## Installation and configuration

The **France T‚l‚vision Simulcast Manager** connector is a **Virtual** connector, and requires the following input during element creation:

- **Element name:** yourchoice_France 0

- yourchoice: The first section of the name can be chosen freely, but may not contain an underscore ( \_ ).
  - \_France 0: The second part of the name always has to start with an underscore, followed by the name of the jobs you want.

## Usage

### General

This page contains the **Job Table**, 3 buttons (**Occultation All ON**, **Occultation All OFF** and **Refresh Table**), a label displaying the **Customer Name** and a parameter displaying the **Status**.

- **Customer Name:** Displays the customer name. For example, for an element named **Occultation_France 2**, the customer name will be **France 2**.
- **Status:** Shows any exceptions or mistakes the user makes.
- **Job Table:** Shows the **Job ID**, **Job Name**, **Logo**, **Input Audio PID**, **Input Audio Description PID**, **Input Audio VO PID**, **Duration (in Minutes)**, **Start Date**, **Start Time**, **End Date**, **End Time** and **Occultation**.
- **Occultation All ON** or **OFF:** Button that allows you to set the occultation of every job to ON or OFF if possible.
- **Refresh Table:** Button to refresh the table instantly, you do not want to wait until the timer refreshes.

## Notes

There can be **Manual Occultation**, **Duration Occultation** and **Schedule Occultation**. Please note the following on these occultation types:

- If **no** **Duration Time** and **no** **Schedule Time** is filled in:

- The occultation stays ON until you set it back to OFF.

- If **Duration Time** is filled in, but **no** **Schedule Time** is filled in:

- If you set the occultation to ON, it stays on until either you manually set it back to OFF or the Duration Time ends.

- If **Duration Time** is filled in, and the **Schedule Time** \< NOW:

  - If the Duration End Time is before the Schedule Start Time: The occultation will stay ON until the Duration Time ends or you set the occultation back to OFF manually.

  - If the Duration End Time is after or at the same time as the Schedule Start Time: The occultation will stay ON even after the Duration Time ends, because the Schedule Time takes priority.

    - Manual **Occultation OFF** outside of the Schedule Time: The occultation is set to OFF, the Duration Time is cleared.
    - Manual **Occultation OFF** inside of the Schedule Time: The occultation is set to OFF, the Duration Time is cleared and the Schedule Time is cleared.

- When **Schedule Time** is entered: occultation will be set to ON and set back to OFF either once the Schedule Time is over, or when it is manually set back to OFF.

  In short, this means that if occultation is turned off manually, it is always set to OFF, but turning off occultation only clears the Schedule Time if this is done within the Schedule Time.

  If occultation is turned on manually, or turned on with duration time, the schedule time always takes over as soon as the current time that occultation is on is within the Schedule Time.
