## EmailOptions constructors

```txt
public EmailOptions()
```

Initializes a new instance of the *EmailOptions* class.

Example:

```txt
EmailOptions options = new EmailOptions();
```

```txt
public EmailOptions(string message, string title, string to)
```

Initializes a new instance of the *EmailOptions* class. A message, message title and destination address are specified.

Example:

```txt
EmailOptions options = new EmailOptions("This is a test.", "Test", "test@skyline.be");
```
