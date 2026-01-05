---
uid: CICD_Quality_Gate_Github
keywords: CICD, SonarQube, SonarCloud, Quality Gate, Quality
---

# CI/CD quality gate GitHub

With a CI/CD pipeline, deployment can be automatically blocked if it does not meet certain quality standards. These standards are configured per organization and are sometimes tweaked for specific departments or outputs. They supplement manual efforts in quality control, such as code reviews and manual testing procedures.

Within Skyline Communications' GitHub organization, we strive to reuse the same quality gate for all our coding artifacts (connectors, Automation scripts, libraries, tooling, etc.).

## Valid compilation

If you provide a Visual Studio solution, we will first attempt to compile it on the GitHub runner agents. This often catches assembly mistakes, for example when a developer references code from a third-party assembly but forgets to add that assembly to their repository. If such mistakes were not caught, things might compile okay on the machine of the original developer but would not compile on other machines.

To accomplish this, we run:

```bash
dotnet build "./NameOfSolution.sln" -p:DefineConstants="DCFv1%3BDBInfo%3BALARM_SQUASHING"
```

Any compilation failure will trigger the quality gate and block a release.

## Automated tests

We will attempt to run any tests defined next to the source code. These could be written in MSTest, NUnit, or other frameworks. As long as they are recognized by .NET as tests, we will run them.

For GitHub, we currently only run unit tests. For integration tests, we are looking into using DaaS instances to run such code against.

You can define an integration test by specifying the test category for the test: **IntegrationTest**. These are filtered out when unit tests are run in the pipeline.

To accomplish this, we run:

```bash
dotnet test "./NameOfSolution.sln" --filter TestCategory!=IntegrationTest --logger "trx;logfilename=unitTestResults.trx" --collect "XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=cobertura,opencover
```

Any test failure will trigger the quality gate and block a release.

## Static code analysis

As part of our clean code and quality standards, Skyline has been using SonarQube and SonarCloud for many years. This service performs code analysis and looks for common mistakes or bad practices. It helps keep our code below a certain complexity and catches bugs before manual validation procedures might catch them.

SonarCloud does not offer an export and import functionality, so below are the settings used for artifacts created on GitHub. You can use these either as a starting point or just for your information.

### SonarCloud quality gate

The following are the conditions of the quality gate we use. This was balanced to handle the large amount of legacy code while also considering completely new code we write. More focus is given to ensuring new code stays as clean as possible while also trying to avoid impacting the ability to perform quick fixes within SLA times.

#### Fail conditions on new code

| Metric            | Operator       | Value  |
|-------------------|----------------|--------|
| Duplicated Blocks | is greater than| 30     |
| Blocker Issues    | is greater than| 0      |
| Bugs              | is greater than| 5      |
| Critical Issues   | is greater than| 2      |
| Major Issues      | is greater than| 10     |
| Minor Issues      | is greater than| 10     |

#### Fail conditions on overall code

| Metric            | Operator       | Value  |
|-------------------|----------------|--------|
| Blocker Issues    | is greater than| 0      |
| Bugs              | is greater than| 20     |
| Critical Issues   | is greater than| 10     |
| Duplicated Blocks | is greater than| 500    |
| Major Issues      | is greater than| 300    |
| Minor Issues      | is greater than| 300    |

### SonarCloud rule tweaks

Some specific rules by SonarCloud have been disabled or tweaked to account for legacy code and specifics to connector and Automation script developments. We have also disabled some rules after finding their ROI to be lacking for our developments.

Currently, our quality profile for C# has 79 rules disabled and 1 overridden rule:

- **Last evaluation:** 9 December 2022
- **Note:** This Quality Profile needs re-evaluation by a team of our senior members.

#### Overridden rules

- **Control flow statements "if", "switch", "for", "foreach", "while", "do" and "try" should not be nested too deeply**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Default Value:** 3
  - **Updated Value:** 5
  - **Reason:** Investment to adjust in legacy code is too high for provided simplification.

#### Disabled rules

- **"Contains" should be used instead of "Any" for simple equality checks**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Simplifying checks in legacy code.

- **"DebuggerDisplayAttribute" strings should reference existing members**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** Activate
  - **Reason:** Legacy code does not always adhere to this practice.

- **"Find" method should be used instead of the "FirstOrDefault" extension**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Minimal performance impact in existing code.

- **"First" and "Last" properties of "LinkedList" should be used instead of the "First()" and "Last()" extension methods**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Compatibility with older code bases.

- **"for" loop increment clauses should modify the loops' counters**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** confusing, Activate
  - **Reason:** Legacy code structure is dependent on the current implementation.

- **"for" loop stop conditions should be invariant**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** pitfall, Activate
  - **Reason:** Existing code uses variant conditions for specific purposes.

- **"Min/Max" properties of "Set" types should be used instead of the "Enumerable" extension methods**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Performance gains are negligible for current usage.

- **"private" methods called only by inner classes should be moved to those classes**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** confusing, Activate
  - **Reason:** Current design simplifies navigation and readability.

- **"StartsWith" and "EndsWith" overloads that take a "char" should be used instead of the ones that take a "string"**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Consistency with existing string operations.

- **"string.Create" should be used instead of "FormattableString"**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Compatibility with legacy formatting practices.

- **"StringBuilder" data should be used**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Existing code uses alternative efficient string manipulations.

- **"Thread.Sleep" should not be used in tests**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** bad-practice, Activate
  - **Reason:** Specific tests require delay to simulate real-world scenarios.

- **"Trace.Write" and "Trace.WriteLine" should not be used**
  - **Category:** Reliability
  - **Type:** Code Smell
  - **Tags:** logging, Activate
  - **Reason:** Existing logging framework relies on these methods.

- **"Trace.WriteLineIf" should not be used with "TraceSwitch" levels**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** clumsy, Activate
  - **Reason:** Legacy logging practices are deeply integrated.

- **[JSInvokable] attribute should only be used on public methods**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** blazor, Activate
  - **Reason:** Flexibility needed for internal method invocations.

- **A Route attribute should be added to the controller when a route template is specified at the action level**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Existing routing conventions are complex and functional.

- **Actions that return a value should be annotated with ProducesResponseTypeAttribute containing the return type**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Current documentation practices are sufficient.

- **Always set the "DateTimeKind" when creating new "DateTime" instances**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** localisation, Activate
  - **Reason:** DateTime handling is managed globally elsewhere in the codebase.

- **An abstract class should have both abstract and concrete methods**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** convention, Activate
  - **Reason:** Abstract classes serve specific design purposes in legacy code.

- **API Controllers should derive from ControllerBase instead of Controller**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Controller class usage aligns with current architecture.

- **Arrays should not be created for params parameters**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** clumsy, Activate
  - **Reason:** Existing method signatures depend on array creation.

- **ASP.NET controller actions should not have a route template starting with "/"**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Route templates are designed to fit specific URL patterns.

- **Assertions should be complete**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** tests, Activate
  - **Reason:** Test coverage is verified through other means.

- **Avoid using "DateTime.Now" for benchmarking or timing operations**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** Activate
  - **Reason:** Existing timing methods are accurate for current needs.

- **Awaitable method should be used**
  - **Category:** Reliability
  - **Type:** Code Smell
  - **Tags:** async-await, Activate
  - **Reason:** Asynchronous patterns are managed differently in legacy code.

- **Backslash should be avoided in route templates**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** asp.net, Activate
  - **Reason:** Route definitions are compatible with backslashes for specific scenarios.

- **Blazor query parameter type should be supported**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** blazor, Activate
  - **Reason:** Flexibility in parameter types is required for certain applications.

- **Blocks should be synchronized on read-only fields**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** cwe, Activate
  - **Reason:** Synchronization methods are handled appropriately elsewhere.

- **Calculations should not overflow**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** overflow, Activate
  - **Reason:** Overflow checks are managed by higher-level logic.

- **Classes named like "Exception" should extend "Exception" or a subclass**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** convention, Activate
  - **Reason:** Naming conventions are specifically designed for clarity.

- **Classes should not be empty**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** clumsy, Activate
  - **Reason:** Empty classes are placeholders for future development.

- **Collection-specific "Exists" method should be used instead of the "Any" extension**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Consistent usage of "Any" across the codebase.

- **Comments should not be empty**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** Activate
  - **Reason:** Empty comments are placeholders for pending documentation.

- **Component parameter type should match the route parameter type constraint**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** blazor, Activate
  - **Reason:** Flexibility in parameter types is required for certain components.

- **Connection strings should not be vulnerable to injections attacks**
  - **Category:** Security
  - **Type:** Vulnerability
  - **Tags:** cwe, Activate
  - **Reason:** Connection string security is managed by external configurations.

- **Controllers should not have mixed responsibilities**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Controller responsibilities are clearly defined despite mixed functionality.

- **Date and time should not be used as a type for primary keys**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** Activate
  - **Reason:** DateTime keys are integral to current database design.

- **Deprecated code should be removed**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** obsolete, Activate
  - **Reason:** Deprecated code is maintained for compatibility reasons.

- **Exceptions should be either logged or rethrown but not both**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** error-handling, Activate
  - **Reason:** Dual handling of exceptions is required for specific error tracking.

- **Floating point numbers should not be tested for equality**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** Activate
  - **Reason:** Existing equality checks are precise enough for current needs.

- **Generic logger injection should match enclosing type**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** confusing, Activate
  - **Reason:** Logger injection is standardized differently.

- **Generic parameters not constrained to reference types should not be compared to "null"**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** Activate
  - **Reason:** Null checks are handled elsewhere in the code.

- **JWT secret keys should not be disclosed**
  - **Category:** Security
  - **Type:** Vulnerability
  - **Tags:** cwe, Activate
  - **Reason:** JWT keys are secured through external means.

- **Literal boolean values should not be used in assertions**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** tests, Activate
  - **Reason:** Literal booleans are used for specific test scenarios.

- **Log message template placeholders should be in the right order**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** logging, Activate
  - **Reason:** Placeholder order is consistent with legacy logging.

- **Log message template should be syntactically correct**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** logging, Activate
  - **Reason:** Syntax is checked through manual review processes.

- **Logger field or property name should comply with a naming convention**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** logging, Activate
  - **Reason:** Current naming conventions fit project requirements.

- **Logging arguments should be passed to the correct parameter**
  - **Category:** Reliability
  - **Type:** Code Smell
  - **Tags:** logging, Activate
  - **Reason:** Logging parameter usage is verified through other means.

- **Logging in a catch clause should pass the caught exception as a parameter**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** error-handling, Activate
  - **Reason:** Exception details are logged separately.

- **Logging templates should be constant**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** logging, Activate
  - **Reason:** Dynamic logging templates are necessary for current requirements.

- **Loops should be simplified with "LINQ" expressions**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** Activate
  - **Reason:** Explicit loops are preferred for readability in legacy code.

- **Memory allocations should not be vulnerable to Denial of Service attacks**
  - **Category:** Security
  - **Type:** Vulnerability
  - **Tags:** cwe, Activate
  - **Reason:** Memory allocation is managed to prevent such vulnerabilities.

- **Message template placeholders should be unique**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** logging, Activate
  - **Reason:** Placeholder uniqueness is verified through other means.

- **ModelState.IsValid should be called in controller actions**
  - **Category:** Maintainability, Reliability, Security
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Validation is performed through custom mechanisms.

- **Not specifying a timeout for regular expressions is security-sensitive**
  - **Category:** Security Hotspot
  - **Tags:** cwe, Activate
  - **Reason:** Regex usage is controlled and safe in the current context.

- **NullReferenceException should not be caught**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** cwe, Activate
  - **Reason:** NullReferenceException handling is crucial for error tracking.

- **Passwords should not be stored in plaintext or with a fast hashing algorithm**
  - **Category:** Security
  - **Type:** Vulnerability
  - **Tags:** cwe, Activate
  - **Reason:** Password storage is secured through external mechanisms.

- **Prefer indexing instead of "Enumerable" methods on types implementing "IList"**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Enumerable methods provide clearer code in the current context.

- **Reflection should not be vulnerable to injection attacks**
  - **Category:** Security
  - **Type:** Vulnerability
  - **Tags:** cwe, Activate
  - **Reason:** Reflection security is managed by existing safeguards.

- **Regular expressions should be syntactically valid**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** regex, Activate
  - **Reason:** Regex syntax is manually verified.

- **REST API actions should be annotated with an HTTP verb attribute**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Verb annotations are managed by routing conventions.

- **Sections of code should not be commented out**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** unused, Activate
  - **Reason:** Commented code is reserved for debugging purposes.

- **String literals should not be duplicated**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** design, Activate
  - **Reason:** Duplicated strings are used for specific automation tasks.

- **The code block contains too many logging calls**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** logging, Activate
  - **Reason:** Extensive logging is necessary for debugging Automation scripts.

- **The collection should be filtered before sorting by using "Where" before "OrderBy"**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Sorting without pre-filtering is efficient for current datasets.

- **The collection-specific "TrueForAll" method should be used instead of the "All" extension**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** The "All" extension is consistently used across the codebase.

- **The lambda parameter should be used instead of capturing arguments in "ConcurrentDictionary" methods**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** performance, Activate
  - **Reason:** Current argument capturing practices are effective.

- **Types should be defined in named namespaces**
  - **Category:** Reliability
  - **Type:** Bug
  - **Tags:** Activate
  - **Reason:** Namespace definitions follow a specific project structure.

- **URIs should not be hardcoded**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** Activate
  - **Reason:** Hardcoded URIs are temporary for rapid development.

- **Use "TimeZoneInfo.FindSystemTimeZoneById" without converting the timezones with "TimezoneConverter"**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** Activate
  - **Reason:** TimeZoneConverter provides necessary functionality.

- **Use a format provider when parsing date and time**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** pitfall, Activate
  - **Reason:** Parsing is handled with consistent formats elsewhere.

- **Use model binding instead of reading raw request data**
  - **Category:** Maintainability, Security, Reliability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Raw request data reading is essential for specific operations.

- **Use the "UnixEpoch" field instead of creating "DateTime" instances that point to the beginning of the Unix epoch**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** Activate
  - **Reason:** DateTime instances are created for specific historical reasons.

- **Using unsafe code blocks is security-sensitive**
  - **Category:** Security Hotspot
  - **Tags:** Activate
  - **Reason:** Unsafe code is required for certain low-level operations.

- **Utility classes should not have public constructors**
  - **Category:** Maintainability
  - **Type:** Code Smell
  - **Tags:** design, Activate
  - **Reason:** Utility classes with public constructors are used for flexibility.

- **Value type property used as input in a controller action should be nullable, required or annotated with the JsonRequiredAttribute to avoid under-posting**
  - **Category:** Reliability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Value types are handled through custom validation.

- **XML operations should not be vulnerable to injection attacks**
  - **Category:** Security
  - **Type:** Vulnerability
  - **Tags:** cwe, Activate
  - **Reason:** XML security is managed through other means.

- **XML signatures should be validated securely**
  - **Category:** Security
  - **Type:** Vulnerability
  - **Tags:** Activate
  - **Reason:** Secure validation is ensured through external libraries.

- **You should pool HTTP connections with HttpClientFactory**
  - **Category:** Reliability
  - **Type:** Code Smell
  - **Tags:** asp.net, Activate
  - **Reason:** Connection pooling is managed by custom implementations.