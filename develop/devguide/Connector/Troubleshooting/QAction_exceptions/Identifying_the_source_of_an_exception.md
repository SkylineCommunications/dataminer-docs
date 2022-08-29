---
uid: Identifying_the_source_of_an_exception
---

# Identifying the source of an exception

Unfortunately, when an exception is thrown, the logging does not give more info on what the object was that caused the exception. The only thing that you get is the exception type and the stack trace.

In case of a null reference exception, it would have been great if it also mentioned something like *tried to access folder.EndsWith() method but string folder is null*. Or in case of an *IndexOutOfRangeException*, it would be great if it mentioned *members[1] is being accessed, but the size of members is 1*. Likewise, in case of a *System.FormatException*, something like *string test that contains value "test" cannot be converted into a number* would be very handy. And all that preferably with the line number where you can find that code line.

However, this information is unfortunately not present in the logging, which makes it very difficult to debug a null reference exception when there are a lot of objects, or an *IndexOutOfRangeException* when there are a lot of arrays being accessed through *[]*. It is even harder if the exception only happens from time to time instead of being thrown whenever the QAction is executed.

## DIS Inject

Ideally, you can use DIS inject on a test DMA where the issue can be reproduced. If the exceptions are not caught, DIS will show where the problem resides when attached to the QAction.

## Logging

In the logging of the exception, you will find the stack trace, which will help you track down which method was being called. If you can find this method in the code, you can take a look to try and understand what is going wrong. If possible, you can create a test element and change the code to add extra log lines. You can for example divide the method into 3 parts and add a line "part 1", "part 2", and "part 3". If you then see in the logging that "part 1" and "part 2" are present, you know that the problem is between "part 2" and "part 3" in the code. You can then add more log lines between part 2 and part 3 to further narrow down the problem.

## Coding

To make it easier to understand your code and pinpoint the cause of an exception, write the code in more logical method parts. This way, unit tests can also be written to test the behavior of a method. This does not mean that you should write a method for each line of code, as adding items to the stack also comes with a performance cost and a stack size is also limited. Try to validate items before accessing them and write the proper logging why something fails and the code execution cannot continue. This is better than receiving a *NullReferenceException* without further information.

## Finding the root problem

It could be that an exception is thrown and written out in logging like this:

```csharp
System.IndexOutOfRangeException: Index was outside the bounds of the array.
    at QAction.Process()
    at QAction.Run(SLProtocol protocol)
```

The stack trace shows that the problem resides in the `Process()` method and you need to look for an *IndexOutOfRangeException*.

Below is the provided code of that method.

```csharp
private List<string> Process()
{
    string[] persons = new string[3];
    persons[0] = "John.Doe";
    persons[1] = "Jane.Doe";
    persons[2] = "Leyla.Doe";
    List<string> mails = new List<string>();
    MailServer server = new MailServer();
    for (int i = 0; i < persons.Length; i++)
    {
        string mailAddress = persons[i] + server.Address;
        mails.Add(mailAddress);
    }
    return mails;
}
```

It can be difficult to spot a mistake in this code – and that is only to be expected, since it actually does not contain a mistake. The problem causing the exception lies in a different part of the code.

A `MailServer` class object is used in the `Process` method. The code of that class looks like this:

```csharp
public class MailServer
{
    private readonly string[] domains;
    public MailServer()
    {
        domains = new string[1];
        domains[0] = "@testdomain.com";
    }
    public string Address
    {
        get
        {
            return RetrieveCustomDomain();
        }
    }
    private string RetrieveCustomDomain()
    {
        return domains[1];
    }
}
```

When the `Process()` method executes `string mailAddress = persons[i] + server.Address;`, it is accessing the *Address* property and the getter of that property executes the `RetrieveCustomDomain()` method. In that method, `domains[1]` is accessed, while domains only contains one member. That is the actual location of the problem. The logged stack trace shows the wrong information in case the exception comes from a property.

However, if you change the code of the getter of the Address to this:

```csharp
try
{
    return RetrieveCustomDomain();
}
catch(Exception ex)
{
    throw ex;
}
```

Then the logging of the exception will result in this:

```csharp
System.IndexOutOfRangeException: Index was outside the bounds of the array.
    at MailServer.get_Address()
    at QAction.Process()
    at QAction.Run(SLProtocol protocol)
```

This will be more useful, as you will have more information to go on and you will not keep looking at the `ProcessMethod`. However, it is not ideal yet, as there is no indication that the actual problem is in the `RetrieveCustomDomain` method.

Also, note that adding the "throw ex" will generate two SonarQube warnings:

- S2372: Exceptions should not be thrown from property getters. Property getters should be simple operations that are always safe to call. If exceptions need to be thrown, it’s best to convert the property to a method.

- S3445: Exceptions should not be explicitly rethrown. The reason is because the stack trace is reset and this makes debugging a lot harder, which is ironic here as the original exception was even harder to debug.

### Inline

A problem that could also explain why the stack trace did not show the `get_<PropertyName>` method or the child methods that are called is something known as *Inline*. When the code gets compiled, the compiler will optimize your code and could for example decide that the content of the method will be copied into the actual code that calls the method. This way, the parent method will never call the method but instead immediately execute the code lines of that method. Whenever such lines generate an exception, the stack trace will show the parent method as the location of the issue instead of the child method, as that child method simply does not exist in the compiled code.

Getting a property is actually calling a `get_<PropertyName>` method in the background, which can be optimized away just like any other method. Adding the try-catch in the previous example prevented the optimization from the compiler, which let it show the get method call in the stack trace of the exception.

### Summary

- Like the SonarQube warning mentions, property getters should never cause exceptions. If exceptions are possible, consider catching them and gracefully returning an exception value, or making a method instead of a getter. A property getter is also considered something simple, meaning that the developer calling the property assumes that this can be called thousands of times in a loop without performance impact. If more complexity is behind it, a method is a better choice, as it flags to the developer that it might be better to call the result once, store it in a variable before the loop starts, and then use that variable inside the loop.

- Write unit tests for your class. These could show issues when accessing properties or calling methods.

- When investigating issues, keep in mind that methods could be optimized away by the compiler, so you might be staring at the original code method thinking that the problem should be there while the compiler inlined some code of child methods that you are not aware of. Do not forget that accessing properties is actually calling a method in the background, which might very well be optimized away. A stack trace could help to identify where a problem resides, but it is never 100% sure that the problem is actually inside that method. It is better to deal with problems inside the code, indicate problems in there, and avoid the more generic exceptions like a *NullReferenceException*, as it is very difficult to pinpoint the exact problem when the code mostly consists of reference type objects.