---
uid: QAOps_Tutorials_User_Tutorials_Advanced_Creating_Test_Packages
---

# How to create a test package

In this tutorial, you create a basic low-code app, prepare a DataMiner test package to test it, and trigger a QAOps test run.

For all tutorials, use the "QAOps Sandbox Environment": [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

Expected duration: 15 to 25 minutes.

## Prerequisites

- Access to [https://qaops-sandbox.skyline.be](https://qaops-sandbox.skyline.be).

- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/).

- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/).

    - Enable the ASP.NET and web development workload in Visual Studio. For details, see [Troubleshooting](xref:skyline_dataminer_sdk_troubleshooting#missing-manage-user-secrets-context-menu-in-visual-studio).

- Access to a DataMiner System with rights to create a low-code-app

- [PowerShell 7](https://learn.microsoft.com/en-us/powershell/scripting/install/install-powershell-on-windows?view=powershell-7.5).

> [!IMPORTANT]
> Contact support.boost@skyline.be to receive a username and password for access to the sandbox system.

## Overview

- [Step 1: Create a new DataMiner test package project](#step-1-create-a-new-dataminer-test-package-project)

- [Step 2: Create a low-code app to be tested](#step-2-create-a-low-code-app-to-be-tested)

- [Step 3: Create the DataMiner environment to be tested](#step-3-create-the-dataminer-environment-to-be-tested)

- [Step 4: Write a test](#step-4-write-a-test)

- [Step 5: Harvest the test](#step-5-harvest-the-test)

- [Step 6: Write the test execution PowerShell script](#step-6-write-the-test-execution-powershell-script)

- [Step 7: Download, install, and verify the QAOps tool](#step-7-download-install-and-verify-the-qaops-tool)

- [Step 8: Find the unique test and configuration identifiers](#step-8-find-the-unique-test-and-configuration-identifiers)

- [Step 9: Create a token](#step-9-create-a-token)

- [Step 10: Create and find the test package](#step-10-create-and-find-the-test-package)

- [Step 11: Trigger the test run](#step-11-trigger-the-test-run)

- [Step 12: Verify that the request was received](#step-12-verify-that-the-request-was-received)

## Related information

- [QAOps](xref:QAOps)

- [QAOps main UI](xref:QAOps_Main_UI)

- [QAOps tool](xref:QAOps_Tool)

- [QAOps test package](xref:QAOps_Test_Package)

- [QAOps configuration](xref:QAOps_Configuration)

- [QAOps test suite](xref:QAOps_Test_Suite)

- [QAOps test run](xref:QAOps_Test_Run)

- [QAOps test result](xref:QAOps_Test_Result)

## Step 1: Create a new DataMiner test package project

1. Open Visual Studio and select *Create new project*.

1. Select the *DataMiner Test Package Project* template, and then click *Next*.

1. Enter a project name, for example "MyFirstTestPackage".

1. Choose a location, for example "C:\DataMiner Testing".

1. Make sure *Place solution and project in the same directory* remains cleared.

1. Click *Next*.

1. Enter your name or initials in *Author*.

1. Verify that *Create DataMiner Package options* is selected.

1. For this tutorial, keep *GitHub Workflows* set to *None*.

1. Click *Create*.

After the project opens, you should see the "Getting Started" Markdown file.

## Step 2: Create a low-code app to be tested

If you have access to a DataMiner system, create a low-code app for this test.

1. In a browser, go to your DataMiner system.

1. Click *+ Create app*.

1. Click *Create page*.

1. Click the green bar with *+* to open the component selection panel.

1. Drag *Text* from *General*.

1. Drag *Text Input* from *Basic Controls*.

1. Select the new *Text* component, go to *Settings*, and enter an expression like "Welcome {COMPONENT.Page.\"Text input 2\".Value.Texts.Value}".

1. Select the new *Text Input* component, go to *Settings*, and enable *Value Change*.

1. Publish the app and verify that text entered in the input box appears in the welcome text.

1. Copy the app identifier from the URL and save it in a text file.

For example, copy "991d7084-cd0a-412b-bffe-0ea176fc5430" from:

https://localhost/app/991d7084-cd0a-412b-bffe-0ea176fc5430/Page


## Step 3: Create the DataMiner environment to be tested

1. In Visual Studio, connect DIS to the DataMiner system where you created the low-code app.

1. On the menu bar, select *Extensions* > *DIS* > *DMA* > *Connect*.

1. Open *Solution Explorer* (shortcut: Ctrl+Alt+L).

1. Expand *Package Content*.

1. Right-click *LowCodeApps*, select *Add*, and then click *Import DataMiner Low-Code-App*.

1. Select the app you created in Step 2.

## Step 4: Write a test

1. Open *Solution Explorer* (shortcut: Ctrl+Alt+L).

1. Right-click *Solution 'MyFirstTestPackage'*, select *Add*, and then select *New Item* (Ctrl+Shift+A).

1. Select *C# Class* and name it "PlaywrightUITest.cs".

1. Confirm that the file is added under *Solution Items*.

1. Replace the file content with the following code:

``` csharp
#:property PublishAot=false
#:package Microsoft.Playwright@1.57.0
#:package Skyline.DataMiner.CICD.Tools.WinEncryptedKeys.Lib@2.1.0

using Microsoft.Playwright;

using Skyline.DataMiner.CICD.Tools.WinEncryptedKeys.Lib;

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

const string Url = "https://localhost/app/991d7084-cd0a-412b-bffe-0ea176fc5430/Page";
const string InputValue = "Random Person Name";

try
{
    var playwrightFolder = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    "ms-playwright");

    var chromiumInstalled =
        Directory.Exists(playwrightFolder) &&
        Directory.GetDirectories(playwrightFolder, "chromium-*").Any();

    if (!chromiumInstalled)
    {
        Microsoft.Playwright.Program.Main(new[] { "install", "chromium" });
    }

    using var playwright = await Playwright.CreateAsync();

    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        Headless = false,
    });

    var context = await browser.NewContextAsync(new BrowserNewContextOptions
    {
        IgnoreHTTPSErrors = true,
    });

    var page = await context.NewPageAsync();

    await page.GotoAsync(Url, new PageGotoOptions
    {
        WaitUntil = WaitUntilState.NetworkIdle,
    });

    await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

    await LoginLocally(page);

    Thread.Sleep(5000);
    await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

    var textInputComponent = await FindFirstComponentByDataComponentNameRegexAsync(
        page,
        new Regex(@"^Text Input \d+$", RegexOptions.IgnoreCase));

    if (textInputComponent is null)
        throw new InvalidOperationException("Could not find a component with data-component-name matching '^Text Input \\d+$'.");

    var input = textInputComponent.Locator("input[type='text']").First;
    await input.WaitForAsync();
    await input.FillAsync(InputValue);

    var textComponent = await FindFirstComponentByDataComponentNameRegexAsync(
        page,
        new Regex(@"^Text \d+$", RegexOptions.IgnoreCase));

    if (textComponent is null)
        throw new InvalidOperationException("Could not find a component with data-component-name matching '^Text \\d+$'.");

    var expectedText = $"Welcome {InputValue}";
    await Assertions.Expect(textComponent).ToContainTextAsync(expectedText);
    Thread.Sleep(5000);
    Console.WriteLine($"PLAYWRIGHT_TEST_SUCCESS: Validated text component contains '{expectedText}'.");
    Environment.Exit(0);
}
catch (Exception ex)
{
    Console.Error.WriteLine($"PLAYWRIGHT_TEST_FAILURE: {ex}");
    Environment.Exit(1);
}

static async Task<ILocator?> FindFirstComponentByDataComponentNameRegexAsync(IPage page, Regex regex)
{
    var components = page.Locator("dma-db-component[data-component-name]");
    var count = await components.CountAsync();

    for (var i = 0; i < count; i++)
    {
        var component = components.Nth(i);
        var name = await component.GetAttributeAsync("data-component-name");

        if (!string.IsNullOrWhiteSpace(name) && regex.IsMatch(name))
            return component;
    }

    return null;
}

static async Task LoginLocally(IPage page)
{
    if (!Keys.TryRetrieveKey("QAOpsDataMinerUser", out var userName) || string.IsNullOrWhiteSpace(userName))
        throw new InvalidOperationException("Could not retrieve QAOpsDataMinerUser.");

    if (!Keys.TryRetrieveKey("QAOpsDataMinerPassword", out var password) || string.IsNullOrWhiteSpace(password))
        throw new InvalidOperationException("Could not retrieve QAOpsDataMinerPassword.");

    await page.GetByPlaceholder("Username").Last.FillAsync(userName);
    await page.GetByPlaceholder("Password").Last.FillAsync(password);
    await page.Locator("dwa-cta-button").GetByText("Sign in").ClickAsync();
}

```

1. Find this line:

    `const string Url = "https://localhost/app/991d7084-cd0a-412b-bffe-0ea176fc5430/Page";`

1. Replace the identifier in the URL with the identifier you saved in Step 2.

## Step 5: Harvest the test

1. Open *Solution Explorer* (shortcut: Ctrl+Alt+L).

1. Expand *TestPackageContent* > *TestHarvesting* and open "TestDiscovery.ps1".

1. Replace the existing content with:

``` ps1

$ErrorActionPreference = 'Stop'

$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Definition
# Base path four levels up, cross-platform
$pathToSolutionRoot = Resolve-Path (Join-Path $scriptRoot '..\..\..\')

$pathToGeneratedTests = Join-Path $PSScriptRoot 'tests.generated'
$pathToGeneratedDependencies = Join-Path $PSScriptRoot 'dependencies.generated'
$pathToXmlAutomationTests = Join-Path $PSScriptRoot 'xmlautomationtests.generated'

# Clean up any previous output
if (Test-Path $pathToGeneratedTests) {
    Remove-Item -Recurse -Force $pathToGeneratedTests
}

if (Test-Path $pathToGeneratedDependencies) {
    Remove-Item -Recurse -Force $pathToGeneratedDependencies
}

if (Test-Path $pathToXmlAutomationTests) {
    Remove-Item -Recurse -Force $pathToXmlAutomationTests
}

New-Item -ItemType Directory -Force -Path $pathToGeneratedTests  | Out-Null
New-Item -ItemType Directory -Force -Path $pathToGeneratedDependencies  | Out-Null
New-Item -ItemType Directory -Force -Path $pathToXmlAutomationTests  | Out-Null

Write-Host "Looking for top-level .cs files in solution folder: $pathToSolutionRoot" -ForegroundColor Cyan

$topLevelCsFiles = Get-ChildItem -Path $pathToSolutionRoot -File -Filter '*.cs'

foreach ($file in $topLevelCsFiles) {
    Copy-Item $file.FullName (Join-Path $pathToGeneratedTests $file.BaseName) -Force
}

Write-Host "Copied $($topLevelCsFiles.Count) top-level .cs file(s)." -ForegroundColor Cyan

# Warning, do not cleanup the collected files here. Next step in the SDK will use these.
Write-Information "`n🎉 Script completed successfully!"
exit 0

```

## Step 6: Write the test execution PowerShell script

1. Open *Solution Explorer* (shortcut: Ctrl+Alt+L).

1. Expand *TestPackageContent* > *TestPackagePipeline* and open "2.TestPackageExecution.ps1".

1. Replace the existing content with:

``` ps1
param (
    [Parameter(Mandatory = $true)]
    [string]$PathToTestPackageContent
)

$ErrorActionPreference = 'Stop'

# Import common code module
Import-Module -Name (Join-Path $PSScriptRoot 'CommonCode.psm1')

$pathToTestHarvesting = Join-Path $PathToTestPackageContent 'TestHarvesting'
$pathToGeneratedTests = Join-Path $pathToTestHarvesting 'tests.generated'
$pathToGeneratedDependencies = Join-Path $pathToTestHarvesting 'dependencies.generated'
$pathToTests = Join-Path $PathToTestPackageContent 'Tests'
$pathToDependencies = Join-Path $PathToTestPackageContent 'Dependencies'
$pathToPlaywrightUiTest = Join-Path $pathToGeneratedTests 'PlaywrightUITesting'

# Track script start time
$scriptStart = Get-Date

try {
    Write-Host "Running Test Package tests..." -ForegroundColor Cyan
    Write-Host "Executing Playwright UI test: $pathToPlaywrightUiTest" -ForegroundColor Cyan

    if (-not (Test-Path $pathToPlaywrightUiTest)) {
        throw "Playwright UI test file not found: $pathToPlaywrightUiTest"
    }

    Write-Host "Checking NuGet sources..." -ForegroundColor Cyan

    $nugetSourcesOutput = & dotnet nuget list source 2>&1
    $nugetSourcesExitCode = $LASTEXITCODE

    if ($nugetSourcesExitCode -ne 0) {
        throw "Failed to list NuGet sources. Output: $($nugetSourcesOutput | Out-String)"
    }

    $nugetSourcesText = ($nugetSourcesOutput | Out-String)

    if ($nugetSourcesText -notmatch '(?im)^\s*\d+\.\s+nuget\.org\s*\[Enabled\]') {
        Write-Host "nuget.org source not found. Adding nuget.org..." -ForegroundColor Yellow

        $addNugetSourceOutput = & dotnet nuget add source 'https://api.nuget.org/v3/index.json' --name 'nuget.org' 2>&1
        $addNugetSourceExitCode = $LASTEXITCODE

        if ($addNugetSourceExitCode -ne 0) {
            throw "Failed to add nuget.org NuGet source. Output: $($addNugetSourceOutput | Out-String)"
        }

        Write-Host "nuget.org source added successfully." -ForegroundColor Green
    }
    else {
        Write-Host "nuget.org source already exists." -ForegroundColor Green
    }

    Write-Host "Starting Playwright test..." -ForegroundColor Cyan

    # Create temporary .cs file
    $tempPlaywrightFile = "$pathToPlaywrightUiTest.cs"
    Copy-Item $pathToPlaywrightUiTest $tempPlaywrightFile -Force

    $playwrightOutput = & dotnet run $tempPlaywrightFile 2>&1
    $playwrightExitCode = $LASTEXITCODE

    Remove-Item $tempPlaywrightFile -Force

    $playwrightMessage = ($playwrightOutput | Out-String).Trim()

    Write-Host "Playwright output:" -ForegroundColor DarkGray
    Write-Host $playwrightMessage

    if ($playwrightExitCode -eq 0) {
        if ([string]::IsNullOrWhiteSpace($playwrightMessage)) { 
            $playwrightMessage = "Playwright UI test passed." 
        }

        Write-Host "Playwright UI test SUCCEEDED." -ForegroundColor Green

        try { Push-TestCaseResult -Outcome 'OK' -Name 'pipeline_PlaywrightUITesting' -Duration ((Get-Date) - $scriptStart) -Message $playwrightMessage -TestAspect Assertion } catch {}
    }
    else {
        if ([string]::IsNullOrWhiteSpace($playwrightMessage)) { 
            $playwrightMessage = "Playwright UI test failed." 
        }

        Write-Host "Playwright UI test FAILED." -ForegroundColor Red

        try { Push-TestCaseResult -Outcome 'Fail' -Name 'pipeline_PlaywrightUITesting' -Duration ((Get-Date) - $scriptStart) -Message $playwrightMessage -TestAspect Assertion } catch {}

        throw "Playwright UI test failed with exit code $playwrightExitCode."
    }

    Write-Host "Test Package execution finished successfully." -ForegroundColor Green

    try { Push-TestCaseResult -Outcome 'OK' -Name 'pipeline_TestPackageExecution' -Duration ((Get-Date) - $scriptStart) -Message 'Test Package execution finished.' -TestAspect Execution } catch {}
}
catch {
    Write-Host "Test Package execution FAILED: $($_.Exception.Message)" -ForegroundColor Red

    try { Push-TestCaseResult -Outcome 'Fail' -Name 'pipeline_TestPackageExecution' -Duration ((Get-Date) - $scriptStart) -Message "Exception during Test Package execution: $($_.Exception.Message)" -TestAspect Execution } catch {}

    exit 1
}
```

## Step 7: Download, install, and verify the QAOps tool

1. Open a Command Prompt, Bash, or PowerShell window.

1. Check if you have `nuget.org` as a known NuGet source:

   ```bash
   dotnet nuget list source
   ```

1. Verify that the output contains `nuget.org [Enabled]`.

   > [!NOTE]
   > The first time you run a `dotnet` command on a computer, you will see a welcome message. The output of your command is displayed below that message.

1. If your sources do not contain `nuget.org`, add it with the following command. Otherwise, skip this step.

   ```bash
   dotnet nuget add source https://api.nuget.org/v3/index.json -n "nuget.org"
   ```

1. Install the [QAOps tool](xref:QAOps_Tool):

   ```bash
   dotnet tool install skyline.dataminer.qaops --global
   ```

1. Verify that the tool is available:

   ```bash
   dataminer-qaops --help
   ```

   The command output will display a description of the tool and the available commands.

> [!NOTE]
> If you see the exception "Unable to load the service index for source ...", one of your configured NuGet sources may be unreachable or may have expired credentials.
>
> To continue this tutorial, you can temporarily remove the failing source and add it again later when needed:
>
> ```bash
> dotnet nuget remove source "NameOfSource"
> ```

## Step 8: Find the unique test and configuration identifiers

For more details about these entities, see [QAOps configuration](xref:QAOps_Configuration) and [QAOps test suite](xref:QAOps_Test_Suite).

1. In the QAOps User app (i.e., the green *QAOps* app), go to the [Configurations](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Configurations) page.

1. Select *Demo Configuration* and *Demo Test Suite*.

1. Copy the configuration ID and save it in a text file.

1. Copy the test suite ID and save it in a text file.

![QAOps Identifier Selections](~/develop/images/QAOps_SelectIdentifiers.png)

## Step 9: Create a token

1. In the QAOps User app, go to the [Tokens](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Tokens) page.

1. In the top-left corner, click *Create Token*.

1. Enter a name for the token.

1. Select the scope that matches the ".execute" scope for your selected configuration.

1. Click *Generate Token*.

1. Wait until the token value is shown.

1. Copy the token value and save it in a text file.

   For production environments, use a key vault solution.

## Step 10: Create and find the test package

1. In Visual Studio, open *Solution Explorer* (shortcut: Ctrl+Alt+L).

1. Right-click the solution and select *Build Solution*.

1. Right-click *Solution 'MyFirstTestPackage'* and select *Open Folder in File Explorer*.

1. In File Explorer, go to the "bin\Debug\net48\DataMinerBuild" folder of your project.

1. Copy the generated [QAOps test package](xref:QAOps_Test_Package) ".dmtest" file path and save it in a text file.

## Step 11: Trigger the test run

1. Open a Command Prompt, Bash, or PowerShell window.

1. Run the following command, after replacing the placeholders as indicated below, making sure to keep the double quotes around the TOKEN and TESTFILEPATH values:

   ```bash
   dataminer-qaops test-run --token "TOKEN" -t TESTSUITE -c CONFIGURATION -tags MYNAME -san saqaopssandbox --test-packages "TESTFILEPATH"
   ```

    - `TOKEN`: The token value you copied earlier. Make sure this value is enclosed in double quotes.

    - `TESTSUITE`: the test suite ID you copied earlier.

    - `CONFIGURATION`: the configuration ID you copied earlier.

    - `MYNAME`: your name, nickname, or another identifier that helps you find your request.

    - `TESTFILEPATH`: the test package filepath you copied earlier. Make sure this value is enclosed in double quotes

    > [!NOTE]
    > For production systems, leave out the `-san` argument. This argument specifies which QAOps system receives the command. In this example, it targets the QAOps sandbox system. The default target is the production QAOps system.

## Step 12: Verify that the request was received

1. In the QAOps User app, go to the [Overview](https://qaops-sandbox.skyline.be/app/8f36715b-d50d-4463-9d2d-c38170929ee4/Overview) page.

1. Locate your tag in the list.

1. Use the filter at the top to find your request more quickly.

1. Track the [test run life cycle](xref:QAOps_Test_Run).

To view and interpret test results, see [Viewing test results](xref:QAOps_Tutorials_User_Tutorials_Basic_How_To_View_Results).

