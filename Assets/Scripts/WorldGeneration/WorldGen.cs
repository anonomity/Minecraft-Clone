using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
	[SerializeField]

	public int width;
	public int height;
	public float scale;

	private float noiseScale = 1f;
	// Start is called before the first frame update
	void Start()
	{

		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		for (int x = 0; x < width; x++)
		{
			for (int z = 0; z < width; z++)
			{
				for (int y = 0; y < height; y++)
				{



					if ((Perlin3D(x, y) * (float)height) > y)
					{
						Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
					}
				}
			}

		}

	}

	public float Perlin3D(int x, int y)
	{
		float Nwidth = (float)width;
		float Nheight = (float)height;
		float newx = (float)x;
		float newy = (float)y;

		float X = (float)(newx / Nwidth);
		float Y = (float)(newy / Nwidth);


		float t = Mathf.PerlinNoise(X * scale, Y * scale);
		// Debug.Log(t);
		return t;




	}

}
