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
    public class Drop : StoryboardObjectGenerator
    {
        public override bool Multithreaded => true;
        public Playfield global;
        double sliderAccuracy = 20;

        public override void Generate()
        {

            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            // General values
            var starttime = 22894;
            var endtime = 55263;
            var duration = endtime - starttime;

            // Playfield Scale
            var width = 250f;
            var height = -600;

            // Note initilization Values
            var bpm = 190f;
            var offset = 0f;

            // Drawinstance Values
            var updatesPerSecond = 50;
            var scrollSpeed = 1350f;
            var rotateNotesToFaceReceptor = false;
            var fadeTime = 60;

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, width, height, 50);
            field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);
            field.Scale(OsbEasing.None, starttime + 2, starttime + 2, new Vector2(0.4f, 0.4f));

            global = field;

            kick(OsbEasing.OutCirc, 25263, 25421, 100);
            kick(OsbEasing.OutCirc, 25421, 25578, -200);
            kick(OsbEasing.OutCirc, 25578, 25736, 100);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 26210, 26210 + 200, Math.PI * 2, ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 26210, 26210, new Vector2(0, -height), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.OutCirc, 26210, 26526, new Vector2(0, height), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 28342, 28342, new Vector2(0, -200), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutCirc, 28342, 28736, new Vector2(0, 200), ColumnType.all);

            field.Rotate(OsbEasing.OutElasticQuarter, 27789, 28250, Math.PI / 2, CenterType.middle);
            field.Rotate(OsbEasing.OutElasticQuarter, 28263, 28736, Math.PI / 2, CenterType.middle);
            field.Resize(OsbEasing.OutElasticQuarter, 28263, 28736, 200, height);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 27315, 27473, Math.PI * 2);
            field.Resize(OsbEasing.OutCirc, 27315, 27473, 800, height);
            field.Resize(OsbEasing.None, 27473, 27473, 200, height);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 32368, 32447, Math.PI * 2);
            field.Resize(OsbEasing.OutCirc, 32368, 32447, 800, height);
            field.Resize(OsbEasing.None, 32447, 32447, 200, height);

            field.MoveColumnRelativeX(OsbEasing.OutSine, 25657, 25736, field.getColumnWidth(200), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 25657, 25736, -field.getColumnWidth(200), ColumnType.three);

            field.MoveColumnRelativeX(OsbEasing.OutSine, 25815, 25894, -field.getColumnWidth(200), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 25815, 25894, field.getColumnWidth(200), ColumnType.three);

            field.MoveColumnRelativeX(OsbEasing.OutSine, 30236, 30394, field.getColumnWidth(200), ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 30236, 30394, -field.getColumnWidth(200), ColumnType.two);

            field.MoveColumnRelativeX(OsbEasing.OutSine, 30473, 30552, -field.getColumnWidth(200), ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 30473, 30552, field.getColumnWidth(200), ColumnType.two);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 30789, 30947, Math.PI / 2);

            field.MoveColumnRelativeX(OsbEasing.OutSine, 30789, 30947, field.getColumnWidth(200), ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 30789, 30947, -field.getColumnWidth(200), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 30789, 30947, field.getColumnWidth(200), ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 30789, 30947, -field.getColumnWidth(200), ColumnType.four);

            field.MoveColumnRelativeX(OsbEasing.OutSine, 31263, 31500, -field.getColumnWidth(200), ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 31263, 31500, field.getColumnWidth(200), ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 31263, 31500, -field.getColumnWidth(200), ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.OutSine, 31263, 31500, field.getColumnWidth(200), ColumnType.four);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 31263, 31500, Math.PI / 2 * 3);


            field.MoveOriginRelative(OsbEasing.None, 31263, 31263, new Vector2(0, height), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutCirc, 31263, 31578, new Vector2(0, -height), ColumnType.all);

            field.Rotate(OsbEasing.OutElasticQuarter, 32842, 33315, Math.PI / 2, CenterType.middle);
            field.Rotate(OsbEasing.OutElasticQuarter, 33315, 33788, Math.PI / 2, CenterType.middle);
            field.Resize(OsbEasing.OutElasticQuarter, 33315, 33788, 200, height);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 33789, 34105, Math.PI * 2);
            field.MoveOriginRelative(OsbEasing.None, 33789, 33789, new Vector2(0, -height), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutCirc, 33789, 34105, new Vector2(0, height), ColumnType.all);

            field.Rotate(OsbEasing.OutElasticQuarter, 37894, 38368, Math.PI / 2, CenterType.middle);
            field.Rotate(OsbEasing.OutElasticQuarter, 38368, 38842, Math.PI / 2, CenterType.middle);
            field.Resize(OsbEasing.OutElasticQuarter, 38368, 38842, 200, height);

            double currenttime = 33789;
            double beatlenght = 60000 / bpm;

            while (currenttime < 36236)
            {
                field.moveFieldY(OsbEasing.OutCirc, currenttime, currenttime + beatlenght, -15);
                field.moveFieldY(OsbEasing.InCirc, currenttime + beatlenght, currenttime + beatlenght + beatlenght, 15);
                currenttime += beatlenght + beatlenght;
            }

            currenttime = 36947;

            while (currenttime < 41368)
            {
                field.moveFieldY(OsbEasing.OutCirc, currenttime, currenttime + beatlenght, -15);
                field.moveFieldY(OsbEasing.InCirc, currenttime + beatlenght, currenttime + beatlenght + beatlenght, 15);
                currenttime += beatlenght + beatlenght;
            }

            currenttime = 42000;

            while (currenttime < 43263)
            {
                field.moveFieldY(OsbEasing.OutCirc, currenttime, currenttime + beatlenght, -15);
                field.moveFieldY(OsbEasing.InCirc, currenttime + beatlenght, currenttime + beatlenght + beatlenght, 15);
                currenttime += beatlenght + beatlenght;
            }

            field.MoveOriginRelative(OsbEasing.OutCirc, 36236, 36236 + 100, new Vector2(0, -150), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.None, 36236 + 100, 36236 + 100, new Vector2(0, 150), ColumnType.all);

            field.ScaleColumn(OsbEasing.OutCirc, 36236, 36315, new Vector2(.8f, .8f), ColumnType.one);
            field.ScaleColumn(OsbEasing.OutCirc, 36236, 36315, new Vector2(.8f, .8f), ColumnType.two);
            field.ScaleColumn(OsbEasing.InCirc, 36315, 36394, new Vector2(0.4f, 0.4f), ColumnType.one);
            field.ScaleColumn(OsbEasing.InCirc, 36315, 36394, new Vector2(0.4f, 0.4f), ColumnType.two);

            field.MoveOriginRelative(OsbEasing.OutCirc, 36394, 36394 + 100, new Vector2(0, -150), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.None, 36394, 36394, new Vector2(0, 150), ColumnType.all);

            field.ScaleColumn(OsbEasing.OutCirc, 36394, 36473, new Vector2(.8f, .8f), ColumnType.three);
            field.ScaleColumn(OsbEasing.OutCirc, 36394, 36473, new Vector2(.8f, .8f), ColumnType.four);
            field.ScaleColumn(OsbEasing.InCirc, 36473, 36552, new Vector2(0.4f, 0.4f), ColumnType.three);
            field.ScaleColumn(OsbEasing.InCirc, 36473, 36552, new Vector2(0.4f, 0.4f), ColumnType.four);

            field.MoveOriginRelative(OsbEasing.None, 39710, 41447, new Vector2(-750, 0), ColumnType.one);
            field.MoveOriginRelative(OsbEasing.None, 39710, 41447, new Vector2(-333, 0), ColumnType.two);
            field.MoveOriginRelative(OsbEasing.None, 39710, 41447, new Vector2(333, 0), ColumnType.three);
            field.MoveOriginRelative(OsbEasing.None, 39710, 41447, new Vector2(750, 0), ColumnType.four);

            field.MoveOriginRelative(OsbEasing.OutCirc, 41447, 42631, new Vector2(750, 0), ColumnType.one);
            field.MoveOriginRelative(OsbEasing.OutCirc, 41447, 42631, new Vector2(333, 0), ColumnType.two);

            field.MoveOriginRelative(OsbEasing.OutCirc, 41447, 42631, new Vector2(-333, 0), ColumnType.three);
            field.MoveOriginRelative(OsbEasing.OutCirc, 41447, 42631, new Vector2(-750, 0), ColumnType.four);

            field.MoveOriginRelative(OsbEasing.OutCirc, 41289, 41289 + 100, new Vector2(0, -150), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.None, 41289 + 100, 41289 + 100, new Vector2(0, 150), ColumnType.all);

            field.moveFieldY(OsbEasing.None, 41684, 42947, 25);

            field.ScaleColumn(OsbEasing.OutCirc, 41289, 41368, new Vector2(.8f, .8f), ColumnType.one);
            field.ScaleColumn(OsbEasing.OutCirc, 41289, 41368, new Vector2(.8f, .8f), ColumnType.two);
            field.ScaleColumn(OsbEasing.InCirc, 41368, 41447, new Vector2(0.4f, 0.4f), ColumnType.one);
            field.ScaleColumn(OsbEasing.InCirc, 41368, 41447, new Vector2(0.4f, 0.4f), ColumnType.two);

            field.MoveOriginRelative(OsbEasing.OutCirc, 41447, 41447 + 100, new Vector2(0, -150), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.None, 41447 + 100, 41447 + 100, new Vector2(0, 150), ColumnType.all);

            field.ScaleColumn(OsbEasing.OutCirc, 41447, 41526, new Vector2(.8f, .8f), ColumnType.three);
            field.ScaleColumn(OsbEasing.OutCirc, 41447, 41526, new Vector2(.8f, .8f), ColumnType.four);
            field.ScaleColumn(OsbEasing.InCirc, 41526, 41605, new Vector2(0.4f, 0.4f), ColumnType.three);
            field.ScaleColumn(OsbEasing.InCirc, 41526, 41605, new Vector2(0.4f, 0.4f), ColumnType.four);

            var closest = new Vector2(0.6f, 0.6f);
            var middleFront = new Vector2(0.5f, 0.5f);
            var middleBack = new Vector2(0.3f, 0.3f);
            var furthest = new Vector2(0.2f, 0.2f);

            var scale = new Vector2(.4f, .4f);

            double endTime = 42631; // fixed end time
            int totalSpins = 3; // total amount of spins desired
            double currentTime = 41368; // start time
            width = 200; // initial width
            double totalDuration = endTime - currentTime; // total duration for all spins

            for (int spin = 0; spin < totalSpins; spin++)
            {
                // Calculate a decreasing fraction for each spin
                double fraction = (double)(totalSpins - spin) / totalSpins;
                double easedFraction = 1 - Math.Cos(fraction * Math.PI / 2);

                // Calculate the previous eased fraction
                double nextFraction = (double)(totalSpins - spin - 1) / totalSpins;
                double nextEasedFraction = spin < totalSpins - 1 ? 1 - Math.Cos(nextFraction * Math.PI / 2) : 0;

                // Find the incremental eased duration
                double incrementalEasedFraction = easedFraction - nextEasedFraction;

                // Determine the current spin's duration using the incremental eased fraction
                double currentDuration = totalDuration * incrementalEasedFraction;

                // Perform the spin
                width *= -1;
                field.Resize(OsbEasing.InOutSine, currentTime, currentTime + currentDuration, width, height);

                double localCur = currentTime;

                if (width < 0)
                {
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, closest, ColumnType.one);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleFront, ColumnType.two);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleBack, ColumnType.three);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, furthest, ColumnType.four);

                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, closest, ColumnType.one);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleFront, ColumnType.two);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleBack, ColumnType.three);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, furthest, ColumnType.four);

                    localCur += currentDuration / 2;
                    field.ScaleReceptor(OsbEasing.OutSine, localCur, localCur + currentDuration / 2, scale, ColumnType.one);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.two);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.three);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.four);

                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.one);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.two);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.three);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.four);
                }

                if (width > 0)
                {
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, closest, ColumnType.four);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleFront, ColumnType.three);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleBack, ColumnType.two);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, furthest, ColumnType.one);

                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, closest, ColumnType.four);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleFront, ColumnType.three);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, middleBack, ColumnType.two);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, furthest, ColumnType.one);

                    localCur += currentDuration / 2;
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.four);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.three);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.two);
                    field.ScaleReceptor(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.one);

                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.four);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.three);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.two);
                    field.ScaleOrigin(OsbEasing.InSine, localCur, localCur + currentDuration / 2, scale, ColumnType.one);
                }

                // Increment the current time by the current duration
                currentTime += currentDuration;
            }

            field.Resize(OsbEasing.OutSine, currentTime, 42947, 200, height);

            double localDuration = 42947 - 42631;

            field.ScaleReceptor(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, closest, ColumnType.four);
            field.ScaleReceptor(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, middleFront, ColumnType.three);
            field.ScaleReceptor(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, middleBack, ColumnType.two);
            field.ScaleReceptor(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, furthest, ColumnType.one);

            field.ScaleOrigin(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, closest, ColumnType.four);
            field.ScaleOrigin(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, middleFront, ColumnType.three);
            field.ScaleOrigin(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, middleBack, ColumnType.two);
            field.ScaleOrigin(OsbEasing.InSine, currentTime, currentTime + localDuration / 2, furthest, ColumnType.one);

            currentTime += localDuration / 2;

            field.ScaleReceptor(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.four);
            field.ScaleReceptor(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.three);
            field.ScaleReceptor(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.two);
            field.ScaleReceptor(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.one);

            field.ScaleOrigin(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.four);
            field.ScaleOrigin(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.three);
            field.ScaleOrigin(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.two);
            field.ScaleOrigin(OsbEasing.OutSine, currentTime, currentTime + localDuration / 2, scale, ColumnType.one);

            field.Rotate(OsbEasing.OutElasticQuarter, 42947, 44210, Math.PI, CenterType.middle);
            field.Resize(OsbEasing.OutElasticHalf, 43578, 43894, 200, height);

            field.ScaleReceptor(OsbEasing.OutCubic, 44210, 54315, new Vector2(0.04f, 0.2f), ColumnType.one);
            field.ScaleReceptor(OsbEasing.OutCubic, 44210, 54315, new Vector2(0.2f, 0.04f), ColumnType.two);
            field.ScaleReceptor(OsbEasing.OutCubic, 44210, 54315, new Vector2(0.2f, 0.04f), ColumnType.three);
            field.ScaleReceptor(OsbEasing.OutCubic, 44210, 54315, new Vector2(0.04f, 0.2f), ColumnType.four);

            field.MoveReceptorRelative(OsbEasing.None, 44210, 54315, new Vector2(30, -200), ColumnType.one);
            field.MoveReceptorRelative(OsbEasing.None, 44210, 54315, new Vector2(10, -200), ColumnType.two);
            field.MoveReceptorRelative(OsbEasing.None, 44210, 54315, new Vector2(-10, -200), ColumnType.three);
            field.MoveReceptorRelative(OsbEasing.None, 44210, 54315, new Vector2(-30, -200), ColumnType.four);

            field.ScaleOrigin(OsbEasing.OutCubic, 44210, 54315, new Vector2(1f, .8f), ColumnType.one);
            field.ScaleOrigin(OsbEasing.OutCubic, 44210, 54315, new Vector2(.8f, 1f), ColumnType.two);
            field.ScaleOrigin(OsbEasing.OutCubic, 44210, 54315, new Vector2(.8f, 1f), ColumnType.three);
            field.ScaleOrigin(OsbEasing.OutCubic, 44210, 54315, new Vector2(1f, .8f), ColumnType.four);

            field.MoveOriginRelative(OsbEasing.None, 44210, 54315, new Vector2(-150, 125), ColumnType.one);
            field.MoveOriginRelative(OsbEasing.None, 44210, 54315, new Vector2(-100, 125), ColumnType.two);
            field.MoveOriginRelative(OsbEasing.None, 44210, 54315, new Vector2(100, 125), ColumnType.three);
            field.MoveOriginRelative(OsbEasing.None, 44210, 54315, new Vector2(150, 125), ColumnType.four);

            field.ScaleReceptor(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.00f, 0.0f), ColumnType.one);
            field.ScaleReceptor(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.0f, 0.00f), ColumnType.two);
            field.ScaleReceptor(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.0f, 0.00f), ColumnType.three);
            field.ScaleReceptor(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.00f, 0.0f), ColumnType.four);

            field.ScaleOrigin(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.0f, 0.0f), ColumnType.one);
            field.ScaleOrigin(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.0f, 0.0f), ColumnType.two);
            field.ScaleOrigin(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.0f, 0.0f), ColumnType.three);
            field.ScaleOrigin(OsbEasing.OutCirc, 54315, 55263, new Vector2(0.0f, 0.0f), ColumnType.four);

            TriggerScale(24004, 24473, -600);
            TriggerScale(26526, 27000, -600);
            TriggerScale(29052, 29526, 600);
            TriggerScale(31578, 32052, 600);
            TriggerScale(34105, 34578, -600);
            TriggerScale(36631, 37105, -600);
            TriggerScale(39157, 39631, 600);


            DrawInstance draw = new DrawInstance(field, starttime + 50, scrollSpeed, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeTime);
            draw.setHoldRotationPrecision(0f);
            draw.setHoldMovementPrecision(.5f);
            draw.setNoteRotationPrecision(0f);
            draw.setNoteMovementPrecision(.5f);
            //draw.setHoldScalePrecision(0f);
            draw.drawViaEquation(duration - 50, NoteFunction, true);
            // draw.drawViaEquation(duration, NoteFunction, true);

        }

        Vector2 NoteFunction(EquationParameters par)
        {

            float x = par.position.X;
            float y = par.position.Y;

            if (par.time >= 22736 && par.time <= 23684)
            {
                x += (float)Utility.TanValue((float)Utility.SmoothAmplitudeByTime(par.time, 22736, 23684, 0, 5), 20, par.progress);
            }

            else if (par.time >= 24631 && par.time <= 25263)
            {
                x -= Math.Max(-30, Math.Min(30, (float)Utility.SineWaveValue(100, 4f, par.progress)));
            }

            else if (par.time >= 27315 && par.time <= 27473)
            {
                x += (float)Utility.TanValue(15, 1.5, par.progress);
            }

            else if (par.time >= 29684 && par.time <= 30157)
            {
                x -= Math.Max(-30, Math.Min(30, (float)Utility.SineWaveValue(100, 4f, par.progress)));
            }
            else if (par.time >= 32368 && par.time <= 32605)
            {
                x += (float)Utility.TanValue(15, 1.5, par.progress);
            }

            if ((par.time >= 28263 && par.time <= 29052) || (par.time >= 38447 && par.time <= 39157))
            {

                x += (float)Utility.SineWaveValue(25, 1, par.progress);

            }

            if (par.time >= 34263 && par.time <= 36236)
            {

                switch (par.column.type)
                {
                    case ColumnType.one:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, 40, 40), 1, par.progress);
                        break;
                    case ColumnType.two:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, 40, 40), 1, par.progress);
                        break;
                }
            }

            if (par.time >= 34263 && par.time <= 36394)
            {

                switch (par.column.type)
                {
                    case ColumnType.three:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, -40, -40), 1, par.progress);
                        break;
                    case ColumnType.four:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, -40, -40), 1, par.progress);
                        break;
                }
            }

            if (par.time >= 36631 && par.time <= 37894)
            {

                switch (par.column.type)
                {
                    case ColumnType.one:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, 25, 25), 1, par.progress);
                        break;
                    case ColumnType.two:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, 25, 25), 1, par.progress);
                        break;
                }
            }

            if (par.time >= 36631 && par.time <= 37894)
            {

                switch (par.column.type)
                {
                    case ColumnType.three:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, -25, -25), 1, par.progress);
                        break;
                    case ColumnType.four:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 34263, 34263 + 1000, 0, -25, -25), 1, par.progress);
                        break;
                }
            }

            if (par.time >= 39473 && par.time <= 41289)
            {
                switch (par.column.type)
                {
                    case ColumnType.one:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 39473, 41289, -20, -250), .5, par.progress);
                        break;
                    case ColumnType.two:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 39473, 41289, -10, -100), .5, par.progress);
                        break;
                }
            }

            if (par.time >= 39473 && par.time <= 41447)
            {
                switch (par.column.type)
                {
                    case ColumnType.three:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 39473, 41447, 10, 100), .5, par.progress);
                        break;
                    case ColumnType.four:
                        x -= (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 39473, 41447, 20, 250), .5, par.progress);
                        break;
                }
            }

            if (par.time >= 44210)
            {
                switch (par.column.type)
                {
                    case ColumnType.one:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, -50), .5, par.progress);
                        y += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, 50), .5, par.progress);
                        break;
                    case ColumnType.two:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, -25), .5, par.progress);
                        y += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, 50), .5, par.progress);
                        break;
                    case ColumnType.three:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, 25), .5, par.progress);
                        y += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, 50), .5, par.progress);
                        break;
                    case ColumnType.four:
                        x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, 50), .5, par.progress);
                        y += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByTime(par.time, 44210, 55263, 0, 50), .5, par.progress);
                        break;
                }
            }

            return new Vector2(x, y);

        }

        public void TriggerScale(double start, double end, float move)
        {
            global.MoveOriginRelative(OsbEasing.OutCirc, start, start + 100, new Vector2(0, move), ColumnType.all);
            global.Scale(OsbEasing.OutCirc, start, start + 100, new Vector2(1f, 1f));

            global.MoveOriginRelative(OsbEasing.OutCirc, end, end + 100, new Vector2(0, -move), ColumnType.all);
            global.Scale(OsbEasing.OutCirc, end, end + 100, new Vector2(0.4f, 0.4f));
        }

        public void kick(OsbEasing easing, double start, double end, float move)
        {
            global.MoveReceptorRelative(easing, start, end, new Vector2(move, 0), ColumnType.all);
            global.MoveOriginRelative(easing, start, end, new Vector2(-move, 0), ColumnType.all);
        }

    }
}
