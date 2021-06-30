VAR showChocolate = false

Hello there! How are you doing on this fine day?
-> InitialChoices

== InitialChoices ==
* [I'm doing good, thank you!] -> DoingGood
* [I'm doing okay I guess] -> DoingOkay

== DoingGood ==
Awesome! So, do you like chocolate? 
-> ChocolateOptions

== DoingOkay ==
Oh, sorry to hear that. Do you think a chocolate could help you out?
-> ChocolateOptions

== ChocolateOptions ==
* [Yes, I love chocolate!] -> LoveChocolate
* [I mean if you've got one, sure] -> YouGotOne
* [Naah, not really] -> NotReally

== LoveChocolate ==
Amazing! Go look at the table behind you!
~ showChocolate = true
* [Oh okay, will do. Thanks!] -> END

== YouGotOne ==
Yes, I do have one! Go look at the table that's behind you! 
~ showChocolate = true
* [Boy you do be doing magic and stuff?] -> END

== NotReally ==
Oh I see. Well, good day then!
* [All rigth, catch you later!] -> END