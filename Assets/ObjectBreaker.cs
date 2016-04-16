using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectBreaker : MonoBehaviour
{
    float EPSILON = 0.000f;

    struct Polygon
    {
        public List<Vector3> vertices;
    };

    Vector3 Intersect( Vector3 v1, Vector3 v2, float da, float db )
    {
        return v1 + (da / (da - db)) * (v2 - v1);
    }

    List<Polygon> SutherlandHodgman(Vector3 normal, float D, Polygon poly)
    {
        Polygon frontPoly; frontPoly.vertices = new List<Vector3>();
        Polygon backPoly; backPoly.vertices = new List<Vector3>();
        int numVerts = poly.vertices.Count;

        Vector3 v1 = poly.vertices[numVerts - 1];
        float distV1 = Vector3.Dot(normal, v1) - D;

        for (int ii = 0; ii < numVerts; ii++)
        {
            Vector3 v2 = poly.vertices[ii];
            float distV2 = Vector3.Dot(normal, v2) - D;

            if (distV2 > EPSILON)
            {
                if (distV1 < - EPSILON)
                {
                    Vector3 i = Intersect(v2, v1, distV2, distV1);
                    float di = Vector3.Dot(normal, i) - D;

                    frontPoly.vertices.Add(i);
                    backPoly.vertices.Add(i);
                }

                frontPoly.vertices.Add(v2);
            }
            else if (distV2 < -EPSILON)
            {
                if (distV1 > EPSILON)
                {
                    Vector3 i = Intersect(v1, v2, distV1, distV2);
                    float di = Vector3.Dot(normal, i) - D;

                    frontPoly.vertices.Add(i);
                    backPoly.vertices.Add(i);
                }
                else if (distV1 < EPSILON && distV1 > -EPSILON)
                    backPoly.vertices.Add(v1);

                backPoly.vertices.Add(v2);
            }
            else
            {
                frontPoly.vertices.Add(v2);

                if (distV1 < EPSILON && distV1 > -EPSILON)
                    backPoly.vertices.Add(v1);
            }

            v1 = v2;
            distV1 = distV2;
        }

        List<Polygon> newPolygons = new List<Polygon>();
        if (frontPoly.vertices.Count > 0)
            newPolygons.Add(frontPoly);
        //if (backPoly.vertices.Count > 0)
          //  newPolygons.Add(backPoly);

        return newPolygons;
    }

    List<int> Triangulate(Polygon poly, int index)
    {
        List<int> indicies = new List<int>();

        for (int i = 1, j = 2; j < poly.vertices.Count; i = j , j++)
        {
            indicies.Add(0 + index);
            indicies.Add(i + index);
            indicies.Add(j + index);
        }

        return indicies;
    }

// Update is called once per frame
void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Mesh m = GetComponent<MeshFilter>().mesh;

            int[] triangles = m.triangles;
            Vector3[] vertices = m.vertices;

            Vector3 normal = Vector3.one.normalized;
            Vector3 point = Vector3.zero;
            float D = Vector3.Dot(point, normal);

            List<Polygon> newPolygons = new List<Polygon>();
            Polygon tmpPoly; tmpPoly.vertices = new List<Vector3>();
            for (int i = 0; i < triangles.Length; i += 3)
            {
                tmpPoly.vertices = new List<Vector3>();
                tmpPoly.vertices.Add(vertices[triangles[i]]);
                tmpPoly.vertices.Add(vertices[triangles[i+1]]);
                tmpPoly.vertices.Add(vertices[triangles[i+2]]);
                newPolygons.AddRange(SutherlandHodgman(normal, D, tmpPoly));
            }

            List<int> newTriangles = new List<int>();
            List<Vector3> newVertices = new List<Vector3>();
            int index = 0;

            foreach (Polygon p in newPolygons)
            {
                newVertices.AddRange(p.vertices);
                newTriangles.AddRange(Triangulate(p, index));
                index += p.vertices.Count;
            }

            GetComponent<MeshFilter>().mesh.vertices = newVertices.ToArray();
            GetComponent<MeshFilter>().mesh.triangles = newTriangles.ToArray();
        }
    }
}
