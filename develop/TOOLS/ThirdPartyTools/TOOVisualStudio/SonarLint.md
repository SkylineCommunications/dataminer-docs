---
uid: SonarLint
---

# SonarLint

This Visual Studio plugin analyzes C# source code to detect issues and aid in creating efficient, maintainable and less error-prone code while you type. It provides additional information and examples for each warning.

## Installation

Install SonarLint using the Visual Studio extension (.vsix): <https://www.sonarlint.org/visualstudio/>

![](~/develop/images/sonarlint_download.png)<br>
*SonarLint extension*

## Usage

In order to run SonarLint, open a QAction and make sure Visual Studio is running in Debug Mode.

![](~/develop/images/sonarlint_vsdebug.png)<br>
*Visual Studio Debug Mode*

The *Error List* window will display the SonarLint rules that have been violated (if any).

![](~/develop/images/sonarlint_errorlist.png)<br>
*Visual Studio Error List Window*

Code analysis is also performed during development and issues will be highlighted.

![](~/develop/images/sonarlint_codemarking.png)<br>
*Visual Studio issue indication*

In order to disable analysis, set Visual Studio to *Release Mode*. This can be convenient for development of larger quick actions.

![](~/develop/images/sonarlint_releasemode.png)<br>
*Visual Studio Release Mode*

## About cyclomatic complexity

SonarLint will check the test/debug complexity of methods. It does this by calculating the so-called cyclomatic complexity. This metric is based on the number of linearly independent paths that can be followed in code. In practice, this usually means the number of selection statements (if, else, switch) and the number of cases in a switch statement. If this number is too big for a specific method, SonarLint will show a warning to indicate this. A high cyclomatic complexity means you need a lot of test cases in order to obtain 100% code coverage. So when the cyclomatic complexity is too high, it means testing and debugging becomes more difficult.

This warning can be ignored if you are dealing with a small switch statement, for example. In that case, readability is considered more important than the high value of cyclomatic complexity.

Some of the easiest ways to refactor this:

- Convert a very large switch statement into a Dictionary\<int,Action> (or another delegate) and perform a single call to get the delegate and then invoke it.

  ![](~/develop/images/sonarlint_switch_dictionary.png)<br>
  *Switch statement refactor*

- Split up nested selection statements into several new methods. This can easily be done using the "Extract Method" functionality within Visual Studio IntelliSense.

## About cognitive complexity

SonarLint will check the readability and maintainability of methods. It does this by calculating the so-called cognitive complexity. This value is calculated based on the number of iteration statements, switch statements, if-else structures and nested structures, resulting in a valuable metric.

Cognitive complexity should never be ignored. It indicates that you created a method that is doing too much and is hard to understand. More information can be found here: <https://blog.sonarsource.com/cognitive-complexity-because-testability-understandability>

The primary way to solve this is to split the logic into smaller and more maintainable parts by extracting these into methods.

In the example below, you can see a method that parses a response from a device and fills in tables. The cognitive complexity is too high because this single method contains too much logic. One way to refactor this is to create a method that handles every table separately.

![](~/develop/images/sonarlint_cognitive_complexity.png)<br>
*SonarLint cognitive complexity warning*

You will notice this creates a “fission” of loops, where instead of a single large loop doing all the logic, you will have multiple loops performing smaller pieces of logic within different methods. This has a detrimental effect on processing speed, but it is generally so small that it can be ignored except for extreme cases.

The benefits outweigh the disadvantages: smaller readable methods, better stacktraces and debugging, easier to test and maintain. If the efficiency does become a problem (during testing), then further refactoring is always possible to create a way to keep a single loop.

![](~/develop/images/sonarlint_cognitive_complexityrefactor.png)<br>
*Cognitive complexity refactor*

## Missing Else clauses

One of the code smells SonarLint reports is when an if-else if construct is used that does not end with an else clause.

It requires the final else clause to either:

- Throw an exception or log an error to indicate the code went into a code path it should never go into.

- Contain a comment indicating the empty else clause was done deliberately and is expected behavior.
