using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Background : StoryboardObjectGenerator
    {

        OsbSprite itg;
        public override void Generate()
        {

            double beatduration = 60000 / 190;

            OsbSprite back = GetLayer("").CreateSprite("sb/white.png");
            back.Color(0, new Color4(0, 0, 0, 0));
            back.ScaleVec(0, 854, 480);
            back.Fade(0, 1f);
            back.Fade(122210, 0);

            OsbSprite itg2 = GetLayer("").CreateSprite("sb/itg2.jpg");
            itg2.Rotate(0, 0);
            itg2.Fade(0, 1);
            itg2.ScaleVec(0, new Vector2(0.5f, 0.5f));
            itg2.Fade(122210, 0);

            itg = GetLayer("").CreateSprite("sb/itg2.jpg");
            itg.Fade(0, 1);
            itg.ScaleVec(0, new Vector2(0.5f, 0.5f));
            itg.Fade(122210, 0);

            kick(3789, 4263, .2);
            kick(6315, 6789, -.2);
            kick(8842, 9315, .2);
            kick(11368, 11842, -.2);
            kick(12629, 13105, .2);

            //itg.ScaleVec(OsbEasing.InOutCirc, 13578, 13894, new Vector2(0.5f, 0.5f), new Vector2(-0.5f, 0.5f));
            // itg.ScaleVec(OsbEasing.InCirc, 13578, 13736, new Vector2(0.4f, 0.4f), new Vector2(0.25f, 0.25f));
            itg.ScaleVec(OsbEasing.OutCirc, 13578, 13894, new Vector2(0.4f, 0.4f), new Vector2(0.55f, 0.55f));

            double currentTime = 13894;
            float scaleChange = 0.02f;
            while (currentTime < 18947 - beatduration)
            {
                // itg.Rotate(OsbEasing.InOutSine, currentTime, currentTime + beatduration, lastrot, rotate);
                itg.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + beatduration / 2, itg.ScaleAt(currentTime), (Vector2)itg.ScaleAt(currentTime) + new Vector2(scaleChange, scaleChange));
                itg.ScaleVec(OsbEasing.InCirc, currentTime + beatduration / 2, currentTime + beatduration, (Vector2)itg.ScaleAt(currentTime) + new Vector2(scaleChange, scaleChange), itg.ScaleAt(currentTime));
                currentTime += beatduration;

            }

            itg.Rotate(OsbEasing.OutCirc, 18947, 23684, 0, Math.PI * 4);
            itg.ScaleVec(OsbEasing.OutCirc, currentTime, 21473, itg.ScaleAt(currentTime), new Vector2(0f, 0f));
            itg.ScaleVec(OsbEasing.InSine, 21473, 23684, new Vector2(0f, 0f), new Vector2(0.55f, 0.55f));

            flipHorz(27789);
            flipVert(28263);
            flipHorz(32842);
            flipVert(33315);
            flipHorz(37894);
            flipVert(38368);

            scale(24000, 24473);
            scale(26526, 27000);
            scale(29052, 29526);
            scale(31578, 32052);
            scale(34105, 34578);
            scale(36710, 37105);
            scale(39157, 39631);

            itg.Rotate(OsbEasing.OutElasticQuarter, 42947, 44210, 0, Math.PI);

            itg.ScaleVec(OsbEasing.None, 44210, 54315, itg.ScaleAt(44210), (Vector2)itg.ScaleAt(44210) + new Vector2(.35f, 0.4f));
            itg2.ScaleVec(OsbEasing.None, 44210, 54315, itg2.ScaleAt(44210), (Vector2)itg.ScaleAt(44210) + new Vector2(.35f, 0.4f));

            itg.ScaleVec(OsbEasing.OutCirc, 54315, 55263, itg.ScaleAt(54315), new Vector2(0.00f, 0.0f));
            itg2.ScaleVec(OsbEasing.OutCirc, 54315, 55263, itg2.ScaleAt(54315), new Vector2(0.00f, 0.0f));

            itg.MoveX(54315, 55263, 320, 280);
            itg2.MoveX(54315, 55263, 320, 280);

            itg.MoveX(63000, 320);
            itg2.MoveX(63000, 320);

            itg.ScaleVec(OsbEasing.OutSine, 64421, 64736, new Vector2(0.65f, 0.65f), new Vector2(854f / 1708f, 854f / 1708f));

            itg.Rotate(OsbEasing.OutElasticQuarter, 63157, 64421, Math.PI, Math.PI * 2);
            itg2.Rotate(OsbEasing.OutElasticQuarter, 63157, 64421, Math.PI, Math.PI * 2);

            itg.ScaleVec(OsbEasing.OutElasticQuarter, 63157, 64421, new Vector2(0.00f, 0.0f), new Vector2(0.5f, 0.5f));
            itg2.ScaleVec(OsbEasing.OutElasticQuarter, 63157, 64421, new Vector2(0.00f, 0.0f), new Vector2(0.5f, 0.5f));

            itg.ScaleVec(OsbEasing.OutCirc, currentTime, 21473, itg.ScaleAt(currentTime), new Vector2(0f, 0f));
            itg.ScaleVec(OsbEasing.InSine, 21473, 23684, new Vector2(0f, 0f), new Vector2(0.55f, 0.55f));

            kick(98526, 99000, .2);
            kick(99473, 99947, -.2);
            kick(101052, 101526, -.2);
            kick(102000, 102473, .2);
            kick(103578, 104052, .2);
            kick(104526, 105000, -.2);
            kick(106105, 106578, -.2);
            kick(107052, 107526, .2);

            currentTime = 108631;
            scaleChange = 0.03f;
            while (currentTime < 113763 - beatduration)
            {
                // itg.Rotate(OsbEasing.InOutSine, currentTime, currentTime + beatduration, lastrot, rotate);
                itg.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + beatduration / 2, itg.ScaleAt(currentTime), (Vector2)itg.ScaleAt(currentTime) + new Vector2(scaleChange, scaleChange));
                itg.ScaleVec(OsbEasing.InCirc, currentTime + beatduration / 2, currentTime + beatduration, (Vector2)itg.ScaleAt(currentTime) + new Vector2(scaleChange, scaleChange), itg.ScaleAt(currentTime));
                currentTime += beatduration;

            }

            currentTime = 114000;
            var currentScale = (Vector2)itg.ScaleAt(currentTime);

            while (currentTime < 116210 - beatduration)
            {
                var newSCale = currentScale + new Vector2(0.015f, 0.015f);
                itg.ScaleVec(OsbEasing.OutElasticHalf, currentTime, currentTime + beatduration, currentScale, newSCale);
                itg2.ScaleVec(OsbEasing.OutElasticHalf, currentTime, currentTime + beatduration, currentScale, newSCale);

                currentTime += beatduration;
                currentScale = itg.ScaleAt(currentTime);
            }

            flipHorz(116210);
            flipHorz(116842);

            itg.ScaleVec(OsbEasing.OutCirc, 117789, 120000, itg.ScaleAt(117789), new Vector2(0));
            itg2.ScaleVec(OsbEasing.OutCirc, 117789, 120000, itg.ScaleAt(117789), new Vector2(0));

            itg.Rotate(OsbEasing.OutSine, 117789, 120000, 0, 1);
            itg2.Rotate(OsbEasing.OutSine, 117789, 120000, 0, 1);

            OsbSprite one = GetLayer("").CreateSprite("sb/one.jpg", OsbOrigin.CentreLeft, new Vector2(-107, 240));
            OsbSprite two = GetLayer("").CreateSprite("sb/two.jpg", OsbOrigin.CentreLeft, new Vector2(-107, 240));
            OsbSprite third = GetLayer("").CreateSprite("sb/three.jpg", OsbOrigin.CentreLeft, new Vector2(-107, 240));
            OsbSprite four = GetLayer("").CreateSprite("sb/four.jpg", OsbOrigin.CentreLeft, new Vector2(-107, 240));


            one.MoveX(64894, 64894, -107, -107 + 854f / 4f);
            two.MoveX(64894, 64894, -107 + 854f / 4f, -107 + 854f / 4f * 2);
            third.MoveX(64894, 64894, -107 + 854f / 4f * 2, -107 + 854f / 4f * 3);
            four.MoveX(64894, 64894, -107 + 854f / 4f * 3, -107);

            one.MoveX(65131, 65131, -107 + 854f / 4f, -107);
            two.MoveX(65131, 65131, -107 + 854f / 4f * 2, -107 + 854f / 4f);
            third.MoveX(65131, 65131, -107 + 854f / 4f * 3, -107 + 854f / 4f * 2);
            four.MoveX(65131, 65131, -107, -107 + 854f / 4f * 3);

            float scaleV = 854f / 1708f;

            one.ScaleVec(64815, new Vector2(scaleV, scaleV));
            two.ScaleVec(64815, new Vector2(scaleV, scaleV));
            third.ScaleVec(64815, new Vector2(scaleV, scaleV));
            four.ScaleVec(64815, new Vector2(scaleV, scaleV));

            one.ScaleVec(OsbEasing.OutCirc, 66947, 67263, new Vector2(scaleV, scaleV), new Vector2(scaleV, -scaleV));
            two.ScaleVec(OsbEasing.OutCirc, 66947, 67263, new Vector2(scaleV, scaleV), new Vector2(scaleV, -scaleV));
            third.ScaleVec(OsbEasing.OutCirc, 66947, 67263, new Vector2(scaleV, scaleV), new Vector2(scaleV, -scaleV));
            four.ScaleVec(OsbEasing.OutCirc, 66947, 67263, new Vector2(scaleV, scaleV), new Vector2(scaleV, -scaleV));

            one.MoveX(67421, 67421, -107, -107 + 854f / 4f * 3);
            two.MoveX(67421, 67421, -107 + 854f / 4f, -107);
            third.MoveX(67421, 67421, -107 + 854f / 4f * 2, -107 + 854f / 4f);
            four.MoveX(67421, 67421, -107 + 854f / 4f * 3, -107 + 854f / 4f * 2);

            one.MoveX(67736, 67736, -107 + 854f / 4f * 3, -107);
            two.MoveX(67736, 67736, -107, -107 + 854f / 4f);
            third.MoveX(67736, 67736, -107 + 854f / 4f, -107 + 854f / 4f * 2);
            four.MoveX(67736, 67736, -107 + 854f / 4f * 2, -107 + 854f / 4f * 3);

            one.Fade(64815, 1);
            one.Fade(68210, 0);
            two.Fade(64815, 1);
            two.Fade(68210, 0);
            third.Fade(64815, 1);
            third.Fade(68210, 0);
            four.Fade(64815, 1);
            four.Fade(68210, 0);

            flipVert(67944);

            itg.ScaleVec(OsbEasing.None, 69473, 74526, itg.ScaleAt(69473), new Vector2(itg.ScaleAt(69473).X + 0.15, itg.ScaleAt(69473).Y - 0.15));
            itg.Rotate(OsbEasing.None, 69473, 74526, 0, .4);
            itg.Rotate(OsbEasing.OutElasticQuarter, 74526, 75473, .4, Math.PI * 2);
            itg.ScaleVec(OsbEasing.OutSine, 74526, 75473, itg.ScaleAt(69473), new Vector2(.55f, .55f));

            itg.ScaleVec(OsbEasing.OutSine, 75789, 75789 + 1250, new Vector2(0.7f, 0.7f), new Vector2(.55f, .55f));
            itg.Rotate(OsbEasing.OutSine, 75789, 75789 + 600, .3, 0);

            itg.ScaleVec(OsbEasing.OutSine, 77052, 77052 + 1250, new Vector2(0.7f, 0.7f), new Vector2(.55f, .55f));
            itg.Rotate(OsbEasing.OutSine, 77052, 77052 + 600, -.3, 0);

            itg.ScaleVec(OsbEasing.OutSine, 78315, 78789, new Vector2(0.7f, 0.7f), new Vector2(.55f, .55f));
            itg.Rotate(OsbEasing.OutSine, 78315, 78315 + 600, -.3, 0);

            itg.ScaleVec(83368, new Vector2(.8f, .8f));
            itg.ScaleVec(83842, new Vector2(.7f, .7f));
            itg.ScaleVec(84157, new Vector2(.6f, .6f));
            itg.ScaleVec(84473, new Vector2(.5f, .5f));

            itg.ScaleVec(OsbEasing.OutCirc, 85894, 85894 + 150, new Vector2(0.5f, 0.5f), new Vector2(.6f, .6f));
            itg.Rotate(OsbEasing.OutCirc, 85894, 85894 + 150, 0, .3);
            itg.Rotate(OsbEasing.OutCirc, 86210, 86210 + 150, .3, -.3);

            itg.Rotate(OsbEasing.OutSine, 86842, 87157, -.3, 0);
            itg.ScaleVec(OsbEasing.OutSine, 86842, 87157, itg.ScaleAt(86842), new Vector2(.52f, .52f));

            itg.ScaleVec(87157, new Vector2(0.6f, .6f));
            itg.ScaleVec(87315, new Vector2(0.7f, .7f));

            itg.ScaleVec(OsbEasing.OutCirc, 88105, 88421, new Vector2(0.65f, .65f), new Vector2(0.55f, 0.55f));

            currentTime = 88421;
            scaleChange = 0.02f;
            while (currentTime < 96000 - beatduration)
            {
                // itg.Rotate(OsbEasing.InOutSine, currentTime, currentTime + beatduration, lastrot, rotate);
                itg.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + beatduration / 2, itg.ScaleAt(currentTime), (Vector2)itg.ScaleAt(currentTime) + new Vector2(scaleChange, scaleChange));
                itg.ScaleVec(OsbEasing.InCirc, currentTime + beatduration / 2, currentTime + beatduration, (Vector2)itg.ScaleAt(currentTime) + new Vector2(scaleChange, scaleChange), itg.ScaleAt(currentTime));
                currentTime += beatduration;
            }

            currentTime = 88421;
            float currentRota = 0;
            float rotate = .05f;
            while (currentTime < 96000 - beatduration)
            {
                // itg.Rotate(OsbEasing.InOutSine, currentTime, currentTime + beatduration, lastrot, rotate);
                itg.Rotate(OsbEasing.OutCirc, currentTime, currentTime + beatduration, currentRota, rotate);
                currentRota = rotate;
                itg.Rotate(OsbEasing.OutCirc, currentTime + beatduration, currentTime + beatduration * 2, currentRota, -rotate);
                currentRota = -rotate;
                currentTime += beatduration * 2;
            }

            itg.Rotate(OsbEasing.OutCirc, 96000, 98526, currentRota, Math.PI * 2);

            itg.ScaleVec(OsbEasing.OutCirc, 96000, 96315, itg.ScaleAt(96000), new Vector2(itg.ScaleAt(96000).X, -itg.ScaleAt(96000).Y));
            itg.ScaleVec(OsbEasing.OutSine, 96315, 98526, itg.ScaleAt(96315), new Vector2(itg.ScaleAt(96315).X, -itg.ScaleAt(96315).Y));

            flipHorz(78789);
            flipVert(79105);
            itg.Rotate(OsbEasing.OutElasticQuarter, 79421, 80447, 0, Math.PI);
            itg.ScaleVec(80447, new Vector2(.55f, .55f));

            itg.Rotate(OsbEasing.OutCirc, 80447, 80526, 0, -.1);
            itg.Rotate(OsbEasing.OutCirc, 80526, 80605, -.1, .1);
            itg.Rotate(OsbEasing.OutCirc, 80605, 80684, .1, -.1);
            itg.Rotate(OsbEasing.OutCirc, 80684, 80763, -.1, .1);
            itg.Rotate(OsbEasing.OutCirc, 80763, 80842, .1, 0);

            itg.ScaleVec(OsbEasing.OutSine, 80842, 80842 + 1250, new Vector2(0.7f, 0.7f), new Vector2(.55f, .55f));
            itg.Rotate(OsbEasing.OutSine, 80842, 80842 + 600, .3, 0);

            itg.ScaleVec(OsbEasing.OutSine, 82105, 82105 + 1250, new Vector2(0.7f, 0.7f), new Vector2(.55f, .55f));
            itg.Rotate(OsbEasing.OutSine, 82105, 82105 + 600, .3, 0);

            OsbSprite left = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreRight);
            left.Color(0, new Color4(0, 0, 0, 0));
            left.ScaleVec(0, 854, 700);
            left.Fade(0, 1f);
            left.Fade(3789, 0);
            left.Rotate(0, .2);
            left.MoveX(OsbEasing.OutCirc, 1263, 3789, 320, 320 - 500);

            OsbSprite right = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreLeft);
            right.Color(0, new Color4(0, 0, 0, 0));
            right.ScaleVec(0, 854, 700);
            right.Fade(0, 1f);
            right.Fade(3789, 0);
            right.Rotate(0, .2);
            right.MoveX(OsbEasing.OutCirc, 1263, 3789, 320, 320 + 500);

            OsbSprite black = GetLayer("").CreateSprite("sb/white.png");
            black.Color(0, new Color4(0, 0, 0, 0));
            black.ScaleVec(0, 854, 480);
            black.Fade(OsbEasing.OutSine, 0, 3789, 1f, .75f);
            black.Fade(122210, 0);
        }

        public void kick(double start, double start2, double rot)
        {

            itg.ScaleVec(OsbEasing.OutCirc, start, start + 100, new Vector2(0.5f, 0.5f), new Vector2(0.6f, 0.6f));
            itg.Rotate(OsbEasing.OutCirc, start, start + 100, 0, rot);


            itg.ScaleVec(OsbEasing.OutCirc, start2, start2 + 150, new Vector2(0.6f, 0.6f), new Vector2(0.5f, 0.5f));
            itg.Rotate(OsbEasing.OutCirc, start2, start2 + 150, rot, 0f);

        }

        public void scale(double start, double start2)
        {

            Vector2 currentScale = itg.ScaleAt(start);
            Vector2 nextScale = itg.ScaleAt(start);

            if (currentScale.X < 0)
            {
                nextScale.X -= .1f;
            }
            else
            {
                nextScale.X += .1f;
            }

            if (currentScale.Y < 0)
            {
                nextScale.Y -= .1f;
            }
            else
            {
                nextScale.Y += .1f;
            }


            itg.ScaleVec(OsbEasing.OutCirc, start, start + 100, currentScale, nextScale);
            itg.ScaleVec(OsbEasing.OutCirc, start2, start2 + 150, nextScale, currentScale);

        }

        public void flipVert(double start)
        {

            Vector2 currentScale = itg.ScaleAt(start);

            itg.ScaleVec(OsbEasing.OutCirc, start, start + 100, currentScale, new Vector2(currentScale.X, currentScale.Y * -1));

        }

        public void flipHorz(double start)
        {

            Vector2 currentScale = itg.ScaleAt(start);

            itg.ScaleVec(OsbEasing.OutCirc, start, start + 100, currentScale, new Vector2(currentScale.X * -1, currentScale.Y));

        }


    }
}
