---
uid: DisTutorials_ValidatorContributions
---

# Contributing to Validator code

## About

In this tutorial, you will explore collaborative software development and DevOps with a focus on adding new checks to the Validator (which is also incorporated in DataMiner Integration Studio (DIS)) and on CI/CD. You will learn how to navigate the Validator source code, add a new check, and create a pull request. With a hands-on exercise using fake Validator source code, you will get to utilize GitHub to create a fork, a clone, and a pull request with your changes so that you will be ready to contribute to the actual Validator.

The only difference between the tutorial and actual contributions lies in the fork used in step 2:

- In the tutorial, you will fork [https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise)

- For real Validator contributions, you will fork [https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators)

This is the missing Validator check you will be adding in this tutorial: When the "datetime" option is added to the *Measurement.Type* tag, the *Display* tag must contain a `<Decimals>8</Decimals>` tag.

Expected duration: 15 minutes.

> [!TIP]
> See also: [Kata #23: Contributing to the DIS Validator](https://community.dataminer.services/courses/kata-23) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- [Microsoft .NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

- [Microsoft Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

> [!NOTE]
> This tutorial requires [Microsoft .NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

> [!WARNING]
> After installing .NET 6.0 SDK and updating Visual Studio, you may need to reboot your computer.

## Step 1: Fork the repository

1. Go to [https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise)

1. In the top-right corner, click *Fork*.

1. Follow the wizard to create a fork of the repository under your own account.

## Step 2: Clone your fork

On the page of your GitHub fork (e.g. `https://github.com/YourGitHubHandle/Skyline.DataMiner.CICD.ValidatorsExercise`), click the *Code* button and select *Open in Visual Studio*.

> [!NOTE]
> In some cases, the *Open in Visual Studio* option may not be available. In that case, you will need to use GitHub Desktop instead to make the clone. Make sure you have [GitHub Desktop](https://desktop.github.com/) installed. Then click the *Code* button on your fork page and select the option *Open with GitHub Desktop* instead.

## Step 3: Run the 'Validator Management Tool'

1. In the *Solution Explorer*, right-click the *Validator Management Tool*, and select *Set as Startup Project*.

   This will turn *Validator Management Tool* bold, and *Validator Management Tool* will appear at the top next to the *Play* button.

1. Click the *Play* button.

   You should now see the following screen:

   ![ValidatorManagementWindow](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/f9c6854e-205c-479c-a3fd-2e8839f46446)

## Step 4: Add a new check

1. In the *Validator Management Tool*, click the *Add Check* button.

   A new window will open.

1. In the new window, do the following:

   ![ValidatorManagementWindowCreateNewTest](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/fccc10e2-9231-47cc-85a8-94ba1c1ece87)

   - **Category:** Choose the top-level category for the check.

     Use `Param`.

   - **Namespace:** Define the "path" of the tag/attribute. If it is a new namespace, use the *Add new Namespace* button.

     In this exercise, the correctness of the *Display* tag is checked. A new namespace for *Protocol.Params.Param.Display.Decimals* should be added.

     Select the newly created `Protocol.Params.Param.Display.Decimals` namespace.

   - **Check Name:** Specify the name of the class to be generated.

     In this exercise, the validity of the content of this tag is checked. A new check named *CheckDecimalsTag* should be added.

     Select the newly created `CheckDecimalsTag`.

   - **Error Message Name:** Enter the name of the error message. A method with that same name will be created during code generation.

     Use `InvalidTagForDateTime`.

   - **Description:** Provide a description with placeholders.

     Open the selection box and select the `Missing tag '{0}' with expected value '{1}' for {2} '{3}'.` template.

   - **Description Parameters:** List the placeholders from the description.

     For this exercise, you can already add some fixed data:

     - tagName: Display/Decimals
     - expectedValue: 8
     - itemKind: Param

     Also rename "itemId" to "paramId" to make the code more readable later on.

   - **Source:** Indicate whether the source is "Validator" (Validate) or "MajorChangeChecker" (Compare).

     Use `Validator`.

   - **Severity:** Specify the severity level. To choose the correct severity, you can follow the following guide:

     - Critical: This type of error will have a critical impact on the system or will fully prevent the connector from working. It may also draw your attention to something that needs to be fixed for administrative reasons.

     - Major: This type of error will prevent part of the connector from working as expected. Example: A specific connector feature will not work.

     - Minor: This type of error will not prevent the connector from working, but will have some impact. It may draw your attention to something that was not implemented according to the best practice guidelines. Example: Bad performance, Not user-friendly, etc.

     - Warning: This type of error reveals something that will not have any impact. Example: Unused XML elements or attributes.

     Use `Major`.

   - **Certainty:** Specify the certainty level.

     - Certain: An error has been detected and needs to be fixed.

     - Uncertain: A possible error has been detected and needs to be fixed once verified.

     Use `Certain`.

   - **Fix Impact:** Determine if there is a breaking change.

     Use `NonBreaking`.

   - **Has Code Fix:** Indicate if an automatic fix is possible.

     Though an automatic fix is possible, automatic fixes are dealt with in a different tutorial. Do not select the checkbox.

   - **How To Fix:** Optionally describe the steps to fix the issue.

     You can write the following:

     ```md
     Add a Protocol/Params/Param/Display/Decimals tag with value 8.
     ```

   - **Example Code:** Optionally provide the correct syntax.

     You can write the following:

     ```xml
     <Display>
        <RTDisplay>true</RTDisplay>
        <Decimals>8</Decimals>
     </Display>
     <Measurement>
        <Type options="datetime">number</Type>
     </Measurement>
     ```

   - **Details:** Extra information about the error. This is important as it will be visible in the DIS UI.

     You can write the following:

     ```md
     By default, only 6 decimals are saved in memory. Parameters holding datetime values need at least 8 decimals to be accurate.
     Otherwise, there might be rounding issues when retrieving the parameter from an external source like an automation script.
     ```

1. Click *Add* to list the error message. If necessary, add more messages or modify existing ones.

   > [!IMPORTANT]
   > Wait for the indication `The XML is outdated!`.

1. Click *Save* to save all changes to the XML file containing all error messages. Then, click *Generate Code* to generate the C# files.

1. Close the window.

## Step 5: Enable your tests

1. In the *Git Changes* window, you can see what was added by the code generation.

   ![ShowGeneratedCode](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/3f9b3c5d-eea4-4fa3-bf4d-83fb086054df)

   Now, the tests can be written. This will ensure that you can develop until no tests are failing.

1. Open the *Valid.xml* file, and create XML code that represents the expected correct XML code:

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

1. Open the *InvalidTagForDateTime.xml*, and create an example of an incorrect situation:

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

1. Go to *ProtocolTests\Protocol\Params\Param\Display\Decimals\CheckDecimalTag*, open the *CheckDecimalTag.cs* file, and remove all the `Ignore` attributes.

   ![ValidatorShowGeneratedCodeChangeTests](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/1cacc3ac-8a13-4b37-b710-7cae5882cf07)

1. Uncomment the `Error.InvalidTagForDateTime(...` line, and change it to what is expected.

   You can press F12 on the static method to see the expected description format: `Missing tag '{0}' with expected value '{1}' for {2} '{3}'.`

   ```csharp
   Error.InvalidTagForDateTime(null, null, null, "10"),
   ```

1. Right-click the first line of the file, and select *Run Tests*.

   At this point, you should see three failing tests.

## Step 6: Write your logic

1. In the *Git Changes* window, you can see what was added by the code generation.

1. Go to *Tests\Protocol\Params\Display\Decimals*, and open the *CheckDecimalTag.cs* file.

   ![ValidatorShowGeneratedCodeChangeLogic](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.ValidatorsExercise/assets/71829634/e0b6a630-e769-471b-a312-6da72e57a6f8)

1. Make sure to check [the documentation of the tag](https://docs.dataminer.services/develop/schemadoc/Protocol/Protocol.Params.Param.Measurement.Type-options.html#options-for-measurement-type-number) to find out what syntax options exist.

1. Uncomment the following attribute:

   ```csharp
   //[Test(CheckId.CheckDecimalTag, Category.Param)]
   ```

1. Comment out `ICodeFix` and `ICompare`. Only `IValidate` will be used.

1. Most of your validation will need to loop over several items to validate. In this case, every parameter is needed: *context.EachParamWithValidId*.

   You can use the following code:

   ```csharp
   public List<IValidationResult> Validate(ValidatorContext context)
   {
      List<IValidationResult> results = new List<IValidationResult>();
   
      foreach (var param in context.EachParamWithValidId())
      {
         var displayTag = param.Display;
         
         // Early return pattern. Only check when there is a Display tag.
         if (displayTag == null) continue;

         // Only check number types.
         if (!param.IsNumber()) continue;
    
         // Only check if date or datetime parameter
         if (!param.IsDateTime()) continue;
    
         // Verify valid decimals.
         var decimalsTag = param.Display?.Decimals;
         if (decimalsTag?.Value != 8)
         {
            var positionNode = decimalsTag ?? (IReadable)displayTag;
            results.Add(Error.InvalidTagForDateTime(this, param, positionNode, param.Id.RawValue));
         }
      }
    
      return results;
   }
   ```

1. As `IReadable` will not be found by default, add an extra "using" at the top of the file:

   ```csharp
   using Skyline.DataMiner.CICD.Models.Protocol.Read;
   ```

## Step 7: Verify your code

1. Run your new tests. Check whether all tests pass.

1. Run the entire test battery to check for any regression. This can take several minutes.

## Step 8: Create a pull request

In order to share your changes with the original owner, you will need to create a pull request.

- If you are using Visual Studio 2022, you can do this from within Visual Studio. It will detect that you performed a commit and push to a forked repository, and it will suggest making a pull request.

- You can also do this from GitHub by navigating to the *Pull requests* tab of your fork page and then clicking the *New pull request* button.

This will inform the owners that you suggested additions and changes. Those can then be reviewed, merged and released.

For this exercise, this will trigger an automatic pipeline that closes your pull request and forwards the results to Skyline.

> [!NOTE]
> Skyline will review your submission. Upon successful review, you will be awarded the appropriate DevOps points as a token of your accomplishment.
