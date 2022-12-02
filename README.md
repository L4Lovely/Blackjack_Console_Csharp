# Blackjack_Console_Csharp

Compiled and built with C# mono on Debian 10

**Features**
	
	100% Self-made
	
	Probably not great code structure!!
	
	>>>ORIGINAL ASCII ART<<<<
	
	...and to top it all off: The worst dialogue you might have read!

Class Descriptions / Overview:

- Box.cs
	Responsible for drawing boxes at fixed x and y dimensions.
	Can take in a single string of text and dynamically (albeit primitive)
	fit it into the box.
	
- Card.cs
	Contains the cards value and definitions.

- Deck.cs
	Can be cut, shuffled, filtered and taken from.
	Contains all the playing cards on object inception.
	
- Dialogue.cs
	Contains the core game loop and dialogue.

- Dealer.cs / Hand.cs
	Containers for the cards of the dealer and the player.
	Can return the overall value of held cards.
	
- Statics.cs
	All primitive box-drawing methods are stored here.
