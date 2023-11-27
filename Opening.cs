using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Commands;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Opening : StoryboardObjectGenerator
    {

        public override bool Multithreaded => true;

        public Playfield global;

        double sliderAccuracy = 25;
        public override void Generate()
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            // General values
            var starttime = 0;
            var endtime = 23684;
            var duration = endtime - starttime;

            // Playfield Scale
            var width = 200f;
            var height = 600;

            // Note initilization Values
            var bpm = 190f;
            var offset = 0f;

            // Drawinstance Values
            var updatesPerSecond = 40;
            var scrollSpeed = 1800f;
            var rotateNotesToFaceReceptor = false;
            var fadeTime = 60;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            Playfield field2 = new Playfield();
            field2.initilizePlayField(receptors, notes, 13421, 22736, 250f, height, 50);
            field2.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);

            field2.Scale(OsbEasing.None, 13421 + 2, 13421 + 2, new Vector2(0.4f, 0.4f));

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, width, height, 50);
            field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);

            global = field;

            field.Scale(OsbEasing.None, starttime + 1, starttime + 1, new Vector2(0.4f), true, CenterType.receptor);

            field.RotateReceptorRelative(OsbEasing.OutSine, 1263, 3157, Math.PI * 8 + 1.3);
            field.RotateReceptorRelative(OsbEasing.OutCirc, 3157, 3789, -1.3);

            field.MoveOriginRelative(OsbEasing.None, starttime + 3, starttime + 3, new Vector2(0, -800), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, starttime + 3, starttime + 3, new Vector2(0, -100), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 1263, 3157, new Vector2(0, 250), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 3157, 3789, new Vector2(0, -150), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.InOutSine, 1894, 3789, new Vector2(0, 800), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 13578, 13578 + 250, new Vector2(0, 100), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.OutCirc, 3789, 3789 + 100, new Vector2(0, 600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 3789, 3789 + 100, new Vector2(1f, 1f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 4263, 4263, new Vector2(0, -600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 4263, 4263, new Vector2(0.4f, 0.4f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 6315, 6315 + 100, new Vector2(0, 600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 6315, 6315 + 100, new Vector2(1f, 1f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 6789, 6789, new Vector2(0, -600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 6789, 6789, new Vector2(0.4f, 0.4f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 8842, 8842 + 100, new Vector2(0, 600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 8842, 8842 + 100, new Vector2(1f, 1f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 9315, 9315, new Vector2(0, -600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 9315, 9315, new Vector2(0.4f, 0.4f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 11368, 11368 + 100, new Vector2(0, 600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 11368, 11368 + 100, new Vector2(1f, 1f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 11842, 11842, new Vector2(0, -600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 11842, 11842, new Vector2(0.4f, 0.4f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 12631, 12631 + 100, new Vector2(0, 600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 12631, 12631 + 100, new Vector2(1f, 1f));

            field.MoveOriginRelative(OsbEasing.OutCirc, 13105, 13105, new Vector2(0, -600), ColumnType.all);
            field.Scale(OsbEasing.OutCirc, 13105, 13105, new Vector2(0.4f, 0.4f));

            field.MoveOriginRelative(OsbEasing.OutSine, 13105, 13105, new Vector2(0, 100), ColumnType.all);


            // 1
            field.moveFieldY(OsbEasing.OutSine, 13894, 14210, 20);
            field.moveFieldY(OsbEasing.InSine, 14210, 15157, -20);
            field2.moveFieldY(OsbEasing.OutSine, 13894, 14210, -20);
            field2.moveFieldY(OsbEasing.InSine, 14210, 15157, 20);
            field2.Scale(OsbEasing.OutSine, 13894, 14210, new Vector2(0.3f, 0.3f));
            field2.Scale(OsbEasing.InSine, 14210, 15157, new Vector2(0.4f, 0.4f));
            field.Scale(OsbEasing.OutSine, 13894, 14210, new Vector2(0.5f, 0.5f));
            field.Scale(OsbEasing.InSine, 14210, 15157, new Vector2(0.4f, 0.4f));

            // 2
            field.moveFieldY(OsbEasing.OutSine, 15157, 15789, -20);
            field.moveFieldY(OsbEasing.InSine, 15789, 16421, 20);
            field2.moveFieldY(OsbEasing.OutSine, 15157, 15789, 20);
            field2.moveFieldY(OsbEasing.InSine, 15789, 16421, -20);
            field.Scale(OsbEasing.OutSine, 15157, 15789, new Vector2(0.3f, 0.3f));
            field.Scale(OsbEasing.InSine, 15789, 16421, new Vector2(0.4f, 0.4f));

            field2.Scale(OsbEasing.OutSine, 15157, 15789, new Vector2(0.5f, 0.5f));
            field2.Scale(OsbEasing.InSine, 15789, 16421, new Vector2(0.4f, 0.4f));

            // 3
            field.moveFieldY(OsbEasing.OutSine, 16421, 17052, 20);
            field.moveFieldY(OsbEasing.InSine, 17052, 17684, -20);
            field2.moveFieldY(OsbEasing.OutSine, 16421, 17052, -20);
            field2.moveFieldY(OsbEasing.InSine, 17052, 17684, 20);
            field.Scale(OsbEasing.OutSine, 16421, 17052, new Vector2(0.5f, 0.5f));
            field.Scale(OsbEasing.InSine, 17052, 17684, new Vector2(0.4f, 0.4f));
            field2.Scale(OsbEasing.OutSine, 16421, 17052, new Vector2(0.3f, 0.3f));
            field2.Scale(OsbEasing.InSine, 17052, 17684, new Vector2(0.4f, 0.4f));

            // 4
            field.Scale(OsbEasing.OutSine, 17684, 18157, new Vector2(0.3f, 0.3f));
            field.Scale(OsbEasing.InSine, 18157, 18632, new Vector2(0.4f, 0.4f));
            field2.Scale(OsbEasing.OutSine, 17684, 18157, new Vector2(0.5f, 0.5f));
            field2.Scale(OsbEasing.InSine, 18157, 18632, new Vector2(0.4f, 0.4f));
            field.moveFieldY(OsbEasing.OutSine, 17684, 18157, -20);
            field.moveFieldY(OsbEasing.InSine, 18157, 18632, 20);
            field2.moveFieldY(OsbEasing.OutSine, 17684, 18157, 20);
            field2.moveFieldY(OsbEasing.InSine, 18157, 18632, -20);

            field.moveFieldX(OsbEasing.OutSine, 13894, 15157, 200);
            field.moveFieldX(OsbEasing.InOutSine, 15157, 16421, -400);
            field.moveFieldX(OsbEasing.InOutSine, 16421, 17684, 400);
            field.moveFieldX(OsbEasing.InOutSine, 17684, 18631, -400);
            field.moveFieldX(OsbEasing.OutCirc, 18631, 18947, 200);

            field2.moveFieldX(OsbEasing.OutSine, 13894, 15157, -200);
            field2.moveFieldX(OsbEasing.InOutSine, 15157, 16421, 400);
            field2.moveFieldX(OsbEasing.InOutSine, 16421, 17684, -400);
            field2.moveFieldX(OsbEasing.InOutSine, 17684, 18631, 400);
            field2.moveFieldX(OsbEasing.OutCirc, 18631, 18947, -200);

            double interval = 14210 - 13894;
            double currentTime = 13736;

            while (currentTime < 18947 - interval)
            {
                field.moveFieldY(OsbEasing.InCirc, currentTime, currentTime + interval / 2, 20);
                field.moveFieldY(OsbEasing.OutCirc, currentTime + interval / 2, currentTime + interval, -20);

                field2.moveFieldY(OsbEasing.InCirc, currentTime, currentTime + interval / 2, 20);
                field2.moveFieldY(OsbEasing.OutCirc, currentTime + interval / 2, currentTime + interval, -20);

                currentTime += interval;
            }

            var closest = new Vector2(0.6f, 0.6f);
            var middleFront = new Vector2(0.5f, 0.5f);
            var middleBack = new Vector2(0.3f, 0.3f);
            var furthest = new Vector2(0.2f, 0.2f);

            var scale = new Vector2(.4f, .4f);

            double endTime = 21473; // fixed end time
            int totalSpins = 9; // total amount of spins desired
            currentTime = 19000; // start time
            width = 200; // initial width
            double totalDuration = endTime - currentTime; // total duration for all spins

            for (int spin = 0; spin < totalSpins; spin++)
            {
                double fraction = (double)(spin + 1) / totalSpins;
                double easedFraction = 1 - Math.Cos(fraction * Math.PI / 2);

                // Calculate the current spin's duration based on the eased fraction
                // We subtract the sum of previous eased fractions from the current eased fraction to find the incremental eased duration
                double previousFraction = spin > 0 ? 1 - Math.Cos((fraction - 1.0 / totalSpins) * Math.PI / 2) : 0;
                double incrementalEasedFraction = easedFraction - previousFraction;

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

            // Make sure we don't exceed the end time in the last spin due to rounding errors
            if (currentTime > endTime)
            {
                currentTime = endTime;
            }


            field.Rotate(OsbEasing.OutCirc, 18947, 22736, Math.PI * 5, CenterType.middle);

            currentTime = 21473;
            double localDuration = 22572 - currentTime;
            field.Resize(OsbEasing.InOutSine, currentTime, 22736, 200, height);

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

            //field.MoveOriginRelative(OsbEasing.OutSine, currentTime, 22736, new Vector2(0, 200), ColumnType.all);


            // All effects have to be executed before calling the draw Function.
            // Anything that is done after the draw Function call will not be rendered out.

            DrawInstance draw = new DrawInstance(field, starttime, scrollSpeed, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeTime);
            draw.setHoldRotationPrecision(0f);
            draw.setHoldMovementPrecision(0f);
            draw.setHoldScalePrecision(0f);
            watch.Start();
            draw.noteScaleEasing = OsbEasing.InSine;
            draw.drawViaEquation(22950 - starttime, NoteFunction, true);
            // draw.drawViaEquation(duration, NoteFunction, true);

            DrawInstance draw2 = new DrawInstance(field2, 13894, 1350f, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeTime);
            draw2.setHoldRotationPrecision(0f);
            draw2.setHoldMovementPrecision(0f);
            draw.setHoldScalePrecision(0f);
            draw2.drawViaEquation(18947 - 13894, NoteFunction, true);

            watch.Stop();
            Log(watch.Elapsed);

        }

        double freq = 0;
        double max = 300;
        double min = 150;

        Vector2 NoteFunction(EquationParameters par)
        {

            float y = par.position.Y;
            float x = par.position.X;

            if (par.time <= 13894)
            {
                double currentAmplitude = max;

                // If within the first time range
                if (par.time >= 2526 && par.time <= 3789)
                {
                    double start = 2526;
                    double end = 3789;  // Ending before the second segment starts

                    // Calculate progress in the range of [0, 1]
                    double progress = (par.time - start) / (end - start);

                    // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                    double startAmplitude = min;
                    double endAmplitude = max;
                    currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);
                }

                // If within the first time range
                if (par.time >= 13578 && par.time <= 13894)
                {
                    double start = 13578;
                    double end = 13894;  // Ending before the second segment starts

                    // Calculate progress in the range of [0, 1]
                    double progress = (par.time - start) / (end - start);

                    // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                    double startAmplitude = max;
                    double endAmplitude = 0;
                    currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);
                }

                if (par.time >= 13894)
                    currentAmplitude = 0;

                Vector2 scale = par.column.receptor.ScaleAt(par.time);

                double scaleAmplitudeX = scale.X;

                double progressStart = 0.6;
                double progressEnd = 0.8;

                if (par.progress > progressStart && par.progress < progressEnd)
                {
                    double remappedProgress = (par.progress - progressStart) / (progressEnd - progressStart);

                    // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                    double starScale = scale.X;
                    double endScale = 0;
                    scaleAmplitudeX = starScale + remappedProgress * (endScale - starScale);
                }

                if (par.progress > progressEnd)
                {
                    scaleAmplitudeX = 0;
                }

                // If within the first time range
                if (par.time >= 13578 && par.time <= 13894)
                {
                    double start = 13578;
                    double end = 13894;  // Ending before the second segment starts

                    // Calculate progress in the range of [0, 1]
                    double progress = (par.time - start) / (end - start);

                    // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                    double startAmplitude = scale.X;
                    double endAmplitude = 0;
                    scaleAmplitudeX = startAmplitude + progress * (endAmplitude - startAmplitude);
                }


                float increase;
                if (par.progress <= .5f)
                {
                    increase = Utility.SmoothAmplitudeByProgress(par.progress, .25f, .5f, 0, .2);
                }
                else if (par.progress >= .5f && par.progress < .6f)
                {
                    increase = Utility.SmoothAmplitudeByProgress(par.progress, .5f, .6f, 0.2, -.1);
                }
                else
                {
                    increase = Utility.SmoothAmplitudeByProgress(par.progress, .6f, 1f, -0.1, 0);
                }

                Vector2 currentScale;
                float xVal = (float)Utility.SineWaveValue(scaleAmplitudeX, 2, par.progress);

                if (par.isHoldBody == false)
                {

                    if (par.column.type == ColumnType.one || par.column.type == ColumnType.four)
                        currentScale = new Vector2(scale.X + increase, scale.Y - Math.Abs(xVal) + increase);
                    else
                        currentScale = new Vector2(scale.X - Math.Abs(xVal) + increase, scale.Y + increase);

                    par.sprite.ScaleVec(par.time, currentScale);
                }

                if (par.isHoldBody && par.sprite != null)
                {

                    double difference = par.part.Timestamp - par.note.starttime;
                    double relativeTime = par.time - difference;

                    currentScale = par.note.ScaleAt(relativeTime);

                    if (par.time >= par.note.starttime)
                    {
                        currentScale = par.column.receptor.ScaleAt(par.time);
                    }

                    float defaultScaleX = 0.7f / 0.5f;
                    float defaultScaleY = 0.14f / 0.5f * ((float)sliderAccuracy / 20f); // This scaled was based on 20ms long sliderParts

                    if (par.column.type == ColumnType.one || par.column.type == ColumnType.four)
                        par.sprite.ScaleVec(par.time, new Vector2(defaultScaleX * currentScale.Y, defaultScaleY * currentScale.X));
                    else
                        par.sprite.ScaleVec(par.time, new Vector2(defaultScaleX * currentScale.X, defaultScaleY * currentScale.Y));

                }

                x += (float)Utility.SineWaveValue(Utility.SmoothAmplitudeByProgress(par.progress, 0f, 0.75f, currentAmplitude, 0, 0), 2, par.progress);
            }

            if (par.time >= 13894 && par.time <= 16421)
            {
                if (par.isHoldBody == false)
                {
                    par.sprite.ScaleVec(par.time, new Vector2(0.4f, 0.4f));
                }
            }

            if (par.time >= 22736 && par.time <= 23684)
            {
                x += (float)Utility.TanValue((float)Utility.SmoothAmplitudeByTime(par.time, 22736, 23684, 0, 5), 20, -par.progress);
            }

            return new Vector2(x, y);
        }
    }
}
