---
uid: BP_Implementing_IAS_in_Regression_Tests
---

# Best practices: Implementing interactive Automation scripts in regression tests

Integrating interactive Automation scripts (IASs) into regression testing can be challenging because the regression test framework may not support executing sets on the UI.

While there are alternative testing methods, these lack integration with the QA portal. Adopting these alternatives often demands considerable time for both implementation and adjustment to changes. To address these issues, it is essential to employ a well-considered design methodology early in the process.

This guide focuses on best practices (recommendations) for integrating interactive Automation scripts into regression tests, emphasizing a design approach that ensures flexibility, reusability, and seamless integration.

> [!TIP]
> See also:
>
> - [Getting started with the IAS Toolkit](xref:Getting_Started_with_the_IAS_Toolkit)
> - [Model View Presenter (MVP)](https://community.dataminer.services/courses/dataminer-automation/lessons/model-view-presenter/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)
> - [How to get started with regression tests](https://www.youtube.com/watch?v=xUcXZAMjp8A) ![Video](~/dataminer/images/video_Duo.png)

## Use the Model View Presenter (MVP) design pattern

When implementing interactive Automation scripts that may be eligible to be tested via regression tests, consider adopting the MVP design pattern. This practice ensures the separation of your logic from other components, significantly facilitating non-interactive runs in the long term.

## Use JSON parameters for user decisions

Introduce a script input parameter that accepts a JSON structure containing the decisions a user would make during the interaction. This JSON can include various parameters like user inputs, options, or configurations required to execute the script.

By encapsulating these decisions in JSON format, the script gains flexibility and can easily adapt to different scenarios without requiring code modifications.

**Example**:

In this image, you can see that three input parameters are required to trigger the script and that the fourth input parameter contains the Interactive Input JSON, representing the decisions a user normally makes during the interaction:

![Interactive Input Json](~/develop/images/InteractiveInputJson.png)

When we read out these parameters, we try to deserialize this JSON. If successful, we run the script non-interactively; otherwise, we trigger the script interactively.

![Deserialize](~/develop/images/Deserialize.png)

![Deserialize](~/develop/images/Deserialize2.png)

![Deserialize](~/develop/images/Deserialize3.png)

## Write generic and reusable code

Ensure the code in your script is as generic as possible, avoiding distinct logic paths for non-interactive versus interactive runs. Embrace a unified logic that seamlessly accommodates both scenarios, minimizing redundancy and upholding consistency in the script's behavior. This can be achieved by wrapping methods.

**Example**:

Expanding on the previous example, the *SetOnElement* method can be invoked in two ways: interactively or non-interactively.

Regardless of the invocation method, it triggers and executes the same underlying logic.

![SetOnElement](~/develop/images/SetOnElement.png)

Avoid the need for separate scripts. Instead of opting for the creation of two scripts (one for interactive execution and another for non-interactive execution), where the interactive Automation script triggers a separate script with decisions for non-interactive execution, opt for a single script.

In this single-script approach, the code adapts its behavior based on the provided input parameters. This eliminates the need to maintain two separate scripts and the complexity of updating scripts for each other's executions, making the solution more manageable.

## Advantages of the recommended approach

### flexibility across various interfaces

Through the implementation of a JSON-based parameter system and a generic script design, the approach not only integrates effectively with the integration test framework but also ensures adaptability across different interfaces. Whether triggering the script interactively, non-interactively, or via a low-code app, users can provide the necessary input, maintaining consistency and facilitating ease of execution.

### Simplified maintenance and scalability

A unified script design eliminates the need to manage separate scripts, simplifying maintenance and reducing complexity. This approach also establishes a foundation for scalability, allowing enhancements or modifications to be seamlessly integrated without necessitating major overhauls.

Implementing IAS into regression tests requires a thoughtful design approach that emphasizes MVP architecture, JSON parameters, and a focus on generating generic code.

By adhering to these best practices, teams can ensure seamless integration, flexibility, and scalability while efficiently creating regression tests across various interfaces.
