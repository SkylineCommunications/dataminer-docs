---
uid: UD_APIs_Elements_in_alarm_tutorial
---

# Elements in alarm tutorial

> [!WARNING]
> It's highly recommended to first do the [Hello world tutorial](xref:UD_APIs_Hello_world_tutorial) before starting this tutorial. This tutorial continues to build on the knowledge of the first tutorial.

In this tutorial we'll build a more realistic use-case for an API. This API will return elements in a specific alarm state that we will pass as input. We will process and validate the input, get all the elements in a specific alarm state, and return them as a JSON response.

## Overview

- [Step 1: Create the automation script](#step-1-create-the-automation-script)
- [Step 2: Create an API token](#step-2-create-an-api-token)
- [Step 3: Create the API definition](#step-3-create-the-api-definition)
- [Step 4 (optional): Test the API using the SLNet Client Test Tool](#step-4-optional-test-the-api-using-the-slnet-client-test-tool)
- [Step 5: Trigger the API using Postman](#step-5-trigger-the-api-using-postman)

## Step 1: Create the automation script

We will use the same Automation script solution from the [Hello World tutorial](xref:UD_APIs_Hello_world_tutorial#step-1-create-an-automation-script-solution). Make sure you have the solution open in Visual Studio.

1. In Visual Studio, right-click the solution at the top of the solution explorer. Click *Add*, then *New DataMiner Automation Script...*  
![Visual Studio add new Automation script solution](~/user-guide/images/UDAPIS_elements_1.jpg)  

1. A pop-up will open requiring you to choose a name, let's choose *ElementsAPI*.  
![Create new automation script solution](~/user-guide/images/UDAPIS_elements_2.jpg)  

1. We're now ready to start developing our API automation script. Double-click the 'ElementsAPI_1.cs' file in the Solution Explorer. This opens our C# file.  
![Visual Studio Automation Script](~/user-guide/images/UDAPIS_elements_3.jpg)  

1. We now have to remove the `Run(IEngine engine)` method and add the User-Defined APIs entrypoint. Follow items 5 to 7 of [step 2 of the hello world tutorial](xref:UD_APIs_Hello_world_tutorial#step-2-create-the-automation-script) to do this.

1. Now we're ready to build the logic of our automation script. Follow the tabs below:

   # [Step A](#tab/A)

   As input from the user we expect the *alarmState* the user wants to see the elements for. Anything passed in the body of the API request will be available as a string in the *RawBody* property of the *requestData* parameter of the entrypoint method. So we're going to save that to a variable that we can use further on.

   [!code-csharp[](~/user-guide/Advanced_modules/User Defined APIs/Tutorial/Scripts/Elements_tutorial_script_A.cs?highlight=14)]

   # [Step B](#tab/B)

   A user could type in anything as alarmType, we have to validate the input and make sure that it is a valid alarmType and return an appropriate error to the user when the input is not valid. We can use a list of the known valid alarm types, and compare the user input with that, and also verify that it is not null or empty.

   [!code-csharp[](~/user-guide/Advanced_modules/User Defined APIs/Tutorial/Scripts/Elements_tutorial_script_B.cs?highlight=13-14,21-29)]

   # [Step C](#tab/C)

   To avoid our API returning huge amounts of data, we want to add a limit as input parameter. This way, the user can choose how many elements are returned. 
   - We already have the *alarmState* as input. To fix that, we're going to adapt our script to expect JSON as input, this way we can expect multiple input parameters. 
   - To read out JSON, we're going to use a NuGet library. In the 'Solution Explorer' in Visual Studio, right click 'Dependencies' under the project named 'ElementsAPI_1'. Then click 'Manage NuGet packages...'.
   - In the window that opens, click 'Browse'. Now search for JSON, and click the first package (Newtonsoft.Json). In the right window, click 'Install'.

   > [!NOTE]
   > We could also use the built-in parameter conversion so we have them available as a Dictionary, how to do that is documented on the [defining an API page of the docs.](xref:UD_APIs_Define_New_API#user-input-data)  

   ![Visual Studio project dependencies](~/user-guide/images/UDAPIS_elements_4.jpg)  

      ![Visual Studio NuGet browse](~/user-guide/images/UDAPIS_elements_5.jpg)  
  
    ![Install Newtonsoft.Json](~/user-guide/images/UDAPIS_elements_6.jpg)  

   - Now we'll parse our request body to an Input class that we'll make. We'll add error handling in case something else then we expect is being passed as request body.
       - We're adding our own classes to map the JSON to so we have more control of the object that is being deserialized. This way, we're not depending on any API.
   - We're adding a JsonSerializerSettings object with a ContractResolver, because the naming conventions for JSON is to use camelCasing, while our C# properties are in PascalCase.

   [!code-csharp[](~/user-guide/Advanced_modules/User Defined APIs/Tutorial/Scripts/Elements_tutorial_script_C.cs?highlight=18-21,35-48,69-77)]

   # [Step D](#tab/D)

   In this step we're going to add the logic to our API that will get the Elements based on the alarmType passed in the request body. We'll put the logic in a separate method called `GetElements()`. We can wrap that method in a try-catch statement, and pass a user-friendly error in case something goes wrong.

   In the method, we'll make sure the ElementFilter is correct to only show the elements with the alarm state that the user passed. We're mapping the Element objects returned by the automation engine to our own class, that is the class that we'll serialize to JSON and return to the user.

   [!code-csharp[](~/user-guide/Advanced_modules/User Defined APIs/Tutorial/Scripts/Elements_tutorial_script_D.cs?highlight=61-73,77,82-118,124-135)]

   # [Step E](#tab/E)

   The last step is to publish the automation script to the DataMiner agent. If you need help with this, this is covered in the last item of step 2 in the [hello world tutorial](xref:UD_APIs_Hello_world_tutorial#step-2-create-the-automation-script).

## Step 2: Create an API token

It's good practice to not reuse API tokens. In the ideal scenario, you have a token for each consumer of your API. We're not going to reuse the token that we made in the hello world tutorial, we're going to make a new one. Don't remember how to? Consult [step 3 of the hello world tutorial](xref:UD_APIs_Hello_world_tutorial#step-3-create-an-api-token). Give it a name of your liking.

## Step 3: Create the API Definition

Now that we have our automation script and API token, we can configure our API. You can just reuse the exact steps of [step 4 of the hello world tutorial](xref:UD_APIs_Hello_world_tutorial#step-4-create-the-api-definition). Just remember to change the URL to 'elements' and use the new token you made.

## Step 4 (optional): Test the API using the SLNet Client Test Tool

You can test your API using the SLNet Client Test Tool, how to do that is described on the [triggering and managing a user-defined API](xref:SLNetClientTest_triggering_api#triggering-a-user-defined-api) page. This approach is great for testing, but does not use an actual API call like we will use in the next step.

## Step 5: Trigger the API using Postman

We are now ready to trigger our API using Postman!

1. Follow items 1 to 5 of [step 6 of the hello world tutorial](xref:UD_APIs_Hello_world_tutorial#step-6-trigger-the-api-using-postman) to start creating our API request. Make sure to change the URL to the correct one (elements instead of helloworld) and also change the token secret to the correct one.

1. If we now click the 'Send' button, we'll get a Bad Request status code with our validation error. Because we didn't add a body to our request yet.  
![Postman UI response error](~/user-guide/images/UDAPIS_elements_7.jpg)

1. First head to the 'Body' tab of the request, then change 'none' to 'raw'. After that change the dropdown that says 'text' to JSON. Now we can add our request body.  
![Postman UI add request body](~/user-guide/images/UDAPIS_elements_8.jpg)  

   ![Postman UI add json request body](~/user-guide/images/UDAPIS_elements_9.jpg)

1. Always start and end your JSON with curly brackets. Add the name of the key and the value you want to pass.  
![Postman UI request body filled in](~/user-guide/images/UDAPIS_elements_10.jpg)

    ```JSON
    {
        "alarmType": "Minor",
        "limit": 10
    }
    ```

1. Make sure your DataMiner system has some elements in an alarm state, in the example, I have two elements in a 'Minor' alarm state, and my limit is set to 10, so I'll receive my 2 elements in the 'Minor' alarm state. Feel free to play around with this, changing the limit to 1 for example. When clicking send, you should now receive a 200 OK status code and your elements in the alarm state you passed in the request body in a JSON format.  
![Postman UI response](~/user-guide/images/UDAPIS_elements_11.jpg)
