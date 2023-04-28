---
uid: UD_APIs_Objects_ApiToken
---
# ApiToken

An `ApiToken` is an object that defines what secret string can be used to access an API.

## Properties

These are the properties of the `ApiToken` object. The table also defines whether the property can be used for filtering using the `ApiTokenExposers`.

|Property       |Type       |Filterable |Description|
|---------------|-----------|-----------|-----------|
|ID             |ApiTokenId |Yes        |The ID of the `ApiToken`.|
|Name           |string     |Yes        |A name that makes the token recognizable. Must be filled in.|
|Secret         |string     |No         |Secret string that will be linked to the token. See the [Secret](#secret) section below.|
|IsDisabled     |bool       |Yes        |You can set this property to true to revoke the token and disable the access. Setting this back to false will re-enable the token.|
|CreatedBy      |string     |Yes        |Name of the user that created the token.|
|CreatedAt      |DateTime   |Yes        |UTC date and time of when the token was created.|
|LastModifiedBy |string     |Yes        |Name of the last user that modified the token.|
|LastModified   |DateTime   |Yes        |UTC date and time of when the token was last modified.|

### Secret

When a user wants to call an API, they need to pass a secret string in the header of their request to authenticate. This secret string should be set on a token that is authorized to use that API.

The `Secret` property on an `ApiToken` is only used to set the secret for the token. This is done when creating the token, or when you want to update the secret. In all other cases, the property should be empty. The secret string should be used by the API users when they want to call an API. It has to adhere to the following requirements:

- It **MUST** be at least 32 characters.
- It **MUST NOT** be used by any other token.
- It **MUST** only contain the following characters:
  - Lowercase letters: `abcdefghijklmnopqrstuvwxyz`
  - Uppercase letters: `ABCDEFGHIJKLMNOPQRSTUVWXYZ`
  - Digits: `0123456789`
  - Special Characters:
    - Underscore: `_`
    - Hyphen: `-`
    - Period: `.`
    - Equals sign: `=`
    - Plus: `+`
    - Forward slash: `/`

If you do not want to define your own format for the secrets, you can just use the built-in secret generator. This will return a 32 character random string that meets all the requirements:

```csharp
var secret = ApiTokenSecretGenerator.GenerateSecret(); 
```

> [!WARNING]
> Once a token is created with a specified secret, **it is not possible to retrieve that secret again**. The value is stored securely in the database with a non-reversible hashing function. Make sure to save it somewhere secure or pass it in a secure way to the API user.

## Requirements

- **Create**:
  - The `Secret` property must contain a secret that adheres to the requirements seen in the section above. ([Secret](#secret))

- **Update:**
  - When updating the `Secret` property (non-empty value), the secret must adhere to the requirements seen in the section above. ([Secret](#secret))

- **Create & Update**
  - The `Name` property must contain a name. (Must not be null or whitespace)

- **Delete**
  - The `ApiToken` must not be in use by an `ApiDefinition`. Meaning, there cannot be an `ApiDefinition` with the ID of the token you are trying to delete in the `AllowedTokens` property. Remove it from these definitions before deleting the token. If you want to quickly block access, you can disable the token instead.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `ApiTokenErrors`. Below is a list of all possible `ErrorReasons`. The `Id` property of the `ApiTokenError` object will always contain the ID of the API token that could not be created, updated or deleted.

|Reason        |Description|
|--------------|-----------|
|InvalidName   |The given name was null or whitespace.|
|InvalidSecret |The given secret did not meet the requirements or is already used by another token.|
|TokenInUse    |The token is in use by one or multiple `ApiDefinitions`. The *ApiDefinitionIdLinks* property will contain a list of IDs of the definitions using the token.|

## Security

There are permission flags that secure the CRUD actions for this type.

- To read or count tokens, the user requires the `PermissionFlags.UserDefinableApiTokenRead` permission flag.
- To create or update tokens, the user requires the `PermissionFlags.UserDefinableApiTokenCreateUpdate` permission flag.
- To delete tokens, the user requires the `PermissionFlags.UserDefinableApiTokenDelete` permission flag.
