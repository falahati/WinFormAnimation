						          WinForm Animation Library
		    A simple library for animating controls/values in .Net
        WinForm (.Net 3.5 and later). 

=========================================================================

USAGE
	Use the  three  'Animator',  'Animator2D' and  'Animator3D' classes  to
  start an animation.

SAMPLE ON ONE DIMENSIONAL ANIMATION OF A PROPERTY
  new Animator(new Path(0, 100, 5000))
    .Play(pb_progress, Animator.KnownProperties.Value);

SAMPLE ON TWO DIMENSIONAL ANIMATION OF A PROPERTY
  new Animator2D(
      new Path2D(0, 100, -100, 200, 5000)
      .ContinueTo(this.Location.ToFloat2D(), 2000, 3000))
    .Play(this, Animator2D.KnownProperties.Location);

SAMPLE ON THREE DIMENSIONAL ANIMATION OF A PROPERTY
  new Animator3D(
      new Path3D(
                Color.Blue.ToFloat3D(), 
                Color.Red.ToFloat3D(), 
                2000, 1000, 
                AnimationFunctions.CubicEaseIn), 
      FPSLimiterKnownValues.LimitTen)
    .Play(c_customLabel, "CustomColor");

MORE SAMPLES:
  Check the Project's Github page at: 
              https://github.com/falahati/WinFormAnimation