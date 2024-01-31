---
uid: DisTutorials_ValidatorContributions
---

# Contributing to Validator code

## About

In this tutorial, you will explore collaborative software development and DevOps with a focus on adding new checks to the Validator as used within DIS (DataMiner Integration Studio) and CI/CD. You will learn how to navigate the Validator source code, add a new check and create a Pull Request. With a hands-on exercise using a fake Validator source code, you will get to utilize GitHub to create a fork, a clone, and a pull request with your changes so that you are ready to perform the real thing!

In the below exercise, the only difference between the exercise and the real thing is in Step 2, your fork:

- For the exercise you will fork [https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise)

- For real validator contributions, you will fork [https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators)

The missing test:
When adding the option "datetime" to the Measurement.Type tag, check if the "Display" tag has the tag <Decimals>8</Decimals>

Expected duration: 15 minutes.

> [!TIP]
> See also: [Kata #X: Validator Contribution](https://community.dataminer.services/courses/kata-X) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

> [!NOTE]
> This tutorial requires .NET 6.0 SDK. You can install the SDK [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
>

> [!WARNING]
> After installing .NET 6.0 SDK and updating Visual Studio you may require a PC reboot.

## Prerequisites

- [SDK 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [GitHub Account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

## Step 1: Fork the repository

1. Go to [https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise)

1. In the top right corner, click *Fork*.

1. Follow the wizard to create a fork of the repository under your own account.

## Step 2: Clone your fork

On the page of your GitHub fork (e.g. `https://github.com/YourGitHubHandle/Skyline.DataMiner.CICD.ValidatorsExercise`), click the *Code* button and select *Open in Visual Studio*.

> [!NOTE]
> In some cases, the *Open in Visual Studio* option may not be available. In that case, you will need to use GitHub Desktop instead to make the clone. Make sure you have [GitHub Desktop](https://desktop.github.com/) installed, and when you click the *Code* button on your fork page, select the option *Open with GitHub Desktop* instead.

## Step 3: Run the 'Validator Management Tool'

1. In the Solution Explorer, right click the *Validator Management Tool* and select *Set as Startup Project*

   This turns the *Validator Management Tool* bold and you'll see *Validator Management Tool* at the top next to the play button.

1. Click the Play button You should now see the following screen

![ValidatorManagementWindow](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/f9c6854e-205c-479c-a3fd-2e8839f46446)

## Step 4: Add a new check

1. In the *Validator Management Tool*, click the **Add Check...** button. This opens a new window.

1. In the new window, follow these steps:

![ValidatorManagementWindowCreateNewTest](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/dcaa8bbd-6d51-43d7-8dbe-e91b3de05c73)

   - **Category:** Choose the top-level category for the check. 

     Use `Param` for this exercise.

   - **Namespace:** Define the 'path' for the tag/attribute. If it's a new namespace, use the **Add new Namespace...** button.

     In this exercise we are checking the correctness of the Display tag. So we should add a new namespace for Protocol.Params.Param.Display.Decimals

     Select the newly created `Protocol.Params.Param.Display.Decimals` namespace.

   - **Check Name:** Specify the name of the class to be generated.

     In this exercise we want to check the validity of the content of this tag. We should add a new Check called CheckDecimalsTag.

     Select the newly created `CheckDecimalsTag` for this exercise.

   - **Error Message Name:** Name the error message. It will become a method during code generation.

     Use `InvalidTagForDateTime` for this exercise.

   - **Description:** Provide a description with placeholders.

     Select from the templates in the dropdown `Missing tag '{0}' with expected value '{1}' for {2} '{3}'.`

   - **Description Parameters:** List the placeholders from the description.

     For this exercise, we can add some fixed data already:
     tagName: Display/Decimals
     expectedValue: 8
     itemKind: Param

     We can also rename itemId into paramId to make our code more readable later on.

   - **Source:** Indicate whether it's from Validator (Validate) or MajorChangeChecker (Compare).

     Use `Validator` for this exercise.

   - **Severity:** Specify the severity level. To choose the right severity, you can follow the following guide:
       
       - Critical: This type of error will have a critical impact on the system or will fully prevent the driver from working. It may also draw your attention to something that needs to be fixed for administrative reasons.

       - Major: This type of error will prevent part of the driver from workingas expected. Example: A specific driver feature will not work.

       - Minor: This type of error will not prevent the driver from working, but will have some impact. It may draw your attention to something that was not implemented according to the best practice guidelines. Example: Bad performance, Not user-friendly, etc.

       - Warning: This type of error reveals something that will not have any impact.Example: Unused XML elements or attributes.

        Use `Major` for this exercise.

   - **Certainty:** Specify the certainty level.
      
      - Certain: An error has been detected and needs to be fixed.

      - Uncertain: A possible error has been detected and needs to be fixed once verified.

     Use `Certain` for this exercise.

   - **Fix Impact:** Determine if there's a breaking change.

     Use `NonBreaking` for this exercise.

   - **Has Code Fix:** Indicate if an automatic fix is possible.

     Though an automatic fix is possible. We'll tackle that in a different tutorial. `Uncheck` for this exercise.

   - **How To Fix:** Optionally describe the steps to fix the issue.

     We can write
     ```md
     Add the Protocol.Params.Param.Display.Decimals tag with value 8`. for this exercise.
     ```
   - **Example Code:** Optionally provide correct syntax.

     For this exercise we can write:

```xml
   <Display>
    <RTDisplay>true</RTDisplay>
    <Decimals>8</Decimals>
   </Display>
   <Measurement>
    <Type options="datetime">number</Type>
   </Measurement>
```
   - **Details:** Extra information about the error. This is important as it will be visible in the UI of DIS.

For this exercise we can write:
```md
By default, only 6 decimals are saved in memory. Parameters holding datetime needs at least 8 decimals to be accurate.
Otherwise you can see rounding issues when retrieving the parameter from an external source like an Automation Script.
```

1. After clicking **Add**, the error message will be listed. If desired, add more messages or modify existing ones.

    **Important** Wait for the indication: The XML is outdated!

1. Click **Save** to save changes to the XML holding all error messages. Then, click **Generate Code** to generate C# files.

1. You can now close the window.

## Step 5: Enable your tests

1. If you look at the Git Changes window, you can easily see what was added by the code generation.

![ShowGeneratedCode](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/3f9b3c5d-eea4-4fa3-bf4d-83fb086054df)

1. We can start by writing our tests first. This ensures we can develop until failing tests become OK.

    1. Open the Valid.xml file and create XML representing the expected correct XML:

```xml
<Protocol xmlns="http://www.skyline.be/validatorProtocolUnitTest">
	<Params>
		<Param id="10">
			<Display>
				<RTDisplay>true</RTDisplay>
				<Decimals>8</Decimals>
			</Display>
			<Measurement>
				<Type options="datetime">number</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>
```

1. Open the InvalidTagForDateTime.xml and create an example of an incorrect situation: 

```xml
<Protocol xmlns="http://www.skyline.be/validatorProtocolUnitTest">
	<Params>
		<Param id="10">
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
			<Measurement>
				<Type options="datetime">number</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>
```
    
1. Open CheckDecimalTag.cs from the *ProtocolTests\Protocol\Params\Param\Display\Decimals\CheckDecimalTag* and remove the [Ignore] attributes on everything.
   
    ![ValidatorShowGeneratedCodeChangeTests](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/1cacc3ac-8a13-4b37-b710-7cae5882cf07)

1. Uncomment the Line: `Error.InvalidTagForDateTime(...` and change this to what we expect to get:
        You can F12 on the static method to see the expected description format again. `Missing tag '{0}' with expected value '{1}' for {2} '{3}'.`
```cs
  Error.InvalidTagForDateTime(null, null, null, "paramId"),
```
1. Try executing all these tests by right clicking on the first line of file and selecting Run Tests.
        You should see 3 failing tests at this point.

## Step 6: Write your logic

1. If you look at the Git Changes window, you can easily see what was added by the code generation.

1. Open CheckDecimalTag.cs from inside the *Tests\Protocol\Params\Display\Decimals*
![ValidatorShowGeneratedCodeChangeLogic](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/e0b6a630-e769-471b-a312-6da72e57a6f8)

1. Make sure to check [the documentation](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.Measurement.Type-options.html#options-for-measurement-type-number) of the tag, to see what possible syntaxes exist. 

1. Uncomment this attribute //[Test(CheckId.CheckDecimalTag, Category.Param)]
   
1. Comment out ICodeFix and ICompare. We will only use IValidate.
    
1. Most of your validation will need to loop over several items to validate. In our case we need every parameter: *context.EachParamWithValidId*.
      You can use the following code:

```cs
        public List<IValidationResult> Validate(ValidatorContext context)
        {
            List<IValidationResult> results = new List<IValidationResult>();

            foreach (var param in context.EachParamWithValidId())
            {
                // Early Return pattern. Only check number types.
                if (!param.IsNumber()) continue;

                // Only check if there are options.
                var allOptions = param.Measurement?.Type?.Options?.Value?.Split(';');
                if (allOptions == null) continue;

                // Is there an option involving date or datetime?
                List<string> possibleLowerCaseDateSyntax = new List<string>() { "date", "datetime", "datetime:minute" };
                bool foundDateTime = Array.Exists(allOptions, option => possibleLowerCaseDateSyntax.Contains(option.ToLower()));

                // Verify valid decimals.
                var decimalsTag = param.Display?.Decimals;
                if (foundDateTime && decimalsTag?.Value != 8)
                {
                    results.Add(Error.InvalidTagForDateTime(this, param, decimalsTag, param.Id.RawValue));
                }
            }

            return results;
        }
```

## Step 7: Verify your code

 1. Run your new tests. Check if they are green.

 1. Run the entire test battery, to check for any regression. (this can take several minutes)

## Step 8: Create a pull request

In order to share your changes with the original owner, you now need to create a pull request.

- If you are using Visual Studio 2022, you can do this from within Visual Studio. It will detect that you did a commit and push to a forked repository, and it will suggest making a pull request.

- You can also do this from GitHub by navigating to the *Pull requests* tab of your fork page and then clicking the *New pull request* button.

This will inform the owners of your suggested additions and changes. They can then be reviewed, merged and released.

For this exercise, this will trigger an automatic pipeline that closes your pull request and forwards the results to Skyline.

> [!NOTE]
> Skyline will review your submission. Upon successful validation, you will be awarded the appropriate DevOps Points as a token of your accomplishment.
