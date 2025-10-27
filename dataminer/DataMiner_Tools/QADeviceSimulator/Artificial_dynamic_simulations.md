---
uid: Artificial_dynamic_simulations
---

# Artificial dynamic simulations

If you want to avoid static values but were not able to capture realistic data, you can configure in the simulation file that the simulator should return random values in a certain range for a certain parameter, or that it should follow a certain pattern. To do that, change the *ReturnValue* attribute:

- You can add simple random values to a given *ReturnValue* using the following syntax:

    ```txt
    ReturnValue= "{INS}RandomInt;[min];[max]{INS}"
    ```

    Example:

    ```txt
    ReturnValue= "{INS}RandomInt;309;409{INS}".
    ```

    > [!NOTE]
    > "max" is inclusive, so the above would produce random values ranging from 309 to 409.

- You can add commands in the *ReturnValue* attribute of the *Definition* tag to create other varying responses. This can be useful to instantly create trend data, to toggle alarms, etc. You can use the following syntax for this:

    ```txt
    ReturnValue = "{INS}increment;[start];[end];[step];[behaviour];[cycle behaviour]{INS}"
    ```

    The table below shows the different possibilities:

    | Attribute     | Possible values       | Sub-attribute | Possible values |
    |-----------------|-----------------------|---------------|-----------------|
    | start           | decimal               | \-            | \-              |
    | end             | decimal               | \-            | \-              |
    | step            | decimal               | \-            | \-              |
    | \-              | rand(\[min\]-\[max\]) | min           | decimal         |
    | \-              | \-                    | max           | decimal         |
    | behaviour       | inc                   | \-            | \-              |
    | \-              | dec                   | \-            | \-              |
    | cycle behaviour | rollover              | \-            | \-              |
    | \-              | bounce                | \-            | \-              |
    | \-              | stop                  | \-            | \-              |

Examples:

- Each poll returns an increasing value from 1-100 in a random step of 1-5 and resets to 1 when cycle reaches 100.

    ```txt
    ReturnValue = "{INS}increment;1;100;rand(1-5);inc;rollover{INS}"
    ```

- Each poll returns a decreasing value from 100 with a fixed step of 2 and starts to increment back to 100 when cycle reaches 1.

    ```txt
    ReturnValue = "{INS}increment;100;1;2;dec;bounce{INS}"
    ```
