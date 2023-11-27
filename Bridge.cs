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
using System.IO;
using System.Linq;

namespace StorybrewScripts
{
    public class Bridge : StoryboardObjectGenerator
    {

        public override bool Multithreaded => true;

        Playfield field;
        float height = 600f;

        public override void Generate()
        {

            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            // General values
            var starttime = 64342;
            var endtime = 122210;
            var duration = endtime - starttime;

            // Playfield Scale
            var width = 200f;

            // Note initilization Values
            var bpm = 190f;
            var offset = 0f;

            // Drawinstance Values
            var updatesPerSecond = 20;
            var scrollSpeed = 1350f;
            var rotateNotesToFaceReceptor = false;
            var fadeTime = 60;

            Playfield field2 = new Playfield();
            field2.initilizePlayField(receptors, notes, 108473, endtime, width, height, 50);
            field2.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, 25);
            field2.Scale(OsbEasing.None, 108473 + 2, 108473 + 2, new Vector2(0.4f, 0.4f), true);

            field = new Playfield();
            field.noteStart = 64263;
            field.initilizePlayField(receptors, notes, starttime, endtime, width, height, 50);
            field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, 30);
            field.Scale(OsbEasing.OutSine, starttime + 2, starttime + 2, new Vector2(0.4f, 0.4f), true);

            collapse(64421, 400, -400);
            collapse(64894, 200, -400);
            field.MoveColumnRelativeX(OsbEasing.None, 64894, 64894, field.getColumnWidth(width), ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.None, 64894, 64894, field.getColumnWidth(width), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.None, 64894, 64894, field.getColumnWidth(width), ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.None, 64894, 64894, -field.getColumnWidth(width) * 3, ColumnType.four);
            collapse(65210, 200, -400);
            field.MoveColumnRelativeX(OsbEasing.None, 65210, 65210, -field.getColumnWidth(width), ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.None, 65210, 65210, -field.getColumnWidth(width), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.None, 65210, 65210, -field.getColumnWidth(width), ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.None, 65210, 65210, field.getColumnWidth(width) * 3, ColumnType.four);
            collapse(65526, 200, -500);

            field.Resize(OsbEasing.OutCirc, 66947, 67263, width, -height);
            field.moveFieldY(OsbEasing.OutCirc, 66947, 67263, 380);

            field.ScaleOrigin(OsbEasing.InCirc, 66947, 67052, new Vector2(0.2f, 0.2f), ColumnType.all);
            field.ScaleOrigin(OsbEasing.OutCirc, 67052, 67263, new Vector2(0.5f, 0.5f), ColumnType.all);

            field.ScaleReceptor(OsbEasing.InSine, 66947, 67052, new Vector2(0.6f, 0.6f), ColumnType.all);
            field.ScaleReceptor(OsbEasing.OutSine, 67052, 67263, new Vector2(0.4f, 0.4f), ColumnType.all);

            //collapse(66947, 400, 400);
            collapse(67421, 200, 400);
            field.MoveColumnRelativeX(OsbEasing.None, 67421, 67421, field.getColumnWidth(width) * 3, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.None, 67421, 67421, -field.getColumnWidth(width), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.None, 67421, 67421, -field.getColumnWidth(width), ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.None, 67421, 67421, -field.getColumnWidth(width), ColumnType.four);
            collapse(67736, 200, 400);
            field.MoveColumnRelativeX(OsbEasing.None, 67736, 67736, -field.getColumnWidth(width) * 3, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.None, 67736, 67736, field.getColumnWidth(width), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.None, 67736, 67736, field.getColumnWidth(width), ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.None, 67736, 67736, field.getColumnWidth(width), ColumnType.four);
            collapse(68052, 200, 500);

            field.RotateReceptorRelative(OsbEasing.None, 65684, 66789, Math.PI * 4);
            field.RotateReceptorRelative(OsbEasing.None, 68210, 69157, Math.PI * 4);

            field.ScaleReceptor(OsbEasing.OutSine, 69473, 74447, new Vector2(.4f, .4f), ColumnType.all);
            field.ScaleOrigin(OsbEasing.OutSine, 69473, 74447, new Vector2(.6f, .6f), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.InOutSine, 69473, 74447, new Vector2(-400, -150), ColumnType.one);
            field.MoveOriginRelative(OsbEasing.InOutSine, 69473, 74447, new Vector2(-150, -150), ColumnType.two);
            field.MoveOriginRelative(OsbEasing.InOutSine, 69473, 74447, new Vector2(150, -150), ColumnType.three);
            field.MoveOriginRelative(OsbEasing.InOutSine, 69473, 74447, new Vector2(400, -150), ColumnType.four);

            field.ScaleOrigin(OsbEasing.OutSine, 74526, 74447, new Vector2(.4f, .4f), ColumnType.all);
            field.Resize(OsbEasing.None, 74526 - 10, 74526 - 10, width, -height);
            field.Scale(OsbEasing.OutSine, 74526, 74526 + 100, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 75000, 75000 + 150, new Vector2(.4f, .4f));

            field.Resize(OsbEasing.None, 75000 + 150, 75000 + 150, width, -height);

            field.MoveColumnRelativeY(OsbEasing.None, 74526, 74526, 200, ColumnType.all);
            field.MoveColumnRelativeY(OsbEasing.OutCirc, 74526, 74526 + 250, -200, ColumnType.all);

            field.MoveOriginRelative(OsbEasing.OutCirc, 75157, 75157 + 150, new Vector2(0, 100), ColumnType.all);

            field.Resize(OsbEasing.OutCirc, 75789, 75789 + 250, width, height);
            field.moveFieldY(OsbEasing.OutCirc, 75789, 75789 + 250, -380);
            field.Scale(OsbEasing.None, 75789, 75789, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 75789 + 50, 75789 + 600, new Vector2(.4f, .4f));

            field.Resize(OsbEasing.OutCirc, 77052, 77052 + 250, width, -height);
            field.moveFieldY(OsbEasing.OutCirc, 77052, 77052 + 250, 380);
            field.Scale(OsbEasing.None, 77052, 77052, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 77052 + 50, 77052 + 600, new Vector2(.4f, .4f));

            field.Resize(OsbEasing.OutCirc, 78315, 78315 + 250, width, height);
            field.moveFieldY(OsbEasing.OutCirc, 78315, 78315 + 250, -380);
            field.Scale(OsbEasing.None, 78315, 78315, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 78315 + 50, 78315 + 600, new Vector2(.4f, .4f));

            field.Rotate(OsbEasing.OutCirc, 78789, 78789 + 250, Math.PI / 2, CenterType.middle);
            field.Rotate(OsbEasing.OutCirc, 79105, 79105 + 250, Math.PI / 2, CenterType.middle);
            field.Rotate(OsbEasing.OutElasticQuarter, 79421, 79421 + 1200, Math.PI, CenterType.middle);

            field.Resize(OsbEasing.OutCirc, 79105, 79105 + 250, width, height);
            field.Resize(OsbEasing.OutElasticQuarter, 79421, 80621, width, height);

            field.Rotate(OsbEasing.OutCirc, 80447, 80526, -.2, CenterType.receptor);
            field.Rotate(OsbEasing.OutCirc, 80526, 80605, .4, CenterType.receptor);
            field.Rotate(OsbEasing.OutCirc, 80605, 80684, -.4, CenterType.receptor);
            field.Rotate(OsbEasing.OutCirc, 80684, 80763, .4, CenterType.receptor);
            field.Rotate(OsbEasing.OutCirc, 80763, 80842, -.2, CenterType.receptor);

            field.Resize(OsbEasing.OutCirc, 80842, 80842 + 250, width, -height);
            field.moveFieldY(OsbEasing.OutCirc, 80842, 80842 + 250, 380);
            field.Scale(OsbEasing.None, 80842, 80842, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 80842 + 50, 80842 + 600, new Vector2(.4f, .4f));

            field.Resize(OsbEasing.OutCirc, 82105, 82105 + 250, width, height);
            field.moveFieldY(OsbEasing.OutCirc, 82105, 82105 + 250, -380);
            field.Scale(OsbEasing.None, 82105, 82105, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 82105 + 50, 82105 + 600, new Vector2(.4f, .4f));

            field.moveFieldX(OsbEasing.None, 83368, 83368, 100);
            collapse(83368, 350, -700);
            field.Scale(OsbEasing.None, 83368, 83368, new Vector2(.65f, .65f));
            collapse(83842, 150, -700);
            field.moveFieldX(OsbEasing.None, 83842, 83842, -100);
            field.Scale(OsbEasing.None, 83842, 83842, new Vector2(.6f, .6f));
            collapse(84157, 150, -700);
            field.moveFieldX(OsbEasing.None, 84157, 84157, -100);
            field.Scale(OsbEasing.None, 84157, 84157, new Vector2(.5f, .5f));
            collapse(84473, 150, -700);
            field.moveFieldX(OsbEasing.None, 84473, 84473, -100);
            field.Scale(OsbEasing.None, 84473, 84473, new Vector2(.4f, .4f));

            field.moveFieldX(OsbEasing.OutCirc, 85578, 85894, 200);

            double currentTime = 85578;
            double interval = 135;
            float localwidth = width * -1;

            var one = new Vector2(0.6f, 0.6f);
            var two = new Vector2(0.4f, 0.4f);
            var three = new Vector2(0.3f, 0.3f);
            var four = new Vector2(0.2f, 0.2f);

            while (currentTime < 85894 - interval)
            {

                var lone = one;
                var ltwo = two;
                var lthree = three;
                var lfour = four;

                field.Resize(OsbEasing.InOutSine, currentTime, currentTime + interval, localwidth, height);

                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, one, ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, two, ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, three, ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, four, ColumnType.four);

                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.four);

                one = lfour;
                two = lthree;
                three = ltwo;
                four = lone;

                localwidth *= -1;

                currentTime += interval;
            }

            field.Scale(OsbEasing.OutCirc, 85894, 85894 + 100, new Vector2(0.5f, 0.5f));
            field.moveFieldX(OsbEasing.OutCirc, 85894, 85894 + 100, 100);
            field.Rotate(OsbEasing.OutCirc, 85894, 85894 + 100, .4);

            field.moveFieldX(OsbEasing.OutCirc, 86210, 86210, -100);
            field.Rotate(OsbEasing.OutCirc, 86210, 86368, -.8);
            field.moveFieldX(OsbEasing.OutCirc, 86210, 86368, -150);

            field.moveFieldX(OsbEasing.OutSine, 86842, 87157, 150);
            field.Rotate(OsbEasing.OutSine, 86842, 87157, .4);
            field.moveFieldY(OsbEasing.OutCirc, 86210, 86368, -40);
            field.Resize(OsbEasing.OutCirc, 86842, 87157, width, height);
            field.Scale(OsbEasing.OutCirc, 86842, 87157, new Vector2(0.4f, 0.4f), true);

            field.Scale(OsbEasing.OutCirc, 87157, 87157 + 50, new Vector2(0.5f, 0.5f));
            field.MoveOriginRelative(OsbEasing.OutCirc, 87157, 87157 + 50, new Vector2(0, 100), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 87315, 87315 + 50, new Vector2(0.65f, 0.65f));
            field.MoveOriginRelative(OsbEasing.OutCirc, 87315, 87315 + 50, new Vector2(0, 100), ColumnType.all);

            currentTime = 88026;
            interval = 150;
            localwidth = width * -1;

            one = new Vector2(0.6f, 0.6f);
            two = new Vector2(0.4f, 0.4f);
            three = new Vector2(0.3f, 0.3f);
            four = new Vector2(0.2f, 0.2f);

            while (currentTime < 88421 - interval)
            {

                var lone = one;
                var ltwo = two;
                var lthree = three;
                var lfour = four;

                field.Resize(OsbEasing.InOutSine, currentTime, currentTime + interval, localwidth, height);

                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, one, ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, two, ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, three, ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, four, ColumnType.four);

                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.four);

                one = lfour;
                two = lthree;
                three = ltwo;
                four = lone;

                localwidth *= -1;

                currentTime += interval;
            }

            field.MoveOriginRelative(OsbEasing.OutCirc, 88105, 88421, new Vector2(0, -200), ColumnType.all);

            field.Resize(OsbEasing.OutCirc, 88421, 88421 + 250, width, -height);
            field.moveFieldY(OsbEasing.OutCirc, 88421, 88421 + 250, 380);
            field.Scale(OsbEasing.None, 88421, 88421, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 88421 + 50, 88421 + 600, new Vector2(.4f, .4f));

            float colTwoY = Random(-30, -15);
            float colThreeY = Random(-30, -15);
            float colFourY = Random(-30, -15);

            bounceColumn(89526, ColumnType.two);
            bounceColumn(89605, ColumnType.three);
            bounceColumn(89684, ColumnType.four);

            bounceColumn(90473, ColumnType.one);
            bounceColumn(90552, ColumnType.three);
            bounceColumn(90631, ColumnType.two);
            bounceColumn(90710, ColumnType.four);
            bounceColumn(90789, ColumnType.two);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 90000, 90000 + 350, Math.PI * 2, ColumnType.all);
            field.Resize(OsbEasing.OutCirc, 90000, 90000, 400, -height);
            field.Resize(OsbEasing.OutCirc, 90000, 90000 + 350, width, -height);

            field.Resize(OsbEasing.OutCirc, 90947, 90947 + 250, width, height);
            field.moveFieldY(OsbEasing.OutCirc, 90947, 90947 + 250, -380);
            field.Scale(OsbEasing.None, 90947, 90947, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 90947 + 50, 90947 + 600, new Vector2(.4f, .4f));

            field.Resize(OsbEasing.OutCirc, 92210, 92210 + 250, width, -height);
            field.moveFieldY(OsbEasing.OutCirc, 92210, 92210 + 250, 380);
            field.Scale(OsbEasing.None, 92210, 92210, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 92210 + 50, 92210 + 600, new Vector2(.4f, .4f));

            field.Resize(OsbEasing.OutCirc, 93473, 93473 + 250, width, height);
            field.moveFieldY(OsbEasing.OutCirc, 93473, 93473 + 250, -380);
            field.Scale(OsbEasing.None, 93473, 93473, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 93473 + 50, 94736, new Vector2(.4f, .4f));

            field.RotateReceptorRelative(OsbEasing.OutSine, 94894, 95368, Math.PI * 2, ColumnType.all);
            field.RotateReceptorRelative(OsbEasing.OutCirc, 95368, 96000, -Math.PI * 2, ColumnType.all);

            field.Resize(OsbEasing.OutCirc, 96000, 96000 + 250, width, -height);
            field.moveFieldY(OsbEasing.OutCirc, 96000, 96000 + 250, 380);
            field.Scale(OsbEasing.None, 96000, 96000, new Vector2(.7f, .7f));
            field.Scale(OsbEasing.OutSine, 96000 + 50, 96000 + 600, new Vector2(.4f, .4f));

            field.RotateReceptorRelative(OsbEasing.OutSine, 96000, 96000 + 500, Math.PI * 2, ColumnType.all);

            field.moveFieldY(OsbEasing.OutSine, 96000, 98526, -380);

            currentTime = 96000;
            interval = 350;
            localwidth = 200 * -1;

            float increase = 1.1f;

            one = new Vector2(0.6f, 0.6f);
            two = new Vector2(0.4f, 0.4f);
            three = new Vector2(0.3f, 0.3f);
            four = new Vector2(0.2f, 0.2f);

            while (currentTime < 98210)
            {

                var lone = one;
                var ltwo = two;
                var lthree = three;
                var lfour = four;

                interval = Utility.SmoothAmplitudeByTime(currentTime, 96000, 98210, 750, 100, 100);

                field.Resize(OsbEasing.InOutSine, currentTime, currentTime + interval, localwidth, height);

                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, one, ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, two, ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, three, ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, four, ColumnType.four);

                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.four);

                one = lfour;
                two = lthree;
                three = ltwo;
                four = lone;

                localwidth *= -1;

                currentTime += interval;
            }

            height += 200;

            field.moveFieldY(OsbEasing.None, 99789, 100894, 15);
            field.moveFieldY(OsbEasing.None, 102789, 103421, 15);
            field.moveFieldY(OsbEasing.None, 105197, 105947, 15);
            field.RotateReceptorRelative(OsbEasing.OutSine, 107723, 108631, Math.PI * 2);
            field.moveFieldY(OsbEasing.OutSine, 107723, 108631, -45);

            field.moveFieldX(OsbEasing.None, 98526, 98526, 100);
            field.moveFieldX(OsbEasing.None, 99434, 99434, -100);
            field.moveFieldX(OsbEasing.None, 101013, 101013, -100);
            field.moveFieldX(OsbEasing.None, 101960, 101960, 100);
            field.moveFieldX(OsbEasing.None, 103539, 103539, 175);
            field.moveFieldX(OsbEasing.None, 104486, 104486, -175);
            field.moveFieldX(OsbEasing.None, 106065, 106065, -150);
            field.moveFieldX(OsbEasing.None, 107014, 107014, 150);

            field.Resize(OsbEasing.OutElasticHalf, 98526, 98526 + 300, 300, height);
            field.Rotate(OsbEasing.OutElasticHalf, 98526, 98526 + 300, .6, CenterType.middle);
            field.ScaleColumn(OsbEasing.OutCirc, 98526, 98526 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);
            field.ScaleColumn(OsbEasing.OutCirc, 99000, 99236, new Vector2(0.4f, 0.4f), ColumnType.all);

            field.Rotate(OsbEasing.OutElasticHalf, 99434 - 10, 99434 - 10, -.6, CenterType.middle);
            field.Resize(OsbEasing.OutElasticHalf, 99434 - 5, 99434 - 5, 200, height);
            field.Resize(OsbEasing.OutElasticQuarter, 99434, 99434 + 300, -300, height);
            field.Rotate(OsbEasing.OutElasticHalf, 99434, 99789, -.2, CenterType.middle);
            field.ScaleColumn(OsbEasing.OutCirc, 99434, 99434 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);

            field.Rotate(OsbEasing.OutCirc, 100105, 100263, .2, CenterType.middle);
            field.Resize(OsbEasing.OutElasticQuarter, 100105 + 10, 100263, 200, height);
            field.ScaleColumn(OsbEasing.OutCirc, 99789, 100894, new Vector2(0.4f, 0.4f), ColumnType.all);

            field.Resize(OsbEasing.OutElasticHalf, 101013, 101013 + 300, 300, height);
            field.Rotate(OsbEasing.OutElasticHalf, 101013, 101013 + 300, -.5, CenterType.middle);
            field.ScaleColumn(OsbEasing.OutCirc, 101013, 101013 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);
            field.ScaleColumn(OsbEasing.OutCirc, 101526, 101684, new Vector2(0.4f, 0.4f), ColumnType.all);

            field.Rotate(OsbEasing.OutElasticHalf, 101960 - 10, 101960 - 10, .5, CenterType.middle);
            field.Resize(OsbEasing.OutElasticHalf, 101960 - 5, 101960 - 5, 200, height);
            field.Resize(OsbEasing.OutElasticQuarter, 101960, 101960 + 200, -300, height);
            field.Rotate(OsbEasing.OutElasticHalf, 101960, 101960 + 200, .4, CenterType.middle);
            field.ScaleColumn(OsbEasing.OutCirc, 101960, 101960 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);

            field.Rotate(OsbEasing.OutCirc, 102473, 102631, -.4, CenterType.middle);
            field.Resize(OsbEasing.OutElasticQuarter, 102473 + 10, 102631, 200, height);
            field.ScaleColumn(OsbEasing.OutCirc, 102236, 103500, new Vector2(0.4f, 0.4f), ColumnType.all);

            field.Resize(OsbEasing.OutElasticHalf, 103539, 103539 + 300, 300, height);
            field.Rotate(OsbEasing.OutElasticHalf, 103539, 103539 + 300, .4, CenterType.middle);
            field.ScaleColumn(OsbEasing.OutCirc, 103539, 103539 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);
            field.ScaleColumn(OsbEasing.OutCirc, 104052, 104250, new Vector2(0.4f, 0.4f), ColumnType.all);

            field.Rotate(OsbEasing.OutElasticHalf, 104486 - 10, 104486 - 10, -.4, CenterType.middle);
            field.Resize(OsbEasing.OutElasticHalf, 104486 - 5, 104486 - 5, 200, height);
            field.Resize(OsbEasing.OutElasticQuarter, 104486, 104486 + 300, -300, height);
            field.Rotate(OsbEasing.OutElasticHalf, 104486, 104486 + 300, -.7, CenterType.middle);
            field.ScaleColumn(OsbEasing.OutCirc, 104486, 104486 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);

            field.Rotate(OsbEasing.OutCirc, 105000, 105197, .7, CenterType.middle);
            field.Resize(OsbEasing.OutElasticQuarter, 105000 + 10, 105197, 200, height);
            field.ScaleColumn(OsbEasing.OutCirc, 105000, 105947, new Vector2(0.4f, 0.4f), ColumnType.all);

            field.Resize(OsbEasing.OutElasticHalf, 106065, 106065 + 300, 300, height);
            field.ScaleColumn(OsbEasing.OutCirc, 106065, 106065 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);
            field.Rotate(OsbEasing.OutElasticHalf, 106065, 106065 + 300, -.6, CenterType.middle);
            field.ScaleColumn(OsbEasing.OutCirc, 106578, 106776, new Vector2(0.4f, 0.4f), ColumnType.all);

            field.Rotate(OsbEasing.OutElasticHalf, 107014 - 10, 107014 - 10, .6, CenterType.middle);
            field.Resize(OsbEasing.OutElasticHalf, 107014 - 5, 107014 - 5, 200, height);
            field.Resize(OsbEasing.OutElasticQuarter, 107014, 107014 + 300, -300, height);
            field.ScaleColumn(OsbEasing.OutCirc, 107014, 107014 + 300, new Vector2(0.65f, 0.65f), ColumnType.all);
            field.Rotate(OsbEasing.OutElasticHalf, 107014, 107014 + 300, .4, CenterType.middle);

            field.Rotate(OsbEasing.OutCirc, 107565, 107723, -.4, CenterType.middle);
            field.Resize(OsbEasing.OutElasticQuarter, 107565 + 10, 107723, 200, height);
            field.ScaleColumn(OsbEasing.OutCirc, 107565, 108315, new Vector2(0.4f, 0.4f), ColumnType.all);

            field2.Resize(OsbEasing.None, 108473 + 20, 108473 + 20, width, height);

            interval = 14210 - 13894;
            currentTime = 108473;

            while (currentTime < 113763 - interval)
            {
                field.moveFieldY(OsbEasing.InCirc, currentTime, currentTime + interval / 2, 15);
                field.moveFieldY(OsbEasing.OutCirc, currentTime + interval / 2, currentTime + interval, -15);

                field2.moveFieldY(OsbEasing.InCirc, currentTime, currentTime + interval / 2, 15);
                field2.moveFieldY(OsbEasing.OutCirc, currentTime + interval / 2, currentTime + interval, -15);

                currentTime += interval;
            }

            // 1
            field.moveFieldY(OsbEasing.OutSine, 108631, 109263, 20);
            field.moveFieldY(OsbEasing.InSine, 109263, 109894, -20);
            field2.moveFieldY(OsbEasing.OutSine, 108631, 109263, -20);
            field2.moveFieldY(OsbEasing.InSine, 109263, 109894, 20);

            field2.Scale(OsbEasing.OutSine, 108631, 109263, new Vector2(0.3f, 0.3f));
            field2.Scale(OsbEasing.InSine, 109263, 109894, new Vector2(0.4f, 0.4f));
            field.Scale(OsbEasing.OutSine, 108631, 109263, new Vector2(0.4f, 0.4f));
            field.Scale(OsbEasing.InSine, 109263, 109894, new Vector2(0.4f, 0.4f));

            // 2
            field.moveFieldY(OsbEasing.OutSine, 109894, 110526, -20);
            field.moveFieldY(OsbEasing.InSine, 110526, 111157, 20);
            field2.moveFieldY(OsbEasing.OutSine, 109894, 110526, 20);
            field2.moveFieldY(OsbEasing.InSine, 110526, 111157, -20);

            field.Scale(OsbEasing.OutSine, 109894, 110526, new Vector2(0.3f, 0.3f));
            field.Scale(OsbEasing.InSine, 110526, 111157, new Vector2(0.4f, 0.4f));
            field2.Scale(OsbEasing.OutSine, 109894, 110526, new Vector2(0.4f, 0.4f));
            field2.Scale(OsbEasing.InSine, 110526, 111157, new Vector2(0.4f, 0.4f));

            // 3
            field.moveFieldY(OsbEasing.OutSine, 111157, 111789, 20);
            field.moveFieldY(OsbEasing.InSine, 111789, 112421, -20);
            field2.moveFieldY(OsbEasing.OutSine, 111157, 111789, -20);
            field2.moveFieldY(OsbEasing.InSine, 110526, 112421, 20);

            field2.Scale(OsbEasing.OutSine, 111157, 111789, new Vector2(0.3f, 0.3f));
            field2.Scale(OsbEasing.InSine, 111789, 112421, new Vector2(0.4f, 0.4f));
            field.Scale(OsbEasing.OutSine, 111157, 111789, new Vector2(0.4f, 0.4f));
            field.Scale(OsbEasing.InSine, 111789, 112421, new Vector2(0.4f, 0.4f));

            // 4
            field.moveFieldY(OsbEasing.OutSine, 112421, 113052, -20);
            field.moveFieldY(OsbEasing.InSine, 113052, 113368, 20);
            field2.moveFieldY(OsbEasing.OutSine, 112421, 113052, 20);
            field2.moveFieldY(OsbEasing.InSine, 113052, 113368, -20);

            field.Scale(OsbEasing.InSine, 112421, 113052, new Vector2(0.3f, 0.3f));
            field.Scale(OsbEasing.OutSine, 113052, 113368, new Vector2(0.4f, 0.4f));
            field2.Scale(OsbEasing.InSine, 112421, 113052, new Vector2(0.4f, 0.4f));
            field2.Scale(OsbEasing.OutSine, 113052, 113368, new Vector2(0.4f, 0.4f));

            field.moveFieldX(OsbEasing.OutSine, 108631, 109894, 200);
            field.moveFieldX(OsbEasing.InOutSine, 109894, 111157, -400);
            field.moveFieldX(OsbEasing.InOutSine, 111157, 112421, 400);
            field.moveFieldX(OsbEasing.InOutSine, 112421, 113368, -400);
            field.moveFieldX(OsbEasing.OutCirc, 113368, 113684, 200);

            field2.moveFieldX(OsbEasing.OutSine, 108631, 109894, -200);
            field2.moveFieldX(OsbEasing.InOutSine, 109894, 111157, 400);
            field2.moveFieldX(OsbEasing.InOutSine, 111157, 112421, -400);
            field2.moveFieldX(OsbEasing.InOutSine, 112421, 113368, 400);
            field2.moveFieldX(OsbEasing.OutCirc, 113368, 113684, -200);

            currentTime = 114000;
            var currentScale = new Vector2(0.4f, 0.4f);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 113684, 116210, Math.PI * 2);

            while (currentTime < 116210)
            {
                currentScale += new Vector2(0.05f, 0.05f);
                field.Scale(OsbEasing.OutElasticHalf, currentTime, currentTime + interval, currentScale);
                field.moveFieldY(OsbEasing.OutElasticHalf, currentTime, currentTime, 2);

                currentTime += interval;
            }

            field.Resize(OsbEasing.OutElasticHalf, 116210, 116565, -375, height - 150);
            field.Resize(OsbEasing.OutElasticHalf, 116842, 117197, 375, height - 300);


            currentTime = 117434;
            interval = 350;
            width *= -1;
            height -= 300;

            increase = 1.1f;

            one = new Vector2(0.6f, 0.6f);
            two = new Vector2(0.4f, 0.4f);
            three = new Vector2(0.3f, 0.3f);
            four = new Vector2(0.2f, 0.2f);

            while (currentTime < 120000)
            {

                var lone = one;
                var ltwo = two;
                var lthree = three;
                var lfour = four;

                interval = Utility.SmoothAmplitudeByTime(currentTime, 117434, 120000, 750, 100, 100);

                field.Resize(OsbEasing.InOutSine, currentTime, currentTime + interval, width, height);

                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, one, ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, two, ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, three, ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime, currentTime + interval / 2, four, ColumnType.four);

                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.one);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.two);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.three);
                field.ScaleColumn(OsbEasing.InSine, currentTime + interval / 2, currentTime + interval, new Vector2(0.4f, 0.4f), ColumnType.four);

                one = lfour;
                two = lthree;
                three = ltwo;
                four = lone;

                width /= increase * -1;
                height /= increase;

                currentTime += interval;
            }

            field.RotateReceptorRelative(OsbEasing.None, 120000, 122210, Random(-15, 15), ColumnType.one);
            field.RotateReceptorRelative(OsbEasing.None, 120000, 122210, Random(-10, 10), ColumnType.two);
            field.RotateReceptorRelative(OsbEasing.None, 120000, 122210, Random(-5, 10), ColumnType.three);
            field.RotateReceptorRelative(OsbEasing.None, 120000, 122210, Random(-5, 20), ColumnType.four);

            field.MoveReceptorRelative(OsbEasing.None, 120000, 122210, new Vector2(Random(-200, 100), 100), ColumnType.one);
            field.MoveReceptorRelative(OsbEasing.None, 120000, 122210, new Vector2(Random(-200, 100), 100), ColumnType.two);
            field.MoveReceptorRelative(OsbEasing.None, 120000, 122210, new Vector2(Random(-100, 200), 100), ColumnType.three);
            field.MoveReceptorRelative(OsbEasing.None, 120000, 122210, new Vector2(Random(-100, 200), 100), ColumnType.four);

            field.RotateColumn(OsbEasing.None, 120000, 122210, Random(-4, 4), ColumnType.one, CenterType.middle);
            field.RotateColumn(OsbEasing.None, 120000, 122210, Random(-4, 4), ColumnType.two, CenterType.middle);
            field.RotateColumn(OsbEasing.None, 120000, 122210, Random(-4, 4), ColumnType.three, CenterType.middle);
            field.RotateColumn(OsbEasing.None, 120000, 122210, Random(-4, 4), ColumnType.four, CenterType.middle);

            field.columns[ColumnType.one].receptor.renderedSprite.Fade(OsbEasing.OutExpo, 121263, 122210, 1, 0);
            field.columns[ColumnType.two].receptor.renderedSprite.Fade(OsbEasing.OutExpo, 121263, 122210, 1, 0);
            field.columns[ColumnType.three].receptor.renderedSprite.Fade(OsbEasing.OutExpo, 121263, 122210, 1, 0);
            field.columns[ColumnType.four].receptor.renderedSprite.Fade(OsbEasing.OutExpo, 121263, 122210, 1, 0);

            DrawInstance draw = new DrawInstance(field, starttime + 50, scrollSpeed, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeTime);
            draw.setHoldRotationPrecision(0f);
            draw.setHoldMovementPrecision(0f);
            draw.setNoteRotationPrecision(0f);
            draw.setNoteMovementPrecision(0f);
            //draw.setHoldScalePrecision(0f);
            draw.drawViaEquation(duration - 50, NoteFunction, true);
            // draw.drawViaEquation(duration, NoteFunction, ColumnType.all);

            DrawInstance draw2 = new DrawInstance(field2, 108473 + 50, scrollSpeed + 100, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeTime);
            draw2.setHoldRotationPrecision(0f);
            draw2.setHoldMovementPrecision(0f);
            draw2.setNoteRotationPrecision(0f);
            draw2.setNoteMovementPrecision(0f);
            //draw.setHoldScalePrecision(0f);
            draw2.drawViaEquation(113684 - 108473 - 50, NoteFunction, true);

        }

        public Vector2 NoteFunction(EquationParameters par)
        {
            float x = par.position.X;
            float y = par.position.Y;

            if (par.column.type == ColumnType.one && par.time >= 69473 && par.time <= 74447)
            {
                x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 69473, 74526, 0, 175, 175), 0.5, par.progress);
            }
            if (par.column.type == ColumnType.two && par.time >= 69473 && par.time <= 74447)
            {
                x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 69473, 74526, 0, 50, 50), 0.5, par.progress);
            }
            if (par.column.type == ColumnType.three && par.time >= 69473 && par.time <= 74447)
            {
                x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 69473, 74526, 0, 50, 50), 0.5, par.progress);
            }
            if (par.column.type == ColumnType.four && par.time >= 69473 && par.time <= 74447)
            {
                x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 69473, 74526, 0, 175, 175), 0.5, par.progress);
            }

            if ((par.time >= 75473 && par.time <= 78789) || (par.time >= 79736 && par.time <= 83368) || (par.time >= 88105 && par.time <= 96000))
            {
                x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 75473, 75789, 0, 30, 30), 1, par.progress);
            }

            return new Vector2(x, y);
        }

        public void collapse(double starttime, double duration, float amount)
        {
            field.MoveOriginRelative(OsbEasing.None, starttime, starttime, new Vector2(0, amount), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutCirc, starttime, starttime + duration, new Vector2(0, -amount), ColumnType.all);
        }

        public void bounceColumn(double starttime, ColumnType type)
        {

            var amount = Random(-30, -15);

            field.MoveColumnRelativeY(OsbEasing.OutCirc, starttime, starttime + 100, amount, type);
            field.MoveColumnRelativeY(OsbEasing.InCirc, starttime + 100, starttime + 300, -amount, type);

        }
    }
}
