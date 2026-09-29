# Docking Bay Bug Log

**Name:** Valery Lot
Peer Review Name: Brandon Langehennig
Peer Review: Great job, code looks fine but, for some reason i was getting this error -----**dotnet watch ❌ Could not find a MSBuild project file in 'C:\Users\brand\OneDrive\Desktop\Repositories\Bug_Hunt_Docking_Bay---LotV'. Specify which project to use with the --project option**.-- could be on my end though, not sure.

Peer Review: Zackary Santos
Review: I tried to run the code but I was given the error: [DockingBayApi (net10.0)] Exited with error code -532462766

Peer Review: Chris Estrada
Review: Opened Terminal in DockingBayApi and checked to verify code was working. All the bugs look fixed in the log.

Log **every** bug as you fix it, one row per bug. There are **15**: 5 syntax, 4 runtime, 6 logic.

- **File**: which file the bug was in, e.g. `Services/ShipService.cs`
- **Line**: the line number where you made the fix
- **Kind**: `Syntax`, `Runtime` or `Logic`
- **What was wrong**: what the code did, and how you noticed (the build error, the exception, or the wrong result in Postman)
- **How I fixed it**: exactly what you changed

## Example (not one of the 15)

| # | File | Line | Kind | What was wrong | How I fixed it |
|---|------|------|------|----------------|----------------|
| 0 | `Services/ExampleService.cs` | 22 | Logic | `GET /api/example/cheapest` returned the **most** expensive item. The list was sorted with `OrderByDescending(i => i.Price)`, so the first item was the priciest. | Changed `OrderByDescending` to `OrderBy`. |

## My bugs

| # | File | Line | Kind | What was wrong | How I fixed it |
|---|------|------|------|----------------|----------------|
| 1 | Ship.cs | 6 | Syntax | Missing a ; | Added a ; |
| 2 | PilotsController.cs | 13 | Syntax | Missing an s, didn't match name of file | Added an s |
| 3 | IPilotService.cs | 9 | Syntax | List had a lowercase L | Made it uppercase L |
| 4 | ShipService.cs | 10 | Syntax | Missing a comma | Added a comma |
| 5 | ShipsController.cs| 32 | Syntax | Missing an end bracket | Added the bracket |
| 6 | Program.cs | 7 | Runtime | AddScoped was added twice for ShipService & IShipService | Changed one of them to the PilotService & IPiloteService |
| 7 | ShipService.cs | 21 | Logic | It was .First | Changed it to .FirstOrDefault |
| 8 | ShipsController.cs | 37 | Logic | Had the inequality operator | Changed it to the equality operator |
| 9 | ShipService.cs | 54 | Logic | Used addition assignment operator | Changed it to an equal sign, to assign the fuel percentage to 100 |
| 10 | ShipsController.cs | 70 | Logic | It just says deleted | I changed it to deleted == false |
| 11 | ShipService.cs | 61 | Runtime | ForEach loop only reads through the item in every collection | Removed it and added FirstOrDefault |
| 12 | ShipsController.cs | 49 | Logic | It was return OK() | I changed it to return CreatedAtAction() |
| 13 | PilotsController.cs| 63 | Logic | It said hours < 0 | I changed it to the comparison operator <= 0 |
| 14 | PilotService.cs | 49 | Logic | Didn't have an if statement for if pilots is null | Added in if pilots == null |
| 15 | PilotService.cs | 39 | Logic | Forgot to increment the new ID | I added _nextId++; |

## Tally

| Kind | Found |
|------|-------|
| Syntax | 5 / 5 |
| Runtime | 2 / 4 |
| Logic | 8 / 6 |

## Reflection

Answer each in 2–3 sentences.

1. Which bug took you the longest to find? What finally led you to it?
- The AddScope took me the longest, but it wasn't that I couldn't find it. I had changed it and kept checking my Postman and nothing was working. I had to restart my window.
2. Pick one **runtime** error. What exception did it throw, and how did the error message help
   you find the line?
- I actually had trouble deciphering what was a runtime error. The only one I really recall coming across was the AddScope and Foreach loop. Unfortunately, I don't recall the exception or error message exactly.
3. `DELETE /api/ships/3` crashed with `Collection was modified`. Why can't a `foreach` loop keep
   going after you remove something from the list it's looping over?
- Because foreach is used to read through every time in a collection. Therefore, it processes it as the collectiong being modified, once it removes something.
4. Every `/api/pilots` request crashed until you fixed one line in `Program.cs`. Explain what
   dependency injection was trying to do and why it failed.
- It was trying to inject the ShipServices twice. I changed it accordingly for the pilots and it worked.
5. Several logic bugs were a single character, like `!=` versus `==`, `<` versus `<=`, or
   `=` versus `+=`. Why doesn't the compiler catch these?
- The compiler doesn't catch them because they are logic errors. Sometimes it may be what YOU intended the code to do, so it can still run.
6. Some bugs hid until you fixed a different one. Give one example.
- There was a moment where I thought I had intiially fixed a bug and it was still incorrect, until I had realized I had to check one of the other files since they all communicate with each other.
