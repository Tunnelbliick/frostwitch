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
    public class Dpad : StoryboardObjectGenerator
    {

        public override bool Multithreaded => true;

        double sliderAccuracy = 25;

        public override void Generate()
        {

            var receptors = GetLayer("rlow");
            var notes = GetLayer("nlow");

            // General values
            var starttime = 54000;
            var endtime = 64421;
            var duration = endtime - starttime;

            // Playfield Scale
            var width = 200f;
            var height = 600;

            // Note initilization Values
            var bpm = 190f;
            var offset = 0f;

            // Drawinstance Values
            var updatesPerSecond = 20;
            var scrollSpeed = 1800f;
            var rotateNotesToFaceReceptor = false;
            var fadeTime = 60;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            Playfield field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, 0, 1, 50);
            field.noteEnd = 65684;
            field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);

            field.moveFieldY(OsbEasing.None, starttime, starttime, 190);

            field.RotateColumn(OsbEasing.None, starttime + 10, starttime + 10, Math.PI / 2, ColumnType.one, CenterType.receptor);
            field.RotateColumn(OsbEasing.None, starttime + 10, starttime + 10, 0, ColumnType.two, CenterType.receptor);
            field.RotateColumn(OsbEasing.None, starttime + 10, starttime + 10, Math.PI, ColumnType.three, CenterType.receptor);
            field.RotateColumn(OsbEasing.None, starttime + 10, starttime + 10, -Math.PI / 2, ColumnType.four, CenterType.receptor);

            field.Scale(OsbEasing.OutSine, starttime + 30, starttime + 30, new Vector2(0.001f, 0.001f), true);
            field.Scale(OsbEasing.OutSine, 54315, 55555, new Vector2(0.5f, 0.5f), true);

            field.MoveOriginRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(-600, 0), ColumnType.one);
            field.MoveOriginRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(0, 600), ColumnType.two);
            field.MoveOriginRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(0, -600), ColumnType.three);
            field.MoveOriginRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(600, 0), ColumnType.four);

            field.MoveReceptorRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(-50, 0), ColumnType.one);
            field.MoveReceptorRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(0, 50), ColumnType.two);
            field.MoveReceptorRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(0, -50), ColumnType.three);
            field.MoveReceptorRelative(OsbEasing.OutSine, 54314, 54314, new Vector2(50, 0), ColumnType.four);

            field.Rotate(OsbEasing.None, 54315, 63157, 2.2, CenterType.middle);

            float x = field.calculateOffset(250) + field.getColumnWidth(250) / 2;
            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 63157, 64421, new Vector2(x, 50), ColumnType.one);
            field.MoveOriginAbsolute(OsbEasing.OutCirc, 63158, 64421, new Vector2(x, 1200), ColumnType.one);
            x += field.getColumnWidth(250);
            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 63157, 64421, new Vector2(x, 50), ColumnType.two);
            field.MoveOriginAbsolute(OsbEasing.OutCirc, 63158, 64421, new Vector2(x, 1200), ColumnType.two);
            x += field.getColumnWidth(250);
            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 63157, 64421, new Vector2(x, 50), ColumnType.three);
            field.MoveOriginAbsolute(OsbEasing.OutCirc, 63158, 64421, new Vector2(x, 1200), ColumnType.three);
            x += field.getColumnWidth(250);
            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 63157, 64421, new Vector2(x, 50), ColumnType.four);
            field.MoveOriginAbsolute(OsbEasing.OutCirc, 63158, 64421, new Vector2(x, 1200), ColumnType.four);

            field.RotateReceptorRelative(OsbEasing.OutCirc, 63157, 64421, Math.PI * 4, ColumnType.all);
            field.Resize(OsbEasing.OutCirc, 63157, 64421, 200, height);
            field.Scale(OsbEasing.OutCirc, 63157, 63157, new Vector2(0.4f,0.4f), true);

            DrawInstance draw = new DrawInstance(field, 54315, 2500f, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeTime);
            draw.setHoldRotationPrecision(0f);
            draw.setHoldMovementPrecision(0f);
            draw.setNoteMovementPrecision(0f);
            draw.setHoldScalePrecision(0f);
            draw.setNoteRotationPrecision(0f);
            draw.drawViaEquation(endtime - 54315, NoteFunction, true);

        }

        Vector2 NoteFunction(EquationParameters par)
        {

            if (par.time < 63157)
            {

                // Define the 'from' and 'to' vectors based on your image
                Vector2 from = par.column.OriginPositionAt(par.time);
                Vector2 to = par.column.ReceptorPositionAt(par.time);

                // Calculate the 'from-to' vector
                Vector2 fromToVector = to - from;

                // Normalize the 'from-to' vector to get the new x-axis
                Vector2 new_x_axis = Vector2.Normalize(fromToVector);

                // Get the perpendicular vector for the new y-axis
                Vector2 new_y_axis = new Vector2(-new_x_axis.Y, new_x_axis.X);

                // Decompose par's position into the new coordinate system
                Vector2 par_position = new Vector2(par.position.X, par.position.Y);

                // Ensure the origin is translated to 'from'
                par_position -= from;

                float x_relative = Vector2.Dot(par_position, new_x_axis);
                float y_relative = Vector2.Dot(par_position, new_y_axis);

                // Apply your original logic in terms of the relative coordinate system
                // Ensure that Utility.CosWaveValue does not return NaN
                float cosWaveValue = (float)Utility.SineWaveValue(50, 1, par.progress);
                if (float.IsNaN(cosWaveValue))
                {
                    // Handle the NaN case, perhaps default to 0 or some other value
                    cosWaveValue = 0;
                }

                y_relative += cosWaveValue;

                // Convert back to the original coordinate system if needed
                Vector2 final_position = from + x_relative * new_x_axis + y_relative * new_y_axis;

                // Ensure the final result is not NaN
                if (float.IsNaN(final_position.X) || float.IsNaN(final_position.Y))
                {
                    // Handle the NaN case, perhaps default to 'from' or some other value
                    final_position = from;
                }

                return final_position;
            }

            return par.position;

        }
    }
}
