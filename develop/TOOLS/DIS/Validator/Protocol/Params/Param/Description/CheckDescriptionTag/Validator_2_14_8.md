---  
uid: Validator_2_14_8  
---

# CheckDescriptionTag

## WrongCasing

### Description

'Param\/Description' values do not follow title casing rules.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.14.8      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Param\/Description values should follow following title case rules:  
\- Should start with a capital  
    \- First and last word  
    \- Important words (verbs, nouns, adjective, adverb, etc)  
\- Should not start with a capital  
    \- Articles (a, an, the)  
    \- Coordinating conjuctions (and, but, for, nor, or, so, yet)  
    \- Preposition with \<4 chars (at, by, to...)
