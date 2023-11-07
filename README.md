# CardBasedRPS

## Inspiration

I watched kakegurui. A unique card-based version of rock paper scissors was played in the first episode. I figured it would be straightforward enough to try and create this with a screen reader.

## What it does

Shuffles 12 cards with even distribution of rock, paper and scissors cards into a central deck. 3 cards are then dealt to the player and the enemy AI. Every card and action that can be performed has screen reader audio associated with it.

## How we built it

The Flax game engine, C# and a lot of tears.

## Challenges we ran into

Flax is a still developing and recent tool. We noticed that when developing. The biggest thing was how Flax worked with Git. Our scenes weren't initially sharing some updates across Git. We fixed this by going to our Content folder in file explorer and dragging it into the VS Solution Explorer. After that, changes were synced (though we had some "ghost edits". times when the code would think there was a change when none actually happened). 

Flax did not have any text-to-speech or screen reading tools in the asset store (especially since it doesn't yet have one) so we just had to make a whole system ourselves. 

For my friend Ryan, we had difficulties setting up his environment to run visual studio code (so much so that when we had to eventually switch to VS, it probably led to various configurations issues for him. The game executable wouldn't run for him. Tooltips wouldn't appear for him sometimes. Files that weren't being touched would be 'modified' from an external environment and destroyed if he reloaded.

Another few pain points were :
- Flax doesn't allow you to check for information in a game object's parent (There's no form of a GetParent method and all Find methods start from the current actor and recursively runs down through its children). 
- The documentation could be extremely lacking at times. We had to rely on our understanding of other game engines (primely unity) and experience to solve a lot of issues. We also got bugs literally no other Flax user had encountered before so we had to try to figure out everything.

One huge saving grace was how Flax doesn't hide anything from us. It's all very digestible in how its stored and I can see everything.

## Accomplishments that we're proud of

We made a screen reader system ourselves in a brand new game engine without having an asset store to support us. That's kinda insane. We also had RIDICULOUS moment. We just didn't ever stop.

## What we learned

- How it's like developing something with Flax (honestly the biggest learning experience). 
- How to set up our own screen reading system.

## What's next for Card based Rock Paper Scissors
- Not much for this game, but I'm now interested in seeing how Godot works now for 3D games and consider between Flax and Unity in the future.
