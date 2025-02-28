# Chest System

## Overview

This is a Unity game project that simulates dynamic Chest System like Clash Royale Game. 
The goal for the player is to navigate through the menus to generate random chests, unlocking them either by using gems or a timer, then collect the coins & gems for rewards. The player can also undo their action of unlocking chest with gems if they have not collected the rewards yet. The project uses design patterns like Service Locator, MVC, Object Pooling, State Machine & Command Pattern.

---

## Features

1. Currencies
    - Gems: Primary currency used to unlock chests instantly.
    - Coins: Secondary currency drops as chest rewards.

3. Chest Types
    Four types: Common, Rare, Epic, and Legendary, each with dynamic rewards and unlock timers:
    - Common: 15-minutes timer, rewards 100-200 coins and 10-20 gems.
    - Rare: 30-minutse timer, rewards 300-500 coins and 20-40 gems.
    - Epic: 60-minutes timer, rewards 600-800 coins and 45-60 gems.
    - Legendary: 180-minutes timer, rewards 1000-1200 coins and 80-100 gems.

4. Chest Slots & Queue Management
    - Dynamic list with a minimum of 4 slots; can generate random chests.
    - Chests are added to the Vacant Slots if available else popup shown for all slots full.
    - Chests are added in queue if they are unlocking or queued for unlocking. They remain in queue until they are unlocked.
    - After collecting rewards, chest slot becomes empty. Empty Slots are added back in the list at the end.

5. Chest States
    - Locked: Timer hasn't started yet. Gems can be used to unlock it.
    - Unlocking: Timer is active. Gems can be used to unlock. Gem Cost changes based on the active timer.
    - Queued: Queued in unlocking Queue.
    - Unlocked: Timer finished or Gems used to unlock. Rewards are ready to be collected.
    - Collected: The player has clicked on the unlocked chest to collect the rewards.

6. Unlocking Rules
   - If Chest is Locked, it can be wither unlocked with Timer or directly unlocked with Gems.
   - Only one chest can be unlocking at a time.
   - While the chest is unlocking, it can still be unlocked using gems.
   - Gem cost to unlock a chest is calculated based on timer remaining, rounded up.
   - If one chest is currently unlocking, other chests can be added to queue for unlocking.
   - Queued Chests have to wait for their turn for timer to start. They cannot be unlocked with gems.
   - If Gems were used to unlock a chest & the rewards have not been collected then that action can be undone.

7. Pop-ups
   - Action Pop-up to choose the primary action on the chest : Unlock with Timer or Unlock with Gems
   - Acknowledgement Pop-up for Chest Collection
   - Confirmation Pop-up to confirm actions like Start Unlocking with Timer, Unlock With Gems, Queuing, Undo Gem Spent
   - Notification Pop-up to notify player about Insufficient Gem for Action, Slot Not Available to generate more chests, if a chest is already Queued
     
---

## Implementation Details

### Design Patterns

**MVC Architecture**:

Used for managing the Chest, Chest Slots, and RefundGem/UndoGemUnlock, ensuring a modular and scalable code with clear separation between game logic (Model), user interface (View), and user interaction (Controller).

**Service Locator**:

Implemented GameService as a Singleton instance to create & provide services for Chest, ChestSlot, QueueUnlocking, Currency, CommandInvoker, RefundGem/UndoGemUnlock, UI, Sound as well as for dependency injection and communication between scripts.

**State Machine Pattern**:

Used State Machine to manage the chest states (Locked, Unlocking, Queued, Unlocked, Collected).

**Object Pooling**:

Implemented Object pools for Chests & Chest Undo Options to resuse objects.

**Command Pattern**:

Used to encapsulate the Unlocking With Gem action as a command in a command object in registry for Undo Option.

### Scriptable Objects

Used for chest & audio data to allow designers to make adjustments through inspectors.


---

## How to Play

1. Tap "Generate Chest" button to add a random chest to an empty slot.
2. Tap a locked chest and select "Start Timer" in the pop-up.
3. Tap a locked or unlocking chest and select "Unlock with Gems" in the pop-up.
4. Queue a locked chest for unlocking if another chest is already unlocking.
5. Unlocking with Gems removes the amount spent from the player's gem balance.
6. Tap an unlocked chest to collect rewards.
7. A pop-up will notify if there are insufficient gems to unlock.
8. A pop-up will notify if all slots are full.
9. If Gems were used and rewards aren't collected, the action can be undone.
10. Tap "Undo Option" button to see unlocked chests with uncollected rewards.
11. Tap "Undo" Button on a chest Option to refund gems and lock the chest again.
  
---

## Architecture Block Diagram

![image](https://github.com/user-attachments/assets/3bf05746-6f22-4bbc-bf32-5b4c83421430)

---

## Playable build

https://outscal.com/iamdeep75/game/play-chest-system-v10-game

---

## Gameplay Video

https://youtu.be/5rW9gTa50fg

