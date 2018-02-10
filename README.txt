VoicePad (For AVR Assembly)
By Kenneth Vorseth, 2018
-----------------------------------------------------------------------------------------------------------------------
Installation Instructions:
Run from Debug/... executable
-----------------------------------------------------------------------------------------------------------------------
Usage Instructions:
VoicePad uses default microphone to take input and recognize known keywords. It recognizes known keywords using a
machine learning library within windows distributions using .NetFramework 3.5 and greater. [System.Speech]

By speaking in english what you want to accomplish, with light syntactic rules; VoicePad will convert to assembly.
For instance try...

"load register 5 with f" then "check" then "insert" then "clear
"add register 2 with register 24"...
"set bit 2 in register 1 a"...

-----------------------------------------------------------------------------------------------------------------------
Full Documentation:

Recognizable Literals, Individually of Hexadecimal:
'zero, one, two, three, four, five, six, seven, eight, nine, a, b, c, d, e, f'

Syntax Statements:
Load Immediate:
	Load Register [v1] with [v2]				: ldi [v1], [v2]
Move (Copy):
	Load Register [v1] with Register [v2]			: mov [v1], [v2]
Add:
	Add Register [v1] with Register [v2]			: add [v1], [v2]
Subtract:
	Subtract Register [v1] from Register [v2]		: sub [v2], [v1]
Add with Carry:
	Add with Carry Register [v1] with Register [v2] 	: adc [v1], [v2]
Logical AND:
	Logical AND Register [v1] with Register [v2]		: and [v1], [v2]
Logical OR:
	Logical OR Register [v1] to Register [v2]		: or [v1], [v2]
Set Bit in Register:
	Set Bit [v1] in Register [v2]				: sbr [v2], [v1]
Clear Bit in Register:
	Clear Bit [v1] in Register [v2]				: cbr [v2], [v1]
Out to Port:
	Out Register [v1], [v2]					: out [v1]
In to Port:
	In Register [v2], [v1]					: in [v2], [v1]



