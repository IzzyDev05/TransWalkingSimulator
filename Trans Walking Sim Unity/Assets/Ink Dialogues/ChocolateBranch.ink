VAR showCoffeeCup = false

Hello there! How are you doing on this fine day?
-> InitialChoices

== InitialChoices ==
* [I'm doing good, thank you!] -> DoingGood
* [I'm doing okay I guess] -> DoingOkay

== DoingGood ==
Awesome! So, do you like coffee? 
-> CoffeeOptions

== DoingOkay ==
Oh, sorry to hear that. Do you think a coffee could help you out?
-> CoffeeOptions

== CoffeeOptions ==
* [Yes, I love coffee!] -> LoveCoffee
* [I mean if you've got one, sure] -> YouGotOne
* [Naah, not really] -> NotReally

== LoveCoffee ==
Amazing! Go look at the table behind you!
~ showCoffeeCup = true
* [Oh okay, will do. Thanks!] -> END

== YouGotOne ==
Yes, I do have one! Go look at the table that's behind you! 
~ showCoffeeCup = true
* [Boy you be doing magic and stuff?] -> END

== NotReally ==
Oh I see. Well, good day then!
* [All rigth, catch you later!] -> END