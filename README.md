# CraftingGame
 The game allow to make new items from others

## Ver

Unity editor ver 2022.3.7f1

Assets:

- AI Navigation 1.1.5
- Cinemachine 2.9.7
- TextMeshPro 3.0.6

## GamePlay
In this game, the player moves towards the location of the mouse click. 

![Main](https://github.com/user-attachments/assets/2ef8d603-53d1-49de-9288-ac982c2f149f)

Items can be collected and are stored in the Inventory, which can be accessed by clicking on the "Inventory" tab. To drop an item, simply click on it in the inventory. To craft new items, open the "Crafting" tab. Scroll through the available options—items can only be crafted if you have the required resources in your inventory. Good luck with your crafting adventures!

![UI](https://github.com/user-attachments/assets/cdeeb0ae-beea-4da2-b877-94bc486ef0f4)

## Classes Structure

![Scheme](https://github.com/user-attachments/assets/1ff7947a-4620-4108-bc38-1c79806a4fe7)

## Editor windows

You can use additional editor windows to create or edit files (ScriptableObjects) with item configurations and set conditions for crafting new items.

![Menu](https://github.com/user-attachments/assets/359f91f1-536a-4a5d-abf9-be152f65f269)

![ItemConfiguration](https://github.com/user-attachments/assets/cca3754e-47fb-4f57-b40f-8586386b5e55)

![CraftConfiguration](https://github.com/user-attachments/assets/ec0dfd42-e20e-4e53-8ff7-9ce4e99217b3)

## Effects

There is ability to add effects in Editor Hierarchy:
- Events when the player picks up or drop an item (Player->Interaction : Drop.cs, PickUp.cs)
- Crafting success or failed events (Controlles -> CraftingController : CraftingController.cs)
