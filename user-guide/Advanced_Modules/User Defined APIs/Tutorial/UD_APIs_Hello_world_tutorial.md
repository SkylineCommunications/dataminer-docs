---
uid: UD_APIs_Hello_world_tutorial
---

# Hello world tutorial

This tutorial lesson demonstrates how to create your first custom API. We will create a simple API that, upon execution, will return 'Hello world'.

## Overview

- [Step 1: Create an automation script solution](#step-1-create-an-automation-script-solution)
- [Step 2: Create the automation script](#step-2-create-the-automation-script)
- [Step 3: Create an API token](#step-3-create-an-api-token)
- [Step 4: Create an API Definition](#step-4-create-the-api-definition)
- [Optional step: Test the API using the SLNet Client Test Tool](#optional-step-test-the-api-using-the-slnet-client-test-tool)
- [Step 5: Trigger the API using Postman](#step-5-trigger-the-api-using-postman)

## Step 1: Create an automation script solution

We could just start developing our automation script in cube, but creating an automation script solution gives us the advantage of using all the features of Visual Studio and [DIS](xref:DIS). In combination with a version control system like Git, we could also provide versioning and make collaboration possible.

1. Open Visual Studio and select 'Create a new project'. Search for 'DataMiner Automation Script Solution (Skyline Communications)' in the template searchbox and click next.
![DataMiner Automation Script Solution in Visual Studio](~/user-guide/images/UDAPIS_helloworld_1.jpg)
1. Let's use 'DataMinerAPIs' as name for our Solution, so we can reuse this solution for any future API scripts. Choose a location to save the automation script solution and click next.
![Visual Studio configure your project](~/user-guide/images/UDAPIS_helloworld_2.jpg)

1. Now the name and author of your automation script are required, follow the next step to create your automation script.

## Step 2: Create the automation script

The logic of your API is in an automation script, the automation script processes input arguments, executes logic and returns a response. For this example we won't process any input, and no logic will be executed, we'll only return 'Hello world!' to the user.

1. Let's use 'HelloWorldAPI' as name for our automation script, fill in your name as author and click Create.
![Visual Studio create automation script](~/user-guide/images/UDAPIS_helloworld_3.jpg)

1. First we'll have to update the NuGet references to make sure they match our DataMiner version. In the 'Solution Explorer' in Visual Studio, right click 'Dependencies' under the project named 'HelloWorldAPI_1'. Then click 'Manage NuGet packages...'. In that window, click 'Updates' in the top.  
![Visual Studio project dependencies](~/user-guide/images/UDAPIS_helloworld_4.jpg)  
![Visual Studio NuGet updates](~/user-guide/images/UDAPIS_helloworld_5.jpg)

1. You'll see that the 'Skyline.DataMiner.Dev.Automation' package has an Update. This package contains all the DataMiner assemblies we need to develop an automation script. Click it, and on the right side, change the 'Version' to the DataMiner version you're using, and click 'Update'.  
![Skyline.DataMiner.Dev.Automation NuGet update](~/user-guide/images/UDAPIS_helloworld_6.jpg)  

   > [!TIP]
   > Don't know your DataMiner version? Connect to your DataMiner system using Cube, click the user icon in the Cube header and select *About*. Under *general*, the DataMiner version can be seen.

1. Now we can start developing our API automation script. Double-click the 'HelloWorldAPI_1.cs' file in the Solution Explorer. This will open our C# file.  
![Visual Studio automation script](~/user-guide/images/UDAPIS_helloworld_7.jpg)

1. By default, our automation script has a `Run(IEngine engine)` method. This method is executed when executing the automation script. But for an API script, we use a different entrypoint. Remove the entire `Run(IEngine engine method)`.
![Initial script layout](~/user-guide/images/UDAPIS_helloworld_8.jpg)

1. To add the entrypoint method for an API in the automation script, we can use a snippet. Right click the empty line between the two curly brackets, select *Snippet*, *Insert Snippet...*, or use the shortcut command. Select *DIS* > *Automation Script* > *CreateUserDefinedAPI*.  
![Insert snippet buttonInitial script layout](~/user-guide/images/UDAPIS_helloworld_9.jpg)  
![Add entrypoint](~/user-guide/images/UDAPIS_helloworld_10.jpg)

1. Your script is now updated with the `OnApiTrigger(IEngine, ApiTriggerInput)` method. You can ignore/remove the comments underneath the curly bracket, as we already updated the NuGet package.

1. Now we're going to build the logic of our API. Our API script will return 'Hello world!'. The only thing we need to change to achieve that is the *ResponseBody* in the return statement, that now returns `"Succeeded"`. Change the string to return `"Hello world!"` instead. When finished, your script should look like this:

    ```C#
    namespace HelloWorldAPI_1
    {
        using Skyline.DataMiner.Automation;
        using Skyline.DataMiner.Net.Apps.UserDefinableApis;
        using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

        /// <summary>
        /// Represents a DataMiner Automation script.
        /// </summary>
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

1. Now we will upload our automation script to DataMiner using the built-in feature in DIS. Make sure that DIS can connect to the DataMiner system you want to upload your script to, to add your DataMiner system, [edit the DIS settings](xref:DIS_settings#dma). In the Solution Explorer, open the HelloWorldAPI.xml file by double-clicking it. At the top you'll see a 'Publish' button. Click the arrow next to it and click the DataMiner system you want to upload your automation script to.  
![Automation script XML](~/user-guide/images/UDAPIS_helloworld_11.jpg)  
![Publish to DMA](~/user-guide/images/UDAPIS_helloworld_12.jpg)

## Step 3: Create an API token

To access our API, we require an [access token](xref:UD_APIs_Objects_ApiToken).

1. Open DataMiner Cube, and login to your DataMiner system

1. Open *System Center* > User-Defined APIs*. In this window we can manage our APIs and Tokens.

1. Under *Tokens* click *Create...*

1. Let's name our token 'HelloWorldToken', and click *Generate token*.
![Create API Token](~/user-guide/images/UDAPIS_helloworld_13.jpg)

1. A secret will now be generated, copy it, and **make sure you save it somewhere.** We will need it later to trigger our API, **you cannot retrieve the secret again after closing this window!** You can now see our token in the list of available tokens!
![Create API secret](~/user-guide/images/UDAPIS_helloworld_14.jpg)

![Tokens list](~/user-guide/images/UDAPIS_helloworld_15.jpg)

## Step 4: Create the API Definition

We will now create an API using the automation script and token we made earlier.

1. Close the *System Center* in Cube and open the *Automation* module.

1. You should see our *HelloWorldAPI* automation script in the left bar, click it to open it.

1. At the bottom of the screen, there's a *Configure API...* button. Click it to start configuring our API.
![Configure API... button](~/user-guide/images/UDAPIS_helloworld_16.jpg)

1. Fill in a description, fill in 'helloworld' for the URL part, and select the 'HelloWorldToken' we made earler as access token, leave all other settings default. Then click *Create*.  
![Create API window](~/user-guide/images/UDAPIS_helloworld_17.jpg)

1. You should now see an icon as shown in the image next to your automation script, this shows that your API is live!
![User-defined API icon on automation script](~/user-guide/images/UDAPIS_helloworld_18.jpg)

## Optional step: Test the API using the SLNet Client Test Tool

You can test your API using the SLNet Client Test Tool, how to do that is described on the [triggering and managing a user-defined API](xref:SLNetClientTest_triggering_api#triggering-a-user-defined-api) page. This approach is great for testing, but does not use an actual API call like we will use in the next step.

## Step 5: Trigger the API using Postman

We are now ready to trigger an API request! [Postman](https://www.postman.com/) is a commonly used tool to test APIs.

1. Open Postman, and click on the *+* icon to create a new request.

1. Fill in the URL, this will be `https://HOSTNAME/api/custom/helloworld`. Make sure to replace HOSTNAME with the actual hostname of your DataMiner agent.

1. Now go to the Authorization tab and choose 'Bearer token' as Type.
![Add bearer token in Postman](~/user-guide/images/UDAPIS_helloworld_19.jpg)

1. In the token section, fill in the secret of the token that we made in [step 2](#step-3-create-an-api-token).

1. Now click the 'Send' button on the right side. You should get 'Hello world' as a response. If you get a warning about SSL verification, you can click *Disable SSL verification* to disable SSL verification and send again.
![Api response](~/user-guide/images/UDAPIS_helloworld_20.jpg)
