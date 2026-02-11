---
uid: UD_APIs_Hello_world_tutorial
---

# Hello world

This tutorial shows you how to create your first user-defined API. You will create a simple API that, upon execution, will return "Hello world!". The content and screenshots for this tutorial have been created in DataMiner version 10.3.9.

> [!IMPORTANT]
> Before you start this tutorial, take a look at the [prerequisites](xref:UD_APIs_Tutorials).

## Overview

- [Step 1: Create an automation script solution](#step-1-create-an-automation-script-solution)
- [Step 2: Create the automation script](#step-2-create-the-automation-script)
- [Step 3: Create an API token](#step-3-create-an-api-token)
- [Step 4: Create the API Definition](#step-4-create-the-api-definition)
- [Step 5: Trigger the API using Postman](#step-5-trigger-the-api-using-postman)

## Step 1: Create an automation script solution

While you could develop the automation script in Cube, creating an automation script solution in Visual Studio will give you the advantage of having access to all the features of Visual Studio and [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio). If you also use a version control system like Git, this will also enable versioning and make collaboration possible.

## [Visual Studio 2022](#tab/tabid-1)

To create an automation script solution:

1. In Visual Studio, select *Create a new project*.

1. Search for *DataMiner User-Defined APIs Solution (Skyline Communications)* in the template search box and click *Next*.

   ![DataMiner Automation Script Solution in Visual Studio](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_DataMiner_DIS_Solution.jpg)

1. Use "DataMinerAPIs" as the name for your solution, so you can reuse this solution for any future API scripts.

1. Choose a location to save the automation script solution and click *Next*.

   ![Visual Studio configure your project](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_DIS_SolutionSettings.jpg)

1. Specify *HelloWorldAPI* as the name of your Automation script, fill in your name as the author, and click *Create*.

   ![Visual Studio create Automation script](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_DIS_ScriptSettings.jpg)

## [Visual Studio 2019](#tab/tabid-2)

To create an automation script solution:

1. In Visual Studio, select *File > New > DataMiner Automation Script Solution*

   ![DataMiner Automation Script Solution in Visual Studio 2019](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_DataMiner_DIS_Solution_2019.jpg)

1. Use "DataMinerAPIs" as the name for your solution, so you can reuse this solution for any future API scripts.

1. Choose a location to save the automation script solution, and click *Next*.

   ![Visual Studio configure your project](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_DIS_SolutionSettings_2019.jpg)

***

## Step 2: Create the automation script

The logic of your API is in an automation script. This processes input arguments, executes logic, and returns a response. In this example, no input is processed, and no logic is executed. The API will only return "Hello world!" to the user.

## [Visual Studio 2022](#tab/tabid-1)

### Write the API logic

The goal of this tutorial is to have "Hello world!" returned when the API script is triggered. To configure this, you need to replace the default "Succeeded" string provided by the snippet with the "Hello world!" string. The resulting and final state of the script should look like this:

```csharp
namespace HelloWorldAPI_1
{
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            return new ApiTriggerOutput
            {
                ResponseBody = "Hello world!",
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}
```

### Publish the script

When the API script is complete, it needs to be published to the DataMiner System. You can do so using the built-in publish feature of DIS. Make sure that DIS can connect to the DataMiner System you want to upload your script to. You will need to [edit the DIS settings](xref:DIS_settings#dma) so the DMA is selectable.

1. In the *Solution Explorer*, double-click *HelloWorldAPI.xml*.

   ![Automation script XML](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Open_Script_XML.jpg)

1. At the top of the code window, click the arrow next to the *Publish* button, and select the DataMiner System you want to upload the script to.

   ![Publish to DMA](~/dataminer/images/UDAPIS_Tutorials_DIS_Publish.jpg)

## [Visual Studio 2019](#tab/tabid-2)

### Prepare the project

You first need to prepare the project so the dependencies are up to date. To develop API scripts, you will need the *Skyline.DataMiner.Dev.Automation* NuGet package version that matches you DataMiner System. This version should be at least 10.3.6.

1. In the *Solution Explorer* in Visual Studio, under the project named *HelloWorldAPI_1*, right-click *Dependencies*.

1. Click *Manage NuGet packages*.

   ![Visual Studio project dependencies](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Manage_NuGet_Packages.jpg)

1. At the top of the window, click *Updates*.

   ![Visual Studio NuGet updates](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Manage_NuGet_Packages_Updates.jpg)

1. Click the *Skyline.DataMiner.Dev.Automation* package.

1. On the right, select the version that matches your DMS and click *Update*.

   ![Skyline.DataMiner.Dev.Automation NuGet update](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Manage_NuGet_Packages_Automation.jpg)

   > [!TIP]
   > Not sure which DataMiner version you are using? Connect to your DataMiner System using Cube, click the user icon in the Cube header, and select *About*. Under *general*, you will see the DataMiner version.

### Prepare the script

Now that the solution is set up and the dependencies are up to date. You will need to update the default script content with the wrapper code for the API script. The default run method should be replaced with a special entry point method.

1. Double-click the *HelloWorldAPI_1.cs* file in the *Solution Explorer*.

   ![Visual Studio automation script](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Open_Automation_Script.jpg)

1. In the code window, remove the default `Run(IEngine engine)` method.

1. Right-click the empty line between the *Script* class brackets and select *Snippet* > *Insert Snippet*.

   ![Insert snippet](~/dataminer/images/UDAPIS_Tutorials_Insert_Snippet.jpg)  

1. Select the snippet *DIS* > *Automation Script* > *CreateUserDefinedAPI*.

   ![Add entrypoint](~/dataminer/images/UDAPIS_Tutorials_API_Snippet.jpg)

The script has now been updated with the `OnApiTrigger(IEngine, ApiTriggerInput)` method. You can also remove the comments and unused "using" directives. This should result in the following script code:

```csharp
namespace HelloWorldAPI_1
{
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

    public class Script
    {

        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            return new ApiTriggerOutput
            {
                ResponseBody = "Succeeded",
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}
```

### Write the API logic

The goal of this tutorial is to have "Hello world!" returned when the API script is triggered. To configure this, you need to replace the default "Succeeded" string provided by the snippet with the "Hello world!" string. The resulting and final state of the script should look like this:

```csharp
namespace HelloWorldAPI_1
{
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            return new ApiTriggerOutput
            {
                ResponseBody = "Hello world!",
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}
```

### Publish the script

When the API script is complete, it needs to be published to the DataMiner System. You can do so using the built-in publish feature of DIS. Make sure that DIS can connect to the DataMiner System you want to upload your script to. You will need to [edit the DIS settings](xref:DIS_settings#dma) so the DMA is selectable.

1. In the *Solution Explorer*, double-click *HelloWorldAPI.xml* .

   ![Automation script XML](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Open_Script_XML.jpg)

1. At the top of the code window, click the arrow next to the *Publish* button and select the DataMiner System you want to upload the script to.

   ![Publish to DMA](~/dataminer/images/UDAPIS_Tutorials_DIS_Publish.jpg)

***

## Step 3: Create an API token

To access the API, you will need an [API token](xref:UD_APIs_Objects_ApiToken).

1. Open DataMiner Cube, and log into your DataMiner System.

1. Go to *System Center* > *User-Defined APIs*.

1. Under *Tokens*, click *Create*

1. For the *Name*, enter "HelloWorldToken", and click *Generate token*.

   ![Create API Token](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Create_Token_Name.jpg)

1. Copy the generated secret to a safe location (e.g. a password manager).

   ![Create API secret](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Create_Token_Secret.jpg)

   > [!IMPORTANT]
   > After closing this window, you will no longer be able to retrieve the secret. Make sure that the secret is saved somewhere safe. If it is lost, a new token will have to be created.

You should now be able to see the token in the *Tokens* table.

![Tokens list](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Cube_Tokens_Table.jpg)

## Step 4: Create the API Definition

The script and the token are now available in the DMS. The next step is to create an API definition that ties both together. This definition is also used to define the URL where this API will be available.

1. Open the *Automation* module in DataMiner Cube.

1. Open the *HelloWorldAPI* Automation script.

1. At the bottom of the screen, click the *Configure API* button.

   ![Configure API button](~/dataminer/images/UDAPIS_Tutorials_Cube_Configure_API.jpg)

1. Optionally enter a description for the API.

1. For the *URL*, enter "helloworld".

1. In the bottom *Tokens* pane, select the *HelloWorldToken*, which was created in the previous step.

1. Finally, click the *Create* button.

   ![Create API window](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Cube_Create_API.jpg)

The API definition has now been created. Next to the API script, you should see an icon that indicates that this script is used by an API definition.

![User-defined API icon on automation script](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Cube_API_Icon.jpg)

## Step 5: Trigger the API using Postman

The API has now been fully configured. To ensure that it functions correctly, you can test the API using an API testing app like [Postman](https://www.postman.com/downloads/).

> [!NOTE]
> If this is the first time you use Postman, the app will ask you to create an account or sign in. You can create an account, but you can also continue using the *try our lightweight API client* button at the bottom of the screen.

1. Open Postman and click the *+* icon to create a new request.

   !['+' icon in Postman](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Postman_Create_New.jpg)

1. In the URL field, enter `https://HOSTNAME/api/custom/helloworld`, replacing "HOSTNAME" with the hostname of the DataMiner Agent.
  
   ![Postman UI with URL filled in](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Postman_URL.jpg)

1. Go to the *Authorization* tab and select *Bearer Token* as *Type*.

   ![Add bearer token in Postman](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Postman_Authorization.jpg)

1. In the *Token* field, enter the API token secret that you copied in [step 3](#step-3-create-an-api-token).

   ![Postman UI with token filled in](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Postman_Bearer_Token.jpg)

1. Finally, click the blue *Send* button on the right.

An HTTP GET request will now be sent to the API endpoint, which will trigger the API script. You should see the "Hello world!" message in the response section.

![API response](~/dataminer/images/UDAPIS_Tutorials_HelloWorld_Postman_Response.jpg)

> [!TIP]
> If the DMA is using SSL certificates that were not signed by an external certificate authority, you may receive a warning about SSL verification. If you trust the system, you can click *Disable SSL verification* to disable SSL verification and send the request again.
