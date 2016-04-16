using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectBreaker : MonoBehaviour
{
    float EPSILON = 0.000f;
    bool doBreak = true;
    bool currentSpace = false; bool oldSpace = false;

    struct Polygon
    {
        public List<Vector3> vertices;
    };

    Vector3 Intersect(Vector3 v1, Vector3 v2, float da, float db)
    {
        return v1 + (da / (da - db)) * (v2 - v1);
    }

    void SutherlandHodgman(Vector3 normal, float D, Polygon poly, ref Polygon interSectPoly, out Polygon frontPoly, out Polygon backPoly)
    {
        frontPoly.vertices = new List<Vector3>();
        backPoly.vertices = new List<Vector3>();
        int numVerts = poly.vertices.Count;

        Vector3 v1 = poly.vertices[numVerts - 1];
        float distV1 = Vector3.Dot(normal, v1) - D;

        for (int ii = 0; ii < numVerts; ii++)
        {
            Vector3 v2 = poly.vertices[ii];
            float distV2 = Vector3.Dot(normal, v2) - D;

            if (distV2 > EPSILON)
            {
                if (distV1 < -EPSILON)
                {
                    Vector3 i = Intersect(v2, v1, distV2, distV1);
                    float di = Vector3.Dot(normal, i) - D;

                    frontPoly.vertices.Add(i);
                    backPoly.vertices.Add(i);
                    interSectPoly.vertices.Add(i);
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
                    interSectPoly.vertices.Add(i);
                }
                else if (distV1 < EPSILON && distV1 > -EPSILON)
                {
                    backPoly.vertices.Add(v1);
                    //interSectPoly.vertices.Add(v1);
                }

                backPoly.vertices.Add(v2);
            }
            else
            {
                frontPoly.vertices.Add(v2);

                if (distV1 < EPSILON && distV1 > -EPSILON)
                {
                    backPoly.vertices.Add(v1);
                    // interSectPoly.vertices.Add(v1);
                }
            }

            v1 = v2;
            distV1 = distV2;
        }
    }

    void Triangulate(Polygon poly, int index, out List<int> triangles)
    {
        triangles = new List<int>();

        for (int i = 1, j = 2; j < poly.vertices.Count; i = j, j++)
        {
            Vector3 v1 = poly.vertices[i] - poly.vertices[0];
            Vector3 v2 = poly.vertices[j] - poly.vertices[0];
            Vector3 n = Vector3.Cross(v1, v2).normalized;

            triangles.Add(0 + index);
            triangles.Add(i + index);
            triangles.Add(j + index);
        }
    }

    void Triangulate(Polygon poly, int index, Vector3 normal, out List<int> triangles)
    {
        triangles = new List<int>();

        for (int i = 1, j = 2; j < poly.vertices.Count; i = j, j++)
        {
            Vector3 v1 = poly.vertices[i] - poly.vertices[0];
            Vector3 v2 = poly.vertices[j] - poly.vertices[0];
            Vector3 n = Vector3.Cross(v1, v2).normalized;
            float d = Vector3.Dot(n, normal);

            if (d >= 0)
            {
                triangles.Add(0 + index);
                triangles.Add(i + index);
                triangles.Add(j + index);
            }
            else
            {
                triangles.Add(i + index);
                triangles.Add(0 + index);
                triangles.Add(j + index);
            }
        }
    }

    void Fracture(Mesh m, Vector3 point, Vector3 normal)
    {
        int[] triangles = m.triangles;
        Vector3[] vertices = m.vertices;

        float D = Vector3.Dot(point, normal);

        List<Polygon> topPolygons = new List<Polygon>();
        List<Polygon> bottomPolygons = new List<Polygon>();
        Polygon intersectPoly; intersectPoly.vertices = new List<Vector3>();
        Polygon tmpInput, tmpAbove, tmpBelow; tmpInput.vertices = new List<Vector3>();

        for (int i = 0; i < triangles.Length; i += 3)
        {
            tmpInput.vertices = new List<Vector3>();
            tmpInput.vertices.Add(vertices[triangles[i]]);
            tmpInput.vertices.Add(vertices[triangles[i + 1]]);
            tmpInput.vertices.Add(vertices[triangles[i + 2]]);

            SutherlandHodgman(normal, D, tmpInput, ref intersectPoly, out tmpAbove, out tmpBelow);
            topPolygons.Add(tmpAbove);
            bottomPolygons.Add(tmpBelow);
        }

        List<int> newTriangles = new List<int>();
        List<int> tmpTriangles = new List<int>();
        List<Vector3> newNormals = new List<Vector3>();
        List<Vector3> newVertices = new List<Vector3>();
        int index = 0;

        foreach (Polygon p in bottomPolygons)
        {
            newVertices.AddRange(p.vertices);
            newNormals.AddRange(p.vertices);

            Triangulate(p, index, out tmpTriangles);
            newTriangles.AddRange(tmpTriangles);

            index += p.vertices.Count;
        }
        newVertices.AddRange(intersectPoly.vertices);
        newNormals.AddRange(intersectPoly.vertices);

        Triangulate(intersectPoly, index, normal, out tmpTriangles);
        newTriangles.AddRange(tmpTriangles);

        m.vertices = newVertices.ToArray();
        m.normals = newNormals.ToArray();
        m.triangles = newTriangles.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpace = Input.GetKey(KeyCode.Space);
        if (currentSpace && currentSpace != oldSpace && doBreak)
        {
            //Vector3 normal = new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f).normalized;
            //Vector3 point = normal * Random.value;
            //Fracture(point, normal);
            Mesh thisMesh = GetComponent<MeshFilter>().mesh;
            
            List<Vector3> fracturePoints = new List<Vector3>();
            List<GameObject> cubes = new List<GameObject>();

            fracturePoints.Add(new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f) * 0.1f);
            fracturePoints.Add(new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f) * 0.1f);
            fracturePoints.Add(new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f) * 0.1f);
            fracturePoints.Add(new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f) * 0.1f);
            fracturePoints.Add(new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f) * 0.1f);

            for (int i = 0; i < fracturePoints.Count; i++)
            {
                cubes.Add(Instantiate(this.gameObject));
                cubes[i].GetComponent<ObjectBreaker>().doBreak = false;
                Mesh m = cubes[i].GetComponent<MeshFilter>().mesh;

                for (int j = 0; j < fracturePoints.Count; j++)
                {
                    if (i != j)
                    {
                        Vector3 point = (fracturePoints[i] + fracturePoints[j]) / 2;
                        Vector3 normal = (fracturePoints[j] - fracturePoints[i]).normalized;        

                        Fracture(m, point, normal);
                    }
                }

                cubes[i].transform.position = cubes[i].transform.position + (fracturePoints[i] - this.transform.position).normalized * 0.005f;
                cubes[i].GetComponent<MeshCollider>().sharedMesh = m;
            }
            Destroy(this.gameObject);
        }
        oldSpace = currentSpace;
    }
}
