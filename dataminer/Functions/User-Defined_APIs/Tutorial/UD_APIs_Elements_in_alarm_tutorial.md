---
uid: UD_APIs_Elements_in_alarm_tutorial
---

# Creating an API to retrieve elements in alarm

> [!IMPORTANT]
> We highly recommend following the [hello world tutorial](xref:UD_APIs_Hello_world_tutorial) before you start this tutorial, as it builds on the knowledge of that first tutorial.

In this tutorial, you will build a more realistic use case for an API. This API will allow you to retrieve a list of elements that have alarms with a specified alarm level. It will process and validate the input, get all the elements according to this input, and return them as a JSON response.

The content and screenshots for this tutorial were created in DataMiner version 10.3.9.

## Overview

- [Step 1: Create the automation script](#step-1-create-the-automation-script)
- [Step 2: Create an API token](#step-2-create-an-api-token)
- [Step 3: Create the API definition](#step-3-create-the-api-definition)
- [Step 4: Trigger the API using Postman](#step-4-trigger-the-api-using-postman)

## Step 1: Create the automation script

To develop this new API script, you can use the automation script solution from the [hello world tutorial](xref:UD_APIs_Hello_world_tutorial#step-1-create-an-automation-script-solution). Make sure you have this solution open in Visual Studio. You will need a new script project to develop this new API.

1. In Visual Studio, right-click the solution at the top of the *Solution Explorer*, and select *Add* > *New DataMiner Automation Script*.

   ![Visual Studio add new automation script solution](~/dataminer/images/UDAPIS_Tutorials_Elements_Add_New_Script.jpg)

1. In the dialog, enter the name "ElementsAPI".

   ![Create new automation script solution](~/dataminer/images/UDAPIS_Tutorials_Elements_Add_New_Script_Name.jpg)

The new Automation project has now been created for this API script. In the next sections, you will expand this script step by step:

1. [Prepare the script](#prepare-the-script)
1. [Store user input](#store-user-input)
1. [Validate user input](#validate-user-input)
1. [Expand the user input with JSON](#expand-the-user-input-with-json)
1. [Retrieve the element data](#retrieve-the-element-data)
1. [Publish the script](#publish-the-script)

### Prepare the script

Before the API logic can be written, the API script wrapper code needs to be present. The default run method should be replaced with a special entry point method.

1. Double-click the *ElementsAPI_1.cs* file in the *Solution Explorer*.

   ![Visual Studio Automation Script](~/dataminer/images/UDAPIS_Tutorials_Elements_Open_Code.jpg)

1. In the code window, remove the default `Run(IEngine engine)` method.

1. Right-click the empty line between the *Script* class brackets and select *Snippet* > *Insert Snippet*.

   ![Insert snippet](~/dataminer/images/UDAPIS_Tutorials_Insert_Snippet.jpg)

1. Select the snippet *DIS* > *Automation Script* > *CreateUserDefinedAPI*.

   ![Add entrypoint](~/dataminer/images/UDAPIS_Tutorials_API_Snippet.jpg)

The script has now been updated with the `OnApiTrigger(IEngine, ApiTriggerInput)` method. You can also remove the comments and unused "using" directives. This should result in the following script code:

[!code-csharp[](~/dataminer/Functions/User-Defined_APIs/Tutorial/Scripts/Elements_Tutorial_Script_Default.cs)]

### Store user input

For this API, the input from the user should be the alarm level (minor, major, etc.) for which the user wants to see the elements. Anything passed in the body of the API request will be available as a string in the *RawBody* property of the *requestData* input argument of the entrypoint method. This content of the *rawBody* can be stored in a variable.

[!code-csharp[](~/dataminer/Functions/User-Defined_APIs/Tutorial/Scripts/Elements_Tutorial_Script_Stored_user_input.cs?highlight=12)]

### Validate user input

The API will currently accept any string as input, even if this is not a valid alarm level. This is why there should be a validation step.

You can add a collection of valid alarm levels, which will be used to check the input. If no valid match is found, a clear error can be returned.

For the response code, the integer representation of the *StatusCode.BadRequest* enum option can be assigned. This will cause the response of the API to be clearly marked as a user request error with the appropriate response code (400).

[!code-csharp[](~/dataminer/Functions/User-Defined_APIs/Tutorial/Scripts/Elements_Tutorial_Script_With_input_validation.cs?highlight=10-11,18-26)]

### Expand the user input with JSON

On large systems, this API could potentially return a large number of records. To prevent performance issues, this should be limited to a certain number, which can also be provided by the user.

The current version of the script expects only one single string value from the body, but now two will have to be sent. This is where JSON can be used to structure the input data and allow you to make APIs that expect multiple input values.

To use JSON, you will need to include the Newtonsoft.Json NuGet package.

1. In Visual Studio, right-click the project *ElementsAPI_1* and click *Manage NuGet packages*.

   ![Visual Studio project dependencies](~/dataminer/images/UDAPIS_Tutorials_Elements_Manage_NuGet.jpg)

1. In the window that opens, click *Browse* at the top.

   ![Visual Studio NuGet browse](~/dataminer/images/UDAPIS_Tutorials_Elements_Browse_NuGet.jpg)

1. Now search for "Newtonsoft.Json", and click the first package.

1. On the right, click *Install*.

   ![Install Newtonsoft.Json](~/dataminer/images/UDAPIS_Tutorials_Elements_Install_NuGet.jpg)

> [!NOTE]
> You could also use the built-in parameter conversion instead of doing the JSON deserialization within this script. This could be a simpler approach if you are less familiar with it. To find out more, see [User input data](xref:UD_APIs_Define_New_API#user-input-data).

To convert (i.e., deserialize) the input JSON to data that can be used in the script, you will have to define a class that contains all the input data that is expected. In this case, the input would look like this:

```json
{
    "alarmLevel" : "Minor",
    "limit" : 10
}
```

The C# class should then look like this:

```csharp
public class Input
{
    public string AlarmLevel { get; set; }

    public int Limit { get; set; }
}
```

When this is done, you can add the actual conversion. By calling `JsonConvert.DeserializeObject<Input>()`, you can easily do so. The library will parse the input and return an instance of the input class where the values have been mapped to the values provided in that JSON input.

When the input data is not correctly formatted, exceptions can be thrown. This is why a try-catch statements should be placed around this conversion. When an exception occurs, a clear error can be returned explaining this. A check can be added at the start of the script that returns an error when the body is empty. This will reduce the number of scenarios where things can go wrong.

Note that there are also `JsonSerializerSettings` defined. These ensure that the conversion will always accept and output camel-case JSON names, which is the recommended casing type for JSON. ("alarmLevel" instead of "AlarmLevel")

[!code-csharp[](~/dataminer/Functions/User-Defined_APIs/Tutorial/Scripts/Elements_Tutorial_Script_With_json_input.cs?highlight=4,8-9,16-20,25-32,34-47,49,68-76)]

### Retrieve the element data

After the input data is converted and validated, it can be used to retrieve the actual element data. This logic should preferably be put into a separate method called `GetElements()`. This method:

- Accepts the input data.
- Converts it to a filter.
- Requests the elements from DataMiner via IEngine.
- Converts the element data to a specific `ElementInfo` output class.
- Ensures the number of records does not exceed the limit set by the input.

Just like with the input data conversion, exceptions could occur when data is retrieved from the system. This why a try-catch statement is recommended here as well.
Another clear error can be returned when something goes wrong.

As you can see at the bottom of the script, an `ElementInfo` class has been defined, which will be used to generate the JSON response. Defining your own types is recommended. This way you have full control over what is included and how it will be serialized. Avoid serializing a class from an external DLL, as there is no guarantee this will remain functional after updates.

[!code-csharp[](~/dataminer/Functions/User-Defined_APIs/Tutorial/Scripts/Elements_Tutorial_Script_Full.cs?highlight=60-72,76,81-116,122-133)]

### Publish the script

When the API script is complete, it needs to be published to the DataMiner System. You can do so using the built-in publish feature of DIS. Make sure that DIS can connect to the DataMiner System you want to upload your script to. You will need to [edit the DIS settings](xref:DIS_settings#dma) so the DMA is selectable:

1. In the *Solution Explorer*, double-click *ElementsAPI.xml*.

   ![Automation script XML](~/dataminer/images/UDAPIS_Tutorials_Elements_Open_Script_XML.png)

1. At the top of the code window, click the arrow next to the *Publish* button and select the DataMiner System you want to upload the script to.

   ![Publish to DMA](~/dataminer/images/UDAPIS_Tutorials_DIS_Publish.jpg)

## Step 2: Create an API token

To access the API, you will need an [API token](xref:UD_APIs_Objects_ApiToken). You can reuse the one you created in the [hello world tutorial](xref:UD_APIs_Hello_world_tutorial), or you can create a new one.

1. Open DataMiner Cube, and log into your DataMiner System.

1. Go to *System Center* > *User-Defined APIs*.

1. Under *Tokens*, click *Create*

1. For the *Name*, enter "ElementsToken", and click *Generate token*.

   ![Create API token](~/dataminer/images/UDAPIS_Tutorials_Elements_Create_API_Token_Name.png)

1. Copy the generated secret to a safe location (e.g., a password manager).

   ![Create API secret](~/dataminer/images/UDAPIS_Tutorials_Elements_Create_API_Token_Secret.png)

   > [!IMPORTANT]
   > After closing this window, you will no longer be able to retrieve the secret. Make sure that the secret is saved somewhere safe. If it is lost, a new token will have to be created.

## Step 3: Create the API Definition

The next step is to create an API definition that ties the token and script together.

1. Open the *Automation* module in DataMiner Cube.

1. Open the *ElementsAPI* automation script.

1. At the bottom of the screen, click the *Configure API* button.

   ![Configure API button](~/dataminer/images/UDAPIS_Tutorials_Cube_Configure_API.jpg)

1. Optionally enter a description for the API.

1. For the *URL*, enter "elements".

1. In the bottom *Tokens* pane, select the *ElementsToken*, which was created in the previous step.

1. Finally, click the *Create* button.

   ![Create API window](~/dataminer/images/UDAPIS_Tutorials_Elements_Create_API_Definition.png)

## Step 4: Trigger the API using Postman

The API is now ready to be tested using an API testing app like Postman. If you have never used Postman before, check [step 5 of the hello world tutorial](xref:UD_APIs_Hello_world_tutorial#step-5-trigger-the-api-using-postman) for more detailed information.

1. Open Postman and click the *+* icon to create a new request.

1. In the URL field, enter `https://HOSTNAME/api/custom/elements`, replacing "HOSTNAME" with the hostname of the DataMiner Agent.

1. Go to the *Authorization* tab and select *Bearer Token* as *Type*.

1. In the *Token* field, enter the API token secret that you copied in [step 2](#step-2-create-an-api-token).

   ![Postman UI new request](~/dataminer/images/UDAPIS_Tutorials_Elements_Postman_API_Request.png)

1. Click the blue *Send* button.

   You should get a *Bad Request* status code with the validation error that was added in the script. This happens because no body was provided in the request. This proves that the validation logic works as expected.

   ![Postman UI response error](~/dataminer/images/UDAPIS_Tutorials_Elements_Postman_Error.jpg)

1. Open the *Body* tab of the request.

1. Change the body type from *none* to *raw* in the dropdown.

1. Change the content type from *text* to *JSON*.

   ![Postman UI add request body](~/dataminer/images/UDAPIS_Tutorials_Elements_Postman_Body_Type.jpg)  

1. Enter the JSON input below the selectors.

    ```JSON
    {
        "alarmLevel": "Minor",
        "limit": 10
    }
    ```

1. Click the blue *Send* button again.

   The API will be triggered, and all elements that have minor alarms should be returned.

   ![Postman UI response](~/dataminer/images/UDAPIS_Tutorials_Elements_Postman_Response.jpg)

This is only a simple example of what can be done using the input and output functionality of a user-defined API. Numerous extensions could be made. For example, a list of alarm levels could be provided in the input, or a flag (i.e., bool property) could be added to the response that indicates whether there are more elements than the provided limit.
