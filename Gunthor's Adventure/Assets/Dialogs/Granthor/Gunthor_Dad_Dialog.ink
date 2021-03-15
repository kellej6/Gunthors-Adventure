Granthor: Hey Gunthor! Where are you going?

* [Hi!] Gunthor: Hey Dad. I'm going to the lake to swim.
-> Continue
* [Gotta run!] Gunthor: Sorry Dad, no time to talk.  I'm off to the lake to swim.
-> Finish

== Continue ==
Granthor: It's a nice day for a swim.  Do you have time to talk?

* [Yes] Gunthor: Sure Dad.
    Granthor: Great! Do you happen to know what's going on in Praetoria?
    -> Information
* [No] Gunthor: Sorry Dad, I want to go swimming.
    ->Finish
    
    == Information ==
    * [About the forest]
        Granthor: The forest is teeming with ferocious monsters.  You will need a weapon.  Here, take my sword.
        -> Sword
    * [About the desert]
        Granthor: The desert is sweltering hot and there's no water anywhere.  You should stay away from there until you have a water jug.
        -> Information
    * [About the tundra]
        Granthor: The tundra is freezing cold.  You won't last long without warm clothes.  You will need to find a fur coat.
        -> Information
    * [Leave]
        -> Finish
        
        == Sword ==
        * [Take sword]
            Gunthor: Thanks Dad.  I will put this to good use.
        * [Decline]
            Gunthor: I can't take your sword Dad. I'll talk to the blacksmith about one.
        -
        -> Information

== Finish ==
* Exit
-> END