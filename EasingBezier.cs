using System;

namespace Utility
{
	public class EasingBezier
	{
		public EasingBezier(float x1, float y1, float x2, float y2)
		{
			_ax = A(x1, x2);
			_bx = B(x1, x2);
			_cx = C(x1);

			_ay = A(y1, y2);
			_by = B(y1, y2);
			_cy = C(y1);

			CalcSampleValues();
		}

		private static EasingBezier _linear;
		public static EasingBezier Linear => _linear ?? (_linear = new EasingBezier(0.0f, 0.0f, 1.0f, 1.0f));

		private static EasingBezier _easeInSin;
		public static EasingBezier EaseInSin => _easeInSin ?? (_easeInSin = new EasingBezier(0.12f, 0.0f, 0.39f, 0.0f));
		private static EasingBezier _easeInCubic;
		public static EasingBezier EaseInCubic => _easeInCubic ?? (_easeInCubic = new EasingBezier(0.32f, 0.0f, 0.67f, 0.0f));
		private static EasingBezier _easeInQuint;
		public static EasingBezier EaseInQuint => _easeInQuint ?? (_easeInQuint = new EasingBezier(0.64f, 0.0f, 0.78f, 0.0f));
		private static EasingBezier _easeInCirc;
		public static EasingBezier EaseInCirc => _easeInCirc ?? (_easeInCirc = new EasingBezier(0.55f, 0.0f, 1.0f, 0.45f));

		private static EasingBezier _easeOutSine;
		public static EasingBezier EaseOutSine => _easeOutSine ?? (_easeOutSine = new EasingBezier(0.61f, 1.0f, 0.88f, 1.0f));
		private static EasingBezier _easeOutCubic;
		public static EasingBezier EaseOutCubic => _easeOutCubic ?? (_easeOutCubic = new EasingBezier(0.33f, 1.0f, 0.68f, 1.0f));
		private static EasingBezier _easeOutQuint;
		public static EasingBezier EaseOutQuint => _easeOutQuint ?? (_easeOutQuint = new EasingBezier(0.22f, 1.0f, 0.36f, 1.0f));
		private static EasingBezier _easeOutCirc;
		public static EasingBezier EaseOutCirc => _easeOutCirc ?? (_easeOutCirc = new EasingBezier(0.0f, 0.55f, 0.45f, 1.0f));

		private static EasingBezier _easeInOutSine;

		public static EasingBezier EaseInOutSine =>
			_easeInOutSine ?? (_easeInOutSine = new EasingBezier(0.37f, 0.0f, 0.63f, 1.0f));

		private static EasingBezier _easeInOutCubic;

		public static EasingBezier EaseInOutCubic =>
			_easeInOutCubic ?? (_easeInOutCubic = new EasingBezier(0.65f, 0.0f, 0.35f, 1.0f));

		private static EasingBezier _easeInOutQuint;

		public static EasingBezier EaseInOutQuint =>
			_easeInOutQuint ?? (_easeInOutQuint = new EasingBezier(0.83f, 0.0f, 0.17f, 1.0f));

		private static EasingBezier _easeInOutCirc;

		public static EasingBezier EaseInOutCirc =>
			_easeInOutCirc ?? (_easeInOutCirc = new EasingBezier(0.85f, 0.0f, 0.15f, 1.0f));

		private static EasingBezier _easeInQuad;
		public static EasingBezier EaseInQuad => _easeInQuad ?? (_easeInQuad = new EasingBezier(0.11f, 0.0f, 0.5f, 0.0f));
		private static EasingBezier _easeInQuart;
		public static EasingBezier EaseInQuart => _easeInQuart ?? (_easeInQuart = new EasingBezier(0.5f, 0.0f, 0.75f, 0.0f));
		private static EasingBezier _easeInExpo;
		public static EasingBezier EaseInExpo => _easeInExpo ?? (_easeInExpo = new EasingBezier(0.7f, 0.0f, 0.84f, 0.0f));
		private static EasingBezier _easeInBack;
		public static EasingBezier EaseInBack => _easeInBack ?? (_easeInBack = new EasingBezier(0.36f, 0.0f, 0.66f, -0.56f));

		private static EasingBezier _easeOutQuad;
		public static EasingBezier EaseOutQuad => _easeOutQuad ?? (_easeOutQuad = new EasingBezier(0.5f, 1.0f, 0.89f, 1.0f));
		private static EasingBezier _easeOutQuart;
		public static EasingBezier EaseOutQuart => _easeOutQuart ?? (_easeOutQuart = new EasingBezier(0.25f, 1.0f, 0.5f, 1.0f));
		private static EasingBezier _easeOutExpo;
		public static EasingBezier EaseOutExpo => _easeOutExpo ?? (_easeOutExpo = new EasingBezier(0.16f, 1.0f, 0.3f, 1.0f));
		private static EasingBezier _easeOutBack;
		public static EasingBezier EaseOutBack => _easeOutBack ?? (_easeOutBack = new EasingBezier(0.34f, 1.56f, 0.64f, 1.0f));

		private static EasingBezier _easeInOutQuad;

		public static EasingBezier EaseInOutQuad =>
			_easeInOutQuad ?? (_easeInOutQuad = new EasingBezier(0.45f, 0.0f, 0.55f, 1.0f));

		private static EasingBezier _easeInOutQuart;

		public static EasingBezier EaseInOutQuart =>
			_easeInOutQuart ?? (_easeInOutQuart = new EasingBezier(0.76f, 0.0f, 0.24f, 1.0f));

		private static EasingBezier _easeInOutExpo;

		public static EasingBezier EaseInOutExpo =>
			_easeInOutExpo ?? (_easeInOutExpo = new EasingBezier(0.87f, 0.0f, 0.13f, 1.0f));

		private static EasingBezier _easeInOutBack;

		public static EasingBezier EaseInOutBack =>
			_easeInOutBack ?? (_easeInOutBack = new EasingBezier(0.68f, -0.6f, 0.32f, 1.6f));

		private const int _newtonIterations = 4;
		private const float _newtonMinSlope = 0.02f;
		private const float _subdivisionPrecision = 0.0000001f;
		private const int _subdivisionMaxIterations = 10;
		private const int _kSplineTableSize = 11;
		private const float _kSampleStepSize = 1.0f / (_kSplineTableSize - 1);

		private readonly float[] _mSampleValues = new float[_kSplineTableSize];

		private readonly float _ax;
		private readonly float _bx;
		private readonly float _cx;

		private readonly float _ay;
		private readonly float _by;
		private readonly float _cy;

		public float Get(float x)
		{
			return CalcBezierY(GetTForX(x));
		}

		private static float A(float v1, float v2) => 1.0f - 3.0f * v2 + 3.0f * v1;
		private static float B(float v1, float v2) => 3.0f * v2 - 6.0f * v1;
		private static float C(float v1) => 3.0f * v1;

		private static bool Approximately(float a, float b)
		{
			return Math.Abs(b - a) < _subdivisionPrecision;
		}

		private void CalcSampleValues()
		{
			for (var i = 0; i < _kSplineTableSize; ++i)
			{
				_mSampleValues[i] = CalcBezierX(i * _kSampleStepSize);
			}
		}

		private float CalcBezierX(float t)
		{
			// use Horner's scheme to evaluate the Bezier polynomial
			return ((_ax * t + _bx) * t + _cx) * t;
		}

		private float CalcBezierY(float t)
		{
			// use Horner's scheme to evaluate the Bezier polynomial
			return ((_ay * t + _by) * t + _cy) * t;
		}

		private float GetSlope(float t)
		{
			return 3.0f * _ax * t * t + 2.0f * _bx * t + _cx;
		}

		private float GetTForX(float x)
		{
			// Early return when x == 1.0 to avoid floating-point inaccuracies.
			if (Approximately(x, 1.0f))
			{
				return 1.0f;
			}

			// Find interval where t lies
			var intervalStart = 0.0f;
			var currentSample = 1;
			const int lastSample = _kSplineTableSize - 1;
			for (; currentSample != lastSample && _mSampleValues[currentSample] <= x; ++currentSample)
			{
				intervalStart += _kSampleStepSize;
			}

			--currentSample; // t now lies between currentSample and currentSample+1

			// Interpolate to provide an initial guess for t
			var dist = (x - _mSampleValues[currentSample]) /
			           (_mSampleValues[currentSample + 1] - _mSampleValues[currentSample]);
			var guessForT = intervalStart + dist * _kSampleStepSize;

			// Check the slope to see what strategy to use. If the slope is too small
			// Newton-Raphson iteration won't converge on a root so we use bisection
			// instead.

			var initialSlope = GetSlope(guessForT);

			if (initialSlope >= _newtonMinSlope)
				return NewtonRaphsonIterate(x, guessForT);

			if (Approximately(initialSlope, 0.0f))
				return guessForT;

			return BinarySubdivide(x, intervalStart, intervalStart + _kSampleStepSize);
		}

		private float NewtonRaphsonIterate(float x, float guessT)
		{
			// Refine guess with Newton-Raphson iteration
			for (var i = 0; i < _newtonIterations; ++i)
			{
				// We're trying to find where f(t) = x,
				// so we're actually looking for a root for: CalcBezier(t) - x
				var currentX = CalcBezierX(guessT) - x;
				var currentSlope = GetSlope(guessT);

				if (Approximately(currentSlope, 0.0f))
					return guessT;

				guessT -= currentX / currentSlope;
			}

			return guessT;
		}

		private float BinarySubdivide(float x, float start, float end)
		{
			float currentX;
			float currentT;
			var i = 0;

			do
			{
				currentT = start + (end - start) / 2.0f;

				currentX = CalcBezierX(currentT) - x;

				if (currentX > 0.0)
				{
					end = currentT;
				}
				else
				{
					start = currentT;
				}
			} while (Math.Abs(currentX) > _subdivisionPrecision &&
			         ++i < _subdivisionMaxIterations);

			return currentT;
		}
	}
}