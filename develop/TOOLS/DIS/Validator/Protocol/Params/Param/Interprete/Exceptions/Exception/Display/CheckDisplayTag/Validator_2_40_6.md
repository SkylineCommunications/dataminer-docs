---  
uid: Validator_2_40_6  
---

# CheckDisplayTag

## WrongCasing\_Sub

### Description

Current value '{currentValue}'. Expected value '{expectedValue}'. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.40.6      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Exception\/Display values should follow following title case rules:  
\- Should start with a capital  
    \- First and last word  
    \- Important words (verbs, nouns, adjective, adverb, etc)  
\- Should not start with a capital  
    \- Articles (a, an, the)  
    \- Coordinating conjuctions (and, but, for, nor, or, so, yet)  
    \- Preposition with \<4 chars (at, by, to...)
