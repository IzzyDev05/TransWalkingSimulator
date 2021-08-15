VAR hotCoco = false


Hi, how are you doing today? Welcome to the Gay-fe, the all inclusive place to chill at where you can be yourself!
* [I'm okay, thanks! How about you?]
I'm doing great as well, thank you! How may I help you today?
-> InitialChoices

== InitialChoices ==
* [I'd just like some coffee, thank you!] -> CupOfCoffee
// I have removed the lighting branch and place it in a txt file next to the inky file since it's not being used
* [Nothing much, just wanted a place to rest if I'm being honest] -> JustChat


// COFFEE STARTS HERE
== CupOfCoffee ==
Sure thing! What kind of coffe would you like? 
-> CoffeeOptions

== CoffeeOptions ==
* [Do you have some hot coco?] -> HotCoco
* [I'd just like a cup of tea please, if you have it?] -> Tea

== HotCoco ==
~ hotCoco = true
Sure thing! We do have some left. It'll take a few seconds for your order to be ready. Feel free to have a look around till then!
* [Thank you, how much is it?]
Oh don't worry, it's on the house tonight! It's my last day!
** [Ohh okay. Well, thank you so much, and I hope you have a great night!] -> END

== Tea ==
Too bad, we haven't coded that in yet. You'll have to go back and choose hot coco!
* [Coded it in? What do you mean?]
The people who I spoke to have understood it! So, what would you like to have?
-> CoffeeOptions
// COFFEE ENDS HERE


// CHATTING STARTS HERE
== JustChat ==
Ohh okay, you're welcome to do so! So, how's your day going?
* [It went great, thanks! What about you?] -> GreatDay
* [It was like every other day, pretty mundane. How was yours?] -> AverageDay
* [Well, it wasn't that good if I'm being quite honest. But it's whatever.] -> BadDay

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
See, if every day was filled with rush and stuff, then after a while, the rush itself becomes mundane, and then you're back in a mundane life. Without mundane days, you would never know what exciting days feel like.
*** [Mother Mary speaking words of wisdom, I see?]
Let it be.
**** [Haha]
Anyways, I need to shut down the cafe now. But it was great talking to you! I hope you have a great night!
***** [It was a blast! Thanks for teaching me a thing or two, o wise one! Gnight] -> END

== BadDay == 
Oh, I'm really sorry to hear that. Do you want to talk about it?
* [Not really. There's nothing to talk about, to be honest.] -> NothingToTalkAbout
* [I mean, it's okay. That would mean letting my burdens weigh on you, and that I just can't do] -> NoThankYou

== NothingToTalkAbout ==
Ahh I see. I hope it gets better
* [Thank you so much.]
Hey, no problem!
** [Anyways, I should leave now. It's getting quite late, isn't it?]
Oh yeah, it really is. I was just about to close the cafe as well. Gnight!
*** [Gnight!] -> END

== NoThankYou ==
You seem like a wise person. I really hope whatever is bothering you gets figured out soon. You deserve some happiness!
* [Aww, thank you so much! You're too kind!]
Haha, no, not really. I'm just doing what everyone should. 
** [Yeah, but still. You don't have to.]
Yeah, I know. But I should, because this is how I'd want others to treat me as well.
*** [Do unto others as you would have them do unto you.]
Right. Anywhoo, I gotta close the cafe now since it's pretty late, or early I guess.
**** [All right, it was really fun talking to you! Have a great night!]
Thank you, and pleasure's all mine! Good night!
***** [Bye!] -> END
// CHATTINGS ENDS HERE