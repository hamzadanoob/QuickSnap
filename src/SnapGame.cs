using System;
using SwinGameSDK;
using CardGames.GameLogic;

namespace CardGames
{
    public class SnapGame
    {
        public static void LoadResources()
        {
            Bitmap cards;
            cards = SwinGame.LoadBitmapNamed ("Cards", "Cards.png");
            SwinGame.BitmapSetCellDetails (cards, 82, 110, 13, 5, 53);      // set the cells in the bitmap to match the cards
			SwinGame.LoadFontNamed ("GameFont", "Chunk.otf", 12); 
        }

		/// <summary>
		/// Respond to the user input -- with requests affecting myGame
		/// </summary>
		/// <param name="myGame">The game object to update in response to events.</param>
		private static void HandleUserInput(Snap myGame)
		{
			//Fetch the next batch of UI interaction
			SwinGame.ProcessEvents();

			if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
			{
				myGame.FlipNextCard ();
			}
		}

		/// <summary>
		/// Draws the game to the Window.
		/// </summary>
		/// <param name="myGame">The details of the game -- mostly top card and scores.</param>
private static void DrawGame(Snap myGame) 
{ 
… 
if (top != null) 
{ 
SwinGame.DrawText (…); 
SwinGame.DrawText (…); 
SwinGame.DrawText (…); 
SwinGame.DrawCell (SwinGame.BitmapNamed 
("Cards"), top.CardIndex, 521, 153); 
} 
else 
{ 
} 
SwinGame.DrawText (…); 
SwinGame.DrawCell (SwinGame.BitmapNamed ("Cards"), 
52, 155, 153); 
… 
} 
		/// <summary>
		/// Updates the game -- it should flip the cards itself once started!
		/// </summary>
		/// <param name="myGame">The game to be updated...</param>
		private static void UpdateGame(Snap myGame)
		{
			myGame.Update(); // just ask the game to do this...
		}

        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("Snap!", 860, 500);

			//Load the card images and set their cell details
            LoadResources();
            
			// Create the game!
			Snap myGame = new Snap ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
				HandleUserInput (myGame);
				DrawGame (myGame);
				UpdateGame (myGame);
            }
        }
    }
}