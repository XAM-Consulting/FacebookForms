using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace FBPlay
{
    public class InstrumentedGrid : Grid
    {
        static int _counter = 0;
        static int _constructorCount = 0;

        public InstrumentedGrid()
        {
            _constructorCount++;
            //Debug.WriteLine("Constructor " + _constructorCount);
        }

        protected override void OnChildMeasureInvalidated()
        {
            base.OnChildMeasureInvalidated();

            //_counter++;

            //Debug.WriteLine("Child measure invalidated");
        }

        bool done = false;
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            //if (done)
            //{
            //    return;
            //}
            //done = true;

            base.LayoutChildren(x, y, width, height);

            _counter++;

            //Debug.WriteLine("Layout Grid Children " + _counter + " " + _constructorCount);
        }

        protected override bool ShouldInvalidateOnChildAdded(View child)
        {
            return false;
        }

        protected override bool ShouldInvalidateOnChildRemoved(View child)
        {
            return false;
        }
    }
}
