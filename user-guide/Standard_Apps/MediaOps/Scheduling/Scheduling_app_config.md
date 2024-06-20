---
uid: scheduling_app_config
---

# Scheduling App Config

## Overview

The Scheduling App Config page allows you to configure App level preferences used by the Scheduling app. Currently there is only one configuration available, but in the future there could be others

## Configurations

### Configure Job ID

The Scheduling app can auto-generate a user friendly and custom Job IDs based on customizable rules. The custom Job ID is comprised of two parts, a string prefix following by a sequential numeric value.
<p>
<img src="~/user-guide/images/mediaops_s_job_ID_config.png" width="810" alt="Job ID Configuration Settings">

To configure a custom Job ID:

1. In the Scheduling App, open the **App Configuration** page from the navigation bar.
1. Click on the **Configure Job Id** button to open the Job ID Configuration dialog.
1. Set the following values:
    - **Prefix** is a string value that will be pre-pended to each Job ID. The default value is "JOB #". In this case, each Job ID will begin with "JOB #" followed by a numeric value determined by the rest of the settings.
    - **Minimum Digits** sets the minimum number of digits in the numeric portion of the ID. If the current value of the ID has:
        - Less digits than indicated by this setting, zeros (0's) will be added to fill the empty spaces. For example, if the five digits are configured and the current value of the sequence is 250, the string "00250" will be appended to the Job ID.
        - More digits than indicated by the setting, the numeric portion of the ID will expand. For example, if five digits are configured and the sequence value is 1234567, then 1234567 will be appended to the prefix.
    - **Starting Seed** sets the initial value used in the sequence.
    - **Increment** sets how the increment used when changing the sequence. For example a Increment of 1 would result in a sequence of 1, 2, 3, 4, 5... whereas a sequence of 5 would result in 5, 10, 15, 20, etc..
1. When finished click **Apply**.
