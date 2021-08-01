Hi there! How are you?
-> FeelingChoices

== FeelingChoices ==
* [Doing good, thanks!] -> FeelingGood
* [Quite ill, actually...] -> FeelingIll

== FeelingGood ==
That's awesome! So, what you up to?
-> FeelingGoodRepsonses

== FeelingIll ==
Ayy, that's rad!
-> FeelingIllResponses


// FEELING GOOD BRANCH STARTS HERE
== FeelingGoodRepsonses == 
* [Nothing much!] -> NothingMuch
* [Just walking around.] -> WalkingAround
* [Talking to you] -> TalkingToYou
* [Bout to leave...] -> Leaving


== NothingMuch ==
Oh that's cool!
* [Yeah... Anyways, gotta go!]
    Okay, bye!
    -> END
    
== WalkingAround ==
Damn, nice!
* [Yeah, bye!]
    Take care!
    -> END
    
== TalkingToYou ==
Ahh so you're that kind of a person...
* [What do you mean?]
    Never mind, bye
    -> RudeEnd
    
== Leaving ==
Oh okay, bye!
-> END

== RudeEnd ==
* [What did I do?] -> WhatDidIDo
* [Ohkay, bye!]
    -> END
    
== WhatDidIDo ==
Doesn't matter.
    * [Oh okay... Bye]
        -> END
// FEELING GOOD BRANCH ENDS HERE


// FEELING ILL BRANCH STARTS HERE
== FeelingIllResponses ==
* [I'm sorry what?] -> SorryWhat
* [Haha, sure is!] -> SureIs

== SorryWhat ==
Nevermind, I don't want to talk to a sick  person.
* [Understandable, have a nice day.]
    -> END
    
== SureIs ==
Yeah...
* [So I'm going to leave before this gets awkward.]
    Good call. See ya around!
    -> AwkwardEnd
    
== AwkwardEnd == 
* [Bye!]
    -> END
* [Take care!]
    -> END
// FEELING ILL BRANCH ENDS HERE