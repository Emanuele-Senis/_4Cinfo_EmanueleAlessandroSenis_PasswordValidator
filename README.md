# simple Password Validation 
separate library written in c# + wpf user interface to show how to use it

The class PasswordValidator validates passwords according to specific rules. It checks for the following conditions:

- Password length should be between the specified minimum and maximum length (default is 8 to 14 characters).
- The password should contain at least one uppercase character.
- The password should contain at least one lowercase character.
- The password should not contain any white spaces.
 The password should contain at least one special character.
 
The class provides a Validate method that checks if the password meets all these conditions.
If the password is valid, the OnPasswordValidated event is triggered, and if it's invalid, the OnPasswordInvalid event is triggered.
The class also maintains a WarningsList to store warning messages when any of the conditions are not met.
