using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Drawing;
using AForge.Vision.Motion;

namespace VideoSurveillance
{

    class MotionSensor
    {
        private readonly MotionDetector motionDetector;
        private readonly BlockingCollection<Motion> motionLevels;

        MotionSensor()
        {
            var detectionAlgorithm = new TwoFramesDifferenceDetector(true);
            var processingAlgorithm = new MotionAreaHighlighting();
            motionDetector = new MotionDetector(detectionAlgorithm, processingAlgorithm);

            motionLevels = new BlockingCollection<Motion>(new ConcurrentQueue<Motion>());
        }

        public void AddNewFrame(Bitmap frame)
        {
            var motionLevel = motionDetector.ProcessFrame(frame);
            motionLevels.Add(new Motion(motionLevel, DateTime.Now));
        }

        public void Reset()
        {
            motionDetector.Reset();
            while (motionLevels.Count > 0) { motionLevels.Take(); }
        }

        float CurrentMotionLevel
        {
            get { return 1.0f; }
        }
    }
}
