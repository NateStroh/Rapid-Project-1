﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rapid1.Sprites
{
    class Player : Sprite
    {
        private bool hasJumped;
        private int health = 1;
        public const int REDSPEED = 2000;
        public const int YELLOWSPEED = 1000;
        public const int GREENSPEED = 500;

        int speedCap = 2000;

        public Player(Dictionary<string, Animation> animationDict, Vector2 pos) : base(animationDict, pos) {
            
        }

        public int getHealth(){
            return health;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites) {
            //get user input
            pollKeys();
            if (animations != null) {
                animationManager.animationPosition = Position;
                updateAnimations();
                animationManager.Update(gameTime);
            }
            //Gravity acting on the player
            SpeedY += 40;

            //this is just test code to change player color instead of the different textures
            if (SpeedY > REDSPEED)
            {
                color = Color.Red;
            }
            else if (SpeedY > YELLOWSPEED)
            {
                color = Color.Yellow;
            }
            else if (SpeedY > GREENSPEED)
            {
                color = Color.Green;
            }
            else {
                color = Color.White;
            }

            foreach (var sprite in sprites) 
            {
                if (sprite != this && sprite.isActive) 
                {
                    //this should stop the player if they hit a paddle
                    if (sprite.GetType() == typeof(Paddle))
                    {
                        if (((Paddle)sprite).paddleType == 1)
                        {
                            if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                            {
                                this.SpeedY = -SpeedY - 400;
                            }
                        }
                        else if (((Paddle)sprite).paddleType == 2)
                        {
                            if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                            {
                                this.SpeedY = -SpeedY - 600;
                            }
                        }
                        else if (((Paddle)sprite).paddleType == 3)
                        {
                            if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                            {
                                this.SpeedY = -SpeedY * 1.5f;
                            }
                        }
                    }
                    else if (sprite.GetType() == typeof(Enemy) && sprite.isActive) {
                        collideWithEnemy((Enemy) sprite, sprites);
                    }
                }
            }

            foreach (var sprite in sprites)
            {
                if (sprite != this && sprite.isActive)
                {
                    
                    if ((this.SpeedX > 0 && this.IsTouchingLeft(sprite)) || (this.SpeedX < 0 & this.IsTouchingRight(sprite)))
                    {
                        this.SpeedX = 0;
                    }
                    if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                    {
                        this.SpeedY = 0;
                        hasJumped = false;
                    }
                    
                }

            }

            
            //Speed Cap
            if(SpeedX > speedCap)
            {
                SpeedX = MathHelper.Lerp(SpeedX, speedCap, .02f);
            }
            else if(SpeedX < -speedCap)
            {
                SpeedX = MathHelper.Lerp(SpeedX, -speedCap, .02f);
            }

            if (SpeedY > speedCap)
            {
                SpeedY = MathHelper.Lerp(SpeedY, speedCap, .02f);
            }
            else if (SpeedY < -speedCap)
            {
                SpeedY = MathHelper.Lerp(SpeedY, -speedCap, .02f);
            }

            //adjust player positions
            Velocity = new Vector2(SpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds, SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds);
            Position += Velocity;
            
        }

        private void pollKeys() {

            //move character - WASD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                SpeedX = MathHelper.Lerp(SpeedX, -2700, .1f);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                SpeedX = MathHelper.Lerp(SpeedX, 2700, .1f);

            }
            else
            {
                SpeedX = MathHelper.Lerp(SpeedX, 0, .9f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W)&&!hasJumped)
            {
                hasJumped = true;
                Position.Y -= 5;
                SpeedY = -1400;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                SpeedY += 20;
            }
        }

        private void updateAnimations() {
            if (SpeedY > REDSPEED || SpeedX > REDSPEED)
            {
                playerAnimations("Red");
            }
            else if (SpeedY > YELLOWSPEED || SpeedX > YELLOWSPEED)
            {
                playerAnimations("Yellow");
            }
            else if (SpeedY > GREENSPEED || SpeedX > GREENSPEED)
            {
                playerAnimations("Green");
            }
            else {
                playerAnimations("Grey");
            }
        }

        private void playerAnimations(string state) {
            switch (state){
                case "Red":
                    if (SpeedY > 0) {
                        animationManager.playAnimation(animations["RedFalling"]);
                    }
                    else if (SpeedY < 0) {
                        animationManager.playAnimation(animations["RedUp"]);
                    }
                    else if (SpeedX > 0)
                    {
                        animationManager.playAnimation(animations["RedWalkRight"]);
                    }
                    /*else if (SpeedX < 0)
                    {
                        animationManager.playAnimation(animations["RedWalkLeft"]);
                    }*/
                    else
                    {
                        animationManager.playAnimation(animations["RedIdle"]);
                    }
                    return;

                case "Yellow":
                    if (SpeedY > 0)
                    {
                        animationManager.playAnimation(animations["YellowFalling"]);
                    }
                    else if (SpeedY < 0)
                    {
                        animationManager.playAnimation(animations["YellowUp"]);
                    }
                    else if (SpeedX > 0)
                    {
                        animationManager.playAnimation(animations["YellowWalkRight"]);
                    }
                    /*else if (SpeedX < 0)
                    {
                        animationManager.playAnimation(animations["YellowWalkLeft"]);
                    }*/
                    else
                    {
                        animationManager.playAnimation(animations["YellowIdle"]);
                    }
                    return;

                case "Green":
                    if (SpeedY > 0)
                    {
                        animationManager.playAnimation(animations["GreenFalling"]);
                    }
                    else if (SpeedY < 0)
                    {
                        animationManager.playAnimation(animations["GreenUp"]);
                    }
                    else if (SpeedX > 0)
                    {
                        animationManager.playAnimation(animations["GreenWalkRight"]);
                    }
                    /*else if (SpeedX < 0)
                    {
                        animationManager.playAnimation(animations["GreenWalkLeft"]);
                    }*/
                    else
                    {
                        animationManager.playAnimation(animations["GreenIdle"]);
                    }
                    return;

                case "Grey":
                    if (SpeedY > 0)
                    {
                        animationManager.playAnimation(animations["GreyFalling"]);
                    }
                    else if (SpeedY < 0)
                    {
                        animationManager.playAnimation(animations["GreyUp"]);
                    }
                    else if (SpeedX > 0)
                    {
                        animationManager.playAnimation(animations["GreyWalkRight"]);
                    }
                    /*else if (SpeedX < 0)
                    {
                        animationManager.playAnimation(animations["GreyWalkLeft"]);
                    }*/
                    else
                    {
                        animationManager.playAnimation(animations["GreyIdle"]);
                    }
                    return;
            }
        }

        private void collideWithEnemy(Enemy enemy, List<Sprite> spriteList) {
            //if its a green enemy
            if (enemy.enemyType == 1)
            {
                //if it's colliding
                if ((this.SpeedY > 0 && this.IsTouchingTop(enemy)) || (this.SpeedY < 0 & this.IsTouchingBottom(enemy)))
                {
                    //if player has enough speed
                    if (SpeedY > GREENSPEED)
                    {
                        this.SpeedY = -SpeedY - 200;
                        enemy.isActive = false;
                    }
                    else {
                        health--;
                    }
                }
            }
            else if (enemy.enemyType == 2)
            {
                //if it's colliding
                if ((this.SpeedY > 0 && this.IsTouchingTop(enemy)) || (this.SpeedY < 0 & this.IsTouchingBottom(enemy)))
                {
                    //if player has enough speed
                    if (SpeedY > YELLOWSPEED)
                    {
                        this.SpeedY = -SpeedY - 400;
                        enemy.isActive = false;
                    }
                    else
                    {
                        health--;
                    }
                }
            }
            if (enemy.enemyType == 3)
            {
                //if it's colliding
                if ((this.SpeedY > 0 && this.IsTouchingTop(enemy)) || (this.SpeedY < 0 & this.IsTouchingBottom(enemy)))
                {
                    //if player has enough speed
                    if (SpeedY > REDSPEED)
                    {
                        this.SpeedY = -SpeedY *1.5f;
                        enemy.isActive = false;
                    }
                    else
                    {
                        health--;
                    }
                }
            }
            if (enemy.enemyType == 0 && this.isColliding(enemy))
            {
                health = 0;
            }
        }

        public void Respawn()
        {
            Position = new Vector2(100, 100);
            health = 1;
        }
    }
}
