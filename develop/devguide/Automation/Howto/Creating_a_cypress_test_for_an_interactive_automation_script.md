---
uid: Creating_a_cypress_test_for_an_interactive_automation_script
---

# Creating a Cypress test for an interactive Automation script

[Cypress](https://www.cypress.io/) is a powerful end-to-end testing framework designed for the modern web. While it simplifies UI testing, leveraging its full potential requires a solid understanding of its core concepts and best practices. This page covers the essential steps to set up, configure, and test an interactive Automation script using Cypress. By following these steps, you can create reliable, reusable tests to validate new components and UI interactions within a real application environment.

> [!TIP]
> For additional information, explore these resources:
>
> - [Introduction to Cypress](https://docs.cypress.io/guides/core-concepts/introduction-to-cypress)
> - [Cypress API documentation](https://docs.cypress.io/api/table-of-contents/)

## Prerequisites

- [Node.js](https://nodejs.org/) must be installed. Make sure *Node* has been added to your *PATH* to enable terminal commands.

- An Integrated Development Environment (IDE) such as [Visual Studio Code](https://code.visualstudio.com/) must be available.

  In the steps below, Visual Studio Code will be mentioned, but a different IDE could be used instead.

## Project setup and Cypress installation

1. Create a folder for your project (e.g. `C:\Testing`) and open it in Visual Studio Code.

1. Initialize the project and install Cypress:

   1. Open a new terminal in Visual Studio Code and execute the following commands:

      ```cmd
      npm init
      ```

   1. Press Enter to proceed through the setup without specifying values until the initialization is complete.

   1. Use the following command to install Cypress:

      ```cmd
      npm install cypress
      ```

1. To simplify running Cypress, add the following line to the `"scripts"` section of your `package.json` file:

   ```json
   "scripts": {
       "start": "npx cypress open"
   }
   ```

1. To verify the installation, run `npm run start` to launch Cypress and confirm that it opens successfully.

1. If it is the first time you run Cypress, select *E2E Testing* as the testing type when prompted.

## Creating the interactive Automation script

1. Create an Automation script as a Visual Studio solution, as explained under [Automation scripts as a Visual Studio solution](xref:Automation_scripts_as_a_Visual_Studio_solution).

1. Add the NuGet package [Skyline.DataMiner.Utils.InteractiveAutomationScriptToolkit](https://www.nuget.org/packages/Skyline.DataMiner.Utils.InteractiveAutomationScriptToolkit/9.0.3) to your project.

1. Use the following C# code to implement a sample interactive script that displays a "Hello, World!" message with an *OK* button:

   ```csharp
   /// <summary>
   /// Represents a DataMiner Automation script.
   /// </summary>
   public class Script
   {
       /// <summary>
       /// The script entry point.
       /// </summary>
       /// <param name="engine">Link with SLAutomation process.</param>
       public void Run(IEngine engine)
       {
          // DO NOT REMOVE THE COMMENTED OUT CODE BELOW OR THE SCRIPT WONT RUN!
          // Interactive scripts need to be launched differently.
          // This is determined by a simple string search looking for "engine.ShowUI" in the source code.
          // However, due to the NuGet package, this string can no longer be detected.
          // This comment is here as a temporary workaround until it has been fixed.
          //// engine.ShowUI(

          try
          {
             // Controls the event loop and switch between dialogs
             var controller = new InteractiveController(engine);

             // Create an instance of the dialog you wish to show.
             var helloWorldDialog = new HelloWorldDialog(engine);
             
             // Starts the event loop and shows the first dialog.
             controller.ShowDialog(helloWorldDialog);
          }
          catch (ScriptAbortException)
          {
             // Catch normal abort exceptions (engine.ExitFail or engine.ExitSuccess)
             throw; // Comment if it should be treated as a normal exit of the script.
          }
          catch (ScriptForceAbortException)
          {
             // Catch forced abort exceptions, caused via external maintenance messages.
             throw;
          }
          catch (ScriptTimeoutException)
          {
             // Catch timeout exceptions for when a script has been running for too long.
             throw;
          }
          catch (InteractiveUserDetachedException)
          {
             // Catch a user detaching from the interactive script by closing the window.
             // Only applicable for interactive scripts, can be removed for non-interactive scripts.
             throw;
          }
          catch (Exception e)
          {
             engine.ExitFail($"Run|Something went wrong: {e}");
          }
       }
   }

   public class HelloWorldDialog : Dialog
   {
      public HelloWorldDialog(IEngine engine) : base(engine)
      {
          // Create a label widget
          var label = new Label("Hello, World!") { Style = TextStyle.Title };
          
          // Define the debug tag to be used in the cypress test
          label.DebugTag = "label";
          
          // Add it to the dialog grid at position 0,0
          AddWidget(label, 0, 0);
          
          // Create a button widget
          var button = new Button("OK");
          
          // Define the debug tag to be used in the cypress test
          button.DebugTag = "button";
          
          // Add it to the dialog just below the label
          AddWidget(button, 1, 0);
          
          // Add an action to be performed whenever the button is clicked
          button.Pressed += (sender, args) => engine.ExitSuccess("Done");
      }
    }
    ```

## Setting up the web environment

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Add a button to the dashboard and configure it to trigger the created interactive Automation script when clicked.

   For more information, see [Button](xref:DashboardButton).

Below is an example of what the dashboard might look like when the button has been added:

![Interactive scripts dashboard](~/develop/images/InteractiveScriptsDashboard.png)

## Creating the Cypress test

1. **Set Up the Test File**  
    In the `cypress/e2e` folder, create a test file with a `.cy.js` extension, such as `HelloWorldDialog.cy.js`.

2. **Implement the Cypress test**  
    Implement the following Cypress test to log in, navigate to the dashboard, and interact with the automation script.
    Be sure to fill in the relevant values for the variables (dmaIp, username, password, dashboardName, scriptName) at the beginning of the file:

    ```javascript
    describe('Test Interactive Automation Script', () => {
        // Define the necessary variables and replace with your specific details
        const dmaIp = ''; // Replace with the DataMiner IP (e.g., 'localhost')
        const username = ''; // Replace with the user username
        const password = ''; // Replace with the user password
        const dashboardName = ''; // Replace with the name of the dashboard page
        const scriptName = ''; // Replace with the name of the script

        // Before running the tests, visit the dashboards page
        before(() => cy.visit(`http://${dmaIp}/dashboard`));

        it('should log in and execute the Interactive Automation Script', () => {
            // Check if the login component exists
            cy.get('dma-login').should('exist');

            // Enter login credentials
            cy.get('[data-cy="login.username"]').type(username);
            cy.get('[data-cy="login.password"]').type(password);

            // Click the login button
            cy.contains('dma-button', 'Log on').click();

            // Verify successful login
            cy.get('dma-login').should('not.exist');
            cy.get('dma-app').should('exist');

            // Navigate to the specified dashboard
            cy.get('dma-folder-list-item').contains(dashboardName).click();

            // Start the IAS script by clicking the associated button
            cy.contains('dma-button', scriptName).click();

            // Validate that the popup appears with the correct title
            cy.get('[data-cy="popup"]').contains('Dialog').should('be.visible');

            // Get the component with the debug tag 'label' and check if the component has the correct text
            cy.get('[data-cy="label"]').should('have.text', 'Hello, World!');

            // Get the component with the debug tag 'button' and click the OK button
            cy.get('[data-cy="button"]').should('have.text', 'OK').click();

            // Validate that the success message is displayed
            cy.get('[data-cy="popup"]').contains('Succeeded').should('be.visible');
        });
    });
    ```

> [!NOTE]
> Ensure all variable values are updated with the correct information (dmaIp, username, password, etc.) before running the test. This allows the script to interact properly with your specific application environment.

## Running the Cypress test

1. **Launch Cypress**  
    In the terminal, run:

    ```cmd
    npm run start
    ```

2. **Select and Run the Test**  
    Choose the test file (`HelloWorldDialog.cy.ts`). Cypress will execute the test, displaying results in real time: green indicates success, and any errors are logged in detail for debugging.
