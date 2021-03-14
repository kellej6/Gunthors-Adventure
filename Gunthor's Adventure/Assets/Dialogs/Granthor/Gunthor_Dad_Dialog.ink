Hey Gunthor! Where are you going?

* [Hi!] Hey Dad. I'm going to the lake to swim.
-> Continue
* [Gotta run!] Sorry Dad, no time to talk.  I'm off to the lake to swim.
-> Finish

== Continue ==
It's a nice day for a swim.  Do you have time to talk?

* [Yes] Sure Dad.
    Great! Do you happen to know what's going on in Praetoria?
    -> Information
* [No] Sorry Dad, I want to go swimming.
    ->Finish
    
    == Information ==
    * [About the forest]
        The forest is teeming with ferocious monsters.  You will need a weapon.  Here, take my sword.
        -> Sword
    * [About the desert]
        The desert is sweltering hot and there's no water anywhere.  You should stay away from there until you have a water jug.
        -> Information
    * [About the tundra]
        The tundra is freezing cold.  You won't last long without warm clothes.  You will need to find a fur coat.
        -> Information
    * [Leave]
        -> Finish
        
        == Sword ==
        * [Take sword]
            Thanks Dad.  I will put this to good use.
        * [Decline]
            I can't take your sword Dad. I'll talk to the blacksmith about one.
        -
        -> Information

== Finish ==
-> END