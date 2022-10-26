# Software_Design_Oppg_03
## Classes
 * [x] make UI Class, and give it a Main method
 * [x] add BlackjackLogic Class
 * [x] built classes out from Blackjack logic:
 -	Deck
 -	Shuffler
 -	Card
 -	Suits (enum)
 -	Values (enum)
 * [x] add UITools Class and fill it out
## Functionality
 * [x] UI class stable
 * [x] BlackjackLogic should give UI class enough to work with
 * [x] UITools should be 100% done
 * [x] classes connected to BlackjackLogic should be 100% done
 * [x] Everything work as intended, with the correct logical steps behind it
 * [ ] Extra features added to program

 ## Comments
 * Works as intended, but there are some ugly looking else if logic going on in UI class
 * BlackjackLogic is one layer under UI, and cannot see UI class. It's done by choice, but it was quite challanging to work around.
	* The whole class is static, and UI have access to variables, lists and methods in BlackjackLogic through them being internal
	* Not sure if connecting the classes this way is a good solution, as it technically gives all classes in assembly access to values as well as operations in BlackjackLogic