---
uid: PA_Creating_script_tasks
---

# Creating script tasks

> [!NOTE]
> Script tasks need to be designed in such a way that their execution does not exceed the default Automation script timeout time of 15 minutes.

1. In the [*Profiles* module](xref:The_Profiles_module), define the **input parameters** required for the script task to execute.

   For example, for a “Ping IP” activity, an input parameter could be “IP Address”.

   1. In the *Parameters* tab, create an input parameter by selecting *Add parameter* in the lower left corner.

   1. Specify the following information:

      - **Name**: The name of the parameter, e.g. "Ping - IP Address".

      - **Type**: Set to *Text*.

   1. Save all changes.

   ![Script Task 1](~/user-guide/images/Script_Task_1.png)

1. In the *Profiles* module, define the **output parameters** that a script task can potentially generate.

   For example, for a “Ping IP” activity, possible output parameters could be “Ping Result” and “RTT”.

   1. In the *Parameters* tab, create an output parameter by selecting *Add parameter* in the lower left corner.

   1. Specify the following information:

      - **Name**: The name of the parameter, e.g. "Ping - Result".

      - **Type**: Depends on the parameter. For example:

        - Set to *Discrete*.

           - **Value**: Click *Add discrete value*.

             - Value: 0.000000

             - Display value: Failed  

             - Value: 1.000000

             - Display value: Succeed

           ![Script Task 2](~/user-guide/images/Script_Task_2.png)

        - Set to *Number*.

           - **Units**: ms

           ![Script Task 3](~/user-guide/images/Script_Task_3.png)

   1. Save all changes.

1. In the *Profiles* module, group your input and output parameters into a **profile definition**.

   For example, for a “Ping IP” activity, create a “Ping IP” profile definition with the following profile parameters:

   - Ping - IP

   - Ping - Result

   - Ping – RTT

   1. In the *Definitions* tab, select *Add definition*

   1. Specify the following information:

      - **Name**: The name of the profile definition, e.g. "PING IP"

      - **Parameters**: Add your previously created input and output parameters.

      - **Based on**: Select *PA Script Task*.

   1. Save all changes.

      ![PING IP](~/user-guide/images/PING_IP.png)

1. Create an Automation script based on the *PA_ProfileLoadDomTemplate* script available in the PA framework:

   1. Add a C# block in the script and configure it as follows:

      - Instantiate the *PaProfileLoadDomHelper*

        `var helper = new PaProfileLoadDomHelper(engine)`;

      - Use the helper to retrieve the input arguments, based on the profile parameter names created earlier.

        *Examples*:

        ```csharp
        var totalPrice = helper.GetParameterValue<double>("PA BillingSystem Invoice Total Price");

        var name = helper.GetParameterValue<string>("PA BillingSystem Customer Name");

        var paidDate = helper.GetParameterValue<DateTime>("PA BillingSystem Invoice Paid Date");

        var resourceIds = helper.GetParameterValue<List<Guid>>("PA Create Basic Booking - Resources");
        ```

      - Implement the script task logic. This is the custom code to reach the objective of the activity.

      - Use the helper to add relevant results to the output, based on the profile parameter names created earlier.

        *Examples*:

        ```csharp
        helper.UpdateField("PA BillingSystem Invoice Creation Date", DateTime.Now);
        helper.UpdateField("PA BillingSystem Invoice Status", 1);
        ```

      - Optionally transition the [DOM instance](xref:DomInstance) to a specific state:

        ```csharp
        helper.TransitionState(transitionId);
        ```

        In the example above, *transitionId* is a string representing the state transition defined in the [DOMBehaviorDefinition](xref:DomBehaviorDefinition).

      - Trigger the update of the DOM instance:

        ```csharp
        `helper.ReturnSuccess();
        ```

      - Generate relevant log records to facilitate debugging:

        ```csharp
        helper.Log("The DOM value was updated", PaLogLevel.Information);
        ```

   1. Add a *FunctionDve* script dummy and configure it with following protocol: *Skyline Process Automation.PA Script Task*, version *Production*.

      ![PA_PING_IP](~/user-guide/images/AutomationScript_PA_Ping.png)

      > [!NOTE]
      > In the C# block, never try to directly retrieve data from the DOM instance, as this can have unexpected results.

   > [!IMPORTANT]
   > The script must have three parameters: *Info*, *ProcessInfo*, and *ProfileInstance*. Double-check to make sure that this is indeed the case.

1. Link the script with the profile definition you created earlier.

   1. Go to the *Profiles* module and select your previously created profile definition in the *Definitions* tab.

   1. In the *Scripts* section, click *Add*.

   1. Next to *Script*, select the script and click *OK*.

   1. Save all changes.

      ![Profile Definition](~/user-guide/images/Profile_Definition.png)
