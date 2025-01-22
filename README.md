# Old phone pad message converter

The solution is contained within the IronSoftwareChallenge project.

Tests can be found in the `Test` project.

## Challenge specification
Here is an old phone keypad with alphabetical letters, a backspace key, and a sendbutton.

Each button has a number to identify it and pressing a button multiple times willcycle 
through the letters on it allowing each button to represent more than one letter.

For example, pressing 2 once will return ‘A’ but pressing twice in succession will return ‘B’.

You must pause for a second in order to type two characters from the same
button after each other: “222 2 22” -> “CAB”.

Prompt:
Please design and document a class of method that will turn any input to OldPhonePad
into the correct output.

Assume that a send “#” will always be included at the end of every input.
