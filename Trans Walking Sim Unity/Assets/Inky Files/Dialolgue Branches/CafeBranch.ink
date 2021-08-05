// VARIABLES START HERE
VAR hotCoco = false
VAR takeAwayCup = false
// VARIABLES END HERE


Well, hello there! Welcome to Gay-fe! The all inclusive place to hang where you can be truly yourself!
* [Thank you so much!]
How may I help you today?
-> InitialChoices

== InitialChoices ==
* [Yeah, before that, I want to ask about the lights in here real quick.] -> Lighting
* [I'd just like some coffee, thank you!] -> CupOfCoffee
* [Nothing much, just wanted a place to rest if I'm being honest] -> JustChat


// LIGHTING STARTS HERE
== Lighting ==
Oh yes, I finally had the oppurtunity to set the lights to my liking today! Do you like them?
* [Yes, I think they look really pretty!] -> PrettyLights
* [Umm, no. Not really] -> DontLikeTheLights

== PrettyLights ==
Thank you so much! What do you like about them?
* [The colour scheme is just so darn good!] -> BackToIntro
* [It gives a really good vibe!] -> BackToIntro
* [No particular reason, they just look really good!] -> BackToIntro

== BackToIntro ==
Well, thank you very much! It really means a lot to me that you like them!
* [Haha no problem]
So what brings you here today?
-> InitialChoices

== DontLikeTheLights ==
Oh I see. Why might that be?
* [I'm not really a fan of neon kinda lights to be honest, but they aren't ugly or anything] -> IndifferentLights
* [Ehh, just becasuse] -> BadEnd

== IndifferentLights ==
Oh okay. Well, thank you, I guess.
* [Yeah...]
So, anything that brings you here other than the lights?
-> InitialChoices

== BadEnd ==
Well, thank you for your input. I was about to close the cafe. The door's right there! Thanks for coming in!
* [Ohh uhh, yeah. Gnight.] -> END
// LIGHTING ENDS HERE


// COFFEE STARTS HERE
== CupOfCoffee ==
Sure thing! What kind of coffe would you like?
-> CoffeeOptions

== CoffeeOptions ==
* [Hmmm... Ya'all got hot coco?] -> HotCoco
* [Just a regular take-away cup please!] -> TakeAwayCup

== HotCoco ==
~ hotCoco = true
Great choice, and we do have it! Feel free to have a look around, I'll place it on the table and ring you when it's ready!
* [Thank you, how much is it?]
Oh don't worry, it's on the house tonight! It's my last day!
** [Ohh okay. Well, thank you so much, and I hope you have a great night!]
Thank you, your order will be ready in just a short bit!
*** [Cool, thanks!] -> END

== TakeAwayCup ==
~ takeAwayCup = true
Great choice, and we do have it! Feel free to have a look around, I'll place it on the table and ring you when it's ready!
* [Thank you, how much is it?]
Oh don't worry, it's on the house tonight! It's my last day!
** [Ohh okay. Well, thank you so much, and I hope you have a great night!]
Thank you, your order will be ready in just a short bit!
*** [Cool, thanks!] -> END
// COFFEE ENDS HERE


// CHATTING STARTS HERE
== JustChat ==
Ohh okay, you're welcome to do so! So, how's your day going?
* [It went great, thanks! What about you?] -> GreatDay
* [It went ehh. Kind of like everyday I guess lol. What about you?] -> AverageDay
* [It hasn't been that good to be honest...] -> BadDay

== GreatDay ==
I'm really  glad to hear that! My day went quite good as well, thank you for asking!
* [Oh, I'm really glad it went well!]
Haha, thank you! I'm really sorry to cut the conversation short, but I really need to close the cafe now. I've alread been here longer than I should have.
** [Oh, no problem! It was great fun talking to you!]
Pleasure's all mine!  
*** [All right, see ya around!] -> END

== AverageDay ==
Oh I see. Yeah, mine was mundane too. Same old same old, yknow.
* [Haha yeah, I feel you]
Yeah. But I think these mundane days make life exciting.
** [Oh really, how so?]
You see, if every day was filled with rush and stuff, then after a while, the rush itself becomes mundane, and then you're back in a mundane life. Without mundane days, you would never know what exciting days feel like.
*** [Mother Mary whispering wordse of wisdom, I see?]
Let it be.
**** [Haha]
Anyways, I need to shut down the cafe now. But it was great talking to you! I hope you have a great night!
***** [It was a blast! Thanks for teaching me a thing or two, o wise one! Gnight] -> END

== BadDay == 
Oh, I'm really sorry to hear that. Do you want to talk about it?
* [I mean, it's okay. That would mean letting my burdens weigh on you, and that I just can't do] -> NoThankYou
* [Not really. There's nothing to talk about, to be honest.] -> NothingToTalkAbout

== NoThankYou ==
You seem like a wise person. I really hope whatever is bothering you gets figured out soon. You deserve some happiness!
* [Aww, thank you so much! You're too kind!]
Haha, no, not really. I'm just doing what everyone should. 
** [Yeah, but still. You don't have to.]
Yeah, I know. But I should, because this is how I'd want other to treat me as well.
*** [Do unto others as you would have them do unto you.]
Right. Anywhoo, I gotta close the cafe now since it's pretty late, or early I guess.
**** [All right, it was really gund talking to you! Have a great night!]
Thank you, and pleasure's all mine! Good night!
***** [Bye!] -> END

== NothingToTalkAbout ==
Ahh I see. I hope it gets better
* [Thank you so much.]
Hey, no problem!
** [Anyways, I should leave now. Have a great night!]
Thank you, I was just about to close the cafe. Gnight!
*** [Gnight!] -> END
// CHATTINGS ENDS HERE