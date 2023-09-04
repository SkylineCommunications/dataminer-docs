---
uid: UD_APIs_Hello_world_tutorial
---

# Hello world tutorial

This tutorial shows you how to create your first custom API. You will create a simple API that, upon execution, will return "Hello world".

> [!IMPORTANT]
> Before you start this tutorial, take a look at the [prerequisites](xref:UD_APIs_tutorials).

## Overview

- [Step 1: Create an Automation script solution](#step-1-create-an-automation-script-solution)
- [Step 2: Create the Automation script](#step-2-create-the-automation-script)
- [Step 3: Create an API token](#step-3-create-an-api-token)
- [Step 4: Create the API Definition](#step-4-create-the-api-definition)
- [Step 5 (optional): Test the API using the SLNetClientTest Tool](#step-5-optional-test-the-api-using-the-slnet-client-test-tool)
- [Step 6: Trigger the API using Postman](#step-6-trigger-the-api-using-postman)

## Step 1: Create an Automation script solution

While you could develop the Automation script in Cube, creating an Automation script solution in Visual Studio will give you the advantage of having access to all the features of Visual Studio and [DIS](xref:DIS). If you also use a version control system like Git, this will also enable versioning and make collaboration possible.

1. Create an Automation script solution:

   1. In Visual Studio, select *Create a new project*.

   1. Search for *DataMiner Automation Script Solution (Skyline Communications)* in the template search box and click *Next*.

      ![DataMiner Automation Script Solution in Visual Studio](~/user-guide/images/UDAPIS_helloworld_1.jpg)

   1. Use "DataMinerAPIs" as the name for your solution, so you can reuse this solution for any future API scripts.

   1. Choose a location to save the Automation script solution and click Next.

      ![Visual Studio configure your project](~/user-guide/images/UDAPIS_helloworld_2.jpg)

## Step 2: Create the Automation script

The logic of your API is in an Automation script. This processes input arguments, executes logic, and returns a response. In this example, no input is processed, and no logic is executed. The API will only return "Hello world!" to the user.

1. Specify *HelloWorldAPI* as the name of your Automation script, fill in your name as the author, and click *Create*.

   ![Visual Studio create Automation script](~/user-guide/images/UDAPIS_helloworld_3.jpg)

1. Update the NuGet references to make sure they match your DataMiner version:

   1. In the *Solution Explorer* in Visual Studio, under the project named *HelloWorldAPI_1*, right-click *Dependencies*.

   1. Click *Manage NuGet packages*. At the top of the window, click *Updates*.

   ![Visual Studio project dependencies](~/user-guide/images/UDAPIS_helloworld_4.jpg)  
  
   ![Visual Studio NuGet updates](~/user-guide/images/UDAPIS_helloworld_5.jpg)

1. You will see that the *Skyline.DataMiner.Dev.Automation* package has an update. This package contains all the DataMiner assemblies we need to develop an Automation script. Click it, and on the right side, change the *Version* to the DataMiner version you are using, and click *Update*.

   ![Skyline.DataMiner.Dev.Automation NuGet update](~/user-guide/images/UDAPIS_helloworld_6.jpg)  

   > [!TIP]
   > Not sure which DataMiner version you are using? Connect to your DataMiner System using Cube, click the user icon in the Cube header, and select *About*. Under *general*, you will see the DataMiner version.

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

1. Open *System Center* > *User-Defined APIs*. In this window we can manage our APIs and Tokens.

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

## Step 5 (optional): Test the API using the SLNet Client Test Tool

You can test your API using the SLNet Client Test Tool, how to do that is described on the [triggering and managing a user-defined API](xref:SLNetClientTest_triggering_api#triggering-a-user-defined-api) page. This approach is great for testing, but does not use an actual API call like we will use in the next step.

## Step 6: Trigger the API using Postman

We are now ready to trigger an API request! [Postman](https://www.postman.com/) is a commonly used tool to test APIs.

1. When this is the first time using postman, the app will ask you to create an account or sign in. you're free to do this, but you can also continue using the *try our lightweight API client* button at the bottom of the screen.

1. Open Postman, and click on the *+* icon to create a new request.  
!['+' icon in Postman](~/user-guide/images/UDAPIS_helloworld_19.jpg)  

1. Fill in the URL, this will be `https://HOSTNAME/api/custom/helloworld`. Make sure to replace HOSTNAME with the actual hostname of your DataMiner agent.  
![Postman UI with url filled in](~/user-guide/images/UDAPIS_helloworld_20.jpg)  

1. Now go to the Authorization tab and choose 'Bearer token' as Type.
![Add bearer token in Postman](~/user-guide/images/UDAPIS_helloworld_21.jpg)  

1. In the token section, fill in the secret of the token that we made in [step 2](#step-3-create-an-api-token).
![Postman UI with token filled in](~/user-guide/images/UDAPIS_helloworld_22.jpg)  

1. Now click the 'Send' button on the right side. You should get 'Hello world' as a response. If you get a warning about SSL verification, you can click *Disable SSL verification* to disable SSL verification and send again.
![Api response](~/user-guide/images/UDAPIS_helloworld_23.jpg)  
