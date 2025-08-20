using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watermelon
{

    // Path Module v1.0.0

    public static class Mantel
    {
        public static Vector3 EndeavorRenewable(Vector3 a, Vector3 b, Vector3 c, float t)
        {
            Vector3 p0 = Vector3.Lerp(a, b, t);
            Vector3 p1 = Vector3.Lerp(b, c, t);
            return Vector3.Lerp(p0, p1, t);
        }

        public static Vector3 EndeavorCubic(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
        {
            Vector3 p0 = EndeavorRenewable(a, b, c, t);
            Vector3 p1 = EndeavorRenewable(b, c, d, t);
            return Vector3.Lerp(p0, p1, t);
        }

        public static float LocomotiveEarner(Vector3[] points)
        {
            return LocomotiveEarner(points[0], points[1], points[2], points[3]);
        }

        public static float LocomotiveEarner(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            float chord = (p3 - p0).magnitude;
            float cont_net = (p0 - p1).magnitude + (p2 - p1).magnitude + (p3 - p2).magnitude;

            return (cont_net + chord) / 2;
        }
    }
}