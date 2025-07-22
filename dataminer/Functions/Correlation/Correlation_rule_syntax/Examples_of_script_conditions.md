---
uid: Examples_of_script_conditions
---

# Examples of script conditions

Below, you can find a number of examples of script conditions you can use in Correlation rules.

- The following condition determines that the calculated average value must be less than 1.3:

    ```txt
    avg(field(value)) < 1.3
    ```

- The following condition determines that there must be more than 5 base alarms:

    ```txt
    count(*) > 5
    ```

- The following condition determines that, after comparing the ImpactedClients Properties of all base alarms, the highest value found must be at least equal to 3

    ```txt
    max(property(Alarm.ImpactedClients)) >= 3
    ```

- the following condition determines that parameter 350 of element 59 of DMA 7 must contain a value higher than 10

    ```txt
    parameter(7,59,350) > 10
    ```

- The following condition determines that there must be a base alarm of which parameter 350 of the associated element contains a value higher than 10,

    ```txt
    parameter(field(dmaid), field(eid), 350) > 10
    ```
