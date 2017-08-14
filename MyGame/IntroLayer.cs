using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace MyGame
{
    public class IntroLayer : CCLayerColor
    {

        // Define a label variable
        CCLabel label;
        CCSprite paddleSprite, ballSprite;
        public IntroLayer() : base(CCColor4B.White)
        {

            // create and initialize a Label
            label = new CCLabel("Hola Consoró", "fonts/MarkerFelt", 90) { Color = CCColor3B.DarkGray };

            label.AnchorPoint = CCPoint.AnchorMiddle;
            // add the label as a child to this Layer
            AddChild(label);

            paddleSprite = new CCSprite("paddle");           
            AddChild(paddleSprite);
            ballSprite = new CCSprite("ball");
            AddChild(ballSprite);
         
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;

            // position the label on the center of the screen
            label.Position = bounds.Center;
            
            paddleSprite.PositionX = 100;
            paddleSprite.PositionY = 100;

            ballSprite.PositionX = 320;
            ballSprite.PositionY = 640;

            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesMoved = OnTouchesEnded;
            touchListener.OnTouchesBegan = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
                paddleSprite.RunActions(new CCMoveTo(.1f, new CCPoint(touches[0].Location.X, paddleSprite.PositionY)));
            }
        }
    }
}

